using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class VisualElementBase : ICloneable, IVisualElement
{
	private AnchorArea mAnchorArea = null;

	public virtual AnchorArea AnchorArea
	{
		get
		{
			return mAnchorArea;
		}
		set
		{
			mAnchorArea = value;
		}
	}

	protected VisualElementBase()
	{
	}

	public VisualElementBase(VisualElementBase other)
	{
		if (!(other.AnchorArea != null))
		{
			AnchorArea = null;
		}
		else
		{
			AnchorArea = (AnchorArea)other.AnchorArea.Clone();
		}
	}

	protected virtual bool ShouldSerializeAnchorArea()
	{
		return AnchorArea != null && !AnchorArea.IsEmpty;
	}

	public SizeF Measure(MeasureHelper measure, SizeF minSize, SizeF maxSize)
	{
		SizeF measureSize = OnMeasureContent(measure, maxSize);
		return Utilities.CheckMeasure(measureSize, minSize, maxSize);
	}

	protected abstract SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize);

	public void Draw(GraphicsCache graphics, RectangleF area, out RectangleF drawingArea)
	{
		using MeasureHelper measure = new MeasureHelper(graphics);
		drawingArea = GetDrawingArea(measure, area);
		OnDraw(graphics, drawingArea);
	}

	public void Draw(GraphicsCache graphics, RectangleF area)
	{
		Draw(graphics, area, out var _);
	}

	public RectangleF GetDrawingArea(MeasureHelper measure, RectangleF area)
	{
		RectangleF result = area;
		if (AnchorArea != null && !AnchorArea.IsEmpty)
		{
			SizeF content = Measure(measure, SizeF.Empty, SizeF.Empty);
			result = AnchorArea.CalculateArea(area, content, AnchorArea);
		}
		return result;
	}

	protected abstract void OnDraw(GraphicsCache graphics, RectangleF area);

	public virtual VisualElementList GetElementsAtPoint(MeasureHelper measure, RectangleF area, PointF point)
	{
		VisualElementList visualElementList = new VisualElementList();
		if (GetDrawingArea(measure, area).Contains(point))
		{
			visualElementList.Add(this);
		}
		return visualElementList;
	}

	public abstract object Clone();
}
