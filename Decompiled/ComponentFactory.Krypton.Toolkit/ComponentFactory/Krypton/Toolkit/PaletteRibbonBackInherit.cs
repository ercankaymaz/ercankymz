using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class PaletteRibbonBackInherit : GlobalId, IPaletteRibbonBack
{
	public abstract PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteState state);

	public abstract Color GetRibbonBackColor1(PaletteState state);

	public abstract Color GetRibbonBackColor2(PaletteState state);

	public abstract Color GetRibbonBackColor3(PaletteState state);

	public abstract Color GetRibbonBackColor4(PaletteState state);

	public abstract Color GetRibbonBackColor5(PaletteState state);
}
