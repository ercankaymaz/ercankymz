using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public delegate void TcpChannelStateEventHandler(UaSCUaBinaryChannel channel, TcpChannelState state, ServiceResult error);
