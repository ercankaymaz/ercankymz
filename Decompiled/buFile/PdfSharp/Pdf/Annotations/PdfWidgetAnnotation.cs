namespace PdfSharp.Pdf.Annotations;

internal sealed class PdfWidgetAnnotation : PdfAnnotation
{
	internal new class Keys : PdfAnnotation.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string H = "/H";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional)]
		public const string MK = "/MK";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfWidgetAnnotation()
	{
		Initialize();
	}

	public PdfWidgetAnnotation(PdfDocument document)
		: base(document)
	{
		Initialize();
	}

	private void Initialize()
	{
		base.Elements.SetName("/Subtype", "/Widget");
	}
}
