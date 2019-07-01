using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows;
using PuzzleCreator.View;
using PuzzleCreator.ViewModel;

namespace PuzzleCreator
{
	public static class Exporter
	{
		private const int ImageSize = 64;

		public static void Export(Board board, string file)
		{
			StringFormat format = new StringFormat()
			{
				Alignment = StringAlignment.Center,
			};

			int width = ImageSize * (int)board.Columns;
			int height = ImageSize * (int)board.Rows;
			bool hasTitle = !string.IsNullOrEmpty(board.Title);

			if (hasTitle)
			{
				height += 31;
			}

			using Font titleFont = new Font(new FontFamily(GenericFontFamilies.SansSerif), 15);
			using Bitmap bitmap = new Bitmap(width, height);

			using (Graphics g = Graphics.FromImage(bitmap))
			{
				int x = 0;
				int y = 0;

				if (hasTitle)
				{
					g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, width, 28));
					g.DrawString(board.Title, titleFont, Brushes.White, new RectangleF(0, 0, width, 28), format);

					g.DrawLine(new Pen(Color.Gray, 1f), 0, 28, width, 28);
					g.DrawLine(new Pen(Color.White, 1f), 0, 29, width, 29);
					g.DrawLine(new Pen(Color.Gray, 1f), 0, 30, width, 30);

					y += 31;
				}

				for (int row = 0; row < board.Rows; row++)
				{
					for (int column = 0; column < board.Columns; column++)
					{
						BoardCell cell = board.GetCell(row, column);

						if (cell.Type == CellType.Blank)
						{
							g.FillRectangle(new SolidBrush(Color.Gray), x, y, ImageSize, ImageSize);
							g.DrawRectangle(new Pen(Color.Black, -1), x, y, ImageSize - 1, ImageSize - 1);
						}
						else if (cell.Type != CellType.Empty)
						{
							Image image = GetImage(cell.Type);

							switch (cell.Rotation)
							{
								case 90:
									image.RotateFlip(RotateFlipType.Rotate90FlipNone);
									break;

								case 180:
									image.RotateFlip(RotateFlipType.Rotate180FlipNone);
									break;

								case 270:
									image.RotateFlip(RotateFlipType.Rotate270FlipNone);
									break;
							}

							g.DrawImage(image, x, y, ImageSize, ImageSize);
						}

						x = (x + ImageSize) % width;
					}

					y += ImageSize;
				}
			}

			bitmap.Save(file);
		}

		private static Image GetImage(CellType type)
		{
			Stream stream = Application.GetResourceStream(GetImageUri(type.GetFileName())).Stream;

			return Image.FromStream(stream);
		}

		private static Uri GetImageUri(string fileName)
			=> new Uri(fileName, UriKind.Relative);
	}
}