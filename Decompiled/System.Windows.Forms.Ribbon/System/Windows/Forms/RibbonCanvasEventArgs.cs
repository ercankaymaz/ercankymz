using System.Drawing;

namespace System.Windows.Forms;

public class RibbonCanvasEventArgs : EventArgs
{
	public object RelatedObject { get; set; }

	public Ribbon Owner { get; set; }

	public Graphics Graphics { get; set; }

	public Rectangle Bounds { get; set; }

	public Control Canvas { get; set; }

	public RibbonCanvasEventArgs(Ribbon owner, Graphics g, Rectangle bounds, Control canvas, object relatedObject)
	{
		Owner = owner;
		Graphics = g;
		Bounds = bounds;
		Canvas = canvas;
		RelatedObject = relatedObject;
	}
}
