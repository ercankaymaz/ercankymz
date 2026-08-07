// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XRect
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
public struct XRect : IFormattable
{
  private double _x;
  private double _y;
  private double _width;
  private double _height;
  private static readonly XRect s_empty = XRect.CreateEmptyRect();

  public XRect(double x, double y, double width, double height)
  {
    if ((width < 0.0 ? 1 : (height < 0.0 ? 1 : 0)) != 0)
      throw new ArgumentException("WidthAndHeightCannotBeNegative");
    this._x = x;
    this._y = y;
    this._width = width;
    this._height = height;
  }

  public XRect(XPoint point1, XPoint point2)
  {
    this._x = Math.Min(point1.X, point2.X);
    this._y = Math.Min(point1.Y, point2.Y);
    this._width = Math.Max(Math.Max(point1.X, point2.X) - this._x, 0.0);
    this._height = Math.Max(Math.Max(point1.Y, point2.Y) - this._y, 0.0);
  }

  public XRect(XPoint point, XVector vector)
    : this(point, point + vector)
  {
  }

  public XRect(XPoint location, XSize size)
  {
    if (size.IsEmpty)
    {
      this = XRect.s_empty;
    }
    else
    {
      this._x = location.X;
      this._y = location.Y;
      this._width = size.Width;
      this._height = size.Height;
    }
  }

  public XRect(XSize size)
  {
    if (size.IsEmpty)
    {
      this = XRect.s_empty;
    }
    else
    {
      double num = 0.0;
      this._y = 0.0;
      this._x = num;
      this._width = size.Width;
      this._height = size.Height;
    }
  }

  public static XRect FromLTRB(double left, double top, double right, double bottom)
  {
    return new XRect(left, top, right - left, bottom - top);
  }

  public static bool operator ==(XRect rect1, XRect rect2)
  {
    return rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Width == rect2.Width && rect1.Height == rect2.Height;
  }

  public static bool operator !=(XRect rect1, XRect rect2) => !(rect1 == rect2);

  public static bool Equals(XRect rect1, XRect rect2)
  {
    return !rect1.IsEmpty ? rect1.X.Equals(rect2.X) && rect1.Y.Equals(rect2.Y) && rect1.Width.Equals(rect2.Width) && rect1.Height.Equals(rect2.Height) : rect2.IsEmpty;
  }

  public override bool Equals(object o) => o is XRect rect2 && XRect.Equals(this, rect2);

  public bool Equals(XRect value) => XRect.Equals(this, value);

  public override int GetHashCode()
  {
    int hashCode1;
    if (this.IsEmpty)
    {
      hashCode1 = 0;
    }
    else
    {
      int hashCode2 = this.X.GetHashCode();
      double num1 = this.Y;
      int hashCode3 = num1.GetHashCode();
      int num2 = hashCode2 ^ hashCode3;
      num1 = this.Width;
      int hashCode4 = num1.GetHashCode();
      int num3 = num2 ^ hashCode4;
      num1 = this.Height;
      int hashCode5 = num1.GetHashCode();
      hashCode1 = num3 ^ hashCode5;
    }
    return hashCode1;
  }

