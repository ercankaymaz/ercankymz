#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRibbonDoubleInheritRedirect : PaletteRibbonDoubleInherit
{
	private PaletteRedirect _redirect;

	private PaletteRibbonBackStyle _styleBack;

	private PaletteRibbonTextStyle _styleText;

	public PaletteRibbonBackStyle StyleBack
	{
		get
		{
			return _styleBack;
		}
		set
		{
			_styleBack = value;
		}
	}

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

	public PaletteRibbonDoubleInheritRedirect(PaletteRedirect redirect, PaletteRibbonBackStyle styleBack, PaletteRibbonTextStyle styleText)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_styleBack = styleBack;
		_styleText = styleText;
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public override PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteState state)
	{
		return _redirect.GetRibbonBackColorStyle(_styleBack, state);
	}

	public override Color GetRibbonBackColor1(PaletteState state)
	{
		return _redirect.GetRibbonBackColor1(_styleBack, state);
	}

	public override Color GetRibbonBackColor2(PaletteState state)
	{
		return _redirect.GetRibbonBackColor2(_styleBack, state);
	}

	public override Color GetRibbonBackColor3(PaletteState state)
	{
		return _redirect.GetRibbonBackColor3(_styleBack, state);
	}

	public override Color GetRibbonBackColor4(PaletteState state)
	{
		return _redirect.GetRibbonBackColor4(_styleBack, state);
	}

	public override Color GetRibbonBackColor5(PaletteState state)
	{
		return _redirect.GetRibbonBackColor5(_styleBack, state);
	}

	public override Color GetRibbonTextColor(PaletteState state)
	{
		return _redirect.GetRibbonTextColor(_styleText, state);
	}
}
