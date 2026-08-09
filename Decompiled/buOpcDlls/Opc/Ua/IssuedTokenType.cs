using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public enum IssuedTokenType
{
	GenericWSS,
	SAML,
	JWT,
	KerberosBinary
}
