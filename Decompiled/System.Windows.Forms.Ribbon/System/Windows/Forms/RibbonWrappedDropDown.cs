namespace System.Windows.Forms;

internal class RibbonWrappedDropDown : ToolStripDropDown
{
	public RibbonWrappedDropDown()
	{
		DoubleBuffered = false;
		SetStyle(ControlStyles.Opaque, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.ResizeRedraw, value: false);
		AutoSize = false;
	}
}
