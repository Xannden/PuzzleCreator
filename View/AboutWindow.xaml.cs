using System;
using System.Windows;

namespace PuzzleCreator.View
{
	/// <summary>
	/// Interaction logic for AboutWindow.xaml
	/// </summary>
	public partial class AboutWindow : Window
	{
		public AboutWindow()
		{
			this.InitializeComponent();
			this.DataContext = this;
		}

		public string Version
		{
			get
			{
				Version version = typeof(AboutWindow).Assembly.GetName().Version;

				return $"{version.Major}.{version.Minor}.{version.Build}";
			}
		}
	}
}