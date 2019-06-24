using XannLib.Attributes;

namespace PuzzleCreator.ViewModel
{
	public enum CellType
	{
		[Icon("Blank", "Icons/blank.png")]
		Blank,

		[Icon("Start", "Icons/start.png")]
		Start,

		[Icon("Straight", "Icons/straight.png")]
		Straight,

		[Icon("Angle", "Icons/angle.png")]
		Angle,

		[Icon("T-Angle", "Icons/t_angle.png")]
		TAngle,

		[Icon("Cross", "Icons/cross.png")]
		Cross,

		[Icon("Rune 0 Through", "Icons/rune0_through.png")]
		Rune0Through,

		[Icon("Rune 0 End", "Icons/rune0_end.png")]
		Rune0End,

		[Icon("Rune 1 Through", "Icons/rune1_through.png")]
		Rune1Through,

		[Icon("Rune 1 End", "Icons/rune1_end.png")]
		Rune1End,

		[Icon("Rune 2 Through", "Icons/rune2_through.png")]
		Rune2Through,

		[Icon("Rune 2 End", "Icons/rune2_end.png")]
		Rune2End,

		[Icon("Rune 3 Through", "Icons/rune3_through.png")]
		Rune3Through,

		[Icon("Rune 3 End", "Icons/rune3_end.png")]
		Rune3End,

		[Icon("Rune 4 Through", "Icons/rune4_through.png")]
		Rune4Through,

		[Icon("Rune 4 End", "Icons/rune4_end.png")]
		Rune4End,

		[Icon("Rune 5 Through", "Icons/rune5_through.png")]
		Rune5Through,

		[Icon("Rune 5 End", "Icons/rune5_end.png")]
		Rune5End,

		[Icon("Blue Crystal", "Icons/blue_crystal.png")]
		BlueCrystal,

		[Icon("Green Crystal", "Icons/green_crystal.png")]
		GreenCrystal,

		[Icon("Red Crystal", "Icons/red_crystal.png")]
		RedCrystal,
	}

	public static class CellTypeExtensions
	{
		public static string GetName(this CellType cellType)
		{
			if (cellType.TryGetEnumAttribute(out IconAttribute icon))
			{
				return icon.Name;
			}

			return string.Empty;
		}

		public static string GetFileName(this CellType cellType)
		{
			if (cellType.TryGetEnumAttribute(out IconAttribute icon))
			{
				return icon.FileName;
			}

			return string.Empty;
		}
	}
}