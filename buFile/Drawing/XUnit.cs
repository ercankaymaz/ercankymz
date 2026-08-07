// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XUnit
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.ComponentModel;
using System.Globalization;

#nullable disable
namespace PdfSharp.Drawing;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
public struct XUnit : IFormattable
{
  internal const double PointFactor = 1.0;
  internal const double InchFactor = 72.0;
  internal const double MillimeterFactor = 2.8346456692913389;
  internal const double CentimeterFactor = 28.346456692913385;
  internal const double PresentationFactor = 0.75;
  internal const double PointFactorWpf = 1.3333333333333333;
  internal const double InchFactorWpf = 96.0;
  internal const double MillimeterFactorWpf = 3.7795275590551185;
  internal const double CentimeterFactorWpf = 37.795275590551178;
  internal const double PresentationFactorWpf = 1.0;
  public static readonly XUnit Zero = new XUnit();
  private double _value;
  private XGraphicsUnit _type;

  public XUnit(double point)
  {
    this._value = point;
    this._type = XGraphicsUnit.Point;
  }

  public XUnit(double value, XGraphicsUnit type)
  {
    if (!Enum.IsDefined(typeof (XGraphicsUnit), (object) type))
      throw new InvalidEnumArgumentException(nameof (type), (int) type, typeof (XGraphicsUnit));
    this._value = value;
    this._type = type;
  }

  public double Value => this._value;

  public XGraphicsUnit Type => this._type;

  public double Point
  {
    get
    {
      double point;
      switch (this._type)
      {
        case XGraphicsUnit.Point:
          point = this._value;
          break;
        case XGraphicsUnit.Inch:
          point = this._value * 72.0;
          break;
        case XGraphicsUnit.Millimeter:
          point = this._value * 72.0 / 25.4;
          break;
        case XGraphicsUnit.Centimeter:
          point = this._value * 72.0 / 2.54;
          break;
        case XGraphicsUnit.Presentation:
          point = this._value * 72.0 / 96.0;
          break;
        default:
          throw new InvalidCastException();
      }
      return point;
    }
    set
    {
      this._value = value;
      this._type = XGraphicsUnit.Point;
    }
  }

  public double Inch
  {
    get
    {
      double inch;
      switch (this._type)
      {
        case XGraphicsUnit.Point:
          inch = this._value / 72.0;
          break;
        case XGraphicsUnit.Inch:
          inch = this._value;
          break;
        case XGraphicsUnit.Millimeter:
          inch = this._value / 25.4;
          break;
        case XGraphicsUnit.Centimeter:
          inch = this._value / 2.54;
          break;
        case XGraphicsUnit.Presentation:
          inch = this._value / 96.0;
          break;
        default:
          throw new InvalidCastException();
      }
      return inch;
    }
    set
    {
      this._value = value;
      this._type = XGraphicsUnit.Inch;
    }
  }

  public double Millimeter
  {
    get
    {
      double millimeter;
      switch (this._type)
      {
        case XGraphicsUnit.Point:
          millimeter = this._value * 25.4 / 72.0;
          break;
        case XGraphicsUnit.Inch:
          millimeter = this._value * 25.4;
          break;
        case XGraphicsUnit.Millimeter:
          millimeter = this._value;
          break;
        case XGraphicsUnit.Centimeter:
          millimeter = this._value * 10.0;
          break;
        case XGraphicsUnit.Presentation:
          millimeter = this._value * 25.4 / 96.0;
          break;
        default:
          throw new InvalidCastException();
      }
      return millimeter;
    }
    set
    {
      this._value = value;
      this._type = XGraphicsUnit.Millimeter;
    }
  }

  public double Centimeter
  {
    get
    {
      double centimeter;
      switch (this._type)
      {
        case XGraphicsUnit.Point:
          centimeter = this._value * 2.54 / 72.0;
          break;
        case XGraphicsUnit.Inch:
          centimeter = this._value * 2.54;
          break;
        case XGraphicsUnit.Millimeter:
          centimeter = this._value / 10.0;
          break;
        case XGraphicsUnit.Centimeter:
          centimeter = this._value;
          break;
        case XGraphicsUnit.Presentation:
          centimeter = this._value * 2.54 / 96.0;
          break;
        default:
          throw new InvalidCastException();
      }
      return centimeter;
    }
    set
    {
      this._value = value;
      this._type = XGraphicsUnit.Centimeter;
    }
  }

  public double Presentation
  {
    get
    {
      double presentation;
      switch (this._type)
      {
        case XGraphicsUnit.Point:
          presentation = this._value * 96.0 / 72.0;
          break;
        case XGraphicsUnit.Inch:
          presentation = this._value * 96.0;
          break;
        case XGraphicsUnit.Millimeter:
          presentation = this._value * 96.0 / 25.4;
          break;
        case XGraphicsUnit.Centimeter:
          presentation = this._value * 96.0 / 2.54;
          break;
        case XGraphicsUnit.Presentation:
          presentation = this._value;
          break;
        default:
          throw new InvalidCastException();
      }
      return presentation;
    }
    set
    {
      this._value = value;
      this._type = XGraphicsUnit.Point;
    }
  }

  public string ToString(IFormatProvider formatProvider)
  {
    return this._value.ToString(formatProvider) + this.GetSuffix();
  }

