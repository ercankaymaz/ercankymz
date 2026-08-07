// Decompiled with JetBrains decompiler
// Type: SourceGrid.ValueCellComparer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System;
using System.Collections;

#nullable disable
namespace SourceGrid;

public class ValueCellComparer : IComparer
{
  public virtual int Compare(object x, object y)
  {
    if ((x != null ? 0 : (y == null ? 1 : 0)) != 0)
      return 0;
    if (x == null)
      return -1;
    if (y == null)
      return 1;
    if (x is IComparable)
      return !x.GetType().Equals(y.GetType()) ? -1 : ((IComparable) x).CompareTo(y);
    if (y is IComparable)
      return !x.GetType().Equals(y.GetType()) ? -1 : -1 * ((IComparable) y).CompareTo(x);
    object obj1 = ((ICell) x).Value;
    object obj2 = ((ICell) y).Value;
    if ((obj1 != null ? 0 : (obj2 == null ? 1 : 0)) != 0)
      return 0;
    if (obj1 == null)
      return -1;
    if (obj2 == null)
      return 1;
    if (obj1 is IComparable)
      return !obj1.GetType().Equals(obj2.GetType()) ? -1 : ((IComparable) obj1).CompareTo(obj2);
    if (!(obj2 is IComparable))
      throw new ArgumentException("Invalid cell object, no IComparable interface found");
    return !obj1.GetType().Equals(obj2.GetType()) ? -1 : -1 * ((IComparable) obj2).CompareTo(obj1);
  }
}
