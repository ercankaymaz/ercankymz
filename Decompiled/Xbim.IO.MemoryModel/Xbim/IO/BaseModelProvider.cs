using System;
using System.IO;
using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.Ifc2x3;
using Xbim.Ifc4;
using Xbim.Ifc4x3;

namespace Xbim.IO;

public abstract class BaseModelProvider : IModelProvider
{
	public abstract StoreCapabilities Capabilities { get; }

	public Func<XbimSchemaVersion, IEntityFactory> EntityFactoryResolver { get; set; }

	public abstract void Close(IModel model);

	public abstract IModel Create(XbimSchemaVersion ifcVersion, string path);

	public abstract IModel Create(XbimSchemaVersion ifcVersion, XbimStoreType storageType);

	public abstract string GetLocation(IModel model);

	public abstract XbimSchemaVersion GetXbimSchemaVersion(string modelPath);

	public abstract IModel Open(Stream data, StorageType dataType, XbimSchemaVersion schema, XbimModelType modelType, XbimDBAccess accessMode = XbimDBAccess.Read, ReportProgressDelegate progDelegate = null, int codePageOverride = -1);

	public abstract IModel Open(string path, XbimSchemaVersion schema, double? ifcDatabaseSizeThreshHold = null, ReportProgressDelegate progDelegate = null, XbimDBAccess accessMode = XbimDBAccess.Read, int codePageOverride = -1);

	public abstract void Persist(IModel model, string fileName, ReportProgressDelegate progDelegate = null);

	protected IEntityFactory GetFactory(XbimSchemaVersion type)
	{
		if (EntityFactoryResolver != null)
		{
			IEntityFactory entityFactory = EntityFactoryResolver(type);
			if (entityFactory != null)
			{
				return entityFactory;
			}
		}
		return type switch
		{
			XbimSchemaVersion.Ifc4 => new EntityFactoryIfc4(), 
			XbimSchemaVersion.Ifc4x1 => new EntityFactoryIfc4x1(), 
			XbimSchemaVersion.Ifc4x3 => new EntityFactoryIfc4x3Add2(), 
			XbimSchemaVersion.Ifc2X3 => new EntityFactoryIfc2x3(), 
			_ => throw new NotSupportedException("Schema '" + type.ToString() + "' is not supported"), 
		};
	}
}
