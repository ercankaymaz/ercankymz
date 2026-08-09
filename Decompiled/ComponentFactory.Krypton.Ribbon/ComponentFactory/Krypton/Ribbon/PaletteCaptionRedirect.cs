using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class PaletteCaptionRedirect : PaletteRedirect
{
	public PaletteCaptionRedirect(IPalette target)
		: base(target)
	{
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		PaletteDrawBorders borderDrawBorders = base.GetBorderDrawBorders(style, state);
		if ((borderDrawBorders & PaletteDrawBorders.Bottom) == PaletteDrawBorders.Bottom)
		{
			return PaletteDrawBorders.Bottom;
		}
		return PaletteDrawBorders.None;
	}
}
