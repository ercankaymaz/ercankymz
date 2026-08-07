// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Progress.F_ProgressCalculation
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
namespace buControls.Forms.WinControlForms.Progress;

public class F_ProgressCalculation : Form
{
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal Label label_1;
  internal Button button_0;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  public ProgressBar progress_current;
  public ProgressBar progress_overall;

  public F_ProgressCalculation() => Class39.smethod_363(this);

  public event CancelCommandEventHandler CancelProcess;

  public void Init(double currentvalue, double overallvalue, string operation)
  {
    if (currentvalue >= 0.0 & currentvalue <= (double) this.progress_current.Maximum)
    {
      this.progress_current.Value = (int) currentvalue;
      this.label_4.Text = currentvalue.ToString("f1") + "%";
    }
    else if (currentvalue < 0.0)
    {
      this.progress_current.Value = 0;
      this.label_4.Text = "0.0%";
    }
    else if (currentvalue > (double) this.progress_current.Maximum)
    {
      this.progress_current.Value = this.progress_current.Maximum;
      this.label_4.Text = this.progress_current.Maximum.ToString("f1") + "%";
    }
    if (overallvalue >= 0.0 & overallvalue <= (double) this.progress_overall.Maximum)
    {
      this.progress_overall.Value = (int) overallvalue;
      this.label_5.Text = overallvalue.ToString("f1") + "%";
    }
    else if (overallvalue < 0.0)
    {
      this.progress_overall.Value = 0;
      this.label_5.Text = "0.0%";
    }
    else if (overallvalue > (double) this.progress_overall.Maximum)
    {
      this.progress_overall.Value = this.progress_overall.Maximum;
      this.label_5.Text = this.progress_overall.Maximum.ToString("f1") + "%";
    }
    this.label_3.Text = operation;
    Class39.smethod_424(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.cancelCommandEventHandler_0();
    }
    buSystem.Cancel = true;
    this.Visible = false;
  }

  internal void method_1(object sender, FormClosingEventArgs e)
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
