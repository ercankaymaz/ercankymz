using System.Collections.ObjectModel;
using System.Net;
using System.Security.Principal;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public class KerberosRequestorSecurityToken : SecurityToken
{
	private string _id;

	private DateTime _effectiveTime;

	private DateTime _expirationTime;

	public override string Id => _id;

	public override ReadOnlyCollection<SecurityKey> SecurityKeys => EmptyReadOnlyCollection<SecurityKey>.Instance;

	public override DateTime ValidFrom => _effectiveTime;

	public override DateTime ValidTo => _expirationTime;

	public string ServicePrincipalName { get; }

	internal KerberosRequestorSecurityToken(string servicePrincipalName, TokenImpersonationLevel tokenImpersonationLevel, NetworkCredential networkCredential, string id)
	{
		if (tokenImpersonationLevel != TokenImpersonationLevel.Identification && tokenImpersonationLevel != TokenImpersonationLevel.Impersonation)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("tokenImpersonationLevel", System.SR.Format(System.SR.ImpersonationLevelNotSupported, tokenImpersonationLevel)));
		}
		ServicePrincipalName = servicePrincipalName ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("servicePrincipalName");
		if (networkCredential != null && networkCredential != CredentialCache.DefaultNetworkCredentials && string.IsNullOrEmpty(networkCredential.UserName))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.ProvidedNetworkCredentialsForKerberosHasInvalidUserName);
		}
		_id = id ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("id");
	}
}
