using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Federation;
using Xbim.Common.Geometry;
using Xbim.Common.Metadata;
using Xbim.Common.Model;
using Xbim.Common.Step21;
using Xbim.IO;
using Xbim.IO.Memory;
using Xbim.IO.Step21;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc;

public class IfcStore : IModel, IDisposable, IFederatedModel, IEquatable<IModel>
{
	private const string RefDocument = "XbimReferencedModel";

	private bool _disposed;

	private IIfcOwnerHistory _ownerHistoryAddObject;

	private IIfcOwnerHistory _ownerHistoryModifyObject;

	private IIfcPersonAndOrganization _defaultOwningUser;

	private IIfcApplication _defaultOwningApplication;

	private readonly ReferencedModelCollection _referencedModels = new ReferencedModelCollection();

	internal bool ManageOwnerHistory = true;

	public IModel Model { get; protected set; }

	public XbimEditorCredentials EditorDetails { get; private set; }

	public IModelProvider ModelProvider { get; private set; }

	[Obsolete("Redundant. Model Providers are now provided by internal dependency injection with the ServicesProvider on XbimServices")]
	public static IModelProviderFactory ModelProviderFactory { get; set; }

	public object Tag
	{
		get
		{
			return Model.Tag;
		}
		set
		{
			Model.Tag = value;
		}
	}

	protected ILogger Logger { get; private set; }

	public IInverseCache InverseCache => Model.InverseCache;

	public int UserDefinedId
	{
		get
		{
			return Model.UserDefinedId;
		}
		set
		{
			Model.UserDefinedId = value;
		}
	}

	public IGeometryStore GeometryStore => Model.GeometryStore;

	public IStepFileHeader Header => Model.Header;

	public bool IsTransactional => Model.IsTransactional;

	public string Location => ModelProvider.GetLocation(Model);

	public IEntityCollection Instances => Model.Instances;

	public IList<XbimInstanceHandle> InstanceHandles => Model.InstanceHandles.ToList();

	public ITransaction CurrentTransaction => Model.CurrentTransaction;

	public ExpressMetaData Metadata => Model.Metadata;

	public IModelFactors ModelFactors => Model.ModelFactors;

	public IEntityCache EntityCache => Model.EntityCache;

	public XbimSchemaVersion SchemaVersion => Model.SchemaVersion;

	public IIfcPersonAndOrganization DefaultOwningUser
	{
		get
		{
			if (_defaultOwningUser != null)
			{
				return _defaultOwningUser;
			}
			_defaultOwningUser = this.GetOrCreateDefaultUser(EditorDetails);
			return _defaultOwningUser;
		}
	}

	public IIfcApplication DefaultOwningApplication
	{
		get
		{
			if (_defaultOwningApplication != null)
			{
				return _defaultOwningApplication;
			}
			_defaultOwningApplication = this.GetOrCreateApplication(EditorDetails, addDefaultRole: true);
			return _defaultOwningApplication;
		}
	}

	public IIfcOwnerHistory OwnerHistoryAddObject
	{
		get
		{
			if (_ownerHistoryAddObject != null)
			{
				return _ownerHistoryAddObject;
			}
			EntityCreator entityCreator = new EntityCreator(this);
			_ownerHistoryAddObject = entityCreator.OwnerHistory(delegate(IIfcOwnerHistory owner)
			{
				owner.OwningUser = DefaultOwningUser;
				owner.OwningApplication = DefaultOwningApplication;
				owner.ChangeAction = IfcChangeActionEnum.ADDED;
				owner.LastModifyingUser = DefaultOwningUser;
				owner.LastModifyingApplication = DefaultOwningApplication;
			});
			return _ownerHistoryAddObject;
		}
	}

	internal IIfcOwnerHistory OwnerHistoryModifyObject
	{
		get
		{
			if (_ownerHistoryModifyObject != null)
			{
				return _ownerHistoryModifyObject;
			}
			EntityCreator entityCreator = new EntityCreator(this);
			_ownerHistoryModifyObject = entityCreator.OwnerHistory(delegate(IIfcOwnerHistory owner)
			{
				owner.OwningUser = DefaultOwningUser;
				owner.OwningApplication = DefaultOwningApplication;
				owner.ChangeAction = IfcChangeActionEnum.MODIFIED;
				owner.LastModifyingUser = DefaultOwningUser;
				owner.LastModifyingApplication = DefaultOwningApplication;
			});
			return _ownerHistoryModifyObject;
		}
	}

	public string FileName { get; set; }

	public IEnumerable<IReferencedModel> ReferencedModels => _referencedModels.AsEnumerable();

