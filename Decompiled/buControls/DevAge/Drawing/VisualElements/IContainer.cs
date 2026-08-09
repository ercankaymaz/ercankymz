using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

public interface IContainer : ICloneable, IVisualElement
{
	RectangleF GetContentRectangle(MeasureHelper measure, RectangleF backGroundArea);

	SizeF GetExtent(MeasureHelper measure, SizeF contentSize);
}
