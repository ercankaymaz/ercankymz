using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public interface IXbimCurveSet : IEnumerable<IXbimCurve>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimCurve First { get; }
}
