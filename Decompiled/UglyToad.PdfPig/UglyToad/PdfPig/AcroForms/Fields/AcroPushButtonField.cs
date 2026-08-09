using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroPushButtonField : AcroFieldBase
{
	public AcroButtonFieldFlags Flags { get; }

	public AcroPushButtonField(DictionaryToken dictionary, string fieldType, AcroButtonFieldFlags fieldFlags, AcroFieldCommonInformation information, int? pageNumber, PdfRectangle? bounds)
		: base(dictionary, fieldType, (uint)fieldFlags, AcroFieldType.PushButton, information, pageNumber, bounds)
	{
		Flags = fieldFlags;
	}
}
