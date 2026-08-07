// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Marble.F_CamMarbleSweep
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Marble;

public class F_CamMarbleSweep : Form
{
  public FormProperties Properties = new FormProperties();
  public camParameters camPars = new camParameters();
  public marbleOperation Operation = new marbleOperation();
  public List<ToolBase> Tools = new List<ToolBase>();
  public int SelectedTool = 0;
  public static List<string> Captions = new List<string>();
  public bool ShowHelps = true;
  public bool ShowNextButton = true;
  public bool ShowPreButton = true;
  public int FormHeight = 0;
  public int FormWidth = 0;
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal Panel panel_1;
  internal Label label_1;
  internal Panel panel_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal TabPage tabPage_3;
  internal TabPage tabPage_4;
  internal ImageList imageList_0;
  public Button btn_next;
  public Button btn_pre;
  public Button btn_cancel;
  public Button btn_ok;
  internal CheckBox checkBox_0;
  internal Panel panel_3;
  internal NumericUpDown numericUpDown_2;
  internal Label label_3;
  internal Panel panel_4;
  internal CheckBox checkBox_1;
  internal Label label_4;
  internal Panel panel_5;
  internal Label label_5;
  internal NumericUpDown numericUpDown_3;
  internal Panel panel_6;
  internal Label label_6;
  internal NumericUpDown numericUpDown_4;
  internal Panel panel_7;
  internal Label label_7;
  internal NumericUpDown numericUpDown_5;
  internal CheckBox checkBox_2;
  internal Panel panel_8;
  internal NumericUpDown numericUpDown_6;
  internal Label label_8;
  internal Panel panel_9;
  internal NumericUpDown numericUpDown_7;
  internal Label label_9;
  internal Panel panel_10;
  internal NumericUpDown numericUpDown_8;
  internal Label label_10;
  internal Panel panel_11;
  internal Label label_11;
  internal NumericUpDown numericUpDown_9;
  internal Panel panel_12;
  internal Label label_12;
  internal NumericUpDown numericUpDown_10;
  internal TextBox textBox_0;
  internal ListBox listBox_0;
  internal Panel panel_13;
  internal Label label_13;
  internal ComboBox comboBox_0;
  internal Label label_14;
  internal NumericUpDown numericUpDown_11;
  public Button btn_rampok;
  public Button btn_rampcancel;
  internal Label label_15;
  internal NumericUpDown numericUpDown_12;
  internal Label label_16;
  internal Panel panel_14;
  public Button btn_rampsetshow;
  internal CheckBox checkBox_3;
  internal Label label_17;
  public Button btn_profilecurve;

  public F_CamMarbleSweep() => Class39.smethod_751(this);

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
    ArrayList arrayList = new ArrayList();
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.btn_next.Visible = this.ShowNextButton;
    this.btn_pre.Visible = this.ShowPreButton;
    this.numericUpDown_1.Value = (Decimal) this.Operation.TargetZ;
    this.numericUpDown_0.Value = (Decimal) this.Operation.SweepConstantAngle;
    this.numericUpDown_2.Value = (Decimal) this.Operation.SweepOffsetAngleForTangent;
    this.checkBox_0.Checked = this.Operation.SweepFollowTangent;
    this.checkBox_1.Checked = this.Operation.SweepZUpSharpCorner;
    this.numericUpDown_8.Value = (Decimal) this.camPars.Speeds.Feed;
    this.numericUpDown_6.Value = (Decimal) this.camPars.Speeds.Leave;
    this.numericUpDown_7.Value = (Decimal) this.camPars.Speeds.Plunge;
    this.numericUpDown_10.Value = (Decimal) this.camPars.Distances.Safe;
    this.numericUpDown_9.Value = (Decimal) this.camPars.Distances.StepUp;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Operation.SawRampType, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Operation.SawRampType), ref this.comboBox_0);
    this.numericUpDown_12.Value = (Decimal) this.Operation.SawRampHeight;
    this.numericUpDown_11.Value = (Decimal) this.Operation.SawRampLenght;
    this.checkBox_3.Checked = this.Operation.SawRampEnable;
    if (this.SelectedTool >= 0 & this.SelectedTool <= this.Tools.Count - 1)
    {
      this.textBox_0.Text = buGeneral.GetToolExplanation(this.Tools[this.SelectedTool]);
      this.listBox_0.Items.Clear();
      for (int index = 0; index <= this.Tools.Count - 1; ++index)
        this.listBox_0.Items.Add((object) $"{this.Tools[index].Data.Name} - No : {this.Tools[index].Data.No.ToString()}");
      this.listBox_0.SelectedIndex = this.SelectedTool;
    }
    this.numericUpDown_5.Value = (Decimal) this.camPars.Steps.StartValue;
    this.numericUpDown_4.Value = (Decimal) this.camPars.Steps.EndValue;
    this.numericUpDown_3.Value = (Decimal) this.camPars.Steps.Count;
    this.checkBox_2.Checked = this.camPars.Steps.Enable;
    this.Refresh();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.ControlUpdate();
    Class39.smethod_280(this);
  }

  public void ControlUpdate()
  {
    this.panel_7.Enabled = this.checkBox_2.Checked;
    this.panel_6.Enabled = this.checkBox_2.Checked;
    this.panel_5.Enabled = this.checkBox_2.Checked;
    this.panel_3.Enabled = this.checkBox_0.Checked;
    this.panel_0.Enabled = !this.checkBox_0.Checked;
    this.btn_rampsetshow.Enabled = this.checkBox_3.Checked;
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
      Class39.smethod_590(this);
      this.Properties.Result = DialogResult.OK;
      this.Dispose();
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_pre.Name && this.tabControl_0.SelectedIndex > 0)
      --this.tabControl_0.SelectedIndex;
    if (control2.Name == this.btn_next.Name && this.tabControl_0.SelectedIndex < this.tabControl_0.TabPages.Count - 1)
      ++this.tabControl_0.SelectedIndex;
    if (control2.Name == this.btn_rampsetshow.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (!this.panel_13.Visible)
        this.panel_13.Visible = true;
      else
        this.panel_13.Visible = false;
    }
    if (control2.Name == this.btn_rampcancel.Name)
      this.panel_13.Visible = false;
    if (control2.Name == this.btn_rampok.Name)
    {
      this.Operation.SawRampHeight = (double) this.numericUpDown_12.Value;
      this.Operation.SawRampLenght = (double) this.numericUpDown_11.Value;
      this.Operation.SawRampEnable = this.checkBox_3.Checked;
      this.Operation.SawRampType = (CamZRampType) buGeneral.EnumValueFromInt((object) this.Operation.SawRampType, this.comboBox_0.SelectedIndex);
      this.panel_13.Visible = false;
    }
    if (!(control2.Name == this.btn_profilecurve.Name))
      return;
    this.Properties.Result = DialogResult.Ignore;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    if (this.Properties.Inited)
      ;
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.checkBox_2.Name)
      this.ControlUpdate();
    if (control2.Name == this.checkBox_0.Name)
      this.ControlUpdate();
    if (!(control2.Name == this.checkBox_3.Name))
      return;
    this.ControlUpdate();
  }

  internal void method_4(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
