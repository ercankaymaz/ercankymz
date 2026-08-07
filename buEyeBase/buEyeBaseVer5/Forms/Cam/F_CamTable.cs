// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_CamTable
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using buControls.DialogBox;
using buCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Cam;

public class F_CamTable : Form
{
  public buButton btn_off2;
  internal buPanel \u0001;
  internal buPanel \u0002;
  internal buLabel \u0082;
  public static byte f003575;
  public ColorDrawType Value;
  public static List<string> Captions;
  private IContainer \u0001;
  public Button btn_cancel;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
    {
      ((F_CamTriMeshSettings) this).track_ref.Track.DoneDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Done = new buControlDisplay(((F_CamTriMeshSettings) this).\u0001.Display);
    }
    if (control.Name == ((F_CamTriMeshSettings) this).\u0004.Name)
    {
      ((F_CamTriMeshSettings) this).track_ref.Track.DrawerDisplay = ((F_CamTriMeshSettings) this).\u0004.Display;
      ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Shape = new buControlDisplay(((F_CamTriMeshSettings) this).\u0004.Display);
    }
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      ((F_CamTriMeshSettings) this).lbl_speed.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
      ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Caption = new buControlDisplay(((F_CamTriMeshSettings) this).\u0002.Display);
    }
    if (control.Name == ((F_CamTriMeshSettings) this).\u0003.Name)
    {
      ((F_CamTriMeshSettings) this).track_ref.Display = ((F_CamTriMeshSettings) this).\u0003.Display;
      ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Display = new buControlDisplay(((F_CamTriMeshSettings) this).\u0003.Display);
    }
    if (control.Name == ((F_CamTriMeshSettings) this).\u0005.Name)
    {
      ((F_CamTriMeshSettings) this).btn_minus.Display = ((F_CamTriMeshSettings) this).\u0005.Display;
      ((F_CamTriMeshSettings) this).btn_plus.Display = ((F_CamTriMeshSettings) this).\u0005.Display;
      ((F_CamTriMeshSettings) this).btn_minus.ButtonDownDisplay = ((F_CamTriMeshSettings) this).\u0005.Display;
      ((F_CamTriMeshSettings) this).btn_plus.ButtonDownDisplay = ((F_CamTriMeshSettings) this).\u0005.Display;
      ((buFile5) ((F_CamTriMeshSettings) this).Settings).ButtonNormal = new buControlDisplay(((F_CamTriMeshSettings) this).\u0005.Display);
      ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).ButtonDown = new buControlDisplay(((F_CamTriMeshSettings) this).\u0005.Display);
    }
    if (control.Name == ((F_CamTriMeshSettings) this).\u0006.Name)
    {
      ((F_CamTriMeshSettings) this).btn_minus.ButtonOverDisplay = ((F_CamTriMeshSettings) this).\u0006.Display;
      ((F_CamTriMeshSettings) this).btn_plus.ButtonOverDisplay = ((F_CamTriMeshSettings) this).\u0006.Display;
      ((buFile5) ((F_CamTriMeshSettings) this).Settings).ButtonOver = new buControlDisplay(((F_CamTriMeshSettings) this).\u0006.Display);
    }
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

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    buLabel buLabel = obj0 as buLabel;
    if (!(buLabel.Name == ((F_CamTriMeshSettings) this).\u0002.Name))
      return;
    Color backColor = buLabel.Display.BackColor;
    if (ColorDialogBox.ShowDialog(ref backColor) != DialogResult.OK)
      return;
    buLabel.Display.BackColor = backColor;
    buLabel.Text = buImage.GetColorKnownName(backColor);
    if (backColor == Color.Black)
      buLabel.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      buLabel.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).spn_speed.Display.BackColor = backColor;
    ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ValueColor = backColor;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
