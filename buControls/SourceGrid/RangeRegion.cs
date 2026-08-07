// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangeRegion
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using SourceGrid.Selection;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

[Serializable]
public class RangeRegion : IEnumerable, IEnumerable<Range>, ICollection<Range>
{
  internal RangeCollection m_RangeCollection = new RangeCollection();
  internal bool m_bValidated = false;

  public RangeRegion()
  {
  }

  public RangeRegion(Position position)
  {
    if (position.IsEmpty())
      return;
    this.m_RangeCollection.Add(new Range(position));
  }

  public RangeRegion(Range range)
  {
    if (range.IsEmpty())
      return;
    this.m_RangeCollection.Add(range);
  }

  public RangeRegion(RangeRegion other)
  {
    this.m_RangeCollection.AddRange((IEnumerable<Range>) other.m_RangeCollection);
  }

  public virtual bool IsEmpty() => this.m_RangeCollection.Count == 0;

  public Range this[int index] => this.m_RangeCollection[index];

  public virtual PositionCollection GetCellsPositions()
  {
    PositionCollection cellsPositions = new PositionCollection();
    for (int index = 0; index < this.m_RangeCollection.Count; ++index)
      cellsPositions.AddRange((IEnumerable<Position>) this.m_RangeCollection[index].GetCellsPositions());
    return cellsPositions;
  }

  public virtual int[] GetRowsIndex()
  {
    RangeMergerByRows rangeMergerByRows = new RangeMergerByRows();
    foreach (Range rangeToAdd in this)
      rangeMergerByRows.AddRange(rangeToAdd);
    IList<int> rowsIndex = rangeMergerByRows.GetRowsIndex();
    int[] array = new int[rowsIndex.Count];
    rowsIndex.CopyTo(array, 0);
    return array;
  }

  public virtual int[] GetColumnsIndex()
  {
    ArrayList arrayList = new ArrayList();
    for (int index = 0; index < this.Count; ++index)
    {
      Range range = this[index];
      Position position = range.Start;
      int column1 = position.Column;
      while (true)
      {
        int num = column1;
        range = this[index];
        position = range.End;
        int column2 = position.Column;
        if (num <= column2)
        {
          if (!arrayList.Contains((object) column1))
            arrayList.Add((object) column1);
          ++column1;
        }
        else
          break;
      }
    }
    int[] columnsIndex = new int[arrayList.Count];
    arrayList.CopyTo((Array) columnsIndex, 0);
    return columnsIndex;
  }

