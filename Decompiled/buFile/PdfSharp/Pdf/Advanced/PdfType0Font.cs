#define DEBUG
using System.Diagnostics;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfType0Font : PdfFont
{
	public new sealed class Keys : PdfFont.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
		public new const string Type = "/Type";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public new const string Subtype = "/Subtype";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public new const string BaseFont = "/BaseFont";

		[KeyInfo(KeyType.StreamOrName | KeyType.Required)]
		public const string Encoding = "/Encoding";

		[KeyInfo(KeyType.Array | KeyType.Required)]
		public const string DescendantFonts = "/DescendantFonts";

		[KeyInfo(KeyType.Stream | KeyType.Optional)]
		public const string ToUnicode = "/ToUnicode";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta
		{
			get
			{
				if (_meta == null)
				{
					_meta = KeysBase.CreateMeta(typeof(Keys));
				}
				return _meta;
			}
		}
	}

	private XPdfFontOptions _fontOptions;

	private readonly PdfCIDFont _descendantFont;

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

	internal PdfCIDFont DescendantFont => _descendantFont;

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfType0Font(PdfDocument document)
		: base(document)
	{
	}

	public PdfType0Font(PdfDocument document, XFont font, bool vertical)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Font");
		base.Elements.SetName("/Subtype", "/Type0");
		base.Elements.SetName("/Encoding", vertical ? "/Identity-V" : "/Identity-H");
		OpenTypeDescriptor descriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptorFor(font);
		base.FontDescriptor = new PdfFontDescriptor(document, descriptor);
		_fontOptions = font.PdfOptions;
		Debug.Assert(_fontOptions != null);
		_cmapInfo = new CMapInfo(descriptor);
		_descendantFont = new PdfCIDFont(document, base.FontDescriptor, font);
		_descendantFont.CMapInfo = _cmapInfo;
		_toUnicode = new PdfToUnicodeMap(document, _cmapInfo);
		document.Internals.AddObject(_toUnicode);
		base.Elements.Add("/ToUnicode", _toUnicode);
		BaseFont = font.GlyphTypeface.GetBaseName();
		BaseFont = PdfFont.CreateEmbeddedFontSubsetName(BaseFont);
		base.FontDescriptor.FontName = BaseFont;
		_descendantFont.BaseFont = BaseFont;
		PdfArray pdfArray = new PdfArray(document);
		Owner._irefTable.Add(_descendantFont);
		pdfArray.Elements.Add(_descendantFont.Reference);
		base.Elements["/DescendantFonts"] = pdfArray;
	}

	public PdfType0Font(PdfDocument document, string idName, byte[] fontData, bool vertical)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Font");
		base.Elements.SetName("/Subtype", "/Type0");
		base.Elements.SetName("/Encoding", vertical ? "/Identity-V" : "/Identity-H");
		OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(idName, fontData);
		base.FontDescriptor = new PdfFontDescriptor(document, openTypeDescriptor);
		_fontOptions = new XPdfFontOptions(PdfFontEncoding.Unicode);
		Debug.Assert(_fontOptions != null);
		_cmapInfo = new CMapInfo(openTypeDescriptor);
		_descendantFont = new PdfCIDFont(document, base.FontDescriptor, fontData);
		_descendantFont.CMapInfo = _cmapInfo;
		_toUnicode = new PdfToUnicodeMap(document, _cmapInfo);
		document.Internals.AddObject(_toUnicode);
		base.Elements.Add("/ToUnicode", _toUnicode);
		BaseFont = openTypeDescriptor.FontName;
		if (!BaseFont.Contains("+"))
		{
			BaseFont = PdfFont.CreateEmbeddedFontSubsetName(BaseFont);
		}
		base.FontDescriptor.FontName = BaseFont;
		_descendantFont.BaseFont = BaseFont;
		PdfArray pdfArray = new PdfArray(document);
		Owner._irefTable.Add(_descendantFont);
		pdfArray.Elements.Add(_descendantFont.Reference);
		base.Elements["/DescendantFonts"] = pdfArray;
	}

	internal override void PrepareForSave()
	{
		base.PrepareForSave();
		OpenTypeDescriptor descriptor = base.FontDescriptor._descriptor;
		StringBuilder stringBuilder = new StringBuilder("[");
		if (_cmapInfo != null)
		{
			int[] glyphIndices = _cmapInfo.GetGlyphIndices();
			int num = glyphIndices.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = descriptor.GlyphIndexToPdfWidth(glyphIndices[i]);
			}
			for (int j = 0; j < num; j++)
			{
				stringBuilder.AppendFormat("{0}[{1}]", glyphIndices[j], array[j]);
			}
			stringBuilder.Append("]");
			_descendantFont.Elements.SetValue("/W", new PdfLiteral(stringBuilder.ToString()));
		}
		_descendantFont.PrepareForSave();
		_toUnicode.PrepareForSave();
	}
}
