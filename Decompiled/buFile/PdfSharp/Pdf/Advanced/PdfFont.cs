#define DEBUG
using System;
using System.Diagnostics;
using System.Text;
using PdfSharp.Fonts;

namespace PdfSharp.Pdf.Advanced;

public class PdfFont : PdfDictionary
{
	public class Keys : KeysBase
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public const string Subtype = "/Subtype";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public const string BaseFont = "/BaseFont";

		[KeyInfo(KeyType.Dictionary | KeyType.MustBeIndirect, typeof(PdfFontDescriptor))]
		public const string FontDescriptor = "/FontDescriptor";
	}

	private PdfFontDescriptor _fontDescriptor;

	internal PdfFontEncoding FontEncoding;

	internal CMapInfo _cmapInfo;

	internal PdfToUnicodeMap _toUnicode;

	internal PdfFontDescriptor FontDescriptor
	{
		get
		{
			Debug.Assert(_fontDescriptor != null);
			return _fontDescriptor;
		}
		set
		{
			_fontDescriptor = value;
		}
	}

	public bool IsSymbolFont => _fontDescriptor.IsSymbolFont;

	internal CMapInfo CMapInfo
	{
		get
		{
			return _cmapInfo;
		}
		set
		{
			_cmapInfo = value;
		}
	}

	internal PdfToUnicodeMap ToUnicodeMap
	{
		get
		{
			return _toUnicode;
		}
		set
		{
			_toUnicode = value;
		}
	}

	public PdfFont(PdfDocument document)
		: base(document)
	{
	}

	internal void AddChars(string text)
	{
		if (_cmapInfo != null)
		{
			_cmapInfo.AddChars(text);
		}
	}

	internal void AddGlyphIndices(string glyphIndices)
	{
		if (_cmapInfo != null)
		{
			_cmapInfo.AddGlyphIndices(glyphIndices);
		}
	}

	internal static string CreateEmbeddedFontSubsetName(string name)
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		byte[] array = Guid.NewGuid().ToByteArray();
		for (int i = 0; i < 6; i++)
		{
			stringBuilder.Append((char)(65 + array[i] % 26));
		}
		stringBuilder.Append('+');
		if (name.StartsWith("/"))
		{
			stringBuilder.Append(name.Substring(1));
		}
		else
		{
			stringBuilder.Append(name);
		}
		return stringBuilder.ToString();
	}
}
