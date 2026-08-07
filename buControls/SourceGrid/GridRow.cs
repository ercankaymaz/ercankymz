// Decompiled with JetBrains decompiler
// Type: SourceGrid.GridRow
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public class GridRow(SourceGrid.Grid grid) : RowInfo((GridVirtual) grid)
{
  private Dictionary<GridColumn, ICell> dictionary_0 = new Dictionary<GridColumn, ICell>();

  public ICell this[GridColumn column]
  {
    get
    {
      ICell cell;
      return !this.dictionary_0.TryGetValue(column, out cell) ? (ICell) null : cell;
    }
    set => this.dictionary_0[column] = value;
  }
}
