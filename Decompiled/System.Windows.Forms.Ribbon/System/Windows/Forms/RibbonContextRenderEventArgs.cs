using System.Drawing;

namespace System.Windows.Forms;

public sealed class RibbonContextRenderEventArgs : RibbonRenderEventArgs
{
	public RibbonContext Context { get; set; }

	public RibbonContextRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonContext context)
		: base(owner, g, clip)
	{
		Context = context;
	}
}
