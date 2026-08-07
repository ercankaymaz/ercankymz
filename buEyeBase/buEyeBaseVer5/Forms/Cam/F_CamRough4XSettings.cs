// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_CamRough4XSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
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

public class F_CamRough4XSettings : Form
{
  internal buGroup \u0005;
  public buCheckBox chk_level;
  public buCheckBox chk_region;
  public buButton btn_stocksettingsrrough;
  public buButton btn_rampsettingsrrough;
  internal buGroup \u0006;
  public buCheckBox chk_xdirectionparallel;
  public buCheckBox chk_ydirectionparallel;
  internal buGroup \u0007;
  public buCheckBox chk_cornerupperleftparallel;
  public buCheckBox chk_cornerlowerleftparallel;
  public buCheckBox chk_cornerupperrightparallel;
  public buCheckBox chk_cornerlowerrightparallel;
  public buSpin spn_parallelangleparallel;
  public buCheckBox chk_Angledirectionparallel;
  public buSpin spn_depthsteprough;
  public buCheckBox chk_closedoffsetrrough;
  public buCheckBox chk_maintaincuttingdirectionrough;
  public buCheckBox chk_reversecuttingoderrrough;
  public buSpin spn_overlapconstantZ;
  internal buGroup \u0008;
  public buCheckBox chk_StartAttopconstantZ;
  public buCheckBox chk_StartAtbottomconstantZ;

  static F_CamRough4XSettings() => F_CamTriMeshSettings.Captions = new List<string>();

  public F_CamRough4XSettings()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).refText = (buTextBox) null;
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUIText) this);
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
    if (((F_CamTriMeshSettings) this).refText != null)
    {
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).refText.Caption.Display;
      ((F_CamTriMeshSettings) this).\u0002.Display = ((F_CamTriMeshSettings) this).refText.Display;
      ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((F_CamTriMeshSettings) this).refText.Geometry.ArcDiameter;
      ((F_CamTriMeshSettings) this).\u0002.SelectedItem = (object) ((F_CamTriMeshSettings) this).refText.Geometry.ShapeMode;
      ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((F_CamTriMeshSettings) this).refText.ImageAlign;
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
      ((F_CamTriMeshSettings) this).\u0001.Caption.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
      ((F_CamTriMeshSettings) this).\u0002.UpdateControl();
    }
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUIText) this);
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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
      ((F_CamTriMeshSettings) this).\u0001.Caption.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    ((F_CamTriMeshSettings) this).\u0001.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    if (!((obj0 as Control).Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name))
      return;
    ((F_CamTriMeshSettings) this).\u0001.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    ((F_CamTriMeshSettings) this).refText.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_CamTriMeshSettings) this).\u0001.Geometry.ShapeMode = result;
      ((F_CamTriMeshSettings) this).refText.Geometry.ShapeMode = result;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_CamTriMeshSettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_CamTriMeshSettings) this).\u0001.ImageAlign = result1;
    ((F_CamTriMeshSettings) this).refText.ImageAlign = result1;
  }
}
