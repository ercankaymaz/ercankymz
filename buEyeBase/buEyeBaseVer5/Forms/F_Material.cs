// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_Material
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

public class F_Material : Form
{
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  public static byte f000C31;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public camParameters5 varCamPars;
  public List<ToolBase5> Tools;
  public ToolBase5 ToolSelected;
  public string strRemoveCaption;
  public int SelectedToolIndex;
  internal IContainer \u0001;
  internal ListBox \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Panel \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal NumericUpDown \u0003;
  internal Label \u0005;
  internal NumericUpDown \u0004;
  internal Label \u0006;
  internal NumericUpDown \u0005;
  internal Label \u0007;
  internal NumericUpDown \u0006;
  internal ImageList \u0002;
  internal Label \u0008;
  internal CheckBox \u0001;
  internal NumericUpDown \u0007;
  internal Label \u000E;
  internal NumericUpDown \u0008;
  internal Label \u000F;
  internal Label \u0010;
  internal Label \u0011;
  internal Label \u0012;
  internal CheckBox \u0002;

  public void Init()
  {
    ((F_ColorList) this).Properties.Inited = false;
    ((F_ColorList) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_ColorList) this).Properties.TopMost;
    this.StartPosition = ((F_ColorList) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_ColorList) this).Properties.ScaleFromMode;
    if (((F_ColorList) this).Properties.Height > 10)
      this.Height = ((F_ColorList) this).Properties.Height;
    if (((F_ColorList) this).Properties.Width > 10)
      this.Width = ((F_ColorList) this).Properties.Width;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
    if (((SewingCode) ((F_ColorList) this).Settings).MirrorAxis == MirrorAxisXYType.X)
    {
      ((F_ColorList) this).\u0002.Checked = true;
      ((F_ColorList) this).\u0001.Checked = false;
    }
    else
    {
      ((F_ColorList) this).\u0002.Checked = false;
      ((F_ColorList) this).\u0001.Checked = true;
    }
    ((F_ColorList) this).btn_aligment.Visible = ((SewingCode) ((F_ColorList) this).Settings).ShowAligment;
    ((F_ColorList) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ColorList) this).btn_lefttop.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.TopLeft;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_left.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.MiddleLeft;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_leftbottom.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.BottomLeft;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_righttop.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.TopRight;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_right.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.MiddleRight;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_rightbottom.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.BottomRight;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_center.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.MiddleCenter;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_top.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.TopCenter;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_bottom.Name)
    {
      ((SewingCode) ((F_ColorList) this).Settings).Alignment = ContentAlignment.BottomCenter;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Mirror) this);
      ((F_ColorList) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ColorList) this).btn_ok.Name)
    {
      ((F_ColorList) this).Properties.Result = DialogResult.OK;
      \u0007.\u0001.\u0001((F_Mirror) this);
      if (((F_ColorList) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ColorList) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (((F_ColorList) this).\u0001 != null)
        ;
    }
    if (control2.Name == ((F_ColorList) this).btn_cancel.Name)
    {
      if (((F_ColorList) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ColorList) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_ColorList) this).Properties.Result = DialogResult.Cancel;
      // ISSUE: reference to a compiler-generated field
      if (((F_ColorList) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_ColorList) this).\u0001();
      }
    }
    if (!(control2.Name == ((F_ColorList) this).btn_aligment.Name))
      return;
    ((F_ColorList) this).\u0002.Visible = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ColorList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ColorList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Material() => F_ColorList.Captions = new List<string>();

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_ImageToVector) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_ImageToVector) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_ImageToVector) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_ImageToVector) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_ImageToVector) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_ImageToVector) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_ImageToVector) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_ImageToVector) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandApply(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_ImageToVector) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_ImageToVector) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandApply(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_ImageToVector) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_ImageToVector) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public F_Material()
  {
    ((F_ImageToVector) this).Properties = new FormProperties();
    ((F_ImageToVector) this).Settings = (MoveEventFormVars) new SewingInfo();
    ((F_ImageToVector) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Move) this);
  }
}
