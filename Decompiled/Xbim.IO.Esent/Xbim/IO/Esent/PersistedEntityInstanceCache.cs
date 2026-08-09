using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml;
using Microsoft.Extensions.Logging;
using Microsoft.Isam.Esent.Interop;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Step21;
using Xbim.IO.Step21.Parser;
using Xbim.IO.Xml;

namespace Xbim.IO.Esent;

public class PersistedEntityInstanceCache : IDisposable
{
	private static readonly HashSet<PersistedEntityInstanceCache> OpenInstances;

	private Instance _jetInstance;

	private readonly IEntityFactory _factory;

	private readonly ILoggerFactory _loggerFactory;

	private readonly ILogger _logger;

	private Session _session;

	private JET_DBID _databaseId;

	private static int cacheSizeInBytes;

	private const int MaxCachedEntityTables = 32;

	private const int MaxCachedGeometryTables = 32;

	private readonly object _lockObject;

	private readonly EsentEntityCursor[] _entityTables;

	private readonly EsentCursor[] _geometryTables;

	private XbimDBAccess _accessMode;

	private string _systemPath;

	private readonly ConcurrentDictionary<int, IPersistEntity> _read = new ConcurrentDictionary<int, IPersistEntity>();

	protected ConcurrentDictionary<int, IPersistEntity> ModifiedEntities = new ConcurrentDictionary<int, IPersistEntity>();

	protected ConcurrentDictionary<int, IPersistEntity> CreatedNew = new ConcurrentDictionary<int, IPersistEntity>();

	private BlockingCollection<StepForwardReference> _forwardReferences = new BlockingCollection<StepForwardReference>();

	private string _databaseName;

	private readonly EsentModel _model;

	private bool _disposed;

	private bool _caching;

	private bool _previousCaching;

	internal static int ModelOpenCount => OpenInstances.Count;

	internal ConcurrentDictionary<int, IPersistEntity> Read => _read;

	internal BlockingCollection<StepForwardReference> ForwardReferences => _forwardReferences;

	public XbimDBAccess AccessMode => _accessMode;

	public long Count
	{
		get
		{
			EsentEntityCursor entityTable = GetEntityTable();
			try
			{
				long num = entityTable.RetrieveCount();
				if (_caching)
				{
					num += CreatedNew.Count;
				}
				return num;
			}
			finally
			{
				FreeTable(entityTable);
			}
		}
	}

	public int HighestLabel
	{
		get
		{
			EsentEntityCursor entityTable = GetEntityTable();
			try
			{
				return entityTable.RetrieveHighestLabel();
			}
			finally
			{
				FreeTable(entityTable);
			}
		}
	}

	public IEnumerable<XbimInstanceHandle> InstanceHandles
	{
		get
		{
			EsentEntityCursor entityTable = GetEntityTable();
			try
			{
				if (entityTable.TryMoveFirst())
				{
					do
					{
						yield return entityTable.GetInstanceHandle();
					}
					while (entityTable.TryMoveNext());
				}
			}
			finally
			{
				FreeTable(entityTable);
			}
		}
	}

	public bool Saved
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	internal string DatabaseName
	{
		get
		{
			return _databaseName;
		}
		set
		{
			_databaseName = value;
		}
	}

	public IEnumerable<int> InstanceLabels
	{
		get
		{
			EsentEntityCursor entityTable = GetEntityTable();
			try
			{
				if (entityTable.TryMoveFirstLabel(out var label))
				{
					do
					{
						yield return label;
					}
					while (entityTable.TryMoveNextLabel(out label));
				}
			}
			finally
			{
				FreeTable(entityTable);
			}
		}
	}

	public bool HasDatabaseInstance => _jetInstance != null;

	internal Instance JetInstance => _jetInstance;

	internal bool IsCaching => _caching;

	public EsentModel Model => _model;

	static PersistedEntityInstanceCache()
	{
		cacheSizeInBytes = 134217728;
		SystemParameters.DatabasePageSize = 4096;
		SystemParameters.CacheSizeMin = cacheSizeInBytes / SystemParameters.DatabasePageSize;
		SystemParameters.CacheSizeMax = cacheSizeInBytes / SystemParameters.DatabasePageSize;
		SystemParameters.MaxInstances = 128;
		OpenInstances = new HashSet<PersistedEntityInstanceCache>();
	}

	public PersistedEntityInstanceCache(EsentModel model, IEntityFactory factory, ILoggerFactory loggerFactory)
	{
		_factory = factory;
		_loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		_logger = _loggerFactory.CreateLogger<PersistedEntityInstanceCache>();
		_jetInstance = CreateInstance("XbimInstance");
		_lockObject = new object();
		_model = model;
		_entityTables = new EsentEntityCursor[32];
		_geometryTables = new EsentCursor[32];
	}

	internal void CreateDatabase(string fileName)
	{
		using Session session = new Session(_jetInstance);
		Api.JetCreateDatabase(session, fileName, null, out var dbid, CreateDatabaseGrbit.OverwriteExisting);
		try
		{
			EsentEntityCursor.CreateTable(session, dbid);
			EsentCursor.CreateGlobalsTable(session, dbid);
			EnsureGeometryTables(session, dbid);
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Failed to Create Esent Database, {filename}", fileName);
			try
			{
				Api.JetCloseDatabase(session, dbid, CloseDatabaseGrbit.None);
				lock (OpenInstances)
				{
					Api.JetDetachDatabase(session, fileName);
					OpenInstances.Remove(this);
				}
				File.Delete(fileName);
			}
			catch
			{
			}
			throw;
		}
	}

	internal bool EnsureGeometryTables()
	{
		return EnsureGeometryTables(_session, _databaseId);
	}

	internal void ClearGeometryTables()
	{
		try
		{
			for (int i = 0; i < _geometryTables.Length; i++)
			{
				if (_geometryTables[i] != null)
				{
					_geometryTables[i].Dispose();
					_geometryTables[i] = null;
				}
			}
			try
			{
				Api.JetDeleteTable(_session, _databaseId, EsentShapeGeometryCursor.GeometryTableName);
			}
			catch (Exception exception)
			{
				_logger.LogDebug(exception, "Failed to delete geometry table {tableName}", EsentShapeGeometryCursor.GeometryTableName);
			}
			try
			{
				Api.JetDeleteTable(_session, _databaseId, EsentShapeInstanceCursor.InstanceTableName);
			}
			catch (Exception exception2)
			{
				_logger.LogDebug(exception2, "Failed to delete geometry table {tableName}", EsentShapeInstanceCursor.InstanceTableName);
			}
			EnsureGeometryTables(_session, _databaseId);
		}
		catch (Exception innerException)
		{
			throw new Exception("Could not clear existing geometry tables", innerException);
		}
	}

	private static bool EnsureGeometryTables(Session session, JET_DBID dbid)
	{
		if (!HasTable(XbimGeometryCursor.GeometryTableName, session, dbid))
		{
			XbimGeometryCursor.CreateTable(session, dbid);
		}
		if (!HasTable(EsentShapeGeometryCursor.GeometryTableName, session, dbid))
		{
			EsentShapeGeometryCursor.CreateTable(session, dbid);
		}
		if (!HasTable(EsentShapeInstanceCursor.InstanceTableName, session, dbid))
		{
			EsentShapeInstanceCursor.CreateTable(session, dbid);
		}
		return true;
	}

	internal EsentEntityCursor GetEntityTable()
	{
		lock (_lockObject)
		{
			for (int i = 0; i < _entityTables.Length; i++)
			{
				if (_entityTables[i] != null)
				{
					EsentEntityCursor result = _entityTables[i];
					_entityTables[i] = null;
					return result;
				}
			}
		}
		OpenDatabaseGrbit mode = AttachedDatabase();
		return new EsentEntityCursor(_model, _databaseName, mode, _loggerFactory);
	}

