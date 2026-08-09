using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Federation;
using Xbim.Common.Geometry;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;

namespace Xbim.IO.Esent;

public class EsentModel : IModel, IDisposable, IFederatedModel
{
	internal enum TableStatus
	{
		Unknown,
		Found,
		Missing
	}

	private class DummyCache : IEntityCache, IDisposable
	{
		public int Size => 0;

		public bool IsActive => false;

		public void Clear()
		{
		}

		public void Dispose()
		{
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}
	}

	protected PersistedEntityInstanceCache InstanceCache;

	private bool _disposed;

	private EsentEntityCursor _editTransactionEntityCursor;

	private bool _deleteOnClose;

	private int _codePageOverrideForStepFiles = -1;

	private string _importFilePath;

	private IEntityFactory _factory;

	private WeakReference _cacheReference;

	private WeakReference _transactionReference;

	private readonly ReferencedModelCollection _referencedModels = new ReferencedModelCollection();

	private readonly ILoggerFactory _loggerFactory;

	private EsentGeometryStore _geometryStore;

	private IStepFileHeader _header;

	internal PersistedEntityInstanceCache Cache => InstanceCache;

	public int UserDefinedId { get; set; }

	public IEntityFactory Factory => _factory;

	public ExpressMetaData Metadata { get; private set; }

	public IModelFactors ModelFactors { get; protected set; }

	public string DatabaseName => InstanceCache?.DatabaseName;

	public IGeometryManager GeometryManager { get; set; }

	public static int ModelOpenCount => PersistedEntityInstanceCache.ModelOpenCount;

	public int CodePageOverride
	{
		get
		{
			return _codePageOverrideForStepFiles;
		}
		set
		{
			_codePageOverrideForStepFiles = value;
		}
	}

	private XbimInstanceCollection InstancesLocal { get; set; }

	public IEntityCollection Instances => InstancesLocal;

	public IReadOnlyEntityCollection FederatedInstances => new FederatedModelInstances(this);

	internal InverseCache _inverseCache
	{
		get
		{
			if (_cacheReference == null || !_cacheReference.IsAlive)
			{
				return null;
			}
			return _cacheReference.Target as InverseCache;
		}
		set
		{
			if (value == null)
			{
				_cacheReference = null;
			}
			else if (_cacheReference == null)
			{
				_cacheReference = new WeakReference(value);
			}
			else
			{
				_cacheReference.Target = value;
			}
		}
	}

	public IInverseCache InverseCache
	{
		get
		{
			if (_cacheReference == null || !_cacheReference.IsAlive)
			{
				return null;
			}
			return _cacheReference.Target as IInverseCache;
		}
	}

	public bool IsTransacting => _editTransactionEntityCursor != null;

	public virtual long GeometriesCount => InstanceCache.GeometriesCount();

	public IStepFileHeader Header
	{
		get
		{
			return _header;
		}
		set
		{
			_header = value;
			if (value == null)
			{
				return;
			}
			if (CurrentTransaction != null)
			{
				GetTransactingCursor().WriteHeader(_header);
			}
			else
			{
				using XbimReadWriteTransaction xbimReadWriteTransaction = BeginTransaction("New header");
				GetTransactingCursor().WriteHeader(_header);
				xbimReadWriteTransaction.Commit();
			}
			_header.PropertyChanged += delegate
			{
				if (CurrentTransaction != null)
				{
					GetTransactingCursor().WriteHeader(_header);
					return;
				}
				using XbimReadWriteTransaction xbimReadWriteTransaction2 = BeginTransaction("Header changed");
				GetTransactingCursor().WriteHeader(_header);
				xbimReadWriteTransaction2.Commit();
			};
		}
	}

	public bool CanEdit
	{
		get
		{
			if (Cache.AccessMode != XbimDBAccess.ReadWrite)
			{
				return Cache.AccessMode == XbimDBAccess.Exclusive;
			}
			return true;
		}
	}

