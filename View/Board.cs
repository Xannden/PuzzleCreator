using System.Windows;
using PuzzleCreator.ViewModel;

namespace PuzzleCreator.View
{
	public class Board : UniformSquareGrid
	{
		public static readonly DependencyProperty SelectedToolProperty = DependencyProperty.Register(nameof(SelectedTool), typeof(Tool), typeof(Board));

		public Tool SelectedTool
		{
			get => (Tool)this.GetValue(SelectedToolProperty);
			set => this.SetValue(SelectedToolProperty, value);
		}

		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(Board));

		public string Title
		{
			get => (string)this.GetValue(TitleProperty);
			set => this.SetValue(TitleProperty, value);
		}

		public BoardCell GetCell(int row, int column) => (BoardCell)this.GetItem(row, column).Content;

		protected override object CreateElement() => new ViewModel.BoardCell(this);

		protected override void Resize()
		{
			for (int column = 0; column < this.Columns; column++)
			{
				for (int row = 0; row < this.Rows; row++)
				{
					this.GetCell(row, column).Type = CellType.Blank;
				}
			}
		}
	}
}