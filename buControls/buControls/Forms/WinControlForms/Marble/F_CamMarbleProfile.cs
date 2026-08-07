// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Marble.F_CamMarbleProfile
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

public class F_CamMarbleProfile : Form
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
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal ImageList imageList_0;
  public Button btn_next;
  public Button btn_pre;
  public Button btn_cancel;
  public Button btn_ok;
  internal TextBox textBox_0;
  internal ListBox listBox_0;
  internal Panel panel_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Panel panel_1;
  internal Label label_1;
  internal Panel panel_2;
  internal Label label_2;
  internal Panel panel_3;
  internal Label label_3;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal Panel panel_4;
  internal Label label_4;
  internal NumericUpDown numericUpDown_4;

  public F_CamMarbleProfile() => Class39.smethod_841(this);

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
    this.btn_next.Visible = this.ShowNextButton;
    this.btn_pre.Visible = this.ShowPreButton;
    this.numericUpDown_3.Value = (Decimal) this.camPars.Speeds.Feed;
    this.numericUpDown_1.Value = (Decimal) this.camPars.Speeds.Leave;
    this.numericUpDown_2.Value = (Decimal) this.camPars.Speeds.Plunge;
    this.numericUpDown_0.Value = (Decimal) this.camPars.Distances.Safe;
    this.numericUpDown_4.Value = (Decimal) this.camPars.Distances.StepUp;
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
    this.ControlUpdate();
    Class39.smethod_574(this);
  }

  public void ControlUpdate()
  {
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
      Class39.smethod_9(this);
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