	private OpenDatabaseGrbit AttachedDatabase()
	{
		OpenDatabaseGrbit openDatabaseGrbit = OpenDatabaseGrbit.None;
		if (_accessMode == XbimDBAccess.Read)
		{
			openDatabaseGrbit = OpenDatabaseGrbit.ReadOnly;
		}
		if (_session == null)
		{
			lock (OpenInstances)
			{
				foreach (PersistedEntityInstanceCache openInstance in OpenInstances)
				{
					if (string.Compare(openInstance.DatabaseName, _databaseName, StringComparison.OrdinalIgnoreCase) == 0)
					{
						_jetInstance.Term();
						_jetInstance = openInstance.JetInstance;
						break;
					}
				}
				_session = new Session(_jetInstance);
				try
				{
					if (!string.IsNullOrWhiteSpace(_databaseName))
					{
						Api.JetAttachDatabase(_session, _databaseName, AttachDatabaseGrbit.None);
					}
				}
				catch (EsentDatabaseDirtyShutdownException)
				{
					_logger.LogInformation("Dirty shutdown of Esent DB detected. Attempting repair with EsentUtl.exe");
					using Process process = Process.Start(new ProcessStartInfo("EsentUtl.exe")
					{
						WindowStyle = ProcessWindowStyle.Hidden,
						UseShellExecute = false,
						CreateNoWindow = true,
						Arguments = $"/p \"{_databaseName}\" /o "
					});
					if (process != null && !process.WaitForExit(60000))
					{
						if (!process.HasExited)
						{
							process.Kill();
							Thread.Sleep(500);
						}
						_logger.LogWarning("Repair failed {0} after dirty shutdown, time out", _databaseName);
					}
					else
					{
						_logger.LogWarning("Repair success {0} after dirty shutdown", _databaseName);
						process?.Close();
						Api.JetAttachDatabase(_session, _databaseName, (openDatabaseGrbit == OpenDatabaseGrbit.ReadOnly) ? AttachDatabaseGrbit.ReadOnly : AttachDatabaseGrbit.None);
					}
				}
				OpenInstances.Add(this);
				Api.JetOpenDatabase(_session, _databaseName, string.Empty, out _databaseId, openDatabaseGrbit);
			}
		}
		return openDatabaseGrbit;
	}

	internal XbimGeometryCursor GetGeometryTable()
	{
		lock (_lockObject)
		{
			for (int i = 0; i < _geometryTables.Length; i++)
			{
				if (_geometryTables[i] != null && _geometryTables[i] is XbimGeometryCursor)
				{
					EsentCursor obj = _geometryTables[i];
					_geometryTables[i] = null;
					return (XbimGeometryCursor)obj;
				}
			}
		}
		OpenDatabaseGrbit mode = AttachedDatabase();
		return new XbimGeometryCursor(_model, _databaseName, mode);
	}

	internal void FreeTable(EsentEntityCursor table)
	{
		lock (_lockObject)
		{
			for (int i = 0; i < _entityTables.Length; i++)
			{
				if (_entityTables[i] == null)
				{
					_entityTables[i] = table;
					return;
				}
			}
		}
		table.Dispose();
	}

	public void FreeTable(XbimGeometryCursor table)
	{
		lock (_lockObject)
		{
			for (int i = 0; i < _geometryTables.Length; i++)
			{
				if (_geometryTables[i] == null)
				{
					_geometryTables[i] = table;
					return;
				}
			}
		}
		table.Dispose();
	}

	public void FreeTable(EsentShapeGeometryCursor table)
	{
		lock (_lockObject)
		{
			for (int i = 0; i < _geometryTables.Length; i++)
			{
				if (_geometryTables[i] == null)
				{
					_geometryTables[i] = table;
					return;
				}
			}
		}
		table.Dispose();
	}

	public void FreeTable(EsentShapeInstanceCursor table)
	{
		lock (_lockObject)
		{
			for (int i = 0; i < _geometryTables.Length; i++)
			{
				if (_geometryTables[i] == null)
				{
					_geometryTables[i] = table;
					return;
				}
			}
		}
		table.Dispose();
	}

