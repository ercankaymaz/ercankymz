using System;

namespace Xbim.Common.Geometry;

public interface IGeometryStoreInitialiser : IDisposable
{
	int AddShapeGeometry(XbimShapeGeometry shapeGeometry);

	int AddShapeInstance(XbimShapeInstance shapeInstance, int geometryId);

	int AddRegions(XbimRegionCollection regions);

	void Commit();
}
