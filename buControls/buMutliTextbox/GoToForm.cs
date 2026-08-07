// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.GoToForm
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class GoToForm : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal TextBox textBox_0;
  internal Button button_0;
  internal Button button_1;

  public int SelectedLineNumber { get; set; }

  public int TotalLineCount { get; set; }

  public GoToForm() => Class39.smethod_404(this);

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);
    this.textBox_0.Text = this.SelectedLineNumber.ToString();
    this.label_0.Text = $"Line number (1 - {this.TotalLineCount}):";
  }

  protected override void OnShown(EventArgs e)
  {
    base.OnShown(e);
    this.textBox_0.Focus();
  }

  internal void method_0(object sender, EventArgs e)
  {
    int result;
    if (int.TryParse(this.textBox_0.Text, out result))
      this.SelectedLineNumber = Math.Max(1, Math.Min(result, this.TotalLineCount));
    this.DialogResult = DialogResult.OK;
    this.Close();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.DialogResult = DialogResult.Cancel;
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
