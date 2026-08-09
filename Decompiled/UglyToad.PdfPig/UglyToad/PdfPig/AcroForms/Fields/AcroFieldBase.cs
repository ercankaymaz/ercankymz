using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.AcroForms.Fields;

public abstract class AcroFieldBase
{
	public DictionaryToken Dictionary { get; }

	public string RawFieldType { get; }

	public AcroFieldType FieldType { get; }

	public uint FieldFlags { get; }

	public AcroFieldCommonInformation Information { get; }

	public int? PageNumber { get; }

	public PdfRectangle? Bounds { get; }

	protected AcroFieldBase(DictionaryToken dictionary, string rawFieldType, uint fieldFlags, AcroFieldType fieldType, AcroFieldCommonInformation information, int? pageNumber, PdfRectangle? bounds)
	{
		Dictionary = dictionary ?? throw new ArgumentNullException("dictionary");
		RawFieldType = rawFieldType ?? throw new ArgumentNullException("rawFieldType");
		FieldFlags = fieldFlags;
		FieldType = fieldType;
		Information = information ?? new AcroFieldCommonInformation(null, null, null, null);
		PageNumber = pageNumber;
		Bounds = bounds;
	}

	public override string ToString()
	{
		return $"{FieldType}";
	}
}
