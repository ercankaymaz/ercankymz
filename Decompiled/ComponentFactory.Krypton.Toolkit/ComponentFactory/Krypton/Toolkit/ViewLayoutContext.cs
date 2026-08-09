using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutContext : ViewContext
{
	private Rectangle _displayRectangle;

	public Rectangle DisplayRectangle
	{
		get
		{
			return _displayRectangle;
		}
		set
		{
			_displayRectangle = value;
		}
	}

	public ViewLayoutContext(Control control, IRenderer renderer)
		: this(null, control, control, null, renderer, control.Size)
	{
	}

	public ViewLayoutContext(ViewManager manager, Control control, Control alignControl, IRenderer renderer)
		: this(manager, control, alignControl, null, renderer, control.Size)
	{
	}

	public ViewLayoutContext(ViewManager manager, Control control, Control alignControl, IRenderer renderer, Size displaySize)
		: this(manager, control, alignControl, null, renderer, displaySize)
	{
	}

	public ViewLayoutContext(ViewManager manager, Form form, Rectangle formRect, IRenderer renderer)
		: base(manager, form, form, null, renderer)
	{
		DisplayRectangle = new Rectangle(Point.Empty, formRect.Size);
	}

	public ViewLayoutContext(ViewManager manager, Control control, Control alignControl, Graphics graphics, IRenderer renderer, Size displaySize)
		: base(manager, control, alignControl, graphics, renderer)
	{
		DisplayRectangle = new Rectangle(Point.Empty, displaySize);
	}
}
