// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XVector
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
public struct XVector(double x, double y) : IFormattable
{
  private double _x = x;
  private double _y = y;

  public static bool operator ==(XVector vector1, XVector vector2)
  {
    return vector1._x == vector2._x && vector1._y == vector2._y;
  }

  public static bool operator !=(XVector vector1, XVector vector2)
  {
    return vector1._x != vector2._x || vector1._y != vector2._y;
  }

  public static bool Equals(XVector vector1, XVector vector2)
  {
    return vector1.X.Equals(vector2.X) && vector1.Y.Equals(vector2.Y);
  }

  public override bool Equals(object o) => o is XVector vector2 && XVector.Equals(this, vector2);

  public bool Equals(XVector value) => XVector.Equals(this, value);

  public override int GetHashCode() => this._x.GetHashCode() ^ this._y.GetHashCode();

  public static XVector Parse(string source)
  {
    TokenizerHelper tokenizerHelper = new TokenizerHelper(source, (IFormatProvider) CultureInfo.InvariantCulture);
    XVector xvector = new XVector(Convert.ToDouble(tokenizerHelper.NextTokenRequired(), (IFormatProvider) CultureInfo.InvariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), (IFormatProvider) CultureInfo.InvariantCulture));
    tokenizerHelper.LastTokenRequired();
    return xvector;
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
    provider = provider ?? (IFormatProvider) CultureInfo.InvariantCulture;
    return string.Format(provider, $"{{1:{format}}}{{0}}{{2:{format}}}", (object) ',', (object) this._x, (object) this._y);
  }

  public double Length => Math.Sqrt(this._x * this._x + this._y * this._y);

  public double LengthSquared => this._x * this._x + this._y * this._y;

  public void Normalize()
  {
    this = this / Math.Max(Math.Abs(this._x), Math.Abs(this._y));
    this = this / this.Length;
  }

  public static double CrossProduct(XVector vector1, XVector vector2)
  {
    return vector1._x * vector2._y - vector1._y * vector2._x;
  }

  public static double AngleBetween(XVector vector1, XVector vector2)
  {
    return Math.Atan2(vector1._x * vector2._y - vector2._x * vector1._y, vector1._x * vector2._x + vector1._y * vector2._y) * (180.0 / Math.PI);
  }

  public static XVector operator -(XVector vector) => new XVector(-vector._x, -vector._y);

  public void Negate()
  {
    this._x = -this._x;
    this._y = -this._y;
  }

  public static XVector operator +(XVector vector1, XVector vector2)
  {
    return new XVector(vector1._x + vector2._x, vector1._y + vector2._y);
  }

  public static XVector Add(XVector vector1, XVector vector2)
  {
    return new XVector(vector1._x + vector2._x, vector1._y + vector2._y);
  }

  public static XVector operator -(XVector vector1, XVector vector2)
  {
    return new XVector(vector1._x - vector2._x, vector1._y - vector2._y);
  }

  public static XVector Subtract(XVector vector1, XVector vector2)
  {
    return new XVector(vector1._x - vector2._x, vector1._y - vector2._y);
  }

  public static XPoint operator +(XVector vector, XPoint point)
  {
    return new XPoint(point.X + vector._x, point.Y + vector._y);
  }

  public static XPoint Add(XVector vector, XPoint point)
  {
    return new XPoint(point.X + vector._x, point.Y + vector._y);
  }

  public static XVector operator *(XVector vector, double scalar)
  {
    return new XVector(vector._x * scalar, vector._y * scalar);
  }

  public static XVector Multiply(XVector vector, double scalar)
  {
    return new XVector(vector._x * scalar, vector._y * scalar);
  }

  public static XVector operator *(double scalar, XVector vector)
  {
    return new XVector(vector._x * scalar, vector._y * scalar);
  }

  public static XVector Multiply(double scalar, XVector vector)
  {
    return new XVector(vector._x * scalar, vector._y * scalar);
  }

  public static XVector operator /(XVector vector, double scalar) => vector * (1.0 / scalar);

  public static XVector Divide(XVector vector, double scalar) => vector * (1.0 / scalar);

  public static XVector operator *(XVector vector, XMatrix matrix) => matrix.Transform(vector);

  public static XVector Multiply(XVector vector, XMatrix matrix) => matrix.Transform(vector);

  public static double operator *(XVector vector1, XVector vector2)
  {
    return vector1._x * vector2._x + vector1._y * vector2._y;
  }

  public static double Multiply(XVector vector1, XVector vector2)
  {
    return vector1._x * vector2._x + vector1._y * vector2._y;
  }

  public static double Determinant(XVector vector1, XVector vector2)
  {
    return vector1._x * vector2._y - vector1._y * vector2._x;
  }

  public static explicit operator XSize(XVector vector)
  {
    return new XSize(Math.Abs(vector._x), Math.Abs(vector._y));
  }

  public static explicit operator XPoint(XVector vector) => new XPoint(vector._x, vector._y);

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "vector=({0:0.##########}, {1:0.##########})", (object) this._x, (object) this._y);
    }
  }
}
