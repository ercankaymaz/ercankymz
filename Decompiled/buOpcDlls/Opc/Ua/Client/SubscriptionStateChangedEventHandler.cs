using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void SubscriptionStateChangedEventHandler(Subscription subscription, SubscriptionStateChangedEventArgs e);
