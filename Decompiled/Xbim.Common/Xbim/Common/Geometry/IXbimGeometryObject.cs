using System;

namespace Xbim.Common.Geometry;

public interface IXbimGeometryObject : IDisposable
{
	XbimGeometryObjectType GeometryType { get; }

	bool IsValid { get; }

	bool IsSet { get; }

	XbimRect3D BoundingBox { get; }

	object Tag { get; set; }

	IXbimGeometryObject Transform(XbimMatrix3D matrix3D);

	IXbimGeometryObject TransformShallow(XbimMatrix3D matrix3D);
}
