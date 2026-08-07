// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.HotkeysEditorForm
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns2;
using ns7;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class HotkeysEditorForm : Form
{
  internal BindingList<Class22> bindingList_0 = new BindingList<Class22>();
  private IContainer icontainer_0 = (IContainer) null;
  internal DataGridView dataGridView_0;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Label label_0;
  internal Button button_4;
  internal DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;
  internal DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;
  internal DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

  public HotkeysEditorForm(HotkeysMapping hotkeys)
  {
    Class39.smethod_296(this);
    this.method_1(hotkeys);
    this.dataGridView_0.DataSource = (object) this.bindingList_0;
  }

  private int method_0(Keys keys_0, Keys keys_1)
  {
    int num = ((int) (keys_0 & (Keys.F16 | Keys.F17))).CompareTo((int) (keys_1 & (Keys.F16 | Keys.F17)));
    if (num == 0)
      num = keys_0.CompareTo((object) keys_1);
    return num;
  }

  private void method_1(HotkeysMapping hotkeysMapping_0)
  {
    List<Keys> keysList = new List<Keys>((IEnumerable<Keys>) hotkeysMapping_0.Keys);
    keysList.Sort(new Comparison<Keys>(this.method_0));
    this.bindingList_0.Clear();
    foreach (Keys keys in keysList)
      this.bindingList_0.Add(new Class22(keys, hotkeysMapping_0[keys]));
  }

  public HotkeysMapping GetHotkeys()
  {
    HotkeysMapping hotkeys = new HotkeysMapping();
    foreach (Class22 class22_0 in (Collection<Class22>) this.bindingList_0)
      hotkeys[Class39.smethod_28(class22_0)] = class22_0.method_2();
    return hotkeys;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.bindingList_0.Add(new Class22(Keys.None, FCTBAction.None));
  }

  internal void method_3(object sender, DataGridViewRowsAddedEventArgs e)
  {
    DataGridViewComboBoxCell viewComboBoxCell1 = this.dataGridView_0[0, e.RowIndex] as DataGridViewComboBoxCell;
    if (viewComboBoxCell1.Items.Count == 0)
    {
      string[] strArray = new string[8]
      {
        "",
        "Ctrl",
        "Ctrl + Shift",
        "Ctrl + Alt",
        "Shift",
        "Shift + Alt",
        "Alt",
        "Ctrl + Shift + Alt"
      };
      foreach (string str in strArray)
        viewComboBoxCell1.Items.Add((object) str);
    }
    DataGridViewComboBoxCell viewComboBoxCell2 = this.dataGridView_0[1, e.RowIndex] as DataGridViewComboBoxCell;
    if (viewComboBoxCell2.Items.Count == 0)
    {
      foreach (object obj in Enum.GetValues(typeof (Keys)))
        viewComboBoxCell2.Items.Add(obj);
    }
    DataGridViewComboBoxCell viewComboBoxCell3 = this.dataGridView_0[2, e.RowIndex] as DataGridViewComboBoxCell;
    if (viewComboBoxCell3.Items.Count != 0)
      return;
    foreach (object obj in Enum.GetValues(typeof (FCTBAction)))
      viewComboBoxCell3.Items.Add(obj);
  }

  internal void method_4(object sender, EventArgs e)
  {
    HotkeysMapping hotkeysMapping_0 = new HotkeysMapping();
    hotkeysMapping_0.InitDefault();
    this.method_1(hotkeysMapping_0);
  }

  internal void method_5(object sender, EventArgs e)
  {
    for (int index = this.dataGridView_0.RowCount - 1; index >= 0; --index)
    {
      if (this.dataGridView_0.Rows[index].Selected)
        this.dataGridView_0.Rows.RemoveAt(index);
    }
  }

  internal void method_6(object sender, FormClosingEventArgs e)
  {
    if (this.DialogResult != DialogResult.OK)
      return;
    string str = Class39.smethod_495(this);
    if (string.IsNullOrEmpty(str) || MessageBox.Show($"Some actions are not assigned!\r\nActions: {str}\r\nPress Yes to save and exit, press No to continue editing", "Some actions is not assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
      return;
    e.Cancel = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
