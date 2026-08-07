// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.KeyPad.F_NumVar
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.KeyPad;

public class F_NumVar : Form
{
  public DialogResult Result = DialogResult.None;
  public static List<string> Captions = new List<string>();
  public double Value;
  private IContainer icontainer_0 = (IContainer) null;
  public buGround buGround1;
  public buButton buButton10;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal buButton buButton_3;
  internal buButton buButton_4;
  internal buButton buButton_5;
  internal buButton buButton_6;
  internal buButton buButton_7;
  internal buButton buButton_8;
  internal buButton buButton_9;
  internal buButton buButton_10;
  internal buButton buButton_11;
  internal buButton buButton_12;
  internal buButton buButton_13;
  internal buButton buButton_14;
  internal buTextBox buTextBox_0;
  internal buButton buButton_15;
  public TextBox txt_AxisVal;

  public F_NumVar() => Class39.smethod_50(this);

  public void Init()
  {
    Class39.smethod_347(this);
    try
    {
      this.txt_AxisVal.Focus();
      this.txt_AxisVal.SelectionStart = this.txt_AxisVal.Text.Length;
      this.txt_AxisVal.SelectionLength = 0;
    }
    catch (Exception ex)
    {
    }
    this.Result = DialogResult.None;
  }

  public void ShowDialog(string Value, IWin32Window owner)
  {
    this.txt_AxisVal.Text = Value;
    int num = (int) this.ShowDialog(owner);
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    try
    {
      string text = this.txt_AxisVal.Text;
      int selectionStart = this.txt_AxisVal.SelectionStart;
      string str1 = text.Substring(0, selectionStart);
      string str2 = text.Substring(selectionStart, text.Length - selectionStart);
      this.txt_AxisVal.Text = str1 + control2.Tag.ToString() + str2;
      this.txt_AxisVal.Focus();
      this.txt_AxisVal.SelectionStart = selectionStart + 1;
      this.txt_AxisVal.SelectionLength = 0;
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Value = double.Parse(this.txt_AxisVal.Text);
    this.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      this.Value = double.Parse(this.txt_AxisVal.Text);
    }
    catch (Exception ex)
    {
      this.Value = 0.0;
    }
    this.Result = DialogResult.OK;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e) => this.txt_AxisVal.ResetText();

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      string text = this.txt_AxisVal.Text;
      int selectionStart = this.txt_AxisVal.SelectionStart;
      this.txt_AxisVal.Text = text.Remove(selectionStart - 1, 1);
      this.txt_AxisVal.Focus();
      this.txt_AxisVal.SelectionStart = selectionStart - 1;
      this.txt_AxisVal.SelectionLength = 0;
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      string text1 = this.txt_AxisVal.Text;
      if (text1.IndexOf(".", 0, text1.Length - 1) != -1)
        return;
      string text2 = this.txt_AxisVal.Text;
      int selectionStart = this.txt_AxisVal.SelectionStart;
      string str1 = text2.Substring(0, selectionStart);
      string str2 = text2.Substring(selectionStart, text2.Length - selectionStart);
      this.txt_AxisVal.Text = str1 + this.buButton_0.Tag.ToString() + str2;
      this.txt_AxisVal.Focus();
      this.txt_AxisVal.SelectionStart = selectionStart + 1;
      this.txt_AxisVal.SelectionLength = 0;
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    try
    {
      int selectionStart = this.txt_AxisVal.SelectionStart;
      string text = this.txt_AxisVal.Text;
      this.txt_AxisVal.Text = (double.Parse(this.txt_AxisVal.Text) * -1.0).ToString();
      this.txt_AxisVal.Focus();
      this.txt_AxisVal.SelectionStart = selectionStart + 1;
      this.txt_AxisVal.SelectionLength = 0;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
