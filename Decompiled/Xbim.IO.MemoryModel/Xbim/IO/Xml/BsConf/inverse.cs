using System;
using System.CodeDom.Compiler;
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
public class inverse
{
	private string selectField;

	private string nameField;

	private expattribute expattributeField;

	private bool expattributeFieldSpecified;

	private content contentField;

	private bool contentFieldSpecified;

	private string taglessField;

	private string invertField;

	private string mapField;

	private bool keepField;

	private string minOccursField;

	private string maxOccursField;

	private string refField;

	private static XmlSerializer serializer;

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

	[XmlAttribute(DataType = "NMTOKEN")]
	public string invert
	{
		get
		{
			return invertField;
		}
		set
		{
			invertField = value;
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

	[XmlAttribute]
	[DefaultValue(false)]
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

	[XmlAttribute(DataType = "nonNegativeInteger")]
	[DefaultValue("0")]
	public string minOccurs
	{
		get
		{
			return minOccursField;
		}
		set
		{
			minOccursField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue("unbounded")]
	public string maxOccurs
	{
		get
		{
			return maxOccursField;
		}
		set
		{
			maxOccursField = value;
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

	private static XmlSerializer Serializer
	{
		get
		{
			if (serializer == null)
			{
				serializer = new XmlSerializer(typeof(inverse));
			}
			return serializer;
		}
	}

	public inverse()
	{
		keepField = false;
		minOccursField = "0";
		maxOccursField = "unbounded";
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

	public static bool Deserialize(string xml, out inverse obj, out Exception exception)
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

	public static bool Deserialize(string xml, out inverse obj)
	{
		Exception exception = null;
		return Deserialize(xml, out obj, out exception);
	}

	public static inverse Deserialize(string xml)
	{
		StringReader stringReader = null;
		try
		{
			stringReader = new StringReader(xml);
			return (inverse)Serializer.Deserialize(XmlReader.Create(stringReader));
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

	public static bool LoadFromFile(string fileName, out inverse obj, out Exception exception)
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

	public static bool LoadFromFile(string fileName, out inverse obj)
	{
		Exception exception = null;
		return LoadFromFile(fileName, out obj, out exception);
	}

	public static inverse LoadFromFile(string fileName)
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
