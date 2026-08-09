using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum SetColumnGrbit
{
	None = 0,
	AppendLV = 1,
	OverwriteLV = 4,
	RevertToDefaultValue = 0x200,
	SeparateLV = 0x40,
	SizeLV = 8,
	UniqueMultiValues = 0x80,
	UniqueNormalizedMultiValues = 0x100,
	ZeroLength = 0x20,
	IntrinsicLV = 0x400
}
