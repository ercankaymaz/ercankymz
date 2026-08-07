// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlInterpolatedGradient
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns11;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class56))]
public class buControlInterpolatedGradient
{
  private Color color_0 = Color.LightGray;
  private Color color_1 = Color.Gray;
  private Color color_2 = Color.DimGray;
  private Color color_3 = Color.Black;
  private int int_0 = 3;
  public Control Parent = (Control) null;

  public event EventHandler Changed;

  public buControlInterpolatedGradient()
  {
  }

  public buControlInterpolatedGradient(
    Color firstcolor,
    Color secondcolor,
    Color thirdcolor,
    Color fourthcolor,
    int colorcount)
  {
    this.FirstColor = firstcolor;
    this.SecondColor = secondcolor;
    this.ThirdColor = thirdcolor;
    this.FourthColor = fourthcolor;
    this.ColorCount = colorcount;
  }

  public buControlInterpolatedGradient(buControlInterpolatedGradient gradient)
  {
    this.FirstColor = gradient.FirstColor;
    this.SecondColor = gradient.SecondColor;
    this.ThirdColor = gradient.ThirdColor;
    this.FourthColor = gradient.FourthColor;
    this.ColorCount = gradient.ColorCount;
    this.Parent = gradient.Parent;
  }

  public static void Copy(
    buControlInterpolatedGradient Source,
    ref buControlInterpolatedGradient Target)
  {
    Target.FirstColor = Source.FirstColor;
    Target.SecondColor = Source.SecondColor;
    Target.ThirdColor = Source.ThirdColor;
    Target.FourthColor = Source.FourthColor;
    Target.ColorCount = Source.ColorCount;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(3)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int ColorCount
  {
    get => this.int_0;
    set
    {
      this.int_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightGray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color FirstColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Gray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color SecondColor
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "DimGray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color ThirdColor
  {
    get => this.color_2;
    set
    {
      this.color_2 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Black")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color FourthColor
  {
    get => this.color_3;
    set
    {
      this.color_3 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  protected void OnChanged()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler0 = this.eventHandler_0;
    if (eventHandler0 == null)
      return;
    eventHandler0((object) this, EventArgs.Empty);
  }

  public override string ToString()
  {
    string str1 = this.FirstColor.ToString();
    string str2 = this.SecondColor.ToString();
    string str3 = this.ThirdColor.ToString();
    string str4 = this.FourthColor.ToString();
    KnownColor knownColor;
    if (this.FirstColor.IsKnownColor)
    {
      knownColor = this.FirstColor.ToKnownColor();
      str1 = knownColor.ToString();
    }
    Color color = this.SecondColor;
    if (color.IsKnownColor)
    {
      color = this.SecondColor;
      knownColor = color.ToKnownColor();
      str2 = knownColor.ToString();
    }
    color = this.ThirdColor;
    if (color.IsKnownColor)
    {
      color = this.ThirdColor;
      knownColor = color.ToKnownColor();
      str3 = knownColor.ToString();
    }
    color = this.FourthColor;
    if (color.IsKnownColor)
    {
      color = this.FourthColor;
      knownColor = color.ToKnownColor();
      str4 = knownColor.ToString();
    }
    return $"{str1} , {str2} , {str3} , {str4}";
  }
}
