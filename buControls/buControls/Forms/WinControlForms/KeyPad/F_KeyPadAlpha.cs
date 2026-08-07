// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.KeyPad.F_KeyPadAlpha
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
namespace buControls.Forms.WinControlForms.KeyPad;

public class F_KeyPadAlpha : Form
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
  internal buTextBox buTextBox_0;
  internal Button button_15;

  public F_KeyPadAlpha() => Class39.smethod_688(this);

  public void ShowDialog(string Value)
  {
    this.bool_0 = false;
    this.string_0 = Value;
    this.buTextBox_0.Text = Value;
    this.buTextBox_0.Invalidate();
    this.buTextBox_0.Display.SelectionColor = this.buTextBox_0.Display.BackColor;
    this.buTextBox_0.PasswordChar = this.PasswordChar;
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
    this.buTextBox_0.Text = Value;
    this.buTextBox_0.Display.SelectionColor = this.buTextBox_0.BackColor;
    this.buTextBox_0.PasswordChar = this.PasswordChar;
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
    if (!this.bool_0)
      return;
    if (this.buTextBox_0.txt.SelectedText.Length > 0 && ((Control) sender).Tag.ToString() != "enter")
      this.buTextBox_0.txt.Text = "";
    string string_0 = ((Control) sender).Tag.ToString();
    switch (Class39.smethod_599(string_0))
    {
      case 453700801:
        if (string_0 == "Ğ")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "Ğ";
            break;
          }
          this.buTextBox_0.Text += "ğ";
          break;
        }
        break;
      case 671913016:
        if (string_0 == "-")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "-";
            break;
          }
          this.buTextBox_0.Text += "-";
          break;
        }
        break;
      case 722245873:
        if (string_0 == "." && this.buTextBox_0.Text.IndexOf(".") < 0)
        {
          this.buTextBox_0.Text += ".";
          break;
        }
        break;
      case 806133968:
        if (string_0 == "5")
        {
          this.buTextBox_0.Text += "5";
          break;
        }
        break;
      case 822911587:
        if (string_0 == "4")
        {
          this.buTextBox_0.Text += "4";
          break;
        }
        break;
      case 839689206:
        if (string_0 == "7")
        {
          this.buTextBox_0.Text += "7";
          break;
        }
        break;
      case 856466825:
        if (string_0 == "6")
        {
          this.buTextBox_0.Text += "6";
          break;
        }
        break;
      case 873244444:
        if (string_0 == "1")
        {
          this.buTextBox_0.Text += "1";
          break;
        }
        break;
      case 889918895:
        if (string_0 == "İ")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "İ";
            break;
          }
          this.buTextBox_0.Text += "i";
          break;
        }
        break;
      case 890022063:
        if (string_0 == "0")
        {
          this.buTextBox_0.Text += "0";
          break;
        }
        break;
      case 906799682:
        if (string_0 == "3")
        {
          this.buTextBox_0.Text += "3";
          break;
        }
        break;
      case 923577301:
        if (string_0 == "2")
        {
          this.buTextBox_0.Text += "2";
          break;
        }
        break;
      case 1007465396:
        if (string_0 == "9")
        {
          this.buTextBox_0.Text += "9";
          break;
        }
        break;
      case 1024243015:
        if (string_0 == "8")
        {
          this.buTextBox_0.Text += "8";
          break;
        }
        break;
      case 1108027942:
        if (string_0 == "Ç")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "Ç";
            break;
          }
          this.buTextBox_0.Text += "ç";
          break;
        }
        break;
      case 1393247465:
        if (string_0 == "Ö")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "Ö";
            break;
          }
          this.buTextBox_0.Text += "ö";
          break;
        }
        break;
      case 1493913179:
        if (string_0 == "Ü")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "Ü";
            break;
          }
          this.buTextBox_0.Text += "ü";
          break;
        }
        break;
      case 1538531746:
        if (string_0 == "back" && this.buTextBox_0.Text.Length > 0)
        {
          this.buTextBox_0.Text = this.buTextBox_0.Text.Substring(0, this.buTextBox_0.Text.Length - 1);
          break;
        }
        break;
      case 1550717474:
        if (string_0 == "clear")
        {
          this.buTextBox_0.Text = "";
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
            this.buTextBox_0.Text += "E";
            break;
          }
          this.buTextBox_0.Text += nameof (e);
          break;
        }
        break;
      case 3238785555:
        if (string_0 == "D")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "D";
            break;
          }
          this.buTextBox_0.Text += "d";
          break;
        }
        break;
      case 3250860581:
        if (string_0 == "Space")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += " ";
            break;
          }
          this.buTextBox_0.Text += " ";
          break;
        }
        break;
      case 3255563174:
        if (string_0 == "G")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "G";
            break;
          }
          this.buTextBox_0.Text += "g";
          break;
        }
        break;
      case 3272340793:
        if (string_0 == "F")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "F";
            break;
          }
          this.buTextBox_0.Text += "f";
          break;
        }
        break;
      case 3289118412:
        if (string_0 == "A")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "A";
            break;
          }
          this.buTextBox_0.Text += "a";
          break;
        }
        break;
      case 3322673650:
        if (string_0 == "C")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "C";
            break;
          }
          this.buTextBox_0.Text += "c";
          break;
        }
        break;
      case 3339451269:
        if (string_0 == "B")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "B";
            break;
          }
          this.buTextBox_0.Text += "b";
          break;
        }
        break;
      case 3356228888:
        if (string_0 == "M")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "M";
            break;
          }
          this.buTextBox_0.Text += "m";
          break;
        }
        break;
      case 3373006507:
        if (string_0 == "L")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "L";
            break;
          }
          this.buTextBox_0.Text += "l";
          break;
        }
        break;
      case 3389784126:
        if (string_0 == "O")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "O";
            break;
          }
          this.buTextBox_0.Text += "o";
          break;
        }
        break;
      case 3406561745:
        if (string_0 == "N")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "N";
            break;
          }
          this.buTextBox_0.Text += "n";
          break;
        }
        break;
      case 3423339364:
        if (string_0 == "I")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "I";
            break;
          }
          this.buTextBox_0.Text += "ı";
          break;
        }
        break;
      case 3440116983:
        if (string_0 == "H")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "H";
            break;
          }
          this.buTextBox_0.Text += "h";
          break;
        }
        break;
      case 3456894602:
        if (string_0 == "K")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "K";
            break;
          }
          this.buTextBox_0.Text += "k";
          break;
        }
        break;
      case 3473672221:
        if (string_0 == "J")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "J";
            break;
          }
          this.buTextBox_0.Text += "j";
          break;
        }
        break;
      case 3490449840:
        if (string_0 == "U")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "U";
            break;
          }
          this.buTextBox_0.Text += "u";
          break;
        }
        break;
      case 3507227459:
        if (string_0 == "T")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "T";
            break;
          }
          this.buTextBox_0.Text += "t";
          break;
        }
        break;
      case 3524005078:
        if (string_0 == "W")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "W";
            break;
          }
          this.buTextBox_0.Text += "w";
          break;
        }
        break;
      case 3540782697:
        if (string_0 == "V")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "V";
            break;
          }
          this.buTextBox_0.Text += "v";
          break;
        }
        break;
      case 3557560316:
        if (string_0 == "Q")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "Q";
            break;
          }
          this.buTextBox_0.Text += "q";
          break;
        }
        break;
      case 3574337935:
        if (string_0 == "P")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "P";
            break;
          }
          this.buTextBox_0.Text += "p";
          break;
        }
        break;
      case 3591115554:
        if (string_0 == "S")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "S";
            break;
          }
          this.buTextBox_0.Text += "s";
          break;
        }
        break;
      case 3607893173:
        if (string_0 == "R")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "R";
            break;
          }
          this.buTextBox_0.Text += "r";
          break;
        }
        break;
      case 3658226030:
        if (string_0 == "_")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "_";
            break;
          }
          this.buTextBox_0.Text += "_";
          break;
        }
        break;
      case 3674900481:
        if (string_0 == "Ş")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "Ş";
            break;
          }
          this.buTextBox_0.Text += "ş";
          break;
        }
        break;
      case 3691781268:
        if (string_0 == "Y")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "Y";
            break;
          }
          this.buTextBox_0.Text += "y";
          break;
        }
        break;
      case 3708558887:
        if (string_0 == "X")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "X";
            break;
          }
          this.buTextBox_0.Text += "x";
          break;
        }
        break;
      case 3724402957:
        if (string_0 == "enter")
        {
          if (!this.CheckNumeric)
          {
            this.Value = this.buTextBox_0.Text;
            this.Dispose();
            break;
          }
          if (buNumeric.IsNumeric(this.buTextBox_0.Text))
          {
            this.Value = this.buTextBox_0.Text;
            this.Dispose();
            break;
          }
          this.string_1 = this.buTextBox_0.Text;
          this.buTextBox_0.Text = "None numerical!!";
          this.timer_0.Enabled = true;
          break;
        }
        break;
      case 3742114125:
        if (string_0 == "Z")
        {
          if (this.Caps)
          {
            this.buTextBox_0.Text += "Z";
            break;
          }
          this.buTextBox_0.Text += "z";
          break;
        }
        break;
      case 4160372143:
        if (string_0 == "minus")
        {
          if (this.buTextBox_0.Text.Length > 0)
          {
            if (this.buTextBox_0.Text.Substring(0, 1) != "-")
            {
              this.buTextBox_0.Text = this.buTextBox_0.Text.Insert(0, "-");
              break;
            }
            this.buTextBox_0.Text = this.buTextBox_0.Text.Replace("-", "");
            break;
          }
          this.buTextBox_0.Text = "-";
          break;
        }
        break;
    }
    this.buTextBox_0.txt.SelectionStart = this.buTextBox_0.txt.Text.Length;
  }

  private void timer_2_Tick(object sender, EventArgs e)
  {
    this.buTextBox_0.SelectAll();
    this.bool_0 = true;
    this.timer_2.Enabled = false;
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.buTextBox_0.Text = this.string_1;
    this.timer_0.Enabled = false;
  }

  private void timer_1_Tick(object sender, EventArgs e)
  {
    this.buTextBox_0.Text = "";
    this.timer_1.Enabled = false;
  }

  internal void method_1(object sender, MouseEventArgs e) => this.timer_1.Enabled = true;

  internal void method_2(object sender, MouseEventArgs e) => this.timer_1.Enabled = false;

  internal void method_3(object sender, EventArgs e) => this.timer_1.Enabled = false;

  internal void method_4(object sender, KeyEventArgs e)
  {
    if (e.KeyCode == Keys.Escape)
      this.method_0((object) this.button_14, (EventArgs) null);
    if (e.KeyCode != Keys.Return)
      return;
    this.method_0((object) this.button_8, (EventArgs) null);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
