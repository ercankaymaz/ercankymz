using ACadSharp.Attributes;

namespace ACadSharp.Classes;

public class DxfClass
{
	[DxfCodeValue(new int[] { 3 })]
	public string ApplicationName { get; set; } = "ObjectDBX Classes";

	public short ClassNumber { get; set; }

	[DxfCodeValue(new int[] { 2 })]
	public string CppClassName { get; set; }

	public ACadVersion DwgVersion { get; set; }

	[DxfCodeValue(new int[] { 1 })]
	public string DxfName { get; set; }

	[DxfCodeValue(new int[] { 91 })]
	public int InstanceCount { get; set; }

	[DxfCodeValue(new int[] { 281 })]
	public bool IsAnEntity { get; set; }

	public short ItemClassId { get; internal set; }

	[DxfCodeValue(new int[] { 90 })]
	public ProxyFlags ProxyFlags { get; set; }

	[DxfCodeValue(new int[] { 280 })]
	public bool WasZombie { get; set; }

	internal short MaintenanceVersion { get; set; }

	public override string ToString()
	{
		return $"{DxfName}:{ClassNumber}";
	}
}
