// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Foam.F_FoamSequence
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Holes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamSequence : Form
{
  public Label label17;
  public NumericUpDown spn_circlez;
  public Label label18;
  public NumericUpDown spn_circledepth;
  public Label label19;
  public Label label20;
  public NumericUpDown spn_circlediameter;
  public NumericUpDown spn_drillmode2_height;
  public Label lbl_drillmode2_height;
  public Label lbl_drillmode2_drilldis;
  public NumericUpDown spn_drillmode2_drilldis;
  public NumericUpDown spn_drillmode2_startdis;
  public Label lbl_drillmode2_startdis;
  public NumericUpDown spn_drillmode2_enddis;
  public Label lbl_drillmode2_enddis;
  public NumericUpDown spn_drillmode2_depth;
  public Label lbl_drillmode2_diameter;
  public Label lbl_drillmode2_depth;
  public NumericUpDown spn_drillmode2_diameter;
  public TabPage tabPage_drillstartenddistance;
  public Label lbl_slotmode2_usemilling;
  public CheckBox chk_slotmode2_usemilling;
  public NumericUpDown spn_slotmode2_height;
  public Label lbl_slotmode2_height;

  public F_FoamSequence()
  {
    ((F_FoamWaveMenu) this).PropertiesForm = new FormProperties();
    ((F_FoamSlices) this).settingRuntime = (DrillRuntimeSettings) new buProfileCalc();
    ((F_FoamSlices) this).Job = (DrillJob) new buProfileCalc();
    ((F_FoamSlices) this).settingCNC = (DrillCNCSettings) new buProfileCalc();
    ((F_FoamSlices) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Contour) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_FoamSlices) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_FoamSlices) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_FoamSlices) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_FoamSlices) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_FoamSlices) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_FoamSlices) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataOk(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_FoamSlices) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_FoamSlices) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_FoamSlices) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_FoamSlices) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_FoamSlices) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_FoamSlices) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_FoamWaveMenu) this).PropertiesForm.Inited = false;
    if (((F_FoamWaveMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_FoamWaveMenu) this).PropertiesForm.Height;
    if (((F_FoamWaveMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_FoamWaveMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_FoamWaveMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_FoamWaveMenu) this).PropertiesForm.FormPosition;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_FoamWaveMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_FoamWaveMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_FoamSlices.Captions.Count >= 9)
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
    ((F_FoamSlices) this).\u0001.Value = (Decimal) ((buNestingVar) ((F_FoamSlices) this).settingRuntime).ContourOffset;
    ((F_FoamSlices) this).\u0002.Value = (Decimal) ((buNestingVar) ((F_FoamSlices) this).settingRuntime).ContourDepth;
    ((F_FoamSlices) this).btn_top.BackColor = Color.Gainsboro;
    ((F_FoamSlices) this).btn_bottom.BackColor = Color.Gainsboro;
    if (((buNestingResultSettings) ((F_FoamSlices) this).settingRuntime).lastContourPlaneNames == planeBoxNames.Top)
      ((F_FoamSlices) this).btn_top.BackColor = Color.PaleGreen;
    if (((buNestingResultSettings) ((F_FoamSlices) this).settingRuntime).lastContourPlaneNames != planeBoxNames.Bottom)
      return;
    ((F_FoamSlices) this).btn_bottom.BackColor = Color.PaleGreen;
  }
}
