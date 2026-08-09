#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawDebug : ViewLeaf
{
	private Size _preferredSize;

	private Color _color;

	public ViewDrawDebug(Size preferredSize, Color color)
	{
		_preferredSize = preferredSize;
		_color = color;
	}

	public override string ToString()
	{
		return "ViewDrawDebug:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return _preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		using SolidBrush brush = new SolidBrush(_color);
		context.Graphics.FillRectangle(brush, ClientRectangle);
	}
}
