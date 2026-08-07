// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Foam.F_FoamSlicesList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using dummy_ptr;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamSlicesList : Form
{
  public MirrorBoxType MirrorType;
  public planeBoxNames newPlane;
  public CornerLocation newCorner;
  private CornerLocation \u0001;
  private CornerLocation \u0002;
  public bool CopyAsNew;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal Panel \u0001;
  public Button btn_oldplane;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  public Button btn_oldver;
  public Button btn_newver;

  internal void \u0002([In] object obj0, [In] MouseEventArgs obj1)
  {
    ((F_HolesTemp) this).\u0002.Enabled = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((F_HolesTemp) this).\u0002.Enabled = false;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    if (obj1.KeyCode == Keys.Escape)
      ((F_FoamSpeedList) this).\u0001((object) ((F_HolesTemp) this).\u0011, (EventArgs) null);
    if (obj1.KeyCode != Keys.Return)
      return;
    ((F_FoamSpeedList) this).\u0001((object) ((F_HolesTemp) this).\u0012, (EventArgs) null);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_HolesTemp) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_HolesTemp) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m0014B5();

  public F_FoamSlicesList()
  {
    ((F_HolesTemp) this).PropertiesForm = new FormProperties();
    ((F_HolesTemp) this).Caption = "";
    ((F_HolesTemp) this).CheckNumeric = true;
    ((F_HolesTemp) this).ShowInitValue = true;
    ((F_HolesTemp) this).MaxValue = 0.0;
    ((F_HolesTemp) this).MinValue = 0.0;
    ((F_HolesTemp) this).\u0001 = false;
    ((F_HolesTemp) this).\u0001 = "";
    ((F_HolesTemp) this).\u0002 = "";
    ((F_HolesTemp) this).\u0001 = new Timer();
    ((F_HolesTemp) this).\u0002 = new Timer();
    ((F_HolesTemp) this).\u0003 = new Timer();
    ((F_HolesTemp) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_KeyPadNumV1) this);
    ((F_HolesTemp) this).\u0001 = new Timer();
    ((F_HolesTemp) this).\u0001.Tick += new EventHandler(this.\u0003);
    ((F_HolesTemp) this).\u0002 = new Timer();
    ((F_HolesTemp) this).\u0002.Tick += new EventHandler(((F_FoamWaveMenu) this).\u0004);
    ((F_HolesTemp) this).\u0003 = new Timer();
    ((F_HolesTemp) this).\u0003.Tick += new EventHandler(this.\u0002);
  }

  public void ShowDialog(string Value)
  {
    ((F_HolesTemp) this).\u0001 = false;
    ((F_HolesTemp) this).\u0001 = Value;
    ((F_HolesTemp) this).textCtrl1.Text = Value;
    ((F_HolesTemp) this).textCtrl1.Invalidate();
    ((F_HolesTemp) this).textCtrl1.Display.SelectionColor = ((F_HolesTemp) this).textCtrl1.Display.BackColor;
    ((F_HolesTemp) this).textCtrl1.PasswordChar = ((F_HolesTemp) this).PasswordChar;
    ((F_HolesTemp) this).\u0001.Interval = 1000;
    ((F_HolesTemp) this).\u0002.Interval = 1500;
    ((F_HolesTemp) this).\u0003.Interval = 100;
    ((F_HolesTemp) this).\u0003.Enabled = true;
    if (((F_HolesTemp) this).Caption.Length > 0)
    {
      ((F_HolesTemp) this).\u0001.Text = ((F_HolesTemp) this).Caption;
      if (((F_HolesTemp) this).ShowInitValue)
        ((F_HolesTemp) this).\u0001.Text = $"{((F_HolesTemp) this).\u0001.Text} - [ {Value} ]";
    }
    else
    {
      ((F_HolesTemp) this).\u0001.Text = buLangTranslate.preDef.Value;
      if (((F_HolesTemp) this).ShowInitValue)
        ((F_HolesTemp) this).\u0001.Text = $"{((F_HolesTemp) this).\u0001.Text} - [ {Value} ]";
    }
    int num = (int) this.ShowDialog();
  }

  public void ShowDialog(string Value, IWin32Window owner)
  {
    ((F_HolesTemp) this).\u0001 = false;
    ((F_HolesTemp) this).\u0001 = Value;
    ((F_HolesTemp) this).textCtrl1.Text = Value;
    ((F_HolesTemp) this).textCtrl1.Display.SelectionColor = ((F_HolesTemp) this).textCtrl1.BackColor;
    ((F_HolesTemp) this).textCtrl1.PasswordChar = ((F_HolesTemp) this).PasswordChar;
    ((F_HolesTemp) this).\u0001.Interval = 1000;
    ((F_HolesTemp) this).\u0002.Interval = 1500;
    ((F_HolesTemp) this).\u0003.Interval = 100;
    ((F_HolesTemp) this).\u0003.Enabled = true;
    if ((((F_HolesTemp) this).Caption == null ? 0 : (((F_HolesTemp) this).Caption.Length > 0 ? 1 : 0)) != 0)
    {
      ((F_HolesTemp) this).\u0001.Text = ((F_HolesTemp) this).Caption;
      if (((F_HolesTemp) this).ShowInitValue)
        ((F_HolesTemp) this).\u0001.Text = $"{((F_HolesTemp) this).\u0001.Text} - [ {Value} ]";
    }
    else
    {
      ((F_HolesTemp) this).\u0001.Text = buLangTranslate.preDef.Value;
      if (((F_HolesTemp) this).ShowInitValue)
        ((F_HolesTemp) this).\u0001.Text = $"{((F_HolesTemp) this).\u0001.Text} - [ {Value} ]";
    }
    int num = (int) this.ShowDialog(owner);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (((Control) obj0).Tag.ToString() == "esc")
    {
      ((F_HolesTemp) this).Value = ((F_HolesTemp) this).\u0001;
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Close();
      if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!((F_HolesTemp) this).\u0001)
        return;
      if (((F_HolesTemp) this).textCtrl1.txt.SelectedText.Length > 0 && ((Control) obj0).Tag.ToString() != "enter")
        ((F_HolesTemp) this).textCtrl1.txt.Text = "";
      string str = ((Control) obj0).Tag.ToString();
      switch (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(str))
      {
        case 453700801:
          if (str == "Ğ")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "Ğ";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "ğ";
            break;
          }
          break;
        case 671913016:
          if (str == "-")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "-";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "-";
            break;
          }
          break;
        case 722245873:
          if (str == "." && ((F_HolesTemp) this).textCtrl1.Text.IndexOf(".") < 0)
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + ".";
            break;
          }
          break;
        case 806133968:
          if (str == "5")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "5";
            break;
          }
          break;
        case 822911587:
          if (str == "4")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "4";
            break;
          }
          break;
        case 839689206:
          if (str == "7")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "7";
            break;
          }
          break;
        case 856466825:
          if (str == "6")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "6";
            break;
          }
          break;
        case 873244444:
          if (str == "1")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "1";
            break;
          }
          break;
        case 889918895:
          if (str == "İ")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "İ";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "i";
            break;
          }
          break;
        case 890022063:
          if (str == "0")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "0";
            break;
          }
          break;
        case 906799682:
          if (str == "3")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "3";
            break;
          }
          break;
        case 923577301:
          if (str == "2")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "2";
            break;
          }
          break;
        case 1007465396:
          if (str == "9")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "9";
            break;
          }
          break;
        case 1024243015:
          if (str == "8")
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "8";
            break;
          }
          break;
        case 1108027942:
          if (str == "Ç")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "Ç";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "ç";
            break;
          }
          break;
        case 1393247465:
          if (str == "Ö")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "Ö";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "ö";
            break;
          }
          break;
        case 1493913179:
          if (str == "Ü")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "Ü";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "ü";
            break;
          }
          break;
        case 1538531746:
          if (str == "back" && ((F_HolesTemp) this).textCtrl1.Text.Length > 0)
          {
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text.Substring(0, ((F_HolesTemp) this).textCtrl1.Text.Length - 1);
            break;
          }
          break;
        case 1550717474:
          if (str == "clear")
          {
            ((F_HolesTemp) this).textCtrl1.Text = "";
            break;
          }
          break;
        case 1704568510:
          if (str == "esc")
          {
            ((F_HolesTemp) this).Value = ((F_HolesTemp) this).\u0001;
            if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
              this.Close();
            if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
            {
              this.Visible = false;
              break;
            }
            break;
          }
          break;
        case 3222007936:
          if (str == "E")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "E";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "e";
            break;
          }
          break;
        case 3238785555:
          if (str == "D")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "D";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "d";
            break;
          }
          break;
        case 3250860581:
          if (str == "Space")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + " ";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + " ";
            break;
          }
          break;
        case 3255563174:
          if (str == "G")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "G";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "g";
            break;
          }
          break;
        case 3272340793:
          if (str == "F")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "F";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "f";
            break;
          }
          break;
        case 3289118412:
          if (str == "A")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "A";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "a";
            break;
          }
          break;
        case 3322673650:
          if (str == "C")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "C";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "c";
            break;
          }
          break;
        case 3339451269:
          if (str == "B")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "B";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "b";
            break;
          }
          break;
        case 3356228888:
          if (str == "M")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "M";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "m";
            break;
          }
          break;
        case 3373006507:
          if (str == "L")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "L";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "l";
            break;
          }
          break;
        case 3389784126:
          if (str == "O")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "O";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "o";
            break;
          }
          break;
        case 3406561745:
          if (str == "N")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "N";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "n";
            break;
          }
          break;
        case 3423339364:
          if (str == "I")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "I";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "ı";
            break;
          }
          break;
        case 3440116983:
          if (str == "H")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "H";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "h";
            break;
          }
          break;
        case 3456894602:
          if (str == "K")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "K";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "k";
            break;
          }
          break;
        case 3473672221:
          if (str == "J")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "J";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "j";
            break;
          }
          break;
        case 3490449840:
          if (str == "U")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "U";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "u";
            break;
          }
          break;
        case 3507227459:
          if (str == "T")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "T";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "t";
            break;
          }
          break;
        case 3524005078:
          if (str == "W")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "W";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "w";
            break;
          }
          break;
        case 3540782697:
          if (str == "V")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "V";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "v";
            break;
          }
          break;
        case 3557560316:
          if (str == "Q")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "Q";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "q";
            break;
          }
          break;
        case 3574337935:
          if (str == "P")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "P";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "p";
            break;
          }
          break;
        case 3591115554:
          if (str == "S")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "S";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "s";
            break;
          }
          break;
        case 3607893173:
          if (str == "R")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "R";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "r";
            break;
          }
          break;
        case 3658226030:
          if (str == "_")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "_";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "_";
            break;
          }
          break;
        case 3674900481:
          if (str == "Ş")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "Ş";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "ş";
            break;
          }
          break;
        case 3691781268:
          if (str == "Y")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "Y";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "y";
            break;
          }
          break;
        case 3708558887:
          if (str == "X")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "X";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "x";
            break;
          }
          break;
        case 3724402957:
          if (str == "enter")
          {
            if (!((F_HolesTemp) this).CheckNumeric)
            {
              ((F_HolesTemp) this).Value = ((F_HolesTemp) this).textCtrl1.Text;
              if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
                this.Close();
              if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
              {
                this.Visible = false;
                break;
              }
              break;
            }
            if (buNumeric.IsNumeric(((F_HolesTemp) this).textCtrl1.Text))
            {
              if (((F_HolesTemp) this).MaxValue != ((F_HolesTemp) this).MinValue)
              {
                double num = double.Parse(((F_HolesTemp) this).textCtrl1.Text);
                if (num < ((F_HolesTemp) this).MinValue)
                {
                  ((F_HolesTemp) this).\u0002 = ((F_HolesTemp) this).textCtrl1.Text;
                  ((F_HolesTemp) this).textCtrl1.Text = buLangTranslate.preDef.LowerThenLimit + "!!";
                  ((F_HolesTemp) this).\u0001.Enabled = true;
                  return;
                }
                if (num > ((F_HolesTemp) this).MaxValue)
                {
                  ((F_HolesTemp) this).\u0002 = ((F_HolesTemp) this).textCtrl1.Text;
                  ((F_HolesTemp) this).textCtrl1.Text = buLangTranslate.preDef.HigherThenLimit + "!!";
                  ((F_HolesTemp) this).\u0001.Enabled = true;
                  return;
                }
                ((F_HolesTemp) this).Value = ((F_HolesTemp) this).textCtrl1.Text;
                if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
                  this.Close();
                if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
                {
                  this.Visible = false;
                  break;
                }
                break;
              }
              ((F_HolesTemp) this).Value = ((F_HolesTemp) this).textCtrl1.Text;
              if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
                this.Close();
              if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
              {
                this.Visible = false;
                break;
              }
              break;
            }
            ((F_HolesTemp) this).\u0002 = ((F_HolesTemp) this).textCtrl1.Text;
            ((F_HolesTemp) this).textCtrl1.Text = buLangTranslate.preDef.NotNumeric + "!!";
            ((F_HolesTemp) this).\u0001.Enabled = true;
            break;
          }
          break;
        case 3742114125:
          if (str == "Z")
          {
            if (((F_HolesTemp) this).Caps)
            {
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "Z";
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + "z";
            break;
          }
          break;
        case 4160372143:
          if (str == "minus")
          {
            if (((F_HolesTemp) this).textCtrl1.Text.Length > 0)
            {
              if (((F_HolesTemp) this).textCtrl1.Text.Substring(0, 1) != "-")
              {
                ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text.Insert(0, "-");
                break;
              }
              ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text.Replace("-", "");
              break;
            }
            ((F_HolesTemp) this).textCtrl1.Text = "-";
            break;
          }
          break;
      }
      ((F_HolesTemp) this).textCtrl1.txt.SelectionStart = ((F_HolesTemp) this).textCtrl1.txt.Text.Length;
    }
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_HolesTemp) this).textCtrl1.SelectAll();
    ((F_HolesTemp) this).\u0001 = true;
    ((F_HolesTemp) this).\u0003.Enabled = false;
  }

  private void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).\u0002;
    ((F_HolesTemp) this).\u0001.Enabled = false;
  }
}
