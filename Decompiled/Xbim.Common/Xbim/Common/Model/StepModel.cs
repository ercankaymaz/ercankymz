using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QUT.Gppg;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Parser;
using Xbim.IO.Step21;

namespace Xbim.Common.Model;

public class StepModel : IModel, IDisposable
{
	protected ILoggerFactory _loggerFactory;

	private readonly EntityCollection _instances;

	private readonly EntityFactoryResolverDelegate _factoryResolver;

	private WeakReference _transactionReference;

	private InMemoryGeometryStore _geometryStore;

	private ExpressMetaData _metadata;

	private List<NewEntityHandler> _newEntityHandlers = new List<NewEntityHandler>();

	private List<ModifiedEntityHandler> _modifiedEntityHandlers = new List<ModifiedEntityHandler>();

	private List<DeletedEntityHandler> _deletedEntityHandlers = new List<DeletedEntityHandler>();

	private WeakReference _cacheReference;

	private const int BufferSize = 1024;

	private WeakReference<MemoryEntityCache> _entityCacheReference;

	protected ILogger Logger { get; private set; }

	public IEntityFactory EntityFactory { get; private set; }

	public bool AllowMissingReferences { get; set; }

	public object Tag { get; set; }

	public int UserDefinedId { get; set; }

	public virtual IEntityCollection Instances => _instances;

	public IStepFileHeader Header { get; protected set; }

	public virtual bool IsTransactional { get; private set; }

	public virtual ITransaction CurrentTransaction
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

	public virtual IModelFactors ModelFactors { get; set; }

	public ExpressMetaData Metadata => _metadata ?? (_metadata = ExpressMetaData.GetMetadata(EntityFactory));

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
		private set
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

	private static Encoding UTF8Encoding { get; } = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

	public IGeometryStore GeometryStore => _geometryStore ?? (_geometryStore = new InMemoryGeometryStore());

	public IList<XbimInstanceHandle> InstanceHandles => _instances.Select((IPersistEntity e) => new XbimInstanceHandle(this, e.EntityLabel, 0)).ToList();

	public XbimSchemaVersion SchemaVersion => EntityFactory.SchemaVersion;

	internal MemoryEntityCache EntityCacheReference
	{
		get
		{
			if (_entityCacheReference == null)
			{
				return null;
			}
			if (_entityCacheReference.TryGetTarget(out var target))
			{
				return target;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				_entityCacheReference = null;
			}
			else
			{
				_entityCacheReference = new WeakReference<MemoryEntityCache>(value);
			}
		}
	}

	public IEntityCache EntityCache => EntityCacheReference;

	private event NewEntityHandler _entityNew;

	private event ModifiedEntityHandler _entityModified;

	private event DeletedEntityHandler _entityDeleted;

	public event NewEntityHandler EntityNew
	{
		add
		{
			_entityNew += value;
			_newEntityHandlers.Add(value);
		}
		remove
		{
			_entityNew -= value;
			_newEntityHandlers.RemoveAll((NewEntityHandler v) => v.Equals(value));
		}
	}

	public event ModifiedEntityHandler EntityModified
	{
		add
		{
			_entityModified += value;
			_modifiedEntityHandlers.Add(value);
		}
		remove
		{
			_entityModified -= value;
			_modifiedEntityHandlers.RemoveAll((ModifiedEntityHandler v) => v.Equals(value));
		}
	}

	public event DeletedEntityHandler EntityDeleted
	{
		add
		{
			_entityDeleted += value;
			_deletedEntityHandlers.Add(value);
		}
		remove
		{
			_entityDeleted -= value;
			_deletedEntityHandlers.RemoveAll((DeletedEntityHandler v) => v.Equals(value));
		}
	}

	public static List<string> GetStepFileSchemaVersion(Stream stream)
	{
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		Scanner scanner = new Scanner(stream, loggerFactory);
		int num = scanner.yylex();
		int num2 = 68;
		int num3 = 64;
		int num4 = 73;
		int num5 = 76;
		List<string> list = new List<string>();
		while (num != num2 && num != num3)
		{
			if (num != num4)
			{
				num = scanner.yylex();
				continue;
			}
			if (!string.Equals(scanner.yylval.strVal, "FILE_SCHEMA", StringComparison.OrdinalIgnoreCase))
			{
				num = scanner.yylex();
				continue;
			}
			num = scanner.yylex();
			while (num != 41)
			{
				if (num != num5)
				{
					num = scanner.yylex();
					continue;
				}
				list.Add(scanner.yylval.strVal.Trim(new char[1] { '\'' }));
				num = scanner.yylex();
			}
			break;
		}
		return list;
	}

