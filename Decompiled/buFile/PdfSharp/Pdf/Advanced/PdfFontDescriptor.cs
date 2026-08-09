using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfFontDescriptor : PdfDictionary
{
	public sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "FontDescriptor")]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public const string FontName = "/FontName";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string FontFamily = "/FontFamily";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string FontStretch = "/FontStretch";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string FontWeight = "/FontWeight";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string Flags = "/Flags";

		[KeyInfo(KeyType.Rectangle | KeyType.Required)]
		public const string FontBBox = "/FontBBox";

		[KeyInfo(KeyType.Real | KeyType.Required)]
		public const string ItalicAngle = "/ItalicAngle";

		[KeyInfo(KeyType.Real | KeyType.Required)]
		public const string Ascent = "/Ascent";

		[KeyInfo(KeyType.Real | KeyType.Required)]
		public const string Descent = "/Descent";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string Leading = "/Leading";

		[KeyInfo(KeyType.Real | KeyType.Required)]
		public const string CapHeight = "/CapHeight";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string XHeight = "/XHeight";

		[KeyInfo(KeyType.Real | KeyType.Required)]
		public const string StemV = "/StemV";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string StemH = "/StemH";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string AvgWidth = "/AvgWidth";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string MaxWidth = "/MaxWidth";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string MissingWidth = "/MissingWidth";

		[KeyInfo(KeyType.Stream | KeyType.Optional)]
		public const string FontFile = "/FontFile";

		[KeyInfo(KeyType.Stream | KeyType.Optional)]
		public const string FontFile2 = "/FontFile2";

		[KeyInfo(KeyType.Stream | KeyType.Optional)]
		public const string FontFile3 = "/FontFile3";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string CharSet = "/CharSet";

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

	internal OpenTypeDescriptor _descriptor;

	private bool _isSymbolFont;

	public string FontName
	{
		get
		{
			return base.Elements.GetName("/FontName");
		}
		set
		{
			base.Elements.SetName("/FontName", value);
		}
	}

	public bool IsSymbolFont => _isSymbolFont;

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfFontDescriptor(PdfDocument document, OpenTypeDescriptor descriptor)
		: base(document)
	{
		_descriptor = descriptor;
		base.Elements.SetName("/Type", "/FontDescriptor");
		base.Elements.SetInteger("/Ascent", _descriptor.DesignUnitsToPdf(_descriptor.Ascender));
		base.Elements.SetInteger("/CapHeight", _descriptor.DesignUnitsToPdf(_descriptor.CapHeight));
		base.Elements.SetInteger("/Descent", _descriptor.DesignUnitsToPdf(_descriptor.Descender));
		base.Elements.SetInteger("/Flags", (int)FlagsFromDescriptor(_descriptor));
		base.Elements.SetRectangle("/FontBBox", new PdfRectangle(_descriptor.DesignUnitsToPdf(_descriptor.XMin), _descriptor.DesignUnitsToPdf(_descriptor.YMin), _descriptor.DesignUnitsToPdf(_descriptor.XMax), _descriptor.DesignUnitsToPdf(_descriptor.YMax)));
		base.Elements.SetReal("/ItalicAngle", _descriptor.ItalicAngle);
		base.Elements.SetInteger("/StemV", _descriptor.StemV);
		base.Elements.SetInteger("/XHeight", _descriptor.DesignUnitsToPdf(_descriptor.XHeight));
	}

	private PdfFontDescriptorFlags FlagsFromDescriptor(OpenTypeDescriptor descriptor)
	{
		PdfFontDescriptorFlags pdfFontDescriptorFlags = (PdfFontDescriptorFlags)0;
		_isSymbolFont = descriptor.FontFace.cmap.symbol;
		return (PdfFontDescriptorFlags)((int)pdfFontDescriptorFlags | (descriptor.FontFace.cmap.symbol ? 4 : 32));
	}
}
