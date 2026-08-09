using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ConnectionWaitingEventArgs : EventArgs, ITransportWaitingConnection
{
	public string ServerUri { get; private set; }

	public Uri EndpointUrl { get; private set; }

	public virtual object Handle => null;

	public bool Accepted { get; set; }

	protected ConnectionWaitingEventArgs(string serverUri, Uri endpointUrl)
	{
		ServerUri = serverUri;
		EndpointUrl = endpointUrl;
		Accepted = false;
	}
}
