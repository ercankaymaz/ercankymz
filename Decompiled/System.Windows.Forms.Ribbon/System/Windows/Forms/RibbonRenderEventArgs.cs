using System.Drawing;

namespace System.Windows.Forms;

public class RibbonRenderEventArgs : EventArgs
{
	public Ribbon Ribbon { get; set; }

	public Graphics Graphics { get; set; }

	public Rectangle ClipRectangle { get; set; }

	public RibbonRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip)
	{
		Ribbon = owner;
		Graphics = g;
		ClipRectangle = clip;
	}
}
