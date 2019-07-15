using System.Windows;
using System.Windows.Input;

namespace PuzzleCreator.View
{
	/// <summary>
	/// Interaction logic for DialogWindow.xaml
	/// </summary>
	public partial class DialogWindow : Window
	{
		public DialogWindow()
		{
			this.InitializeComponent();
			this.DataContext = this;
		}

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			if (this.Rows * this.Columns <= 2500)
			{
				this.DialogResult = true;
			}
			else
			{
				this.Error.Visibility = Visibility.Visible;
			}
		}

		private void Cancel_Click(object sender, RoutedEventArgs e) => this.DialogResult = false;

		public int Rows { get; set; }

		public int Columns { get; set; }

		private void Window_Loaded(object sender, RoutedEventArgs e) => this.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
	}
}