using System.Runtime.InteropServices;

namespace System.Formats.Asn1;

[ComVisible(true)]
public enum TagClass
{
	Universal = 0,
	Application = 64,
	ContextSpecific = 128,
	Private = 192
}
