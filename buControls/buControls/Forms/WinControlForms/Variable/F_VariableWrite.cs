// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Variable.F_VariableWrite
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Variable;

public class F_VariableWrite : Form
{
  public FormProperties Properties = new FormProperties();
  public WatchItem Variable = new WatchItem();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ComboBox comboBox_0;
  internal Label label_0;
  internal Label label_1;
  internal TextBox textBox_0;
  internal Label label_2;
  internal ImageList imageList_0;
  internal Button button_0;
  internal Button button_1;
  internal TextBox textBox_1;

  public F_VariableWrite() => Class39.smethod_99(this);

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
      buGeneral.GetEnumTypeValues((object) this.Variable.VarType, ref EnumItems);
      buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Variable.VarType), ref this.comboBox_0);
      this.textBox_0.Text = this.Variable.Name;
      this.textBox_1.Text = this.Variable.Value.ToString();
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
    this.Variable.NewValue = this.textBox_1.Text;
    this.Variable.VarType = (VariableType) buGeneral.EnumValueFromInt((object) this.Variable.VarType, this.comboBox_0.SelectedIndex);
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
