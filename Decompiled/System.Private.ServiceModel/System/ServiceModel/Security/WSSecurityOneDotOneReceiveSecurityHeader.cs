using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace System.ServiceModel.Security;

internal class WSSecurityOneDotOneReceiveSecurityHeader : WSSecurityOneDotZeroReceiveSecurityHeader
{
	public WSSecurityOneDotOneReceiveSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, int headerIndex, MessageDirection direction)
		: base(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, headerIndex, direction)
	{
	}
}
