// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_ProducerSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_ProducerSettings : Form
{
  public static List<string> Captions = new List<string>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public JewelVar ParJewel = new JewelVar();
  public DialogResult Result = DialogResult.None;
  public bool ShowAxisButton = true;
  public bool ShowCncButton = true;
  private IContainer icontainer_0 = (IContainer) null;
  internal ComboBox comboBox_0;
  internal Label label_0;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;
  internal Button button_9;
  internal Button button_10;
  internal Button button_11;
  internal Button button_12;
  internal Button button_13;
  internal Button button_14;
  internal Button button_15;
  internal Button button_16;
  internal Button button_17;

  public F_ProducerSettings() => Class39.smethod_709(this);

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

  public void Init()
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) buFile.FindFilesOneDirectory(this.ParJewel.PostPath, "bupost", FileFilterType.FileWithoutExtension));
    this.comboBox_0.Items.Clear();
    int num = 0;
    for (int index = 0; index <= stringList.Count - 1; ++index)
    {
      this.comboBox_0.Items.Add((object) stringList[index]);
      if (stringList[index].Trim() == this.ParJewel.PostName.Trim())
        num = index;
    }
    if (this.comboBox_0.Items.Count > 0)
      this.comboBox_0.SelectedIndex = num;
    this.button_7.Visible = this.ShowCncButton;
    this.button_8.Visible = this.ShowAxisButton;
    this.button_9.Visible = this.ShowAxisButton;
    this.button_10.Visible = this.ShowAxisButton;
    this.button_13.Visible = this.ShowAxisButton;
    this.button_12.Visible = this.ShowAxisButton;
    this.button_11.Visible = this.ShowAxisButton;
    this.button_16.Visible = this.ShowAxisButton;
    this.button_15.Visible = this.ShowAxisButton;
    this.button_14.Visible = this.ShowAxisButton;
    Class39.smethod_292(this);
    this.Result = DialogResult.None;
  }

  internal void method_1(object sender, EventArgs e)
  {
    if (this.comboBox_0.SelectedIndex >= 0 && new FileInfo($"{this.ParJewel.PostPath}\\{this.comboBox_0.Text}.bupost").Exists)
      this.ParJewel.PostName = this.comboBox_0.Text;
    this.Result = DialogResult.OK;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "Material";
    classViewerDialog.Value = (object) this.ParJewel.JewelMaterialProp;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.JewelMaterialProp = new jewelMaterial((jewelMaterial) classViewerDialog.Value);
  }

  internal void method_4(object sender, EventArgs e)
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "Tangent";
    classViewerDialog.Value = (object) this.ParJewel.JewelTangentProp;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.JewelTangentProp = new jewelTangent((jewelTangent) classViewerDialog.Value);
  }

  internal void method_5(object sender, EventArgs e)
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "Scale";
    classViewerDialog.Value = (object) this.ParJewel.JewelScaleProp;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.JewelScaleProp = new jewelScale((jewelScale) classViewerDialog.Value);
  }

  internal void method_6(object sender, EventArgs e)
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "Cam Rules";
    classViewerDialog.Value = (object) this.ParJewel.JewelCamProp;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.JewelCamProp = new jewelCam((jewelCam) classViewerDialog.Value);
  }

  internal void method_7(object sender, EventArgs e)
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "General";
    classViewerDialog.Value = (object) this.ParJewel.Settings;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.Settings = new jewelSettings((jewelSettings) classViewerDialog.Value);
  }

  internal void method_8(object sender, EventArgs e)
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "CNC";
    classViewerDialog.Value = (object) this.ParJewel.CNCSettings;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Width = 500;
    classViewerDialog.ValuePersentage = 30.0;
    classViewerDialog.DecimalPlace = 4;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.CNCSettings = new CodesysCNCSets((CodesysCNCSets) classViewerDialog.Value);
  }

  internal void method_9(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Width = 500;
    classViewerDialog.ValuePersentage = 30.0;
    classViewerDialog.DecimalPlace = 4;
    if (control2.Name == this.button_8.Name)
    {
      classViewerDialog.Text = "Axis X";
      classViewerDialog.Value = (object) this.ParJewel.AxisXCncSetting;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
      if (classViewerDialog.Result == DialogResult.OK)
        this.ParJewel.AxisXCncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
    }
    if (control2.Name == this.button_9.Name)
    {
      classViewerDialog.Text = "Axis Y";
      classViewerDialog.Value = (object) this.ParJewel.AxisYCncSetting;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
      if (classViewerDialog.Result == DialogResult.OK)
        this.ParJewel.AxisYCncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
    }
    if (control2.Name == this.button_10.Name)
    {
      classViewerDialog.Text = "Axis Z";
      classViewerDialog.Value = (object) this.ParJewel.AxisZCncSetting;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
      if (classViewerDialog.Result == DialogResult.OK)
        this.ParJewel.AxisZCncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
    }
    if (control2.Name == this.button_13.Name)
    {
      classViewerDialog.Text = "Axis A";
      classViewerDialog.Value = (object) this.ParJewel.AxisACncSetting;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
      if (classViewerDialog.Result == DialogResult.OK)
        this.ParJewel.AxisACncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
    }
    if (control2.Name == this.button_12.Name)
    {
      classViewerDialog.Text = "Axis B";
      classViewerDialog.Value = (object) this.ParJewel.AxisBCncSetting;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
      if (classViewerDialog.Result == DialogResult.OK)
        this.ParJewel.AxisBCncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
    }
    if (control2.Name == this.button_11.Name)
    {
      classViewerDialog.Text = "Axis C";
      classViewerDialog.Value = (object) this.ParJewel.AxisCCncSetting;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
      if (classViewerDialog.Result == DialogResult.OK)
        this.ParJewel.AxisCCncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
    }
    if (control2.Name == this.button_16.Name)
    {
      classViewerDialog.Text = "Axis U";
      classViewerDialog.Value = (object) this.ParJewel.AxisUCncSetting;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
      if (classViewerDialog.Result == DialogResult.OK)
        this.ParJewel.AxisUCncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
    }
    if (control2.Name == this.button_15.Name)
    {
      classViewerDialog.Text = "Axis V";
      classViewerDialog.Value = (object) this.ParJewel.AxisVCncSetting;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
      if (classViewerDialog.Result == DialogResult.OK)
        this.ParJewel.AxisVCncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
    }
    if (!(control2.Name == this.button_14.Name))
      return;
    classViewerDialog.Text = "Axis W";
    classViewerDialog.Value = (object) this.ParJewel.AxisWCncSetting;
    classViewerDialog.Init();
    int num1 = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.AxisWCncSetting = new CodesysAxCnc((CodesysAxCnc) classViewerDialog.Value);
  }

  internal void method_10(object sender, EventArgs e)
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Width = 500;
    classViewerDialog.ValuePersentage = 30.0;
    classViewerDialog.DecimalPlace = 4;
    classViewerDialog.Text = "Limits";
    classViewerDialog.Value = (object) this.ParJewel.Limits;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.Limits = new jewelLimits((jewelLimits) classViewerDialog.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
