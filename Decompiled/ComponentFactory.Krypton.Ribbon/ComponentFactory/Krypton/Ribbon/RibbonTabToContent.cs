#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonTabToContent : RibbonToContent
{
	private IPaletteRibbonText _ribbonTabText;

	public IPaletteRibbonText PaletteRibbonText
	{
		get
		{
			return _ribbonTabText;
		}
		set
		{
			_ribbonTabText = value;
		}
	}

	public RibbonTabToContent(PaletteRibbonGeneral ribbonGeneral, IPaletteRibbonText ribbonTabText)
		: base(ribbonGeneral)
	{
		Debug.Assert(ribbonTabText != null);
		_ribbonTabText = ribbonTabText;
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
		return _ribbonTabText.GetRibbonTextColor(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		return _ribbonTabText.GetRibbonTextColor(state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return PaletteTextTrim.Character;
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		return _ribbonTabText.GetRibbonTextColor(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		return _ribbonTabText.GetRibbonTextColor(state);
	}
}
