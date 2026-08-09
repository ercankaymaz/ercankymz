using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockParameter")]
public abstract class BlockParameter : BlockElement
{
	public override string SubclassMarker => "AcDbBlockParameter";

	[DxfCodeValue(new int[] { 280 })]
	internal bool Value280 { get; set; }

	[DxfCodeValue(new int[] { 281 })]
	internal bool Value281 { get; set; }
}
