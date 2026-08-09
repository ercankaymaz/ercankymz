using System;

namespace PdfSharp.Drawing;

public sealed class XPen
{
	internal XColor _color;

	internal double _width;

	internal XLineJoin _lineJoin;

	internal XLineCap _lineCap;

	internal double _miterLimit;

	internal XDashStyle _dashStyle;

	internal double _dashOffset;

	internal double[] _dashPattern;

	internal bool _overprint;

	private bool _dirty = true;

	private readonly bool _immutable;

	public XColor Color
	{
		get
		{
			return _color;
		}
		set
		{
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			_dirty = _dirty || _color != value;
			_color = value;
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
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			_dirty = _dirty || _width != value;
			_width = value;
		}
	}

	public XLineJoin LineJoin
	{
		get
		{
			return _lineJoin;
		}
		set
		{
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			_dirty = _dirty || _lineJoin != value;
			_lineJoin = value;
		}
	}

	public XLineCap LineCap
	{
		get
		{
			return _lineCap;
		}
		set
		{
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			_dirty = _dirty || _lineCap != value;
			_lineCap = value;
		}
	}

	public double MiterLimit
	{
		get
		{
			return _miterLimit;
		}
		set
		{
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			_dirty = _dirty || _miterLimit != value;
			_miterLimit = value;
		}
	}

	public XDashStyle DashStyle
	{
		get
		{
			return _dashStyle;
		}
		set
		{
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			_dirty = _dirty || _dashStyle != value;
			_dashStyle = value;
		}
	}

	public double DashOffset
	{
		get
		{
			return _dashOffset;
		}
		set
		{
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			_dirty = _dirty || _dashOffset != value;
			_dashOffset = value;
		}
	}

	public double[] DashPattern
	{
		get
		{
			if (_dashPattern == null)
			{
				_dashPattern = new double[0];
			}
			return _dashPattern;
		}
		set
		{
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			int num = value.Length;
			for (int i = 0; i < num; i++)
			{
				if (value[i] <= 0.0)
				{
					throw new ArgumentException("Dash pattern value must greater than zero.");
				}
			}
			_dirty = true;
			_dashStyle = XDashStyle.Custom;
			_dashPattern = (double[])value.Clone();
		}
	}

	public bool Overprint
	{
		get
		{
			return _overprint;
		}
		set
		{
			if (_immutable)
			{
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
			}
			_overprint = value;
		}
	}

	public XPen(XColor color)
		: this(color, 1.0, immutable: false)
	{
	}

	public XPen(XColor color, double width)
		: this(color, width, immutable: false)
	{
	}

	internal XPen(XColor color, double width, bool immutable)
	{
		_color = color;
		_width = width;
		_lineJoin = XLineJoin.Miter;
		_lineCap = XLineCap.Flat;
		_dashStyle = XDashStyle.Solid;
		_dashOffset = 0.0;
		_immutable = immutable;
	}

	public XPen(XPen pen)
	{
		_color = pen._color;
		_width = pen._width;
		_lineJoin = pen._lineJoin;
		_lineCap = pen._lineCap;
		_dashStyle = pen._dashStyle;
		_dashOffset = pen._dashOffset;
		_dashPattern = pen._dashPattern;
		if (_dashPattern != null)
		{
			_dashPattern = (double[])_dashPattern.Clone();
		}
	}

	public XPen Clone()
	{
		return new XPen(this);
	}
}
