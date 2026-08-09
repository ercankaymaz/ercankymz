using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Model;
using Xbim.Common.Step21;
using Xbim.IO.Step21;
using Xbim.IO.Xml;
using Xbim.IO.Xml.BsConf;
using Xbim.Ifc2x3;
using Xbim.Ifc4;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3;

namespace Xbim.IO.Memory;

public class MemoryModel : StepModel
{
	private readonly Dictionary<int, IPersistEntity> _read = new Dictionary<int, IPersistEntity>();

	private static ZipArchiveEntry GetZipEntry(Stream fileStream)
	{
		using ZipArchive zipArchive = new ZipArchive(fileStream);
		return zipArchive.Entries.FirstOrDefault((ZipArchiveEntry z) => z.Name.IsStepTextFile());
	}

	public static XbimSchemaVersion GetSchemaVersion(string fileName)
	{
		if (fileName.IsStepTextFile())
		{
			using (FileStream stream = File.OpenRead(fileName))
			{
				return GetStepFileXbimSchemaVersion(stream);
			}
		}
		if (fileName.IsStepZipFile())
		{
			try
			{
				using ZipArchive zipArchive = new ZipArchive(File.OpenRead(fileName), ZipArchiveMode.Read);
				ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault((ZipArchiveEntry z) => z.Name.IsStepTextFile() || z.Name.IsStepXmlFile());
				if (zipArchiveEntry == null)
				{
					throw new FileLoadException("File does not contain a valid model: " + fileName);
				}
				using Stream stream2 = zipArchiveEntry.Open();
				if (zipArchiveEntry.Name.IsStepTextFile())
				{
					return GetStepFileXbimSchemaVersion(stream2);
				}
				if (!zipArchiveEntry.Name.IsStepXmlFile())
				{
					throw new FileLoadException("File does not contain a valid model: " + fileName);
				}
				XmlSchemaVersion xmlSchemaVersion;
				using (XmlReader input = XmlReader.Create(stream2))
				{
					xmlSchemaVersion = XbimXmlReader4.ReadSchemaVersion(input);
				}
				switch (xmlSchemaVersion)
				{
				case XmlSchemaVersion.Ifc2x3:
					return XbimSchemaVersion.Ifc2X3;
				case XmlSchemaVersion.Ifc4Add1:
				case XmlSchemaVersion.Ifc4Add2:
				case XmlSchemaVersion.Ifc4:
					return XbimSchemaVersion.Ifc4;
				case XmlSchemaVersion.Unknown:
					return XbimSchemaVersion.Unsupported;
				}
			}
			catch (Exception inner)
			{
				throw new FileLoadException("File is an invalid zip format: " + fileName, inner);
			}
		}
		else if (fileName.IsStepXmlFile())
		{
			using (FileStream input2 = File.OpenRead(fileName))
			{
				XmlSchemaVersion xmlSchemaVersion2;
				using (XmlReader input3 = XmlReader.Create(input2))
				{
					xmlSchemaVersion2 = XbimXmlReader4.ReadSchemaVersion(input3);
				}
				switch (xmlSchemaVersion2)
				{
				case XmlSchemaVersion.Ifc2x3:
					return XbimSchemaVersion.Ifc2X3;
				case XmlSchemaVersion.Ifc4Add1:
				case XmlSchemaVersion.Ifc4Add2:
				case XmlSchemaVersion.Ifc4:
					return XbimSchemaVersion.Ifc4;
				default:
					return XbimSchemaVersion.Unsupported;
				}
			}
		}
		throw new FileLoadException("File is an invalid model format: " + fileName);
	}

