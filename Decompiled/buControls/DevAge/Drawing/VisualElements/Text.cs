using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Text : VisualElementBase, ICloneable, IVisualElement, IText
{
	private Font mFont = Control.DefaultFont;

	private Color mForeColor = Control.DefaultForeColor;

	private string mValue = null;

	private bool mEnabled = true;

	public virtual Font Font
	{
		get
		{
			return mFont;
		}
		set
		{
			mFont = value;
		}
	}

	public virtual Color ForeColor
	{
		get
		{
			return mForeColor;
		}
		set
		{
			mForeColor = value;
		}
	}

	[DefaultValue(null)]
	public virtual string Value
	{
		get
		{
			return mValue;
		}
		set
		{
			mValue = value;
		}
	}

	public bool Enabled
	{
		get
		{
			return mEnabled;
		}
		set
		{
			mEnabled = value;
		}
	}

	public Text()
	{
	}

	public Text(string value)
	{
		Value = value;
	}

	public Text(Text other)
		: base(other)
	{
		Value = other.Value;
		Font = other.Font;
		ForeColor = other.ForeColor;
		Enabled = other.Enabled;
	}

	private bool ShouldSerializeFont()
	{
		return Font.ToString() != Control.DefaultFont.ToString();
	}

	private bool ShouldSerializeForeColor()
	{
		return ForeColor != Control.DefaultForeColor;
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		if (!(maxSize != SizeF.Empty))
		{
			return measure.Graphics.MeasureString(Value, Font);
		}
		return measure.Graphics.MeasureString(Value, Font, maxSize);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		SolidBrush brush = (Enabled ? graphics.BrushsCache.GetBrush(ForeColor) : graphics.BrushsCache.GetBrush(Color.FromKnownColor(KnownColor.GrayText)));
		graphics.Graphics.DrawString(Value, Font, brush, area);
	}

	public override object Clone()
	{
		return new Text(this);
	}
}
