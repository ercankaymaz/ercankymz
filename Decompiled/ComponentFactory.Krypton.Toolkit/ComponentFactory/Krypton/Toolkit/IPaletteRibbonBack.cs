using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteRibbonBack
{
	PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteState state);

	Color GetRibbonBackColor1(PaletteState state);

	Color GetRibbonBackColor2(PaletteState state);

	Color GetRibbonBackColor3(PaletteState state);

	Color GetRibbonBackColor4(PaletteState state);

	Color GetRibbonBackColor5(PaletteState state);
}
