using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

[Serializable]
[DebuggerDisplay("{DebuggerDisplay}")]
public struct XPoint(double x, double y) : IFormattable
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

	private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "point=({0:0.##########}, {1:0.##########})", _x, _y);

	public static bool operator ==(XPoint point1, XPoint point2)
	{
		return point1._x == point2._x && point1._y == point2._y;
	}

	public static bool operator !=(XPoint point1, XPoint point2)
	{
		return !(point1 == point2);
	}

	public static bool Equals(XPoint point1, XPoint point2)
	{
		return point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y);
	}

	public override bool Equals(object o)
	{
		if (!(o is XPoint))
		{
			return false;
		}
		return Equals(this, (XPoint)o);
	}

	public bool Equals(XPoint value)
	{
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode();
	}

	public static XPoint Parse(string source)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantCulture);
		string value = tokenizerHelper.NextTokenRequired();
		XPoint result = new XPoint(Convert.ToDouble(value, invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture));
		tokenizerHelper.LastTokenRequired();
		return result;
	}

	public static XPoint[] ParsePoints(string value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		string[] array = value.Split(' ');
		int num = array.Length;
		XPoint[] array2 = new XPoint[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = Parse(array[i]);
		}
		return array2;
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
		char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
		provider = provider ?? CultureInfo.InvariantCulture;
		return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", new object[3] { numericListSeparator, _x, _y });
	}

	public void Offset(double offsetX, double offsetY)
	{
		_x += offsetX;
		_y += offsetY;
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

	public static XPoint operator *(XPoint point, XMatrix matrix)
	{
		return matrix.Transform(point);
	}

	public static XPoint Multiply(XPoint point, XMatrix matrix)
	{
		return matrix.Transform(point);
	}

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

	public static explicit operator XVector(XPoint point)
	{
		return new XVector(point._x, point._y);
	}
}
