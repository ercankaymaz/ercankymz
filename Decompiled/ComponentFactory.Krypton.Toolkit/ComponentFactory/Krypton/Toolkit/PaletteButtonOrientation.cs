using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(PaletteButtonOrientationConverter))]
public enum PaletteButtonOrientation
{
	Inherit,
	Auto,
	FixedTop,
	FixedBottom,
	FixedLeft,
	FixedRight
}
