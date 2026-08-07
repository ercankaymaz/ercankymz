// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwGaugeClearanceForTool
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

public class F_MwGaugeClearanceForTool : Form
{
  internal CheckBox \u0006;
  internal CheckBox \u0007;
  internal System.Windows.Forms.Label \u0003;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_ok;
  internal ImageList \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  public Button btn_cancel;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal NumericUpDown \u0004;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal System.Windows.Forms.Label \u0007;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwGaugeAdvancedSettings) this).Properties.Inited)
      return;
    ((F_MwGaugeAdvancedSettings) this).Properties.Inited = false;
    ((F_MwGaugeAdvancedSettings) this).Apply();
    ((F_MwGaugeAdvancedSettings) this).UpdateControlFromType();
    ((F_MwGaugeAdvancedSettings) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwGaugeAdvancedSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwGaugeAdvancedSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwGaugeClearanceForTool() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    ((F_MwGaugeItemAdvanced) this).\u0007.Value = (Decimal) this.Par.CollControl.AngularClearance;
    this.\u0003.Value = (Decimal) this.Par.CollControl.HolderLowerClearance;
    this.\u0004.Value = (Decimal) this.Par.CollControl.HolderUpperClearance;
    this.\u0002.Value = (Decimal) this.Par.CollControl.ArborLowerClearance;
    this.\u0005.Value = (Decimal) this.Par.CollControl.ArborUpperClearance;
    this.\u0001.Value = (Decimal) this.Par.CollControl.ToolShaftLowerClearance;
    this.\u0006.Value = (Decimal) this.Par.CollControl.ToolShaftUpperClearance;
    if (this.Par.CollControl.ClearanceType == CollCtrlParamsCollCtrlClearanceType.CcCtCylindrical)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
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
    this.Apply();
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
    if (this.\u0002.Checked)
    {
      this.\u0002.Enabled = false;
      this.\u0003.Enabled = false;
      this.\u0001.Enabled = false;
      this.\u0005.Enabled = false;
    }
    else
    {
      this.\u0002.Enabled = true;
      this.\u0003.Enabled = true;
      this.\u0001.Enabled = true;
      this.\u0005.Enabled = true;
    }
  }

  public void Apply()
  {
    this.Par.CollControl.AngularClearance = (double) ((F_MwGaugeItemAdvanced) this).\u0007.Value;
    this.Par.CollControl.HolderLowerClearance = (double) this.\u0003.Value;
    this.Par.CollControl.HolderUpperClearance = (double) this.\u0004.Value;
    this.Par.CollControl.ArborLowerClearance = (double) this.\u0002.Value;
    this.Par.CollControl.ArborUpperClearance = (double) this.\u0005.Value;
    this.Par.CollControl.ToolShaftLowerClearance = (double) this.\u0001.Value;
    this.Par.CollControl.ToolShaftUpperClearance = (double) this.\u0006.Value;
    if (this.\u0002.Checked)
      this.Par.CollControl.ClearanceType = CollCtrlParamsCollCtrlClearanceType.CcCtCylindrical;
    else
      this.Par.CollControl.ClearanceType = CollCtrlParamsCollCtrlClearanceType.CcCtConical;
  }
}
