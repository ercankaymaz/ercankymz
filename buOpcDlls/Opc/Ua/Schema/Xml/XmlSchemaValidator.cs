// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.Xml.XmlSchemaValidator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Schema;

#nullable disable
namespace Opc.Ua.Schema.Xml;

[ComVisible(true)]
public class XmlSchemaValidator : SchemaValidator
{
  protected static readonly string[][] WellKnownDictionaries = new string[1][]
  {
    new string[2]
    {
      "http://opcfoundation.org/UA/2008/02/Types.xsd",
      "Opc.Ua.Schema.Opc.Ua.Types.xsd"
    }
  };
  private XmlSchema m_schema;
  private XmlSchemaSet m_schemaSet;

  public XmlSchemaValidator() => this.SetResourcePaths(XmlSchemaValidator.WellKnownDictionaries);

  public XmlSchemaValidator(IDictionary<string, string> fileTable)
    : base(fileTable)
  {
    this.SetResourcePaths(XmlSchemaValidator.WellKnownDictionaries);
  }

  public XmlSchemaValidator(IDictionary<string, byte[]> importTable)
    : base(importTable)
  {
    this.SetResourcePaths(XmlSchemaValidator.WellKnownDictionaries);
  }

  public XmlSchemaSet SchemaSet => this.m_schemaSet;

  public XmlSchema TargetSchema => this.m_schema;

  public void Validate(string inputPath)
  {
    using (Stream stream = (Stream) File.OpenRead(inputPath))
      this.Validate(stream);
  }

  public void Validate(Stream stream)
  {
    using (XmlReader reader1 = XmlReader.Create(stream, Utils.DefaultXmlReaderSettings()))
    {
      this.m_schema = XmlSchema.Read(reader1, new ValidationEventHandler(XmlSchemaValidator.OnValidate));
      Assembly assembly = typeof (XmlSchemaValidator).GetTypeInfo().Assembly;
      foreach (XmlSchemaImport include in this.m_schema.Includes)
      {
        string str = (string) null;
        if (!this.KnownFiles.TryGetValue(include.Namespace, out str))
          str = include.SchemaLocation;
        FileInfo fileInfo = new FileInfo(str);
        XmlReaderSettings settings = Utils.DefaultXmlReaderSettings();
        if (!fileInfo.Exists)
        {
          using (StreamReader input = new StreamReader(assembly.GetManifestResourceStream(str)))
          {
            using (XmlReader reader2 = XmlReader.Create((TextReader) input, settings))
              include.Schema = XmlSchema.Read(reader2, new ValidationEventHandler(XmlSchemaValidator.OnValidate));
          }
        }
        else
        {
          using (Stream input = (Stream) File.OpenRead(str))
          {
            using (XmlReader reader3 = XmlReader.Create(input, settings))
              include.Schema = XmlSchema.Read(reader3, new ValidationEventHandler(XmlSchemaValidator.OnValidate));
          }
        }
      }
      this.m_schemaSet = new XmlSchemaSet();
      this.m_schemaSet.Add(this.m_schema);
      this.m_schemaSet.Compile();
    }
  }

  public override string GetSchema(string typeName)
  {
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    MemoryStream output = new MemoryStream();
    XmlWriter writer = XmlWriter.Create((Stream) output, settings);
    try
    {
      if (typeName != null && this.m_schema.Elements.Values.Count != 0)
      {
        foreach (XmlSchemaObject xmlSchemaObject in (IEnumerable) this.m_schema.Elements.Values)
        {
          if (xmlSchemaObject is XmlSchemaElement xmlSchemaElement && xmlSchemaElement.Name == typeName)
          {
            new XmlSchema()
            {
              Items = {
                (XmlSchemaObject) xmlSchemaElement.ElementSchemaType,
                (XmlSchemaObject) xmlSchemaElement
              }
            }.Write(writer);
            break;
          }
        }
      }
      else
        this.m_schema.Write(writer);
    }
    finally
    {
      writer.Flush();
      writer.Dispose();
    }
    return Encoding.UTF8.GetString(output.ToArray());
  }

  private static void OnValidate(object sender, ValidationEventArgs args)
  {
    Utils.LogError("Error in XML schema validation: {0}", (object) args.Message);
    throw new InvalidOperationException(args.Message, (System.Exception) args.Exception);
  }
}
