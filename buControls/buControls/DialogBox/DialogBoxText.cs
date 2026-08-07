// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.DialogBoxText
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox;

public class DialogBoxText : Form
{
  public string FormCaption = "Inut";
  public string Caption = "Data";
  public DialogResult Result = DialogResult.None;
  public string Value = "";
  private IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_0;
  internal TextBox textBox_0;
  internal ImageList imageList_0;

  public DialogBoxText() => Class39.smethod_566(this);

  public void Init(string Text)
  {
    this.Text = this.FormCaption;
    this.Value = Text;
    this.label_0.Text = this.Caption;
    this.textBox_0.Text = Text;
    this.textBox_0.Focus();
    this.textBox_0.SelectAll();
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.Value = this.textBox_0.Text;
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
