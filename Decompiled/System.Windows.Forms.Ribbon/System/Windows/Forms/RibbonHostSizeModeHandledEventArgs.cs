using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonHostSizeModeHandledEventArgs : HandledEventArgs
{
	public RibbonElementSizeMode SizeMode { get; }

	public Graphics Graphics { get; }

	public Size ControlSize { get; set; }

	internal RibbonHostSizeModeHandledEventArgs(Graphics graphics, RibbonElementSizeMode sizeMode)
	{
		Graphics = graphics;
		SizeMode = sizeMode;
	}
}
