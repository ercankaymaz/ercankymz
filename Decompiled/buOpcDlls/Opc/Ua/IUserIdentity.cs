using System.Runtime.InteropServices;
using System.Xml;

namespace Opc.Ua;

[ComVisible(true)]
public interface IUserIdentity
{
	string DisplayName { get; }

	string PolicyId { get; }

	UserTokenType TokenType { get; }

	XmlQualifiedName IssuedTokenType { get; }

	bool SupportsSignatures { get; }

	NodeIdCollection GrantedRoleIds { get; set; }

	UserIdentityToken GetIdentityToken();
}
