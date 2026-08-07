// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.CAM.F_CamCommon
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.CAM;

public class F_CamCommon : Form
{
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public camSpeeds Velocity = new camSpeeds();
  public camSpeedsEnable VelocityEnable = new camSpeedsEnable();
  public camDistances Distance = new camDistances();
  public camDistanceEnable DistanceEnable = new camDistanceEnable();
  public camStep Step = new camStep();
  public camStepEnable StepEnable = new camStepEnable();
  public camOffset Offset = new camOffset();
  public camOffsetEnable OffsetEnable = new camOffsetEnable();
  public camOperation Operation = new camOperation();
  public camOperationEnable OperationEnable = new camOperationEnable();
  public LeadIn LeadIn = new LeadIn();
  public LeadOut LeadOut = new LeadOut();
  public LeadInOutEnable LeadInOutEnable = new LeadInOutEnable();
  public bool VelocityTabVisible = true;
  public bool DistanceTabVisible = true;
  public bool OffsetTabVisible = true;
  public bool StepTabVisible = true;
  public bool LeadInTabVisible = true;
  public bool LeadOutTabVisible = true;
  public bool MiscTabVisible = false;
  public bool OperationTabVisible = true;
  public bool ToolTabVisible = false;
  public bool ShowHelps = true;
  public bool ShowNextButton = true;
  public bool ShowPreButton = true;
  public bool ReadOnly = false;
  public int FormHeight = 0;
  public int FormWidth = 0;
  public DialogResult Result = DialogResult.None;
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal TabPage tabPage_3;
  internal TabPage tabPage_4;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal TabPage tabPage_5;
  public Button btn_pre;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal Label label_3;
  internal Panel panel_0;
  internal Panel panel_1;
  internal Panel panel_2;
  internal Label label_4;
  internal NumericUpDown numericUpDown_2;
  internal Label label_5;
  internal Panel panel_3;
  internal Label label_6;
  internal NumericUpDown numericUpDown_3;
  internal Label label_7;
  internal Panel panel_4;
  internal Label label_8;
  internal NumericUpDown numericUpDown_4;
  internal Label label_9;
  internal Panel panel_5;
  internal Label label_10;
  internal NumericUpDown numericUpDown_5;
  internal Label label_11;
  internal Panel panel_6;
  internal Label label_12;
  internal NumericUpDown numericUpDown_6;
  internal Label label_13;
  internal Panel panel_7;
  internal Label label_14;
  internal Label label_15;
  internal Panel panel_8;
  internal Label label_16;
  internal NumericUpDown numericUpDown_7;
  internal Label label_17;
  internal Panel panel_9;
  internal Label label_18;
  internal NumericUpDown numericUpDown_8;
  internal Label label_19;
  internal CheckBox checkBox_0;
  internal Panel panel_10;
  internal Label label_20;
  internal NumericUpDown numericUpDown_9;
  internal Label label_21;
  internal Panel panel_11;
  internal Label label_22;
  internal NumericUpDown numericUpDown_10;
  internal Label label_23;
  internal Panel panel_12;
  internal Label label_24;
  internal NumericUpDown numericUpDown_11;
  internal Label label_25;
  internal Panel panel_13;
  internal Label label_26;
  internal NumericUpDown numericUpDown_12;
  internal Label label_27;
  internal Label label_28;
  internal ComboBox comboBox_0;
  internal CheckBox checkBox_1;
  internal Panel panel_14;
  internal Label label_29;
  internal NumericUpDown numericUpDown_13;
  internal Label label_30;
  internal Label label_31;
  internal ComboBox comboBox_1;
  internal Panel panel_15;
  internal Label label_32;
  internal NumericUpDown numericUpDown_14;
  internal Label label_33;
  internal Panel panel_16;
  internal Label label_34;
  internal NumericUpDown numericUpDown_15;
  internal Label label_35;
  internal Panel panel_17;
  internal Label label_36;
  internal NumericUpDown numericUpDown_16;
  internal Label label_37;
  internal TabPage tabPage_6;
  internal Panel panel_18;
  internal Label label_38;
  internal NumericUpDown numericUpDown_17;
  internal Label label_39;
  internal Panel panel_19;
  internal Label label_40;
  internal NumericUpDown numericUpDown_18;
  internal Label label_41;
  internal Panel panel_20;
  internal Label label_42;
  internal NumericUpDown numericUpDown_19;
  internal Label label_43;
  internal Label label_44;
  internal ComboBox comboBox_2;
  internal CheckBox checkBox_2;
  internal Panel panel_21;
  internal Label label_45;
  internal NumericUpDown numericUpDown_20;
  internal Label label_46;
  internal Panel panel_22;
  internal Label label_47;
  internal NumericUpDown numericUpDown_21;
  internal Label label_48;
  internal CheckBox checkBox_3;
  internal Panel panel_23;
  internal Label label_49;
  internal NumericUpDown numericUpDown_22;
  internal Label label_50;
  internal Panel panel_24;
  internal Label label_51;
  internal NumericUpDown numericUpDown_23;
  internal Label label_52;
  internal Panel panel_25;
  internal Label label_53;
  internal NumericUpDown numericUpDown_24;
  internal Label label_54;
  internal Panel panel_26;
  internal ComboBox comboBox_3;
  internal Label label_55;
  internal Label label_56;
  internal Panel panel_27;
  internal ComboBox comboBox_4;
  internal Label label_57;
  internal Label label_58;
  internal Panel panel_28;
  internal ComboBox comboBox_5;
  internal Label label_59;
  internal Label label_60;
  internal Panel panel_29;
  internal Label label_61;
  internal NumericUpDown numericUpDown_25;
  internal Label label_62;
  internal CheckBox checkBox_4;
  public Button btn_next;
  internal TabPage tabPage_7;
  internal TabPage tabPage_8;
  internal Panel panel_30;
  internal ComboBox comboBox_6;
  internal Label label_63;
  internal Label label_64;
  internal Panel panel_31;
  internal Label label_65;
  internal NumericUpDown numericUpDown_26;
  internal Label label_66;

