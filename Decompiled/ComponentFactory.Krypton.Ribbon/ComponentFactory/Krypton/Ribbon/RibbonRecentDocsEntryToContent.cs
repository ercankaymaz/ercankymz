#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonRecentDocsEntryToContent : RibbonToContent
{
	private IPaletteRibbonText _ribbonRecentDocEntryText;

	public RibbonRecentDocsEntryToContent(PaletteRibbonGeneral ribbonGeneral, IPaletteRibbonText ribbonRecentDocEntryText)
		: base(ribbonGeneral)
	{
		Debug.Assert(ribbonRecentDocEntryText != null);
		_ribbonRecentDocEntryText = ribbonRecentDocEntryText;
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return PaletteRelativeAlign.Near;
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return PaletteTextTrim.EllipsisPath;
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		return _ribbonRecentDocEntryText.GetRibbonTextColor(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		return _ribbonRecentDocEntryText.GetRibbonTextColor(state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		return PaletteRelativeAlign.Far;
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return PaletteTextTrim.EllipsisPath;
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		return _ribbonRecentDocEntryText.GetRibbonTextColor(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		return _ribbonRecentDocEntryText.GetRibbonTextColor(state);
	}
}
