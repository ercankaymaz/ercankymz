using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroCheckboxField : AcroFieldBase
{
	public AcroButtonFieldFlags Flags { get; }

	public NameToken CurrentValue { get; }

	public bool IsChecked { get; }

	public AcroCheckboxField(DictionaryToken dictionary, string fieldType, AcroButtonFieldFlags fieldFlags, AcroFieldCommonInformation information, NameToken currentValue, bool isChecked, int? pageNumber, PdfRectangle? bounds)
		: base(dictionary, fieldType, (uint)fieldFlags, AcroFieldType.Checkbox, information, pageNumber, bounds)
	{
		Flags = fieldFlags;
		CurrentValue = currentValue;
		IsChecked = isChecked;
	}
}
