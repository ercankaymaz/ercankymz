using System;

namespace ACadSharp;

public class CollectionChangedEventArgs : EventArgs
{
	public CadObject Item { get; }

	public CollectionChangedEventArgs(CadObject item)
	{
		Item = item;
	}
}
