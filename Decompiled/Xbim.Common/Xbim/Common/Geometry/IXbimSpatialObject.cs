namespace Xbim.Common.Geometry;

public interface IXbimSpatialObject
{
	bool Equals(IXbimGeometryObject geom, double tolerance);

	bool Intersects(IXbimGeometryObject geom, double tolerance);

	bool Disjoint(IXbimGeometryObject geom, double tolerance);

	bool Touches(IXbimGeometryObject geom, double tolerance);

	bool Within(IXbimGeometryObject geom, double tolerance);

	bool Contains(IXbimGeometryObject geom, double tolerance);

	bool Relates(IXbimGeometryObject geom, double tolerance);
}
