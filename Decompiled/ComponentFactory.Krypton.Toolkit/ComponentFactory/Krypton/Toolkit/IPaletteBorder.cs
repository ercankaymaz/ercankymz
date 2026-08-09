using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteBorder
{
	InheritBool GetBorderDraw(PaletteState state);

	PaletteDrawBorders GetBorderDrawBorders(PaletteState state);

	PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state);

	Color GetBorderColor1(PaletteState state);

	Color GetBorderColor2(PaletteState state);

	PaletteColorStyle GetBorderColorStyle(PaletteState state);

	PaletteRectangleAlign GetBorderColorAlign(PaletteState state);

	float GetBorderColorAngle(PaletteState state);

	int GetBorderWidth(PaletteState state);

	int GetBorderRounding(PaletteState state);

	Image GetBorderImage(PaletteState state);

	PaletteImageStyle GetBorderImageStyle(PaletteState state);

	PaletteRectangleAlign GetBorderImageAlign(PaletteState state);
}
