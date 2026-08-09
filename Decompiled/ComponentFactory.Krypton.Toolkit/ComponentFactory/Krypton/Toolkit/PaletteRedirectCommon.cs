#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectCommon : PaletteRedirect
{
	private IPaletteTriple _disabled;

	private IPaletteTriple _others;

	public PaletteRedirectCommon(IPalette target, IPaletteTriple disabled, IPaletteTriple others)
		: base(target)
	{
		Debug.Assert(disabled != null);
		Debug.Assert(others != null);
		_disabled = disabled;
		_others = others;
	}

	public override InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackDraw(state) ?? base.GetBackDraw(style, state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackGraphicsHint(state) ?? base.GetBackGraphicsHint(style, state);
	}

	public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColor1(state) ?? base.GetBackColor1(style, state);
	}

	public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColor2(state) ?? base.GetBackColor2(style, state);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColorStyle(state) ?? base.GetBackColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColorAlign(state) ?? base.GetBackColorAlign(style, state);
	}

	public override float GetBackColorAngle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackColorAngle(state) ?? base.GetBackColorAngle(style, state);
	}

	public override Image GetBackImage(PaletteBackStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteBack.GetBackImage(state);
		}
		return base.GetBackImage(style, state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackImageStyle(state) ?? base.GetBackImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBack.GetBackImageAlign(state) ?? base.GetBackImageAlign(style, state);
	}

	public override InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderDraw(state) ?? base.GetBorderDraw(style, state);
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderDrawBorders(state) ?? base.GetBorderDrawBorders(style, state);
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderGraphicsHint(state) ?? base.GetBorderGraphicsHint(style, state);
	}

	public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColor1(state) ?? base.GetBorderColor1(style, state);
	}

	public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColor2(state) ?? base.GetBorderColor2(style, state);
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColorStyle(state) ?? base.GetBorderColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColorAlign(state) ?? base.GetBorderColorAlign(style, state);
	}

	public override float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderColorAngle(state) ?? base.GetBorderColorAngle(style, state);
	}

	public override int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderWidth(state) ?? base.GetBorderWidth(style, state);
	}

	public override int GetBorderRounding(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderRounding(state) ?? base.GetBorderRounding(style, state);
	}

	public override Image GetBorderImage(PaletteBorderStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteBorder.GetBorderImage(state);
		}
		return base.GetBorderImage(style, state);
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderImageStyle(state) ?? base.GetBorderImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteBorder.GetBorderImageAlign(state) ?? base.GetBorderImageAlign(style, state);
	}

	public override InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentDraw(state) ?? base.GetContentDraw(style, state);
	}

	public override InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentDrawFocus(state) ?? base.GetContentDrawFocus(style, state);
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentImageH(state) ?? base.GetContentImageH(style, state);
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentImageV(state) ?? base.GetContentImageV(style, state);
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentImageEffect(state) ?? base.GetContentImageEffect(style, state);
	}

	public override Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteContent.GetContentShortTextFont(state);
		}
		return base.GetContentShortTextFont(style, state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextHint(state) ?? base.GetContentShortTextHint(style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextPrefix(state) ?? base.GetContentShortTextPrefix(style, state);
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextMultiLine(state) ?? base.GetContentShortTextMultiLine(style, state);
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextTrim(state) ?? base.GetContentShortTextTrim(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextH(state) ?? base.GetContentShortTextH(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextV(state) ?? base.GetContentShortTextV(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextMultiLineH(state) ?? base.GetContentShortTextMultiLineH(style, state);
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColor1(state) ?? base.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColor2(state) ?? base.GetContentShortTextColor2(style, state);
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColorStyle(state) ?? base.GetContentShortTextColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColorAlign(state) ?? base.GetContentShortTextColorAlign(style, state);
	}

	public override float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextColorAngle(state) ?? base.GetContentShortTextColorAngle(style, state);
	}

	public override Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteContent.GetContentShortTextImage(state);
		}
		return base.GetContentShortTextImage(style, state);
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextImageStyle(state) ?? base.GetContentShortTextImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentShortTextImageAlign(state) ?? base.GetContentShortTextImageAlign(style, state);
	}

	public override Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteContent.GetContentLongTextFont(state);
		}
		return base.GetContentLongTextFont(style, state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextHint(state) ?? base.GetContentLongTextHint(style, state);
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextMultiLine(state) ?? base.GetContentLongTextMultiLine(style, state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextTrim(state) ?? base.GetContentLongTextTrim(style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextPrefix(state) ?? base.GetContentLongTextPrefix(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextH(state) ?? base.GetContentLongTextH(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextV(state) ?? base.GetContentLongTextV(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextMultiLineH(state) ?? base.GetContentLongTextMultiLineH(style, state);
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColor1(state) ?? base.GetContentLongTextColor1(style, state);
	}

	public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColor2(state) ?? base.GetContentLongTextColor2(style, state);
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColorStyle(state) ?? base.GetContentLongTextColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColorAlign(state) ?? base.GetContentLongTextColorAlign(style, state);
	}

	public override float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextColorAngle(state) ?? base.GetContentLongTextColorAngle(style, state);
	}

	public override Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state)
	{
		IPaletteTriple inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.PaletteContent.GetContentLongTextImage(state);
		}
		return base.GetContentLongTextImage(style, state);
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextImageStyle(state) ?? base.GetContentLongTextImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentLongTextImageAlign(state) ?? base.GetContentLongTextImageAlign(style, state);
	}

	public override Padding GetContentPadding(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentPadding(state) ?? base.GetContentPadding(style, state);
	}

	public override int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state)
	{
		return GetInherit(state)?.PaletteContent.GetContentAdjacentGap(state) ?? base.GetContentAdjacentGap(style, state);
	}

	private IPaletteTriple GetInherit(PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return null;
		}
		if (state == PaletteState.Disabled)
		{
			Debug.Assert(_disabled != null);
			return _disabled;
		}
		Debug.Assert(_others != null);
		return _others;
	}
}
