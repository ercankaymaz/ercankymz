namespace System.Windows.Forms;

public class RibbonItemEventArgs : EventArgs
{
	public RibbonItem Item { get; set; }

	public RibbonItemEventArgs(RibbonItem item)
	{
		Item = item;
	}
}
