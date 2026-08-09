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
public class attribute
{
	private List<aggregate> itemsField;

	private string selectField;

	private bool newField;

	private string nameField;

	private expattribute expattributeField;

	private bool expattributeFieldSpecified;

	private content contentField;

	private bool contentFieldSpecified;

	private content aggregatecontentField;

	private bool aggregatecontentFieldSpecified;

	private string mapField;

	private bool useidField;

	private bool useidFieldSpecified;

	private bool keepField;

	private string taglessField;

	private string notationField;

	private bool flattenField;

	private bool flattenFieldSpecified;

	private string refField;

	private string useField;

	private string implementationField;

	private static XmlSerializer serializer;

	[XmlElement("aggregate")]
	public List<aggregate> Items
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

	[XmlAttribute(DataType = "NMTOKEN")]
	public string select
	{
		get
		{
			return selectField;
		}
		set
		{
			selectField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(false)]
	public bool @new
	{
		get
		{
			return newField;
		}
		set
		{
			newField = value;
		}
	}

	[XmlAttribute(DataType = "NMTOKEN")]
	public string name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
		}
	}

	[XmlAttribute("exp-attribute")]
	public expattribute expattribute
	{
		get
		{
			return expattributeField;
		}
		set
		{
			expattributeField = value;
		}
	}

	[XmlIgnore]
	public bool expattributeSpecified
	{
		get
		{
			return expattributeFieldSpecified;
		}
		set
		{
			expattributeFieldSpecified = value;
		}
	}

	[XmlAttribute]
	public content content
	{
		get
		{
			return contentField;
		}
		set
		{
			contentField = value;
		}
	}

	[XmlIgnore]
	public bool contentSpecified
	{
		get
		{
			return contentFieldSpecified;
		}
		set
		{
			contentFieldSpecified = value;
		}
	}

	[XmlAttribute("aggregate-content")]
	public content aggregatecontent
	{
		get
		{
			return aggregatecontentField;
		}
		set
		{
			aggregatecontentField = value;
		}
	}

	[XmlIgnore]
	public bool aggregatecontentSpecified
	{
		get
		{
			return aggregatecontentFieldSpecified;
		}
		set
		{
			aggregatecontentFieldSpecified = value;
		}
	}

	[XmlAttribute(DataType = "NMTOKEN")]
	public string map
	{
		get
		{
			return mapField;
		}
		set
		{
			mapField = value;
		}
	}

	[XmlAttribute("use-id")]
	public bool useid
	{
		get
		{
			return useidField;
		}
		set
		{
			useidField = value;
		}
	}

	[XmlIgnore]
	public bool useidSpecified
	{
		get
		{
			return useidFieldSpecified;
		}
		set
		{
			useidFieldSpecified = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(true)]
	public bool keep
	{
		get
		{
			return keepField;
		}
		set
		{
			keepField = value;
		}
	}

	[XmlAttribute]
	public string tagless
	{
		get
		{
			return taglessField;
		}
		set
		{
			taglessField = value;
		}
	}

	[XmlAttribute(DataType = "normalizedString")]
	public string notation
	{
		get
		{
			return notationField;
		}
		set
		{
			notationField = value;
		}
	}

	[XmlAttribute]
	public bool flatten
	{
		get
		{
			return flattenField;
		}
		set
		{
			flattenField = value;
		}
	}

	[XmlIgnore]
	public bool flattenSpecified
	{
		get
		{
			return flattenFieldSpecified;
		}
		set
		{
			flattenFieldSpecified = value;
		}
	}

	[XmlAttribute(DataType = "NMTOKEN")]
	public string @ref
	{
		get
		{
			return refField;
		}
		set
		{
			refField = value;
		}
	}

	[XmlAttribute(DataType = "NMTOKEN")]
	public string use
	{
		get
		{
			return useField;
		}
		set
		{
			useField = value;
		}
	}

	[XmlAttribute]
	public string implementation
	{
		get
		{
			return implementationField;
		}
		set
		{
			implementationField = value;
		}
	}

	private static XmlSerializer Serializer
	{
		get
		{
			if (serializer == null)
			{
				serializer = new XmlSerializer(typeof(attribute));
			}
			return serializer;
		}
	}

	public attribute()
	{
		newField = false;
		keepField = true;
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

	public static bool Deserialize(string xml, out attribute obj, out Exception exception)
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

	public static bool Deserialize(string xml, out attribute obj)
	{
		Exception exception = null;
		return Deserialize(xml, out obj, out exception);
	}

	public static attribute Deserialize(string xml)
	{
		StringReader stringReader = null;
		try
		{
			stringReader = new StringReader(xml);
			return (attribute)Serializer.Deserialize(XmlReader.Create(stringReader));
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

	public static bool LoadFromFile(string fileName, out attribute obj, out Exception exception)
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

	public static bool LoadFromFile(string fileName, out attribute obj)
	{
		Exception exception = null;
		return LoadFromFile(fileName, out obj, out exception);
	}

	public static attribute LoadFromFile(string fileName)
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
