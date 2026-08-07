// Decompiled with JetBrains decompiler
// Type: SourceGrid.Selection.RangeMergerByRows
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Selection;

public class RangeMergerByRows
{
  internal List<Range> list_0 = new List<Range>();
  internal int int_0 = 0;
  internal int int_1 = 0;

  public IEnumerable<Range> LoopAllRanges()
  {
    List<Range>.Enumerator enumerator = this.list_0.GetEnumerator();
    while (enumerator.MoveNext())
    {
      Range current = enumerator.Current;
      yield return current;
    }
    Class39.smethod_76(this);
    enumerator = new List<Range>.Enumerator();
  }

  public List<Range> GetSelectedRowRegions(int startColumn, int endColumn)
  {
    if (startColumn > endColumn)
      throw new ArgumentException("end column can not be less than startColumn");
    List<Range> selectedRowRegions = new List<Range>();
    foreach (Range range1 in this.list_0)
    {
      List<Range> rangeList = selectedRowRegions;
      Position position = range1.Start;
      int row1 = position.Row;
      int p_StartCol = startColumn;
      position = range1.End;
      int row2 = position.Row;
      int p_EndCol = endColumn;
      Range range2 = new Range(row1, p_StartCol, row2, p_EndCol);
      rangeList.Add(range2);
    }
    return selectedRowRegions;
  }

  public RangeMergerByRows AddRange(Range rangeToAdd)
  {
    rangeToAdd = Class39.smethod_738(this, rangeToAdd);
    Class39.smethod_385(this, rangeToAdd);
    Class39.smethod_174(this);
    return this;
  }

  public RangeMergerByRows RemoveRange(Range rangeToRemove)
  {
    do
      ;
    while (Class39.smethod_394(this, rangeToRemove));
    return this;
  }

  public IList<int> GetRowsIndex()
  {
    IList<int> rowsIndex = (IList<int>) new List<int>();
    using (List<Range>.Enumerator enumerator = this.list_0.GetEnumerator())
    {
label_5:
      while (enumerator.MoveNext())
      {
        Range current = enumerator.Current;
        Position position = current.Start;
        int row1 = position.Row;
        while (true)
        {
          int num = row1;
          position = current.End;
          int row2 = position.Row;
          if (num <= row2)
          {
            rowsIndex.Add(row1);
            ++row1;
          }
          else
            goto label_5;
        }
      }
    }
    return rowsIndex;
  }

  public bool IsEmpty() => this.list_0.Count == 0;

  public bool IsSelectedRow(int rowIndex)
  {
    Position p_Position = new Position(rowIndex, 0);
    bool flag;
    foreach (Range range in this.list_0)
    {
      if (range.Contains(p_Position))
      {
        flag = true;
        goto label_7;
      }
    }
    flag = false;
label_7:
    return flag;
  }

  public RangeMergerByRows Clear()
  {
    this.list_0.Clear();
    return this;
  }
}
