using System;

namespace DevAge.Windows.Forms;

public class SubButtonItemEventArgs : EventArgs
{
	private SubButtonItem p_Item;

	public SubButtonItem ButtonItem
	{
		get
		{
			return p_Item;
		}
		set
		{
			p_Item = value;
		}
	}

	public SubButtonItemEventArgs(SubButtonItem p_Item)
	{
		this.p_Item = p_Item;
	}
}
