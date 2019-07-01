using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PuzzleCreator.ViewModel;

namespace PuzzleCreator.Converters
{
	public sealed class CellTypeToImageConverter : IValueConverter
	{
		private static readonly Dictionary<CellType, ImageSource> cache = new Dictionary<CellType, ImageSource>();

		public static ImageSource Convert(CellType type)
		{
			if (!cache.TryGetValue(type, out ImageSource source))
			{
				source = new BitmapImage(new Uri("pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name + ";component/" + type.GetFileName(), UriKind.Absolute));

				cache.Add(type, source);
			}

			return source;
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => Convert((CellType)value);

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
	}
}