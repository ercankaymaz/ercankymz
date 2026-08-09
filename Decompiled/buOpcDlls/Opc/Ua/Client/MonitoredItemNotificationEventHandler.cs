using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void MonitoredItemNotificationEventHandler(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e);
