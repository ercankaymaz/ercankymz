#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectRibbonGeneral : PaletteRedirect
{
	private IPaletteRibbonGeneral _disabled;

	private IPaletteRibbonGeneral _normal;

	private IPaletteRibbonGeneral _pressed;

	private IPaletteRibbonGeneral _tracking;

	public PaletteRedirectRibbonGeneral(IPalette target)
		: this(target, null, null, null, null)
	{
	}

	public PaletteRedirectRibbonGeneral(IPalette target, IPaletteRibbonGeneral disabled, IPaletteRibbonGeneral normal, IPaletteRibbonGeneral pressed, IPaletteRibbonGeneral tracking)
		: base(target)
	{
		_disabled = disabled;
		_normal = normal;
		_pressed = pressed;
		_tracking = tracking;
	}

	public override Color GetRibbonDisabledDark(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonDisabledDark(state) ?? Target.GetRibbonDisabledDark(state);
	}

	public override Color GetRibbonDisabledLight(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonDisabledLight(state) ?? Target.GetRibbonDisabledLight(state);
	}

	public override Color GetRibbonGroupDialogDark(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonGroupDialogDark(state) ?? Target.GetRibbonGroupDialogDark(state);
	}

	public override Color GetRibbonGroupDialogLight(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonGroupDialogLight(state) ?? Target.GetRibbonGroupDialogLight(state);
	}

	public override Color GetRibbonGroupSeparatorDark(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonGroupSeparatorDark(state) ?? Target.GetRibbonGroupSeparatorDark(state);
	}

	public override Color GetRibbonGroupSeparatorLight(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonGroupSeparatorLight(state) ?? Target.GetRibbonGroupSeparatorLight(state);
	}

	public override Color GetRibbonMinimizeBarDark(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonMinimizeBarDark(state) ?? Target.GetRibbonMinimizeBarDark(state);
	}

	public override Color GetRibbonMinimizeBarLight(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonMinimizeBarLight(state) ?? Target.GetRibbonMinimizeBarLight(state);
	}

	public override Color GetRibbonTabSeparatorColor(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonTabSeparatorColor(state) ?? Target.GetRibbonTabSeparatorColor(state);
	}

	public override Color GetRibbonTabSeparatorContextColor(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonTabSeparatorContextColor(state) ?? Target.GetRibbonTabSeparatorContextColor(state);
	}

	public override Font GetRibbonTextFont(PaletteState state)
	{
		IPaletteRibbonGeneral inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.GetRibbonTextFont(state);
		}
		return Target.GetRibbonTextFont(state);
	}

	public override PaletteTextHint GetRibbonTextHint(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonTextHint(state) ?? Target.GetRibbonTextHint(state);
	}

	public override Color GetRibbonQATButtonDark(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonQATButtonDark(state) ?? Target.GetRibbonQATButtonDark(state);
	}

	public override Color GetRibbonQATButtonLight(PaletteState state)
	{
		return GetInherit(state)?.GetRibbonQATButtonLight(state) ?? Target.GetRibbonQATButtonLight(state);
	}

	private IPaletteRibbonGeneral GetInherit(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return _disabled;
		case PaletteState.Normal:
			return _normal;
		case PaletteState.Pressed:
			return _pressed;
		case PaletteState.Tracking:
			return _tracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}
}
