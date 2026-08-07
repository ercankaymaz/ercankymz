// Decompiled with JetBrains decompiler
// Type: SourceGrid.StandardHiddenRowCoordinator
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using SourceGrid.Selection;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public class StandardHiddenRowCoordinator : IHiddenRowCoordinator
{
  protected RowsBase m_rows = (RowsBase) null;
  protected int m_totalHiddenRows = 0;
  protected RangeMergerByRows m_rowMerger = new RangeMergerByRows();

  public RowsBase Rows => this.m_rows;

  public int GetTotalHiddenRows() => this.m_totalHiddenRows;

  public StandardHiddenRowCoordinator(RowsBase rows)
  {
    this.m_rows = rows;
    rows.RowVisibilityChanged += (RowVisibilityChangedHandler) ((int_0, bool_0) =>
    {
      Range range = new Range(int_0, 0, int_0, 1);
      if (bool_0)
        this.m_rowMerger.RemoveRange(range);
      else
        this.m_rowMerger.AddRange(range);
    });
    rows.RowVisibilityChanged += (RowVisibilityChangedHandler) ((int_0, bool_0) =>
    {
      if (bool_0)
        --this.m_totalHiddenRows;
      else
        ++this.m_totalHiddenRows;
      if (this.m_totalHiddenRows < 0)
        throw new SourceGridException("Total hidden rows becamse less than 0. This indicates a bug");
    });
  }

  public int ConvertScrollbarValueToRowIndex(int scrollBarValue)
  {
    int rowIndex = 0;
    int num1 = 0;
    foreach (Range loopAllRange in this.m_rowMerger.LoopAllRanges())
    {
      Position position = loopAllRange.End;
      int num2 = position.Row - rowIndex + 1;
      position = loopAllRange.Start;
      int num3 = position.Row - rowIndex;
      if (num1 <= scrollBarValue)
      {
        if (num1 + num3 > scrollBarValue)
          num2 = num3 - (num1 + num3 - scrollBarValue);
        rowIndex += num2;
        num1 += num3;
      }
      else
        break;
    }
    if (num1 < scrollBarValue)
      rowIndex += scrollBarValue - num1;
    return rowIndex;
  }

  public IEnumerable<int> LoopVisibleRows(int scrollBarValue, int numberOfRowsToProduce)
  {
    int num = 0;
    int int_0 = scrollBarValue;
    if (!this.Rows.IsRowVisible(scrollBarValue))
    {
      int? nullable = Class39.smethod_24(int_0, this);
      if (!nullable.HasValue)
        yield break;
      int_0 = nullable.Value;
    }
    while (num <= numberOfRowsToProduce)
    {
      yield return int_0;
      ++num;
      int? nullable = Class39.smethod_24(int_0, this);
      if (!nullable.HasValue)
        break;
      int_0 = nullable.Value;
    }
  }
}
