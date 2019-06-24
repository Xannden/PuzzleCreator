namespace PuzzleCreator.ViewModel
{
	public class BoardCell : BaseViewModel
	{
		private CellType type;
		public CellType Type
		{
			get => this.type;
			set => this.SetField(ref this.type, value);
		}

		public BoardCell()
		{
		}
	}
}