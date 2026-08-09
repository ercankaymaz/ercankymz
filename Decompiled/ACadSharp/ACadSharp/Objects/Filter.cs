using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfSubClass("AcDbFilter")]
public abstract class Filter : NonGraphicalObject
{
	public const string FilterEntryName = "ACAD_FILTER";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker => "AcDbFilter";

	public Filter()
	{
	}

	public Filter(string name)
		: base(name)
	{
	}
}
