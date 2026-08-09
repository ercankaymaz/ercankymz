using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

[Serializable]
[DebuggerDisplay("{DebuggerDisplay}")]
public struct XMatrix : IFormattable
{
	[Flags]
	internal enum XMatrixTypes
	{
		Identity = 0,
		Translation = 1,
		Scaling = 2,
		Unknown = 4
	}

	internal static class MatrixHelper
	{
		internal static void MultiplyMatrix(ref XMatrix matrix1, ref XMatrix matrix2)
		{
			XMatrixTypes type = matrix1._type;
			XMatrixTypes type2 = matrix2._type;
			if (type2 == XMatrixTypes.Identity)
			{
				return;
			}
			if (type == XMatrixTypes.Identity)
			{
				matrix1 = matrix2;
				return;
			}
			if (type2 == XMatrixTypes.Translation)
			{
				matrix1._offsetX += matrix2._offsetX;
				matrix1._offsetY += matrix2._offsetY;
				if (type != XMatrixTypes.Unknown)
				{
					matrix1._type |= XMatrixTypes.Translation;
				}
				return;
			}
			if (type == XMatrixTypes.Translation)
			{
				double offsetX = matrix1._offsetX;
				double offsetY = matrix1._offsetY;
				matrix1 = matrix2;
				matrix1._offsetX = offsetX * matrix2._m11 + offsetY * matrix2._m21 + matrix2._offsetX;
				matrix1._offsetY = offsetX * matrix2._m12 + offsetY * matrix2._m22 + matrix2._offsetY;
				if (type2 == XMatrixTypes.Unknown)
				{
					matrix1._type = XMatrixTypes.Unknown;
				}
				else
				{
					matrix1._type = XMatrixTypes.Translation | XMatrixTypes.Scaling;
				}
				return;
			}
			switch ((int)((uint)((int)type << 4) | (uint)type2))
			{
			case 34:
				matrix1._m11 *= matrix2._m11;
				matrix1._m22 *= matrix2._m22;
				break;
			case 35:
				matrix1._m11 *= matrix2._m11;
				matrix1._m22 *= matrix2._m22;
				matrix1._offsetX = matrix2._offsetX;
				matrix1._offsetY = matrix2._offsetY;
				matrix1._type = XMatrixTypes.Translation | XMatrixTypes.Scaling;
				break;
			case 36:
			case 52:
			case 66:
			case 67:
			case 68:
				matrix1 = new XMatrix(matrix1._m11 * matrix2._m11 + matrix1._m12 * matrix2._m21, matrix1._m11 * matrix2._m12 + matrix1._m12 * matrix2._m22, matrix1._m21 * matrix2._m11 + matrix1._m22 * matrix2._m21, matrix1._m21 * matrix2._m12 + matrix1._m22 * matrix2._m22, matrix1._offsetX * matrix2._m11 + matrix1._offsetY * matrix2._m21 + matrix2._offsetX, matrix1._offsetX * matrix2._m12 + matrix1._offsetY * matrix2._m22 + matrix2._offsetY);
				break;
			case 50:
				matrix1._m11 *= matrix2._m11;
				matrix1._m22 *= matrix2._m22;
				matrix1._offsetX *= matrix2._m11;
				matrix1._offsetY *= matrix2._m22;
				break;
			case 51:
				matrix1._m11 *= matrix2._m11;
				matrix1._m22 *= matrix2._m22;
				matrix1._offsetX = matrix2._m11 * matrix1._offsetX + matrix2._offsetX;
				matrix1._offsetY = matrix2._m22 * matrix1._offsetY + matrix2._offsetY;
				break;
			}
		}

		internal static void PrependOffset(ref XMatrix matrix, double offsetX, double offsetY)
		{
			if (matrix._type == XMatrixTypes.Identity)
			{
				matrix = new XMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY);
				matrix._type = XMatrixTypes.Translation;
				return;
			}
			matrix._offsetX += matrix._m11 * offsetX + matrix._m21 * offsetY;
			matrix._offsetY += matrix._m12 * offsetX + matrix._m22 * offsetY;
			if (matrix._type != XMatrixTypes.Unknown)
			{
				matrix._type |= XMatrixTypes.Translation;
			}
		}

