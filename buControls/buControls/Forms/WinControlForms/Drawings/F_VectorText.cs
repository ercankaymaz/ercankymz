// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Drawings.F_VectorText
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.UserControls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Drawings;

public class F_VectorText : Form
{
  public static List<string> Captions = new List<string>();
  public TextVectorData TextData = new TextVectorData();
  public DialogResult Result = DialogResult.None;
  public bool ShowXYPoint = false;
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
  internal NumericUpDown numericUpDown_2;
  internal Label label_5;

  public F_VectorText() => Class39.smethod_408(this);

  public void Init()
  {
    this.TextData.Font = new Font(this.TextData.Font.FontFamily, (float) this.TextData.Height, this.TextData.Font.Style);
    this.textBox_0.Text = this.TextData.Text;
    this.numericUpDown_0.Value = (Decimal) this.TextData.Height;
    this.btn_font.Text = $"{this.TextData.Font.Name} - {this.TextData.Font.Size.ToString()}";
    this.buContentAlignment_0.Alignment = this.TextData.Alignment;
    this.numericUpDown_2.Value = (Decimal) this.TextData.CenterPoint.X;
    this.numericUpDown_1.Value = (Decimal) this.TextData.CenterPoint.Y;
    this.label_5.Visible = this.ShowXYPoint;
    this.label_4.Visible = this.ShowXYPoint;
    this.numericUpDown_2.Visible = this.ShowXYPoint;
    this.numericUpDown_1.Visible = this.ShowXYPoint;
    Class39.smethod_720(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      this.TextData.CenterPoint.X = (double) this.numericUpDown_2.Value;
      this.TextData.CenterPoint.Y = (double) this.numericUpDown_1.Value;
      this.TextData.Text = this.textBox_0.Text;
      this.TextData.Height = (double) this.numericUpDown_0.Value;
      this.TextData.Alignment = this.buContentAlignment_0.Alignment;
      this.Result = DialogResult.OK;
      this.Dispose();
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Result = DialogResult.Cancel;
      this.Dispose();
    }
    if (!(control2.Name == this.btn_font.Name))
      return;
    FontDialog fontDialog = new FontDialog();
    fontDialog.Font = new Font(this.TextData.Font.FontFamily, (float) this.numericUpDown_0.Value, this.TextData.Font.Style);
    if (fontDialog.ShowDialog() != DialogResult.OK)
      return;
    this.numericUpDown_0.Value = Math.Round((Decimal) fontDialog.Font.Size, 0);
    this.TextData.Height = (double) this.numericUpDown_0.Value;
    this.TextData.Font = new Font(fontDialog.Font.FontFamily, (float) this.TextData.Height, fontDialog.Font.Style);
    this.btn_font.Font = new Font(fontDialog.Font.FontFamily, 8f);
    this.btn_font.Text = $"{this.TextData.Font.Name} - {this.TextData.Font.Size.ToString()}";
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
