using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace System.ServiceModel.Dispatcher;

[EditorBrowsable(EditorBrowsableState.Never)]
public class ClientRuntimeCompatBase
{
	internal SynchronizedCollection<IClientMessageInspector> messageInspectors;

	internal SynchronizedKeyedCollection<string, ClientOperation> operations;

	internal KeyedCollection<string, ClientOperation> compatOperations;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.", true)]
	public IList<IClientMessageInspector> MessageInspectors => messageInspectors;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.", true)]
	public KeyedCollection<string, ClientOperation> Operations => compatOperations;

	internal ClientRuntimeCompatBase()
	{
	}
}
