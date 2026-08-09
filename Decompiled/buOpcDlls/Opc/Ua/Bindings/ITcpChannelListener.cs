using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface ITcpChannelListener
{
	Uri EndpointUrl { get; }

	bool ReconnectToExistingChannel(IMessageSocket socket, uint requestId, uint sequenceNumber, uint channelId, X509Certificate2 clientCertificate, ChannelToken token, OpenSecureChannelRequest request);

	Task<bool> TransferListenerChannel(uint channelId, string serverUri, Uri endpointUrl);

	void ChannelClosed(uint channelId);
}
