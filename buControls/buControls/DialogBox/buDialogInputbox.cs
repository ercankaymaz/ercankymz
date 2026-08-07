// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.buDialogInputbox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using buCore;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox;

public class buDialogInputbox : Form
{
  public string Caption = "MessageBox";
  public double Value = 0.0;
  public int FormWidth = 0;
  public int FormHeight = 0;
  public int DecimalPoint = 2;
  public Color ColorHeader = Color.LightBlue;
  public Color ColorBaseFirst = Color.Black;
  public Color ColorBaseSecond = Color.DarkGray;
  public Color ColorMessage = Color.Silver;
  public Color ColorBottomYes = Color.LightGray;
  public Color ColorBottomNo = Color.LightGray;
  public DialogResult Result = DialogResult.None;
  internal IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  public buButton btn_close;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal ImageList imageList_0;
  internal buSpin buSpin_0;

  public buDialogInputbox() => Class39.smethod_173(this);

  public void Init()
  {
    this.buGround_0.Text = this.Caption;
    this.buSpin_0.Caption.Caption = this.Caption;
    if (this.DecimalPoint >= 0)
      this.buSpin_0.DecimalPoint = this.DecimalPoint;
    this.buSpin_0.Value = this.Value;
    this.SetColors();
  }

  public void Init(string caption, double value)
  {
    this.Caption = caption;
    this.buGround_0.Text = this.Caption;
    this.buSpin_0.Caption.Caption = this.Caption;
    this.Value = value;
    if (this.DecimalPoint >= 0)
      this.buSpin_0.DecimalPoint = this.DecimalPoint;
    this.buSpin_0.Value = value;
    this.SetColors();
  }

  public void Init(string caption, string varname, double value)
  {
    this.Caption = caption;
    this.buGround_0.Text = this.Caption;
    this.buSpin_0.Caption.Caption = varname;
    this.Value = value;
    if (this.DecimalPoint >= 0)
      this.buSpin_0.DecimalPoint = this.DecimalPoint;
    this.buSpin_0.Value = value;
    this.SetColors();
  }

  public void SetColors()
  {
    if (this.FormWidth > 10)
      this.Width = this.FormWidth;
    if (this.FormHeight > 10)
      this.Height = this.FormHeight;
    this.buButton_1.Display.BackColor = this.ColorBottomNo;
    this.buButton_1.ButtonDownDisplay.BackColor = buImage.ColorToneChange(this.ColorBottomNo, 0.9);
    this.buButton_1.ButtonOverDisplay.BackColor = buImage.ColorToneChange(this.ColorBottomNo, 0.8);
    this.buButton_0.Display.BackColor = this.ColorBottomNo;
    this.buButton_0.ButtonDownDisplay.BackColor = buImage.ColorToneChange(this.ColorBottomYes, 0.9);
    this.buButton_0.ButtonOverDisplay.BackColor = buImage.ColorToneChange(this.ColorBottomYes, 0.8);
    this.buGround_0.Display.LineerGradient.FirstColor = this.ColorBaseFirst;
    this.buGround_0.Display.LineerGradient.SecondColor = this.ColorBaseSecond;
    this.buGround_0.DisplayTop.BackColor = this.ColorHeader;
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value = this.buSpin_0.Value;
    this.Result = DialogResult.Yes;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.No;
    this.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
