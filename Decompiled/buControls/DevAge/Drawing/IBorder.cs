using System;
using System.Drawing;

namespace DevAge.Drawing;

public interface IBorder : ICloneable
{
	RectangleF GetContentRectangle(RectangleF backGroundArea);

	SizeF GetExtent(SizeF contentSize);

	void Draw(GraphicsCache graphics, RectangleF area);

	RectanglePartType GetPointPartType(RectangleF area, PointF point, out float distanceFromBorder);
}
