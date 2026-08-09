using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentJustText : PaletteContent
{
	[KryptonPersist(false)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override InheritBool DrawFocus
	{
		get
		{
			return base.DrawFocus;
		}
		set
		{
			base.DrawFocus = value;
		}
	}

	[KryptonPersist]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override PaletteContentImage Image => base.Image;

	public PaletteContentJustText()
		: this(null, null)
	{
	}

	public PaletteContentJustText(IPaletteContent inherit)
		: this(inherit, null)
	{
	}

	public PaletteContentJustText(IPaletteContent inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
	}

	public override void PopulateFromBase(PaletteState state)
	{
		Draw = GetContentDraw(state);
		ShortText.Font = GetContentShortTextFont(state);
		ShortText.Hint = GetContentShortTextHint(state);
		ShortText.Prefix = GetContentShortTextPrefix(state);
		ShortText.Trim = GetContentShortTextTrim(state);
		ShortText.TextH = GetContentShortTextH(state);
		ShortText.TextV = GetContentShortTextV(state);
		ShortText.MultiLineH = GetContentShortTextMultiLineH(state);
		ShortText.MultiLine = GetContentShortTextMultiLine(state);
		ShortText.Color1 = GetContentShortTextColor1(state);
		ShortText.Color2 = GetContentShortTextColor2(state);
		ShortText.ColorStyle = GetContentShortTextColorStyle(state);
		ShortText.ColorAlign = GetContentShortTextColorAlign(state);
		ShortText.ColorAngle = GetContentShortTextColorAngle(state);
		ShortText.Image = GetContentShortTextImage(state);
		ShortText.ImageStyle = GetContentShortTextImageStyle(state);
		ShortText.ImageAlign = GetContentShortTextImageAlign(state);
		LongText.Font = GetContentLongTextFont(state);
		LongText.Hint = GetContentLongTextHint(state);
		LongText.Prefix = GetContentLongTextPrefix(state);
		LongText.Trim = GetContentLongTextTrim(state);
		LongText.TextH = GetContentLongTextH(state);
		LongText.TextV = GetContentLongTextV(state);
		LongText.MultiLineH = GetContentLongTextMultiLineH(state);
		LongText.MultiLine = GetContentLongTextMultiLine(state);
		LongText.Color1 = GetContentLongTextColor1(state);
		LongText.Color2 = GetContentLongTextColor2(state);
		LongText.ColorStyle = GetContentLongTextColorStyle(state);
		LongText.ColorAlign = GetContentLongTextColorAlign(state);
		LongText.ColorAngle = GetContentLongTextColorAngle(state);
		LongText.Image = GetContentLongTextImage(state);
		LongText.ImageStyle = GetContentLongTextImageStyle(state);
		LongText.ImageAlign = GetContentLongTextImageAlign(state);
		Padding = GetContentPadding(state);
		AdjacentGap = GetContentAdjacentGap(state);
	}
}
