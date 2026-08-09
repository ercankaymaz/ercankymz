#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectDouble : PaletteRedirect
{
	private IPaletteDouble _disabled;

	private IPaletteDouble _normal;

	private IPaletteDouble _pressed;

	private IPaletteDouble _tracking;

	private IPaletteDouble _checkedNormal;

	private IPaletteDouble _checkedPressed;

	private IPaletteDouble _checkedTracking;

	private IPaletteDouble _focusOverride;

	private IPaletteDouble _normalDefaultOverride;

	public PaletteRedirectDouble()
		: this(null, null, null, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectDouble(IPalette target)
		: this(target, null, null, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectDouble(IPalette target, IPaletteDouble disabled, IPaletteDouble normal)
		: this(target, disabled, normal, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectDouble(IPalette target, IPaletteDouble disabled, IPaletteDouble normal, IPaletteDouble pressed, IPaletteDouble tracking)
		: this(target, disabled, normal, pressed, tracking, null, null, null, null, null)
	{
	}

	public PaletteRedirectDouble(IPalette target, IPaletteDouble disabled, IPaletteDouble normal, IPaletteDouble pressed, IPaletteDouble tracking, IPaletteDouble checkedNormal, IPaletteDouble checkedPressed, IPaletteDouble checkedTracking, IPaletteDouble focusOverride, IPaletteDouble normalDefaultOverride)
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

	public virtual void SetRedirectStates(IPaletteDouble disabled, IPaletteDouble normal)
	{
		_disabled = disabled;
		_normal = normal;
		_pressed = null;
		_tracking = null;
	}

	public virtual void SetRedirectStates(IPaletteDouble disabled, IPaletteDouble normal, IPaletteDouble pressed, IPaletteDouble tracking)
	{
		_disabled = disabled;
		_normal = normal;
		_pressed = pressed;
		_tracking = tracking;
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

	public override InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackDraw(state) ?? Target.GetBackDraw(style, state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackGraphicsHint(state) ?? Target.GetBackGraphicsHint(style, state);
	}

	public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColor1(state) ?? Target.GetBackColor1(style, state);
	}

	public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColor2(state) ?? Target.GetBackColor2(style, state);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColorStyle(state) ?? Target.GetBackColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColorAlign(state) ?? Target.GetBackColorAlign(style, state);
	}

	public override float GetBackColorAngle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColorAngle(state) ?? Target.GetBackColorAngle(style, state);
	}

	public override Image GetBackImage(PaletteBackStyle style, PaletteState state)
	{
		IPaletteDouble inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteBack.GetBackImage(state);
		}
		return Target.GetBackImage(style, state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackImageStyle(state) ?? Target.GetBackImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackImageAlign(state) ?? Target.GetBackImageAlign(style, state);
	}

	public override InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderDraw(state) ?? Target.GetBorderDraw(style, state);
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderDrawBorders(state) ?? Target.GetBorderDrawBorders(style, state);
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderGraphicsHint(state) ?? Target.GetBorderGraphicsHint(style, state);
	}

	public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColor1(state) ?? Target.GetBorderColor1(style, state);
	}

	public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColor2(state) ?? Target.GetBorderColor2(style, state);
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColorStyle(state) ?? Target.GetBorderColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColorAlign(state) ?? Target.GetBorderColorAlign(style, state);
	}

	public override float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColorAngle(state) ?? Target.GetBorderColorAngle(style, state);
	}

	public override int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderWidth(state) ?? Target.GetBorderWidth(style, state);
	}

	public override int GetBorderRounding(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderRounding(state) ?? Target.GetBorderRounding(style, state);
	}

	public override Image GetBorderImage(PaletteBorderStyle style, PaletteState state)
	{
		IPaletteDouble inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteBorder.GetBorderImage(state);
		}
		return Target.GetBorderImage(style, state);
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderImageStyle(state) ?? Target.GetBorderImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderImageAlign(state) ?? Target.GetBorderImageAlign(style, state);
	}

	private IPaletteDouble GetInherit(PaletteState state)
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
