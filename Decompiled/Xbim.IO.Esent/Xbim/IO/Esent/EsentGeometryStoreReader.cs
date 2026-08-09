using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Geometry;

namespace Xbim.IO.Esent;

internal class EsentGeometryStoreReader : IGeometryStoreReader, IDisposable
{
	private readonly EsentModel _esentModel;

	private readonly EsentShapeGeometryCursor _shapeGeometryCursor;

	private readonly EsentShapeInstanceCursor _shapeInstanceCursor;

	private EsentReadOnlyTransaction _shapeGeometryTransaction;

	private EsentReadOnlyTransaction _shapeInstanceTransaction;

	private readonly XbimContextRegionCollection _regionsList;

	private readonly HashSet<int> _contextIds;

	public IEnumerable<XbimShapeInstance> ShapeInstances
	{
		get
		{
			IXbimShapeInstanceData shapeInstance = new XbimShapeInstance();
			if (_shapeInstanceCursor.TrySeekShapeInstance(ref shapeInstance))
			{
				do
				{
					yield return (XbimShapeInstance)shapeInstance;
					shapeInstance = new XbimShapeInstance();
				}
				while (_shapeInstanceCursor.TryMoveNextShapeInstance(ref shapeInstance));
			}
		}
	}

	public IEnumerable<XbimShapeGeometry> ShapeGeometries
	{
		get
		{
			IXbimShapeGeometryData sg = new XbimShapeGeometry();
			if (!_shapeGeometryCursor.TryMoveFirstShapeGeometry(ref sg))
			{
				yield break;
			}
			do
			{
				if (sg.Format != 4)
				{
					yield return (XbimShapeGeometry)sg;
				}
				sg = new XbimShapeGeometry();
			}
			while (_shapeGeometryCursor.TryMoveNextShapeGeometry(ref sg));
		}
	}

