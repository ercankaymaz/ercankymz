using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public interface IXbimWireSet : IEnumerable<IXbimWire>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimWire First { get; }
}
