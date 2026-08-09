using System.IdentityModel.Tokens;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Security;

internal class SecurityProtocolCorrelationState
{
	public SecurityToken Token { get; }

	internal SignatureConfirmations SignatureConfirmations { get; set; }

	internal ServiceModelActivity Activity { get; }

	public SecurityProtocolCorrelationState(SecurityToken token)
	{
		Token = token;
		Activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.Current : null);
	}
}
