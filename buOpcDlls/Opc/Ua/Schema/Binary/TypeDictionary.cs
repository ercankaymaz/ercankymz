// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.Binary.TypeDictionary
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Schema.Binary;

[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/BinarySchema/")]
[XmlRoot(Namespace = "http://opcfoundation.org/BinarySchema/", IsNullable = false)]
[ComVisible(true)]
public class TypeDictionary
{
  private Documentation documentationField;
  private ImportDirective[] importField;
  private TypeDescription[] itemsField;
  private string targetNamespaceField;
  private ByteOrder defaultByteOrderField;
  private bool defaultByteOrderFieldSpecified;

  public Documentation Documentation
  {
    get => this.documentationField;
    set => this.documentationField = value;
  }

  [XmlElement("Import")]
  public ImportDirective[] Import
  {
    get => this.importField;
    set => this.importField = value;
  }

  [XmlElement("EnumeratedType", typeof (EnumeratedType))]
  [XmlElement("OpaqueType", typeof (OpaqueType))]
  [XmlElement("StructuredType", typeof (StructuredType))]
  public TypeDescription[] Items
  {
    get => this.itemsField;
    set => this.itemsField = value;
  }

  [XmlAttribute]
  public string TargetNamespace
  {
    get => this.targetNamespaceField;
    set => this.targetNamespaceField = value;
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
