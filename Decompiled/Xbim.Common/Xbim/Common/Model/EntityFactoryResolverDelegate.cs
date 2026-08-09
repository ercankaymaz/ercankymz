using System.Collections.Generic;

namespace Xbim.Common.Model;

public delegate IEntityFactory EntityFactoryResolverDelegate(IEnumerable<string> schemas);
