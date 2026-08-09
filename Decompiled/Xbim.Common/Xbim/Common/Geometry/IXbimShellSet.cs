using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Xbim.Common.Geometry;

public interface IXbimShellSet : IEnumerable<IXbimShell>, IEnumerable, IXbimGeometryObject, IDisposable
{
	int Count { get; }

	IXbimShell First { get; }

	bool IsPolyhedron { get; }

	IXbimGeometryObjectSet Cut(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Cut(IXbimSolid toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Union(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Union(IXbimSolid toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Intersection(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Intersection(IXbimSolid toCut, double tolerance, ILogger logger = null);

	void Add(IXbimGeometryObject shape);

	void Union(double tolerance);
}
