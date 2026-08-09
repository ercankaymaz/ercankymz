using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate IServiceResponse ChannelSendRequestEventHandler(IServiceRequest request);
