using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class SortIndicatorThemed : SortIndicator
{
	public SortIndicatorThemed()
	{
	}

	public SortIndicatorThemed(SortIndicatorThemed other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new SortIndicatorThemed(this);
	}

	protected VisualStyleElement GetSortElement()
	{
		if (SortStyle != HeaderSortStyle.Ascending)
		{
			if (SortStyle != HeaderSortStyle.Descending)
			{
				return null;
			}
			return VisualStyleElement.Header.SortArrow.SortedDown;
		}
		return VisualStyleElement.Header.SortArrow.SortedUp;
	}

	public VisualStyleRenderer GetRenderer(VisualStyleElement element)
	{
		return new VisualStyleRenderer(element);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (SortStyle == HeaderSortStyle.None || !Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetSortElement()))
		{
			base.OnDraw(graphics, area);
			return;
		}
		Rectangle bounds = Rectangle.Round(area);
		VisualStyleRenderer renderer = GetRenderer(GetSortElement());
		Size partSize = renderer.GetPartSize(graphics.Graphics, bounds, ThemeSizeType.Draw);
		renderer.DrawBackground(bounds: new Rectangle(bounds.Right - partSize.Width, bounds.Top, partSize.Width, partSize.Height), dc: graphics.Graphics);
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		if (SortStyle == HeaderSortStyle.None || !Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetSortElement()))
		{
			return base.OnMeasureContent(measure, maxSize);
		}
		VisualStyleRenderer renderer = GetRenderer(GetSortElement());
		return renderer.GetPartSize(measure.Graphics, ThemeSizeType.Draw);
	}
}
