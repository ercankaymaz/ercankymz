using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace devDept.Eyeshot;

[Serializable]
[DebuggerDisplay("Count = {Count}")]
public class EyeshotCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
{
	internal readonly List<T> baseList;

	public int Capacity
	{
		get
		{
			return baseList.Capacity;
		}
		set
		{
			baseList.Capacity = value;
		}
	}

	public int Count => baseList.Count;

	public bool IsReadOnly => false;

	public virtual T this[int index]
	{
		get
		{
			return baseList[index];
		}
		set
		{
			baseList[index] = value;
		}
	}

	public EyeshotCollection()
	{
		baseList = new List<T>();
	}

	public EyeshotCollection(ICollection<T> c)
	{
		baseList = new List<T>(c);
	}

	public EyeshotCollection(int capacity)
	{
		baseList = new List<T>(capacity);
	}

	public virtual void AddRange(IEnumerable<T> collection)
	{
		baseList.AddRange(collection);
	}

	public virtual void Insert(int index, T item)
	{
		baseList.Insert(index, item);
	}

	public virtual void InsertRange(int index, IEnumerable<T> collection)
	{
		baseList.InsertRange(index, collection);
	}

	public virtual void Add(T item)
	{
		baseList.Add(item);
	}

	public virtual void Clear()
	{
		baseList.Clear();
	}

	public bool Contains(T item)
	{
		return baseList.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		baseList.CopyTo(array, arrayIndex);
	}

	public void Sort(IComparer<T> comparer)
	{
		baseList.Sort(comparer);
	}

	public virtual bool Remove(T item)
	{
		return baseList.Remove(item);
	}

	public virtual void RemoveAt(int index)
	{
		baseList.RemoveAt(index);
	}

	public virtual void RemoveRange(int index, int count)
	{
		baseList.RemoveRange(index, count);
	}

	public virtual int RemoveAll(Predicate<T> match)
	{
		return baseList.RemoveAll(match);
	}

	public void Reverse()
	{
		baseList.Reverse();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return baseList.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return baseList.GetEnumerator();
	}

	public int IndexOf(T item)
	{
		return baseList.IndexOf(item);
	}

	public override string ToString()
	{
		return baseList.ToString();
	}

	public bool Exists(Predicate<T> match)
	{
		return baseList.Exists(match);
	}

	public T Find(Predicate<T> match)
	{
		return baseList.Find(match);
	}

	public List<T> FindAll(Predicate<T> match)
	{
		return baseList.FindAll(match);
	}

	public int FindIndex(Predicate<T> match)
	{
		return baseList.FindIndex(match);
	}

	public int FindIndex(int startIndex, Predicate<T> match)
	{
		return baseList.FindIndex(startIndex, match);
	}

	public int FindIndex(int startIndex, int count, Predicate<T> match)
	{
		return baseList.FindIndex(startIndex, count, match);
	}

	public T FindLast(Predicate<T> match)
	{
		return baseList.FindLast(match);
	}

	public int FindLastIndex(Predicate<T> match)
	{
		return baseList.FindLastIndex(match);
	}

	public int FindLastIndex(int startIndex, Predicate<T> match)
	{
		return baseList.FindLastIndex(startIndex, match);
	}

	public int FindLastIndex(int startIndex, int count, Predicate<T> match)
	{
		return baseList.FindLastIndex(startIndex, count, match);
	}

	public void ForEach(Action<T> action)
	{
		baseList.ForEach(action);
	}
}
