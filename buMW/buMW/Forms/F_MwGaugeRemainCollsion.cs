// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwGaugeRemainCollsion
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwGaugeRemainCollsion : Form
{
  internal Button \u000E;
  internal Button \u000F;
  internal Button \u0010;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MwGaugeCheck) this).\u0001.Name)
    {
      ((F_MwGaugeCheck) this).Apply();
      F_MwGaugeItemAdvanced gaugeItemAdvanced = new F_MwGaugeItemAdvanced();
      gaugeItemAdvanced.Par = new MachiningParams(((F_MwGaugeCheck) this).Par);
      gaugeItemAdvanced.Init();
      int num = (int) gaugeItemAdvanced.ShowDialog();
      if (gaugeItemAdvanced.Properties.Result == DialogResult.OK)
      {
        ((F_MwGaugeCheck) this).Par = new MachiningParams(gaugeItemAdvanced.Par);
        gaugeItemAdvanced.Dispose();
      }
    }
    if (control2.Name == ((F_MwGaugeCheck) this).\u0002.Name)
    {
      ((F_MwGaugeCheck) this).Apply();
      F_MwGaugeItemAdvanced gaugeItemAdvanced = new F_MwGaugeItemAdvanced();
      gaugeItemAdvanced.Par = new MachiningParams(((F_MwGaugeCheck) this).Par);
      gaugeItemAdvanced.GaugeIndex = 1;
      gaugeItemAdvanced.Init();
      int num = (int) gaugeItemAdvanced.ShowDialog();
      if (gaugeItemAdvanced.Properties.Result == DialogResult.OK)
      {
        ((F_MwGaugeCheck) this).Par = new MachiningParams(gaugeItemAdvanced.Par);
        gaugeItemAdvanced.Dispose();
      }
    }
    if (control2.Name == ((F_MwGaugeCheck) this).\u0004.Name)
    {
      ((F_MwGaugeCheck) this).Apply();
      F_MwGaugeItemAdvanced gaugeItemAdvanced = new F_MwGaugeItemAdvanced();
      gaugeItemAdvanced.Par = new MachiningParams(((F_MwGaugeCheck) this).Par);
      gaugeItemAdvanced.GaugeIndex = 2;
      gaugeItemAdvanced.Init();
      int num = (int) gaugeItemAdvanced.ShowDialog();
      if (gaugeItemAdvanced.Properties.Result == DialogResult.OK)
      {
        ((F_MwGaugeCheck) this).Par = new MachiningParams(gaugeItemAdvanced.Par);
        gaugeItemAdvanced.Dispose();
      }
    }
    if (control2.Name == ((F_MwGaugeCheck) this).\u0003.Name)
    {
      ((F_MwGaugeCheck) this).Apply();
      F_MwGaugeItemAdvanced gaugeItemAdvanced = new F_MwGaugeItemAdvanced();
      gaugeItemAdvanced.Par = new MachiningParams(((F_MwGaugeCheck) this).Par);
      gaugeItemAdvanced.GaugeIndex = 3;
      gaugeItemAdvanced.Init();
      int num = (int) gaugeItemAdvanced.ShowDialog();
      if (gaugeItemAdvanced.Properties.Result == DialogResult.OK)
      {
        ((F_MwGaugeCheck) this).Par = new MachiningParams(gaugeItemAdvanced.Par);
        gaugeItemAdvanced.Dispose();
      }
    }
    if (control2.Name == ((F_MwGaugeCheck) this).\u0007.Name)
    {
      ((F_MwGaugeCheck) this).Apply();
      F_MwGaugeAdvancedSettings advancedSettings = new F_MwGaugeAdvancedSettings();
      advancedSettings.Par = new MachiningParams(((F_MwGaugeCheck) this).Par);
      advancedSettings.Init();
      int num = (int) advancedSettings.ShowDialog();
      if (advancedSettings.Properties.Result == DialogResult.OK)
      {
        ((F_MwGaugeCheck) this).Par = new MachiningParams(advancedSettings.Par);
        advancedSettings.Dispose();
      }
    }
    if (control2.Name == ((F_MwGaugeCheck) this).\u0005.Name)
    {
      ((F_MwGaugeCheck) this).Apply();
      F_MwGaugeRemainCollsion gaugeRemainCollsion = new F_MwGaugeRemainCollsion();
      gaugeRemainCollsion.Par = new MachiningParams(((F_MwGaugeCheck) this).Par);
      gaugeRemainCollsion.Init();
      int num = (int) gaugeRemainCollsion.ShowDialog();
      if (gaugeRemainCollsion.Properties.Result == DialogResult.OK)
      {
        ((F_MwGaugeCheck) this).Par = new MachiningParams(gaugeRemainCollsion.Par);
        gaugeRemainCollsion.Dispose();
      }
    }
    if (!(control2.Name == ((F_MwGaugeCheck) this).\u0006.Name))
      return;
    ((F_MwGaugeCheck) this).Apply();
    F_MwGaugeClearanceForTool clearanceForTool = new F_MwGaugeClearanceForTool();
    clearanceForTool.Par = new MachiningParams(((F_MwGaugeCheck) this).Par);
    clearanceForTool.Init();
    int num1 = (int) clearanceForTool.ShowDialog();
    if (clearanceForTool.Properties.Result != DialogResult.OK)
      return;
    ((F_MwGaugeCheck) this).Par = new MachiningParams(clearanceForTool.Par);
    clearanceForTool.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwGaugeCheck) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwGaugeCheck) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwGaugeRemainCollsion() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    ((F_MwTriM2dContainment) this).\u0001.Checked = this.Par.CollControl.ReportRemainingColls;
    if (this.Par.CollControl.CollCtrlOperations[0].StopTpCalcOnFirstRemainingGougeFlg)
      this.\u0003.Checked = true;
    if (this.Par.CollControl.CollCtrlOperations[0].RemoveRemainingGougesForContoursFlg)
      this.\u0001.Checked = true;
    if (!this.Par.CollControl.CollCtrlOperations[0].StopTpCalcOnFirstRemainingGougeFlg & !this.Par.CollControl.CollCtrlOperations[0].RemoveRemainingGougesForContoursFlg)
      this.\u0002.Checked = true;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriM2dContainment) this).Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
    if (this.Par.CollControl.CollCtrlOperations[0].Strategy == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions | this.Par.CollControl.CollCtrlOperations[1].Strategy == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions | this.Par.CollControl.CollCtrlOperations[2].Strategy == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions | this.Par.CollControl.CollCtrlOperations[3].Strategy == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
      this.\u0001.Enabled = true;
    else
      this.\u0001.Enabled = false;
  }
}
