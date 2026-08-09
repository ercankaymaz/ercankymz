using System.Collections.Generic;
using System.ComponentModel;

namespace System.ServiceModel.Dispatcher;

[EditorBrowsable(EditorBrowsableState.Never)]
public class ClientOperationCompatBase
{
	internal SynchronizedCollection<IParameterInspector> parameterInspectors;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.", true)]
	public IList<IParameterInspector> ParameterInspectors => parameterInspectors;

	internal ClientOperationCompatBase()
	{
	}
}
