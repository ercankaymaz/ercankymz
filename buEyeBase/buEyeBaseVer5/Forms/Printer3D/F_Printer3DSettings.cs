// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Printer3D.F_Printer3DSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Printer3D;

public class F_Printer3DSettings : Form
{
  public buSpin spn_smoothmaxtiltangle;
  public buCheckBox chk_smoot;
  public buCheckBox chk_WAngleLimit;
  public buCheckBox chk_CAngleLimit;
  public buCheckBox chk_AAngleLimit;
  public buCheckBox chk_BAngleLimit;
  public buSpin spn_CAngleLimitStartInXYPlane;
  public buSpin spn_CAngleLimitEndInXYPlane;
  public buSpin spn_WOrtAngleLimitStart;
  public buSpin spn_WOrtAngleLimitEnd;
  public buSpin spn_MaxAngleChange;
  public buSpin spn_BAngleLimitStartInXZPlane;
  public buSpin spn_BAngleLimitEndInXZPlane;
  public buSpin spn_LagAngle;
  public buSpin spn_SideTiltAngle;
  public buSpin spn_AAngleLimitStartInYZPlane;
  public buSpin spn_AAngleLimitEndInYZPlane;
  public buCheckBox chk_silhouettetoolcontact;
  public buCheckBox chk_silhouettepartend;
  public buCheckBox chk_silhouettepart;
  public buCheckBox chk_silhouettenone;
  internal buGroup \u000F;
  public buSpin spn_silhouetteoffset;
  internal buGroup \u0010;
  public buSpin spn_maxdeviationrundcorner;
  public buCheckBox chk_roundcorner;
  internal buGroup \u0011;
  public buCheckBox chk_tiltedwithfixangle;
  public buCheckBox chk_betiltedeleative;
  public buCheckBox chk_notbetilted;
  internal buGroup \u0012;
  public buCheckBox chk_tiltZAxis;
  public buCheckBox chk_tiltYAxis;
  public buCheckBox chk_tiltXAxis;
  public buCheckBox chk_maintaintiltaxis;
  public buCheckBox chk_toolaxiscrossestiltaxis;
  public buSpin spn_rotaryangle;
  public buSpin spn_tiltangle;
  internal buGroup \u0013;
  public buCheckBox chk_usespindlemaindir;
  public buCheckBox chk_orthotocutdirection;
  public buCheckBox chk_followsurfaceisodir;
  internal buGroup \u0014;
  internal buGroup \u0015;

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    if (!((obj0 as Control).Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name))
      return;
    ((F_CamTriMeshSettings) this).spn_ref.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    ((F_CamTriMeshSettings) this).refSpin.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_CamTriMeshSettings) this).spn_ref.Geometry.ShapeMode = result;
      ((F_CamTriMeshSettings) this).refSpin.Geometry.ShapeMode = result;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_CamTriMeshSettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_CamTriMeshSettings) this).spn_ref.ImageAlign = result1;
    ((F_CamTriMeshSettings) this).refSpin.ImageAlign = result1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Printer3DSettings() => F_CamTriMeshSettings.Captions = new List<string>();

  public F_Printer3DSettings()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).refLabel = (buLabel) null;
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUILabel) this);
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
    if (((F_CamTriMeshSettings) this).refLabel != null)
    {
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).refLabel.Display;
      ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((F_CamTriMeshSettings) this).refLabel.Geometry.ArcDiameter;
      ((F_CamTriMeshSettings) this).\u0002.SelectedItem = (object) ((F_CamTriMeshSettings) this).refLabel.Geometry.ShapeMode;
      ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((F_CamTriMeshSettings) this).refLabel.ImageAlign;
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
    }
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUILabel) this);
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
