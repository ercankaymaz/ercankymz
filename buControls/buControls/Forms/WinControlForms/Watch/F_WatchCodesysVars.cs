// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Watch.F_WatchCodesysVars
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Forms.WinControlForms.Variable;
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
namespace buControls.Forms.WinControlForms.Watch;

public class F_WatchCodesysVars : Form
{
  public FormProperties Properties = new FormProperties();
  public bool HideExplanationColumb = false;
  public bool HideStatusColumb = false;
  public List<WatchItem> AllItems = new List<WatchItem>();
  public List<WatchItem> Items = new List<WatchItem>();
  public static List<string> Captions = new List<string>();
  public static string strRemove = "Do you want to remove variable?";
  private int int_0 = -1;
  private DataColumn dataColumn_0;
  private DataTable dataTable_0 = new DataTable();
  internal IContainer icontainer_0 = (IContainer) null;
  public DataGridView DGV;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal ImageList imageList_0;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;

  public F_WatchCodesysVars() => Class39.smethod_268(this);

  public event WatchItemWriteEventHandler WriteVariable;

  public void Init()
  {
    try
    {
      this.Properties.Inited = false;
      if (this.Properties.Height > 10)
        this.Height = this.Properties.Height;
      if (this.Properties.Width > 10)
        this.Width = this.Properties.Width;
      this.TopMost = this.Properties.TopMost;
      this.StartPosition = this.Properties.FormPosition;
      this.AutoScaleMode = this.Properties.ScaleFromMode;
      this.dataTable_0 = new DataTable();
      this.dataColumn_0 = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Name", System.Type.GetType("System.String"));
      this.dataTable_0.Columns.Add(this.dataColumn_0);
      this.dataColumn_0 = new DataColumn("Value", System.Type.GetType("System.Double"));
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
      this.DGV.Columns[0].Width = 60;
      this.DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[2].Width = 100;
      this.DGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[3].Width = 100;
      this.DGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[4].Width = 100;
      this.DGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[5].Width = 120;
      this.DGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.DGV.Columns[6].Width = 80 /*0x50*/;
      this.DGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
      if (this.HideExplanationColumb)
      {
        this.DGV.Columns[5].Visible = false;
        this.DGV.Columns[5].Width = 0;
      }
      if (this.HideStatusColumb)
      {
        this.DGV.Columns[6].Visible = false;
        this.DGV.Columns[6].Width = 0;
      }
      int num = this.Width - this.DGV.Columns[0].Width - this.DGV.Columns[2].Width - this.DGV.Columns[3].Width - this.DGV.Columns[4].Width - this.DGV.Columns[5].Width - this.DGV.Columns[6].Width - 40;
      if (num < 200)
        num = 200;
      this.DGV.Columns[1].Width = num;
      this.DGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
      for (int index = 0; index <= this.Items.Count - 1; ++index)
      {
        DataRowCollection rows = this.dataTable_0.Rows;
        ref DataTable local = ref this.dataTable_0;
        DataRow row = Class39.smethod_232(this.Items[index], ref local, this, index + 1);
        rows.Add(row);
      }
      this.Properties.Result = DialogResult.None;
      this.Properties.Inited = true;
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
      if (F_WatchCodesysVars.Captions.Count > 0)
        ;
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
          this.DGV.Rows[index].Cells[2].Value = (object) Items[index].Value;
          this.DGV.Rows[index].Cells[3].Value = (object) Items[index].MinValue;
          this.DGV.Rows[index].Cells[4].Value = (object) Items[index].MaxValue;
          this.DGV.Rows[index].Cells[6].Value = (object) Items[index].Status;
          if (!Items[index].CommStatus & this.DGV.Rows[index].Cells[2].Style.BackColor == Color.White)
            this.DGV.Rows[index].Cells[2].Style.BackColor = Color.Red;
          if (Items[index].CommStatus & this.DGV.Rows[index].Cells[2].Style.BackColor != Color.White)
            this.DGV.Rows[index].Cells[2].Style.BackColor = Color.White;
          this.DGV.Rows[index].Cells[6].Value = (object) Items[index].Status;
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

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.button_0.Name)
    {
      F_VariableAdd fVariableAdd = new F_VariableAdd();
      for (int index = 0; index <= this.AllItems.Count - 1; ++index)
        fVariableAdd.Variables.Add(new WatchItem(this.AllItems[index]));
      fVariableAdd.Init();
      fVariableAdd.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fVariableAdd.ShowDialog((IWin32Window) this);
      if (fVariableAdd.Properties.Result == DialogResult.OK)
      {
        this.Items.Add(new WatchItem(fVariableAdd.SelectedVariables)
        {
          VarType = fVariableAdd.VarType
        });
        this.dataTable_0.Rows.Add(Class39.smethod_232(this.Items[this.Items.Count - 1], ref this.dataTable_0, this, this.Items.Count));
      }
    }
    if (control2.Name == this.button_1.Name && this.int_0 >= 0 & this.int_0 <= this.Items.Count - 1 && buString.MessageBoxQuestion(F_WatchCodesysVars.strRemove) == DialogResult.Yes)
    {
      this.Items.RemoveAt(this.int_0);
      this.dataTable_0.Rows.RemoveAt(this.int_0);
    }
    if (control2.Name == this.button_5.Name && this.int_0 >= 0 & this.int_0 <= this.Items.Count - 1)
    {
      F_VariableWrite fVariableWrite = new F_VariableWrite();
      fVariableWrite.Variable = new WatchItem(this.Items[this.int_0]);
      fVariableWrite.Init();
      fVariableWrite.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fVariableWrite.ShowDialog((IWin32Window) this);
      // ISSUE: reference to a compiler-generated field
      if (fVariableWrite.Properties.Result == DialogResult.OK && this.watchItemWriteEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.watchItemWriteEventHandler_0(new List<WatchItem>()
        {
          fVariableWrite.Variable
        });
      }
    }
    if (!(control2.Name == this.button_4.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, DataGridViewCellEventArgs e) => this.int_0 = e.RowIndex;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
