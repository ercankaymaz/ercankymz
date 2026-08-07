// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_Cam4And5AxisSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Cam;

public class F_Cam4And5AxisSettings : Form
{
  internal buLabel \u0005;
  public buButton btn_speedminus;
  public buButton btn_speedplus;
  public buSpin spn_speed;
  public buLabel lbl_speed;
  public buTrack track_speed;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal PictureBox \u0003;
  internal PictureBox \u0004;
  internal buLabel \u0006;
  internal PictureBox \u0005;
  internal PictureBox \u0006;
  internal PictureBox \u0007;
  public buTrack track_2;
  public buTrack track_1;
  public buProgressBar Progress_1;
  internal PictureBox \u0008;
  public buProgressBar Progress_2;
  internal buLabel \u0007;
  internal buLabel \u0008;
  internal buLabel \u000E;
  internal buLabel \u000F;
  internal buLabel \u0010;
  internal buLabel \u0011;
  internal PictureBox \u000E;
  internal PictureBox \u000F;
  internal buLabel \u0012;
  internal buLabel \u0013;
  internal PictureBox \u0010;
  internal PictureBox \u0011;
  internal buLabel \u0014;
  internal buLabel \u0015;
  internal buLabel \u0016;
  internal buGround \u0001;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Cam4And5AxisSettings() => F_CamTriMeshSettings.Captions = new List<string>();

  public F_Cam4And5AxisSettings()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).Settings = (hmiUISettings) new buEyeShotFunctions();
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUICombo) this);
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
    ((F_CamTriMeshSettings) this).\u0002.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Display;
    ((F_CamTriMeshSettings) this).\u0001.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Caption;
    ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).\u0002.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).spn_arrowwidth.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ObjectWidth;
    ((F_CamTriMeshSettings) this).\u0002.Display.BackColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ArrowColor;
    ((F_CamTriMeshSettings) this).\u0006.Display.BackColor = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).LineColor;
    ((F_CamTriMeshSettings) this).\u0004.Display.BackColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).DropColor;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.ArrowButtonWidth = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ObjectWidth;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.ValueColor = ((F_CamTriMeshSettings) this).\u0002.Display.BackColor;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Caption.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.ArrowLineColor = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).LineColor;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.ArrowColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ArrowColor;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.DropBoxColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).DropColor;
    ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0002.UpdateControl();
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u0015.\u0002.\u0001((F_ControlUICombo) this);
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
    buLabel buLabel = obj0 as buLabel;
    if (buLabel.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.ArrowColor = backColor;
      }
    }
    if (buLabel.Name == ((F_CamTriMeshSettings) this).\u0006.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.ArrowLineColor = backColor;
      }
    }
    if (!(buLabel.Name == ((F_CamTriMeshSettings) this).\u0004.Name))
      return;
    Color backColor1 = buLabel.Display.BackColor;
    if (ColorDialogBox.ShowDialog(ref backColor1) != DialogResult.OK)
      return;
    buLabel.Display.BackColor = backColor1;
    buLabel.Text = buImage.GetColorKnownName(backColor1);
    ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.DropBoxColor = backColor1;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
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

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
      ((F_CamTriMeshSettings) this).Cmb_Ref.Caption.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
      ((F_CamTriMeshSettings) this).Cmb_Ref.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    ((F_CamTriMeshSettings) this).Cmb_Ref.BackColor = Color.Transparent;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Combo.ValueColor = ((F_CamTriMeshSettings) this).Cmb_Ref.Display.BackColor;
    ((F_CamTriMeshSettings) this).Cmb_Ref.Invalidate();
  }
}
