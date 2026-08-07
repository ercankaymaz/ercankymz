// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_AngleRange
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buEyeBaseVer5;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_AngleRange : Form
{
  internal Panel \u0001;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  internal CheckBox \u0006;
  internal System.Windows.Forms.Label \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0004;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0002;
  internal RadioButton \u0001;
  internal Panel \u0003;
  internal RadioButton \u0002;

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.Controls, result, obj1.Shift);
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_HeightAdvanced) this).PropertiesForm.TouchPad & !((F_HeightAdvanced) this).\u0003.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_HeightAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_HeightAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_AngleRange() => F_HeightAdvanced.Captions = new List<string>();

  public F_AngleRange() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.ShallowAndSteepAreaParams.SlopeAngleStart;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.ShallowAndSteepAreaParams.SlopeAngleEnd;
    if (this.mwCamParameter.MachParam.ShallowAndSteepAreaParams.MachiningAreaType == ShallowAndSteepAreaParamsMachiningAreaType.MatSteepAreas)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
    ((F_2DContainment) this).\u0001.Image = (Image) null;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_2DContainment) this).btn_ok.Name)
    {
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_2DContainment) this).btn_cancel.Name))
      return;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.ShallowAndSteepAreaParams.SlopeAngleEnd = (double) this.\u0001.Value;
    this.mwCamParameter.MachParam.ShallowAndSteepAreaParams.SlopeAngleStart = (double) this.\u0002.Value;
    if (this.\u0002.Checked)
      this.mwCamParameter.MachParam.ShallowAndSteepAreaParams.MachiningAreaType = ShallowAndSteepAreaParamsMachiningAreaType.MatSteepAreas;
    else
      this.mwCamParameter.MachParam.ShallowAndSteepAreaParams.MachiningAreaType = ShallowAndSteepAreaParamsMachiningAreaType.MatShallowAreas;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.Controls, result, obj1.Shift);
  }
}
