// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.KeyPad.F_Keyboard
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

public class F_Keyboard : Form
{
  public DialogResult Result = DialogResult.None;
  public static List<string> Captions = new List<string>();
  public string Value;
  private IContainer icontainer_0 = (IContainer) null;
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
  internal buButton buButton_15;
  internal buButton buButton_16;
  internal buButton buButton_17;
  internal buButton buButton_18;
  internal buButton buButton_19;
  internal buButton buButton_20;
  internal buButton buButton_21;
  internal buButton buButton_22;
  internal buButton buButton_23;
  internal buButton buButton_24;
  internal buButton buButton_25;
  internal buButton buButton_26;
  internal buButton buButton_27;
  internal buButton buButton_28;
  internal buButton buButton_29;
  internal buButton buButton_30;
  internal buButton buButton_31;
  internal buButton buButton_32;
  internal buButton buButton_33;
  internal buCheckBox buCheckBox_0;
  internal buButton buButton_34;
  internal buButton buButton_35;
  internal buButton buButton_36;
  internal buButton buButton_37;
  internal buButton buButton_38;
  internal buButton buButton_39;
  internal buButton buButton_40;
  internal buButton buButton_41;
  internal buButton buButton_42;
  internal buButton buButton_43;
  internal buButton buButton_44;
  internal buButton buButton_45;
  internal buButton buButton_46;
  internal buButton buButton_47;
  internal buButton buButton_48;
  internal buButton buButton_49;
  internal buButton buButton_50;
  internal buButton buButton_51;
  internal buButton buButton_52;
  internal buButton buButton_53;
  internal buButton buButton_54;
  internal buButton buButton_55;
  internal buButton buButton_56;
  internal buButton buButton_57;
  internal buButton buButton_58;
  internal buButton buButton_59;
  internal buButton buButton_60;
  internal buButton buButton_61;
  internal buButton buButton_62;
  internal buButton buButton_63;
  internal buButton buButton_64;
  internal buButton buButton_65;
  internal buButton buButton_66;
  internal buButton buButton_67;
  internal buButton buButton_68;
  internal buButton buButton_69;
  internal buButton buButton_70;
  internal buButton buButton_71;
  internal buButton buButton_72;
  internal buButton buButton_73;
  internal buButton buButton_74;
  internal buButton buButton_75;
  internal buButton buButton_76;
  internal buButton buButton_77;
  internal buButton buButton_78;
  internal buButton buButton_79;
  internal buButton buButton_80;
  internal buButton buButton_81;
  internal buGround buGround_0;
  public TextBox txt_input;

  public F_Keyboard() => Class39.smethod_216(this);

  internal void method_0(object sender, EventArgs e)
  {
    Class39.smethod_788(this);
    this.Result = DialogResult.None;
    this.Value = "";
  }

  public void ShowDialog(string Value, IWin32Window owner)
  {
    this.txt_input.Text = Value;
    int num = (int) this.ShowDialog(owner);
  }

  public void ClickKey(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    try
    {
      string text = this.txt_input.Text;
      int selectionStart = this.txt_input.SelectionStart;
      string str1 = text.Substring(0, selectionStart);
      string str2 = text.Substring(selectionStart, text.Length - selectionStart);
      this.txt_input.Text = str1 + control2.Text + str2;
      this.txt_input.Focus();
      this.txt_input.SelectionStart = selectionStart + 1;
      this.txt_input.SelectionLength = 0;
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Value = this.txt_input.Text;
    this.Result = DialogResult.Cancel;
    this.Close();
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      SendKeys.Send("{BACKSPACE}");
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.Result = DialogResult.OK;
    try
    {
      this.Value = this.txt_input.Text;
    }
    catch (Exception ex)
    {
    }
    this.Close();
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      SendKeys.Send("{RIGHT}");
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      SendKeys.Send("{LEFT}");
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    try
    {
      SendKeys.Send(" ");
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_7(object object_0, bool bool_0)
  {
    SendKeys.Send("{CAPSLOCK}");
    if (!this.buCheckBox_0.Check)
    {
      this.buButton_0.Text = "q";
      this.buButton_1.Text = "a";
      this.buButton_2.Text = "z";
      this.buButton_3.Text = "x";
      this.buButton_4.Text = "s";
      this.buButton_5.Text = "w";
      this.buButton_6.Text = "c";
      this.buButton_7.Text = "d";
      this.buButton_8.Text = "e";
      this.buButton_9.Text = "v";
      this.buButton_10.Text = "f";
      this.buButton_11.Text = "r";
      this.buButton_12.Text = "b";
      this.buButton_13.Text = "g";
      this.buButton_14.Text = "t";
      this.buButton_15.Text = "n";
      this.buButton_16.Text = "h";
      this.buButton_17.Text = "y";
      this.buButton_18.Text = "m";
      this.buButton_19.Text = "j";
      this.buButton_20.Text = "u";
      this.buButton_21.Text = "ö";
      this.buButton_22.Text = "k";
      this.buButton_23.Text = "ı";
      this.buButton_24.Text = "ç";
      this.buButton_25.Text = "l";
      this.buButton_26.Text = "o";
      this.buButton_28.Text = "ş";
      this.buButton_29.Text = "p";
      this.buButton_30.Text = "i";
      this.buButton_31.Text = "ğ";
      this.buButton_33.Text = "ü";
    }
    else
    {
      this.buButton_0.Text = "Q";
      this.buButton_1.Text = "A";
      this.buButton_2.Text = "Z";
      this.buButton_3.Text = "X";
      this.buButton_4.Text = "S";
      this.buButton_5.Text = "W";
      this.buButton_6.Text = "C";
      this.buButton_7.Text = "D";
      this.buButton_8.Text = "E";
      this.buButton_9.Text = "V";
      this.buButton_10.Text = "F";
      this.buButton_11.Text = "R";
      this.buButton_12.Text = "B";
      this.buButton_13.Text = "G";
      this.buButton_14.Text = "T";
      this.buButton_15.Text = "N";
      this.buButton_16.Text = "H";
      this.buButton_17.Text = "Y";
      this.buButton_18.Text = "M";
      this.buButton_19.Text = "J";
      this.buButton_20.Text = "U";
      this.buButton_21.Text = "Ö";
      this.buButton_22.Text = "K";
      this.buButton_23.Text = "I";
      this.buButton_24.Text = "Ç";
      this.buButton_25.Text = "L";
      this.buButton_26.Text = "O";
      this.buButton_28.Text = "Ş";
      this.buButton_29.Text = "P";
      this.buButton_30.Text = "İ";
      this.buButton_31.Text = "Ğ";
      this.buButton_33.Text = "Ü";
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
