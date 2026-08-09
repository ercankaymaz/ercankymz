using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ServiceModel.Security;

internal static class EmptyReadOnlyCollection<T>
{
	public static ReadOnlyCollection<T> Instance = new ReadOnlyCollection<T>(new List<T>());
}
