// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Password.F_MacCode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Password;

public class F_MacCode : Form
{
  public List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buSpin buSpin_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal buButton buButton_3;
  internal buButton buButton_4;
  public buLabel lbl_address;

  public F_MacCode() => Class39.smethod_224(this);

  public event EventHandler GetAddress;

  public event SetCodeClickEventHandler SetCode;

  public void Init()
  {
    try
    {
      this.buSpin_0.Value = 0.0;
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
      this.buButton_0.Text = this.Captions[1];
      this.buButton_1.Text = this.Captions[2];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_3.Name | control2.Name == this.buButton_1.Name)
        this.Visible = false;
      if (!(control2.Name == this.buButton_2.Name))
        return;
      this.WindowState = FormWindowState.Minimized;
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
      // ISSUE: reference to a compiler-generated field
      if (this.setCodeClickEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.setCodeClickEventHandler_0(this.buSpin_0.Value);
      }
      this.Dispose();
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
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, e);
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