	public virtual bool IsFederation => _referencedModels.Any();

	public IModel ReferencingModel => Model;

	public IReadOnlyEntityCollection FederatedInstances => new FederatedModelInstances(this);

	public IList<XbimInstanceHandle> FederatedInstanceHandles => ReferencedModels.Select((IReferencedModel r) => r.Model).Concat(new IfcStore[1] { this }).SelectMany((IModel m) => m.InstanceHandles)
		.ToList();

	public event NewEntityHandler EntityNew;

	public event ModifiedEntityHandler EntityModified;

	public event DeletedEntityHandler EntityDeleted;

	static IfcStore()
	{
		if (XbimServices.Current.IsBuilt)
		{
			return;
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			XbimServices.Current.ConfigureServices(delegate(IServiceCollection s)
			{
				s.AddXbimToolkit(delegate(IXbimConfigurationBuilder opt)
				{
					opt.AddHeuristicModel();
				});
			});
			return;
		}
		XbimServices.Current.ConfigureServices(delegate(IServiceCollection s)
		{
			s.AddXbimToolkit(delegate(IXbimConfigurationBuilder opt)
			{
				opt.AddMemoryModel();
			});
		});
	}

	protected IfcStore()
	{
		ModelProvider = XbimServices.Current.ServiceProvider.GetRequiredService<IModelProvider>();
		Logger = XbimServices.Current.ServiceProvider.GetRequiredService<ILogger<IfcStore>>();
	}

	protected IfcStore(string filepath, XbimSchemaVersion ifcVersion, XbimEditorCredentials editorDetails)
		: this()
	{
		IModel model = ModelProvider.Create(ifcVersion, filepath);
		AssignModel(model, editorDetails, ifcVersion, filepath);
	}

	protected IfcStore(XbimStoreType storageType, XbimSchemaVersion ifcVersion, XbimEditorCredentials editorDetails)
		: this()
	{
		IModel model = ModelProvider.Create(ifcVersion, storageType);
		AssignModel(model, editorDetails, ifcVersion);
	}

	private void AssignModel(IModel model, XbimEditorCredentials editorDetails, XbimSchemaVersion schema, string modelPath = null)
	{
		Model = model;
		Model.EntityNew += Model_EntityNew;
		Model.EntityDeleted += Model_EntityDeleted;
		Model.EntityModified += Model_EntityModified;
		FileName = modelPath ?? Model.Header.FileName.Name;
		SetupEditing(editorDetails);
		LoadReferenceModels(modelPath);
		MemoryModel.CalculateModelFactors(model);
	}

	private void SetupEditing(XbimEditorCredentials editorDetails)
	{
		if (editorDetails == null)
		{
			EditorDetails = new XbimEditorCredentials
			{
				ApplicationDevelopersName = "Unspecified",
				ApplicationVersion = "Unspecified",
				ApplicationFullName = "Unspecified",
				EditorsFamilyName = Environment.UserName,
				EditorsOrganisationName = "Unspecified",
				EditorsGivenName = ""
			};
		}
		else
		{
			EditorDetails = editorDetails;
		}
		Model.EntityNew += IfcRootInit;
		Model.EntityModified += IfcRootModified;
	}

	public static IfcStore Create(string filePath, XbimEditorCredentials editorDetails, XbimSchemaVersion ifcVersion)
	{
		return new IfcStore(filePath, ifcVersion, editorDetails);
	}

	public static IfcStore Create(XbimEditorCredentials editorDetails, XbimSchemaVersion ifcVersion, XbimStoreType storageType)
	{
		return new IfcStore(storageType, ifcVersion, editorDetails);
	}

	public static IfcStore Create(XbimSchemaVersion ifcVersion, XbimStoreType storageType)
	{
		return new IfcStore(storageType, ifcVersion, null);
	}

	public static IfcStore Open(Stream stream, StorageType dataType, XbimSchemaVersion schema, XbimModelType modelType, XbimEditorCredentials editorDetails = null, XbimDBAccess accessMode = XbimDBAccess.Read, ReportProgressDelegate progDelegate = null, int codePageOverride = -1)
	{
		IfcStore ifcStore = new IfcStore();
		IModel model = ifcStore.ModelProvider.Open(stream, dataType, schema, modelType, accessMode, progDelegate, codePageOverride);
		ifcStore.AssignModel(model, editorDetails, schema);
		return ifcStore;
	}

