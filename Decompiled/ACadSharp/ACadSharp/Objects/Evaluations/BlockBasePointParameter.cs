using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockBasePointParameter")]
public class BlockBasePointParameter : Block1PtParameter
{
	public override string ObjectName => "BLOCKBASEPOINTPARAMETER";

	public override string SubclassMarker => "AcDbBlockBasePointParameter";

	[DxfCodeValue(new int[] { 1011, 1021, 1031 })]
	public XYZ Point1010 { get; set; }

	[DxfCodeValue(new int[] { 1012, 1022, 1032 })]
	public XYZ Point1012 { get; set; }
}
