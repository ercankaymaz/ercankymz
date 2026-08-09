using System.Collections;
using System.Collections.Generic;

namespace SharpGLTF.Memory;

public interface IAccessorArray<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IList<T>, ICollection<T>
{
	new T this[int index] { get; set; }

	new int Count { get; }
}
