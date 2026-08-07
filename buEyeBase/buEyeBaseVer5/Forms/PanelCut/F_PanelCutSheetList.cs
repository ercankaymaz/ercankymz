// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.PanelCut.F_PanelCutSheetList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot.Control;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.PanelCut;

public class F_PanelCutSheetList : Form
{
  internal Label \u000F;
  internal NumericUpDown \u0003;
  internal Label \u0010;
  internal Label \u0011;
  internal NumericUpDown \u0004;
  internal Label \u0012;
  internal Button \u000E;
  internal Label \u0013;
  internal NumericUpDown \u0005;
  internal Label \u0014;
  internal NumericUpDown \u0006;
  internal NumericUpDown \u0007;
  internal Label \u0015;
  internal NumericUpDown \u0008;
  internal Label \u0016;
  internal Label \u0017;
  public DataGridView grid_files;
  internal Panel \u0004;
  internal CheckBox \u0001;
  internal Label \u0018;
  internal NumericUpDown \u000E;
  internal NumericUpDown \u000F;
  internal NumericUpDown \u0010;
  internal Label \u0019;
  internal CheckBox \u0002;
  internal NumericUpDown \u0011;
  internal Label \u001A;
  internal NumericUpDown \u0012;
  internal Label \u001B;
  internal Panel \u0005;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Button \u000F;
  internal Button \u0010;
  internal Button \u0011;
  internal Button \u0012;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal CheckBox \u0003;
  internal NumericUpDown \u0013;
  internal Label \u001C;
  internal NumericUpDown \u0014;
  internal Label \u001D;
  internal CheckBox \u0004;
  internal PictureBox \u0003;
  internal TextBox \u0004;
  internal PictureBox \u0004;
  public static byte f00185B;
  public FormProperties PropertiesForm;
  public Design viewportLayout;
  public static List<string> Captions;
  public bool ShowViewport;
  public bool ShowCamSettings;
  public bool ShowTool;
  public bool ShowObjectPosition;
  public bool ShowCornerLocation;
  public bool EnableTopPlane;
  public bool EnableBottomPlane;
  public bool EnableFrontPlane;
  public bool EnableBackPlane;
  public bool EnableFreePlane;
  public bool ClosePageAfterOk;
  public bool CellFirstSelected;
  public List<ToolBase5> Tools;

  public void Init()
  {
    ((F_ProfileAdd) this).Properties.Inited = false;
    if (((F_ProfileAdd) this).Properties.Height > 10)
      this.Height = ((F_ProfileAdd) this).Properties.Height;
    if (((F_ProfileAdd) this).Properties.Width > 10)
      this.Width = ((F_ProfileAdd) this).Properties.Width;
    this.TopMost = ((F_ProfileAdd) this).Properties.TopMost;
    this.StartPosition = ((F_ProfileAdd) this).Properties.FormPosition;
    ((F_ProfileAdd) this).spn_circularangle.Value = (Decimal) ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).CircularAngle;
    ((F_ProfileAdd) this).spn_circularcount.Value = (Decimal) ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).CircularCount;
    ((F_ProfileAdd) this).spn_linearcount.Value = (Decimal) ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).LineerXCount;
    ((F_ProfileAdd) this).spn_linearlen.Value = (Decimal) ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).LineerXDistance;
    ((F_ProfileAdd) this).chk_circular.Checked = ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).CircularEnable;
    ((F_ProfileAdd) this).chk_lineer.Checked = ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).LineerEnable;
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
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_ProfileAdd) this).btn_ok.Name)
    {
      if (!((F_ProfileAdd) this).Properties.Inited)
        return;
      if (((F_ProfileAdd) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_ProfileArrayCircular) this);
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

  static F_PanelCutSheetList() => F_ProfileAdd.Captions = new List<string>();

  public F_PanelCutSheetList()
  {
    ((F_ProfileAdd) this).Properties = new FormProperties();
    ((F_ProfileAdd) this).OperationData = (ProfileOperationData) new buMarbleCalc();
    ((F_ProfileAdd) this).CircularArrayVisible = false;
    ((F_ProfileAdd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfileArray) this);
  }

  public void Init()
  {
    ((F_ProfileAdd) this).Properties.Inited = false;
    if (((F_ProfileAdd) this).Properties.Height > 10)
      this.Height = ((F_ProfileAdd) this).Properties.Height;
    if (((F_ProfileAdd) this).Properties.Width > 10)
      this.Width = ((F_ProfileAdd) this).Properties.Width;
    this.TopMost = ((F_ProfileAdd) this).Properties.TopMost;
    this.StartPosition = ((F_ProfileAdd) this).Properties.FormPosition;
    ((F_ProfileAdd) this).spn_linearYcount.Value = (Decimal) ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).LineerYCount;
    ((F_ProfileAdd) this).spn_linearYlen.Value = (Decimal) ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).LineerYDistance;
    ((F_ProfileAdd) this).spn_linearXcount.Value = (Decimal) ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).LineerXCount;
    ((F_ProfileAdd) this).spn_linearXlen.Value = (Decimal) ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).LineerXDistance;
    ((F_ProfileAdd) this).chk_lineer.Checked = ((ShapeRuntimeData) ((DepthPositionOptions) ((F_ProfileAdd) this).OperationData).Array).LineerEnable;
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
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_ProfileAdd) this).btn_ok.Name)
    {
      if (!((F_ProfileAdd) this).Properties.Inited)
        return;
      if (((F_ProfileAdd) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_ProfileArray) this);
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

  static F_PanelCutSheetList() => F_ProfileAdd.Captions = new List<string>();

  public F_PanelCutSheetList()
  {
    ((F_ProfileAdd) this).Properties = new FormProperties();
    ((F_ProfileAdd) this).Pattern = (ProfilePatternCopy) new MarbleCountertopSettings();
    ((F_ProfileAdd) this).ShowSeperators = true;
    ((F_ProfileAdd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0018.\u0002.\u0001.\u0001((F_ProfilePatternCopy) this);
  }
}
