// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMRotate
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

public class F_MwTriMRotate : Form
{
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal NumericUpDown \u0011;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  public Button btn_ok;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  public ComboBox combo_direction;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0004;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u000E;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u000F;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u0010;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0011;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u0012;
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0013;
  internal Panel \u0004;
  public ComboBox combo_applystock;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRetract) this).Properties.Inited)
      return;
    ((F_MwTriMRetract) this).Properties.Inited = false;
    ((F_MwTriMRetract) this).Apply();
    ((F_MwTriMRetract) this).UpdateControlFromType();
    ((F_MwTriMRetract) this).Properties.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRetract) this).Properties.Inited)
      return;
    ((F_MwTriMRetract) this).Properties.Inited = false;
    ((F_MwTriMRetract) this).Apply();
    ((F_MwTriMRetract) this).UpdateControlFromType();
    ((F_MwTriMRetract) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMRetract) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMRetract) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMRotate() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0007.Value = (Decimal) this.Par.RoughingParams.TPRotationRoughParams.StepoverShiftDistance;
    this.\u0008.Value = (Decimal) this.Par.RoughingParams.TPRotationRoughParams.StartShiftDistance;
    this.\u0005.Value = (Decimal) this.Par.RoughingParams.TPRotationRoughParams.RotationAngle;
    this.\u0006.Value = (Decimal) this.Par.RoughingParams.TPRotationRoughParams.StartAngle;
    this.\u0004.Value = (Decimal) this.Par.RoughingParams.TPRotationRoughParams.NumberOfSteps;
    this.\u0001.Value = (Decimal) this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisBasePoint.X;
    this.\u0002.Value = (Decimal) this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisBasePoint.Y;
    this.\u0003.Value = (Decimal) this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisBasePoint.Z;
    if (this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.X == 1.0 & this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.Y == 0.0 & this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.Z == 0.0)
      this.combo_direction.SelectedIndex = 0;
    else if (this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.X == 0.0 & this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.Y == 1.0 & this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.Z == 0.0)
      this.combo_direction.SelectedIndex = 1;
    else if (this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.X == 0.0 & this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.Y == 0.0 & this.Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection.Z == 1.0)
      this.combo_direction.SelectedIndex = 2;
    else
      this.combo_direction.SelectedIndex = 3;
    if (this.Par.RoughingParams.TPRotationRoughParams.LinkingApplicationStage == TPRotationRoughParamsLinkingApplicationStage.TprLinkBeforeRotate)
      ((F_MwTriMRoughLink) this).combo_applylink.SelectedIndex = 0;
    else
      ((F_MwTriMRoughLink) this).combo_applylink.SelectedIndex = 1;
    if (this.Par.RoughingParams.TPRotationRoughParams.StockApplicationStage == TPRotationRoughParamsStockApplicationStage.TprApplyStockBeforeRotation)
      this.combo_applystock.SelectedIndex = 0;
    else
      this.combo_applystock.SelectedIndex = 1;
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
    ((F_MwTriMRoughLink) this).Apply();
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
    ((F_MwTriMRoughLink) this).\u0014.Enabled = false;
    this.combo_applystock.Enabled = false;
  }
}
