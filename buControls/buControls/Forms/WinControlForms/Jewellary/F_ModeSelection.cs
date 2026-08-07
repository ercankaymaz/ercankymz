// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_ModeSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_ModeSelection : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public List<JewelVar> Modes = new List<JewelVar>();
  public string strDelete = "Do You Want to Delete Mode";
  public string strNotAllowedDelete = "You Can't Delete this Mode";
  public string strNotAllowedEdit = "You Can't Edit this Mode";
  public string strFolder = Application.StartupPath;
  public bool SpindleEnable = true;
  public bool Dia1Enable = true;
  public bool Dia2Enable = true;
  public bool EngraveEnable = true;
  public bool LaserEnable = true;
  public bool LatheEnable = true;
  private int int_0 = -1;
  private DataColumn dataColumn_0;
  private DataTable dataTable_0 = new DataTable();
  private IContainer icontainer_0 = (IContainer) null;
  public DataGridView DGV;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Button button_3;
  internal Button button_4;

  public F_ModeSelection() => Class39.smethod_662(this);

  public void Init()
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
    this.dataColumn_0 = new DataColumn("Prepare", System.Type.GetType("System.String"));
    this.dataTable_0.Columns.Add(this.dataColumn_0);
    this.dataColumn_0 = new DataColumn("Update", System.Type.GetType("System.String"));
    this.dataTable_0.Columns.Add(this.dataColumn_0);
    this.dataColumn_0 = new DataColumn("Delete", System.Type.GetType("System.String"));
    this.dataTable_0.Columns.Add(this.dataColumn_0);
    this.DGV.DataSource = (object) this.dataTable_0;
    this.DGV.RowHeadersVisible = false;
    this.DGV.AllowUserToAddRows = false;
    this.DGV.AllowUserToResizeColumns = true;
    this.DGV.Columns[0].Width = 40;
    this.DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV.Columns[1].Width = 200;
    this.DGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV.Columns[2].Width = 100;
    this.DGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV.Columns[3].Width = 100;
    this.DGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV.Columns[3].ReadOnly = true;
    this.DGV.Columns[4].Width = 100;
    this.DGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV.Columns[4].ReadOnly = true;
    for (int index = 0; index <= this.Modes.Count - 1; ++index)
    {
      DataRowCollection rows = this.dataTable_0.Rows;
      ref DataTable local = ref this.dataTable_0;
      string modeName = this.Modes[index].ModeName;
      DataRow row = Class39.smethod_753(this.Modes[index].ModePreparedBy, ref local, this, modeName, index + 1);
      rows.Add(row);
    }
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_0(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      this.int_0 = e.RowIndex;
      if (e.ColumnIndex == 3 && this.int_0 >= 0 & this.int_0 <= this.Modes.Count - 1)
      {
        if (new JewelVar(this.Modes[this.int_0]).ModePreparedBy.ToLower() == "manufacturer" & AppSecurity.PasswordLevel < 2)
        {
          buString.MessageBoxWarning(this.strNotAllowedEdit);
          return;
        }
        F_JewelWizardForModes jewelWizardForModes = new F_JewelWizardForModes();
        jewelWizardForModes.SpindleEnable = this.SpindleEnable;
        jewelWizardForModes.Dia1Enable = this.Dia1Enable;
        jewelWizardForModes.Dia2Enable = this.Dia2Enable;
        jewelWizardForModes.EngraveEnable = this.EngraveEnable;
        jewelWizardForModes.LaserEnable = this.LaserEnable;
        jewelWizardForModes.LatheEnable = this.LatheEnable;
        jewelWizardForModes.ParJewel = new JewelVar(this.Modes[this.int_0]);
        jewelWizardForModes.Properties.FormCloseMode = FormCloseModeType.Dispose;
        jewelWizardForModes.Init();
        int num = (int) jewelWizardForModes.ShowDialog();
        if (jewelWizardForModes.Properties.Result == DialogResult.OK)
        {
          this.Modes[this.int_0] = new JewelVar(new JewelVar(jewelWizardForModes.ParJewel));
          this.dataTable_0.Rows.Clear();
          for (int index = 0; index <= this.Modes.Count - 1; ++index)
          {
            DataRowCollection rows = this.dataTable_0.Rows;
            ref DataTable local = ref this.dataTable_0;
            string modeName = this.Modes[index].ModeName;
            DataRow row = Class39.smethod_753(this.Modes[index].ModePreparedBy, ref local, this, modeName, index + 1);
            rows.Add(row);
          }
        }
      }
      if (e.ColumnIndex != 4 || !(this.int_0 >= 0 & this.int_0 <= this.Modes.Count - 1))
        return;
      if (new JewelVar(this.Modes[this.int_0]).ModePreparedBy.ToLower() == "manufacturer" & AppSecurity.PasswordLevel < 2)
      {
        buString.MessageBoxWarning(this.strNotAllowedDelete);
      }
      else
      {
        if (buString.MessageBoxQuestion(this.strDelete) != DialogResult.Yes)
          return;
        this.Modes.RemoveAt(this.int_0);
        this.dataTable_0.Rows.Clear();
        for (int index = 0; index <= this.Modes.Count - 1; ++index)
        {
          DataRowCollection rows = this.dataTable_0.Rows;
          ref DataTable local = ref this.dataTable_0;
          string modeName = this.Modes[index].ModeName;
          DataRow row = Class39.smethod_753(this.Modes[index].ModePreparedBy, ref local, this, modeName, index + 1);
          rows.Add(row);
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

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
      ;
    if (control2.Name == this.button_0.Name)
    {
      F_JewelWizardForModes jewelWizardForModes = new F_JewelWizardForModes();
      jewelWizardForModes.SpindleEnable = this.SpindleEnable;
      jewelWizardForModes.Dia1Enable = this.Dia1Enable;
      jewelWizardForModes.Dia2Enable = this.Dia2Enable;
      jewelWizardForModes.EngraveEnable = this.EngraveEnable;
      jewelWizardForModes.LaserEnable = this.LaserEnable;
      jewelWizardForModes.LatheEnable = this.LatheEnable;
      jewelWizardForModes.Properties.FormCloseMode = FormCloseModeType.Dispose;
      jewelWizardForModes.Init();
      int num = (int) jewelWizardForModes.ShowDialog();
      if (jewelWizardForModes.Properties.Result == DialogResult.OK)
      {
        JewelVar jewelVar = new JewelVar(jewelWizardForModes.ParJewel);
        this.Modes.Add(jewelVar);
        DataRowCollection rows = this.dataTable_0.Rows;
        ref DataTable local = ref this.dataTable_0;
        int count = this.Modes.Count;
        string modeName = jewelVar.ModeName;
        DataRow row = Class39.smethod_753(jewelVar.ModePreparedBy, ref local, this, modeName, count);
        rows.Add(row);
      }
    }
    if (control2.Name == this.button_3.Name && this.int_0 >= 0 & this.int_0 <= this.Modes.Count - 1)
    {
      JewelVar jewelVar = new JewelVar(this.Modes[this.int_0]);
      this.Modes.Add(jewelVar);
      DataRowCollection rows = this.dataTable_0.Rows;
      ref DataTable local = ref this.dataTable_0;
      int count = this.Modes.Count;
      string modeName = jewelVar.ModeName;
      DataRow row = Class39.smethod_753(jewelVar.ModePreparedBy, ref local, this, modeName, count);
      rows.Add(row);
    }
    if (control2.Name == this.button_4.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = this.strFolder;
      openFileDialog.Multiselect = false;
      openFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
        if (fileInfo.Exists)
        {
          this.strFolder = buFile.GetPath(openFileDialog.FileName);
          ArrayList RefList = new ArrayList();
          TextReader textReader = (TextReader) File.OpenText(fileInfo.FullName);
          string str;
          while ((str = textReader.ReadLine()) != null)
            RefList.Add((object) str);
          textReader.Close();
          try
          {
            ArrayList CalcList1 = new ArrayList();
            buString.ListToSpecificList("<OperationMod>", "</OperationMod>", true, RefList, ref CalcList1);
            if (CalcList1.Count > 0)
            {
              this.dataTable_0.Rows.Clear();
              List<List<string>> CalcList2 = new List<List<string>>();
              buString.ListToSpecificList("<JewelVar>", "</JewelVar>", true, CalcList1, ref CalcList2);
              if (CalcList2.Count > 0)
              {
                for (int index = 0; index <= CalcList2.Count - 1; ++index)
                {
                  JewelVar jewelVar = new JewelVar();
                  buSerilization.Decode(CalcList2[index], "", SerilizationMode.MultiLine, (object) jewelVar);
                  this.Modes.Add(jewelVar);
                }
                for (int index = 0; index <= this.Modes.Count - 1; ++index)
                {
                  DataRowCollection rows = this.dataTable_0.Rows;
                  ref DataTable local = ref this.dataTable_0;
                  string modeName = this.Modes[index].ModeName;
                  DataRow row = Class39.smethod_753(this.Modes[index].ModePreparedBy, ref local, this, modeName, index + 1);
                  rows.Add(row);
                }
              }
              else
              {
                buLog.addLog("No Available Modes", "Not Ok", MethodBase.GetCurrentMethod().Name);
                buString.MessageBoxInfo("No Available Modes");
              }
            }
            else
            {
              buLog.addLog("No Available Modes", "Not Ok", MethodBase.GetCurrentMethod().Name);
              buString.MessageBoxInfo("No Available Modes");
            }
          }
          catch (Exception ex)
          {
            buLog.addLog("Open KutezDefault.cncuser", "Not Ok", MethodBase.GetCurrentMethod().Name);
            buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Open KutezDefault.cncuser");
          }
        }
      }
    }
    if (control2.Name == this.button_2.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = this.strFolder;
      openFileDialog.Multiselect = false;
      openFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
        if (fileInfo.Exists)
        {
          this.strFolder = buFile.GetPath(openFileDialog.FileName);
          ArrayList RefList = new ArrayList();
          TextReader textReader = (TextReader) File.OpenText(fileInfo.FullName);
          string str;
          while ((str = textReader.ReadLine()) != null)
            RefList.Add((object) str);
          textReader.Close();
          try
          {
            ArrayList CalcList3 = new ArrayList();
            buString.ListToSpecificList("<OperationMod>", "</OperationMod>", true, RefList, ref CalcList3);
            if (CalcList3.Count > 0)
            {
              this.dataTable_0.Rows.Clear();
              List<List<string>> CalcList4 = new List<List<string>>();
              buString.ListToSpecificList("<JewelVar>", "</JewelVar>", true, CalcList3, ref CalcList4);
              if (CalcList4.Count > 0)
              {
                this.Modes.Clear();
                for (int index = 0; index <= CalcList4.Count - 1; ++index)
                {
                  JewelVar jewelVar = new JewelVar();
                  buSerilization.Decode(CalcList4[index], "", SerilizationMode.MultiLine, (object) jewelVar);
                  this.Modes.Add(jewelVar);
                }
                for (int index = 0; index <= this.Modes.Count - 1; ++index)
                {
                  DataRowCollection rows = this.dataTable_0.Rows;
                  ref DataTable local = ref this.dataTable_0;
                  string modeName = this.Modes[index].ModeName;
                  DataRow row = Class39.smethod_753(this.Modes[index].ModePreparedBy, ref local, this, modeName, index + 1);
                  rows.Add(row);
                }
              }
              else
              {
                buLog.addLog("No Available Modes", "Not Ok", MethodBase.GetCurrentMethod().Name);
                buString.MessageBoxInfo("No Available Modes");
              }
            }
            else
            {
              buLog.addLog("No Available Modes", "Not Ok", MethodBase.GetCurrentMethod().Name);
              buString.MessageBoxInfo("No Available Modes");
            }
          }
          catch (Exception ex)
          {
            buLog.addLog("Open KutezDefault.cncuser", "Not Ok", MethodBase.GetCurrentMethod().Name);
            buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Open KutezDefault.cncuser");
          }
        }
      }
    }
    if (!(control2.Name == this.button_1.Name))
      return;
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = this.strFolder;
    saveFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "   Mods");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "<OperationMod>");
    for (int index = 0; index <= this.Modes.Count - 1; ++index)
      StringList.AddRange((ICollection) this.Modes[index].ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList.Add((object) "</OperationMod>");
    buFile.SaveToFile(StringList, saveFileDialog.FileName);
    this.strFolder = buFile.GetPath(saveFileDialog.FileName);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
