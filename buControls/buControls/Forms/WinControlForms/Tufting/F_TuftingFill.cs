// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tufting.F_TuftingFill
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
namespace buControls.Forms.WinControlForms.Tufting;

public class F_TuftingFill : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  public TuftingSettings Settings = new TuftingSettings();
  public List<string> LayerNames = new List<string>();
  public int SelectedLayerIndex = 0;
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  internal Panel panel_0;
  internal Label label_0;
  internal Button button_0;
  public Button btn_ok;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal RadioButton radioButton_2;
  internal ComboBox comboBox_0;
  internal Label label_1;
  internal RadioButton radioButton_3;

  public F_TuftingFill() => Class39.smethod_474(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.comboBox_0.Items.Clear();
    for (int index = 0; index <= this.LayerNames.Count - 1; ++index)
      this.comboBox_0.Items.Add((object) this.LayerNames[index]);
    if (this.comboBox_0.Items.Count > 0 & this.SelectedLayerIndex <= this.comboBox_0.Items.Count - 1)
      this.comboBox_0.SelectedIndex = this.SelectedLayerIndex;
    if (this.Settings.FillType == tuftingFillOffsetType.Contour)
      this.radioButton_1.Checked = true;
    else if (this.Settings.FillType == tuftingFillOffsetType.Spiral)
      this.radioButton_2.Checked = true;
    else if (this.Settings.FillType == tuftingFillOffsetType.Straight)
      this.radioButton_0.Checked = true;
    else if (this.Settings.FillType == tuftingFillOffsetType.Trace)
      this.radioButton_3.Checked = true;
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
      if (F_TuftingFill.Captions.Count >= 9)
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
      this.SelectedLayerIndex = this.comboBox_0.SelectedIndex;
      if (this.radioButton_1.Checked)
        this.Settings.FillType = tuftingFillOffsetType.Contour;
      else if (this.radioButton_2.Checked)
        this.Settings.FillType = tuftingFillOffsetType.Spiral;
      else if (this.radioButton_0.Checked)
        this.Settings.FillType = tuftingFillOffsetType.Straight;
      else if (this.radioButton_3.Checked)
        this.Settings.FillType = tuftingFillOffsetType.Trace;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.button_0.Name))
      return;
    if (this.radioButton_2.Checked)
    {
      F_TuftingSpiralSettings tuftingSpiralSettings = new F_TuftingSpiralSettings();
      tuftingSpiralSettings.Settings = new TuftingSettings(this.Settings);
      tuftingSpiralSettings.Init();
      int num = (int) tuftingSpiralSettings.ShowDialog();
      if (tuftingSpiralSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      this.Settings = new TuftingSettings(tuftingSpiralSettings.Settings);
    }
    else if (this.radioButton_0.Checked)
    {
      F_TuftingStraightSettings straightSettings = new F_TuftingStraightSettings();
      straightSettings.Settings = new TuftingSettings(this.Settings);
      straightSettings.Init();
      int num = (int) straightSettings.ShowDialog();
      if (straightSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      this.Settings = new TuftingSettings(straightSettings.Settings);
    }
    else if (this.radioButton_3.Checked)
    {
      F_TuftingTraceSettings tuftingTraceSettings = new F_TuftingTraceSettings();
      tuftingTraceSettings.Settings = new TuftingSettings(this.Settings);
      tuftingTraceSettings.Init();
      int num = (int) tuftingTraceSettings.ShowDialog();
      if (tuftingTraceSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      this.Settings = new TuftingSettings(tuftingTraceSettings.Settings);
    }
    else
    {
      if (!this.radioButton_1.Checked)
        return;
      F_TuftingCounterSettings tuftingCounterSettings = new F_TuftingCounterSettings();
      tuftingCounterSettings.Settings = new TuftingSettings(this.Settings);
      tuftingCounterSettings.Init();
      int num = (int) tuftingCounterSettings.ShowDialog();
      if (tuftingCounterSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      this.Settings = new TuftingSettings(tuftingCounterSettings.Settings);
    }
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