	public StepModel(IEntityFactory entityFactory, ILoggerFactory loggerFactory, int labelFrom)
	{
		SetupLogger(loggerFactory);
		InitFromEntityFactory(entityFactory);
		_instances = new EntityCollection(this, labelFrom);
		IsTransactional = true;
		ModelFactors = new XbimModelFactors(Math.PI / 180.0, 0.001, 1E-05);
		Header = new StepFileHeader(StepFileHeader.HeaderCreationMode.InitWithXbimDefaults, this);
		foreach (string schemasId in EntityFactory.SchemasIds)
		{
			Header.FileSchema.Schemas.Add(schemasId);
		}
	}

	private void SetupLogger(ILoggerFactory loggerFactory)
	{
		_loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		Logger = _loggerFactory.CreateLogger<StepModel>();
	}

	public StepModel(IEntityFactory entityFactory, ILoggerFactory loggerFactory = null)
		: this(entityFactory, loggerFactory, 0)
	{
	}

	[Obsolete("Prefer ILoggerFactory overload instead")]
	public StepModel(IEntityFactory entityFactory, ILogger logger, int labelFrom)
		: this(entityFactory, (ILoggerFactory)null, labelFrom)
	{
		Logger = logger ?? XbimLogging.CreateLogger<StepModel>();
	}

