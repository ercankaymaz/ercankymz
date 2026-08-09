using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBackInheritRedirect : PaletteBackInherit
{
	private PaletteRedirect _redirect;

	private PaletteBackStyle _style;

	public PaletteBackStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			_style = value;
		}
	}

	public PaletteBackInheritRedirect(PaletteRedirect redirect)
		: this(redirect, PaletteBackStyle.ButtonStandalone)
	{
	}

	public PaletteBackInheritRedirect(PaletteRedirect redirect, PaletteBackStyle style)
	{
		_redirect = redirect;
		_style = style;
	}

	public PaletteRedirect GetRedirector()
	{
		return _redirect;
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public override InheritBool GetBackDraw(PaletteState state)
	{
		return _redirect.GetBackDraw(Style, state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		return _redirect.GetBackGraphicsHint(Style, state);
	}

	public override Color GetBackColor1(PaletteState state)
	{
		return _redirect.GetBackColor1(Style, state);
	}

	public override Color GetBackColor2(PaletteState state)
	{
		return _redirect.GetBackColor2(Style, state);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		return _redirect.GetBackColorStyle(Style, state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		return _redirect.GetBackColorAlign(Style, state);
	}

	public override float GetBackColorAngle(PaletteState state)
	{
		return _redirect.GetBackColorAngle(Style, state);
	}

	public override Image GetBackImage(PaletteState state)
	{
		return _redirect.GetBackImage(Style, state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		return _redirect.GetBackImageStyle(Style, state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		return _redirect.GetBackImageAlign(Style, state);
	}
}
