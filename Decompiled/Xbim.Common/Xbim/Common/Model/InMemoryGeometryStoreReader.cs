using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common.Geometry;

namespace Xbim.Common.Model;

internal class InMemoryGeometryStoreReader : IGeometryStoreReader, IDisposable
{
	private readonly InMemoryGeometryStore _inMemoryGeometryStore;

	public IEnumerable<XbimShapeInstance> ShapeInstances => _inMemoryGeometryStore.ShapeInstances.Values;

	public IEnumerable<XbimShapeGeometry> ShapeGeometries => _inMemoryGeometryStore.ShapeGeometries.Values.Where((XbimShapeGeometry g) => g.Format != XbimGeometryType.Region);

	public ISet<int> StyleIds => _inMemoryGeometryStore.Styles;

	public XbimContextRegionCollection ContextRegions => _inMemoryGeometryStore.ContextRegions;

	public IEnumerable<int> ContextIds => _inMemoryGeometryStore.ContextIds;

	public InMemoryGeometryStoreReader(InMemoryGeometryStore inMemoryGeometryStore)
	{
		_inMemoryGeometryStore = inMemoryGeometryStore;
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfContext(int contextId)
	{
		return _inMemoryGeometryStore.ShapeInstances.Values.Where((XbimShapeInstance s) => s.RepresentationContext == contextId);
	}

	public XbimShapeGeometry ShapeGeometry(int shapeGeometryLabel)
	{
		if (_inMemoryGeometryStore.ShapeGeometries.TryGetValue(shapeGeometryLabel, out var value))
		{
			return value;
		}
		return null;
	}

	public XbimShapeGeometry ShapeGeometryOfInstance(XbimShapeInstance shapeInstance)
	{
		return ShapeGeometry(shapeInstance.ShapeGeometryLabel);
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfEntity(IPersistEntity entity)
	{
		if (_inMemoryGeometryStore.EntityInstanceLookup.TryGetValue(entity.EntityLabel, out var value))
		{
			return value;
		}
		return Enumerable.Empty<XbimShapeInstance>();
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfEntity(int entityLabel)
	{
		if (_inMemoryGeometryStore.EntityInstanceLookup.TryGetValue(entityLabel, out var value))
		{
			return value;
		}
		return Enumerable.Empty<XbimShapeInstance>();
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfEntityType(int entityTypeId)
	{
		if (_inMemoryGeometryStore.EntityTypeLookup.TryGetValue(entityTypeId, out var value))
		{
			return value;
		}
		return Enumerable.Empty<XbimShapeInstance>();
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfStyle(int styleLabel)
	{
		if (_inMemoryGeometryStore.EntityStyleLookup.TryGetValue(styleLabel, out var value))
		{
			return value;
		}
		return Enumerable.Empty<XbimShapeInstance>();
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfGeometry(int geometryLabel)
	{
		if (_inMemoryGeometryStore.GeometryShapeLookup.TryGetValue(geometryLabel, out var value))
		{
			return value;
		}
		return Enumerable.Empty<XbimShapeInstance>();
	}

	public void Dispose()
	{
	}

	public XbimRect3D BoundingBox(int entityLabel)
	{
		XbimRect3D empty = XbimRect3D.Empty;
		foreach (XbimShapeInstance item in ShapeInstancesOfEntity(entityLabel))
		{
			empty.Union(item.BoundingBox);
		}
		return empty;
	}
}
