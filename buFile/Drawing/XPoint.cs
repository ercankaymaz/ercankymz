// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XPoint
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Drawing;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
[Serializable]
public struct XPoint(double x, double y) : IFormattable
{
  private double _x = x;
  private double _y = y;

  public static bool operator ==(XPoint point1, XPoint point2)
  {
    return point1._x == point2._x && point1._y == point2._y;
  }

  public static bool operator !=(XPoint point1, XPoint point2) => !(point1 == point2);

  public static bool Equals(XPoint point1, XPoint point2)
  {
    return point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y);
  }

  public override bool Equals(object o) => o is XPoint point2 && XPoint.Equals(this, point2);

  public bool Equals(XPoint value) => XPoint.Equals(this, value);

  public override int GetHashCode()
  {
    double num = this.X;
    int hashCode1 = num.GetHashCode();
    num = this.Y;
    int hashCode2 = num.GetHashCode();
    return hashCode1 ^ hashCode2;
  }

  public static XPoint Parse(string source)
  {
    CultureInfo invariantCulture = CultureInfo.InvariantCulture;
    TokenizerHelper tokenizerHelper = new TokenizerHelper(source, (IFormatProvider) invariantCulture);
    XPoint xpoint = new XPoint(Convert.ToDouble(tokenizerHelper.NextTokenRequired(), (IFormatProvider) invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), (IFormatProvider) invariantCulture));
    tokenizerHelper.LastTokenRequired();
    return xpoint;
  }

  public static XPoint[] ParsePoints(string value)
  {
    string[] strArray = value != null ? value.Split(' ') : throw new ArgumentNullException(nameof (value));
    int length = strArray.Length;
    XPoint[] points = new XPoint[length];
    for (int index = 0; index < length; ++index)
      points[index] = XPoint.Parse(strArray[index]);
    return points;
  }

  public double X
  {
    get => this._x;
    set => this._x = value;
  }

  public double Y
  {
    get => this._y;
    set => this._y = value;
  }

  public override string ToString() => this.ConvertToString((string) null, (IFormatProvider) null);

  public string ToString(IFormatProvider provider) => this.ConvertToString((string) null, provider);

  string IFormattable.ToString(string format, IFormatProvider provider)
  {
    return this.ConvertToString(format, provider);
  }

  internal string ConvertToString(string format, IFormatProvider provider)
  {
    char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
    provider = provider ?? (IFormatProvider) CultureInfo.InvariantCulture;
    return string.Format(provider, $"{{1:{format}}}{{0}}{{2:{format}}}", new object[3]
    {
      (object) numericListSeparator,
      (object) this._x,
      (object) this._y
    });
  }

  public void Offset(double offsetX, double offsetY)
  {
    this._x += offsetX;
    this._y += offsetY;
  }

  public static XPoint operator +(XPoint point, XVector vector)
  {
    return new XPoint(point._x + vector.X, point._y + vector.Y);
  }

  public static XPoint operator +(XPoint point, XSize size)
  {
    return new XPoint(point._x + size.Width, point._y + size.Height);
  }

  public static XPoint Add(XPoint point, XVector vector)
  {
    return new XPoint(point._x + vector.X, point._y + vector.Y);
  }

  public static XPoint operator -(XPoint point, XVector vector)
  {
    return new XPoint(point._x - vector.X, point._y - vector.Y);
  }

  public static XPoint Subtract(XPoint point, XVector vector)
  {
    return new XPoint(point._x - vector.X, point._y - vector.Y);
  }

  public static XVector operator -(XPoint point1, XPoint point2)
  {
    return new XVector(point1._x - point2._x, point1._y - point2._y);
  }

  [Obsolete("Use XVector instead of XSize as second parameter.")]
  public static XPoint operator -(XPoint point, XSize size)
  {
    return new XPoint(point._x - size.Width, point._y - size.Height);
  }

  public static XVector Subtract(XPoint point1, XPoint point2)
  {
    return new XVector(point1._x - point2._x, point1._y - point2._y);
  }

  public static XPoint operator *(XPoint point, XMatrix matrix) => matrix.Transform(point);

  public static XPoint Multiply(XPoint point, XMatrix matrix) => matrix.Transform(point);

  public static XPoint operator *(XPoint point, double value)
  {
    return new XPoint(point._x * value, point._y * value);
  }

  public static XPoint operator *(double value, XPoint point)
  {
    return new XPoint(value * point._x, value * point._y);
  }

  public static explicit operator XSize(XPoint point)
  {
    return new XSize(Math.Abs(point._x), Math.Abs(point._y));
  }

  public static explicit operator XVector(XPoint point) => new XVector(point._x, point._y);

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "point=({0:0.##########}, {1:0.##########})", (object) this._x, (object) this._y);
    }
  }
}
