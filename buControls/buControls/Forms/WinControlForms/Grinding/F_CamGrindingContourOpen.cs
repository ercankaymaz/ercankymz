// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Grinding.F_CamGrindingContourOpen
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
namespace buControls.Forms.WinControlForms.Grinding;

public class F_CamGrindingContourOpen : Form
{
  public FormProperties Properties = new FormProperties();
  public camParameters camPars = new camParameters();
  public GrindingOperations Operation = new GrindingOperations();
  public List<ToolBase> Tools = new List<ToolBase>();
  public int SelectedTool = 0;
  public bool IsInsideOperation = false;
  public bool ShowHelps = true;
  public bool ShowNextButton = true;
  public bool ShowPreButton = true;
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal Panel panel_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal TabPage tabPage_3;
  internal ImageList imageList_0;
  public Button btn_next;
  public Button btn_pre;
  public Button btn_cancel;
  public Button btn_ok;
  internal TabPage tabPage_4;
  internal Panel panel_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Panel panel_2;
  internal CheckBox checkBox_0;
  internal Label label_2;
  internal TextBox textBox_0;
  internal ListBox listBox_0;
  public Button btn_help;
  internal Panel panel_3;
  internal ComboBox comboBox_0;
  internal Label label_3;
  internal Panel panel_4;
  internal Label label_4;
  internal NumericUpDown numericUpDown_2;
  internal Panel panel_5;
  internal Label label_5;
  internal NumericUpDown numericUpDown_3;
  internal Panel panel_6;
  internal Label label_6;
  internal NumericUpDown numericUpDown_4;
  internal Panel panel_7;
  internal Label label_7;
  internal NumericUpDown numericUpDown_5;
  internal Label label_8;
  internal NumericUpDown numericUpDown_6;
  internal Label label_9;
  internal NumericUpDown numericUpDown_7;
  internal Label label_10;
  internal NumericUpDown numericUpDown_8;
  internal Label label_11;
  internal NumericUpDown numericUpDown_9;
  internal ComboBox comboBox_1;
  internal ComboBox comboBox_2;
  internal PictureBox pictureBox_0;
  internal Label label_12;
  internal NumericUpDown numericUpDown_10;
  internal Label label_13;
  internal NumericUpDown numericUpDown_11;
  internal Label label_14;
  internal NumericUpDown numericUpDown_12;
  internal Label label_15;
  internal NumericUpDown numericUpDown_13;
  internal CheckBox checkBox_1;
  internal Label label_16;
  internal NumericUpDown numericUpDown_14;
  internal Label label_17;
  internal NumericUpDown numericUpDown_15;
  internal CheckBox checkBox_2;

