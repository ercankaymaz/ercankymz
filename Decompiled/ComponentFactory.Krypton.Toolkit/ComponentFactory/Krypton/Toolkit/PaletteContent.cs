#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContent : Storage, IPaletteContent
{
	private class InternalStorage
	{
		public InheritBool ContentDraw;

		public InheritBool ContentDrawFocus;

		public Padding ContentPadding;

		public int ContentAdjacentGap;

		public bool IsDefault => ContentDraw == InheritBool.Inherit && ContentDrawFocus == InheritBool.Inherit && ContentPadding.Equals(CommonHelper.InheritPadding) && ContentAdjacentGap == -1;

		public InternalStorage()
		{
			ContentDraw = InheritBool.Inherit;
			ContentDrawFocus = InheritBool.Inherit;
			ContentPadding = CommonHelper.InheritPadding;
			ContentAdjacentGap = -1;
		}
	}

	private InternalStorage _storage;

	private PaletteContentImage _image;

	private PaletteContentText _shortText;

	private PaletteContentText _longText;

	private IPaletteContent _inherit;

	[Browsable(false)]
	public override bool IsDefault => _image.IsDefault && _shortText.IsDefault && _longText.IsDefault && (_storage == null || _storage.IsDefault);

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Should content be drawn.")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual InheritBool Draw
	{
		get
		{
			if (_storage == null)
			{
				return InheritBool.Inherit;
			}
			return _storage.ContentDraw;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentDraw != value)
				{
					_storage.ContentDraw = value;
					OnPropertyChanged("Draw");
					PerformNeedPaint();
				}
			}
			else if (value != InheritBool.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentDraw = value;
				OnPropertyChanged("Draw");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Should content be drawn with focus indication..")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual InheritBool DrawFocus
	{
		get
		{
			if (_storage == null)
			{
				return InheritBool.Inherit;
			}
			return _storage.ContentDrawFocus;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentDrawFocus != value)
				{
					_storage.ContentDrawFocus = value;
					OnPropertyChanged("DrawFocus");
					PerformNeedPaint();
				}
			}
			else if (value != InheritBool.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentDrawFocus = value;
				OnPropertyChanged("DrawFocus");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining image appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteContentImage Image => _image;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining short text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteContentText ShortText => _shortText;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining long text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteContentText LongText => _longText;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding between the border and content drawing.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Padding Padding
	{
		get
		{
			if (_storage == null)
			{
				return CommonHelper.InheritPadding;
			}
			return _storage.ContentPadding;
		}
		set
		{
			if (_storage != null)
			{
				if (!value.Equals(_storage.ContentPadding))
				{
					_storage.ContentPadding = value;
					OnPropertyChanged("Padding");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (!value.Equals(CommonHelper.InheritPadding))
			{
				_storage = new InternalStorage();
				_storage.ContentPadding = value;
				OnPropertyChanged("Padding");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Spacing gap between adjacent content items.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual int AdjacentGap
	{
		get
		{
			if (_storage == null)
			{
				return -1;
			}
			return _storage.ContentAdjacentGap;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentAdjacentGap != value)
				{
					_storage.ContentAdjacentGap = value;
					OnPropertyChanged("AdjacentGap");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != -1)
			{
				_storage = new InternalStorage();
				_storage.ContentAdjacentGap = value;
				OnPropertyChanged("AdjacentGap");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event PropertyChangedEventHandler PropertyChanged;

	public PaletteContent(IPaletteContent inherit)
		: this(inherit, null)
	{
	}

	public PaletteContent(IPaletteContent inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
		NeedPaint = needPaint;
		_image = new PaletteContentImage(needPaint);
		_shortText = new PaletteContentText(needPaint);
		_longText = new PaletteContentText(needPaint);
	}

	public void SetInherit(IPaletteContent inherit)
	{
		_inherit = inherit;
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		Draw = GetContentDraw(state);
		DrawFocus = GetContentDrawFocus(state);
		Image.ImageH = GetContentImageH(state);
		Image.ImageV = GetContentImageV(state);
		Image.Effect = GetContentImageEffect(state);
		Image.ImageColorMap = GetContentImageColorMap(state);
		Image.ImageColorTo = GetContentImageColorTo(state);
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

	public InheritBool GetContentDraw(PaletteState state)
	{
		if (Draw != InheritBool.Inherit)
		{
			return Draw;
		}
		return _inherit.GetContentDraw(state);
	}

	public InheritBool GetContentDrawFocus(PaletteState state)
	{
		if (DrawFocus != InheritBool.Inherit)
		{
			return DrawFocus;
		}
		return _inherit.GetContentDrawFocus(state);
	}

	private bool ShouldSerializeImage()
	{
		return !_image.IsDefault;
	}

	public PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		if (_image.ImageH != PaletteRelativeAlign.Inherit)
		{
			return _image.ImageH;
		}
		return _inherit.GetContentImageH(state);
	}

	public PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		if (_image.ImageV != PaletteRelativeAlign.Inherit)
		{
			return _image.ImageV;
		}
		return _inherit.GetContentImageV(state);
	}

	public PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		if (_image.Effect != PaletteImageEffect.Inherit)
		{
			return _image.Effect;
		}
		return _inherit.GetContentImageEffect(state);
	}

	public Color GetContentImageColorMap(PaletteState state)
	{
		if (_image.ImageColorMap != Color.Empty)
		{
			return _image.ImageColorMap;
		}
		return _inherit.GetContentImageColorMap(state);
	}

	public Color GetContentImageColorTo(PaletteState state)
	{
		if (_image.ImageColorTo != Color.Empty)
		{
			return _image.ImageColorTo;
		}
		return _inherit.GetContentImageColorTo(state);
	}

	private bool ShouldSerializeShortText()
	{
		return !_shortText.IsDefault;
	}

	public Font GetContentShortTextFont(PaletteState state)
	{
		if (_shortText.Font != null)
		{
			return _shortText.Font;
		}
		return _inherit.GetContentShortTextFont(state);
	}

	public Font GetContentShortTextNewFont(PaletteState state)
	{
		if (_shortText.Font != null)
		{
			return _shortText.Font;
		}
		return _inherit.GetContentShortTextNewFont(state);
	}

	public PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		if (_shortText.Hint != PaletteTextHint.Inherit)
		{
			return _shortText.Hint;
		}
		return _inherit.GetContentShortTextHint(state);
	}

	public PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		if (_shortText.Prefix != PaletteTextHotkeyPrefix.Inherit)
		{
			return _shortText.Prefix;
		}
		return _inherit.GetContentShortTextPrefix(state);
	}

	public PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		if (_shortText.Trim != PaletteTextTrim.Inherit)
		{
			return _shortText.Trim;
		}
		return _inherit.GetContentShortTextTrim(state);
	}

	public PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		if (_shortText.TextH != PaletteRelativeAlign.Inherit)
		{
			return _shortText.TextH;
		}
		return _inherit.GetContentShortTextH(state);
	}

	public PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		if (_shortText.TextV != PaletteRelativeAlign.Inherit)
		{
			return _shortText.TextV;
		}
		return _inherit.GetContentShortTextV(state);
	}

	public PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		if (_shortText.MultiLineH != PaletteRelativeAlign.Inherit)
		{
			return _shortText.MultiLineH;
		}
		return _inherit.GetContentShortTextMultiLineH(state);
	}

	public InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		if (_shortText.MultiLine != InheritBool.Inherit)
		{
			return _shortText.MultiLine;
		}
		return _inherit.GetContentShortTextMultiLine(state);
	}

	public Color GetContentShortTextColor1(PaletteState state)
	{
		if (ShortText.Color1 != Color.Empty)
		{
			return ShortText.Color1;
		}
		return _inherit.GetContentShortTextColor1(state);
	}

	public Color GetContentShortTextColor2(PaletteState state)
	{
		if (ShortText.Color2 != Color.Empty)
		{
			return ShortText.Color2;
		}
		return _inherit.GetContentShortTextColor2(state);
	}

	public PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		if (ShortText.ColorStyle != PaletteColorStyle.Inherit)
		{
			return ShortText.ColorStyle;
		}
		return _inherit.GetContentShortTextColorStyle(state);
	}

	public PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		if (ShortText.ColorAlign != PaletteRectangleAlign.Inherit)
		{
			return ShortText.ColorAlign;
		}
		return _inherit.GetContentShortTextColorAlign(state);
	}

	public float GetContentShortTextColorAngle(PaletteState state)
	{
		if (ShortText.ColorAngle != -1f)
		{
			return ShortText.ColorAngle;
		}
		return _inherit.GetContentShortTextColorAngle(state);
	}

	public Image GetContentShortTextImage(PaletteState state)
	{
		if (ShortText.Image != null)
		{
			return ShortText.Image;
		}
		return _inherit.GetContentShortTextImage(state);
	}

	public PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		if (ShortText.ImageStyle != PaletteImageStyle.Inherit)
		{
			return ShortText.ImageStyle;
		}
		return _inherit.GetContentShortTextImageStyle(state);
	}

	public PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		if (ShortText.ImageAlign != PaletteRectangleAlign.Inherit)
		{
			return ShortText.ImageAlign;
		}
		return _inherit.GetContentShortTextImageAlign(state);
	}

	private bool ShouldSerializeLongText()
	{
		return !_longText.IsDefault;
	}

	public Font GetContentLongTextFont(PaletteState state)
	{
		if (_longText.Font != null)
		{
			return _longText.Font;
		}
		return _inherit.GetContentLongTextFont(state);
	}

	public Font GetContentLongTextNewFont(PaletteState state)
	{
		if (_longText.Font != null)
		{
			return _longText.Font;
		}
		return _inherit.GetContentLongTextNewFont(state);
	}

	public PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		if (_longText.Hint != PaletteTextHint.Inherit)
		{
			return _longText.Hint;
		}
		return _inherit.GetContentLongTextHint(state);
	}

	public PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		if (_longText.Prefix != PaletteTextHotkeyPrefix.Inherit)
		{
			return _longText.Prefix;
		}
		return _inherit.GetContentLongTextPrefix(state);
	}

	public PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		if (_longText.Trim != PaletteTextTrim.Inherit)
		{
			return _longText.Trim;
		}
		return _inherit.GetContentLongTextTrim(state);
	}

	public PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		if (_longText.TextH != PaletteRelativeAlign.Inherit)
		{
			return _longText.TextH;
		}
		return _inherit.GetContentLongTextH(state);
	}

	public PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		if (_longText.TextV != PaletteRelativeAlign.Inherit)
		{
			return _longText.TextV;
		}
		return _inherit.GetContentLongTextV(state);
	}

	public PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		if (_longText.MultiLineH != PaletteRelativeAlign.Inherit)
		{
			return _longText.MultiLineH;
		}
		return _inherit.GetContentLongTextMultiLineH(state);
	}

	public InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		if (_longText.MultiLine != InheritBool.Inherit)
		{
			return _longText.MultiLine;
		}
		return _inherit.GetContentLongTextMultiLine(state);
	}

	public Color GetContentLongTextColor1(PaletteState state)
	{
		if (LongText.Color1 != Color.Empty)
		{
			return LongText.Color1;
		}
		return _inherit.GetContentLongTextColor1(state);
	}

	public Color GetContentLongTextColor2(PaletteState state)
	{
		if (LongText.Color2 != Color.Empty)
		{
			return LongText.Color2;
		}
		return _inherit.GetContentLongTextColor2(state);
	}

	public PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		if (LongText.ColorStyle != PaletteColorStyle.Inherit)
		{
			return LongText.ColorStyle;
		}
		return _inherit.GetContentLongTextColorStyle(state);
	}

	public PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		if (LongText.ColorAlign != PaletteRectangleAlign.Inherit)
		{
			return LongText.ColorAlign;
		}
		return _inherit.GetContentLongTextColorAlign(state);
	}

	public float GetContentLongTextColorAngle(PaletteState state)
	{
		if (LongText.ColorAngle != -1f)
		{
			return LongText.ColorAngle;
		}
		return _inherit.GetContentLongTextColorAngle(state);
	}

	public Image GetContentLongTextImage(PaletteState state)
	{
		if (LongText.Image != null)
		{
			return LongText.Image;
		}
		return _inherit.GetContentLongTextImage(state);
	}

	public PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		if (LongText.ImageStyle != PaletteImageStyle.Inherit)
		{
			return LongText.ImageStyle;
		}
		return _inherit.GetContentLongTextImageStyle(state);
	}

	public PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		if (LongText.ImageAlign != PaletteRectangleAlign.Inherit)
		{
			return LongText.ImageAlign;
		}
		return _inherit.GetContentLongTextImageAlign(state);
	}

	public void ResetPadding()
	{
		Padding = CommonHelper.InheritPadding;
	}

	public Padding GetContentPadding(PaletteState state)
	{
		Padding contentPadding = _inherit.GetContentPadding(state);
		Padding padding = Padding;
		if (padding.Left != -1)
		{
			contentPadding.Left = padding.Left;
		}
		if (padding.Right != -1)
		{
			contentPadding.Right = padding.Right;
		}
		if (padding.Top != -1)
		{
			contentPadding.Top = padding.Top;
		}
		if (padding.Bottom != -1)
		{
			contentPadding.Bottom = padding.Bottom;
		}
		return contentPadding;
	}

	public void ResetAdjacentGap()
	{
		AdjacentGap = -1;
	}

	public int GetContentAdjacentGap(PaletteState state)
	{
		if (AdjacentGap != -1)
		{
			return AdjacentGap;
		}
		return _inherit.GetContentAdjacentGap(state);
	}

	public PaletteContentStyle GetContentStyle()
	{
		return _inherit.GetContentStyle();
	}

	protected virtual void OnPropertyChanged(string property)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}
