using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public interface IXbimMeshSet : IEnumerable<IXbimMesh>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimMesh First { get; }
}
