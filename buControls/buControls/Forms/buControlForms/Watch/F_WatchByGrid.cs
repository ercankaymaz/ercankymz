// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Watch.F_WatchByGrid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Watch;

public class F_WatchByGrid : Form
{
  public string AddString = "";
  public static List<string> Captions = new List<string>();
  public List<WatchItem> Items = new List<WatchItem>();
  public bool HideNewValueColumb = false;
  public bool HideExplanationColumb = false;
  public bool HideStatusColumb = false;
  private int int_0 = -1;
  private DataColumn dataColumn_0;
  private DataTable dataTable_0 = new DataTable();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  public DataGridView DGV;
  internal buButton buButton_2;
  public buButton btn_add;
  public buButton btn_cancel;
  public buButton btn_write;
  public buButton btn_save;
  public buButton btn_load;
  public buButton buButton4;
  public buButton btn_reset;
  public buButton btn_removeall;
  public buButton btn_remove;

  public F_WatchByGrid() => Class39.smethod_762(this);

  public event WatchItemResetClickEventHandler ResetClick;

  public event WatchItemRemoveAllClickEventHandler RemoveAllClick;

  public event WatchItemRemoveClickEventHandler RemoveClick;

  public event WatchItemListChangedEventHandler ListChanged;

  public event WatchItemWriteEventHandler WriteItems;

