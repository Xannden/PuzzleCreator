using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PuzzleCreator
{
	public class UniformSquareGrid : Control
	{
		private VisualCollection visuals;
		private List<UIElement> children = new List<UIElement>();

		public UniformSquareGrid()
		{
			this.visuals = new VisualCollection(this);
		}

		public static readonly DependencyProperty RowsProperty = DependencyProperty.Register(nameof(Rows), typeof(uint), typeof(UniformSquareGrid), new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, RowColoumnChanged));

		public uint Rows
		{
			get => (uint)this.GetValue(RowsProperty);
			set => this.SetValue(RowsProperty, value);
		}

		public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(nameof(Columns), typeof(uint), typeof(UniformSquareGrid), new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, RowColoumnChanged));

		public uint Columns
		{
			get => (uint)this.GetValue(ColumnsProperty);
			set => this.SetValue(ColumnsProperty, value);
		}

		private static void RowColoumnChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			UniformSquareGrid b = sender as UniformSquareGrid;

			if (b.children.Count != b.Rows * b.Columns)
			{
				b.children.Clear();
				b.visuals.Clear();

				for (int i = 0; i < b.Rows * b.Columns; i++)
				{
					object elem = b.CreateElement();

					UniformSquareGridItem item = new UniformSquareGridItem()
					{
						Content = elem,
					};

					if (elem == null)
					{
						continue;
					}

					b.children.Add(item);
					b.visuals.Add(item);
				}
			}
		}

		protected virtual object CreateElement()
		{
			return null;
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			Size cellSize = this.GetCellSize(availableSize);

			for (int i = 0; i < this.children.Count; i++)
			{
				(int row, int column) = this.GetPos(i);

				if (row >= this.Rows || column > this.Columns)
				{
					continue;
				}

				this.children[i].Measure(cellSize);
			}

			return new Size(cellSize.Width * this.Columns, cellSize.Height * this.Rows);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			Size cellSize = this.GetCellSize(finalSize);

			for (int i = 0; i < this.children.Count; i++)
			{
				(int row, int column) = this.GetPos(i);

				if (row >= this.Rows || column > this.Columns)
				{
					this.children[i].Arrange(new Rect(0, 0, 0, 0));
				}
				else
				{
					double x = column * cellSize.Width;
					double y = row * cellSize.Height;

					this.children[i].Arrange(new Rect(x, y, cellSize.Width, cellSize.Height));
				}
			}

			return finalSize;
		}

		protected override int VisualChildrenCount => this.visuals.Count;

		protected override Visual GetVisualChild(int index) => this.visuals[index];

		private Size GetCellSize(Size availableSize)
		{
			double max = Math.Min(availableSize.Width / this.Columns, availableSize.Height / this.Rows);

			return new Size(max, max);
		}

		private (int row, int column) GetPos(int index)
		{
			return (index / (int)this.Columns, index % (int)this.Columns);
		}
	}

	public class UniformSquareGridItem : ContentControl
	{
	}
}