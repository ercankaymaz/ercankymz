// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Marble.F_MarbleSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Marble;

public class F_MarbleSettings : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties Properties = new FormProperties();
  public marbleOperation Operation = new marbleOperation();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal Label label_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal CheckBox checkBox_0;
  internal Label label_2;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_4;
  internal Label label_5;
  internal NumericUpDown numericUpDown_4;
  internal NumericUpDown numericUpDown_5;
  internal Label label_6;
  internal Label label_7;
  internal NumericUpDown numericUpDown_6;
  internal NumericUpDown numericUpDown_7;
  internal Label label_8;
  internal Label label_9;
  internal NumericUpDown numericUpDown_8;
  internal Label label_10;
  internal NumericUpDown numericUpDown_9;
  internal CheckBox checkBox_1;
  internal Label label_11;
  internal Label label_12;
  internal NumericUpDown numericUpDown_10;
  internal Label label_13;
  internal NumericUpDown numericUpDown_11;
  internal Label label_14;
  internal NumericUpDown numericUpDown_12;
  internal Label label_15;
  internal NumericUpDown numericUpDown_13;
  internal Label label_16;
  internal NumericUpDown numericUpDown_14;
  internal Label label_17;
  internal NumericUpDown numericUpDown_15;
  internal CheckBox checkBox_2;
  internal Label label_18;
  internal CheckBox checkBox_3;
  internal Label label_19;
  internal CheckBox checkBox_4;
  internal Label label_20;
  internal TabPage tabPage_2;
  internal NumericUpDown numericUpDown_16;
  internal Label label_21;
  internal NumericUpDown numericUpDown_17;
  internal Label label_22;
  internal Label label_23;
  internal NumericUpDown numericUpDown_18;
  internal Label label_24;
  internal NumericUpDown numericUpDown_19;
  internal Label label_25;
  internal NumericUpDown numericUpDown_20;
  internal NumericUpDown numericUpDown_21;
  internal Label label_26;
  internal Label label_27;
  internal NumericUpDown numericUpDown_22;
  internal NumericUpDown numericUpDown_23;
  internal Label label_28;
  internal Label label_29;
  internal NumericUpDown numericUpDown_24;
  internal TabPage tabPage_3;
  internal NumericUpDown numericUpDown_25;
  internal Label label_30;
  internal NumericUpDown numericUpDown_26;
  internal Label label_31;
  internal NumericUpDown numericUpDown_27;
  internal Label label_32;
  internal NumericUpDown numericUpDown_28;
  internal Label label_33;
  internal NumericUpDown numericUpDown_29;
  internal Label label_34;
  internal NumericUpDown numericUpDown_30;
  internal Label label_35;
  internal NumericUpDown numericUpDown_31;
  internal Label label_36;
  internal NumericUpDown numericUpDown_32;
  internal Label label_37;
  internal NumericUpDown numericUpDown_33;
  internal Label label_38;
  internal NumericUpDown numericUpDown_34;
  internal Label label_39;
  internal NumericUpDown numericUpDown_35;
  internal Label label_40;
  internal NumericUpDown numericUpDown_36;
  internal Label label_41;
  internal NumericUpDown numericUpDown_37;
  internal Label label_42;

  public F_MarbleSettings() => Class39.smethod_5(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (!(this.Properties.Result != DialogResult.OK & this.Properties.Result != DialogResult.Ignore))
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.numericUpDown_5.Value = (Decimal) this.Operation.WaterJet5AxisCRtForA1;
    this.numericUpDown_7.Value = (Decimal) this.Operation.WaterJet5AxisCRtForA10;
    this.numericUpDown_8.Value = (Decimal) this.Operation.WaterJet5AxisCRtForA20;
    this.numericUpDown_6.Value = (Decimal) this.Operation.WaterJet5AxisCRtForA30;
    this.numericUpDown_4.Value = (Decimal) this.Operation.WaterJet5AxisCRtForA40;
    this.numericUpDown_2.Value = (Decimal) this.Operation.WaterJet5AxisCRtForA45;
    this.numericUpDown_1.Value = (Decimal) this.Operation.WaterJet5AxisCRtForA50;
    this.numericUpDown_0.Value = (Decimal) this.Operation.WaterJet5AxisCOffsetStartEnd;
    this.numericUpDown_3.Value = (Decimal) this.Operation.WaterJet5AxisCOffsetMiddle;
    this.checkBox_0.Checked = this.Operation.WaterJet5AxisConcaveCalculation;
    this.numericUpDown_17.Value = (Decimal) this.Operation.WaterJet5AxisARtForA0;
    this.numericUpDown_21.Value = (Decimal) this.Operation.WaterJet5AxisARtForA1;
    this.numericUpDown_16.Value = (Decimal) this.Operation.WaterJet5AxisARtForA5;
    this.numericUpDown_23.Value = (Decimal) this.Operation.WaterJet5AxisARtForA10;
    this.numericUpDown_24.Value = (Decimal) this.Operation.WaterJet5AxisARtForA20;
    this.numericUpDown_22.Value = (Decimal) this.Operation.WaterJet5AxisARtForA30;
    this.numericUpDown_20.Value = (Decimal) this.Operation.WaterJet5AxisARtForA40;
    this.numericUpDown_19.Value = (Decimal) this.Operation.WaterJet5AxisARtForA45;
    this.numericUpDown_18.Value = (Decimal) this.Operation.WaterJet5AxisARtForA50;
    this.numericUpDown_37.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle60;
    this.numericUpDown_36.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle70;
    this.numericUpDown_35.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle80;
    this.numericUpDown_34.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle90;
    this.numericUpDown_33.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle100;
    this.numericUpDown_32.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle110;
    this.numericUpDown_31.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle120;
    this.numericUpDown_30.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle130;
    this.numericUpDown_29.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle140;
    this.numericUpDown_28.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle150;
    this.numericUpDown_27.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle160;
    this.numericUpDown_26.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle170;
    this.numericUpDown_25.Value = (Decimal) this.Operation.WaterJet5AxisARatioCornerAngle180;
    this.numericUpDown_12.Value = (Decimal) this.Operation.WaterJetLeadInInsideAngle;
    this.numericUpDown_13.Value = (Decimal) this.Operation.WaterJetLeadInLength;
    this.numericUpDown_10.Value = (Decimal) this.Operation.WaterJetLeadOutInsideAngle;
    this.numericUpDown_11.Value = (Decimal) this.Operation.WaterJetLeadOutLength;
    this.numericUpDown_15.Value = (Decimal) this.Operation.WaterJetLeadInOutsideAngle;
    this.numericUpDown_14.Value = (Decimal) this.Operation.WaterJetLeadOutOutsideAngle;
    this.numericUpDown_9.Value = (Decimal) this.Operation.SurfaceReadDevideLength;
    this.checkBox_1.Checked = this.Operation.ApplySurfaceReadData;
    this.checkBox_3.Checked = this.Operation.BreakEntitiesByMouseClickForMilling;
    this.checkBox_4.Checked = this.Operation.BreakEntitiesByMouseClickForSaw;
    this.checkBox_2.Checked = this.Operation.BreakEntitiesByMouseClickForWaterJet;
    this.Refresh();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.ControlUpdate();
    Class39.smethod_479(this);
  }

  public void ControlUpdate()
  {
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_518(this);
      this.Properties.Result = DialogResult.OK;
      this.Dispose();
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
