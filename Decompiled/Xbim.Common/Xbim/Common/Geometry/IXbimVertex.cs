using System;

namespace Xbim.Common.Geometry;

public interface IXbimVertex : IXbimGeometryObject, IDisposable, IEquatable<IXbimVertex>
{
	XbimPoint3D VertexGeometry { get; }

	string ToBRep { get; }
}
