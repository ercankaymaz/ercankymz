using System;
using System.Collections;
using System.Collections.Generic;
using SourceGrid.Selection;
using ns27;

namespace SourceGrid;

[Serializable]
public class RangeRegion : IEnumerable, IEnumerable<Range>, ICollection<Range>
{
	internal RangeCollection m_RangeCollection = new RangeCollection();

	internal bool m_bValidated = false;

	public Range this[int index] => m_RangeCollection[index];

	public int Count => m_RangeCollection.Count;

	public bool IsReadOnly => false;

	public event RangeRegionCancelEventHandler AddingRange;

	public event RangeRegionCancelEventHandler RemovingRange;

	public event RangeRegionEventHandler AddedRange;

	public event RangeRegionEventHandler RemovedRange;

	public event RangeRegionChangedEventHandler Changed;

	public RangeRegion()
	{
	}

	public RangeRegion(Position position)
	{
		if (!position.IsEmpty())
		{
			m_RangeCollection.Add(new Range(position));
		}
	}

	public RangeRegion(Range range)
	{
		if (!range.IsEmpty())
		{
			m_RangeCollection.Add(range);
		}
	}

	public RangeRegion(RangeRegion other)
	{
		m_RangeCollection.AddRange(other.m_RangeCollection);
	}

	public virtual bool IsEmpty()
	{
		if (m_RangeCollection.Count != 0)
		{
			return false;
		}
		return true;
	}

	public virtual PositionCollection GetCellsPositions()
	{
		PositionCollection positionCollection = new PositionCollection();
		for (int i = 0; i < m_RangeCollection.Count; i++)
		{
			positionCollection.AddRange(m_RangeCollection[i].GetCellsPositions());
		}
		return positionCollection;
	}

