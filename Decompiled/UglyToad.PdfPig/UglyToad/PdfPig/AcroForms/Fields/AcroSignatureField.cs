using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroSignatureField : AcroFieldBase
{
	public AcroSignatureField(DictionaryToken dictionary, string fieldType, uint fieldFlags, AcroFieldCommonInformation information, int? pageNumber, PdfRectangle? bounds)
		: base(dictionary, fieldType, fieldFlags, AcroFieldType.Signature, information, pageNumber, bounds)
	{
	}
}
