using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public enum ExtensionObjectEncoding
{
	None,
	Binary,
	Xml,
	EncodeableObject,
	Json
}
