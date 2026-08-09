using System.Drawing;

namespace System.Windows.Forms;

public class RibbonDropDownRenderEventArgs : EventArgs
{
	public Graphics Graphics { get; set; }

	public RibbonDropDown DropDown { get; set; }

	public RibbonDropDownRenderEventArgs(Graphics g, RibbonDropDown dropDown)
	{
		Graphics = g;
		DropDown = dropDown;
	}
}
