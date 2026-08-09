using System;

namespace Xbim.Common;

public interface IExpressValueType : IPersist
{
	Type UnderlyingSystemType { get; }

	object Value { get; }
}
