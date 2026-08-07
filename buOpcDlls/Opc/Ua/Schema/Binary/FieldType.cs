// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.Binary.FieldType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Schema.Binary;

[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public class FieldType
{
  private Documentation documentationField;
  private string nameField;
  private XmlQualifiedName typeNameField;
  private uint lengthField;
  private bool lengthFieldSpecified;
  private string lengthFieldField;
  private bool isLengthInBytesField;
  private string switchFieldField;
  private uint switchValueField;
  private bool switchValueFieldSpecified;
  private SwitchOperand switchOperandField;
  private bool switchOperandFieldSpecified;
  private byte[] terminatorField;
  private string[] anyAttrField;

  public FieldType() => this.isLengthInBytesField = false;

  public Documentation Documentation
  {
    get => this.documentationField;
    set => this.documentationField = value;
  }

  [XmlAttribute]
  public string Name
  {
    get => this.nameField;
    set => this.nameField = value;
  }

  [XmlAttribute]
  public XmlQualifiedName TypeName
  {
    get => this.typeNameField;
    set => this.typeNameField = value;
  }

  [XmlAttribute]
  public uint Length
  {
    get => this.lengthField;
    set => this.lengthField = value;
  }

  [XmlIgnore]
  public bool LengthSpecified
  {
    get => this.lengthFieldSpecified;
    set => this.lengthFieldSpecified = value;
  }

  [XmlAttribute]
  public string LengthField
  {
    get => this.lengthFieldField;
    set => this.lengthFieldField = value;
  }

  [XmlAttribute]
  [DefaultValue(false)]
  public bool IsLengthInBytes
  {
    get => this.isLengthInBytesField;
    set => this.isLengthInBytesField = value;
  }

  [XmlAttribute]
  public string SwitchField
  {
    get => this.switchFieldField;
    set => this.switchFieldField = value;
  }

  [XmlAttribute]
  public uint SwitchValue
  {
    get => this.switchValueField;
    set => this.switchValueField = value;
  }

  [XmlIgnore]
  public bool SwitchValueSpecified
  {
    get => this.switchValueFieldSpecified;
    set => this.switchValueFieldSpecified = value;
  }

  [XmlAttribute]
  public SwitchOperand SwitchOperand
  {
    get => this.switchOperandField;
    set => this.switchOperandField = value;
  }

  [XmlIgnore]
  public bool SwitchOperandSpecified
  {
    get => this.switchOperandFieldSpecified;
    set => this.switchOperandFieldSpecified = value;
  }

  [XmlAttribute(DataType = "hexBinary")]
  public byte[] Terminator
  {
    get => this.terminatorField;
    set => this.terminatorField = value;
  }

  public string[] AnyAttr
  {
    get => this.anyAttrField;
    set => this.anyAttrField = value;
  }
}