	public static IfcStore Open(Stream stream, StorageType dataType, XbimModelType modelType, XbimEditorCredentials editorDetails = null, XbimDBAccess accessMode = XbimDBAccess.Read, ReportProgressDelegate progDelegate = null, int codePageOverride = -1, int streamBufferSize = 8192)
	{
		if (stream.CanSeek)
		{
			XbimSchemaVersion schema = InferPayloadFromSchema(stream);
			return OpenModelStream(stream, dataType, modelType, editorDetails, accessMode, progDelegate, codePageOverride, schema);
		}
		using ReadSeekableStream readSeekableStream = new ReadSeekableStream(stream, streamBufferSize);
		XbimSchemaVersion schema2;
		try
		{
			schema2 = InferPayloadFromSchema(readSeekableStream);
		}
		catch (NotSupportedException inner)
		{
			throw new XbimException($"Cannot infer Schema for this model since the header size ({readSeekableStream.Position} bytes) exceeds the size of the buffer size ({streamBufferSize} bytes)", inner);
		}
		return OpenModelStream(readSeekableStream, dataType, modelType, editorDetails, accessMode, progDelegate, codePageOverride, schema2);
	}

	private static XbimSchemaVersion InferPayloadFromSchema(Stream stream)
	{
		XbimSchemaVersion stepFileXbimSchemaVersion = MemoryModel.GetStepFileXbimSchemaVersion(stream);
		stream.Seek(0L, SeekOrigin.Begin);
		if (stream is ReadSeekableStream readSeekableStream)
		{
			readSeekableStream.DisableBuffering();
		}
		return stepFileXbimSchemaVersion;
	}

	private static IfcStore OpenModelStream(Stream stream, StorageType dataType, XbimModelType modelType, XbimEditorCredentials editorDetails, XbimDBAccess accessMode, ReportProgressDelegate progDelegate, int codePageOverride, XbimSchemaVersion schema)
	{
		IfcStore ifcStore = new IfcStore();
		IModel model = ifcStore.ModelProvider.Open(stream, dataType, schema, modelType, accessMode, progDelegate, codePageOverride);
		ifcStore.AssignModel(model, editorDetails, schema);
		return ifcStore;
	}

	public static IfcStore Open(string path, XbimEditorCredentials editorDetails = null, double? ifcDatabaseSizeThreshHold = null, ReportProgressDelegate progDelegate = null, XbimDBAccess accessMode = XbimDBAccess.Read, int codePageOverride = -1)
	{
		path = Path.GetFullPath(path);
		if (!Directory.Exists(Path.GetDirectoryName(path) ?? ""))
		{
			throw new DirectoryNotFoundException(Path.GetDirectoryName(path) + " directory was not found");
		}
		if (!File.Exists(path))
		{
			throw new FileNotFoundException(path + " file was not found");
		}
		IfcStore ifcStore = new IfcStore();
		XbimSchemaVersion xbimSchemaVersion = ifcStore.ModelProvider.GetXbimSchemaVersion(path);
		if (xbimSchemaVersion == XbimSchemaVersion.Unsupported)
		{
			throw new FileLoadException(path + " is not a valid IFC file format, ifc, ifcxml, ifczip and xBIM are supported.");
		}
		IModel model = ifcStore.ModelProvider.Open(path, xbimSchemaVersion, ifcDatabaseSizeThreshHold, progDelegate, accessMode, codePageOverride);
		if (string.IsNullOrEmpty(model.Header.FileName.Name))
		{
			FileInfo fileInfo = new FileInfo(path);
			model.Header.FileName.Name = fileInfo.FullName;
		}
		ifcStore.AssignModel(model, editorDetails, xbimSchemaVersion, path);
		return ifcStore;
	}

	bool IModel.Activate(IPersistEntity owningEntity)
	{
		return Model.Activate(owningEntity);
	}

	public void Delete(IPersistEntity entity)
	{
		Model.Delete(entity);
	}

	public ITransaction BeginTransaction(string name = null)
	{
		if (Model.IsTransactional)
		{
			return Model.BeginTransaction(name);
		}
		throw new XbimException("Native store does not support transactions");
	}

	public T InsertCopy<T>(T toCopy, XbimInstanceHandleMap mappings, PropertyTranformDelegate propTransform, bool includeInverses, bool keepLabels) where T : IPersistEntity
	{
		try
		{
			ManageOwnerHistory = false;
			return Model.InsertCopy(toCopy, mappings, propTransform, includeInverses, keepLabels);
		}
		finally
		{
			ManageOwnerHistory = true;
		}
	}

