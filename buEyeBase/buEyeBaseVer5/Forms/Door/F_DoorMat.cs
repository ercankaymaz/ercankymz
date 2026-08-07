// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Door.F_DoorMat
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Events;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Foam;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Door;

public class F_DoorMat : Form
{
  public NumericUpDown spn_blockwidthendoffset;
  public NumericUpDown spn_blockheightendoffset;
  public NumericUpDown spn_blockheightstartoffset;
  public NumericUpDown spn_waveheight;
  internal Panel \u0001;
  public Label label18;
  internal Label \u0001;
  internal Label \u0002;
  internal Panel \u0002;
  public NumericUpDown spn_totalpart;
  public Label label23;
  internal Label \u0003;
  internal Label \u0004;
  public Label label16;
  public Label label19;
  public NumericUpDown spn_blockhorcount;
  public NumericUpDown spn_blockvercount;
  internal Panel \u0003;
  internal Button \u0005;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  public Label label24;
  public Label label25;
  public Label label26;
  internal TextBox \u0001;
  internal Label \u0008;
  internal Panel \u0004;
  public NumericUpDown spn_connectionvel;
  public Label label1;
  public NumericUpDown spn_leadoutvel;
  public Label label2;
  public NumericUpDown spn_leadinvel;
  public Label label3;
  public Label label4;
  public NumericUpDown spn_cutvel;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_AddFromFile) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_AddFromFile) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_AddFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_AddFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_AddFromFile) this).btn_addradius.Name)
      ((F_AddFromFile) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((F_AddFromFile) this).\u0001.Rows.Count + 1, 0.0, (F_FoamSpeedList) this, 0.0, 0.0));
    else if (control2.Name == ((F_AddFromFile) this).btn_addlength.Name)
      ((F_AddFromFile) this).\u0002.Rows.Add(\u0007.\u0001.\u0001(0.0, 0.0, 0.0, ((F_AddFromFile) this).\u0002.Rows.Count + 1, (F_FoamSpeedList) this));
    else if (control2.Name == ((F_AddFromFile) this).btn_removerad.Name)
    {
      if (!(((F_AddFromFile) this).SelectedRadiusRowSheet >= 0 & ((F_AddFromFile) this).SelectedRadiusRowSheet <= ((F_AddFromFile) this).\u0001.Rows.Count - 1))
        return;
      ((F_AddFromFile) this).\u0001.Rows.RemoveAt(((F_AddFromFile) this).SelectedRadiusRowSheet);
    }
    else if (control2.Name == ((F_AddFromFile) this).btn_removelen.Name)
    {
      if (!(((F_AddFromFile) this).SelectedLengthRowSheet >= 0 & ((F_AddFromFile) this).SelectedLengthRowSheet <= ((F_AddFromFile) this).\u0002.Rows.Count - 1))
        return;
      ((F_AddFromFile) this).\u0002.Rows.RemoveAt(((F_AddFromFile) this).SelectedLengthRowSheet);
    }
    else if (control2.Name == ((F_AddFromFile) this).btn_ok.Name)
    {
      ((F_EventAll) this).Apply();
      ((F_AddFromFile) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_AddFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_AddFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!(control2.Name == ((F_AddFromFile) this).btn_cancel.Name))
        return;
      ((F_AddFromFile) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_AddFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_AddFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_AddFromFile) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_AddFromFile) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_DoorMat() => F_AddFromFile.Captions = new List<string>();

  public F_DoorMat()
  {
    ((F_AddFromFile) this).PropertiesForm = new FormProperties();
    ((F_AddFromFile) this).SliceList = new List<LengthCount>();
    ((F_AddFromFile) this).\u0001 = -1;
    ((F_AddFromFile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_FoamSlicesList) this);
  }

  public void Init()
  {
    ((F_AddFromFile) this).PropertiesForm.Inited = false;
    if (((F_AddFromFile) this).PropertiesForm.Height > 10)
      this.Height = ((F_AddFromFile) this).PropertiesForm.Height;
    if (((F_AddFromFile) this).PropertiesForm.Width > 10)
      this.Width = ((F_AddFromFile) this).PropertiesForm.Width;
    this.TopMost = ((F_AddFromFile) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_AddFromFile) this).PropertiesForm.FormPosition;
    ((F_EventAll) this).DGV_table.Columns.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 200;
    dataGridViewColumn1.HeaderText = "Length";
    dataGridViewColumn1.Name = "Length";
    dataGridViewColumn1.ReadOnly = false;
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_EventAll) this).DGV_table.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = 200;
    dataGridViewColumn2.HeaderText = "Count";
    dataGridViewColumn2.Name = "Count";
    dataGridViewColumn2.ReadOnly = false;
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_EventAll) this).DGV_table.Columns.Add(dataGridViewColumn2);
    ((F_EventAll) this).DGV_table.RowHeadersVisible = false;
    ((F_EventAll) this).DGV_table.AllowUserToAddRows = false;
    ((F_EventAll) this).DGV_table.AllowUserToResizeColumns = false;
    this.FillGrid();
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_AddFromFile) this).PropertiesForm.Result = DialogResult.None;
    ((F_AddFromFile) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_AddFromFile.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }

  public void FillGrid()
  {
    ((F_EventAll) this).DGV_table.Rows.Clear();
    for (int index = 0; index <= ((F_AddFromFile) this).SliceList.Count - 1; ++index)
      ((F_EventAll) this).DGV_table.Rows.Add(\u0007.\u0001.\u0001(((F_AddFromFile) this).SliceList[index].Length, ((F_AddFromFile) this).SliceList[index].Count, (F_FoamSlicesList) this));
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_AddFromFile) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_AddFromFile) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_AddFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_AddFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
