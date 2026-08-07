// Decompiled with JetBrains decompiler
// Type: buControls.ColorPicker.buAdobeColors
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.Drawing;

#nullable disable
namespace buControls.ColorPicker;

public class buAdobeColors
{
  public static Color SetBrightness(Color c, double brightness)
  {
    buAdobeColors.HSL hsl = buAdobeColors.RGB_to_HSL(c);
    hsl.L = brightness;
    return buAdobeColors.HSL_to_RGB(hsl);
  }

  public static Color ModifyBrightness(Color c, double brightness)
  {
    buAdobeColors.HSL hsl = buAdobeColors.RGB_to_HSL(c);
    hsl.L *= brightness;
    return buAdobeColors.HSL_to_RGB(hsl);
  }

  public static Color SetSaturation(Color c, double Saturation)
  {
    buAdobeColors.HSL hsl = buAdobeColors.RGB_to_HSL(c);
    hsl.S = Saturation;
    return buAdobeColors.HSL_to_RGB(hsl);
  }

  public static Color ModifySaturation(Color c, double Saturation)
  {
    buAdobeColors.HSL hsl = buAdobeColors.RGB_to_HSL(c);
    hsl.S *= Saturation;
    return buAdobeColors.HSL_to_RGB(hsl);
  }

  public static Color SetHue(Color c, double Hue)
  {
    buAdobeColors.HSL hsl = buAdobeColors.RGB_to_HSL(c);
    hsl.H = Hue;
    return buAdobeColors.HSL_to_RGB(hsl);
  }

  public static Color ModifyHue(Color c, double Hue)
  {
    buAdobeColors.HSL hsl = buAdobeColors.RGB_to_HSL(c);
    hsl.H *= Hue;
    return buAdobeColors.HSL_to_RGB(hsl);
  }

  public static Color HSL_to_RGB(buAdobeColors.HSL hsl)
  {
    int num1 = Class39.smethod_664(hsl.L * (double) byte.MaxValue);
    int num2 = Class39.smethod_664((1.0 - hsl.S) * (hsl.L / 1.0) * (double) byte.MaxValue);
    double num3 = (double) (num1 - num2) / (double) byte.MaxValue;
    Color rgb;
    if ((hsl.H < 0.0 ? 0 : (hsl.H <= 1.0 / 6.0 ? 1 : 0)) != 0)
    {
      int green = Class39.smethod_664((hsl.H - 0.0) * num3 * 1530.0 + (double) num2);
      rgb = Color.FromArgb(num1, green, num2);
    }
    else if (hsl.H <= 1.0 / 3.0)
      rgb = Color.FromArgb(Class39.smethod_664(-((hsl.H - 1.0 / 6.0) * num3) * 1530.0 + (double) num1), num1, num2);
    else if (hsl.H <= 0.5)
    {
      int blue = Class39.smethod_664((hsl.H - 1.0 / 3.0) * num3 * 1530.0 + (double) num2);
      rgb = Color.FromArgb(num2, num1, blue);
    }
    else if (hsl.H <= 2.0 / 3.0)
    {
      int green = Class39.smethod_664(-((hsl.H - 0.5) * num3) * 1530.0 + (double) num1);
      rgb = Color.FromArgb(num2, green, num1);
    }
    else if (hsl.H <= 5.0 / 6.0)
      rgb = Color.FromArgb(Class39.smethod_664((hsl.H - 2.0 / 3.0) * num3 * 1530.0 + (double) num2), num2, num1);
    else if (hsl.H <= 1.0)
    {
      int blue = Class39.smethod_664(-((hsl.H - 5.0 / 6.0) * num3) * 1530.0 + (double) num1);
      rgb = Color.FromArgb(num1, num2, blue);
    }
    else
      rgb = Color.FromArgb(0, 0, 0);
    return rgb;
  }

