using System.IdentityModel.Selectors;
using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel.Security;

internal class SupportingTokenProviderSpecification
{
	private SecurityTokenParameters _tokenParameters;

	public SecurityTokenProvider TokenProvider { get; }

	public SecurityTokenAttachmentMode SecurityTokenAttachmentMode { get; }

	public SecurityTokenParameters TokenParameters => _tokenParameters;

	public SupportingTokenProviderSpecification(SecurityTokenProvider tokenProvider, SecurityTokenAttachmentMode attachmentMode, SecurityTokenParameters tokenParameters)
	{
		SecurityTokenAttachmentModeHelper.Validate(attachmentMode);
		TokenProvider = tokenProvider ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenProvider");
		SecurityTokenAttachmentMode = attachmentMode;
		_tokenParameters = tokenParameters ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenParameters");
	}
}
