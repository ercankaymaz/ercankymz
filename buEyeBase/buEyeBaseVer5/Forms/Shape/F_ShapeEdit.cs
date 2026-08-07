// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Shape.F_ShapeEdit
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Simulation;
using buEyeBaseVer5.Forms.Text;
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
namespace buEyeBaseVer5.Forms.Shape;

public class F_ShapeEdit : Form
{
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
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  internal CheckBox \u0001;
  public static byte f00120D;
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
  private System.Windows.Forms.Timer \u0001;
  private int \u0001;
  private bool \u0001;
  internal IContainer \u0001;
  public Button btn_cancel;
  public Button btn_ok;

  public F_ShapeEdit()
  {
    ((F_ProfilingList) this).Properties = new FormProperties();
    ((F_ProfilingList) this).TextHeight = 50.0;
    ((F_ProfilingList) this).TextString = "ABC";
    ((F_ProfilingList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_TextWireframe) this);
  }

  public void Init()
  {
    ((F_ProfilingList) this).Properties.Inited = false;
    if (((F_ProfilingList) this).Properties.Height > 10)
      this.Height = ((F_ProfilingList) this).Properties.Height;
    if (((F_ProfilingList) this).Properties.Width > 10)
      this.Width = ((F_ProfilingList) this).Properties.Width;
    this.TopMost = ((F_ProfilingList) this).Properties.TopMost;
    this.StartPosition = ((F_ProfilingList) this).Properties.FormPosition;
    ((F_ProfilingList) this).Properties.Result = DialogResult.None;
    ((F_ProfilingList) this).Properties.Inited = true;
    ((F_ProfilingList) this).\u0001.Text = ((F_ProfilingList) this).TextString;
    ((F_ProfilingList) this).spn_textheight.Value = ((F_ProfilingList) this).TextHeight;
    \u0007.\u0001.\u0001((F_TextWireframe) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ProfilingList) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ProfilingList) this).Properties.Result = DialogResult.Cancel;
    if (((F_ProfilingList) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfilingList) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
      System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
      if (control2.Name == ((F_ProfilingList) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_TextWireframe) this);
        ((F_ProfilingList) this).Properties.Result = DialogResult.OK;
        if (((F_ProfilingList) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ProfilingList) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_ProfilingList) this).btn_cancel.Name | control2.Name == ((F_ProfilingList) this).\u0001.Name))
        return;
      ((F_ProfilingList) this).Properties.Result = DialogResult.Cancel;
      if (((F_ProfilingList) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfilingList) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfilingList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfilingList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ShapeEdit() => F_ProfilingList.Captions = new List<string>();

  public F_ShapeEdit()
  {
    ((F_ProfilingList) this).timWarning = (System.Windows.Forms.Timer) null;
    ((F_ProfilingList) this).PropertiesForm = new FormProperties();
    ((F_ProfilingList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SimulationPanel) this);
    ((F_ProfilingList) this).timWarning = new System.Windows.Forms.Timer();
    ((F_ProfilingList) this).timWarning.Tick += new EventHandler(((F_DrillList) this).\u0001);
    ((F_ProfilingList) this).timWarning.Interval = 800;
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_ProfilingList) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_ProfilingList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_ProfilingList) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_ProfilingList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
