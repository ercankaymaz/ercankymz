namespace Microsoft.Windows.Design;

public delegate void SubscribeContextCallback(ContextItem item);
public delegate void SubscribeContextCallback<TContextItemType>(TContextItemType item) where TContextItemType : ContextItem;
