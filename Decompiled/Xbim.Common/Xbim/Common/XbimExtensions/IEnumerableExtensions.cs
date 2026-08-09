using System.Collections.Generic;

namespace Xbim.Common.XbimExtensions;

public static class IEnumerableExtensions
{
	public static XbimTriplet<T> AsTriplet<T>(this IEnumerable<T> coll)
	{
		return new XbimTriplet<T>(coll);
	}
}
