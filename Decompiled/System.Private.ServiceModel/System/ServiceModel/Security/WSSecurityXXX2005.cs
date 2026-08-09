using System.Collections.Generic;
using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security;

internal class WSSecurityXXX2005 : WSSecurityJan2004
{
	public WSSecurityXXX2005(WSSecurityTokenSerializer tokenSerializer, SamlSerializer samlSerializer)
		: base(tokenSerializer, samlSerializer)
	{
	}

	public override void PopulateTokenEntries(IList<WSSecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		PopulateJan2004TokenEntries(tokenEntryList);
	}
}
