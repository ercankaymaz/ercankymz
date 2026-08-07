// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Materials.F_MaterialRect3D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.PanelCut;
using buEyeBaseVer5.Forms.Password;
using buEyeBaseVer5.Forms.Popup;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Materials;

public class F_MaterialRect3D : Form
{
  private string \u0001;
  private string \u0002;
  private Timer \u0001;
  private Timer \u0002;
  private Timer \u0003;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buTextBox textCtrl1;
  public static byte f0018CE;
  public FormProperties PropertiesForm;
  private Timer \u0001;
  private int \u0001;
  private int \u0002;
  private Design \u0001;
  public buNestingVar Settings;
  public string AddPartFromFileExtender;
  public string SaveFileExtender;

  public void Init()
  {
    ((F_OperationList) this).\u0001 = false;
    if (((F_OperationList) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_OperationList) this).\u0001);
      ((F_OperationList) this).\u0001.Dock = DockStyle.Fill;
      ((F_PasswordV1) this).\u000F.Controls.Add((System.Windows.Forms.Control) ((F_OperationList) this).\u0001);
    }
    ((F_PanelCutPartList) this).radio_rightholder.Enabled = ((F_OperationList) this).RightProfile;
    if (!((F_OperationList) this).RightProfile)
      ((F_OperationList) this).XDirRefType = LeftRightType.Left;
    ((F_PasswordV1) this).cmb_length.Items.Clear();
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 100);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 500);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 800);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 1000);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 1200);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 1500);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 2000);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 3000);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 4000);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 5000);
    ((F_PasswordV1) this).cmb_length.Items.Add((object) 6000);
    ((F_OperationList) this).\u0001.Items.Clear();
    ((F_OperationList) this).\u0001.Items.Add((object) "Rectangle");
    ((F_OperationList) this).\u0001.Items.Add((object) "Circle");
    ((F_OperationList) this).\u0001.SelectedIndex = 0;
    ((F_OperationList) this).\u0001 = true;
    ((F_PopupPreview) this).\u0001.Value = (Decimal) ((F_OperationList) this).ItemWidth;
    ((F_PopupPreview) this).\u0002.Value = (Decimal) ((F_OperationList) this).ItemHeight;
    ((F_PopupPreview) this).\u0003.Value = (Decimal) ((F_OperationList) this).ItemThickness;
    ((F_PanelCutPartList) this).\u000E.Value = (Decimal) ((F_OperationList) this).MaxClamper;
    ((F_OperationList) this).\u0001.SelectedIndex = 0;
    if (((F_OperationList) this).\u0001 == null)
    {
      ((F_OperationList) this).\u0001 = new Timer();
      ((F_OperationList) this).\u0001.Interval = 20;
      ((F_OperationList) this).\u0001.Tick += new EventHandler(this.Init_Tick);
    }
    ((F_OperationList) this).\u0001.Enabled = true;
  }

  public void Init_Tick(object sender, EventArgs e)
  {
    if (!((F_OperationList) this).\u0001.IsHandleCreated)
      return;
    this.UpdateByProfileType(0);
    ((F_OperationList) this).\u0001.Enabled = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_OperationList) this).\u0001 = false;
    this.UpdateByProfileType(((F_OperationList) this).\u0001.SelectedIndex);
    ((F_OperationList) this).\u0001 = true;
  }

  public void UpdateByProfileType(int Index)
  {
    ((F_PopupPreview) this).\u0001.Visible = false;
    ((F_PopupPreview) this).\u0002.Visible = false;
    ((F_PopupPreview) this).\u0003.Visible = false;
    ((F_PopupPreview) this).\u0004.Visible = false;
    ((F_PasswordV1) this).\u0008.Visible = false;
    ((F_PopupPreview) this).\u0007.Visible = false;
    ((F_PopupPreview) this).\u0006.Visible = false;
    ((F_PopupPreview) this).\u0005.Visible = false;
    if (Index == 0)
    {
      ((F_PopupPreview) this).\u0001.Visible = true;
      ((F_PopupPreview) this).\u0002.Visible = true;
      ((F_PopupPreview) this).\u0003.Visible = true;
      ((F_OperationList) this).\u0001.Text = "Width";
      ((F_PopupPreview) this).\u0002.Text = "Height";
      ((F_PopupPreview) this).\u0003.Text = "Thickness";
      ((F_PopupPreview) this).\u0001.Value = (Decimal) ((F_OperationList) this).ItemWidth;
      ((F_PopupPreview) this).\u0002.Value = (Decimal) ((F_OperationList) this).ItemHeight;
      ((F_PopupPreview) this).\u0003.Value = (Decimal) ((F_OperationList) this).ItemThickness;
      if (((F_OperationList) this).\u0001.IsHandleCreated)
      {
        ((F_OperationList) this).\u0001.Entities.Clear();
        ((F_OperationList) this).\u0001.Entities.Add((Entity) CompositeCurve.CreateRectangle(((F_OperationList) this).ItemWidth, ((F_OperationList) this).ItemHeight));
        if (((F_OperationList) this).ItemThickness > 0.0)
        {
          CompositeCurve rectangle = CompositeCurve.CreateRectangle(((F_OperationList) this).ItemWidth - ((F_OperationList) this).ItemThickness * 2.0, ((F_OperationList) this).ItemHeight - ((F_OperationList) this).ItemThickness * 2.0);
          rectangle.Translate(((F_OperationList) this).ItemThickness, ((F_OperationList) this).ItemThickness);
          ((F_OperationList) this).\u0001.Entities.Add((Entity) rectangle);
        }
        ((F_OperationList) this).\u0001.SetView(viewType.Top);
        ((F_OperationList) this).\u0001.ZoomFit();
        ((F_OperationList) this).\u0001.ZoomOut(10);
        ((F_OperationList) this).\u0001.Invalidate();
      }
      ((F_OperationList) this).SelectedType = ProfileNewType.Rectangle;
    }
    if (Index != 1)
      return;
    ((F_PopupPreview) this).\u0001.Visible = true;
    ((F_PopupPreview) this).\u0002.Visible = true;
    ((F_OperationList) this).\u0001.Text = "Diameter";
    ((F_PopupPreview) this).\u0002.Text = "Thickness";
    ((F_PopupPreview) this).\u0001.Value = (Decimal) ((F_OperationList) this).ItemDiameter;
    ((F_PopupPreview) this).\u0002.Value = (Decimal) ((F_OperationList) this).ItemThickness;
    if (((F_OperationList) this).\u0001.IsHandleCreated)
    {
      ((F_OperationList) this).\u0001.Entities.Clear();
      ((F_OperationList) this).\u0001.Entities.Add((Entity) new Circle(new Point3D(), ((F_OperationList) this).ItemWidth / 2.0));
      if (((F_OperationList) this).ItemThickness > 0.0)
        ((F_OperationList) this).\u0001.Entities.Add((Entity) new Circle(new Point3D(), ((F_OperationList) this).ItemWidth / 2.0 - ((F_OperationList) this).ItemThickness));
      ((F_OperationList) this).\u0001.SetView(viewType.Top);
      ((F_OperationList) this).\u0001.ZoomFit();
      ((F_OperationList) this).\u0001.ZoomOut(10);
      ((F_OperationList) this).\u0001.Invalidate();
    }
    ((F_OperationList) this).SelectedType = ProfileNewType.Circle;
  }

  public void UpdateData(int Index)
  {
    if (Index == 0)
    {
      ((F_OperationList) this).ItemWidth = (double) ((F_PopupPreview) this).\u0001.Value;
      ((F_OperationList) this).ItemHeight = (double) ((F_PopupPreview) this).\u0002.Value;
      ((F_OperationList) this).ItemThickness = (double) ((F_PopupPreview) this).\u0003.Value;
    }
    if (Index != 1)
      return;
    ((F_OperationList) this).ItemDiameter = (double) ((F_PopupPreview) this).\u0001.Value;
    ((F_OperationList) this).ItemThickness = (double) ((F_PopupPreview) this).\u0002.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_OperationList) this).\u0001.Name)
    {
      this.UpdateByProfileType(((F_OperationList) this).\u0001.SelectedIndex);
      ((F_OperationList) this).PreviewEnts.Clear();
      ((F_OperationList) this).PreviewEnts = new List<Entity>();
      buVector5.CopyEntities(((F_OperationList) this).\u0001.Entities, ref ((F_OperationList) this).PreviewEnts);
      ((F_OperationList) this).MaxClamper = (int) ((F_PanelCutPartList) this).\u000E.Value;
      ((F_OperationList) this).ItemLength = ((F_PasswordV1) this).cmb_length.Text;
      ((F_OperationList) this).ItemName = ((F_PasswordV1) this).txt_name.Text;
      ((F_OperationList) this).Result = DialogResult.OK;
      if (((F_OperationList) this).FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_OperationList) this).FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_OperationList) this).\u0002.Name))
      return;
    ((F_OperationList) this).Result = DialogResult.Cancel;
    if (((F_OperationList) this).FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_OperationList) this).FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_OperationList) this).Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_OperationList) this).Result = DialogResult.Cancel;
    if (((F_OperationList) this).FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_OperationList) this).FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_OperationList) this).\u0001)
      return;
    this.UpdateData(((F_OperationList) this).\u0001.SelectedIndex);
    this.UpdateByProfileType(((F_OperationList) this).\u0001.SelectedIndex);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_OperationList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_OperationList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m000DC9();

  public F_MaterialRect3D()
  {
    ((F_PanelCutPartList) this).FrmNewProfile = (F_NewProfile) null;
    ((F_PanelCutPartList) this).PropertiesForm = new FormProperties();
    ((F_PanelCutPartList) this).EntitiesTransformed = new List<buEntity>();
    ((F_PanelCutPartList) this).Layers = new List<LayerBase5>();
    ((F_PanelCutPartList) this).Materials = new List<MaterialSkin>();
    ((F_PanelCutPartList) this).MaterialIndex = 0;
    ((F_PanelCutPartList) this).RigthProfile = false;
    ((F_PanelCutPartList) this).BoxProfile = false;
    ((F_PanelCutPartList) this).Profile = (ProfileItem) new PanelCutRuntimeSettings();
    ((F_PanelCutPartList) this).ProfileSet = (ProfileSettings) new MarbleEntitiesSettings();
    ((F_PanelCutPartList) this).ProfileRunTimeSet = (ProfileRuntimeSettings) new MarbleScreenCaptureSettings();
    ((F_PanelCutPartList) this).strDelete = "Do You Want to Delete This File";
    ((F_PanelCutPartList) this).\u0001 = (Design) null;
    ((F_PanelCutPartList) this).\u0001 = new List<string>();
    ((F_PanelCutPartList) this).\u0001 = -1;
    ((F_PanelCutPartList) this).\u0002 = -1;
    ((F_PanelCutPartList) this).\u0001 = "";
    ((F_PanelCutPartList) this).\u0001 = new Point3D();
    ((F_PanelCutPartList) this).\u0002 = new Point3D();
    ((F_PanelCutPartList) this).\u0003 = new Point3D();
    ((F_PanelCutPartList) this).\u0002 = new List<string>();
    ((F_PanelCutPartList) this).\u0001 = (Timer) null;
    ((F_PanelCutPartList) this).\u0001 = (ProfileItem) null;
    ((F_PanelCutPartList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ProfileAdd) this);
  }
}
