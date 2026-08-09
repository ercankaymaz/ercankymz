using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class PaletteBackInherit : GlobalId, IPaletteBack
{
	public abstract InheritBool GetBackDraw(PaletteState state);

	public abstract PaletteGraphicsHint GetBackGraphicsHint(PaletteState state);

	public abstract Color GetBackColor1(PaletteState state);

	public abstract Color GetBackColor2(PaletteState state);

	public abstract PaletteColorStyle GetBackColorStyle(PaletteState state);

	public abstract PaletteRectangleAlign GetBackColorAlign(PaletteState state);

	public abstract float GetBackColorAngle(PaletteState state);

	public abstract Image GetBackImage(PaletteState state);

	public abstract PaletteImageStyle GetBackImageStyle(PaletteState state);

	public abstract PaletteRectangleAlign GetBackImageAlign(PaletteState state);
}
