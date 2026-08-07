// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_LayerConvertToTufting
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_LayerConvertToTufting : Form
{
  internal Label \u0019;
  internal Label \u001A;
  internal Label \u001B;
  internal Label \u001C;
  internal Label \u001D;
  internal Label \u001E;
  internal Label \u001F;
  internal Label \u007F;
  internal Label \u0080;
  internal Label \u0081;
  internal Label \u0082;
  internal Label \u0083;
  internal Label \u0084;
  public static byte f000BF3;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public string pathInit;
  public Image imageOutput;
  public RasterToVectorVar Settings;
  private string \u0001;
  private List<Color> \u0001;
  private List<Color> \u0002;
  private Image \u0001;
  private IContainer \u0001;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal Button \u0001;
  internal RadioButton \u0001;
  internal Panel \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_Copy) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_Copy) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_Copy) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_Copy) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_Copy) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_Copy) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_Copy) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_Copy) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandApply(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_Copy) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_Copy) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandApply(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_Copy) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_Copy) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public F_LayerConvertToTufting()
  {
    ((F_Copy) this).Properties = new FormProperties();
    ((F_Copy) this).Settings = (DeleteTypeEventFormVars) new SewingVertex();
    ((F_Copy) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_DeleteType) this);
  }

  public void Init()
  {
    ((F_Copy) this).Properties.Inited = false;
    ((F_Copy) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_Copy) this).Properties.TopMost;
    this.StartPosition = ((F_Copy) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_Copy) this).Properties.ScaleFromMode;
    if (((F_Copy) this).Properties.Height > 10)
      this.Height = ((F_Copy) this).Properties.Height;
    if (((F_Copy) this).Properties.Width > 10)
      this.Width = ((F_Copy) this).Properties.Width;
    ((F_ColorList) this).\u0008.Checked = ((SewingInfo) ((F_Copy) this).Settings).PointDelete;
    ((F_ColorList) this).\u0007.Checked = ((SewingInfo) ((F_Copy) this).Settings).LineDelete;
    ((F_ColorList) this).\u0006.Checked = ((SewingInfo) ((F_Copy) this).Settings).PolylinDelete;
    ((F_ColorList) this).\u0005.Checked = ((SewingInfo) ((F_Copy) this).Settings).CircleDelete;
    ((F_Copy) this).\u0004.Checked = ((SewingInfo) ((F_Copy) this).Settings).ArcDelete;
    ((F_Copy) this).\u0003.Checked = ((SewingInfo) ((F_Copy) this).Settings).EllipseDelete;
    ((F_ColorList) this).\u000E.Checked = ((SewingInfo) ((F_Copy) this).Settings).EllipseArcDelete;
    ((F_Copy) this).\u0001.Checked = ((SewingVertex) ((F_Copy) this).Settings).CurveDelete;
    ((F_Copy) this).\u0002.Checked = ((SewingInfo) ((F_Copy) this).Settings).CompositeCurveDelete;
    ((F_ColorList) this).\u000F.Checked = ((SewingVertex) ((F_Copy) this).Settings).RegionDelete;
    ((F_ColorList) this).\u0013.Checked = ((SewingVertex) ((F_Copy) this).Settings).DimensionDelete;
    ((F_ColorList) this).\u0014.Checked = ((SewingVertex) ((F_Copy) this).Settings).PictureDelete;
    ((F_ColorList) this).\u0015.Checked = ((SewingVertex) ((F_Copy) this).Settings).TextDelete;
    ((F_ColorList) this).\u0010.Checked = ((SewingVertex) ((F_Copy) this).Settings).MeshDelete;
    ((F_ColorList) this).\u0012.Checked = ((SewingVertex) ((F_Copy) this).Settings).BrepDelete;
    ((F_ColorList) this).\u0011.Checked = ((SewingCode) ((F_Copy) this).Settings).SurfaceDelete;
    ((F_ColorList) this).\u0016.Checked = ((SewingCode) ((F_Copy) this).Settings).SolidDelete;
    ((F_ColorList) this).\u0017.Checked = ((SewingCode) ((F_Copy) this).Settings).HatchDelete;
    ((F_Copy) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Copy) this).btn_ok.Name)
    {
      ((F_Copy) this).Properties.Result = DialogResult.OK;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_DeleteType) this);
      if (((F_Copy) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Copy) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (((F_Copy) this).\u0001 != null)
        ;
    }
    if (!(control2.Name == ((F_Copy) this).btn_cancel.Name))
      return;
    if (((F_Copy) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Copy) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    ((F_Copy) this).Properties.Result = DialogResult.Cancel;
    // ISSUE: reference to a compiler-generated field
    if (((F_Copy) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_Copy) this).\u0001();
  }
}
