using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroTextField : AcroFieldBase
{
	public AcroTextFieldFlags Flags { get; }

	public string? Value { get; }

	public int? MaxLength { get; }

	public bool IsRichText { get; }

	public bool IsMultiline { get; }

	public AcroTextField(DictionaryToken dictionary, string fieldType, AcroTextFieldFlags fieldFlags, AcroFieldCommonInformation information, string? value, int? maxLength, int? pageNumber, PdfRectangle? bounds)
		: base(dictionary, fieldType, (uint)fieldFlags, AcroFieldType.Text, information, pageNumber, bounds)
	{
		Flags = fieldFlags;
		Value = value;
		MaxLength = maxLength;
		IsRichText = Flags.HasFlag(AcroTextFieldFlags.RichText);
		IsMultiline = Flags.HasFlag(AcroTextFieldFlags.Multiline);
	}

	public override string ToString()
	{
		return $"{base.FieldType}: {Value ?? string.Empty}";
	}
}
