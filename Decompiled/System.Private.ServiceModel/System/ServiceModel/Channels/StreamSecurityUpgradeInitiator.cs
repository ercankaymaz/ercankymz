using System.ServiceModel.Security;

namespace System.ServiceModel.Channels;

public abstract class StreamSecurityUpgradeInitiator : StreamUpgradeInitiator
{
	public abstract SecurityMessageProperty GetRemoteSecurity();

	internal static SecurityMessageProperty GetRemoteSecurity(StreamUpgradeInitiator upgradeInitiator)
	{
		if (upgradeInitiator is StreamSecurityUpgradeInitiator streamSecurityUpgradeInitiator)
		{
			return streamSecurityUpgradeInitiator.GetRemoteSecurity();
		}
		return null;
	}
}
