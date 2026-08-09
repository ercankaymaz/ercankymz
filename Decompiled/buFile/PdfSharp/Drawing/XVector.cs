using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

[Serializable]
[DebuggerDisplay("{DebuggerDisplay}")]
public struct XVector(double x, double y) : IFormattable
{
	private double _x = x;

	private double _y = y;

	public double X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public double Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public double Length => Math.Sqrt(_x * _x + _y * _y);

	public double LengthSquared => _x * _x + _y * _y;

	private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "vector=({0:0.##########}, {1:0.##########})", _x, _y);

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
		if (vector1.X.Equals(vector2.X))
		{
			return vector1.Y.Equals(vector2.Y);
		}
		return false;
	}

	public override bool Equals(object o)
	{
		if (!(o is XVector))
		{
			return false;
		}
		return Equals(this, (XVector)o);
	}

	public bool Equals(XVector value)
	{
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		return _x.GetHashCode() ^ _y.GetHashCode();
	}

	public static XVector Parse(string source)
	{
		TokenizerHelper tokenizerHelper = new TokenizerHelper(source, CultureInfo.InvariantCulture);
		string value = tokenizerHelper.NextTokenRequired();
		XVector result = new XVector(Convert.ToDouble(value, CultureInfo.InvariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), CultureInfo.InvariantCulture));
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
		provider = provider ?? CultureInfo.InvariantCulture;
		return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", ',', _x, _y);
	}

	public void Normalize()
	{
		this /= Math.Max(Math.Abs(_x), Math.Abs(_y));
		this /= Length;
	}

	public static double CrossProduct(XVector vector1, XVector vector2)
	{
		return vector1._x * vector2._y - vector1._y * vector2._x;
	}

	public static double AngleBetween(XVector vector1, XVector vector2)
	{
		double y = vector1._x * vector2._y - vector2._x * vector1._y;
		double x = vector1._x * vector2._x + vector1._y * vector2._y;
		return Math.Atan2(y, x) * (180.0 / Math.PI);
	}

	public static XVector operator -(XVector vector)
	{
		return new XVector(0.0 - vector._x, 0.0 - vector._y);
	}

	public void Negate()
	{
		_x = 0.0 - _x;
		_y = 0.0 - _y;
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

	public static XVector operator /(XVector vector, double scalar)
	{
		return vector * (1.0 / scalar);
	}

	public static XVector Divide(XVector vector, double scalar)
	{
		return vector * (1.0 / scalar);
	}

	public static XVector operator *(XVector vector, XMatrix matrix)
	{
		return matrix.Transform(vector);
	}

	public static XVector Multiply(XVector vector, XMatrix matrix)
	{
		return matrix.Transform(vector);
	}

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

	public static explicit operator XPoint(XVector vector)
	{
		return new XPoint(vector._x, vector._y);
	}
}
