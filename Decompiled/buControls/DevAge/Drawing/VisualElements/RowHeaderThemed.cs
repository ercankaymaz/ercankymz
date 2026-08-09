using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class RowHeaderThemed : RowHeaderBase
{
	private RowHeader mStandardRowHeader = new RowHeader();

	private ColumnHeaderThemed mColHeaderThemed = new ColumnHeaderThemed();

	private bool mRotateColHeaderIfNotDefined = true;

	public override ControlDrawStyle Style
	{
		get
		{
			return base.Style;
		}
		set
		{
			base.Style = value;
			mStandardRowHeader.Style = value;
			mColHeaderThemed.Style = value;
		}
	}

	public virtual bool RotateColHeaderIfNotDefined
	{
		get
		{
			return mRotateColHeaderIfNotDefined;
		}
		set
		{
			mRotateColHeaderIfNotDefined = value;
		}
	}

	public RowHeaderThemed()
	{
	}

	public RowHeaderThemed(RowHeaderThemed other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new RowHeaderThemed(this);
	}

	protected VisualStyleElement GetBackgroundElement()
	{
		if (Style != ControlDrawStyle.Hot)
		{
			if (Style != ControlDrawStyle.Pressed)
			{
				return VisualStyleElement.Header.ItemLeft.Normal;
			}
			return VisualStyleElement.Header.ItemLeft.Pressed;
		}
		return VisualStyleElement.Header.ItemLeft.Hot;
	}

	protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
	{
		return new VisualStyleRenderer(element);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		base.OnDraw(graphics, area);
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			if (RotateColHeaderIfNotDefined)
			{
				Bitmap bitmap = new Bitmap((int)area.Height, (int)area.Width);
				Graphics graphics2 = Graphics.FromImage(bitmap);
				try
				{
					Rectangle rectangle = new Rectangle(0, 0, (int)area.Height, (int)area.Width);
					using (GraphicsCache graphics3 = new GraphicsCache(graphics2))
					{
						mColHeaderThemed.Draw(graphics3, rectangle);
					}
					bitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
					graphics.Graphics.DrawImage(bitmap, area);
					return;
				}
				finally
				{
					graphics2.Dispose();
					bitmap.Dispose();
				}
			}
			mStandardRowHeader.Draw(graphics, area);
		}
		else
		{
			GetRenderer(GetBackgroundElement()).DrawBackground(graphics.Graphics, Rectangle.Round(area));
		}
	}

	public override RectangleF GetBackgroundContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
	{
		backGroundArea = base.GetBackgroundContentRectangle(measure, backGroundArea);
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			return mStandardRowHeader.GetBackgroundContentRectangle(measure, backGroundArea);
		}
		return GetRenderer(GetBackgroundElement()).GetBackgroundContentRectangle(measure.Graphics, Rectangle.Round(backGroundArea));
	}

	public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
	{
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			contentSize = mStandardRowHeader.GetBackgroundExtent(measure, contentSize);
		}
		else
		{
			Rectangle contentBounds = new Rectangle(new Point(0, 0), Size.Ceiling(contentSize));
			contentSize = GetRenderer(GetBackgroundElement()).GetBackgroundExtent(measure.Graphics, contentBounds).Size;
		}
		return base.GetBackgroundExtent(measure, contentSize);
	}
}
