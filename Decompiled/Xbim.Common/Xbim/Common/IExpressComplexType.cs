using System.Collections.Generic;

namespace Xbim.Common;

public interface IExpressComplexType : IExpressValueType, IPersist
{
	IEnumerable<object> Properties { get; }
}
