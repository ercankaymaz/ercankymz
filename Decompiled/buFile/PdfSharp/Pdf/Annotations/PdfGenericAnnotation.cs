namespace PdfSharp.Pdf.Annotations;

internal sealed class PdfGenericAnnotation : PdfAnnotation
{
	internal new class Keys : PdfAnnotation.Keys
	{
		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfGenericAnnotation(PdfDictionary dict)
		: base(dict)
	{
	}
}
