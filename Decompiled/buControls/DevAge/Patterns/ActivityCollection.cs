using System;
using System.Collections;
using ns27;

namespace DevAge.Patterns;

public class ActivityCollection : IEnumerable, ICollection
{
	public class Enumerator : IEnumerator
	{
		private IEnumerator ienumerator_0;

		public IActivity Current => (IActivity)ienumerator_0.Current;

		object IEnumerator.Current => (IActivity)ienumerator_0.Current;

		public Enumerator(ActivityCollection collection)
		{
			ienumerator_0 = collection.arrayList_0.GetEnumerator();
		}

		public bool MoveNext()
		{
			return ienumerator_0.MoveNext();
		}

		public void Reset()
		{
			ienumerator_0.Reset();
		}
	}

	private ArrayList arrayList_0 = new ArrayList();

	private IActivity parentActivity;

	public int Count => arrayList_0.Count;

	public virtual IActivity this[int index] => (IActivity)arrayList_0[index];

	public bool IsSynchronized => arrayList_0.IsSynchronized;

	public object SyncRoot => arrayList_0.SyncRoot;

	public ActivityCollection(IActivity parentActivity)
	{
		this.parentActivity = parentActivity;
	}

	public virtual bool Contains(IActivity value)
	{
		return arrayList_0.Contains(value);
	}

	public virtual int IndexOf(IActivity value)
	{
		return arrayList_0.IndexOf(value);
	}

	public virtual void Add(IActivity value)
	{
		Insert(Count, value);
	}

	public virtual void Insert(int index, IActivity value)
	{
		Class76.smethod_697(this);
		arrayList_0.Insert(index, value);
		value.Parent = parentActivity;
	}

	public virtual void Remove(IActivity value)
	{
		Class76.smethod_697(this);
		arrayList_0.Remove(value);
		value.Parent = null;
	}

	public virtual Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	public void CopyTo(Array array, int index)
	{
		arrayList_0.CopyTo(array, index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
