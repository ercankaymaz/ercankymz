// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangeFullGridNoFixedRows
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public class RangeFullGridNoFixedRows : IRangeLoader
{
  public Range GetRange(GridVirtual p_Grid)
  {
    return p_Grid.Rows.Count < p_Grid.FixedRows ? Range.Empty : new Range(p_Grid.FixedRows, 0, p_Grid.Rows.Count - 1, p_Grid.Columns.Count - 1);
  }
}
