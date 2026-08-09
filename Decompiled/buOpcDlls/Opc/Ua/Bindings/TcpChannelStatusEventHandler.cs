using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public delegate void TcpChannelStatusEventHandler(TcpServerChannel channel, ServiceResult status, bool closed);
