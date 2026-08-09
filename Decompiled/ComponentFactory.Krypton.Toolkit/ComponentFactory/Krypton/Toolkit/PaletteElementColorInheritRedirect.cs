#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteElementColorInheritRedirect : PaletteElementColorInherit
{
	private PaletteRedirect _redirect;

	private PaletteElement _element;

	public PaletteElement Element
	{
		get
		{
			return _element;
		}
		set
		{
			_element = value;
		}
	}

	public PaletteElementColorInheritRedirect(PaletteRedirect redirect, PaletteElement element)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_element = element;
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public override Color GetElementColor1(PaletteState state)
	{
		return _redirect.GetElementColor1(_element, state);
	}

	public override Color GetElementColor2(PaletteState state)
	{
		return _redirect.GetElementColor2(_element, state);
	}

	public override Color GetElementColor3(PaletteState state)
	{
		return _redirect.GetElementColor3(_element, state);
	}

	public override Color GetElementColor4(PaletteState state)
	{
		return _redirect.GetElementColor4(_element, state);
	}

	public override Color GetElementColor5(PaletteState state)
	{
		return _redirect.GetElementColor5(_element, state);
	}
}
