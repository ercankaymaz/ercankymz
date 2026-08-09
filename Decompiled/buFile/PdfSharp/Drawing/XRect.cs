using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

[Serializable]
[DebuggerDisplay("{DebuggerDisplay}")]
public struct XRect : IFormattable
{
	private double _x;

	private double _y;

	private double _width;

	private double _height;

	private static readonly XRect s_empty;

	public static XRect Empty => s_empty;

	public bool IsEmpty => _width < 0.0;

	public XPoint Location
	{
		get
		{
			return new XPoint(_x, _y);
		}
		set
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("CannotModifyEmptyRect");
			}
			_x = value.X;
			_y = value.Y;
		}
	}

	public XSize Size
	{
		get
		{
			if (IsEmpty)
			{
				return XSize.Empty;
			}
			return new XSize(_width, _height);
		}
		set
		{
			if (value.IsEmpty)
			{
				this = s_empty;
				return;
			}
			if (IsEmpty)
			{
				throw new InvalidOperationException("CannotModifyEmptyRect");
			}
			_width = value.Width;
			_height = value.Height;
		}
	}

	public double X
	{
		get
		{
			return _x;
		}
		set
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("CannotModifyEmptyRect");
			}
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
			if (IsEmpty)
			{
				throw new InvalidOperationException("CannotModifyEmptyRect");
			}
			_y = value;
		}
	}

	public double Width
	{
		get
		{
			return _width;
		}
		set
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("CannotModifyEmptyRect");
			}
			if (value < 0.0)
			{
				throw new ArgumentException("WidthCannotBeNegative");
			}
			_width = value;
		}
	}

	public double Height
	{
		get
		{
			return _height;
		}
		set
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("CannotModifyEmptyRect");
			}
			if (value < 0.0)
			{
				throw new ArgumentException("HeightCannotBeNegative");
			}
			_height = value;
		}
	}

	public double Left => _x;

	public double Top => _y;

	public double Right
	{
		get
		{
			if (IsEmpty)
			{
				return double.NegativeInfinity;
			}
			return _x + _width;
		}
	}

	public double Bottom
	{
		get
		{
			if (IsEmpty)
			{
				return double.NegativeInfinity;
			}
			return _y + _height;
		}
	}

	public XPoint TopLeft => new XPoint(Left, Top);

	public XPoint TopRight => new XPoint(Right, Top);

	public XPoint BottomLeft => new XPoint(Left, Bottom);

	public XPoint BottomRight => new XPoint(Right, Bottom);

	public XPoint Center => new XPoint(_x + _width / 2.0, _y + _height / 2.0);

	private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "rect=({0:0.##########}, {1:0.##########}, {2:0.##########}, {3:0.##########})", _x, _y, _width, _height);

	public XRect(double x, double y, double width, double height)
	{
		if (width < 0.0 || height < 0.0)
		{
			throw new ArgumentException("WidthAndHeightCannotBeNegative");
		}
		_x = x;
		_y = y;
		_width = width;
		_height = height;
	}

	public XRect(XPoint point1, XPoint point2)
	{
		_x = Math.Min(point1.X, point2.X);
		_y = Math.Min(point1.Y, point2.Y);
		_width = Math.Max(Math.Max(point1.X, point2.X) - _x, 0.0);
		_height = Math.Max(Math.Max(point1.Y, point2.Y) - _y, 0.0);
	}

	public XRect(XPoint point, XVector vector)
		: this(point, point + vector)
	{
	}

	public XRect(XPoint location, XSize size)
	{
		if (size.IsEmpty)
		{
			this = s_empty;
			return;
		}
		_x = location.X;
		_y = location.Y;
		_width = size.Width;
		_height = size.Height;
	}

	public XRect(XSize size)
	{
		if (size.IsEmpty)
		{
			this = s_empty;
			return;
		}
		_x = (_y = 0.0);
		_width = size.Width;
		_height = size.Height;
	}

	public static XRect FromLTRB(double left, double top, double right, double bottom)
	{
		return new XRect(left, top, right - left, bottom - top);
	}

	public static bool operator ==(XRect rect1, XRect rect2)
	{
		return rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Width == rect2.Width && rect1.Height == rect2.Height;
	}

	public static bool operator !=(XRect rect1, XRect rect2)
	{
		return !(rect1 == rect2);
	}

	public static bool Equals(XRect rect1, XRect rect2)
	{
		if (rect1.IsEmpty)
		{
			return rect2.IsEmpty;
		}
		return rect1.X.Equals(rect2.X) && rect1.Y.Equals(rect2.Y) && rect1.Width.Equals(rect2.Width) && rect1.Height.Equals(rect2.Height);
	}

	public override bool Equals(object o)
	{
		if (!(o is XRect))
		{
			return false;
		}
		return Equals(this, (XRect)o);
	}

	public bool Equals(XRect value)
	{
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		if (IsEmpty)
		{
			return 0;
		}
		return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
	}

	public static XRect Parse(string source)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantCulture);
		string text = tokenizerHelper.NextTokenRequired();
		XRect result = ((!(text == "Empty")) ? new XRect(Convert.ToDouble(text, invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture)) : Empty);
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
		if (IsEmpty)
		{
			return "Empty";
		}
		char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
		provider = provider ?? CultureInfo.InvariantCulture;
		return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}{0}{4:" + format + "}", numericListSeparator, _x, _y, _width, _height);
	}

	public bool Contains(XPoint point)
	{
		return Contains(point.X, point.Y);
	}

	public bool Contains(double x, double y)
	{
		if (IsEmpty)
		{
			return false;
		}
		return ContainsInternal(x, y);
	}

	public bool Contains(XRect rect)
	{
		return !IsEmpty && !rect.IsEmpty && _x <= rect._x && _y <= rect._y && _x + _width >= rect._x + rect._width && _y + _height >= rect._y + rect._height;
	}

	public bool IntersectsWith(XRect rect)
	{
		return !IsEmpty && !rect.IsEmpty && rect.Left <= Right && rect.Right >= Left && rect.Top <= Bottom && rect.Bottom >= Top;
	}

	public void Intersect(XRect rect)
	{
		if (!IntersectsWith(rect))
		{
			this = Empty;
			return;
		}
		double num = Math.Max(Left, rect.Left);
		double num2 = Math.Max(Top, rect.Top);
		_width = Math.Max(Math.Min(Right, rect.Right) - num, 0.0);
		_height = Math.Max(Math.Min(Bottom, rect.Bottom) - num2, 0.0);
		_x = num;
		_y = num2;
	}

	public static XRect Intersect(XRect rect1, XRect rect2)
	{
		rect1.Intersect(rect2);
		return rect1;
	}

	public void Union(XRect rect)
	{
		if (IsEmpty)
		{
			this = rect;
		}
		else if (!rect.IsEmpty)
		{
			double num = Math.Min(Left, rect.Left);
			double num2 = Math.Min(Top, rect.Top);
			if (rect.Width == double.PositiveInfinity || Width == double.PositiveInfinity)
			{
				_width = double.PositiveInfinity;
			}
			else
			{
				double num3 = Math.Max(Right, rect.Right);
				_width = Math.Max(num3 - num, 0.0);
			}
			if (rect.Height == double.PositiveInfinity || _height == double.PositiveInfinity)
			{
				_height = double.PositiveInfinity;
			}
			else
			{
				double num4 = Math.Max(Bottom, rect.Bottom);
				_height = Math.Max(num4 - num2, 0.0);
			}
			_x = num;
			_y = num2;
		}
	}

	public static XRect Union(XRect rect1, XRect rect2)
	{
		rect1.Union(rect2);
		return rect1;
	}

	public void Union(XPoint point)
	{
		Union(new XRect(point, point));
	}

	public static XRect Union(XRect rect, XPoint point)
	{
		rect.Union(new XRect(point, point));
		return rect;
	}

	public void Offset(XVector offsetVector)
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException("CannotCallMethod");
		}
		_x += offsetVector.X;
		_y += offsetVector.Y;
	}

	public void Offset(double offsetX, double offsetY)
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException("CannotCallMethod");
		}
		_x += offsetX;
		_y += offsetY;
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

	public void Inflate(XSize size)
	{
		Inflate(size.Width, size.Height);
	}

	public void Inflate(double width, double height)
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException("CannotCallMethod");
		}
		_x -= width;
		_y -= height;
		_width += width;
		_width += width;
		_height += height;
		_height += height;
		if (_width < 0.0 || _height < 0.0)
		{
			this = s_empty;
		}
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

	public void Transform(XMatrix matrix)
	{
		XMatrix.MatrixHelper.TransformRect(ref this, ref matrix);
	}

	public void Scale(double scaleX, double scaleY)
	{
		if (!IsEmpty)
		{
			_x *= scaleX;
			_y *= scaleY;
			_width *= scaleX;
			_height *= scaleY;
			if (scaleX < 0.0)
			{
				_x += _width;
				_width *= -1.0;
			}
			if (scaleY < 0.0)
			{
				_y += _height;
				_height *= -1.0;
			}
		}
	}

	private bool ContainsInternal(double x, double y)
	{
		return x >= _x && x - _width <= _x && y >= _y && y - _height <= _y;
	}

	private static XRect CreateEmptyRect()
	{
		return new XRect
		{
			_x = double.PositiveInfinity,
			_y = double.PositiveInfinity,
			_width = double.NegativeInfinity,
			_height = double.NegativeInfinity
		};
	}

	static XRect()
	{
		s_empty = CreateEmptyRect();
	}
}
