// Decompiled with JetBrains decompiler
// Type: buControls.ColorPicker.buColorVerticalSlider
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.ColorPicker;

public class buColorVerticalSlider : UserControl
{
  internal int int_0 = 0;
  private bool bool_0 = false;
  internal buColorVerticalSlider.eDrawStyle eDrawStyle_0 = buColorVerticalSlider.eDrawStyle.Hue;
  internal buAdobeColors.HSL hsl_0;
  internal Color color_0;
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;

  public buColorVerticalSlider()
  {
    Class39.smethod_172(this);
    this.hsl_0 = new buAdobeColors.HSL();
    this.hsl_0.H = 1.0;
    this.hsl_0.S = 1.0;
    this.hsl_0.L = 1.0;
    this.color_0 = buAdobeColors.HSL_to_RGB(this.hsl_0);
    this.eDrawStyle_0 = buColorVerticalSlider.eDrawStyle.Hue;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  internal void method_0(object sender, EventArgs e) => Class39.smethod_761(this);

  internal void method_1(object sender, MouseEventArgs e)
  {
    if (e.Button != MouseButtons.Left)
      return;
    this.bool_0 = true;
    int int_0 = e.Y - 4;
    if (int_0 < 0)
      int_0 = 0;
    if (int_0 > this.Height - 9)
      int_0 = this.Height - 9;
    if (int_0 == this.int_0)
      return;
    Class39.smethod_239(this, int_0, false);
    Class39.smethod_335(this);
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
    int int_0 = e.Y - 4;
    if (int_0 < 0)
      int_0 = 0;
    if (int_0 > this.Height - 9)
      int_0 = this.Height - 9;
    if (int_0 == this.int_0)
      return;
    Class39.smethod_239(this, int_0, false);
    Class39.smethod_335(this);
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, (EventArgs) e);
  }

  internal void method_3(object sender, MouseEventArgs e)
  {
    if (e.Button != MouseButtons.Left)
      return;
    this.bool_0 = false;
    int int_0 = e.Y - 4;
    if (int_0 < 0)
      int_0 = 0;
    if (int_0 > this.Height - 9)
      int_0 = this.Height - 9;
    if (int_0 == this.int_0)
      return;
    Class39.smethod_239(this, int_0, false);
    Class39.smethod_335(this);
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, (EventArgs) e);
  }

  internal void method_4(object sender, PaintEventArgs e) => Class39.smethod_761(this);

  internal void method_5(object sender, EventArgs e) => Class39.smethod_761(this);

  public event EventHandler ScrollColor;

  public buColorVerticalSlider.eDrawStyle DrawStyle
  {
    get => this.eDrawStyle_0;
    set
    {
      this.eDrawStyle_0 = value;
      Class39.smethod_313(true, this);
      Class39.smethod_761(this);
    }
  }

  public buAdobeColors.HSL HSL
  {
    get => this.hsl_0;
    set
    {
      this.hsl_0 = value;
      this.color_0 = buAdobeColors.HSL_to_RGB(this.hsl_0);
      Class39.smethod_313(true, this);
      Class39.smethod_790(this);
    }
  }

  public Color RGB
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_0);
      Class39.smethod_313(true, this);
      Class39.smethod_790(this);
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
