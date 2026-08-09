using System;

namespace DevAge.ComponentModel;

public class ItemDeletedEventArgs : EventArgs
{
	private object item;

	public object Item
	{
		get
		{
			return item;
		}
		set
		{
			item = value;
		}
	}

	public ItemDeletedEventArgs(object item)
	{
		this.item = item;
	}
}
