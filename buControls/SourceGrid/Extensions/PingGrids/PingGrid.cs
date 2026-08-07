// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.PingGrid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using SourceGrid.Selection;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

[ToolboxItem(true)]
public class PingGrid : GridVirtual
{
  private IPingData ipingData_0;
  private bool bool_7 = true;
  private bool bool_8 = true;
  private bool bool_9 = true;
  private string string_0 = "Are you sure to delete all the selected rows?";

  public PingGrid()
  {
    this.FixedRows = 1;
    this.FixedColumns = 0;
    this.Controller.AddController((IController) new PingGridCellController());
    this.DataSource = (IPingData) new EmptyPingSource();
    this.SelectionMode = GridSelectionMode.Row;
  }

  protected override void Dispose(bool disposing) => base.Dispose(disposing);

  protected override RowsBase CreateRowsObject() => (RowsBase) new PingGridRows(this);

  protected override ColumnsBase CreateColumnsObject() => (ColumnsBase) new PingGridColumns(this);

  protected override SelectionBase CreateSelectionObject()
  {
    SelectionBase selectionObject = base.CreateSelectionObject();
    selectionObject.EnableMultiSelection = true;
    selectionObject.FocusStyle = FocusStyle.RemoveFocusCellOnLeave;
    selectionObject.FocusRowLeaving += new RowCancelEventHandler(this.method_1);
    return selectionObject;
  }

  public override bool EnableSort
  {
    get => true;
    set
    {
    }
  }

  public IPingData DataSource
  {
    get => this.ipingData_0;
    set
    {
      this.Unbind();
      this.ipingData_0 = value != null ? value : (IPingData) new EmptyPingSource();
      if (this.ipingData_0 == null)
        return;
      this.Bind();
    }
  }

  protected virtual void Unbind()
  {
    if (this.ipingData_0 != null)
      ;
    this.Rows.RowsChanged();
  }

  protected virtual void Bind() => this.Rows.RowsChanged();

  public PingGridRows Rows => (PingGridRows) base.Rows;

  public PingGridColumns Columns => (PingGridColumns) base.Columns;

  protected virtual void mBoundList_ListChanged(object sender, ListChangedEventArgs e)
  {
    if (this.IsSuspended())
      return;
    this.Rows.RowsChanged();
    this.Invalidate(true);
  }

  public override ICellVirtual GetCell(int p_iRow, int p_iCol)
  {
    return this.ipingData_0 != null ? (p_iCol < this.Columns.Count ? (p_iRow >= this.FixedRows ? this.Columns[p_iCol].GetDataCell(p_iRow) : this.Columns[p_iCol].HeaderCell) : (ICellVirtual) null) : (ICellVirtual) null;
  }

  protected override void OnSortingRangeRows(SortRangeRowsEventArgs e)
  {
    base.OnSortingRangeRows(e);
    if ((this.DataSource == null ? 1 : (!this.DataSource.AllowSort ? 1 : 0)) != 0)
      return;
    this.DataSource.ApplySort(this.Columns[e.KeyColumn].PropertyName, e.Ascending);
    this.Invalidate();
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Obsolete]
  public object[] SelectedDataRows
  {
    get
    {
      object[] selectedDataRows;
      if (this.ipingData_0 == null)
      {
        selectedDataRows = (object[]) new DataRowView[0];
      }
      else
      {
        int[] rowsIndex = this.Selection.GetSelectionRegion().GetRowsIndex();
        int length = 0;
        for (int index = 0; index < rowsIndex.Length; ++index)
        {
          if (this.Rows.IndexToDataSourceRow(rowsIndex[index]) != null)
            ++length;
        }
        object[] objArray = new object[length];
        int index1 = 0;
        for (int index2 = 0; index2 < rowsIndex.Length; ++index2)
        {
          object dataSourceRow = this.Rows.IndexToDataSourceRow(rowsIndex[index2]);
          if (dataSourceRow != null)
          {
            objArray[index1] = dataSourceRow;
            ++index1;
          }
        }
        selectedDataRows = objArray;
      }
      return selectedDataRows;
    }
    set
    {
      this.Selection.ResetSelection(false);
      if ((this.ipingData_0 == null ? 0 : (value != null ? 1 : 0)) == 0)
        return;
      for (int index = 0; index < value.Length; ++index)
      {
        for (int fixedRows = this.FixedRows; fixedRows < this.Rows.Count; ++fixedRows)
        {
          if (this.Rows.IndexToDataSourceRow(fixedRows) == value[index])
          {
            this.Selection.SelectRow(fixedRows, true);
            break;
          }
        }
      }
    }
  }

  protected override void OnValidating(CancelEventArgs e)
  {
    base.OnValidating(e);
    try
    {
    }
    catch (Exception ex)
    {
      this.OnUserException(new ExceptionEventArgs(ex));
    }
  }

  [DefaultValue(true)]
  [Obsolete]
  public bool EndEditingRowOnValidate
  {
    get => this.bool_7;
    set => this.bool_7 = value;
  }

  [DefaultValue(true)]
  public bool DeleteRowsWithDeleteKey
  {
    get => this.bool_8;
    set => this.bool_8 = value;
  }

  [DefaultValue(true)]
  public bool CancelEditingWithEscapeKey
  {
    get => this.bool_9;
    set => this.bool_9 = value;
  }

  public string DeleteQuestionMessage
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  [Obsolete]
  public virtual bool DeleteSelectedRows()
  {
    bool flag;
    if ((string.IsNullOrEmpty(this.string_0) ? 1 : (MessageBox.Show((IWin32Window) this, this.string_0, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 0)) != 0)
    {
      foreach (int gridRowIndex in this.Selection.GetSelectionRegion().GetRowsIndex())
        this.Rows.IndexToDataSourceIndex(gridRowIndex);
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public override void AutoSizeCells()
  {
    this.Columns.AutoSizeView();
    for (int row = 0; row < this.Rows.Count; ++row)
      this.Rows.AutoSizeRow(row);
  }

  private void method_1(object sender, RowCancelEventArgs e)
  {
    try
    {
    }
    catch (Exception ex)
    {
      this.OnUserException(new ExceptionEventArgs((Exception) new EndEditingException(ex)));
      e.Cancel = true;
    }
  }

  [Obsolete]
  public bool BeginEditRow(int gridRow) => true;

  [Obsolete]
  public void EndEditingRow(bool cancel)
  {
  }
}
