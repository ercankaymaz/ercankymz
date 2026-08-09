#define DEBUG
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf.Internal;

internal static class PdfEncoders
{
	private static Encoding _rawEncoding;

	private static Encoding _rawUnicodeEncoding;

	private static Encoding _winAnsiEncoding;

	private static Encoding _docEncoding;

	private static Encoding _unicodeEncoding;

	private static byte[] docencode_______ = new byte[256]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
		20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
		30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
		40, 41, 42, 43, 44, 45, 46, 47, 48, 49,
		50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
		60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
		70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
		80, 81, 82, 83, 84, 85, 86, 87, 88, 89,
		90, 91, 92, 93, 94, 95, 96, 97, 98, 99,
		100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
		110, 111, 112, 113, 114, 115, 116, 117, 118, 119,
		120, 121, 122, 123, 124, 125, 126, 127, 160, 127,
		130, 131, 132, 133, 134, 135, 136, 137, 138, 139,
		140, 141, 142, 143, 144, 145, 146, 147, 148, 149,
		138, 140, 152, 153, 154, 155, 156, 157, 158, 159,
		160, 161, 162, 163, 164, 165, 166, 167, 168, 169,
		170, 171, 172, 173, 174, 175, 176, 177, 178, 179,
		180, 181, 182, 183, 184, 185, 186, 187, 188, 189,
		190, 191, 192, 193, 194, 195, 196, 197, 198, 199,
		200, 201, 202, 203, 204, 205, 206, 207, 208, 209,
		210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
		220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
		230, 231, 232, 233, 234, 235, 236, 237, 238, 239,
		240, 241, 242, 243, 244, 245, 246, 247, 248, 249,
		250, 251, 252, 253, 254, 255
	};

	public static Encoding RawEncoding => _rawEncoding ?? (_rawEncoding = new RawEncoding());

	public static Encoding RawUnicodeEncoding => _rawUnicodeEncoding ?? (_rawUnicodeEncoding = new RawUnicodeEncoding());

	public static Encoding WinAnsiEncoding
	{
		get
		{
			if (_winAnsiEncoding == null)
			{
				_winAnsiEncoding = Encoding.GetEncoding(1252);
			}
			return _winAnsiEncoding;
		}
	}

	public static Encoding DocEncoding => _docEncoding ?? (_docEncoding = new DocEncoding());

	public static Encoding UnicodeEncoding => _unicodeEncoding ?? (_unicodeEncoding = Encoding.Unicode);

	public static string ToStringLiteral(string text, PdfStringEncoding encoding, PdfStandardSecurityHandler securityHandler)
	{
		if (string.IsNullOrEmpty(text))
		{
			return "()";
		}
		byte[] array = FormatStringLiteral(encoding switch
		{
			PdfStringEncoding.RawEncoding => RawEncoding.GetBytes(text), 
			PdfStringEncoding.WinAnsiEncoding => WinAnsiEncoding.GetBytes(text), 
			PdfStringEncoding.PDFDocEncoding => DocEncoding.GetBytes(text), 
			PdfStringEncoding.Unicode => RawUnicodeEncoding.GetBytes(text), 
			_ => throw new NotImplementedException(encoding.ToString()), 
		}, encoding == PdfStringEncoding.Unicode, prefix: true, hex: false, securityHandler);
		return RawEncoding.GetString(array, 0, array.Length);
	}

	public static string ToStringLiteral(byte[] bytes, bool unicode, PdfStandardSecurityHandler securityHandler)
	{
		if (bytes == null || bytes.Length == 0)
		{
			return "()";
		}
		byte[] array = FormatStringLiteral(bytes, unicode, prefix: true, hex: false, securityHandler);
		return RawEncoding.GetString(array, 0, array.Length);
	}

	public static string ToHexStringLiteral(string text, PdfStringEncoding encoding, PdfStandardSecurityHandler securityHandler)
	{
		if (string.IsNullOrEmpty(text))
		{
			return "<>";
		}
		byte[] array = FormatStringLiteral(encoding switch
		{
			PdfStringEncoding.RawEncoding => RawEncoding.GetBytes(text), 
			PdfStringEncoding.WinAnsiEncoding => WinAnsiEncoding.GetBytes(text), 
			PdfStringEncoding.PDFDocEncoding => DocEncoding.GetBytes(text), 
			PdfStringEncoding.Unicode => RawUnicodeEncoding.GetBytes(text), 
			_ => throw new NotImplementedException(encoding.ToString()), 
		}, encoding == PdfStringEncoding.Unicode, prefix: true, hex: true, securityHandler);
		return RawEncoding.GetString(array, 0, array.Length);
	}

	public static string ToHexStringLiteral(byte[] bytes, bool unicode, PdfStandardSecurityHandler securityHandler)
	{
		if (bytes == null || bytes.Length == 0)
		{
			return "<>";
		}
		byte[] array = FormatStringLiteral(bytes, unicode, prefix: true, hex: true, securityHandler);
		return RawEncoding.GetString(array, 0, array.Length);
	}

	public static byte[] FormatStringLiteral(byte[] bytes, bool unicode, bool prefix, bool hex, PdfStandardSecurityHandler securityHandler)
	{
		if (bytes == null || bytes.Length == 0)
		{
			return (!hex) ? new byte[2] { 40, 41 } : new byte[2] { 60, 62 };
		}
		Debug.Assert(!unicode || bytes.Length % 2 == 0, "Odd number of bytes in Unicode string.");
		byte[] bytes2 = null;
		bool flag = false;
		if (securityHandler != null && !hex)
		{
			bytes2 = bytes;
			bytes = (byte[])bytes.Clone();
			bytes = securityHandler.EncryptBytes(bytes);
			flag = true;
		}
		int num = bytes.Length;
		StringBuilder stringBuilder = new StringBuilder();
		if (!unicode)
		{
			if (!hex)
			{
				stringBuilder.Append("(");
				for (int i = 0; i < num; i++)
				{
					char c = (char)bytes[i];
					if (c < ' ')
					{
						switch (c)
						{
						case '\n':
							stringBuilder.Append("\\n");
							continue;
						case '\r':
							stringBuilder.Append("\\r");
							continue;
						case '\t':
							stringBuilder.Append("\\t");
							continue;
						case '\b':
							stringBuilder.Append("\\b");
							continue;
						}
						if (1 == 0)
						{
							stringBuilder.Append("\\0");
							stringBuilder.Append((char)(c % 8 + 48));
							stringBuilder.Append((char)(c / 8 + 48));
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
					else
					{
						switch (c)
						{
						case '(':
							stringBuilder.Append("\\(");
							break;
						case ')':
							stringBuilder.Append("\\)");
							break;
						case '\\':
							stringBuilder.Append("\\\\");
							break;
						default:
							stringBuilder.Append(c);
							break;
						}
					}
				}
				stringBuilder.Append(')');
			}
			else
			{
				stringBuilder.Append('<');
				for (int j = 0; j < num; j++)
				{
					stringBuilder.AppendFormat("{0:X2}", bytes[j]);
				}
				stringBuilder.Append('>');
			}
		}
		else
		{
			if (!hex)
			{
				if (flag)
				{
					return FormatStringLiteral(bytes2, unicode, prefix, hex: true, securityHandler);
				}
				return FormatStringLiteral(bytes, unicode: true, prefix, hex: true, null);
			}
			if (securityHandler != null && prefix)
			{
				byte[] array = new byte[bytes.Length + 2];
				array[0] = 254;
				array[1] = byte.MaxValue;
				Array.Copy(bytes, 0, array, 2, bytes.Length);
				array = securityHandler.EncryptBytes(array);
				flag = true;
				stringBuilder.Append("<");
				int num2 = array.Length;
				for (int k = 0; k < num2; k += 2)
				{
					stringBuilder.AppendFormat("{0:X2}{1:X2}", array[k], array[k + 1]);
					if (k != 0 && k % 48 == 0)
					{
						stringBuilder.Append("\n");
					}
				}
				stringBuilder.Append(">");
			}
			else
			{
				stringBuilder.Append(prefix ? "<FEFF" : "<");
				for (int l = 0; l < num; l += 2)
				{
					stringBuilder.AppendFormat("{0:X2}{1:X2}", bytes[l], bytes[l + 1]);
					if (l != 0 && l % 48 == 0)
					{
						stringBuilder.Append("\n");
					}
				}
				stringBuilder.Append(">");
			}
		}
		return RawEncoding.GetBytes(stringBuilder.ToString());
	}

	public static string Format(string format, params object[] args)
	{
		return string.Format(CultureInfo.InvariantCulture, format, args);
	}

	public static string ToString(double val)
	{
		return val.ToString("0.###", CultureInfo.InvariantCulture);
	}

	public static string ToString(XColor color, PdfColorMode colorMode)
	{
		if (colorMode == PdfColorMode.Undefined)
		{
			colorMode = ((color.ColorSpace != XColorSpace.Cmyk) ? PdfColorMode.Rgb : PdfColorMode.Cmyk);
		}
		PdfColorMode pdfColorMode = colorMode;
		PdfColorMode pdfColorMode2 = pdfColorMode;
		if (pdfColorMode2 == PdfColorMode.Cmyk)
		{
			return string.Format(CultureInfo.InvariantCulture, "{0:0.###} {1:0.###} {2:0.###} {3:0.###}", color.C, color.M, color.Y, color.K);
		}
		return string.Format(CultureInfo.InvariantCulture, "{0:0.###} {1:0.###} {2:0.###}", (double)(int)color.R / 255.0, (double)(int)color.G / 255.0, (double)(int)color.B / 255.0);
	}

	public static string ToString(XMatrix matrix)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####}", matrix.M11, matrix.M12, matrix.M21, matrix.M22, matrix.OffsetX, matrix.OffsetY);
	}
}
