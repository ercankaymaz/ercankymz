// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Shape.F_DrillList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.SheetBending;
using devDept.Eyeshot.Control;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Shape;

public class F_DrillList : Form
{
  public Panel pnl_model;
  internal ImageList \u0001;
  internal ListView \u0001;
  internal ImageList \u0002;
  internal DataGridView \u0001;
  internal Panel \u0001;
  public Button btn_front;
  public Button btn_back;
  public Button btn_right;
  public Button btn_left;
  public Button btn_top;
  public Button btn_bottom;
  internal PictureBox \u0001;
  internal Button \u0001;
  public Button btn_camsettings;
  public Button btn_toolsettings;
  public ComboBox cmb_tools;
  internal Button \u0002;
  internal ImageList \u0003;
  internal ImageList \u0004;
  internal ImageList \u0005;
  internal ImageList \u0006;
  internal Button \u0003;
  internal CheckBox \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  public static byte f001249;
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
  public bool ClosePageAfterOk;
  public List<ToolBase5> Tools;
  public ToolBase5 activeTool;
  public buShape selectedShape;
  public camParameters5 CamPar;
  public ShapeRuntimeData parShape;
  private Timer \u0001;
  private int \u0001;
  private bool \u0001;
  internal IContainer \u0001;
  public Button btn_cancel;
  public Button btn_ok;

