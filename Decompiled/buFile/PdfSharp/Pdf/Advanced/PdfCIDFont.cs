using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced;

internal class PdfCIDFont : PdfFont
{
	public new sealed class Keys : PdfFont.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
		public new const string Type = "/Type";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public new const string Subtype = "/Subtype";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public new const string BaseFont = "/BaseFont";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string CIDSystemInfo = "/CIDSystemInfo";

		[KeyInfo(KeyType.Dictionary | KeyType.MustBeIndirect, typeof(PdfFontDescriptor))]
		public new const string FontDescriptor = "/FontDescriptor";

		[KeyInfo(KeyType.Integer)]
		public const string DW = "/DW";

		[KeyInfo(KeyType.Array, typeof(PdfArray))]
		public const string W = "/W";

		[KeyInfo(KeyType.Array)]
		public const string DW2 = "/DW2";

		[KeyInfo(KeyType.Array, typeof(PdfArray))]
		public const string W2 = "/W2";

		[KeyInfo(KeyType.Dictionary | KeyType.StreamOrName)]
		public const string CIDToGIDMap = "/CIDToGIDMap";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

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

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfCIDFont(PdfDocument document)
		: base(document)
	{
	}

	public PdfCIDFont(PdfDocument document, PdfFontDescriptor fontDescriptor, XFont font)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Font");
		base.Elements.SetName("/Subtype", "/CIDFontType2");
		PdfDictionary pdfDictionary = new PdfDictionary();
		pdfDictionary.Elements.SetString("/Ordering", "Identity");
		pdfDictionary.Elements.SetString("/Registry", "Adobe");
		pdfDictionary.Elements.SetInteger("/Supplement", 0);
		base.Elements.SetValue("/CIDSystemInfo", pdfDictionary);
		base.FontDescriptor = fontDescriptor;
		Owner._irefTable.Add(fontDescriptor);
		base.Elements["/FontDescriptor"] = fontDescriptor.Reference;
		FontEncoding = font.PdfOptions.FontEncoding;
	}

	public PdfCIDFont(PdfDocument document, PdfFontDescriptor fontDescriptor, byte[] fontData)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Font");
		base.Elements.SetName("/Subtype", "/CIDFontType2");
		PdfDictionary pdfDictionary = new PdfDictionary();
		pdfDictionary.Elements.SetString("/Ordering", "Identity");
		pdfDictionary.Elements.SetString("/Registry", "Adobe");
		pdfDictionary.Elements.SetInteger("/Supplement", 0);
		base.Elements.SetValue("/CIDSystemInfo", pdfDictionary);
		base.FontDescriptor = fontDescriptor;
		Owner._irefTable.Add(fontDescriptor);
		base.Elements["/FontDescriptor"] = fontDescriptor.Reference;
		FontEncoding = PdfFontEncoding.Unicode;
	}

	internal override void PrepareForSave()
	{
		base.PrepareForSave();
		OpenTypeFontface openTypeFontface = null;
		openTypeFontface = ((base.FontDescriptor._descriptor.FontFace.loca != null) ? base.FontDescriptor._descriptor.FontFace.CreateFontSubSet(_cmapInfo.GlyphIndices, cidFont: true) : base.FontDescriptor._descriptor.FontFace);
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
	}
}
