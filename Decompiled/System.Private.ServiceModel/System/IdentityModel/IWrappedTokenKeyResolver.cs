using System.IdentityModel.Tokens;

namespace System.IdentityModel;

internal interface IWrappedTokenKeyResolver
{
	SecurityToken ExpectedWrapper { get; set; }

	bool CheckExternalWrapperMatch(SecurityKeyIdentifier keyIdentifier);
}
