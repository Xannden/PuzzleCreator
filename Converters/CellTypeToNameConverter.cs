using System;
using System.Globalization;
using System.Windows.Data;
using PuzzleCreator.ViewModel;

namespace PuzzleCreator.Converters
{
	public sealed class CellTypeToNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			CellType type = (CellType)value;

			return type.GetName();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
	}
}