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
public class uosElement
{
	private addAttribute itemField;

	private string nameField;

	private static XmlSerializer serializer;

	[XmlElement("addAttribute")]
	public addAttribute Item
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

	private static XmlSerializer Serializer
	{
		get
		{
			if (serializer == null)
			{
				serializer = new XmlSerializer(typeof(uosElement));
			}
			return serializer;
		}
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

	public static bool Deserialize(string xml, out uosElement obj, out Exception exception)
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

	public static bool Deserialize(string xml, out uosElement obj)
	{
		Exception exception = null;
		return Deserialize(xml, out obj, out exception);
	}

	public static uosElement Deserialize(string xml)
	{
		StringReader stringReader = null;
		try
		{
			stringReader = new StringReader(xml);
			return (uosElement)Serializer.Deserialize(XmlReader.Create(stringReader));
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

	public static bool LoadFromFile(string fileName, out uosElement obj, out Exception exception)
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

	public static bool LoadFromFile(string fileName, out uosElement obj)
	{
		Exception exception = null;
		return LoadFromFile(fileName, out obj, out exception);
	}

	public static uosElement LoadFromFile(string fileName)
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
