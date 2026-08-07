// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XMatrix
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
public struct XMatrix : IFormattable
{
  private double _m11;
  private double _m12;
  private double _m21;
  private double _m22;
  private double _offsetX;
  private double _offsetY;
  private XMatrix.XMatrixTypes _type;
  private static readonly XMatrix s_identity = XMatrix.CreateIdentity();

  public XMatrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY)
  {
    this._m11 = m11;
    this._m12 = m12;
    this._m21 = m21;
    this._m22 = m22;
    this._offsetX = offsetX;
    this._offsetY = offsetY;
    this._type = XMatrix.XMatrixTypes.Unknown;
    this.DeriveMatrixType();
  }

  public static XMatrix Identity => XMatrix.s_identity;

  public void SetIdentity() => this._type = XMatrix.XMatrixTypes.Identity;

  public bool IsIdentity
  {
    get
    {
      bool isIdentity;
      if (this._type == XMatrix.XMatrixTypes.Identity)
        isIdentity = true;
      else if ((this._m11 != 1.0 || this._m12 != 0.0 || this._m21 != 0.0 || this._m22 != 1.0 || this._offsetX != 0.0 ? 0 : (this._offsetY == 0.0 ? 1 : 0)) != 0)
      {
        this._type = XMatrix.XMatrixTypes.Identity;
        isIdentity = true;
      }
      else
        isIdentity = false;
      return isIdentity;
    }
  }

  public double[] GetElements()
  {
    double[] elements;
    if (this._type == XMatrix.XMatrixTypes.Identity)
      elements = new double[6]
      {
        1.0,
        0.0,
        0.0,
        1.0,
        0.0,
        0.0
      };
    else
      elements = new double[6]
      {
        this._m11,
        this._m12,
        this._m21,
        this._m22,
        this._offsetX,
        this._offsetY
      };
    return elements;
  }

  public static XMatrix operator *(XMatrix trans1, XMatrix trans2)
  {
    XMatrix.MatrixHelper.MultiplyMatrix(ref trans1, ref trans2);
    return trans1;
  }

  public static XMatrix Multiply(XMatrix trans1, XMatrix trans2)
  {
    XMatrix.MatrixHelper.MultiplyMatrix(ref trans1, ref trans2);
    return trans1;
  }

  public void Append(XMatrix matrix) => this = this * matrix;

  public void Prepend(XMatrix matrix) => this = matrix * this;

  [Obsolete("Use Append.")]
  public void Multiply(XMatrix matrix) => this.Append(matrix);

  [Obsolete("Use Prepend.")]
  public void MultiplyPrepend(XMatrix matrix) => this.Prepend(matrix);

  public void Multiply(XMatrix matrix, XMatrixOrder order)
  {
    if (this._type == XMatrix.XMatrixTypes.Identity)
      this = XMatrix.CreateIdentity();
    double m11 = this.M11;
    double m12 = this.M12;
    double m21 = this.M21;
    double m22 = this.M22;
    double offsetX = this.OffsetX;
    double offsetY = this.OffsetY;
    if (order == XMatrixOrder.Append)
    {
      this._m11 = m11 * matrix.M11 + m12 * matrix.M21;
      this._m12 = m11 * matrix.M12 + m12 * matrix.M22;
      this._m21 = m21 * matrix.M11 + m22 * matrix.M21;
      this._m22 = m21 * matrix.M12 + m22 * matrix.M22;
      this._offsetX = offsetX * matrix.M11 + offsetY * matrix.M21 + matrix.OffsetX;
      this._offsetY = offsetX * matrix.M12 + offsetY * matrix.M22 + matrix.OffsetY;
    }
    else
    {
      this._m11 = m11 * matrix.M11 + m21 * matrix.M12;
      this._m12 = m12 * matrix.M11 + m22 * matrix.M12;
      this._m21 = m11 * matrix.M21 + m21 * matrix.M22;
      this._m22 = m12 * matrix.M21 + m22 * matrix.M22;
      this._offsetX = m11 * matrix.OffsetX + m21 * matrix.OffsetY + offsetX;
      this._offsetY = m12 * matrix.OffsetX + m22 * matrix.OffsetY + offsetY;
    }
    this.DeriveMatrixType();
  }

  [Obsolete("Use TranslateAppend or TranslatePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void Translate(double offsetX, double offsetY)
  {
    throw new InvalidOperationException("Temporarily out of order.");
  }

  public void TranslateAppend(double offsetX, double offsetY)
  {
    if (this._type == XMatrix.XMatrixTypes.Identity)
      this.SetMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY, XMatrix.XMatrixTypes.Translation);
    else if (this._type == XMatrix.XMatrixTypes.Unknown)
    {
      this._offsetX += offsetX;
      this._offsetY += offsetY;
    }
    else
    {
      this._offsetX += offsetX;
      this._offsetY += offsetY;
      this._type |= XMatrix.XMatrixTypes.Translation;
    }
  }

  public void TranslatePrepend(double offsetX, double offsetY)
  {
    this = XMatrix.CreateTranslation(offsetX, offsetY) * this;
  }

  public void Translate(double offsetX, double offsetY, XMatrixOrder order)
  {
    if (this._type == XMatrix.XMatrixTypes.Identity)
      this = XMatrix.CreateIdentity();
    if (order == XMatrixOrder.Append)
    {
      this._offsetX += offsetX;
      this._offsetY += offsetY;
    }
    else
    {
      this._offsetX += offsetX * this._m11 + offsetY * this._m21;
      this._offsetY += offsetX * this._m12 + offsetY * this._m22;
    }
    this.DeriveMatrixType();
  }

  [Obsolete("Use ScaleAppend or ScalePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void Scale(double scaleX, double scaleY)
  {
    this = XMatrix.CreateScaling(scaleX, scaleY) * this;
  }

  public void ScaleAppend(double scaleX, double scaleY)
  {
    this = this * XMatrix.CreateScaling(scaleX, scaleY);
  }

  public void ScalePrepend(double scaleX, double scaleY)
  {
    this = XMatrix.CreateScaling(scaleX, scaleY) * this;
  }

  public void Scale(double scaleX, double scaleY, XMatrixOrder order)
  {
    if (this._type == XMatrix.XMatrixTypes.Identity)
      this = XMatrix.CreateIdentity();
    if (order == XMatrixOrder.Append)
    {
      this._m11 *= scaleX;
      this._m12 *= scaleY;
      this._m21 *= scaleX;
      this._m22 *= scaleY;
      this._offsetX *= scaleX;
      this._offsetY *= scaleY;
    }
    else
    {
      this._m11 *= scaleX;
      this._m12 *= scaleX;
      this._m21 *= scaleY;
      this._m22 *= scaleY;
    }
    this.DeriveMatrixType();
  }

  [Obsolete("Use ScaleAppend or ScalePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void Scale(double scaleXY)
  {
    throw new InvalidOperationException("Temporarily out of order.");
  }

  public void ScaleAppend(double scaleXY) => this.Scale(scaleXY, scaleXY, XMatrixOrder.Append);

  public void ScalePrepend(double scaleXY) => this.Scale(scaleXY, scaleXY, XMatrixOrder.Prepend);

  public void Scale(double scaleXY, XMatrixOrder order) => this.Scale(scaleXY, scaleXY, order);

  [Obsolete("Use ScaleAtAppend or ScaleAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void ScaleAt(double scaleX, double scaleY, double centerX, double centerY)
  {
    throw new InvalidOperationException("Temporarily out of order.");
  }

  public void ScaleAtAppend(double scaleX, double scaleY, double centerX, double centerY)
  {
    this = this * XMatrix.CreateScaling(scaleX, scaleY, centerX, centerY);
  }

  public void ScaleAtPrepend(double scaleX, double scaleY, double centerX, double centerY)
  {
    this = XMatrix.CreateScaling(scaleX, scaleY, centerX, centerY) * this;
  }

  [Obsolete("Use RotateAppend or RotatePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void Rotate(double angle)
  {
    throw new InvalidOperationException("Temporarily out of order.");
  }

  public void RotateAppend(double angle)
  {
    angle %= 360.0;
    this = this * XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0));
  }

  public void RotatePrepend(double angle)
  {
    angle %= 360.0;
    this = XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0)) * this;
  }

  public void Rotate(double angle, XMatrixOrder order)
  {
    if (this._type == XMatrix.XMatrixTypes.Identity)
      this = XMatrix.CreateIdentity();
    angle *= Math.PI / 180.0;
    double num1 = Math.Cos(angle);
    double num2 = Math.Sin(angle);
    if (order == XMatrixOrder.Append)
    {
      double m11 = this._m11;
      double m12 = this._m12;
      double m21 = this._m21;
      double m22 = this._m22;
      double offsetX = this._offsetX;
      double offsetY = this._offsetY;
      this._m11 = m11 * num1 - m12 * num2;
      this._m12 = m11 * num2 + m12 * num1;
      this._m21 = m21 * num1 - m22 * num2;
      this._m22 = m21 * num2 + m22 * num1;
      this._offsetX = offsetX * num1 - offsetY * num2;
      this._offsetY = offsetX * num2 + offsetY * num1;
    }
    else
    {
      double m11 = this._m11;
      double m12 = this._m12;
      double m21 = this._m21;
      double m22 = this._m22;
      this._m11 = m11 * num1 + m21 * num2;
      this._m12 = m12 * num1 + m22 * num2;
      this._m21 = -m11 * num2 + m21 * num1;
      this._m22 = -m12 * num2 + m22 * num1;
    }
    this.DeriveMatrixType();
  }

  [Obsolete("Use RotateAtAppend or RotateAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void RotateAt(double angle, double centerX, double centerY)
  {
    throw new InvalidOperationException("Temporarily out of order.");
  }

  public void RotateAtAppend(double angle, double centerX, double centerY)
  {
    angle %= 360.0;
    this = this * XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0), centerX, centerY);
  }

  public void RotateAtPrepend(double angle, double centerX, double centerY)
  {
    angle %= 360.0;
    this = XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0), centerX, centerY) * this;
  }

  [Obsolete("Use RotateAtAppend or RotateAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void RotateAt(double angle, XPoint point)
  {
    throw new InvalidOperationException("Temporarily out of order.");
  }

  public void RotateAtAppend(double angle, XPoint point)
  {
    this.RotateAt(angle, point, XMatrixOrder.Append);
  }

  public void RotateAtPrepend(double angle, XPoint point)
  {
    this.RotateAt(angle, point, XMatrixOrder.Prepend);
  }

  public void RotateAt(double angle, XPoint point, XMatrixOrder order)
  {
    if (order == XMatrixOrder.Append)
    {
      angle %= 360.0;
      this = this * XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0), point.X, point.Y);
    }
    else
    {
      angle %= 360.0;
      this = XMatrix.CreateRotationRadians(angle * (Math.PI / 180.0), point.X, point.Y) * this;
    }
    this.DeriveMatrixType();
  }

  [Obsolete("Use ShearAppend or ShearPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void Shear(double shearX, double shearY)
  {
    throw new InvalidOperationException("Temporarily out of order.");
  }

  public void ShearAppend(double shearX, double shearY)
  {
    this.Shear(shearX, shearY, XMatrixOrder.Append);
  }

  public void ShearPrepend(double shearX, double shearY)
  {
    this.Shear(shearX, shearY, XMatrixOrder.Prepend);
  }

  public void Shear(double shearX, double shearY, XMatrixOrder order)
  {
    if (this._type == XMatrix.XMatrixTypes.Identity)
      this = XMatrix.CreateIdentity();
    double m11 = this._m11;
    double m12 = this._m12;
    double m21 = this._m21;
    double m22 = this._m22;
    double offsetX = this._offsetX;
    double offsetY = this._offsetY;
    if (order == XMatrixOrder.Append)
    {
      this._m11 += shearX * m12;
      this._m12 += shearY * m11;
      this._m21 += shearX * m22;
      this._m22 += shearY * m21;
      this._offsetX += shearX * offsetY;
      this._offsetY += shearY * offsetX;
    }
    else
    {
      this._m11 += shearY * m21;
      this._m12 += shearY * m22;
      this._m21 += shearX * m11;
      this._m22 += shearX * m12;
    }
    this.DeriveMatrixType();
  }

  [Obsolete("Use SkewAppend or SkewPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
  public void Skew(double skewX, double skewY)
  {
    throw new InvalidOperationException("Temporarily out of order.");
  }

  public void SkewAppend(double skewX, double skewY)
  {
    skewX %= 360.0;
    skewY %= 360.0;
    this = this * XMatrix.CreateSkewRadians(skewX * (Math.PI / 180.0), skewY * (Math.PI / 180.0));
  }

  public void SkewPrepend(double skewX, double skewY)
  {
    skewX %= 360.0;
    skewY %= 360.0;
    this = XMatrix.CreateSkewRadians(skewX * (Math.PI / 180.0), skewY * (Math.PI / 180.0)) * this;
  }

  public XPoint Transform(XPoint point)
  {
    double x = point.X;
    double y = point.Y;
    this.MultiplyPoint(ref x, ref y);
    return new XPoint(x, y);
  }

  public void Transform(XPoint[] points)
  {
    if (points == null)
      return;
    int length = points.Length;
    for (int index = 0; index < length; ++index)
    {
      double x = points[index].X;
      double y = points[index].Y;
      this.MultiplyPoint(ref x, ref y);
      points[index].X = x;
      points[index].Y = y;
    }
  }

  public void TransformPoints(XPoint[] points)
  {
    if (points == null)
      throw new ArgumentNullException(nameof (points));
    if (this.IsIdentity)
      return;
    int length = points.Length;
    for (int index = 0; index < length; ++index)
    {
      double x = points[index].X;
      double y = points[index].Y;
      points[index].X = x * this._m11 + y * this._m21 + this._offsetX;
      points[index].Y = x * this._m12 + y * this._m22 + this._offsetY;
    }
  }

  public XVector Transform(XVector vector)
  {
    double x = vector.X;
    double y = vector.Y;
    this.MultiplyVector(ref x, ref y);
    return new XVector(x, y);
  }

  public void Transform(XVector[] vectors)
  {
    if (vectors == null)
      return;
    int length = vectors.Length;
    for (int index = 0; index < length; ++index)
    {
      double x = vectors[index].X;
      double y = vectors[index].Y;
      this.MultiplyVector(ref x, ref y);
      vectors[index].X = x;
      vectors[index].Y = y;
    }
  }

  public double Determinant
  {
    get
    {
      double determinant;
      switch (this._type)
      {
        case XMatrix.XMatrixTypes.Identity:
        case XMatrix.XMatrixTypes.Translation:
          determinant = 1.0;
          break;
        case XMatrix.XMatrixTypes.Scaling:
        case XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling:
          determinant = this._m11 * this._m22;
          break;
        default:
          determinant = this._m11 * this._m22 - this._m12 * this._m21;
          break;
      }
      return determinant;
    }
  }

  public bool HasInverse => !DoubleUtil.IsZero(this.Determinant);

  public void Invert()
  {
    double determinant = this.Determinant;
    if (DoubleUtil.IsZero(determinant))
      throw new InvalidOperationException("NotInvertible");
    switch (this._type)
    {
      case XMatrix.XMatrixTypes.Identity:
        break;
      case XMatrix.XMatrixTypes.Translation:
        this._offsetX = -this._offsetX;
        this._offsetY = -this._offsetY;
        break;
      case XMatrix.XMatrixTypes.Scaling:
        this._m11 = 1.0 / this._m11;
        this._m22 = 1.0 / this._m22;
        break;
      case XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling:
        this._m11 = 1.0 / this._m11;
        this._m22 = 1.0 / this._m22;
        this._offsetX = -this._offsetX * this._m11;
        this._offsetY = -this._offsetY * this._m22;
        break;
      default:
        double num = 1.0 / determinant;
        this.SetMatrix(this._m22 * num, -this._m12 * num, -this._m21 * num, this._m11 * num, (this._m21 * this._offsetY - this._offsetX * this._m22) * num, (this._offsetX * this._m12 - this._m11 * this._offsetY) * num, XMatrix.XMatrixTypes.Unknown);
        break;
    }
  }

  public double M11
  {
    get => this._type != XMatrix.XMatrixTypes.Identity ? this._m11 : 1.0;
    set
    {
      if (this._type == XMatrix.XMatrixTypes.Identity)
      {
        this.SetMatrix(value, 0.0, 0.0, 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Scaling);
      }
      else
      {
        this._m11 = value;
        if (this._type == XMatrix.XMatrixTypes.Unknown)
          return;
        this._type |= XMatrix.XMatrixTypes.Scaling;
      }
    }
  }

  public double M12
  {
    get => this._type != XMatrix.XMatrixTypes.Identity ? this._m12 : 0.0;
    set
    {
      if (this._type == XMatrix.XMatrixTypes.Identity)
      {
        this.SetMatrix(1.0, value, 0.0, 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Unknown);
      }
      else
      {
        this._m12 = value;
        this._type = XMatrix.XMatrixTypes.Unknown;
      }
    }
  }

  public double M21
  {
    get => this._type != XMatrix.XMatrixTypes.Identity ? this._m21 : 0.0;
    set
    {
      if (this._type == XMatrix.XMatrixTypes.Identity)
      {
        this.SetMatrix(1.0, 0.0, value, 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Unknown);
      }
      else
      {
        this._m21 = value;
        this._type = XMatrix.XMatrixTypes.Unknown;
      }
    }
  }

  public double M22
  {
    get => this._type != XMatrix.XMatrixTypes.Identity ? this._m22 : 1.0;
    set
    {
      if (this._type == XMatrix.XMatrixTypes.Identity)
      {
        this.SetMatrix(1.0, 0.0, 0.0, value, 0.0, 0.0, XMatrix.XMatrixTypes.Scaling);
      }
      else
      {
        this._m22 = value;
        if (this._type == XMatrix.XMatrixTypes.Unknown)
          return;
        this._type |= XMatrix.XMatrixTypes.Scaling;
      }
    }
  }

  public double OffsetX
  {
    get => this._type != XMatrix.XMatrixTypes.Identity ? this._offsetX : 0.0;
    set
    {
      if (this._type == XMatrix.XMatrixTypes.Identity)
      {
        this.SetMatrix(1.0, 0.0, 0.0, 1.0, value, 0.0, XMatrix.XMatrixTypes.Translation);
      }
      else
      {
        this._offsetX = value;
        if (this._type == XMatrix.XMatrixTypes.Unknown)
          return;
        this._type |= XMatrix.XMatrixTypes.Translation;
      }
    }
  }

  public double OffsetY
  {
    get => this._type != XMatrix.XMatrixTypes.Identity ? this._offsetY : 0.0;
    set
    {
      if (this._type == XMatrix.XMatrixTypes.Identity)
      {
        this.SetMatrix(1.0, 0.0, 0.0, 1.0, 0.0, value, XMatrix.XMatrixTypes.Translation);
      }
      else
      {
        this._offsetY = value;
        if (this._type == XMatrix.XMatrixTypes.Unknown)
          return;
        this._type |= XMatrix.XMatrixTypes.Translation;
      }
    }
  }

  public static bool operator ==(XMatrix matrix1, XMatrix matrix2)
  {
    return (matrix1.IsDistinguishedIdentity ? 1 : (matrix2.IsDistinguishedIdentity ? 1 : 0)) == 0 ? matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.OffsetX == matrix2.OffsetX && matrix1.OffsetY == matrix2.OffsetY : matrix1.IsIdentity == matrix2.IsIdentity;
  }

  public static bool operator !=(XMatrix matrix1, XMatrix matrix2) => !(matrix1 == matrix2);

  public static bool Equals(XMatrix matrix1, XMatrix matrix2)
  {
    bool flag;
    if ((matrix1.IsDistinguishedIdentity ? 1 : (matrix2.IsDistinguishedIdentity ? 1 : 0)) != 0)
    {
      flag = matrix1.IsIdentity == matrix2.IsIdentity;
    }
    else
    {
      double num1 = matrix1.M11;
      int num2;
      if (num1.Equals(matrix2.M11))
      {
        num1 = matrix1.M12;
        if (num1.Equals(matrix2.M12))
        {
          num1 = matrix1.M21;
          if (num1.Equals(matrix2.M21))
          {
            num1 = matrix1.M22;
            if (num1.Equals(matrix2.M22))
            {
              num1 = matrix1.OffsetX;
              if (num1.Equals(matrix2.OffsetX))
              {
                num1 = matrix1.OffsetY;
                num2 = num1.Equals(matrix2.OffsetY) ? 1 : 0;
                goto label_9;
              }
            }
          }
        }
      }
      num2 = 0;
label_9:
      flag = num2 != 0;
    }
    return flag;
  }

  public override bool Equals(object o) => o is XMatrix matrix2 && XMatrix.Equals(this, matrix2);

  public bool Equals(XMatrix value) => XMatrix.Equals(this, value);

  public override int GetHashCode()
  {
    int hashCode1;
    if (this.IsDistinguishedIdentity)
    {
      hashCode1 = 0;
    }
    else
    {
      int hashCode2 = this.M11.GetHashCode();
      double num1 = this.M12;
      int hashCode3 = num1.GetHashCode();
      int num2 = hashCode2 ^ hashCode3;
      num1 = this.M21;
      int hashCode4 = num1.GetHashCode();
      int num3 = num2 ^ hashCode4;
      num1 = this.M22;
      int hashCode5 = num1.GetHashCode();
      int num4 = num3 ^ hashCode5;
      num1 = this.OffsetX;
      int hashCode6 = num1.GetHashCode();
      int num5 = num4 ^ hashCode6;
      num1 = this.OffsetY;
      int hashCode7 = num1.GetHashCode();
      hashCode1 = num5 ^ hashCode7;
    }
    return hashCode1;
  }

  public static XMatrix Parse(string source)
  {
    IFormatProvider invariantCulture = (IFormatProvider) CultureInfo.InvariantCulture;
    TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantCulture);
    string str = tokenizerHelper.NextTokenRequired();
    XMatrix xmatrix = str == "Identity" ? XMatrix.Identity : new XMatrix(Convert.ToDouble(str, invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture));
    tokenizerHelper.LastTokenRequired();
    return xmatrix;
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
    if (this.IsIdentity)
    {
      str = "Identity";
    }
    else
    {
      char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
      provider = provider ?? (IFormatProvider) CultureInfo.InvariantCulture;
      str = string.Format(provider, $"{{1:{format}}}{{0}}{{2:{format}}}{{0}}{{3:{format}}}{{0}}{{4:{format}}}{{0}}{{5:{format}}}{{0}}{{6:{format}}}", (object) numericListSeparator, (object) this._m11, (object) this._m12, (object) this._m21, (object) this._m22, (object) this._offsetX, (object) this._offsetY);
    }
    return str;
  }

  internal void MultiplyVector(ref double x, ref double y)
  {
    switch (this._type)
    {
      case XMatrix.XMatrixTypes.Identity:
      case XMatrix.XMatrixTypes.Translation:
        break;
      case XMatrix.XMatrixTypes.Scaling:
      case XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling:
        x *= this._m11;
        y *= this._m22;
        break;
      default:
        double num1 = y * this._m21;
        double num2 = x * this._m12;
        x *= this._m11;
        x += num1;
        y *= this._m22;
        y += num2;
        break;
    }
  }

  internal void MultiplyPoint(ref double x, ref double y)
  {
    switch (this._type)
    {
      case XMatrix.XMatrixTypes.Identity:
        break;
      case XMatrix.XMatrixTypes.Translation:
        x += this._offsetX;
        y += this._offsetY;
        break;
      case XMatrix.XMatrixTypes.Scaling:
        x *= this._m11;
        y *= this._m22;
        break;
      case XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling:
        x *= this._m11;
        x += this._offsetX;
        y *= this._m22;
        y += this._offsetY;
        break;
      default:
        double num1 = y * this._m21 + this._offsetX;
        double num2 = x * this._m12 + this._offsetY;
        x *= this._m11;
        x += num1;
        y *= this._m22;
        y += num2;
        break;
    }
  }

  internal static XMatrix CreateTranslation(double offsetX, double offsetY)
  {
    XMatrix translation = new XMatrix();
    translation.SetMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY, XMatrix.XMatrixTypes.Translation);
    return translation;
  }

  internal static XMatrix CreateRotationRadians(double angle)
  {
    return XMatrix.CreateRotationRadians(angle, 0.0, 0.0);
  }

  internal static XMatrix CreateRotationRadians(double angle, double centerX, double centerY)
  {
    XMatrix rotationRadians = new XMatrix();
    double m12 = Math.Sin(angle);
    double num = Math.Cos(angle);
    double offsetX = centerX * (1.0 - num) + centerY * m12;
    double offsetY = centerY * (1.0 - num) - centerX * m12;
    rotationRadians.SetMatrix(num, m12, -m12, num, offsetX, offsetY, XMatrix.XMatrixTypes.Unknown);
    return rotationRadians;
  }

  internal static XMatrix CreateScaling(double scaleX, double scaleY)
  {
    XMatrix scaling = new XMatrix();
    scaling.SetMatrix(scaleX, 0.0, 0.0, scaleY, 0.0, 0.0, XMatrix.XMatrixTypes.Scaling);
    return scaling;
  }

  internal static XMatrix CreateScaling(
    double scaleX,
    double scaleY,
    double centerX,
    double centerY)
  {
    XMatrix scaling = new XMatrix();
    scaling.SetMatrix(scaleX, 0.0, 0.0, scaleY, centerX - scaleX * centerX, centerY - scaleY * centerY, XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling);
    return scaling;
  }

  internal static XMatrix CreateSkewRadians(
    double skewX,
    double skewY,
    double centerX,
    double centerY)
  {
    XMatrix skewRadians = new XMatrix();
    skewRadians.Append(XMatrix.CreateTranslation(-centerX, -centerY));
    skewRadians.Append(new XMatrix(1.0, Math.Tan(skewY), Math.Tan(skewX), 1.0, 0.0, 0.0));
    skewRadians.Append(XMatrix.CreateTranslation(centerX, centerY));
    return skewRadians;
  }

  internal static XMatrix CreateSkewRadians(double skewX, double skewY)
  {
    XMatrix skewRadians = new XMatrix();
    skewRadians.SetMatrix(1.0, Math.Tan(skewY), Math.Tan(skewX), 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Unknown);
    return skewRadians;
  }

  private static XMatrix CreateIdentity()
  {
    XMatrix identity = new XMatrix();
    identity.SetMatrix(1.0, 0.0, 0.0, 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Identity);
    return identity;
  }

  private void SetMatrix(
    double m11,
    double m12,
    double m21,
    double m22,
    double offsetX,
    double offsetY,
    XMatrix.XMatrixTypes type)
  {
    this._m11 = m11;
    this._m12 = m12;
    this._m21 = m21;
    this._m22 = m22;
    this._offsetX = offsetX;
    this._offsetY = offsetY;
    this._type = type;
  }

  private void DeriveMatrixType()
  {
    this._type = XMatrix.XMatrixTypes.Identity;
    if ((this._m12 != 0.0 ? 1 : (this._m21 != 0.0 ? 1 : 0)) != 0)
    {
      this._type = XMatrix.XMatrixTypes.Unknown;
    }
    else
    {
      if ((this._m11 != 1.0 ? 1 : (this._m22 != 1.0 ? 1 : 0)) != 0)
        this._type = XMatrix.XMatrixTypes.Scaling;
      if ((this._offsetX != 0.0 ? 1 : (this._offsetY != 0.0 ? 1 : 0)) != 0)
        this._type |= XMatrix.XMatrixTypes.Translation;
      if ((this._type & (XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling)) != XMatrix.XMatrixTypes.Identity)
        return;
      this._type = XMatrix.XMatrixTypes.Identity;
    }
  }

  private bool IsDistinguishedIdentity => this._type == XMatrix.XMatrixTypes.Identity;

  private string DebuggerDisplay
  {
    get
    {
      string debuggerDisplay;
      if (this.IsIdentity)
      {
        debuggerDisplay = "matrix=(Identity)";
      }
      else
      {
        XPoint xpoint = new XMatrix(this._m11, this._m12, this._m21, this._m22, 0.0, 0.0).Transform(new XPoint(1.0, 0.0));
        debuggerDisplay = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "matrix=({0:0.#######}, {1:0.#######}, {2:0.#######}, {3:0.#######}, {4:0.#######}, {5:0.#######}), φ={6:0.0#########}°", (object) this._m11, (object) this._m12, (object) this._m21, (object) this._m22, (object) this._offsetX, (object) this._offsetY, (object) (Math.Atan2(xpoint.Y, xpoint.X) / (Math.PI / 180.0)));
      }
      return debuggerDisplay;
    }
  }

  [Flags]
  internal enum XMatrixTypes
  {
    Identity = 0,
    Translation = 1,
    Scaling = 2,
    Unknown = 4,
  }

  internal static class MatrixHelper
  {
    internal static void MultiplyMatrix(ref XMatrix matrix1, ref XMatrix matrix2)
    {
      XMatrix.XMatrixTypes type1 = matrix1._type;
      XMatrix.XMatrixTypes type2 = matrix2._type;
      if (type2 == 0)
        return;
      if (type1 == XMatrix.XMatrixTypes.Identity)
        matrix1 = matrix2;
      else if (type2 == XMatrix.XMatrixTypes.Translation)
      {
        matrix1._offsetX += matrix2._offsetX;
        matrix1._offsetY += matrix2._offsetY;
        if (type1 == XMatrix.XMatrixTypes.Unknown)
          return;
        matrix1._type |= XMatrix.XMatrixTypes.Translation;
      }
      else if (type1 == XMatrix.XMatrixTypes.Translation)
      {
        double offsetX = matrix1._offsetX;
        double offsetY = matrix1._offsetY;
        matrix1 = matrix2;
        matrix1._offsetX = offsetX * matrix2._m11 + offsetY * matrix2._m21 + matrix2._offsetX;
        matrix1._offsetY = offsetX * matrix2._m12 + offsetY * matrix2._m22 + matrix2._offsetY;
        if (type2 == XMatrix.XMatrixTypes.Unknown)
          matrix1._type = XMatrix.XMatrixTypes.Unknown;
        else
          matrix1._type = XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling;
      }
      else
      {
        switch ((XMatrix.XMatrixTypes) ((int) type1 << 4) | type2)
        {
          case (XMatrix.XMatrixTypes) 34:
            matrix1._m11 *= matrix2._m11;
            matrix1._m22 *= matrix2._m22;
            break;
          case (XMatrix.XMatrixTypes) 35:
            matrix1._m11 *= matrix2._m11;
            matrix1._m22 *= matrix2._m22;
            matrix1._offsetX = matrix2._offsetX;
            matrix1._offsetY = matrix2._offsetY;
            matrix1._type = XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling;
            break;
          case (XMatrix.XMatrixTypes) 36:
          case (XMatrix.XMatrixTypes) 52:
          case (XMatrix.XMatrixTypes) 66:
          case (XMatrix.XMatrixTypes) 67:
          case (XMatrix.XMatrixTypes) 68:
            matrix1 = new XMatrix(matrix1._m11 * matrix2._m11 + matrix1._m12 * matrix2._m21, matrix1._m11 * matrix2._m12 + matrix1._m12 * matrix2._m22, matrix1._m21 * matrix2._m11 + matrix1._m22 * matrix2._m21, matrix1._m21 * matrix2._m12 + matrix1._m22 * matrix2._m22, matrix1._offsetX * matrix2._m11 + matrix1._offsetY * matrix2._m21 + matrix2._offsetX, matrix1._offsetX * matrix2._m12 + matrix1._offsetY * matrix2._m22 + matrix2._offsetY);
            break;
          case (XMatrix.XMatrixTypes) 50:
            matrix1._m11 *= matrix2._m11;
            matrix1._m22 *= matrix2._m22;
            matrix1._offsetX *= matrix2._m11;
            matrix1._offsetY *= matrix2._m22;
            break;
          case (XMatrix.XMatrixTypes) 51:
            matrix1._m11 *= matrix2._m11;
            matrix1._m22 *= matrix2._m22;
            matrix1._offsetX = matrix2._m11 * matrix1._offsetX + matrix2._offsetX;
            matrix1._offsetY = matrix2._m22 * matrix1._offsetY + matrix2._offsetY;
            break;
        }
      }
    }

    internal static void PrependOffset(ref XMatrix matrix, double offsetX, double offsetY)
    {
      if (matrix._type == XMatrix.XMatrixTypes.Identity)
      {
        matrix = new XMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY);
        matrix._type = XMatrix.XMatrixTypes.Translation;
      }
      else
      {
        matrix._offsetX += matrix._m11 * offsetX + matrix._m21 * offsetY;
        matrix._offsetY += matrix._m12 * offsetX + matrix._m22 * offsetY;
        if (matrix._type == XMatrix.XMatrixTypes.Unknown)
          return;
        matrix._type |= XMatrix.XMatrixTypes.Translation;
      }
    }

    internal static void TransformRect(ref XRect rect, ref XMatrix matrix)
    {
      if (rect.IsEmpty)
        return;
      XMatrix.XMatrixTypes type = matrix._type;
      if (type == 0)
        return;
      if ((type & XMatrix.XMatrixTypes.Scaling) != 0)
      {
        rect.X *= matrix._m11;
        rect.Y *= matrix._m22;
        rect.Width *= matrix._m11;
        rect.Height *= matrix._m22;
        if (rect.Width < 0.0)
        {
          rect.X += rect.Width;
          rect.Width = -rect.Width;
        }
        if (rect.Height < 0.0)
        {
          rect.Y += rect.Height;
          rect.Height = -rect.Height;
        }
      }
      if ((type & XMatrix.XMatrixTypes.Translation) != 0)
      {
        rect.X += matrix._offsetX;
        rect.Y += matrix._offsetY;
      }
      if (type != XMatrix.XMatrixTypes.Unknown)
        return;
      XPoint xpoint1 = matrix.Transform(rect.TopLeft);
      XPoint xpoint2 = matrix.Transform(rect.TopRight);
      XPoint xpoint3 = matrix.Transform(rect.BottomRight);
      XPoint xpoint4 = matrix.Transform(rect.BottomLeft);
      rect.X = Math.Min(Math.Min(xpoint1.X, xpoint2.X), Math.Min(xpoint3.X, xpoint4.X));
      rect.Y = Math.Min(Math.Min(xpoint1.Y, xpoint2.Y), Math.Min(xpoint3.Y, xpoint4.Y));
      rect.Width = Math.Max(Math.Max(xpoint1.X, xpoint2.X), Math.Max(xpoint3.X, xpoint4.X)) - rect.X;
      rect.Height = Math.Max(Math.Max(xpoint1.Y, xpoint2.Y), Math.Max(xpoint3.Y, xpoint4.Y)) - rect.Y;
    }
  }
}
