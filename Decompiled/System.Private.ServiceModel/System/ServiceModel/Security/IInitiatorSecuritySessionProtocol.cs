using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security;

internal interface IInitiatorSecuritySessionProtocol
{
	bool ReturnCorrelationState { get; set; }

	SecurityToken GetOutgoingSessionToken();

	void SetIdentityCheckAuthenticator(SecurityTokenAuthenticator tokenAuthenticator);

	void SetOutgoingSessionToken(SecurityToken token);

	List<SecurityToken> GetIncomingSessionTokens();

	void SetIncomingSessionTokens(List<SecurityToken> tokens);
}
