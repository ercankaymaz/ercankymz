using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ConnectionStatusEventArgs : EventArgs
{
	public Uri EndpointUrl { get; private set; }

	public ServiceResult ChannelStatus { get; private set; }

	public bool Closed { get; private set; }

	internal ConnectionStatusEventArgs(Uri endpointUrl, ServiceResult channelStatus, bool closed)
	{
		EndpointUrl = endpointUrl;
		ChannelStatus = channelStatus;
		Closed = closed;
	}
}
