#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectRibbonBack : PaletteRedirect
{
	private IPaletteRibbonBack _disabledBack;

	private IPaletteRibbonBack _normalBack;

	private IPaletteRibbonBack _pressedBack;

	private IPaletteRibbonBack _trackingBack;

	private IPaletteRibbonBack _selectedBack;

	private IPaletteRibbonBack _focusOverrideBack;

	public PaletteRedirectRibbonBack(IPalette target)
		: this(target, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectRibbonBack(IPalette target, IPaletteRibbonBack disabledBack, IPaletteRibbonBack normalBack)
		: this(target, disabledBack, normalBack, null, null, null, null)
	{
	}

	public PaletteRedirectRibbonBack(IPalette target, IPaletteRibbonBack disabledBack, IPaletteRibbonBack normalBack, IPaletteRibbonBack pressedBack, IPaletteRibbonBack trackingBack, IPaletteRibbonBack selectedBack, IPaletteRibbonBack focusOverrideBack)
		: base(target)
	{
		_disabledBack = disabledBack;
		_normalBack = normalBack;
		_pressedBack = pressedBack;
		_trackingBack = trackingBack;
		_selectedBack = selectedBack;
		_focusOverrideBack = focusOverrideBack;
	}

	public virtual void SetRedirectStates(IPaletteRibbonBack disabledBack, IPaletteRibbonBack normalBack)
	{
		_disabledBack = disabledBack;
		_normalBack = normalBack;
		_pressedBack = null;
		_trackingBack = null;
		_selectedBack = null;
		_focusOverrideBack = null;
	}

	public virtual void SetRedirectStates(IPaletteRibbonBack disabledBack, IPaletteRibbonBack normalBack, IPaletteRibbonBack pressedBack, IPaletteRibbonBack trackingBack, IPaletteRibbonBack selectedBack, IPaletteRibbonBack focusOverrideBack)
	{
		_disabledBack = disabledBack;
		_normalBack = normalBack;
		_pressedBack = pressedBack;
		_trackingBack = trackingBack;
		_selectedBack = selectedBack;
		_focusOverrideBack = focusOverrideBack;
	}

	public virtual void ResetRedirectStates()
	{
		_disabledBack = null;
		_normalBack = null;
		_pressedBack = null;
		_trackingBack = null;
		_selectedBack = null;
		_focusOverrideBack = null;
	}

	public override PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetBackInherit(state)?.GetRibbonBackColorStyle(state) ?? Target.GetRibbonBackColorStyle(style, state);
	}

	public override Color GetRibbonBackColor1(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetBackInherit(state)?.GetRibbonBackColor1(state) ?? Target.GetRibbonBackColor1(style, state);
	}

	public override Color GetRibbonBackColor2(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetBackInherit(state)?.GetRibbonBackColor2(state) ?? Target.GetRibbonBackColor2(style, state);
	}

	public override Color GetRibbonBackColor3(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetBackInherit(state)?.GetRibbonBackColor3(state) ?? Target.GetRibbonBackColor3(style, state);
	}

	public override Color GetRibbonBackColor4(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetBackInherit(state)?.GetRibbonBackColor4(state) ?? Target.GetRibbonBackColor4(style, state);
	}

	public override Color GetRibbonBackColor5(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetBackInherit(state)?.GetRibbonBackColor5(state) ?? Target.GetRibbonBackColor5(style, state);
	}

	private IPaletteRibbonBack GetBackInherit(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return _disabledBack;
		case PaletteState.Normal:
			return _normalBack;
		case PaletteState.Pressed:
			return _pressedBack;
		case PaletteState.Tracking:
			return _trackingBack;
		case PaletteState.CheckedNormal:
		case PaletteState.CheckedTracking:
		case PaletteState.CheckedPressed:
			return _selectedBack;
		case PaletteState.FocusOverride:
			return _focusOverrideBack;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}
}
