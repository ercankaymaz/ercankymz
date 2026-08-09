using System;

namespace Opc.Ua;

[Flags]
internal enum ExtensionObjectEncodingBits
{
	TypeId = 1,
	BinaryBody = 2,
	XmlBody = 4
}
