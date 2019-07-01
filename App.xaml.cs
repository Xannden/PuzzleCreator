using System.Windows;
using System.Windows.Controls;
using Update;
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
			Updater updater = new GithubUpdater();

			if (updater.UpdateAvailable())
			{
				updater.Update();
				this.Shutdown();
			}

			EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(this.TextBox_GotFocus));

			base.OnStartup(e);
		}

		private void TextBox_GotFocus(object sender, RoutedEventArgs e) => (sender as TextBox)?.SelectAll();
	}
}