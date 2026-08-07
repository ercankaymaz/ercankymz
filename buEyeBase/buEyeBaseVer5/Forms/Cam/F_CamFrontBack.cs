// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_CamFrontBack
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buControls.Controls;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Cam;

public class F_CamFrontBack : Form
{
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  internal buComboBox \u0002;

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
      ((F_CamTriMeshSettings) this).grp_ref.TitleDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
      ((F_CamTriMeshSettings) this).grp_ref.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    ((F_CamTriMeshSettings) this).grp_ref.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name)
    {
      ((F_CamTriMeshSettings) this).grp_ref.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).spn_headerheight.Name))
      return;
    ((F_CamTriMeshSettings) this).grp_ref.TitleHeight = (int) ((F_CamTriMeshSettings) this).spn_headerheight.Value;
    ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).TopHeight = (int) ((F_CamTriMeshSettings) this).spn_headerheight.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_CamTriMeshSettings) this).grp_ref.Geometry.ShapeMode = result;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType = result;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_CamTriMeshSettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_CamTriMeshSettings) this).grp_ref.ImageAlign = result1;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment = result1;
  }
}
