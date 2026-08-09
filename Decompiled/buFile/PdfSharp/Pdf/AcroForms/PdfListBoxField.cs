namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfListBoxField : PdfChoiceField
{
	public new class Keys : PdfAcroField.Keys
	{
		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	public int SelectedIndex
	{
		get
		{
			string value = base.Elements.GetString("/V");
			return IndexInOptArray(value);
		}
		set
		{
			string value2 = ValueInOptArray(value);
			base.Elements.SetString("/V", value2);
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfListBoxField(PdfDocument document)
		: base(document)
	{
	}

	internal PdfListBoxField(PdfDictionary dict)
		: base(dict)
	{
	}
}
