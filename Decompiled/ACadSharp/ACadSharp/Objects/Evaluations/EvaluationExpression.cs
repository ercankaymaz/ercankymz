using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbEvalExpr")]
public abstract class EvaluationExpression : CadObject
{
	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker => "AcDbEvalExpr";

	[DxfCodeValue(new int[] { 90 })]
	internal int Value90 { get; set; }

	[DxfCodeValue(new int[] { 98 })]
	internal int Value98 { get; set; }

	[DxfCodeValue(new int[] { 99 })]
	internal int Value99 { get; set; }
}
