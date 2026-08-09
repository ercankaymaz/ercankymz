using System;

namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfRadioButtonField : PdfButtonField
{
	public new class Keys : PdfButtonField.Keys
	{
		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Opt = "/Opt";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	public int SelectedIndex
	{
		get
		{
			string value = base.Elements.GetString("/V");
			return IndexInOptStrings(value);
		}
		set
		{
			PdfArray pdfArray = base.Elements["/Opt"] as PdfArray;
			if (pdfArray == null)
			{
				pdfArray = base.Elements["/Kids"] as PdfArray;
			}
			if (pdfArray != null)
			{
				int count = pdfArray.Elements.Count;
				if (value < 0 || value >= count)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				base.Elements.SetName("/V", pdfArray.Elements[value].ToString());
			}
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfRadioButtonField(PdfDocument document)
		: base(document)
	{
		_document = document;
	}

	internal PdfRadioButtonField(PdfDictionary dict)
		: base(dict)
	{
	}

	private int IndexInOptStrings(string value)
	{
		if (base.Elements["/Opt"] is PdfArray pdfArray)
		{
			int count = pdfArray.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				PdfItem pdfItem = pdfArray.Elements[i];
				if (pdfItem is PdfString && pdfItem.ToString() == value)
				{
					return i;
				}
			}
		}
		return -1;
	}
}
