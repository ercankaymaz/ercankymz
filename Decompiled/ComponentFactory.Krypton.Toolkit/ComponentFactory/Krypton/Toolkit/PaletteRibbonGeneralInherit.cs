using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class PaletteRibbonGeneralInherit : GlobalId, IPaletteRibbonGeneral
{
	public abstract PaletteRibbonShape GetRibbonShape();

	public abstract PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state);

	public abstract Font GetRibbonContextTextFont(PaletteState state);

	public abstract Color GetRibbonContextTextColor(PaletteState state);

	public abstract Color GetRibbonDisabledDark(PaletteState state);

	public abstract Color GetRibbonDisabledLight(PaletteState state);

	public abstract Color GetRibbonGroupDialogDark(PaletteState state);

	public abstract Color GetRibbonGroupDialogLight(PaletteState state);

	public abstract Color GetRibbonDropArrowDark(PaletteState state);

	public abstract Color GetRibbonDropArrowLight(PaletteState state);

	public abstract Color GetRibbonGroupSeparatorDark(PaletteState state);

	public abstract Color GetRibbonGroupSeparatorLight(PaletteState state);

	public abstract Color GetRibbonMinimizeBarDark(PaletteState state);

	public abstract Color GetRibbonMinimizeBarLight(PaletteState state);

	public abstract Color GetRibbonTabSeparatorColor(PaletteState state);

	public abstract Color GetRibbonTabSeparatorContextColor(PaletteState state);

	public abstract Font GetRibbonTextFont(PaletteState state);

	public abstract PaletteTextHint GetRibbonTextHint(PaletteState state);

	public abstract Color GetRibbonQATButtonDark(PaletteState state);

	public abstract Color GetRibbonQATButtonLight(PaletteState state);
}
