using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

public interface IBackground : ICloneable, IVisualElement
{
	RectangleF GetBackgroundContentRectangle(MeasureHelper measure, RectangleF backGroundArea);

	SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize);
}
