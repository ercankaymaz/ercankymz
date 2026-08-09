using ACadSharp.Attributes;
using ACadSharp.Classes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("ACAD_PROXY_ENTITY")]
[DxfSubClass("AcDbProxyEntity")]
public class ProxyEntity : Entity, IProxy
{
	[DxfCodeValue(new int[] { 91 })]
	public int ClassId => DxfClass.ClassNumber;

	[DxfCodeValue(new int[] { 95 })]
	public int DrawingFormat => (int)Version | (MaintenanceVersion << 16);

	public DxfClass DxfClass { get; set; }

	public int MaintenanceVersion { get; set; }

	public override string ObjectName => "ACAD_PROXY_ENTITY";

	public override ObjectType ObjectType => ObjectType.ACAD_PROXY_ENTITY;

	[DxfCodeValue(new int[] { 70 })]
	public bool OriginalDataFormatDxf { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public int ProxyClassId { get; } = 498;

	public override string SubclassMarker => "AcDbProxyEntity";

	public ACadVersion Version { get; set; }

	public override void ApplyTransform(Transform transform)
	{
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Null;
	}
}
