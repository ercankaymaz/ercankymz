// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Events.F_MoveXYZHeights
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Events;

public class F_MoveXYZHeights : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  public MoveHeightEventVar Settings = new MoveHeightEventVar();
  internal IContainer icontainer_0 = (IContainer) null;
  internal RadioButton radioButton_0;
  internal Panel panel_0;
  internal RadioButton radioButton_1;
  internal NumericUpDown numericUpDown_0;
  internal Button button_0;
  internal ImageList imageList_0;
  internal Label label_0;
  internal Button button_1;
  internal Panel panel_1;
  internal RadioButton radioButton_2;
  internal RadioButton radioButton_3;
  internal Panel panel_2;
  internal RadioButton radioButton_4;
  internal RadioButton radioButton_5;
  public TextBox txt_zbottom;
  public TextBox txt_ztop;
  public TextBox txt_yfrontpos;
  public TextBox txt_ybackpos;
  public TextBox txt_xrightpos;
  public TextBox txt_xfleftpos;

  public F_MoveXYZHeights() => Class39.smethod_354(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.numericUpDown_0.Value = (Decimal) this.Settings.MoveToPosition;
    if (this.Settings.ZType == TopBottomType.Top)
      this.radioButton_0.Checked = true;
    else
      this.radioButton_1.Checked = true;
    if (this.Settings.XType == LeftRightType.Left)
      this.radioButton_5.Checked = true;
    else
      this.radioButton_4.Checked = true;
    if (this.Settings.YType == FrontBackType.Back)
      this.radioButton_3.Checked = true;
    else
      this.radioButton_2.Checked = true;
    if (this.Settings.Axis == AxesXYZ.Z)
    {
      this.panel_2.Visible = false;
      this.panel_1.Visible = false;
      this.panel_0.Visible = true;
      this.panel_0.Location = new Point(5, 7);
    }
    else if (this.Settings.Axis == AxesXYZ.X)
    {
      this.panel_2.Visible = true;
      this.panel_1.Visible = false;
      this.panel_0.Visible = false;
      this.panel_2.Location = new Point(5, 7);
    }
    else if (this.Settings.Axis == AxesXYZ.Y)
    {
      this.panel_2.Visible = false;
      this.panel_1.Visible = true;
      this.panel_0.Visible = false;
      this.panel_1.Location = new Point(5, 7);
    }
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
      if (F_MoveXYZHeights.Captions.Count >= 9)
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
    if (control2.Name == this.button_0.Name)
    {
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      this.Apply();
    }
    if (!(control2.Name == this.button_1.Name))
      return;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    this.Settings.MoveToPosition = (double) this.numericUpDown_0.Value;
    this.Settings.ZType = !this.radioButton_0.Checked ? TopBottomType.Bottom : TopBottomType.Top;
    this.Settings.XType = !this.radioButton_4.Checked ? LeftRightType.Left : LeftRightType.Right;
    if (this.radioButton_3.Checked)
      this.Settings.YType = FrontBackType.Back;
    else
      this.Settings.YType = FrontBackType.Front;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
