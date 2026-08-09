using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class TextRenderer : Text
{
	private TextFormatFlags mTextFormatFlags = TextFormatFlags.NoPrefix;

	public virtual TextFormatFlags TextFormatFlags
	{
		get
		{
			return mTextFormatFlags;
		}
		set
		{
			mTextFormatFlags = value;
		}
	}

	public TextRenderer()
	{
	}

	public TextRenderer(string value)
	{
		Value = value;
	}

	public TextRenderer(TextRenderer other)
		: base(other)
	{
		TextFormatFlags = other.TextFormatFlags;
	}

	public override object Clone()
	{
		return new TextRenderer(this);
	}

	protected virtual bool ShouldSerializeTextFormatFlags()
	{
		return TextFormatFlags != TextFormatFlags.NoPrefix;
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (Value != null && Value.Length != 0)
		{
			if (!base.Enabled)
			{
				System.Windows.Forms.TextRenderer.DrawText(graphics.Graphics, Value, Font, Rectangle.Round(area), Color.FromKnownColor(KnownColor.GrayText), TextFormatFlags);
			}
			else
			{
				System.Windows.Forms.TextRenderer.DrawText(graphics.Graphics, Value, Font, Rectangle.Round(area), ForeColor, TextFormatFlags);
			}
		}
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		Size proposedSize;
		if (!(maxSize != SizeF.Empty))
		{
			proposedSize = new Size(int.MaxValue, int.MaxValue);
		}
		else
		{
			proposedSize = Size.Ceiling(maxSize);
			if (proposedSize.Width == 0)
			{
				proposedSize.Width = int.MaxValue;
			}
			if (proposedSize.Height == 0)
			{
				proposedSize.Height = int.MaxValue;
			}
		}
		return System.Windows.Forms.TextRenderer.MeasureText(measure.Graphics, Value, Font, proposedSize, TextFormatFlags);
	}
}
