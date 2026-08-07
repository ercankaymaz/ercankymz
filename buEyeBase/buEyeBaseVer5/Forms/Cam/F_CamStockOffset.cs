// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_CamStockOffset
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Forms.Controls;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Cam;

public class F_CamStockOffset : Form
{
  internal buLabel \u0017;
  internal buLabel \u0018;
  internal buLabel \u0019;
  public buButton btn_on2;
  public buButton btn_on1;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  internal buComboBox \u0003;
  internal buComboBox \u0004;
  internal buLabel \u001A;
  internal buGroup \u0001;
  internal buGroup \u0002;
  internal buLabel \u001B;
  internal buGround \u0002;
  internal buLabel \u001C;
  internal buLabel \u001D;
  internal buLabel \u001E;
  internal buLabel \u001F;
  internal buLabel \u007F;
  internal buLabel \u0080;
  internal PictureBox \u0012;
  internal buLabel \u0081;
  internal TreeView \u0001;
  internal TreeView \u0002;
  public buButton btn_off1;

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name)
    {
      ((F_CamTriMeshSettings) this).Cmb_Ref.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).spn_arrowwidth.Name))
      return;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.ArrowButtonWidth = (int) ((F_CamTriMeshSettings) this).spn_arrowwidth.Value;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ObjectWidth = (int) ((F_CamTriMeshSettings) this).spn_arrowwidth.Value;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_CamTriMeshSettings) this).Cmb_Ref.Geometry.ShapeMode = result;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType = result;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_CamTriMeshSettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment = result1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CamStockOffset() => F_CamTriMeshSettings.Captions = new List<string>();

  public F_CamStockOffset()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).Settings = (hmiUISettings) new buEyeShotFunctions();
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ControlUISpeeds) this);
  }

  public void Init()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = false;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_CamTriMeshSettings) this).PropertiesForm.Height;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_CamTriMeshSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_CamTriMeshSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_CamTriMeshSettings) this).PropertiesForm.FormPosition;
    ((F_CamTriMeshSettings) this).\u0001.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0001.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
    ((F_CamTriMeshSettings) this).\u0002.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0002.Items.AddRange(Enum.GetValues(typeof (ShapeType)).Cast<object>().ToArray<object>());
    ((F_CamTriMeshSettings) this).\u0001.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Done;
    ((F_CamTriMeshSettings) this).\u0004.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Shape;
    ((F_CamTriMeshSettings) this).\u0003.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Display;
    ((F_CamTriMeshSettings) this).\u0002.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Caption;
    ((F_CamTriMeshSettings) this).\u0005.Display = ((buFile5) ((F_CamTriMeshSettings) this).Settings).ButtonNormal;
    ((F_CamTriMeshSettings) this).\u0006.Display = ((buFile5) ((F_CamTriMeshSettings) this).Settings).ButtonOver;
    ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).\u0002.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).spn_drawerwidth.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ObjectWidth;
    ((F_CamTriMeshSettings) this).\u0001.Check = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ShowPersentage;
    ((F_CamTriMeshSettings) this).\u0002.Display.BackColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ValueColor;
    ((F_CamTriMeshSettings) this).\u0002.Text = buImage.GetColorKnownName(((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ValueColor);
    if (((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ValueColor == Color.Black)
      ((F_CamTriMeshSettings) this).\u0002.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      ((F_CamTriMeshSettings) this).\u0002.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).track_ref.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).track_ref.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).track_ref.ImageAlign = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).track_ref.Track.ShowPersentage = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ShowPersentage;
    ((F_CamTriMeshSettings) this).track_ref.Track.DrawerWidth = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ObjectWidth;
    ((F_CamTriMeshSettings) this).track_ref.BackColor = Color.Transparent;
    ((F_CamTriMeshSettings) this).btn_minus.Display = ((F_CamTriMeshSettings) this).\u0005.Display;
    ((F_CamTriMeshSettings) this).btn_minus.ButtonDownDisplay = ((F_CamTriMeshSettings) this).\u0005.Display;
    ((F_CamTriMeshSettings) this).btn_minus.ButtonOverDisplay = ((F_CamTriMeshSettings) this).\u0006.Display;
    ((F_CamTriMeshSettings) this).btn_plus.Display = ((F_CamTriMeshSettings) this).\u0005.Display;
    ((F_CamTriMeshSettings) this).btn_plus.ButtonDownDisplay = ((F_CamTriMeshSettings) this).\u0005.Display;
    ((F_CamTriMeshSettings) this).btn_plus.ButtonOverDisplay = ((F_CamTriMeshSettings) this).\u0006.Display;
    ((F_CamTriMeshSettings) this).lbl_speed.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    ((F_CamTriMeshSettings) this).track_ref.Display = ((F_CamTriMeshSettings) this).\u0003.Display;
    ((F_CamTriMeshSettings) this).track_ref.Track.DoneDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
    ((F_CamTriMeshSettings) this).track_ref.Track.DrawerDisplay = ((F_CamTriMeshSettings) this).\u0004.Display;
    ((F_CamTriMeshSettings) this).spn_speed.Display.BackColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ValueColor;
    ((F_CamTriMeshSettings) this).\u0004.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0002.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0003.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0005.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0006.UpdateControl();
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ControlUISpeeds) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamTriMeshSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
      if (control.Name == ((F_CamTriMeshSettings) this).btn_ok.Name)
      {
        this.Apply();
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (!(control.Name == ((F_CamTriMeshSettings) this).btn_close.Name | control.Name == ((F_CamTriMeshSettings) this).btn_cancel.Name))
          return;
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }
}
