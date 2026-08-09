#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectBack : PaletteRedirect
{
	private IPaletteBack _disabled;

	private IPaletteBack _normal;

	private IPaletteBack _pressed;

	private IPaletteBack _tracking;

	private IPaletteBack _checkedNormal;

	private IPaletteBack _checkedPressed;

	private IPaletteBack _checkedTracking;

	private IPaletteBack _focusOverride;

	private IPaletteBack _normalDefaultOverride;

	public PaletteRedirectBack(IPalette target)
		: this(target, null, null, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectBack(IPalette target, IPaletteBack disabled, IPaletteBack normal)
		: this(target, disabled, normal, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectBack(IPalette target, IPaletteBack disabled, IPaletteBack normal, IPaletteBack pressed, IPaletteBack tracking, IPaletteBack checkedNormal, IPaletteBack checkedPressed, IPaletteBack checkedTracking, IPaletteBack focusOverride, IPaletteBack normalDefaultOverride)
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

	public virtual void SetRedirectStates(IPaletteBack disabled, IPaletteBack normal)
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

	public override InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackDraw(state) ?? Target.GetBackDraw(style, state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackGraphicsHint(state) ?? Target.GetBackGraphicsHint(style, state);
	}

	public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColor1(state) ?? Target.GetBackColor1(style, state);
	}

	public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColor2(state) ?? Target.GetBackColor2(style, state);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColorStyle(state) ?? Target.GetBackColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColorAlign(state) ?? Target.GetBackColorAlign(style, state);
	}

	public override float GetBackColorAngle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColorAngle(state) ?? Target.GetBackColorAngle(style, state);
	}

	public override Image GetBackImage(PaletteBackStyle style, PaletteState state)
	{
		IPaletteBack inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.GetBackImage(state);
		}
		return Target.GetBackImage(style, state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackImageStyle(state) ?? Target.GetBackImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackImageAlign(state) ?? Target.GetBackImageAlign(style, state);
	}

	private IPaletteBack GetInherit(PaletteState state)
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
