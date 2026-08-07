// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.Binary.EnumeratedValue
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
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public class EnumeratedValue
{
  private Documentation documentationField;
  private string nameField;
  private int valueField;
  private bool valueFieldSpecified;

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
  public int Value
  {
    get => this.valueField;
    set => this.valueField = value;
  }

  [XmlIgnore]
  public bool ValueSpecified
  {
    get => this.valueFieldSpecified;
    set => this.valueFieldSpecified = value;
  }
}
