using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroRadioButtonsField : AcroNonTerminalField
{
	public AcroButtonFieldFlags Flags { get; }

	public AcroRadioButtonsField(DictionaryToken dictionary, string fieldType, AcroButtonFieldFlags fieldFlags, AcroFieldCommonInformation information, IReadOnlyList<AcroFieldBase> children)
		: base(dictionary, fieldType, (uint)fieldFlags, information, AcroFieldType.RadioButtons, children)
	{
		Flags = fieldFlags;
	}
}
