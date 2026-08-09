using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.IO;
using Xbim.IO.Step21;
using Xbim.IO.Xml;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc;

public static class IfcStoreExportExtensions
{
	private const int BufferSize = 1024;

	private static Encoding UTF8Encoding { get; } = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

	public static void SaveAsIfc(this IModel model, Stream stream, ReportProgressDelegate progDelegate = null, bool leaveOpen = false)
	{
		using TextWriter textWriter = new StreamWriter(stream, UTF8Encoding, 1024, leaveOpen);
		Part21Writer.Write(model, textWriter, model.Metadata, null, progDelegate);
		textWriter.Flush();
	}

	public static void SaveAsIfcXml(this IModel model, Stream stream, ReportProgressDelegate progDelegate = null)
	{
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Indent = true
		};
		XbimSchemaVersion schemaVersion = model.SchemaVersion;
		using XmlWriter xmlWriter = XmlWriter.Create(stream, settings);
		switch (schemaVersion)
		{
		case XbimSchemaVersion.Ifc2X3:
			new IfcXmlWriter3().Write(model, xmlWriter, model.Instances);
			break;
		case XbimSchemaVersion.Ifc4:
		case XbimSchemaVersion.Ifc4x1:
		{
			XbimXmlWriter4 xbimXmlWriter = new XbimXmlWriter4(XbimXmlSettings.IFC4Add2);
			IEnumerable<IfcProject> second = model.Instances.OfType<IfcProject>();
			IEnumerable<IfcObject> second2 = model.Instances.OfType<IfcObject>();
			IEnumerable<IfcRelationship> second3 = model.Instances.OfType<IfcRelationship>();
			IEnumerable<IPersistEntity> entities = new IPersistEntity[0].Concat(second).Concat(second2).Concat(second3)
				.Concat(model.Instances);
			xbimXmlWriter.Write(model, xmlWriter, entities);
			break;
		}
		case XbimSchemaVersion.Ifc4x3:
			throw new NotImplementedException();
		}
		xmlWriter.Close();
	}

	public static void SaveAsIfcZip(this IModel model, Stream stream, string zipEntryName, StorageType storageType, ReportProgressDelegate progDelegate = null)
	{
		string entryName = Path.ChangeExtension(zipEntryName, storageType.HasFlag(StorageType.IfcXml) ? "ifcXml" : "ifc");
		using ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Create);
		using Stream stream2 = zipArchive.CreateEntry(entryName).Open();
		if (storageType.HasFlag(StorageType.IfcXml))
		{
			model.SaveAsIfcXml(stream2, progDelegate);
		}
		else
		{
			model.SaveAsIfc(stream2, progDelegate);
		}
	}
}