  string IFormattable.ToString(string format, IFormatProvider formatProvider)
  {
    return this._value.ToString(format, formatProvider) + this.GetSuffix();
  }

  public override string ToString()
  {
    return this._value.ToString((IFormatProvider) CultureInfo.InvariantCulture) + this.GetSuffix();
  }

  private string GetSuffix()
  {
    string suffix;
    switch (this._type)
    {
      case XGraphicsUnit.Point:
        suffix = "pt";
        break;
      case XGraphicsUnit.Inch:
        suffix = "in";
        break;
      case XGraphicsUnit.Millimeter:
        suffix = "mm";
        break;
      case XGraphicsUnit.Centimeter:
        suffix = "cm";
        break;
      case XGraphicsUnit.Presentation:
        suffix = "pu";
        break;
      default:
        throw new InvalidCastException();
    }
    return suffix;
  }

  public static XUnit FromPoint(double value)
  {
    XUnit xunit;
    xunit._value = value;
    xunit._type = XGraphicsUnit.Point;
    return xunit;
  }

  public static XUnit FromInch(double value)
  {
    XUnit xunit;
    xunit._value = value;
    xunit._type = XGraphicsUnit.Inch;
    return xunit;
  }

  public static XUnit FromMillimeter(double value)
  {
    XUnit xunit;
    xunit._value = value;
    xunit._type = XGraphicsUnit.Millimeter;
    return xunit;
  }

  public static XUnit FromCentimeter(double value)
  {
    XUnit xunit;
    xunit._value = value;
    xunit._type = XGraphicsUnit.Centimeter;
    return xunit;
  }

  public static XUnit FromPresentation(double value)
  {
    XUnit xunit;
    xunit._value = value;
    xunit._type = XGraphicsUnit.Presentation;
    return xunit;
  }

  public static implicit operator XUnit(string value)
  {
    value = value.Trim();
    value = value.Replace(',', '.');
    int length = value.Length;
    int num1;
    for (num1 = 0; num1 < length; ++num1)
    {
      char c = value[num1];
      int num2;
      switch (c)
      {
        case '+':
        case '-':
        case '.':
          num2 = 1;
          break;
        default:
          num2 = char.IsNumber(c) ? 1 : 0;
          break;
      }
      if (num2 == 0)
        break;
    }
    XUnit xunit;
    try
    {
      xunit._value = double.Parse(value.Substring(0, num1).Trim(), (IFormatProvider) CultureInfo.InvariantCulture);
    }
    catch (Exception ex)
    {
      xunit._value = 1.0;
      throw new ArgumentException($"String '{value}' is not a valid value for structure 'XUnit'.", ex);
    }
    string lower = value.Substring(num1).Trim().ToLower();
    xunit._type = XGraphicsUnit.Point;
    switch (lower)
    {
      case "cm":
        xunit._type = XGraphicsUnit.Centimeter;
        break;
      case "in":
        xunit._type = XGraphicsUnit.Inch;
        break;
      case "mm":
        xunit._type = XGraphicsUnit.Millimeter;
        break;
      case "":
      case "pt":
        xunit._type = XGraphicsUnit.Point;
        break;
      case "pu":
        xunit._type = XGraphicsUnit.Presentation;
        break;
      default:
        throw new ArgumentException($"Unknown unit type: '{lower}'");
    }
    return xunit;
  }

  public static implicit operator XUnit(int value)
  {
    XUnit xunit;
    xunit._value = (double) value;
    xunit._type = XGraphicsUnit.Point;
    return xunit;
  }

  public static implicit operator XUnit(double value)
  {
    XUnit xunit;
    xunit._value = value;
    xunit._type = XGraphicsUnit.Point;
    return xunit;
  }

  public static implicit operator double(XUnit value) => value.Point;

  public static bool operator ==(XUnit value1, XUnit value2)
  {
    return value1._type == value2._type && value1._value == value2._value;
  }

  public static bool operator !=(XUnit value1, XUnit value2) => !(value1 == value2);

  public override bool Equals(object obj) => obj is XUnit xunit && this == xunit;

  public override int GetHashCode() => this._value.GetHashCode() ^ this._type.GetHashCode();

  public static XUnit Parse(string value) => (XUnit) value;

  public void ConvertType(XGraphicsUnit type)
  {
    if (this._type == type)
      return;
    switch (type)
    {
      case XGraphicsUnit.Point:
        this._value = this.Point;
        this._type = XGraphicsUnit.Point;
        break;
      case XGraphicsUnit.Inch:
        this._value = this.Inch;
        this._type = XGraphicsUnit.Inch;
        break;
      case XGraphicsUnit.Millimeter:
        this._value = this.Millimeter;
        this._type = XGraphicsUnit.Millimeter;
        break;
      case XGraphicsUnit.Centimeter:
        this._value = this.Centimeter;
        this._type = XGraphicsUnit.Centimeter;
        break;
      case XGraphicsUnit.Presentation:
        this._value = this.Presentation;
        this._type = XGraphicsUnit.Presentation;
        break;
      default:
        throw new ArgumentException($"Unknown unit type: '{type.ToString()}'");
    }
  }

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "unit=({0:0.##########} {1})", (object) this._value, (object) this.GetSuffix());
    }
  }
}
