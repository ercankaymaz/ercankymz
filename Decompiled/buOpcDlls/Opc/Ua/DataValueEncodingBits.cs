using System;

namespace Opc.Ua;

[Flags]
internal enum DataValueEncodingBits
{
	Value = 1,
	StatusCode = 2,
	SourceTimestamp = 4,
	ServerTimestamp = 8,
	SourcePicoseconds = 0x10,
	ServerPicoseconds = 0x20
}
