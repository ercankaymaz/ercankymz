using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockFlipParameter")]
public class BlockFlipParameter : Block2PtParameter
{
	public override string ObjectName => "BLOCKFLIPPARAMETER";

	public override string SubclassMarker => "AcDbBlockFlipParameter";

	public string Caption { get; set; }

	public string Description { get; set; }

	public string BaseStateName { get; set; }

	public string FlippedStateName { get; set; }

	public XYZ CaptionLocation { get; set; }

	public string Caption309 { get; set; }

	public int Value96 { get; set; }

	public string Caption1001 { get; set; }

	public XYZ Point1010 { get; set; }
}
