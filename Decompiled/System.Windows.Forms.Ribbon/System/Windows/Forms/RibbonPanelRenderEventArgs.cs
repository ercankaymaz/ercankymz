using System.Drawing;

namespace System.Windows.Forms;

public sealed class RibbonPanelRenderEventArgs : RibbonRenderEventArgs
{
	public RibbonPanel Panel { get; set; }

	public Control Canvas { get; set; }

	public RibbonPanelRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonPanel panel, Control canvas)
		: base(owner, g, clip)
	{
		Panel = panel;
		Canvas = canvas;
	}
}