		internal static void TransformRect(ref XRect rect, ref XMatrix matrix)
		{
			if (rect.IsEmpty)
			{
				return;
			}
			XMatrixTypes type = matrix._type;
			if (type == XMatrixTypes.Identity)
			{
				return;
			}
			if ((type & XMatrixTypes.Scaling) != XMatrixTypes.Identity)
			{
				rect.X *= matrix._m11;
				rect.Y *= matrix._m22;
				rect.Width *= matrix._m11;
				rect.Height *= matrix._m22;
				if (rect.Width < 0.0)
				{
					rect.X += rect.Width;
					rect.Width = 0.0 - rect.Width;
				}
				if (rect.Height < 0.0)
				{
					rect.Y += rect.Height;
					rect.Height = 0.0 - rect.Height;
				}
			}
			if ((type & XMatrixTypes.Translation) != XMatrixTypes.Identity)
			{
				rect.X += matrix._offsetX;
				rect.Y += matrix._offsetY;
			}
			if (type == XMatrixTypes.Unknown)
			{
				XPoint xPoint = matrix.Transform(rect.TopLeft);
				XPoint xPoint2 = matrix.Transform(rect.TopRight);
				XPoint xPoint3 = matrix.Transform(rect.BottomRight);
				XPoint xPoint4 = matrix.Transform(rect.BottomLeft);
				rect.X = Math.Min(Math.Min(xPoint.X, xPoint2.X), Math.Min(xPoint3.X, xPoint4.X));
				rect.Y = Math.Min(Math.Min(xPoint.Y, xPoint2.Y), Math.Min(xPoint3.Y, xPoint4.Y));
				rect.Width = Math.Max(Math.Max(xPoint.X, xPoint2.X), Math.Max(xPoint3.X, xPoint4.X)) - rect.X;
				rect.Height = Math.Max(Math.Max(xPoint.Y, xPoint2.Y), Math.Max(xPoint3.Y, xPoint4.Y)) - rect.Y;
			}
		}
	}

	private double _m11;

	private double _m12;

	private double _m21;

	private double _m22;

	private double _offsetX;

	private double _offsetY;

	private XMatrixTypes _type;

	private static readonly XMatrix s_identity = CreateIdentity();

	public static XMatrix Identity => s_identity;

	public bool IsIdentity
	{
		get
		{
			if (_type == XMatrixTypes.Identity)
			{
				return true;
			}
			if (_m11 == 1.0 && _m12 == 0.0 && _m21 == 0.0 && _m22 == 1.0 && _offsetX == 0.0 && _offsetY == 0.0)
			{
				_type = XMatrixTypes.Identity;
				return true;
			}
			return false;
		}
	}

	public double Determinant
	{
		get
		{
			switch (_type)
			{
			case XMatrixTypes.Identity:
			case XMatrixTypes.Translation:
				return 1.0;
			case XMatrixTypes.Scaling:
			case XMatrixTypes.Translation | XMatrixTypes.Scaling:
				return _m11 * _m22;
			default:
				return _m11 * _m22 - _m12 * _m21;
			}
		}
	}

	public bool HasInverse => !DoubleUtil.IsZero(Determinant);

	public double M11
	{
		get
		{
			if (_type == XMatrixTypes.Identity)
			{
				return 1.0;
			}
			return _m11;
		}
		set
		{
			if (_type == XMatrixTypes.Identity)
			{
				SetMatrix(value, 0.0, 0.0, 1.0, 0.0, 0.0, XMatrixTypes.Scaling);
				return;
			}
			_m11 = value;
			if (_type != XMatrixTypes.Unknown)
			{
				_type |= XMatrixTypes.Scaling;
			}
		}
	}

	public double M12
	{
		get
		{
			if (_type == XMatrixTypes.Identity)
			{
				return 0.0;
			}
			return _m12;
		}
		set
		{
			if (_type == XMatrixTypes.Identity)
			{
				SetMatrix(1.0, value, 0.0, 1.0, 0.0, 0.0, XMatrixTypes.Unknown);
				return;
			}
			_m12 = value;
			_type = XMatrixTypes.Unknown;
		}
	}

	public double M21
	{
		get
		{
			if (_type == XMatrixTypes.Identity)
			{
				return 0.0;
			}
			return _m21;
		}
		set
		{
			if (_type == XMatrixTypes.Identity)
			{
				SetMatrix(1.0, 0.0, value, 1.0, 0.0, 0.0, XMatrixTypes.Unknown);
				return;
			}
			_m21 = value;
			_type = XMatrixTypes.Unknown;
		}
	}

	public double M22
	{
		get
		{
			if (_type == XMatrixTypes.Identity)
			{
				return 1.0;
			}
			return _m22;
		}
		set
		{
			if (_type == XMatrixTypes.Identity)
			{
				SetMatrix(1.0, 0.0, 0.0, value, 0.0, 0.0, XMatrixTypes.Scaling);
				return;
			}
			_m22 = value;
			if (_type != XMatrixTypes.Unknown)
			{
				_type |= XMatrixTypes.Scaling;
			}
		}
	}

	public double OffsetX
	{
		get
		{
			if (_type == XMatrixTypes.Identity)
			{
				return 0.0;
			}
			return _offsetX;
		}
		set
		{
			if (_type == XMatrixTypes.Identity)
			{
				SetMatrix(1.0, 0.0, 0.0, 1.0, value, 0.0, XMatrixTypes.Translation);
				return;
			}
			_offsetX = value;
			if (_type != XMatrixTypes.Unknown)
			{
				_type |= XMatrixTypes.Translation;
			}
		}
	}

	public double OffsetY
	{
		get
		{
			if (_type == XMatrixTypes.Identity)
			{
				return 0.0;
			}
			return _offsetY;
		}
		set
		{
			if (_type == XMatrixTypes.Identity)
			{
				SetMatrix(1.0, 0.0, 0.0, 1.0, 0.0, value, XMatrixTypes.Translation);
				return;
			}
			_offsetY = value;
			if (_type != XMatrixTypes.Unknown)
			{
				_type |= XMatrixTypes.Translation;
			}
		}
	}

	private bool IsDistinguishedIdentity => _type == XMatrixTypes.Identity;

	private string DebuggerDisplay
	{
		get
		{
			if (IsIdentity)
			{
				return "matrix=(Identity)";
			}
			XPoint xPoint = new XMatrix(_m11, _m12, _m21, _m22, 0.0, 0.0).Transform(new XPoint(1.0, 0.0));
			double num = Math.Atan2(xPoint.Y, xPoint.X) / (Math.PI / 180.0);
			return string.Format(CultureInfo.InvariantCulture, "matrix=({0:0.#######}, {1:0.#######}, {2:0.#######}, {3:0.#######}, {4:0.#######}, {5:0.#######}), φ={6:0.0#########}°", _m11, _m12, _m21, _m22, _offsetX, _offsetY, num);
		}
	}

	public XMatrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY)
	{
		_m11 = m11;
		_m12 = m12;
		_m21 = m21;
		_m22 = m22;
		_offsetX = offsetX;
		_offsetY = offsetY;
		_type = XMatrixTypes.Unknown;
		DeriveMatrixType();
	}

	public void SetIdentity()
	{
		_type = XMatrixTypes.Identity;
	}

	public double[] GetElements()
	{
		if (_type == XMatrixTypes.Identity)
		{
			return new double[6] { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0 };
		}
		return new double[6] { _m11, _m12, _m21, _m22, _offsetX, _offsetY };
	}

	public static XMatrix operator *(XMatrix trans1, XMatrix trans2)
	{
		MatrixHelper.MultiplyMatrix(ref trans1, ref trans2);
		return trans1;
	}

	public static XMatrix Multiply(XMatrix trans1, XMatrix trans2)
	{
		MatrixHelper.MultiplyMatrix(ref trans1, ref trans2);
		return trans1;
	}

	public void Append(XMatrix matrix)
	{
		this *= matrix;
	}

	public void Prepend(XMatrix matrix)
	{
		this = matrix * this;
	}

	[Obsolete("Use Append.")]
	public void Multiply(XMatrix matrix)
	{
		Append(matrix);
	}

	[Obsolete("Use Prepend.")]
	public void MultiplyPrepend(XMatrix matrix)
	{
		Prepend(matrix);
	}

	public void Multiply(XMatrix matrix, XMatrixOrder order)
	{
		if (_type == XMatrixTypes.Identity)
		{
			this = CreateIdentity();
		}
		double m = M11;
		double m2 = M12;
		double m3 = M21;
		double m4 = M22;
		double offsetX = OffsetX;
		double offsetY = OffsetY;
		if (order == XMatrixOrder.Append)
		{
			_m11 = m * matrix.M11 + m2 * matrix.M21;
			_m12 = m * matrix.M12 + m2 * matrix.M22;
			_m21 = m3 * matrix.M11 + m4 * matrix.M21;
			_m22 = m3 * matrix.M12 + m4 * matrix.M22;
			_offsetX = offsetX * matrix.M11 + offsetY * matrix.M21 + matrix.OffsetX;
			_offsetY = offsetX * matrix.M12 + offsetY * matrix.M22 + matrix.OffsetY;
		}
		else
		{
			_m11 = m * matrix.M11 + m3 * matrix.M12;
			_m12 = m2 * matrix.M11 + m4 * matrix.M12;
			_m21 = m * matrix.M21 + m3 * matrix.M22;
			_m22 = m2 * matrix.M21 + m4 * matrix.M22;
			_offsetX = m * matrix.OffsetX + m3 * matrix.OffsetY + offsetX;
			_offsetY = m2 * matrix.OffsetX + m4 * matrix.OffsetY + offsetY;
		}
		DeriveMatrixType();
	}

	[Obsolete("Use TranslateAppend or TranslatePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
	public void Translate(double offsetX, double offsetY)
	{
		throw new InvalidOperationException("Temporarily out of order.");
	}

	public void TranslateAppend(double offsetX, double offsetY)
	{
		if (_type == XMatrixTypes.Identity)
		{
			SetMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY, XMatrixTypes.Translation);
		}
		else if (_type == XMatrixTypes.Unknown)
		{
			_offsetX += offsetX;
			_offsetY += offsetY;
		}
		else
		{
			_offsetX += offsetX;
			_offsetY += offsetY;
			_type |= XMatrixTypes.Translation;
		}
	}

	public void TranslatePrepend(double offsetX, double offsetY)
	{
		this = CreateTranslation(offsetX, offsetY) * this;
	}

	public void Translate(double offsetX, double offsetY, XMatrixOrder order)
	{
		if (_type == XMatrixTypes.Identity)
		{
			this = CreateIdentity();
		}
		if (order == XMatrixOrder.Append)
		{
			_offsetX += offsetX;
			_offsetY += offsetY;
		}
		else
		{
			_offsetX += offsetX * _m11 + offsetY * _m21;
			_offsetY += offsetX * _m12 + offsetY * _m22;
		}
		DeriveMatrixType();
	}

	[Obsolete("Use ScaleAppend or ScalePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
	public void Scale(double scaleX, double scaleY)
	{
		this = CreateScaling(scaleX, scaleY) * this;
	}

	public void ScaleAppend(double scaleX, double scaleY)
	{
		this *= CreateScaling(scaleX, scaleY);
	}

	public void ScalePrepend(double scaleX, double scaleY)
	{
		this = CreateScaling(scaleX, scaleY) * this;
	}

	public void Scale(double scaleX, double scaleY, XMatrixOrder order)
	{
		if (_type == XMatrixTypes.Identity)
		{
			this = CreateIdentity();
		}
		if (order == XMatrixOrder.Append)
		{
			_m11 *= scaleX;
			_m12 *= scaleY;
			_m21 *= scaleX;
			_m22 *= scaleY;
			_offsetX *= scaleX;
			_offsetY *= scaleY;
		}
		else
		{
			_m11 *= scaleX;
			_m12 *= scaleX;
			_m21 *= scaleY;
			_m22 *= scaleY;
		}
		DeriveMatrixType();
	}

	[Obsolete("Use ScaleAppend or ScalePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
	public void Scale(double scaleXY)
	{
		throw new InvalidOperationException("Temporarily out of order.");
	}

	public void ScaleAppend(double scaleXY)
	{
		Scale(scaleXY, scaleXY, XMatrixOrder.Append);
	}

	public void ScalePrepend(double scaleXY)
	{
		Scale(scaleXY, scaleXY, XMatrixOrder.Prepend);
	}

	public void Scale(double scaleXY, XMatrixOrder order)
	{
		Scale(scaleXY, scaleXY, order);
	}

	[Obsolete("Use ScaleAtAppend or ScaleAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
	public void ScaleAt(double scaleX, double scaleY, double centerX, double centerY)
	{
		throw new InvalidOperationException("Temporarily out of order.");
	}

	public void ScaleAtAppend(double scaleX, double scaleY, double centerX, double centerY)
	{
		this *= CreateScaling(scaleX, scaleY, centerX, centerY);
	}

	public void ScaleAtPrepend(double scaleX, double scaleY, double centerX, double centerY)
	{
		this = CreateScaling(scaleX, scaleY, centerX, centerY) * this;
	}

	[Obsolete("Use RotateAppend or RotatePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
	public void Rotate(double angle)
	{
		throw new InvalidOperationException("Temporarily out of order.");
	}

	public void RotateAppend(double angle)
	{
		angle %= 360.0;
		this *= CreateRotationRadians(angle * (Math.PI / 180.0));
	}

	public void RotatePrepend(double angle)
	{
		angle %= 360.0;
		this = CreateRotationRadians(angle * (Math.PI / 180.0)) * this;
	}

	public void Rotate(double angle, XMatrixOrder order)
	{
		if (_type == XMatrixTypes.Identity)
		{
			this = CreateIdentity();
		}
		angle *= Math.PI / 180.0;
		double num = Math.Cos(angle);
		double num2 = Math.Sin(angle);
		if (order == XMatrixOrder.Append)
		{
			double m = _m11;
			double m2 = _m12;
			double m3 = _m21;
			double m4 = _m22;
			double offsetX = _offsetX;
			double offsetY = _offsetY;
			_m11 = m * num - m2 * num2;
			_m12 = m * num2 + m2 * num;
			_m21 = m3 * num - m4 * num2;
			_m22 = m3 * num2 + m4 * num;
			_offsetX = offsetX * num - offsetY * num2;
			_offsetY = offsetX * num2 + offsetY * num;
		}
		else
		{
			double m5 = _m11;
			double m6 = _m12;
			double m7 = _m21;
			double m8 = _m22;
			_m11 = m5 * num + m7 * num2;
			_m12 = m6 * num + m8 * num2;
			_m21 = (0.0 - m5) * num2 + m7 * num;
			_m22 = (0.0 - m6) * num2 + m8 * num;
		}
		DeriveMatrixType();
	}

	[Obsolete("Use RotateAtAppend or RotateAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
	public void RotateAt(double angle, double centerX, double centerY)
	{
		throw new InvalidOperationException("Temporarily out of order.");
	}

	public void RotateAtAppend(double angle, double centerX, double centerY)
	{
		angle %= 360.0;
		this *= CreateRotationRadians(angle * (Math.PI / 180.0), centerX, centerY);
	}

	public void RotateAtPrepend(double angle, double centerX, double centerY)
	{
		angle %= 360.0;
		this = CreateRotationRadians(angle * (Math.PI / 180.0), centerX, centerY) * this;
	}

	[Obsolete("Use RotateAtAppend or RotateAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
	public void RotateAt(double angle, XPoint point)
	{
		throw new InvalidOperationException("Temporarily out of order.");
	}

	public void RotateAtAppend(double angle, XPoint point)
	{
		RotateAt(angle, point, XMatrixOrder.Append);
	}

	public void RotateAtPrepend(double angle, XPoint point)
	{
		RotateAt(angle, point, XMatrixOrder.Prepend);
	}

	public void RotateAt(double angle, XPoint point, XMatrixOrder order)
	{
		if (order == XMatrixOrder.Append)
		{
			angle %= 360.0;
			this *= CreateRotationRadians(angle * (Math.PI / 180.0), point.X, point.Y);
		}
		else
		{
			angle %= 360.0;
			this = CreateRotationRadians(angle * (Math.PI / 180.0), point.X, point.Y) * this;
		}
		DeriveMatrixType();
	}

	[Obsolete("Use ShearAppend or ShearPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
	public void Shear(double shearX, double shearY)
	{
		throw new InvalidOperationException("Temporarily out of order.");
	}

	public void ShearAppend(double shearX, double shearY)
	{
		Shear(shearX, shearY, XMatrixOrder.Append);
	}

	public void ShearPrepend(double shearX, double shearY)
	{
		Shear(shearX, shearY, XMatrixOrder.Prepend);
	}

	public void Shear(double shearX, double shearY, XMatrixOrder order)
	{
		if (_type == XMatrixTypes.Identity)
		{
			this = CreateIdentity();
		}
		double m = _m11;
		double m2 = _m12;
		double m3 = _m21;
		double m4 = _m22;
		double offsetX = _offsetX;
		double offsetY = _offsetY;
		if (order == XMatrixOrder.Append)
		{
			_m11 += shearX * m2;
			_m12 += shearY * m;
			_m21 += shearX * m4;
			_m22 += shearY * m3;
			_offsetX += shearX * offsetY;
			_offsetY += shearY * offsetX;
		}
		else
		{
			_m11 += shearY * m3;
			_m12 += shearY * m4;
			_m21 += shearX * m;
			_m22 += shearX * m2;
		}
		DeriveMatrixType();
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
		this *= CreateSkewRadians(skewX * (Math.PI / 180.0), skewY * (Math.PI / 180.0));
	}

	public void SkewPrepend(double skewX, double skewY)
	{
		skewX %= 360.0;
		skewY %= 360.0;
		this = CreateSkewRadians(skewX * (Math.PI / 180.0), skewY * (Math.PI / 180.0)) * this;
	}

	public XPoint Transform(XPoint point)
	{
		double x = point.X;
		double y = point.Y;
		MultiplyPoint(ref x, ref y);
		return new XPoint(x, y);
	}

	public void Transform(XPoint[] points)
	{
		if (points != null)
		{
			int num = points.Length;
			for (int i = 0; i < num; i++)
			{
				double x = points[i].X;
				double y = points[i].Y;
				MultiplyPoint(ref x, ref y);
				points[i].X = x;
				points[i].Y = y;
			}
		}
	}

	public void TransformPoints(XPoint[] points)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		if (!IsIdentity)
		{
			int num = points.Length;
			for (int i = 0; i < num; i++)
			{
				double x = points[i].X;
				double y = points[i].Y;
				points[i].X = x * _m11 + y * _m21 + _offsetX;
				points[i].Y = x * _m12 + y * _m22 + _offsetY;
			}
		}
	}

	public XVector Transform(XVector vector)
	{
		double x = vector.X;
		double y = vector.Y;
		MultiplyVector(ref x, ref y);
		return new XVector(x, y);
	}

	public void Transform(XVector[] vectors)
	{
		if (vectors != null)
		{
			int num = vectors.Length;
			for (int i = 0; i < num; i++)
			{
				double x = vectors[i].X;
				double y = vectors[i].Y;
				MultiplyVector(ref x, ref y);
				vectors[i].X = x;
				vectors[i].Y = y;
			}
		}
	}

	public void Invert()
	{
		double determinant = Determinant;
		if (DoubleUtil.IsZero(determinant))
		{
			throw new InvalidOperationException("NotInvertible");
		}
		switch (_type)
		{
		case XMatrixTypes.Identity:
			break;
		case XMatrixTypes.Translation:
			_offsetX = 0.0 - _offsetX;
			_offsetY = 0.0 - _offsetY;
			break;
		case XMatrixTypes.Scaling:
			_m11 = 1.0 / _m11;
			_m22 = 1.0 / _m22;
			break;
		case XMatrixTypes.Translation | XMatrixTypes.Scaling:
			_m11 = 1.0 / _m11;
			_m22 = 1.0 / _m22;
			_offsetX = (0.0 - _offsetX) * _m11;
			_offsetY = (0.0 - _offsetY) * _m22;
			break;
		default:
		{
			double num = 1.0 / determinant;
			SetMatrix(_m22 * num, (0.0 - _m12) * num, (0.0 - _m21) * num, _m11 * num, (_m21 * _offsetY - _offsetX * _m22) * num, (_offsetX * _m12 - _m11 * _offsetY) * num, XMatrixTypes.Unknown);
			break;
		}
		}
	}

	public static bool operator ==(XMatrix matrix1, XMatrix matrix2)
	{
		if (matrix1.IsDistinguishedIdentity || matrix2.IsDistinguishedIdentity)
		{
			return matrix1.IsIdentity == matrix2.IsIdentity;
		}
		return matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.OffsetX == matrix2.OffsetX && matrix1.OffsetY == matrix2.OffsetY;
	}

	public static bool operator !=(XMatrix matrix1, XMatrix matrix2)
	{
		return !(matrix1 == matrix2);
	}

	public static bool Equals(XMatrix matrix1, XMatrix matrix2)
	{
		if (matrix1.IsDistinguishedIdentity || matrix2.IsDistinguishedIdentity)
		{
			return matrix1.IsIdentity == matrix2.IsIdentity;
		}
		return matrix1.M11.Equals(matrix2.M11) && matrix1.M12.Equals(matrix2.M12) && matrix1.M21.Equals(matrix2.M21) && matrix1.M22.Equals(matrix2.M22) && matrix1.OffsetX.Equals(matrix2.OffsetX) && matrix1.OffsetY.Equals(matrix2.OffsetY);
	}

	public override bool Equals(object o)
	{
		if (!(o is XMatrix))
		{
			return false;
		}
		return Equals(this, (XMatrix)o);
	}

	public bool Equals(XMatrix value)
	{
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		if (IsDistinguishedIdentity)
		{
			return 0;
		}
		return M11.GetHashCode() ^ M12.GetHashCode() ^ M21.GetHashCode() ^ M22.GetHashCode() ^ OffsetX.GetHashCode() ^ OffsetY.GetHashCode();
	}

	public static XMatrix Parse(string source)
	{
		IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
		TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantCulture);
		string text = tokenizerHelper.NextTokenRequired();
		XMatrix result = ((text == "Identity") ? Identity : new XMatrix(Convert.ToDouble(text, invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture)));
		tokenizerHelper.LastTokenRequired();
		return result;
	}

	public override string ToString()
	{
		return ConvertToString(null, null);
	}

	public string ToString(IFormatProvider provider)
	{
		return ConvertToString(null, provider);
	}

	string IFormattable.ToString(string format, IFormatProvider provider)
	{
		return ConvertToString(format, provider);
	}

	internal string ConvertToString(string format, IFormatProvider provider)
	{
		if (IsIdentity)
		{
			return "Identity";
		}
		char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
		provider = provider ?? CultureInfo.InvariantCulture;
		return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}{0}{4:" + format + "}{0}{5:" + format + "}{0}{6:" + format + "}", numericListSeparator, _m11, _m12, _m21, _m22, _offsetX, _offsetY);
	}

	internal void MultiplyVector(ref double x, ref double y)
	{
		switch (_type)
		{
		case XMatrixTypes.Identity:
		case XMatrixTypes.Translation:
			return;
		case XMatrixTypes.Scaling:
		case XMatrixTypes.Translation | XMatrixTypes.Scaling:
			x *= _m11;
			y *= _m22;
			return;
		}
		double num = y * _m21;
		double num2 = x * _m12;
		x *= _m11;
		x += num;
		y *= _m22;
		y += num2;
	}

	internal void MultiplyPoint(ref double x, ref double y)
	{
		switch (_type)
		{
		case XMatrixTypes.Identity:
			break;
		case XMatrixTypes.Translation:
			x += _offsetX;
			y += _offsetY;
			break;
		case XMatrixTypes.Scaling:
			x *= _m11;
			y *= _m22;
			break;
		case XMatrixTypes.Translation | XMatrixTypes.Scaling:
			x *= _m11;
			x += _offsetX;
			y *= _m22;
			y += _offsetY;
			break;
		default:
		{
			double num = y * _m21 + _offsetX;
			double num2 = x * _m12 + _offsetY;
			x *= _m11;
			x += num;
			y *= _m22;
			y += num2;
			break;
		}
		}
	}

	internal static XMatrix CreateTranslation(double offsetX, double offsetY)
	{
		XMatrix result = default(XMatrix);
		result.SetMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY, XMatrixTypes.Translation);
		return result;
	}

	internal static XMatrix CreateRotationRadians(double angle)
	{
		return CreateRotationRadians(angle, 0.0, 0.0);
	}

	internal static XMatrix CreateRotationRadians(double angle, double centerX, double centerY)
	{
		XMatrix result = default(XMatrix);
		double num = Math.Sin(angle);
		double num2 = Math.Cos(angle);
		double offsetX = centerX * (1.0 - num2) + centerY * num;
		double offsetY = centerY * (1.0 - num2) - centerX * num;
		result.SetMatrix(num2, num, 0.0 - num, num2, offsetX, offsetY, XMatrixTypes.Unknown);
		return result;
	}

	internal static XMatrix CreateScaling(double scaleX, double scaleY)
	{
		XMatrix result = default(XMatrix);
		result.SetMatrix(scaleX, 0.0, 0.0, scaleY, 0.0, 0.0, XMatrixTypes.Scaling);
		return result;
	}

	internal static XMatrix CreateScaling(double scaleX, double scaleY, double centerX, double centerY)
	{
		XMatrix result = default(XMatrix);
		result.SetMatrix(scaleX, 0.0, 0.0, scaleY, centerX - scaleX * centerX, centerY - scaleY * centerY, XMatrixTypes.Translation | XMatrixTypes.Scaling);
		return result;
	}

	internal static XMatrix CreateSkewRadians(double skewX, double skewY, double centerX, double centerY)
	{
		XMatrix result = default(XMatrix);
		result.Append(CreateTranslation(0.0 - centerX, 0.0 - centerY));
		result.Append(new XMatrix(1.0, Math.Tan(skewY), Math.Tan(skewX), 1.0, 0.0, 0.0));
		result.Append(CreateTranslation(centerX, centerY));
		return result;
	}

	internal static XMatrix CreateSkewRadians(double skewX, double skewY)
	{
		XMatrix result = default(XMatrix);
		result.SetMatrix(1.0, Math.Tan(skewY), Math.Tan(skewX), 1.0, 0.0, 0.0, XMatrixTypes.Unknown);
		return result;
	}

	private static XMatrix CreateIdentity()
	{
		XMatrix result = default(XMatrix);
		result.SetMatrix(1.0, 0.0, 0.0, 1.0, 0.0, 0.0, XMatrixTypes.Identity);
		return result;
	}

	private void SetMatrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY, XMatrixTypes type)
	{
		_m11 = m11;
		_m12 = m12;
		_m21 = m21;
		_m22 = m22;
		_offsetX = offsetX;
		_offsetY = offsetY;
		_type = type;
	}

	private void DeriveMatrixType()
	{
		_type = XMatrixTypes.Identity;
		if (_m12 != 0.0 || _m21 != 0.0)
		{
			_type = XMatrixTypes.Unknown;
			return;
		}
		if (_m11 != 1.0 || _m22 != 1.0)
		{
			_type = XMatrixTypes.Scaling;
		}
		if (_offsetX != 0.0 || _offsetY != 0.0)
		{
			_type |= XMatrixTypes.Translation;
		}
		if ((_type & (XMatrixTypes.Translation | XMatrixTypes.Scaling)) == 0)
		{
			_type = XMatrixTypes.Identity;
		}
	}
}
