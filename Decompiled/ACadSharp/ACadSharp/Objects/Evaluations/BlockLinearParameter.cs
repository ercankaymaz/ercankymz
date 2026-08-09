using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfName("BLOCKLINEARPARAMETER")]
[DxfSubClass("AcDbBlockLinearParameter")]
public class BlockLinearParameter : Block2PtParameter
{
	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "BLOCKLINEARPARAMETER";

	public override string SubclassMarker => "AcDbBlockLinearParameter";

	[DxfCodeValue(new int[] { 305 })]
	public string Label { get; set; }

	[DxfCodeValue(new int[] { 306 })]
	public string Description { get; set; }

	[DxfCodeValue(new int[] { 140 })]
	public double LabelOffset { get; set; }
}
