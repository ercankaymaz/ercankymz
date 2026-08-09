using System;

namespace Xbim.IO;

[Flags]
public enum StorageType
{
	Invalid = 0,
	IfcXml = 1,
	Ifc = 2,
	IfcZip = 4,
	Xbim = 8,
	Stp = 0x10,
	StpZip = 0x20,
	Zip = 0x40
}
