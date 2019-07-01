using System.Windows;
using System.Windows.Input;

namespace PuzzleCreator.View
{
	/// <summary>
	/// Interaction logic for TitleWindow.xaml
	/// </summary>
	public partial class TitleWindow : Window
	{
		public TitleWindow(string title)
		{
			this.InitializeComponent();

			this.BoardTitle = title;

			this.DataContext = this;
		}

		public string BoardTitle { get; set; }

		private void Create_Click(object sender, RoutedEventArgs e) => this.DialogResult = true;

		private void Cancel_Click(object sender, RoutedEventArgs e) => this.DialogResult = false;

		private void Window_Loaded(object sender, RoutedEventArgs e) => this.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
	}
}