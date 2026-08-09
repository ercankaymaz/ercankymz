using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class BackgroundBase : VisualElementBase, ICloneable, IVisualElement, IBackground
{
	public BackgroundBase()
	{
	}

	public BackgroundBase(BackgroundBase other)
		: base(other)
	{
	}

	public virtual RectangleF GetBackgroundContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
	{
		return backGroundArea;
	}

	public virtual SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
	{
		return contentSize;
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		SizeF empty = SizeF.Empty;
		return GetBackgroundExtent(measure, empty);
	}
}
