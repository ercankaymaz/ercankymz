// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCavity
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCavity : Form
{
  public buSpin spn_length;
  public buSpin spn_angle;
  public TabPage tabPage_builtin;
  internal TabPage \u0002;
  internal buPanel \u0001;
  internal TabPage \u0003;
  internal buPanel \u0002;
  public buButton btn_leftup;
  public buButton btn_right;
  public buButton btn_rightdown;
  public buButton btn_left;
  public buButton btn_rightup;
  public buButton btn_up;
  public buButton btn_down;
  public buButton btn_leftdown;
  internal buPanel \u0003;
  public buSpin spn_diameter;
  public buSpin spn_width;
  public buSpin spn_height;
  public buButton btn_undo;
  public buButton btn_clear;

  internal void \u0001([In] object obj0, [In] TreeViewEventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0001([In] object obj0, [In] TreeNodeMouseClickEventArgs obj1)
  {
    if (AppBool.ListFilling | AppBool.TreeCollapsing | AppBool.TreeExpanding)
    {
      AppBool.TreeCollapsing = false;
      AppBool.TreeExpanding = false;
    }
    else
    {
      AppBool.TreeNodeClicked = true;
      if (!(((buTreeNode) obj1.Node).Command == "main"))
        ;
      AppBool.TreeNodeClicked = false;
    }
  }

  internal void \u0001([In] object obj0, [In] TreeViewCancelEventArgs obj1)
  {
    AppBool.TreeExpanding = true;
  }

  internal void \u0002([In] object obj0, [In] TreeViewCancelEventArgs obj1)
  {
    AppBool.TreeCollapsing = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarblePointerCmd) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarblePointerCmd) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCavity() => F_MarbleBackupLoad.Captions = new List<string>();

  public F_MarbleCavity()
  {
    ((F_MarbleCutRemailMaterial) this).PropertiesForm = new FormProperties();
    ((F_MarbleCutRemailMaterial) this).pntList = new List<Point3D>();
    ((F_MarbleCutRemailMaterial) this).EntityList = new List<Entity>();
    ((F_MarbleTap) this).\u0001 = (Timer) null;
    ((F_MarbleTap) this).\u0001 = DrawingTypes.Line;
    ((F_MarbleTap) this).\u0001 = new List<buEntity>();
    ((F_MarbleTap) this).\u0001 = new Point3D();
    ((F_MarbleTap) this).\u0002 = new Point3D();
    ((F_MarbleTap) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEasyDraw) this);
    ((F_MarbleTap) this).\u0001 = new Timer();
    ((F_MarbleTap) this).\u0001.Interval = 50;
    ((F_MarbleTap) this).\u0001.Tick += new EventHandler(((F_MarbleSawMillingCam) this).\u0001);
  }
}
