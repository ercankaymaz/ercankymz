// Decompiled with JetBrains decompiler
// Type: DevAge.Configuration.PersistableSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Xml;

#nullable disable
namespace DevAge.Configuration;

public class PersistableSettings
{
  private PersistableItemDictionary persistableItemDictionary_0 = new PersistableItemDictionary();

  protected PersistableItemDictionary Dictionary => this.persistableItemDictionary_0;

  protected void AddPersistableItem(PersistableItem item)
  {
    this.persistableItemDictionary_0.Add(item.Name, item);
  }

  protected virtual object this[string name]
  {
    get => this.persistableItemDictionary_0[name].Value;
    set => this.persistableItemDictionary_0[name].Value = value;
  }

  [Browsable(false)]
  public virtual bool HasChanges
  {
    get
    {
      bool hasChanges;
      foreach (PersistableItem persistableItem in (IEnumerable) this.persistableItemDictionary_0.Values)
      {
        if (persistableItem.IsChanged)
        {
          hasChanges = true;
          goto label_9;
        }
      }
      hasChanges = false;
label_9:
      return hasChanges;
    }
  }

  public virtual void AcceptChangesAsDefault()
  {
    foreach (PersistableItem persistableItem in (IEnumerable) this.persistableItemDictionary_0.Values)
      persistableItem.AcceptAsDefault();
  }

  public virtual void Reset()
  {
    foreach (PersistableItem persistableItem in (IEnumerable) this.persistableItemDictionary_0.Values)
      persistableItem.Reset();
  }

  protected virtual IsolatedStorageFile GetStorage() => IsolatedStorageFile.GetUserStoreForDomain();

  protected virtual void WriteToIsolatedStorage(string fileName, PersistenceFlags flags)
  {
    using (IsolatedStorageFile storage = this.GetStorage())
    {
      IsolatedStorageFileStream storageFileStream = new IsolatedStorageFileStream(fileName, FileMode.Create, FileAccess.Write, storage);
      try
      {
        this.WriteToStream((Stream) storageFileStream, flags);
      }
      finally
      {
        storageFileStream.Close();
      }
      storage.Close();
    }
  }

  protected virtual void ReadFromIsolatedStorage(string fileName)
  {
    using (IsolatedStorageFile storage = this.GetStorage())
    {
      IsolatedStorageFileStream storageFileStream;
      try
      {
        storageFileStream = new IsolatedStorageFileStream(fileName, FileMode.Open, FileAccess.Read, storage);
      }
      catch (FileNotFoundException ex)
      {
        storageFileStream = (IsolatedStorageFileStream) null;
      }
      if (storageFileStream != null)
      {
        try
        {
          this.ReadFromStream((Stream) storageFileStream);
        }
        finally
        {
          storageFileStream.Close();
        }
      }
      storage.Close();
    }
  }

  protected virtual bool IsolatedStorageExists(string fileName)
  {
    fileName = Path.GetFileName(fileName).ToLower();
    bool flag;
    using (IsolatedStorageFile storage = this.GetStorage())
    {
      foreach (string fileName1 in storage.GetFileNames("*"))
      {
        if (Path.GetFileName(fileName1).ToLower() == fileName)
        {
          flag = true;
          goto label_11;
        }
      }
      storage.Close();
    }
    flag = false;
label_11:
    return flag;
  }

  protected virtual void RemoveIsolatedStorage(string fileName)
  {
    using (IsolatedStorageFile storage = this.GetStorage())
    {
      storage.DeleteFile(fileName);
      storage.Close();
    }
  }

  protected virtual void WriteToStream(Stream stream, PersistenceFlags flags)
  {
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.AppendChild((XmlNode) xmlDocument.CreateElement("settings"));
    this.WriteToXmlElement(xmlDocument.DocumentElement, flags);
    XmlTextWriter w = new XmlTextWriter(stream, Encoding.UTF8);
    w.Formatting = Formatting.Indented;
    xmlDocument.WriteTo((XmlWriter) w);
    w.Flush();
  }

