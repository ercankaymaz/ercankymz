// Decompiled with JetBrains decompiler
// Type: SourceGrid.ListEditor
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Windows.Forms;
using ns7;
using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid;

[ToolboxItem(false)]
public class ListEditor : UserControl
{
  internal Grid grid_0;
  internal System.Windows.Forms.Button button_0;
  internal System.Windows.Forms.Button button_1;
  internal System.Windows.Forms.Button button_2;
  internal System.Windows.Forms.Button button_3;
  internal System.Windows.Forms.Button button_4;
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private ArrayList arrayList_0;
  internal System.Type type_0;
  internal EditorBase[] editorBase_0;
  internal PropertyInfo[] propertyInfo_0;

  public ListEditor()
  {
    Class39.smethod_41(this);
    this.grid_0.Selection.FocusRowLeaving += new RowCancelEventHandler(this.method_6);
    this.grid_0.Selection.FocusRowEntered += new RowEventHandler(this.method_7);
    this.grid_0.Selection.FocusStyle = FocusStyle.None;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  public ArrayList List
  {
    get => this.arrayList_0;
    set => this.arrayList_0 = value;
  }

  public System.Type ItemType
  {
    get => this.type_0;
    set
    {
      this.type_0 = value;
      Class39.smethod_285(this);
    }
  }

  [Browsable(false)]
  public EditorBase[] Editors
  {
    get => this.editorBase_0;
    set => this.editorBase_0 = value;
  }

  [Browsable(false)]
  public PropertyInfo[] Properties
  {
    get => this.propertyInfo_0;
    set => this.propertyInfo_0 = value;
  }

  public void LoadList()
  {
    if (this.type_0 == (System.Type) null)
      throw new ApplicationException("ItemType is null");
    if (this.arrayList_0 == null)
      this.arrayList_0 = new ArrayList();
    if (this.propertyInfo_0.Length != this.editorBase_0.Length)
      throw new ApplicationException("Properteis.Length != Editors.Length");
    this.grid_0.FixedRows = 1;
    this.grid_0.FixedColumns = 0;
    this.grid_0.Redim(this.arrayList_0.Count + this.grid_0.FixedRows, this.propertyInfo_0.Length + this.grid_0.FixedColumns);
    for (int index = 0; index < this.propertyInfo_0.Length; ++index)
    {
      SourceGrid.Cells.ColumnHeader columnHeader = new SourceGrid.Cells.ColumnHeader((object) this.propertyInfo_0[index].Name);
      this.grid_0[0, index + this.grid_0.FixedColumns] = (ICell) columnHeader;
      columnHeader.AutomaticSortEnabled = false;
    }
    for (int index = 0; index < this.arrayList_0.Count; ++index)
      Class39.smethod_213(index + this.grid_0.FixedRows, this.arrayList_0[index], this);
    this.grid_0.AutoStretchColumnsToFitWidth = true;
    this.grid_0.AutoSizeCells();
  }

  internal void method_0(object sender, EventArgs e)
  {
    try
    {
      int rowsCount = this.grid_0.RowsCount;
      this.grid_0.Rows.Insert(rowsCount);
      object instance = Activator.CreateInstance(this.type_0);
      this.arrayList_0.Add(instance);
      Class39.smethod_213(rowsCount, instance, this);
      this.OnListChanged(EventArgs.Empty);
    }
    catch (Exception ex)
    {
      ErrorDialog.Show((IWin32Window) this, ex, "Error");
    }
  }

  public event EventHandler ListChanged;

  protected virtual void OnListChanged(EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, e);
  }

