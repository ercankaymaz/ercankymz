namespace PdfSharp.Pdf.Advanced;

public abstract class PdfGroupAttributes : PdfDictionary
{
	public class Keys : KeysBase
	{
		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public const string S = "/S";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfGroupAttributes(PdfDocument thisDocument)
		: base(thisDocument)
	{
		base.Elements.SetName("/Type", "/Group");
	}
}
