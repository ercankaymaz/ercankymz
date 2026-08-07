// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.PanelCut.F_PanelCutMaterials
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Profile;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.PanelCut;

public class F_PanelCutMaterials : Form
{
  public ToolBase5 activeTool;
  public List<SelectedPlaneInfo> selectedPlanes;
  private Timer \u0001;
  private int \u0001;
  private bool \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal ImageList \u0003;
  internal ImageList \u0004;
  internal ImageList \u0005;
  internal ImageList \u0006;
  internal Panel \u0001;
  public Button btn_toolsettings;
  internal Button \u0001;
  internal Button \u0002;
  public ComboBox cmb_tools;
  internal Label \u0001;
  internal Button \u0003;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal Button \u0004;
  internal Button \u0005;
  internal CheckBox \u0003;
  public Panel pnl_model;
  internal ListView \u0001;
  internal PictureBox \u0001;
  public Button btn_camsettings;
  internal Panel \u0002;
  internal Label \u0002;
  public Button btn_free;
  internal Label \u0003;
  public Button btn_front;
  internal Label \u0004;
  public Button btn_back;
  internal Label \u0005;
  internal Label \u0006;
  public Button btn_top;
  public Button btn_bottom;
  public Button btn_ok;
  public Button btn_cancel;
  public DataGridView dgv_data;
  internal Label \u0007;
  internal Label \u0008;
  internal Label \u000E;

  public void Init()
  {
    ((F_ProfileAdd) this).Properties.Inited = false;
    if (((F_ProfileAdd) this).Properties.Height > 10)
      this.Height = ((F_ProfileAdd) this).Properties.Height;
    if (((F_ProfileAdd) this).Properties.Width > 10)
      this.Width = ((F_ProfileAdd) this).Properties.Width;
    this.TopMost = ((F_ProfileAdd) this).Properties.TopMost;
    this.StartPosition = ((F_ProfileAdd) this).Properties.FormPosition;
    ((F_ProfileAdd) this).spn_cutspace.Value = (Decimal) ((MarbleRuntimeSettings) ((F_ProfileAdd) this).Pattern).CutSpace;
    ((F_ProfileAdd) this).spn_count.Value = (Decimal) ((MarbleRuntimeSettings) ((F_ProfileAdd) this).Pattern).Count;
    ((F_ProfileAdd) this).spn_distance.Value = (Decimal) ((MarbleRuntimeSettings) ((F_ProfileAdd) this).Pattern).Distance;
    ((F_ProfileAdd) this).\u0001.Checked = ((F_ProfileAdd) this).ShowSeperators;
    ((F_ProfileAdd) this).Properties.Result = DialogResult.None;
    ((F_ProfileAdd) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_ProfileAdd.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ProfileAdd) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ProfileAdd) this).Properties.Result = DialogResult.Cancel;
    if (((F_ProfileAdd) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfileAdd) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ProfileAdd) this).btn_ok.Name)
    {
      if (!((F_ProfileAdd) this).Properties.Inited)
        return;
      if (((F_ProfileAdd) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfilePatternCopy) this);
      ((F_ProfileAdd) this).Properties.Result = DialogResult.OK;
      if (((F_ProfileAdd) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ProfileAdd) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_ProfileAdd) this).btn_cancel.Name))
      return;
    ((F_ProfileAdd) this).Properties.Result = DialogResult.Cancel;
    if (((F_ProfileAdd) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfileAdd) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfileAdd) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfileAdd) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_PanelCutMaterials() => F_ProfileAdd.Captions = new List<string>();

  public F_PanelCutMaterials()
  {
    ((F_ProfileAdd) this).PropertiesForm = new FormProperties();
    ((F_ProfileAdd) this).Plane = (SelectedPlaneInfo) new hmiUISettings();
    ((F_ProfileAdd) this).pntMinProfile = new Point3D();
    ((F_ProfileAdd) this).pntMaxProfile = new Point3D();
    ((F_ProfileAdd) this).VarUcs = (UCSObjectData) new buMatrix5();
    ((F_ProfileAdd) this).PlaneThinkness = 4.0;
    ((F_ProfileAdd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_PlaneList) this);
  }

  public void Init()
  {
    ((F_ProfileAdd) this).PropertiesForm.Inited = false;
    if (((F_ProfileAdd) this).PropertiesForm.Height > 10)
      this.Height = ((F_ProfileAdd) this).PropertiesForm.Height;
    if (((F_ProfileAdd) this).PropertiesForm.Width > 10)
      this.Width = ((F_ProfileAdd) this).PropertiesForm.Width;
    this.TopMost = ((F_ProfileAdd) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ProfileAdd) this).PropertiesForm.FormPosition;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PlaneList) this);
    ((F_ProfileAdd) this).PropertiesForm.Result = DialogResult.None;
    ((F_ProfileAdd) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }
}
