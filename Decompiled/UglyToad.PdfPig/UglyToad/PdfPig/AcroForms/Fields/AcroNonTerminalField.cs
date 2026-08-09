using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroNonTerminalField : AcroFieldBase
{
	public IReadOnlyList<AcroFieldBase> Children { get; }

	internal AcroNonTerminalField(DictionaryToken dictionary, string fieldType, uint fieldFlags, AcroFieldCommonInformation information, AcroFieldType acroFieldType, IReadOnlyList<AcroFieldBase> children)
		: base(dictionary, fieldType, fieldFlags, acroFieldType, information, null, null)
	{
		Children = children ?? throw new ArgumentNullException("children");
	}
}
