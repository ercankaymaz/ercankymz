#define DEBUG
using System;
using System.Diagnostics;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Pdf.AcroForms;

public abstract class PdfChoiceField : PdfAcroField
{
	public new class Keys : PdfAcroField.Keys
	{
		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Opt = "/Opt";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string TI = "/TI";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string I = "/I";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	protected PdfChoiceField(PdfDocument document)
		: base(document)
	{
	}

	protected PdfChoiceField(PdfDictionary dict)
		: base(dict)
	{
	}

	protected int IndexInOptArray(string value)
	{
		PdfArray array = base.Elements.GetArray("/Opt");
		PdfArray pdfArray = null;
		if (base.Elements["/Opt"] is PdfArray)
		{
			pdfArray = base.Elements["/Opt"] as PdfArray;
		}
		else if (base.Elements["/Opt"] is PdfReference)
		{
			pdfArray = ((PdfReference)base.Elements["/Opt"]).Value as PdfArray;
		}
		Debug.Assert(array == pdfArray);
		if (array != null)
		{
			int count = array.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				PdfItem pdfItem = array.Elements[i];
				if (pdfItem is PdfString)
				{
					if (pdfItem.ToString() == value)
					{
						return i;
					}
				}
				else if (pdfItem is PdfArray)
				{
					PdfArray pdfArray2 = (PdfArray)pdfItem;
					if (pdfArray2.Elements.Count != 0 && pdfArray2.Elements[0].ToString() == value)
					{
						return i;
					}
				}
			}
		}
		return -1;
	}

	protected string ValueInOptArray(int index)
	{
		PdfArray array = base.Elements.GetArray("/Opt");
		if (array != null)
		{
			int count = array.Elements.Count;
			if (index < 0 || index >= count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			PdfItem pdfItem = array.Elements[index];
			if (pdfItem is PdfString)
			{
				return pdfItem.ToString();
			}
			if (pdfItem is PdfArray)
			{
				PdfArray pdfArray = (PdfArray)pdfItem;
				if (pdfArray.Elements.Count != 0)
				{
					return pdfArray.Elements[0].ToString();
				}
			}
		}
		return "";
	}
}
