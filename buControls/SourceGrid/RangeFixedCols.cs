// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangeFixedCols
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public class RangeFixedCols : IRangeLoader
{
  public Range GetRange(GridVirtual p_Grid)
  {
    return p_Grid.Columns.Count < p_Grid.FixedColumns ? Range.Empty : new Range(0, 0, p_Grid.Rows.Count - 1, p_Grid.FixedColumns);
  }
}
