// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Library.F_LibraryProps
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Library;

public class F_LibraryProps : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public LibraryProps Properties = new LibraryProps();
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList imageList_0;
  public Button btn_ok;
  internal TextBox textBox_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal TextBox textBox_1;
  internal Label label_2;

  public F_LibraryProps() => Class39.smethod_462(this);

  public void Init(LibraryProps properties)
  {
    this.bool_0 = false;
    this.Result = DialogResult.None;
    this.bool_0 = true;
    Class39.smethod_222(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (this.bool_0)
    {
      Class39.smethod_81(this);
      this.Result = DialogResult.OK;
    }
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  internal void method_2(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.Controls, result, e.Shift);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
