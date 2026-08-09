using System;
using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public interface IGeometryStoreReader : IDisposable
{
	IEnumerable<XbimShapeInstance> ShapeInstances { get; }

	IEnumerable<XbimShapeGeometry> ShapeGeometries { get; }

	ISet<int> StyleIds { get; }

	XbimContextRegionCollection ContextRegions { get; }

	IEnumerable<int> ContextIds { get; }

	IEnumerable<XbimShapeInstance> ShapeInstancesOfContext(int contextId);

	XbimShapeGeometry ShapeGeometry(int shapeGeometryLabel);

	XbimShapeGeometry ShapeGeometryOfInstance(XbimShapeInstance shapeInstance);

	IEnumerable<XbimShapeInstance> ShapeInstancesOfEntity(IPersistEntity entity);

	IEnumerable<XbimShapeInstance> ShapeInstancesOfEntity(int entityLabel);

	IEnumerable<XbimShapeInstance> ShapeInstancesOfEntityType(int entityTypeId);

	XbimRect3D BoundingBox(int entityLabel);

	IEnumerable<XbimShapeInstance> ShapeInstancesOfStyle(int styleLabel);

	IEnumerable<XbimShapeInstance> ShapeInstancesOfGeometry(int geometryLabel);
}