  public static XRect Parse(string source)
  {
    CultureInfo invariantCulture = CultureInfo.InvariantCulture;
    TokenizerHelper tokenizerHelper = new TokenizerHelper(source, (IFormatProvider) invariantCulture);
    string str = tokenizerHelper.NextTokenRequired();
    XRect xrect = !(str == "Empty") ? new XRect(Convert.ToDouble(str, (IFormatProvider) invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), (IFormatProvider) invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), (IFormatProvider) invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), (IFormatProvider) invariantCulture)) : XRect.Empty;
    tokenizerHelper.LastTokenRequired();
    return xrect;
  }

  public override string ToString() => this.ConvertToString((string) null, (IFormatProvider) null);

  public string ToString(IFormatProvider provider) => this.ConvertToString((string) null, provider);

  string IFormattable.ToString(string format, IFormatProvider provider)
  {
    return this.ConvertToString(format, provider);
  }

  internal string ConvertToString(string format, IFormatProvider provider)
  {
    string str;
    if (this.IsEmpty)
    {
      str = "Empty";
    }
    else
    {
      char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
      provider = provider ?? (IFormatProvider) CultureInfo.InvariantCulture;
      str = string.Format(provider, $"{{1:{format}}}{{0}}{{2:{format}}}{{0}}{{3:{format}}}{{0}}{{4:{format}}}", (object) numericListSeparator, (object) this._x, (object) this._y, (object) this._width, (object) this._height);
    }
    return str;
  }

  public static XRect Empty => XRect.s_empty;

  public bool IsEmpty => this._width < 0.0;

  public XPoint Location
  {
    get => new XPoint(this._x, this._y);
    set
    {
      if (this.IsEmpty)
        throw new InvalidOperationException("CannotModifyEmptyRect");
      this._x = value.X;
      this._y = value.Y;
    }
  }

  public XSize Size
  {
    get => !this.IsEmpty ? new XSize(this._width, this._height) : XSize.Empty;
    set
    {
      if (value.IsEmpty)
      {
        this = XRect.s_empty;
      }
      else
      {
        if (this.IsEmpty)
          throw new InvalidOperationException("CannotModifyEmptyRect");
        this._width = value.Width;
        this._height = value.Height;
      }
    }
  }

  public double X
  {
    get => this._x;
    set
    {
      if (this.IsEmpty)
        throw new InvalidOperationException("CannotModifyEmptyRect");
      this._x = value;
    }
  }

  public double Y
  {
    get => this._y;
    set
    {
      if (this.IsEmpty)
        throw new InvalidOperationException("CannotModifyEmptyRect");
      this._y = value;
    }
  }

  public double Width
  {
    get => this._width;
    set
    {
      if (this.IsEmpty)
        throw new InvalidOperationException("CannotModifyEmptyRect");
      this._width = value >= 0.0 ? value : throw new ArgumentException("WidthCannotBeNegative");
    }
  }

  public double Height
  {
    get => this._height;
    set
    {
      if (this.IsEmpty)
        throw new InvalidOperationException("CannotModifyEmptyRect");
      this._height = value >= 0.0 ? value : throw new ArgumentException("HeightCannotBeNegative");
    }
  }

  public double Left => this._x;

  public double Top => this._y;

  public double Right => !this.IsEmpty ? this._x + this._width : double.NegativeInfinity;

  public double Bottom => !this.IsEmpty ? this._y + this._height : double.NegativeInfinity;

  public XPoint TopLeft => new XPoint(this.Left, this.Top);

  public XPoint TopRight => new XPoint(this.Right, this.Top);

  public XPoint BottomLeft => new XPoint(this.Left, this.Bottom);

  public XPoint BottomRight => new XPoint(this.Right, this.Bottom);

  public XPoint Center => new XPoint(this._x + this._width / 2.0, this._y + this._height / 2.0);

  public bool Contains(XPoint point) => this.Contains(point.X, point.Y);

  public bool Contains(double x, double y) => !this.IsEmpty && this.ContainsInternal(x, y);

  public bool Contains(XRect rect)
  {
    return !this.IsEmpty && !rect.IsEmpty && this._x <= rect._x && this._y <= rect._y && this._x + this._width >= rect._x + rect._width && this._y + this._height >= rect._y + rect._height;
  }

  public bool IntersectsWith(XRect rect)
  {
    return !this.IsEmpty && !rect.IsEmpty && rect.Left <= this.Right && rect.Right >= this.Left && rect.Top <= this.Bottom && rect.Bottom >= this.Top;
  }

  public void Intersect(XRect rect)
  {
    if (!this.IntersectsWith(rect))
    {
      this = XRect.Empty;
    }
    else
    {
      double num1 = Math.Max(this.Left, rect.Left);
      double num2 = Math.Max(this.Top, rect.Top);
      this._width = Math.Max(Math.Min(this.Right, rect.Right) - num1, 0.0);
      this._height = Math.Max(Math.Min(this.Bottom, rect.Bottom) - num2, 0.0);
      this._x = num1;
      this._y = num2;
    }
  }

  public static XRect Intersect(XRect rect1, XRect rect2)
  {
    rect1.Intersect(rect2);
    return rect1;
  }

  public void Union(XRect rect)
  {
    if (this.IsEmpty)
    {
      this = rect;
    }
    else
    {
      if (rect.IsEmpty)
        return;
      double num1 = Math.Min(this.Left, rect.Left);
      double num2 = Math.Min(this.Top, rect.Top);
      this._width = (rect.Width == double.PositiveInfinity ? 1 : (this.Width == double.PositiveInfinity ? 1 : 0)) == 0 ? Math.Max(Math.Max(this.Right, rect.Right) - num1, 0.0) : double.PositiveInfinity;
      this._height = (rect.Height == double.PositiveInfinity ? 1 : (this._height == double.PositiveInfinity ? 1 : 0)) == 0 ? Math.Max(Math.Max(this.Bottom, rect.Bottom) - num2, 0.0) : double.PositiveInfinity;
      this._x = num1;
      this._y = num2;
    }
  }

  public static XRect Union(XRect rect1, XRect rect2)
  {
    rect1.Union(rect2);
    return rect1;
  }

  public void Union(XPoint point) => this.Union(new XRect(point, point));

  public static XRect Union(XRect rect, XPoint point)
  {
    rect.Union(new XRect(point, point));
    return rect;
  }

  public void Offset(XVector offsetVector)
  {
    if (this.IsEmpty)
      throw new InvalidOperationException("CannotCallMethod");
    this._x += offsetVector.X;
    this._y += offsetVector.Y;
  }

  public void Offset(double offsetX, double offsetY)
  {
    if (this.IsEmpty)
      throw new InvalidOperationException("CannotCallMethod");
    this._x += offsetX;
    this._y += offsetY;
  }

  public static XRect Offset(XRect rect, XVector offsetVector)
  {
    rect.Offset(offsetVector.X, offsetVector.Y);
    return rect;
  }

  public static XRect Offset(XRect rect, double offsetX, double offsetY)
  {
    rect.Offset(offsetX, offsetY);
    return rect;
  }

  public static XRect operator +(XRect rect, XPoint point)
  {
    return new XRect(rect._x + point.X, rect.Y + point.Y, rect._width, rect._height);
  }

  public static XRect operator -(XRect rect, XPoint point)
  {
    return new XRect(rect._x - point.X, rect.Y - point.Y, rect._width, rect._height);
  }

  public void Inflate(XSize size) => this.Inflate(size.Width, size.Height);

  public void Inflate(double width, double height)
  {
    if (this.IsEmpty)
      throw new InvalidOperationException("CannotCallMethod");
    this._x -= width;
    this._y -= height;
    this._width += width;
    this._width += width;
    this._height += height;
    this._height += height;
    if ((this._width < 0.0 ? 1 : (this._height < 0.0 ? 1 : 0)) == 0)
      return;
    this = XRect.s_empty;
  }

  public static XRect Inflate(XRect rect, XSize size)
  {
    rect.Inflate(size.Width, size.Height);
    return rect;
  }

  public static XRect Inflate(XRect rect, double width, double height)
  {
    rect.Inflate(width, height);
    return rect;
  }

  public static XRect Transform(XRect rect, XMatrix matrix)
  {
    XMatrix.MatrixHelper.TransformRect(ref rect, ref matrix);
    return rect;
  }

  public void Transform(XMatrix matrix) => XMatrix.MatrixHelper.TransformRect(ref this, ref matrix);

  public void Scale(double scaleX, double scaleY)
  {
    if (this.IsEmpty)
      return;
    this._x *= scaleX;
    this._y *= scaleY;
    this._width *= scaleX;
    this._height *= scaleY;
    if (scaleX < 0.0)
    {
      this._x += this._width;
      this._width *= -1.0;
    }
    if (scaleY >= 0.0)
      return;
    this._y += this._height;
    this._height *= -1.0;
  }

  private bool ContainsInternal(double x, double y)
  {
    return x >= this._x && x - this._width <= this._x && y >= this._y && y - this._height <= this._y;
  }

  private static XRect CreateEmptyRect()
  {
    return new XRect()
    {
      _x = double.PositiveInfinity,
      _y = double.PositiveInfinity,
      _width = double.NegativeInfinity,
      _height = double.NegativeInfinity
    };
  }

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "rect=({0:0.##########}, {1:0.##########}, {2:0.##########}, {3:0.##########})", (object) this._x, (object) this._y, (object) this._width, (object) this._height);
    }
  }
}
