// Decompiled with JetBrains decompiler
// Type: SourceGrid.DataGrid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel;
using ns7;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using SourceGrid.Selection;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid;

[ToolboxItem(true)]
public class DataGrid : GridVirtual
{
  private IBoundList iboundList_0;
  private bool bool_7 = true;
  private bool bool_8 = true;
  private bool bool_9 = true;
  private string string_0 = "Are you sure to delete all the selected rows?";
  private int? nullable_0;

  public DataGrid()
  {
    this.FixedRows = 1;
    this.FixedColumns = 0;
    this.Controller.AddController((IController) new DataGridCellController());
    this.SelectionMode = GridSelectionMode.Row;
  }

  protected override void Dispose(bool disposing) => base.Dispose(disposing);

  protected override RowsBase CreateRowsObject() => (RowsBase) new DataGridRows(this);

  protected override ColumnsBase CreateColumnsObject() => (ColumnsBase) new DataGridColumns(this);

  protected override SelectionBase CreateSelectionObject()
  {
    SelectionBase selectionObject = base.CreateSelectionObject();
    selectionObject.EnableMultiSelection = false;
    selectionObject.FocusStyle = FocusStyle.RemoveFocusCellOnLeave;
    selectionObject.FocusRowLeaving += new RowCancelEventHandler(this.method_1);
    return selectionObject;
  }

