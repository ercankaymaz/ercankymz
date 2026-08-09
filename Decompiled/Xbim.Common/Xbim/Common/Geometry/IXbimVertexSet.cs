using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public interface IXbimVertexSet : IEnumerable<IXbimVertex>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimVertex First { get; }
}
