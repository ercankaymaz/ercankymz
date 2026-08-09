using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(PaletteImageStyleConverter))]
public enum PaletteImageStyle
{
	Inherit,
	TopLeft,
	TopMiddle,
	TopRight,
	CenterLeft,
	CenterMiddle,
	CenterRight,
	BottomLeft,
	BottomMiddle,
	BottomRight,
	Stretch,
	Tile,
	TileFlipX,
	TileFlipY,
	TileFlipXY
}
