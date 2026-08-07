// Decompiled with JetBrains decompiler
// Type: buControls.ColorPicker.buColorBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.ColorPicker;

public class buColorBox : UserControl
{
  internal int int_0 = 0;
  internal int int_1 = 0;
  private bool bool_0 = false;
  internal buColorBox.eDrawStyle eDrawStyle_0 = buColorBox.eDrawStyle.Hue;
  internal buAdobeColors.HSL hsl_0;
  internal Color color_0;
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;

  public buColorBox()
  {
    Class39.smethod_412(this);
    this.hsl_0 = new buAdobeColors.HSL();
    this.hsl_0.H = 1.0;
    this.hsl_0.S = 1.0;
    this.hsl_0.L = 1.0;
    this.color_0 = buAdobeColors.HSL_to_RGB(this.hsl_0);
    this.eDrawStyle_0 = buColorBox.eDrawStyle.Hue;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  internal void method_0(object sender, EventArgs e) => Class39.smethod_782(this);

  internal void method_1(object sender, MouseEventArgs e)
  {
    if (e.Button != MouseButtons.Left)
      return;
    this.bool_0 = true;
    int int_0 = e.X - 2;
    int int_1 = e.Y - 2;
    if (int_0 < 0)
      int_0 = 0;
    if (int_0 > this.Width - 4)
      int_0 = this.Width - 4;
    if (int_1 < 0)
      int_1 = 0;
    if (int_1 > this.Height - 4)
      int_1 = this.Height - 4;
    if ((int_0 != this.int_0 ? 0 : (int_1 == this.int_1 ? 1 : 0)) != 0)
      return;
    Class39.smethod_322(this, int_0, int_1, true);
    Class39.smethod_366(this);
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, (EventArgs) e);
  }

  internal void method_2(object sender, MouseEventArgs e)
  {
    if (!this.bool_0)
      return;
    int int_0 = e.X - 2;
    int int_1 = e.Y - 2;
    if (int_0 < 0)
      int_0 = 0;
    if (int_0 > this.Width - 4)
      int_0 = this.Width - 4;
    if (int_1 < 0)
      int_1 = 0;
    if (int_1 > this.Height - 4)
      int_1 = this.Height - 4;
    if ((int_0 != this.int_0 ? 0 : (int_1 == this.int_1 ? 1 : 0)) != 0)
      return;
    Class39.smethod_322(this, int_0, int_1, true);
    Class39.smethod_366(this);
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, (EventArgs) e);
  }

  internal void method_3(object sender, MouseEventArgs e)
  {
    if (e.Button != MouseButtons.Left || !this.bool_0)
      return;
    this.bool_0 = false;
    int int_0 = e.X - 2;
    int int_1 = e.Y - 2;
    if (int_0 < 0)
      int_0 = 0;
    if (int_0 > this.Width - 4)
      int_0 = this.Width - 4;
    if (int_1 < 0)
      int_1 = 0;
    if (int_1 > this.Height - 4)
      int_1 = this.Height - 4;
    if ((int_0 != this.int_0 ? 0 : (int_1 == this.int_1 ? 1 : 0)) != 0)
      return;
    Class39.smethod_322(this, int_0, int_1, true);
    Class39.smethod_366(this);
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, (EventArgs) e);
  }

  internal void method_4(object sender, EventArgs e) => Class39.smethod_782(this);

  internal void method_5(object sender, PaintEventArgs e) => Class39.smethod_782(this);

  public event EventHandler ScrollColor;

  public buColorBox.eDrawStyle DrawStyle
  {
    get => this.eDrawStyle_0;
    set
    {
      this.eDrawStyle_0 = value;
      Class39.smethod_781(true, this);
      Class39.smethod_782(this);
    }
  }

  public buAdobeColors.HSL HSL
  {
    get => this.hsl_0;
    set
    {
      this.hsl_0 = value;
      this.color_0 = buAdobeColors.HSL_to_RGB(this.hsl_0);
      Class39.smethod_781(true, this);
      Class39.smethod_782(this);
    }
  }

  public Color RGB
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_0);
      Class39.smethod_781(true, this);
      Class39.smethod_782(this);
    }
  }

  public enum eDrawStyle
  {
    Hue,
    Saturation,
    Brightness,
    Red,
    Green,
    Blue,
  }
}