	public void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body) where TSource : IPersistEntity
	{
		Model.ForEach(source, body);
	}

	public IInverseCache BeginInverseCaching()
	{
		return Model.BeginInverseCaching();
	}

	public IEntityCache BeginEntityCaching()
	{
		return Model.BeginEntityCaching();
	}

	public void Close()
	{
		foreach (IReferencedModel referencedModel in _referencedModels)
		{
			referencedModel.Close();
		}
		ModelProvider.Close(Model);
	}

	private void Model_EntityDeleted(IPersistEntity entity)
	{
		if (this.EntityDeleted != null)
		{
			this.EntityDeleted(entity);
		}
	}

	private void Model_EntityNew(IPersistEntity entity)
	{
		if (this.EntityNew != null)
		{
			this.EntityNew(entity);
		}
	}

	private void Model_EntityModified(IPersistEntity entity, int property)
	{
		if (this.EntityModified != null)
		{
			this.EntityModified(entity, property);
		}
	}

	private void IfcRootModified(IPersistEntity entity, int property)
	{
		if (ManageOwnerHistory && entity is IIfcRoot ifcRoot && ifcRoot.OwnerHistory != _ownerHistoryAddObject && ifcRoot.OwnerHistory != _ownerHistoryModifyObject)
		{
			IIfcOwnerHistory ownerHistory = ifcRoot.OwnerHistory;
			MergeOwnerHistory(ownerHistory);
			ifcRoot.OwnerHistory = OwnerHistoryModifyObject;
			OwnerHistoryModifyObject.LastModifiedDate = DateTime.UtcNow;
		}
	}

	private void MergeOwnerHistory(IIfcOwnerHistory originalHistory)
	{
		OwnerHistoryModifyObject.CreationDate = originalHistory.CreationDate;
		OwnerHistoryModifyObject.OwningApplication = originalHistory.OwningApplication;
		OwnerHistoryModifyObject.OwningUser = originalHistory.OwningUser;
	}

	private void IfcRootInit(IPersistEntity entity)
	{
		if (ManageOwnerHistory && entity is IIfcRoot ifcRoot)
		{
			ifcRoot.OwnerHistory = OwnerHistoryAddObject;
			ifcRoot.GlobalId = Guid.NewGuid().ToPart21();
			OwnerHistoryAddObject.LastModifiedDate = DateTime.UtcNow;
			if (OwnerHistoryAddObject.CreationDate.Value == null)
			{
				OwnerHistoryAddObject.CreationDate = DateTime.UtcNow;
			}
		}
	}

	public void SaveAs(string fileName, StorageType? format = null, ReportProgressDelegate progDelegate = null)
	{
		if (string.IsNullOrWhiteSpace(fileName))
		{
			return;
		}
		string text = Path.GetExtension(fileName).ToLowerInvariant();
		StorageType requiredFormat = StorageType.Invalid;
		if (format.HasValue)
		{
			if (format.Value.HasFlag(StorageType.IfcZip))
			{
				text = ".ifczip";
				requiredFormat = StorageType.IfcZip;
				requiredFormat = ((!format.Value.HasFlag(StorageType.IfcXml)) ? (requiredFormat | StorageType.Ifc) : (requiredFormat | StorageType.IfcXml));
			}
			else if (format.Value.HasFlag(StorageType.Ifc))
			{
				text = ".ifc";
				requiredFormat = StorageType.Ifc;
			}
			else if (format.Value.HasFlag(StorageType.IfcXml))
			{
				text = ".ifcxml";
				requiredFormat = StorageType.IfcXml;
			}
			else if (format.Value.HasFlag(StorageType.Xbim))
			{
				text = ".xbim";
				requiredFormat = StorageType.Xbim;
			}
		}
		else
		{
			switch (text)
			{
			case ".ifczip":
				requiredFormat = StorageType.IfcZip;
				requiredFormat |= StorageType.Ifc;
				break;
			case ".ifcxml":
				requiredFormat = StorageType.IfcXml;
				break;
			case ".xbim":
				requiredFormat = StorageType.Xbim;
				break;
			case ".ifc":
				requiredFormat = StorageType.Ifc;
				break;
			default:
				text += ".ifc";
				requiredFormat = StorageType.Ifc;
				break;
			}
		}
		string destinationFileName = Path.ChangeExtension(fileName, text);
		SaveAs(destinationFileName, requiredFormat, progDelegate);
	}

	private void SaveAs(string destinationFileName, StorageType requiredFormat, ReportProgressDelegate progDelegate)
	{
		FileName = destinationFileName;
		if (requiredFormat.HasFlag(StorageType.Xbim))
		{
			ModelProvider.Persist(Model, destinationFileName, progDelegate);
			return;
		}
		using FileStream stream = new FileStream(destinationFileName, FileMode.Create, FileAccess.Write);
		if (requiredFormat.HasFlag(StorageType.IfcZip))
		{
			this.SaveAsIfcZip(stream, Path.GetFileName(destinationFileName), requiredFormat, progDelegate);
		}
		else if (requiredFormat.HasFlag(StorageType.Ifc))
		{
			this.SaveAsIfc(stream, progDelegate);
		}
		else if (requiredFormat.HasFlag(StorageType.IfcXml))
		{
			this.SaveAsIfcXml(stream, progDelegate);
		}
	}

	public XbimReferencedModel AddModelReference(string refModelPath, string organisationName, string organisationRole)
	{
		using ITransaction transaction = BeginTransaction();
		EntityCreator entityCreator = new EntityCreator(this);
		IIfcActorRole role = entityCreator.ActorRole(delegate(IIfcActorRole r)
		{
			r.Role = IfcRoleEnum.USERDEFINED;
			r.UserDefinedRole = organisationRole;
		});
		IIfcOrganization owner = entityCreator.Organization(delegate(IIfcOrganization org)
		{
			org.Name = organisationName;
			org.Roles.Add(role);
		});
		XbimReferencedModel result = AddModelReference(refModelPath, owner);
		transaction.Commit();
		return result;
	}

	private XbimReferencedModel AddModelReference(string refModelPath, IIfcOrganization owner)
	{
		EntityCreator entityCreator = new EntityCreator(this);
		XbimReferencedModel xbimReferencedModel;
		if (CurrentTransaction == null)
		{
			using ITransaction transaction = BeginTransaction();
			xbimReferencedModel = new XbimReferencedModel(entityCreator.DocumentInformation(delegate(IIfcDocumentInformation d)
			{
				d.Identification = new IfcIdentifier(_referencedModels.NextIdentifer());
				d.Name = refModelPath;
				d.DocumentOwner = owner;
				d.IntendedUse = "XbimReferencedModel";
			}));
			AddModelReference(xbimReferencedModel);
			transaction.Commit();
		}
		else
		{
			xbimReferencedModel = new XbimReferencedModel(entityCreator.DocumentInformation(delegate(IIfcDocumentInformation d)
			{
				d.Identification = new IfcIdentifier(_referencedModels.NextIdentifer());
				d.Name = refModelPath;
				d.DocumentOwner = owner;
				d.IntendedUse = "XbimReferencedModel";
			}));
			AddModelReference(xbimReferencedModel);
		}
		return xbimReferencedModel;
	}

	private void LoadReferenceModels(string rootModelPath, bool throwErrorOnReferenceModelExceptions = false)
	{
		foreach (IIfcDocumentInformation item in from d in Instances.OfType<IIfcDocumentInformation>()
			where d.IntendedUse == (IfcText?)(IfcText)"XbimReferencedModel"
			select d)
		{
			try
			{
				AddModelReference(new XbimReferencedModel(item, rootModelPath));
			}
			catch (Exception ex)
			{
				if (throwErrorOnReferenceModelExceptions)
				{
					throw;
				}
				Logger?.LogError($"Ignored exception on modelreference load for #{item.EntityLabel}.", ex);
			}
		}
	}

	public void AddModelReference(IReferencedModel model)
	{
		_referencedModels.Add(model);
	}

	public void EnsureUniqueUserDefinedId()
	{
		short num = 0;
		foreach (IModel item in new IfcStore[1] { this }.Concat(ReferencedModels.Select((IReferencedModel rm) => rm.Model)))
		{
			item.UserDefinedId = num++;
		}
	}

	public bool Equals(IModel other)
	{
		if ((object)this != other)
		{
			return other == Model;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (!Model.Equals(obj))
		{
			return this == obj;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return Model.GetHashCode();
	}

	public static bool operator ==(IfcStore store, IModel model)
	{
		if ((object)store == model)
		{
			return true;
		}
		if ((object)store == null)
		{
			return false;
		}
		if (model == null)
		{
			return false;
		}
		return store.Model.Equals(model);
	}

	public static bool operator !=(IfcStore store, IModel model)
	{
		return !(store == model);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			try
			{
				if (disposing)
				{
					Close();
					if (Model != null)
					{
						Model.EntityDeleted -= Model_EntityDeleted;
						Model.EntityNew -= Model_EntityNew;
						Model.EntityModified -= Model_EntityModified;
						if (EditorDetails != null)
						{
							Model.EntityNew -= IfcRootInit;
							Model.EntityModified -= IfcRootModified;
						}
					}
					Model?.Dispose();
					Model = null;
				}
			}
			catch
			{
			}
		}
		_disposed = true;
	}
}
