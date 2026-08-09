using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class EditablePanel : EditablePanelBase
{
	private RectangleBorder mEquivalentPadding = new RectangleBorder(new BorderLine(Color.Empty, 2f));

	public EditablePanel()
	{
	}

	public EditablePanel(EditablePanel other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new EditablePanel(this);
	}

	public override void Draw(GraphicsCache graphics, RectangleF area)
	{
		if (BorderStyle == BorderStyle.System)
		{
			ControlPaint.DrawBorder3D(graphics.Graphics, Rectangle.Round(area), Border3DStyle.Flat, Border3DSide.All);
		}
	}

	public override RectangleF GetContentRectangle(RectangleF backGroundArea)
	{
		if (BorderStyle != BorderStyle.System)
		{
			return backGroundArea;
		}
		return mEquivalentPadding.GetContentRectangle(backGroundArea);
	}

	public override SizeF GetExtent(SizeF contentSize)
	{
		if (BorderStyle != BorderStyle.System)
		{
			return contentSize;
		}
		return mEquivalentPadding.GetExtent(contentSize);
	}

	public override RectanglePartType GetPointPartType(RectangleF area, PointF point, out float distanceFromBorder)
	{
		if (BorderStyle != BorderStyle.System)
		{
			distanceFromBorder = 0f;
			return RectanglePartType.ContentArea;
		}
		return mEquivalentPadding.GetPointPartType(area, point, out distanceFromBorder);
	}
}
