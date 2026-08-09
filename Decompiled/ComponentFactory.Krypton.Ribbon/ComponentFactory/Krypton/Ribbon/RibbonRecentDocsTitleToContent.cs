#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonRecentDocsTitleToContent : RibbonToContent
{
	private static readonly Padding _titlePadding = new Padding(5, 3, 5, 1);

	private IPaletteRibbonText _ribbonRecentTitleText;

	private Font _shortTextFont;

	public RibbonRecentDocsTitleToContent(PaletteRibbonGeneral ribbonGeneral, IPaletteRibbonText ribbonRecentTitleText)
		: base(ribbonGeneral)
	{
		Debug.Assert(ribbonRecentTitleText != null);
		_ribbonRecentTitleText = ribbonRecentTitleText;
	}

	public void Dispose()
	{
		if (_shortTextFont != null)
		{
			_shortTextFont.Dispose();
		}
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return PaletteRelativeAlign.Near;
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		return _ribbonRecentTitleText.GetRibbonTextColor(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		return _ribbonRecentTitleText.GetRibbonTextColor(state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		return _ribbonRecentTitleText.GetRibbonTextColor(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		return _ribbonRecentTitleText.GetRibbonTextColor(state);
	}

	public override Padding GetContentPadding(PaletteState state)
	{
		return _titlePadding;
	}

	public override Font GetContentShortTextFont(PaletteState state)
	{
		if (_shortTextFont != null)
		{
			_shortTextFont.Dispose();
		}
		_shortTextFont = new Font(base.RibbonGeneral.GetRibbonTextFont(state), FontStyle.Bold);
		return _shortTextFont;
	}
}
