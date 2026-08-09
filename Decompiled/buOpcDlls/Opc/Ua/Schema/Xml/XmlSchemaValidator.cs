using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace Opc.Ua.Schema.Xml;

[ComVisible(true)]
public class XmlSchemaValidator : SchemaValidator
{
	protected static readonly string[][] WellKnownDictionaries = new string[1][] { new string[2] { "http://opcfoundation.org/UA/2008/02/Types.xsd", "Opc.Ua.Schema.Opc.Ua.Types.xsd" } };

	private XmlSchema m_schema;

	private XmlSchemaSet m_schemaSet;

	public XmlSchemaSet SchemaSet => m_schemaSet;

	public XmlSchema TargetSchema => m_schema;

	public XmlSchemaValidator()
	{
		SetResourcePaths(WellKnownDictionaries);
	}

	public XmlSchemaValidator(IDictionary<string, string> fileTable)
		: base(fileTable)
	{
		SetResourcePaths(WellKnownDictionaries);
	}

	public XmlSchemaValidator(IDictionary<string, byte[]> importTable)
		: base(importTable)
	{
		SetResourcePaths(WellKnownDictionaries);
	}

	public void Validate(string inputPath)
	{
		using Stream stream = File.OpenRead(inputPath);
		Validate(stream);
	}

	public void Validate(Stream stream)
	{
		using XmlReader reader = XmlReader.Create(stream, Utils.DefaultXmlReaderSettings());
		m_schema = XmlSchema.Read(reader, OnValidate);
		Assembly assembly = typeof(XmlSchemaValidator).GetTypeInfo().Assembly;
		foreach (XmlSchemaImport include in m_schema.Includes)
		{
			string value = null;
			if (!base.KnownFiles.TryGetValue(include.Namespace, out value))
			{
				value = include.SchemaLocation;
			}
			FileInfo fileInfo = new FileInfo(value);
			XmlReaderSettings settings = Utils.DefaultXmlReaderSettings();
			if (!fileInfo.Exists)
			{
				using (StreamReader input = new StreamReader(assembly.GetManifestResourceStream(value)))
				{
					using XmlReader reader2 = XmlReader.Create(input, settings);
					include.Schema = XmlSchema.Read(reader2, OnValidate);
				}
				continue;
			}
			using Stream input2 = File.OpenRead(value);
			using XmlReader reader3 = XmlReader.Create(input2, settings);
			include.Schema = XmlSchema.Read(reader3, OnValidate);
		}
		m_schemaSet = new XmlSchemaSet();
		m_schemaSet.Add(m_schema);
		m_schemaSet.Compile();
	}

	public override string GetSchema(string typeName)
	{
		XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
		MemoryStream memoryStream = new MemoryStream();
		XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings);
		try
		{
			if (typeName == null || m_schema.Elements.Values.Count == 0)
			{
				m_schema.Write(xmlWriter);
			}
			else
			{
				foreach (XmlSchemaObject value in m_schema.Elements.Values)
				{
					if (value is XmlSchemaElement xmlSchemaElement && xmlSchemaElement.Name == typeName)
					{
						XmlSchema xmlSchema = new XmlSchema();
						xmlSchema.Items.Add(xmlSchemaElement.ElementSchemaType);
						xmlSchema.Items.Add(xmlSchemaElement);
						xmlSchema.Write(xmlWriter);
						break;
					}
				}
			}
		}
		finally
		{
			xmlWriter.Flush();
			xmlWriter.Dispose();
		}
		return Encoding.UTF8.GetString(memoryStream.ToArray());
	}

	private static void OnValidate(object sender, ValidationEventArgs args)
	{
		Utils.LogError("Error in XML schema validation: {0}", args.Message);
		throw new InvalidOperationException(args.Message, args.Exception);
	}
}
