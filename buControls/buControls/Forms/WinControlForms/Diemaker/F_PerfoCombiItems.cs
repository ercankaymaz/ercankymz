// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_PerfoCombiItems
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
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_PerfoCombiItems : Form
{
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public List<PerfoCombiItem> Perfo = new List<PerfoCombiItem>();
  public DiemakerPerfoPropSettings PerfoPropVar = new DiemakerPerfoPropSettings();
  public BendingJob Job = new BendingJob();
  public string strPerfo = nameof (Perfo);
  public string strRemove = "Do You Want to Remove";
  public bool ShowAddRemove = true;
  public bool ShowPerfoCombiList = true;
  public static List<string> Captions = new List<string>();
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal NumericUpDown numericUpDown_5;
  internal Label label_5;
  internal NumericUpDown numericUpDown_6;
  internal Label label_6;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal CheckedListBox checkedListBox_0;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Label label_7;
  internal ComboBox comboBox_0;
  internal Label label_8;
  internal PictureBox pictureBox_0;
  internal Button button_4;
  internal ImageList imageList_0;
  internal Button button_5;
  internal Button button_6;

  public F_PerfoCombiItems() => Class39.smethod_249(this);

  public event ApplyCommandWithBoolEventHandler ApplyPressed;

  public void Init()
  {
    this.bool_0 = false;
    this.checkedListBox_0.Items.Clear();
    for (int index = 0; index <= this.Perfo.Count - 1; ++index)
      this.checkedListBox_0.Items.Add((object) $"{(index + 1).ToString()}-{this.strPerfo} - {this.Perfo[index].PerfoType.ToString()}", (this.Perfo[index].Enable ? 1 : 0) != 0);
    if (this.Perfo.Count > 1)
    {
      this.numericUpDown_5.Enabled = true;
      this.numericUpDown_6.Enabled = true;
      this.button_2.Enabled = true;
      this.button_3.Enabled = true;
    }
    else
    {
      this.numericUpDown_5.Enabled = false;
      this.numericUpDown_6.Enabled = false;
      this.button_2.Enabled = false;
      this.button_3.Enabled = false;
    }
    this.numericUpDown_4.Value = (Decimal) this.PerfoPropVar.EndOffset;
    this.numericUpDown_6.Value = (Decimal) this.PerfoPropVar.EndPosition;
    this.numericUpDown_1.Value = (Decimal) this.PerfoPropVar.FamaleWidth;
    this.numericUpDown_0.Value = (Decimal) this.PerfoPropVar.MaleWidth;
    this.numericUpDown_2.Value = (Decimal) this.PerfoPropVar.PerfoHeight;
    this.numericUpDown_3.Value = (Decimal) this.PerfoPropVar.StartOffset;
    this.numericUpDown_5.Value = (Decimal) this.PerfoPropVar.StartPosition;
    this.checkBox_1.Checked = this.PerfoPropVar.MultiPerfo;
    this.numericUpDown_5.Enabled = this.PerfoPropVar.MultiPerfo;
    this.numericUpDown_6.Enabled = this.PerfoPropVar.MultiPerfo;
    this.button_2.Enabled = this.PerfoPropVar.MultiPerfo;
    this.button_3.Enabled = this.PerfoPropVar.MultiPerfo;
    if (this.Perfo.Count > 0)
    {
      this.numericUpDown_4.Value = (Decimal) this.Perfo[0].EndOffset;
      this.numericUpDown_6.Value = (Decimal) this.Perfo[0].EndPoint;
      this.numericUpDown_1.Value = (Decimal) this.Perfo[0].FemaleWidth;
      this.numericUpDown_0.Value = (Decimal) this.Perfo[0].MaleWidth;
      this.numericUpDown_3.Value = (Decimal) this.Perfo[0].StartOffset;
      this.numericUpDown_5.Value = (Decimal) this.Perfo[0].StartPoint;
      this.numericUpDown_2.Value = (Decimal) this.Perfo[0].PerfoHeight;
      this.checkBox_0.Checked = this.Perfo[0].Enable;
      this.comboBox_0.SelectedIndex = Convert.ToInt32((object) this.Perfo[0].PerfoType);
    }
    if (this.Perfo.Count == 0)
      this.checkBox_0.Checked = false;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) DiemakerPerfoType.MaleMale, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) DiemakerPerfoType.MaleMale), ref this.comboBox_0);
    this.comboBox_0.SelectedIndex = Convert.ToInt32((object) this.PerfoPropVar.PerfoType);
    this.button_2.Visible = this.ShowAddRemove;
    this.button_3.Visible = this.ShowAddRemove;
    this.button_2.Visible = this.ShowPerfoCombiList;
    this.button_3.Visible = this.ShowPerfoCombiList;
    this.checkBox_1.Visible = this.ShowPerfoCombiList;
    this.checkedListBox_0.Visible = this.ShowPerfoCombiList;
    if (this.ShowPerfoCombiList)
      this.Width = 580;
    else
      this.Width = 260;
    this.Result = DialogResult.Cancel;
    this.pictureBox_0.Image = this.imageList_0.Images[this.comboBox_0.SelectedIndex];
    this.bool_0 = true;
    if (this.checkedListBox_0.Items.Count > 0)
      this.checkedListBox_0.SelectedIndex = 0;
    Class39.smethod_120(this);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
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

  internal void method_1(object sender, EventArgs e)
  {
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.PerfoPropVar.EndOffset = (double) this.numericUpDown_4.Value;
    this.PerfoPropVar.EndPosition = (double) this.numericUpDown_6.Value;
    this.PerfoPropVar.FamaleWidth = (double) this.numericUpDown_1.Value;
    this.PerfoPropVar.MaleWidth = (double) this.numericUpDown_0.Value;
    this.PerfoPropVar.PerfoHeight = (double) this.numericUpDown_2.Value;
    this.PerfoPropVar.StartOffset = (double) this.numericUpDown_3.Value;
    this.PerfoPropVar.StartPosition = (double) this.numericUpDown_5.Value;
    this.PerfoPropVar.MultiPerfo = this.checkBox_1.Checked;
    this.PerfoPropVar.PerfoType = (DiemakerPerfoType) buGeneral.EnumValueFromInt((object) this.PerfoPropVar.PerfoType, this.comboBox_0.SelectedIndex);
    if (!this.PerfoPropVar.MultiPerfo)
    {
      this.Perfo.Clear();
      if (this.checkBox_0.Checked)
      {
        PerfoCombiItem perfoCombiItem = new PerfoCombiItem()
        {
          Enable = this.checkBox_0.Checked,
          EndOffset = (double) this.numericUpDown_4.Value,
          EndPoint = this.Job.Information.CalculatedLength,
          FemaleWidth = (double) this.numericUpDown_1.Value,
          MaleWidth = (double) this.numericUpDown_0.Value,
          PerfoHeight = (double) this.numericUpDown_2.Value,
          StartOffset = (double) this.numericUpDown_3.Value,
          StartPoint = 0.0
        };
        perfoCombiItem.PerfoType = (DiemakerPerfoType) buGeneral.EnumValueFromInt((object) perfoCombiItem.PerfoType, this.comboBox_0.SelectedIndex);
        this.Perfo.Add(perfoCombiItem);
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.applyCommandWithBoolEventHandler_0(false);
    }
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    this.Result = DialogResult.OK;
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.PerfoPropVar.EndOffset = (double) this.numericUpDown_4.Value;
    this.PerfoPropVar.EndPosition = (double) this.numericUpDown_6.Value;
    this.PerfoPropVar.FamaleWidth = (double) this.numericUpDown_1.Value;
    this.PerfoPropVar.MaleWidth = (double) this.numericUpDown_0.Value;
    this.PerfoPropVar.PerfoHeight = (double) this.numericUpDown_2.Value;
    this.PerfoPropVar.StartOffset = (double) this.numericUpDown_3.Value;
    this.PerfoPropVar.StartPosition = (double) this.numericUpDown_5.Value;
    this.PerfoPropVar.MultiPerfo = this.checkBox_1.Checked;
    PerfoCombiItem perfoCombiItem = new PerfoCombiItem()
    {
      Enable = this.checkBox_0.Checked,
      EndOffset = (double) this.numericUpDown_4.Value,
      EndPoint = (double) this.numericUpDown_6.Value,
      FemaleWidth = (double) this.numericUpDown_1.Value,
      MaleWidth = (double) this.numericUpDown_0.Value,
      PerfoHeight = (double) this.numericUpDown_2.Value,
      StartOffset = (double) this.numericUpDown_3.Value,
      StartPoint = (double) this.numericUpDown_5.Value
    };
    perfoCombiItem.PerfoType = (DiemakerPerfoType) buGeneral.EnumValueFromInt((object) perfoCombiItem.PerfoType, this.comboBox_0.SelectedIndex);
    this.Perfo.Add(perfoCombiItem);
    this.checkedListBox_0.Items.Clear();
    for (int index = 0; index <= this.Perfo.Count - 1; ++index)
      this.checkedListBox_0.Items.Add((object) $"{(index + 1).ToString()}-{this.strPerfo} - {perfoCombiItem.PerfoType.ToString()}", (this.Perfo[index].Enable ? 1 : 0) != 0);
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithBoolEventHandler_0(false);
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!(this.checkedListBox_0.SelectedIndex >= 0 & this.checkedListBox_0.SelectedIndex <= this.Perfo.Count - 1 & this.bool_0) || buString.MessageBoxQuestion(this.strRemove) != DialogResult.Yes)
      return;
    this.Perfo.RemoveAt(this.checkedListBox_0.SelectedIndex);
    this.Init();
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithBoolEventHandler_0(false);
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (!this.bool_0)
      return;
    if (this.checkBox_1.Checked)
    {
      this.numericUpDown_5.Enabled = true;
      this.numericUpDown_6.Enabled = true;
      this.button_2.Enabled = true;
      this.button_3.Enabled = true;
    }
    else
    {
      this.numericUpDown_5.Enabled = false;
      this.numericUpDown_6.Enabled = false;
      this.button_2.Enabled = false;
      this.button_3.Enabled = false;
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    if (!(this.checkedListBox_0.SelectedIndex >= 0 & this.checkedListBox_0.SelectedIndex <= this.Perfo.Count - 1 & this.bool_0))
      return;
    this.numericUpDown_4.Value = (Decimal) this.Perfo[this.checkedListBox_0.SelectedIndex].EndOffset;
    this.numericUpDown_6.Value = (Decimal) this.Perfo[this.checkedListBox_0.SelectedIndex].EndPoint;
    this.numericUpDown_1.Value = (Decimal) this.Perfo[this.checkedListBox_0.SelectedIndex].FemaleWidth;
    this.numericUpDown_0.Value = (Decimal) this.Perfo[this.checkedListBox_0.SelectedIndex].MaleWidth;
    this.numericUpDown_3.Value = (Decimal) this.Perfo[this.checkedListBox_0.SelectedIndex].StartOffset;
    this.numericUpDown_5.Value = (Decimal) this.Perfo[this.checkedListBox_0.SelectedIndex].StartPoint;
    this.numericUpDown_2.Value = (Decimal) this.Perfo[this.checkedListBox_0.SelectedIndex].PerfoHeight;
    this.checkBox_0.Checked = this.Perfo[this.checkedListBox_0.SelectedIndex].Enable;
    this.comboBox_0.SelectedIndex = Convert.ToInt32((object) this.Perfo[this.checkedListBox_0.SelectedIndex].PerfoType);
  }

  internal void method_7(object sender, EventArgs e)
  {
    if (!(this.checkedListBox_0.SelectedIndex >= 0 & this.checkedListBox_0.SelectedIndex <= this.Perfo.Count - 1 & this.bool_0))
      return;
    this.Perfo[this.checkedListBox_0.SelectedIndex].EndOffset = (double) this.numericUpDown_4.Value;
    this.Perfo[this.checkedListBox_0.SelectedIndex].EndPoint = (double) this.numericUpDown_6.Value;
    this.Perfo[this.checkedListBox_0.SelectedIndex].FemaleWidth = (double) this.numericUpDown_1.Value;
    this.Perfo[this.checkedListBox_0.SelectedIndex].MaleWidth = (double) this.numericUpDown_0.Value;
    this.Perfo[this.checkedListBox_0.SelectedIndex].StartOffset = (double) this.numericUpDown_3.Value;
    this.Perfo[this.checkedListBox_0.SelectedIndex].StartPoint = (double) this.numericUpDown_5.Value;
    this.Perfo[this.checkedListBox_0.SelectedIndex].PerfoHeight = (double) this.numericUpDown_2.Value;
    this.Perfo[this.checkedListBox_0.SelectedIndex].Enable = this.checkBox_0.Checked;
    this.Perfo[this.checkedListBox_0.SelectedIndex].PerfoType = (DiemakerPerfoType) buGeneral.EnumValueFromInt((object) this.Perfo[this.checkedListBox_0.SelectedIndex].PerfoType, this.comboBox_0.SelectedIndex);
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithBoolEventHandler_0(false);
  }

  internal void method_8(object sender, EventArgs e)
  {
    if (!this.bool_0)
      return;
    this.pictureBox_0.Image = this.imageList_0.Images[this.comboBox_0.SelectedIndex];
  }

  internal void method_9(object sender, EventArgs e)
  {
    this.PerfoPropVar.EndOffset = (double) this.numericUpDown_4.Value;
    this.PerfoPropVar.EndPosition = (double) this.numericUpDown_6.Value;
    this.PerfoPropVar.FamaleWidth = (double) this.numericUpDown_1.Value;
    this.PerfoPropVar.MaleWidth = (double) this.numericUpDown_0.Value;
    this.PerfoPropVar.PerfoHeight = (double) this.numericUpDown_2.Value;
    this.PerfoPropVar.StartOffset = (double) this.numericUpDown_3.Value;
    this.PerfoPropVar.StartPosition = (double) this.numericUpDown_5.Value;
    this.PerfoPropVar.MultiPerfo = this.checkBox_1.Checked;
    this.PerfoPropVar.PerfoType = (DiemakerPerfoType) buGeneral.EnumValueFromInt((object) this.PerfoPropVar.PerfoType, this.comboBox_0.SelectedIndex);
    if (!this.PerfoPropVar.MultiPerfo)
    {
      this.Perfo.Clear();
      if (this.checkBox_0.Checked)
      {
        PerfoCombiItem perfoCombiItem = new PerfoCombiItem()
        {
          Enable = this.checkBox_0.Checked,
          EndOffset = (double) this.numericUpDown_4.Value,
          EndPoint = this.Job.Information.CalculatedLength,
          FemaleWidth = (double) this.numericUpDown_1.Value,
          MaleWidth = (double) this.numericUpDown_0.Value,
          PerfoHeight = (double) this.numericUpDown_2.Value,
          StartOffset = (double) this.numericUpDown_3.Value,
          StartPoint = 0.0
        };
        perfoCombiItem.PerfoType = (DiemakerPerfoType) buGeneral.EnumValueFromInt((object) perfoCombiItem.PerfoType, this.comboBox_0.SelectedIndex);
        this.Perfo.Add(perfoCombiItem);
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithBoolEventHandler_0(false);
  }

  internal void method_10(object sender, EventArgs e)
  {
    this.PerfoPropVar.EndOffset = (double) this.numericUpDown_4.Value;
    this.PerfoPropVar.EndPosition = (double) this.numericUpDown_6.Value;
    this.PerfoPropVar.FamaleWidth = (double) this.numericUpDown_1.Value;
    this.PerfoPropVar.MaleWidth = (double) this.numericUpDown_0.Value;
    this.PerfoPropVar.PerfoHeight = (double) this.numericUpDown_2.Value;
    this.PerfoPropVar.StartOffset = (double) this.numericUpDown_3.Value;
    this.PerfoPropVar.StartPosition = (double) this.numericUpDown_5.Value;
    this.PerfoPropVar.MultiPerfo = this.checkBox_1.Checked;
    this.PerfoPropVar.PerfoType = (DiemakerPerfoType) buGeneral.EnumValueFromInt((object) this.PerfoPropVar.PerfoType, this.comboBox_0.SelectedIndex);
    if (!this.PerfoPropVar.MultiPerfo)
    {
      this.Perfo.Clear();
      if (this.checkBox_0.Checked)
      {
        PerfoCombiItem perfoCombiItem = new PerfoCombiItem()
        {
          Enable = this.checkBox_0.Checked,
          EndOffset = (double) this.numericUpDown_4.Value,
          EndPoint = this.Job.Information.CalculatedLength,
          FemaleWidth = (double) this.numericUpDown_1.Value,
          MaleWidth = (double) this.numericUpDown_0.Value,
          PerfoHeight = (double) this.numericUpDown_2.Value,
          StartOffset = (double) this.numericUpDown_3.Value,
          StartPoint = 0.0
        };
        perfoCombiItem.PerfoType = (DiemakerPerfoType) buGeneral.EnumValueFromInt((object) perfoCombiItem.PerfoType, this.comboBox_0.SelectedIndex);
        this.Perfo.Add(perfoCombiItem);
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithBoolEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithBoolEventHandler_0(true);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
