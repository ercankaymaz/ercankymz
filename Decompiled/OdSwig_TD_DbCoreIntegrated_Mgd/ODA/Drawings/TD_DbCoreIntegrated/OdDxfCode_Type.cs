using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDxfCode_Type
{
	Unknown = 0,
	Name = 1,
	String = 2,
	Bool = 3,
	Integer8 = 4,
	Integer16 = 5,
	Integer32 = 6,
	Double = 7,
	Angle = 8,
	Point = 9,
	BinaryChunk = 0xA,
	LayerName = 0xB,
	Handle = 0xC,
	ObjectId = 0xD,
	SoftPointerId = 0xE,
	HardPointerId = 0xF,
	SoftOwnershipId = 0x10,
	HardOwnershipId = 0x11,
	Integer64 = 0x12
}
