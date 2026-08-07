// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.MortiseTenon.F_SlotNoDepth
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Material;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.MortiseTenon;

public class F_SlotNoDepth : Form
{
  public Label lbl_palnedegree;
  internal Label \u000F;
  public Label lbl_camcenter;
  public NumericUpDown spn_manuelzstart;
  internal PictureBox \u0002;
  public CheckBox chk_locked;
  public CheckBox chk_manuelmode;
  public Label lbl_Editing;
  public DataGridView dgv_list;
  public static byte f0018A6;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buButton btn_popupviewleft;
  public buButton btn_popupviewfront;
  public buButton btn_popupzoomfit;
  public buButton btn_popupviewiso;
  public buButton btn_popupviewtop;
  public buButton btn_popupviewrotate;
  public buButton btn_popupviewpan;
  public buButton btn_popupzoomout;
  public buButton btn_popupzoomin;
  public Panel pnl_viewport;
  public buGround ground_base;
  public buButton btn_close;
  public buButton btn_popupviewback;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (control.Name == ((F_ProfileAdd) this).\u0001.Name)
    {
      ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_ProfileAdd) this).\u0006.Name)
    {
      ((ProfileOperationDataHole) buCall.\u0001).CreatePlane(ProfilePlaneDef.Top0, 0, true, ((F_ProfileAdd) this).pntMinProfile, ((F_ProfileAdd) this).pntMaxProfile, ((F_ProfileAdd) this).PlaneThinkness, ((F_ProfileAdd) this).VarUcs, ref ((F_ProfileAdd) this).Plane);
      ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_ProfileAdd) this).\u0005.Name)
    {
      hmiUISettings hmiUiSettings = new hmiUISettings();
      ((ProfileOperationDataHole) buCall.\u0001).CreatePlane(ProfilePlaneDef.Back45, 0, true, ((F_ProfileAdd) this).pntMinProfile, ((F_ProfileAdd) this).pntMaxProfile, ((F_ProfileAdd) this).PlaneThinkness, ((F_ProfileAdd) this).VarUcs, ref ((F_ProfileAdd) this).Plane);
      ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_ProfileAdd) this).\u0004.Name)
    {
      ((ProfileOperationDataHole) buCall.\u0001).CreatePlane(ProfilePlaneDef.Back90, 0, true, ((F_ProfileAdd) this).pntMinProfile, ((F_ProfileAdd) this).pntMaxProfile, ((F_ProfileAdd) this).PlaneThinkness, ((F_ProfileAdd) this).VarUcs, ref ((F_ProfileAdd) this).Plane);
      ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_ProfileAdd) this).\u0003.Name)
    {
      ((ProfileOperationDataHole) buCall.\u0001).CreatePlane(ProfilePlaneDef.Front45, 0, true, ((F_ProfileAdd) this).pntMinProfile, ((F_ProfileAdd) this).pntMaxProfile, ((F_ProfileAdd) this).PlaneThinkness, ((F_ProfileAdd) this).VarUcs, ref ((F_ProfileAdd) this).Plane);
      ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_ProfileAdd) this).\u0002.Name))
      return;
    ((ProfileOperationDataHole) buCall.\u0001).CreatePlane(ProfilePlaneDef.Front90, 0, true, ((F_ProfileAdd) this).pntMinProfile, ((F_ProfileAdd) this).pntMaxProfile, ((F_ProfileAdd) this).PlaneThinkness, ((F_ProfileAdd) this).VarUcs, ref ((F_ProfileAdd) this).Plane);
    ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ProfileAdd) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfileAdd) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfileAdd) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfileAdd) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_SlotNoDepth()
  {
    ((F_ProfileAdd) this).PropertiesForm = new FormProperties();
    ((F_ProfileAdd) this).PreviewEnts = new List<Entity>();
    ((F_ProfileAdd) this).Planes = new List<SelectedPlaneInfo>();
    ((F_ProfileAdd) this).UcsData = (UCSObjectData) new buMatrix5();
    ((F_ProfileAdd) this).PlaneThickess = 4.0;
    ((F_ProfileAdd) this).SelectedPlane = -1;
    ((F_OperationList) this).Increment = 1.0;
    ((F_OperationList) this).pathString = Application.StartupPath;
    ((F_OperationList) this).\u0001 = (Design) null;
    ((F_OperationList) this).\u0001 = new Timer();
    ((F_OperationList) this).\u0001 = new Point3D();
    ((F_OperationList) this).\u0002 = new Point3D();
    ((F_OperationList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SelectedPlanes) this);
  }

  public void Init()
  {
    ((F_ProfileAdd) this).PropertiesForm.Inited = false;
    if (((F_ProfileAdd) this).PropertiesForm.Height > 10)
      this.Height = ((F_ProfileAdd) this).PropertiesForm.Height;
    if (((F_ProfileAdd) this).PropertiesForm.Width > 10)
      this.Width = ((F_ProfileAdd) this).PropertiesForm.Width;
    this.TopMost = ((F_ProfileAdd) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ProfileAdd) this).PropertiesForm.FormPosition;
    if (((F_OperationList) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = true;
      ((MaterialBase5) Properties).ShowOrigin = false;
      ((MaterialBase5) Properties).ShowOriginCaption = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_OperationList) this).\u0001);
      ((F_OperationList) this).\u0001.Dock = DockStyle.Fill;
      ((F_OperationList) this).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_OperationList) this).\u0001);
    }
    ((F_OperationList) this).\u0001.Tick += new EventHandler(((F_MaterialsList) this).\u0002);
    ((F_OperationList) this).\u0001.Interval = 100;
    ((F_OperationList) this).\u0001.Enabled = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SelectedPlanes) this);
    \u0007.\u0001.\u0001((F_SelectedPlanes) this);
    ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.None;
    ((F_ProfileAdd) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }
}
