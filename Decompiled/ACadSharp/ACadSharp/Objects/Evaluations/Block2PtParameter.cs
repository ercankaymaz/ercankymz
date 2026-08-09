using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlock2PtParameter")]
public abstract class Block2PtParameter : BlockParameter
{
	public override string SubclassMarker => "AcDbBlock2PtParameter";

	[DxfCodeValue(new int[] { 1010, 1020, 1030 })]
	public XYZ FirstPoint { get; set; }

	[DxfCodeValue(new int[] { 1011, 1021, 1031 })]
	public XYZ SecondPoint { get; set; }
}
