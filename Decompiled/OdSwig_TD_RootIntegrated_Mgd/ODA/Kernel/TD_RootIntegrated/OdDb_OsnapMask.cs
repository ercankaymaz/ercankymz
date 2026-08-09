using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDb_OsnapMask
{
	kOsMaskEnd = 1,
	kOsMaskMid = 2,
	kOsMaskCen = 4,
	kOsMaskNode = 8,
	kOsMaskQuad = 0x10,
	kOsMaskInt = 0x20,
	kOsMaskIns = 0x40,
	kOsMaskPerp = 0x80,
	kOsMaskTan = 0x100,
	kOsMaskNear = 0x200,
	kOsMaskQuick = 0x400,
	kOsMaskApint = 0x800,
	kOsMaskImmediate = 0x10000,
	kOsMaskAllowTan = 0x20000,
	kOsMaskDisablePerp = 0x40000,
	kOsMaskRelCartesian = 0x80000,
	kOsMaskRelPolar = 0x100000,
	kOsMaskNoneOverride = 0x200000
}
