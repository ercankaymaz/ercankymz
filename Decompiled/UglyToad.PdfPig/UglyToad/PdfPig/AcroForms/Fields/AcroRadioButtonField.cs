using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroRadioButtonField : AcroFieldBase
{
	public AcroButtonFieldFlags Flags { get; }

	public NameToken CurrentValue { get; }

	public bool IsSelected { get; }

	public AcroRadioButtonField(DictionaryToken dictionary, string fieldType, AcroButtonFieldFlags fieldFlags, AcroFieldCommonInformation information, int? pageNumber, PdfRectangle? bounds, NameToken currentValue, bool isSelected)
		: base(dictionary, fieldType, (uint)fieldFlags, AcroFieldType.RadioButton, information, pageNumber, bounds)
	{
		Flags = fieldFlags;
		CurrentValue = currentValue;
		IsSelected = isSelected;
	}
}
