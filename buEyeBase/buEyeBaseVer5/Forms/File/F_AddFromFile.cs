// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.File.F_AddFromFile
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Foam;
using buEyeBaseVer5.Forms.GCode;
using buEyeBaseVer5.Forms.Holes;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.File;

public class F_AddFromFile : Form
{
  internal NumericUpDown \u0002;
  internal NumericUpDown \u0003;
  internal NumericUpDown \u0004;
  internal Label \u0004;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal Label \u0005;
  internal NumericUpDown \u0007;
  internal NumericUpDown \u0008;
  internal Label \u0006;
  internal NumericUpDown \u000E;
  internal NumericUpDown \u000F;
  internal Label \u0007;
  internal NumericUpDown \u0010;
  internal NumericUpDown \u0011;
  internal Label \u0008;
  internal NumericUpDown \u0012;
  internal NumericUpDown \u0013;
  internal Label \u000E;
  internal NumericUpDown \u0014;
  internal NumericUpDown \u0015;
  internal Label \u000F;
  internal NumericUpDown \u0016;
  internal Label \u0010;
  public static byte f0030FC;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<camRadiusFeed> RadiusFeedList;
  public List<camLengthFeed> LengthFeedList;
  public int SelectedRadiusRowSheet;
  public int SelectedLengthRowSheet;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal ImageList \u0003;
  internal DataGridView \u0001;
  internal DataGridView \u0002;
  public Button btn_addradius;
  public Button btn_addlength;
  public Button btn_removerad;
  public Button btn_removelen;
  public static byte f00310F;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<LengthCount> SliceList;
  private int \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;

  public F_AddFromFile()
  {
    ((F_FoamWaveForm) this).PropertiesForm = new FormProperties();
    ((F_FoamWaveForm) this).varCNC = (DrillCNCSettings) null;
    ((F_FoamWaveForm) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SlotSettings) this);
  }

  public void Init()
  {
    ((F_FoamWaveForm) this).PropertiesForm.Inited = false;
    if (((F_FoamWaveForm) this).PropertiesForm.Height > 10)
      this.Height = ((F_FoamWaveForm) this).PropertiesForm.Height;
    if (((F_FoamWaveForm) this).PropertiesForm.Width > 10)
      this.Width = ((F_FoamWaveForm) this).PropertiesForm.Width;
    this.TopMost = ((F_FoamWaveForm) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_FoamWaveForm) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    if (((F_FoamWaveForm) this).varCNC == null)
      ((F_FoamWaveForm) this).varCNC = (DrillCNCSettings) new buProfileCalc();
    ((F_FoamWaveForm) this).\u0002.Value = (Decimal) ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawCuttingSpeed;
    ((F_FoamWaveForm) this).\u0001.Value = (Decimal) ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawPlungeSpeed;
    ((F_FoamWaveForm) this).\u0003.Value = (Decimal) ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawRapidDistance;
    ((F_FoamWaveForm) this).\u0004.Value = (Decimal) ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawSafeDistance;
    ((F_FoamWaveForm) this).\u0001.Checked = ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawReverseDirection;
    ((F_FoamWaveForm) this).PropertiesForm.Result = DialogResult.None;
    ((F_FoamWaveForm) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_FoamWaveForm.Captions.Count >= 9)
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
    if (((F_FoamWaveForm) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_FoamWaveForm) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_FoamWaveForm) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_FoamWaveForm) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamWaveForm) this).btn_ok.Name)
    {
      this.Apply();
      ((F_FoamWaveForm) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_FoamWaveForm) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_FoamWaveForm) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!(control2.Name == ((F_FoamWaveForm) this).btn_cancel.Name))
        return;
      ((F_FoamWaveForm) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_FoamWaveForm) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_FoamWaveForm) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  public void Apply()
  {
    ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawCuttingSpeed = (double) ((F_FoamWaveForm) this).\u0002.Value;
    ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawPlungeSpeed = (double) ((F_FoamWaveForm) this).\u0001.Value;
    ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawRapidDistance = (double) ((F_FoamWaveForm) this).\u0003.Value;
    ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawSafeDistance = (double) ((F_FoamWaveForm) this).\u0004.Value;
    ((buNestingSheetSettings) ((F_FoamWaveForm) this).varCNC).SlotSawReverseDirection = ((F_FoamWaveForm) this).\u0001.Checked;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FoamWaveForm) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamWaveForm) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_AddFromFile() => F_FoamWaveForm.Captions = new List<string>();

  public F_AddFromFile()
  {
    ((F_FoamWaveForm) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_HolesTemp) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FoamWaveForm) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamWaveForm) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_AddFromFile()
  {
    ((F_AddImageFromFile) this).PropertiesForm = new FormProperties();
    ((F_AddImageFromFile) this).Converter = (GCodeConverter) new buFunctions();
    ((F_AddImageFromFile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_FoamGCodeConverter) this);
  }

  public void Init()
  {
    ((F_AddImageFromFile) this).PropertiesForm.Inited = false;
    if (((F_AddImageFromFile) this).PropertiesForm.Height > 10)
      this.Height = ((F_AddImageFromFile) this).PropertiesForm.Height;
    if (((F_AddImageFromFile) this).PropertiesForm.Width > 10)
      this.Width = ((F_AddImageFromFile) this).PropertiesForm.Width;
    this.TopMost = ((F_AddImageFromFile) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_AddImageFromFile) this).PropertiesForm.FormPosition;
    this.\u0008.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).AMultiply;
    this.\u000F.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).BMultiply;
    this.\u0011.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).CMultiply;
    ((F_AddImageFromFile) this).\u0001.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).XMultiply;
    this.\u0004.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).YMultiply;
    this.\u0006.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).ZMultiply;
    this.\u0015.Value = (Decimal) ((MacroItem) ((F_AddImageFromFile) this).Converter).SMultiply;
    this.\u0013.Value = (Decimal) ((MacroItem) ((F_AddImageFromFile) this).Converter).FMultiply;
    this.\u0007.Value = (Decimal) ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).AOffset;
    this.\u000E.Value = (Decimal) ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).BOffset;
    this.\u0010.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).COffset;
    this.\u0002.Value = (Decimal) ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).XOffset;
    this.\u0003.Value = (Decimal) ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).YOffset;
    this.\u0005.Value = (Decimal) ((hmiUIDataGridView) ((F_AddImageFromFile) this).Converter).ZOffset;
    this.\u0012.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).FOffset;
    this.\u0014.Value = (Decimal) ((UCSObjectData) ((F_AddImageFromFile) this).Converter).SOffset;
    this.\u0016.Value = (Decimal) ((MacroItem) ((F_AddImageFromFile) this).Converter).FilterLength;
    this.LoadLanguage();
    ((F_AddImageFromFile) this).PropertiesForm.Result = DialogResult.None;
    ((F_AddImageFromFile) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_AddImageFromFile.Captions.Count >= 9)
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

  public event OkCommandWithTwoDataEventHandler ReadFile;
}
