using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdTf_TypesEnum
{
	Subclass = 0,
	Bool = 1,
	Byte = 2,
	Short = 3,
	Int = 4,
	UnsignedByte = 5,
	UnsignedShort = 6,
	UnsignedInt = 7,
	Long = 8,
	Double = 9,
	HexBinary = 0xA,
	String = 0xB,
	Handle = 0xC,
	SoftOwnershipId = 0xD,
	HardOwnershipId = 0xE,
	SoftPointerId = 0xF,
	HardPointerId = 0x10,
	Point2d = 0x11,
	Point3d = 0x12,
	Vector2d = 0x13,
	Vector3d = 0x14,
	Scale3d = 0x15,
	DateTime = 0x16,
	DataEnd = 0x17,
	Table = 0x18,
	Empty = 0x19,
	DoubleWithDefault = 0x1A
}
