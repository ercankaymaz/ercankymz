using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void NotificationEventHandler(ISession session, NotificationEventArgs e);
