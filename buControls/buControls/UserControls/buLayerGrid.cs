// Decompiled with JetBrains decompiler
// Type: buControls.UserControls.buLayerGrid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

#nullable disable
namespace buControls.UserControls;

public class buLayerGrid : UserControl
{
  public List<LayerBase> Layers = new List<LayerBase>();
  public int SelectedLayer = 0;
  public bool ShowNoteColumb = false;
  private DataColumn dataColumn_0;
  private DataTable dataTable_0 = new DataTable();
  private bool bool_0 = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal DataGridView dataGridView_0;

  public event ValueIntChangedEventHandler LayerChanged;

  public event ValueBoolChangedEventHandler EnableChanged;

  public buLayerGrid() => Class39.smethod_819(this);

  public void Init()
  {
    this.dataTable_0 = new DataTable();
    this.dataColumn_0 = new DataColumn("Name", System.Type.GetType("System.String"));
    this.dataTable_0.Columns.Add(this.dataColumn_0);
    this.dataColumn_0 = new DataColumn("Enable", System.Type.GetType("System.Boolean"));
    this.dataTable_0.Columns.Add(this.dataColumn_0);
    this.dataColumn_0 = new DataColumn("Color", System.Type.GetType("System.String"));
    this.dataTable_0.Columns.Add(this.dataColumn_0);
    this.dataColumn_0 = new DataColumn("Info", System.Type.GetType("System.String"));
    this.dataTable_0.Columns.Add(this.dataColumn_0);
    this.dataGridView_0.DataSource = (object) this.dataTable_0;
    this.dataGridView_0.RowHeadersVisible = false;
    this.dataGridView_0.ColumnHeadersVisible = false;
    this.dataGridView_0.AllowUserToAddRows = false;
    this.dataGridView_0.AllowUserToResizeColumns = false;
    int num = 145;
    if (!this.ShowNoteColumb)
    {
      num -= 40;
      this.dataGridView_0.Columns[3].Visible = false;
    }
    this.dataGridView_0.Columns[0].Width = this.dataGridView_0.Width - num - 1;
    this.dataGridView_0.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridView_0.Columns[1].Width = 35;
    this.dataGridView_0.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridView_0.Columns[2].Width = 70;
    this.dataGridView_0.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridView_0.Columns[3].Width = 40;
    this.dataGridView_0.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
  }

  public void LayerUpdate(bool Fill, List<LayerBase> layers)
  {
    this.bool_0 = true;
    if (Fill)
    {
      this.dataTable_0.Rows.Clear();
      for (int index = 0; index <= layers.Count - 1; ++index)
      {
        DataRowCollection rows = this.dataTable_0.Rows;
        ref DataTable local = ref this.dataTable_0;
        DataRow row = Class39.smethod_728(layers[index], this, ref local);
        rows.Add(row);
        this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 1].Cells[2].Style.BackColor = layers[index].LayerColor;
        this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 1].Cells[2].Style.ForeColor = buImage.InvertColorNoGray(layers[index].LayerColor);
      }
    }
    else
    {
      for (int index = 0; index <= layers.Count - 1; ++index)
      {
        this.dataGridView_0.Rows[index].Cells[0].Value = (object) layers[index].ShownName;
        this.dataGridView_0.Rows[index].Cells[1].Value = (object) layers[index].Enable;
        this.dataGridView_0.Rows[index].Cells[2].Value = !layers[index].LayerColor.IsKnownColor ? (object) layers[index].LayerColor.ToString() : (object) layers[index].LayerColor.ToKnownColor();
        this.dataGridView_0.Rows[index].Cells[2].Style.BackColor = layers[index].LayerColor;
        this.dataGridView_0.Rows[index].Cells[2].Style.ForeColor = buImage.InvertColorNoGray(layers[index].LayerColor);
        this.dataGridView_0.Rows[index].Cells[3].Value = (object) layers[index].Note;
      }
    }
    this.bool_0 = false;
  }

  public void SetEnableValue(bool Enable, int LayerIndex)
  {
    this.bool_0 = true;
    if (LayerIndex >= 0 & LayerIndex <= this.dataGridView_0.Rows.Count - 1)
      this.dataGridView_0.Rows[LayerIndex].Cells[1].Value = (object) Enable;
    this.bool_0 = false;
  }

  public void SetSelectedValue(int LayerIndex)
  {
    this.bool_0 = true;
    if (LayerIndex >= 0 & LayerIndex <= this.dataGridView_0.Rows.Count - 1)
      this.dataGridView_0.Rows[LayerIndex].Cells[0].Selected = true;
    this.bool_0 = false;
  }

  internal void method_0(object sender, DataGridViewCellEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(e.ColumnIndex == 1 & !this.bool_0) || this.valueBoolChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.valueBoolChangedEventHandler_0(Convert.ToBoolean(this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
  }

  internal void method_1(object sender, DataGridViewCellEventArgs e)
  {
    this.SelectedLayer = e.RowIndex;
    // ISSUE: reference to a compiler-generated field
    if (this.valueIntChangedEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.valueIntChangedEventHandler_0(this.SelectedLayer);
    }
    for (int index = 0; index <= this.dataGridView_0.Rows.Count - 1; ++index)
      this.dataGridView_0.Rows[index].Cells[0].Selected = false;
    this.dataGridView_0.Rows[e.RowIndex].Cells[0].Selected = true;
  }

  internal void method_2(object sender, DataGridViewCellMouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(e.ColumnIndex == 1 & !this.bool_0) || this.valueBoolChangedEventHandler_0 == null)
      return;
    this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (object) !Convert.ToBoolean(this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
  }

  internal void method_3(object sender, DataGridViewCellValidatingEventArgs e)
  {
  }

  internal void method_4(object sender, DataGridViewCellEventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
