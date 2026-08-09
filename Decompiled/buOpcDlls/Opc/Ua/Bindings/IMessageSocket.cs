using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface IMessageSocket : IDisposable
{
	int Handle { get; }

	EndPoint LocalEndpoint { get; }

	TransportChannelFeatures MessageSocketFeatures { get; }

	Task<bool> BeginConnect(Uri endpointUrl, EventHandler<IMessageSocketAsyncEventArgs> callback, object state, CancellationToken cts);

	void Close();

	void ReadNextMessage();

	void ChangeSink(IMessageSink sink);

	bool SendAsync(IMessageSocketAsyncEventArgs args);

	IMessageSocketAsyncEventArgs MessageSocketEventArgs();
}
