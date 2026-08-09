#define DEBUG
using System;
using System.Diagnostics;
using System.Text;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfString : PdfItem
{
	private readonly PdfStringFlags _flags;

	private string _value;

	private static readonly char[] Encode = new char[256]
	{
		'\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a', '\b', '\t',
		'\n', '\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0011', '\u0012', '\u0013',
		'\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019', '\u001a', '\u001b', '\u001c', '\u001d',
		'\u001e', '\u001f', ' ', '!', '"', '#', '$', '%', '&', '\'',
		'(', ')', '*', '+', ',', '-', '.', '/', '0', '1',
		'2', '3', '4', '5', '6', '7', '8', '9', ':', ';',
		'<', '=', '>', '?', '@', 'A', 'B', 'C', 'D', 'E',
		'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
		'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
		'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c',
		'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
		'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
		'x', 'y', 'z', '{', '|', '}', '~', '\u007f', '•', '†',
		'‡', '…', '—', '–', 'ƒ', '⁄', '‹', '›', '−', '‰',
		'„', '“', '”', '‘', '’', '‚', '™', 'ﬁ', 'ﬂ', 'Ł',
		'Œ', 'Š', 'Ÿ', 'Ž', 'ı', 'ł', 'œ', 'š', 'ž', '\ufffd',
		'€', '¡', '¢', '£', '¤', '¥', '¦', '§', '\u00a8', '©',
		'ª', '«', '¬', '\u00ad', '®', '\u00af', '°', '±', '²', '³',
		'\u00b4', 'µ', '¶', '·', '\u00b8', '¹', 'º', '»', '¼', '½',
		'¾', '¿', 'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', 'Æ', 'Ç',
		'È', 'É', 'Ê', 'Ë', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ñ',
		'Ò', 'Ó', 'Ô', 'Õ', 'Ö', '×', 'Ø', 'Ù', 'Ú', 'Û',
		'Ü', 'Ý', 'Þ', 'ß', 'à', 'á', 'â', 'ã', 'ä', 'å',
		'æ', 'ç', 'è', 'é', 'ê', 'ë', 'ì', 'í', 'î', 'ï',
		'ð', 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø', 'ù',
		'ú', 'û', 'ü', 'ý', 'þ', 'ÿ'
	};

	public int Length => (_value != null) ? _value.Length : 0;

	public PdfStringEncoding Encoding => (PdfStringEncoding)(_flags & PdfStringFlags.EncodingMask);

	public bool HexLiteral => (_flags & PdfStringFlags.HexLiteral) != 0;

	internal PdfStringFlags Flags => _flags;

	public string Value => _value ?? "";

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

	public PdfString()
	{
	}

	public PdfString(string value)
	{
		if (!IsRawEncoding(value))
		{
			_flags = PdfStringFlags.Unicode;
		}
		_value = value;
	}

	public PdfString(string value, PdfStringEncoding encoding)
	{
		switch (encoding)
		{
		case PdfStringEncoding.RawEncoding:
			CheckRawEncoding(value);
			break;
		case PdfStringEncoding.WinAnsiEncoding:
			CheckRawEncoding(value);
			break;
		default:
			throw new ArgumentOutOfRangeException("encoding");
		case PdfStringEncoding.StandardEncoding:
		case PdfStringEncoding.PDFDocEncoding:
		case PdfStringEncoding.MacRomanEncoding:
		case PdfStringEncoding.Unicode:
			break;
		}
		_value = value;
		_flags = (PdfStringFlags)encoding;
	}

	internal PdfString(string value, PdfStringFlags flags)
	{
		_value = value;
		_flags = flags;
	}

	public override string ToString()
	{
		PdfStringEncoding encoding = (PdfStringEncoding)(_flags & PdfStringFlags.EncodingMask);
		return ((_flags & PdfStringFlags.HexLiteral) == 0) ? PdfEncoders.ToStringLiteral(_value, encoding, null) : PdfEncoders.ToHexStringLiteral(_value, encoding, null);
	}

	public string ToStringFromPdfDocEncoded()
	{
		int length = _value.Length;
		char[] array = new char[length];
		for (int i = 0; i < length; i++)
		{
			char c = _value[i];
			if (c <= 'ÿ')
			{
				array[i] = Encode[(uint)c];
				continue;
			}
			throw new InvalidOperationException("DocEncoded string contains char greater 255.");
		}
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int j = 0; j < length; j++)
		{
			stringBuilder.Append(array[j]);
		}
		return stringBuilder.ToString();
	}

	private static void CheckRawEncoding(string s)
	{
		if (!string.IsNullOrEmpty(s))
		{
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				Debug.Assert(s[i] < 'Ā', "RawString contains invalid character.");
			}
		}
	}

	private static bool IsRawEncoding(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return true;
		}
		int length = s.Length;
		for (int i = 0; i < length; i++)
		{
			if (s[i] >= 'Ā')
			{
				return false;
			}
		}
		return true;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.Write(this);
	}
}
