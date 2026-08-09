using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

public interface IVisualElement : ICloneable
{
	AnchorArea AnchorArea { get; set; }

	RectangleF GetDrawingArea(MeasureHelper measure, RectangleF area);

	SizeF Measure(MeasureHelper measure, SizeF minSize, SizeF maxSize);

	void Draw(GraphicsCache graphics, RectangleF area);

	void Draw(GraphicsCache graphics, RectangleF area, out RectangleF drawingArea);

	VisualElementList GetElementsAtPoint(MeasureHelper measure, RectangleF area, PointF point);
}
