using System.Collections;
using System.Collections.Generic;

namespace ACadSharp;

public interface ICadCollection<T> : IEnumerable<T>, IEnumerable where T : CadObject
{
	T TryAdd(T item);
}
