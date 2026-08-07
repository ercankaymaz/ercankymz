// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Grinding.F_CamGrindingHole
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

public class F_CamGrindingHole : Form
{
  public FormProperties Properties = new FormProperties();
  public camParameters camPars = new camParameters();
  public GrindingOperations Operation = new GrindingOperations();
  public List<ToolBase> Tools = new List<ToolBase>();
  public int SelectedTool = 0;
  public bool ShowHelps = true;
  public bool ShowNextButton = true;
  public bool ShowPreButton = true;
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal TabPage tabPage_0;
  internal TextBox textBox_0;
  internal ListBox listBox_0;
  internal TabPage tabPage_1;
  internal ImageList imageList_0;
  public Button btn_next;
  public Button btn_pre;
  public Button btn_cancel;
  public Button btn_help;
  internal TabControl tabControl_0;
  internal TabPage tabPage_2;
  internal Panel panel_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Panel panel_2;
  internal ComboBox comboBox_0;
  internal Label label_2;
  internal Panel panel_3;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal TabPage tabPage_3;
  internal Panel panel_4;
  internal Label label_4;
  internal NumericUpDown numericUpDown_3;
  internal Panel panel_5;
  internal Label label_5;
  internal NumericUpDown numericUpDown_4;
  public Button btn_ok;
  internal Panel panel_6;
  internal Label label_6;
  internal NumericUpDown numericUpDown_5;
  internal Panel panel_7;
  internal Label label_7;
  internal NumericUpDown numericUpDown_6;
  internal Panel panel_8;
  internal Label label_8;
  internal NumericUpDown numericUpDown_7;

  public F_CamGrindingHole() => Class39.smethod_601(this);

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
    buGeneral.GetEnumTypeValues((object) this.camPars.Hole.HoleType, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.camPars.Hole.HoleType), ref this.comboBox_0);
    this.numericUpDown_5.Value = (Decimal) this.camPars.Hole.DownStep;
    this.numericUpDown_6.Value = (Decimal) this.camPars.Hole.UpStep;
    this.numericUpDown_1.Value = (Decimal) this.camPars.Hole.EndHeight;
    this.numericUpDown_2.Value = (Decimal) this.camPars.Hole.StartHeight;
    this.numericUpDown_3.Value = (Decimal) this.camPars.Speeds.Leave;
    this.numericUpDown_4.Value = (Decimal) this.camPars.Speeds.Plunge;
    this.numericUpDown_0.Value = (Decimal) this.camPars.Distances.Safe;
    this.numericUpDown_7.Value = (Decimal) this.camPars.Distances.FirstApproach;
    if (this.SelectedTool >= 0 & this.SelectedTool <= this.Tools.Count - 1)
    {
      this.textBox_0.Text = buGeneral.GetToolExplanation(this.Tools[this.SelectedTool]);
      this.listBox_0.Items.Clear();
      for (int index = 0; index <= this.Tools.Count - 1; ++index)
        this.listBox_0.Items.Add((object) $"{this.Tools[index].Data.Name} - No : {this.Tools[index].Data.No.ToString()}");
    }
    if (this.comboBox_0.SelectedIndex == 0)
    {
      this.panel_6.Enabled = false;
      this.panel_7.Enabled = false;
    }
    if (this.comboBox_0.SelectedIndex == 1)
    {
      this.panel_6.Enabled = true;
      this.panel_7.Enabled = true;
    }
    this.Refresh();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    Class39.smethod_334(this);
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
      Class39.smethod_603(this);
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
    if (!this.Properties.TouchPad)
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) sender);
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (this.comboBox_0.SelectedIndex == 0)
    {
      this.panel_6.Enabled = false;
      this.panel_7.Enabled = false;
    }
    if (this.comboBox_0.SelectedIndex != 1)
      return;
    this.panel_6.Enabled = true;
    this.panel_7.Enabled = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
