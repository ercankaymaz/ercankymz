// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Commands.F_Debug
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Commands;

public class F_Debug : Form
{
  public bool PasswordCharEnable = true;
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buListBox buListBox_0;
  internal buButton buButton_0;
  internal buTextBox buTextBox_0;
  internal buButton buButton_1;
  internal buButton buButton_2;

  public F_Debug() => Class39.smethod_563(this);

  public event DebugCommandEventHandler DebugCommandExecuted;

  public void Init()
  {
    try
    {
      this.buTextBox_0.Text = "";
      this.buTextBox_0.PasswordChar = !this.PasswordCharEnable ? char.MinValue : '*';
      this.buListBox_0.Items.Clear();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void AddToList(string commands)
  {
    try
    {
      this.buListBox_0.Items.Add((object) commands);
      if (this.buListBox_0.Items.Count <= 1)
        return;
      this.buListBox_0.SelectedIndex = this.buListBox_0.Items.Count - 1;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void ClearList()
  {
    try
    {
      this.buListBox_0.Items.Clear();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void ClearText()
  {
    try
    {
      this.buTextBox_0.Text = "";
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_0(object sender, KeyEventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (e.KeyCode != Keys.Return || this.debugCommandEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.debugCommandEventHandler_0((object) this, new DebugCommandEventArg()
      {
        DebugCommand = this.buTextBox_0.Text.Trim()
      });
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
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_2.Name | control2.Name == this.buButton_0.Name)
        this.Visible = false;
      if (!(control2.Name == this.buButton_1.Name))
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
