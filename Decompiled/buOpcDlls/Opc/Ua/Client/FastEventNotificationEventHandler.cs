using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void FastEventNotificationEventHandler(Subscription subscription, EventNotificationList notification, IList<string> stringTable);
