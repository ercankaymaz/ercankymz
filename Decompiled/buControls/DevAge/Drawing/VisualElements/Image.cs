using System;
using System.ComponentModel;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Image : VisualElementBase, ICloneable, IVisualElement, IImage
{
	private System.Drawing.Image mValue = null;

	private bool mEnabled = true;

	[DefaultValue(null)]
	public System.Drawing.Image Value
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

	public Image()
	{
	}

	public Image(System.Drawing.Image value)
	{
		Value = value;
	}

	public Image(Image other)
		: base(other)
	{
		if (other.Value == null)
		{
			Value = null;
		}
		else
		{
			Value = (System.Drawing.Image)other.Value.Clone();
		}
		Enabled = other.Enabled;
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (Value == null)
		{
			return;
		}
		if (!Enabled)
		{
			using (System.Drawing.Image image = Utilities.CreateDisabledImage(Value, Color.White))
			{
				graphics.Graphics.DrawImage(image, area);
				return;
			}
		}
		graphics.Graphics.DrawImage(Value, Rectangle.Round(area));
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
		return new Image(this);
	}
}