	public static XbimSchemaVersion GetStepFileXbimSchemaVersion(IEnumerable<string> schemas)
	{
		foreach (string schema in schemas)
		{
			if (schema.StartsWith("Ifc4x3", StringComparison.OrdinalIgnoreCase))
			{
				return XbimSchemaVersion.Ifc4x3;
			}
			if (string.Compare(schema, "Ifc4", StringComparison.OrdinalIgnoreCase) == 0 || schema.StartsWith("Ifc4RC", StringComparison.OrdinalIgnoreCase))
			{
				return XbimSchemaVersion.Ifc4;
			}
			if (string.Equals(schema, "Ifc4x1", StringComparison.OrdinalIgnoreCase))
			{
				return XbimSchemaVersion.Ifc4x1;
			}
			if (schema.StartsWith("Ifc2x", StringComparison.OrdinalIgnoreCase))
			{
				return XbimSchemaVersion.Ifc2X3;
			}
			if (schema.StartsWith("Ifc4x3", StringComparison.OrdinalIgnoreCase))
			{
				return XbimSchemaVersion.Ifc4x3;
			}
			if (schema.StartsWith("Cobie2X4", StringComparison.OrdinalIgnoreCase))
			{
				return XbimSchemaVersion.Cobie2X4;
			}
		}
		return XbimSchemaVersion.Unsupported;
	}

	public static XbimSchemaVersion GetStepFileXbimSchemaVersion(Stream stream)
	{
		return GetStepFileXbimSchemaVersion(StepModel.GetStepFileSchemaVersion(stream));
	}

	public MemoryModel(IEntityFactory entityFactory, IStepFileHeader header, ILoggerFactory loggerFactory = null)
		: base(entityFactory, loggerFactory, 0)
	{
		base.Header = header;
	}

	public MemoryModel(IEntityFactory entityFactory, ILoggerFactory loggerFactory = null, int labelFrom = 0)
		: base(entityFactory, loggerFactory, labelFrom)
	{
	}

	[Obsolete("Prefer ILoggerFactory implementation")]
	public MemoryModel(IEntityFactory entityFactory, ILogger logger, int labelFrom)
		: base(entityFactory, logger, labelFrom)
	{
	}

	private MemoryModel(EntityFactoryResolverDelegate resolver, ILoggerFactory loggerFactory, int labelFrom = 0)
		: base(resolver, loggerFactory, labelFrom)
	{
	}

	public virtual void LoadXml(string path, ReportProgressDelegate progDelegate = null)
	{
		using FileStream fileStream = File.OpenRead(path);
		LoadXml(fileStream, fileStream.Length, progDelegate);
	}

	public virtual void LoadXml(Stream stream, long streamSize, ReportProgressDelegate progDelegate = null)
	{
		_read.Clear();
		string text = base.EntityFactory.SchemasIds.First();
		if (string.Equals(text, "IFC2X3", StringComparison.OrdinalIgnoreCase))
		{
			XbimXmlReader3 xbimXmlReader = new XbimXmlReader3(GetOrCreateXMLEntity, delegate
			{
			}, base.Metadata);
			if (progDelegate != null)
			{
				xbimXmlReader.ProgressStatus += progDelegate;
			}
			base.Header = xbimXmlReader.Read(stream, this, streamSize);
			if (progDelegate != null)
			{
				xbimXmlReader.ProgressStatus -= progDelegate;
			}
		}
		else
		{
			XbimXmlReader4 xbimXmlReader2 = new XbimXmlReader4(GetOrCreateXMLEntity, delegate
			{
			}, base.Metadata, _loggerFactory);
			if (progDelegate != null)
			{
				xbimXmlReader2.ProgressStatus += progDelegate;
			}
			base.Header = xbimXmlReader2.Read(stream, this);
			if (progDelegate != null)
			{
				xbimXmlReader2.ProgressStatus -= progDelegate;
			}
		}
		if (base.Header.FileSchema.Schemas == null)
		{
			base.Header.FileSchema.Schemas = new List<string>();
		}
		if (!base.Header.FileSchema.Schemas.Any())
		{
			base.Header.FileSchema.Schemas.Add(text);
		}
		CalculateModelFactors(this);
		_read.Clear();
	}

	protected override int LoadStep21(XbimP21Scanner parser)
	{
		int result = base.LoadStep21(parser);
		CalculateModelFactors(this);
		return result;
	}

	private IPersistEntity GetOrCreateXMLEntity(int label, Type type)
	{
		if (_read.TryGetValue(label, out var value))
		{
			return value;
		}
		IInstantiableEntity instantiableEntity = base.EntityFactory.New(this, type, label, activated: true);
		AddEntityInternal(instantiableEntity);
		_read.Add(label, instantiableEntity);
		return instantiableEntity;
	}

