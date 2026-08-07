// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_Status
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_Status : Form
{
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  public Label lbl_status;
  public ProgressBar progressBar1;
  public Label lbl_time;

  public F_Status() => Class39.smethod_177(this);

  public event EventHandler StatusClick;

  public void Init() => Class39.smethod_421(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0(sender, e);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
