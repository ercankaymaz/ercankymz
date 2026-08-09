using System.Collections.Generic;

namespace Xbim.Common.XbimExtensions;

public struct XbimTriplet<T>
{
	public T A;

	public T B;

	public T C;

	public XbimTriplet(IEnumerable<T> coll)
	{
		IEnumerator<T> enumerator = coll.GetEnumerator();
		A = (enumerator.MoveNext() ? enumerator.Current : default(T));
		B = (enumerator.MoveNext() ? enumerator.Current : default(T));
		C = (enumerator.MoveNext() ? enumerator.Current : default(T));
	}
}
