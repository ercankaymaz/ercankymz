using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlock1PtParameter")]
public abstract class Block1PtParameter : BlockParameter
{
	public override string SubclassMarker => "AcDbBlock1PtParameter";

	[DxfCodeValue(new int[] { 1010, 1020, 1030 })]
	public XYZ Location { get; set; }

	[DxfCodeValue(new int[] { 93 })]
	internal long Value93 { get; set; }

	[DxfCodeValue(new int[] { 170 })]
	internal short Value170 { get; set; }

	[DxfCodeValue(new int[] { 171 })]
	internal short Value171 { get; set; }
}
