// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingExtend
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Shape;
using devDept.Eyeshot.Control;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingExtend : Form
{
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public Design viewportLayout;
  public bool ShowViewport;
  public bool ShowCamSettings;
  public bool ShowTool;
  public bool ShowObjectPosition;
  public bool ShowCornerLocation;
  public bool EnableTopPlane;
  public bool EnableBottomPlane;
  public bool EnableLeftPlane;
  public bool EnableRightPlane;
  public bool EnableFrontPlane;
  public bool EnableBacktPlane;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ShapeEdit) this);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ShapeEdit) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SewingFootHeight) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SewingFootHeight) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SewingExtend() => F_SewingFootHeight.Captions = new List<string>();

  public F_SewingExtend()
  {
    ((F_SewingPunteriz) this).ClosePageAfterOk = false;
    ((F_SewingPunteriz) this).Tools = new List<ToolBase5>();
    ((F_SewingPunteriz) this).activeTool = (ToolBase5) null;
    ((F_SewingPunteriz) this).selectedShape = (buShape) null;
    ((F_SewingPunteriz) this).CamPar = (camParameters5) null;
    ((F_SewingPunteriz) this).parShape = (ShapeRuntimeData) new hmiUICommands();
    ((F_SewingPunteriz) this).\u0001 = new System.Windows.Forms.Timer();
    ((F_SewingPunteriz) this).\u0001 = -1;
    ((F_SewingPunteriz) this).\u0001 = false;
    ((F_SewingPunteriz) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_DrillList) this);
    ((F_SewingPunteriz) this).\u0001.Interval = 100;
    ((F_SewingPunteriz) this).\u0001.Tick += new EventHandler(((F_SewingPunteriz) this).\u0001);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_SewingMove) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_SewingMove) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_SewingMove) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_SewingMove) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
