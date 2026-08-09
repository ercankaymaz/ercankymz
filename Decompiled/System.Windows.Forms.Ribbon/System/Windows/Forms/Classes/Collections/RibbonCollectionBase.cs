using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms.Classes.Collections;

public abstract class RibbonCollectionBase<T> : List<T>, IList, ICollection, IEnumerable where T : IRibbonElement
{
	private Ribbon _owner;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Ribbon Owner => _owner;

	public new virtual T this[int index]
	{
		get
		{
			return base[index];
		}
		set
		{
			SetOwner(value);
			base[index] = value;
			UpdateRegions();
		}
	}

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = (T)value;
		}
	}

	protected RibbonCollectionBase(Ribbon owner)
	{
		_owner = owner;
	}

	internal virtual void SetOwner(Ribbon owner)
	{
		_owner = owner;
	}

	internal void SetOwner(IEnumerable<T> items)
	{
		if (items == null)
		{
			return;
		}
		foreach (T item in items)
		{
			SetOwner(item);
		}
	}

	internal abstract void SetOwner(T item);

	internal void ClearOwner(IEnumerable<T> items)
	{
		if (items == null)
		{
			return;
		}
		foreach (T item in items)
		{
			ClearOwner(item);
		}
	}

	internal abstract void ClearOwner(T item);

	internal abstract void UpdateRegions();

	public new virtual void Add(T item)
	{
		SetOwner(item);
		base.Add(item);
		UpdateRegions();
	}

	public new virtual void AddRange(IEnumerable<T> items)
	{
		SetOwner(items);
		base.AddRange(items);
		UpdateRegions();
	}

	public new virtual void Insert(int index, T item)
	{
		SetOwner(item);
		base.Insert(index, item);
		UpdateRegions();
	}

	public new virtual bool Remove(T item)
	{
		if (base.Remove(item))
		{
			ClearOwner(item);
			UpdateRegions();
			return true;
		}
		return false;
	}

	public new virtual int RemoveAll(Predicate<T> predicate)
	{
		List<T> list = FindAll(predicate);
		int result = base.RemoveAll(predicate);
		if (list.Count > 0)
		{
			ClearOwner(list);
			UpdateRegions();
		}
		return result;
	}

	public new virtual void RemoveAt(int index)
	{
		T item = this[index];
		base.RemoveAt(index);
		ClearOwner(item);
		UpdateRegions();
	}

	public new virtual void RemoveRange(int index, int count)
	{
		List<T> range = GetRange(index, count);
		base.RemoveRange(index, count);
		if (range.Count > 0)
		{
			ClearOwner(range);
			UpdateRegions();
		}
	}

	public new virtual void Clear()
	{
		List<T> list = new List<T>(this);
		base.Clear();
		if (list.Count > 0)
		{
			ClearOwner(list);
			UpdateRegions();
		}
	}

	int IList.Add(object item)
	{
		Add((T)item);
		return base.Count - 1;
	}

	void IList.Insert(int index, object item)
	{
		Insert(index, (T)item);
	}

	void IList.Remove(object value)
	{
		Remove((T)value);
	}

	void IList.RemoveAt(int index)
	{
		RemoveAt(index);
	}

	void IList.Clear()
	{
		Clear();
	}
}
