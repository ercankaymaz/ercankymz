// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Shape.F_ShapeAll
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.UserFiles.buCad;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Viewport;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Shape;

public class F_ShapeAll : Form
{
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
  public static byte f0011D1;
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
  public Entity entMesh;
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
  public Panel pnl_model;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal DataGridView \u0001;
  internal Panel \u0001;
  public Button btn_front;
  public Button btn_back;
  public Button btn_right;

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_EngraveList.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_EngraveList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_EngraveList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ShapeAll() => F_EngraveList.Captions = new List<string>();

  public F_ShapeAll()
  {
    ((F_EngraveList) this).PropertiesForm = new FormProperties();
    ((F_EngraveList) this).Settings = new setMouse();
    ((F_ProfilingList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ViewportMouseCfg) this);
  }

  public void Init()
  {
    ((F_EngraveList) this).PropertiesForm.Inited = false;
    if (((F_EngraveList) this).PropertiesForm.Height > 10)
      this.Height = ((F_EngraveList) this).PropertiesForm.Height;
    if (((F_EngraveList) this).PropertiesForm.Width > 10)
      this.Width = ((F_EngraveList) this).PropertiesForm.Width;
    this.TopMost = ((F_EngraveList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_EngraveList) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    if (((F_EngraveList) this).Settings.ZoomConfigration.Button == mouseButtons.Left)
      ((F_ProfilingList) this).\u0003.Checked = true;
    else if (((F_EngraveList) this).Settings.ZoomConfigration.Button == mouseButtons.Right)
      ((F_ProfilingList) this).\u0001.Checked = true;
    else
      ((F_ProfilingList) this).\u0002.Checked = true;
    if (((F_EngraveList) this).Settings.ZoomConfigration.Key == buClass.modifierKeys.Shift)
      ((F_ProfilingList) this).\u0005.Checked = true;
    else if (((F_EngraveList) this).Settings.ZoomConfigration.Key == buClass.modifierKeys.Ctrl)
      ((F_ProfilingList) this).\u0004.Checked = true;
    else
      ((F_ProfilingList) this).\u0006.Checked = true;
    if (((F_EngraveList) this).Settings.PanConfigration.Button == mouseButtons.Left)
      ((F_ProfilingList) this).\u0011.Checked = true;
    else if (((F_EngraveList) this).Settings.PanConfigration.Button == mouseButtons.Right)
      ((F_ProfilingList) this).\u000F.Checked = true;
    else
      ((F_ProfilingList) this).\u0010.Checked = true;
    if (((F_EngraveList) this).Settings.PanConfigration.Key == buClass.modifierKeys.Shift)
      ((F_ProfilingList) this).\u0008.Checked = true;
    else if (((F_EngraveList) this).Settings.PanConfigration.Key == buClass.modifierKeys.Ctrl)
      ((F_ProfilingList) this).\u0007.Checked = true;
    else
      ((F_ProfilingList) this).\u000E.Checked = true;
    if (((F_EngraveList) this).Settings.RotateConfigration.Button == mouseButtons.Left)
      ((F_ProfilingList) this).\u0017.Checked = true;
    else if (((F_EngraveList) this).Settings.RotateConfigration.Button == mouseButtons.Right)
      ((F_ProfilingList) this).\u0015.Checked = true;
    else
      ((F_ProfilingList) this).\u0016.Checked = true;
    if (((F_EngraveList) this).Settings.RotateConfigration.Key == buClass.modifierKeys.Shift)
      ((F_ProfilingList) this).\u0013.Checked = true;
    else if (((F_EngraveList) this).Settings.RotateConfigration.Key == buClass.modifierKeys.Ctrl)
      ((F_ProfilingList) this).\u0012.Checked = true;
    else
      ((F_ProfilingList) this).\u0014.Checked = true;
    ((F_EngraveList) this).PropertiesForm.Result = DialogResult.None;
    ((F_EngraveList) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_EngraveList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_EngraveList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_EngraveList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_EngraveList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_ProfilingList.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (control.Name == ((F_ProfilingList) this).\u0001.Name)
    {
      if (((F_ProfilingList) this).\u000E.Checked)
      {
        if (((F_ProfilingList) this).\u0011.Checked)
        {
          buNumeric5.MessageBoxWarning($"{buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible} {buLangTranslate.preDef.Pan} {buLangTranslate.preDef.None} + {buLangTranslate.preDef.Left}");
          return;
        }
        if (((F_ProfilingList) this).\u000F.Checked)
        {
          buNumeric5.MessageBoxWarning($"{buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible} {buLangTranslate.preDef.Pan} {buLangTranslate.preDef.None} + {buLangTranslate.preDef.Right}");
          return;
        }
      }
      if (((F_ProfilingList) this).\u0006.Checked)
      {
        if (((F_ProfilingList) this).\u0003.Checked)
        {
          buNumeric5.MessageBoxWarning($"{buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible} {buLangTranslate.preDef.Zoom} {buLangTranslate.preDef.None} + {buLangTranslate.preDef.Left}");
          return;
        }
        if (((F_ProfilingList) this).\u0001.Checked)
        {
          buNumeric5.MessageBoxWarning($"{buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible} {buLangTranslate.preDef.Zoom} {buLangTranslate.preDef.None} + {buLangTranslate.preDef.Right}");
          return;
        }
      }
      if (((F_ProfilingList) this).\u0014.Checked)
      {
        if (((F_ProfilingList) this).\u0017.Checked)
        {
          buNumeric5.MessageBoxWarning($"{buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible} {buLangTranslate.preDef.Rotate} {buLangTranslate.preDef.None} + {buLangTranslate.preDef.Left}");
          return;
        }
        if (((F_ProfilingList) this).\u0015.Checked)
        {
          buNumeric5.MessageBoxWarning($"{buLangTranslate.preSentences.ThisMouseConfigrationIsNotPossible} {buLangTranslate.preDef.Rotate} {buLangTranslate.preDef.None} + {buLangTranslate.preDef.Right}");
          return;
        }
      }
      this.Apply();
      ((F_EngraveList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_EngraveList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EngraveList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_ProfilingList) this).\u0002.Name))
      return;
    ((F_EngraveList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_EngraveList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_EngraveList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    if (((F_ProfilingList) this).\u0003.Checked)
      ((F_EngraveList) this).Settings.ZoomConfigration.Button = mouseButtons.Left;
    else if (((F_ProfilingList) this).\u0001.Checked)
      ((F_EngraveList) this).Settings.ZoomConfigration.Button = mouseButtons.Right;
    else if (((F_ProfilingList) this).\u0003.Checked)
      ((F_EngraveList) this).Settings.ZoomConfigration.Button = mouseButtons.Middle;
    if (((F_ProfilingList) this).\u0005.Checked)
      ((F_EngraveList) this).Settings.ZoomConfigration.Key = buClass.modifierKeys.Shift;
    else if (((F_ProfilingList) this).\u0004.Checked)
      ((F_EngraveList) this).Settings.ZoomConfigration.Key = buClass.modifierKeys.Ctrl;
    else if (((F_ProfilingList) this).\u0006.Checked)
      ((F_EngraveList) this).Settings.ZoomConfigration.Key = buClass.modifierKeys.None;
    if (((F_ProfilingList) this).\u0011.Checked)
      ((F_EngraveList) this).Settings.PanConfigration.Button = mouseButtons.Left;
    else if (((F_ProfilingList) this).\u000F.Checked)
      ((F_EngraveList) this).Settings.PanConfigration.Button = mouseButtons.Right;
    else if (((F_ProfilingList) this).\u0011.Checked)
      ((F_EngraveList) this).Settings.PanConfigration.Button = mouseButtons.Middle;
    if (((F_ProfilingList) this).\u0008.Checked)
      ((F_EngraveList) this).Settings.PanConfigration.Key = buClass.modifierKeys.Shift;
    else if (((F_ProfilingList) this).\u0007.Checked)
      ((F_EngraveList) this).Settings.PanConfigration.Key = buClass.modifierKeys.Ctrl;
    else if (((F_ProfilingList) this).\u000E.Checked)
      ((F_EngraveList) this).Settings.PanConfigration.Key = buClass.modifierKeys.None;
    if (((F_ProfilingList) this).\u0017.Checked)
      ((F_EngraveList) this).Settings.RotateConfigration.Button = mouseButtons.Left;
    else if (((F_ProfilingList) this).\u0015.Checked)
      ((F_EngraveList) this).Settings.RotateConfigration.Button = mouseButtons.Right;
    else if (((F_ProfilingList) this).\u0017.Checked)
      ((F_EngraveList) this).Settings.RotateConfigration.Button = mouseButtons.Middle;
    if (((F_ProfilingList) this).\u0013.Checked)
      ((F_EngraveList) this).Settings.RotateConfigration.Key = buClass.modifierKeys.Shift;
    else if (((F_ProfilingList) this).\u0012.Checked)
    {
      ((F_EngraveList) this).Settings.RotateConfigration.Key = buClass.modifierKeys.Ctrl;
    }
    else
    {
      if (!((F_ProfilingList) this).\u0014.Checked)
        return;
      ((F_EngraveList) this).Settings.RotateConfigration.Key = buClass.modifierKeys.None;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfilingList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfilingList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ShapeAll() => F_ProfilingList.Captions = new List<string>();
}
