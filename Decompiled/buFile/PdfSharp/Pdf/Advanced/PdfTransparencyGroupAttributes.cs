namespace PdfSharp.Pdf.Advanced;

public sealed class PdfTransparencyGroupAttributes : PdfGroupAttributes
{
	public new sealed class Keys : PdfGroupAttributes.Keys
	{
		[KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
		public const string CS = "/CS";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string I = "/I";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string K = "/K";

		private static DictionaryMeta _meta;

		internal new static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfTransparencyGroupAttributes(PdfDocument thisDocument)
		: base(thisDocument)
	{
		base.Elements.SetName("/S", "/Transparency");
	}
}
