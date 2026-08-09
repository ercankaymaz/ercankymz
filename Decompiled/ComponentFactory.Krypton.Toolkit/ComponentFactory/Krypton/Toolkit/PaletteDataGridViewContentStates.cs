#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDataGridViewContentStates : Storage, IPaletteContent
{
	private IPaletteContent _inherit;

	private InheritBool _draw;

	private PaletteTextHint _hint;

	private PaletteTextTrim _trim;

	private Color _color1;

	private Color _color2;

	private PaletteColorStyle _colorStyle;

	private PaletteRectangleAlign _colorAlign;

	private float _colorAngle;

	private Image _image;

	private PaletteImageStyle _imageStyle;

	private PaletteRectangleAlign _imageAlign;

	private InheritBool _multiLine;

	private PaletteRelativeAlign _multiLineH;

	[Browsable(false)]
	public override bool IsDefault => Draw == InheritBool.Inherit && Hint == PaletteTextHint.Inherit && Trim == PaletteTextTrim.Inherit && Color1 == Color.Empty && Color2 == Color.Empty && ColorStyle == PaletteColorStyle.Inherit && ColorAlign == PaletteRectangleAlign.Inherit && ColorAngle == -1f && Image == null && ImageStyle == PaletteImageStyle.Inherit && ImageAlign == PaletteRectangleAlign.Inherit && MultiLine == InheritBool.Inherit && MultiLineH == PaletteRelativeAlign.Inherit;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Should content be drawn.")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public InheritBool Draw
	{
		get
		{
			return _draw;
		}
		set
		{
			if (_draw != value)
			{
				_draw = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Text rendering hint for the content text.")]
	[DefaultValue(typeof(PaletteTextHint), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteTextHint Hint
	{
		get
		{
			return _hint;
		}
		set
		{
			if (value != _hint)
			{
				_hint = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Text trimming style for the content text.")]
	[DefaultValue(typeof(PaletteTextTrim), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteTextTrim Trim
	{
		get
		{
			return _trim;
		}
		set
		{
			if (value != _trim)
			{
				_trim = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Relative horizontal alignment of multiline content text.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRelativeAlign MultiLineH
	{
		get
		{
			return _multiLineH;
		}
		set
		{
			if (value != _multiLineH)
			{
				_multiLineH = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Flag indicating if multiline text is allowed..")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual InheritBool MultiLine
	{
		get
		{
			return _multiLine;
		}
		set
		{
			if (value != _multiLine)
			{
				_multiLine = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Main color for the text.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color1
	{
		get
		{
			return _color1;
		}
		set
		{
			if (value != _color1)
			{
				_color1 = value;
				OnSyncPropertyChanged(EventArgs.Empty);
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Secondary color for the text.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color2
	{
		get
		{
			return _color2;
		}
		set
		{
			if (value != _color2)
			{
				_color2 = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color drawing style for the text.")]
	[DefaultValue(typeof(PaletteColorStyle), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteColorStyle ColorStyle
	{
		get
		{
			return _colorStyle;
		}
		set
		{
			if (value != _colorStyle)
			{
				_colorStyle = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color alignment style for the text.")]
	[DefaultValue(typeof(PaletteRectangleAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRectangleAlign ColorAlign
	{
		get
		{
			return _colorAlign;
		}
		set
		{
			if (value != _colorAlign)
			{
				_colorAlign = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color angle for the text.")]
	[DefaultValue(-1f)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual float ColorAngle
	{
		get
		{
			return _colorAngle;
		}
		set
		{
			if (value != _colorAngle)
			{
				_colorAngle = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for the text.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			if (value != _image)
			{
				_image = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image style for the text.")]
	[DefaultValue(typeof(PaletteImageStyle), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteImageStyle ImageStyle
	{
		get
		{
			return _imageStyle;
		}
		set
		{
			if (value != _imageStyle)
			{
				_imageStyle = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image alignment style for the text.")]
	[DefaultValue(typeof(PaletteRectangleAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRectangleAlign ImageAlign
	{
		get
		{
			return _imageAlign;
		}
		set
		{
			if (value != _imageAlign)
			{
				_imageAlign = value;
				PerformNeedPaint();
			}
		}
	}

	protected IPaletteContent Inherit => _inherit;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event EventHandler SyncPropertyChanged;

	public PaletteDataGridViewContentStates(IPaletteContent inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
		NeedPaint = needPaint;
		_draw = InheritBool.Inherit;
		_hint = PaletteTextHint.Inherit;
		_trim = PaletteTextTrim.Inherit;
		_color1 = Color.Empty;
		_color2 = Color.Empty;
		_colorStyle = PaletteColorStyle.Inherit;
		_colorAlign = PaletteRectangleAlign.Inherit;
		_colorAngle = -1f;
		_imageStyle = PaletteImageStyle.Inherit;
		_imageAlign = PaletteRectangleAlign.Inherit;
		_multiLine = InheritBool.Inherit;
		_multiLineH = PaletteRelativeAlign.Inherit;
	}

	public void SetInherit(IPaletteContent inherit)
	{
		_inherit = inherit;
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		Draw = GetContentDraw(state);
		Hint = GetContentShortTextHint(state);
		Trim = GetContentShortTextTrim(state);
		Color1 = GetContentShortTextColor1(state);
		Color2 = GetContentShortTextColor2(state);
		ColorStyle = GetContentShortTextColorStyle(state);
		ColorAlign = GetContentShortTextColorAlign(state);
		ColorAngle = GetContentShortTextColorAngle(state);
		Image = GetContentShortTextImage(state);
		ImageStyle = GetContentShortTextImageStyle(state);
		ImageAlign = GetContentShortTextImageAlign(state);
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
		return _inherit.GetContentDrawFocus(state);
	}

	public PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		return _inherit.GetContentImageH(state);
	}

	public PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		return _inherit.GetContentImageV(state);
	}

	public PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		return _inherit.GetContentImageEffect(state);
	}

	public Color GetContentImageColorMap(PaletteState state)
	{
		return _inherit.GetContentImageColorMap(state);
	}

	public Color GetContentImageColorTo(PaletteState state)
	{
		return _inherit.GetContentImageColorTo(state);
	}

	public virtual Font GetContentShortTextFont(PaletteState state)
	{
		return _inherit.GetContentShortTextFont(state);
	}

	public virtual Font GetContentShortTextNewFont(PaletteState state)
	{
		return _inherit.GetContentShortTextNewFont(state);
	}

	public PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		if (_hint != PaletteTextHint.Inherit)
		{
			return _hint;
		}
		return _inherit.GetContentShortTextHint(state);
	}

	public PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return _inherit.GetContentShortTextPrefix(state);
	}

	public PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		if (_trim != PaletteTextTrim.Inherit)
		{
			return _trim;
		}
		return _inherit.GetContentShortTextTrim(state);
	}

	public virtual PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return _inherit.GetContentShortTextH(state);
	}

	public virtual PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		return _inherit.GetContentShortTextV(state);
	}

	public PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		if (_multiLineH != PaletteRelativeAlign.Inherit)
		{
			return _multiLineH;
		}
		return _inherit.GetContentShortTextMultiLineH(state);
	}

	public InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		if (_multiLine != InheritBool.Inherit)
		{
			return _multiLine;
		}
		return _inherit.GetContentShortTextMultiLine(state);
	}

	public Color GetContentShortTextColor1(PaletteState state)
	{
		if (_color1 != Color.Empty)
		{
			return _color1;
		}
		return _inherit.GetContentShortTextColor1(state);
	}

	public Color GetContentShortTextColor2(PaletteState state)
	{
		if (_color2 != Color.Empty)
		{
			return _color2;
		}
		return _inherit.GetContentShortTextColor2(state);
	}

	public PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		if (_colorStyle != PaletteColorStyle.Inherit)
		{
			return _colorStyle;
		}
		return _inherit.GetContentShortTextColorStyle(state);
	}

	public PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		if (_colorAlign != PaletteRectangleAlign.Inherit)
		{
			return _colorAlign;
		}
		return _inherit.GetContentShortTextColorAlign(state);
	}

	public float GetContentShortTextColorAngle(PaletteState state)
	{
		if (_colorAngle != -1f)
		{
			return _colorAngle;
		}
		return _inherit.GetContentShortTextColorAngle(state);
	}

	public Image GetContentShortTextImage(PaletteState state)
	{
		if (_image != null)
		{
			return _image;
		}
		return _inherit.GetContentShortTextImage(state);
	}

	public PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		if (_imageStyle != PaletteImageStyle.Inherit)
		{
			return _imageStyle;
		}
		return _inherit.GetContentShortTextImageStyle(state);
	}

	public PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		if (_imageAlign != PaletteRectangleAlign.Inherit)
		{
			return _imageAlign;
		}
		return _inherit.GetContentShortTextImageAlign(state);
	}

	public Font GetContentLongTextFont(PaletteState state)
	{
		return _inherit.GetContentLongTextFont(state);
	}

	public Font GetContentLongTextNewFont(PaletteState state)
	{
		return _inherit.GetContentLongTextNewFont(state);
	}

	public PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		return _inherit.GetContentLongTextHint(state);
	}

	public PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		return _inherit.GetContentLongTextPrefix(state);
	}

	public PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return _inherit.GetContentLongTextTrim(state);
	}

	public PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		return _inherit.GetContentLongTextH(state);
	}

	public PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		return _inherit.GetContentLongTextV(state);
	}

	public PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		return _inherit.GetContentLongTextMultiLineH(state);
	}

	public InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		return _inherit.GetContentLongTextMultiLine(state);
	}

	public Color GetContentLongTextColor1(PaletteState state)
	{
		return _inherit.GetContentLongTextColor1(state);
	}

	public Color GetContentLongTextColor2(PaletteState state)
	{
		return _inherit.GetContentLongTextColor2(state);
	}

	public PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		return _inherit.GetContentLongTextColorStyle(state);
	}

	public PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		return _inherit.GetContentLongTextColorAlign(state);
	}

	public float GetContentLongTextColorAngle(PaletteState state)
	{
		return _inherit.GetContentLongTextColorAngle(state);
	}

	public Image GetContentLongTextImage(PaletteState state)
	{
		return _inherit.GetContentLongTextImage(state);
	}

	public PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		return _inherit.GetContentLongTextImageStyle(state);
	}

	public PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		return _inherit.GetContentLongTextImageAlign(state);
	}

	public virtual Padding GetContentPadding(PaletteState state)
	{
		return _inherit.GetContentPadding(state);
	}

	public int GetContentAdjacentGap(PaletteState state)
	{
		return _inherit.GetContentAdjacentGap(state);
	}

	public PaletteContentStyle GetContentStyle()
	{
		return _inherit.GetContentStyle();
	}

	protected virtual void OnSyncPropertyChanged(EventArgs e)
	{
		if (this.SyncPropertyChanged != null)
		{
			this.SyncPropertyChanged(this, e);
		}
	}
}
