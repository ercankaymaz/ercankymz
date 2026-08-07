// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Drawings.F_CustomText
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.UserControls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Drawings;

public class F_CustomText : Form
{
  public static List<string> Captions = new List<string>();
  public TextCustomData TextData = new TextCustomData();
  public DialogResult Result = DialogResult.None;
  public bool ShowFont = false;
  private IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal TextBox textBox_0;
  internal buContentAlignment buContentAlignment_0;
  internal Label label_2;
  internal Label label_3;
  public Button btn_font;
  internal Label label_4;
  internal NumericUpDown numericUpDown_1;
  internal Label label_5;
  internal NumericUpDown numericUpDown_2;

  public F_CustomText() => Class39.smethod_812(this);

  public void Init()
  {
    this.TextData.FontName = "";
    this.textBox_0.Text = this.TextData.Text;
    this.numericUpDown_0.Value = (Decimal) this.TextData.Height;
    this.numericUpDown_1.Value = (Decimal) this.TextData.CharSpace;
    this.numericUpDown_2.Value = (Decimal) this.TextData.SpaceValue;
    this.btn_font.Text = this.TextData.FontName;
    this.btn_font.Visible = this.ShowFont;
    this.label_3.Visible = this.ShowFont;
    this.buContentAlignment_0.Alignment = this.TextData.Alignment;
    Class39.smethod_316(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      this.TextData.Text = this.textBox_0.Text;
      this.TextData.Height = (double) this.numericUpDown_0.Value;
      this.TextData.SpaceValue = (double) this.numericUpDown_2.Value;
      this.TextData.CharSpace = (double) this.numericUpDown_1.Value;
      this.TextData.Alignment = this.buContentAlignment_0.Alignment;
      this.Result = DialogResult.OK;
      this.Dispose();
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Result = DialogResult.Cancel;
      this.Dispose();
    }
    if (control2.Name == this.btn_font.Name)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
