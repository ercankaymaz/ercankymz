using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void FastDataChangeNotificationEventHandler(Subscription subscription, DataChangeNotification notification, IList<string> stringTable);