  public static buAdobeColors.HSL RGB_to_HSL(Color c)
  {
    buAdobeColors.HSL hsl = new buAdobeColors.HSL();
    int num1;
    int num2;
    if ((int) c.R > (int) c.G)
    {
      num1 = (int) c.R;
      num2 = (int) c.G;
    }
    else
    {
      num1 = (int) c.G;
      num2 = (int) c.R;
    }
    if ((int) c.B > num1)
      num1 = (int) c.B;
    else if ((int) c.B < num2)
      num2 = (int) c.B;
    int num3 = num1 - num2;
    hsl.L = (double) num1 / (double) byte.MaxValue;
    hsl.S = num1 != 0 ? (double) num3 / (double) num1 : 0.0;
    double num4 = num3 != 0 ? 60.0 / (double) num3 : 0.0;
    hsl.H = num1 != (int) c.R ? (num1 != (int) c.G ? (num1 != (int) c.B ? 0.0 : (240.0 + num4 * (double) ((int) c.R - (int) c.G)) / 360.0) : (120.0 + num4 * (double) ((int) c.B - (int) c.R)) / 360.0) : ((int) c.G >= (int) c.B ? num4 * (double) ((int) c.G - (int) c.B) / 360.0 : (360.0 + num4 * (double) ((int) c.G - (int) c.B)) / 360.0);
    return hsl;
  }

  public static buAdobeColors.CMYK RGB_to_CMYK(Color c)
  {
    buAdobeColors.CMYK cmyk = new buAdobeColors.CMYK();
    double num = 1.0;
    cmyk.C = (double) ((int) byte.MaxValue - (int) c.R) / (double) byte.MaxValue;
    if (num > cmyk.C)
      num = cmyk.C;
    cmyk.M = (double) ((int) byte.MaxValue - (int) c.G) / (double) byte.MaxValue;
    if (num > cmyk.M)
      num = cmyk.M;
    cmyk.Y = (double) ((int) byte.MaxValue - (int) c.B) / (double) byte.MaxValue;
    if (num > cmyk.Y)
      num = cmyk.Y;
    if (num > 0.0)
      cmyk.K = num;
    return cmyk;
  }

  public static Color CMYK_to_RGB(buAdobeColors.CMYK _cmyk)
  {
    return Color.FromArgb(Class39.smethod_664((double) byte.MaxValue - (double) byte.MaxValue * _cmyk.C), Class39.smethod_664((double) byte.MaxValue - (double) byte.MaxValue * _cmyk.M), Class39.smethod_664((double) byte.MaxValue - (double) byte.MaxValue * _cmyk.Y));
  }

  public class HSL
  {
    private double double_0;
    private double double_1;
    private double double_2;

    public HSL()
    {
      this.double_0 = 0.0;
      this.double_1 = 0.0;
      this.double_2 = 0.0;
    }

    public double H
    {
      get => this.double_0;
      set
      {
        this.double_0 = value;
        this.double_0 = this.double_0 > 1.0 ? 1.0 : (this.double_0 < 0.0 ? 0.0 : this.double_0);
      }
    }

    public double S
    {
      get => this.double_1;
      set
      {
        this.double_1 = value;
        this.double_1 = this.double_1 > 1.0 ? 1.0 : (this.double_1 < 0.0 ? 0.0 : this.double_1);
      }
    }

    public double L
    {
      get => this.double_2;
      set
      {
        this.double_2 = value;
        this.double_2 = this.double_2 > 1.0 ? 1.0 : (this.double_2 < 0.0 ? 0.0 : this.double_2);
      }
    }
  }

  public class CMYK
  {
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;

    public CMYK()
    {
      this.double_0 = 0.0;
      this.double_1 = 0.0;
      this.double_2 = 0.0;
      this.double_3 = 0.0;
    }

    public double C
    {
      get => this.double_0;
      set
      {
        this.double_0 = value;
        this.double_0 = this.double_0 > 1.0 ? 1.0 : (this.double_0 < 0.0 ? 0.0 : this.double_0);
      }
    }

    public double M
    {
      get => this.double_1;
      set
      {
        this.double_1 = value;
        this.double_1 = this.double_1 > 1.0 ? 1.0 : (this.double_1 < 0.0 ? 0.0 : this.double_1);
      }
    }

    public double Y
    {
      get => this.double_2;
      set
      {
        this.double_2 = value;
        this.double_2 = this.double_2 > 1.0 ? 1.0 : (this.double_2 < 0.0 ? 0.0 : this.double_2);
      }
    }

    public double K
    {
      get => this.double_3;
      set
      {
        this.double_3 = value;
        this.double_3 = this.double_3 > 1.0 ? 1.0 : (this.double_3 < 0.0 ? 0.0 : this.double_3);
      }
    }
  }
}
