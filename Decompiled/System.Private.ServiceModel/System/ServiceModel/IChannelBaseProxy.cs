using System.ServiceModel.Channels;

namespace System.ServiceModel;

internal interface IChannelBaseProxy
{
	ServiceChannel GetServiceChannel();
}
