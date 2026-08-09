namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteImageStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[15]
	{
		new Pair(PaletteImageStyle.Inherit, "Inherit"),
		new Pair(PaletteImageStyle.Stretch, "Stretch"),
		new Pair(PaletteImageStyle.Tile, "Tile"),
		new Pair(PaletteImageStyle.TileFlipX, "TileFlip - X"),
		new Pair(PaletteImageStyle.TileFlipY, "TileFlip - Y"),
		new Pair(PaletteImageStyle.TileFlipXY, "TileFlip - XY"),
		new Pair(PaletteImageStyle.TopLeft, "Top - Left"),
		new Pair(PaletteImageStyle.TopMiddle, "Top - Middle"),
		new Pair(PaletteImageStyle.TopRight, "Top - Right"),
		new Pair(PaletteImageStyle.CenterLeft, "Center - Left"),
		new Pair(PaletteImageStyle.CenterMiddle, "Center - Middle"),
		new Pair(PaletteImageStyle.CenterRight, "Center - Right"),
		new Pair(PaletteImageStyle.BottomLeft, "Bottom - Left"),
		new Pair(PaletteImageStyle.BottomMiddle, "Bottom - Middle"),
		new Pair(PaletteImageStyle.BottomRight, "Bottom - Right")
	};

	protected override Pair[] Pairs => _pairs;

	public PaletteImageStyleConverter()
		: base(typeof(PaletteImageStyle))
	{
	}
}
