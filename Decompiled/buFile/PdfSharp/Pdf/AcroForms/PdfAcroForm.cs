namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfAcroForm : PdfDictionary
{
	public sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.Array | KeyType.Required, typeof(PdfAcroField.PdfAcroFieldCollection))]
		public const string Fields = "/Fields";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string NeedAppearances = "/NeedAppearances";

		[KeyInfo("1.3", KeyType.Integer | KeyType.Optional)]
		public const string SigFlags = "/SigFlags";

		[KeyInfo(KeyType.Array)]
		public const string CO = "/CO";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional)]
		public const string DR = "/DR";

		[KeyInfo(KeyType.String | KeyType.Optional)]
		public const string DA = "/DA";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string Q = "/Q";

		private static DictionaryMeta s_meta;

		internal static DictionaryMeta Meta
		{
			get
			{
				if (s_meta == null)
				{
					s_meta = KeysBase.CreateMeta(typeof(Keys));
				}
				return s_meta;
			}
		}
	}

	private PdfAcroField.PdfAcroFieldCollection _fields;

	public PdfAcroField.PdfAcroFieldCollection Fields
	{
		get
		{
			if (_fields == null)
			{
				object value = base.Elements.GetValue("/Fields", VCF.CreateIndirect);
				_fields = (PdfAcroField.PdfAcroFieldCollection)value;
			}
			return _fields;
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfAcroForm(PdfDocument document)
		: base(document)
	{
		_document = document;
	}

	internal PdfAcroForm(PdfDictionary dictionary)
		: base(dictionary)
	{
	}
}
