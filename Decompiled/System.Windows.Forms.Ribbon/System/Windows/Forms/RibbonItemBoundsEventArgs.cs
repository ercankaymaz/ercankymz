using System.Drawing;

namespace System.Windows.Forms;

public class RibbonItemBoundsEventArgs : RibbonItemRenderEventArgs
{
	public Rectangle Bounds { get; set; }

	public RibbonItemBoundsEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonItem item, Rectangle bounds)
		: base(owner, g, clip, item)
	{
		Bounds = bounds;
	}
}
