using System;
using Microsoft.Extensions.Logging;

namespace Xbim.Common.Geometry;

public interface IXbimShell : IXbimGeometryObject, IDisposable, IEquatable<IXbimShell>
{
	IXbimFaceSet Faces { get; }

	IXbimEdgeSet Edges { get; }

	IXbimVertexSet Vertices { get; }

	double SurfaceArea { get; }

	bool IsPolyhedron { get; }

	bool IsClosed { get; }

	string ToBRep { get; }

	bool CanCreateSolid();

	IXbimSolid CreateSolid();

	IXbimGeometryObjectSet Cut(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Cut(IXbimSolid toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Union(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Union(IXbimSolid toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Intersection(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimGeometryObjectSet Intersection(IXbimSolid toCut, double tolerance, ILogger logger = null);

	IXbimFaceSet Section(IXbimFace toSection, double tolerance, ILogger logger = null);

	void SaveAsBrep(string fileName);
}
