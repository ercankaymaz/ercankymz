using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockVisibilityGrip")]
public class BlockVisibilityGrip : BlockGrip
{
	public override string SubclassMarker => "AcDbBlockVisibilityGrip";
}
