using System.IO;

namespace Xbim.IO;

public static class IfcStorageTypeExtensions
{
	public static StorageType StorageType(this string path)
	{
		string extension = Path.GetExtension(path);
		if (string.IsNullOrEmpty(extension))
		{
			return Xbim.IO.StorageType.Invalid;
		}
		extension = extension.ToLowerInvariant();
		switch (extension)
		{
		case ".ifc":
			return Xbim.IO.StorageType.Ifc;
		case ".ifcxml":
			return Xbim.IO.StorageType.IfcXml;
		case ".ifczip":
			return Xbim.IO.StorageType.IfcZip;
		case ".xbim":
			return Xbim.IO.StorageType.Xbim;
		case ".stp":
			return Xbim.IO.StorageType.Stp;
		case ".stpzip":
			return Xbim.IO.StorageType.StpZip;
		default:
			if (extension.Contains("zip"))
			{
				return Xbim.IO.StorageType.Zip;
			}
			return Xbim.IO.StorageType.Invalid;
		}
	}

	public static bool IsStepTextFile(this string path)
	{
		string extension = Path.GetExtension(path);
		if (string.IsNullOrEmpty(extension))
		{
			return false;
		}
		return ".ifc;.stp;".Contains(extension.ToLowerInvariant() + ";");
	}

	public static bool IsStepZipFile(this string path)
	{
		string extension = Path.GetExtension(path);
		if (string.IsNullOrEmpty(extension))
		{
			return false;
		}
		return ".ifczip;.stpzip;.zip;".Contains(extension.ToLowerInvariant() + ";");
	}

	public static bool IsStepXmlFile(this string path)
	{
		string extension = Path.GetExtension(path);
		if (string.IsNullOrEmpty(extension))
		{
			return false;
		}
		return extension.ToLowerInvariant() == ".ifcxml";
	}
}
