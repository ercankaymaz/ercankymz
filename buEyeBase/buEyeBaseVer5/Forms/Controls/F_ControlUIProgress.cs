// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIProgress
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Diamaker;
using buEyeBaseVer5.Forms.Door;
using devDept.Eyeshot.Control;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIProgress : Form
{
  public ToolBase5 ToolNick;
  public bool isCircular;
  private IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal ImageList \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal ImageList \u0002;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal ImageList \u0003;
  public TabControl tabControl1;
  public NumericUpDown spn_basethickness;
  public NumericUpDown spn_baseHeight;

  public void Apply()
  {
    ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Width = (double) ((F_ControlUIGroup) this).\u0001.Value;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Height = (double) ((F_ControlUIGroup) this).\u0002.Value;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Depth = (double) ((F_ControlUIGroup) this).\u0003.Value;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).FrontAngle = (double) ((F_ControlUIGroup) this).\u0004.Value;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).BackAngle = (double) ((F_ControlUIGroup) this).\u0005.Value;
    ((F_ControlUIDataGridView) this).Case1.Width = (double) ((F_ControlUIRadio) this).\u0008.Value;
    ((F_ControlUIDataGridView) this).Case1.Height = (double) ((F_ControlUIRadio) this).\u0007.Value;
    ((F_ControlUIDataGridView) this).Case1.Depth = (double) ((F_ControlUIRadio) this).\u0006.Value;
    ((F_ControlUIDataGridView) this).Case2.Width = (double) ((F_ControlUIRadio) this).\u0010.Value;
    ((F_ControlUIDataGridView) this).Case2.Height = (double) ((F_ControlUIRadio) this).\u000F.Value;
    ((F_ControlUIDataGridView) this).Case2.Depth = (double) ((F_ControlUIRadio) this).\u000E.Value;
    if (((F_ControlUIGroup) this).\u0001.Checked)
      ((SortAskMe) ((F_ControlUIDataGridView) this).Material).Purpose = MaterialPurpose.Door;
    else
      ((SortAskMe) ((F_ControlUIDataGridView) this).Material).Purpose = MaterialPurpose.Case;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    if (!((F_ControlUIDataGridView) this).PropertiesForm.Inited)
      return;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Width = (double) ((F_ControlUIGroup) this).\u0001.Value;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Height = (double) ((F_ControlUIGroup) this).\u0002.Value;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).Size.Depth = (double) ((F_ControlUIGroup) this).\u0003.Value;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).FrontAngle = (double) ((F_ControlUIGroup) this).\u0004.Value;
    ((SortResult) ((F_ControlUIDataGridView) this).Material).BackAngle = (double) ((F_ControlUIGroup) this).\u0005.Value;
    \u0018.\u0002.\u0007.\u0001((F_DoorMat) this);
    ((F_ControlUIDataGridView) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUIDataGridView) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUIDataGridView) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUIProgress() => F_ControlUIDataGridView.Captions = new List<string>();

  public F_ControlUIProgress()
  {
    ((F_ControlUIRadio) this).PropertiesForm = new FormProperties();
    ((F_ControlUIRadio) this).viewport = (Design) null;
    ((F_ControlUIRadio) this).ToolGrinding = (ToolBase5) new ToolGeometry5();
    this.ToolNick = (ToolBase5) new ToolGeometry5();
    this.isCircular = false;
    this.\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_DiamakerGrindVShape) this);
    if (((F_ControlUIRadio) this).viewport != null)
      return;
    EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
    ((DiameterDepthPoint) Properties).ShowToolBar = false;
    ((DiameterDepthPoint) Properties).ShowViewCube = false;
    ((MaterialBase5) Properties).ShowCoordinateArrow = false;
    buConversion5.CreateControlsTool(true, Properties, ref ((F_ControlUIRadio) this).viewport);
    ((F_ControlUIRadio) this).viewport.Dock = DockStyle.Fill;
    if (((F_ControlUISpeeds) this).\u0003.Controls.Count != 0)
      return;
    ((F_ControlUISpeeds) this).\u0003.Controls.Add((System.Windows.Forms.Control) ((F_ControlUIRadio) this).viewport);
  }

  public void Init()
  {
    ((F_ControlUIRadio) this).PropertiesForm.Inited = false;
    this.tabControl1.SizeMode = TabSizeMode.Fixed;
    this.tabControl1.Appearance = TabAppearance.FlatButtons;
    this.tabControl1.ItemSize = new Size(0, 1);
    this.tabControl1.Top = 5;
    ((F_ControlUIText) this).spn_toolpersentage.Value = (Decimal) ((WoodJob) PipeBendTempVars.varGrindingShape).ToolPersentage;
    ((F_ControlUIText) this).spn_grindinglength.Value = (Decimal) ((WoodJob) PipeBendTempVars.varGrindingShape).GrindingLength;
    ((F_ControlUITrack) this).spn_feedcount.Value = (Decimal) ((WoodJob) PipeBendTempVars.varGrindingShape).FeedCount;
    ((F_ControlUISpeeds) this).spn_feeddistance.Value = (Decimal) ((WoodJob) PipeBendTempVars.varGrindingShape).FeedDistance;
    this.spn_baseHeight.Value = (Decimal) ((PipeBendMoveCommand) PipeBendTempVars.varGrindingShape).BaseMaterialHeight;
    ((F_ControlUISpeeds) this).spn_targetHeight.Value = (Decimal) ((PipeBendMoveCommand) PipeBendTempVars.varGrindingShape).TargetMaterialHeight;
    this.spn_basethickness.Value = (Decimal) ((buWood) PipeBendTempVars.varGrindingShape).MaterialThickness;
    ((F_ControlUICombo) this).spn_targetangle.Value = (Decimal) ((buWood) PipeBendTempVars.varGrindingShape).VShapeTargetAngle;
    ((F_ControlUISpeeds) this).spn_height_finishdepth.Value = (Decimal) ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightFinishDepth;
    ((F_ControlUISpeeds) this).spn_height_finishspindlespeed.Value = (Decimal) ((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightFinishSpindleSpeed;
    ((F_ControlUISpeeds) this).spn_height_finishvel.Value = (Decimal) ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightFinishVel;
    ((F_ControlUISpeeds) this).spn_height_roughspindlespeed.Value = (Decimal) ((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightRoughSpindleSpeed;
    ((F_ControlUISpeeds) this).spn_height_roughtdepth.Value = (Decimal) ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightRoughDepth;
    ((F_ControlUISpeeds) this).spn_height_roughtvel.Value = (Decimal) ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightRoughVel;
    ((F_ControlUISpeeds) this).spn_height_width.Value = (Decimal) ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightWidth;
    ((F_ControlUICombo) this).spn_angle_finishdepth.Value = (Decimal) ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleFinishDepth;
    ((F_ControlUICombo) this).spn_angle_finishspindlespeed.Value = (Decimal) ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleFinishSpindleSpeed;
    ((F_ControlUICombo) this).spn_angle_finishvel.Value = (Decimal) ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleFinishVel;
    ((F_ControlUICombo) this).spn_angle_roughdepth.Value = (Decimal) ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleRoughDepth;
    ((F_ControlUICombo) this).spn_angle_roughspindlespeed.Value = (Decimal) ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleRoughSpindleSpeed;
    ((F_ControlUICombo) this).spn_angle_roughtvel.Value = (Decimal) ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleRoughVel;
    ((F_ControlUICombo) this).spn_angle_width.Value = (Decimal) ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleWidth;
    ((F_ControlUIText) this).spn_angle_finishoperationcount.Value = (Decimal) ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleFinishCount;
    ((F_ControlUIText) this).\u0002.Checked = ((WoodSettings) PipeBendTempVars.varGrindingShape).VShapeAngleEnable;
    ((F_ControlUITrack) this).spn_nick_finishdepth.Value = (Decimal) ((WoodSettings) PipeBendTempVars.varGrindingShape).NickFinishDepth;
    ((F_ControlUITrack) this).spn_nick_finishspindlespeed.Value = (Decimal) ((WoodSettings) PipeBendTempVars.varGrindingShape).NickFinishSpindleSpeed;
    ((F_ControlUITrack) this).spn_nick_finishvel.Value = (Decimal) ((WoodSettings) PipeBendTempVars.varGrindingShape).NickFinishVel;
    ((F_ControlUITrack) this).spn_nick_roughspindlespeed.Value = (Decimal) ((WoodSettings) PipeBendTempVars.varGrindingShape).NickRoughSpindleSpeed;
    ((F_ControlUITrack) this).spn_nick_depth.Value = (Decimal) ((WoodJob) PipeBendTempVars.varGrindingShape).NickDepth;
    ((F_ControlUITrack) this).spn_nick_roughtvel.Value = (Decimal) ((WoodSettings) PipeBendTempVars.varGrindingShape).NickRoughVel;
    ((F_ControlUITrack) this).spn_nick_width.Value = (Decimal) ((WoodJob) PipeBendTempVars.varGrindingShape).NickWidth;
    ((F_ControlUISpeeds) this).\u0001.Checked = ((WoodSettings) PipeBendTempVars.varGrindingShape).NickEnable;
    ((F_ControlUIText) this).\u0003.Checked = ((WoodSettings) PipeBendTempVars.varGrindingShape).NickReverseDir;
    if (((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightToolNo == 1)
      ((F_ControlUISpeeds) this).\u0006.Checked = true;
    else if (((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightToolNo == 2)
      ((F_ControlUISpeeds) this).\u0005.Checked = true;
    else
      ((F_ControlUISpeeds) this).\u0004.Checked = true;
    if (((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleToolNo == 1)
      ((F_ControlUICombo) this).\u0003.Checked = true;
    else if (((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleToolNo == 2)
      ((F_ControlUICombo) this).\u0002.Checked = true;
    else
      ((F_ControlUICombo) this).\u0001.Checked = true;
    if (((WoodSettings) PipeBendTempVars.varGrindingShape).NickToolNo == 1)
      ((F_ControlUITrack) this).\u000E.Checked = true;
    else if (((WoodSettings) PipeBendTempVars.varGrindingShape).NickToolNo == 2)
      ((F_ControlUITrack) this).\u0008.Checked = true;
    else
      ((F_ControlUISpeeds) this).\u0007.Checked = true;
    ((F_ControlUIRadio) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Apply()
  {
    ((WoodJob) PipeBendTempVars.varGrindingShape).ToolPersentage = (double) ((F_ControlUIText) this).spn_toolpersentage.Value;
    ((WoodJob) PipeBendTempVars.varGrindingShape).GrindingLength = (double) ((F_ControlUIText) this).spn_grindinglength.Value;
    ((WoodJob) PipeBendTempVars.varGrindingShape).FeedCount = (int) ((F_ControlUITrack) this).spn_feedcount.Value;
    ((WoodJob) PipeBendTempVars.varGrindingShape).FeedDistance = (double) ((F_ControlUISpeeds) this).spn_feeddistance.Value;
    ((PipeBendMoveCommand) PipeBendTempVars.varGrindingShape).BaseMaterialHeight = (double) this.spn_baseHeight.Value;
    ((PipeBendMoveCommand) PipeBendTempVars.varGrindingShape).TargetMaterialHeight = (double) ((F_ControlUISpeeds) this).spn_targetHeight.Value;
    ((buWood) PipeBendTempVars.varGrindingShape).MaterialThickness = (double) this.spn_basethickness.Value;
    ((buWood) PipeBendTempVars.varGrindingShape).VShapeTargetAngle = (double) ((F_ControlUICombo) this).spn_targetangle.Value;
    ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightFinishDepth = (double) ((F_ControlUISpeeds) this).spn_height_finishdepth.Value;
    ((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightFinishSpindleSpeed = (double) ((F_ControlUISpeeds) this).spn_height_finishspindlespeed.Value;
    ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightFinishVel = (double) ((F_ControlUISpeeds) this).spn_height_finishvel.Value;
    ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightRoughDepth = (double) ((F_ControlUISpeeds) this).spn_height_roughtdepth.Value;
    ((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightRoughSpindleSpeed = (double) ((F_ControlUISpeeds) this).spn_height_roughspindlespeed.Value;
    ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightRoughVel = (double) ((F_ControlUISpeeds) this).spn_height_roughtvel.Value;
    ((buWood) PipeBendTempVars.varGrindingShape).VShapeHeightWidth = (double) ((F_ControlUISpeeds) this).spn_height_width.Value;
    ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleFinishDepth = (double) ((F_ControlUICombo) this).spn_angle_finishdepth.Value;
    ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleFinishSpindleSpeed = (double) ((F_ControlUICombo) this).spn_angle_finishspindlespeed.Value;
    ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleFinishVel = (double) ((F_ControlUICombo) this).spn_angle_finishvel.Value;
    ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleRoughDepth = (double) ((F_ControlUICombo) this).spn_angle_roughdepth.Value;
    ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleRoughSpindleSpeed = (double) ((F_ControlUICombo) this).spn_angle_roughspindlespeed.Value;
    ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleRoughVel = (double) ((F_ControlUICombo) this).spn_angle_roughtvel.Value;
    ((WoodRuntimeSettings) PipeBendTempVars.varGrindingShape).VShapeAngleWidth = (double) ((F_ControlUICombo) this).spn_angle_width.Value;
    ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleFinishCount = (int) ((F_ControlUIText) this).spn_angle_finishoperationcount.Value;
    ((WoodSettings) PipeBendTempVars.varGrindingShape).VShapeAngleEnable = ((F_ControlUIText) this).\u0002.Checked;
    ((WoodSettings) PipeBendTempVars.varGrindingShape).NickFinishDepth = (double) ((F_ControlUITrack) this).spn_nick_finishdepth.Value;
    ((WoodSettings) PipeBendTempVars.varGrindingShape).NickFinishSpindleSpeed = (double) ((F_ControlUITrack) this).spn_nick_finishspindlespeed.Value;
    ((WoodSettings) PipeBendTempVars.varGrindingShape).NickFinishVel = (double) ((F_ControlUITrack) this).spn_nick_finishvel.Value;
    ((WoodSettings) PipeBendTempVars.varGrindingShape).NickRoughSpindleSpeed = (double) ((F_ControlUITrack) this).spn_nick_roughspindlespeed.Value;
    ((WoodJob) PipeBendTempVars.varGrindingShape).NickDepth = (double) ((F_ControlUITrack) this).spn_nick_depth.Value;
    ((WoodSettings) PipeBendTempVars.varGrindingShape).NickRoughVel = (double) ((F_ControlUITrack) this).spn_nick_roughtvel.Value;
    ((WoodJob) PipeBendTempVars.varGrindingShape).NickWidth = (double) ((F_ControlUITrack) this).spn_nick_width.Value;
    ((WoodSettings) PipeBendTempVars.varGrindingShape).NickEnable = ((F_ControlUISpeeds) this).\u0001.Checked;
    ((WoodSettings) PipeBendTempVars.varGrindingShape).NickReverseDir = ((F_ControlUIText) this).\u0003.Checked;
    if (((F_ControlUISpeeds) this).\u0006.Checked)
      ((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightToolNo = 1;
    else if (((F_ControlUISpeeds) this).\u0005.Checked)
      ((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightToolNo = 2;
    else
      ((WoodJob) PipeBendTempVars.varGrindingShape).VShapeHeightToolNo = 3;
    if (((F_ControlUICombo) this).\u0003.Checked)
      ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleToolNo = 1;
    else if (((F_ControlUICombo) this).\u0002.Checked)
      ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleToolNo = 2;
    else
      ((WoodTempVars) PipeBendTempVars.varGrindingShape).VShapeAngleToolNo = 3;
    if (((F_ControlUITrack) this).\u000E.Checked)
      ((WoodSettings) PipeBendTempVars.varGrindingShape).NickToolNo = 1;
    else if (((F_ControlUITrack) this).\u0008.Checked)
      ((WoodSettings) PipeBendTempVars.varGrindingShape).NickToolNo = 2;
    else
      ((WoodSettings) PipeBendTempVars.varGrindingShape).NickToolNo = 3;
    if (((F_ControlUIText) this).radiolineartype.Checked)
    {
      this.isCircular = false;
    }
    else
    {
      if (!((F_ControlUIText) this).radio_circulartype.Checked)
        return;
      this.isCircular = true;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_ControlUISpeeds) this).\u0003.Name)
    {
      this.Apply();
      \u0007.\u0001.\u0001((F_DiamakerGrindVShape) this);
    }
    if (control2.Name == this.\u0002.Name)
    {
      ((F_ControlUIRadio) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_ControlUIRadio) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ControlUIRadio) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.\u0001.Name))
      return;
    this.Apply();
    ((F_ControlUIRadio) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_ControlUIRadio) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIRadio) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUIRadio) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUIRadio) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ControlUIRadio) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUIRadio) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ControlUIRadio) this).PropertiesForm.Inited)
      ;
  }
}
