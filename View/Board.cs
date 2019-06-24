namespace PuzzleCreator.View
{
	public class Board : UniformSquareGrid
	{
		protected override object CreateElement() => new ViewModel.BoardCell();
	}
}