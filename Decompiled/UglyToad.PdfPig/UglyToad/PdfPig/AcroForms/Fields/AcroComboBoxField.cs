using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroComboBoxField : AcroFieldBase
{
	public AcroChoiceFieldFlags Flags { get; }

	public IReadOnlyList<AcroChoiceOption> Options { get; }

	public IReadOnlyList<string> SelectedOptions { get; }

	public IReadOnlyList<int>? SelectedOptionIndices { get; }

	public AcroComboBoxField(DictionaryToken dictionary, string fieldType, AcroChoiceFieldFlags fieldFlags, AcroFieldCommonInformation information, IReadOnlyList<AcroChoiceOption> options, IReadOnlyList<string> selectedOptions, IReadOnlyList<int>? selectedOptionIndices, int? pageNumber, PdfRectangle? bounds)
		: base(dictionary, fieldType, (uint)fieldFlags, AcroFieldType.ComboBox, information, pageNumber, bounds)
	{
		Flags = fieldFlags;
		Options = options ?? throw new ArgumentNullException("options");
		SelectedOptions = selectedOptions ?? throw new ArgumentNullException("selectedOptions");
		SelectedOptionIndices = selectedOptionIndices;
	}
}
