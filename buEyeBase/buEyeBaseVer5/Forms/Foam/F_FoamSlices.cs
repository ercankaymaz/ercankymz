// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Foam.F_FoamSlices
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.GCode;
using buEyeBaseVer5.Forms.Holes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamSlices : Form
{
  public DrillRuntimeSettings settingRuntime;
  public DrillJob Job;
  public DrillCNCSettings settingCNC;
  public static List<string> Captions;
  [CompilerGenerated]
  internal OkCommandWithTwoDataEventHandler \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal Label \u0001;
  internal Label \u0002;
  internal Panel \u0001;
  public Button btn_top;
  public Button btn_bottom;
  internal Label \u0003;
  internal NumericUpDown \u0001;
  internal Label \u0004;
  internal NumericUpDown \u0002;
  public static byte f002FCD;
  public FormProperties PropertiesForm;
  public drillCommands Commands;
  public drillCommandBase CommandsBase;
  public static List<string> Captions;
  private Timer \u0001;
  private IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  public static byte f002FD7;
  public FormProperties PropertiesForm;
  public drillCommands Commands;
  public drillCommandBase CommandsBase;
  public static List<string> Captions;
  private Timer \u0001;
  private IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  public static byte f002FE3;
  public FormProperties PropertiesForm;
  public drillCommands Commands;
  public drillCommandBase CommandsBase;
  public static List<string> Captions;
  private Timer \u0001;
  private IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  public static byte f002FEF;
  public FormProperties PropertiesForm;

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_HolesTemp.Captions.Count >= 9)
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
    if (((F_HolesTemp) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_HolesTemp) this).btn_ok.Name)
    {
      this.Apply();
      ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!(control2.Name == ((F_HolesTemp) this).btn_cancel.Name))
        return;
      ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_HolesTemp) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_HolesTemp) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FoamSlices() => F_HolesTemp.Captions = new List<string>();

  public F_FoamSlices()
  {
    ((F_HolesTemp) this).PropertiesForm = new FormProperties();
    ((F_HolesTemp) this).Settings = (DrillRuntimeSettings) new buProfileCalc();
    ((F_HolesTemp) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_CabinetSettings) this);
  }

  public void Init()
  {
    ((F_HolesTemp) this).PropertiesForm.Inited = false;
    if (((F_HolesTemp) this).PropertiesForm.Height > 10)
      this.Height = ((F_HolesTemp) this).PropertiesForm.Height;
    if (((F_HolesTemp) this).PropertiesForm.Width > 10)
      this.Width = ((F_HolesTemp) this).PropertiesForm.Width;
    this.TopMost = ((F_HolesTemp) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_HolesTemp) this).PropertiesForm.FormPosition;
    if (((buNestingVar) ((F_HolesTemp) this).Settings).ErpFileType == drillErpFileType.Cabinet)
      ((F_FoamGCodeConverter) this).\u0001.SelectedIndex = 0;
    else if (((buNestingVar) ((F_HolesTemp) this).Settings).ErpFileType == drillErpFileType.Corpus)
      ((F_FoamGCodeConverter) this).\u0001.SelectedIndex = 1;
    else if (((buNestingVar) ((F_HolesTemp) this).Settings).ErpFileType == drillErpFileType.Cyncly)
      ((F_FoamGCodeConverter) this).\u0001.SelectedIndex = 2;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_FoamGCodeConverter) this).\u0001.Text = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetReferanceKey;
    ((F_FoamGCodeConverter) this).\u0005.Text = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetAutoFileExtension;
    ((F_FoamGCodeConverter) this).\u0002.Text = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathImport;
    ((F_FoamGCodeConverter) this).\u0003.Text = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathExport;
    ((F_FoamGCodeConverter) this).\u0004.Text = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathDeleted;
    ((F_FoamGCodeConverter) this).\u0002.Checked = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetShowInfo;
    ((F_FoamGCodeConverter) this).\u0001.Checked = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetSubFolder;
    ((F_FoamGCodeConverter) this).\u0004.Checked = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetMirrorIfNoClamperSideAvailable;
    ((F_FoamGCodeConverter) this).\u0003.Checked = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetMirrorIfSlotClamperSide;
    ((F_FoamGCodeConverter) this).\u0005.Checked = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetAutoCycleDeleteAndMove;
    ((F_FoamGCodeConverter) this).\u0002.Value = (Decimal) ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetAutoCycleTickDelayMs;
    ((F_FoamGCodeConverter) this).\u0001.Value = (Decimal) ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetAutoCycleTickMs;
    ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.None;
    ((F_HolesTemp) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_HolesTemp.Captions.Count >= 9)
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
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetReferanceKey = ((F_FoamGCodeConverter) this).\u0001.Text;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathImport = ((F_FoamGCodeConverter) this).\u0002.Text;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathExport = ((F_FoamGCodeConverter) this).\u0003.Text;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathDeleted = ((F_FoamGCodeConverter) this).\u0004.Text;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetShowInfo = ((F_FoamGCodeConverter) this).\u0002.Checked;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetSubFolder = ((F_FoamGCodeConverter) this).\u0001.Checked;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetMirrorIfNoClamperSideAvailable = ((F_FoamGCodeConverter) this).\u0004.Checked;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetMirrorIfSlotClamperSide = ((F_FoamGCodeConverter) this).\u0003.Checked;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetAutoFileExtension = ((F_FoamGCodeConverter) this).\u0005.Text;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetAutoCycleDeleteAndMove = ((F_FoamGCodeConverter) this).\u0005.Checked;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetAutoCycleTickDelayMs = (int) ((F_FoamGCodeConverter) this).\u0002.Value;
    ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetAutoCycleTickMs = (int) ((F_FoamGCodeConverter) this).\u0001.Value;
    if (((F_FoamGCodeConverter) this).\u0001.SelectedIndex == 0)
      ((buNestingVar) ((F_HolesTemp) this).Settings).ErpFileType = drillErpFileType.Cabinet;
    else if (((F_FoamGCodeConverter) this).\u0001.SelectedIndex == 1)
    {
      ((buNestingVar) ((F_HolesTemp) this).Settings).ErpFileType = drillErpFileType.Corpus;
    }
    else
    {
      if (((F_FoamGCodeConverter) this).\u0001.SelectedIndex != 2)
        return;
      ((buNestingVar) ((F_HolesTemp) this).Settings).ErpFileType = drillErpFileType.Cyncly;
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_HolesTemp) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamGCodeConverter) this).btn_ok.Name)
    {
      this.Apply();
      ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else if (control2.Name == ((F_FoamGCodeConverter) this).btn_cancel.Name)
    {
      ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (control2.Name == ((F_FoamGCodeConverter) this).\u0001.Name)
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.SelectedPath = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathImport;
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
          ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathImport = folderBrowserDialog.SelectedPath;
          ((F_FoamGCodeConverter) this).\u0002.Text = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathImport;
        }
      }
      if (control2.Name == ((F_FoamGCodeConverter) this).\u0002.Name)
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.SelectedPath = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathExport;
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
          ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathExport = folderBrowserDialog.SelectedPath;
          ((F_FoamGCodeConverter) this).\u0003.Text = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathExport;
        }
      }
      if (!(control2.Name == ((F_FoamGCodeConverter) this).\u0003.Name))
        return;
      FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
      folderBrowserDialog1.SelectedPath = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathDeleted;
      if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
        return;
      ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathDeleted = folderBrowserDialog1.SelectedPath;
      ((F_FoamGCodeConverter) this).\u0004.Text = ((buNestingRuntime) ((F_HolesTemp) this).Settings).CabinetpathDeleted;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_HolesTemp) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_HolesTemp) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FoamSlices() => F_HolesTemp.Captions = new List<string>();

  public event OkCommandWithTwoDataEventHandler DataChanged;

  public event OkCommandWithTwoDataEventHandler ParameterChanged;

  public event CancelCommandEventHandler DataCancel;
}
