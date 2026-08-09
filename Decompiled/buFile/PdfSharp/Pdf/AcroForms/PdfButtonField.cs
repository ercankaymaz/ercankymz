#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;

namespace PdfSharp.Pdf.AcroForms;

public abstract class PdfButtonField : PdfAcroField
{
	public new class Keys : PdfAcroField.Keys
	{
	}

	protected PdfButtonField(PdfDocument document)
		: base(document)
	{
	}

	protected PdfButtonField(PdfDictionary dict)
		: base(dict)
	{
	}

	protected string GetNonOffValue()
	{
		if (base.Elements["/AP"] is PdfDictionary pdfDictionary && pdfDictionary.Elements["/N"] is PdfDictionary pdfDictionary2)
		{
			foreach (string key in pdfDictionary2.Elements.Keys)
			{
				if (key != "/Off")
				{
					return key;
				}
			}
		}
		return null;
	}

	internal override void GetDescendantNames(ref List<string> names, string partialName)
	{
		string text = base.Elements.GetString("/T");
		if (text == "")
		{
			text = "???";
		}
		Debug.Assert(text != "");
		if (text.Length > 0)
		{
			if (!string.IsNullOrEmpty(partialName))
			{
				names.Add(partialName + "." + text);
			}
			else
			{
				names.Add(text);
			}
		}
	}
}
