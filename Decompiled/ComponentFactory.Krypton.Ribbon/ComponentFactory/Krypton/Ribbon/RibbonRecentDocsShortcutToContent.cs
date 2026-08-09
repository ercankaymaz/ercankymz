using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonRecentDocsShortcutToContent : RibbonRecentDocsEntryToContent
{
	public RibbonRecentDocsShortcutToContent(PaletteRibbonGeneral ribbonGeneral, IPaletteRibbonText ribbonRecentDocEntryText)
		: base(ribbonGeneral, ribbonRecentDocEntryText)
	{
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return PaletteTextHotkeyPrefix.Show;
	}
}
