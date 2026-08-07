// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_PlaneList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_PlaneList : Form
{
  public string strPath;
  public static List<string> Captions;
  private int \u0001;
  public List<ProfileClamper> Clampers;
  public List<ProfileLengthClamperCount> Lengths;
  internal IContainer \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Panel \u0001;
  internal Button \u0001;
  internal Label \u0003;
  internal Button \u0002;

  static F_PlaneList() => F_Clampers.Captions = new List<string>();

  public F_PlaneList()
  {
    ((F_PlaneMoveRotate) this).PropertiesForm = new FormProperties();
    ((F_PlaneMoveRotate) this).ShowViewport = true;
    ((F_ProfileFreeDrawCmd) this).ShowCamSettings = true;
    ((F_ProfileFreeDrawCmd) this).ShowTool = false;
    ((F_ProfileFreeDrawCmd) this).ShowObjectPosition = true;
    ((F_ProfileFreeDrawCmd) this).ShowCornerLocation = true;
    ((F_ProfileFreeDrawCmd) this).EnableLeftPlane = true;
    ((F_ProfileFreeDrawCmd) this).EnableRightPlane = true;
    ((F_ProfileFreeDrawCmd) this).EnableFrontPlane = true;
    ((F_ProfileFreeDrawCmd) this).EnableBackPlane = true;
    ((F_ProfileFreeDrawCmd) this).EnableFreePlane = true;
    ((F_ProfileFreeDrawCmd) this).ClosePageAfterOk = false;
    ((F_ProfileFreeDrawCmd) this).Tools = new List<ToolBase5>();
    ((F_ProfileFreeDrawCmd) this).activeTool = (ToolBase5) null;
    ((F_ProfileFreeDrawCmd) this).parShape = (ShapeRuntimeData) new hmiUICommands();
    ((F_ProfileClamperSet) this).selectedPlanes = new List<SelectedPlaneInfo>();
    ((F_ProfileClamperSet) this).\u0001 = new System.Windows.Forms.Timer();
    ((F_ProfileClamperSet) this).\u0001 = -1;
    ((F_ProfileClamperSet) this).\u0001 = false;
    ((F_ProfileClamperSet) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_NotchList) this);
    ((F_ProfileClamperSet) this).\u0001.Interval = 100;
    ((F_ProfileClamperSet) this).\u0001.Tick += new EventHandler(((F_SelectedPlanes) this).\u0001);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_PlaneMoveRotate) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_PlaneMoveRotate) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_PlaneMoveRotate) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_PlaneMoveRotate) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_PlaneMoveRotate) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_PlaneMoveRotate) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_PlaneMoveRotate) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_PlaneMoveRotate) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
