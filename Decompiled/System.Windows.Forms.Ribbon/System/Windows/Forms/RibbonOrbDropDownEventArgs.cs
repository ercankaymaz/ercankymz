using System.Drawing;

namespace System.Windows.Forms;

public class RibbonOrbDropDownEventArgs : RibbonRenderEventArgs
{
	public RibbonOrbDropDown RibbonOrbDropDown { get; }

	public RibbonOrbDropDownEventArgs(Ribbon ribbon, RibbonOrbDropDown dropDown, Graphics g, Rectangle clip)
		: base(ribbon, g, clip)
	{
		RibbonOrbDropDown = dropDown;
	}
}
