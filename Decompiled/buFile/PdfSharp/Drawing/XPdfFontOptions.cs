using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing;

public class XPdfFontOptions
{
	private readonly PdfFontEncoding _fontEncoding;

	public PdfFontEmbedding FontEmbedding => PdfFontEmbedding.Always;

	public PdfFontEncoding FontEncoding => _fontEncoding;

	public static XPdfFontOptions WinAnsiDefault => new XPdfFontOptions(PdfFontEncoding.WinAnsi);

	public static XPdfFontOptions UnicodeDefault => new XPdfFontOptions(PdfFontEncoding.Unicode);

	internal XPdfFontOptions()
	{
	}

	[Obsolete("Must not specify an embedding option anymore.")]
	public XPdfFontOptions(PdfFontEncoding encoding, PdfFontEmbedding embedding)
	{
		_fontEncoding = encoding;
	}

	public XPdfFontOptions(PdfFontEncoding encoding)
	{
		_fontEncoding = encoding;
	}

	[Obsolete("Must not specify an embedding option anymore.")]
	public XPdfFontOptions(PdfFontEmbedding embedding)
	{
		_fontEncoding = PdfFontEncoding.WinAnsi;
	}
}
