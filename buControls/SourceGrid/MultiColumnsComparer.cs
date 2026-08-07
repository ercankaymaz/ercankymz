// Decompiled with JetBrains decompiler
// Type: SourceGrid.MultiColumnsComparer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System.Collections;

#nullable disable
namespace SourceGrid;

public class MultiColumnsComparer : IComparer
{
  private IComparer icomparer_0 = (IComparer) new ValueCellComparer();
  private int[] secondarySortColumns;

  public MultiColumnsComparer(params int[] secondarySortColumns)
  {
    this.secondarySortColumns = secondarySortColumns;
  }

  public virtual int Compare(object x, object y)
  {
    int num1 = this.icomparer_0.Compare(x, y);
    int num2;
    if (num1 == 0)
    {
      Grid grid = ((ICell) x).Grid;
      int row1 = ((ICell) x).Range.Start.Row;
      int row2 = ((ICell) y).Range.Start.Row;
      for (int index = 0; index < this.secondarySortColumns.Length; ++index)
      {
        int num3 = this.icomparer_0.Compare((object) grid.GetCell(row1, this.secondarySortColumns[index]), (object) grid.GetCell(row2, this.secondarySortColumns[index]));
        if (num3 != 0)
        {
          num2 = num3;
          goto label_8;
        }
      }
      num2 = 0;
    }
    else
      num2 = num1;
label_8:
    return num2;
  }
}
