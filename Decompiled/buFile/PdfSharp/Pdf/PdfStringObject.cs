using System.Diagnostics;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfStringObject : PdfObject
{
	private PdfStringFlags _flags;

	private string _value;

	public int Length => (_value != null) ? _value.Length : 0;

	public PdfStringEncoding Encoding
	{
		get
		{
			return (PdfStringEncoding)(_flags & PdfStringFlags.EncodingMask);
		}
		set
		{
			_flags = (PdfStringFlags)((int)(_flags & ~PdfStringFlags.EncodingMask) | (int)(value & (PdfStringEncoding)15));
		}
	}

	public bool HexLiteral
	{
		get
		{
			return (_flags & PdfStringFlags.HexLiteral) != 0;
		}
		set
		{
			_flags = (value ? (_flags | PdfStringFlags.HexLiteral) : (_flags & ~PdfStringFlags.HexLiteral));
		}
	}

	public string Value
	{
		get
		{
			return _value ?? "";
		}
		set
		{
			_value = value ?? "";
		}
	}

	internal byte[] EncryptionValue
	{
		get
		{
			return (_value == null) ? new byte[0] : PdfEncoders.RawEncoding.GetBytes(_value);
		}
		set
		{
			_value = PdfEncoders.RawEncoding.GetString(value, 0, value.Length);
		}
	}

	public PdfStringObject()
	{
		_flags = PdfStringFlags.RawEncoding;
	}

	public PdfStringObject(PdfDocument document, string value)
		: base(document)
	{
		_value = value;
		_flags = PdfStringFlags.RawEncoding;
	}

	public PdfStringObject(string value, PdfStringEncoding encoding)
	{
		_value = value;
		_flags = (PdfStringFlags)encoding;
	}

	internal PdfStringObject(string value, PdfStringFlags flags)
	{
		_value = value;
		_flags = flags;
	}

	public override string ToString()
	{
		return _value;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.WriteBeginObject(this);
		writer.Write(new PdfString(_value, _flags));
		writer.WriteEndObject();
	}
}
