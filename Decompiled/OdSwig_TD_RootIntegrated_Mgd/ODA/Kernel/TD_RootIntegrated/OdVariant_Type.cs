using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdVariant_Type
{
	kVoid = 0,
	kString = 1,
	kBool = 2,
	kInt8 = 3,
	kUInt8 = 3,
	kInt16 = 4,
	kUInt16 = 4,
	kInt32 = 5,
	kUInt32 = 5,
	kInt64 = 6,
	kUInt64 = 6,
	kDouble = 7,
	kWString = 8,
	kAnsiString = 8,
	kRxObjectPtr = 9,
	kNextType = 0xA,
	kByRef = 0x40,
	kArray = 0x80
}
