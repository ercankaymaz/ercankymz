using System.IdentityModel.Selectors;
using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel.Security;

internal class SupportingTokenAuthenticatorSpecification
{
	private bool _isTokenOptional;

	public SecurityTokenAuthenticator TokenAuthenticator { get; }

	public SecurityTokenResolver TokenResolver { get; }

	public SecurityTokenAttachmentMode SecurityTokenAttachmentMode { get; }

	public SecurityTokenParameters TokenParameters { get; }

	internal bool IsTokenOptional
	{
		get
		{
			return _isTokenOptional;
		}
		set
		{
			_isTokenOptional = value;
		}
	}

	public SupportingTokenAuthenticatorSpecification(SecurityTokenAuthenticator tokenAuthenticator, SecurityTokenResolver securityTokenResolver, SecurityTokenAttachmentMode attachmentMode, SecurityTokenParameters tokenParameters)
		: this(tokenAuthenticator, securityTokenResolver, attachmentMode, tokenParameters, isTokenOptional: false)
	{
	}

	internal SupportingTokenAuthenticatorSpecification(SecurityTokenAuthenticator tokenAuthenticator, SecurityTokenResolver securityTokenResolver, SecurityTokenAttachmentMode attachmentMode, SecurityTokenParameters tokenParameters, bool isTokenOptional)
	{
		SecurityTokenAttachmentModeHelper.Validate(attachmentMode);
		TokenAuthenticator = tokenAuthenticator ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenAuthenticator");
		TokenResolver = securityTokenResolver;
		SecurityTokenAttachmentMode = attachmentMode;
		TokenParameters = tokenParameters ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenParameters");
		_isTokenOptional = isTokenOptional;
	}
}
