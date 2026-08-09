#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectContent : PaletteRedirect
{
	private IPaletteContent _disabled;

	private IPaletteContent _normal;

	private IPaletteContent _pressed;

	private IPaletteContent _tracking;

	private IPaletteContent _checkedNormal;

	private IPaletteContent _checkedPressed;

	private IPaletteContent _checkedTracking;

	private IPaletteContent _focusOverride;

	private IPaletteContent _normalDefaultOverride;

	private IPaletteContent _linkVisitedOverride;

	private IPaletteContent _linkNotVisitedOverride;

	private IPaletteContent _linkPressedOverride;

	public PaletteRedirectContent()
		: this(null, null, null, null, null, null, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectContent(IPalette target, IPaletteContent disabled, IPaletteContent normal)
		: this(target, disabled, normal, null, null, null, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectContent(IPalette target, IPaletteContent disabled, IPaletteContent normal, IPaletteContent pressed, IPaletteContent tracking, IPaletteContent checkedNormal, IPaletteContent checkedPressed, IPaletteContent checkedTracking, IPaletteContent focusOverride, IPaletteContent normalDefaultOverride, IPaletteContent linkVisitedOverride, IPaletteContent linkNotVisitedOverride, IPaletteContent linkPressedOverride)
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
		_linkVisitedOverride = linkVisitedOverride;
		_linkNotVisitedOverride = linkNotVisitedOverride;
		_linkPressedOverride = linkPressedOverride;
	}

	public virtual void SetRedirectStates(IPaletteContent disabled, IPaletteContent normal)
	{
		_disabled = disabled;
		_normal = normal;
	}

	public virtual void SetRedirectStates(IPaletteContent disabled, IPaletteContent normal, IPaletteContent pressed, IPaletteContent tracking, IPaletteContent checkedNormal, IPaletteContent checkedPressed, IPaletteContent checkedTracking, IPaletteContent focusOverride, IPaletteContent normalDefaultOverride, IPaletteContent linkVisitedOverride, IPaletteContent linkNotVisitedOverride, IPaletteContent linkPressedOverride)
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
		_linkVisitedOverride = linkVisitedOverride;
		_linkNotVisitedOverride = linkNotVisitedOverride;
		_linkPressedOverride = linkPressedOverride;
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
		_linkVisitedOverride = null;
		_linkNotVisitedOverride = null;
		_linkPressedOverride = null;
	}

	public override InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentDraw(state) ?? Target.GetContentDraw(style, state);
	}

	public override InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentDrawFocus(state) ?? Target.GetContentDrawFocus(style, state);
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentImageH(state) ?? Target.GetContentImageH(style, state);
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentImageV(state) ?? Target.GetContentImageV(style, state);
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentImageEffect(state) ?? Target.GetContentImageEffect(style, state);
	}

	public override Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state)
	{
		IPaletteContent inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.GetContentShortTextFont(state);
		}
		return Target.GetContentShortTextFont(style, state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextHint(state) ?? Target.GetContentShortTextHint(style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextPrefix(state) ?? Target.GetContentShortTextPrefix(style, state);
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextMultiLine(state) ?? Target.GetContentShortTextMultiLine(style, state);
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextTrim(state) ?? Target.GetContentShortTextTrim(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextH(state) ?? Target.GetContentShortTextH(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextV(state) ?? Target.GetContentShortTextV(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextMultiLineH(state) ?? Target.GetContentShortTextMultiLineH(style, state);
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextColor1(state) ?? Target.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextColor2(state) ?? Target.GetContentShortTextColor2(style, state);
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextColorStyle(state) ?? Target.GetContentShortTextColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextColorAlign(state) ?? Target.GetContentShortTextColorAlign(style, state);
	}

	public override float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextColorAngle(state) ?? Target.GetContentShortTextColorAngle(style, state);
	}

	public override Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state)
	{
		IPaletteContent inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.GetContentShortTextImage(state);
		}
		return Target.GetContentShortTextImage(style, state);
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextImageStyle(state) ?? Target.GetContentShortTextImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentShortTextImageAlign(state) ?? Target.GetContentShortTextImageAlign(style, state);
	}

	public override Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state)
	{
		IPaletteContent inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.GetContentLongTextFont(state);
		}
		return Target.GetContentLongTextFont(style, state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextHint(state) ?? Target.GetContentLongTextHint(style, state);
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextMultiLine(state) ?? Target.GetContentLongTextMultiLine(style, state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextTrim(state) ?? Target.GetContentLongTextTrim(style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextPrefix(state) ?? Target.GetContentLongTextPrefix(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextH(state) ?? Target.GetContentLongTextH(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextV(state) ?? Target.GetContentLongTextV(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextMultiLineH(state) ?? Target.GetContentLongTextMultiLineH(style, state);
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextColor1(state) ?? Target.GetContentLongTextColor1(style, state);
	}

	public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextColor2(state) ?? Target.GetContentLongTextColor2(style, state);
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextColorStyle(state) ?? Target.GetContentLongTextColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextColorAlign(state) ?? Target.GetContentLongTextColorAlign(style, state);
	}

	public override Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state)
	{
		IPaletteContent inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.GetContentLongTextImage(state);
		}
		return Target.GetContentLongTextImage(style, state);
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextImageStyle(state) ?? Target.GetContentLongTextImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentLongTextImageAlign(state) ?? Target.GetContentLongTextImageAlign(style, state);
	}

	public override Padding GetContentPadding(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentPadding(state) ?? Target.GetContentPadding(style, state);
	}

	public override int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetContentAdjacentGap(state) ?? Target.GetContentAdjacentGap(style, state);
	}

	private IPaletteContent GetInherit(PaletteState state)
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
		case PaletteState.LinkVisitedOverride:
			return _linkVisitedOverride;
		case PaletteState.LinkNotVisitedOverride:
			return _linkNotVisitedOverride;
		case PaletteState.LinkPressedOverride:
			return _linkPressedOverride;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}
}
