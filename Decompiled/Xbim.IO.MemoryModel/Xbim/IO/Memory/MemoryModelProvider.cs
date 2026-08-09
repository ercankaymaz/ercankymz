using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Step21;

namespace Xbim.IO.Memory;

public class MemoryModelProvider : BaseModelProvider
{
	private readonly ILoggerFactory _loggerFactory;

	public override StoreCapabilities Capabilities => new StoreCapabilities(isTransient: true, supportsTransactions: true);

	public MemoryModelProvider()
		: this(null)
	{
	}

	public MemoryModelProvider(ILoggerFactory loggerFactory)
	{
		_loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
	}

	public override void Close(IModel model)
	{
	}

	public override IModel Create(XbimSchemaVersion ifcVersion, string dbPath)
	{
		throw new NotImplementedException("The MemoryModelProvider does not support creation of XBIM models");
	}

	public override IModel Create(XbimSchemaVersion ifcVersion, XbimStoreType storageType)
	{
		return new MemoryModel(GetFactory(ifcVersion), _loggerFactory);
	}

	public override string GetLocation(IModel model)
	{
		return string.Empty;
	}

	public override XbimSchemaVersion GetXbimSchemaVersion(string modelPath)
	{
		return modelPath.StorageType() switch
		{
			StorageType.Invalid => XbimSchemaVersion.Unsupported, 
			StorageType.Xbim => throw new NotImplementedException("The MemoryModelProvider does not support reading of XBIM models"), 
			_ => MemoryModel.GetSchemaVersion(modelPath), 
		};
	}

	public override IModel Open(Stream stream, StorageType dataType, XbimSchemaVersion schema, XbimModelType modelType, XbimDBAccess accessMode = XbimDBAccess.Read, ReportProgressDelegate progDelegate = null, int codePageOverride = -1)
	{
		if (modelType != XbimModelType.MemoryModel)
		{
			throw new ArgumentOutOfRangeException("modelType", "MemoryModelProvider only supports MemoryModel");
		}
		switch (dataType)
		{
		case StorageType.Xbim:
			throw new NotSupportedException("MemoryModelProvider cannot support opening XBIM Streams");
		case StorageType.IfcXml:
		{
			MemoryModel memoryModel3 = CreateMemoryModel(schema);
			memoryModel3.LoadXml(stream, stream.Length, progDelegate);
			return memoryModel3;
		}
		case StorageType.Ifc:
		case StorageType.Stp:
		{
			MemoryModel memoryModel2 = CreateMemoryModel(schema);
			memoryModel2.LoadStep21(stream, stream.Length, progDelegate);
			return memoryModel2;
		}
		case StorageType.IfcZip:
		case StorageType.StpZip:
		case StorageType.Zip:
		{
			MemoryModel memoryModel = CreateMemoryModel(schema);
			memoryModel.LoadZip(stream, progDelegate);
			return memoryModel;
		}
		default:
			throw new ArgumentOutOfRangeException("dataType");
		}
	}

	public override IModel Open(string path, XbimSchemaVersion schemaVersion, double? ifcDatabaseSizeThreshHold = null, ReportProgressDelegate progDelegate = null, XbimDBAccess accessMode = XbimDBAccess.Read, int codePageOverride = -1)
	{
		StorageType storageType = path.StorageType();
		if (storageType == StorageType.Xbim)
		{
			throw new NotSupportedException("The MemoryModelProvider does not support loading of XBIM files.");
		}
		MemoryModel memoryModel = CreateMemoryModel(schemaVersion);
		if (storageType.HasFlag(StorageType.IfcZip) || storageType.HasFlag(StorageType.Zip) || storageType.HasFlag(StorageType.StpZip))
		{
			memoryModel.LoadZip(path, progDelegate);
		}
		else if (storageType.HasFlag(StorageType.Ifc) || storageType.HasFlag(StorageType.Stp))
		{
			memoryModel.LoadStep21(path, progDelegate);
		}
		else if (storageType.HasFlag(StorageType.IfcXml))
		{
			memoryModel.LoadXml(path, progDelegate);
		}
		FileInfo fileInfo = new FileInfo(path);
		memoryModel.Header.FileName.Name = fileInfo.FullName;
		return memoryModel;
	}

	public override void Persist(IModel model, string fileName, ReportProgressDelegate progDelegate = null)
	{
		throw new NotImplementedException("MemoryModelProvider is a transient store and does not support persistance");
	}

	private MemoryModel CreateMemoryModel(XbimSchemaVersion schema)
	{
		return new MemoryModel(GetFactory(schema), _loggerFactory);
	}
}
