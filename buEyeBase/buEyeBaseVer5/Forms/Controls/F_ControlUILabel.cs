// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUILabel
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

public class F_ControlUILabel : Form
{
  public buSpin spn_slotdepth;
  public buSpin spn_slotheight;
  public buSpin spn_slotwidth;
  public buSpin spn_ZPos;
  public buSpin spn_XPos;
  public buCheckBox chk_contourcenter;
  public buCheckBox chk_contourinside;
  public buCheckBox chk_tool3;
  public buCheckBox chk_contouroutside;
  public buCheckBox chk_tool2;
  public buCheckBox chk_tool1;
  public buSpin spn_slotradius;
  internal buGroup \u0001;
  public buSpin spn_cuttingfeed;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ColorType) this).\u0001.Name)
      ((F_CamFrontBackAll) this).Ground_Ref.DisplayTop = ((F_ColorType) this).\u0001.Display;
    if (control.Name == ((F_CamFrontBackAll) this).\u0003.Name)
      ((F_CamFrontBackAll) this).Ground_Ref.DisplayBottom = ((F_CamFrontBackAll) this).\u0003.Display;
    if (control.Name == ((F_ColorType) this).\u0002.Name)
      ((F_CamFrontBackAll) this).Ground_Ref.Display = ((F_ColorType) this).\u0002.Display;
    ((F_CamFrontBackAll) this).Ground_Ref.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ColorType) this).spn_geometryrad.Name)
    {
      ((F_CamFrontBackAll) this).Ground_Ref.Geometry.ArcDiameter = (int) ((F_ColorType) this).spn_geometryrad.Value;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).GeometryArcDiameer = (int) ((F_ColorType) this).spn_geometryrad.Value;
    }
    if (control.Name == ((F_ColorType) this).spn_headerheight.Name)
    {
      ((F_CamFrontBackAll) this).Ground_Ref.Ground.TopHeight = (int) ((F_ColorType) this).spn_headerheight.Value;
      ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).TopHeight = (int) ((F_ColorType) this).spn_headerheight.Value;
    }
    if (!(control.Name == ((F_CamFrontBackAll) this).spn_bottomheight.Name))
      return;
    ((F_CamFrontBackAll) this).Ground_Ref.Ground.BottomHeight = (int) ((F_CamFrontBackAll) this).spn_bottomheight.Value;
    ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).BottomHeight = (int) ((F_CamFrontBackAll) this).spn_bottomheight.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ColorType) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_ColorType) this).\u0002.SelectedItem.ToString(), out result);
      ((F_CamFrontBackAll) this).Ground_Ref.Geometry.ShapeMode = result;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).GeometryType = result;
    }
    if (!(control.Name == ((F_ColorType) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_ColorType) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_CamFrontBackAll) this).Ground_Ref.ImageAlign = result1;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ColorDrawType) this).Settings).Parameters).ImageAlignment = result1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ColorDrawType) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ColorDrawType) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUILabel() => F_ColorDrawType.Captions = new List<string>();

  public F_ControlUILabel()
  {
    ((F_CamFrontBackAll) this).PropertiesForm = new FormProperties();
    ((F_CamFrontBackAll) this).Settings = (hmiUIBasicSettings) new buEyeShotFunctions();
    ((F_CamFrontBackAll) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUIBasic) this);
  }

  public void Init()
  {
    ((F_CamFrontBackAll) this).PropertiesForm.Inited = false;
    if (((F_CamFrontBackAll) this).PropertiesForm.Height > 10)
      this.Height = ((F_CamFrontBackAll) this).PropertiesForm.Height;
    if (((F_CamFrontBackAll) this).PropertiesForm.Width > 10)
      this.Width = ((F_CamFrontBackAll) this).PropertiesForm.Width;
    this.TopMost = ((F_CamFrontBackAll) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_CamFrontBackAll) this).PropertiesForm.FormPosition;
    ((F_CamFrontBack) this).\u0001.Items.Clear();
    ((F_CamFrontBack) this).\u0001.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
    ((F_CamFrontBack) this).\u0002.Items.Clear();
    ((F_CamFrontBack) this).\u0002.Items.AddRange(Enum.GetValues(typeof (ShapeType)).Cast<object>().ToArray<object>());
    ((F_CamFrontBack) this).\u0001.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) this).Settings).Display;
    ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamFrontBack) this).\u0002.SelectedItem = (object) ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) this).Settings).Parameters).GeometryType;
    ((F_CamFrontBack) this).\u0001.SelectedItem = (object) ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).\u0001.Geometry.ShapeMode = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).\u0001.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).\u0001.ImageAlign = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) ((F_CamFrontBackAll) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamFrontBack) this).\u0001.Display;
    ((F_CamFrontBack) this).\u0001.UpdateControl();
    ((F_CamFrontBackAll) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamFrontBackAll) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUIBasic) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamFrontBackAll) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamFrontBackAll) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CamFrontBackAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamFrontBackAll) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
      if (control.Name == ((F_CamFrontBack) this).btn_ok.Name)
      {
        this.Apply();
        ((F_CamFrontBackAll) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_CamFrontBackAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamFrontBackAll) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (!(control.Name == ((F_CamFrontBackAll) this).btn_close.Name | control.Name == ((F_CamFrontBack) this).btn_cancel.Name))
          return;
        ((F_CamFrontBackAll) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_CamFrontBackAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamFrontBackAll) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }
}
