using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace System.ServiceModel.Security;

internal sealed class WSSecurityOneDotOneSendSecurityHeader : WSSecurityOneDotZeroSendSecurityHeader
{
	public WSSecurityOneDotOneSendSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction)
		: base(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, direction)
	{
	}
}