  public F_CamCommon() => Class39.smethod_494(this);

  public void Init()
  {
    this.bool_0 = false;
    ArrayList arrayList = new ArrayList();
    if (this.FormHeight > 10)
      this.Height = this.FormHeight;
    if (this.FormWidth > 10)
      this.Width = this.FormWidth;
    this.btn_next.Visible = this.ShowNextButton;
    this.btn_pre.Visible = this.ShowPreButton;
    if (!this.MiscTabVisible && this.tabControl_0.TabPages.Count >= 9)
      this.tabControl_0.TabPages.RemoveAt(8);
    if (!this.ToolTabVisible && this.tabControl_0.TabPages.Count >= 8)
      this.tabControl_0.TabPages.RemoveAt(7);
    if (!this.LeadOutTabVisible && this.tabControl_0.TabPages.Count >= 7)
      this.tabControl_0.TabPages.RemoveAt(6);
    if (!this.LeadInTabVisible && this.tabControl_0.TabPages.Count >= 6)
      this.tabControl_0.TabPages.RemoveAt(5);
    if (!this.OffsetTabVisible && this.tabControl_0.TabPages.Count >= 5)
      this.tabControl_0.TabPages.RemoveAt(4);
    if (!this.StepTabVisible && this.tabControl_0.TabPages.Count >= 4)
      this.tabControl_0.TabPages.RemoveAt(3);
    if (!this.DistanceTabVisible && this.tabControl_0.TabPages.Count >= 3)
      this.tabControl_0.TabPages.RemoveAt(2);
    if (!this.VelocityTabVisible && this.tabControl_0.TabPages.Count >= 2)
      this.tabControl_0.TabPages.RemoveAt(1);
    if (!this.OperationTabVisible && this.tabControl_0.TabPages.Count >= 1)
      this.tabControl_0.TabPages.RemoveAt(0);
    int num1 = 0;
    this.panel_31.Visible = this.OperationEnable.Height;
    if (this.OperationEnable.Height)
    {
      this.panel_31.Top = 6 + num1 * 32 /*0x20*/;
      ++num1;
    }
    this.label_64.Visible = this.OperationEnable.Direction;
    if (this.OperationEnable.Direction)
    {
      this.label_64.Top = 6 + num1 * 32 /*0x20*/;
      int num2 = num1 + 1;
    }
    int num3 = 0;
    this.panel_1.Visible = this.VelocityEnable.Feed;
    if (this.VelocityEnable.Feed)
    {
      this.panel_1.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_0.Visible = this.VelocityEnable.Plunge;
    if (this.VelocityEnable.Plunge)
    {
      this.panel_0.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_5.Visible = this.VelocityEnable.Leave;
    if (this.VelocityEnable.Leave)
    {
      this.panel_5.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_4.Visible = this.VelocityEnable.Finish;
    if (this.VelocityEnable.Finish)
    {
      this.panel_4.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_3.Visible = this.VelocityEnable.Rapid;
    if (this.VelocityEnable.Rapid)
    {
      this.panel_3.Top = 6 + num3 * 32 /*0x20*/;
      ++num3;
    }
    this.panel_2.Visible = this.VelocityEnable.BackwardFeed;
    if (this.VelocityEnable.BackwardFeed)
    {
      this.panel_2.Top = 6 + num3 * 32 /*0x20*/;
      int num4 = num3 + 1;
    }
    int num5 = 0;
    this.panel_6.Visible = this.DistanceEnable.Safe;
    if (this.DistanceEnable.Safe)
    {
      this.panel_6.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_8.Visible = this.DistanceEnable.StepUp;
    if (this.DistanceEnable.StepUp)
    {
      this.panel_8.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_9.Visible = this.DistanceEnable.Air;
    if (this.DistanceEnable.Air)
    {
      this.panel_9.Top = 6 + num5 * 32 /*0x20*/;
      ++num5;
    }
    this.panel_7.Visible = this.DistanceEnable.IncrementalSafe;
    if (this.DistanceEnable.IncrementalSafe)
    {
      this.panel_7.Top = 6 + num5 * 32 /*0x20*/;
      int num6 = num5 + 1;
    }
    int num7 = 0;
    this.comboBox_0.Visible = this.StepEnable.Type;
    this.panel_10.Visible = this.StepEnable.StartValue;
    if (this.StepEnable.StartValue)
    {
      this.panel_10.Top = 40 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_13.Visible = this.StepEnable.EndValue;
    if (this.StepEnable.EndValue)
    {
      this.panel_13.Top = 40 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_11.Visible = this.StepEnable.Step;
    if (this.StepEnable.Step)
    {
      this.panel_11.Top = 40 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_29.Visible = this.StepEnable.Count;
    if (this.StepEnable.Count)
    {
      this.panel_29.Top = 40 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_12.Visible = this.StepEnable.Distance;
    if (this.StepEnable.Distance)
    {
      this.panel_12.Top = 40 + num7 * 32 /*0x20*/;
      int num8 = num7 + 1;
    }
    int num9 = 0;
    this.panel_22.Visible = this.OffsetEnable.Offset;
    if (this.OffsetEnable.Offset)
    {
      this.panel_22.Top = 40 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_25.Visible = this.OffsetEnable.OverlapDistance;
    if (this.OffsetEnable.OverlapDistance)
    {
      this.panel_25.Top = 40 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_24.Visible = this.OffsetEnable.OffsetCount;
    if (this.OffsetEnable.OffsetCount)
    {
      this.panel_24.Top = 40 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_23.Visible = this.OffsetEnable.AdditionalOffset;
    if (this.OffsetEnable.AdditionalOffset)
    {
      this.panel_23.Top = 40 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_28.Visible = this.OffsetEnable.Flow;
    if (this.OffsetEnable.Flow)
    {
      this.panel_28.Top = 40 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_27.Visible = this.OffsetEnable.Corner;
    if (this.OffsetEnable.Corner)
    {
      this.panel_27.Top = 40 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_26.Visible = this.OffsetEnable.OpenContour;
    if (this.OffsetEnable.OpenContour)
    {
      this.panel_26.Top = 40 + num9 * 32 /*0x20*/;
      int num10 = num9 + 1;
    }
    int num11 = 0;
    this.comboBox_1.Visible = this.LeadInOutEnable.LeadType;
    this.panel_14.Visible = this.LeadInOutEnable.Length;
    if (this.LeadInOutEnable.Length)
    {
      this.panel_14.Top = 40 + num11 * 32 /*0x20*/;
      ++num11;
    }
    this.panel_17.Visible = this.LeadInOutEnable.TangentAngle;
    if (this.LeadInOutEnable.TangentAngle)
    {
      this.panel_17.Top = 40 + num11 * 32 /*0x20*/;
      ++num11;
    }
    this.panel_16.Visible = this.LeadInOutEnable.ArcRadius;
    if (this.LeadInOutEnable.ArcRadius)
    {
      this.panel_16.Top = 40 + num11 * 32 /*0x20*/;
      ++num11;
    }
    this.panel_15.Visible = this.LeadInOutEnable.ArcSweepAngle;
    if (this.LeadInOutEnable.ArcSweepAngle)
    {
      this.panel_15.Top = 40 + num11 * 32 /*0x20*/;
      int num12 = num11 + 1;
    }
    int num13 = 0;
    this.comboBox_2.Visible = this.LeadInOutEnable.LeadType;
    this.panel_21.Visible = this.LeadInOutEnable.Length;
    if (this.LeadInOutEnable.Length)
    {
      this.panel_21.Top = 40 + num13 * 32 /*0x20*/;
      ++num13;
    }
    this.panel_20.Visible = this.LeadInOutEnable.TangentAngle;
    if (this.LeadInOutEnable.TangentAngle)
    {
      this.panel_20.Top = 40 + num13 * 32 /*0x20*/;
      ++num13;
    }
    this.panel_19.Visible = this.LeadInOutEnable.ArcRadius;
    if (this.LeadInOutEnable.ArcRadius)
    {
      this.panel_19.Top = 40 + num13 * 32 /*0x20*/;
      ++num13;
    }
    this.panel_18.Visible = this.LeadInOutEnable.ArcSweepAngle;
    if (this.LeadInOutEnable.ArcSweepAngle)
    {
      this.panel_18.Top = 40 + num13 * 32 /*0x20*/;
      int num14 = num13 + 1;
    }
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Operation.Direction, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) this.Operation.Direction), ref this.comboBox_6);
    this.numericUpDown_26.Value = (Decimal) this.Operation.Height;
    this.numericUpDown_0.Value = (Decimal) this.Velocity.Feed;
    this.numericUpDown_2.Value = (Decimal) this.Velocity.BackwardFeed;
    this.numericUpDown_1.Value = (Decimal) this.Velocity.Plunge;
    this.numericUpDown_4.Value = (Decimal) this.Velocity.Finish;
    this.numericUpDown_5.Value = (Decimal) this.Velocity.Leave;
    this.numericUpDown_3.Value = (Decimal) this.Velocity.Rapid;
    this.numericUpDown_8.Value = (Decimal) this.Distance.Air;
    this.checkBox_4.Checked = this.Distance.IncrementalSafe;
    this.numericUpDown_6.Value = (Decimal) this.Distance.Safe;
    this.numericUpDown_7.Value = (Decimal) this.Distance.StepUp;
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Step.StepType, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Step.StepType), ref this.comboBox_0);
    this.checkBox_0.Checked = this.Step.Enable;
    this.numericUpDown_25.Value = (Decimal) this.Step.Count;
    this.numericUpDown_11.Value = (Decimal) this.Step.Distance;
    this.numericUpDown_12.Value = (Decimal) this.Step.EndValue;
    this.numericUpDown_9.Value = (Decimal) this.Step.StartValue;
    this.numericUpDown_10.Value = (Decimal) this.Step.Step;
    ArrayList EnumItems3 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Offset.ClosedContour, ref EnumItems3);
    buControlCommands.ComboboxAddItem(EnumItems3, Convert.ToInt32((object) this.Offset.ClosedContour), ref this.comboBox_5);
    ArrayList EnumItems4 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Offset.Corner, ref EnumItems4);
    buControlCommands.ComboboxAddItem(EnumItems4, Convert.ToInt32((object) this.Offset.Corner), ref this.comboBox_4);
    ArrayList EnumItems5 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Offset.OpenContourOld, ref EnumItems5);
    buControlCommands.ComboboxAddItem(EnumItems5, Convert.ToInt32((object) this.Offset.OpenContourOld), ref this.comboBox_3);
    this.checkBox_3.Checked = this.Offset.Enable;
    this.numericUpDown_22.Value = (Decimal) this.Offset.AdditionalOffset;
    this.numericUpDown_21.Value = (Decimal) this.Offset.Offset;
    this.numericUpDown_23.Value = (Decimal) this.Offset.OffsetCount;
    this.numericUpDown_24.Value = (Decimal) this.Offset.OverlapDistance;
    ArrayList EnumItems6 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.LeadIn.LeadType, ref EnumItems6);
    buControlCommands.ComboboxAddItem(EnumItems6, Convert.ToInt32((object) this.LeadIn.LeadType), ref this.comboBox_1);
    ArrayList EnumItems7 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.LeadOut.LeadType, ref EnumItems7);
    buControlCommands.ComboboxAddItem(EnumItems7, Convert.ToInt32((object) this.LeadOut.LeadType), ref this.comboBox_2);
    this.checkBox_1.Checked = this.LeadIn.Enable;
    this.numericUpDown_15.Value = (Decimal) this.LeadIn.ArcRadius;
    this.numericUpDown_14.Value = (Decimal) this.LeadIn.ArcSweepAngle;
    this.numericUpDown_13.Value = (Decimal) this.LeadIn.Length;
    this.numericUpDown_16.Value = (Decimal) this.LeadIn.TangentAngle;
    this.checkBox_2.Checked = this.LeadOut.Enable;
    this.numericUpDown_18.Value = (Decimal) this.LeadOut.ArcRadius;
    this.numericUpDown_17.Value = (Decimal) this.LeadOut.ArcSweepAngle;
    this.numericUpDown_20.Value = (Decimal) this.LeadOut.Length;
    this.numericUpDown_19.Value = (Decimal) this.LeadOut.TangentAngle;
    this.Result = DialogResult.None;
    this.bool_0 = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.bool_0)
        return;
      if (this.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_10(this);
      this.Result = DialogResult.OK;
      this.Dispose();
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Result = DialogResult.Cancel;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_pre.Name && this.tabControl_0.SelectedIndex > 0)
      --this.tabControl_0.SelectedIndex;
    if (!(control2.Name == this.btn_next.Name) || this.tabControl_0.SelectedIndex >= this.tabControl_0.TabPages.Count - 1)
      return;
    ++this.tabControl_0.SelectedIndex;
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.tabControl_0.SelectedTab.Controls, result, e.Shift);
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (sender.GetType() == typeof (TextBox))
      {
        TextBox textBox = new TextBox();
        buControlCommands.ShowKeyPad((Form) this, (Control) sender);
      }
      if (!(sender.GetType() == typeof (NumericUpDown)))
        return;
      NumericUpDown numericUpDown = new NumericUpDown();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