	public int GeometrySupportLevel
	{
		get
		{
			if (DatabaseHasInstanceTable())
			{
				using EsentShapeInstanceCursor esentShapeInstanceCursor = GetShapeInstanceTable();
				if (esentShapeInstanceCursor.RetrieveCount() > 0)
				{
					return 2;
				}
			}
			else if (DatabaseHasGeometryTable() && GetGeometryData(XbimGeometryType.TriangulatedMesh).Any())
			{
				return 1;
			}
			return 0;
		}
	}

	public object Tag { get; set; }

	bool IModel.IsTransactional => true;

	public ITransaction CurrentTransaction
	{
		get
		{
			if (_transactionReference == null || !_transactionReference.IsAlive)
			{
				return null;
			}
			return _transactionReference.Target as ITransaction;
		}
		internal set
		{
			if (value == null)
			{
				_transactionReference = null;
			}
			else if (_transactionReference == null)
			{
				_transactionReference = new WeakReference(value);
			}
			else
			{
				_transactionReference.Target = value;
			}
		}
	}

	public IEnumerable<IReferencedModel> ReferencedModels => _referencedModels.AsEnumerable();

	public virtual bool IsFederation
	{
		get
		{
			if (!_referencedModels.Any())
			{
				return string.Compare(Path.GetExtension(InstanceCache.DatabaseName), ".xbimf", StringComparison.OrdinalIgnoreCase) == 0;
			}
			return true;
		}
	}

	public IEnumerable<XbimInstanceHandle> AllInstancesHandles
	{
		get
		{
			foreach (XbimInstanceHandle instanceHandle in InstanceHandles)
			{
				yield return instanceHandle;
			}
			foreach (EsentModel item in from r in ReferencedModels
				where r.Model is EsentModel
				select r.Model as EsentModel)
			{
				foreach (XbimInstanceHandle allInstancesHandle in item.AllInstancesHandles)
				{
					yield return allInstancesHandle;
				}
			}
		}
	}

	public IGeometryStore GeometryStore
	{
		get
		{
			if (_geometryStore == null)
			{
				_geometryStore = new EsentGeometryStore(this);
			}
			return _geometryStore;
		}
	}

	public IModel ReferencingModel => this;

	public IList<XbimInstanceHandle> FederatedInstanceHandles => ReferencedModels.Select((IReferencedModel r) => r.Model).Concat(new EsentModel[1] { this }).SelectMany((IModel m) => m.InstanceHandles)
		.ToList();

	public IList<XbimInstanceHandle> InstanceHandles => InstanceCache.InstanceHandles.ToList();

	public XbimSchemaVersion SchemaVersion => Factory.SchemaVersion;

	protected ILogger Logger { get; set; }

	public IEntityCache EntityCache => null;

	public event NewEntityHandler EntityNew;

	public event ModifiedEntityHandler EntityModified;

	public event DeletedEntityHandler EntityDeleted;

	public EsentModel(IEntityFactory factory)
		: this(factory, null)
	{
	}

	public EsentModel(IEntityFactory factory, ILoggerFactory loggerFactory)
		: this(loggerFactory)
	{
		Init(factory);
	}

	internal EsentModel()
		: this((ILoggerFactory)null)
	{
	}

