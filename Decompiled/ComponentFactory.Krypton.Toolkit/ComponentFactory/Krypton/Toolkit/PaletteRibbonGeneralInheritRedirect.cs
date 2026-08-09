#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRibbonGeneralInheritRedirect : PaletteRibbonGeneralInherit
{
	private PaletteRedirect _redirect;

	public PaletteRibbonGeneralInheritRedirect(PaletteRedirect redirect)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public override PaletteRibbonShape GetRibbonShape()
	{
		return _redirect.GetRibbonShape();
	}

	public override PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state)
	{
		return _redirect.GetRibbonContextTextAlign(state);
	}

	public override Font GetRibbonContextTextFont(PaletteState state)
	{
		return _redirect.GetRibbonContextTextFont(state);
	}

	public override Color GetRibbonContextTextColor(PaletteState state)
	{
		return _redirect.GetRibbonContextTextColor(state);
	}

	public override Color GetRibbonDisabledDark(PaletteState state)
	{
		return _redirect.GetRibbonDisabledDark(state);
	}

	public override Color GetRibbonDisabledLight(PaletteState state)
	{
		return _redirect.GetRibbonDisabledLight(state);
	}

	public override Color GetRibbonDropArrowLight(PaletteState state)
	{
		return _redirect.GetRibbonDropArrowLight(state);
	}

	public override Color GetRibbonDropArrowDark(PaletteState state)
	{
		return _redirect.GetRibbonDropArrowDark(state);
	}

	public override Color GetRibbonGroupDialogDark(PaletteState state)
	{
		return _redirect.GetRibbonGroupDialogDark(state);
	}

	public override Color GetRibbonGroupDialogLight(PaletteState state)
	{
		return _redirect.GetRibbonGroupDialogLight(state);
	}

	public override Color GetRibbonGroupSeparatorDark(PaletteState state)
	{
		return _redirect.GetRibbonGroupSeparatorDark(state);
	}

	public override Color GetRibbonGroupSeparatorLight(PaletteState state)
	{
		return _redirect.GetRibbonGroupSeparatorLight(state);
	}

	public override Color GetRibbonMinimizeBarDark(PaletteState state)
	{
		return _redirect.GetRibbonMinimizeBarDark(state);
	}

	public override Color GetRibbonMinimizeBarLight(PaletteState state)
	{
		return _redirect.GetRibbonMinimizeBarLight(state);
	}

	public override Color GetRibbonTabSeparatorColor(PaletteState state)
	{
		return _redirect.GetRibbonTabSeparatorColor(state);
	}

	public override Color GetRibbonTabSeparatorContextColor(PaletteState state)
	{
		return _redirect.GetRibbonTabSeparatorContextColor(state);
	}

	public override Font GetRibbonTextFont(PaletteState state)
	{
		return _redirect.GetRibbonTextFont(state);
	}

	public override PaletteTextHint GetRibbonTextHint(PaletteState state)
	{
		return _redirect.GetRibbonTextHint(state);
	}

	public override Color GetRibbonQATButtonDark(PaletteState state)
	{
		return _redirect.GetRibbonQATButtonDark(state);
	}

	public override Color GetRibbonQATButtonLight(PaletteState state)
	{
		return _redirect.GetRibbonQATButtonLight(state);
	}
}
