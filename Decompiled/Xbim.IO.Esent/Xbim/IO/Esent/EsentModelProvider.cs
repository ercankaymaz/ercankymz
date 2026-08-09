using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Step21;
using Xbim.IO.Memory;

namespace Xbim.IO.Esent;

public class EsentModelProvider : BaseModelProvider
{
	private readonly ILoggerFactory _loggerFactory;

	private readonly ILogger _logger;

	public override StoreCapabilities Capabilities => new StoreCapabilities(isTransient: false, supportsTransactions: true);

	public string DatabaseFileName { get; set; }

	public EsentModelProvider()
		: this(null)
	{
	}

	public EsentModelProvider(ILoggerFactory loggerFactory)
	{
		_loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		_logger = _loggerFactory.CreateLogger<EsentModelProvider>();
		if (!IsEsentSupported())
		{
			_logger.LogWarning("EsentModel is only compatible with Windows operating systems. Please use another ModelProvider.");
		}
	}

	public override void Close(IModel model)
	{
		if (model is EsentModel esentModel)
		{
			esentModel.Close();
		}
	}

	public override IModel Create(XbimSchemaVersion ifcVersion, string dbPath)
	{
		return EsentModel.CreateModel(GetFactory(ifcVersion), dbPath);
	}

	public override IModel Create(XbimSchemaVersion ifcVersion, XbimStoreType storageType)
	{
		IEntityFactory factory = GetFactory(ifcVersion);
		if (storageType == XbimStoreType.EsentDatabase)
		{
			return EsentModel.CreateTemporaryModel(factory);
		}
		throw new NotSupportedException($"{storageType} is not a supported Storage Type");
	}

	public override string GetLocation(IModel model)
	{
		if (model == null)
		{
			return null;
		}
		if (model is EsentModel esentModel)
		{
			return esentModel.DatabaseName;
		}
		throw new NotSupportedException(model.GetType().Name + " is not a supported Model Type");
	}

	public override XbimSchemaVersion GetXbimSchemaVersion(string modelPath)
	{
		switch (modelPath.StorageType())
		{
		case StorageType.Invalid:
			return XbimSchemaVersion.Unsupported;
		default:
			return MemoryModel.GetSchemaVersion(modelPath);
		case StorageType.Xbim:
		{
			IList<string> schemas = EsentModel.GetStepFileHeader(modelPath).FileSchema.Schemas;
			string.Join(", ", schemas);
			foreach (string item in schemas)
			{
				if (item.StartsWith("Ifc4x3", StringComparison.OrdinalIgnoreCase))
				{
					return XbimSchemaVersion.Ifc4x3;
				}
				if (string.Compare(item, "Ifc4", StringComparison.OrdinalIgnoreCase) == 0 || item.StartsWith("Ifc4RC", StringComparison.OrdinalIgnoreCase))
				{
					return XbimSchemaVersion.Ifc4;
				}
				if (string.Compare(item, "Ifc4x1", StringComparison.OrdinalIgnoreCase) == 0)
				{
					return XbimSchemaVersion.Ifc4x1;
				}
				if (string.Compare(item, "Ifc2x3", StringComparison.OrdinalIgnoreCase) == 0)
				{
					return XbimSchemaVersion.Ifc2X3;
				}
				if (item.StartsWith("Ifc2x", StringComparison.OrdinalIgnoreCase))
				{
					return XbimSchemaVersion.Ifc2X3;
				}
			}
			return XbimSchemaVersion.Unsupported;
		}
		}
	}

