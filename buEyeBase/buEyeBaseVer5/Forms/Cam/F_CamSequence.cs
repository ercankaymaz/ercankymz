// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_CamSequence
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.ColorPicker;
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

public class F_CamSequence : Form
{
  public Button btn_ok;
  internal buColorComboBox \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  public ColorType Value;
  public static List<string> Captions;
  private IContainer \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal buColorComboBox \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0001;

  static F_CamSequence() => F_CamTriMeshSettings.Captions = new List<string>();

  public F_CamSequence()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).Settings = (hmiUISettings) new buEyeShotFunctions();
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUITrack) this);
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
    ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).\u0002.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).spn_drawerwidth.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ObjectWidth;
    ((F_CamTriMeshSettings) this).\u0001.Check = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ShowPersentage;
    ((F_CamTriMeshSettings) this).track_ref.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).track_ref.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).track_ref.ImageAlign = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).track_ref.Track.ShowPersentage = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ShowPersentage;
    ((F_CamTriMeshSettings) this).track_ref.Track.DrawerWidth = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ObjectWidth;
    ((F_CamTriMeshSettings) this).track_ref.Display = ((F_CamTriMeshSettings) this).\u0003.Display;
    ((F_CamTriMeshSettings) this).track_ref.Caption.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    ((F_CamTriMeshSettings) this).track_ref.Track.DoneDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
    ((F_CamTriMeshSettings) this).track_ref.Track.DrawerDisplay = ((F_CamTriMeshSettings) this).\u0004.Display;
    ((F_CamTriMeshSettings) this).\u0004.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0002.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0003.UpdateControl();
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUITrack) this);
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
}
