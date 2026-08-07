// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.DataTypeField
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Export;

[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
[Serializable]
public class DataTypeField
{
  private LocalizedText[] displayNameField;
  private LocalizedText[] descriptionField;
  private string nameField;
  private string symbolicNameField;
  private string dataTypeField;
  private int valueRankField;
  private string arrayDimensionsField;
  private uint maxStringLengthField;
  private int valueField;
  private bool isOptionalField;
  private bool allowSubTypesField;

  public DataTypeField()
  {
    this.dataTypeField = "i=24";
    this.valueRankField = -1;
    this.arrayDimensionsField = "";
    this.maxStringLengthField = 0U;
    this.valueField = -1;
    this.isOptionalField = false;
    this.allowSubTypesField = false;
  }

  [XmlElement("DisplayName")]
  public LocalizedText[] DisplayName
  {
    get => this.displayNameField;
    set => this.displayNameField = value;
  }

  [XmlElement("Description")]
  public LocalizedText[] Description
  {
    get => this.descriptionField;
    set => this.descriptionField = value;
  }

  [XmlAttribute]
  public string Name
  {
    get => this.nameField;
    set => this.nameField = value;
  }

  [XmlAttribute]
  public string SymbolicName
  {
    get => this.symbolicNameField;
    set => this.symbolicNameField = value;
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

  [XmlAttribute]
  [DefaultValue(typeof (uint), "0")]
  public uint MaxStringLength
  {
    get => this.maxStringLengthField;
    set => this.maxStringLengthField = value;
  }

  [XmlAttribute]
  [DefaultValue(-1)]
  public int Value
  {
    get => this.valueField;
    set => this.valueField = value;
  }

  [XmlAttribute]
  [DefaultValue(false)]
  public bool IsOptional
  {
    get => this.isOptionalField;
    set => this.isOptionalField = value;
  }

  [XmlAttribute]
  [DefaultValue(false)]
  public bool AllowSubTypes
  {
    get => this.allowSubTypesField;
    set => this.allowSubTypesField = value;
  }
}
