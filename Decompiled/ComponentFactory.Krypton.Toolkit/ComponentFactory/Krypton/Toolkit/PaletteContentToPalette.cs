using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentToPalette : IPaletteContent
{
	private IPalette _palette;

	private PaletteContentStyle _style;

	public PaletteContentStyle ContentStyle
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

	public PaletteContentToPalette(IPalette palette, PaletteContentStyle style)
	{
		_palette = palette;
		_style = style;
	}

	public PaletteContentStyle GetContentStyle()
	{
		return ContentStyle;
	}

	public InheritBool GetContentDraw(PaletteState state)
	{
		return _palette.GetContentDraw(_style, state);
	}

	public InheritBool GetContentDrawFocus(PaletteState state)
	{
		return _palette.GetContentDrawFocus(_style, state);
	}

	public PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		return _palette.GetContentImageH(_style, state);
	}

	public PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		return _palette.GetContentImageV(_style, state);
	}

	public PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		return _palette.GetContentImageEffect(_style, state);
	}

	public Color GetContentImageColorMap(PaletteState state)
	{
		return _palette.GetContentImageColorMap(_style, state);
	}

	public Color GetContentImageColorTo(PaletteState state)
	{
		return _palette.GetContentImageColorTo(_style, state);
	}

	public Font GetContentShortTextFont(PaletteState state)
	{
		return _palette.GetContentShortTextFont(_style, state);
	}

	public Font GetContentShortTextNewFont(PaletteState state)
	{
		return _palette.GetContentShortTextNewFont(_style, state);
	}

	public PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		return _palette.GetContentShortTextHint(_style, state);
	}

	public PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return _palette.GetContentShortTextPrefix(_style, state);
	}

	public PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return _palette.GetContentShortTextTrim(_style, state);
	}

	public PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return _palette.GetContentShortTextH(_style, state);
	}

	public PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		return _palette.GetContentShortTextV(_style, state);
	}

	public PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		return _palette.GetContentShortTextMultiLineH(_style, state);
	}

	public InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		return _palette.GetContentShortTextMultiLine(_style, state);
	}

	public Color GetContentShortTextColor1(PaletteState state)
	{
		return _palette.GetContentShortTextColor1(_style, state);
	}

	public Color GetContentShortTextColor2(PaletteState state)
	{
		return _palette.GetContentShortTextColor2(_style, state);
	}

	public PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		return _palette.GetContentShortTextColorStyle(_style, state);
	}

	public PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		return _palette.GetContentShortTextColorAlign(_style, state);
	}

	public float GetContentShortTextColorAngle(PaletteState state)
	{
		return _palette.GetContentShortTextColorAngle(_style, state);
	}

	public Image GetContentShortTextImage(PaletteState state)
	{
		return _palette.GetContentShortTextImage(_style, state);
	}

	public PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		return _palette.GetContentShortTextImageStyle(_style, state);
	}

	public PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		return _palette.GetContentShortTextImageAlign(_style, state);
	}

	public Font GetContentLongTextFont(PaletteState state)
	{
		return _palette.GetContentLongTextFont(_style, state);
	}

	public Font GetContentLongTextNewFont(PaletteState state)
	{
		return _palette.GetContentLongTextNewFont(_style, state);
	}

	public PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		return _palette.GetContentLongTextHint(_style, state);
	}

	public PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		return _palette.GetContentLongTextPrefix(_style, state);
	}

	public PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return _palette.GetContentLongTextTrim(_style, state);
	}

	public PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		return _palette.GetContentLongTextH(_style, state);
	}

	public PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		return _palette.GetContentLongTextV(_style, state);
	}

	public PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		return _palette.GetContentLongTextMultiLineH(_style, state);
	}

	public InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		return _palette.GetContentLongTextMultiLine(_style, state);
	}

	public Color GetContentLongTextColor1(PaletteState state)
	{
		return _palette.GetContentLongTextColor1(_style, state);
	}

	public Color GetContentLongTextColor2(PaletteState state)
	{
		return _palette.GetContentLongTextColor2(_style, state);
	}

	public PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		return _palette.GetContentLongTextColorStyle(_style, state);
	}

	public PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		return _palette.GetContentLongTextColorAlign(_style, state);
	}

	public float GetContentLongTextColorAngle(PaletteState state)
	{
		return _palette.GetContentLongTextColorAngle(_style, state);
	}

	public Image GetContentLongTextImage(PaletteState state)
	{
		return _palette.GetContentLongTextImage(_style, state);
	}

	public PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		return _palette.GetContentLongTextImageStyle(_style, state);
	}

	public PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		return _palette.GetContentLongTextImageAlign(_style, state);
	}

	public Padding GetContentPadding(PaletteState state)
	{
		return _palette.GetContentPadding(_style, state);
	}

	public int GetContentAdjacentGap(PaletteState state)
	{
		return _palette.GetContentAdjacentGap(_style, state);
	}
}
