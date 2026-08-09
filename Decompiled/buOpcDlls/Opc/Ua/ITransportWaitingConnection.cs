using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ITransportWaitingConnection
{
	string ServerUri { get; }

	Uri EndpointUrl { get; }

	object Handle { get; }
}
