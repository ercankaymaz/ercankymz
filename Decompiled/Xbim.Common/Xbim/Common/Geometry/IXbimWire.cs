using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Xbim.Common.Geometry;

public interface IXbimWire : IXbimGeometryObject, IDisposable, IEquatable<IXbimWire>
{
	IXbimEdgeSet Edges { get; }

	IXbimVertexSet Vertices { get; }

	IEnumerable<XbimPoint3D> Points { get; }

	XbimVector3D Normal { get; }

	bool IsPlanar { get; }

	bool IsClosed { get; }

	XbimPoint3D Start { get; }

	XbimPoint3D End { get; }

	double Length { get; }

	string ToBRep { get; }

	IXbimWire Trim(double start, double end, double tolerance, ILogger logger = null);
}