	public ISet<int> StyleIds
	{
		get
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int contextId in _contextIds)
			{
				if (!_shapeInstanceCursor.TryMoveFirstSurfaceStyle(contextId, out var surfaceStyle, out var _))
				{
					continue;
				}
				do
				{
					if (surfaceStyle > 0)
					{
						hashSet.Add(surfaceStyle);
					}
					surfaceStyle = _shapeInstanceCursor.SkipSurfaceStyes(surfaceStyle);
				}
				while (surfaceStyle != -1);
			}
			return hashSet;
		}
	}

	public XbimContextRegionCollection ContextRegions => _regionsList;

	public IEnumerable<int> ContextIds
	{
		get
		{
			foreach (XbimRegionCollection contextRegion in ContextRegions)
			{
				yield return contextRegion.ContextLabel;
			}
		}
	}

	public EsentGeometryStoreReader(EsentModel esentModel)
	{
		_esentModel = esentModel;
		_shapeGeometryCursor = _esentModel.GetShapeGeometryTable();
		_shapeInstanceCursor = _esentModel.GetShapeInstanceTable();
		_shapeGeometryTransaction = _shapeGeometryCursor.BeginReadOnlyTransaction();
		_shapeInstanceTransaction = _shapeInstanceCursor.BeginReadOnlyTransaction();
		_regionsList = new XbimContextRegionCollection();
		IXbimShapeGeometryData sg = new XbimRegionCollection();
		if (_shapeGeometryCursor.TryMoveFirstRegion(ref sg))
		{
			do
			{
				_regionsList.Add((XbimRegionCollection)sg);
				sg = new XbimRegionCollection();
			}
			while (_shapeGeometryCursor.TryMoveNextRegion(ref sg));
		}
		if (!_regionsList.Any())
		{
			XbimGeometryCursor geometryTable = _esentModel.GetGeometryTable();
			using (geometryTable.BeginReadOnlyTransaction())
			{
				foreach (XbimGeometryData geometryDatum in geometryTable.GetGeometryData(XbimGeometryType.Region))
				{
					_regionsList.Add(XbimRegionCollection.FromArray(geometryDatum.ShapeData));
				}
			}
			_esentModel.FreeTable(geometryTable);
		}
		_contextIds = new HashSet<int>(ContextIds);
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfContext(int contextId)
	{
		IXbimShapeInstanceData si = new XbimShapeInstance();
		if (_shapeInstanceCursor.TrySeekShapeInstance(contextId, ref si))
		{
			do
			{
				yield return (XbimShapeInstance)si;
				si = new XbimShapeInstance();
			}
			while (_shapeInstanceCursor.TryMoveNextShapeInstance(ref si));
		}
	}

	public XbimShapeGeometry ShapeGeometry(int shapeGeometryLabel)
	{
		IXbimShapeGeometryData sg = new XbimShapeGeometry();
		_shapeGeometryCursor.TryGetShapeGeometry(shapeGeometryLabel, ref sg);
		return (XbimShapeGeometry)sg;
	}

	public XbimShapeGeometry ShapeGeometryOfInstance(XbimShapeInstance shapeInstance)
	{
		return ShapeGeometry(shapeInstance.ShapeGeometryLabel);
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfEntity(IPersistEntity entity)
	{
		return ShapeInstancesOfEntity(entity.EntityLabel);
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfEntity(int entityLabel)
	{
		IXbimShapeInstanceData si = new XbimShapeInstance();
		if (!_shapeInstanceCursor.TrySeekShapeInstanceOfProduct(entityLabel, ref si))
		{
			yield break;
		}
		do
		{
			if (_contextIds.Contains(si.RepresentationContext))
			{
				yield return (XbimShapeInstance)si;
				si = new XbimShapeInstance();
			}
		}
		while (_shapeInstanceCursor.TryMoveNextShapeInstance(ref si));
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfStyle(int styleLabel)
	{
		IXbimShapeInstanceData shapeInstance = new XbimShapeInstance();
		foreach (int contextId in _contextIds)
		{
			if (_shapeInstanceCursor.TrySeekSurfaceStyle(contextId, styleLabel, ref shapeInstance))
			{
				do
				{
					yield return (XbimShapeInstance)shapeInstance;
					shapeInstance = new XbimShapeInstance();
				}
				while (_shapeInstanceCursor.TryMoveNextShapeInstance(ref shapeInstance) && shapeInstance.StyleLabel == styleLabel);
			}
		}
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfGeometry(int geometryLabel)
	{
		IXbimShapeInstanceData si = new XbimShapeInstance();
		if (!_shapeInstanceCursor.TrySeekShapeInstanceOfGeometry(geometryLabel, ref si))
		{
			yield break;
		}
		do
		{
			if (_contextIds.Contains(si.RepresentationContext))
			{
				yield return (XbimShapeInstance)si;
				si = new XbimShapeInstance();
			}
		}
		while (_shapeInstanceCursor.TryMoveNextShapeInstance(ref si));
	}

	public bool EntityHasShapeInstances(IPersistEntity entity)
	{
		return _shapeInstanceCursor.TrySeekShapeInstanceOfProduct(entity.EntityLabel);
	}

	public void Dispose()
	{
		_shapeInstanceTransaction.Dispose();
		_shapeGeometryTransaction.Dispose();
		if (_shapeGeometryCursor != null)
		{
			_esentModel.FreeTable(_shapeGeometryCursor);
		}
		if (_shapeInstanceCursor != null)
		{
			_esentModel.FreeTable(_shapeInstanceCursor);
		}
	}

	public IEnumerable<XbimShapeInstance> ShapeInstancesOfEntityType(int entityTypeId)
	{
		IXbimShapeInstanceData shapeInstance = new XbimShapeInstance();
		if (!_shapeInstanceCursor.TrySeekProductType((short)entityTypeId, ref shapeInstance))
		{
			yield break;
		}
		do
		{
			if (_contextIds.Contains(shapeInstance.RepresentationContext))
			{
				yield return (XbimShapeInstance)shapeInstance;
				shapeInstance = new XbimShapeInstance();
			}
		}
		while (_shapeInstanceCursor.TryMoveNextShapeInstance(ref shapeInstance) && shapeInstance.IfcTypeId == entityTypeId);
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
