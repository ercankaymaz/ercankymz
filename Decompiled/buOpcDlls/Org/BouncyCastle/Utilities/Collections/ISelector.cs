using System;

namespace Org.BouncyCastle.Utilities.Collections;

public interface ISelector<in T> : ICloneable
{
	bool Match(T candidate);
}
