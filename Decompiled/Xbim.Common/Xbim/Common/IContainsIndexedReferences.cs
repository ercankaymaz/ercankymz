using System.Collections.Generic;

namespace Xbim.Common;

public interface IContainsIndexedReferences : IPersistEntity, IPersist
{
	IEnumerable<IPersistEntity> IndexedReferences { get; }
}
