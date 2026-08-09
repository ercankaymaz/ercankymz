using System.IO;
using ACadSharp.Attributes;
using ACadSharp.Classes;

namespace ACadSharp.Objects;

[DxfName("ACAD_PROXY_OBJECT")]
[DxfSubClass("AcDbProxyObject")]
public class ProxyObject : NonGraphicalObject, IProxy
{
	[DxfCodeValue(new int[] { 91 })]
	public int ClassId => DxfClass.ClassNumber;

	[DxfCodeValue(new int[] { 95 })]
	public int DrawingFormat => (int)Version | (MaintenanceVersion << 16);

	public DxfClass DxfClass { get; set; }

	public int MaintenanceVersion { get; set; }

	public override string ObjectName => "ACAD_PROXY_OBJECT";

	[DxfCodeValue(new int[] { 70 })]
	public bool OriginalDataFormatDxf { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public int ProxyClassId { get; } = 499;

	[DxfCodeValue(new int[] { 310 })]
	public Stream BinaryData { get; set; }

	[DxfCodeValue(new int[] { 311 })]
	public Stream Data { get; set; }

	public override string SubclassMarker => "AcDbProxyObject";

	public ACadVersion Version { get; set; }
}
