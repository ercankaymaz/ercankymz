// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUISpin
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.ClassForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUISpin : Form
{
  public double Depth;
  public double Radius;
  public double XPos;
  public double YPos;
  public double SafeDis;
  public double RapidDis;
  public double PlungeFeed;
  public double CuttingFeed;
  public CamClosedContourType CamType;
  public int ToolNo;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ControlUISettings) this).\u0001.Name)
    {
      ((F_ControlUISettings) this).lbl_val.Display = ((F_ControlUISettings) this).\u0001.Display;
      ((F_ColorDrawType) this).lbl_title.Display.Fonts.ForeColor = ((F_ControlUISettings) this).\u0001.Display.TitleForeColor;
    }
    if (control.Name == ((F_ColorDrawType) this).\u0002.Name)
      ((F_ColorDrawType) this).lbl_caption.Display = ((F_ColorDrawType) this).\u0002.Display;
    ((F_ControlUISettings) this).lbl_val.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    if (!((obj0 as Control).Name == ((F_ControlUISettings) this).spn_geometryrad.Name))
      return;
    ((F_ControlUISettings) this).lbl_val.Geometry.ArcDiameter = (int) ((F_ControlUISettings) this).spn_geometryrad.Value;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ControlUISettings) this).Settings).Parameters).GeometryArcDiameer = (int) ((F_ControlUISettings) this).spn_geometryrad.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ControlUISettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_ControlUISettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_ControlUISettings) this).lbl_val.Geometry.ShapeMode = result;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ControlUISettings) this).Settings).Parameters).GeometryType = result;
    }
    if (!(control.Name == ((F_ControlUISettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_ControlUISettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_ControlUISettings) this).lbl_val.ImageAlign = result1;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ControlUISettings) this).Settings).Parameters).ImageAlignment = result1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUISettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUISettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUISpin() => F_ControlUISettings.Captions = new List<string>();

  public F_ControlUISpin()
  {
    ((F_ColorDrawType) this).PropertiesForm = new FormProperties();
    ((F_ColorDrawType) this).Settings = (hmiUISettings) new buEyeShotFunctions();
    ((F_ColorDrawType) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUIGround) this);
  }

  public void Init()
  {
    ((F_ColorDrawType) this).PropertiesForm.Inited = false;
    if (((F_ColorDrawType) this).PropertiesForm.Height > 10)
      this.Height = ((F_ColorDrawType) this).PropertiesForm.Height;
    if (((F_ColorDrawType) this).PropertiesForm.Width > 10)
      this.Width = ((F_ColorDrawType) this).PropertiesForm.Width;
    this.TopMost = ((F_ColorDrawType) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ColorDrawType) this).PropertiesForm.FormPosition;
    ((F_ColorType) this).\u0001.Items.Clear();
    ((F_ColorType) this).\u0001.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
    ((F_ColorType) this).\u0002.Items.Clear();
    ((F_ColorType) this).\u0002.Items.AddRange(Enum.GetValues(typeof (ShapeType)).Cast<object>().ToArray<object>());
    ((F_ColorType) this).\u0001.Display = ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Caption;
    ((F_CamFrontBackAll) this).\u0003.Display = ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Shape;
    ((F_ColorType) this).\u0002.Display = ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Display;
    ((F_ColorType) this).spn_geometryrad.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).GeometryArcDiameer;
    ((F_ColorType) this).\u0002.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).GeometryType;
    ((F_ColorType) this).\u0001.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).ImageAlignment;
    ((F_ColorType) this).spn_headerheight.Value = (double) ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).TopHeight;
    ((F_CamFrontBackAll) this).spn_bottomheight.Value = (double) ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).BottomHeight;
    ((F_CamFrontBackAll) this).Ground_Ref.Ground.TopHeight = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).TopHeight;
    ((F_CamFrontBackAll) this).Ground_Ref.Ground.BottomHeight = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).BottomHeight;
    ((F_CamFrontBackAll) this).Ground_Ref.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamFrontBackAll) this).Ground_Ref.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).GeometryType;
    ((F_CamFrontBackAll) this).Ground_Ref.ImageAlign = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).ImageAlignment;
    ((F_CamFrontBackAll) this).Ground_Ref.Display = ((F_ColorType) this).\u0002.Display;
    ((F_CamFrontBackAll) this).Ground_Ref.DisplayTop = ((F_ColorType) this).\u0001.Display;
    ((F_CamFrontBackAll) this).Ground_Ref.DisplayBottom = ((F_CamFrontBackAll) this).\u0003.Display;
    ((F_ColorType) this).\u0001.UpdateControl();
    ((F_CamFrontBackAll) this).\u0003.UpdateControl();
    ((F_ColorType) this).\u0002.UpdateControl();
    ((F_ColorDrawType) this).PropertiesForm.Result = DialogResult.None;
    ((F_ColorDrawType) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUIGround) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ColorDrawType) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ColorDrawType) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ColorDrawType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ColorDrawType) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_ColorType) this).btn_ok.Name)
      {
        this.Apply();
        ((F_ColorDrawType) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_ColorDrawType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ColorDrawType) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (!(control.Name == ((F_ColorDrawType) this).btn_close.Name | control.Name == ((F_ColorType) this).btn_cancel.Name))
          return;
        ((F_ColorDrawType) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_ColorDrawType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ColorDrawType) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }
}
