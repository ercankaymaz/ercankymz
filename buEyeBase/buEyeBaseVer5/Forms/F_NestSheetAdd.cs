// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestSheetAdd
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_NestSheetAdd : Form
{
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  public Button btn_dirpower;
  public Button btn_dirfeed;
  public Button btn_dirfocus;
  internal Label \u0015;
  internal Label \u0016;
  internal Label \u0017;
  internal Panel \u0004;
  internal Label \u0018;
  internal NumericUpDown \u0007;
  internal Label \u0019;
  internal NumericUpDown \u0008;
  internal Label \u001A;
  internal NumericUpDown \u000E;
  internal Label \u001B;
  internal NumericUpDown \u000F;
  public Button btn_dircancel;
  public Button btn_dirok;
  internal Label \u001C;
  public Button btn_edit;
  public Button btn_ordermoveup;
  public Button btn_ordermovedown;
  internal NumericUpDown \u0010;
  internal Label \u001D;
  internal NumericUpDown \u0011;
  internal Label \u001E;
  internal NumericUpDown \u0012;
  internal Label \u001F;
  public static byte f000EC7;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buNestingSettings Settings;
  public buNestingRuntime RunTimeSettings;
  internal IContainer \u0001;

  [CompilerGenerated]
  [SpecialName]
  public void add_ClosedPressed(OkCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandEventHandler commandEventHandler = ((F_BendingRotaryDisk) this).\u0002;
    OkCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<OkCommandEventHandler>(ref ((F_BendingRotaryDisk) this).\u0002, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ClosedPressed(OkCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandEventHandler commandEventHandler = ((F_BendingRotaryDisk) this).\u0002;
    OkCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<OkCommandEventHandler>(ref ((F_BendingRotaryDisk) this).\u0002, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init(bool ClearTree = true)
  {
    ((F_PanelCutNestSheetPartList) this).PropertiesForm.Inited = false;
    ((F_BendingRotaryDisk) this).txt_bestcount.Text = "0";
    if (ClearTree)
      ((F_BendingRotaryDisk) this).treeView1.Nodes.Clear();
    if (((ProfileTempVars) ((ProfileMultiply) ((F_BendingRotaryDisk) this).SettingsPar).Runtime).NestExecutionTo == nestResultSendType.Draw)
    {
      ((F_BendingRotaryDisk) this).\u0001.Checked = false;
      ((F_BendingRotaryDisk) this).\u0002.Checked = true;
      ((F_BendingRotaryDisk) this).\u0003.Checked = false;
    }
    else if (((ProfileTempVars) ((ProfileMultiply) ((F_BendingRotaryDisk) this).SettingsPar).Runtime).NestExecutionTo == nestResultSendType.Job)
    {
      ((F_BendingRotaryDisk) this).\u0001.Checked = true;
      ((F_BendingRotaryDisk) this).\u0002.Checked = false;
      ((F_BendingRotaryDisk) this).\u0003.Checked = false;
    }
    else
    {
      ((F_BendingRotaryDisk) this).\u0001.Checked = false;
      ((F_BendingRotaryDisk) this).\u0002.Checked = false;
      ((F_BendingRotaryDisk) this).\u0003.Checked = true;
    }
    ((F_BendingRotaryDisk) this).\u0001.Checked = ((ProfileClamperSettings) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).SettingsPar).Settings).ShowResultPreviewAfterFinish;
    this.LoadLanguage();
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
      ((F_BendingRotaryDisk) this).\u0001.Text = F_PanelCutNestSheetPartList.Captions[1];
      ((F_BendingRotaryDisk) this).\u0002.Text = F_PanelCutNestSheetPartList.Captions[2];
      ((F_BendingRotaryDisk) this).lbl_status.Text = F_PanelCutNestSheetPartList.Captions[3];
      ((F_BendingRotaryDisk) this).\u0003.Text = F_PanelCutNestSheetPartList.Captions[4];
      ((F_BendingRotaryDisk) this).btn_settings.Text = F_PanelCutNestSheetPartList.Captions[4];
      ((F_BendingRotaryDisk) this).\u0001.Text = F_PanelCutNestSheetPartList.Captions[5];
      ((F_BendingRotaryDisk) this).btn_send.Text = F_PanelCutNestSheetPartList.Captions[6];
      ((F_BendingRotaryDisk) this).btn_preview.Text = F_PanelCutNestSheetPartList.Captions[7];
      ((F_BendingRotaryDisk) this).btn_stop.Text = F_PanelCutNestSheetPartList.Captions[8];
      ((F_BendingRotaryDisk) this).btn_close.Text = F_PanelCutNestSheetPartList.Captions[9];
      ((F_BendingRotaryDisk) this).\u0002.Text = F_PanelCutNestSheetPartList.Captions[10];
      ((F_BendingRotaryDisk) this).\u0001.Text = F_PanelCutNestSheetPartList.Captions[11];
      ((F_BendingRotaryDisk) this).\u0003.Text = buLangTranslate.preDef.File;
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
    obj1.Cancel = true;
    this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (((F_BendingRotaryDisk) this).\u0002 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_BendingRotaryDisk) this).\u0002();
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (((F_BendingRotaryDisk) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_BendingRotaryDisk) this).\u0001();
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (((F_BendingRotaryDisk) this).\u0002 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_BendingRotaryDisk) this).\u0002();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_BendingRotaryDisk) this).\u0002.Checked)
      ((ProfileTempVars) ((ProfileMultiply) ((F_BendingRotaryDisk) this).SettingsPar).Runtime).NestExecutionTo = nestResultSendType.Draw;
    else if (((F_BendingRotaryDisk) this).\u0001.Checked)
      ((ProfileTempVars) ((ProfileMultiply) ((F_BendingRotaryDisk) this).SettingsPar).Runtime).NestExecutionTo = nestResultSendType.Job;
    else
      ((ProfileTempVars) ((ProfileMultiply) ((F_BendingRotaryDisk) this).SettingsPar).Runtime).NestExecutionTo = nestResultSendType.File;
    // ISSUE: reference to a compiler-generated field
    if (((F_BendingRotaryDisk) this).\u0002 == null)
      return;
    this.Visible = false;
    buNestedResultSentEventArg Data = (buNestedResultSentEventArg) new ProfileOperationDataCut();
    string str = ((F_BendingRotaryDisk) this).\u0001;
    ref int local1 = ref ((ProfileTempVars) Data).IndexResult;
    ref int local2 = ref ((ProfileTempVars) Data).IndexSheet;
    ref int local3 = ref ((ProfileTempVars) Data).IndexPart;
    \u0007.\u0001.\u0001(ref local1, str, ref local3, ref local2, (F_NestOnlineCalc) this);
    ((ProfileTempVars) Data).SendToDraw = ((ProfileTempVars) ((ProfileMultiply) ((F_BendingRotaryDisk) this).SettingsPar).Runtime).NestExecutionTo;
    ((ProfileClamperSettings) ((ProfileSupportBlock) ((F_BendingRotaryDisk) this).SettingsPar).Settings).ShowResultPreviewAfterFinish = ((F_BendingRotaryDisk) this).\u0001.Checked;
    // ISSUE: reference to a compiler-generated field
    ((F_BendingRotaryDisk) this).\u0002((object) Data);
  }
}
