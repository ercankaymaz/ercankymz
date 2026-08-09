namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteTextTrimConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[7]
	{
		new Pair(PaletteTextTrim.Inherit, "Inherit"),
		new Pair(PaletteTextTrim.Hide, "Hide"),
		new Pair(PaletteTextTrim.Character, "Character"),
		new Pair(PaletteTextTrim.Word, "Word"),
		new Pair(PaletteTextTrim.EllipsisCharacter, "Ellipsis Character"),
		new Pair(PaletteTextTrim.EllipsisWord, "Ellipsis Word"),
		new Pair(PaletteTextTrim.EllipsisPath, "Ellipsis Path")
	};

	protected override Pair[] Pairs => _pairs;

	public PaletteTextTrimConverter()
		: base(typeof(PaletteTextTrim))
	{
	}
}