	public StepModel(EntityFactoryResolverDelegate factoryResolver, ILoggerFactory loggerFactory, int labelFrom = 0)
	{
		SetupLogger(loggerFactory);
		_factoryResolver = factoryResolver;
		_instances = new EntityCollection(this, labelFrom);
		IsTransactional = true;
		Header = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty, this);
		ModelFactors = new XbimModelFactors(Math.PI / 180.0, 0.001, 1E-05);
	}

	[Obsolete("Prefer ILoggerFactory overload instead")]
	public StepModel(EntityFactoryResolverDelegate factoryResolver, ILogger logger, int labelFrom)
		: this(factoryResolver, (ILoggerFactory)null, labelFrom)
	{
		Logger = Logger ?? logger ?? XbimServices.Current.ServiceProvider.GetRequiredService<ILogger<StepModel>>();
	}

	private void InitFromEntityFactory(IEntityFactory entityFactory)
	{
		EntityFactory = entityFactory ?? throw new ArgumentNullException("entityFactory");
	}

	bool IModel.Activate(IPersistEntity owningEntity)
	{
		return true;
	}

	public virtual void Delete(IPersistEntity entity)
	{
		ModelHelper.Delete(this, entity, (IPersistEntity e) => _instances.RemoveReversible(e));
	}

	public virtual void Delete(IPersistEntity[] entities, bool noTransaction)
	{
		if (noTransaction)
		{
			IsTransactional = false;
		}
		try
		{
			ModelHelper.Delete(this, entities, delegate(IPersistEntity[] e)
			{
				_instances.RemoveReversible(e);
			});
		}
		finally
		{
			IsTransactional = true;
		}
	}

	public virtual void DiscardNaturalOrder()
	{
		_instances.DiscardNaturalOrder();
	}

	public virtual ITransaction BeginTransaction(string name)
	{
		if (CurrentTransaction != null)
		{
			throw new XbimException("Transaction is opened already.");
		}
		if (InverseCache != null)
		{
			throw new XbimException("Transaction can't be open when cache is in operation.");
		}
		return CurrentTransaction = new Transaction(this);
	}

	public virtual void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body) where TSource : IPersistEntity
	{
		foreach (TSource item in source)
		{
			body(item);
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
		return InverseCache = new MemoryInverseCache(_instances);
	}

	internal void HandleEntityChange(ChangeType changeType, IPersistEntity entity, int propertyOrder)
	{
		switch (changeType)
		{
		case ChangeType.New:
			this._entityNew?.Invoke(entity);
			break;
		case ChangeType.Deleted:
			this._entityDeleted?.Invoke(entity);
			break;
		case ChangeType.Modified:
			this._entityModified?.Invoke(entity, propertyOrder);
			break;
		default:
			throw new ArgumentOutOfRangeException("changeType", changeType, null);
		}
	}

	public int LoadStep21Part(Stream data)
	{
		XbimP21Scanner parser = new XbimP21Scanner(data, -1L, _loggerFactory)
		{
			AllowMissingReferences = AllowMissingReferences
		};
		return LoadStep21(parser);
	}

	public int LoadStep21Part(string data)
	{
		XbimP21Scanner parser = new XbimP21Scanner(data, _loggerFactory)
		{
			AllowMissingReferences = AllowMissingReferences
		};
		return LoadStep21(parser);
	}

	public static IStepFileHeader LoadStep21Header(Stream stream)
	{
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		StepFileHeader header = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty, null);
		XbimP21Scanner xbimP21Scanner = new XbimP21Scanner(stream, 1000L, loggerFactory);
		xbimP21Scanner.EntityCreate = (CreateEntityDelegate)Delegate.Combine(xbimP21Scanner.EntityCreate, (CreateEntityDelegate)delegate(string name, long? label, bool inHeader)
		{
			if (inHeader)
			{
				switch (name)
				{
				case "FILE_DESCRIPTION":
					return header.FileDescription;
				case "FILE_NAME":
					return header.FileName;
				case "FILE_SCHEMA":
					if (header.FileSchema != null)
					{
						header.FileSchema = new StepFileSchema();
					}
					return header.FileSchema;
				default:
					return (IPersist)null;
				}
			}
			return (IPersist)null;
		});
		try
		{
			xbimP21Scanner.Parse(onlyHeader: true);
		}
		catch (Exception inner)
		{
			LexLocation currentPosition = xbimP21Scanner.CurrentPosition;
			throw new XbimParserException($"Parser failed on line {currentPosition.EndLine}, column {currentPosition.EndColumn}", inner);
		}
		return header;
	}

	protected virtual int LoadStep21(XbimP21Scanner parser)
	{
		if (Header == null)
		{
			Header = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty, this);
		}
		if (EntityFactory == null && _factoryResolver == null)
		{
			throw new XbimParserException("EntityFactory is not defined and no resolver is specified to create one. Data can't be created.");
		}
		parser.EntityCreate = (CreateEntityDelegate)Delegate.Combine(parser.EntityCreate, (CreateEntityDelegate)delegate(string name, long? label, bool header)
		{
			if (header)
			{
				switch (name)
				{
				case "FILE_DESCRIPTION":
					return Header.FileDescription;
				case "FILE_NAME":
					return Header.FileName;
				case "FILE_SCHEMA":
					if (Header.FileSchema != null)
					{
						Header.FileSchema = new StepFileSchema();
					}
					return Header.FileSchema;
				default:
					return (IPersist)null;
				}
			}
			if (EntityFactory == null)
			{
				EntityFactory = _factoryResolver(Header.FileSchema.Schemas);
				if (EntityFactory == null)
				{
					throw new XbimParserException("Entity factory resolver didn't resolve factory for schema '" + string.Join(", ", Header.FileSchema.Schemas) + "'");
				}
				InitFromEntityFactory(EntityFactory);
			}
			if (!label.HasValue)
			{
				return EntityFactory.New(name);
			}
			IInstantiableEntity instantiableEntity = EntityFactory.New(this, name, (int)label.Value, activated: true);
			if (instantiableEntity != null)
			{
				_instances.InternalAdd(instantiableEntity);
			}
			else
			{
				string message = $"Error in file at label {label} for type {name}.";
				ExpressType expressType = Metadata.ExpressType(name);
				if (expressType == null)
				{
					message = $"Illegal element in file; cannot find type {name} at label {label}.";
				}
				else if (expressType.Type.GetTypeInfo().IsAbstract)
				{
					message = $"Illegal element in file; cannot instantiate the abstract type {name} at label {label}.";
				}
				Logger?.LogError(message);
			}
			if (label >= _instances.CurrentLabel)
			{
				_instances.CurrentLabel = (int)label.Value;
			}
			return instantiableEntity;
		});
		try
		{
			parser.Parse();
			if (Header.FileSchema.Schemas.Count == 0 && EntityFactory != null)
			{
				foreach (string item in EntityFactory?.SchemasIds)
				{
					Header.FileSchema.Schemas.Add(item);
				}
			}
		}
		catch (Exception inner)
		{
			LexLocation currentPosition = parser.CurrentPosition;
			throw new XbimParserException($"Parser failed on line {currentPosition.EndLine}, column {currentPosition.EndColumn}", inner);
		}
		if (EntityFactory == null)
		{
			EntityFactory = _factoryResolver(Header.FileSchema.Schemas);
			if (EntityFactory == null)
			{
				throw new XbimParserException("Entity factory resolver didn't resolve factory for schema '" + string.Join(", ", Header.FileSchema.Schemas) + "'");
			}
			InitFromEntityFactory(EntityFactory);
		}
		for (int num = 0; num < Header.FileSchema.Schemas.Count; num++)
		{
			string id = Header.FileSchema.Schemas[num];
			string text = EntityFactory.SchemasIds.FirstOrDefault((string s) => id.StartsWith(s, StringComparison.OrdinalIgnoreCase));
			if (text == null)
			{
				HashSet<string> obj = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "IFC2X_FINAL", "IFC2X2_FINAL", "IFC2X2", "IFC2X4_RC3" };
				HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "IFC4X3_RC2", "IFC4X3_RC4", "IFC4X3", "IFC4X3_ADD1" };
				if (obj.Contains(id))
				{
					text = EntityFactory.SchemasIds.FirstOrDefault((string s) => string.Equals(s, "IFC2X3", StringComparison.OrdinalIgnoreCase));
				}
				else
				{
					if (!hashSet.Contains(id))
					{
						string text2 = ", " + EntityFactory.SchemasIds;
						throw new XbimParserException("Mismatch between schema '" + id + "' defined in the file and schemas available in the entity factory [" + text2 + "].");
					}
					text = EntityFactory.SchemasIds.FirstOrDefault((string s) => s.StartsWith("IFC4X3", StringComparison.OrdinalIgnoreCase));
				}
			}
			if (id != text)
			{
				Header.FileSchema.Schemas[num] = text;
			}
		}
		return parser.ErrorCount;
	}

	public virtual int LoadStep21(Stream stream, long streamSize, ReportProgressDelegate progDelegate = null, IEnumerable<string> ignoreTypes = null)
	{
		XbimP21Scanner xbimP21Scanner = new XbimP21Scanner(stream, streamSize, _loggerFactory, ignoreTypes)
		{
			AllowMissingReferences = AllowMissingReferences
		};
		if (progDelegate != null)
		{
			xbimP21Scanner.ProgressStatus += progDelegate;
		}
		try
		{
			return LoadStep21(xbimP21Scanner);
		}
		catch
		{
			throw;
		}
		finally
		{
			if (progDelegate != null)
			{
				xbimP21Scanner.ProgressStatus -= progDelegate;
			}
		}
	}

	public virtual int LoadStep21(string file, ReportProgressDelegate progDelegate = null)
	{
		using FileStream fileStream = File.OpenRead(file);
		return LoadStep21(fileStream, fileStream.Length, progDelegate);
	}

	public virtual void SaveAsStep21(Stream stream, ReportProgressDelegate progress = null, bool leaveOpen = false)
	{
		using StreamWriter writer = new StreamWriter(stream, UTF8Encoding, 1024, leaveOpen);
		SaveAsStep21(writer, progress);
	}

	public virtual void SaveAsStep21(TextWriter writer, ReportProgressDelegate progress = null)
	{
		Part21Writer.Write(this, writer, Metadata, new Dictionary<int, int>());
	}

	protected virtual void Dispose(bool native)
	{
		_instances.Dispose();
		_transactionReference = null;
		_cacheReference = null;
		_entityCacheReference = null;
		_newEntityHandlers.ToList().ForEach(delegate(NewEntityHandler h)
		{
			EntityNew -= h;
		});
		_modifiedEntityHandlers.ToList().ForEach(delegate(ModifiedEntityHandler h)
		{
			EntityModified -= h;
		});
		_deletedEntityHandlers.ToList().ForEach(delegate(DeletedEntityHandler h)
		{
			EntityDeleted -= h;
		});
		_newEntityHandlers.Clear();
		_modifiedEntityHandlers.Clear();
		_deletedEntityHandlers.Clear();
	}

	public void Dispose()
	{
		Dispose(native: true);
		GC.SuppressFinalize(this);
	}

	public T InsertCopy<T>(T toCopy, XbimInstanceHandleMap mappings, PropertyTranformDelegate propTransform, bool includeInverses, bool keepLabels) where T : IPersistEntity
	{
		return InsertCopy(toCopy, mappings, propTransform, includeInverses, keepLabels, noTransaction: false);
	}

	public T InsertCopy<T>(T toCopy, XbimInstanceHandleMap mappings, PropertyTranformDelegate propTransform, bool includeInverses, bool keepLabels, bool noTransaction) where T : IPersistEntity
	{
		if (noTransaction)
		{
			IsTransactional = false;
		}
		try
		{
			return ModelHelper.InsertCopy(this, toCopy, mappings, propTransform, includeInverses, keepLabels, (Type type, int i) => _instances.New(type, i));
		}
		catch
		{
			throw;
		}
		finally
		{
			IsTransactional = true;
		}
	}

	public IEntityCache BeginEntityCaching()
	{
		return EntityCacheReference = new MemoryEntityCache(this);
	}

	protected void AddEntityInternal(IPersistEntity entity)
	{
		_instances.InternalAdd(entity);
	}
}
