using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PuzzleCreator
{
	public class UniformSquareGrid : Control
	{
		private readonly VisualCollection visuals;
		private readonly List<UIElement> children = new List<UIElement>();

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

		public UniformSquareGridItem GetItem(int row, int column) => (UniformSquareGridItem)this.children[column + (row * (int)this.Columns)];

		private static void RowColoumnChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			UniformSquareGrid b = sender as UniformSquareGrid;

			long diff = b.children.Count - (b.Rows * b.Columns);

			if (diff > 0)
			{
				b.children.RemoveRange(b.children.Count - (int)diff, (int)diff);
				b.visuals.RemoveRange(b.visuals.Count - (int)diff, (int)diff);
			}
			else if (diff < 0)
			{
				for (int i = 0; i < Math.Abs(diff); i++)
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

			b.Resize();
		}

		protected virtual void Resize()
		{
		}

		protected virtual object CreateElement() => null;

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
			if (this.Columns == 0 || this.Rows == 0)
			{
				return new Size(0, 0);
			}

			double max = Math.Min(availableSize.Width / this.Columns, availableSize.Height / this.Rows);

			return new Size(max, max);
		}

		private (int row, int column) GetPos(int index) => (index / (int)this.Columns, index % (int)this.Columns);
	}

	public class UniformSquareGridItem : ContentControl
	{
	}
}