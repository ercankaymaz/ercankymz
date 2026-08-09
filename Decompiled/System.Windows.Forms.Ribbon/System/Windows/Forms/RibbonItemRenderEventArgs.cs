using System.Drawing;

namespace System.Windows.Forms;

public class RibbonItemRenderEventArgs : RibbonRenderEventArgs
{
	public RibbonItem Item { get; set; }

	public RibbonItemRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonItem item)
		: base(owner, g, clip)
	{
		Item = item;
	}
}
