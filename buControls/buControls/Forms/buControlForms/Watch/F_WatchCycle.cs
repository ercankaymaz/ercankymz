// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Watch.F_WatchCycle
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
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Watch;

public class F_WatchCycle : Form
{
  public string AddString = "";
  public static List<string> Captions = new List<string>();
  public List<WatchItem> Items = new List<WatchItem>();
  private DataColumn dataColumn_0;
  private DataTable dataTable_0 = new DataTable();
  private int int_0 = -1;
  private IContainer icontainer_0 = (IContainer) null;
  public DataGridView DGV;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal buButton buButton_3;
  internal buButton buButton_4;
  internal buButton buButton_5;

  public F_WatchCycle() => Class39.smethod_132(this);

  public event EventHandler ResetClick;

  public void Init()
  {
    try
    {
      this.dataTable_0 = new DataTable();
      this.dataColumn_0 = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Program", System.Type.GetType("System.String"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Task", System.Type.GetType("System.String"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Value", System.Type.GetType("System.Double"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Min", System.Type.GetType("System.Double"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Max", System.Type.GetType("System.Double"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Counter", System.Type.GetType("System.Int32"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Explanation", System.Type.GetType("System.String"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.DGV.DataSource = (object) this.dataTable_0;
      this.DGV.RowHeadersVisible = false;
      this.DGV.AllowUserToAddRows = false;
      this.DGV.AllowUserToResizeColumns = true;
      this.DGV.Columns[0].Width = 40;
      this.DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[2].Width = 120;
      this.DGV.Columns[3].Width = 80 /*0x50*/;
      this.DGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[4].Width = 80 /*0x50*/;
      this.DGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[5].Width = 80 /*0x50*/;
      this.DGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[6].Width = 80 /*0x50*/;
      this.DGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[7].Width = 150;
      this.DGV.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
      int num = this.Width - this.DGV.Columns[0].Width - this.DGV.Columns[1].Width - this.DGV.Columns[3].Width - this.DGV.Columns[4].Width - this.DGV.Columns[5].Width - this.DGV.Columns[6].Width - this.DGV.Columns[7].Width - 25;
      if (num < 200)
        num = 200;
      this.DGV.Columns[1].Width = num;
      for (int index = 0; index <= this.Items.Count - 1; ++index)
      {
        DataRowCollection rows = this.dataTable_0.Rows;
        ref DataTable local = ref this.dataTable_0;
        DataRow row = Class39.smethod_372(this.Items[index], ref local, index + 1, this);
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
      if (F_WatchCycle.Captions.Count <= 0)
        return;
      this.Text = F_WatchCycle.Captions[0];
      this.buButton_2.Text = F_WatchCycle.Captions[0];
      this.buButton_1.Text = F_WatchCycle.Captions[0];
      this.buButton_3.Text = F_WatchCycle.Captions[0];
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
          this.DGV.Rows[index].Cells[1].Value = (object) Items[index].Task;
          this.DGV.Rows[index].Cells[2].Value = (object) Items[index].Program;
          this.DGV.Rows[index].Cells[3].Value = (object) Items[index].Value;
          this.DGV.Rows[index].Cells[4].Value = (object) Items[index].MinValue;
          this.DGV.Rows[index].Cells[5].Value = (object) Items[index].MaxValue;
          this.DGV.Rows[index].Cells[6].Value = (object) Items[index].Counter;
          this.DGV.Rows[index].Cells[7].Value = (object) Items[index].Explanation;
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

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_0((object) this.buButton_2, new EventArgs());
      }
      SendKeys.Send("{ESC}");
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
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = Application.StartupPath;
      saveFileDialog.Filter = "Watch Item Files (*.watch)|*.watch";
      saveFileDialog.FilterIndex = 1;
      saveFileDialog.FileName = "";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      List<string> StringList = new List<string>();
      string str = "Name ; Value ; MinValue ; MaxValue ; AvarageValue ; Explanation";
      StringList.Add(str);
      for (int index = 0; index <= this.Items.Count - 1; ++index)
        StringList.Add(str);
      buFile.SaveToFile(StringList, saveFileDialog.FileName);
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
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_5.Name | control2.Name == this.buButton_3.Name)
        this.Visible = false;
      if (control2.Name == this.buButton_4.Name)
        this.WindowState = FormWindowState.Minimized;
      if (!(control2.Name == this.buButton_0.Name))
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
