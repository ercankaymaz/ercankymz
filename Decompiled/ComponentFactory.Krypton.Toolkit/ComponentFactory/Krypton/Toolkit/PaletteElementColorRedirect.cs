namespace ComponentFactory.Krypton.Toolkit;

public class PaletteElementColorRedirect : PaletteElementColor
{
	private PaletteElementColorInheritRedirect _redirect;

	public PaletteElementColorRedirect(PaletteRedirect redirect, PaletteElement element, NeedPaintHandler needPaint)
		: base(null, needPaint)
	{
		_redirect = new PaletteElementColorInheritRedirect(redirect, element);
		SetInherit(_redirect);
	}

	public virtual void SetRedirector(PaletteRedirect redirect)
	{
		_redirect.SetRedirector(redirect);
	}
}
