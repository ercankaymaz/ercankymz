using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(TabBorderStyleConverter))]
public enum TabBorderStyle
{
	SquareEqualSmall,
	SquareEqualMedium,
	SquareEqualLarge,
	SquareOutsizeSmall,
	SquareOutsizeMedium,
	SquareOutsizeLarge,
	RoundedEqualSmall,
	RoundedEqualMedium,
	RoundedEqualLarge,
	RoundedOutsizeSmall,
	RoundedOutsizeMedium,
	RoundedOutsizeLarge,
	SlantEqualNear,
	SlantEqualFar,
	SlantEqualBoth,
	SlantOutsizeNear,
	SlantOutsizeFar,
	SlantOutsizeBoth,
	OneNote,
	SmoothEqual,
	SmoothOutsize,
	DockEqual,
	DockOutsize
}
