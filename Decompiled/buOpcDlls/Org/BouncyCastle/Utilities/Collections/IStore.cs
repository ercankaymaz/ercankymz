using System.Collections.Generic;

namespace Org.BouncyCastle.Utilities.Collections;

public interface IStore<out T>
{
	IEnumerable<T> EnumerateMatches(ISelector<T> selector);
}
