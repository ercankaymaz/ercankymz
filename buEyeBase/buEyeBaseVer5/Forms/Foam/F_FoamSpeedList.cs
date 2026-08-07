// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Foam.F_FoamSpeedList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamSpeedList : Form
{
  public buShape Shape;
  public ClockDirectionType ClockType;
  public double Degree;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal Panel \u0001;
  public RadioButton radio_ccw;
  public RadioButton radio_cw;
  public RadioButton radio_90;
  public RadioButton radio_180;
  internal Panel \u0002;
  public static byte f002F97;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public buShape Shape;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    string text = ((Control) obj0).Text;
    if ((char.IsDigit(text[0]) ? 1 : (text == "." ? 1 : 0)) != 0)
    {
      if (((F_HolesTemp) this).\u0001.Text == "0")
        ((F_HolesTemp) this).\u0001.Text = "";
      ((F_HolesTemp) this).\u0001.Text += text;
      ((F_HolesTemp) this).\u0001 = ((F_HolesTemp) this).\u0001.Text;
    }
    else
    {
      string str = text;
      switch (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(str))
      {
        case 501192521:
          if (str == "M+")
          {
            ((F_HolesTemp) this).\u0001 = ((F_HolesTemp) this).\u0001 + \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((F_HolesTemp) this).\u0001.Text, (Form1) this);
            return;
          }
          break;
        case 534747759:
          if (str == "M-")
          {
            ((F_HolesTemp) this).\u0001 = ((F_HolesTemp) this).\u0001 - \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((F_HolesTemp) this).\u0001.Text, (Form1) this);
            return;
          }
          break;
        case 775983274:
          if (str == "⌫")
          {
            if (((F_HolesTemp) this).\u0001.Text.Length > 0)
              ((F_HolesTemp) this).\u0001.Text = ((F_HolesTemp) this).\u0001.Text.Substring(0, ((F_HolesTemp) this).\u0001.Text.Length - 1);
            ((F_HolesTemp) this).\u0001 = ((F_HolesTemp) this).\u0001.Text;
            return;
          }
          break;
        case 887077758:
          if (str == "MR")
          {
            ((F_HolesTemp) this).\u0001.Text = ((F_HolesTemp) this).\u0001.ToString();
            return;
          }
          break;
        case 940354920:
          if (str == "=")
          {
            try
            {
              double num = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((F_HolesTemp) this).\u0001.Text, (Form1) this);
              ((F_HolesTemp) this).\u0001.Items.Insert(0, (object) $"{((F_HolesTemp) this).\u0001.Text} = {num.ToString()}");
              ((F_HolesTemp) this).\u0001.Text = num.ToString();
              ((F_HolesTemp) this).\u0001 = ((F_HolesTemp) this).\u0001.Text;
              return;
            }
            catch
            {
              ((F_HolesTemp) this).\u0001.Text = "Error";
              return;
            }
          }
          else
            break;
        case 1172297281:
          if (str == "MC")
          {
            ((F_HolesTemp) this).\u0001 = 0.0;
            return;
          }
          break;
        case 3322673650:
          if (str == "C")
          {
            ((F_HolesTemp) this).\u0001.Text = "0";
            ((F_HolesTemp) this).\u0001 = "";
            return;
          }
          break;
      }
      ((F_HolesTemp) this).\u0001.Text += text;
      ((F_HolesTemp) this).\u0001 = ((F_HolesTemp) this).\u0001.Text;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_HolesTemp) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_HolesTemp) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m0014A8();

  public F_FoamSpeedList()
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
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_KeyPadCharV1) this);
    ((F_HolesTemp) this).\u0001 = new Timer();
    ((F_HolesTemp) this).\u0001.Tick += new EventHandler(this.\u0003);
    ((F_HolesTemp) this).\u0002 = new Timer();
    ((F_HolesTemp) this).\u0002.Tick += new EventHandler(this.\u0004);
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
      ((F_HolesTemp) this).\u0001.Text = nameof (Value);
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
    if (((F_HolesTemp) this).Caption.Length > 0)
    {
      ((F_HolesTemp) this).\u0001.Text = ((F_HolesTemp) this).Caption;
      if (((F_HolesTemp) this).ShowInitValue)
        ((F_HolesTemp) this).\u0001.Text = $"{((F_HolesTemp) this).\u0001.Text} - [ {Value} ]";
    }
    else
    {
      ((F_HolesTemp) this).\u0001.Text = nameof (Value);
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
      if (((Control) obj0).Tag.ToString() == "caps")
        ((F_HolesTemp) this).Caps = !((F_HolesTemp) this).Caps;
      else if (((Control) obj0).Tag.ToString() == "back")
      {
        if (((F_HolesTemp) this).textCtrl1.Text.Length <= 0)
          return;
        ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text.Substring(0, ((F_HolesTemp) this).textCtrl1.Text.Length - 1);
      }
      else if (((Control) obj0).Tag.ToString() == "enter")
      {
        ((F_HolesTemp) this).Value = ((F_HolesTemp) this).textCtrl1.Text;
        if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Close();
        if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (((F_HolesTemp) this).Caps)
          ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + ((Control) obj0).Tag.ToString();
        else
          ((F_HolesTemp) this).textCtrl1.Text = ((F_HolesTemp) this).textCtrl1.Text + ((Control) obj0).Tag.ToString().ToLower();
        ((F_HolesTemp) this).textCtrl1.txt.SelectionStart = ((F_HolesTemp) this).textCtrl1.txt.Text.Length;
      }
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

  private void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((F_HolesTemp) this).textCtrl1.Text = "";
    ((F_HolesTemp) this).\u0002.Enabled = false;
  }

  internal void \u0001([In] object obj0, [In] MouseEventArgs obj1)
  {
    ((F_HolesTemp) this).\u0002.Enabled = true;
  }
}
