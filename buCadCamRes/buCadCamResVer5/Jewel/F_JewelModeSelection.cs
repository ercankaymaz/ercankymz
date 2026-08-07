// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Jewel.F_JewelModeSelection
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Jewel;

public class F_JewelModeSelection : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  public JewelMode CurrentModePars = new JewelMode();
  public string strDelete = "Do You Want to Delete Mode";
  public string strNotAllowedDelete = "You Can't Delete this Mode";
  public string strNotAllowedEdit = "You Can't Edit this Mode";
  public string strFolder = Application.StartupPath;
  private int int_0 = -1;
  private IContainer icontainer_0 = (IContainer) null;
  public DataGridView DGV;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Button button_3;

  public F_JewelModeSelection() => Class5.smethod_195(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.AutoScaleMode = this.PropertiesForm.ScaleFromMode;
    this.DGV.Columns.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 40;
    dataGridViewColumn1.HeaderText = "No";
    dataGridViewColumn1.Name = "No";
    dataGridViewColumn1.ReadOnly = true;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.DGV.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = 200;
    dataGridViewColumn2.HeaderText = "Name";
    dataGridViewColumn2.Name = "Name";
    dataGridViewColumn2.ReadOnly = true;
    dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.DGV.Columns.Add(dataGridViewColumn2);
    DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
    dataGridViewColumn3.Width = 140;
    dataGridViewColumn3.HeaderText = "Prepare";
    dataGridViewColumn3.Name = "Prepare";
    dataGridViewColumn3.ReadOnly = true;
    dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.DGV.Columns.Add(dataGridViewColumn3);
    DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
    dataGridViewColumn4.Width = 100;
    dataGridViewColumn4.HeaderText = "Update";
    dataGridViewColumn4.Name = "Update";
    dataGridViewColumn4.ReadOnly = true;
    dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.DGV.Columns.Add(dataGridViewColumn4);
    DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
    dataGridViewColumn5.Width = 100;
    dataGridViewColumn5.HeaderText = "Delete";
    dataGridViewColumn5.Name = "Delete";
    dataGridViewColumn5.ReadOnly = true;
    dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn5.ReadOnly = false;
    this.DGV.Columns.Add(dataGridViewColumn5);
    dataGridViewColumn2.Width = this.DGV.Width - dataGridViewColumn1.Width - dataGridViewColumn3.Width - dataGridViewColumn4.Width - dataGridViewColumn5.Width - 15;
    this.DGV.RowHeadersVisible = false;
    this.DGV.AllowUserToAddRows = false;
    this.DGV.AllowUserToResizeColumns = false;
    this.DGV.AllowUserToResizeRows = false;
    this.DGV.Rows.Clear();
    for (int index = 0; index <= clsJewel.JewelModes.Count - 1; ++index)
      this.DGV.Rows.Add((object) (index + 1).ToString(), (object) clsJewel.JewelModes[index].Name, (object) clsJewel.JewelModes[index].Prepared, (object) "Update", (object) "Delete");
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void method_1(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      this.int_0 = e.RowIndex;
      if (e.ColumnIndex == 3 && this.int_0 >= 0 & this.int_0 <= clsJewel.JewelModes.Count - 1)
      {
        if (new JewelMode(clsJewel.JewelModes[this.int_0]).Prepared.ToLower() == "manufacturer" & AppSecurity.PasswordLevel < 2)
        {
          buString5.MessageBoxWarning(this.strNotAllowedEdit);
          return;
        }
        F_JewelModes fJewelModes = new F_JewelModes();
        fJewelModes.CurrentModePars = new JewelMode(clsJewel.JewelModes[this.int_0]);
        fJewelModes.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
        fJewelModes.Init();
        int num = (int) fJewelModes.ShowDialog();
        if (fJewelModes.PropertiesForm.Result == DialogResult.OK)
        {
          JewelMode data = new JewelMode(fJewelModes.CurrentModePars);
          clsJewel.JewelModes[this.int_0] = new JewelMode(data);
          this.DGV.Rows.Clear();
          for (int index = 0; index <= clsJewel.JewelModes.Count - 1; ++index)
            this.DGV.Rows.Add((object) (index + 1).ToString(), (object) clsJewel.JewelModes[index].Name, (object) clsJewel.JewelModes[index].Prepared, (object) "Update", (object) "Delete");
        }
      }
      if (e.ColumnIndex != 4 || !(this.int_0 >= 0 & this.int_0 <= clsJewel.JewelModes.Count - 1))
        return;
      if (new JewelMode(clsJewel.JewelModes[this.int_0]).Prepared.ToLower() == "manufacturer" & AppSecurity.PasswordLevel < 2)
      {
        buString5.MessageBoxWarning(this.strNotAllowedDelete);
      }
      else
      {
        if (buString5.MessageBoxQuestion(this.strDelete) != DialogResult.Yes)
          return;
        clsJewel.JewelModes.RemoveAt(this.int_0);
        this.DGV.Rows.Clear();
        for (int index = 0; index <= clsJewel.JewelModes.Count - 1; ++index)
          this.DGV.Rows.Add((object) (index + 1).ToString(), (object) clsJewel.JewelModes[index].Name, (object) clsJewel.JewelModes[index].Prepared, (object) "Update", (object) "Delete");
      }
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
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (this.int_0 >= 0 & this.int_0 <= clsJewel.JewelModes.Count - 1)
        this.CurrentModePars = new JewelMode(clsJewel.JewelModes[this.int_0]);
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_0.Name)
    {
      F_JewelModes fJewelModes = new F_JewelModes();
      fJewelModes.CurrentModePars = !(this.int_0 >= 0 & this.int_0 <= clsJewel.JewelModes.Count - 1) ? new JewelMode(this.CurrentModePars) : new JewelMode(clsJewel.JewelModes[this.int_0]);
      fJewelModes.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      fJewelModes.Init();
      int num = (int) fJewelModes.ShowDialog();
      if (fJewelModes.PropertiesForm.Result == DialogResult.OK)
      {
        JewelMode jewelMode = new JewelMode(fJewelModes.CurrentModePars);
        clsJewel.JewelModes.Add(jewelMode);
        this.DGV.Rows.Add((object) clsJewel.JewelModes.Count.ToString(), (object) jewelMode.Name, (object) jewelMode.Prepared, (object) "Update", (object) "Delete");
      }
    }
    if (control2.Name == this.button_3.Name && this.int_0 >= 0 & this.int_0 <= clsJewel.JewelModes.Count - 1)
    {
      JewelMode jewelMode = new JewelMode(clsJewel.JewelModes[this.int_0]);
      jewelMode.Name += " - Copy";
      clsJewel.JewelModes.Add(jewelMode);
      this.DGV.Rows.Add((object) clsJewel.JewelModes.Count.ToString(), (object) clsJewel.JewelModes[clsJewel.JewelModes.Count - 1].Name, (object) clsJewel.JewelModes[clsJewel.JewelModes.Count - 1].Prepared, (object) "Update", (object) "Delete");
    }
    if (control2.Name == this.button_2.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsVar.varInterface.pathJewelModes;
      openFileDialog.Multiselect = false;
      openFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        clsVar.varInterface.pathJewelModes = buFile5.GetPath(openFileDialog.FileName);
        clsJewel.JewelModeOpen(openFileDialog.FileName);
        this.DGV.Rows.Clear();
        for (int index = 0; index <= clsJewel.JewelModes.Count - 1; ++index)
          this.DGV.Rows.Add((object) (index + 1).ToString(), (object) clsJewel.JewelModes[index].Name, (object) clsJewel.JewelModes[index].Prepared, (object) "Update", (object) "Delete");
        clsFiles.SaveParameter();
      }
    }
    if (!(control2.Name == this.button_1.Name))
      return;
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathJewelModes;
    saveFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    clsVar.varInterface.pathJewelModes = buFile5.GetPath(saveFileDialog.FileName);
    clsJewel.JewelModeSave(saveFileDialog.FileName, true);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
