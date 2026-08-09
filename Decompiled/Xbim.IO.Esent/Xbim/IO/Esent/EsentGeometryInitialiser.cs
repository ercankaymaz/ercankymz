using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Isam.Esent.Interop;
using Xbim.Common.Geometry;

namespace Xbim.IO.Esent;

internal class EsentGeometryInitialiser : IGeometryStoreInitialiser, IDisposable
{
	private const int TransactionBatchSize = 100;

	private readonly EsentGeometryStore _esentGeometryStore;

	private readonly EsentShapeGeometryCursor _shapeGeometryCursor;

	private readonly EsentShapeInstanceCursor _shapeInstanceCursor;

	private EsentLazyDBTransaction _shapeGeometryTransaction;

	private EsentLazyDBTransaction _shapeInstanceTransaction;

	private int _geometryCount;

	private int _instanceCount;

	private IntPtr _geometryContextId;

	private IntPtr _instanceContextId;

	private bool _disposed;

	public EsentGeometryInitialiser(EsentGeometryStore esentGeometryStore, EsentShapeGeometryCursor shapeGeometryCursor, EsentShapeInstanceCursor shapeInstanceCursor)
	{
		try
		{
			_esentGeometryStore = esentGeometryStore;
			_shapeGeometryCursor = shapeGeometryCursor;
			_shapeInstanceCursor = shapeInstanceCursor;
			_geometryContextId = new IntPtr(_shapeGeometryCursor.GetHashCode());
			_instanceContextId = new IntPtr(_shapeInstanceCursor.GetHashCode());
			SetGeometryContext();
			try
			{
				_shapeGeometryTransaction = _shapeGeometryCursor.BeginLazyTransaction();
			}
			finally
			{
				ResetGeometryContext();
			}
			SetInstanceContext();
			try
			{
				_shapeInstanceTransaction = _shapeInstanceCursor.BeginLazyTransaction();
			}
			finally
			{
				ResetInstanceContext();
			}
			_geometryCount = 0;
			_instanceCount = 0;
		}
		catch (Exception innerException)
		{
			throw new Exception("Error creating transactions", innerException);
		}
	}

	public int AddShapeGeometry(XbimShapeGeometry shapeGeometry)
	{
		lock (_shapeGeometryCursor)
		{
			SetGeometryContext();
			try
			{
				if ((long)(_geometryCount % 100) == 99)
				{
					_shapeGeometryTransaction.Commit();
					_shapeGeometryTransaction.Begin();
				}
				_geometryCount++;
				return _shapeGeometryCursor.AddGeometry(shapeGeometry);
			}
			finally
			{
				ResetGeometryContext();
			}
		}
	}

	public int AddShapeInstance(XbimShapeInstance shapeInstance, int geometryId)
	{
		lock (_shapeInstanceCursor)
		{
			SetInstanceContext();
			try
			{
				if ((long)(_instanceCount % 100) == 99)
				{
					_shapeInstanceTransaction.Commit();
					_shapeInstanceTransaction.Begin();
				}
				_instanceCount++;
				shapeInstance.ShapeGeometryLabel = geometryId;
				return _shapeInstanceCursor.AddInstance(shapeInstance);
			}
			finally
			{
				ResetInstanceContext();
			}
		}
	}

	public int AddRegions(XbimRegionCollection regions)
	{
		lock (_shapeGeometryCursor)
		{
			SetGeometryContext();
			try
			{
				_geometryCount++;
				return _shapeGeometryCursor.AddGeometry(regions);
			}
			finally
			{
				ResetGeometryContext();
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Dispose(bool disposing)
	{
		if (_disposed)
		{
			return;
		}
		if (disposing)
		{
			SetGeometryContext();
			try
			{
				_shapeGeometryTransaction.Dispose();
			}
			finally
			{
				ResetGeometryContext();
			}
			SetInstanceContext();
			try
			{
				_shapeInstanceTransaction.Dispose();
			}
			finally
			{
				ResetInstanceContext();
			}
		}
		_disposed = true;
	}

	internal void Commit()
	{
		SetGeometryContext();
		try
		{
			_shapeGeometryTransaction.Commit();
		}
		finally
		{
			ResetGeometryContext();
		}
		SetInstanceContext();
		try
		{
			_shapeInstanceTransaction.Commit();
		}
		finally
		{
			ResetInstanceContext();
		}
	}

	internal void UpdateReferenceCounts()
	{
		lock (_shapeGeometryCursor)
		{
			SetGeometryContext();
			SetInstanceContext();
			try
			{
				_shapeGeometryTransaction.Commit();
				_shapeGeometryTransaction.Begin();
				_shapeInstanceTransaction.Commit();
				_shapeInstanceTransaction.Begin();
				using IGeometryStoreReader geometryStoreReader = _esentGeometryStore.BeginRead();
				foreach (var item in geometryStoreReader.ShapeInstances.GroupBy((XbimShapeInstance i) => i.ShapeGeometryLabel, (int label, IEnumerable<XbimShapeInstance> instances) => new
				{
					Label = label,
					Count = instances.Count()
				}))
				{
					if ((long)(_geometryCount % 100) == 99)
					{
						_shapeGeometryTransaction.Commit();
						_shapeGeometryTransaction.Begin();
					}
					_geometryCount++;
					_shapeGeometryCursor.UpdateReferenceCount(item.Label, item.Count);
				}
			}
			finally
			{
				ResetGeometryContext();
				ResetInstanceContext();
			}
		}
	}

	void IGeometryStoreInitialiser.Commit()
	{
		_esentGeometryStore.EndInit(this);
	}

	private void SetGeometryContext()
	{
		Api.JetSetSessionContext(_shapeGeometryCursor.Session, _geometryContextId);
	}

	private void SetInstanceContext()
	{
		Api.JetSetSessionContext(_shapeInstanceCursor.Session, _instanceContextId);
	}

	private void ResetGeometryContext()
	{
		Api.JetResetSessionContext(_shapeGeometryCursor.Session);
	}

	private void ResetInstanceContext()
	{
		Api.JetResetSessionContext(_shapeInstanceCursor.Session);
	}
}