  public void Init()
  {
    try
    {
      this.dataTable_0 = new DataTable();
      this.dataColumn_0 = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Name", System.Type.GetType("System.String"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Value", System.Type.GetType("System.Double"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("New Value", System.Type.GetType("System.String"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Min", System.Type.GetType("System.Double"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Max", System.Type.GetType("System.Double"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Explanation", System.Type.GetType("System.String"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Status", System.Type.GetType("System.String"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.DGV.DataSource = (object) this.dataTable_0;
      this.DGV.RowHeadersVisible = false;
      this.DGV.AllowUserToAddRows = false;
      this.DGV.AllowUserToResizeColumns = true;
      this.DGV.Columns[0].Width = 40;
      this.DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[2].Width = 100;
      this.DGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[3].Width = 100;
      this.DGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[4].Width = 100;
      this.DGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[5].Width = 100;
      this.DGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[6].Width = 120;
      this.DGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[7].Width = 80 /*0x50*/;
      this.DGV.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
      if (this.HideNewValueColumb)
      {
        this.DGV.Columns[3].Visible = false;
        this.DGV.Columns[3].Width = 0;
      }
      if (this.HideExplanationColumb)
      {
        this.DGV.Columns[6].Visible = false;
        this.DGV.Columns[6].Width = 0;
      }
      if (this.HideStatusColumb)
      {
        this.DGV.Columns[7].Visible = false;
        this.DGV.Columns[7].Width = 0;
      }
      int num = this.Width - this.DGV.Columns[0].Width - this.DGV.Columns[2].Width - this.DGV.Columns[3].Width - this.DGV.Columns[4].Width - this.DGV.Columns[5].Width - this.DGV.Columns[6].Width - this.DGV.Columns[7].Width - this.btn_add.Width - 25;
      if (num < 200)
        num = 200;
      this.DGV.Columns[1].Width = num;
      this.DGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
      for (int index = 0; index <= this.Items.Count - 1; ++index)
      {
        DataRowCollection rows = this.dataTable_0.Rows;
        ref DataTable local = ref this.dataTable_0;
        WatchItem watchItem_0 = this.Items[index];
        DataRow row = Class39.smethod_300(index + 1, watchItem_0, ref local, this);
        rows.Add(row);
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_WatchByGrid.Captions.Count <= 0)
        return;
      this.Text = F_WatchByGrid.Captions[0];
      this.btn_reset.Text = F_WatchByGrid.Captions[0];
      this.btn_write.Text = F_WatchByGrid.Captions[0];
      this.btn_add.Text = F_WatchByGrid.Captions[0];
      this.btn_remove.Text = F_WatchByGrid.Captions[0];
      this.btn_removeall.Text = F_WatchByGrid.Captions[0];
      this.btn_save.Text = F_WatchByGrid.Captions[0];
      this.btn_cancel.Text = F_WatchByGrid.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void UpdateWatchList(List<WatchItem> Items)
  {
    try
    {
      for (int index = 0; index <= Items.Count - 1; ++index)
      {
        if (index <= this.DGV.Rows.Count - 1)
        {
          if (Convert.ToDouble(this.DGV.Rows[index].Cells[2].Value) != Items[index].Value)
          {
            this.DGV.Rows[index].Cells[2].Value = (object) Items[index].Value;
            this.DGV.Rows[index].Cells[4].Value = (object) Items[index].MinValue;
            this.DGV.Rows[index].Cells[5].Value = (object) Items[index].MaxValue;
            this.DGV.Rows[index].Cells[7].Value = (object) Items[index].Status;
          }
          if (!Items[index].CommStatus & this.DGV.Rows[index].Cells[2].Style.BackColor == Color.White)
          {
            this.DGV.Rows[index].Cells[2].Style.BackColor = Color.Red;
            this.DGV.Rows[index].Cells[7].Value = (object) Items[index].Status;
          }
          if (Items[index].CommStatus & this.DGV.Rows[index].Cells[2].Style.BackColor == Color.Red)
          {
            this.DGV.Rows[index].Cells[2].Style.BackColor = Color.White;
            this.DGV.Rows[index].Cells[7].Value = (object) Items[index].Status;
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_0(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      this.int_0 = e.RowIndex;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_1(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      if (!(e.RowIndex >= 0 & e.RowIndex <= this.Items.Count - 1))
        return;
      if (e.ColumnIndex == 1)
      {
        this.Items[e.RowIndex].Name = this.DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        // ISSUE: reference to a compiler-generated field
        if (this.watchItemListChangedEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.watchItemListChangedEventHandler_0(this.Items);
        }
      }
      if (e.ColumnIndex == 3)
        this.Items[e.RowIndex].NewValue = this.DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
      this.btn_write.Focus();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemResetClickEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemResetClickEventHandler_0();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = Application.StartupPath;
      saveFileDialog.Filter = "Watch Item Files (*.watch)|*.watch";
      saveFileDialog.FilterIndex = 1;
      saveFileDialog.FileName = "";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      List<string> StringList = new List<string>();
      StringList.Add("Name ; Value ; MinValue ; MaxValue ; AvarageValue ; Explanation");
      for (int index = 0; index <= this.Items.Count - 1; ++index)
      {
        string str = $"{this.Items[index].Name} ; {this.Items[index].Value.ToString()} ; {this.Items[index].MinValue.ToString()} ; {this.Items[index].MaxValue.ToString()} ; {this.Items[index].AvarageValue.ToString()} ; {this.Items[index].Explanation}";
        StringList.Add(str);
      }
      buFile.SaveToFile(StringList, saveFileDialog.FileName);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      this.Items.Add(new WatchItem());
      this.dataTable_0.Rows.Add(Class39.smethod_300(this.Items.Count, this.Items[this.Items.Count - 1], ref this.dataTable_0, this));
      if (this.DGV.Rows.Count > 0)
        this.DGV.Rows[this.DGV.Rows.Count - 1].Cells[2].Style.BackColor = Color.White;
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemListChangedEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemListChangedEventHandler_0(this.Items);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      string text = "Do You Want to Remove";
      if (AppLanguage.SystemMessages.Count >= 8)
        text = AppLanguage.SystemMessages[7];
      if (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.No || !(this.int_0 >= 0 & this.int_0 <= this.Items.Count - 1))
        return;
      this.dataTable_0.Rows.RemoveAt(this.int_0);
      this.Items.RemoveAt(this.int_0);
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemListChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.watchItemListChangedEventHandler_0(this.Items);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemRemoveClickEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemRemoveClickEventHandler_0(this.int_0);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    try
    {
      string text = "Do You Want to Remove All";
      if (AppLanguage.SystemMessages.Count >= 9)
        text = AppLanguage.SystemMessages[8];
      if (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.No)
        return;
      this.dataTable_0.Rows.Clear();
      this.Items.Clear();
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemListChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.watchItemListChangedEventHandler_0(this.Items);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemRemoveAllClickEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemRemoveAllClickEventHandler_0();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_7(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemWriteEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemWriteEventHandler_0(this.Items);
      for (int index = 0; index <= this.Items.Count - 1; ++index)
      {
        this.Items[index].NewValue = "";
        this.DGV.Rows[index].Cells[3].Value = (object) "";
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_8(object sender, EventArgs e)
  {
    try
    {
      if (!(this.int_0 >= 0 & this.int_0 <= this.DGV.Rows.Count - 1))
        return;
      this.DGV.Rows[this.int_0].Cells[1].Value = (object) this.AddString;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_9(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_1.Name | control2.Name == this.btn_cancel.Name)
        this.Visible = false;
      if (control2.Name == this.buButton_0.Name)
        this.WindowState = FormWindowState.Minimized;
      if (!(control2.Name == this.buButton_2.Name))
        return;
      if (this.WindowState == FormWindowState.Maximized)
        this.WindowState = FormWindowState.Normal;
      else
        this.WindowState = FormWindowState.Maximized;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
