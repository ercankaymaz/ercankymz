// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestPartAdd
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_NestPartAdd : Form
{
  internal NumericUpDown \u0002;
  internal Label \u0004;
  internal NumericUpDown \u0003;
  internal Label \u0005;
  internal NumericUpDown \u0004;
  public Button btn_open;
  public Button btn_save;
  internal Panel \u0002;
  public Button btn_sim;
  public Button btn_clear;
  internal NumericUpDown \u0005;
  internal Label \u0006;
  public static byte f000E58;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<LaserMaterialData> MaterialOrders;
  public string pathCf2File;
  public string fileCf2SettingsName;
  public string strRemoveCaption;
  public int SelectedMaterialIndex;
  public int DirType;
  private bool \u0001;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_down;
  public Button btn_up;
  internal ImageList \u0002;
  internal CheckedListBox \u0001;
  public static byte f000E6A;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<LaserMaterial> Materials;
  public List<Cf2FileProperties> Cf2Properties;
  public string pathMaterialFile;
  public string strRemoveCaption;
  public int SelectedMaterialIndex;
  public int DirType;
  public bool EditMode;
  private bool \u0001;
  internal IContainer \u0001;
  internal ListBox \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;

  public F_NestPartAdd()
  {
    ((F_PanelCutNestSheetPartList) this).PropertiesForm = new FormProperties();
    ((F_PanelCutNestSheetPartList) this).NestedResultList = new List<string>();
    ((F_PanelCutNestSheetPartList) this).selectedItem = "";
    ((F_PanelCutNestSheetPartList) this).JobFolder = Application.StartupPath;
    ((F_PanelCutNestSheetPartList) this).FileExtension = "bunesting";
    ((F_PanelCutNestSheetPartList) this).Settings = (buNestingVar) new ProfileOperationDataBarel();
    ((F_PanelCutNestSheetPartList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_NestOldResult) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_PreviewPressed(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_PanelCutNestSheetPartList) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_PanelCutNestSheetPartList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_PreviewPressed(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_PanelCutNestSheetPartList) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_PanelCutNestSheetPartList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_PanelCutNestSheetPartList) this).PropertiesForm.Inited = false;
    this.LoadLanguage();
    ((F_PanelCutNestSheetPartList) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((F_PanelCutNestSheetPartList) this).NestedResultList.Count - 1; ++index)
      ((F_PanelCutNestSheetPartList) this).\u0001.Items.Add((object) ((F_PanelCutNestSheetPartList) this).NestedResultList[index]);
    ((F_PanelCutNestSheetPartList) this).\u0001.Checked = ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestedResult;
    ((F_PanelCutNestSheetPartList) this).\u0003.Checked = ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestingParts;
    ((F_PanelCutNestSheetPartList) this).\u0002.Checked = ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestingSheets;
    ((F_PanelCutNestSheetPartList) this).\u0004.Checked = ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestingClearParts;
    ((F_PanelCutNestSheetPartList) this).\u0005.Checked = ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestingClearSheets;
    if (((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultLocation == nestOldResultPosition.ToJob)
    {
      ((F_PanelCutNestSheetPartList) this).\u0002.Checked = true;
      ((F_PanelCutNestSheetPartList) this).\u0001.Checked = false;
    }
    else
    {
      ((F_PanelCutNestSheetPartList) this).\u0002.Checked = false;
      ((F_PanelCutNestSheetPartList) this).\u0001.Checked = true;
    }
    ((F_PanelCutNestSheetPartList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestOnlineCalculation LoadLanguage";
    try
    {
      if (F_PanelCutNestSheetPartList.Captions.Count < 6)
        return;
      this.Text = F_PanelCutNestSheetPartList.Captions[0];
      ((F_PanelCutNestSheetPartList) this).\u0001.Text = F_PanelCutNestSheetPartList.Captions[1];
      ((F_PanelCutNestSheetPartList) this).\u0002.Text = F_PanelCutNestSheetPartList.Captions[2];
      ((F_PanelCutNestSheetPartList) this).\u0004.Text = F_PanelCutNestSheetPartList.Captions[3];
      ((F_PanelCutNestSheetPartList) this).\u0001.Text = F_PanelCutNestSheetPartList.Captions[4];
      ((F_PanelCutNestSheetPartList) this).\u0006.Text = F_PanelCutNestSheetPartList.Captions[5];
      ((F_PanelCutNestSheetPartList) this).\u0002.Text = F_PanelCutNestSheetPartList.Captions[6];
      ((F_PanelCutNestSheetPartList) this).\u0005.Text = F_PanelCutNestSheetPartList.Captions[7];
      ((F_PanelCutNestSheetPartList) this).\u0005.Text = F_PanelCutNestSheetPartList.Captions[8];
      ((F_PanelCutNestSheetPartList) this).\u0003.Text = F_PanelCutNestSheetPartList.Captions[9];
      ((F_PanelCutNestSheetPartList) this).\u0004.Text = F_PanelCutNestSheetPartList.Captions[10];
      ((F_PanelCutNestSheetPartList) this).\u0003.Text = F_PanelCutNestSheetPartList.Captions[11];
      ((F_PanelCutNestSheetPartList) this).\u0001.Text = F_PanelCutNestSheetPartList.Captions[12];
      ((F_PanelCutNestSheetPartList) this).\u0002.Text = F_PanelCutNestSheetPartList.Captions[13];
      ((F_PanelCutNestSheetPartList) this).btn_preview.Text = F_PanelCutNestSheetPartList.Captions[14];
      ((F_PanelCutNestSheetPartList) this).btn_select.Text = F_PanelCutNestSheetPartList.Captions[15];
      ((F_PanelCutNestSheetPartList) this).btn_close.Text = F_PanelCutNestSheetPartList.Captions[16 /*0x10*/];
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
    if (((F_PanelCutNestSheetPartList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_PanelCutNestSheetPartList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_PanelCutNestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_PanelCutNestSheetPartList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_PanelCutNestSheetPartList) this).btn_select.Name)
    {
      ((F_PanelCutNestSheetPartList) this).selectedItem = ((F_PanelCutNestSheetPartList) this).\u0001.Items[((F_PanelCutNestSheetPartList) this).\u0001.SelectedIndex].ToString();
      ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestedResult = ((F_PanelCutNestSheetPartList) this).\u0001.Checked;
      ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestingParts = ((F_PanelCutNestSheetPartList) this).\u0003.Checked;
      ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestingSheets = ((F_PanelCutNestSheetPartList) this).\u0002.Checked;
      ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestingClearParts = ((F_PanelCutNestSheetPartList) this).\u0004.Checked;
      ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultImportNestingClearSheets = ((F_PanelCutNestSheetPartList) this).\u0005.Checked;
      if (((F_PanelCutNestSheetPartList) this).\u0002.Checked)
        ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultLocation = nestOldResultPosition.ToJob;
      else
        ((ProfileTempVars) ((ProfileMultiply) ((F_PanelCutNestSheetPartList) this).Settings).Runtime).OldResultLocation = nestOldResultPosition.ToDrawing;
      ((F_PanelCutNestSheetPartList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_PanelCutNestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_PanelCutNestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_PanelCutNestSheetPartList) this).btn_close.Name)
    {
      ((F_PanelCutNestSheetPartList) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_PanelCutNestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_PanelCutNestSheetPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == ((F_PanelCutNestSheetPartList) this).btn_preview.Name) || ((F_PanelCutNestSheetPartList) this).\u0001 == null || !(((F_PanelCutNestSheetPartList) this).\u0001.SelectedIndex >= 0 & ((F_PanelCutNestSheetPartList) this).\u0001.Items.Count > 0))
      return;
    ((F_PanelCutNestSheetPartList) this).selectedItem = $"{((F_PanelCutNestSheetPartList) this).JobFolder}\\{((F_PanelCutNestSheetPartList) this).\u0001.Items[((F_PanelCutNestSheetPartList) this).\u0001.SelectedIndex].ToString()}.{((F_PanelCutNestSheetPartList) this).FileExtension}";
    // ISSUE: reference to a compiler-generated field
    ((F_PanelCutNestSheetPartList) this).\u0001((object) ((F_PanelCutNestSheetPartList) this).selectedItem);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_PanelCutNestSheetPartList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_PanelCutNestSheetPartList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestPartAdd() => F_PanelCutNestSheetPartList.Captions = new List<string>();

  public F_NestPartAdd()
  {
    ((F_PanelCutNestSheetPartList) this).PropertiesForm = new FormProperties();
    ((F_BendingRotaryDisk) this).SettingsPar = (buNestingVar) new ProfileOperationDataBarel();
    ((F_BendingRotaryDisk) this).SelectedResultIndex = 0;
    ((F_BendingRotaryDisk) this).SelectedSheetIndex = 0;
    ((F_BendingRotaryDisk) this).SelectedPartIndex = 0;
    ((F_BendingRotaryDisk) this).\u0001 = "";
    ((F_BendingRotaryDisk) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_NestOnlineCalc) this);
  }
}
