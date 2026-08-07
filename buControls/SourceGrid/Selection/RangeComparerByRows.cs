// Decompiled with JetBrains decompiler
// Type: SourceGrid.Selection.RangeComparerByRows
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Selection;

public class RangeComparerByRows : IComparer<Range>
{
  public int Compare(Range x, Range y)
  {
    Position start1 = x.Start;
    int row1 = start1.Row;
    start1 = y.Start;
    int row2 = start1.Row;
    int num;
    if (row1 == row2)
    {
      num = 0;
    }
    else
    {
      Position start2 = x.Start;
      int row3 = start2.Row;
      start2 = y.Start;
      int row4 = start2.Row;
      num = row3 <= row4 ? -1 : 1;
    }
    return num;
  }
}
