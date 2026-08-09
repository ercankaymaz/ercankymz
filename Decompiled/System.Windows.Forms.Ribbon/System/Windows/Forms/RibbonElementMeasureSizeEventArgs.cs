using System.Drawing;

namespace System.Windows.Forms;

public class RibbonElementMeasureSizeEventArgs : EventArgs
{
	public RibbonElementSizeMode SizeMode { get; }

	public Graphics Graphics { get; }

	internal RibbonElementMeasureSizeEventArgs(Graphics graphics, RibbonElementSizeMode sizeMode)
	{
		Graphics = graphics;
		SizeMode = sizeMode;
	}
}