	private EsentModel(ILoggerFactory loggerFactory)
	{
		_loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		Logger = _loggerFactory.CreateLogger<EsentModel>();
		if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			Logger.LogCritical("Esent is Windows only and not supported on {OS}", RuntimeInformation.OSDescription);
			throw new NotSupportedException("Esent is not supported on this operating system");
		}
	}

	protected void Init(IEntityFactory factory)
	{
		try
		{
			_factory = factory;
			InstanceCache = new PersistedEntityInstanceCache(this, factory, _loggerFactory);
			InstancesLocal = new XbimInstanceCollection(this);
			Random random = new Random();
			UserDefinedId = (short)random.Next(32767);
			Metadata = ExpressMetaData.GetMetadata(factory);
			ModelFactors = new XbimModelFactors(Math.PI / 180.0, 0.001, 1E-05);
		}
		catch (Exception exception)
		{
			Logger.LogError(exception, "Failed to Initialise EsentModel");
			throw;
		}
	}

	public IInverseCache BeginInverseCaching()
	{
		if (CurrentTransaction != null)
		{
			throw new XbimException("Caching is not allowed within active transaction.");
		}
		IInverseCache inverseCache = InverseCache;
		if (inverseCache != null)
		{
			return inverseCache;
		}
		return _inverseCache = new InverseCache();
	}

	public void StopCaching()
	{
		IInverseCache inverseCache = InverseCache;
		if (inverseCache != null)
		{
			inverseCache.Dispose();
			_inverseCache = null;
		}
	}

	internal void HandleEntityChange(ChangeType changeType, IPersistEntity entity, int property)
	{
		switch (changeType)
		{
		case ChangeType.New:
			if (this.EntityNew != null)
			{
				this.EntityNew(entity);
			}
			break;
		case ChangeType.Deleted:
			if (this.EntityDeleted != null)
			{
				this.EntityDeleted(entity);
			}
			break;
		case ChangeType.Modified:
			if (this.EntityModified != null)
			{
				this.EntityModified(entity, property);
			}
			if (entity != null)
			{
				Cache.AddModified(entity);
			}
			break;
		default:
			throw new ArgumentOutOfRangeException("changeType", changeType, null);
		}
	}

	internal XbimGeometryCursor GetGeometryTable()
	{
		return InstanceCache.GetGeometryTable();
	}

	public void FreeTable(XbimGeometryCursor table)
	{
		InstanceCache.FreeTable(table);
	}

	public void FreeTable(EsentEntityCursor table)
	{
		InstanceCache.FreeTable(table);
	}

	public void FreeTable(EsentShapeGeometryCursor table)
	{
		InstanceCache.FreeTable(table);
	}

	public void FreeTable(EsentShapeInstanceCursor table)
	{
		InstanceCache.FreeTable(table);
	}

	bool IModel.Activate(IPersistEntity entity)
	{
		if (entity.Activated)
		{
			return true;
		}
		try
		{
			lock (entity)
			{
				if (entity.Activated)
				{
					return true;
				}
				InstanceCache.Activate(entity);
				FlagSetter.SetActivationFlag(entity, value: true);
				return true;
			}
		}
		catch (Exception inner)
		{
			throw new XbimInitializationFailedException($"Failed to activate #{entity.EntityLabel}={entity.ExpressType.ExpressNameUpper}", inner);
		}
	}

	public XbimReadWriteTransaction BeginTransaction()
	{
		return BeginTransaction(null);
	}

	public XbimReadWriteTransaction BeginTransaction(string operationName)
	{
		if (InverseCache != null)
		{
			throw new XbimException("Transaction can't be open when cache is in operation.");
		}
		if (_editTransactionEntityCursor != null)
		{
			throw new XbimException("Attempt to begin another transaction whilst one is already running");
		}
		try
		{
			_editTransactionEntityCursor = InstanceCache.GetWriteableEntityTable();
			InstanceCache.BeginCaching();
			return (XbimReadWriteTransaction)(CurrentTransaction = new XbimReadWriteTransaction(this, _editTransactionEntityCursor.BeginLazyTransaction(), operationName));
		}
		catch (Exception inner)
		{
			throw new XbimException("Failed to create ReadWrite transaction", inner);
		}
	}

	public void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body) where TSource : IPersistEntity
	{
		InstanceCache.ForEach(source, body);
	}

	public void Delete(IPersistEntity instance)
	{
		InstanceCache.Delete_Reversable(instance);
	}

	internal IPersistEntity GetInstanceVolatile(int label)
	{
		return InstanceCache.GetInstance(label, loadProperties: true, unCached: true);
	}

	public virtual bool CreateFrom(string importFrom, string xbimDbName = null, ReportProgressDelegate progDelegate = null, bool keepOpen = false, bool cacheEntities = false, StorageType? storageType = null, bool deleteOnClose = false)
	{
		Close();
		_importFilePath = Path.GetFullPath(importFrom);
		if (!Directory.Exists(Path.GetDirectoryName(_importFilePath) ?? ""))
		{
			throw new DirectoryNotFoundException(Path.GetDirectoryName(importFrom) + " directory was not found");
		}
		if (!File.Exists(_importFilePath))
		{
			throw new FileNotFoundException(_importFilePath + " file was not found");
		}
		if (string.IsNullOrWhiteSpace(xbimDbName))
		{
			xbimDbName = Path.ChangeExtension(importFrom, "xBIM");
		}
		switch (storageType ?? importFrom.StorageType())
		{
		case StorageType.IfcXml:
			InstanceCache.ImportIfcXml(xbimDbName, importFrom, progDelegate, keepOpen, cacheEntities);
			break;
		case StorageType.Ifc:
		case StorageType.Stp:
			InstanceCache.ImportStep(xbimDbName, importFrom, progDelegate, keepOpen, cacheEntities, _codePageOverrideForStepFiles);
			break;
		case StorageType.IfcZip:
		case StorageType.StpZip:
		case StorageType.Zip:
			InstanceCache.ImportZip(xbimDbName, importFrom, progDelegate, keepOpen, cacheEntities, _codePageOverrideForStepFiles);
			break;
		case StorageType.Xbim:
			throw new NotImplementedException("Use SaveAs() or CreateFrom(IModel)");
		default:
			return false;
		}
		_deleteOnClose = deleteOnClose;
		return true;
	}

	public virtual bool CreateFrom(Stream inputStream, long streamSize, StorageType streamType, string xbimDbName, ReportProgressDelegate progDelegate = null, bool keepOpen = false, bool cacheEntities = false, ILoggerFactory loggerFactory = null)
	{
		Close();
		if (streamType.HasFlag(StorageType.IfcZip) || streamType.HasFlag(StorageType.StpZip) || streamType.HasFlag(StorageType.Zip))
		{
			Cache.ImportZip(xbimDbName, inputStream, progDelegate, keepOpen, cacheEntities, _codePageOverrideForStepFiles);
		}
		else if (streamType.HasFlag(StorageType.Ifc) || streamType.HasFlag(StorageType.Stp))
		{
			Cache.ImportStep(xbimDbName, inputStream, streamSize, progDelegate, keepOpen, cacheEntities, _codePageOverrideForStepFiles);
		}
		else if (streamType.HasFlag(StorageType.IfcXml))
		{
			Cache.ImportIfcXml(xbimDbName, inputStream, progDelegate, keepOpen, cacheEntities);
		}
		return true;
	}

	public static EsentModel CreateTemporaryModel(IEntityFactory factory)
	{
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		string tempFileName = Path.GetTempFileName();
		try
		{
			EsentModel esentModel = new EsentModel(factory, loggerFactory);
			esentModel.CreateDatabase(tempFileName);
			esentModel.Open(tempFileName, XbimDBAccess.ReadWrite, deleteOnClose: true);
			esentModel.Header = new StepFileHeader(StepFileHeader.HeaderCreationMode.InitWithXbimDefaults, esentModel);
			foreach (string schemasId in factory.SchemasIds)
			{
				esentModel.Header.FileSchema.Schemas.Add(schemasId);
			}
			return esentModel;
		}
		catch (Exception ex)
		{
			throw new XbimException("Failed to create and open temporary xBIM file '" + tempFileName + "'\n" + ex.Message, ex);
		}
	}

	protected void CreateDatabase(string tmpFileName)
	{
		InstanceCache.CreateDatabase(tmpFileName);
	}

	internal void ClearGeometryTables()
	{
		InstanceCache.ClearGeometryTables();
	}

	public static EsentModel CreateModel(IEntityFactory factory, string dbFileName, XbimDBAccess access = XbimDBAccess.ReadWrite)
	{
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		try
		{
			if (string.IsNullOrWhiteSpace(Path.GetExtension(dbFileName)))
			{
				dbFileName += ".xBIM";
			}
			EsentModel esentModel = new EsentModel(factory, loggerFactory);
			esentModel.CreateDatabase(dbFileName);
			esentModel.Open(dbFileName, access);
			esentModel.Header = new StepFileHeader(StepFileHeader.HeaderCreationMode.InitWithXbimDefaults, esentModel)
			{
				FileName = 
				{
					Name = dbFileName
				}
			};
			foreach (string schemasId in factory.SchemasIds)
			{
				esentModel.Header.FileSchema.Schemas.Add(schemasId);
			}
			return esentModel;
		}
		catch (Exception ex)
		{
			throw new XbimException("Failed to create and open xBIM file '" + dbFileName + "'\n" + ex.Message, ex);
		}
	}

	public byte[] GetEntityBinaryData(IInstantiableEntity entity)
	{
		if (!entity.Activated)
		{
			MemoryStream memoryStream = new MemoryStream(4096);
			BinaryWriter entityWriter = new BinaryWriter(memoryStream);
			entity.WriteEntity(entityWriter, Metadata);
			return memoryStream.ToArray();
		}
		return InstanceCache.GetEntityBinaryData(entity);
	}

	public virtual void Close()
	{
		try
		{
			string databaseName = DatabaseName;
			ModelFactors = new XbimModelFactors(Math.PI / 180.0, 0.001, 1E-05);
			Header = null;
			if (_editTransactionEntityCursor != null)
			{
				EndTransaction();
			}
			if (_geometryStore != null)
			{
				_geometryStore.Dispose();
				_geometryStore = null;
			}
			InstanceCache?.Close();
			foreach (IDisposable item in _referencedModels.Select((IReferencedModel r) => r.Model).OfType<IDisposable>())
			{
				item.Dispose();
			}
			_referencedModels.Clear();
			if (_deleteOnClose && File.Exists(databaseName))
			{
				File.Delete(databaseName);
				string path = Path.ChangeExtension(databaseName, ".jfm");
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			Logger.LogDebug("Closed EsentModel {dbName}", databaseName);
		}
		catch (Exception exception)
		{
			Logger.LogWarning(exception, "Failed to close EsentModel");
		}
		_deleteOnClose = false;
	}

	internal void InitialiseHeader(IStepFileHeader header)
	{
		_header = header;
	}

	protected void Open(string fileName, XbimDBAccess accessMode, bool deleteOnClose)
	{
		Open(fileName, accessMode);
		_deleteOnClose = deleteOnClose;
	}

	public void CacheStart()
	{
		if (_editTransactionEntityCursor == null)
		{
			InstanceCache.CacheStart();
		}
	}

	public void CacheClear()
	{
		if (_editTransactionEntityCursor == null)
		{
			InstanceCache.CacheClear();
		}
	}

	public void CacheStop()
	{
		if (_editTransactionEntityCursor == null)
		{
			InstanceCache.CacheStop();
		}
	}

	public virtual bool Open(string fileName, XbimDBAccess accessMode = XbimDBAccess.Read, ReportProgressDelegate progDelegate = null)
	{
		try
		{
			Close();
			InstanceCache.Open(fileName, accessMode);
			return true;
		}
		catch (Exception ex)
		{
			throw new XbimException($"Error opening file {fileName}\n{ex.Message}", ex);
		}
	}

	public bool SaveAs(string outputFileName, StorageType? storageType = null, ReportProgressDelegate progress = null, IDictionary<int, int> map = null)
	{
		try
		{
			if (!storageType.HasValue)
			{
				storageType = outputFileName.StorageType();
			}
			if (storageType.Value == StorageType.Invalid)
			{
				string extension = Path.GetExtension(outputFileName);
				if (string.IsNullOrWhiteSpace(extension))
				{
					throw new XbimException("Invalid file type, no extension specified in file " + outputFileName);
				}
				throw new XbimException("Invalid file extension " + extension.ToUpper() + " in file " + outputFileName);
			}
			if (storageType.Value == StorageType.Xbim && DatabaseName != null)
			{
				string text = DatabaseName;
				if (string.Compare(text, outputFileName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
				{
					throw new XbimException("Cannot save file to the same name, " + outputFileName);
				}
				bool deleteOnClose = _deleteOnClose;
				XbimDBAccess accessMode = InstanceCache.AccessMode;
				try
				{
					_deleteOnClose = false;
					Close();
					File.Copy(text, outputFileName);
					if (deleteOnClose)
					{
						File.Delete(text);
					}
					text = outputFileName;
					return true;
				}
				catch (Exception inner)
				{
					throw new XbimException("Failed to save file as outputFileName", inner);
				}
				finally
				{
					Open(text, accessMode);
				}
			}
			InstanceCache.SaveAs(storageType.Value, outputFileName, progress, map);
			return true;
		}
		catch (Exception ex)
		{
			throw new XbimException($"Failed to Save file as {outputFileName}\n{ex.Message}", ex);
		}
	}

	public void Print()
	{
		InstanceCache.Print();
	}

	~EsentModel()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			try
			{
				if (disposing)
				{
					Close();
				}
				if (_geometryStore != null)
				{
					_geometryStore.Dispose();
				}
				if (InstanceCache != null)
				{
					InstanceCache.Dispose();
				}
			}
			catch
			{
			}
		}
		_disposed = true;
	}

	public void CheckMaps()
	{
		foreach (XbimGeometryData geometryDatum in GetGeometryData(XbimGeometryType.TriangulatedMesh))
		{
			_ = geometryDatum;
		}
	}

	public XbimGeometryHandleCollection GetGeometryHandles(XbimGeometryType geomType = XbimGeometryType.TriangulatedMesh, XbimGeometrySort sortOrder = XbimGeometrySort.OrderByIfcSurfaceStyleThenIfcType)
	{
		return InstanceCache.GetGeometryHandles(geomType, sortOrder);
	}

	public XbimGeometryHandle GetGeometryHandle(int geometryLabel)
	{
		return InstanceCache.GetGeometryHandle(geometryLabel);
	}

	public IEnumerable<XbimGeometryData> GetGeometryData(int productLabel, XbimGeometryType geomType)
	{
		IPersistEntity instance = InstanceCache.GetInstance(productLabel, loadProperties: false, unCached: true);
		if (instance == null)
		{
			yield break;
		}
		foreach (XbimGeometryData item in InstanceCache.GetGeometry(Metadata.ExpressTypeId(instance), productLabel, geomType))
		{
			yield return item;
		}
	}

	public IEnumerable<XbimGeometryData> GetGeometryData(XbimGeometryType ofType)
	{
		return InstanceCache.GetGeometryData(ofType);
	}

	internal EsentEntityCursor GetEntityTable()
	{
		return InstanceCache.GetEntityTable();
	}

	public void Compact(string targetModelName)
	{
		Cache.Compact(targetModelName);
	}

	public T InsertCopy<T>(T toCopy, XbimInstanceHandleMap mappings, XbimReadWriteTransaction txn, bool includeInverses = false) where T : IPersistEntity
	{
		return Cache.InsertCopy(toCopy, mappings, txn, includeInverses);
	}

	public T InsertCopy<T>(T toCopy, XbimInstanceHandleMap mappings, XbimReadWriteTransaction txn, PropertyTranformDelegate propTransform, bool includeInverses = false) where T : IPersistEntity
	{
		return Cache.InsertCopy(toCopy, mappings, txn, includeInverses, propTransform);
	}

	public T InsertCopy<T>(T toCopy, XbimInstanceHandleMap mappings, PropertyTranformDelegate propTransform, bool includeInverses, bool keepLabels) where T : IPersistEntity
	{
		XbimReadWriteTransaction txn = CurrentTransaction as XbimReadWriteTransaction;
		return Cache.InsertCopy(toCopy, mappings, txn, includeInverses, propTransform, keepLabels);
	}

	internal void EndTransaction()
	{
		InstanceCache.EndCaching();
		_editTransactionEntityCursor.Dispose();
		_editTransactionEntityCursor = null;
	}

	internal void Flush()
	{
		InstanceCache.Write(_editTransactionEntityCursor);
	}

	internal EsentEntityCursor GetTransactingCursor()
	{
		return _editTransactionEntityCursor;
	}

	public XbimGeometryData GetGeometryData(XbimGeometryHandle handle)
	{
		return InstanceCache.GetGeometryData(handle);
	}

	public XbimGeometryData GetGeometryData(int geomLabel)
	{
		return InstanceCache.GetGeometryData(geomLabel);
	}

	public IEnumerable<XbimGeometryData> GetGeometryData(IEnumerable<XbimGeometryHandle> handles)
	{
		return InstanceCache.GetGeometryData(handles);
	}

	internal EsentShapeGeometryCursor GetShapeGeometryTable()
	{
		return InstanceCache.GetShapeGeometryTable();
	}

	internal EsentShapeInstanceCursor GetShapeInstanceTable()
	{
		return InstanceCache.GetShapeInstanceTable();
	}

	public bool EnsureGeometryTables()
	{
		return InstanceCache.EnsureGeometryTables();
	}

	public bool DeleteGeometryCache()
	{
		return InstanceCache.DeleteGeometry();
	}

	public bool DatabaseHasGeometryTable()
	{
		return InstanceCache.DatabaseHasGeometryTable();
	}

	public bool DatabaseHasInstanceTable()
	{
		return InstanceCache.DatabaseHasInstanceTable();
	}

	ITransaction IModel.BeginTransaction(string name)
	{
		return BeginTransaction(name);
	}

	public void AddModelReference(IReferencedModel model)
	{
		_referencedModels.Add(model);
	}

	protected string NextReferenceIdentifier()
	{
		return _referencedModels.NextIdentifer();
	}

	public void EnsureUniqueUserDefinedId()
	{
		short num = 0;
		foreach (EsentModel item in new EsentModel[1] { this }.Concat(from rm in ReferencedModels
			where rm.Model is EsentModel
			select rm.Model).Cast<EsentModel>())
		{
			item.UserDefinedId = num++;
		}
	}

	public static IStepFileHeader GetStepFileHeader(string fileName)
	{
		EsentModel esentModel = null;
		EsentEntityCursor esentEntityCursor = null;
		try
		{
			esentModel = new EsentModel();
			esentModel.InstanceCache = new PersistedEntityInstanceCache(esentModel, null, null);
			esentModel.InstanceCache.DatabaseName = fileName;
			esentEntityCursor = esentModel.InstanceCache.GetEntityTable();
			using (esentEntityCursor.BeginReadOnlyTransaction())
			{
				return esentEntityCursor.ReadHeader();
			}
		}
		catch (Exception inner)
		{
			throw new XbimException("Failed to open " + fileName, inner);
		}
		finally
		{
			if (esentModel != null)
			{
				if (esentEntityCursor != null)
				{
					esentModel.InstanceCache.FreeTable(esentEntityCursor);
				}
				esentModel.Dispose();
			}
		}
	}

	public void CreateFrom(IModel model, string fileName, ReportProgressDelegate progDelegate = null)
	{
		Close();
		string xbimDbName = Path.ChangeExtension(fileName, "xBIM");
		InstanceCache.ImportModel(model, xbimDbName, progDelegate);
	}

	public IEntityCache BeginEntityCaching()
	{
		return new DummyCache();
	}
}
