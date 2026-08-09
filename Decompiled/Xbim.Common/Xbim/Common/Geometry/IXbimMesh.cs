using System;

namespace Xbim.Common.Geometry;

public interface IXbimMesh : IXbimShell, IXbimGeometryObject, IDisposable, IEquatable<IXbimShell>
{
	bool IsSolid { get; }

	IXbimMesh Cut(IXbimMesh toCut, double tolerance);

	IXbimMesh Union(IXbimMesh toUnion, double tolerance);

	IXbimMesh Intersection(IXbimMesh toIntersect, double tolerance);

	IXbimMesh Section(IXbimMesh mesh, double tolerance);
}
