using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class SecurityHeaderElementInferenceEngine
{
	public abstract void ExecuteProcessingPasses(ReceiveSecurityHeader securityHeader, XmlDictionaryReader reader);

	public abstract void MarkElements(ReceiveSecurityHeaderElementManager elementManager, bool messageSecurityMode);

	public static SecurityHeaderElementInferenceEngine GetInferenceEngine(SecurityHeaderLayout layout)
	{
		SecurityHeaderLayoutHelper.Validate(layout);
		if (layout == SecurityHeaderLayout.Strict)
		{
			return StrictModeSecurityHeaderElementInferenceEngine.Instance;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("layout"));
	}
}
