// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XColor
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

#nullable disable
namespace PdfSharp.Drawing;

[DebuggerDisplay("clr=(A={A}, R={R}, G={G}, B={B} C={C}, M={M}, Y={Y}, K={K})")]
public struct XColor
{
  public static XColor Empty;
  private XColorSpace _cs;
  private float _a;
  private byte _r;
  private byte _g;
  private byte _b;
  private float _c;
  private float _m;
  private float _y;
  private float _k;
  private float _gs;

  private XColor(uint argb)
  {
    this._cs = XColorSpace.Rgb;
    this._a = (float) (byte) (argb >> 24 & (uint) byte.MaxValue) / (float) byte.MaxValue;
    this._r = (byte) (argb >> 16 /*0x10*/ & (uint) byte.MaxValue);
    this._g = (byte) (argb >> 8 & (uint) byte.MaxValue);
    this._b = (byte) (argb & (uint) byte.MaxValue);
    this._c = 0.0f;
    this._m = 0.0f;
    this._y = 0.0f;
    this._k = 0.0f;
    this._gs = 0.0f;
    this.RgbChanged();
  }

  private XColor(byte alpha, byte red, byte green, byte blue)
  {
    this._cs = XColorSpace.Rgb;
    this._a = (float) alpha / (float) byte.MaxValue;
    this._r = red;
    this._g = green;
    this._b = blue;
    this._c = 0.0f;
    this._m = 0.0f;
    this._y = 0.0f;
    this._k = 0.0f;
    this._gs = 0.0f;
    this.RgbChanged();
  }

  private XColor(double alpha, double cyan, double magenta, double yellow, double black)
  {
    this._cs = XColorSpace.Cmyk;
    this._a = alpha > 1.0 ? 1f : (alpha < 0.0 ? 0.0f : (float) alpha);
    this._c = cyan > 1.0 ? 1f : (cyan < 0.0 ? 0.0f : (float) cyan);
    this._m = magenta > 1.0 ? 1f : (magenta < 0.0 ? 0.0f : (float) magenta);
    this._y = yellow > 1.0 ? 1f : (yellow < 0.0 ? 0.0f : (float) yellow);
    this._k = black > 1.0 ? 1f : (black < 0.0 ? 0.0f : (float) black);
    this._r = (byte) 0;
    this._g = (byte) 0;
    this._b = (byte) 0;
    this._gs = 0.0f;
    this.CmykChanged();
  }

  private XColor(double cyan, double magenta, double yellow, double black)
    : this(1.0, cyan, magenta, yellow, black)
  {
  }

  private XColor(double gray)
  {
    this._cs = XColorSpace.GrayScale;
    this._gs = gray >= 0.0 ? (gray <= 1.0 ? (float) gray : 1f) : 0.0f;
    this._a = 1f;
    this._r = (byte) 0;
    this._g = (byte) 0;
    this._b = (byte) 0;
    this._c = 0.0f;
    this._m = 0.0f;
    this._y = 0.0f;
    this._k = 0.0f;
    this.GrayChanged();
  }

  internal XColor(XKnownColor knownColor)
    : this(XKnownColorTable.KnownColorToArgb(knownColor))
  {
  }

  public static XColor FromArgb(int argb)
  {
    return new XColor((byte) (argb >> 24), (byte) (argb >> 16 /*0x10*/), (byte) (argb >> 8), (byte) argb);
  }

  public static XColor FromArgb(uint argb)
  {
    return new XColor((byte) (argb >> 24), (byte) (argb >> 16 /*0x10*/), (byte) (argb >> 8), (byte) argb);
  }

  public static XColor FromArgb(int red, int green, int blue)
  {
    XColor.CheckByte(red, nameof (red));
    XColor.CheckByte(green, nameof (green));
    XColor.CheckByte(blue, nameof (blue));
    return new XColor(byte.MaxValue, (byte) red, (byte) green, (byte) blue);
  }

  public static XColor FromArgb(int alpha, int red, int green, int blue)
  {
    XColor.CheckByte(alpha, nameof (alpha));
    XColor.CheckByte(red, nameof (red));
    XColor.CheckByte(green, nameof (green));
    XColor.CheckByte(blue, nameof (blue));
    return new XColor((byte) alpha, (byte) red, (byte) green, (byte) blue);
  }

  public static XColor FromArgb(int alpha, XColor color)
  {
    color.A = (double) (byte) alpha / (double) byte.MaxValue;
    return color;
  }

  public static XColor FromCmyk(double cyan, double magenta, double yellow, double black)
  {
    return new XColor(cyan, magenta, yellow, black);
  }

  public static XColor FromCmyk(
    double alpha,
    double cyan,
    double magenta,
    double yellow,
    double black)
  {
    return new XColor(alpha, cyan, magenta, yellow, black);
  }

  public static XColor FromGrayScale(double grayScale) => new XColor(grayScale);

  public static XColor FromKnownColor(XKnownColor color) => new XColor(color);

