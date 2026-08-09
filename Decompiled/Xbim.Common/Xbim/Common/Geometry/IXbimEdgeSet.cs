using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public interface IXbimEdgeSet : IEnumerable<IXbimEdge>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimEdge First { get; }
}
