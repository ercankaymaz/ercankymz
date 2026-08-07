// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestOldResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buControls;
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

public class F_NestOldResult : Form
{
  internal Label \u0010;
  internal NumericUpDown \u0004;
  internal Label \u0011;
  internal CheckBox \u0002;
  internal Label \u0012;
  internal TextBox \u0002;
  internal Label \u0013;
  internal NumericUpDown \u0005;
  public static byte f000CA6;
  public LayerBase5 layer;
  public List<TuftingYarn> Yarns;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal ComboBox \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal CheckBox \u0001;
  internal Label \u0003;
  internal TextBox \u0001;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  public Button btn_cancel;
  public Button btn_ok;
  internal ComboBox \u0002;
  internal Label \u0007;
  internal Label \u0008;
  internal NumericUpDown \u0002;
  internal Label \u000E;
  internal NumericUpDown \u0003;

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandApply(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_RouterOperations) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_RouterOperations) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandApply(ApplyCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ApplyCommandWithDataEventHandler dataEventHandler = ((F_RouterOperations) this).\u0001;
    ApplyCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ApplyCommandWithDataEventHandler>(ref ((F_RouterOperations) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public F_NestOldResult()
  {
    ((F_PerpendicularSelection) this).Properties = new FormProperties();
    ((F_PerpendicularSelection) this).Settings = (ScaleEventFormVars) new SewingVertex();
    ((F_RouterOperations) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Scale) this);
  }

  public void Init()
  {
    ((F_PerpendicularSelection) this).Properties.Inited = false;
    ((F_PerpendicularSelection) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_PerpendicularSelection) this).Properties.TopMost;
    this.StartPosition = ((F_PerpendicularSelection) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_PerpendicularSelection) this).Properties.ScaleFromMode;
    if (((F_PerpendicularSelection) this).Properties.Height > 10)
      this.Height = ((F_PerpendicularSelection) this).Properties.Height;
    if (((F_PerpendicularSelection) this).Properties.Width > 10)
      this.Width = ((F_PerpendicularSelection) this).Properties.Width;
    \u0007.\u0001.\u0001((F_Scale) this);
    ((F_RouterOperations) this).\u0001.Value = (Decimal) ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Ratio.X;
    ((F_RouterOperations) this).\u0002.Value = (Decimal) ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Ratio.Y;
    ((F_RouterOperations) this).btn_aligment.Visible = ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).ShowAligment;
    ((F_RouterOperations) this).\u0002.Checked = ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).KeepRatio;
    ((F_RouterOperations) this).\u0001.Checked = ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).isLengthMode;
    ((F_PerpendicularSelection) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RouterOperations) this).btn_lefttop.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.TopLeft;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_left.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.MiddleLeft;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_leftbottom.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.BottomLeft;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_righttop.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.TopRight;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_right.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.MiddleRight;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_rightbottom.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.BottomRight;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_center.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.MiddleCenter;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_top.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.TopCenter;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_bottom.Name)
    {
      ((EntityShapeInfo) ((F_PerpendicularSelection) this).Settings).Alignment = ContentAlignment.BottomCenter;
      \u0007.\u0001.\u0001((F_Scale) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_ok.Name)
    {
      ((F_PerpendicularSelection) this).Properties.Result = DialogResult.OK;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Scale) this);
      if (((F_PerpendicularSelection) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_PerpendicularSelection) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (((F_PerpendicularSelection) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_PerpendicularSelection) this).\u0001((object) new Pnt3D((double) ((F_RouterOperations) this).\u0001.Value, (double) ((F_RouterOperations) this).\u0002.Value, 1.0));
      }
    }
    if (control2.Name == ((F_RouterOperations) this).btn_cancel.Name)
    {
      if (((F_PerpendicularSelection) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_PerpendicularSelection) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_PerpendicularSelection) this).Properties.Result = DialogResult.Cancel;
      // ISSUE: reference to a compiler-generated field
      if (((F_RouterOperations) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_RouterOperations) this).\u0001();
      }
    }
    if (!(control2.Name == ((F_RouterOperations) this).btn_aligment.Name))
      return;
    ((F_RouterOperations) this).\u0002.Visible = true;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.Controls, result, obj1.Shift);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (!((F_PerpendicularSelection) this).Properties.Inited || ((F_RouterOperations) this).\u0001 == null)
      return;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Scale) this);
    // ISSUE: reference to a compiler-generated field
    ((F_RouterOperations) this).\u0001((object) ((F_PerpendicularSelection) this).Settings);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_RouterOperations) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RouterOperations) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestOldResult() => F_PerpendicularSelection.Captions = new List<string>();

  public event OkCommandWithDataEventHandler PreviewPressed;
}
