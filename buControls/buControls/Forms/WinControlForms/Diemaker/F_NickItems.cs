// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_NickItems
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_NickItems : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public List<NickItem> Nicks = new List<NickItem>();
  public string strNick = "Nick";
  public string strRemove = "Do You Want to Remove";
  public bool ShowAddRemove = true;
  private bool bool_0 = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal CheckedListBox checkedListBox_0;

  public F_NickItems() => Class39.smethod_643(this);

  public event ApplyCommandEventHandler ApplyPressed;

  public void Init()
  {
    this.bool_0 = false;
    this.checkedListBox_0.Items.Clear();
    for (int index = 0; index <= this.Nicks.Count - 1; ++index)
      this.checkedListBox_0.Items.Add((object) $"{(index + 1).ToString()}-{this.strNick}", this.Nicks[index].Enable);
    this.Result = DialogResult.Cancel;
    this.button_1.Visible = this.ShowAddRemove;
    this.button_0.Visible = this.ShowAddRemove;
    this.bool_0 = true;
    if (this.checkedListBox_0.Items.Count > 0)
      this.checkedListBox_0.SelectedIndex = 0;
    Class39.smethod_515(this);
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
    for (int index = 0; index <= this.Nicks.Count - 1; ++index)
    {
      this.Nicks[index].Enable = true;
      this.checkedListBox_0.SetItemCheckState(index, CheckState.Checked);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandEventHandler_0();
  }

  internal void method_3(object sender, EventArgs e)
  {
    for (int index = 0; index <= this.Nicks.Count - 1; ++index)
    {
      this.Nicks[index].Enable = false;
      this.checkedListBox_0.SetItemCheckState(index, CheckState.Unchecked);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandEventHandler_0();
  }

  internal void method_4(object sender, EventArgs e)
  {
    for (int index = 0; index <= this.Nicks.Count - 1; ++index)
    {
      this.Nicks[index].Width = (double) this.numericUpDown_3.Value;
      this.Nicks[index].Height = (double) this.numericUpDown_2.Value;
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandEventHandler_0();
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (this.checkedListBox_0.SelectedIndex >= 0 & this.checkedListBox_0.SelectedIndex <= this.Nicks.Count - 1)
    {
      this.Nicks[this.checkedListBox_0.SelectedIndex].Width = (double) this.numericUpDown_3.Value;
      this.Nicks[this.checkedListBox_0.SelectedIndex].Height = (double) this.numericUpDown_2.Value;
      this.Nicks[this.checkedListBox_0.SelectedIndex].Offset = (double) this.numericUpDown_1.Value;
      this.Nicks[this.checkedListBox_0.SelectedIndex].ExtractXPosition = (double) this.numericUpDown_0.Value;
      this.Nicks[this.checkedListBox_0.SelectedIndex].Enable = this.checkedListBox_0.GetItemChecked(this.checkedListBox_0.SelectedIndex);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandEventHandler_0();
  }

  internal void method_6(object sender, EventArgs e)
  {
    this.Result = DialogResult.OK;
    for (int index = 0; index <= this.checkedListBox_0.Items.Count - 1; ++index)
    {
      bool itemChecked = this.checkedListBox_0.GetItemChecked(index);
      this.Nicks[index].Enable = itemChecked;
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.applyCommandEventHandler_0();
    }
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_7(object sender, EventArgs e)
  {
    this.Nicks.Add(new NickItem());
    this.Init();
  }

  internal void method_8(object sender, EventArgs e)
  {
    if (!(this.checkedListBox_0.SelectedIndex >= 0 & this.checkedListBox_0.SelectedIndex <= this.Nicks.Count - 1 & this.bool_0) || buString.MessageBoxQuestion(this.strRemove) != DialogResult.Yes)
      return;
    this.Nicks.RemoveAt(this.checkedListBox_0.SelectedIndex);
    this.Init();
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandEventHandler_0();
  }

  internal void method_9(object sender, EventArgs e)
  {
    if (!(this.checkedListBox_0.SelectedIndex >= 0 & this.checkedListBox_0.SelectedIndex <= this.Nicks.Count - 1 & this.bool_0))
      return;
    this.numericUpDown_3.Value = (Decimal) this.Nicks[this.checkedListBox_0.SelectedIndex].Width;
    this.numericUpDown_2.Value = (Decimal) this.Nicks[this.checkedListBox_0.SelectedIndex].Height;
    this.numericUpDown_1.Value = (Decimal) this.Nicks[this.checkedListBox_0.SelectedIndex].Offset;
    this.numericUpDown_0.Value = (Decimal) this.Nicks[this.checkedListBox_0.SelectedIndex].ExtractXPosition;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
