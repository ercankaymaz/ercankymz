// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.KeyPad.F_KeyPadCharV1
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.KeyPad;

public class F_KeyPadCharV1 : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public string Caption = "";
  public bool Caps;
  public string Value;
  public bool CheckNumeric = true;
  public bool ShowInitValue = true;
  public char PasswordChar;
  public double MaxValue = 0.0;
  public double MinValue = 0.0;
  private bool bool_0 = false;
  private string string_0 = "";
  private string string_1 = "";
  private Timer timer_0 = new Timer();
  private Timer timer_1 = new Timer();
  private Timer timer_2 = new Timer();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
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
  public buTextBox textCtrl1;
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

  public F_KeyPadCharV1()
  {
    Class39.smethod_329(this);
    this.timer_0 = new Timer();
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.timer_1 = new Timer();
    this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
    this.timer_2 = new Timer();
    this.timer_2.Tick += new EventHandler(this.timer_2_Tick);
  }

  public void ShowDialog(string Value)
  {
    this.bool_0 = false;
    this.string_0 = Value;
    this.textCtrl1.Text = Value;
    this.textCtrl1.Invalidate();
    this.textCtrl1.Display.SelectionColor = this.textCtrl1.Display.BackColor;
    this.textCtrl1.PasswordChar = this.PasswordChar;
    this.timer_0.Interval = 1000;
    this.timer_1.Interval = 1500;
    this.timer_2.Interval = 100;
    this.timer_2.Enabled = true;
    if (this.Caption.Length > 0)
    {
      this.buGround_0.Text = this.Caption;
      if (this.ShowInitValue)
        this.buGround_0.Text = $"{this.buGround_0.Text} - [ {Value} ]";
    }
    else
    {
      this.buGround_0.Text = nameof (Value);
      if (this.ShowInitValue)
        this.buGround_0.Text = $"{this.buGround_0.Text} - [ {Value} ]";
    }
    int num = (int) this.ShowDialog();
  }

  public void ShowDialog(string Value, IWin32Window owner)
  {
    this.bool_0 = false;
    this.string_0 = Value;
    this.textCtrl1.Text = Value;
    this.textCtrl1.Display.SelectionColor = this.textCtrl1.BackColor;
    this.textCtrl1.PasswordChar = this.PasswordChar;
    this.timer_0.Interval = 1000;
    this.timer_1.Interval = 1500;
    this.timer_2.Interval = 100;
    this.timer_2.Enabled = true;
    if (this.Caption.Length > 0)
    {
      this.buGround_0.Text = this.Caption;
      if (this.ShowInitValue)
        this.buGround_0.Text = $"{this.buGround_0.Text} - [ {Value} ]";
    }
    else
    {
      this.buGround_0.Text = nameof (Value);
      if (this.ShowInitValue)
        this.buGround_0.Text = $"{this.buGround_0.Text} - [ {Value} ]";
    }
    int num = (int) this.ShowDialog(owner);
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (((Control) sender).Tag.ToString() == "esc")
    {
      this.Value = this.string_0;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Close();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!this.bool_0)
        return;
      if (this.textCtrl1.txt.SelectedText.Length > 0 && ((Control) sender).Tag.ToString() != "enter")
        this.textCtrl1.txt.Text = "";
      if (((Control) sender).Tag.ToString() == "caps")
        this.Caps = !this.Caps;
      else if (((Control) sender).Tag.ToString() == "back")
      {
        if (this.textCtrl1.Text.Length <= 0)
          return;
        this.textCtrl1.Text = this.textCtrl1.Text.Substring(0, this.textCtrl1.Text.Length - 1);
      }
      else if (((Control) sender).Tag.ToString() == "enter")
      {
        this.Value = this.textCtrl1.Text;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Close();
        if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (this.Caps)
          this.textCtrl1.Text += ((Control) sender).Tag.ToString();
        else
          this.textCtrl1.Text += ((Control) sender).Tag.ToString().ToLower();
        this.textCtrl1.txt.SelectionStart = this.textCtrl1.txt.Text.Length;
      }
    }
  }

  private void timer_2_Tick(object sender, EventArgs e)
  {
    this.textCtrl1.SelectAll();
    this.bool_0 = true;
    this.timer_2.Enabled = false;
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.textCtrl1.Text = this.string_1;
    this.timer_0.Enabled = false;
  }

  private void timer_1_Tick(object sender, EventArgs e)
  {
    this.textCtrl1.Text = "";
    this.timer_1.Enabled = false;
  }

  internal void method_1(object sender, MouseEventArgs e) => this.timer_1.Enabled = true;

  internal void method_2(object sender, MouseEventArgs e) => this.timer_1.Enabled = false;

  internal void method_3(object sender, EventArgs e) => this.timer_1.Enabled = false;

  internal void method_4(object sender, KeyEventArgs e)
  {
    if (e.KeyCode == Keys.Escape)
      this.method_0((object) this.buButton_11, (EventArgs) null);
    if (e.KeyCode != Keys.Return)
      return;
    this.method_0((object) this.buButton_12, (EventArgs) null);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
