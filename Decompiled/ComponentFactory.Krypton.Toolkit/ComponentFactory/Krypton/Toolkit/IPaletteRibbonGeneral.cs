using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteRibbonGeneral
{
	PaletteRibbonShape GetRibbonShape();

	PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state);

	Font GetRibbonContextTextFont(PaletteState state);

	Color GetRibbonContextTextColor(PaletteState state);

	Color GetRibbonDisabledDark(PaletteState state);

	Color GetRibbonDisabledLight(PaletteState state);

	Color GetRibbonGroupDialogDark(PaletteState state);

	Color GetRibbonGroupDialogLight(PaletteState state);

	Color GetRibbonDropArrowDark(PaletteState state);

	Color GetRibbonDropArrowLight(PaletteState state);

	Color GetRibbonGroupSeparatorDark(PaletteState state);

	Color GetRibbonGroupSeparatorLight(PaletteState state);

	Color GetRibbonMinimizeBarDark(PaletteState state);

	Color GetRibbonMinimizeBarLight(PaletteState state);

	Color GetRibbonTabSeparatorColor(PaletteState state);

	Color GetRibbonTabSeparatorContextColor(PaletteState state);

	Font GetRibbonTextFont(PaletteState state);

	PaletteTextHint GetRibbonTextHint(PaletteState state);

	Color GetRibbonQATButtonDark(PaletteState state);

	Color GetRibbonQATButtonLight(PaletteState state);
}
