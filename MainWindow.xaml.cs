using System.ComponentModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using PuzzleCreator.View;

namespace PuzzleCreator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private int rows;
		private int columns;
		private string initialDirectory;

		public event PropertyChangedEventHandler PropertyChanged;

		public MainWindow()
		{
			this.InitializeComponent();
			this.DataContext = this;
		}

		private void New_Click(object sender, RoutedEventArgs e)
		{
			DialogWindow window = new DialogWindow()
			{
				Owner = this,
			};

			bool? result = window.ShowDialog();

			if (result ?? false)
			{
				this.Rows = window.Rows;
				this.Columns = window.Columns;
			}
		}

		private void Export_Click(object sender, RoutedEventArgs e)
		{
			if (this.Board.Rows == 0 || this.Board.Columns == 0)
			{
				return;
			}

			SaveFileDialog dialog = new SaveFileDialog
			{
				AddExtension = true,
				DefaultExt = ".png",
				Filter = "PNG (*.png)|*.png",
				OverwritePrompt = true,
				ValidateNames = true,
			};

			if (!string.IsNullOrEmpty(this.initialDirectory))
			{
				dialog.InitialDirectory = this.initialDirectory;
			}

			bool? result = dialog.ShowDialog();

			if (result.HasValue && result == true)
			{
				this.initialDirectory = Path.GetDirectoryName(dialog.FileName);

				Exporter.Export(this.Board, dialog.FileName);
			}
		}

		private void Exit_Click(object sender, RoutedEventArgs e) => this.Close();

		public int Rows
		{
			get => this.rows;

			set
			{
				this.rows = value;

				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Rows)));
			}
		}

		public int Columns
		{
			get => this.columns;

			set
			{
				this.columns = value;

				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Columns)));
			}
		}

		private void Title_Click(object sender, RoutedEventArgs e)
		{
			TitleWindow window = new TitleWindow(this.Board.Title)
			{
				Owner = this,
			};

			bool? result = window.ShowDialog();

			if (result ?? false)
			{
				this.Board.Title = window.BoardTitle;
			}
		}

		private void About_Click(object sender, RoutedEventArgs e) => _ = new AboutWindow()
		{
			Owner = this,
		}.ShowDialog();
	}
}