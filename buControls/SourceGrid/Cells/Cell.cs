// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Cell
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace SourceGrid.Cells;

public class Cell : CellVirtual, ICellVirtual, ICell
{
  private Grid grid_0;
  private GridColumn gridColumn_0;
  private GridRow gridRow_0;
  private object object_0 = (object) null;
  private int int_0 = 1;
  private int int_1 = 1;

  public Cell()
    : this((object) null)
  {
  }

  public Cell(object cellValue)
  {
    this.Model = new ModelContainer();
    this.Model.ValueModel = (IValueModel) new ValueModel();
    this.Model.AddModel((IModel) new ToolTip());
    this.Model.AddModel((IModel) new SourceGrid.Cells.Models.Image());
    this.Value = cellValue;
  }

  public Cell(object cellValue, Type pType)
    : this(cellValue)
  {
    this.Editor = Factory.Create(pType);
  }

  public Cell(object cellValue, EditorBase pEditor)
    : this(cellValue)
  {
    this.Editor = pEditor;
  }

  public virtual void BindToGrid(Grid p_grid, Position p_Position)
  {
    this.grid_0 = p_grid;
    this.gridRow_0 = this.Grid.Rows[p_Position.Row];
    this.gridColumn_0 = this.Grid.Columns[p_Position.Column] as GridColumn;
  }

  public virtual void UnBindToGrid()
  {
    this.grid_0 = (Grid) null;
    this.gridColumn_0 = (GridColumn) null;
    this.gridRow_0 = (GridRow) null;
  }

  public Grid Grid => this.grid_0;

  public GridColumn Column => this.gridColumn_0;

  public GridRow Row => this.gridRow_0;

  public Range Range
  {
    get
    {
      Range range;
      if (this.Grid == null)
      {
        range = Range.Empty;
      }
      else
      {
        int index1 = this.Column.Index;
        int index2 = this.Row.Index;
        range = new Range(index2, index1, index2 + this.RowSpan - 1, index1 + this.ColumnSpan - 1);
      }
      return range;
    }
  }

  protected CellContext GetContext()
  {
    return new CellContext((GridVirtual) this.Grid, this.Range.Start, (ICellVirtual) this);
  }

  public virtual string DisplayText => this.GetContext().DisplayText;

  public virtual object Value
  {
    get => this.Model.ValueModel.GetValue(this.GetContext());
    set => this.Model.ValueModel.SetValue(this.GetContext(), value);
  }

  public virtual object Tag
  {
    get => this.object_0;
    set => this.object_0 = value;
  }

  public override string ToString() => this.DisplayText;

  public void SetSpan(int rowSpan, int colSpan)
  {
    int columnSpan = this.ColumnSpan;
    int int1 = this.int_1;
    try
    {
      bool flag = false;
      if ((this.int_0 > 1 ? 1 : (this.int_1 > 1 ? 1 : 0)) != 0)
        flag = true;
      this.int_0 = colSpan;
      this.int_1 = rowSpan;
      if (this.grid_0 == null || (this.int_0 != 1 ? 1 : (this.int_1 != 1 ? 1 : 0)) == 0)
        return;
      if (flag)
        this.grid_0.UpdateSpannedArea(this.Row.Index, this.Column.Index, (ICell) this);
      else
        this.grid_0.OccupySpannedArea(this.Row.Index, this.Column.Index, (ICell) this);
    }
    catch (OverlappingCellException ex)
    {
      this.int_0 = columnSpan;
      this.int_1 = int1;
      throw new OverlappingCellException("Can not change span", (Exception) ex);
    }
  }

  public int ColumnSpan
  {
    get => this.int_0;
    set
    {
      if (value < 1)
        throw new ArgumentOutOfRangeException(nameof (ColumnSpan));
      this.SetSpan(this.RowSpan, value);
    }
  }

  public int RowSpan
  {
    get => this.int_1;
    set
    {
      if (value < 1)
        throw new ArgumentOutOfRangeException(nameof (RowSpan));
      this.SetSpan(value, this.ColumnSpan);
    }
  }

  [SpecialName]
  private ToolTip method_0() => (ToolTip) this.Model.FindModel(typeof (ToolTip));

  public string ToolTipText
  {
    get => this.method_0().ToolTipText;
    set => this.method_0().ToolTipText = value;
  }

  [SpecialName]
  private SourceGrid.Cells.Models.Image method_1() => (SourceGrid.Cells.Models.Image) this.Model.FindModel(typeof (SourceGrid.Cells.Models.Image));

  public System.Drawing.Image Image
  {
    get => this.method_1().ImageValue;
    set => this.method_1().ImageValue = value;
  }
}
