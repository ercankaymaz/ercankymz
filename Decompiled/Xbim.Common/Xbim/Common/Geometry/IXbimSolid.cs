using System;
using Microsoft.Extensions.Logging;

namespace Xbim.Common.Geometry;

public interface IXbimSolid : IXbimGeometryObject, IDisposable, IEquatable<IXbimSolid>
{
	IXbimShellSet Shells { get; }

	IXbimFaceSet Faces { get; }

	IXbimEdgeSet Edges { get; }

	IXbimVertexSet Vertices { get; }

	double Volume { get; }

	double SurfaceArea { get; }

	bool IsPolyhedron { get; }

	string ToBRep { get; }

	IXbimSolidSet Cut(IXbimSolidSet toCut, double tolerance, ILogger logger = null);

	IXbimSolidSet Cut(IXbimSolid toCut, double tolerance, ILogger logger = null);

	IXbimSolidSet Union(IXbimSolidSet toUnion, double tolerance, ILogger logger = null);

	IXbimSolidSet Union(IXbimSolid toUnion, double tolerance, ILogger logger = null);

	IXbimSolidSet Intersection(IXbimSolidSet toIntersect, double tolerance, ILogger logger = null);

	IXbimSolidSet Intersection(IXbimSolid toIntersect, double tolerance, ILogger logger = null);

	IXbimFaceSet Section(IXbimFace toSection, double tolerance, ILogger logger = null);

	void SaveAsBrep(string fileName);
}
