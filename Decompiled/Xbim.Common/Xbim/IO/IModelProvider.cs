using System;
using System.IO;
using Xbim.Common;
using Xbim.Common.Step21;

namespace Xbim.IO;

public interface IModelProvider
{
	StoreCapabilities Capabilities { get; }

	Func<XbimSchemaVersion, IEntityFactory> EntityFactoryResolver { get; set; }

	void Close(IModel model);

	IModel Create(XbimSchemaVersion ifcVersion, string dbPath);

	IModel Create(XbimSchemaVersion ifcVersion, XbimStoreType storageType);

	XbimSchemaVersion GetXbimSchemaVersion(string modelPath);

	IModel Open(Stream stream, StorageType dataType, XbimSchemaVersion schemaVersion, XbimModelType modelType, XbimDBAccess accessMode = XbimDBAccess.Read, ReportProgressDelegate progDelegate = null, int codePageOverride = -1);

	IModel Open(string path, XbimSchemaVersion schemaVersion, double? ifcDatabaseSizeThreshHold = null, ReportProgressDelegate progDelegate = null, XbimDBAccess accessMode = XbimDBAccess.Read, int codePageOverride = -1);

	void Persist(IModel model, string fileName, ReportProgressDelegate progDelegate = null);

	string GetLocation(IModel model);
}
