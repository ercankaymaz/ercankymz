using System;

namespace Xbim.Ifc.Fluent.Internal;

internal class StandardDateTimeGenerator : IDateTimeGenerator
{
	public DateTime Generate()
	{
		return DateTime.UtcNow;
	}
}
