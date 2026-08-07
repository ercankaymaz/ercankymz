// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Events.F_Copy
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
namespace buControls.Forms.WinControlForms.Events;

public class F_Copy : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public Pnt3D refPoint = new Pnt3D();
  public bool ShowZ = true;
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList imageList_0;
  public Button btn_ok;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal Panel panel_0;

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;

  public F_Copy() => Class39.smethod_87(this);

  public void Init()
  {
    this.Properties.Inited = false;
    this.Properties.Result = DialogResult.None;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.numericUpDown_0.Value = (Decimal) this.refPoint.X;
    this.numericUpDown_1.Value = (Decimal) this.refPoint.Y;
    this.numericUpDown_2.Value = (Decimal) this.refPoint.Z;
    this.label_2.Visible = this.ShowZ;
    this.numericUpDown_2.Visible = this.ShowZ;
    this.Properties.Inited = true;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.refPoint);
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_ok.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      Class39.smethod_510(this);
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) new Pnt3D((double) this.numericUpDown_0.Value, (double) this.numericUpDown_1.Value, (double) this.numericUpDown_2.Value));
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  internal void method_1(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.Controls, result, e.Shift);
  }

  internal void method_2(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!this.Properties.Inited || this.applyCommandWithDataEventHandler_0 == null)
      return;
    Class39.smethod_510(this);
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.refPoint);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
