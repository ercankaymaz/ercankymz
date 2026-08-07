// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tufting.F_YarnSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Tufting;

public class F_YarnSettings : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  public List<TuftingYarn> Yarns = new List<TuftingYarn>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal ImageList imageList_0;
  public Button btn_cancel;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal Button button_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal Panel panel_0;
  internal Label label_3;
  internal TextBox textBox_0;
  internal ListBox listBox_0;
  internal Button button_2;
  public Button btn_ok;

  public F_YarnSettings() => Class39.smethod_647(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.listBox_0.Items.Clear();
    for (int index = 0; index <= this.Yarns.Count - 1; ++index)
      this.listBox_0.Items.Add((object) this.Yarns[index].Name);
    if (this.Yarns.Count > 0)
      this.listBox_0.SelectedIndex = 0;
    this.ControlUpdate();
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_YarnSettings.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_2.Name && this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Yarns.Count - 1)
    {
      if (this.textBox_0.Text.Trim().Length > 0)
        this.Yarns[this.listBox_0.SelectedIndex].Name = this.textBox_0.Text.Trim();
      this.Yarns[this.listBox_0.SelectedIndex].HundredMeterPerGram = (double) this.numericUpDown_0.Value;
      this.Yarns[this.listBox_0.SelectedIndex].Kat = (double) this.numericUpDown_1.Value;
      this.listBox_0.Items[this.listBox_0.SelectedIndex] = (object) this.Yarns[this.listBox_0.SelectedIndex].Name;
    }
    if (control2.Name == this.button_1.Name && this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Yarns.Count - 1)
    {
      this.Yarns.RemoveAt(this.listBox_0.SelectedIndex);
      this.listBox_0.Items.RemoveAt(this.listBox_0.SelectedIndex);
    }
    if (!(control2.Name == this.button_0.Name))
      return;
    TuftingYarn tuftingYarn = new TuftingYarn();
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "Yarn";
    classViewerDialog.Value = (object) tuftingYarn;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.Yarns.Add((TuftingYarn) classViewerDialog.Value);
    this.listBox_0.Items.Add((object) ((TuftingYarn) classViewerDialog.Value).Name);
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = true;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!(this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Yarns.Count - 1))
      return;
    this.textBox_0.Text = this.Yarns[this.listBox_0.SelectedIndex].Name;
    this.numericUpDown_0.Value = (Decimal) this.Yarns[this.listBox_0.SelectedIndex].HundredMeterPerGram;
    this.numericUpDown_1.Value = (Decimal) this.Yarns[this.listBox_0.SelectedIndex].Kat;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
