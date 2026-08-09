using System;

namespace Opc.Ua;

[Flags]
internal enum DiagnosticInfoEncodingBits
{
	SymbolicId = 1,
	NamespaceUri = 2,
	LocalizedText = 4,
	Locale = 8,
	AdditionalInfo = 0x10,
	InnerStatusCode = 0x20,
	InnerDiagnosticInfo = 0x40
}
