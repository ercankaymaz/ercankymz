using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfName("ACDBPLACEHOLDER")]
[DxfSubClass("AcDbPlaceHolder")]
public class AcdbPlaceHolder : NonGraphicalObject
{
	public override ObjectType ObjectType => ObjectType.ACDBPLACEHOLDER;

	public override string ObjectName => "ACDBPLACEHOLDER";

	public override string SubclassMarker => "AcDbPlaceHolder";
}
