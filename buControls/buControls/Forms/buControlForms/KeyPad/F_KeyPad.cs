// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.KeyPad.F_KeyPad
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using buCore;
using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.KeyPad;

public class F_KeyPad : Form
{
  public bool Caps;
  public string Value;
  public bool CheckNumeric = true;
  public char PasswordChar;
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

  public F_KeyPad() => Class39.smethod_288(this);

  public void ShowDialog(string Value)
  {
    this.bool_0 = false;
    this.string_0 = Value;
    this.textCtrl1.Text = Value;
    this.textCtrl1.Invalidate();
    this.textCtrl1.Display.SelectionColor = this.textCtrl1.Display.BackColor;
    this.textCtrl1.PasswordChar = this.PasswordChar;
    this.timer_0 = new Timer();
    this.timer_0.Interval = 1000;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.timer_1 = new Timer();
    this.timer_1.Interval = 1500;
    this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
    int num = (int) this.ShowDialog();
  }

  public void ShowDialog(string Value, IWin32Window owner)
  {
    this.bool_0 = false;
    this.string_0 = Value;
    this.textCtrl1.Text = Value;
    this.textCtrl1.Display.SelectionColor = this.textCtrl1.BackColor;
    this.textCtrl1.PasswordChar = this.PasswordChar;
    this.timer_0 = new Timer();
    this.timer_0.Interval = 1000;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.timer_1 = new Timer();
    this.timer_1.Interval = 1500;
    this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
    this.timer_2 = new Timer();
    this.timer_2.Interval = 100;
    this.timer_2.Tick += new EventHandler(this.timer_2_Tick);
    this.timer_2.Enabled = true;
    int num = (int) this.ShowDialog(owner);
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (((Control) sender).Tag.ToString() == "esc")
    {
      this.Value = this.string_0;
      this.Close();
    }
    else
    {
      if (!this.bool_0)
        return;
      if (this.textCtrl1.txt.SelectedText.Length > 0 && ((Control) sender).Tag.ToString() != "enter")
        this.textCtrl1.txt.Text = "";
      string string_0 = ((Control) sender).Tag.ToString();
      switch (Class39.smethod_599(string_0))
      {
        case 453700801:
          if (string_0 == "Ğ")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "Ğ";
              break;
            }
            this.textCtrl1.Text += "ğ";
            break;
          }
          break;
        case 671913016:
          if (string_0 == "-")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "-";
              break;
            }
            this.textCtrl1.Text += "-";
            break;
          }
          break;
        case 722245873:
          if (string_0 == "." && this.textCtrl1.Text.IndexOf(".") < 0)
          {
            this.textCtrl1.Text += ".";
            break;
          }
          break;
        case 806133968:
          if (string_0 == "5")
          {
            this.textCtrl1.Text += "5";
            break;
          }
          break;
        case 822911587:
          if (string_0 == "4")
          {
            this.textCtrl1.Text += "4";
            break;
          }
          break;
        case 839689206:
          if (string_0 == "7")
          {
            this.textCtrl1.Text += "7";
            break;
          }
          break;
        case 856466825:
          if (string_0 == "6")
          {
            this.textCtrl1.Text += "6";
            break;
          }
          break;
        case 873244444:
          if (string_0 == "1")
          {
            this.textCtrl1.Text += "1";
            break;
          }
          break;
        case 889918895:
          if (string_0 == "İ")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "İ";
              break;
            }
            this.textCtrl1.Text += "i";
            break;
          }
          break;
        case 890022063:
          if (string_0 == "0")
          {
            this.textCtrl1.Text += "0";
            break;
          }
          break;
        case 906799682:
          if (string_0 == "3")
          {
            this.textCtrl1.Text += "3";
            break;
          }
          break;
        case 923577301:
          if (string_0 == "2")
          {
            this.textCtrl1.Text += "2";
            break;
          }
          break;
        case 1007465396:
          if (string_0 == "9")
          {
            this.textCtrl1.Text += "9";
            break;
          }
          break;
        case 1024243015:
          if (string_0 == "8")
          {
            this.textCtrl1.Text += "8";
            break;
          }
          break;
        case 1108027942:
          if (string_0 == "Ç")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "Ç";
              break;
            }
            this.textCtrl1.Text += "ç";
            break;
          }
          break;
        case 1393247465:
          if (string_0 == "Ö")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "Ö";
              break;
            }
            this.textCtrl1.Text += "ö";
            break;
          }
          break;
        case 1493913179:
          if (string_0 == "Ü")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "Ü";
              break;
            }
            this.textCtrl1.Text += "ü";
            break;
          }
          break;
        case 1538531746:
          if (string_0 == "back" && this.textCtrl1.Text.Length > 0)
          {
            this.textCtrl1.Text = this.textCtrl1.Text.Substring(0, this.textCtrl1.Text.Length - 1);
            break;
          }
          break;
        case 1550717474:
          if (string_0 == "clear")
          {
            this.textCtrl1.Text = "";
            break;
          }
          break;
        case 1704568510:
          if (string_0 == "esc")
          {
            this.Value = this.string_0;
            this.Close();
            break;
          }
          break;
        case 3222007936:
          if (string_0 == "E")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "E";
              break;
            }
            this.textCtrl1.Text += nameof (e);
            break;
          }
          break;
        case 3238785555:
          if (string_0 == "D")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "D";
              break;
            }
            this.textCtrl1.Text += "d";
            break;
          }
          break;
        case 3250860581:
          if (string_0 == "Space")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += " ";
              break;
            }
            this.textCtrl1.Text += " ";
            break;
          }
          break;
        case 3255563174:
          if (string_0 == "G")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "G";
              break;
            }
            this.textCtrl1.Text += "g";
            break;
          }
          break;
        case 3272340793:
          if (string_0 == "F")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "F";
              break;
            }
            this.textCtrl1.Text += "f";
            break;
          }
          break;
        case 3289118412:
          if (string_0 == "A")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "A";
              break;
            }
            this.textCtrl1.Text += "a";
            break;
          }
          break;
        case 3322673650:
          if (string_0 == "C")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "C";
              break;
            }
            this.textCtrl1.Text += "c";
            break;
          }
          break;
        case 3339451269:
          if (string_0 == "B")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "B";
              break;
            }
            this.textCtrl1.Text += "b";
            break;
          }
          break;
        case 3356228888:
          if (string_0 == "M")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "M";
              break;
            }
            this.textCtrl1.Text += "m";
            break;
          }
          break;
        case 3373006507:
          if (string_0 == "L")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "L";
              break;
            }
            this.textCtrl1.Text += "l";
            break;
          }
          break;
        case 3389784126:
          if (string_0 == "O")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "O";
              break;
            }
            this.textCtrl1.Text += "o";
            break;
          }
          break;
        case 3406561745:
          if (string_0 == "N")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "N";
              break;
            }
            this.textCtrl1.Text += "n";
            break;
          }
          break;
        case 3423339364:
          if (string_0 == "I")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "I";
              break;
            }
            this.textCtrl1.Text += "ı";
            break;
          }
          break;
        case 3440116983:
          if (string_0 == "H")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "H";
              break;
            }
            this.textCtrl1.Text += "h";
            break;
          }
          break;
        case 3456894602:
          if (string_0 == "K")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "K";
              break;
            }
            this.textCtrl1.Text += "k";
            break;
          }
          break;
        case 3473672221:
          if (string_0 == "J")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "J";
              break;
            }
            this.textCtrl1.Text += "j";
            break;
          }
          break;
        case 3490449840:
          if (string_0 == "U")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "U";
              break;
            }
            this.textCtrl1.Text += "u";
            break;
          }
          break;
        case 3507227459:
          if (string_0 == "T")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "T";
              break;
            }
            this.textCtrl1.Text += "t";
            break;
          }
          break;
        case 3524005078:
          if (string_0 == "W")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "W";
              break;
            }
            this.textCtrl1.Text += "w";
            break;
          }
          break;
        case 3540782697:
          if (string_0 == "V")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "V";
              break;
            }
            this.textCtrl1.Text += "v";
            break;
          }
          break;
        case 3557560316:
          if (string_0 == "Q")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "Q";
              break;
            }
            this.textCtrl1.Text += "q";
            break;
          }
          break;
        case 3574337935:
          if (string_0 == "P")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "P";
              break;
            }
            this.textCtrl1.Text += "p";
            break;
          }
          break;
        case 3591115554:
          if (string_0 == "S")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "S";
              break;
            }
            this.textCtrl1.Text += "s";
            break;
          }
          break;
        case 3607893173:
          if (string_0 == "R")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "R";
              break;
            }
            this.textCtrl1.Text += "r";
            break;
          }
          break;
        case 3658226030:
          if (string_0 == "_")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "_";
              break;
            }
            this.textCtrl1.Text += "_";
            break;
          }
          break;
        case 3674900481:
          if (string_0 == "Ş")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "Ş";
              break;
            }
            this.textCtrl1.Text += "ş";
            break;
          }
          break;
        case 3691781268:
          if (string_0 == "Y")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "Y";
              break;
            }
            this.textCtrl1.Text += "y";
            break;
          }
          break;
        case 3708558887:
          if (string_0 == "X")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "X";
              break;
            }
            this.textCtrl1.Text += "x";
            break;
          }
          break;
        case 3724402957:
          if (string_0 == "enter")
          {
            if (!this.CheckNumeric)
            {
              this.Value = this.textCtrl1.Text;
              this.Dispose();
              break;
            }
            if (buNumeric.IsNumeric(this.textCtrl1.Text))
            {
              this.Value = this.textCtrl1.Text;
              this.Dispose();
              break;
            }
            this.string_1 = this.textCtrl1.Text;
            this.textCtrl1.Text = "None numerical!!";
            this.timer_0.Enabled = true;
            break;
          }
          break;
        case 3742114125:
          if (string_0 == "Z")
          {
            if (this.Caps)
            {
              this.textCtrl1.Text += "Z";
              break;
            }
            this.textCtrl1.Text += "z";
            break;
          }
          break;
        case 4160372143:
          if (string_0 == "minus")
          {
            if (this.textCtrl1.Text.Length > 0)
            {
              if (this.textCtrl1.Text.Substring(0, 1) != "-")
              {
                this.textCtrl1.Text = this.textCtrl1.Text.Insert(0, "-");
                break;
              }
              this.textCtrl1.Text = this.textCtrl1.Text.Replace("-", "");
              break;
            }
            this.textCtrl1.Text = "-";
            break;
          }
          break;
      }
      this.textCtrl1.txt.SelectionStart = this.textCtrl1.txt.Text.Length;
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
