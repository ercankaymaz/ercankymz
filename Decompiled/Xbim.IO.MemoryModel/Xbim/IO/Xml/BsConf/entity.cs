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
public class entity
{
	private List<object> itemsField;

	private string selectField;

	private List<string> syntheticField;

	private bool inheritanceField;

	private string nameField;

	private string tagsourceField;

	private string tagvaluesField;

	private string mapField;

	private exptype exptypeField;

	private bool exptypeFieldSpecified;

	private content contentField;

	private bool contentFieldSpecified;

	private expattribute expattributeField;

	private string taglessField;

	private bool keepField;

	private bool newField;

	private string implementationField;

	private string facetField;

	private static XmlSerializer serializer;

	public IEnumerable<inverse> ChangedInverses
	{
		get
		{
			if (Items != null)
			{
				return from i in Items.OfType<inverse>()
					where i.expattribute == expattribute.doubletag || i.expattribute == expattribute.attributetag
					select i;
			}
			return Enumerable.Empty<inverse>();
		}
	}

	public IEnumerable<attribute> IgnoredAttributes
	{
		get
		{
			if (Items != null)
			{
				return from i in Items.OfType<attribute>()
					where !i.keep
					select i;
			}
			return Enumerable.Empty<attribute>();
		}
	}

	public IEnumerable<attribute> Attributes
	{
		get
		{
			if (Items != null)
			{
				return Items.OfType<attribute>();
			}
			return Enumerable.Empty<attribute>();
		}
	}

	public IEnumerable<attribute> TaggLessAttributes
	{
		get
		{
			if (Items != null)
			{
				return from a in Items.OfType<attribute>()
					where a.tagless == "true"
					select a;
			}
			return Enumerable.Empty<attribute>();
		}
	}

	public string EntityName => select?.FirstOrDefault();

	[XmlElement("attribute", typeof(attribute))]
	[XmlElement("inverse", typeof(inverse))]
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

	[XmlAttribute(DataType = "Name")]
	public List<string> synthetic
	{
		get
		{
			return syntheticField;
		}
		set
		{
			syntheticField = value;
		}
	}

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

	[XmlAttribute("tag-source", DataType = "NMTOKEN")]
	public string tagsource
	{
		get
		{
			return tagsourceField;
		}
		set
		{
			tagsourceField = value;
		}
	}

	[XmlAttribute("tag-values", DataType = "NMTOKENS")]
	public string tagvalues
	{
		get
		{
			return tagvaluesField;
		}
		set
		{
			tagvaluesField = value;
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

	[XmlAttribute("exp-attribute")]
	[DefaultValue(expattribute.unspecified)]
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

	[XmlAttribute]
	public string facet
	{
		get
		{
			return facetField;
		}
		set
		{
			facetField = value;
		}
	}

	private static XmlSerializer Serializer
	{
		get
		{
			if (serializer == null)
			{
				serializer = new XmlSerializer(typeof(entity));
			}
			return serializer;
		}
	}

	public attribute GetOrCreateAttribute(string attributeName)
	{
		if (Items == null)
		{
			Items = new List<object>();
		}
		attribute attribute2 = Items.OfType<attribute>().FirstOrDefault((attribute a) => a.select == attributeName);
		if (attribute2 != null)
		{
			return attribute2;
		}
		attribute2 = new attribute
		{
			select = attributeName
		};
		Items.Add(attribute2);
		return attribute2;
	}

	public inverse GetOrCreateInverse(string attributeName)
	{
		if (Items == null)
		{
			Items = new List<object>();
		}
		inverse inverse2 = Items.OfType<inverse>().FirstOrDefault((inverse a) => a.select == attributeName);
		if (inverse2 != null)
		{
			return inverse2;
		}
		inverse2 = new inverse
		{
			select = attributeName
		};
		Items.Add(inverse2);
		return inverse2;
	}

	public entity()
	{
		inheritanceField = false;
		expattributeField = expattribute.unspecified;
		keepField = true;
		newField = false;
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

	public static bool Deserialize(string xml, out entity obj, out Exception exception)
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

	public static bool Deserialize(string xml, out entity obj)
	{
		Exception exception = null;
		return Deserialize(xml, out obj, out exception);
	}

	public static entity Deserialize(string xml)
	{
		StringReader stringReader = null;
		try
		{
			stringReader = new StringReader(xml);
			return (entity)Serializer.Deserialize(XmlReader.Create(stringReader));
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

	public static bool LoadFromFile(string fileName, out entity obj, out Exception exception)
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

	public static bool LoadFromFile(string fileName, out entity obj)
	{
		Exception exception = null;
		return LoadFromFile(fileName, out obj, out exception);
	}

	public static entity LoadFromFile(string fileName)
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
