using System.Collections;
using SourceGrid.Cells;

namespace SourceGrid;

public class CellCollection : CollectionBase
{
	public class Enumerator : IEnumerator
	{
		private IEnumerator ienumerator_0;

		public ICellVirtual Current => (ICellVirtual)ienumerator_0.Current;

		object IEnumerator.Current => (ICellVirtual)ienumerator_0.Current;

		public Enumerator(CellCollection collection)
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

	public virtual ICellVirtual this[int index]
	{
		get
		{
			return (ICellVirtual)base.List[index];
		}
		set
		{
			base.List[index] = value;
		}
	}

	public CellCollection()
	{
	}

	public CellCollection(ICellVirtual[] items)
	{
		AddRange(items);
	}

	public CellCollection(CellCollection items)
	{
		AddRange(items);
	}

	public virtual void AddRange(ICellVirtual[] items)
	{
		foreach (ICellVirtual value in items)
		{
			base.List.Add(value);
		}
	}

	public virtual void AddRange(CellCollection items)
	{
		foreach (ICellVirtual item in items)
		{
			base.List.Add(item);
		}
	}

	public virtual void Add(ICellVirtual value)
	{
		base.List.Add(value);
	}

	public virtual bool Contains(ICellVirtual value)
	{
		return base.List.Contains(value);
	}

	public virtual int IndexOf(ICellVirtual value)
	{
		return base.List.IndexOf(value);
	}

	public virtual void Insert(int index, ICellVirtual value)
	{
		base.List.Insert(index, value);
	}

	public virtual void Remove(ICellVirtual value)
	{
		base.List.Remove(value);
	}

	public new virtual Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}
}
