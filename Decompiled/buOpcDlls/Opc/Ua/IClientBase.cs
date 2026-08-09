using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IClientBase : IDisposable
{
	EndpointDescription Endpoint { get; }

	EndpointConfiguration EndpointConfiguration { get; }

	IServiceMessageContext MessageContext { get; }

	ITransportChannel TransportChannel { get; }

	DiagnosticsMasks ReturnDiagnostics { get; set; }

	int OperationTimeout { get; set; }

	bool Disposed { get; }

	void AttachChannel(ITransportChannel channel);

	void DetachChannel();

	StatusCode Close();

	uint NewRequestHandle();
}