  public override bool EnableSort
  {
    get => this.DataSource != null && this.DataSource.AllowSort;
    set
    {
      if (this.DataSource == null)
        return;
      this.DataSource.AllowSort = value;
    }
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public IBoundList DataSource
  {
    get => this.iboundList_0;
    set
    {
      this.Unbind();
      this.iboundList_0 = value;
      if (this.iboundList_0 == null)
        return;
      this.Bind();
    }
  }

  protected virtual void Unbind()
  {
    if (this.iboundList_0 != null)
    {
      this.iboundList_0.ListChanged -= new ListChangedEventHandler(this.mBoundList_ListChanged);
      this.iboundList_0.ItemDeleted -= new ItemDeletedEventHandler(this.iboundList_0_ItemDeleted);
      this.iboundList_0.ListCleared -= new EventHandler(this.iboundList_0_ListCleared);
    }
    this.Rows.RowsChanged();
  }

  protected virtual void Bind()
  {
    if (this.Columns.Count == 0)
      this.CreateColumns();
    Class39.smethod_107(this);
    this.iboundList_0.ListChanged += new ListChangedEventHandler(this.mBoundList_ListChanged);
    this.iboundList_0.ItemDeleted += new ItemDeletedEventHandler(this.iboundList_0_ItemDeleted);
    this.iboundList_0.ListCleared += new EventHandler(this.iboundList_0_ListCleared);
    this.Rows.RowsChanged();
    this.Rows.ResetRowHeigth();
  }

  private void iboundList_0_ListCleared(object sender, EventArgs e) => this.Rows.ResetRowHeigth();

  private void iboundList_0_ItemDeleted(object sender, ItemDeletedEventArgs e)
  {
    this.Rows.RowDeleted(e.Item);
  }

  public DataGridRows Rows => (DataGridRows) base.Rows;

  public DataGridColumns Columns => (DataGridColumns) base.Columns;

  protected virtual void mBoundList_ListChanged(object sender, ListChangedEventArgs e)
  {
    if (this.IsSuspended())
      return;
    this.Rows.RowsChanged();
    this.Invalidate(true);
  }

  public override ICellVirtual GetCell(int p_iRow, int p_iCol)
  {
    return this.iboundList_0 != null ? (p_iCol < this.Columns.Count ? (p_iRow >= this.FixedRows ? this.Columns[p_iCol].GetDataCell(p_iRow) : this.Columns[p_iCol].HeaderCell) : (ICellVirtual) null) : (ICellVirtual) null;
  }

  protected override void OnSortingRangeRows(SortRangeRowsEventArgs e)
  {
    base.OnSortingRangeRows(e);
    if ((this.DataSource == null ? 1 : (!this.DataSource.AllowSort ? 1 : 0)) != 0)
      return;
    PropertyDescriptor propertyColumn = this.Columns[e.KeyColumn].PropertyColumn;
    if (propertyColumn != null)
    {
      ListSortDirection direction = !e.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
      this.DataSource.ApplySort(new ListSortDescriptionCollection(new ListSortDescription[1]
      {
        new ListSortDescription(propertyColumn, direction)
      }));
    }
    else
      this.DataSource.ApplySort((ListSortDescriptionCollection) null);
  }

  public void CreateColumns()
  {
    this.Columns.Clear();
    if (this.DataSource == null)
      return;
    int index = 0;
    if (this.FixedColumns > 0)
    {
      this.Columns.Insert(index, (ColumnInfo) DataGridColumn.CreateRowHeader(this));
      int num = index + 1;
    }
    foreach (PropertyDescriptor itemProperty in this.DataSource.GetItemProperties())
      this.Columns.Add(itemProperty.Name, itemProperty.DisplayName, SourceGrid.Cells.DataGrid.Cell.Create(itemProperty.PropertyType, !itemProperty.IsReadOnly));
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object[] SelectedDataRows
  {
    get
    {
      object[] selectedDataRows;
      if (this.iboundList_0 == null)
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
      if ((this.iboundList_0 == null ? 0 : (value != null ? 1 : 0)) == 0)
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

  protected override void OnKeyDown(KeyEventArgs e)
  {
    base.OnKeyDown(e);
    if ((e.KeyCode != Keys.Delete || this.iboundList_0 == null || !this.iboundList_0.AllowDelete || e.Handled ? 0 : (this.bool_8 ? 1 : 0)) != 0)
    {
      object[] selectedDataRows = this.SelectedDataRows;
      if ((selectedDataRows == null ? 0 : (selectedDataRows.Length != 0 ? 1 : 0)) != 0)
        this.DeleteSelectedRows();
      e.Handled = true;
    }
    else
    {
      if ((e.KeyCode != Keys.Escape || e.Handled ? 0 : (this.bool_9 ? 1 : 0)) == 0)
        return;
      this.EndEditingRow(true);
      e.Handled = true;
    }
  }

  protected override void OnValidating(CancelEventArgs e)
  {
    base.OnValidating(e);
    try
    {
      if (!this.EndEditingRowOnValidate)
        return;
      this.EndEditingRow(false);
    }
    catch (Exception ex)
    {
      this.OnUserException(new ExceptionEventArgs(ex));
    }
  }

  [DefaultValue(true)]
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

  public virtual bool DeleteSelectedRows()
  {
    bool flag;
    if ((string.IsNullOrEmpty(this.string_0) ? 1 : (MessageBox.Show((IWin32Window) this, this.string_0, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 0)) != 0)
    {
      foreach (int gridRowIndex in this.Selection.GetSelectionRegion().GetRowsIndex())
      {
        int dataSourceIndex = this.Rows.IndexToDataSourceIndex(gridRowIndex);
        if (dataSourceIndex < this.DataSource.Count)
          this.DataSource.RemoveAt(dataSourceIndex);
      }
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
      this.EndEditingRow(false);
    }
    catch (Exception ex)
    {
      this.OnUserException(new ExceptionEventArgs((Exception) new EndEditingException(ex)));
      e.Cancel = true;
    }
  }

  public bool BeginEditRow(int gridRow)
  {
    bool flag;
    if ((!this.nullable_0.HasValue ? 0 : (this.nullable_0.Value == gridRow ? 1 : 0)) != 0)
    {
      flag = true;
    }
    else
    {
      this.EndEditingRow(false);
      if (this.DataSource != null)
      {
        int dataSourceIndex = this.Rows.IndexToDataSourceIndex(gridRow);
        if (!this.DataSource.AllowEdit)
        {
          flag = false;
          goto label_10;
        }
        if ((dataSourceIndex != this.DataSource.Count ? 0 : (this.DataSource.AllowNew ? 1 : 0)) != 0)
          this.DataSource.BeginAddNew();
        else if (dataSourceIndex < this.DataSource.Count)
          this.DataSource.BeginEdit(dataSourceIndex);
      }
      this.nullable_0 = new int?(gridRow);
      flag = true;
    }
label_10:
    return flag;
  }

  public void EndEditingRow(bool cancel)
  {
    if (this.iboundList_0 != null)
      this.iboundList_0.EndEdit(cancel);
    this.nullable_0 = new int?();
  }
}
