// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Variable.F_VariableAdd
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Variable;

public class F_VariableAdd : Form
{
  public FormProperties Properties = new FormProperties();
  public List<WatchItem> Variables = new List<WatchItem>();
  public string SelectedVariables = "";
  public VariableType VarType = VariableType.LREAL;
  internal IContainer icontainer_0 = (IContainer) null;
  internal ListBox listBox_0;
  internal TextBox textBox_0;
  internal Label label_0;
  internal ImageList imageList_0;
  internal Button button_0;
  internal Button button_1;
  internal Label label_1;
  internal ComboBox comboBox_0;

  public F_VariableAdd() => Class39.smethod_246(this);

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
      ArrayList EnumItems = new ArrayList();
      buGeneral.GetEnumTypeValues((object) this.VarType, ref EnumItems);
      buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.VarType), ref this.comboBox_0);
      Class39.smethod_343(this);
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

  internal void method_0(object sender, EventArgs e)
  {
    this.SelectedVariables = "";
    if (this.listBox_0.SelectedIndex >= 0 && this.listBox_0.Text.Length > 0)
      this.SelectedVariables = this.listBox_0.Text;
    this.VarType = (VariableType) buGeneral.EnumValueFromInt((object) this.VarType, this.comboBox_0.SelectedIndex);
    if (this.SelectedVariables.Length == 0)
    {
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
  }

  internal void method_3(object sender, KeyEventArgs e)
  {
    if (e.KeyCode != Keys.Return)
      return;
    try
    {
      if (this.textBox_0.Text.Length == 0)
      {
        Class39.smethod_343(this);
      }
      else
      {
        this.listBox_0.Items.Clear();
        for (int index = 0; index <= this.Variables.Count - 1; ++index)
        {
          if (this.Variables[index].Name.ToLower().IndexOf(this.textBox_0.Text.ToLower()) >= 0)
            this.listBox_0.Items.Add((object) this.Variables[index]);
        }
      }
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
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
