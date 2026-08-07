// Decompiled with JetBrains decompiler
// Type: buControls.UserControls.buContentAlignment
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.UserControls;

public class buContentAlignment : UserControl
{
  private Color color_0 = Color.LightGray;
  private Color color_1 = Color.Gray;
  private ContentAlignment contentAlignment_0 = ContentAlignment.MiddleCenter;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;

  public buContentAlignment() => Class39.smethod_208(this);

  [Description("BackColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "LightGray")]
  [Category("Appearance")]
  public Color ActiveColor
  {
    get => this.color_0;
    set
    {
      if (value == this.color_0)
        return;
      this.color_0 = value;
      this.button_2.BackColor = this.color_0;
      this.button_1.BackColor = this.color_0;
      this.button_0.BackColor = this.color_0;
      this.button_6.BackColor = this.color_0;
      this.button_7.BackColor = this.color_0;
      this.button_8.BackColor = this.color_0;
      this.button_3.BackColor = this.color_0;
      this.button_4.BackColor = this.color_0;
      this.button_5.BackColor = this.color_0;
      this.Invalidate();
    }
  }

  [Description("Selected Color")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "Gray")]
  [Category("Appearance")]
  public Color SelectedColor
  {
    get => this.color_1;
    set
    {
      if (value == this.color_1)
        return;
      this.color_1 = value;
      this.Invalidate();
    }
  }

  [Description("Content Alignment")]
  [Browsable(true)]
  [DefaultValue(typeof (ContentAlignment), "MiddleCenter")]
  [Category("Appearance")]
  public ContentAlignment Alignment
  {
    get => this.contentAlignment_0;
    set
    {
      this.contentAlignment_0 = value;
      this.button_2.BackColor = this.color_0;
      this.button_1.BackColor = this.color_0;
      this.button_0.BackColor = this.color_0;
      this.button_6.BackColor = this.color_0;
      this.button_7.BackColor = this.color_0;
      this.button_8.BackColor = this.color_0;
      this.button_3.BackColor = this.color_0;
      this.button_4.BackColor = this.color_0;
      this.button_5.BackColor = this.color_0;
      if (this.contentAlignment_0 == ContentAlignment.BottomLeft)
        this.button_2.BackColor = this.SelectedColor;
      if (this.contentAlignment_0 == ContentAlignment.BottomRight)
        this.button_6.BackColor = this.SelectedColor;
      if (this.contentAlignment_0 == ContentAlignment.BottomCenter)
        this.button_3.BackColor = this.SelectedColor;
      if (this.contentAlignment_0 == ContentAlignment.TopCenter)
        this.button_5.BackColor = this.SelectedColor;
      if (this.contentAlignment_0 == ContentAlignment.TopLeft)
        this.button_0.BackColor = this.SelectedColor;
      if (this.contentAlignment_0 == ContentAlignment.TopRight)
        this.button_8.BackColor = this.SelectedColor;
      if (this.contentAlignment_0 == ContentAlignment.MiddleCenter)
        this.button_4.BackColor = this.SelectedColor;
      if (this.contentAlignment_0 == ContentAlignment.MiddleLeft)
        this.button_1.BackColor = this.SelectedColor;
      if (this.contentAlignment_0 == ContentAlignment.MiddleRight)
        this.button_7.BackColor = this.SelectedColor;
      this.Invalidate();
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.button_3.Name)
      this.Alignment = ContentAlignment.BottomCenter;
    if (control2.Name == this.button_2.Name)
      this.Alignment = ContentAlignment.BottomLeft;
    if (control2.Name == this.button_6.Name)
      this.Alignment = ContentAlignment.BottomRight;
    if (control2.Name == this.button_5.Name)
      this.Alignment = ContentAlignment.TopCenter;
    if (control2.Name == this.button_0.Name)
      this.Alignment = ContentAlignment.TopLeft;
    if (control2.Name == this.button_8.Name)
      this.Alignment = ContentAlignment.TopRight;
    if (control2.Name == this.button_4.Name)
      this.Alignment = ContentAlignment.MiddleCenter;
    if (control2.Name == this.button_1.Name)
      this.Alignment = ContentAlignment.MiddleLeft;
    if (!(control2.Name == this.button_7.Name))
      return;
    this.Alignment = ContentAlignment.MiddleRight;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
