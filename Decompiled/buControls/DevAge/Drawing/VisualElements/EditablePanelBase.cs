using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class EditablePanelBase : ICloneable, IBorder, IEditablePanel
{
	private BorderStyle mBorderStyle = BorderStyle.System;

	public virtual BorderStyle BorderStyle
	{
		get
		{
			return mBorderStyle;
		}
		set
		{
			mBorderStyle = value;
		}
	}

	public EditablePanelBase()
	{
	}

	public EditablePanelBase(EditablePanelBase other)
	{
		BorderStyle = other.BorderStyle;
	}

	protected virtual bool ShouldSerializeBorderStyle()
	{
		return BorderStyle != BorderStyle.System;
	}

	public abstract RectangleF GetContentRectangle(RectangleF backGroundArea);

	public abstract SizeF GetExtent(SizeF contentSize);

	public abstract void Draw(GraphicsCache graphics, RectangleF area);

	public abstract RectanglePartType GetPointPartType(RectangleF area, PointF point, out float distanceFromBorder);

	public abstract object Clone();
}
