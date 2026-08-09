using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Xml;

namespace DevAge.Configuration;

public class PersistableSettings
{
	private PersistableItemDictionary persistableItemDictionary_0 = new PersistableItemDictionary();

	protected PersistableItemDictionary Dictionary => persistableItemDictionary_0;

	protected virtual object this[string name]
	{
		get
		{
			return persistableItemDictionary_0[name].Value;
		}
		set
		{
			persistableItemDictionary_0[name].Value = value;
		}
	}

	[Browsable(false)]
	public virtual bool HasChanges
	{
		get
		{
			foreach (PersistableItem value in persistableItemDictionary_0.Values)
			{
				if (value.IsChanged)
				{
					return true;
				}
			}
			return false;
		}
	}

	protected void AddPersistableItem(PersistableItem item)
	{
		persistableItemDictionary_0.Add(item.Name, item);
	}

	public virtual void AcceptChangesAsDefault()
	{
		foreach (PersistableItem value in persistableItemDictionary_0.Values)
		{
			value.AcceptAsDefault();
		}
	}

	public virtual void Reset()
	{
		foreach (PersistableItem value in persistableItemDictionary_0.Values)
		{
			value.Reset();
		}
	}

	protected virtual IsolatedStorageFile GetStorage()
	{
		return IsolatedStorageFile.GetUserStoreForDomain();
	}

	protected virtual void WriteToIsolatedStorage(string fileName, PersistenceFlags flags)
	{
		using IsolatedStorageFile isolatedStorageFile = GetStorage();
		IsolatedStorageFileStream isolatedStorageFileStream = null;
		isolatedStorageFileStream = new IsolatedStorageFileStream(fileName, FileMode.Create, FileAccess.Write, isolatedStorageFile);
		try
		{
			WriteToStream(isolatedStorageFileStream, flags);
		}
		finally
		{
			isolatedStorageFileStream.Close();
		}
		isolatedStorageFile.Close();
	}

	protected virtual void ReadFromIsolatedStorage(string fileName)
	{
		using IsolatedStorageFile isolatedStorageFile = GetStorage();
		IsolatedStorageFileStream isolatedStorageFileStream = null;
		try
		{
			isolatedStorageFileStream = new IsolatedStorageFileStream(fileName, FileMode.Open, FileAccess.Read, isolatedStorageFile);
		}
		catch (FileNotFoundException)
		{
			isolatedStorageFileStream = null;
		}
		if (isolatedStorageFileStream != null)
		{
			try
			{
				ReadFromStream(isolatedStorageFileStream);
			}
			finally
			{
				isolatedStorageFileStream.Close();
			}
		}
		isolatedStorageFile.Close();
	}

	protected virtual bool IsolatedStorageExists(string fileName)
	{
		fileName = Path.GetFileName(fileName).ToLower();
		using (IsolatedStorageFile isolatedStorageFile = GetStorage())
		{
			string[] fileNames = isolatedStorageFile.GetFileNames("*");
			for (int i = 0; i < fileNames.Length; i++)
			{
				string text = Path.GetFileName(fileNames[i]).ToLower();
				if (text == fileName)
				{
					return true;
				}
			}
			isolatedStorageFile.Close();
		}
		return false;
	}

	protected virtual void RemoveIsolatedStorage(string fileName)
	{
		using IsolatedStorageFile isolatedStorageFile = GetStorage();
		isolatedStorageFile.DeleteFile(fileName);
		isolatedStorageFile.Close();
	}

