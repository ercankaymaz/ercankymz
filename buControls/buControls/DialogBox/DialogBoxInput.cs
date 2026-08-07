// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.DialogBoxInput
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox;

public class DialogBoxInput : Form
{
  public double Value = 0.0;
  public string ValueCaption = nameof (Value);
  public string FormCaption = "Data Input";
  public int FormWidth = 0;
  public int FormHeight = 0;
  public DialogResult Result = DialogResult.None;
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList imageList_0;
  public Button btn_ok;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;

  public DialogBoxInput() => Class39.smethod_62(this);

  public void Init()
  {
    if (this.FormWidth > 1)
      this.Width = this.FormWidth;
    if (this.FormHeight > 1)
      this.Height = this.FormHeight;
    this.Text = this.FormCaption;
    this.label_0.Text = this.ValueCaption;
    this.numericUpDown_0.Value = (System.Decimal) this.Value;
    this.Result = DialogResult.None;
  }

  public void SelectAll() => this.numericUpDown_0.Select(0, 100);

  public void Decimal(int Decimal) => this.numericUpDown_0.DecimalPlaces = Decimal;

  internal void method_0(object sender, EventArgs e)
  {
    this.Value = (double) this.numericUpDown_0.Value;
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
