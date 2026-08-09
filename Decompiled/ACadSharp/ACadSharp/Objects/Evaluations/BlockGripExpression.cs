using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockGripExpression")]
public abstract class BlockGripExpression : EvaluationExpression
{
	public override string SubclassMarker => "AcDbBlockGripExpression";
}
