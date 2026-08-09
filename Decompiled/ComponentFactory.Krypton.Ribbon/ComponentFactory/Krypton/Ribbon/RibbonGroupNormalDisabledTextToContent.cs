#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonGroupNormalDisabledTextToContent : RibbonToContent
{
	private IPaletteRibbonText _ribbonGroupTextNormal;

	private IPaletteRibbonText _ribbonGroupTextDisabled;

	public RibbonGroupNormalDisabledTextToContent(PaletteRibbonGeneral ribbonGeneral, IPaletteRibbonText ribbonGroupTextNormal, IPaletteRibbonText ribbonGroupTextDisabled)
		: base(ribbonGeneral)
	{
		Debug.Assert(ribbonGroupTextNormal != null);
		Debug.Assert(ribbonGroupTextDisabled != null);
		_ribbonGroupTextNormal = ribbonGroupTextNormal;
		_ribbonGroupTextDisabled = ribbonGroupTextDisabled;
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		if (state == PaletteState.Disabled)
		{
			return _ribbonGroupTextDisabled.GetRibbonTextColor(state);
		}
		return _ribbonGroupTextNormal.GetRibbonTextColor(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		if (state == PaletteState.Disabled)
		{
			return _ribbonGroupTextDisabled.GetRibbonTextColor(state);
		}
		return _ribbonGroupTextNormal.GetRibbonTextColor(state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		if (state == PaletteState.Disabled)
		{
			return _ribbonGroupTextDisabled.GetRibbonTextColor(state);
		}
		return _ribbonGroupTextNormal.GetRibbonTextColor(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		if (state == PaletteState.Disabled)
		{
			return _ribbonGroupTextDisabled.GetRibbonTextColor(state);
		}
		return _ribbonGroupTextNormal.GetRibbonTextColor(state);
	}
}
