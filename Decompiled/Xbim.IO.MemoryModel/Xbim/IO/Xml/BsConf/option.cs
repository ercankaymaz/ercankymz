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
public class option
{
	private bool inheritanceField;

	private exptype exptypeField;

	private expattributeglobal entityattributeField;

	private expattributeglobal concreteattributeField;

	private string taglessField;

	private namingconvention namingconventionField;

	private attributeType keepallField;

	private bool keepallFieldSpecified;

	private bool generatekeysField;

	private static XmlSerializer serializer;

	[XmlAttribute]
	[DefaultValue(false)]
	public bool inheritance
	{
		get
		{
			return inheritanceField;
		}
		set
		{
			inheritanceField = value;
		}
	}

	[XmlAttribute("exp-type")]
	[DefaultValue(exptype.unspecified)]
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

	[XmlAttribute("entity-attribute")]
	[DefaultValue(expattributeglobal.doubletag)]
	public expattributeglobal entityattribute
	{
		get
		{
			return entityattributeField;
		}
		set
		{
			entityattributeField = value;
		}
	}

	[XmlAttribute("concrete-attribute")]
	[DefaultValue(expattributeglobal.attributetag)]
	public expattributeglobal concreteattribute
	{
		get
		{
			return concreteattributeField;
		}
		set
		{
			concreteattributeField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue("unspecified")]
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

	[XmlAttribute("naming-convention")]
	[DefaultValue(namingconvention.initialupper)]
	public namingconvention namingconvention
	{
		get
		{
			return namingconventionField;
		}
		set
		{
			namingconventionField = value;
		}
	}

	[XmlAttribute("keep-all")]
	public attributeType keepall
	{
		get
		{
			return keepallField;
		}
		set
		{
			keepallField = value;
		}
	}

	[XmlIgnore]
	public bool keepallSpecified
	{
		get
		{
			return keepallFieldSpecified;
		}
		set
		{
			keepallFieldSpecified = value;
		}
	}

	[XmlAttribute("generate-keys")]
	[DefaultValue(true)]
	public bool generatekeys
	{
		get
		{
			return generatekeysField;
		}
		set
		{
			generatekeysField = value;
		}
	}

	private static XmlSerializer Serializer
	{
		get
		{
			if (serializer == null)
			{
				serializer = new XmlSerializer(typeof(option));
			}
			return serializer;
		}
	}

	public option()
	{
		inheritanceField = false;
		exptypeField = exptype.unspecified;
		entityattributeField = expattributeglobal.doubletag;
		concreteattributeField = expattributeglobal.attributetag;
		taglessField = "unspecified";
		namingconventionField = namingconvention.initialupper;
		generatekeysField = true;
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

	public static bool Deserialize(string xml, out option obj, out Exception exception)
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

	public static bool Deserialize(string xml, out option obj)
	{
		Exception exception = null;
		return Deserialize(xml, out obj, out exception);
	}

	public static option Deserialize(string xml)
	{
		StringReader stringReader = null;
		try
		{
			stringReader = new StringReader(xml);
			return (option)Serializer.Deserialize(XmlReader.Create(stringReader));
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

	public static bool LoadFromFile(string fileName, out option obj, out Exception exception)
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

	public static bool LoadFromFile(string fileName, out option obj)
	{
		Exception exception = null;
		return LoadFromFile(fileName, out obj, out exception);
	}

	public static option LoadFromFile(string fileName)
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
