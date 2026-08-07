// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestedResults
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buControls;
using buEyeBaseVer5.Apps;
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

public class F_NestedResults : Form
{
  internal Label \u0013;
  internal CheckBox \u0003;
  internal Label \u0014;
  internal Label \u0015;
  public Button btn_vacuumall;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  internal NumericUpDown \u000E;
  internal Label \u0016;
  internal NumericUpDown \u000F;
  internal Label \u0017;
  internal Label \u0018;
  internal ComboBox \u0001;
  internal CheckBox \u0006;
  internal Label \u0019;
  public static byte f000C66;
  public static List<string> Captions;
  public LayerBase5 layer;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal CheckBox \u0001;
  internal Label \u0002;
  internal TextBox \u0001;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal CheckBox \u0002;
  public Button btn_cancel;
  public Button btn_ok;
  internal ComboBox \u0001;
  internal Label \u0006;
  internal Label \u0007;
  internal NumericUpDown \u0002;
  internal Label \u0008;
  public static byte f000C7B;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<LayerBase5> Layers;
  public int SelectedLayerIndex;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ListView \u0001;
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
  internal Label \u000F;
  internal ComboBox \u0003;

  public void Init()
  {
    ((F_ImageToVector) this).Properties.Inited = false;
    ((F_ImageToVector) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_ImageToVector) this).Properties.TopMost;
    this.StartPosition = ((F_ImageToVector) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_ImageToVector) this).Properties.ScaleFromMode;
    if (((F_ImageToVector) this).Properties.Height > 10)
      this.Height = ((F_ImageToVector) this).Properties.Height;
    if (((F_ImageToVector) this).Properties.Width > 10)
      this.Width = ((F_ImageToVector) this).Properties.Width;
    \u0007.\u0001.\u0001((F_Move) this);
    ((F_ImageToVector) this).\u0001.Value = (Decimal) ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).CatchPoint.X;
    ((F_ImageToVector) this).\u0002.Value = (Decimal) ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).CatchPoint.Y;
    ((F_ImageToVector) this).\u0003.Value = (Decimal) ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).CatchPoint.Z;
    ((F_ImageToVector) this).\u0001.Checked = !((EntityShapeInfo) ((F_ImageToVector) this).Settings).isCoordinateMode;
    ((F_ImageToVector) this).\u0003.Visible = ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).ShowZ;
    ((F_ImageToVector) this).\u0003.Visible = ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).ShowZ;
    ((F_ImageToVector) this).btn_aligment.Visible = ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).ShowAligment;
    ((F_ImageToVector) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ImageToVector) this).btn_lefttop.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.TopLeft;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_left.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.MiddleLeft;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_leftbottom.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.BottomLeft;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_righttop.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.TopRight;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_right.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.MiddleRight;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_rightbottom.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.BottomRight;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_center.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.MiddleCenter;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_top.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.TopCenter;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_bottom.Name)
    {
      ((MirrorEventFormVars) ((F_ImageToVector) this).Settings).Alignment = ContentAlignment.BottomCenter;
      \u0007.\u0001.\u0001((F_Move) this);
      ((F_ImageToVector) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_ImageToVector) this).btn_ok.Name)
    {
      ((F_ImageToVector) this).Properties.Result = DialogResult.OK;
      \u0007.\u0001.\u0001((F_Move) this);
      if (((F_ImageToVector) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ImageToVector) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (((F_ImageToVector) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_ImageToVector) this).\u0001((object) new Pnt3D((double) ((F_ImageToVector) this).\u0001.Value, (double) ((F_ImageToVector) this).\u0002.Value, (double) ((F_ImageToVector) this).\u0003.Value));
      }
    }
    if (control2.Name == ((F_ImageToVector) this).btn_cancel.Name)
    {
      if (((F_ImageToVector) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ImageToVector) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_ImageToVector) this).Properties.Result = DialogResult.Cancel;
      // ISSUE: reference to a compiler-generated field
      if (((F_ImageToVector) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_ImageToVector) this).\u0001();
      }
    }
    if (!(control2.Name == ((F_ImageToVector) this).btn_aligment.Name))
      return;
    ((F_ImageToVector) this).\u0002.Visible = true;
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
    if (!((F_ImageToVector) this).Properties.Inited || ((F_ImageToVector) this).\u0001 == null)
      return;
    \u0007.\u0001.\u0001((F_Move) this);
    // ISSUE: reference to a compiler-generated field
    ((F_ImageToVector) this).\u0001((object) ((F_ImageToVector) this).Settings);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ImageToVector) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ImageToVector) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestedResults() => F_ImageToVector.Captions = new List<string>();

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

  public F_NestedResults()
  {
    ((F_ImageToVector) this).Properties = new FormProperties();
    ((F_ImageToVector) this).Settings = (DevideEventFormVars) new SewingVertex();
    ((F_ImageToVector) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Devide) this);
  }

  public void Init()
  {
    ((F_ImageToVector) this).Properties.Inited = false;
    ((F_ImageToVector) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_ImageToVector) this).Properties.TopMost;
    this.StartPosition = ((F_ImageToVector) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_ImageToVector) this).Properties.ScaleFromMode;
    if (((F_ImageToVector) this).Properties.Height > 10)
      this.Height = ((F_ImageToVector) this).Properties.Height;
    if (((F_ImageToVector) this).Properties.Width > 10)
      this.Width = ((F_ImageToVector) this).Properties.Width;
    ((F_ImageToVector) this).\u0001.Value = (Decimal) ((EntityShapeInfo) ((F_ImageToVector) this).Settings).LineLength;
    ((F_PerpendicularSelection) this).\u0007.Value = (Decimal) ((EditorCustomData) ((F_ImageToVector) this).Settings).PolylineLength;
    ((F_PerpendicularSelection) this).\u0006.Value = (Decimal) ((EditorCustomData) ((F_ImageToVector) this).Settings).CircleLength;
    ((F_PerpendicularSelection) this).\u0005.Value = (Decimal) ((SketchAnalyseData) ((F_ImageToVector) this).Settings).ArcLength;
    ((F_PerpendicularSelection) this).\u0004.Value = (Decimal) ((SketchAnalyseData) ((F_ImageToVector) this).Settings).EllipseLength;
    ((F_PerpendicularSelection) this).\u0003.Value = (Decimal) ((SketchAnalyseSetData) ((F_ImageToVector) this).Settings).CompositeCurveLength;
    ((F_PerpendicularSelection) this).\u0002.Value = (Decimal) ((SewingInfo) ((F_ImageToVector) this).Settings).CurveLength;
    ((F_PerpendicularSelection) this).\u0002.Checked = ((EntityShapeInfo) ((F_ImageToVector) this).Settings).LineEnable;
    ((F_PerpendicularSelection) this).\u0008.Checked = ((EntityShapeInfo) ((F_ImageToVector) this).Settings).PolylineEnable;
    ((F_PerpendicularSelection) this).\u0007.Checked = ((EntityShapeInfo) ((F_ImageToVector) this).Settings).CircleEnable;
    ((F_PerpendicularSelection) this).\u0006.Checked = ((EntityShapeInfo) ((F_ImageToVector) this).Settings).ArcEnable;
    ((F_PerpendicularSelection) this).\u0005.Checked = ((EntityShapeInfo) ((F_ImageToVector) this).Settings).EllipseEnable;
    ((F_PerpendicularSelection) this).\u0004.Checked = ((EntityShapeInfo) ((F_ImageToVector) this).Settings).CompositeCurveEnable;
    ((F_PerpendicularSelection) this).\u0003.Checked = ((EntityShapeInfo) ((F_ImageToVector) this).Settings).CurveEnable;
    ((F_ImageToVector) this).\u0001.Checked = ((SewingInfo) ((F_ImageToVector) this).Settings).ConvertAllToPolyline;
    ((F_ImageToVector) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ImageToVector) this).btn_ok.Name)
    {
      ((F_ImageToVector) this).Properties.Result = DialogResult.OK;
      \u0007.\u0001.\u0001((F_Devide) this);
      if (((F_ImageToVector) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ImageToVector) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (((F_ImageToVector) this).\u0001 != null)
        ;
    }
    if (!(control2.Name == ((F_ImageToVector) this).btn_cancel.Name))
      return;
    if (((F_ImageToVector) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ImageToVector) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    ((F_ImageToVector) this).Properties.Result = DialogResult.Cancel;
    // ISSUE: reference to a compiler-generated field
    if (((F_ImageToVector) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_ImageToVector) this).\u0001();
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
    if (!((F_ImageToVector) this).Properties.Inited || ((F_ImageToVector) this).\u0001 == null)
      return;
    \u0007.\u0001.\u0001((F_Devide) this);
    // ISSUE: reference to a compiler-generated field
    ((F_ImageToVector) this).\u0001((object) ((F_ImageToVector) this).Settings);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ImageToVector) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ImageToVector) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestedResults() => F_ImageToVector.Captions = new List<string>();

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_PerpendicularSelection) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_PerpendicularSelection) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_PerpendicularSelection) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_PerpendicularSelection) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_RouterOperations) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_RouterOperations) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_RouterOperations) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_RouterOperations) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public event CreatbuNestedResultEventHandler Creat;

  public event OkCommandWithDataEventHandler DrawResult;

  public event OkCommandWithDataEventHandler Updated;

  public event ClickSenderDataEventHandler Command;
}
