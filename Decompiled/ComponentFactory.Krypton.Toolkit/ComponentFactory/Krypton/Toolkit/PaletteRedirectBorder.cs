#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectBorder : PaletteRedirect
{
	private IPaletteBorder _disabled;

	private IPaletteBorder _normal;

	private IPaletteBorder _pressed;

	private IPaletteBorder _tracking;

	private IPaletteBorder _checkedNormal;

	private IPaletteBorder _checkedPressed;

	private IPaletteBorder _checkedTracking;

	private IPaletteBorder _focusOverride;

	private IPaletteBorder _normalDefaultOverride;

	public PaletteRedirectBorder(IPalette target)
		: this(target, null, null, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectBorder(IPalette target, IPaletteBorder disabled, IPaletteBorder normal)
		: this(target, disabled, normal, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectBorder(IPalette target, IPaletteBorder disabled, IPaletteBorder normal, IPaletteBorder pressed, IPaletteBorder tracking)
		: this(target, disabled, normal, pressed, tracking, null, null, null, null, null)
	{
	}

	public PaletteRedirectBorder(IPalette target, IPaletteBorder disabled, IPaletteBorder normal, IPaletteBorder pressed, IPaletteBorder tracking, IPaletteBorder checkedNormal, IPaletteBorder checkedPressed, IPaletteBorder checkedTracking, IPaletteBorder focusOverride, IPaletteBorder normalDefaultOverride)
		: base(target)
	{
		_disabled = disabled;
		_normal = normal;
		_pressed = pressed;
		_tracking = tracking;
		_checkedNormal = checkedNormal;
		_checkedPressed = checkedPressed;
		_checkedTracking = checkedTracking;
		_focusOverride = focusOverride;
		_normalDefaultOverride = normalDefaultOverride;
	}

	public virtual void SetRedirectStates(IPaletteBorder disabled, IPaletteBorder normal)
	{
		_disabled = disabled;
		_normal = normal;
	}

	public virtual void ResetRedirectStates()
	{
		_disabled = null;
		_normal = null;
		_pressed = null;
		_tracking = null;
		_checkedNormal = null;
		_checkedPressed = null;
		_checkedTracking = null;
		_focusOverride = null;
		_normalDefaultOverride = null;
	}

	public override InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderDraw(state) ?? Target.GetBorderDraw(style, state);
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderDrawBorders(state) ?? Target.GetBorderDrawBorders(style, state);
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderGraphicsHint(state) ?? Target.GetBorderGraphicsHint(style, state);
	}

	public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderColor1(state) ?? Target.GetBorderColor1(style, state);
	}

	public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderColor2(state) ?? Target.GetBorderColor2(style, state);
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderColorStyle(state) ?? Target.GetBorderColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderColorAlign(state) ?? Target.GetBorderColorAlign(style, state);
	}

	public override float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderColorAngle(state) ?? Target.GetBorderColorAngle(style, state);
	}

	public override int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderWidth(state) ?? Target.GetBorderWidth(style, state);
	}

	public override int GetBorderRounding(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderRounding(state) ?? Target.GetBorderRounding(style, state);
	}

	public override Image GetBorderImage(PaletteBorderStyle style, PaletteState state)
	{
		IPaletteBorder inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.GetBorderImage(state);
		}
		return Target.GetBorderImage(style, state);
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderImageStyle(state) ?? Target.GetBorderImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderImageAlign(state) ?? Target.GetBorderImageAlign(style, state);
	}

	private IPaletteBorder GetInherit(PaletteState state)
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
		case PaletteState.CheckedNormal:
			return _checkedNormal;
		case PaletteState.CheckedPressed:
			return _checkedPressed;
		case PaletteState.CheckedTracking:
			return _checkedTracking;
		case PaletteState.FocusOverride:
			return _focusOverride;
		case PaletteState.NormalDefaultOverride:
			return _normalDefaultOverride;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}
}
