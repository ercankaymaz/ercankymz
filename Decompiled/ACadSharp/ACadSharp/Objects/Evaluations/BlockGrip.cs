using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockGrip")]
public abstract class BlockGrip : BlockElement
{
	public override string SubclassMarker => "AcDbBlockGrip";

	[DxfCodeValue(new int[] { 9 })]
	public int Value9 { get; set; }

	[DxfCodeValue(new int[] { 10 })]
	public int Value10 { get; set; }

	[DxfCodeValue(new int[] { 1010, 1020, 1030 })]
	public XYZ Location { get; set; }

	[DxfCodeValue(new int[] { 10 })]
	public short Value280 { get; set; }

	[DxfCodeValue(new int[] { 93 })]
	public int Value93 { get; set; }
}
