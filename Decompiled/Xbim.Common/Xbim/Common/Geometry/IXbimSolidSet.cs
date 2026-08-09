using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Xbim.Common.Geometry;

public interface IXbimSolidSet : IEnumerable<IXbimSolid>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimSolid First { get; }

	bool IsPolyhedron { get; }

	bool IsSimplified { get; }

	string ToBRep { get; }

	void Add(IXbimGeometryObject shape);

	IXbimSolidSet Cut(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimSolidSet Cut(IXbimSolid toCut, double tolerance, ILogger logger = null);

	IXbimSolidSet Union(IXbimSolidSet toUnion, double tolerance, ILogger logger = null);

	IXbimSolidSet Union(IXbimSolid toUnion, double tolerance, ILogger logger = null);

	IXbimSolidSet Intersection(IXbimSolidSet toIntersect, double tolerance, ILogger logger = null);

	IXbimSolidSet Intersection(IXbimSolid toIntersect, double tolerance, ILogger logger = null);

	IXbimSolidSet Range(int start, int count);
}
