using System.Collections.ObjectModel;
using System.Windows.Media;

namespace PuzzleCreator.ViewModel
{
	public class Tool
	{
		private bool nameSet;
		private string name;

		public CellType Type { get; set; }

		public string Name
		{
			get => this.nameSet ? this.name : this.Type.GetName();

			set
			{
				this.nameSet = true;
				this.name = value;
			}
		}

		public ObservableCollection<Tool> Tools { get; set; } = new ObservableCollection<Tool>();

		public bool IsLeaf => this.Tools.Count == 0;
	}
}
