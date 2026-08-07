// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_CamSettings1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Cam;

public class F_CamSettings1 : Form
{
  public FormProperties Properties;
  public static List<string> Captions;
  public CamFrontBackAll FrontBackAll;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  public static byte f003590;
  public FormProperties Properties;
  public static List<string> Captions;
  public CamFrontBackAll FrontBack;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal Button \u0001;
  internal Button \u0002;
  public static byte f003598;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public camParameters5 Settings;
  public CamType camType;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buSpin spn_topoffet;
  public buButton btn_ok;
  public buSpin spn_bottomoffst;
  public buButton btn_cancel;
  public buSpin spn_stepoverparallel;
  public buSpin spn_plungespeed;
  public buSpin spn_cuttingspeed;
  public buSpin spn_rapiddistance;
  public buSpin spn_safedistance;
  internal buTab \u0001;
  internal TabPage \u0001;
  public buCheckBox chk_roughstocksurface;
  public buCheckBox chk_roughstockbox;
  public buCheckBox chk_roughminimizelink;
  public buCheckBox chk_roughremovecornerpeg;
  public buCheckBox chk_roughleadout;
  public buCheckBox chk_roughuseramp;
  public buCheckBox chk_roughsharpcorner;
  public buCheckBox chk_roughadaptive;
  public buCheckBox chk_roughoffset;
  public buCheckBox chk_roughparalel;
  internal TabPage \u0002;
  internal buLabel \u0001;
  internal TabPage \u0003;
  internal TabPage \u0004;
  internal TabPage \u0005;
  internal buTab \u0002;
  internal TabPage \u0006;
  internal TabPage \u0007;
  internal TabPage \u0008;
  public buButton btn_advanced;
  public buButton btn_5Axis;
  public buButton btn_camstrategy;
  internal buGroup \u0001;
  internal buGroup \u0002;
  internal buGroup \u0003;
  public buSpin spn_stepoverrough;
  public buSpin spn_roughrampangle;
  public buSpin spn_roughrampdia;
  public buSpin spn_cuttolerance;
  internal buGroup \u0004;
  public buCheckBox chk_zigzag;
  public buCheckBox chk_oneway;
  public buCheckBox chk_spiral;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
      ((F_CamTriMeshSettings) this).track_ref.Track.DoneDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0004.Name)
      ((F_CamTriMeshSettings) this).track_ref.Track.DrawerDisplay = ((F_CamTriMeshSettings) this).\u0004.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
      ((F_CamTriMeshSettings) this).track_ref.Caption.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0003.Name)
      ((F_CamTriMeshSettings) this).track_ref.Display = ((F_CamTriMeshSettings) this).\u0003.Display;
    ((F_CamTriMeshSettings) this).track_ref.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name)
    {
      ((F_CamTriMeshSettings) this).track_ref.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).spn_drawerwidth.Name))
      return;
    ((F_CamTriMeshSettings) this).track_ref.Track.DrawerWidth = (int) ((F_CamTriMeshSettings) this).spn_drawerwidth.Value;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ObjectWidth = (int) ((F_CamTriMeshSettings) this).spn_drawerwidth.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_CamTriMeshSettings) this).track_ref.Geometry.ShapeMode = result;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType = result;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_CamTriMeshSettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_CamTriMeshSettings) this).track_ref.ImageAlign = result1;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment = result1;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
    {
      Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out ShapeType _);
      ((F_CamTriMeshSettings) this).track_ref.Track.ShowPersentage = ((F_CamTriMeshSettings) this).\u0001.Check;
      ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ShowPersentage = ((F_CamTriMeshSettings) this).\u0001.Check;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).\u0002.Name))
      return;
    Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out ShapeType _);
    ((F_CamTriMeshSettings) this).track_ref.Track.DrawerRectangle = ((F_CamTriMeshSettings) this).\u0002.Check;
    ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).DrawerRectangle = ((F_CamTriMeshSettings) this).\u0002.Check;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