  public void Init()
  {
    ((F_ProfilingList) this).PropertiesForm.Inited = false;
    if (((F_ProfilingList) this).PropertiesForm.Height > 10)
      this.Height = ((F_ProfilingList) this).PropertiesForm.Height;
    if (((F_ProfilingList) this).PropertiesForm.Width > 10)
      this.Width = ((F_ProfilingList) this).PropertiesForm.Width;
    this.TopMost = ((F_ProfilingList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ProfilingList) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_ProfilingList) this).PropertiesForm.Result = DialogResult.None;
    ((F_ProfilingList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_ProfilingList) this).\u0001.Text = buLangTranslate.preDef.Simulation;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ProfilingList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ProfilingList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ProfilingList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfilingList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_CutList) this).\u0001.Visible = false;
    ((F_ProfilingList) this).timWarning.Enabled = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void Apply()
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    // ISSUE: reference to a compiler-generated field
    if (((F_ProfilingList) this).\u0001 == null)
      return;
    if (control.Name == ((F_ProfilingList) this).btn_start.Name)
    {
      if (((F_ProfilingList) this).spn_step.Value <= 0.0)
      {
        ((F_CutList) this).\u0001.Text = buLangTranslate.preSentences.SimuationStepisZero;
        ((F_CutList) this).\u0001.Visible = true;
        ((F_ProfilingList) this).timWarning.Enabled = true;
      }
      // ISSUE: reference to a compiler-generated field
      ((F_ProfilingList) this).\u0001((object) SimulationCommands.Start, (object) ((F_ProfilingList) this).spn_step.Value, (object) null);
    }
    if (control.Name == ((F_CutList) this).btn_stop.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_ProfilingList) this).\u0001((object) SimulationCommands.Stop, (object) ((F_ProfilingList) this).spn_step.Value, (object) null);
    }
    if (control.Name == ((F_CutList) this).btn_pause.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_ProfilingList) this).\u0001((object) SimulationCommands.Pause, (object) ((F_ProfilingList) this).spn_step.Value, (object) null);
    }
    if (control.Name == ((F_ProfilingList) this).btn_pre.Name)
    {
      if (((F_ProfilingList) this).spn_step.Value <= 0.0)
      {
        ((F_CutList) this).\u0001.Text = buLangTranslate.preSentences.SimuationStepisZero;
        ((F_CutList) this).\u0001.Visible = true;
        ((F_ProfilingList) this).timWarning.Enabled = true;
      }
      // ISSUE: reference to a compiler-generated field
      ((F_ProfilingList) this).\u0001((object) SimulationCommands.Previous, (object) ((F_ProfilingList) this).spn_step.Value, (object) null);
    }
    if (!(control.Name == ((F_ProfilingList) this).btn_next.Name))
      return;
    if (((F_ProfilingList) this).spn_step.Value <= 0.0)
    {
      ((F_CutList) this).\u0001.Text = buLangTranslate.preSentences.SimuationStepisZero;
      ((F_CutList) this).\u0001.Visible = true;
      ((F_ProfilingList) this).timWarning.Enabled = true;
    }
    // ISSUE: reference to a compiler-generated field
    ((F_ProfilingList) this).\u0001((object) SimulationCommands.Next, (object) ((F_ProfilingList) this).spn_step.Value, (object) null);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((F_ProfilingList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ProfilingList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfilingList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    // ISSUE: reference to a compiler-generated field
    if (((F_ProfilingList) this).\u0001 == null || !(control.Name == ((F_ProfilingList) this).spn_step.Name))
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_ProfilingList) this).\u0001((object) SimulationCommands.StepChanged, (object) ((F_ProfilingList) this).spn_step.Value, (object) null);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfilingList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfilingList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_DrillList() => F_ProfilingList.Captions = new List<string>();

  public F_DrillList()
  {
    ((F_CutList) this).PropertiesForm = new FormProperties();
    ((F_CutList) this).Sequence = FoamSequenceHor.HorizontalStartThenEnd;
    ((F_CutList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SheetBendData) this);
  }

  public void Init()
  {
    ((F_CutList) this).PropertiesForm.Inited = false;
    if (((F_CutList) this).PropertiesForm.Height > 10)
      this.Height = ((F_CutList) this).PropertiesForm.Height;
    if (((F_CutList) this).PropertiesForm.Width > 10)
      this.Width = ((F_CutList) this).PropertiesForm.Width;
    this.TopMost = ((F_CutList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_CutList) this).PropertiesForm.FormPosition;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_CutList) this).PropertiesForm.Result = DialogResult.None;
    ((F_CutList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_CutList.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CutList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CutList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CutList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_CutList) this).btn_ok.Name)
    {
      this.Apply();
      ((F_CutList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_CutList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!(control2.Name == ((F_CutList) this).btn_cancel.Name))
        return;
      ((F_CutList) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_CutList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_CutList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CutList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CutList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_DrillList() => F_CutList.Captions = new List<string>();

  public F_DrillList()
  {
    ((F_CutList) this).PropertiesForm = new FormProperties();
    ((F_CutList) this).ShowViewport = true;
    ((F_CutList) this).ShowCamSettings = true;
    ((F_CutList) this).ShowTool = false;
    ((F_CutList) this).ShowObjectPosition = true;
    ((F_CutList) this).ShowCornerLocation = true;
    ((F_CutList) this).EnableTopPlane = true;
    ((F_CutList) this).EnableBottomPlane = true;
    ((F_CutList) this).EnableLeftPlane = true;
    ((F_CutList) this).EnableRightPlane = true;
    ((F_CutList) this).EnableFrontPlane = true;
    ((F_CutList) this).EnableBacktPlane = true;
    ((F_CutList) this).ClosePageAfterOk = false;
    ((F_CutList) this).Tools = new List<ToolBase5>();
    ((F_CutList) this).activeTool = (ToolBase5) null;
    ((F_CutList) this).selectedShape = (buShape) null;
    ((F_CutList) this).CamPar = (camParameters5) null;
    ((F_CutList) this).parShape = (ShapeRuntimeData) new hmiUICommands();
    ((F_CutList) this).\u0001 = new Timer();
    ((F_CutList) this).\u0001 = -1;
    ((F_CutList) this).\u0001 = false;
    ((F_CutList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_JunctionList) this);
    ((F_CutList) this).\u0001.Interval = 100;
    ((F_CutList) this).\u0001.Tick += new EventHandler(((F_ShapeList) this).\u0001);
  }

  public event OkCommandWithTwoDataEventHandler DataOk;

  public event CancelCommandEventHandler DataCancel;
}
