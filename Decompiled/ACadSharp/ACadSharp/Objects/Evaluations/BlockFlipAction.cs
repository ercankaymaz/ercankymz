using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfName("BLOCKFLIPACTION")]
[DxfSubClass("AcDbBlockFlipAction")]
public class BlockFlipAction : BlockAction
{
	public override string ObjectName => "BLOCKFLIPACTION";

	public override string SubclassMarker => "AcDbBlockFlipAction";

	[DxfCodeValue(new int[] { 92 })]
	public int Value92 { get; set; }

	[DxfCodeValue(new int[] { 93 })]
	public int Value93 { get; set; }

	[DxfCodeValue(new int[] { 94 })]
	public int Value94 { get; set; }

	[DxfCodeValue(new int[] { 95 })]
	public int Value95 { get; set; }

	[DxfCodeValue(new int[] { 301 })]
	public string Caption301 { get; set; }

	[DxfCodeValue(new int[] { 302 })]
	public string Caption302 { get; set; }

	[DxfCodeValue(new int[] { 303 })]
	public string Caption303 { get; set; }

	[DxfCodeValue(new int[] { 304 })]
	public string Caption304 { get; set; }
}