	public virtual int[] GetRowsIndex()
	{
		RangeMergerByRows rangeMergerByRows = new RangeMergerByRows();
		using (IEnumerator<Range> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Range current = enumerator.Current;
				rangeMergerByRows.AddRange(current);
			}
		}
		IList<int> rowsIndex = rangeMergerByRows.GetRowsIndex();
		int[] array = new int[rowsIndex.Count];
		rowsIndex.CopyTo(array, 0);
		return array;
	}

	public virtual int[] GetColumnsIndex()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < Count; i++)
		{
			for (int j = this[i].Start.Column; j <= this[i].End.Column; j++)
			{
				if (!arrayList.Contains(j))
				{
					arrayList.Add(j);
				}
			}
		}
		int[] array = new int[arrayList.Count];
		arrayList.CopyTo(array, 0);
		return array;
	}

	public virtual bool Contains(Position p_Cell)
	{
		if (!p_Cell.IsEmpty() && !IsEmpty())
		{
			for (int i = 0; i < m_RangeCollection.Count; i++)
			{
				if (m_RangeCollection[i].Contains(p_Cell))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public virtual bool Contains(Range p_Range)
	{
		if (!p_Range.IsEmpty() && !IsEmpty())
		{
			if (p_Range.ColumnsCount != 1 || p_Range.RowsCount != 1)
			{
				for (int i = 0; i < m_RangeCollection.Count; i++)
				{
					if (m_RangeCollection[i].Contains(p_Range))
					{
						return true;
					}
				}
				PositionCollection cellsPositions = p_Range.GetCellsPositions();
				for (int j = 0; j < cellsPositions.Count; j++)
				{
					if (!Contains(cellsPositions[j]))
					{
						return false;
					}
				}
				return true;
			}
			return Contains(p_Range.Start);
		}
		return false;
	}

	public virtual bool Contains(RangeRegion p_Range)
	{
		if (!p_Range.IsEmpty() && !IsEmpty())
		{
			PositionCollection cellsPositions = p_Range.GetCellsPositions();
			for (int i = 0; i < cellsPositions.Count; i++)
			{
				if (!Contains(cellsPositions[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public virtual bool ContainsRow(int p_Row)
	{
		if (!IsEmpty())
		{
			for (int i = 0; i < m_RangeCollection.Count; i++)
			{
				if (m_RangeCollection[i].ContainsRow(p_Row))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public virtual bool ContainsColumn(int p_Column)
	{
		if (!IsEmpty())
		{
			for (int i = 0; i < m_RangeCollection.Count; i++)
			{
				if (m_RangeCollection[i].ContainsColumn(p_Column))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public virtual bool IntersectsWith(Range p_Range)
	{
		if (!p_Range.IsEmpty() && !IsEmpty())
		{
			RangeRegion rangeRegion = Intersect(p_Range);
			return !rangeRegion.IsEmpty();
		}
		return false;
	}

	public virtual RangeRegion Intersect(Range p_Range)
	{
		RangeRegion rangeRegion = new RangeRegion();
		if (!p_Range.IsEmpty() && !IsEmpty())
		{
			for (int i = 0; i < m_RangeCollection.Count; i++)
			{
				Range item = p_Range.Intersect(m_RangeCollection[i]);
				if (!item.IsEmpty())
				{
					rangeRegion.m_RangeCollection.Add(item);
				}
			}
		}
		return rangeRegion;
	}

	public RangeRegion Intersect(RangeRegion pRange)
	{
		RangeRegion rangeRegion = new RangeRegion();
		for (int i = 0; i < pRange.m_RangeCollection.Count; i++)
		{
			Range p_Range = pRange.m_RangeCollection[i];
			RangeRegion rangeRegion2 = Intersect(p_Range);
			rangeRegion.m_RangeCollection.AddRange(rangeRegion2.m_RangeCollection);
		}
		return rangeRegion;
	}

	public RangeRegion Exclude(Range pRange)
	{
		RangeRegion rangeRegion = new RangeRegion();
		for (int i = 0; i < m_RangeCollection.Count; i++)
		{
			RangeRegion rangeRegion2 = m_RangeCollection[i].Exclude(pRange);
			rangeRegion.m_RangeCollection.AddRange(rangeRegion2.m_RangeCollection);
		}
		return rangeRegion;
	}

	public RangeRegion Exclude(RangeRegion pRange)
	{
		RangeRegion rangeRegion = new RangeRegion(this);
		if (!rangeRegion.IsEmpty())
		{
			for (int i = 0; i < pRange.m_RangeCollection.Count; i++)
			{
				rangeRegion = rangeRegion.Exclude(pRange.m_RangeCollection[i]);
			}
		}
		return rangeRegion;
	}

	public void Clear()
	{
		Remove(new RangeRegion(this));
	}

	public void Clear(Range pRangeToLeave)
	{
		RangeRegion rangeRegion = new RangeRegion(this);
		rangeRegion.Remove(pRangeToLeave);
		Remove(rangeRegion);
	}

	protected virtual void ResetRange()
	{
		m_bValidated = false;
		m_RangeCollection.Clear();
	}

	public bool Add(Position pCell)
	{
		return Add(new Range(pCell));
	}

	public bool Remove(Position pCell)
	{
		return Remove(new Range(pCell));
	}

	public bool Add(Range pRange)
	{
		return Class76.smethod_301(new RangeRegion(pRange), this);
	}

	public bool Remove(Range pRange)
	{
		return Class76.smethod_311(new RangeRegion(pRange), this);
	}

	public bool Add(RangeRegion pRange)
	{
		return Class76.smethod_301(pRange, this);
	}

	public bool Remove(RangeRegion pRange)
	{
		return Class76.smethod_311(pRange, this);
	}

	public virtual void OnAddingRange(RangeRegionCancelEventArgs e)
	{
		if (this.AddingRange != null)
		{
			this.AddingRange(this, e);
		}
	}

	public virtual void OnRemovingRange(RangeRegionCancelEventArgs e)
	{
		if (this.RemovingRange != null)
		{
			this.RemovingRange(this, e);
		}
	}

	public virtual void OnAddedRange(RangeRegionEventArgs e)
	{
		if (this.AddedRange != null)
		{
			this.AddedRange(this, e);
		}
		OnChanged(new RangeRegionChangedEventArgs(e.RangeRegion, null));
	}

	public virtual void OnRemovedRange(RangeRegionEventArgs e)
	{
		if (this.RemovedRange != null)
		{
			this.RemovedRange(this, e);
		}
		OnChanged(new RangeRegionChangedEventArgs(null, e.RangeRegion));
	}

	public virtual void OnChanged(RangeRegionChangedEventArgs e)
	{
		if (this.Changed != null)
		{
			this.Changed(this, e);
		}
	}

	public override string ToString()
	{
		string text = "RangeRegion";
		for (int i = 0; i < m_RangeCollection.Count; i++)
		{
			text = text + " | " + m_RangeCollection[i].ToString();
		}
		return text;
	}

	void ICollection<Range>.Add(Range item)
	{
		Add(item);
	}

	public void CopyTo(Range[] array, int arrayIndex)
	{
		m_RangeCollection.CopyTo(array, arrayIndex);
	}

	public IEnumerator<Range> GetEnumerator()
	{
		return m_RangeCollection.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return m_RangeCollection.GetEnumerator();
	}
}
