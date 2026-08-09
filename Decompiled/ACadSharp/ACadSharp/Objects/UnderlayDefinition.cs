using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfSubClass(null, true)]
public abstract class UnderlayDefinition : NonGraphicalObject
{
	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker => "AcDbUnderlayDefinition";

	[DxfCodeValue(new int[] { 1 })]
	public string File { get; set; }
}
