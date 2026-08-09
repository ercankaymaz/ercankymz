using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Isam.Esent.Interop;

internal class GenericEnumerable<T> : IEnumerable<T>, IEnumerable
{
	public delegate IEnumerator<T> CreateEnumerator();

	private readonly CreateEnumerator enumeratorCreator;

	public GenericEnumerable(CreateEnumerator enumeratorCreator)
	{
		this.enumeratorCreator = enumeratorCreator;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return enumeratorCreator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
