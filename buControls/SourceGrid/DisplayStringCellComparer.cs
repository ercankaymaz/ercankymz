// Decompiled with JetBrains decompiler
// Type: SourceGrid.DisplayStringCellComparer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System;
using System.Collections;

#nullable disable
namespace SourceGrid;

public class DisplayStringCellComparer : IComparer
{
  public virtual int Compare(object x, object y)
  {
    int num;
    if ((x != null ? 0 : (y == null ? 1 : 0)) != 0)
      num = 0;
    else if (x == null)
      num = -1;
    else if (y == null)
      num = 1;
    else if (x is IComparable)
      num = ((IComparable) x).CompareTo(y);
    else if (y is IComparable)
    {
      num = -1 * ((IComparable) y).CompareTo(x);
    }
    else
    {
      string displayText1 = ((ICell) x).DisplayText;
      string displayText2 = ((ICell) y).DisplayText;
      num = (displayText1 != null ? 0 : (displayText2 == null ? 1 : 0)) == 0 ? (displayText1 != null ? (displayText2 != null ? displayText1.CompareTo(displayText2) : 1) : -1) : 0;
    }
    return num;
  }
}
