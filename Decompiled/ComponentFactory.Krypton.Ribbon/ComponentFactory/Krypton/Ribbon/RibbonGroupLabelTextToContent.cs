#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonGroupLabelTextToContent : RibbonToContent
{
	private IPaletteRibbonText _ribbonGroupTextNormal;

	private IPaletteRibbonText _ribbonGroupTextDisabled;

	private IPaletteRibbonText _ribbonLabelTextNormal;

	private IPaletteRibbonText _ribbonLabelTextDisabled;

	public RibbonGroupLabelTextToContent(PaletteRibbonGeneral ribbonGeneral, IPaletteRibbonText ribbonGroupTextNormal, IPaletteRibbonText ribbonGroupTextDisabled, IPaletteRibbonText ribbonLabelTextNormal, IPaletteRibbonText ribbonLabelTextDisabled)
		: base(ribbonGeneral)
	{
		Debug.Assert(ribbonGroupTextNormal != null);
		Debug.Assert(ribbonGroupTextDisabled != null);
		Debug.Assert(ribbonLabelTextNormal != null);
		Debug.Assert(ribbonLabelTextDisabled != null);
		_ribbonGroupTextNormal = ribbonGroupTextNormal;
		_ribbonGroupTextDisabled = ribbonGroupTextDisabled;
		_ribbonLabelTextNormal = ribbonLabelTextNormal;
		_ribbonLabelTextDisabled = ribbonLabelTextDisabled;
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		return GetTextColor(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		return GetTextColor(state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		return GetTextColor(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		return GetTextColor(state);
	}

	private Color GetTextColor(PaletteState state)
	{
		Color empty = Color.Empty;
		if (state == PaletteState.Disabled)
		{
			empty = _ribbonLabelTextDisabled.GetRibbonTextColor(state);
			if (empty == Color.Empty)
			{
				empty = _ribbonGroupTextDisabled.GetRibbonTextColor(state);
			}
		}
		else
		{
			empty = _ribbonLabelTextNormal.GetRibbonTextColor(state);
			if (empty == Color.Empty)
			{
				empty = _ribbonGroupTextNormal.GetRibbonTextColor(state);
			}
		}
		return empty;
	}
}
