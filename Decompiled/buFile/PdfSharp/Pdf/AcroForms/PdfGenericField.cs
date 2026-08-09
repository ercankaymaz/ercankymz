namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfGenericField : PdfAcroField
{
	public new class Keys : PdfAcroField.Keys
	{
		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfGenericField(PdfDocument document)
		: base(document)
	{
	}

	internal PdfGenericField(PdfDictionary dict)
		: base(dict)
	{
	}
}
