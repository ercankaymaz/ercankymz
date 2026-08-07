// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Commands.F_DebugV2
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

public class F_DebugV2 : Form
{
  public bool PasswordCharEnable = true;
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buTextBox buTextBox_0;
  public buButton btn_close;
  internal buButton buButton_0;
  internal buButton buButton_1;
  public buListBox lst_commands;

  public F_DebugV2() => Class39.smethod_531(this);

  public event DebugCommandEventHandler DebugCommandExecuted;

  public void Init()
  {
    try
    {
      this.PropertiesForm.Inited = false;
      if (this.PropertiesForm.Height > 10)
        this.Height = this.PropertiesForm.Height;
      if (this.PropertiesForm.Width > 10)
        this.Width = this.PropertiesForm.Width;
      this.TopMost = this.PropertiesForm.TopMost;
      this.StartPosition = this.PropertiesForm.FormPosition;
      this.buTextBox_0.Text = "";
      this.buTextBox_0.PasswordChar = !this.PasswordCharEnable ? char.MinValue : '*';
      this.lst_commands.Items.Clear();
      this.LoadLanguage();
      this.PropertiesForm.Result = DialogResult.None;
      this.PropertiesForm.Inited = true;
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
    }
    catch (Exception ex)
    {
    }
  }

  public void AddToList(string commands)
  {
    try
    {
      this.lst_commands.Items.Add((object) commands);
      if (this.lst_commands.Items.Count <= 1)
        return;
      this.lst_commands.SelectedIndex = this.lst_commands.Items.Count - 1;
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
      this.lst_commands.Items.Clear();
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

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, KeyEventArgs e)
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

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.btn_close.Name | control2.Name == this.buButton_1.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (!(control2.Name == this.buButton_0.Name) || this.debugCommandEventHandler_0 == null)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
