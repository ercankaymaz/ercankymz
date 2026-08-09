using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Windows.Forms;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class RichText : VisualElementBase, ICloneable, IVisualElement, IRichText
{
	private DevAge.Windows.Forms.RichText m_Value = null;

	private Color m_ForeColor = Control.DefaultForeColor;

	private ContentAlignment m_TextAlignment;

	private Font m_Font = Control.DefaultFont;

	private RotateFlipType m_RotateFlipType = RotateFlipType.RotateNoneFlipNone;

	[DefaultValue(null)]
	public virtual DevAge.Windows.Forms.RichText Value
	{
		get
		{
			return m_Value;
		}
		set
		{
			m_Value = value;
		}
	}

	public virtual Color ForeColor
	{
		get
		{
			return m_ForeColor;
		}
		set
		{
			m_ForeColor = value;
		}
	}

	public ContentAlignment TextAlignment
	{
		get
		{
			return m_TextAlignment;
		}
		set
		{
			m_TextAlignment = value;
		}
	}

	public virtual Font Font
	{
		get
		{
			return m_Font;
		}
		set
		{
			m_Font = value;
		}
	}

	public RotateFlipType RotateFlipType
	{
		get
		{
			return m_RotateFlipType;
		}
		set
		{
			m_RotateFlipType = value;
		}
	}

	public RichText()
	{
	}

	public RichText(DevAge.Windows.Forms.RichText value)
	{
		Value = value;
	}

	public RichText(RichText other)
		: base(other)
	{
		Value = other.Value;
		ForeColor = other.ForeColor;
		TextAlignment = other.TextAlignment;
		Font = other.Font;
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		Font defaultFont = Control.DefaultFont;
		if (!(maxSize != SizeF.Empty))
		{
			return measure.Graphics.MeasureString(Value.Rtf, defaultFont);
		}
		return measure.Graphics.MeasureString(Value.Rtf, defaultFont, maxSize);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		Color defaultForeColor = Control.DefaultForeColor;
		Font defaultFont = Control.DefaultFont;
		SolidBrush brush = graphics.BrushsCache.GetBrush(defaultForeColor);
		graphics.Graphics.DrawString(Value.Rtf, defaultFont, brush, area);
	}

	public override object Clone()
	{
		return new RichText(this);
	}
}
