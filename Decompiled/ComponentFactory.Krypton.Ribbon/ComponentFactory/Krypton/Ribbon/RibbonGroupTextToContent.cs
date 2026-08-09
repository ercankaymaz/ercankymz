#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonGroupTextToContent : RibbonToContent
{
	private IPaletteRibbonText _ribbonGroupText;

	public IPaletteRibbonText PaletteRibbonGroup
	{
		get
		{
			return _ribbonGroupText;
		}
		set
		{
			_ribbonGroupText = value;
		}
	}

	public RibbonGroupTextToContent(PaletteRibbonGeneral ribbonGeneral, IPaletteRibbonText ribbonGroupText)
		: base(ribbonGeneral)
	{
		Debug.Assert(ribbonGroupText != null);
		_ribbonGroupText = ribbonGroupText;
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		return _ribbonGroupText.GetRibbonTextColor(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		return _ribbonGroupText.GetRibbonTextColor(state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		return _ribbonGroupText.GetRibbonTextColor(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		return _ribbonGroupText.GetRibbonTextColor(state);
	}
}
