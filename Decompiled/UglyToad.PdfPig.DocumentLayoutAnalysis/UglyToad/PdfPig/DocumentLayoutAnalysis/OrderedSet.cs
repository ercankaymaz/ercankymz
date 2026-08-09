using System.Collections.Generic;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

internal class OrderedSet<T>
{
	private readonly HashSet<T> _set;

	private readonly List<T> _list;

	public int Count => _set.Count;

	public OrderedSet()
		: this((IEqualityComparer<T>)EqualityComparer<T>.Default)
	{
	}

	public OrderedSet(IEqualityComparer<T> comparer)
	{
		_set = new HashSet<T>(comparer);
		_list = new List<T>();
	}

	public bool TryAdd(T item)
	{
		if (_set.Contains(item))
		{
			return false;
		}
		_list.Add(item);
		_set.Add(item);
		return true;
	}

	public void Clear()
	{
		_list.Clear();
		_set.Clear();
	}

	public bool Contains(T item)
	{
		if (item != null)
		{
			return _set.Contains(item);
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		_list.CopyTo(array, arrayIndex);
	}

	public List<T> GetList()
	{
		return _list;
	}
}
