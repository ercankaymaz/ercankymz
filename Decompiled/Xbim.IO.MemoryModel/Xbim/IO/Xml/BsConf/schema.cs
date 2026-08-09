using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Xbim.IO.Xml.BsConf;

[Serializable]
[GeneratedCode("System.Xml", "4.0.30319.34234")]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language")]
[XmlRoot(Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language", IsNullable = false)]
public class schema
{
	private List<object> itemsField;

	private string targetNamespaceField;

	private qual elementFormDefaultField;

	private bool elementFormDefaultFieldSpecified;

	private qual attributeFormDefaultField;

	private bool attributeFormDefaultFieldSpecified;

	private string defaultRootObjectTypeField;

	private string defaultObjectTypeField;

	private string schemaversionField;

	private bool embedschemaitemsField;

	private static XmlSerializer serializer;

	[XmlElement("additionalObject", typeof(additionalObject))]
	[XmlElement("containerObject", typeof(containerObject))]
	[XmlElement("include", typeof(include))]
	[XmlElement("namespace", typeof(@namespace))]
	public List<object> Items
	{
		get
		{
			return itemsField;
		}
		set
		{
			itemsField = value;
		}
	}

	[XmlAttribute(DataType = "anyURI")]
	public string targetNamespace
	{
		get
		{
			return targetNamespaceField;
		}
		set
		{
			targetNamespaceField = value;
		}
	}

	[XmlAttribute]
	public qual elementFormDefault
	{
		get
		{
			return elementFormDefaultField;
		}
		set
		{
			elementFormDefaultField = value;
		}
	}

	[XmlIgnore]
	public bool elementFormDefaultSpecified
	{
		get
		{
			return elementFormDefaultFieldSpecified;
		}
		set
		{
			elementFormDefaultFieldSpecified = value;
		}
	}

	[XmlAttribute]
	public qual attributeFormDefault
	{
		get
		{
			return attributeFormDefaultField;
		}
		set
		{
			attributeFormDefaultField = value;
		}
	}

	[XmlIgnore]
	public bool attributeFormDefaultSpecified
	{
		get
		{
			return attributeFormDefaultFieldSpecified;
		}
		set
		{
			attributeFormDefaultFieldSpecified = value;
		}
	}

	[XmlAttribute]
	public string defaultRootObjectType
	{
		get
		{
			return defaultRootObjectTypeField;
		}
		set
		{
			defaultRootObjectTypeField = value;
		}
	}

	[XmlAttribute]
	public string defaultObjectType
	{
		get
		{
			return defaultObjectTypeField;
		}
		set
		{
			defaultObjectTypeField = value;
		}
	}

	[XmlAttribute("schema-version")]
	public string schemaversion
	{
		get
		{
			return schemaversionField;
		}
		set
		{
			schemaversionField = value;
		}
	}

	[XmlAttribute("embed-schema-items")]
	[DefaultValue(false)]
	public bool embedschemaitems
	{
		get
		{
			return embedschemaitemsField;
		}
		set
		{
			embedschemaitemsField = value;
		}
	}

	private static XmlSerializer Serializer
	{
		get
		{
			if (serializer == null)
			{
				serializer = new XmlSerializer(typeof(schema));
			}
			return serializer;
		}
	}

	public schema()
	{
		embedschemaitemsField = false;
	}

	public virtual string Serialize()
	{
		StreamReader streamReader = null;
		MemoryStream memoryStream = null;
		try
		{
			memoryStream = new MemoryStream();
			Serializer.Serialize(memoryStream, this);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			streamReader = new StreamReader(memoryStream);
			return streamReader.ReadToEnd();
		}
		finally
		{
			streamReader?.Dispose();
			memoryStream?.Dispose();
		}
	}

	public static bool Deserialize(string xml, out schema obj, out Exception exception)
	{
		exception = null;
		obj = null;
		try
		{
			obj = Deserialize(xml);
			return true;
		}
		catch (Exception ex)
		{
			exception = ex;
			return false;
		}
	}

	public static bool Deserialize(string xml, out schema obj)
	{
		Exception exception = null;
		return Deserialize(xml, out obj, out exception);
	}

	public static schema Deserialize(string xml)
	{
		StringReader stringReader = null;
		try
		{
			stringReader = new StringReader(xml);
			return (schema)Serializer.Deserialize(XmlReader.Create(stringReader));
		}
		finally
		{
			stringReader?.Dispose();
		}
	}

	public virtual bool SaveToFile(string fileName, out Exception exception)
	{
		exception = null;
		try
		{
			SaveToFile(fileName);
			return true;
		}
		catch (Exception ex)
		{
			exception = ex;
			return false;
		}
	}

	public virtual void SaveToFile(string fileName)
	{
		StreamWriter streamWriter = null;
		try
		{
			string value = Serialize();
			streamWriter = new FileInfo(fileName).CreateText();
			streamWriter.WriteLine(value);
		}
		finally
		{
			streamWriter?.Dispose();
		}
	}

	public static bool LoadFromFile(string fileName, out schema obj, out Exception exception)
	{
		exception = null;
		obj = null;
		try
		{
			obj = LoadFromFile(fileName);
			return true;
		}
		catch (Exception ex)
		{
			exception = ex;
			return false;
		}
	}

	public static bool LoadFromFile(string fileName, out schema obj)
	{
		Exception exception = null;
		return LoadFromFile(fileName, out obj, out exception);
	}

	public static schema LoadFromFile(string fileName)
	{
		FileStream fileStream = null;
		StreamReader streamReader = null;
		try
		{
			fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			streamReader = new StreamReader(fileStream);
			return Deserialize(streamReader.ReadToEnd());
		}
		finally
		{
			fileStream?.Dispose();
			streamReader?.Dispose();
		}
	}
}
