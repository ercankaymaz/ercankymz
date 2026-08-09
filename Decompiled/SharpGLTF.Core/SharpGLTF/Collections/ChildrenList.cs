using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using SharpGLTF.Reflection;

namespace SharpGLTF.Collections;

[DebuggerDisplay("{Count}")]
public sealed class ChildrenList<T, TParent> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, IReflectionArray, IReflectionObject where T : class, IChildOfList<TParent> where TParent : class
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly TParent _Parent;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private List<T> _Collection;

	public T this[int index]
	{
		get
		{
			if (_Collection == null)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return _Collection[index];
		}
		set
		{
			_VerifyIsOrphan(value);
			if (_Collection == null)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_Collection[index] != value)
			{
				if (_Collection[index] != null)
				{
					_Collection[index].SetLogicalParent(null, -1);
				}
				_Collection[index] = value;
				if (_Collection[index] != null)
				{
					_Collection[index].SetLogicalParent(_Parent, index);
				}
			}
		}
	}

	public int Count
	{
		get
		{
			if (_Collection != null)
			{
				return _Collection.Count;
			}
			return 0;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool IsReadOnly => false;

	public ChildrenList(TParent parent)
	{
		Guard.NotNull(parent, "parent");
		_Parent = parent;
	}

	public bool Contains(T item)
	{
		return _Collection?.Contains(item) ?? false;
	}

	public int IndexOf(T item)
	{
		return _Collection?.IndexOf(item) ?? (-1);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (_Collection != null)
		{
			_Collection.CopyTo(array, arrayIndex);
		}
	}

	public void Add(T item)
	{
		_VerifyIsOrphan(item);
		if (_Collection == null)
		{
			_Collection = new List<T>();
		}
		int count = _Collection.Count;
		_Collection.Add(item);
		item.SetLogicalParent(_Parent, count);
	}

	public void Clear()
	{
		if (_Collection == null)
		{
			return;
		}
		foreach (T item in _Collection)
		{
			item.SetLogicalParent(null, -1);
		}
		_Collection = null;
	}

	public void Insert(int index, T item)
	{
		_VerifyIsOrphan(item);
		if (_Collection == null)
		{
			_Collection = new List<T>();
		}
		_Collection.Insert(index, item);
		for (int i = index; i < _Collection.Count; i++)
		{
			item = _Collection[i];
			item?.SetLogicalParent(_Parent, i);
		}
	}

	public bool Remove(T item)
	{
		int num = IndexOf(item);
		if (num < 0)
		{
			return false;
		}
		RemoveAt(num);
		return true;
	}

	public void RemoveAt(int index)
	{
		if (_Collection == null)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (index < 0 || index >= _Collection.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		T val = _Collection[index];
		_Collection.RemoveAt(index);
		val?.SetLogicalParent(null, -1);
		for (int i = index; i < _Collection.Count; i++)
		{
			val = _Collection[i];
			val.SetLogicalParent(_Parent, i);
		}
		if (_Collection.Count == 0)
		{
			_Collection = null;
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		List<T>.Enumerator? enumerator = _Collection?.GetEnumerator();
		if (!enumerator.HasValue)
		{
			return Enumerable.Empty<T>().GetEnumerator();
		}
		return enumerator.GetValueOrDefault();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		List<T>.Enumerator? enumerator = _Collection?.GetEnumerator();
		if (!enumerator.HasValue)
		{
			return Enumerable.Empty<T>().GetEnumerator();
		}
		return enumerator.GetValueOrDefault();
	}

	private static void _VerifyIsOrphan(T item)
	{
		Guard.NotNull(item, "item");
		Guard.MustBeNull(item.LogicalParent, "LogicalParent");
		Guard.MustBeEqualTo(-1, item.LogicalIndex, "LogicalIndex");
	}

	[Conditional("DEBUG")]
	private void _AssertItem(T item, int index)
	{
		TParent val = ((index >= 0) ? _Parent : null);
	}

	IEnumerable<FieldInfo> IReflectionObject.GetFields()
	{
		int i = 0;
		while (i < Count)
		{
			yield return ((IReflectionArray)this).GetField(i);
			int num = i + 1;
			i = num;
		}
	}

	FieldInfo IReflectionArray.GetField(int index)
	{
		return FieldInfo.From(index.ToString(CultureInfo.InvariantCulture), this, (ChildrenList<T, TParent> list) => list[index]);
	}

	public bool TryGetField(string name, out FieldInfo value)
	{
		if (int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out var index))
		{
			value = FieldInfo.From(name, this, (ChildrenList<T, TParent> list) => list[index]);
			return true;
		}
		value = default(FieldInfo);
		return false;
	}
}
