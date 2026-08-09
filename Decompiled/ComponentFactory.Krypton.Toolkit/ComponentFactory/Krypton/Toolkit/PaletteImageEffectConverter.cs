namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteImageEffectConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[11]
	{
		new Pair(PaletteImageEffect.Inherit, "Inherit"),
		new Pair(PaletteImageEffect.Light, "Light"),
		new Pair(PaletteImageEffect.LightLight, "LightLight"),
		new Pair(PaletteImageEffect.Normal, "Normal"),
		new Pair(PaletteImageEffect.Disabled, "Disabled"),
		new Pair(PaletteImageEffect.Dark, "Dark"),
		new Pair(PaletteImageEffect.DarkDark, "DarkDark"),
		new Pair(PaletteImageEffect.GrayScale, "GrayScale"),
		new Pair(PaletteImageEffect.GrayScaleRed, "GrayScale - Red"),
		new Pair(PaletteImageEffect.GrayScaleGreen, "GrayScale - Green"),
		new Pair(PaletteImageEffect.GrayScaleBlue, "GrayScale - Blue")
	};

	protected override Pair[] Pairs => _pairs;

	public PaletteImageEffectConverter()
		: base(typeof(PaletteImageEffect))
	{
	}
}