	public virtual void LoadZip(string file, ReportProgressDelegate progDelegate = null)
	{
		using FileStream stream = File.OpenRead(file);
		LoadZip(stream, progDelegate);
	}

	public virtual void LoadZip(Stream stream, ReportProgressDelegate progDelegate = null)
	{
		using ZipArchive zipArchive = new ZipArchive(stream);
		ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault((ZipArchiveEntry z) => z.Name.IsStepTextFile() || z.Name.IsStepXmlFile());
		if (zipArchiveEntry.Name.IsStepTextFile())
		{
			using (Stream stream2 = zipArchiveEntry.Open())
			{
				LoadStep21(stream2, zipArchiveEntry.Length, progDelegate);
				return;
			}
		}
		if (zipArchiveEntry.Name.IsStepXmlFile())
		{
			using (Stream stream3 = zipArchiveEntry.Open())
			{
				LoadXml(stream3, zipArchiveEntry.Length, progDelegate);
				return;
			}
		}
	}

	public static MemoryModel OpenRead(string fileName)
	{
		return OpenRead(fileName, (ReportProgressDelegate)null);
	}

	[Obsolete("Prefer ILogger injection")]
	public static MemoryModel OpenRead(string fileName, ILogger logger, ReportProgressDelegate progressDel = null)
	{
		return OpenRead(fileName, progressDel);
	}

	public static MemoryModel OpenRead(string fileName, ReportProgressDelegate progressDel = null)
	{
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		if (fileName.IsStepTextFile())
		{
			using (FileStream stream = File.OpenRead(fileName))
			{
				return OpenReadStep21(stream, progressDel);
			}
		}
		MemoryModel memoryModel = new MemoryModel(GetFactory(GetSchemaVersion(fileName)), loggerFactory);
		if (fileName.IsStepZipFile())
		{
			memoryModel.LoadZip(fileName, progressDel);
		}
		else
		{
			if (!fileName.IsStepXmlFile())
			{
				throw new FileLoadException("Unsupported file type extension: " + Path.GetExtension(fileName));
			}
			memoryModel.LoadXml(fileName, progressDel);
		}
		return memoryModel;
	}

	public static IEntityFactory GetFactory(XbimSchemaVersion schema)
	{
		return schema switch
		{
			XbimSchemaVersion.Ifc4 => new EntityFactoryIfc4(), 
			XbimSchemaVersion.Ifc4x1 => new EntityFactoryIfc4x1(), 
			XbimSchemaVersion.Ifc4x3 => new EntityFactoryIfc4x3Add2(), 
			XbimSchemaVersion.Ifc2X3 => new EntityFactoryIfc2x3(), 
			_ => throw new NotSupportedException($"Schema '{schema}' is not supported"), 
		};
	}

	[Obsolete("Passing of ILogger is redundant. Use XbimServices")]
	public static MemoryModel OpenReadStep21(string file, ILogger logger, ReportProgressDelegate progressDel = null)
	{
		using FileStream stream = File.OpenRead(file);
		return OpenReadStep21(stream, progressDel);
	}

	public static MemoryModel OpenReadStep21(string file, ReportProgressDelegate progressDel = null)
	{
		using FileStream stream = File.OpenRead(file);
		return OpenReadStep21(stream, progressDel);
	}

	[Obsolete("Prefer ILogger injection")]
	public static MemoryModel OpenReadStep21(Stream stream, ILogger logger, ReportProgressDelegate progressDel = null, IEnumerable<string> ignoreTypes = null, bool allowMissingReferences = false, bool keepOrder = true)
	{
		return OpenReadStep21(stream, progressDel, ignoreTypes, allowMissingReferences, keepOrder);
	}

