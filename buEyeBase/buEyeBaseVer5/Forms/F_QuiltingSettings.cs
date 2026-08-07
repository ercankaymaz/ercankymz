// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_QuiltingSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_QuiltingSettings : Form
{
  internal NumericUpDown \u0004;
  internal Panel \u0006;
  internal Label \u000E;
  internal TextBox \u0002;
  internal Label \u000F;
  internal Label \u0010;
  internal Label \u0011;
  internal Label \u0012;
  internal Label \u0013;
  internal Label \u0014;
  public static byte f000F7C;
  public FormProperties PropertiesForm;
  internal Timer \u0001;
  private int \u0001;
  public int SelectedRowPart;
  public int SelectedColPart;
  public int PartPreSelectedRow;
  private Design \u0001;
  public buNestingVar Settings;
  public string AddPartFromFileExtender;
  public string AddSheetFromFileExtender;
  public string SaveFileExtender;
  public bool AddPartFromFileExtenderAsCsvType;
  public bool SendToCad;
  public bool DrawPart;
  public bool ShiftPressed;

  public void Tick_Timer(object sender, EventArgs e)
  {
    if (!((F_NestSheetShapeAdd) this).viewportPart.IsHandleCreated)
      return;
    ((F_NestSheetShapeAdd) this).\u0001.Enabled = false;
    this.\u0001((object) ((F_NestPartAdd) this).btn_sim, e);
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_NestSheetShapeAdd) this).btn_ok.Name)
    {
      ((F_NestSheetShapeAdd) this).PropertiesForm.Result = DialogResult.OK;
      ((FoamEditorSettings) ((F_NestSheetShapeAdd) this).Job).PipeDiameter = (double) ((F_NestPartAdd) this).\u0005.Value;
      if (((F_NestSheetShapeAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestSheetShapeAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_NestSheetShapeAdd) this).btn_cancel.Name)
    {
      ((F_NestSheetShapeAdd) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_NestSheetShapeAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestSheetShapeAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_NestSheetShapeAdd) this).btn_add.Name)
    {
      BendingLRAMaterialData bendingLraMaterialData = (BendingLRAMaterialData) new buDrillCalc();
      ((F_NestSheetShapeAdd) this).BendingList.Add(bendingLraMaterialData);
      ((F_NestSheetShapeAdd) this).\u0001.Rows.Add((object) ((F_NestSheetShapeAdd) this).BendingList.Count.ToString(), (object) ((FoamWaveShapeArgs) bendingLraMaterialData).Length, (object) ((FoamWaveShapeArgs) bendingLraMaterialData).Rotation, (object) ((FoamWaveShapeArgs) bendingLraMaterialData).Angle, (object) ((FoamWaveShapeArgs) bendingLraMaterialData).Radius);
      this.\u0001((object) ((F_NestPartAdd) this).btn_sim, (EventArgs) null);
    }
    if (control2.Name == ((F_NestSheetShapeAdd) this).btn_adddata.Name)
      ;
    if (control2.Name == ((F_NestSheetShapeAdd) this).btn_canceldata.Name)
      ((F_NestSheetShapeAdd) this).\u0001.Visible = false;
    if (control2.Name == ((F_NestSheetShapeAdd) this).btn_remove.Name && ((F_NestSheetShapeAdd) this).RowIndex >= 0 & ((F_NestSheetShapeAdd) this).RowIndex <= ((F_NestSheetShapeAdd) this).BendingList.Count - 1 && buString.MessageBoxQuestion(((F_NestSheetShapeAdd) this).strRemoveCaption) == DialogResult.Yes)
    {
      ((F_NestSheetShapeAdd) this).BendingList.RemoveAt(((F_NestSheetShapeAdd) this).RowIndex);
      ((F_NestSheetShapeAdd) this).\u0001.Rows.RemoveAt(((F_NestSheetShapeAdd) this).RowIndex);
    }
    if (control2.Name == ((F_NestPartAdd) this).btn_clear.Name && buString.MessageBoxQuestion(((F_NestSheetShapeAdd) this).strRemoveCaption) == DialogResult.Yes)
    {
      ((F_NestSheetShapeAdd) this).BendingList.Clear();
      ((F_NestSheetShapeAdd) this).\u0001.Rows.Clear();
      ((F_NestSheetShapeAdd) this).viewportPart.Entities.Clear();
      ((F_NestSheetShapeAdd) this).viewportPart.Invalidate();
    }
    if (control2.Name == ((F_NestPartAdd) this).btn_sim.Name)
    {
      SewingSettings._pipeDiameter = (double) ((F_NestPartAdd) this).\u0005.Value;
      if (SewingSettings._pipeDiameter <= 0.0)
        SewingSettings._pipeDiameter = 10.0;
      SewingTempVars._c1 = new Circle(Plane.YZ, SewingSettings._pipeDiameter);
      SewingTempVars._c1.Reverse();
      SewingSettings._pipeColor = Color.Gray;
      SewingSettings._pipeTotalLength = ((QuiltingRuntimeSettings) buCall.\u0001).GetPipeLength(((F_NestSheetShapeAdd) this).BendingList);
      SewingSettings._excecutionPipe += (double) SewingPickType.PipeExecStep;
      SewingSettings._excecutionPipe = SewingSettings._pipeTotalLength;
      ((F_NestSheetShapeAdd) this).BendingList.Clear();
      for (int index = 0; index <= ((F_NestSheetShapeAdd) this).\u0001.Rows.Count - 1; ++index)
      {
        BendingLRAMaterialData bendingLraMaterialData = (BendingLRAMaterialData) new buDrillCalc();
        ((FoamWaveShapeArgs) bendingLraMaterialData).Length = double.Parse(Convert.ToString(((F_NestSheetShapeAdd) this).\u0001.Rows[index].Cells[1].Value));
        ((FoamWaveShapeArgs) bendingLraMaterialData).Rotation = double.Parse(Convert.ToString(((F_NestSheetShapeAdd) this).\u0001.Rows[index].Cells[2].Value));
        ((FoamWaveShapeArgs) bendingLraMaterialData).Angle = double.Parse(Convert.ToString(((F_NestSheetShapeAdd) this).\u0001.Rows[index].Cells[3].Value));
        ((FoamWaveShapeArgs) bendingLraMaterialData).Radius = double.Parse(Convert.ToString(((F_NestSheetShapeAdd) this).\u0001.Rows[index].Cells[4].Value));
        ((F_NestSheetShapeAdd) this).BendingList.Add(bendingLraMaterialData);
      }
      ((F_NestSheetShapeAdd) this).viewportPart = ((buDrillCalc) buCall.\u0001).PipeProgressAll(((F_NestSheetShapeAdd) this).viewportPart, ((F_NestSheetShapeAdd) this).BendingList);
      if (((F_NestSheetShapeAdd) this).viewportPart.Entities.Count > 0)
      {
        ((F_NestSheetShapeAdd) this).viewportPart.Entities[((F_NestSheetShapeAdd) this).viewportPart.Entities.Count - 1].Color = Color.Green;
        ((F_NestSheetShapeAdd) this).viewportPart.Entities[((F_NestSheetShapeAdd) this).viewportPart.Entities.Count - 1].ColorMethod = colorMethodType.byLayer;
        ((F_NestSheetShapeAdd) this).viewportPart.Invalidate();
      }
      if (((F_NestSheetShapeAdd) this).Job != null)
      {
        for (int index = 0; index <= ((FoamTempVars) ((F_NestSheetShapeAdd) this).Job).AuxEntityList.Count - 1; ++index)
          ((F_NestSheetShapeAdd) this).viewportPart.Entities.Add(((FoamTempVars) ((F_NestSheetShapeAdd) this).Job).AuxEntityList[index]);
        ((F_NestSheetShapeAdd) this).viewportPart.Invalidate();
      }
    }
    if (control2.Name == ((F_NestPartAdd) this).btn_save.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = ((F_NestSheetShapeAdd) this).pathLRA;
      saveFileDialog.Filter = "LRA Bending File (*.bulra)|*.bulra";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        buVector5.SaveLRAFile(saveFileDialog.FileName, ((F_NestSheetShapeAdd) this).BendingList);
        ((F_NestSheetShapeAdd) this).pathLRA = buFile.GetPath(saveFileDialog.FileName);
      }
    }
    if (!(control2.Name == ((F_NestPartAdd) this).btn_open.Name))
      return;
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = ((F_NestSheetShapeAdd) this).pathLRA;
    openFileDialog.Filter = "LRA Bending File (*.bulra)|*.bulra";
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    ((F_NestSheetShapeAdd) this).BendingList.Clear();
    buVector5.OpenLRAFile(openFileDialog.FileName, ref ((F_NestSheetShapeAdd) this).BendingList);
    ((F_NestSheetShapeAdd) this).\u0001.Rows.Clear();
    for (int index = 0; index <= ((F_NestSheetShapeAdd) this).BendingList.Count - 1; ++index)
      ((F_NestSheetShapeAdd) this).\u0001.Rows.Add((object) (index + 1).ToString(), (object) ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[index]).Length, (object) ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[index]).Rotation, (object) ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[index]).Angle, (object) ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[index]).Radius);
    ((F_NestSheetShapeAdd) this).pathLRA = buFile.GetPath(openFileDialog.FileName);
    this.\u0001((object) ((F_NestPartAdd) this).btn_sim, obj1);
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_NestSheetShapeAdd) this).PropertiesForm.Inited || obj1.RowIndex < 0)
      return;
    if (obj1.ColumnIndex == 1)
      ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[((F_NestSheetShapeAdd) this).RowIndex]).Length = Convert.ToDouble(((F_NestSheetShapeAdd) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (obj1.ColumnIndex == 2)
      ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[((F_NestSheetShapeAdd) this).RowIndex]).Rotation = Convert.ToDouble(((F_NestSheetShapeAdd) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (obj1.ColumnIndex == 3)
      ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[((F_NestSheetShapeAdd) this).RowIndex]).Angle = Convert.ToDouble(((F_NestSheetShapeAdd) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (obj1.ColumnIndex == 4)
      ((FoamWaveShapeArgs) ((F_NestSheetShapeAdd) this).BendingList[((F_NestSheetShapeAdd) this).RowIndex]).Radius = Convert.ToDouble(((F_NestSheetShapeAdd) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    this.\u0001((object) ((F_NestPartAdd) this).btn_sim, (EventArgs) null);
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_NestSheetShapeAdd) this).RowIndex = obj1.RowIndex;
    ((F_NestSheetShapeAdd) this).ColIndex = obj1.ColumnIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestSheetShapeAdd) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestSheetShapeAdd) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_QuiltingSettings() => F_NestSheetShapeAdd.Captions = new List<string>();

  public F_QuiltingSettings()
  {
    ((F_NestPartAdd) this).PropertiesForm = new FormProperties();
    ((F_NestPartAdd) this).MaterialOrders = new List<LaserMaterialData>();
    ((F_NestPartAdd) this).pathCf2File = Application.StartupPath;
    ((F_NestPartAdd) this).fileCf2SettingsName = "";
    ((F_NestPartAdd) this).strRemoveCaption = "Do You Want to Remove Item";
    ((F_NestPartAdd) this).SelectedMaterialIndex = -1;
    ((F_NestPartAdd) this).DirType = 0;
    ((F_NestPartAdd) this).\u0001 = false;
    ((F_NestPartAdd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0003.\u0002.\u0001((F_LaserStartOrder) this);
  }

  public void Init()
  {
    ((F_NestPartAdd) this).PropertiesForm.Inited = false;
    if (((F_NestPartAdd) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestPartAdd) this).PropertiesForm.Height;
    if (((F_NestPartAdd) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestPartAdd) this).PropertiesForm.Width;
    this.TopMost = ((F_NestPartAdd) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestPartAdd) this).PropertiesForm.FormPosition;
    \u0007.\u0001.\u0001((F_LaserStartOrder) this);
    \u0007.\u0001.\u0001((F_LaserStartOrder) this);
    ((F_NestPartAdd) this).PropertiesForm.Inited = true;
  }
}