	public override IModel Open(Stream stream, StorageType dataType, XbimSchemaVersion schema, XbimModelType modelType, XbimDBAccess accessMode = XbimDBAccess.Read, ReportProgressDelegate progDelegate = null, int codePageOverride = -1)
	{
		string path = DatabaseFileName ?? Path.GetTempFileName();
		path = Path.ChangeExtension(path, ".xbim");
		switch (dataType)
		{
		case StorageType.Xbim:
		{
			bool flag = false;
			if (stream is FileStream fileStream)
			{
				string name = fileStream.Name;
				if (File.Exists(name))
				{
					path = name;
					stream.Close();
					flag = true;
				}
			}
			if (!flag)
			{
				using FileStream fileStream2 = File.Create(path);
				stream.CopyTo(fileStream2);
				fileStream2.Close();
			}
			EsentModel esentModel3 = CreateEsentModel(schema, codePageOverride);
			esentModel3.Open(path, accessMode, progDelegate);
			return esentModel3;
		}
		case StorageType.IfcXml:
			if (modelType == XbimModelType.EsentModel)
			{
				EsentModel esentModel4 = CreateEsentModel(schema, codePageOverride);
				if (esentModel4.CreateFrom(stream, stream.Length, dataType, path, progDelegate, keepOpen: true, cacheEntities: true))
				{
					return esentModel4;
				}
				throw new XbimException("Failed to create Esent model");
			}
			throw new ArgumentOutOfRangeException("EsentModelProvider only supports EsentModel");
		case StorageType.Ifc:
		case StorageType.Stp:
			if (modelType == XbimModelType.EsentModel)
			{
				EsentModel esentModel2 = CreateEsentModel(schema, codePageOverride);
				if (esentModel2.CreateFrom(stream, stream.Length, dataType, path, progDelegate, keepOpen: true, cacheEntities: true))
				{
					return esentModel2;
				}
				throw new XbimException("Failed to create Esent model");
			}
			throw new ArgumentOutOfRangeException("EsentModelProvider only supports EsentModel");
		case StorageType.IfcZip:
		case StorageType.StpZip:
		case StorageType.Zip:
			if (modelType == XbimModelType.EsentModel)
			{
				EsentModel esentModel = CreateEsentModel(schema, codePageOverride);
				if (esentModel.CreateFrom(stream, stream.Length, dataType, path, progDelegate, keepOpen: true, cacheEntities: true))
				{
					return esentModel;
				}
				throw new XbimException("Failed to create Esent model");
			}
			throw new ArgumentOutOfRangeException("EsentModelProvider only supports EsentModel");
		default:
			throw new ArgumentOutOfRangeException("dataType");
		}
	}

	public override IModel Open(string path, XbimSchemaVersion schemaVersion, double? ifcDatabaseSizeThreshHold = null, ReportProgressDelegate progDelegate = null, XbimDBAccess accessMode = XbimDBAccess.Read, int codePageOverride = -1)
	{
		if (path.StorageType() == StorageType.Xbim)
		{
			EsentModel esentModel = CreateEsentModel(schemaVersion, codePageOverride);
			esentModel.Open(path, accessMode, progDelegate);
			return esentModel;
		}
		new FileInfo(path);
		string xbimDbName = DatabaseFileName ?? Path.GetTempFileName();
		EsentModel esentModel2 = CreateEsentModel(schemaVersion, codePageOverride);
		bool deleteOnClose = DatabaseFileName == null;
		if (esentModel2.CreateFrom(path, xbimDbName, progDelegate, keepOpen: true, cacheEntities: false, null, deleteOnClose))
		{
			return esentModel2;
		}
		throw new FileLoadException(path + " file was not a valid IFC format");
	}

	public override void Persist(IModel model, string fileName, ReportProgressDelegate progDelegate = null)
	{
		if (model is EsentModel esentModel)
		{
			string fullPath = Path.GetFullPath(esentModel.DatabaseName);
			string fullPath2 = Path.GetFullPath(fileName);
			if (string.Compare(fullPath, fullPath2, StringComparison.OrdinalIgnoreCase) != 0)
			{
				esentModel.SaveAs(fileName);
			}
			return;
		}
		using EsentModel esentModel2 = new EsentModel(GetFactory(model.SchemaVersion), _loggerFactory);
		esentModel2.CreateFrom(model, fileName, progDelegate);
		esentModel2.Close();
	}

	private EsentModel CreateEsentModel(XbimSchemaVersion schema, int codePageOverride)
	{
		return new EsentModel(GetFactory(schema), _loggerFactory)
		{
			CodePageOverride = codePageOverride
		};
	}

	private static bool IsEsentSupported()
	{
		return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
	}
}