	public static MemoryModel OpenReadStep21(Stream stream, ReportProgressDelegate progressDel = null, IEnumerable<string> ignoreTypes = null, bool allowMissingReferences = false, bool keepOrder = true)
	{
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		MemoryModel memoryModel = new MemoryModel(delegate(IEnumerable<string> schemas)
		{
			XbimSchemaVersion stepFileXbimSchemaVersion = GetStepFileXbimSchemaVersion(schemas);
			if (stepFileXbimSchemaVersion == XbimSchemaVersion.Unsupported)
			{
				throw new XbimParserException("IFC Schema could not be read from Header");
			}
			return GetFactory(stepFileXbimSchemaVersion);
		}, loggerFactory)
		{
			AllowMissingReferences = allowMissingReferences
		};
		if (!keepOrder)
		{
			memoryModel.DiscardNaturalOrder();
		}
		long streamSize = -1L;
		if (stream.CanSeek)
		{
			streamSize = stream.Length;
		}
		memoryModel.LoadStep21(stream, streamSize, progressDel, ignoreTypes);
		return memoryModel;
	}

	public virtual void SaveAsXml(Stream stream, XmlWriterSettings xmlSettings, XbimXmlSettings xbimSettings = null, configuration configuration = null, ReportProgressDelegate progress = null)
	{
		string text = base.Header.FileSchema.Schemas.FirstOrDefault();
		using XmlWriter output = XmlWriter.Create(stream, xmlSettings);
		switch (base.SchemaVersion)
		{
		case XbimSchemaVersion.Ifc2X3:
			new IfcXmlWriter3().Write(this, output, GetXmlOrderedEntities(text));
			return;
		case XbimSchemaVersion.Ifc4:
			new XbimXmlWriter4(XbimXmlSettings.IFC4Add2).Write(this, output, GetXmlOrderedEntities(text));
			return;
		}
		if (xbimSettings == null)
		{
			base.Logger.LogWarning("No xbimsettings set. Defaulting to Ifc4 Add2");
			xbimSettings = XbimXmlSettings.IFC4Add2;
		}
		new XbimXmlWriter4(xbimSettings).Write(this, output);
	}

	public static void CalculateModelFactors(IModel model)
	{
		bool flag = false;
		double num = 1.0;
		double lengthToMetresConversionFactor = 1.0;
		IIfcUnitAssignment ifcUnitAssignment = model.Instances.OfType<IIfcUnitAssignment>().FirstOrDefault();
		if (ifcUnitAssignment != null)
		{
			foreach (IIfcUnit unit in ifcUnitAssignment.Units)
			{
				double num2 = 1.0;
				IIfcSIUnit ifcSIUnit = unit as IIfcSIUnit;
				if (unit is IIfcConversionBasedUnit ifcConversionBasedUnit)
				{
					IIfcMeasureWithUnit conversionFactor = ifcConversionBasedUnit.ConversionFactor;
					if (conversionFactor.UnitComponent is IIfcSIUnit ifcSIUnit2)
					{
						ifcSIUnit = ifcSIUnit2;
					}
					IExpressValueType valueComponent = conversionFactor.ValueComponent;
					if (valueComponent != null)
					{
						if (valueComponent.UnderlyingSystemType == typeof(double))
						{
							num2 *= (double)valueComponent.Value;
						}
						else if (valueComponent.UnderlyingSystemType == typeof(int))
						{
							num2 *= (double)(int)valueComponent.Value;
						}
						else if (valueComponent.UnderlyingSystemType == typeof(long))
						{
							num2 *= (double)(long)valueComponent.Value;
						}
					}
				}
				if (ifcSIUnit == null)
				{
					continue;
				}
				num2 *= ifcSIUnit.Power;
				switch (ifcSIUnit.UnitType)
				{
				case IfcUnitEnum.LENGTHUNIT:
					lengthToMetresConversionFactor = num2;
					break;
				case IfcUnitEnum.PLANEANGLEUNIT:
					flag = true;
					num = num2;
					if (Math.Abs(num - Math.PI / 180.0) < 1E-09)
					{
						num = Math.PI / 180.0;
					}
					break;
				}
			}
		}
		IEnumerable<IIfcGeometricRepresentationContext> source = model.Instances.OfType<IIfcGeometricRepresentationContext>();
		double num3 = 1E-05;
		using (IEnumerator<IIfcGeometricRepresentationContext> enumerator2 = (from gc in source
			where !(gc is IIfcGeometricRepresentationSubContext)
			where gc.ContextType.HasValue && string.Compare(gc.ContextType.Value, "model", ignoreCase: true) == 0
			where gc.Precision.HasValue
			select gc).GetEnumerator())
		{
			if (enumerator2.MoveNext())
			{
				IIfcGeometricRepresentationContext current2 = enumerator2.Current;
				if (current2.Precision.HasValue)
				{
					num3 = current2.Precision.Value;
				}
			}
		}
		if (num3 < 1E-07 && num3 < 1E-07)
		{
			num3 = 1E-05;
		}
		if (!flag && Math.Abs(num - 1.0) < 1E-10 && (from trimmedCurve in model.Instances
			where trimmedCurve.BasisCurve is IIfcConic
			where trimmedCurve.MasterRepresentation == IfcTrimmingPreference.PARAMETER
			select trimmedCurve).Any((IIfcTrimmedCurve trimmedCurve) => (from trim in trimmedCurve.Trim1.Concat(trimmedCurve.Trim2).OfType<IfcParameterValue>()
			select (double)trim.Value).Any((double val) => val > Math.PI * 2.0)))
		{
			num = Math.PI / 180.0;
		}
		model.ModelFactors.Initialise(num, lengthToMetresConversionFactor, num3);
		if (model.ModelFactors is XbimModelFactors modelFactors)
		{
			SetWorkArounds(model.Header, modelFactors);
		}
	}

