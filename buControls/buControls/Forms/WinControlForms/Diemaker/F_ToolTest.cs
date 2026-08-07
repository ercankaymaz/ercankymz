// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_ToolTest
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_ToolTest : Form
{
  public List<string> Tools = new List<string>();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal ListBox listBox_0;
  internal Button button_0;
  internal Button button_1;

  public F_ToolTest() => Class39.smethod_786(this);

  public event ValueChangedEventHandler ToolTest;

  public void Init()
  {
    this.listBox_0.Items.Clear();
    for (int index = 0; index <= this.Tools.Count - 1; ++index)
      this.listBox_0.Items.Add((object) this.Tools[index]);
    this.listBox_0.SelectedIndex = 0;
    Class39.smethod_100(this);
  }

  internal void method_0(object sender, EventArgs e) => this.Visible = false;

  internal void method_1(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.valueChangedEventHandler_0((double) this.listBox_0.SelectedIndex);
  }

  internal void method_2(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
