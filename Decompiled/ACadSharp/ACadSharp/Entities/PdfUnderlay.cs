using ACadSharp.Attributes;
using ACadSharp.Objects;
using ACadSharp.Objects.Collections;

namespace ACadSharp.Entities;

[DxfName("PDFUNDERLAY")]
[DxfSubClass("AcDbUnderlayReference")]
public class PdfUnderlay : UnderlayEntity<PdfUnderlayDefinition>
{
	public override string ObjectName => "PDFUNDERLAY";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public PdfUnderlay(PdfUnderlayDefinition definition)
		: base(definition)
	{
	}

	internal PdfUnderlay()
	{
	}

	protected override ObjectDictionaryCollection<PdfUnderlayDefinition> getDocumentCollection(CadDocument document)
	{
		return document.PdfDefinitions;
	}
}
