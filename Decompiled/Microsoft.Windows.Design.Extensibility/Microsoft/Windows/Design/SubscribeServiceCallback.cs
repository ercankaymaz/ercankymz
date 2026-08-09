using System;

namespace Microsoft.Windows.Design;

public delegate void SubscribeServiceCallback(Type serviceType, object serviceInstance);
public delegate void SubscribeServiceCallback<TServiceType>(TServiceType serviceInstance);
