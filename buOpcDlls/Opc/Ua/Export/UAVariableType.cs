// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.UAVariableType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Export;

[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
[Serializable]
public class UAVariableType : UAType
{
  private XmlElement valueField;
  private string dataTypeField;
  private int valueRankField;
  private string arrayDimensionsField;

  public UAVariableType()
  {
    this.dataTypeField = "i=24";
    this.valueRankField = -1;
    this.arrayDimensionsField = "";
  }

  public XmlElement Value
  {
    get => this.valueField;
    set => this.valueField = value;
  }

  [XmlAttribute]
  [DefaultValue("i=24")]
  public string DataType
  {
    get => this.dataTypeField;
    set => this.dataTypeField = value;
  }

  [XmlAttribute]
  [DefaultValue(-1)]
  public int ValueRank
  {
    get => this.valueRankField;
    set => this.valueRankField = value;
  }

  [XmlAttribute(DataType = "token")]
  [DefaultValue("")]
  public string ArrayDimensions
  {
    get => this.arrayDimensionsField;
    set => this.arrayDimensionsField = value;
  }
}
