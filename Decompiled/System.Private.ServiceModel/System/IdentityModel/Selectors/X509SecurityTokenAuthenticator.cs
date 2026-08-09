using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.ServiceModel;

namespace System.IdentityModel.Selectors;

public class X509SecurityTokenAuthenticator : SecurityTokenAuthenticator
{
	private X509CertificateValidator _validator;

	private bool _mapToWindows;

	private bool _includeWindowsGroups;

	private bool _cloneHandle;

	public X509SecurityTokenAuthenticator()
		: this(X509CertificateValidator.ChainTrust)
	{
	}

	public X509SecurityTokenAuthenticator(X509CertificateValidator validator)
		: this(validator, mapToWindows: false)
	{
	}

	public X509SecurityTokenAuthenticator(X509CertificateValidator validator, bool mapToWindows)
		: this(validator, mapToWindows, includeWindowsGroups: true)
	{
	}

	public X509SecurityTokenAuthenticator(X509CertificateValidator validator, bool mapToWindows, bool includeWindowsGroups)
		: this(validator, mapToWindows, includeWindowsGroups, cloneHandle: true)
	{
	}

	internal X509SecurityTokenAuthenticator(X509CertificateValidator validator, bool mapToWindows, bool includeWindowsGroups, bool cloneHandle)
	{
		_validator = validator ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("validator");
		_mapToWindows = mapToWindows;
		_includeWindowsGroups = includeWindowsGroups;
		_cloneHandle = cloneHandle;
	}

	protected override bool CanValidateTokenCore(SecurityToken token)
	{
		return token is X509SecurityToken;
	}

	protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
	{
		X509SecurityToken x509SecurityToken = (X509SecurityToken)token;
		_validator.Validate(x509SecurityToken.Certificate);
		X509CertificateClaimSet claimSet = new X509CertificateClaimSet(x509SecurityToken.Certificate, _cloneHandle);
		if (!_mapToWindows)
		{
			return SecurityUtils.CreateAuthorizationPolicies(claimSet, x509SecurityToken.ValidTo);
		}
		throw ExceptionHelper.PlatformNotSupported("Mapping to Windows identity not supported.");
	}
}