  public F_CamGrindingContourOpen() => Class39.smethod_46(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
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
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    this.btn_next.Visible = this.ShowNextButton;
    this.btn_pre.Visible = this.ShowPreButton;
    this.btn_help.Visible = this.ShowHelps;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.camPars.Offsets.OpenContourOld, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.camPars.Offsets.OpenContourOld), ref this.comboBox_0);
    this.comboBox_0.Items.RemoveAt(4);
    this.comboBox_0.Items.RemoveAt(3);
    this.numericUpDown_0.Value = (Decimal) this.camPars.Operations.TargetZ;
    this.numericUpDown_1.Value = (Decimal) this.camPars.Offsets.Offset;
    this.checkBox_0.Checked = this.camPars.Offsets.AddToolDiameterAsOffset;
    this.numericUpDown_4.Value = (Decimal) this.camPars.Speeds.Feed;
    this.numericUpDown_2.Value = (Decimal) this.camPars.Speeds.Leave;
    this.numericUpDown_3.Value = (Decimal) this.camPars.Speeds.Plunge;
    this.numericUpDown_5.Value = (Decimal) this.camPars.Distances.Safe;
    EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.camPars.LeadIn.LeadType, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.camPars.LeadIn.LeadType), ref this.comboBox_2);
    EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.camPars.LeadOut.LeadType, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.camPars.LeadOut.LeadType), ref this.comboBox_1);
    this.numericUpDown_14.Value = (Decimal) this.camPars.LeadIn.ExtendLength;
    this.numericUpDown_15.Value = (Decimal) this.camPars.LeadIn.ArcRadius;
    this.numericUpDown_11.Value = (Decimal) this.camPars.LeadIn.ArcSweepAngle;
    this.numericUpDown_9.Value = (Decimal) this.camPars.LeadIn.TangentAngle;
    this.numericUpDown_7.Value = (Decimal) this.camPars.LeadIn.Length;
    this.numericUpDown_12.Value = (Decimal) this.camPars.LeadOut.ExtendLength;
    this.numericUpDown_13.Value = (Decimal) this.camPars.LeadOut.ArcRadius;
    this.numericUpDown_10.Value = (Decimal) this.camPars.LeadOut.ArcSweepAngle;
    this.numericUpDown_8.Value = (Decimal) this.camPars.LeadOut.TangentAngle;
    this.numericUpDown_6.Value = (Decimal) this.camPars.LeadOut.Length;
    this.checkBox_2.Checked = this.camPars.LeadIn.Enable;
    this.checkBox_1.Checked = this.camPars.LeadOut.Enable;
    if (this.comboBox_2.SelectedIndex == 0)
    {
      this.label_11.Enabled = false;
      this.label_17.Enabled = true;
      this.label_13.Enabled = true;
      this.numericUpDown_9.Enabled = false;
      this.numericUpDown_11.Enabled = true;
      this.numericUpDown_15.Enabled = true;
    }
    if (this.comboBox_2.SelectedIndex == 1)
    {
      this.label_11.Enabled = true;
      this.label_17.Enabled = false;
      this.label_13.Enabled = false;
      this.numericUpDown_9.Enabled = true;
      this.numericUpDown_11.Enabled = false;
      this.numericUpDown_15.Enabled = false;
    }
    if (this.comboBox_1.SelectedIndex == 0)
    {
      this.label_10.Enabled = false;
      this.label_15.Enabled = true;
      this.label_12.Enabled = true;
      this.numericUpDown_8.Enabled = false;
      this.numericUpDown_10.Enabled = true;
      this.numericUpDown_13.Enabled = true;
    }
    if (this.comboBox_1.SelectedIndex == 1)
    {
      this.label_10.Enabled = true;
      this.label_15.Enabled = false;
      this.label_12.Enabled = false;
      this.numericUpDown_8.Enabled = true;
      this.numericUpDown_10.Enabled = false;
      this.numericUpDown_13.Enabled = false;
    }
    if (this.SelectedTool >= 0 & this.SelectedTool <= this.Tools.Count - 1)
    {
      this.textBox_0.Text = buGeneral.GetToolExplanation(this.Tools[this.SelectedTool]);
      this.listBox_0.Items.Clear();
      for (int index = 0; index <= this.Tools.Count - 1; ++index)
        this.listBox_0.Items.Add((object) $"{this.Tools[index].Data.Name} - No : {this.Tools[index].Data.No.ToString()}");
      this.listBox_0.SelectedIndex = this.SelectedTool;
    }
    this.Refresh();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    Class39.smethod_467(this);
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
      Class39.smethod_624(this);
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
    if (!(control2.Name == this.btn_next.Name) || this.tabControl_0.SelectedIndex >= this.tabControl_0.TabPages.Count - 1)
      return;
    ++this.tabControl_0.SelectedIndex;
  }

  internal void method_2(object sender, EventArgs e)
  {
    if (this.Properties.Inited)
      ;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!this.Properties.TouchPad)
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) sender);
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!this.Properties.Inited)
      return;
    this.SelectedTool = this.listBox_0.SelectedIndex;
    this.textBox_0.Text = buGeneral.GetToolExplanation(this.Tools[this.SelectedTool]);
  }

  internal void method_5(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.comboBox_2.Name)
    {
      if (this.comboBox_2.SelectedIndex == 0)
      {
        this.label_11.Enabled = false;
        this.label_9.Enabled = false;
        this.label_17.Enabled = true;
        this.label_13.Enabled = true;
        this.numericUpDown_9.Enabled = false;
        this.numericUpDown_7.Enabled = false;
        this.numericUpDown_11.Enabled = true;
        this.numericUpDown_15.Enabled = true;
      }
      if (this.comboBox_2.SelectedIndex == 1)
      {
        this.label_11.Enabled = true;
        this.label_9.Enabled = true;
        this.label_17.Enabled = false;
        this.label_13.Enabled = false;
        this.numericUpDown_9.Enabled = true;
        this.numericUpDown_7.Enabled = true;
        this.numericUpDown_11.Enabled = false;
        this.numericUpDown_15.Enabled = false;
      }
    }
    if (!(control2.Name == this.comboBox_1.Name))
      return;
    if (this.comboBox_1.SelectedIndex == 0)
    {
      this.label_10.Enabled = false;
      this.label_8.Enabled = false;
      this.label_15.Enabled = true;
      this.label_12.Enabled = true;
      this.numericUpDown_8.Enabled = false;
      this.numericUpDown_6.Enabled = false;
      this.numericUpDown_10.Enabled = true;
      this.numericUpDown_13.Enabled = true;
    }
    if (this.comboBox_1.SelectedIndex != 1)
      return;
    this.label_10.Enabled = true;
    this.label_8.Enabled = true;
    this.label_15.Enabled = false;
    this.label_12.Enabled = false;
    this.numericUpDown_8.Enabled = true;
    this.numericUpDown_6.Enabled = true;
    this.numericUpDown_10.Enabled = false;
    this.numericUpDown_13.Enabled = false;
  }

  internal void method_6(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
