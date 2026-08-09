using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class ColumnHeaderThemed : ColumnHeaderBase
{
	private ColumnHeader mStandardHeader = new ColumnHeader();

	public override ControlDrawStyle Style
	{
		get
		{
			return base.Style;
		}
		set
		{
			base.Style = value;
			mStandardHeader.Style = value;
		}
	}

	public ColumnHeaderThemed()
	{
	}

	public ColumnHeaderThemed(ColumnHeaderThemed other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new ColumnHeaderThemed(this);
	}

	protected VisualStyleElement GetBackgroundElement()
	{
		if (Style != ControlDrawStyle.Hot)
		{
			if (Style != ControlDrawStyle.Pressed)
			{
				return VisualStyleElement.Header.Item.Normal;
			}
			return VisualStyleElement.Header.Item.Pressed;
		}
		return VisualStyleElement.Header.Item.Hot;
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
			mStandardHeader.Draw(graphics, area);
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
			return mStandardHeader.GetBackgroundContentRectangle(measure, backGroundArea);
		}
		return GetRenderer(GetBackgroundElement()).GetBackgroundContentRectangle(measure.Graphics, Rectangle.Round(backGroundArea));
	}

	public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
	{
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			contentSize = mStandardHeader.GetBackgroundExtent(measure, contentSize);
		}
		else
		{
			Rectangle contentBounds = new Rectangle(new Point(0, 0), Size.Ceiling(contentSize));
			contentSize = GetRenderer(GetBackgroundElement()).GetBackgroundExtent(measure.Graphics, contentBounds).Size;
		}
		return base.GetBackgroundExtent(measure, contentSize);
	}
}
