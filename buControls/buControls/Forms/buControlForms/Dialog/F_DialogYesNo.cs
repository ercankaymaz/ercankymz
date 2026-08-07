// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Dialog.F_DialogYesNo
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Dialog;

public class F_DialogYesNo : Form
{
  public string Caption = "";
  public string Message = "";
  public DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buLabel buLabel_0;
  internal buButton buButton_1;

  public F_DialogYesNo() => Class39.smethod_685(this);

  public void ShowDialog(string message, string caption = "")
  {
    this.Text = this.Caption;
    this.buGround_0.Text = this.Caption;
    if (caption.Length > 0)
    {
      this.Text = caption;
      this.buGround_0.Text = caption;
    }
    this.buLabel_0.Text = message;
    int num = (int) this.ShowDialog();
  }

  public void ShowDialog(string message, IWin32Window owner, string caption = "")
  {
    this.Text = this.Caption;
    this.buGround_0.Text = this.Caption;
    if (caption.Length > 0)
    {
      this.Text = caption;
      this.buGround_0.Text = caption;
    }
    this.buLabel_0.Text = message;
    int num = (int) this.ShowDialog(owner);
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control = sender as Control;
    if (control.Name == this.buButton_0.Name)
      this.Result = DialogResult.Yes;
    if (control.Name == this.buButton_1.Name)
      this.Result = DialogResult.No;
    this.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
