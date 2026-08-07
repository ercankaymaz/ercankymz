// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BuildInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BuildInfo : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_productUri;
  private string m_manufacturerName;
  private string m_productName;
  private string m_softwareVersion;
  private string m_buildNumber;
  private DateTime m_buildDate;

  public BuildInfo() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_productUri = (string) null;
    this.m_manufacturerName = (string) null;
    this.m_productName = (string) null;
    this.m_softwareVersion = (string) null;
    this.m_buildNumber = (string) null;
    this.m_buildDate = DateTime.MinValue;
  }

  [DataMember(Name = "ProductUri", IsRequired = false, Order = 1)]
  public string ProductUri
  {
    get => this.m_productUri;
    set => this.m_productUri = value;
  }

  [DataMember(Name = "ManufacturerName", IsRequired = false, Order = 2)]
  public string ManufacturerName
  {
    get => this.m_manufacturerName;
    set => this.m_manufacturerName = value;
  }

  [DataMember(Name = "ProductName", IsRequired = false, Order = 3)]
  public string ProductName
  {
    get => this.m_productName;
    set => this.m_productName = value;
  }

  [DataMember(Name = "SoftwareVersion", IsRequired = false, Order = 4)]
  public string SoftwareVersion
  {
    get => this.m_softwareVersion;
    set => this.m_softwareVersion = value;
  }

  [DataMember(Name = "BuildNumber", IsRequired = false, Order = 5)]
  public string BuildNumber
  {
    get => this.m_buildNumber;
    set => this.m_buildNumber = value;
  }

  [DataMember(Name = "BuildDate", IsRequired = false, Order = 6)]
  public DateTime BuildDate
  {
    get => this.m_buildDate;
    set => this.m_buildDate = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BuildInfo;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BuildInfo_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BuildInfo_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BuildInfo_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("ProductUri", this.ProductUri);
    encoder.WriteString("ManufacturerName", this.ManufacturerName);
    encoder.WriteString("ProductName", this.ProductName);
    encoder.WriteString("SoftwareVersion", this.SoftwareVersion);
    encoder.WriteString("BuildNumber", this.BuildNumber);
    encoder.WriteDateTime("BuildDate", this.BuildDate);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ProductUri = decoder.ReadString("ProductUri");
    this.ManufacturerName = decoder.ReadString("ManufacturerName");
    this.ProductName = decoder.ReadString("ProductName");
    this.SoftwareVersion = decoder.ReadString("SoftwareVersion");
    this.BuildNumber = decoder.ReadString("BuildNumber");
    this.BuildDate = decoder.ReadDateTime("BuildDate");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BuildInfo buildInfo && Utils.IsEqual((object) this.m_productUri, (object) buildInfo.m_productUri) && Utils.IsEqual((object) this.m_manufacturerName, (object) buildInfo.m_manufacturerName) && Utils.IsEqual((object) this.m_productName, (object) buildInfo.m_productName) && Utils.IsEqual((object) this.m_softwareVersion, (object) buildInfo.m_softwareVersion) && Utils.IsEqual((object) this.m_buildNumber, (object) buildInfo.m_buildNumber) && Utils.IsEqual(this.m_buildDate, buildInfo.m_buildDate);
  }

  public virtual object Clone() => (object) (BuildInfo) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BuildInfo buildInfo = (BuildInfo) base.MemberwiseClone();
    buildInfo.m_productUri = (string) Utils.Clone((object) this.m_productUri);
    buildInfo.m_manufacturerName = (string) Utils.Clone((object) this.m_manufacturerName);
    buildInfo.m_productName = (string) Utils.Clone((object) this.m_productName);
    buildInfo.m_softwareVersion = (string) Utils.Clone((object) this.m_softwareVersion);
    buildInfo.m_buildNumber = (string) Utils.Clone((object) this.m_buildNumber);
    buildInfo.m_buildDate = (DateTime) Utils.Clone((object) this.m_buildDate);
    return (object) buildInfo;
  }
}
