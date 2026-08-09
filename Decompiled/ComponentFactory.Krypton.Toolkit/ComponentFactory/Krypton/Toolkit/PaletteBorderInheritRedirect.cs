using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBorderInheritRedirect : PaletteBorderInherit
{
	private PaletteRedirect _redirect;

	private PaletteBorderStyle _style;

	private bool _overrideBorderToFalse;

	public bool OverrideBorderToFalse
	{
		get
		{
			return _overrideBorderToFalse;
		}
		set
		{
			_overrideBorderToFalse = value;
		}
	}

	public PaletteBorderStyle Style
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

	public PaletteBorderInheritRedirect(PaletteRedirect redirect)
		: this(redirect, PaletteBorderStyle.ButtonStandalone)
	{
	}

	public PaletteBorderInheritRedirect(PaletteRedirect redirect, PaletteBorderStyle style)
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

	public override InheritBool GetBorderDraw(PaletteState state)
	{
		if (_overrideBorderToFalse)
		{
			return InheritBool.False;
		}
		return _redirect.GetBorderDraw(_style, state);
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteState state)
	{
		return _redirect.GetBorderDrawBorders(_style, state);
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state)
	{
		return _redirect.GetBorderGraphicsHint(_style, state);
	}

	public override Color GetBorderColor1(PaletteState state)
	{
		return _redirect.GetBorderColor1(_style, state);
	}

	public override Color GetBorderColor2(PaletteState state)
	{
		return _redirect.GetBorderColor2(_style, state);
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteState state)
	{
		return _redirect.GetBorderColorStyle(_style, state);
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteState state)
	{
		return _redirect.GetBorderColorAlign(_style, state);
	}

	public override float GetBorderColorAngle(PaletteState state)
	{
		return _redirect.GetBorderColorAngle(_style, state);
	}

	public override int GetBorderWidth(PaletteState state)
	{
		return _redirect.GetBorderWidth(_style, state);
	}

	public override int GetBorderRounding(PaletteState state)
	{
		return _redirect.GetBorderRounding(_style, state);
	}

	public override Image GetBorderImage(PaletteState state)
	{
		return _redirect.GetBorderImage(_style, state);
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteState state)
	{
		return _redirect.GetBorderImageStyle(_style, state);
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteState state)
	{
		return _redirect.GetBorderImageAlign(_style, state);
	}
}
