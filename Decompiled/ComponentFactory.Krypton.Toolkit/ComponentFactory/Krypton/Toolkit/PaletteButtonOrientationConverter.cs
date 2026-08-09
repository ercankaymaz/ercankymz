namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteButtonOrientationConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[6]
	{
		new Pair(PaletteButtonOrientation.Inherit, "Inherit"),
		new Pair(PaletteButtonOrientation.Auto, "Auto"),
		new Pair(PaletteButtonOrientation.FixedTop, "Fixed Top"),
		new Pair(PaletteButtonOrientation.FixedBottom, "Fixed Bottom"),
		new Pair(PaletteButtonOrientation.FixedLeft, "Fixed Left"),
		new Pair(PaletteButtonOrientation.FixedRight, "Fixed Right")
	};

	protected override Pair[] Pairs => _pairs;

	public PaletteButtonOrientationConverter()
		: base(typeof(PaletteButtonOrientation))
	{
	}
}
