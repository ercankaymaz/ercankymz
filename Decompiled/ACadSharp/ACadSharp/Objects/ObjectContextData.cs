using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfSubClass("AcDbObjectContextData")]
public abstract class ObjectContextData : NonGraphicalObject
{
	public override string SubclassMarker => "AcDbObjectContextData";

	[DxfCodeValue(new int[] { 70 })]
	public short Version { get; set; } = 3;

	public bool HasFileToExtensionDictionary { get; set; } = true;

	[DxfCodeValue(new int[] { 290 })]
	public bool Default { get; set; }
}
