using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdValue_DataType
{
	kUnknown = 0,
	kLong = 1,
	kDouble = 2,
	kString = 4,
	kDate = 8,
	kPoint = 0x10,
	k3dPoint = 0x20,
	kObjectId = 0x40,
	kBuffer = 0x80,
	kResbuf = 0x100,
	kGeneral = 0x200,
	kColor = 0x400
}
