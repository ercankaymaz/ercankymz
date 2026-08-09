using System.Drawing;

namespace System.Windows.Forms;

public sealed class RibbonButtonRenderEventArgs : RibbonRenderEventArgs
{
	public RibbonButton Button { get; set; }

	public RibbonButtonRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonButton button)
		: base(owner, g, clip)
	{
		Button = button;
	}
}
