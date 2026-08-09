using System;

namespace Opc.Ua;

[Flags]
internal enum VariantArrayEncodingBits
{
	Array = 0x80,
	ArrayDimensions = 0x40,
	TypeMask = 0x3F
}
