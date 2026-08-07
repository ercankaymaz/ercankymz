// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tools.F_ToolDBase
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
namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolDBase : Form
{
  public static List<string> Captions = new List<string>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public List<ToolBase> Tools = new List<ToolBase>();
  public int ToolSelectedIndex = 0;
  public bool DemoMode = false;
  public bool ShowPurpose = true;
  public bool ShowSpindleDir = true;
  public bool ShowGeometry = true;
  public string LangMessageDMode = "You Can't Do This Operation in Demo Mode";
  public string LangMessageRemove = "Do You Want to Remove Tool";
  public string LangMessageThisToolAvailable = "This Tool is Available";
  private bool bool_0 = false;
  private ToolBase toolBase_0 = new ToolBase();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ListBox listBox_0;
  internal TextBox textBox_0;
  internal Label label_0;
  internal ComboBox comboBox_0;
  internal Label label_1;
  internal ComboBox comboBox_1;
  internal Label label_2;
  internal Label label_3;
  internal NumericUpDown numericUpDown_0;
  internal Label label_4;
  internal NumericUpDown numericUpDown_1;
  internal Label label_5;
  internal NumericUpDown numericUpDown_2;
  internal Label label_6;
  internal NumericUpDown numericUpDown_3;
  internal Label label_7;
  internal NumericUpDown numericUpDown_4;
  internal Label label_8;
  internal NumericUpDown numericUpDown_5;
  internal Label label_9;
  internal TextBox textBox_1;
  internal ComboBox comboBox_2;
  internal Label label_10;
  internal Panel panel_0;
  internal Label label_11;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_add;
  public Button btn_edit;
  public Button btn_remove;

  public F_ToolDBase() => Class39.smethod_783(this);

  public event OkCommandWithDataEventHandler OkPressed;

  public event CancelCommandEventHandler CancelPressed;

  public void Init()
  {
    this.bool_0 = false;
    this.label_2.Visible = this.ShowPurpose;
    this.comboBox_1.Visible = this.ShowPurpose;
    this.label_1.Visible = this.ShowGeometry;
    this.comboBox_0.Visible = this.ShowGeometry;
    this.label_10.Visible = this.ShowSpindleDir;
    this.comboBox_2.Visible = this.ShowSpindleDir;
    this.listBox_0.Items.Clear();
    if (this.Tools.Count > 0)
    {
      this.toolBase_0 = new ToolBase(this.Tools[0]);
      for (int index = 0; index <= this.Tools.Count - 1; ++index)
        this.listBox_0.Items.Add((object) $"T{this.Tools[index].Data.No.ToString()} - {this.Tools[index].Data.Name}");
      if (this.ToolSelectedIndex >= 0 & this.ToolSelectedIndex <= this.Tools.Count - 1)
      {
        this.bool_0 = true;
        this.listBox_0.SelectedIndex = this.ToolSelectedIndex;
        this.toolBase_0 = new ToolBase(this.Tools[this.ToolSelectedIndex]);
      }
      else
      {
        this.bool_0 = true;
        this.ToolSelectedIndex = 0;
        this.listBox_0.SelectedIndex = this.ToolSelectedIndex;
        this.toolBase_0 = new ToolBase(this.Tools[this.ToolSelectedIndex]);
      }
    }
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "TooDataBase LoadLanguage";
    try
    {
      if (F_ToolDBase.Captions.Count < 18)
        return;
      this.Text = F_ToolDBase.Captions[0];
      this.label_0.Text = F_ToolDBase.Captions[1];
      this.btn_add.Text = F_ToolDBase.Captions[2];
      this.btn_remove.Text = F_ToolDBase.Captions[3];
      this.btn_edit.Text = F_ToolDBase.Captions[4];
      this.label_11.Text = F_ToolDBase.Captions[5];
      this.label_9.Text = F_ToolDBase.Captions[6];
      this.label_8.Text = F_ToolDBase.Captions[7];
      this.label_7.Text = F_ToolDBase.Captions[8];
      this.label_6.Text = F_ToolDBase.Captions[9];
      this.label_5.Text = F_ToolDBase.Captions[10];
      this.label_4.Text = F_ToolDBase.Captions[11];
      this.label_3.Text = F_ToolDBase.Captions[12];
      this.label_2.Text = F_ToolDBase.Captions[13];
      this.label_1.Text = F_ToolDBase.Captions[14];
      this.label_10.Text = F_ToolDBase.Captions[15];
      this.btn_ok.Text = F_ToolDBase.Captions[16 /*0x10*/];
      this.btn_cancel.Text = F_ToolDBase.Captions[17];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (this.DemoMode)
    {
      buString.MessageBoxError(this.LangMessageDMode);
    }
    else
    {
      this.Result = DialogResult.OK;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithDataEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) this.Tools);
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (this.Owner != null)
      this.Owner.Focus();
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  internal void method_2(object sender, EventArgs e)
  {
    for (int index = 0; index <= this.Tools.Count - 1; ++index)
    {
      if (this.Tools[index].Data.Name.Trim().ToLower() == this.textBox_1.Text.Trim().ToLower())
      {
        buString.MessageBoxWarning(this.LangMessageThisToolAvailable);
        return;
      }
    }
    ToolBase toolBase = new ToolBase();
    toolBase.Data.Name = this.textBox_1.Text;
    toolBase.Data.No = (int) this.numericUpDown_5.Value;
    toolBase.CamData.FeedSpeed = (double) this.numericUpDown_1.Value;
    toolBase.CamData.PlungeSpeed = (double) this.numericUpDown_0.Value;
    toolBase.CamData.SpindleSpeed = (double) this.numericUpDown_2.Value;
    toolBase.Geometry.Diameter = (double) this.numericUpDown_4.Value;
    toolBase.Geometry.Length = (double) this.numericUpDown_3.Value;
    if (this.ShowGeometry)
      toolBase.Geometry.GeometryType = (ToolType) buGeneral.EnumValueFromInt((object) toolBase.Geometry.GeometryType, this.comboBox_0.SelectedIndex);
    if (this.ShowSpindleDir)
      toolBase.CamData.SpindleDirection = (ClockDirectionType) buGeneral.EnumValueFromInt((object) toolBase.CamData.SpindleDirection, this.comboBox_2.SelectedIndex);
    if (this.ShowPurpose)
      toolBase.Purpose = (ToolPurpose) buGeneral.EnumValueFromInt((object) toolBase.Purpose, this.comboBox_1.SelectedIndex);
    this.Tools.Add(toolBase);
    this.Init();
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!(this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Tools.Count - 1) || buString.MessageBoxQuestion(this.LangMessageRemove) != DialogResult.Yes)
      return;
    this.Tools.RemoveAt(this.listBox_0.SelectedIndex);
    this.Init();
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!(this.ToolSelectedIndex >= 0 & this.ToolSelectedIndex <= this.Tools.Count - 1))
      return;
    this.Tools[this.ToolSelectedIndex].Data.Name = this.textBox_1.Text;
    this.Tools[this.ToolSelectedIndex].Data.No = (int) this.numericUpDown_5.Value;
    this.Tools[this.ToolSelectedIndex].CamData.FeedSpeed = (double) this.numericUpDown_1.Value;
    this.Tools[this.ToolSelectedIndex].CamData.PlungeSpeed = (double) this.numericUpDown_0.Value;
    this.Tools[this.ToolSelectedIndex].CamData.SpindleSpeed = (double) this.numericUpDown_2.Value;
    this.Tools[this.ToolSelectedIndex].Geometry.Diameter = (double) this.numericUpDown_4.Value;
    this.Tools[this.ToolSelectedIndex].Geometry.Length = (double) this.numericUpDown_3.Value;
    if (this.ShowGeometry)
      this.Tools[this.ToolSelectedIndex].Geometry.GeometryType = (ToolType) buGeneral.EnumValueFromInt((object) this.Tools[this.ToolSelectedIndex].Geometry.GeometryType, this.comboBox_0.SelectedIndex);
    if (this.ShowSpindleDir)
      this.Tools[this.ToolSelectedIndex].CamData.SpindleDirection = (ClockDirectionType) buGeneral.EnumValueFromInt((object) this.Tools[this.ToolSelectedIndex].CamData.SpindleDirection, this.comboBox_2.SelectedIndex);
    if (this.ShowPurpose)
      this.Tools[this.ToolSelectedIndex].Purpose = (ToolPurpose) buGeneral.EnumValueFromInt((object) this.Tools[this.ToolSelectedIndex].Purpose, this.comboBox_1.SelectedIndex);
    this.Init();
  }

  internal void method_5(object sender, EventArgs e)
  {
  }

  internal void method_6(object sender, EventArgs e)
  {
    if (!this.bool_0)
      return;
    this.toolBase_0 = new ToolBase();
    ToolBase.Copy(this.Tools[this.listBox_0.SelectedIndex], ref this.toolBase_0);
    this.ToolSelectedIndex = this.listBox_0.SelectedIndex;
    this.textBox_1.Text = this.toolBase_0.Data.Name;
    this.numericUpDown_5.Value = (Decimal) this.toolBase_0.Data.No;
    this.numericUpDown_4.Value = (Decimal) this.toolBase_0.Geometry.Diameter;
    this.numericUpDown_3.Value = (Decimal) this.toolBase_0.Geometry.Length;
    this.numericUpDown_2.Value = (Decimal) this.toolBase_0.CamData.SpindleSpeed;
    this.numericUpDown_1.Value = (Decimal) this.toolBase_0.CamData.FeedSpeed;
    this.numericUpDown_0.Value = (Decimal) this.toolBase_0.CamData.PlungeSpeed;
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.toolBase_0.CamData.SpindleDirection, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) this.toolBase_0.CamData.SpindleDirection), ref this.comboBox_2);
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.toolBase_0.Purpose, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.toolBase_0.Purpose), ref this.comboBox_1);
    ArrayList EnumItems3 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.toolBase_0.Geometry.GeometryType, ref EnumItems3);
    buControlCommands.ComboboxAddItem(EnumItems3, Convert.ToInt32((object) this.toolBase_0.Geometry.GeometryType), ref this.comboBox_0);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
