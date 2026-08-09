using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroCheckboxesField : AcroNonTerminalField
{
	internal AcroCheckboxesField(DictionaryToken dictionary, string fieldType, AcroButtonFieldFlags fieldFlags, AcroFieldCommonInformation information, IReadOnlyList<AcroFieldBase> children)
		: base(dictionary, fieldType, (uint)fieldFlags, information, AcroFieldType.Checkboxes, children)
	{
	}
}
