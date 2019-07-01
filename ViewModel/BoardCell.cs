using System.Windows.Input;
using PuzzleCreator.View;

namespace PuzzleCreator.ViewModel
{
	public class BoardCell : BaseViewModel
	{
		private CellType type = CellType.Blank;
		private double rotation = 0;
		private readonly Board board;

		public CellType Type
		{
			get => this.type;

			set
			{
				this.Rotation = 0;
				if (value == CellType.Cursor)
				{
					return;
				}

				this.SetField(ref this.type, value);
			}
		}

		public double Rotation
		{
			get => this.rotation;
			set => this.SetField(ref this.rotation, value);
		}

		public BoardCell(Board board)
		{
			this.board = board;
		}

		public ICommand MouseDownCommand => new DelegateCommand(this.MouseDown);

		private void MouseDown(object param) => this.Type = this.board.SelectedTool?.Type ?? CellType.Cursor;

		public ICommand RotateClockwiseCommand => new DelegateCommand(this.RotateClockwise);

		private void RotateClockwise(object param)
		{
			double rotation = this.rotation + 90;

			if (rotation >= 360)
			{
				rotation = 0;
			}

			this.Rotation = rotation;
		}

		public ICommand RotateCounterClockwiseCommand => new DelegateCommand(this.RotateCounterClockwise);

		private void RotateCounterClockwise(object param)
		{
			double rotation = this.rotation - 90;

			if (rotation < 0)
			{
				rotation = 270;
			}

			this.Rotation = rotation;
		}

		public ICommand DeleteCommand => new DelegateCommand(this.Delete);

		public void Delete(object param) => this.Type = CellType.Empty;
	}
}