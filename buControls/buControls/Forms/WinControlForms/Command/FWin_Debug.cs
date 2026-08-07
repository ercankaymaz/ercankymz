// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Command.FWin_Debug
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Command;

public class FWin_Debug : Form
{
  public FormProperties Properties = new FormProperties();
  public bool PasswordCharEnable = true;
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal Button button_0;
  internal Button button_1;
  public ListBox lst_commands;
  public TextBox txt_command;

  public FWin_Debug() => Class39.smethod_264(this);

  public event DebugCommandEventHandler DebugCommandExecuted;

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
      this.txt_command.Text = "";
      this.txt_command.PasswordChar = !this.PasswordCharEnable ? char.MinValue : '*';
      this.lst_commands.Items.Clear();
      this.Properties.Result = DialogResult.None;
      this.Properties.Inited = true;
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
    Class39.smethod_650(this);
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
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
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
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  public void ClearText()
  {
    try
    {
      this.txt_command.Text = "";
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  public void ShowChar()
  {
    try
    {
      this.txt_command.PasswordChar = char.MinValue;
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  public void HideChar()
  {
    try
    {
      this.txt_command.PasswordChar = '*';
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
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
        DebugCommand = this.txt_command.Text.Trim(),
        PasswordChar = this.PasswordCharEnable
      });
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      Control control = new Control();
      if (!(((Control) sender).Name == this.button_0.Name) || this.Properties.Result == DialogResult.OK)
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
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      this.method_1((object) null, new KeyEventArgs(Keys.Return));
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
