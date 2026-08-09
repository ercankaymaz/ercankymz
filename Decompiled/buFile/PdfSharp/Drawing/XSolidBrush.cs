using System;

namespace PdfSharp.Drawing;

public sealed class XSolidBrush : XBrush
{
	internal XColor _color;

	internal bool _overprint;

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
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XSolidBrush"));
			}
			_color = value;
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
				throw new ArgumentException(PSSR.CannotChangeImmutableObject("XSolidBrush"));
			}
			_overprint = value;
		}
	}

	public XSolidBrush()
	{
	}

	public XSolidBrush(XColor color)
		: this(color, immutable: false)
	{
	}

	internal XSolidBrush(XColor color, bool immutable)
	{
		_color = color;
		_immutable = immutable;
	}

	public XSolidBrush(XSolidBrush brush)
	{
		_color = brush.Color;
	}
}
