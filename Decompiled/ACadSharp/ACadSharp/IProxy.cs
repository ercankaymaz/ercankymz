using ACadSharp.Classes;

namespace ACadSharp;

public interface IProxy
{
	int ClassId { get; }

	DxfClass DxfClass { get; set; }

	int ProxyClassId { get; }

	bool OriginalDataFormatDxf { get; set; }

	ACadVersion Version { get; set; }

	int MaintenanceVersion { get; set; }
}
