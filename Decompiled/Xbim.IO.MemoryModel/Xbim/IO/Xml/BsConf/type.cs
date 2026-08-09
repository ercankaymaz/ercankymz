using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Xbim.IO.Xml.BsConf;

[Serializable]
[GeneratedCode("System.Xml", "4.0.30319.34234")]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language")]
[XmlRoot(Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language", IsNullable = false)]
public class type
{
	private aggregate itemField;

	private string selectField;

	private string nameField;

	private string mapField;

	private exptype exptypeField;

	private bool exptypeFieldSpecified;

	private string taglessField;

	private string notationField;

	private bool keepField;

	private bool flattenField;

	private bool flattenFieldSpecified;

	private static XmlSerializer serializer;

	[XmlElement("aggregate")]
	public aggregate Item
	{
		get
		{
			return itemField;
		}
		set
		{
			itemField = value;
		}
	}

	[XmlAttribute(DataType = "normalizedString", AttributeName = "select")]
	public string _select
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

	[XmlIgnore]
	public List<string> select
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(_select))
			{
				return _select.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			}
			return new List<string>(0);
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

	[XmlAttribute("exp-type")]
	public exptype exptype
	{
		get
		{
			return exptypeField;
		}
		set
		{
			exptypeField = value;
		}
	}

	[XmlIgnore]
	public bool exptypeSpecified
	{
		get
		{
			return exptypeFieldSpecified;
		}
		set
		{
			exptypeFieldSpecified = value;
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

	private static XmlSerializer Serializer
	{
		get
		{
			if (serializer == null)
			{
				serializer = new XmlSerializer(typeof(type));
			}
			return serializer;
		}
	}

	public type()
	{
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

	public static bool Deserialize(string xml, out type obj, out Exception exception)
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

	public static bool Deserialize(string xml, out type obj)
	{
		Exception exception = null;
		return Deserialize(xml, out obj, out exception);
	}

	public static type Deserialize(string xml)
	{
		StringReader stringReader = null;
		try
		{
			stringReader = new StringReader(xml);
			return (type)Serializer.Deserialize(XmlReader.Create(stringReader));
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

	public static bool LoadFromFile(string fileName, out type obj, out Exception exception)
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

	public static bool LoadFromFile(string fileName, out type obj)
	{
		Exception exception = null;
		return LoadFromFile(fileName, out obj, out exception);
	}

	public static type LoadFromFile(string fileName)
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
