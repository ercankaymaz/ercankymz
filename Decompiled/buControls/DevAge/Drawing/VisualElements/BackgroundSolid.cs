using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class BackgroundSolid : VisualElementBase
{
	private Color mBackColor = Color.Empty;

	public virtual Color BackColor
	{
		get
		{
			return mBackColor;
		}
		set
		{
			mBackColor = value;
		}
	}

	public BackgroundSolid()
	{
	}

	public BackgroundSolid(Color backcolor)
	{
		BackColor = backcolor;
	}

	public BackgroundSolid(BackgroundSolid other)
		: base(other)
	{
		BackColor = other.BackColor;
	}

	protected virtual bool ShouldSerializeBackColor()
	{
		return BackColor != Color.Empty;
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (BackColor != Color.Empty)
		{
			SolidBrush brush = graphics.BrushsCache.GetBrush(BackColor);
			graphics.Graphics.FillRectangle(brush, area);
		}
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		return SizeF.Empty;
	}

	public override object Clone()
	{
		return new BackgroundSolid(this);
	}
}
