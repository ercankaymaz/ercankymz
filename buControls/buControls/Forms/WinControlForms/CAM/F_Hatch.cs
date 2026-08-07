// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.CAM.F_Hatch
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.CAM;

public class F_Hatch : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public camParameters camPars = new camParameters();
  public camParametersEnable camParsEnable = new camParametersEnable();
  public bool VelocityTabVisible = true;
  public bool DistanceTabVisible = true;
  public bool OffsetTabVisible = true;
  public bool StepTabVisible = true;
  public bool LeadInTabVisible = true;
  public bool LeadOutTabVisible = true;
  public bool MiscTabVisible = false;
  public bool ShowHelps = true;
  public bool ShowNextButton = true;
  public bool ShowPreButton = true;
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_next;
  public Button btn_pre;
  internal RadioButton radioButton_0;
  internal Panel panel_0;
  internal RadioButton radioButton_1;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal Panel panel_1;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Panel panel_2;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Panel panel_3;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal Panel panel_4;
  internal Label label_3;
  internal NumericUpDown numericUpDown_3;
  internal Panel panel_5;
  internal Label label_4;
  internal NumericUpDown numericUpDown_4;
  internal Panel panel_6;
  internal Label label_5;
  internal NumericUpDown numericUpDown_5;
  internal TabPage tabPage_1;
  internal Panel panel_7;
  internal CheckBox checkBox_0;
  internal Label label_6;
  internal Panel panel_8;
  internal Label label_7;
  internal NumericUpDown numericUpDown_6;
  internal Panel panel_9;
  internal Label label_8;
  internal NumericUpDown numericUpDown_7;
  internal Panel panel_10;
  internal Label label_9;
  internal NumericUpDown numericUpDown_8;
  internal TabPage tabPage_2;
  internal Panel panel_11;
  internal Label label_10;
  internal NumericUpDown numericUpDown_9;
  internal Panel panel_12;
  internal Label label_11;
  internal NumericUpDown numericUpDown_10;
  internal Panel panel_13;
  internal Label label_12;
  internal NumericUpDown numericUpDown_11;
  internal Panel panel_14;
  internal Label label_13;
  internal NumericUpDown numericUpDown_12;
  internal Label label_14;
  internal ComboBox comboBox_0;
  internal CheckBox checkBox_1;
  internal Panel panel_15;
  internal Label label_15;
  internal NumericUpDown numericUpDown_13;
  internal TabPage tabPage_3;
  internal Panel panel_16;
  internal Label label_16;
  internal NumericUpDown numericUpDown_14;
  internal Panel panel_17;
  internal Label label_17;
  internal NumericUpDown numericUpDown_15;
  internal Panel panel_18;
  internal Label label_18;
  internal NumericUpDown numericUpDown_16;
  internal Panel panel_19;
  internal Label label_19;
  internal NumericUpDown numericUpDown_17;
  internal TabPage tabPage_4;
  internal Label label_20;
  internal Panel panel_20;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal PictureBox pictureBox_2;
  internal RadioButton radioButton_2;
  internal Label label_21;
  internal RadioButton radioButton_3;
  internal RadioButton radioButton_4;
  internal Label label_22;
  internal NumericUpDown numericUpDown_18;
  internal Label label_23;
  internal NumericUpDown numericUpDown_19;
  internal Panel panel_21;
  internal Label label_24;
  internal NumericUpDown numericUpDown_20;
  internal Label label_25;
  internal NumericUpDown numericUpDown_21;
  internal Panel panel_22;

  public F_Hatch() => Class39.smethod_18(this);

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
    this.LoadLanguage();
    this.btn_next.Visible = this.ShowNextButton;
    this.btn_pre.Visible = this.ShowPreButton;
    if (!this.MiscTabVisible && this.tabControl_0.TabPages.Count >= 7)
      this.tabControl_0.TabPages.RemoveAt(6);
    if (!this.LeadOutTabVisible && this.tabControl_0.TabPages.Count >= 6)
      this.tabControl_0.TabPages.RemoveAt(5);
    if (!this.LeadInTabVisible && this.tabControl_0.TabPages.Count >= 5)
      this.tabControl_0.TabPages.RemoveAt(4);
    if (!this.StepTabVisible && this.tabControl_0.TabPages.Count >= 4)
      this.tabControl_0.TabPages.RemoveAt(3);
    if (!this.DistanceTabVisible && this.tabControl_0.TabPages.Count >= 3)
      this.tabControl_0.TabPages.RemoveAt(2);
    if (!this.VelocityTabVisible && this.tabControl_0.TabPages.Count >= 2)
      this.tabControl_0.TabPages.RemoveAt(1);
    int Count1 = 0;
    buControlCommands.SetVisiblityOfPanel(ref this.panel_6, this.camParsEnable.SpeedsEnable.Feed, 32 /*0x20*/, 6, ref Count1);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_5, this.camParsEnable.SpeedsEnable.Plunge, 32 /*0x20*/, 6, ref Count1);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_4, this.camParsEnable.SpeedsEnable.Leave, 32 /*0x20*/, 6, ref Count1);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_3, this.camParsEnable.SpeedsEnable.Finish, 32 /*0x20*/, 6, ref Count1);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_2, this.camParsEnable.SpeedsEnable.Rapid, 32 /*0x20*/, 6, ref Count1);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_1, this.camParsEnable.SpeedsEnable.BackwardFeed, 32 /*0x20*/, 6, ref Count1);
    int Count2 = 0;
    buControlCommands.SetVisiblityOfPanel(ref this.panel_10, this.camParsEnable.DistancesEnable.Safe, 32 /*0x20*/, 6, ref Count2);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_8, this.camParsEnable.DistancesEnable.StepUp, 32 /*0x20*/, 6, ref Count2);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_9, this.camParsEnable.DistancesEnable.Air, 32 /*0x20*/, 6, ref Count2);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_7, this.camParsEnable.DistancesEnable.IncrementalSafe, 32 /*0x20*/, 6, ref Count2);
    int Count3 = 0;
    buControlCommands.SetVisiblityOfPanel(ref this.panel_15, this.camParsEnable.StepsEnable.StartValue, 32 /*0x20*/, 40, ref Count3);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_14, this.camParsEnable.StepsEnable.EndValue, 32 /*0x20*/, 40, ref Count3);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_12, this.camParsEnable.StepsEnable.Step, 32 /*0x20*/, 40, ref Count3);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_11, this.camParsEnable.StepsEnable.Count, 32 /*0x20*/, 40, ref Count3);
    buControlCommands.SetVisiblityOfPanel(ref this.panel_13, this.camParsEnable.StepsEnable.Distance, 32 /*0x20*/, 40, ref Count3);
    this.comboBox_0.Visible = this.camParsEnable.StepsEnable.Type;
    this.numericUpDown_14.Value = (Decimal) this.camPars.Hatch.TotalWidth;
    this.numericUpDown_17.Value = (Decimal) this.camPars.Hatch.OperationZ;
    this.numericUpDown_15.Value = (Decimal) this.camPars.Hatch.CutStep;
    this.numericUpDown_16.Value = (Decimal) this.camPars.Hatch.CutLength;
    this.numericUpDown_21.Value = (Decimal) this.camPars.Hatch.CornerPoint.X;
    this.numericUpDown_20.Value = (Decimal) this.camPars.Hatch.CornerPoint.Y;
    if (this.camPars.Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
    {
      this.radioButton_0.Checked = true;
      this.radioButton_1.Checked = false;
    }
    if (this.camPars.Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
    {
      this.radioButton_0.Checked = false;
      this.radioButton_1.Checked = true;
    }
    if (this.camPars.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
    {
      this.radioButton_4.Checked = true;
      this.radioButton_3.Checked = false;
      this.radioButton_2.Checked = false;
    }
    if (this.camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
    {
      this.radioButton_4.Checked = false;
      this.radioButton_3.Checked = true;
      this.radioButton_2.Checked = false;
    }
    if (this.camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
    {
      this.radioButton_4.Checked = false;
      this.radioButton_3.Checked = false;
      this.radioButton_2.Checked = true;
    }
    this.numericUpDown_5.Value = (Decimal) this.camPars.Speeds.Feed;
    this.numericUpDown_0.Value = (Decimal) this.camPars.Speeds.BackwardFeed;
    this.numericUpDown_4.Value = (Decimal) this.camPars.Speeds.Plunge;
    this.numericUpDown_2.Value = (Decimal) this.camPars.Speeds.Finish;
    this.numericUpDown_3.Value = (Decimal) this.camPars.Speeds.Leave;
    this.numericUpDown_1.Value = (Decimal) this.camPars.Speeds.Rapid;
    this.numericUpDown_7.Value = (Decimal) this.camPars.Distances.Air;
    this.checkBox_0.Checked = this.camPars.Distances.IncrementalSafe;
    this.numericUpDown_8.Value = (Decimal) this.camPars.Distances.Safe;
    this.numericUpDown_6.Value = (Decimal) this.camPars.Distances.StepUp;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.camPars.Steps.StepType, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.camPars.Steps.StepType), ref this.comboBox_0);
    this.checkBox_1.Checked = this.camPars.Steps.Enable;
    this.numericUpDown_9.Value = (Decimal) this.camPars.Steps.Count;
    this.numericUpDown_11.Value = (Decimal) this.camPars.Steps.Distance;
    this.numericUpDown_12.Value = (Decimal) this.camPars.Steps.EndValue;
    this.numericUpDown_13.Value = (Decimal) this.camPars.Steps.StartValue;
    this.numericUpDown_10.Value = (Decimal) this.camPars.Steps.Step;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_Hatch.Captions.Count <= 55)
        return;
      this.Text = F_Hatch.Captions[0];
      this.tabPage_3.Text = F_Hatch.Captions[0];
      this.tabPage_0.Text = F_Hatch.Captions[1];
      this.tabPage_1.Text = F_Hatch.Captions[2];
      this.tabPage_2.Text = F_Hatch.Captions[4];
      this.tabPage_4.Text = F_Hatch.Captions[22];
      this.label_19.Text = F_Hatch.Captions[6];
      this.label_18.Text = F_Hatch.Captions[28];
      this.label_17.Text = F_Hatch.Captions[29];
      this.label_25.Text = F_Hatch.Captions[55];
      this.label_20.Text = F_Hatch.Captions[31 /*0x1F*/];
      this.label_21.Text = F_Hatch.Captions[34];
      this.radioButton_0.Text = F_Hatch.Captions[32 /*0x20*/];
      this.radioButton_1.Text = F_Hatch.Captions[33];
      this.radioButton_4.Text = F_Hatch.Captions[35];
      this.radioButton_3.Text = F_Hatch.Captions[36];
      this.radioButton_2.Text = F_Hatch.Captions[37];
      this.btn_next.Text = F_Hatch.Captions[23];
      this.btn_pre.Text = F_Hatch.Captions[22];
      this.btn_ok.Text = F_Hatch.Captions[24];
      this.btn_cancel.Text = F_Hatch.Captions[25];
      this.label_5.Text = F_Hatch.Captions[38];
      this.label_4.Text = F_Hatch.Captions[39];
      this.label_3.Text = F_Hatch.Captions[40];
      this.label_2.Text = F_Hatch.Captions[41];
      this.label_1.Text = F_Hatch.Captions[42];
      this.label_0.Text = F_Hatch.Captions[43];
      this.label_9.Text = F_Hatch.Captions[44];
      this.label_7.Text = F_Hatch.Captions[45];
      this.label_8.Text = F_Hatch.Captions[46];
      this.label_6.Text = F_Hatch.Captions[47];
      this.checkBox_1.Text = F_Hatch.Captions[48 /*0x30*/];
      this.label_14.Text = F_Hatch.Captions[49];
      this.label_15.Text = F_Hatch.Captions[50];
      this.label_13.Text = F_Hatch.Captions[51];
      this.label_12.Text = F_Hatch.Captions[52];
      this.label_11.Text = F_Hatch.Captions[53];
      this.label_10.Text = F_Hatch.Captions[54];
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.pictureBox_2.Name)
      this.radioButton_4.Checked = true;
    if (control2.Name == this.pictureBox_1.Name)
      this.radioButton_3.Checked = true;
    if (!(control2.Name == this.pictureBox_0.Name))
      return;
    this.radioButton_2.Checked = true;
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
      Class39.smethod_319(this);
      this.Properties.Result = DialogResult.OK;
      this.Dispose();
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      this.Dispose();
    }
    if (control2.Name == this.btn_pre.Name && this.tabControl_0.SelectedIndex > 0)
      --this.tabControl_0.SelectedIndex;
    if (!(control2.Name == this.btn_next.Name) || this.tabControl_0.SelectedIndex >= this.tabControl_0.TabPages.Count - 1)
      return;
    ++this.tabControl_0.SelectedIndex;
  }

  internal void method_2(object sender, FormClosingEventArgs e)
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

  internal void method_3(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.tabControl_0.SelectedTab.Controls, result, e.Shift);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