  protected virtual void WriteToXmlElement(XmlElement xmlElement, PersistenceFlags flags)
  {
    XmlNode newChild1 = xmlElement.SelectSingleNode("settings");
    if (newChild1 == null)
    {
      newChild1 = (XmlNode) xmlElement.OwnerDocument.CreateElement("settings");
      xmlElement.AppendChild(newChild1);
    }
    XmlNode newChild2 = newChild1.SelectSingleNode("items");
    if (newChild2 == null)
    {
      newChild2 = (XmlNode) newChild1.OwnerDocument.CreateElement("items");
      newChild1.AppendChild(newChild2);
      newChild2.Attributes.Append(newChild2.OwnerDocument.CreateAttribute("schemaversion"));
      newChild2.Attributes["schemaversion"].Value = "1";
    }
    foreach (PersistableItem persistableItem in (IEnumerable) this.persistableItemDictionary_0.Values)
    {
      string xpath = $"item[@name='{persistableItem.Name}' and @type='{persistableItem.Type.FullName}' and @schemaversion='1']";
      XmlNode xmlNode = newChild2.SelectSingleNode(xpath);
      if (((flags & PersistenceFlags.OnlyChanges) != PersistenceFlags.OnlyChanges ? 0 : (!persistableItem.IsChanged ? 1 : 0)) != 0)
      {
        if (xmlNode != null)
          newChild2.RemoveChild(xmlNode);
      }
      else
      {
        if (xmlNode == null)
        {
          xmlNode = (XmlNode) newChild2.OwnerDocument.CreateElement("item");
          newChild2.AppendChild(xmlNode);
          xmlNode.Attributes.Append(xmlNode.OwnerDocument.CreateAttribute("name"));
          xmlNode.Attributes.Append(xmlNode.OwnerDocument.CreateAttribute("type"));
          xmlNode.Attributes.Append(xmlNode.OwnerDocument.CreateAttribute("schemaversion"));
          xmlNode.Attributes["name"].Value = persistableItem.Name;
          xmlNode.Attributes["type"].Value = persistableItem.Type.FullName;
          xmlNode.Attributes["schemaversion"].Value = "1";
        }
        xmlNode.InnerText = persistableItem.Validator.ValueToString(persistableItem.Value);
      }
    }
  }

  protected virtual void ReadFromXmlElement(XmlElement xmlElement)
  {
    foreach (PersistableItem persistableItem in (IEnumerable) this.persistableItemDictionary_0.Values)
    {
      string xpath = $"settings/items/item[@name='{persistableItem.Name}' and @type='{persistableItem.Type.FullName}' and @schemaversion='1']";
      XmlNode xmlNode = xmlElement.SelectSingleNode(xpath);
      if (xmlNode != null)
        persistableItem.Value = persistableItem.Validator.StringToValue(xmlNode.InnerText);
    }
  }

  protected virtual void ReadFromStream(Stream stream)
  {
    if (stream.Length == 0L)
      return;
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load(stream);
    this.ReadFromXmlElement(xmlDocument.DocumentElement);
  }

  protected virtual void ReadFromAppSettings(string itemPrefix)
  {
    if (ConfigurationManager.AppSettings.Count == 0)
      return;
    foreach (PersistableItem persistableItem in (IEnumerable) this.persistableItemDictionary_0.Values)
    {
      string appSetting = ConfigurationManager.AppSettings[itemPrefix + persistableItem.Name];
      if (appSetting != null)
        persistableItem.Value = persistableItem.Validator.StringToValue(appSetting);
    }
  }

  protected virtual void ReadFromCommandLine(
    CommandLineArgs commandArguments,
    string itemPrefix,
    bool matchCase,
    bool throwErrorOnUnrecognizedParameter)
  {
    foreach (string key1 in (IEnumerable) commandArguments.Keys)
    {
      string key2 = key1;
      if (!matchCase)
        key2 = key2.ToUpper();
      bool flag = false;
      foreach (PersistableItem persistableItem in (IEnumerable) this.persistableItemDictionary_0.Values)
      {
        string str = itemPrefix + persistableItem.Name;
        if (!matchCase)
          str = str.ToUpper();
        if (key2 == str)
        {
          persistableItem.Value = persistableItem.Validator.StringToValue(commandArguments[key2]);
          flag = true;
          break;
        }
      }
      if (!flag & throwErrorOnUnrecognizedParameter)
        throw new UnrecognizedCommandLineParametersException(key1);
    }
  }

  protected virtual void ReadFromOther(PersistableSettings other)
  {
    foreach (PersistableItem persistableItem1 in (IEnumerable) this.persistableItemDictionary_0.Values)
    {
      foreach (PersistableItem persistableItem2 in (IEnumerable) other.persistableItemDictionary_0.Values)
      {
        if (persistableItem1.Name == persistableItem2.Name)
        {
          string p_str = persistableItem2.Validator.ValueToString(persistableItem2.Value);
          persistableItem1.Value = persistableItem1.Validator.StringToValue(p_str);
          break;
        }
      }
    }
  }

  public override string ToString()
  {
    string str = "ApplicationSetting: ";
    foreach (PersistableItem persistableItem in (IEnumerable) this.persistableItemDictionary_0.Values)
      str = $"{str}{persistableItem.ToString()}, ";
    return str;
  }
}
