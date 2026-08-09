using System.Security.Authentication.ExtendedProtection;

namespace System.ServiceModel.Channels;

internal interface IStreamUpgradeChannelBindingProvider : IChannelBindingProvider
{
	ChannelBinding GetChannelBinding(StreamUpgradeInitiator upgradeInitiator, ChannelBindingKind kind);
}
