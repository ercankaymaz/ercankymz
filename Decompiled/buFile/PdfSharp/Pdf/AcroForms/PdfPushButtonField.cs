namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfPushButtonField : PdfButtonField
{
	public new class Keys : PdfAcroField.Keys
	{
		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfPushButtonField(PdfDocument document)
		: base(document)
	{
		_document = document;
	}

	internal PdfPushButtonField(PdfDictionary dict)
		: base(dict)
	{
	}
}
