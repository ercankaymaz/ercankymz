using System;
using System.ComponentModel;

namespace PdfSharp.Drawing.BarCodes;

public abstract class BarCode : CodeBase
{
	private TextLocation _textLocation;

	private int _dataLength;

	private char _startChar;

	private char _endChar;

	private bool _turboBit;

	public virtual double WideNarrowRatio
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	public TextLocation TextLocation
	{
		get
		{
			return _textLocation;
		}
		set
		{
			_textLocation = value;
		}
	}

	public int DataLength
	{
		get
		{
			return _dataLength;
		}
		set
		{
			_dataLength = value;
		}
	}

	public char StartChar
	{
		get
		{
			return _startChar;
		}
		set
		{
			_startChar = value;
		}
	}

	public char EndChar
	{
		get
		{
			return _endChar;
		}
		set
		{
			_endChar = value;
		}
	}

	public virtual bool TurboBit
	{
		get
		{
			return _turboBit;
		}
		set
		{
			_turboBit = value;
		}
	}

	public BarCode(string text, XSize size, CodeDirection direction)
		: base(text, size, direction)
	{
		base.Text = text;
		base.Size = size;
		base.Direction = direction;
	}

	public static BarCode FromType(CodeType type, string text, XSize size, CodeDirection direction)
	{
		return type switch
		{
			CodeType.Code2of5Interleaved => new Code2of5Interleaved(text, size, direction), 
			CodeType.Code3of9Standard => new Code3of9Standard(text, size, direction), 
			_ => throw new InvalidEnumArgumentException("type", (int)type, typeof(CodeType)), 
		};
	}

	public static BarCode FromType(CodeType type, string text, XSize size)
	{
		return FromType(type, text, size, CodeDirection.LeftToRight);
	}

	public static BarCode FromType(CodeType type, string text)
	{
		return FromType(type, text, XSize.Empty, CodeDirection.LeftToRight);
	}

	public static BarCode FromType(CodeType type)
	{
		return FromType(type, string.Empty, XSize.Empty, CodeDirection.LeftToRight);
	}

	internal virtual void InitRendering(BarCodeRenderInfo info)
	{
		if (base.Text == null)
		{
			throw new InvalidOperationException(BcgSR.BarCodeNotSet);
		}
		if (base.Size.IsEmpty)
		{
			throw new InvalidOperationException(BcgSR.EmptyBarCodeSize);
		}
	}

	protected internal abstract void Render(XGraphics gfx, XBrush brush, XFont font, XPoint position);
}
