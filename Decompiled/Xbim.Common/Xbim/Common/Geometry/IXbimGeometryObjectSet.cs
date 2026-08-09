using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Xbim.Common.Geometry;

public interface IXbimGeometryObjectSet : IEnumerable<IXbimGeometryObject>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimGeometryObject First { get; }

	IXbimSolidSet Solids { get; }

	IXbimShellSet Shells { get; }

	IXbimFaceSet Faces { get; }

	IXbimEdgeSet Edges { get; }

	IXbimVertexSet Vertices { get; }

	string ToBRep { get; }

	void Add(IXbimGeometryObject shape);

	IXbimGeometryObjectSet Cut(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Cut(IXbimSolid toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Union(IXbimSolidSet toUnion, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Union(IXbimSolid toUnion, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Intersection(IXbimSolidSet toIntersect, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Intersection(IXbimSolid toIntersect, double tolerance, ILogger logger = null);

	bool Sew();
}
