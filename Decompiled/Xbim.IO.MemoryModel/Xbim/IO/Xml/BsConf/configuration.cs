using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Xbim.Common.Metadata;

namespace Xbim.IO.Xml.BsConf;

[Serializable]
[GeneratedCode("System.Xml", "4.0.30319.34234")]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language")]
[XmlRoot(Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language", IsNullable = true)]
public class configuration
{
	private List<object> itemsField;

	private string idField;

	private string targetNamespaceField;

	private string schemaField;

	private List<string> configurationlocationField;

	private static XmlSerializer serializer;

	public static configuration IFC4Add2 => Deserialize(GetData("IFC4_ADD2_config"));

	public static configuration IFC4Add1 => Deserialize(GetData("IFC4_ADD1_config"));

	public static configuration IFC4 => Deserialize(GetData("IFC4_config"));

	public option Option => Items?.OfType<option>().FirstOrDefault();

	public schema Schema => Items?.OfType<schema>().FirstOrDefault();

	public uosElement RootElement => Items?.OfType<uosElement>().FirstOrDefault();

	public IEnumerable<entity> Entities => Items?.OfType<entity>();

	public IEnumerable<type> Types => Items?.OfType<type>();

	public @namespace Namespace => Schema?.Items.OfType<@namespace>().FirstOrDefault();

	public IEnumerable<entity> ChangedInverses
	{
		get
		{
			if (Items != null)
			{
				return from e in Items.OfType<entity>()
					where e.ChangedInverses.Any()
					select e;
			}
			return Enumerable.Empty<entity>();
		}
	}

	public IEnumerable<entity> IgnoredAttributes
	{
		get
		{
			if (Items != null)
			{
				return from e in Items.OfType<entity>()
					where e.IgnoredAttributes.Any()
					select e;
			}
			return Enumerable.Empty<entity>();
		}
	}

	[XmlElement("include", typeof(configurationInclude), Form = XmlSchemaForm.Unqualified)]
	[XmlElement("entity", typeof(entity))]
	[XmlElement("option", typeof(option))]
	[XmlElement("rootEntity", typeof(rootEntity))]
	[XmlElement("schema", typeof(schema))]
	[XmlElement("type", typeof(type))]
	[XmlElement("uosElement", typeof(uosElement))]
	[XmlElement("uosEntity", typeof(uosEntity))]
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

	[XmlAttribute(DataType = "ID")]
	public string id
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
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

	[XmlAttribute(DataType = "IDREF")]
	public string schema
	{
		get
		{
			return schemaField;
		}
		set
		{
			schemaField = value;
		}
	}

	[XmlAttribute("configuration-location", DataType = "anyURI")]
	public List<string> configurationlocation
	{
		get
		{
			return configurationlocationField;
		}
		set
		{
			configurationlocationField = value;
		}
	}

	private static XmlSerializer Serializer
	{
		get
		{
			if (serializer == null)
			{
				serializer = new XmlSerializer(typeof(configuration));
			}
			return serializer;
		}
	}

	private static string GetData(string name)
	{
		Assembly assembly = typeof(configuration).Assembly;
		string name2 = "Xbim.IO.MemoryModel.Xml.BsConf." + name + ".xml";
		using Stream stream = assembly.GetManifestResourceStream(name2);
		using StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}

	private entity GetEntity(string name)
	{
		return Items?.OfType<entity>().FirstOrDefault((entity e) => string.Compare(e.EntityName, name, StringComparison.OrdinalIgnoreCase) == 0);
	}

	public IEnumerable<entity> GetEntities(ExpressType type)
	{
		List<ExpressType> list = new List<ExpressType> { type };
		while (type.SuperType != null)
		{
			list.Add(type.SuperType);
			type = type.SuperType;
		}
		return from expressType in list
			select GetEntity(expressType.ExpressName) into entity2
			where entity2 != null
			select entity2;
	}

	public entity GetOrCreatEntity(string name)
	{
		if (Items == null)
		{
			Items = new List<object>();
		}
		entity entity2 = Items.OfType<entity>().FirstOrDefault((entity e) => e.select != null && e.select.FirstOrDefault() == name);
		if (entity2 != null)
		{
			return entity2;
		}
		entity2 = new entity
		{
			_select = name
		};
		Items.Add(entity2);
		return entity2;
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

	public static bool Deserialize(string xml, out configuration obj, out Exception exception)
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

	public static bool Deserialize(string xml, out configuration obj)
	{
		Exception exception = null;
		return Deserialize(xml, out obj, out exception);
	}

	public static configuration Deserialize(string xml)
	{
		StringReader stringReader = null;
		try
		{
			stringReader = new StringReader(xml);
			return (configuration)Serializer.Deserialize(XmlReader.Create(stringReader));
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

	public static bool LoadFromFile(string fileName, out configuration obj, out Exception exception)
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

	public static bool LoadFromFile(string fileName, out configuration obj)
	{
		Exception exception = null;
		return LoadFromFile(fileName, out obj, out exception);
	}

	public static configuration LoadFromFile(string fileName)
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
