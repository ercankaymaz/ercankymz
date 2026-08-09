using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void PublishStateChangedEventHandler(Subscription subscription, PublishStateChangedEventArgs e);
