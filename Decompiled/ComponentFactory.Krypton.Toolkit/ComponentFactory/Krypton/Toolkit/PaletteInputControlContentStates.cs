#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteInputControlContentStates : Storage, IPaletteContent
{
	private IPaletteContent _inherit;

	private Font _font;

	private Color _color1;

	private Padding _padding;

	[Browsable(false)]
	public override bool IsDefault => Font == null && Color1 == Color.Empty && Padding.Equals(CommonHelper.InheritPadding);

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Font for drawing the content text.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Font Font
	{
		get
		{
			return _font;
		}
		set
		{
			if (value != _font)
			{
				_font = value;
				PerformNeedPaint(needLayout: true);
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
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding between the border and content drawing.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding Padding
	{
		get
		{
			return _padding;
		}
		set
		{
			if (!value.Equals(_padding))
			{
				_padding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	protected IPaletteContent Inherit => _inherit;

	public PaletteInputControlContentStates(IPaletteContent inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
		NeedPaint = needPaint;
		_font = null;
		_color1 = Color.Empty;
		_padding = CommonHelper.InheritPadding;
	}

	public void SetInherit(IPaletteContent inherit)
	{
		_inherit = inherit;
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		Font = GetContentShortTextFont(state);
		Color1 = GetContentShortTextColor1(state);
		Padding = GetContentPadding(state);
	}

	public InheritBool GetContentDraw(PaletteState state)
	{
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
		if (_font != null)
		{
			return _font;
		}
		return _inherit.GetContentShortTextFont(state);
	}

	public virtual Font GetContentShortTextNewFont(PaletteState state)
	{
		if (_font != null)
		{
			return _font;
		}
		return _inherit.GetContentShortTextNewFont(state);
	}

	public PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		return _inherit.GetContentShortTextHint(state);
	}

	public PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return _inherit.GetContentShortTextPrefix(state);
	}

	public PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
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
		return _inherit.GetContentShortTextMultiLineH(state);
	}

	public InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
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
		return _inherit.GetContentShortTextColor2(state);
	}

	public PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		return _inherit.GetContentShortTextColorStyle(state);
	}

	public PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		return _inherit.GetContentShortTextColorAlign(state);
	}

	public float GetContentShortTextColorAngle(PaletteState state)
	{
		return _inherit.GetContentShortTextColorAngle(state);
	}

	public Image GetContentShortTextImage(PaletteState state)
	{
		return _inherit.GetContentShortTextImage(state);
	}

	public PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		return _inherit.GetContentShortTextImageStyle(state);
	}

	public PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
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
		if (!_padding.Equals(CommonHelper.InheritPadding))
		{
			return _padding;
		}
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
}
