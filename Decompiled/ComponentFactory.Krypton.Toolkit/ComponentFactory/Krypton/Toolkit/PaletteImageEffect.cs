using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(PaletteImageEffectConverter))]
public enum PaletteImageEffect
{
	Inherit,
	Normal,
	Disabled,
	GrayScale,
	GrayScaleRed,
	GrayScaleGreen,
	GrayScaleBlue,
	Light,
	LightLight,
	Dark,
	DarkDark
}
