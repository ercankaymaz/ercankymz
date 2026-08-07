// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.Binary.TypeDescription
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Schema.Binary;

[XmlInclude(typeof (StructuredType))]
[XmlInclude(typeof (OpaqueType))]
[XmlInclude(typeof (EnumeratedType))]
[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public class TypeDescription
{
  private XmlQualifiedName m_qname;
  private Documentation documentationField;
  private string nameField;
  private ByteOrder defaultByteOrderField;
  private bool defaultByteOrderFieldSpecified;

  [XmlIgnore]
  public XmlQualifiedName QName
  {
    get => this.m_qname;
    set => this.m_qname = value;
  }

  public Documentation Documentation
  {
    get => this.documentationField;
    set => this.documentationField = value;
  }

  [XmlAttribute(DataType = "NCName")]
  public string Name
  {
    get => this.nameField;
    set => this.nameField = value;
  }

  [XmlAttribute]
  public ByteOrder DefaultByteOrder
  {
    get => this.defaultByteOrderField;
    set => this.defaultByteOrderField = value;
  }

  [XmlIgnore]
  public bool DefaultByteOrderSpecified
  {
    get => this.defaultByteOrderFieldSpecified;
    set => this.defaultByteOrderFieldSpecified = value;
  }
}
