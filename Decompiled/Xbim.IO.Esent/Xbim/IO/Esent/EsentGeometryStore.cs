using System;
using Microsoft.Extensions.Logging;
using Xbim.Common.Configuration;
using Xbim.Common.Geometry;

namespace Xbim.IO.Esent;

internal class EsentGeometryStore : IGeometryStore, IDisposable
{
	private ILogger Log;

	private readonly EsentModel _esentModel;

	private EsentGeometryInitialiser _currentTransaction;

	private EsentShapeInstanceCursor _shapeInstanceCursor;

	private EsentShapeGeometryCursor _shapeGeometryCursor;

	private bool _disposed;

	private EsentModel.TableStatus _tableStatus;

	public EsentModel Model => _esentModel;

	private EsentModel.TableStatus TableStatus
	{
		get
		{
			if (_tableStatus == EsentModel.TableStatus.Unknown)
			{
				_tableStatus = (_esentModel.Cache.HasTable(EsentShapeGeometryCursor.GeometryTableName) ? EsentModel.TableStatus.Found : EsentModel.TableStatus.Missing);
			}
			return _tableStatus;
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (TableStatus == EsentModel.TableStatus.Missing)
			{
				return true;
			}
			EsentShapeGeometryCursor esentShapeGeometryCursor = null;
			try
			{
				IXbimShapeGeometryData sg = new XbimShapeGeometry();
				esentShapeGeometryCursor = _esentModel.GetShapeGeometryTable();
				using (esentShapeGeometryCursor.BeginReadOnlyTransaction())
				{
					return !esentShapeGeometryCursor.TryMoveFirstShapeGeometry(ref sg);
				}
			}
			catch (Exception)
			{
				Log.LogWarning("Esent model {0} does not contain geometry tables.", _esentModel.DatabaseName);
				return true;
			}
			finally
			{
				if (esentShapeGeometryCursor != null)
				{
					_esentModel.FreeTable(esentShapeGeometryCursor);
				}
			}
		}
	}

	public EsentGeometryStore(EsentModel esentModel)
	{
		_esentModel = esentModel;
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		Log = loggerFactory.CreateLogger<EsentGeometryStore>();
	}

	public IGeometryStoreInitialiser BeginInit()
	{
		try
		{
			if (_currentTransaction == null)
			{
				if (_shapeGeometryCursor != null)
				{
					_shapeGeometryCursor.Dispose();
					_shapeGeometryCursor = null;
				}
				if (_shapeInstanceCursor != null)
				{
					_shapeInstanceCursor.Dispose();
					_shapeInstanceCursor = null;
				}
				_esentModel.ClearGeometryTables();
				_shapeGeometryCursor = _esentModel.GetShapeGeometryTable();
				_shapeInstanceCursor = _esentModel.GetShapeInstanceTable();
				_currentTransaction = new EsentGeometryInitialiser(this, _shapeGeometryCursor, _shapeInstanceCursor);
				return _currentTransaction;
			}
			throw new Exception("A transaction is in operation on the geometry store");
		}
		catch (Exception innerException)
		{
			if (_shapeGeometryCursor != null)
			{
				_esentModel.FreeTable(_shapeGeometryCursor);
			}
			if (_shapeInstanceCursor != null)
			{
				_esentModel.FreeTable(_shapeInstanceCursor);
			}
			_currentTransaction = null;
			throw new Exception("Begin initialisation failed on Geometry Store", innerException);
		}
	}

	internal void EndInit(IGeometryStoreInitialiser transaction)
	{
		if (transaction == _currentTransaction)
		{
			_currentTransaction.UpdateReferenceCounts();
			_currentTransaction.Commit();
			_currentTransaction.Dispose();
			_currentTransaction = null;
			return;
		}
		throw new ArgumentException("The transaction is not the one that is currently running", "transaction");
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (_currentTransaction != null)
			{
				_currentTransaction.Dispose();
				_currentTransaction = null;
			}
			if (_shapeGeometryCursor != null)
			{
				_esentModel.FreeTable(_shapeGeometryCursor);
			}
			if (_shapeInstanceCursor != null)
			{
				_esentModel.FreeTable(_shapeInstanceCursor);
			}
		}
		_disposed = true;
	}

	public IGeometryStoreReader BeginRead()
	{
		return new EsentGeometryStoreReader(_esentModel);
	}
}
