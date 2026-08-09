using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockGripLocationComponent")]
internal class BlockGripLocationComponent : BlockGripExpression
{
	public override string SubclassMarker => "AcDbBlockGripLocationComponent";
}
