using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class EditablePanelThemed : EditablePanelBase
{
	private EditablePanel mStandard = new EditablePanel();

	private RectangleBorder mEquivalentPadding = new RectangleBorder(new BorderLine(Color.Empty, 2f));

	public override BorderStyle BorderStyle
	{
		get
		{
			return base.BorderStyle;
		}
		set
		{
			base.BorderStyle = value;
			mStandard.BorderStyle = value;
		}
	}

	public EditablePanelThemed()
	{
	}

	public EditablePanelThemed(EditablePanelThemed other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new EditablePanelThemed(this);
	}

	protected VisualStyleElement GetBackgroundElement()
	{
		return VisualStyleElement.TextBox.TextEdit.Normal;
	}

	protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
	{
		return new VisualStyleRenderer(element);
	}

	public override void Draw(GraphicsCache graphics, RectangleF area)
	{
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			mStandard.Draw(graphics, area);
		}
		else if (BorderStyle == BorderStyle.System)
		{
			GetRenderer(GetBackgroundElement()).DrawBackground(graphics.Graphics, Rectangle.Round(area));
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
