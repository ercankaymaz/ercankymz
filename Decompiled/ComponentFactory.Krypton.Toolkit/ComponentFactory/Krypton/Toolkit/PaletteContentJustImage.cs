using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentJustImage : PaletteContent
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
	public override PaletteContentText ShortText => base.ShortText;

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

	public PaletteContentJustImage(IPaletteContent inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
	}

	public override void PopulateFromBase(PaletteState state)
	{
		Draw = GetContentDraw(state);
		Image.ImageH = GetContentImageH(state);
		Image.ImageV = GetContentImageV(state);
		Image.Effect = GetContentImageEffect(state);
		Image.ImageColorMap = GetContentImageColorMap(state);
		Image.ImageColorTo = GetContentImageColorTo(state);
		Padding = GetContentPadding(state);
	}
}
