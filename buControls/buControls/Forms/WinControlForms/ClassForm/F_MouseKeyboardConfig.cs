// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.ClassForm.F_MouseKeyboardConfig
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
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.ClassForm;

public class F_MouseKeyboardConfig : Form
{
  public MouseKeyboardConfigration Value = new MouseKeyboardConfigration();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal ComboBox comboBox_0;
  internal Label label_0;
  internal ComboBox comboBox_1;
  internal Label label_1;
  public Button btn_cancel;
  public Button btn_ok;

  public F_MouseKeyboardConfig() => Class39.smethod_621(this);

  public void Init()
  {
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Value.Button.GetType(), ref EnumItems1);
    for (int index = 0; index <= EnumItems1.Count - 1; ++index)
      this.comboBox_0.Items.Add((object) EnumItems1[index].ToString());
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Value.Key.GetType(), ref EnumItems2);
    for (int index = 0; index <= EnumItems2.Count - 1; ++index)
      this.comboBox_1.Items.Add((object) EnumItems2[index].ToString());
    this.comboBox_0.SelectedIndex = Convert.ToInt32((object) this.Value.Button);
    this.comboBox_1.SelectedIndex = Convert.ToInt32((object) this.Value.Key);
    Class39.smethod_19(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value.Button = (mouseButtons) new EnumConverter(this.Value.Button.GetType()).ConvertFromString(this.comboBox_0.Text);
    this.Value.Key = (modifierKeys) new EnumConverter(this.Value.Key.GetType()).ConvertFromString(this.comboBox_1.Text);
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e) => this.Dispose();

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