  public static XColor FromName(string name) => XColor.Empty;

  public XColorSpace ColorSpace
  {
    get => this._cs;
    set
    {
      this._cs = Enum.IsDefined(typeof (XColorSpace), (object) value) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (XColorSpace));
    }
  }

  public bool IsEmpty => this == XColor.Empty;

  public override bool Equals(object obj)
  {
    return obj is XColor xcolor && ((int) this._r != (int) xcolor._r || (int) this._g != (int) xcolor._g || (int) this._b != (int) xcolor._b || (double) this._c != (double) xcolor._c || (double) this._m != (double) xcolor._m || (double) this._y != (double) xcolor._y || (double) this._k != (double) xcolor._k ? 0 : ((double) this._gs == (double) xcolor._gs ? 1 : 0)) != 0 && (double) this._a == (double) xcolor._a;
  }

  public override int GetHashCode()
  {
    return (int) (byte) ((double) this._a * (double) byte.MaxValue) ^ (int) this._r ^ (int) this._g ^ (int) this._b;
  }

  public static bool operator ==(XColor left, XColor right)
  {
    return ((int) left._r != (int) right._r || (int) left._g != (int) right._g || (int) left._b != (int) right._b || (double) left._c != (double) right._c || (double) left._m != (double) right._m || (double) left._y != (double) right._y || (double) left._k != (double) right._k ? 0 : ((double) left._gs == (double) right._gs ? 1 : 0)) != 0 && (double) left._a == (double) right._a;
  }

  public static bool operator !=(XColor left, XColor right) => !(left == right);

  public bool IsKnownColor => XKnownColorTable.IsKnownColor(this.Argb);

  public double GetHue()
  {
    double hue;
    if (((int) this._r != (int) this._g ? 0 : ((int) this._g == (int) this._b ? 1 : 0)) != 0)
    {
      hue = 0.0;
    }
    else
    {
      double num1 = (double) this._r / (double) byte.MaxValue;
      double num2 = (double) this._g / (double) byte.MaxValue;
      double num3 = (double) this._b / (double) byte.MaxValue;
      double num4 = 0.0;
      double num5 = num1;
      double num6 = num1;
      if (num2 > num5)
        num5 = num2;
      if (num3 > num5)
        num5 = num3;
      if (num2 < num6)
        num6 = num2;
      if (num3 < num6)
        num6 = num3;
      double num7 = num5 - num6;
      if (num1 == num5)
        num4 = (num2 - num3) / num7;
      else if (num2 == num5)
        num4 = 2.0 + (num3 - num1) / num7;
      else if (num3 == num5)
        num4 = 4.0 + (num1 - num2) / num7;
      double num8 = num4 * 60.0;
      if (num8 < 0.0)
        num8 += 360.0;
      hue = num8;
    }
    return hue;
  }

  public double GetSaturation()
  {
    double num1 = (double) this._r / (double) byte.MaxValue;
    double num2 = (double) this._g / (double) byte.MaxValue;
    double num3 = (double) this._b / (double) byte.MaxValue;
    double num4 = 0.0;
    double num5 = num1;
    double num6 = num1;
    if (num2 > num5)
      num5 = num2;
    if (num3 > num5)
      num5 = num3;
    if (num2 < num6)
      num6 = num2;
    if (num3 < num6)
      num6 = num3;
    return num5 != num6 ? ((num5 + num6) / 2.0 > 0.5 ? (num5 - num6) / (2.0 - num5 - num6) : (num5 - num6) / (num5 + num6)) : num4;
  }

  public double GetBrightness()
  {
    double num1 = (double) this._r / (double) byte.MaxValue;
    double num2 = (double) this._g / (double) byte.MaxValue;
    double num3 = (double) this._b / (double) byte.MaxValue;
    double num4 = num1;
    double num5 = num1;
    if (num2 > num4)
      num4 = num2;
    if (num3 > num4)
      num4 = num3;
    if (num2 < num5)
      num5 = num2;
    if (num3 < num5)
      num5 = num3;
    return (num4 + num5) / 2.0;
  }

  private void RgbChanged()
  {
    this._cs = XColorSpace.Rgb;
    int val1_1 = (int) byte.MaxValue - (int) this._r;
    int val1_2 = (int) byte.MaxValue - (int) this._g;
    int val2 = (int) byte.MaxValue - (int) this._b;
    int num1 = Math.Min(val1_1, Math.Min(val1_2, val2));
    if (num1 == (int) byte.MaxValue)
    {
      float num2 = 0.0f;
      this._y = 0.0f;
      double num3 = (double) num2;
      float num4 = 0.0f;
      this._m = (float) num3;
      this._c = num4;
    }
    else
    {
      float num5 = (float) byte.MaxValue - (float) num1;
      this._c = (float) (val1_1 - num1) / num5;
      this._m = (float) (val1_2 - num1) / num5;
      this._y = (float) (val2 - num1) / num5;
    }
    this._k = this._gs = (float) num1 / (float) byte.MaxValue;
  }

  private void CmykChanged()
  {
    this._cs = XColorSpace.Cmyk;
    float num1 = this._k * (float) byte.MaxValue;
    float num2 = (float) byte.MaxValue - num1;
    this._r = (byte) ((double) byte.MaxValue - (double) Math.Min((float) byte.MaxValue, this._c * num2 + num1));
    this._g = (byte) ((double) byte.MaxValue - (double) Math.Min((float) byte.MaxValue, this._m * num2 + num1));
    this._b = (byte) ((double) byte.MaxValue - (double) Math.Min((float) byte.MaxValue, this._y * num2 + num1));
    this._gs = (float) (1.0 - Math.Min(1.0, 0.30000001192092896 * (double) this._c + 0.5899999737739563 * (double) this._m + 0.11 * (double) this._y + (double) this._k));
  }

  private void GrayChanged()
  {
    this._cs = XColorSpace.GrayScale;
    this._r = (byte) ((double) this._gs * (double) byte.MaxValue);
    this._g = (byte) ((double) this._gs * (double) byte.MaxValue);
    this._b = (byte) ((double) this._gs * (double) byte.MaxValue);
    this._c = 0.0f;
    this._m = 0.0f;
    this._y = 0.0f;
    this._k = 1f - this._gs;
  }

  public double A
  {
    get => (double) this._a;
    set
    {
      if (value < 0.0)
        this._a = 0.0f;
      else if (value > 1.0)
        this._a = 1f;
      else
        this._a = (float) value;
    }
  }

  public byte R
  {
    get => this._r;
    set
    {
      this._r = value;
      this.RgbChanged();
    }
  }

  public byte G
  {
    get => this._g;
    set
    {
      this._g = value;
      this.RgbChanged();
    }
  }

  public byte B
  {
    get => this._b;
    set
    {
      this._b = value;
      this.RgbChanged();
    }
  }

  internal uint Rgb => (uint) ((int) this._r << 16 /*0x10*/ | (int) this._g << 8) | (uint) this._b;

  internal uint Argb
  {
    get
    {
      return (uint) ((int) (uint) ((double) this._a * (double) byte.MaxValue) << 24 | (int) this._r << 16 /*0x10*/ | (int) this._g << 8) | (uint) this._b;
    }
  }

  public double C
  {
    get => (double) this._c;
    set
    {
      this._c = value >= 0.0 ? (value <= 1.0 ? (float) value : 1f) : 0.0f;
      this.CmykChanged();
    }
  }

  public double M
  {
    get => (double) this._m;
    set
    {
      this._m = value >= 0.0 ? (value <= 1.0 ? (float) value : 1f) : 0.0f;
      this.CmykChanged();
    }
  }

  public double Y
  {
    get => (double) this._y;
    set
    {
      this._y = value >= 0.0 ? (value <= 1.0 ? (float) value : 1f) : 0.0f;
      this.CmykChanged();
    }
  }

  public double K
  {
    get => (double) this._k;
    set
    {
      this._k = value >= 0.0 ? (value <= 1.0 ? (float) value : 1f) : 0.0f;
      this.CmykChanged();
    }
  }

  public double GS
  {
    get => (double) this._gs;
    set
    {
      this._gs = value >= 0.0 ? (value <= 1.0 ? (float) value : 1f) : 0.0f;
      this.GrayChanged();
    }
  }

  public string RgbCmykG
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0};{1};{2};{3};{4};{5};{6};{7};{8}", (object) this._r, (object) this._g, (object) this._b, (object) this._c, (object) this._m, (object) this._y, (object) this._k, (object) this._gs, (object) this._a);
    }
    set
    {
      string[] strArray = value.Split(';');
      this._r = byte.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture);
      this._g = byte.Parse(strArray[1], (IFormatProvider) CultureInfo.InvariantCulture);
      this._b = byte.Parse(strArray[2], (IFormatProvider) CultureInfo.InvariantCulture);
      this._c = float.Parse(strArray[3], (IFormatProvider) CultureInfo.InvariantCulture);
      this._m = float.Parse(strArray[4], (IFormatProvider) CultureInfo.InvariantCulture);
      this._y = float.Parse(strArray[5], (IFormatProvider) CultureInfo.InvariantCulture);
      this._k = float.Parse(strArray[6], (IFormatProvider) CultureInfo.InvariantCulture);
      this._gs = float.Parse(strArray[7], (IFormatProvider) CultureInfo.InvariantCulture);
      this._a = float.Parse(strArray[8], (IFormatProvider) CultureInfo.InvariantCulture);
    }
  }

  private static void CheckByte(int val, string name)
  {
    if ((val < 0 ? 1 : (val > (int) byte.MaxValue ? 1 : 0)) != 0)
      throw new ArgumentException(PSSR.InvalidValue(val, name, 0, (int) byte.MaxValue));
  }
}
