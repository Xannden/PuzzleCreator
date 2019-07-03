using System.Windows;
using System.Windows.Controls;

using XannLib.Update;

namespace PuzzleCreator
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			new GithubUpdater("https://raw.githubusercontent.com/Xannden/PuzzleCreator/master/UpdateInfo.json", "PuzzleCreator.exe").Run();

			EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(this.TextBox_GotFocus));

			base.OnStartup(e);
		}

		private void TextBox_GotFocus(object sender, RoutedEventArgs e) => (sender as TextBox)?.SelectAll();
	}
}