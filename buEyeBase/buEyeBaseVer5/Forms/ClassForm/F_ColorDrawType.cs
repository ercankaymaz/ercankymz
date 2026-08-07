// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.ClassForm.F_ColorDrawType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.ClassForm;

public class F_ColorDrawType : Form
{
  public buLabel lbl_caption;
  public buLabel lbl_title;
  internal buControlDisplaySet \u0002;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public hmiUISettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if ((obj0 as Control).Name == ((F_CamTriMeshSettings) this).\u0001.Name)
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
    ((F_CamTriMeshSettings) this).\u0001.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    if (!((obj0 as Control).Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name))
      return;
    ((F_CamTriMeshSettings) this).\u0001.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    ((F_CamTriMeshSettings) this).refList.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((obj0 as Control).Name == ((F_CamTriMeshSettings) this).\u0001.Name))
      return;
    ShapeType result;
    Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0001.SelectedItem.ToString(), out result);
    ((F_CamTriMeshSettings) this).\u0001.Geometry.ShapeMode = result;
    ((F_CamTriMeshSettings) this).refList.Geometry.ShapeMode = result;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ColorDrawType() => F_CamTriMeshSettings.Captions = new List<string>();
}