  internal void method_1(object sender, EventArgs e) => this.OnListChanged(e);

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      Position activePosition = this.grid_0.Selection.ActivePosition;
      int num;
      if (!activePosition.IsEmpty())
      {
        activePosition = this.grid_0.Selection.ActivePosition;
        num = activePosition.Row >= this.grid_0.FixedRows ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0)
        return;
      ArrayList arrayList0 = this.arrayList_0;
      GridRows rows1 = this.grid_0.Rows;
      activePosition = this.grid_0.Selection.ActivePosition;
      int row1 = activePosition.Row;
      object tag = rows1[row1].Tag;
      arrayList0.Remove(tag);
      GridRows rows2 = this.grid_0.Rows;
      activePosition = this.grid_0.Selection.ActivePosition;
      int row2 = activePosition.Row;
      rows2.Remove(row2);
      this.OnListChanged(EventArgs.Empty);
    }
    catch (Exception ex)
    {
      ErrorDialog.Show((IWin32Window) this, ex, "Error");
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      this.LoadList();
    }
    catch (Exception ex)
    {
      ErrorDialog.Show((IWin32Window) this, ex, "Error");
    }
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      Position activePosition = this.grid_0.Selection.ActivePosition;
      int num1;
      if (!activePosition.IsEmpty())
      {
        activePosition = this.grid_0.Selection.ActivePosition;
        num1 = activePosition.Row >= this.grid_0.FixedRows ? 1 : 0;
      }
      else
        num1 = 0;
      if (num1 == 0)
        return;
      GridRows rows = this.grid_0.Rows;
      activePosition = this.grid_0.Selection.ActivePosition;
      int row1 = activePosition.Row;
      object tag = rows[row1].Tag;
      activePosition = this.grid_0.Selection.ActivePosition;
      int row2 = activePosition.Row;
      int num2 = this.arrayList_0.IndexOf(tag);
      this.arrayList_0.Remove(tag);
      this.arrayList_0.Insert(num2 - 1, tag);
      this.grid_0.Rows.Move(row2, row2 - 1);
      this.grid_0.Selection.FocusRow(row2 - 1);
      this.OnListChanged(EventArgs.Empty);
    }
    catch (Exception ex)
    {
      ErrorDialog.Show((IWin32Window) this, ex, "Error");
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      Position activePosition = this.grid_0.Selection.ActivePosition;
      int num1;
      if (!activePosition.IsEmpty())
      {
        activePosition = this.grid_0.Selection.ActivePosition;
        if (activePosition.Row >= this.grid_0.FixedRows)
        {
          activePosition = this.grid_0.Selection.ActivePosition;
          num1 = activePosition.Row < this.grid_0.Rows.Count - 1 ? 1 : 0;
          goto label_5;
        }
      }
      num1 = 0;
label_5:
      if (num1 == 0)
        return;
      GridRows rows = this.grid_0.Rows;
      activePosition = this.grid_0.Selection.ActivePosition;
      int row1 = activePosition.Row;
      object tag = rows[row1].Tag;
      activePosition = this.grid_0.Selection.ActivePosition;
      int row2 = activePosition.Row;
      int num2 = this.arrayList_0.IndexOf(tag);
      this.arrayList_0.Remove(tag);
      this.arrayList_0.Insert(num2 + 1, tag);
      this.grid_0.Rows.Move(row2, row2 + 1);
      this.grid_0.Selection.FocusRow(row2 + 1);
      this.OnListChanged(EventArgs.Empty);
    }
    catch (Exception ex)
    {
      ErrorDialog.Show((IWin32Window) this, ex, "Error");
    }
  }

  public bool EnableAdd
  {
    get => this.button_3.Visible;
    set => this.button_3.Visible = value;
  }

  public bool EnableRemove
  {
    get => this.button_2.Visible;
    set => this.button_2.Visible = value;
  }

  public bool EnableRefresh
  {
    get => this.button_4.Visible;
    set => this.button_4.Visible = value;
  }

  public bool EnableMove
  {
    get => this.button_1.Visible;
    set
    {
      this.button_1.Visible = value;
      this.button_0.Visible = value;
    }
  }

  private void method_6(object sender, RowCancelEventArgs e)
  {
    this.button_0.Enabled = false;
    this.button_1.Enabled = false;
    this.button_2.Enabled = false;
  }

  private void method_7(object sender, RowEventArgs e)
  {
    this.button_0.Enabled = true;
    this.button_1.Enabled = true;
    this.button_2.Enabled = true;
  }
}
