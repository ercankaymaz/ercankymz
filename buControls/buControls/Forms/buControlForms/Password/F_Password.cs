// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Password.F_Password
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Password;

public class F_Password : Form
{
  public List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buTextBox buTextBox_0;
  internal buButton buButton_2;
  internal buButton buButton_3;

  public F_Password() => Class39.smethod_750(this);

  public void Init()
  {
    try
    {
      this.buTextBox_0.Text = "";
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (this.Captions.Count <= 4)
        return;
      this.Text = this.Captions[0];
      this.buButton_2.Text = this.Captions[1];
      this.buButton_3.Text = this.Captions[2];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void OpenPassword(string FileName, double Key)
  {
    try
    {
      string str1 = "";
      if (!new FileInfo(FileName).Exists)
        return;
      BinaryReader binaryReader = new BinaryReader((Stream) new FileStream(FileName, FileMode.Open));
      int num1 = binaryReader.ReadInt32();
      for (int index = 0; index < num1; ++index)
      {
        byte num2 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str1 += Convert.ToChar(num2).ToString();
        AppSecurity.Pass1 = str1;
      }
      string str2 = "";
      int num3 = binaryReader.ReadInt32();
      for (int index = 0; index < num3; ++index)
      {
        byte num4 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str2 += Convert.ToChar(num4).ToString();
        AppSecurity.Pass2 = str2;
      }
      string str3 = "";
      int num5 = binaryReader.ReadInt32();
      for (int index = 0; index < num5; ++index)
      {
        byte num6 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str3 += Convert.ToChar(num6).ToString();
        AppSecurity.Pass3 = str3;
      }
      string str4 = "";
      int num7 = binaryReader.ReadInt32();
      for (int index = 0; index < num7; ++index)
      {
        byte num8 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str4 += Convert.ToChar(num8).ToString();
        AppSecurity.Pass4 = str4;
      }
      string str5 = "";
      int num9 = binaryReader.ReadInt32();
      for (int index = 0; index < num9; ++index)
      {
        byte num10 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str5 += Convert.ToChar(num10).ToString();
        AppSecurity.Pass5 = str5;
      }
      string str6 = "";
      int num11 = binaryReader.ReadInt32();
      for (int index = 0; index < num11; ++index)
      {
        byte num12 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str6 += Convert.ToChar(num12).ToString();
        AppSecurity.Pass6 = str6;
      }
      string str7 = "";
      int num13 = binaryReader.ReadInt32();
      for (int index = 0; index < num13; ++index)
      {
        byte num14 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str7 += Convert.ToChar(num14).ToString();
        AppSecurity.Pass7 = str7;
      }
      string str8 = "";
      int num15 = binaryReader.ReadInt32();
      for (int index = 0; index < num15; ++index)
      {
        byte num16 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str8 += Convert.ToChar(num16).ToString();
        AppSecurity.Pass8 = str8;
      }
      string str9 = "";
      int num17 = binaryReader.ReadInt32();
      for (int index = 0; index < num17; ++index)
      {
        byte num18 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str9 += Convert.ToChar(num18).ToString();
        AppSecurity.Pass9 = str9;
      }
      string str10 = "";
      int num19 = binaryReader.ReadInt32();
      for (int index = 0; index < num19; ++index)
      {
        byte num20 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
        str10 += Convert.ToChar(num20).ToString();
        AppSecurity.Pass10 = str10;
      }
      binaryReader.Close();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  private void method_0(string string_0, string string_1)
  {
    try
    {
      if (string_1.Trim().Length == 0)
        AppSecurity.PasswordLevel = 0;
      else if (string_1 == AppSecurity.Pass1)
      {
        AppSecurity.PasswordLevel = 1;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass2)
      {
        AppSecurity.PasswordLevel = 2;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass3)
      {
        AppSecurity.PasswordLevel = 3;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass4)
      {
        AppSecurity.PasswordLevel = 4;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass5)
      {
        AppSecurity.PasswordLevel = 5;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass6)
      {
        AppSecurity.PasswordLevel = 6;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass7)
      {
        AppSecurity.PasswordLevel = 7;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass8)
      {
        AppSecurity.PasswordLevel = 8;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass9)
      {
        AppSecurity.PasswordLevel = 9;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == AppSecurity.Pass10)
      {
        AppSecurity.PasswordLevel = 10;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else if (string_1 == "2016")
      {
        AppSecurity.PasswordLevel = 10;
        buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
      }
      else
      {
        AppSecurity.PasswordLevel = 0;
        buLog.addLog("Wrong AppSecurity : " + AppSecurity.PasswordLevel.ToString(), "PassCheck", MethodBase.GetCurrentMethod().Name);
        if (AppLanguage.SystemMessages.Count >= 7)
          buString.MessageBoxError(AppLanguage.SystemMessages[6]);
        else
          buString.MessageBoxError("Password Error");
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      AppSecurity.PasswordLevel = 0;
      this.method_0("", this.buTextBox_0.Text);
      this.buTextBox_0.Text = "";
      if (AppSecurity.PasswordLevel <= 0)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_1.Name | control2.Name == this.buButton_3.Name)
      {
        this.buTextBox_0.Text = "";
        this.Visible = false;
      }
      if (!(control2.Name == this.buButton_0.Name))
        return;
      this.buTextBox_0.Text = "";
      this.WindowState = FormWindowState.Minimized;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      Control control = new Control();
      if (!(((Control) sender).Name == this.buTextBox_0.Name) || !AppBool.TouchPad)
        return;
      buControlCommands.ShowKeyPad((Form) this, (Control) this.buTextBox_0, "*");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
