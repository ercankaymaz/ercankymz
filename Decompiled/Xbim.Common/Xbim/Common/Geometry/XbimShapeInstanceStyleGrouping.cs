using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xbim.Common.Geometry;

public class XbimShapeInstanceStyleGrouping : IGrouping<int, XbimShapeInstance>, IEnumerable<XbimShapeInstance>, IEnumerable
{
	private readonly IEnumerable<XbimShapeInstance> _shapeInstances;

	private readonly int _key;

	int IGrouping<int, XbimShapeInstance>.Key => _key;

	public XbimShapeInstanceStyleGrouping(int key, IEnumerable<XbimShapeInstance> shapeInstances)
	{
		_shapeInstances = shapeInstances;
		_key = key;
	}

	public IEnumerator<XbimShapeInstance> GetEnumerator()
	{
		return _shapeInstances.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _shapeInstances.GetEnumerator();
	}
}
