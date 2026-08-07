// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_QuiltingSetProperties
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_QuiltingSetProperties : Form
{
  internal Label \u0002;
  internal Label \u0003;
  internal Panel \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal NumericUpDown \u0002;
  internal Panel \u0004;
  internal Label \u0006;
  internal Label \u0007;
  internal NumericUpDown \u0003;
  internal Panel \u0005;
  internal Label \u0008;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    string str = "spn_Click";
    try
    {
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_LaserMaterial) this).PropertiesForm.sClassName, str, ex.Message, "Exception");
      buException.throwException(ex, str, false, ((F_LaserMaterial) this).PropertiesForm.sClassName);
    }
  }

  internal void \u0001([In] object obj0, [In] TreeViewEventArgs obj1)
  {
    buTreeNode selectedNode = (buTreeNode) ((F_NestExecute) this).treeView_bend.SelectedNode;
    switch (selectedNode.Command)
    {
      case "bendbase":
        ((F_LaserMaterial) this).SelectedIndex = -1;
        ((F_LaserMaterial) this).DiskIndex = -1;
        ((F_Layer) this).DrawDiskBlock(((F_LaserMaterial) this).SelectedIndex, ((F_LaserMaterial) this).DiskIndex);
        break;
      case "benddisk":
        ((F_LaserMaterial) this).SelectedIndex = selectedNode.ClassSubIndex;
        ((F_LaserMaterial) this).DiskIndex = selectedNode.ClassSubSubIndex;
        ((F_Layer) this).ItemToControls(FoamCalcVars.DiskBlocks[((F_LaserMaterial) this).SelectedIndex]);
        ((F_Layer) this).DrawDiskBlock(((F_LaserMaterial) this).SelectedIndex, ((F_LaserMaterial) this).DiskIndex);
        break;
      case "disk":
        ((F_LaserMaterial) this).SelectedIndex = selectedNode.ClassSubIndex;
        ((F_LaserMaterial) this).DiskIndex = selectedNode.ClassSubSubIndex;
        ((F_Layer) this).ItemToControls(FoamCalcVars.DiskBlocks[((F_LaserMaterial) this).SelectedIndex]);
        ((F_Layer) this).DrawDiskBlock(((F_LaserMaterial) this).SelectedIndex, ((F_LaserMaterial) this).DiskIndex);
        break;
      case "block":
        ((F_LaserMaterial) this).SelectedIndex = selectedNode.ClassSubIndex;
        ((F_LaserMaterial) this).DiskIndex = selectedNode.ClassSubSubIndex;
        ((F_Layer) this).ItemToControls(FoamCalcVars.DiskBlocks[((F_LaserMaterial) this).SelectedIndex]);
        ((F_Layer) this).DrawDiskBlock(((F_LaserMaterial) this).SelectedIndex, ((F_LaserMaterial) this).DiskIndex);
        break;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LaserMaterial) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LaserMaterial) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_QuiltingSetProperties() => F_LaserMaterial.Captions = new List<string>();

  public F_QuiltingSetProperties()
  {
    ((F_NestSheetShapeAdd) this).PropertiesForm = new FormProperties();
    ((F_NestSheetShapeAdd) this).BendingList = new List<BendingLRAMaterialData>();
    ((F_NestSheetShapeAdd) this).strRemoveCaption = "Do You Want to Remove Item";
    ((F_NestSheetShapeAdd) this).pathLRA = Application.StartupPath;
    ((F_NestSheetShapeAdd) this).RowIndex = -1;
    ((F_NestSheetShapeAdd) this).ColIndex = -1;
    ((F_NestSheetShapeAdd) this).viewportPart = (Design) null;
    ((F_NestSheetShapeAdd) this).\u0001 = new Timer();
    ((F_NestSheetShapeAdd) this).Job = (PipeBendJob) null;
    ((F_NestSheetShapeAdd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_BendingLRAList) this);
    ((F_NestSheetShapeAdd) this).\u0001.Tick += new EventHandler(((F_QuiltingSettings) this).Tick_Timer);
    ((F_NestSheetShapeAdd) this).\u0001.Interval = 10;
  }

  public void Init()
  {
    ((F_NestSheetShapeAdd) this).PropertiesForm.Inited = false;
    if (((F_NestSheetShapeAdd) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestSheetShapeAdd) this).PropertiesForm.Height;
    if (((F_NestSheetShapeAdd) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestSheetShapeAdd) this).PropertiesForm.Width;
    this.TopMost = ((F_NestSheetShapeAdd) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestSheetShapeAdd) this).PropertiesForm.FormPosition;
    ((F_NestPartAdd) this).\u0005.Value = (Decimal) SewingSettings._pipeDiameter;
    ((F_NestSheetShapeAdd) this).\u0001.Columns.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 40;
    dataGridViewColumn1.HeaderText = "No";
    dataGridViewColumn1.Name = "No";
    dataGridViewColumn1.ReadOnly = true;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_NestSheetShapeAdd) this).\u0001.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = 200;
    dataGridViewColumn2.HeaderText = "Length";
    dataGridViewColumn2.Name = "Length";
    dataGridViewColumn2.ReadOnly = false;
    dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_NestSheetShapeAdd) this).\u0001.Columns.Add(dataGridViewColumn2);
    DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
    dataGridViewColumn3.Width = 140;
    dataGridViewColumn3.HeaderText = "Rotation";
    dataGridViewColumn3.Name = "Rotation";
    dataGridViewColumn3.ReadOnly = false;
    dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_NestSheetShapeAdd) this).\u0001.Columns.Add(dataGridViewColumn3);
    DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
    dataGridViewColumn4.Width = 100;
    dataGridViewColumn4.HeaderText = "Angle";
    dataGridViewColumn4.Name = "Angle";
    dataGridViewColumn4.ReadOnly = false;
    dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_NestSheetShapeAdd) this).\u0001.Columns.Add(dataGridViewColumn4);
    DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
    dataGridViewColumn5.Width = 100;
    dataGridViewColumn5.HeaderText = "Radius";
    dataGridViewColumn5.Name = "Radius";
    dataGridViewColumn5.ReadOnly = false;
    dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn5.ReadOnly = false;
    ((F_NestSheetShapeAdd) this).\u0001.Columns.Add(dataGridViewColumn5);
    dataGridViewColumn2.Width = ((F_NestSheetShapeAdd) this).\u0001.Width - dataGridViewColumn1.Width - dataGridViewColumn3.Width - dataGridViewColumn4.Width - dataGridViewColumn5.Width - 15;
    ((F_NestSheetShapeAdd) this).\u0001.RowHeadersVisible = false;
    ((F_NestSheetShapeAdd) this).\u0001.AllowUserToAddRows = false;
    ((F_NestSheetShapeAdd) this).\u0001.AllowUserToResizeColumns = false;
    ((F_NestSheetShapeAdd) this).\u0001.AllowUserToResizeRows = false;
    ((F_NestSheetShapeAdd) this).\u0001.Rows.Clear();
    for (int index = 0; index <= ((F_NestSheetShapeAdd) this).BendingList.Count - 1; ++index)
      ((F_NestSheetShapeAdd) this).\u0001.Rows.Add((object) (index + 1).ToString(), (object) ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[index]).Length, (object) ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[index]).Rotation, (object) ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[index]).Angle, (object) ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[index]).Radius);
    ((F_NestSheetShapeAdd) this).\u0001.Visible = false;
    if (((F_NestSheetShapeAdd) this).viewportPart == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = true;
      ((MaterialBase5) Properties).ShowCoordinateArrow = true;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_NestSheetShapeAdd) this).viewportPart);
      ((F_NestSheetShapeAdd) this).viewportPart.Dock = DockStyle.Fill;
      ((F_NestPartAdd) this).\u0002.Controls.Add((System.Windows.Forms.Control) ((F_NestSheetShapeAdd) this).viewportPart);
    }
    ((F_QuiltingSettings) this).ControlUpdate();
    this.LoadLanguage();
    ((F_NestSheetShapeAdd) this).\u0001.Visible = false;
    ((F_NestSheetShapeAdd) this).PropertiesForm.Result = DialogResult.None;
    ((F_NestSheetShapeAdd) this).PropertiesForm.Inited = true;
    if (((F_NestSheetShapeAdd) this).BendingList.Count <= 0)
      return;
    ((F_NestSheetShapeAdd) this).\u0001.Enabled = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_NestSheetShapeAdd.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestSheetShapeAdd) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestSheetShapeAdd) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestSheetShapeAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestSheetShapeAdd) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
