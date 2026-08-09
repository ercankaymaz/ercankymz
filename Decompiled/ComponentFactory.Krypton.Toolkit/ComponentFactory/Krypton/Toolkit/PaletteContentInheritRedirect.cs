using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentInheritRedirect : PaletteContentInherit
{
	private PaletteRedirect _redirect;

	private PaletteContentStyle _style;

	public PaletteContentStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			_style = value;
		}
	}

	public PaletteContentInheritRedirect(PaletteContentStyle style)
		: this(null, style)
	{
	}

	public PaletteContentInheritRedirect(PaletteRedirect redirect)
		: this(redirect, PaletteContentStyle.ButtonStandalone)
	{
	}

	public PaletteContentInheritRedirect(PaletteRedirect redirect, PaletteContentStyle style)
	{
		_redirect = redirect;
		_style = style;
	}

	public PaletteRedirect GetRedirector()
	{
		return _redirect;
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public override InheritBool GetContentDraw(PaletteState state)
	{
		return _redirect.GetContentDraw(_style, state);
	}

	public override InheritBool GetContentDrawFocus(PaletteState state)
	{
		return _redirect.GetContentDrawFocus(_style, state);
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		return _redirect.GetContentImageH(_style, state);
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		return _redirect.GetContentImageV(_style, state);
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		return _redirect.GetContentImageEffect(_style, state);
	}

	public override Color GetContentImageColorMap(PaletteState state)
	{
		return _redirect.GetContentImageColorMap(_style, state);
	}

	public override Color GetContentImageColorTo(PaletteState state)
	{
		return _redirect.GetContentImageColorTo(_style, state);
	}

	public override Font GetContentShortTextFont(PaletteState state)
	{
		return _redirect.GetContentShortTextFont(_style, state);
	}

	public override Font GetContentShortTextNewFont(PaletteState state)
	{
		return _redirect.GetContentShortTextNewFont(_style, state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		return _redirect.GetContentShortTextHint(_style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return _redirect.GetContentShortTextPrefix(_style, state);
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		return _redirect.GetContentShortTextMultiLine(_style, state);
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return _redirect.GetContentShortTextTrim(_style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return _redirect.GetContentShortTextH(_style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		return _redirect.GetContentShortTextV(_style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		return _redirect.GetContentShortTextMultiLineH(_style, state);
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		return _redirect.GetContentShortTextColor1(_style, state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		return _redirect.GetContentShortTextColor2(_style, state);
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		return _redirect.GetContentShortTextColorStyle(_style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		return _redirect.GetContentShortTextColorAlign(_style, state);
	}

	public override float GetContentShortTextColorAngle(PaletteState state)
	{
		return _redirect.GetContentShortTextColorAngle(_style, state);
	}

	public override Image GetContentShortTextImage(PaletteState state)
	{
		return _redirect.GetContentShortTextImage(_style, state);
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		return _redirect.GetContentShortTextImageStyle(_style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		return _redirect.GetContentShortTextImageAlign(_style, state);
	}

	public override Font GetContentLongTextFont(PaletteState state)
	{
		return _redirect.GetContentLongTextFont(_style, state);
	}

	public override Font GetContentLongTextNewFont(PaletteState state)
	{
		return _redirect.GetContentLongTextNewFont(_style, state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		return _redirect.GetContentLongTextHint(_style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		return _redirect.GetContentLongTextPrefix(_style, state);
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		return _redirect.GetContentLongTextMultiLine(_style, state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return _redirect.GetContentLongTextTrim(_style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		return _redirect.GetContentLongTextH(_style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		return _redirect.GetContentLongTextV(_style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		return _redirect.GetContentLongTextMultiLineH(_style, state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		return _redirect.GetContentLongTextColor1(_style, state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		return _redirect.GetContentLongTextColor2(_style, state);
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		return _redirect.GetContentLongTextColorStyle(_style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		return _redirect.GetContentLongTextColorAlign(_style, state);
	}

	public override float GetContentLongTextColorAngle(PaletteState state)
	{
		return _redirect.GetContentLongTextColorAngle(_style, state);
	}

	public override Image GetContentLongTextImage(PaletteState state)
	{
		return _redirect.GetContentLongTextImage(_style, state);
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		return _redirect.GetContentLongTextImageStyle(_style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		return _redirect.GetContentLongTextImageAlign(_style, state);
	}

	public override Padding GetContentPadding(PaletteState state)
	{
		return _redirect.GetContentPadding(_style, state);
	}

	public override int GetContentAdjacentGap(PaletteState state)
	{
		return _redirect.GetContentAdjacentGap(_style, state);
	}

	public override PaletteContentStyle GetContentStyle()
	{
		return _style;
	}
}
