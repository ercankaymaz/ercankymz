// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_NotchCamSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Sewing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_NotchCamSettings : Form
{
  internal Label \u0099;
  internal Label \u009A;
  internal Label \u009B;
  public NumericUpDown spn_AutoSaveMaxCount;
  internal Label \u009C;
  public NumericUpDown spn_AutoSaveTimeSec;
  internal Label \u009D;
  internal Label \u009E;
  internal Label \u009F;
  internal Label \u0001\u0002;
  public CheckBox chk_SaveCurrentProfilesWhileProgramClosing;
  public CheckBox chkAutoCloseWater;
  public CheckBox chk_ToolDistanceDataToOperationDistanceData;
  public CheckBox chk_ToolSpeedDataToOperationSpeedData;
  public CheckBox chk_DontAddLineFromExternalFile;
  public CheckBox chk_ClamperCanMoveInsideProfileLength;
  public CheckBox chk_MultipleEdit;
  internal Label \u0002\u0002;
  internal Label \u0003\u0002;
  public CheckBox chk_OperationFrontBackMirrorYDirToAnotherPlane;
  internal Label \u0004\u0002;
  internal Label \u0005\u0002;
  public CheckBox chk_RightProfileMakeAsMirror;
  internal Label \u0006\u0002;
  internal Label \u0007\u0002;
  internal TabPage \u000F;
  internal Label \u0008\u0002;
  internal Label \u000E\u0002;
  internal Label \u000F\u0002;
  internal Label \u0010\u0002;
  internal Label \u0011\u0002;
  internal Label \u0012\u0002;
  internal Label \u0013\u0002;
  internal Label \u0014\u0002;
  internal Label \u0015\u0002;
  internal Label \u0016\u0002;
  internal Label \u0017\u0002;
  internal Label \u0018\u0002;
  internal Label \u0019\u0002;

  static F_NotchCamSettings() => F_Settnigs.Captions = new List<string>();

  public F_NotchCamSettings()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).FootHeight = 1.0;
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SewingFootHeight) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_MoveCommad(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Settnigs) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Settnigs) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_MoveCommad(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Settnigs) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Settnigs) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CancelCommad(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_Settnigs) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_Settnigs) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CancelCommad(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_Settnigs) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_Settnigs) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_Settnigs) this).Properties.Inited = false;
    if (((F_Settnigs) this).Properties.Height > 10)
      this.Height = ((F_Settnigs) this).Properties.Height;
    if (((F_Settnigs) this).Properties.Width > 10)
      this.Width = ((F_Settnigs) this).Properties.Width;
    this.TopMost = ((F_Settnigs) this).Properties.TopMost;
    this.StartPosition = ((F_Settnigs) this).Properties.FormPosition;
    ((F_Settnigs) this).\u0001.Value = (Decimal) ((F_Settnigs) this).FootHeight;
    ((F_Settnigs) this).Properties.Result = DialogResult.None;
    ((F_Settnigs) this).Properties.Inited = true;
    ((F_NotchList) this).LoadLangueage();
  }
}
