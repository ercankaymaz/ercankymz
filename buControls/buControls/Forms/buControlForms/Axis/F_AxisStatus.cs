// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Axis.F_AxisStatus
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Axis;

public class F_AxisStatus : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buCheckBox buCheckBox_0;
  internal buCheckBox buCheckBox_1;
  internal buLabel buLabel_0;
  internal buLabel buLabel_1;
  internal buTextBox buTextBox_0;
  internal buTextBox buTextBox_1;

  public F_AxisStatus() => Class39.smethod_163(this);

  public void Init()
  {
  }

  public void UpdateFields(double Position, string AxisChar, string Status, string Comm)
  {
    this.buTextBox_0.Text = Status;
    this.buTextBox_1.Text = Comm;
    this.buLabel_1.Text = AxisChar;
    this.buLabel_0.Text = Position.ToString("f3");
  }

  public void UpdateFields(
    double Position,
    string AxisChar,
    bool Homing,
    bool Enable,
    string Status,
    string Comm)
  {
    this.buTextBox_0.Text = Status;
    this.buTextBox_1.Text = Comm;
    this.buLabel_1.Text = AxisChar;
    this.buLabel_0.Text = Position.ToString("f3");
    this.buCheckBox_0.Check = Enable;
    this.buCheckBox_1.Check = Homing;
  }

  internal void method_0(object sender, EventArgs e) => this.Visible = false;

  public event StatusChangedEventHandler StatusChanged;

  internal void method_1(object object_0, bool bool_0)
  {
    Control control1 = new Control();
    Control control2 = (Control) object_0;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.buCheckBox_0.Name && this.statusChangedEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.statusChangedEventHandler_0((object) this.buCheckBox_0, this.buCheckBox_0.Check, this.buCheckBox_1.Check);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.buCheckBox_1.Name) || this.statusChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.statusChangedEventHandler_0((object) this.buCheckBox_1, this.buCheckBox_0.Check, this.buCheckBox_1.Check);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
