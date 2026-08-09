using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_OdGeXConfig
{
	kNotDefined = 1,
	kUnknown = 2,
	kLeftRight = 4,
	kRightLeft = 8,
	kLeftLeft = 0x10,
	kRightRight = 0x20,
	kPointLeft = 0x40,
	kPointRight = 0x80,
	kLeftOverlap = 0x100,
	kOverlapLeft = 0x200,
	kRightOverlap = 0x400,
	kOverlapRight = 0x800,
	kOverlapStart = 0x1000,
	kOverlapEnd = 0x2000,
	kOverlapOverlap = 0x4000
}
