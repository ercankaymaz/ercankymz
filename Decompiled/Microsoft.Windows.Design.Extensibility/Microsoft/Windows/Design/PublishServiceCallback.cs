using System;

namespace Microsoft.Windows.Design;

public delegate object PublishServiceCallback(Type serviceType);
public delegate TServiceType PublishServiceCallback<TServiceType>();
