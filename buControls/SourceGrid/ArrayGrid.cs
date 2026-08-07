// Decompiled with JetBrains decompiler
// Type: SourceGrid.ArrayGrid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;
using System;
using System.ComponentModel;

#nullable disable
namespace SourceGrid;

[ToolboxItem(true)]
public class ArrayGrid : GridVirtual
{
  private Array array_0 = (Array) null;
  private ICellVirtual icellVirtual_0 = (ICellVirtual) new ArrayColumnHeader();
  private ICellVirtual icellVirtual_1 = (ICellVirtual) new ArrayRowHeader();
  private ICellVirtual icellVirtual_2 = (ICellVirtual) new ArrayHeader();
  private ICellVirtual icellVirtual_3;

  public override bool EnableSort { get; set; }

  protected override RowsBase CreateRowsObject() => (RowsBase) new ArrayRows(this);

  protected override ColumnsBase CreateColumnsObject() => (ColumnsBase) new ArrayColumns(this);

  public override ICellVirtual GetCell(int p_iRow, int p_iCol)
  {
    return (p_iRow >= this.FixedRows ? 0 : (p_iCol < this.FixedColumns ? 1 : 0)) == 0 ? (p_iRow >= this.FixedRows ? (p_iCol >= this.FixedColumns ? this.icellVirtual_3 : this.icellVirtual_1) : this.icellVirtual_0) : this.icellVirtual_2;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ArrayRows Rows => (ArrayRows) base.Rows;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ArrayColumns Columns => (ArrayColumns) base.Columns;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Array DataSource
  {
    get => this.array_0;
    set
    {
      this.array_0 = (value == null ? 0 : (value.Rank != 2 ? 1 : 0)) == 0 ? value : throw new SourceGridException("Array dimension not valid, must be an array with 2 dimensions");
      this.Bind();
    }
  }

  protected virtual void Bind()
  {
    this.ValueCell = (ICellVirtual) null;
    if (this.array_0 != null)
    {
      this.icellVirtual_3 = (ICellVirtual) new CellVirtual();
      this.icellVirtual_3.Model.AddModel((IModel) new ArrayValueModel());
      this.icellVirtual_3.Editor = Factory.Create(this.array_0.GetType().GetElementType());
    }
    this.Rows.RowsChanged();
    this.Columns.ColumnsChanged();
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ICellVirtual ColumnHeader
  {
    get => this.icellVirtual_0;
    set => this.icellVirtual_0 = value;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ICellVirtual RowHeader
  {
    get => this.icellVirtual_1;
    set => this.icellVirtual_1 = value;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ICellVirtual Header
  {
    get => this.icellVirtual_2;
    set => this.icellVirtual_2 = value;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ICellVirtual ValueCell
  {
    get => this.icellVirtual_3;
    set => this.icellVirtual_3 = value;
  }
}
