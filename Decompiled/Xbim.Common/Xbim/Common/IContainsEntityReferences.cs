using System.Collections.Generic;

namespace Xbim.Common;

public interface IContainsEntityReferences : IPersistEntity, IPersist
{
	IEnumerable<IPersistEntity> References { get; }
}
