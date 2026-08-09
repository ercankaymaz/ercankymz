#define DEBUG
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced;

internal class PdfTrueTypeFont : PdfFont
{
	public new sealed class Keys : PdfFont.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
		public new const string Type = "/Type";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public new const string Subtype = "/Subtype";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string Name = "/Name";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public new const string BaseFont = "/BaseFont";

		[KeyInfo(KeyType.Integer)]
		public const string FirstChar = "/FirstChar";

		[KeyInfo(KeyType.Integer)]
		public const string LastChar = "/LastChar";

		[KeyInfo(KeyType.Array, typeof(PdfArray))]
		public const string Widths = "/Widths";

		[KeyInfo(KeyType.Dictionary | KeyType.MustBeIndirect, typeof(PdfFontDescriptor))]
		public new const string FontDescriptor = "/FontDescriptor";

		[KeyInfo(KeyType.Dictionary)]
		public const string Encoding = "/Encoding";

		[KeyInfo(KeyType.Stream | KeyType.Optional)]
		public const string ToUnicode = "/ToUnicode";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private readonly XPdfFontOptions _fontOptions;

	private XPdfFontOptions FontOptions => _fontOptions;

	public string BaseFont
	{
		get
		{
			return base.Elements.GetName("/BaseFont");
		}
		set
		{
			base.Elements.SetName("/BaseFont", value);
		}
	}

	public int FirstChar
	{
		get
		{
			return base.Elements.GetInteger("/FirstChar");
		}
		set
		{
			base.Elements.SetInteger("/FirstChar", value);
		}
	}

	public int LastChar
	{
		get
		{
			return base.Elements.GetInteger("/LastChar");
		}
		set
		{
			base.Elements.SetInteger("/LastChar", value);
		}
	}

	public PdfArray Widths => (PdfArray)base.Elements.GetValue("/Widths", VCF.Create);

	public string Encoding
	{
		get
		{
			return base.Elements.GetName("/Encoding");
		}
		set
		{
			base.Elements.SetName("/Encoding", value);
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfTrueTypeFont(PdfDocument document)
		: base(document)
	{
	}

	public PdfTrueTypeFont(PdfDocument document, XFont font)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Font");
		base.Elements.SetName("/Subtype", "/TrueType");
		OpenTypeDescriptor descriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptorFor(font);
		base.FontDescriptor = new PdfFontDescriptor(document, descriptor);
		_fontOptions = font.PdfOptions;
		Debug.Assert(_fontOptions != null);
		_cmapInfo = new CMapInfo(descriptor);
		BaseFont = font.GlyphTypeface.GetBaseName();
		if (_fontOptions.FontEmbedding == PdfFontEmbedding.Always)
		{
			BaseFont = PdfFont.CreateEmbeddedFontSubsetName(BaseFont);
		}
		base.FontDescriptor.FontName = BaseFont;
		Debug.Assert(_fontOptions.FontEncoding == PdfFontEncoding.WinAnsi);
		if (!base.IsSymbolFont)
		{
			Encoding = "/WinAnsiEncoding";
		}
		Owner._irefTable.Add(base.FontDescriptor);
		base.Elements["/FontDescriptor"] = base.FontDescriptor.Reference;
		FontEncoding = font.PdfOptions.FontEncoding;
	}

	internal override void PrepareForSave()
	{
		base.PrepareForSave();
		OpenTypeFontface openTypeFontface = base.FontDescriptor._descriptor.FontFace.CreateFontSubSet(_cmapInfo.GlyphIndices, cidFont: false);
		byte[] array = openTypeFontface.FontSource.Bytes;
		PdfDictionary pdfDictionary = new PdfDictionary(Owner);
		Owner.Internals.AddObject(pdfDictionary);
		base.FontDescriptor.Elements["/FontFile2"] = pdfDictionary.Reference;
		pdfDictionary.Elements["/Length1"] = new PdfInteger(array.Length);
		if (!Owner.Options.NoCompression)
		{
			array = Filtering.FlateDecode.Encode(array, _document.Options.FlateEncodeMode);
			pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
		}
		pdfDictionary.Elements["/Length"] = new PdfInteger(array.Length);
		pdfDictionary.CreateStream(array);
		FirstChar = 0;
		LastChar = 255;
		PdfArray widths = Widths;
		for (int i = 0; i < 256; i++)
		{
			widths.Elements.Add(new PdfInteger(base.FontDescriptor._descriptor.Widths[i]));
		}
	}
}
