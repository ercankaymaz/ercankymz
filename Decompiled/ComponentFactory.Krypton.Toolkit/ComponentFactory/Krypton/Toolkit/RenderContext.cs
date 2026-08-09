#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class RenderContext : ViewContext
{
	private Rectangle _clipRect;

	public Rectangle ClipRect => _clipRect;

	public RenderContext(Control control, Graphics graphics, Rectangle clipRect, IRenderer renderer)
		: this(null, control, control, graphics, clipRect, renderer)
	{
	}

	public RenderContext(Control control, Control alignControl, Graphics graphics, Rectangle clipRect, IRenderer renderer)
		: this(null, control, alignControl, graphics, clipRect, renderer)
	{
	}

	public RenderContext(ViewManager manager, Control control, Control alignControl, Graphics graphics, Rectangle clipRect, IRenderer renderer)
		: base(manager, control, alignControl, graphics, renderer)
	{
		_clipRect = clipRect;
	}

	public Rectangle GetAlignedRectangle(PaletteRectangleAlign align, Rectangle local)
	{
		switch (align)
		{
		case PaletteRectangleAlign.Local:
			local.Inflate(2, 2);
			return local;
		case PaletteRectangleAlign.Control:
		{
			Rectangle empty = Rectangle.Empty;
			empty = ((base.AlignControl != base.Control) ? base.Control.RectangleToClient(base.AlignControl.RectangleToScreen(base.AlignControl.ClientRectangle)) : base.Control.ClientRectangle);
			empty.Inflate(2, 2);
			return empty;
		}
		case PaletteRectangleAlign.Form:
		{
			Rectangle result = base.Control.RectangleToClient(base.TopControl.RectangleToScreen(base.AlignControl.ClientRectangle));
			result.Inflate(2, 2);
			return result;
		}
		default:
			Debug.Assert(condition: false);
			throw new ArgumentOutOfRangeException("align");
		}
	}
}
