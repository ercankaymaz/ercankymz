// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.PingGridColumn
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using SourceGrid.Conditions;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

public class PingGridColumn : ColumnInfo
{
  private string propertyName;
  [Obsolete]
  private PropertyDescriptor propertyDescriptor_0 = (PropertyDescriptor) null;
  private ICellVirtual headerCell;
  private ICellVirtual dataCell;
  [Obsolete]
  private List<ICondition> list_0 = new List<ICondition>();
  [Obsolete]
  private Dictionary<ICondition, ICellVirtual> dictionary_0 = new Dictionary<ICondition, ICellVirtual>();

  public PingGridColumn(PingGrid grid)
    : base((GridVirtual) grid)
  {
    this.headerCell = (ICellVirtual) new SourceGrid.Extensions.PingGrids.Cells.ColumnHeader(string.Empty);
    this.dataCell = (ICellVirtual) new SourceGrid.Extensions.PingGrids.Cells.Cell();
  }

  public PingGridColumn(
    PingGrid grid,
    ICellVirtual headerCell,
    ICellVirtual dataCell,
    string propertyName)
    : base((GridVirtual) grid)
  {
    this.propertyName = propertyName;
    this.headerCell = headerCell;
    this.dataCell = dataCell;
  }

  public static PingGridColumn CreateRowHeader(PingGrid grid)
  {
    return new PingGridColumn(grid, (ICellVirtual) new SourceGrid.Extensions.PingGrids.Cells.Header(), (ICellVirtual) new SourceGrid.Extensions.PingGrids.Cells.RowHeader(), (string) null);
  }

  public PingGrid Grid => (PingGrid) base.Grid;

  public string PropertyName
  {
    get => this.propertyName;
    set => this.propertyName = value;
  }

  [Obsolete]
  public void Invalidate()
  {
  }

  [Obsolete]
  public PropertyDescriptor PropertyColumn => this.propertyDescriptor_0;

  public ICellVirtual HeaderCell
  {
    get => this.headerCell;
    set => this.headerCell = value;
  }

  public ICellVirtual DataCell
  {
    get => this.dataCell;
    set => this.dataCell = value;
  }

  [Obsolete]
  public List<ICondition> Conditions => this.list_0;

  public virtual ICellVirtual GetDataCell(int gridRow) => this.DataCell;
}
