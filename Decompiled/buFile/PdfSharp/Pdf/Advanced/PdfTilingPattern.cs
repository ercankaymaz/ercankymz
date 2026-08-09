namespace PdfSharp.Pdf.Advanced;

public sealed class PdfTilingPattern : PdfDictionaryWithContentStream
{
	internal new sealed class Keys : PdfDictionaryWithContentStream.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Required)]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string PatternType = "/PatternType";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string PaintType = "/PaintType";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string TilingType = "/TilingType";

		[KeyInfo(KeyType.Rectangle | KeyType.Optional)]
		public const string BBox = "/BBox";

		[KeyInfo(KeyType.Real | KeyType.Required)]
		public const string XStep = "/XStep";

		[KeyInfo(KeyType.Real | KeyType.Required)]
		public const string YStep = "/YStep";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public new const string Resources = "/Resources";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Matrix = "/Matrix";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfTilingPattern(PdfDocument document)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Pattern");
		base.Elements["/PatternType"] = new PdfInteger(1);
	}
}
