using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SharpGLTF.Diagnostics;

internal sealed class _CollectionDebugProxy<T>
{
	private readonly ICollection<T> _Collection;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public T[] Items
	{
		get
		{
			T[] array = new T[_Collection.Count];
			_Collection.CopyTo(array, 0);
			return array;
		}
	}

	public _CollectionDebugProxy(ICollection<T> collection)
	{
		_Collection = collection ?? throw new ArgumentNullException("collection");
	}
}
