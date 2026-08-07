// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_LayerTufting
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_LayerTufting : Form
{
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  internal RadioButton \u0002;
  internal Label \u0008;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Label \u000E;
  internal Label \u000F;
  internal Label \u0010;
  internal Label \u0011;
  internal Label \u0012;
  internal Label \u0013;
  internal Label \u0014;
  internal Label \u0015;
  internal Label \u0016;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0017;
  internal NumericUpDown \u0003;
  internal Label \u0018;
  internal NumericUpDown \u0004;
  internal Label \u0019;
  public static byte f000C1F;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public bool Vertical;
  public bool Horizontal;
  public bool Angle;
  public string strRemoveCaption;
  private IContainer \u0001;
  internal ImageList \u0001;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Copy) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Copy) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_LayerTufting() => F_Copy.Captions = new List<string>();

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_ColorList) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_ColorList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_ColorList) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_ColorList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_ColorList) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_ColorList) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_ColorList) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_ColorList) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandApply(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_ColorList) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_ColorList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandApply(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_ColorList) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_ColorList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public F_LayerTufting()
  {
    ((F_ColorList) this).Properties = new FormProperties();
    ((F_ColorList) this).Settings = (MirrorEventFormVars) new SewingCode();
    ((F_ColorList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Mirror) this);
  }
}
