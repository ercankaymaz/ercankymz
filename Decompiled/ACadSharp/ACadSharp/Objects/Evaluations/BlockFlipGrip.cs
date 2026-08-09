using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockFlipGrip")]
public class BlockFlipGrip : BlockGrip
{
	public override string SubclassMarker => "AcDbBlockFlipGrip";

	[DxfCodeValue(new int[] { 140 })]
	public double Value140 { get; set; }

	[DxfCodeValue(new int[] { 141 })]
	public double Value141 { get; set; }

	[DxfCodeValue(new int[] { 142 })]
	public double Value142 { get; set; }

	[DxfCodeValue(new int[] { 93 })]
	public int Value93N { get; set; }
}
