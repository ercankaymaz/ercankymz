// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.Binary.Documentation
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

[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/BinarySchema/")]
[XmlRoot(Namespace = "http://opcfoundation.org/BinarySchema/", IsNullable = false)]
[ComVisible(true)]
public class Documentation
{
  private XmlElement[] itemsField;
  private string[] textField;
  private string[] anyAttrField;

  [XmlAnyElement]
  public XmlElement[] Items
  {
    get => this.itemsField;
    set => this.itemsField = value;
  }

  [XmlText]
  public string[] Text
  {
    get => this.textField;
    set => this.textField = value;
  }

  public string[] AnyAttr
  {
    get => this.anyAttrField;
    set => this.anyAttrField = value;
  }
}
