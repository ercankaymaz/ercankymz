using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockElement")]
public abstract class BlockElement : EvaluationExpression
{
	public override string SubclassMarker => "AcDbBlockElement";

	[DxfCodeValue(new int[] { 300 })]
	public string ElementName { get; set; }

	[DxfCodeValue(new int[] { 1071 })]
	internal int Value1071 { get; set; }
}
