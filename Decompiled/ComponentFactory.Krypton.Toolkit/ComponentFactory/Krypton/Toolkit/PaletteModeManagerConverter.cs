namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteModeManagerConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[11]
	{
		new Pair(PaletteModeManager.ProfessionalSystem, "Professional - System"),
		new Pair(PaletteModeManager.ProfessionalOffice2003, "Professional - Office 2003"),
		new Pair(PaletteModeManager.Office2007Blue, "Office 2007 - Blue"),
		new Pair(PaletteModeManager.Office2007Silver, "Office 2007 - Silver"),
		new Pair(PaletteModeManager.Office2007Black, "Office 2007 - Black"),
		new Pair(PaletteModeManager.Office2010Blue, "Office 2010 - Blue"),
		new Pair(PaletteModeManager.Office2010Silver, "Office 2010 - Silver"),
		new Pair(PaletteModeManager.Office2010Black, "Office 2010 - Black"),
		new Pair(PaletteModeManager.SparkleBlue, "Sparkle - Blue"),
		new Pair(PaletteModeManager.SparkleOrange, "Sparkle - Orange"),
		new Pair(PaletteModeManager.SparklePurple, "Sparkle - Purple")
	};

	protected override Pair[] Pairs => _pairs;

	public PaletteModeManagerConverter()
		: base(typeof(PaletteModeManager))
	{
	}
}
