using System;
using System.ComponentModel;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Icon : VisualElementBase, ICloneable, IVisualElement, IIcon
{
	private System.Drawing.Icon mValue = null;

	[DefaultValue(null)]
	public System.Drawing.Icon Value
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

	public Icon()
	{
	}

	public Icon(System.Drawing.Icon value)
	{
		Value = value;
	}

	public Icon(Icon other)
		: base(other)
	{
		if (other.Value == null)
		{
			Value = null;
		}
		else
		{
			Value = (System.Drawing.Icon)other.Value.Clone();
		}
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (Value != null)
		{
			graphics.Graphics.DrawIcon(Value, Rectangle.Round(area));
		}
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		if (Value == null)
		{
			return SizeF.Empty;
		}
		return Value.Size;
	}

	public override object Clone()
	{
		return new Icon(this);
	}
}