	protected virtual void WriteToStream(Stream stream, PersistenceFlags flags)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.AppendChild(xmlDocument.CreateElement("settings"));
		WriteToXmlElement(xmlDocument.DocumentElement, flags);
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlDocument.WriteTo(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	protected virtual void WriteToXmlElement(XmlElement xmlElement, PersistenceFlags flags)
	{
		XmlNode xmlNode = xmlElement.SelectSingleNode("settings");
		if (xmlNode == null)
		{
			xmlNode = xmlElement.OwnerDocument.CreateElement("settings");
			xmlElement.AppendChild(xmlNode);
		}
		XmlNode xmlNode2 = xmlNode.SelectSingleNode("items");
		if (xmlNode2 == null)
		{
			xmlNode2 = xmlNode.OwnerDocument.CreateElement("items");
			xmlNode.AppendChild(xmlNode2);
			xmlNode2.Attributes.Append(xmlNode2.OwnerDocument.CreateAttribute("schemaversion"));
			xmlNode2.Attributes["schemaversion"].Value = "1";
		}
		foreach (PersistableItem value in persistableItemDictionary_0.Values)
		{
			string xpath = $"item[@name='{value.Name}' and @type='{value.Type.FullName}' and @schemaversion='1']";
			XmlNode xmlNode3 = xmlNode2.SelectSingleNode(xpath);
			if ((flags & PersistenceFlags.OnlyChanges) != PersistenceFlags.OnlyChanges || value.IsChanged)
			{
				if (xmlNode3 == null)
				{
					xmlNode3 = xmlNode2.OwnerDocument.CreateElement("item");
					xmlNode2.AppendChild(xmlNode3);
					xmlNode3.Attributes.Append(xmlNode3.OwnerDocument.CreateAttribute("name"));
					xmlNode3.Attributes.Append(xmlNode3.OwnerDocument.CreateAttribute("type"));
					xmlNode3.Attributes.Append(xmlNode3.OwnerDocument.CreateAttribute("schemaversion"));
					xmlNode3.Attributes["name"].Value = value.Name;
					xmlNode3.Attributes["type"].Value = value.Type.FullName;
					xmlNode3.Attributes["schemaversion"].Value = "1";
				}
				xmlNode3.InnerText = value.Validator.ValueToString(value.Value);
			}
			else if (xmlNode3 != null)
			{
				xmlNode2.RemoveChild(xmlNode3);
			}
		}
	}

	protected virtual void ReadFromXmlElement(XmlElement xmlElement)
	{
		foreach (PersistableItem value in persistableItemDictionary_0.Values)
		{
			string xpath = $"settings/items/item[@name='{value.Name}' and @type='{value.Type.FullName}' and @schemaversion='1']";
			XmlNode xmlNode = xmlElement.SelectSingleNode(xpath);
			if (xmlNode != null)
			{
				value.Value = value.Validator.StringToValue(xmlNode.InnerText);
			}
		}
	}

	protected virtual void ReadFromStream(Stream stream)
	{
		if (stream.Length != 0L)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(stream);
			ReadFromXmlElement(xmlDocument.DocumentElement);
		}
	}

	protected virtual void ReadFromAppSettings(string itemPrefix)
	{
		if (ConfigurationManager.AppSettings.Count == 0)
		{
			return;
		}
		foreach (PersistableItem value in persistableItemDictionary_0.Values)
		{
			string text = ConfigurationManager.AppSettings[itemPrefix + value.Name];
			if (text != null)
			{
				value.Value = value.Validator.StringToValue(text);
			}
		}
	}

	protected virtual void ReadFromCommandLine(CommandLineArgs commandArguments, string itemPrefix, bool matchCase, bool throwErrorOnUnrecognizedParameter)
	{
		foreach (string key in commandArguments.Keys)
		{
			string text2 = key;
			if (!matchCase)
			{
				text2 = text2.ToUpper();
			}
			bool flag = false;
			foreach (PersistableItem value in persistableItemDictionary_0.Values)
			{
				string text3 = itemPrefix + value.Name;
				if (!matchCase)
				{
					text3 = text3.ToUpper();
				}
				if (text2 == text3)
				{
					value.Value = value.Validator.StringToValue(commandArguments[text2]);
					flag = true;
					break;
				}
			}
			if (!flag && throwErrorOnUnrecognizedParameter)
			{
				throw new UnrecognizedCommandLineParametersException(key);
			}
		}
	}

	protected virtual void ReadFromOther(PersistableSettings other)
	{
		foreach (PersistableItem value in persistableItemDictionary_0.Values)
		{
			foreach (PersistableItem value2 in other.persistableItemDictionary_0.Values)
			{
				if (value.Name == value2.Name)
				{
					string p_str = value2.Validator.ValueToString(value2.Value);
					value.Value = value.Validator.StringToValue(p_str);
					break;
				}
			}
		}
	}

	public override string ToString()
	{
		string text = "ApplicationSetting: ";
		foreach (PersistableItem value in persistableItemDictionary_0.Values)
		{
			text = text + value.ToString() + ", ";
		}
		return text;
	}
}
