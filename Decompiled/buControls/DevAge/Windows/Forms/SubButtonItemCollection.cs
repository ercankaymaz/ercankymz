using System.Collections;

namespace DevAge.Windows.Forms;

public class SubButtonItemCollection : CollectionBase
{
	public class Enumerator : IEnumerator
	{
		private IEnumerator ienumerator_0;

		public SubButtonItem Current => (SubButtonItem)ienumerator_0.Current;

		object IEnumerator.Current => (SubButtonItem)ienumerator_0.Current;

		public Enumerator(SubButtonItemCollection collection)
		{
			ienumerator_0 = ((CollectionBase)collection).GetEnumerator();
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

	public virtual SubButtonItem this[int index]
	{
		get
		{
			return (SubButtonItem)base.List[index];
		}
		set
		{
			base.List[index] = value;
		}
	}

	public SubButtonItemCollection()
	{
	}

	public SubButtonItemCollection(SubButtonItem[] items)
	{
		AddRange(items);
	}

	public SubButtonItemCollection(SubButtonItemCollection items)
	{
		AddRange(items);
	}

	public virtual void AddRange(SubButtonItem[] items)
	{
		foreach (SubButtonItem value in items)
		{
			base.List.Add(value);
		}
	}

	public virtual void AddRange(SubButtonItemCollection items)
	{
		foreach (SubButtonItem item in items)
		{
			base.List.Add(item);
		}
	}

	public virtual void Add(SubButtonItem value)
	{
		base.List.Add(value);
	}

	public virtual bool Contains(SubButtonItem value)
	{
		return base.List.Contains(value);
	}

	public virtual int IndexOf(SubButtonItem value)
	{
		return base.List.IndexOf(value);
	}

	public virtual void Insert(int index, SubButtonItem value)
	{
		base.List.Insert(index, value);
	}

	public virtual void Remove(SubButtonItem value)
	{
		base.List.Remove(value);
	}

	public new virtual Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}
}