	internal void Open(string filename, XbimDBAccess accessMode = XbimDBAccess.Read)
	{
		Close();
		_databaseName = Path.GetFullPath(filename);
		_accessMode = accessMode;
		_caching = false;
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			using (entityTable.BeginReadOnlyTransaction())
			{
				_model.InitialiseHeader(entityTable.ReadHeader());
			}
		}
		catch (Exception inner)
		{
			Close();
			throw new XbimException("Failed to open " + filename, inner);
		}
		finally
		{
			FreeTable(entityTable);
		}
	}

	public void Close()
	{
		int num;
		lock (OpenInstances)
		{
			num = OpenInstances.Count((PersistedEntityInstanceCache c) => c.JetInstance == JetInstance);
		}
		bool disposeTables = num != 0;
		CleanTableArrays(disposeTables);
		EndCaching();
		if (_session == null)
		{
			return;
		}
		Api.JetCloseDatabase(_session, _databaseId, CloseDatabaseGrbit.None);
		lock (OpenInstances)
		{
			OpenInstances.Remove(this);
			if (OpenInstances.Count((PersistedEntityInstanceCache c) => string.Compare(c.DatabaseName, DatabaseName, StringComparison.OrdinalIgnoreCase) == 0) == 0)
			{
				Api.JetDetachDatabase(_session, _databaseName);
			}
		}
		_logger.LogTrace("Closed PersistedEntityInstanceCache {dbName}", _databaseName);
		_databaseName = null;
		_session.Dispose();
		_session = null;
	}

	private void CleanTableArrays(bool disposeTables)
	{
		for (int i = 0; i < _entityTables.Length; i++)
		{
			if (_entityTables[i] != null)
			{
				if (disposeTables)
				{
					_entityTables[i].Dispose();
				}
				_entityTables[i] = null;
			}
		}
		for (int j = 0; j < _geometryTables.Length; j++)
		{
			if (_geometryTables[j] != null)
			{
				if (disposeTables)
				{
					_geometryTables[j].Dispose();
				}
				_geometryTables[j] = null;
			}
		}
	}

	public void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body) where TSource : IPersistEntity
	{
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			using (entityTable.BeginReadOnlyTransaction())
			{
				foreach (TSource item in source)
				{
					body(item);
				}
			}
		}
		finally
		{
			FreeTable(entityTable);
		}
	}

	internal static string GetXbimTempDirectory()
	{
		string tempDirectory = Path.Combine(Path.GetTempPath(), "Xbim." + Guid.NewGuid());
		if (!IsValidDirectory(ref tempDirectory))
		{
			tempDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Xbim." + Guid.NewGuid());
			if (!IsValidDirectory(ref tempDirectory))
			{
				throw new XbimException("Unable to initialise the Xbim database engine, no write access. Please set a location for the XbimTempDirectory in the config file");
			}
		}
		return tempDirectory;
	}

	private static bool IsValidDirectory(ref string tempDirectory)
	{
		string path = Guid.NewGuid().ToString();
		string path2 = "";
		if (!string.IsNullOrWhiteSpace(tempDirectory))
		{
			tempDirectory = Path.GetFullPath(tempDirectory);
			bool flag = false;
			try
			{
				path2 = Path.Combine(tempDirectory, path);
				if (!Directory.Exists(tempDirectory))
				{
					Directory.CreateDirectory(tempDirectory);
					flag = true;
				}
				using (File.Create(path2))
				{
				}
				return true;
			}
			catch (Exception)
			{
				tempDirectory = null;
			}
			finally
			{
				File.Delete(path2);
				if (flag && tempDirectory != null)
				{
					Directory.Delete(tempDirectory);
				}
			}
		}
		return false;
	}

	private Instance CreateInstance(string instanceName, bool recovery = false, bool createTemporaryTables = false)
	{
		string text = Guid.NewGuid().ToString();
		Instance instance = new Instance(instanceName + text);
		if (string.IsNullOrWhiteSpace(_systemPath))
		{
			_systemPath = GetXbimTempDirectory();
		}
		instance.Parameters.BaseName = "XBM";
		instance.Parameters.SystemDirectory = _systemPath;
		instance.Parameters.LogFileDirectory = _systemPath;
		instance.Parameters.TempDirectory = _systemPath;
		instance.Parameters.AlternateDatabaseRecoveryDirectory = _systemPath;
		instance.Parameters.CreatePathIfNotExist = true;
		instance.Parameters.EnableIndexChecking = false;
		instance.Parameters.CircularLog = true;
		instance.Parameters.CheckpointDepthMax = cacheSizeInBytes;
		instance.Parameters.LogFileSize = 1024;
		instance.Parameters.LogBuffers = 1024;
		if (!createTemporaryTables)
		{
			instance.Parameters.MaxTemporaryTables = 0;
		}
		instance.Parameters.MaxVerPages = 8192;
		instance.Parameters.NoInformationEvent = true;
		instance.Parameters.WaypointLatency = 1;
		instance.Parameters.MaxSessions = 512;
		instance.Parameters.MaxOpenTables = 256;
		InitGrbit grbit = (EsentVersion.SupportsWindows7Features ? ((InitGrbit)128) : InitGrbit.None);
		instance.Parameters.Recovery = recovery;
		instance.Init(grbit);
		return instance;
	}

	public void ImportModel(IModel fromModel, string xbimDbName, ReportProgressDelegate progressHandler = null)
	{
		CreateDatabase(xbimDbName);
		Open(xbimDbName, XbimDBAccess.Exclusive);
		try
		{
			using (XbimReadWriteTransaction xbimReadWriteTransaction = Model.BeginTransaction())
			{
				EsentEntityCursor transactingCursor = Model.GetTransactingCursor();
				foreach (IPersistEntity instance in fromModel.Instances)
				{
					transactingCursor.AddEntity(instance);
					xbimReadWriteTransaction.Pulse();
				}
				transactingCursor.WriteHeader(fromModel.Header);
				xbimReadWriteTransaction.Commit();
			}
			IGeometryStore geometryStore = fromModel.GeometryStore;
			using (IGeometryStore geometryStore2 = Model.GeometryStore)
			{
				using IGeometryStoreInitialiser geometryStoreInitialiser = geometryStore2.BeginInit();
				using (IGeometryStoreReader geometryStoreReader = geometryStore.BeginRead())
				{
					foreach (XbimShapeGeometry shapeGeometry in geometryStoreReader.ShapeGeometries)
					{
						geometryStoreInitialiser.AddShapeGeometry(shapeGeometry);
					}
					foreach (XbimShapeInstance shapeInstance in geometryStoreReader.ShapeInstances)
					{
						geometryStoreInitialiser.AddShapeInstance(shapeInstance, shapeInstance.ShapeGeometryLabel);
					}
					foreach (XbimRegionCollection contextRegion in geometryStoreReader.ContextRegions)
					{
						geometryStoreInitialiser.AddRegions(contextRegion);
					}
				}
				geometryStoreInitialiser.Commit();
			}
			Close();
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Failed to Import Step file to {xbimFile}", xbimDbName);
			Close();
			try
			{
				File.Delete(xbimDbName);
			}
			catch
			{
			}
			throw;
		}
	}

	public void ImportStep(string xbimDbName, string toImportIfcFilename, ReportProgressDelegate progressHandler = null, bool keepOpen = false, bool cacheEntities = false, int codePageOverride = -1)
	{
		using FileStream fileStream = new FileStream(toImportIfcFilename, FileMode.Open, FileAccess.Read);
		ImportStep(xbimDbName, fileStream, fileStream.Length, progressHandler, keepOpen, cacheEntities, codePageOverride);
	}

	internal void ImportStep(string xbimDbName, Stream stream, long streamSize, ReportProgressDelegate progressHandler = null, bool keepOpen = false, bool cacheEntities = false, int codePageOverride = -1)
	{
		_logger.LogInformation("Opening {esentDb}", xbimDbName);
		CreateDatabase(xbimDbName);
		Open(xbimDbName, XbimDBAccess.Exclusive);
		EsentEntityCursor entityTable = GetEntityTable();
		if (cacheEntities)
		{
			CacheStart();
		}
		try
		{
			_forwardReferences = new BlockingCollection<StepForwardReference>();
			using (P21ToIndexParser p21ToIndexParser = new P21ToIndexParser(stream, streamSize, entityTable, this, codePageOverride, _loggerFactory))
			{
				if (progressHandler != null)
				{
					p21ToIndexParser.ProgressStatus += progressHandler;
				}
				p21ToIndexParser.Parse();
				_model.Header = p21ToIndexParser.Header;
				if (progressHandler != null)
				{
					p21ToIndexParser.ProgressStatus -= progressHandler;
				}
			}
			using (EsentLazyDBTransaction esentLazyDBTransaction = entityTable.BeginLazyTransaction())
			{
				entityTable.WriteHeader(_model.Header);
				esentLazyDBTransaction.Commit();
			}
			FreeTable(entityTable);
			if (!keepOpen)
			{
				Close();
			}
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Failed to Import Step file to {xbimFile}", xbimDbName);
			TidyUp(xbimDbName, entityTable);
			throw;
		}
	}

	private void TidyUp(string xbimDbName, EsentEntityCursor table)
	{
		try
		{
			FreeTable(table);
			Close();
			File.Delete(xbimDbName);
		}
		catch (Exception exception)
		{
			_logger.LogWarning(exception, "Failed to tidy up {xbimFile}", xbimDbName);
		}
	}

	public void ImportZip(string xbimDbName, string toImportFilename, ReportProgressDelegate progressHandler = null, bool keepOpen = false, bool cacheEntities = false, int codePageOverride = -1)
	{
		using FileStream fileStream = File.OpenRead(toImportFilename);
		ImportZip(xbimDbName, fileStream, progressHandler, keepOpen, cacheEntities, codePageOverride);
		fileStream.Close();
	}

	internal void ImportZip(string xbimDbName, Stream fileStream, ReportProgressDelegate progressHandler = null, bool keepOpen = false, bool cacheEntities = false, int codePageOverride = -1)
	{
		CreateDatabase(xbimDbName);
		Open(xbimDbName, XbimDBAccess.Exclusive);
		EsentEntityCursor entityTable = GetEntityTable();
		if (cacheEntities)
		{
			CacheStart();
		}
		try
		{
			using (ZipArchive zipArchive = new ZipArchive(fileStream))
			{
				foreach (ZipArchiveEntry entry in zipArchive.Entries)
				{
					string extension = Path.GetExtension(entry.Name);
					if (extension == null)
					{
						continue;
					}
					string strA = extension.ToLowerInvariant();
					if (string.Compare(strA, ".ifc", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(strA, ".step21", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(strA, ".stp", StringComparison.OrdinalIgnoreCase) == 0)
					{
						using (Stream inputP = entry.Open())
						{
							_forwardReferences = new BlockingCollection<StepForwardReference>();
							using P21ToIndexParser p21ToIndexParser = new P21ToIndexParser(inputP, entry.Length, entityTable, this, codePageOverride, _loggerFactory);
							if (progressHandler != null)
							{
								p21ToIndexParser.ProgressStatus += progressHandler;
							}
							p21ToIndexParser.Parse();
							_model.Header = p21ToIndexParser.Header;
							if (progressHandler != null)
							{
								p21ToIndexParser.ProgressStatus -= progressHandler;
							}
						}
						using (EsentLazyDBTransaction esentLazyDBTransaction = entityTable.BeginLazyTransaction())
						{
							entityTable.WriteHeader(_model.Header);
							esentLazyDBTransaction.Commit();
						}
						FreeTable(entityTable);
						if (!keepOpen)
						{
							Close();
						}
						return;
					}
					if (string.CompareOrdinal(strA, ".ifcxml") != 0 && string.CompareOrdinal(strA, ".stpxml") != 0 && string.CompareOrdinal(strA, ".xml") != 0)
					{
						continue;
					}
					XbimReadWriteTransaction transaction = _model.BeginTransaction();
					try
					{
						using (Stream xmlStream = entry.Open())
						{
							if (Model.Factory.SchemasIds.First() == "IFC2X3")
							{
								XbimXmlReader3 xbimXmlReader = new XbimXmlReader3(GetOrCreateEntity, delegate(IPersistEntity e)
								{
									ModifiedEntities.TryAdd(e.EntityLabel, e);
									transaction.Pulse();
								}, Model.Metadata);
								if (progressHandler != null)
								{
									xbimXmlReader.ProgressStatus += progressHandler;
								}
								_model.Header = xbimXmlReader.Read(xmlStream, _model, entry.Length);
								if (progressHandler != null)
								{
									xbimXmlReader.ProgressStatus -= progressHandler;
								}
							}
							else
							{
								XbimXmlReader4 xbimXmlReader2 = new XbimXmlReader4(GetOrCreateEntity, delegate(IPersistEntity e)
								{
									ModifiedEntities.TryAdd(e.EntityLabel, e);
									transaction.Pulse();
								}, Model.Metadata, _loggerFactory);
								if (progressHandler != null)
								{
									xbimXmlReader2.ProgressStatus += progressHandler;
								}
								_model.Header = xbimXmlReader2.Read(xmlStream, _model);
								if (progressHandler != null)
								{
									xbimXmlReader2.ProgressStatus -= progressHandler;
								}
							}
							_model.GetTransactingCursor().WriteHeader(_model.Header);
						}
						transaction.Commit();
					}
					finally
					{
						if (transaction != null)
						{
							((IDisposable)transaction).Dispose();
						}
					}
					FreeTable(entityTable);
					if (!keepOpen)
					{
						Close();
					}
					return;
				}
			}
			FreeTable(entityTable);
			Close();
			File.Delete(xbimDbName);
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Failed to Import Xml file to {xbimFile}", xbimDbName);
			TidyUp(xbimDbName, entityTable);
			throw;
		}
	}

	public void ImportIfcXml(string xbimDbName, string xmlFilename, ReportProgressDelegate progressHandler = null, bool keepOpen = false, bool cacheEntities = false)
	{
		using FileStream inputStream = File.OpenRead(xmlFilename);
		ImportIfcXml(xbimDbName, inputStream, progressHandler, keepOpen, cacheEntities);
	}

	internal void ImportIfcXml(string xbimDbName, Stream inputStream, ReportProgressDelegate progressHandler = null, bool keepOpen = false, bool cacheEntities = false)
	{
		CreateDatabase(xbimDbName);
		Open(xbimDbName, XbimDBAccess.Exclusive);
		if (cacheEntities)
		{
			CacheStart();
		}
		try
		{
			XbimReadWriteTransaction transaction = _model.BeginTransaction();
			try
			{
				if (Model.Factory.SchemasIds.First() == "IFC2X3")
				{
					XbimXmlReader3 xbimXmlReader = new XbimXmlReader3(GetOrCreateEntity, delegate(IPersistEntity e)
					{
						ModifiedEntities.TryAdd(e.EntityLabel, e);
						transaction.Pulse();
					}, Model.Metadata);
					if (progressHandler != null)
					{
						xbimXmlReader.ProgressStatus += progressHandler;
					}
					_model.Header = xbimXmlReader.Read(inputStream, _model, inputStream.Length);
					if (progressHandler != null)
					{
						xbimXmlReader.ProgressStatus -= progressHandler;
					}
				}
				else
				{
					XbimXmlReader4 xbimXmlReader2 = new XbimXmlReader4(GetOrCreateEntity, delegate(IPersistEntity e)
					{
						ModifiedEntities.TryAdd(e.EntityLabel, e);
						transaction.Pulse();
					}, Model.Metadata, _loggerFactory);
					if (progressHandler != null)
					{
						xbimXmlReader2.ProgressStatus += progressHandler;
					}
					_model.Header = xbimXmlReader2.Read(inputStream, _model);
					if (progressHandler != null)
					{
						xbimXmlReader2.ProgressStatus -= progressHandler;
					}
				}
				_model.GetTransactingCursor().WriteHeader(_model.Header);
				transaction.Commit();
			}
			finally
			{
				if (transaction != null)
				{
					((IDisposable)transaction).Dispose();
				}
			}
			if (!keepOpen)
			{
				Close();
			}
		}
		catch (Exception innerException)
		{
			Close();
			File.Delete(xbimDbName);
			throw new Exception("Error importing IfcXml file.", innerException);
		}
	}

	private IPersistEntity GetOrCreateEntity(int label, Type type)
	{
		if (Contains(label))
		{
			return GetInstance(label, loadProperties: false, unCached: true);
		}
		XbimInstanceHandle xbimInstanceHandle = _model.GetTransactingCursor().AddEntity(type, label);
		IPersistEntity value = _factory.New(_model, type, xbimInstanceHandle.EntityLabel, activated: true);
		value = _read.GetOrAdd(xbimInstanceHandle.EntityLabel, value);
		CreatedNew.TryAdd(xbimInstanceHandle.EntityLabel, value);
		return value;
	}

	public bool Contains(IPersistEntity instance)
	{
		return Contains(instance.EntityLabel);
	}

	public bool Contains(int entityLabel)
	{
		if (_caching && _read.ContainsKey(entityLabel))
		{
			return true;
		}
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			return entityTable.TrySeekEntityLabel(entityLabel);
		}
		finally
		{
			FreeTable(entityTable);
		}
	}

	public long CountOf<TIfcType>() where TIfcType : IPersistEntity
	{
		return CountOf(typeof(TIfcType));
	}

	private long CountOf(Type theType)
	{
		HashSet<int> hashSet = new HashSet<int>();
		ExpressType expressType = Model.Metadata.ExpressType(theType);
		EsentEntityCursor entityTable = GetEntityTable();
		HashSet<short> hashSet2 = new HashSet<short>();
		IEnumerable<ExpressType> enumerable = ((expressType != null) ? expressType.NonAbstractSubTypes : Model.Metadata.TypesImplementing(theType));
		try
		{
			foreach (ExpressType item in enumerable)
			{
				XbimInstanceHandle ih;
				if (!item.IndexedClass)
				{
					hashSet2.Add(item.TypeId);
				}
				else if (entityTable.TrySeekEntityType(item.TypeId, out ih))
				{
					do
					{
						hashSet.Add(ih.EntityLabel);
					}
					while (entityTable.TryMoveNextEntityType(out ih));
				}
			}
			entityTable.MoveBeforeFirst();
			while (entityTable.TryMoveNext())
			{
				XbimInstanceHandle ih = entityTable.GetInstanceHandle();
				if (hashSet2.Contains(ih.EntityTypeId))
				{
					hashSet.Add(ih.EntityLabel);
				}
			}
			if (_caching)
			{
				foreach (KeyValuePair<int, IPersistEntity> item2 in CreatedNew.Where((KeyValuePair<int, IPersistEntity> m) => theType.IsAssignableFrom(m.Value.GetType())))
				{
					hashSet.Add(item2.Key);
				}
			}
		}
		finally
		{
			FreeTable(entityTable);
		}
		return hashSet.Count;
	}

	public bool Any<TIfcType>() where TIfcType : IPersistEntity
	{
		ExpressType expressType = Model.Metadata.ExpressType(typeof(TIfcType));
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			foreach (ExpressType nonAbstractSubType in expressType.NonAbstractSubTypes)
			{
				if (!entityTable.TrySeekEntityType(nonAbstractSubType.TypeId, out var _))
				{
					return true;
				}
			}
		}
		finally
		{
			FreeTable(entityTable);
		}
		return false;
	}

	internal IPersistEntity CreateNew(Type t)
	{
		if (!_caching)
		{
			throw new XbimException("XbimModel.BeginTransaction must be called before editing a model");
		}
		XbimInstanceHandle xbimInstanceHandle = _model.GetTransactingCursor().AddEntity(t);
		IPersistEntity value = _factory.New(_model, t, xbimInstanceHandle.EntityLabel, activated: true);
		value = _read.GetOrAdd(xbimInstanceHandle.EntityLabel, value);
		ModifiedEntities.TryAdd(xbimInstanceHandle.EntityLabel, value);
		CreatedNew.TryAdd(xbimInstanceHandle.EntityLabel, value);
		return value;
	}

	internal IPersistEntity CreateNew(Type type, int label)
	{
		return _factory.New(_model, type, label, activated: true);
	}

	internal void AddForwardReference(StepForwardReference forwardReference)
	{
		_forwardReferences.Add(forwardReference);
	}

	public long InstancesOfTypeCount(Type t)
	{
		return CountOf(t);
	}

	public IEnumerable<XbimInstanceHandle> InstanceHandlesOfType<TIfcType>()
	{
		Type typeFromHandle = typeof(TIfcType);
		ExpressType expressType = Model.Metadata.ExpressType(typeFromHandle);
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			foreach (ExpressType nonAbstractSubType in expressType.NonAbstractSubTypes)
			{
				if (entityTable.TrySeekEntityType(nonAbstractSubType.TypeId, out var ih))
				{
					yield return ih;
					while (entityTable.TryMoveNextEntityType(out ih))
					{
						yield return ih;
					}
				}
			}
		}
		finally
		{
			FreeTable(entityTable);
		}
	}

	public IPersistEntity GetInstance(int label, bool loadProperties = false, bool unCached = false)
	{
		if (_caching && _read.TryGetValue(label, out var value))
		{
			return value;
		}
		return GetInstanceFromStore(label, loadProperties, unCached);
	}

	public IPersistEntity GetOrCreateInstanceFromCache(int label, Type type, byte[] properties)
	{
		if (_read.TryGetValue(label, out var value))
		{
			return value;
		}
		if (type.IsAbstract)
		{
			_logger.LogError("Illegal Entity in the model #{0}, Type {1} is defined as Abstract and cannot be created", label, type.Name);
			return null;
		}
		return _read.GetOrAdd(label, delegate
		{
			IInstantiableEntity instantiableEntity = _factory.New(_model, type, label, activated: true);
			instantiableEntity.ReadEntityProperties(this, new BinaryReader(new MemoryStream(properties)), unCached: false, fromCache: true);
			return instantiableEntity;
		});
	}

	private IPersistEntity GetInstanceFromStore(int entityLabel, bool loadProperties = false, bool unCached = false)
	{
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			using (entityTable.BeginReadOnlyTransaction())
			{
				if (entityTable.TrySeekEntityLabel(entityLabel))
				{
					short ifcType = entityTable.GetIfcType();
					if (ifcType == 0)
					{
						return null;
					}
					IPersistEntity persistEntity;
					if (loadProperties)
					{
						byte[] properties = entityTable.GetProperties();
						persistEntity = _factory.New(_model, ifcType, entityLabel, activated: true);
						if (persistEntity == null)
						{
							return null;
						}
						persistEntity.ReadEntityProperties(this, new BinaryReader(new MemoryStream(properties)), unCached);
					}
					else
					{
						persistEntity = _factory.New(_model, ifcType, entityLabel, activated: false);
					}
					if (_caching && !unCached)
					{
						persistEntity = _read.GetOrAdd(entityLabel, persistEntity);
					}
					return persistEntity;
				}
			}
		}
		finally
		{
			FreeTable(entityTable);
		}
		return null;
	}

	public void Print()
	{
	}

	private IEnumerable<TIfcType> InstancesOf<TIfcType>(IEnumerable<ExpressType> expressTypes, bool activate = false, HashSet<int> read = null) where TIfcType : IPersistEntity
	{
		ExpressType[] array = (expressTypes as ExpressType[]) ?? expressTypes.ToArray();
		if (!array.Any())
		{
			yield break;
		}
		HashSet<int> entityLabels = read ?? new HashSet<int>();
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			HashSet<short> typeIds = new HashSet<short>();
			ExpressType[] array2 = array;
			foreach (ExpressType expressType in array2)
			{
				typeIds.Add(expressType.TypeId);
			}
			using (entityTable.BeginReadOnlyTransaction())
			{
				entityTable.MoveBeforeFirst();
				while (entityTable.TryMoveNext())
				{
					XbimInstanceHandle instanceHandle = entityTable.GetInstanceHandle();
					if (!typeIds.Contains(instanceHandle.EntityTypeId))
					{
						continue;
					}
					if (_caching && _read.TryGetValue(instanceHandle.EntityLabel, out var value))
					{
						if (activate && !value.Activated)
						{
							byte[] properties = entityTable.GetProperties();
							value.ReadEntityProperties(this, new BinaryReader(new MemoryStream(properties)));
							FlagSetter.SetActivationFlag(value, value: true);
						}
						entityLabels.Add(value.EntityLabel);
						yield return (TIfcType)value;
						continue;
					}
					if (activate)
					{
						byte[] properties2 = entityTable.GetProperties();
						value = _factory.New(_model, instanceHandle.EntityType, instanceHandle.EntityLabel, activated: true);
						value.ReadEntityProperties(this, new BinaryReader(new MemoryStream(properties2)));
					}
					else
					{
						value = _factory.New(_model, instanceHandle.EntityType, instanceHandle.EntityLabel, activated: false);
					}
					if (_caching)
					{
						value = _read.GetOrAdd(instanceHandle.EntityLabel, value);
					}
					entityLabels.Add(value.EntityLabel);
					yield return (TIfcType)value;
				}
			}
			if (!_caching)
			{
				yield break;
			}
			foreach (KeyValuePair<int, IPersistEntity> item in CreatedNew.Where((KeyValuePair<int, IPersistEntity> e) => e.Value is TIfcType))
			{
				if (entityLabels.Add(item.Key))
				{
					yield return (TIfcType)item.Value;
				}
			}
		}
		finally
		{
			FreeTable(entityTable);
		}
	}

	internal IEnumerable<TOType> OfType<TOType>(bool activate = false, int? indexKey = null, ExpressType overrideType = null) where TOType : IPersistEntity
	{
		int indexKeyAsInt = ((!indexKey.HasValue) ? (-1) : indexKey.Value);
		ExpressType expressType = overrideType ?? Model.Metadata.ExpressType(typeof(TOType));
		IEnumerable<ExpressType> enumerable = ((expressType != null) ? expressType.NonAbstractSubTypes : Model.Metadata.TypesImplementing(typeof(TOType)));
		HashSet<ExpressType> unindexedTypes = new HashSet<ExpressType>();
		HashSet<int> entityLabels = new HashSet<int>();
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			using (entityTable.BeginReadOnlyTransaction())
			{
				foreach (ExpressType item in enumerable)
				{
					if (!item.IndexedClass)
					{
						unindexedTypes.Add(item);
						continue;
					}
					short typeId = item.TypeId;
					if (!entityTable.TrySeekEntityType(typeId, out var ih, indexKeyAsInt) || !entityTable.TrySeekEntityLabel(ih.EntityLabel))
					{
						continue;
					}
					do
					{
						if (_caching && _read.TryGetValue(ih.EntityLabel, out var value))
						{
							if (activate && !value.Activated)
							{
								byte[] properties = entityTable.GetProperties();
								value = _factory.New(_model, ih.EntityType, ih.EntityLabel, activated: true);
								value.ReadEntityProperties(this, new BinaryReader(new MemoryStream(properties)));
							}
							entityLabels.Add(value.EntityLabel);
							yield return (TOType)value;
							continue;
						}
						if (activate)
						{
							byte[] properties2 = entityTable.GetProperties();
							value = _factory.New(_model, ih.EntityType, ih.EntityLabel, activated: true);
							value.ReadEntityProperties(this, new BinaryReader(new MemoryStream(properties2)));
						}
						else
						{
							value = _factory.New(_model, ih.EntityType, ih.EntityLabel, activated: false);
						}
						if (value == null)
						{
							_logger.LogError("Could not get {tp} #{label}={type}", ih.EntityType.IsAbstract ? "abstract" : "concrete", ih.EntityLabel, ih.EntityType);
							continue;
						}
						if (_caching)
						{
							value = _read.GetOrAdd(ih.EntityLabel, value);
						}
						entityLabels.Add(ih.EntityLabel);
						yield return (TOType)value;
					}
					while (entityTable.TryMoveNextEntityType(out ih) && entityTable.TrySeekEntityLabel(ih.EntityLabel));
				}
			}
			if (_caching)
			{
				foreach (KeyValuePair<int, IPersistEntity> item2 in CreatedNew.Where((KeyValuePair<int, IPersistEntity> e) => e.Value is TOType))
				{
					if (entityLabels.Add(item2.Key))
					{
						yield return (TOType)item2.Value;
					}
				}
			}
		}
		finally
		{
			FreeTable(entityTable);
		}
		foreach (TOType item3 in InstancesOf<TOType>(unindexedTypes, activate, entityLabels))
		{
			yield return item3;
		}
	}

	public void Activate(IPersistEntity entity)
	{
		byte[] entityBinaryData = GetEntityBinaryData(entity);
		if (entityBinaryData != null)
		{
			(entity as IInstantiableEntity).ReadEntityProperties(this, new BinaryReader(new MemoryStream(entityBinaryData)));
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~PersistedEntityInstanceCache()
	{
		Dispose(disposing: false);
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
				string systemDirectory = _jetInstance.Parameters.SystemDirectory;
				lock (OpenInstances)
				{
					OpenInstances.Remove(this);
					if (OpenInstances.Count((PersistedEntityInstanceCache c) => c.JetInstance == JetInstance) == 0)
					{
						_jetInstance.Term();
						if (Directory.Exists(systemDirectory))
						{
							Directory.Delete(systemDirectory, recursive: true);
						}
					}
				}
				_logger.LogDebug("Disposed PersistedEntityInstanceCache");
			}
			catch (Exception exception)
			{
				_logger.LogWarning(exception, "Failed to Dispose Esent Model");
			}
			finally
			{
				_jetInstance = null;
			}
		}
		_disposed = true;
	}

	internal byte[] GetEntityBinaryData(IPersistEntity entity)
	{
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			using (entityTable.BeginReadOnlyTransaction())
			{
				if (entityTable.TrySeekEntityLabel(entity.EntityLabel))
				{
					return entityTable.GetProperties();
				}
			}
		}
		finally
		{
			FreeTable(entityTable);
		}
		return null;
	}

	public void SaveAs(StorageType storageType, string storageFileName, ReportProgressDelegate progress = null, IDictionary<int, int> map = null)
	{
		if (storageType <= StorageType.Xbim)
		{
			switch (storageType)
			{
			default:
				_ = 8;
				return;
			case StorageType.IfcXml:
				SaveAsIfcXml(storageFileName);
				return;
			case StorageType.Ifc:
				break;
			case StorageType.IfcZip:
				goto IL_0043;
			case StorageType.IfcXml | StorageType.Ifc:
				return;
			}
		}
		else if (storageType != StorageType.Stp)
		{
			if (storageType != StorageType.StpZip && storageType != StorageType.Zip)
			{
				return;
			}
			goto IL_0043;
		}
		SaveAsIfc(storageFileName, map);
		return;
		IL_0043:
		SaveAsIfcZip(storageFileName);
	}

	private void SaveAsIfcZip(string storageFileName)
	{
		if (string.IsNullOrWhiteSpace(Path.GetExtension(storageFileName)))
		{
			storageFileName = Path.ChangeExtension(storageFileName, "IfcZip");
		}
		string entryName = (Path.GetExtension(storageFileName).ToLowerInvariant().Contains("ifc") ? Path.ChangeExtension(Path.GetFileName(storageFileName), "ifc") : Path.ChangeExtension(Path.GetFileName(storageFileName), "stp"));
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			using FileStream fileStream = new FileStream(storageFileName, FileMode.Create, FileAccess.Write);
			using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
			{
				using Stream stream = zipArchive.CreateEntry(entryName).Open();
				using (entityTable.BeginReadOnlyTransaction())
				{
					using TextWriter textWriter = new StreamWriter(stream);
					Part21Writer.Write(_model, textWriter, Model.Metadata);
					textWriter.Flush();
				}
				stream.Close();
			}
			fileStream.Close();
		}
		catch (Exception inner)
		{
			throw new XbimException("Failed to write IfcZip file " + storageFileName, inner);
		}
		finally
		{
			FreeTable(entityTable);
		}
	}

	private void SaveAsIfc(string storageFileName, IDictionary<int, int> map = null)
	{
		if (string.IsNullOrWhiteSpace(Path.GetExtension(storageFileName)))
		{
			storageFileName = Path.ChangeExtension(storageFileName, "Ifc");
		}
		EsentEntityCursor entityTable = GetEntityTable();
		try
		{
			using (entityTable.BeginReadOnlyTransaction())
			{
				using TextWriter textWriter = new StreamWriter(storageFileName);
				Part21Writer.Write(_model, textWriter, Model.Metadata, map);
				textWriter.Flush();
			}
		}
		catch (Exception inner)
		{
			throw new XbimException("Failed to write Ifc file " + storageFileName, inner);
		}
		finally
		{
			FreeTable(entityTable);
		}
	}

	private void SaveAsIfcXml(string storageFileName)
	{
		if (string.IsNullOrWhiteSpace(Path.GetExtension(storageFileName)))
		{
			storageFileName = Path.ChangeExtension(storageFileName, "IfcXml");
		}
		try
		{
			using FileStream output = new FileStream(storageFileName, FileMode.Create, FileAccess.ReadWrite);
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true
			};
			_model.Header.FileSchema.Schemas.FirstOrDefault();
			using XmlWriter output2 = XmlWriter.Create(output, settings);
			XbimSchemaVersion schemaVersion = _model.SchemaVersion;
			if (schemaVersion != XbimSchemaVersion.Ifc4 && schemaVersion == XbimSchemaVersion.Ifc2X3)
			{
				new IfcXmlWriter3().Write(_model, output2, InstanceHandles.Select((XbimInstanceHandle i) => _model.GetInstanceVolatile(i.EntityLabel)));
			}
			else
			{
				new XbimXmlWriter4(XbimXmlSettings.IFC4Add2).Write(_model, output2, InstanceHandles.Select((XbimInstanceHandle i) => _model.GetInstanceVolatile(i.EntityLabel)));
			}
		}
		catch (Exception inner)
		{
			throw new XbimException("Failed to write IfcXml file " + storageFileName, inner);
		}
	}

	public void Delete_Reversable(IPersistEntity instance)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<T> Where<T>(Func<T, bool> condition) where T : IPersistEntity
	{
		return Where(condition, null, null);
	}

	public IEnumerable<T> Where<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity
	{
		Type typeFromHandle = typeof(T);
		ExpressType expressType = Model.Metadata.ExpressType(typeFromHandle);
		List<ExpressType> source;
		if (expressType != null)
		{
			source = new List<ExpressType> { expressType };
		}
		else
		{
			List<ExpressType> implementations = (from t in Model.Metadata.ExpressTypesImplementing(typeFromHandle)
				where !t.Type.IsAbstract
				select t).ToList();
			source = implementations.Where((ExpressType implementation) => !implementations.Any((ExpressType i) => i != implementation && i.NonAbstractSubTypes.Contains(implementation))).ToList();
		}
		if (inverseProperty == null || inverseArgument == null || !source.All((ExpressType e) => e.HasIndexedAttribute && e.IndexedProperties.Any((PropertyInfo p) => p.Name == inverseProperty)))
		{
			return source.SelectMany((ExpressType overrideType) => OfType<T>(activate: true, null, overrideType).Where(condition));
		}
		InverseCache inverseCache = _model._inverseCache;
		if (inverseCache != null && inverseCache.TryGet(inverseProperty, inverseArgument, out IEnumerable<T> entities))
		{
			return entities;
		}
		entities = source.SelectMany((ExpressType t) => OfType<T>(activate: true, inverseArgument.EntityLabel, t).Where(condition));
		IList<T> list = (entities as IList<T>) ?? entities.ToList();
		inverseCache?.Add(inverseProperty, inverseArgument, list);
		return list;
	}

	public IEnumerable<XbimGeometryData> GetGeometry(short typeId, int productLabel, XbimGeometryType geomType)
	{
		XbimGeometryCursor geomTable = GetGeometryTable();
		try
		{
			using (geomTable.BeginReadOnlyTransaction())
			{
				foreach (XbimGeometryData item in geomTable.GeometryData(typeId, productLabel, geomType))
				{
					yield return item;
				}
			}
		}
		finally
		{
			FreeTable(geomTable);
		}
	}

	public IEnumerable<XbimGeometryData> GetGeometryData(XbimGeometryType ofType)
	{
		XbimGeometryCursor geometryTable = GetGeometryTable();
		try
		{
			foreach (XbimGeometryData geometryDatum in geometryTable.GetGeometryData(ofType))
			{
				yield return geometryDatum;
			}
		}
		finally
		{
			FreeTable(geometryTable);
		}
	}

	internal long GeometriesCount()
	{
		XbimGeometryCursor geometryTable = GetGeometryTable();
		try
		{
			return geometryTable.RetrieveCount();
		}
		finally
		{
			FreeTable(geometryTable);
		}
	}

	internal T InsertCopy<T>(T toCopy, XbimInstanceHandleMap mappings, XbimReadWriteTransaction txn, bool includeInverses, PropertyTranformDelegate propTransform = null, bool keepLabels = true) where T : IPersistEntity
	{
		XbimInstanceHandle handle = toCopy.GetHandle();
		if (mappings.TryGetValue(handle, out var value))
		{
			return (T)GetInstance(value);
		}
		txn.Pulse();
		ExpressType expressType = Model.Metadata.ExpressType(toCopy);
		int entityLabel = toCopy.EntityLabel;
		value = (keepLabels ? InsertNew(expressType.Type, entityLabel) : InsertNew(expressType.Type));
		mappings.Add(handle, value);
		IInstantiableEntity instantiableEntity = _factory.New(_model, value.EntityType, value.EntityLabel, activated: true);
		_read.TryAdd(value.EntityLabel, instantiableEntity);
		CreatedNew.TryAdd(value.EntityLabel, instantiableEntity);
		ModifiedEntities.TryAdd(value.EntityLabel, instantiableEntity);
		IEnumerable<ExpressMetaProperty> enumerable = expressType.Properties.Values.Where((ExpressMetaProperty p) => !p.EntityAttribute.IsDerived);
		if (includeInverses)
		{
			enumerable = enumerable.Union(expressType.Inverses);
		}
		foreach (ExpressMetaProperty item in enumerable)
		{
			object obj = ((propTransform != null) ? propTransform(item, toCopy) : item.PropertyInfo.GetValue(toCopy, null));
			if (obj == null)
			{
				continue;
			}
			bool flag = item.EntityAttribute.Order == -1;
			Type type = obj.GetType();
			if (type.IsValueType || typeof(ExpressType).IsAssignableFrom(type))
			{
				item.PropertyInfo.SetValue(instantiableEntity, obj, null);
			}
			else if (!flag && typeof(IPersistEntity).IsAssignableFrom(type))
			{
				item.PropertyInfo.SetValue(instantiableEntity, InsertCopy((IPersistEntity)obj, mappings, txn, includeInverses, propTransform, keepLabels), null);
			}
			else if (!flag && typeof(IList).IsAssignableFrom(type))
			{
				Type itemTypeFromGenericType = type.GetItemTypeFromGenericType();
				if (!(item.PropertyInfo.GetValue(instantiableEntity, null) is IList list))
				{
					throw new XbimException($"Unexpected collection type ({itemTypeFromGenericType.Name}) found");
				}
				foreach (object item2 in (IExpressEnumerable)obj)
				{
					Type type2 = item2.GetType();
					if (type2.IsValueType || typeof(ExpressType).IsAssignableFrom(type2))
					{
						list.Add(item2);
						continue;
					}
					if (typeof(IPersistEntity).IsAssignableFrom(type2))
					{
						IPersistEntity value2 = InsertCopy((IPersistEntity)item2, mappings, txn, includeInverses, propTransform, keepLabels);
						list.Add(value2);
						continue;
					}
					if (typeof(IList).IsAssignableFrom(type2))
					{
						IList list2 = (IList)item2;
						MethodInfo? method = list.GetType().GetMethod("GetAt");
						if (method == null)
						{
							throw new Exception($"GetAt Method not found on ({list.GetType().Name}) found");
						}
						IList list3 = method.Invoke(list, new object[1] { list.Count }) as IList;
						foreach (object item3 in list2)
						{
							Type type3 = item3.GetType();
							if (type3.IsValueType || typeof(ExpressType).IsAssignableFrom(type3))
							{
								list3.Add(item3);
								continue;
							}
							if (typeof(IPersistEntity).IsAssignableFrom(type3))
							{
								IPersistEntity value3 = InsertCopy((IPersistEntity)item3, mappings, txn, includeInverses, propTransform, keepLabels);
								list3.Add(value3);
								continue;
							}
							throw new Exception($"Unexpected collection item type ({itemTypeFromGenericType.Name}) found");
						}
						continue;
					}
					throw new XbimException($"Unexpected collection item type ({itemTypeFromGenericType.Name}) found");
				}
			}
			else if (flag && obj is IEnumerable<IPersistEntity>)
			{
				foreach (IPersistEntity item4 in (IEnumerable<IPersistEntity>)obj)
				{
					if (!mappings.TryGetValue(item4.GetHandle(), out var _))
					{
						InsertCopy(item4, mappings, txn, includeInverses, propTransform, keepLabels);
					}
				}
			}
			else
			{
				if (!flag || !(obj is IPersistEntity))
				{
					throw new XbimException($"Unexpected item type ({type.Name})  found");
				}
				IPersistEntity persistEntity = (IPersistEntity)obj;
				if (!mappings.TryGetValue(persistEntity.GetHandle(), out var _))
				{
					InsertCopy(persistEntity, mappings, txn, includeInverses, propTransform, keepLabels);
				}
			}
		}
		return (T)instantiableEntity;
	}

	private IPersistEntity GetInstance(XbimInstanceHandle map)
	{
		return GetInstance(map.EntityLabel);
	}

	private XbimInstanceHandle InsertNew(Type type, int entityLabel)
	{
		return _model.GetTransactingCursor().AddEntity(type, entityLabel);
	}

	private XbimInstanceHandle InsertNew(Type type)
	{
		return _model.GetTransactingCursor().AddEntity(type);
	}

	internal void AddModified(IPersistEntity entity)
	{
		ModifiedEntities.TryAdd(entity.EntityLabel, entity as IInstantiableEntity);
	}

	internal void BeginCaching()
	{
		if (!_caching)
		{
			_read.Clear();
		}
		ModifiedEntities.Clear();
		CreatedNew.Clear();
		_previousCaching = _caching;
		_caching = true;
	}

	internal void EndCaching()
	{
		if (!_previousCaching)
		{
			_read.Clear();
		}
		ModifiedEntities.Clear();
		CreatedNew.Clear();
		_caching = _previousCaching;
	}

	internal void Write(EsentEntityCursor entityTable)
	{
		foreach (IPersistEntity value in ModifiedEntities.Values)
		{
			entityTable.UpdateEntity(value);
		}
		ModifiedEntities.Clear();
		CreatedNew.Clear();
	}

	internal IEnumerable<IPersistEntity> Modified()
	{
		return ModifiedEntities.Values;
	}

	internal XbimGeometryHandleCollection GetGeometryHandles(XbimGeometryType geomType = XbimGeometryType.TriangulatedMesh, XbimGeometrySort sortOrder = XbimGeometrySort.OrderByIfcSurfaceStyleThenIfcType)
	{
		XbimGeometryCursor geometryTable = GetGeometryTable();
		try
		{
			return geometryTable.GetGeometryHandles(geomType, sortOrder);
		}
		finally
		{
			FreeTable(geometryTable);
		}
	}

	internal XbimGeometryData GetGeometryData(XbimGeometryHandle handle)
	{
		XbimGeometryCursor geometryTable = GetGeometryTable();
		try
		{
			return geometryTable.GetGeometryData(handle);
		}
		finally
		{
			FreeTable(geometryTable);
		}
	}

	internal IEnumerable<XbimGeometryData> GetGeometryData(IEnumerable<XbimGeometryHandle> handles)
	{
		XbimGeometryCursor geometryTable = GetGeometryTable();
		try
		{
			foreach (XbimGeometryData geometryDatum in geometryTable.GetGeometryData(handles))
			{
				yield return geometryDatum;
			}
		}
		finally
		{
			FreeTable(geometryTable);
		}
	}

	internal XbimGeometryHandle GetGeometryHandle(int geometryLabel)
	{
		XbimGeometryCursor geometryTable = GetGeometryTable();
		try
		{
			return geometryTable.GetGeometryHandle(geometryLabel);
		}
		finally
		{
			FreeTable(geometryTable);
		}
	}

	internal IEnumerable<IPersistEntity> OfType(string stringType, bool activate)
	{
		ExpressType expressType = Model.Metadata.ExpressType(stringType.ToUpper());
		ExpressType overrideType;
		if (expressType == null)
		{
			IEnumerable<ExpressType> enumerable = Model.Metadata.TypesImplementing(stringType);
			foreach (ExpressType item in enumerable)
			{
				PersistedEntityInstanceCache persistedEntityInstanceCache = this;
				overrideType = item;
				foreach (IPersistEntity item2 in persistedEntityInstanceCache.OfType<IPersistEntity>(activate, null, overrideType))
				{
					yield return item2;
				}
			}
			yield break;
		}
		PersistedEntityInstanceCache persistedEntityInstanceCache2 = this;
		overrideType = expressType;
		foreach (IPersistEntity item3 in persistedEntityInstanceCache2.OfType<IPersistEntity>(activate, null, overrideType))
		{
			yield return item3;
		}
	}

	internal void CacheStart()
	{
		_caching = true;
	}

	internal void CacheClear()
	{
		_read.Clear();
	}

	internal void CacheStop()
	{
		_read.Clear();
		_caching = false;
	}

	internal XbimGeometryData GetGeometryData(int geomLabel)
	{
		XbimGeometryCursor geometryTable = GetGeometryTable();
		try
		{
			return geometryTable.GetGeometryData(geomLabel);
		}
		finally
		{
			FreeTable(geometryTable);
		}
	}

	internal EsentShapeGeometryCursor GetShapeGeometryTable()
	{
		lock (_lockObject)
		{
			for (int i = 0; i < _geometryTables.Length; i++)
			{
				if (_geometryTables[i] != null && _geometryTables[i] is EsentShapeGeometryCursor)
				{
					EsentCursor obj = _geometryTables[i];
					_geometryTables[i] = null;
					return (EsentShapeGeometryCursor)obj;
				}
			}
		}
		OpenDatabaseGrbit mode = AttachedDatabase();
		return new EsentShapeGeometryCursor(_model, _databaseName, mode);
	}

	internal bool DeleteJetTable(string name)
	{
		if (!HasTable(name))
		{
			return true;
		}
		try
		{
			Api.JetDeleteTable(_session, _databaseId, name);
		}
		catch (Exception exception)
		{
			_logger.LogWarning(exception, "Failed to delete Jet table {table}", name);
			return false;
		}
		return true;
	}

	internal bool DeleteGeometry()
	{
		CleanTableArrays(disposeTables: true);
		return (byte)(1u & (DeleteJetTable(EsentShapeInstanceCursor.InstanceTableName) ? 1u : 0u) & (DeleteJetTable(XbimGeometryCursor.GeometryTableName) ? 1u : 0u) & (DeleteJetTable(EsentShapeGeometryCursor.GeometryTableName) ? 1u : 0u)) != 0;
	}

	internal bool DatabaseHasInstanceTable()
	{
		return HasTable(EsentShapeInstanceCursor.InstanceTableName);
	}

	internal bool DatabaseHasGeometryTable()
	{
		return HasTable(XbimGeometryCursor.GeometryTableName);
	}

	internal bool HasTable(string name)
	{
		return HasTable(name, _session, _databaseId);
	}

	internal void Compact(string targetName)
	{
		using Session session = new Session(_jetInstance);
		Api.JetAttachDatabase(session, _databaseName, AttachDatabaseGrbit.None);
		Api.JetCompact(session, _databaseName, targetName, null, null, CompactGrbit.None);
	}

	private static bool HasTable(string name, Session sess, JET_DBID db)
	{
		JET_TABLEID tableid;
		bool num = Api.TryOpenTable(sess, db, name, OpenTableGrbit.ReadOnly, out tableid);
		if (num)
		{
			Api.JetCloseTable(sess, tableid);
		}
		return num;
	}

	internal EsentShapeInstanceCursor GetShapeInstanceTable()
	{
		lock (_lockObject)
		{
			for (int i = 0; i < _geometryTables.Length; i++)
			{
				if (_geometryTables[i] != null && _geometryTables[i] is EsentShapeInstanceCursor)
				{
					EsentCursor obj = _geometryTables[i];
					_geometryTables[i] = null;
					return (EsentShapeInstanceCursor)obj;
				}
			}
		}
		OpenDatabaseGrbit mode = AttachedDatabase();
		return new EsentShapeInstanceCursor(_model, _databaseName, mode);
	}

	internal EsentEntityCursor GetWriteableEntityTable()
	{
		AttachedDatabase();
		return new EsentEntityCursor(_model, _databaseName, OpenDatabaseGrbit.None, _loggerFactory);
	}
}
