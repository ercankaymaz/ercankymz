// Decompiled with JetBrains decompiler
// Type: SourceGrid.Selection.RangeMergerByCells
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Selection;

public class RangeMergerByCells
{
  internal List<Range> list_0 = new List<Range>();

  internal bool method_0(RangeRegion rangeRegion_0)
  {
    bool flag1;
    foreach (Range range in this.list_0)
    {
      RangeRegion pRange1 = (RangeRegion) null;
      Range pRange2 = Range.Empty;
      bool flag2 = false;
      foreach (Range p_Range in rangeRegion_0)
      {
        if (range.IntersectsWith(p_Range))
        {
          pRange1 = p_Range.Exclude(range);
          flag2 = true;
          pRange2 = p_Range;
          break;
        }
      }
      if (flag2)
      {
        rangeRegion_0.Remove(pRange2);
        rangeRegion_0.Add(pRange1);
        flag1 = true;
        goto label_15;
      }
    }
    flag1 = false;
label_15:
    return flag1;
  }

  public RangeMergerByCells AddRange(Range rangeToAdd)
  {
    foreach (Range range in Class39.smethod_266(new RangeRegion(rangeToAdd), this))
      this.list_0.Add(range);
    Class39.smethod_60(this);
    return this;
  }

  internal bool method_1()
  {
    bool flag;
    foreach (Range range in new List<Range>((IEnumerable<Range>) this.list_0))
    {
      foreach (Range range_0 in this.list_0)
      {
        if (!range_0.Equals(range))
        {
          Position position = range_0.Start;
          int row1 = position.Row;
          position = range.Start;
          int row2 = position.Row;
          int num1;
          if (row1 == row2)
          {
            position = range_0.End;
            int row3 = position.Row;
            position = range.End;
            int row4 = position.Row;
            num1 = row3 == row4 ? 1 : 0;
          }
          else
            num1 = 0;
          if (num1 != 0)
          {
            position = range_0.Start;
            int column1 = position.Column;
            position = range.End;
            int column2 = position.Column;
            if (Math.Abs(column1 - column2) == 1)
            {
              Class39.smethod_617(range_0, range, this);
              flag = true;
              goto label_22;
            }
          }
          position = range_0.Start;
          int column3 = position.Column;
          position = range.Start;
          int column4 = position.Column;
          int num2;
          if (column3 == column4)
          {
            position = range_0.End;
            int column5 = position.Column;
            position = range.End;
            int column6 = position.Column;
            num2 = column5 == column6 ? 1 : 0;
          }
          else
            num2 = 0;
          if (num2 != 0)
          {
            position = range_0.Start;
            int row5 = position.Row;
            position = range.End;
            int row6 = position.Row;
            if (Math.Abs(row5 - row6) == 1)
            {
              Class39.smethod_617(range_0, range, this);
              flag = true;
              goto label_22;
            }
          }
        }
      }
    }
    flag = false;
label_22:
    return flag;
  }

  public List<Range> GetSelectedRowRegions() => this.list_0;
}
