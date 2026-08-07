// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestOnlineCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.DialogBox;
using devDept.Eyeshot.Control;
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

public class F_NestOnlineCalc : Form
{
  internal Label \u000F;
  internal ComboBox \u0003;
  internal Label \u0010;
  internal NumericUpDown \u0004;
  internal Label \u0011;
  internal CheckBox \u0002;
  internal Label \u0012;
  internal TextBox \u0002;
  internal Label \u0013;
  internal NumericUpDown \u0005;
  public static byte f000CC8;
  public FormProperties Properties;
  public static List<string> Captions;
  public MaterialBase5 Material;
  public Design viewportLayout;
  public string pathTool;
  private IContainer \u0001;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0002;
  internal TabPage \u0002;
  internal NumericUpDown \u0003;
  internal Label \u0003;
  internal TabPage \u0003;
  internal NumericUpDown \u0004;
  internal Label \u0004;
  internal NumericUpDown \u0005;
  internal Label \u0005;
  internal TabPage \u0004;
  internal NumericUpDown \u0006;
  internal Label \u0006;
  internal NumericUpDown \u0007;

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_RouterOperations) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_RouterOperations) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_RouterOperations) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_RouterOperations) this).\u0001, comparand - value, comparand);
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

  public F_NestOnlineCalc()
  {
    ((F_RouterOperations) this).Properties = new FormProperties();
    ((F_RouterOperations) this).Settings = (CopyEventFormVars) new SewingInfo();
    ((F_RouterOperations) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Copy) this);
  }

  public void Init()
  {
    ((F_RouterOperations) this).Properties.Inited = false;
    ((F_RouterOperations) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_RouterOperations) this).Properties.TopMost;
    this.StartPosition = ((F_RouterOperations) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_RouterOperations) this).Properties.ScaleFromMode;
    if (((F_RouterOperations) this).Properties.Height > 10)
      this.Height = ((F_RouterOperations) this).Properties.Height;
    if (((F_RouterOperations) this).Properties.Width > 10)
      this.Width = ((F_RouterOperations) this).Properties.Width;
    \u0007.\u0001.\u0001((F_Copy) this);
    ((F_RouterOperations) this).\u0001.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).CatchPoint.X;
    ((F_RouterOperations) this).\u0002.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).CatchPoint.Y;
    ((F_RouterOperations) this).\u0003.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).CatchPoint.Z;
    ((F_LayerRouter3X) this).\u0001.Checked = !((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).isCoordinateMode;
    ((F_RouterOperations) this).\u0003.Visible = ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).ShowZ;
    ((F_RouterOperations) this).\u0003.Visible = ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).ShowZ;
    ((F_LayerRouter3X) this).btn_aligment.Visible = ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).ShowAligment;
    ((F_RouterOperations) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_LayerRouter3X) this).btn_lefttop.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.TopLeft;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_left.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.MiddleLeft;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_leftbottom.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.BottomLeft;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_righttop.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.TopRight;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_right.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.MiddleRight;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_rightbottom.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.BottomRight;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_center.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.MiddleCenter;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_top.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.TopCenter;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_bottom.Name)
    {
      ((DeleteTypeEventFormVars) ((F_RouterOperations) this).Settings).Alignment = ContentAlignment.BottomCenter;
      \u0007.\u0001.\u0001((F_Copy) this);
      ((F_RouterOperations) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_RouterOperations) this).btn_ok.Name)
    {
      ((F_RouterOperations) this).Properties.Result = DialogResult.OK;
      \u0007.\u0001.\u0001((F_Copy) this);
      if (((F_RouterOperations) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_RouterOperations) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (((F_RouterOperations) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_RouterOperations) this).\u0001((object) new Pnt3D((double) ((F_RouterOperations) this).\u0001.Value, (double) ((F_RouterOperations) this).\u0002.Value, (double) ((F_RouterOperations) this).\u0003.Value));
      }
    }
    if (control2.Name == ((F_RouterOperations) this).btn_cancel.Name)
    {
      if (((F_RouterOperations) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_RouterOperations) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_RouterOperations) this).Properties.Result = DialogResult.Cancel;
      // ISSUE: reference to a compiler-generated field
      if (((F_RouterOperations) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_RouterOperations) this).\u0001();
      }
    }
    if (!(control2.Name == ((F_LayerRouter3X) this).btn_aligment.Name))
      return;
    ((F_RouterOperations) this).\u0002.Visible = true;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.Controls, result, obj1.Shift);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (!((F_RouterOperations) this).Properties.Inited || ((F_RouterOperations) this).\u0001 == null)
      return;
    \u0007.\u0001.\u0001((F_Copy) this);
    // ISSUE: reference to a compiler-generated field
    ((F_RouterOperations) this).\u0001((object) ((F_RouterOperations) this).Settings);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_RouterOperations) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RouterOperations) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestOnlineCalc() => F_RouterOperations.Captions = new List<string>();

  public F_NestOnlineCalc()
  {
    ((F_LayerRouter3X) this).PropertiesForm = new FormProperties();
    ((F_LayerRouter3X) this).ColorList = new List<Color>();
    ((F_LayerRouter3X) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0018.\u0002.\u0005.\u0001((F_ColorList) this);
  }

  public void Init()
  {
    ((F_LayerRouter3X) this).PropertiesForm.Inited = false;
    this.LoadLanguage();
    ((F_LayerRouter3X) this).PropertiesForm.Result = DialogResult.None;
    for (int index1 = 0; index1 <= this.Controls.Count - 1; ++index1)
    {
      if (this.Controls[index1] is Label && this.Controls[index1].Tag != null && buFile5.IsNumeric(this.Controls[index1].Tag.ToString()))
      {
        int index2 = int.Parse(this.Controls[index1].Tag.ToString());
        // ISSUE: reference to a compiler-generated field
        if (index2 >= 0 & index2 <= buVector5.\u0002.ColorList.Count - 1)
        {
          // ISSUE: reference to a compiler-generated field
          this.Controls[index1].BackColor = buVector5.\u0002.ColorList[index2];
          // ISSUE: reference to a compiler-generated field
          this.Controls[index1].ForeColor = buFile5.InvertColorNoGray(buVector5.\u0002.ColorList[index2]);
          // ISSUE: reference to a compiler-generated field
          this.Controls[index1].Text = buFile5.GetColorKnownName(buVector5.\u0002.ColorList[index2]);
        }
      }
    }
    ((F_LayerRouter3X) this).PropertiesForm.Inited = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_LayerRouter3X) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_LayerRouter3X) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_LayerRouter3X) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_LayerRouter3X) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_LayerRouter3X.Captions.Count < 33)
        return;
      this.Text = F_LayerRouter3X.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    if (obj0.GetType() == typeof (System.Windows.Forms.Control) | obj0.GetType() == typeof (Button))
    {
      control = (System.Windows.Forms.Control) obj0;
      string name = control.Name;
    }
    if (obj0.GetType() == typeof (ToolStripMenuItem))
    {
      string name1 = ((ToolStripItem) obj0).Name;
    }
    if (control.Name == ((F_LayerList) this).btn_ok.Name)
    {
      ((F_LayerRouter3X) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_LayerRouter3X) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_LayerRouter3X) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_LayerList) this).btn_cancel.Name))
      return;
    ((F_LayerRouter3X) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_LayerRouter3X) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_LayerRouter3X) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if ((control2.Tag == null ? 0 : (buFile5.IsNumeric(control2.Tag.ToString()) ? 1 : 0)) == 0)
      return;
    int index = int.Parse(control2.Tag.ToString());
    // ISSUE: reference to a compiler-generated field
    if (!(index >= 0 & index <= buVector5.\u0002.ColorList.Count - 1))
      return;
    // ISSUE: reference to a compiler-generated field
    ColorDialogBox.ShowDialog(buVector5.\u0002.ColorList[index]);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    // ISSUE: reference to a compiler-generated field
    buVector5.\u0002.ColorList[index] = ColorDialogBox.Color;
    control2.BackColor = ColorDialogBox.Color;
    control2.ForeColor = buFile5.InvertColorNoGray(control2.BackColor);
    control2.Text = buFile5.GetColorKnownName(control2.BackColor);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LayerRouter3X) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LayerRouter3X) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestOnlineCalc() => F_LayerRouter3X.Captions = new List<string>();

  public F_NestOnlineCalc()
  {
    ((F_LayerConvertToTufting) this).PropertiesForm = new FormProperties();
    ((F_LayerConvertToTufting) this).pathInit = Application.StartupPath;
    ((F_LayerConvertToTufting) this).imageOutput = (Image) null;
    ((F_LayerConvertToTufting) this).Settings = new RasterToVectorVar();
    ((F_LayerConvertToTufting) this).\u0001 = "";
    ((F_LayerConvertToTufting) this).\u0001 = new List<Color>();
    ((F_LayerConvertToTufting) this).\u0002 = new List<Color>();
    ((F_LayerConvertToTufting) this).\u0001 = (Image) null;
    ((F_LayerConvertToTufting) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ImageToVector) this);
  }

  public void Init()
  {
    ((F_LayerConvertToTufting) this).PropertiesForm.Inited = false;
    ((F_LayerTufting) this).\u0002.Value = (Decimal) ((F_LayerConvertToTufting) this).Settings.DPI;
    ((F_LayerTufting) this).\u0001.Value = (Decimal) ((F_LayerConvertToTufting) this).Settings.ColorToBWThreshold;
    ((F_LayerTufting) this).\u0004.Value = (Decimal) ((F_LayerConvertToTufting) this).Settings.SplineToleranca;
    ((F_LayerTufting) this).\u0003.Value = (Decimal) ((F_LayerConvertToTufting) this).Settings.SimplifyTolerance;
    ((F_NestPartAddV2) this).LoadLanguage();
    ((F_LayerConvertToTufting) this).PropertiesForm.Result = DialogResult.None;
    ((F_LayerConvertToTufting) this).PropertiesForm.Inited = false;
  }

  public event OkCommandWithDataEventHandler PreviewPressed;

  public event OkCommandWithDataEventHandler SendPressed;

  public event OkCommandWithDataEventHandler Applied;

  public event OkCommandEventHandler StopPressed;

  public event OkCommandEventHandler ClosedPressed;
}
