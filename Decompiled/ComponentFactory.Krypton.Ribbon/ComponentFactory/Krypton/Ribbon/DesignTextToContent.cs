#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class DesignTextToContent : RibbonToContent
{
	private KryptonRibbon _ribbon;

	public DesignTextToContent(KryptonRibbon ribbon)
		: base(ribbon.StateCommon.RibbonGeneral)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return PaletteTextTrim.Character;
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		if (state == PaletteState.Normal)
		{
			return _ribbon.StateCommon.RibbonGeneral.GetRibbonGroupSeparatorLight(state);
		}
		return _ribbon.StateCommon.RibbonGroupButton.Content.GetContentShortTextColor1(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		if (state == PaletteState.Normal)
		{
			return _ribbon.StateCommon.RibbonGeneral.GetRibbonGroupSeparatorLight(state);
		}
		return _ribbon.StateCommon.RibbonGroupButton.Content.GetContentShortTextColor1(state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return PaletteTextTrim.Character;
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		if (state == PaletteState.Normal)
		{
			return _ribbon.StateCommon.RibbonGeneral.GetRibbonGroupSeparatorLight(state);
		}
		return _ribbon.StateCommon.RibbonGroupButton.Content.GetContentShortTextColor1(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		if (state == PaletteState.Normal)
		{
			return _ribbon.StateCommon.RibbonGeneral.GetRibbonGroupSeparatorLight(state);
		}
		return _ribbon.StateCommon.RibbonGroupButton.Content.GetContentShortTextColor1(state);
	}
}
