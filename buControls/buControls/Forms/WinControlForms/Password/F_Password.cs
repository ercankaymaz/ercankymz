// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Password.F_Password
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Password;

public class F_Password : Form
{
  public FormProperties Properties = new FormProperties();
  public List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal TextBox textBox_0;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;

  public F_Password() => Class39.smethod_242(this);

  public void Init()
  {
    try
    {
      this.Properties.Inited = false;
      if (this.Properties.Height > 10)
        this.Height = this.Properties.Height;
      if (this.Properties.Width > 10)
        this.Width = this.Properties.Width;
      this.TopMost = this.Properties.TopMost;
      this.StartPosition = this.Properties.FormPosition;
      this.AutoScaleMode = this.Properties.ScaleFromMode;
      this.textBox_0.Text = "";
      this.LoadLanguage();
      this.Properties.Result = DialogResult.None;
      this.Properties.Inited = true;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    try
    {
      if (this.Captions.Count <= 4)
        return;
      this.Text = this.Captions[0];
      this.btn_ok.Text = this.Captions[1];
      this.btn_cancel.Text = this.Captions[2];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  private void method_1(string string_0, string string_1)
  {
    try
    {
      if (string_1 == AppSecurity.Pass1)
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
      else if (string_1 == "2018")
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

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      AppSecurity.PasswordLevel = 0;
      this.method_1("", this.textBox_0.Text);
      this.textBox_0.Text = "";
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

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      Control control = new Control();
      if (!(((Control) sender).Name == this.btn_cancel.Name))
        return;
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
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

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      Control control = new Control();
      if (!(((Control) sender).Name == this.textBox_0.Name) || !AppBool.TouchPad)
        return;
      buControlCommands.ShowKeyPad((Form) this, (Control) this.textBox_0);
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