	private IEnumerable<IPersistEntity> GetXmlOrderedEntities(string schema)
	{
		schema = schema.ToUpperInvariant();
		if (schema == null || !schema.StartsWith("IFC2X"))
		{
			return Instances;
		}
		IEnumerable<IPersistEntity> second = Instances.OfType("IfcProject", activate: true);
		IEnumerable<IPersistEntity> second2 = Instances.OfType("IfcObject", activate: true);
		IEnumerable<IPersistEntity> second3 = Instances.OfType("IfcRelationship", activate: true);
		return new IPersistEntity[0].Concat(second).Concat(second2).Concat(second3)
			.Concat(Instances);
	}

	public virtual void SaveAsXMLZip(Stream stream, XmlWriterSettings xmlSettings, XbimXmlSettings xbimSettings = null, configuration configuration = null, ReportProgressDelegate progress = null)
	{
		using ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Update);
		string text = base.EntityFactory.SchemasIds.FirstOrDefault();
		string text2 = ((text != null && text.StartsWith("IFC")) ? ".ifcxml" : ".xml");
		using Stream stream2 = zipArchive.CreateEntry("data" + text2).Open();
		SaveAsXml(stream2, xmlSettings, xbimSettings, configuration, progress);
	}

	public virtual void SaveAsStep21Zip(Stream stream, ReportProgressDelegate progress = null)
	{
		using ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Update);
		string text = base.EntityFactory.SchemasIds.FirstOrDefault();
		string text2 = ((text != null && text.StartsWith("IFC")) ? ".ifc" : ".stp");
		using Stream stream2 = zipArchive.CreateEntry("data" + text2).Open();
		SaveAsStep21(stream2, progress);
	}

	public static void SetWorkArounds(IStepFileHeader header, XbimModelFactors modelFactors)
	{
		string pattern = "- Exporter\\s(\\d*.\\d*.\\d*.\\d*)";
		if (header.FileName == null || string.IsNullOrWhiteSpace(header.FileName.OriginatingSystem))
		{
			return;
		}
		MatchCollection matchCollection = Regex.Matches(header.FileName.OriginatingSystem, pattern, RegexOptions.IgnoreCase);
		if (matchCollection.Count > 0 && matchCollection[0].Groups.Count == 2 && Version.TryParse(matchCollection[0].Groups[1].Value, out Version result))
		{
			Version version = new Version(21, 1, 0, 0);
			if (result <= version)
			{
				modelFactors.AddWorkAround("#SurfaceOfLinearExtrusion");
			}
		}
	}
}
