namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteModeConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[11]
	{
		new Pair(PaletteMode.ProfessionalSystem, "Professional - System"),
		new Pair(PaletteMode.ProfessionalOffice2003, "Professional - Office 2003"),
		new Pair(PaletteMode.Office2007Blue, "Office 2007 - Blue"),
		new Pair(PaletteMode.Office2007Silver, "Office 2007 - Silver"),
		new Pair(PaletteMode.Office2007Black, "Office 2007 - Black"),
		new Pair(PaletteMode.Office2010Blue, "Office 2010 - Blue"),
		new Pair(PaletteMode.Office2010Silver, "Office 2010 - Silver"),
		new Pair(PaletteMode.Office2010Black, "Office 2010 - Black"),
		new Pair(PaletteMode.SparkleBlue, "Sparkle - Blue"),
		new Pair(PaletteMode.SparkleOrange, "Sparkle - Orange"),
		new Pair(PaletteMode.SparklePurple, "Sparkle - Purple")
	};

	protected override Pair[] Pairs => _pairs;

	public PaletteModeConverter()
		: base(typeof(PaletteMode))
	{
	}
}
