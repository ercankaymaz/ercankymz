#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfFontTable(PdfDocument document) : PdfResourceTable(document)
{
	private readonly Dictionary<string, PdfFont> _fonts = new Dictionary<string, PdfFont>();

	public PdfFont GetFont(XFont font)
	{
		string text = font.Selector;
		if (text == null)
		{
			text = (font.Selector = ComputeKey(font));
		}
		if (!_fonts.TryGetValue(text, out var value))
		{
			value = ((!font.Unicode) ? ((PdfFont)new PdfTrueTypeFont(base.Owner, font)) : ((PdfFont)new PdfType0Font(base.Owner, font, font.IsVertical)));
			Debug.Assert(value.Owner == base.Owner);
			_fonts[text] = value;
		}
		return value;
	}

	public PdfFont GetFont(string idName, byte[] fontData)
	{
		Debug.Assert(condition: false);
		string key = null;
		if (!_fonts.TryGetValue(key, out var value))
		{
			value = new PdfType0Font(base.Owner, idName, fontData, vertical: false);
			Debug.Assert(value.Owner == base.Owner);
			_fonts[key] = value;
		}
		return value;
	}

	public PdfFont TryGetFont(string idName)
	{
		Debug.Assert(condition: false);
		string key = null;
		_fonts.TryGetValue(key, out var value);
		return value;
	}

	internal static string ComputeKey(XFont font)
	{
		XGlyphTypeface glyphTypeface = font.GlyphTypeface;
		return glyphTypeface.Fontface.FullFaceName.ToLowerInvariant() + (glyphTypeface.IsBold ? "/b" : "") + (glyphTypeface.IsItalic ? "/i" : "") + font.Unicode;
	}

	public void PrepareForSave()
	{
		foreach (PdfFont value in _fonts.Values)
		{
			value.PrepareForSave();
		}
	}
}
