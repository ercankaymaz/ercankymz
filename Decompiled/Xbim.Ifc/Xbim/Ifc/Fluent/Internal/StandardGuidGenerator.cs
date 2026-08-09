using System;
using Xbim.Common;

namespace Xbim.Ifc.Fluent.Internal;

internal class StandardGuidGenerator : IGuidGenerator
{
	public Guid GenerateForEntity(IPersistEntity entity)
	{
		return Guid.NewGuid();
	}
}
