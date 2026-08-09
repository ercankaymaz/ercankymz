using System.Drawing;

namespace System.Windows.Forms;

public sealed class RibbonTabRenderEventArgs : RibbonRenderEventArgs
{
	public RibbonTab Tab { get; set; }

	public RibbonTabRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonTab tab)
		: base(owner, g, clip)
	{
		Tab = tab;
	}
}
