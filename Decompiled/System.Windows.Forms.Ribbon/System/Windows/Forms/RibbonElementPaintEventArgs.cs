using System.Drawing;

namespace System.Windows.Forms;

public class RibbonElementPaintEventArgs : EventArgs
{
	public Rectangle Clip { get; }

	public Graphics Graphics { get; }

	public RibbonElementSizeMode Mode { get; }

	public Control Control { get; }

	internal RibbonElementPaintEventArgs(Rectangle clip, Graphics graphics, RibbonElementSizeMode mode)
	{
		Clip = clip;
		Graphics = graphics;
		Mode = mode;
	}

	internal RibbonElementPaintEventArgs(Rectangle clip, Graphics graphics, RibbonElementSizeMode mode, Control control)
		: this(clip, graphics, mode)
	{
		Control = control;
	}
}