  public virtual bool Contains(Position p_Cell)
  {
    bool flag;
    if ((p_Cell.IsEmpty() ? 1 : (this.IsEmpty() ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index < this.m_RangeCollection.Count; ++index)
      {
        if (this.m_RangeCollection[index].Contains(p_Cell))
        {
          flag = true;
          goto label_8;
        }
      }
      flag = false;
    }
label_8:
    return flag;
  }

  public virtual bool Contains(Range p_Range)
  {
    bool flag;
    if ((p_Range.IsEmpty() ? 1 : (this.IsEmpty() ? 1 : 0)) != 0)
      flag = false;
    else if ((p_Range.ColumnsCount != 1 ? 0 : (p_Range.RowsCount == 1 ? 1 : 0)) != 0)
    {
      flag = this.Contains(p_Range.Start);
    }
    else
    {
      for (int index = 0; index < this.m_RangeCollection.Count; ++index)
      {
        if (this.m_RangeCollection[index].Contains(p_Range))
        {
          flag = true;
          goto label_15;
        }
      }
      PositionCollection cellsPositions = p_Range.GetCellsPositions();
      for (int index = 0; index < cellsPositions.Count; ++index)
      {
        if (!this.Contains(cellsPositions[index]))
        {
          flag = false;
          goto label_15;
        }
      }
      flag = true;
    }
label_15:
    return flag;
  }

  public virtual bool Contains(RangeRegion p_Range)
  {
    bool flag;
    if ((p_Range.IsEmpty() ? 1 : (this.IsEmpty() ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      PositionCollection cellsPositions = p_Range.GetCellsPositions();
      for (int index = 0; index < cellsPositions.Count; ++index)
      {
        if (!this.Contains(cellsPositions[index]))
        {
          flag = false;
          goto label_8;
        }
      }
      flag = true;
    }
label_8:
    return flag;
  }

  public virtual bool ContainsRow(int p_Row)
  {
    bool flag;
    if (this.IsEmpty())
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index < this.m_RangeCollection.Count; ++index)
      {
        if (this.m_RangeCollection[index].ContainsRow(p_Row))
        {
          flag = true;
          goto label_8;
        }
      }
      flag = false;
    }
label_8:
    return flag;
  }

  public virtual bool ContainsColumn(int p_Column)
  {
    bool flag;
    if (this.IsEmpty())
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index < this.m_RangeCollection.Count; ++index)
      {
        if (this.m_RangeCollection[index].ContainsColumn(p_Column))
        {
          flag = true;
          goto label_8;
        }
      }
      flag = false;
    }
label_8:
    return flag;
  }

  public virtual bool IntersectsWith(Range p_Range)
  {
    return (p_Range.IsEmpty() ? 1 : (this.IsEmpty() ? 1 : 0)) == 0 && !this.Intersect(p_Range).IsEmpty();
  }

  public virtual RangeRegion Intersect(Range p_Range)
  {
    RangeRegion rangeRegion = new RangeRegion();
    if ((p_Range.IsEmpty() ? 0 : (!this.IsEmpty() ? 1 : 0)) != 0)
    {
      for (int index = 0; index < this.m_RangeCollection.Count; ++index)
      {
        Range range = p_Range.Intersect(this.m_RangeCollection[index]);
        if (!range.IsEmpty())
          rangeRegion.m_RangeCollection.Add(range);
      }
    }
    return rangeRegion;
  }

  public RangeRegion Intersect(RangeRegion pRange)
  {
    RangeRegion rangeRegion1 = new RangeRegion();
    for (int index = 0; index < pRange.m_RangeCollection.Count; ++index)
    {
      RangeRegion rangeRegion2 = this.Intersect(pRange.m_RangeCollection[index]);
      rangeRegion1.m_RangeCollection.AddRange((IEnumerable<Range>) rangeRegion2.m_RangeCollection);
    }
    return rangeRegion1;
  }

  public RangeRegion Exclude(Range pRange)
  {
    RangeRegion rangeRegion1 = new RangeRegion();
    for (int index = 0; index < this.m_RangeCollection.Count; ++index)
    {
      RangeRegion rangeRegion2 = this.m_RangeCollection[index].Exclude(pRange);
      rangeRegion1.m_RangeCollection.AddRange((IEnumerable<Range>) rangeRegion2.m_RangeCollection);
    }
    return rangeRegion1;
  }

  public RangeRegion Exclude(RangeRegion pRange)
  {
    RangeRegion rangeRegion = new RangeRegion(this);
    if (!rangeRegion.IsEmpty())
    {
      for (int index = 0; index < pRange.m_RangeCollection.Count; ++index)
        rangeRegion = rangeRegion.Exclude(pRange.m_RangeCollection[index]);
    }
    return rangeRegion;
  }

  public void Clear() => this.Remove(new RangeRegion(this));

  public void Clear(Range pRangeToLeave)
  {
    RangeRegion pRange = new RangeRegion(this);
    pRange.Remove(pRangeToLeave);
    this.Remove(pRange);
  }

  protected virtual void ResetRange()
  {
    this.m_bValidated = false;
    this.m_RangeCollection.Clear();
  }

  public bool Add(Position pCell) => this.Add(new Range(pCell));

  public bool Remove(Position pCell) => this.Remove(new Range(pCell));

  public bool Add(Range pRange) => Class39.smethod_301(new RangeRegion(pRange), this);

  public bool Remove(Range pRange) => Class39.smethod_311(new RangeRegion(pRange), this);

  public bool Add(RangeRegion pRange) => Class39.smethod_301(pRange, this);

  public bool Remove(RangeRegion pRange) => Class39.smethod_311(pRange, this);

  public virtual void OnAddingRange(RangeRegionCancelEventArgs e)
  {
    if (this.AddingRange == null)
      return;
    this.AddingRange((object) this, e);
  }

  public virtual void OnRemovingRange(RangeRegionCancelEventArgs e)
  {
    if (this.RemovingRange == null)
      return;
    this.RemovingRange((object) this, e);
  }

  public virtual void OnAddedRange(RangeRegionEventArgs e)
  {
    if (this.AddedRange != null)
      this.AddedRange((object) this, e);
    this.OnChanged(new RangeRegionChangedEventArgs(e.RangeRegion, (RangeRegion) null));
  }

  public virtual void OnRemovedRange(RangeRegionEventArgs e)
  {
    if (this.RemovedRange != null)
      this.RemovedRange((object) this, e);
    this.OnChanged(new RangeRegionChangedEventArgs((RangeRegion) null, e.RangeRegion));
  }

  public virtual void OnChanged(RangeRegionChangedEventArgs e)
  {
    if (this.Changed == null)
      return;
    this.Changed((object) this, e);
  }

  public event RangeRegionCancelEventHandler AddingRange;

  public event RangeRegionCancelEventHandler RemovingRange;

  public event RangeRegionEventHandler AddedRange;

  public event RangeRegionEventHandler RemovedRange;

  public event RangeRegionChangedEventHandler Changed;

  public override string ToString()
  {
    string str = nameof (RangeRegion);
    for (int index = 0; index < this.m_RangeCollection.Count; ++index)
      str = $"{str} | {this.m_RangeCollection[index].ToString()}";
    return str;
  }

  void ICollection<Range>.Add(Range item) => this.Add(item);

  public void CopyTo(Range[] array, int arrayIndex)
  {
    this.m_RangeCollection.CopyTo(array, arrayIndex);
  }

  public int Count => this.m_RangeCollection.Count;

  public bool IsReadOnly => false;

  public IEnumerator<Range> GetEnumerator()
  {
    return (IEnumerator<Range>) this.m_RangeCollection.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.m_RangeCollection.GetEnumerator();
}
