using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.AcroForms.Fields;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms;

public class AcroForm
{
	private readonly IReadOnlyDictionary<IndirectReference, AcroFieldBase> fieldsWithReferences;

	public DictionaryToken Dictionary { get; }

	public SignatureFlags SignatureFlags { get; }

	public bool NeedAppearances { get; }

	public IReadOnlyList<AcroFieldBase> Fields { get; }

	internal AcroForm(DictionaryToken dictionary, SignatureFlags signatureFlags, bool needAppearances, IReadOnlyDictionary<IndirectReference, AcroFieldBase> fieldsWithReferences)
	{
		Dictionary = dictionary ?? throw new ArgumentNullException("dictionary");
		SignatureFlags = signatureFlags;
		NeedAppearances = needAppearances;
		this.fieldsWithReferences = fieldsWithReferences ?? throw new ArgumentNullException("fieldsWithReferences");
		Fields = fieldsWithReferences.Values.ToList();
	}

	public IEnumerable<AcroFieldBase> GetFieldsForPage(int pageNumber)
	{
		if (pageNumber <= 0)
		{
			throw new ArgumentOutOfRangeException("pageNumber", $"Page number starts at 1, instead got {pageNumber}.");
		}
		foreach (AcroFieldBase field in Fields)
		{
			if (field.PageNumber == pageNumber)
			{
				yield return field;
			}
			else if (field is AcroNonTerminalField acroNonTerminalField && acroNonTerminalField.Children.Any((AcroFieldBase x) => x.PageNumber == pageNumber))
			{
				yield return field;
			}
		}
	}

	public override string ToString()
	{
		return Dictionary.ToString();
	}
}
