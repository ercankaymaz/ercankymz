using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteBack
{
	InheritBool GetBackDraw(PaletteState state);

	PaletteGraphicsHint GetBackGraphicsHint(PaletteState state);

	Color GetBackColor1(PaletteState state);

	Color GetBackColor2(PaletteState state);

	PaletteColorStyle GetBackColorStyle(PaletteState state);

	PaletteRectangleAlign GetBackColorAlign(PaletteState state);

	float GetBackColorAngle(PaletteState state);

	Image GetBackImage(PaletteState state);

	PaletteImageStyle GetBackImageStyle(PaletteState state);

	PaletteRectangleAlign GetBackImageAlign(PaletteState state);
}
