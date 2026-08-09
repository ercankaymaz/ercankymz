using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public delegate void TcpChannelRequestEventHandler(TcpListenerChannel channel, uint requestId, IServiceRequest request);
