using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(PaletteTextTrimConverter))]
public enum PaletteTextTrim
{
	Inherit = -1,
	Hide,
	Character,
	Word,
	EllipsisCharacter,
	EllipsisWord,
	EllipsisPath
}
