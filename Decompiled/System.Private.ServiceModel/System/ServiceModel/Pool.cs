namespace System.ServiceModel;

public class Pool<T> where T : class
{
	private T[] _items;

	public int Count { get; private set; }

	public Pool(int maxCount)
	{
		_items = new T[maxCount];
	}

	public T Take()
	{
		if (Count > 0)
		{
			T result = _items[--Count];
			_items[Count] = null;
			return result;
		}
		return null;
	}

	public bool Return(T item)
	{
		if (Count < _items.Length)
		{
			_items[Count++] = item;
			return true;
		}
		return false;
	}

	public void Clear()
	{
		for (int i = 0; i < Count; i++)
		{
			_items[i] = null;
		}
		Count = 0;
	}
}
