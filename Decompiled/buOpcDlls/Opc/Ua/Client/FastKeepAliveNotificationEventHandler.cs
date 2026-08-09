using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void FastKeepAliveNotificationEventHandler(Subscription subscription, NotificationData notification);
