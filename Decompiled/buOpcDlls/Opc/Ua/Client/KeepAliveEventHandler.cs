using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void KeepAliveEventHandler(ISession session, KeepAliveEventArgs e);
