using System;

namespace PdfSharp.Pdf;

public class PdfCustomValues : PdfDictionary
{
	public PdfCustomValueCompressionMode CompressionMode
	{
		set
		{
			throw new NotImplementedException();
		}
	}

	public PdfCustomValue this[string key]
	{
		get
		{
			PdfDictionary dictionary = base.Elements.GetDictionary(key);
			if (dictionary == null)
			{
				return null;
			}
			PdfCustomValue pdfCustomValue = dictionary as PdfCustomValue;
			if (pdfCustomValue == null)
			{
				pdfCustomValue = new PdfCustomValue(dictionary);
			}
			return pdfCustomValue;
		}
		set
		{
			if (value == null)
			{
				base.Elements.Remove(key);
				return;
			}
			Owner.Internals.AddObject(value);
			base.Elements.SetReference(key, value);
		}
	}

	internal PdfCustomValues()
	{
	}

	internal PdfCustomValues(PdfDocument document)
		: base(document)
	{
	}

	internal PdfCustomValues(PdfDictionary dict)
		: base(dict)
	{
	}

	public bool Contains(string key)
	{
		return base.Elements.ContainsKey(key);
	}

	public static void ClearAllCustomValues(PdfDocument document)
	{
		document.CustomValues = null;
		foreach (PdfPage page in document.Pages)
		{
			page.CustomValues = null;
		}
	}

	internal static PdfCustomValues Get(DictionaryElements elem)
	{
		string customValueKey = elem.Owner.Owner.Internals.CustomValueKey;
		PdfDictionary dictionary = elem.GetDictionary(customValueKey);
		PdfCustomValues pdfCustomValues;
		if (dictionary == null)
		{
			pdfCustomValues = new PdfCustomValues();
			elem.Owner.Owner.Internals.AddObject(pdfCustomValues);
			elem.Add(customValueKey, pdfCustomValues);
		}
		else
		{
			pdfCustomValues = dictionary as PdfCustomValues;
			if (pdfCustomValues == null)
			{
				pdfCustomValues = new PdfCustomValues(dictionary);
			}
		}
		return pdfCustomValues;
	}

	internal static void Remove(DictionaryElements elem)
	{
		elem.Remove(elem.Owner.Owner.Internals.CustomValueKey);
	}
}
