#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRibbonTextInheritRedirect : PaletteRibbonTextInherit
{
	private PaletteRedirect _redirect;

	private PaletteRibbonTextStyle _styleText;

	public PaletteRibbonTextStyle StyleText
	{
		get
		{
			return _styleText;
		}
		set
		{
			_styleText = value;
		}
	}

	public PaletteRibbonTextInheritRedirect(PaletteRedirect redirect, PaletteRibbonTextStyle styleText)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_styleText = styleText;
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public override Color GetRibbonTextColor(PaletteState state)
	{
		return _redirect.GetRibbonTextColor(_styleText, state);
	}
}
