// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.ICell
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid.Cells;

public interface ICell : ICellVirtual
{
  string DisplayText { get; }

  object Value { get; set; }

  object Tag { get; set; }

  string ToolTipText { get; set; }

  System.Drawing.Image Image { get; set; }

  Grid Grid { get; }

  void BindToGrid(Grid p_grid, Position p_Position);

  void UnBindToGrid();

  GridColumn Column { get; }

  GridRow Row { get; }

  Range Range { get; }

  int ColumnSpan { get; set; }

  int RowSpan { get; set; }

  void SetSpan(int rowSpan, int colSpan);
}
