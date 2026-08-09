using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Step21;
using Xbim.IO;
using Xbim.IO.Esent;
using Xbim.IO.Memory;

namespace Xbim.Ifc;

public class HeuristicModelProvider : BaseModelProvider
{
	private readonly ILoggerFactory _loggerFactory;

	private readonly ILogger _logger;

	public static double DefaultIfcDatabaseSizeThreshHoldMb = 100.0;

	public override StoreCapabilities Capabilities => new StoreCapabilities(isTransient: false, supportsTransactions: true);

	public HeuristicModelProvider()
		: this(null)
	{
	}

	public HeuristicModelProvider(ILoggerFactory loggerFactory)
	{
		_loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		_logger = _loggerFactory.CreateLogger<HeuristicModelProvider>();
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
		return new MemoryModel(factory, _loggerFactory);
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
		return string.Empty;
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
		if (modelType == XbimModelType.EsentModel && !IsEsentSupported())
		{
			modelType = XbimModelType.MemoryModel;
			_logger.LogWarning("EsentModel not support on this platform. Falling back to memory model where possible");
		}
		string tempFileName = Path.GetTempFileName();
		tempFileName = Path.ChangeExtension(tempFileName, ".xbim");
		switch (dataType)
		{
		case StorageType.Xbim:
		{
			if (modelType == XbimModelType.MemoryModel)
			{
				throw new NotSupportedException("Cannot open xbim file with a Memory Model");
			}
			bool flag = false;
			if (stream is FileStream fileStream)
			{
				string name = fileStream.Name;
				if (File.Exists(name))
				{
					tempFileName = name;
					stream.Close();
					flag = true;
				}
			}
			if (!flag)
			{
				using FileStream fileStream2 = File.Create(tempFileName);
				stream.CopyTo(fileStream2);
				fileStream2.Close();
			}
			EsentModel esentModel4 = CreateEsentModel(schema, codePageOverride);
			esentModel4.Open(tempFileName, accessMode, progDelegate);
			return esentModel4;
		}
		case StorageType.IfcXml:
			switch (modelType)
			{
			case XbimModelType.EsentModel:
			{
				EsentModel esentModel3 = CreateEsentModel(schema, codePageOverride);
				if (esentModel3.CreateFrom(stream, stream.Length, dataType, tempFileName, progDelegate, keepOpen: true, cacheEntities: true))
				{
					return esentModel3;
				}
				throw new XbimException("Failed to create Esent model");
			}
			case XbimModelType.MemoryModel:
			{
				MemoryModel memoryModel3 = CreateMemoryModel(schema);
				memoryModel3.LoadXml(stream, stream.Length, progDelegate);
				return memoryModel3;
			}
			default:
				throw new ArgumentOutOfRangeException("HeuristicModelProvider only supports EsentModel and MemoryModel");
			}
		case StorageType.Ifc:
		case StorageType.Stp:
			switch (modelType)
			{
			case XbimModelType.EsentModel:
			{
				EsentModel esentModel2 = CreateEsentModel(schema, codePageOverride);
				if (esentModel2.CreateFrom(stream, stream.Length, dataType, tempFileName, progDelegate, keepOpen: true, cacheEntities: true))
				{
					return esentModel2;
				}
				throw new XbimException("Failed to create Esent model");
			}
			case XbimModelType.MemoryModel:
			{
				MemoryModel memoryModel2 = CreateMemoryModel(schema);
				memoryModel2.LoadStep21(stream, stream.Length, progDelegate);
				return memoryModel2;
			}
			default:
				throw new ArgumentOutOfRangeException("HeuristicModelProvider only supports EsentModel and MemoryModel");
			}
		case StorageType.IfcZip:
		case StorageType.StpZip:
		case StorageType.Zip:
			switch (modelType)
			{
			case XbimModelType.EsentModel:
			{
				EsentModel esentModel = CreateEsentModel(schema, codePageOverride);
				if (esentModel.CreateFrom(stream, stream.Length, dataType, tempFileName, progDelegate, keepOpen: true, cacheEntities: true))
				{
					return esentModel;
				}
				throw new XbimException("Failed to create Esent model");
			}
			case XbimModelType.MemoryModel:
			{
				MemoryModel memoryModel = CreateMemoryModel(schema);
				memoryModel.LoadZip(stream, progDelegate);
				return memoryModel;
			}
			default:
				throw new ArgumentOutOfRangeException("HeuristicModelProvider only supports EsentModel and MemoryModel");
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
			if (!IsEsentSupported())
			{
				throw new NotSupportedException("Cannot open xbim file on this platform");
			}
			EsentModel esentModel = CreateEsentModel(schemaVersion, codePageOverride);
			esentModel.Open(path, accessMode, progDelegate);
			return esentModel;
		}
		FileInfo file = new FileInfo(path);
		double maxLength = (ifcDatabaseSizeThreshHold ?? DefaultIfcDatabaseSizeThreshHoldMb) * 1024.0 * 1024.0;
		if (ExceedsThreshold(file, maxLength) && IsEsentSupported())
		{
			string tempFileName = Path.GetTempFileName();
			EsentModel esentModel2 = CreateEsentModel(schemaVersion, codePageOverride);
			if (esentModel2.CreateFrom(path, tempFileName, progDelegate, keepOpen: true, cacheEntities: false, null, deleteOnClose: true))
			{
				return esentModel2;
			}
			throw new FileLoadException(path + " file was not a valid IFC format");
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
		return memoryModel;
	}

	private static bool ExceedsThreshold(FileInfo file, double maxLength)
	{
		if (maxLength >= 0.0)
		{
			return (double)file.Length > maxLength;
		}
		return false;
	}

	private static bool IsEsentSupported()
	{
		return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
	}

	public override void Persist(IModel model, string fileName, ReportProgressDelegate progDelegate = null)
	{
		if (model is EsentModel esentModel)
		{
			string fullPath = Path.GetFullPath(esentModel.DatabaseName);
			string fullPath2 = Path.GetFullPath(fileName);
			if (string.Compare(fullPath, fullPath2, StringComparison.OrdinalIgnoreCase) != 0)
			{
				CoverageProbes.HeuristicModelProvider_EfficientEsentSaveasHit = true;
				esentModel.SaveAs(fileName, StorageType.Xbim, progDelegate);
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

	private MemoryModel CreateMemoryModel(XbimSchemaVersion schema)
	{
		return new MemoryModel(GetFactory(schema), _loggerFactory);
	}
}
