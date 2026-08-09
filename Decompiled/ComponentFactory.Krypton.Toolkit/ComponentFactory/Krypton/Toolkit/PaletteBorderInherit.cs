using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class PaletteBorderInherit : GlobalId, IPaletteBorder
{
	public abstract InheritBool GetBorderDraw(PaletteState state);

	public abstract PaletteDrawBorders GetBorderDrawBorders(PaletteState state);

	public abstract PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state);

	public abstract Color GetBorderColor1(PaletteState state);

	public abstract Color GetBorderColor2(PaletteState state);

	public abstract PaletteColorStyle GetBorderColorStyle(PaletteState state);

	public abstract PaletteRectangleAlign GetBorderColorAlign(PaletteState state);

	public abstract float GetBorderColorAngle(PaletteState state);

	public abstract int GetBorderWidth(PaletteState state);

	public abstract int GetBorderRounding(PaletteState state);

	public abstract Image GetBorderImage(PaletteState state);

	public abstract PaletteImageStyle GetBorderImageStyle(PaletteState state);

	public abstract PaletteRectangleAlign GetBorderImageAlign(PaletteState state);
}
