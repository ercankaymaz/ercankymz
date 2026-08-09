#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectTriple : PaletteRedirect
{
	private IPaletteTriple _disabled;

	private IPaletteTriple _normal;

	private IPaletteTriple _pressed;

	private IPaletteTriple _tracking;

	private IPaletteTriple _checkedNormal;

	private IPaletteTriple _checkedPressed;

	private IPaletteTriple _checkedTracking;

	private IPaletteTriple _focusOverride;

	private IPaletteTriple _normalDefaultOverride;

	public PaletteRedirectTriple()
		: this(null, null, null, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectTriple(IPalette target)
		: this(target, null, null, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectTriple(IPalette target, IPaletteTriple disabled, IPaletteTriple normal)
		: this(target, disabled, normal, null, null, null, null, null, null, null)
	{
	}

	public PaletteRedirectTriple(IPalette target, IPaletteTriple disabled, IPaletteTriple normal, IPaletteTriple tracking)
		: this(target, disabled, normal, null, tracking, null, null, null, null, null)
	{
	}

	public PaletteRedirectTriple(IPalette target, IPaletteTriple disabled, IPaletteTriple normal, IPaletteTriple pressed, IPaletteTriple tracking, IPaletteTriple selected, IPaletteTriple focusOverride)
		: this(target, disabled, normal, pressed, tracking, selected, selected, selected, focusOverride, null)
	{
	}

	public PaletteRedirectTriple(IPalette target, IPaletteTriple disabled, IPaletteTriple normal, IPaletteTriple pressed, IPaletteTriple tracking, IPaletteTriple checkedNormal, IPaletteTriple checkedPressed, IPaletteTriple checkedTracking, IPaletteTriple focusOverride, IPaletteTriple normalDefaultOverride)
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

	public virtual void SetRedirectStates(IPaletteTriple disabled, IPaletteTriple normal)
	{
		_disabled = disabled;
		_normal = normal;
	}

	public virtual void SetRedirectStates(IPaletteTriple disabled, IPaletteTriple normal, IPaletteTriple pressed, IPaletteTriple tracking, IPaletteTriple checkedNormal, IPaletteTriple checkedPressed, IPaletteTriple checkedTracking, IPaletteTriple focusOverride, IPaletteTriple normalDefaultOverride)
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
		IPaletteTriple inherit = GetInherit(state);
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
		IPaletteTriple inherit = GetInherit(state);
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

	public override InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentDraw(state) ?? Target.GetContentDraw(style, state);
	}

	public override InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentDrawFocus(state) ?? Target.GetContentDrawFocus(style, state);
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentImageH(state) ?? Target.GetContentImageH(style, state);
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentImageV(state) ?? Target.GetContentImageV(style, state);
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentImageEffect(state) ?? Target.GetContentImageEffect(style, state);
	}

	public override Color GetContentImageColorMap(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentImageColorMap(state) ?? Target.GetContentImageColorMap(style, state);
	}

	public override Color GetContentImageColorTo(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentImageColorTo(state) ?? Target.GetContentImageColorTo(style, state);
	}

	public override Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteContent.GetContentShortTextFont(state);
		}
		return Target.GetContentShortTextFont(style, state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextHint(state) ?? Target.GetContentShortTextHint(style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextPrefix(state) ?? Target.GetContentShortTextPrefix(style, state);
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextMultiLine(state) ?? Target.GetContentShortTextMultiLine(style, state);
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextTrim(state) ?? Target.GetContentShortTextTrim(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextH(state) ?? Target.GetContentShortTextH(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextV(state) ?? Target.GetContentShortTextV(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextMultiLineH(state) ?? Target.GetContentShortTextMultiLineH(style, state);
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColor1(state) ?? Target.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColor2(state) ?? Target.GetContentShortTextColor2(style, state);
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColorStyle(state) ?? Target.GetContentShortTextColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColorAlign(state) ?? Target.GetContentShortTextColorAlign(style, state);
	}

	public override float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColorAngle(state) ?? Target.GetContentShortTextColorAngle(style, state);
	}

	public override Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteContent.GetContentShortTextImage(state);
		}
		return Target.GetContentShortTextImage(style, state);
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextImageStyle(state) ?? Target.GetContentShortTextImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextImageAlign(state) ?? Target.GetContentShortTextImageAlign(style, state);
	}

	public override Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteContent.GetContentLongTextFont(state);
		}
		return Target.GetContentLongTextFont(style, state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextHint(state) ?? Target.GetContentLongTextHint(style, state);
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextMultiLine(state) ?? Target.GetContentLongTextMultiLine(style, state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextTrim(state) ?? Target.GetContentLongTextTrim(style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextPrefix(state) ?? Target.GetContentLongTextPrefix(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextH(state) ?? Target.GetContentLongTextH(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextV(state) ?? Target.GetContentLongTextV(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextMultiLineH(state) ?? Target.GetContentLongTextMultiLineH(style, state);
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColor1(state) ?? Target.GetContentLongTextColor1(style, state);
	}

	public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColor2(state) ?? Target.GetContentLongTextColor2(style, state);
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColorStyle(state) ?? Target.GetContentLongTextColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColorAlign(state) ?? Target.GetContentLongTextColorAlign(style, state);
	}

	public override float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColorAngle(state) ?? Target.GetContentLongTextColorAngle(style, state);
	}

	public override Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteContent.GetContentLongTextImage(state);
		}
		return Target.GetContentLongTextImage(style, state);
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextImageStyle(state) ?? Target.GetContentLongTextImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextImageAlign(state) ?? Target.GetContentLongTextImageAlign(style, state);
	}

	public override Padding GetContentPadding(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentPadding(state) ?? Target.GetContentPadding(style, state);
	}

	public override int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentAdjacentGap(state) ?? Target.GetContentAdjacentGap(style, state);
	}

	private IPaletteTriple GetInherit(PaletteState state)
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
