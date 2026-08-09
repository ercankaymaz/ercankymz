using System;

namespace ComponentFactory.Krypton.Toolkit;

public class TypedCollectionEventArgs<T> : EventArgs where T : class
{
	private T _item;

	private int _index;

	public T Item => _item;

	public int Index => _index;

	public TypedCollectionEventArgs(T item, int index)
	{
		_item = item;
		_index = index;
	}
}
