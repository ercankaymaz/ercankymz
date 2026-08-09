using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawNull : ViewLayoutNull
{
	private Color _fillColor;

	public ViewDrawNull(Color fillColor)
	{
		_fillColor = fillColor;
	}

	public override string ToString()
	{
		return "ViewDrawNull:" + base.Id;
	}

	public override void RenderBefore(RenderContext context)
	{
		using SolidBrush brush = new SolidBrush(_fillColor);
		context.Graphics.FillRectangle(brush, ClientRectangle);
	}
}
