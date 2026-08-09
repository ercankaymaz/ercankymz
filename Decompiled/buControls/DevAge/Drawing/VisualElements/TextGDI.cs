using System;
using System.ComponentModel;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class TextGDI : Text
{
	private StringFormat mStringFormat = new StringFormat(StringFormat.GenericDefault);

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public virtual StringFormat StringFormat
	{
		get
		{
			return mStringFormat;
		}
		set
		{
			mStringFormat = value;
		}
	}

	public virtual ContentAlignment Alignment
	{
		get
		{
			return Utilities.StringFormatToContentAlignment(StringFormat);
		}
		set
		{
			Utilities.ApplyContentAlignmentToStringFormat(value, StringFormat);
		}
	}

	public TextGDI()
	{
	}

	public TextGDI(string value)
	{
		Value = value;
	}

	public TextGDI(TextGDI other)
		: base(other)
	{
		if (other.StringFormat == null)
		{
			StringFormat = null;
		}
		else
		{
			StringFormat = (StringFormat)other.StringFormat.Clone();
		}
	}

	protected virtual bool ShouldSerializeAlignment()
	{
		return false;
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (Value != null && Value.Length != 0)
		{
			SolidBrush brush = (base.Enabled ? graphics.BrushsCache.GetBrush(ForeColor) : graphics.BrushsCache.GetBrush(Color.FromKnownColor(KnownColor.GrayText)));
			graphics.Graphics.DrawString(Value, Font, brush, area, StringFormat);
		}
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		if (!(maxSize != SizeF.Empty))
		{
			return measure.Graphics.MeasureString(Value, Font, new SizeF(5000f, 5000f), StringFormat);
		}
		return measure.Graphics.MeasureString(Value, Font, maxSize, StringFormat);
	}

	public override object Clone()
	{
		return new TextGDI(this);
	}
}
