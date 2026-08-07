// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.SchemaValidator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Schema;

[ComVisible(true)]
public class SchemaValidator
{
  private IDictionary<string, string> m_knownFiles;
  private IDictionary<string, object> m_loadedFiles;
  private IDictionary<string, byte[]> m_importFiles;

  public SchemaValidator()
  {
    this.m_knownFiles = (IDictionary<string, string>) new Dictionary<string, string>();
    this.m_loadedFiles = (IDictionary<string, object>) new Dictionary<string, object>();
    this.m_importFiles = (IDictionary<string, byte[]>) new Dictionary<string, byte[]>();
  }

  public SchemaValidator(IDictionary<string, string> knownFiles)
  {
    this.m_knownFiles = knownFiles ?? (IDictionary<string, string>) new Dictionary<string, string>();
    this.m_loadedFiles = (IDictionary<string, object>) new Dictionary<string, object>();
    this.m_importFiles = (IDictionary<string, byte[]>) new Dictionary<string, byte[]>();
  }

  public SchemaValidator(IDictionary<string, byte[]> importFiles)
  {
    this.m_knownFiles = (IDictionary<string, string>) new Dictionary<string, string>();
    this.m_loadedFiles = (IDictionary<string, object>) new Dictionary<string, object>();
    this.m_importFiles = importFiles ?? (IDictionary<string, byte[]>) new Dictionary<string, byte[]>();
  }

  public string FilePath { get; private set; }

  public IDictionary<string, string> KnownFiles => this.m_knownFiles;

  public IDictionary<string, object> LoadedFiles => this.m_loadedFiles;

  public IDictionary<string, byte[]> ImportFiles => this.m_importFiles;

  protected static bool IsNull(XmlQualifiedName name)
  {
    return !(name != (XmlQualifiedName) null) || string.IsNullOrEmpty(name.Name);
  }

  protected static System.Exception Exception(string format) => throw new FormatException(format);

  protected static System.Exception Exception(string format, object arg1)
  {
    return (System.Exception) new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, arg1));
  }

  protected static System.Exception Exception(string format, object arg1, object arg2)
  {
    return (System.Exception) new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, arg1, arg2));
  }

  protected static System.Exception Exception(
    string format,
    object arg1,
    object arg2,
    object arg3)
  {
    return (System.Exception) new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, arg1, arg2, arg3));
  }

  protected object LoadInput(Type type, Stream stream)
  {
    this.m_loadedFiles.Clear();
    object obj = SchemaValidator.LoadFile(type, stream);
    this.FilePath = (string) null;
    return obj;
  }

  protected object LoadInput(Type type, string path)
  {
    this.m_loadedFiles.Clear();
    object obj = SchemaValidator.LoadFile(type, path);
    this.FilePath = path;
    return obj;
  }

  protected object Load(Type type, string namespaceUri, string path, Assembly assembly = null)
  {
    if (this.m_loadedFiles.ContainsKey(namespaceUri))
      return this.m_loadedFiles[namespaceUri];
    byte[] buffer;
    if (this.m_importFiles.TryGetValue(namespaceUri, out buffer))
    {
      using (Stream stream = (Stream) new MemoryStream(buffer))
        return SchemaValidator.LoadFile(type, stream);
    }
    FileInfo fileInfo1 = (FileInfo) null;
    if (!string.IsNullOrEmpty(path))
    {
      fileInfo1 = new FileInfo(path);
      if (fileInfo1.Exists)
        return SchemaValidator.LoadFile(type, path);
    }
    string str = (string) null;
    if (this.m_knownFiles.TryGetValue(namespaceUri, out str))
      return new FileInfo(str).Exists ? SchemaValidator.LoadFile(type, str) : SchemaValidator.LoadResource(type, str, assembly);
    if (!string.IsNullOrEmpty(path))
    {
      if (!File.Exists(path))
        return SchemaValidator.LoadResource(type, path, assembly);
      FileInfo fileInfo2 = new FileInfo(new FileInfo(this.FilePath).DirectoryName + Path.DirectorySeparatorChar.ToString() + fileInfo1.Name);
      if (fileInfo2.Exists)
        return SchemaValidator.LoadFile(type, fileInfo2.FullName);
      FileInfo fileInfo3 = new FileInfo(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar.ToString() + fileInfo2.Name);
      if (fileInfo3.Exists)
        return SchemaValidator.LoadFile(type, fileInfo3.FullName);
    }
    throw SchemaValidator.Exception("Cannot import namespace '{0}' from '{1}'.", (object) namespaceUri, (object) path);
  }

  protected static object LoadFile(Type type, string path)
  {
    using (StreamReader input = new StreamReader((Stream) new FileStream(path, FileMode.Open)))
    {
      using (XmlReader xmlReader = XmlReader.Create((TextReader) input, Utils.DefaultXmlReaderSettings()))
        return new XmlSerializer(type).Deserialize(xmlReader);
    }
  }

  protected static object LoadFile(Type type, Stream stream)
  {
    using (StreamReader input = new StreamReader(stream))
    {
      using (XmlReader xmlReader = XmlReader.Create((TextReader) input, Utils.DefaultXmlReaderSettings()))
        return new XmlSerializer(type).Deserialize(xmlReader);
    }
  }

  protected static object LoadResource(Type type, string path, Assembly assembly)
  {
    try
    {
      if (assembly == (Assembly) null)
        assembly = typeof (SchemaValidator).GetTypeInfo().Assembly;
      using (StreamReader input = new StreamReader(assembly.GetManifestResourceStream(path)))
      {
        using (XmlReader xmlReader = XmlReader.Create((TextReader) input, Utils.DefaultXmlReaderSettings()))
          return new XmlSerializer(type).Deserialize(xmlReader);
      }
    }
    catch (System.Exception ex)
    {
      throw new FileNotFoundException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Could not load resource '{0}'.", (object) path), ex);
    }
  }

  protected void SetResourcePaths(string[][] resources)
  {
    if (resources == null)
      return;
    for (int index = 0; index < resources.Length; ++index)
    {
      if (!this.m_knownFiles.ContainsKey(resources[index][0]))
        this.m_knownFiles.Add(resources[index][0], resources[index][1]);
    }
  }

  public virtual string GetSchema(string typeName) => (string) null;
}
