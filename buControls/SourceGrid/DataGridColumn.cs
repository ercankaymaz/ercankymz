// Decompiled with JetBrains decompiler
// Type: SourceGrid.DataGridColumn
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using SourceGrid.Conditions;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable
namespace SourceGrid;

public class DataGridColumn : ColumnInfo
{
  private string propertyName;
  private PropertyDescriptor propertyDescriptor_0;
  private ICellVirtual headerCell;
  private ICellVirtual dataCell;
  private List<ICondition> list_0 = new List<ICondition>();
  private Dictionary<ICondition, ICellVirtual> dictionary_0 = new Dictionary<ICondition, ICellVirtual>();

  public DataGridColumn(SourceGrid.DataGrid grid)
    : base((GridVirtual) grid)
  {
    this.headerCell = (ICellVirtual) new SourceGrid.Cells.DataGrid.ColumnHeader(string.Empty);
    this.dataCell = (ICellVirtual) new SourceGrid.Cells.DataGrid.Cell();
  }

  public DataGridColumn(
    SourceGrid.DataGrid grid,
    ICellVirtual headerCell,
    ICellVirtual dataCell,
    string propertyName)
    : base((GridVirtual) grid)
  {
    this.propertyName = propertyName;
    this.headerCell = headerCell;
    this.dataCell = dataCell;
  }

  public static DataGridColumn CreateRowHeader(SourceGrid.DataGrid grid)
  {
    return new DataGridColumn(grid, (ICellVirtual) new SourceGrid.Cells.DataGrid.Header(), (ICellVirtual) new SourceGrid.Cells.DataGrid.RowHeader(), (string) null);
  }

  public SourceGrid.DataGrid Grid => (SourceGrid.DataGrid) base.Grid;

  public string PropertyName
  {
    get => this.propertyName;
    set
    {
      this.propertyName = value;
      this.propertyDescriptor_0 = (PropertyDescriptor) null;
    }
  }

  public void Invalidate() => this.propertyDescriptor_0 = (PropertyDescriptor) null;

  public PropertyDescriptor PropertyColumn
  {
    get
    {
      if ((this.propertyDescriptor_0 != null ? 0 : (this.Grid.DataSource != null ? 1 : 0)) != 0)
        this.propertyDescriptor_0 = this.Grid.DataSource.GetItemProperty(this.PropertyName, StringComparison.InvariantCultureIgnoreCase);
      return this.propertyDescriptor_0;
    }
  }

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

  public List<ICondition> Conditions => this.list_0;

  public virtual ICellVirtual GetDataCell(int gridRow)
  {
    object dataSourceRow = this.Grid.Rows.IndexToDataSourceRow(gridRow);
    ICellVirtual dataCell;
    foreach (ICondition condition in this.Conditions)
    {
      if (condition.Evaluate(this, gridRow, dataSourceRow))
      {
        ICellVirtual cellVirtual;
        if (!this.dictionary_0.TryGetValue(condition, out cellVirtual))
        {
          cellVirtual = condition.ApplyCondition(this.DataCell);
          this.dictionary_0.Add(condition, cellVirtual);
        }
        dataCell = cellVirtual;
        goto label_9;
      }
    }
    dataCell = this.DataCell;
label_9:
    return dataCell;
  }
}
