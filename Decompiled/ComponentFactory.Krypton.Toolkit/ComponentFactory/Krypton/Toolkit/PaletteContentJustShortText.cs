using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentJustShortText : PaletteContentJustText
{
	[KryptonPersist]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override PaletteContentText LongText => base.LongText;

	[KryptonPersist(false)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int AdjacentGap
	{
		get
		{
			return base.AdjacentGap;
		}
		set
		{
			base.AdjacentGap = value;
		}
	}

	public PaletteContentJustShortText()
		: this(null, null)
	{
	}

	public PaletteContentJustShortText(IPaletteContent inherit)
		: this(inherit, null)
	{
	}

	public PaletteContentJustShortText(IPaletteContent inherit, NeedPaintHandler needPaint)
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
		Padding = GetContentPadding(state);
	}
}
