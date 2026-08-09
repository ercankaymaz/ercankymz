using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced;

internal class PdfResourceMap : PdfDictionary
{
	public PdfResourceMap()
	{
	}

	public PdfResourceMap(PdfDocument document)
		: base(document)
	{
	}

	protected PdfResourceMap(PdfDictionary dict)
		: base(dict)
	{
	}

	internal void CollectResourceNames(Dictionary<string, object> usedResourceNames)
	{
		PdfName[] keyNames = base.Elements.KeyNames;
		PdfName[] array = keyNames;
		foreach (PdfName pdfName in array)
		{
			usedResourceNames.Add(pdfName.ToString(), null);
		}
	}
}
