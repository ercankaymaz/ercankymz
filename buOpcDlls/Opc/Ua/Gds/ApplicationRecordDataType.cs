// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Gds.ApplicationRecordDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/GDS/Types.xsd")]
[ComVisible(true)]
public class ApplicationRecordDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_applicationId;
  private string m_applicationUri;
  private ApplicationType m_applicationType;
  private LocalizedTextCollection m_applicationNames;
  private string m_productUri;
  private StringCollection m_discoveryUrls;
  private StringCollection m_serverCapabilities;

  public ApplicationRecordDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_applicationId = (NodeId) null;
    this.m_applicationUri = (string) null;
    this.m_applicationType = ApplicationType.Server;
    this.m_applicationNames = new LocalizedTextCollection();
    this.m_productUri = (string) null;
    this.m_discoveryUrls = new StringCollection();
    this.m_serverCapabilities = new StringCollection();
  }

  [DataMember(Name = "ApplicationId", IsRequired = false, Order = 1)]
  public NodeId ApplicationId
  {
    get => this.m_applicationId;
    set => this.m_applicationId = value;
  }

  [DataMember(Name = "ApplicationUri", IsRequired = false, Order = 2)]
  public string ApplicationUri
  {
    get => this.m_applicationUri;
    set => this.m_applicationUri = value;
  }

  [DataMember(Name = "ApplicationType", IsRequired = false, Order = 3)]
  public ApplicationType ApplicationType
  {
    get => this.m_applicationType;
    set => this.m_applicationType = value;
  }

  [DataMember(Name = "ApplicationNames", IsRequired = false, Order = 4)]
  public LocalizedTextCollection ApplicationNames
  {
    get => this.m_applicationNames;
    set
    {
      this.m_applicationNames = value;
      if (value != null)
        return;
      this.m_applicationNames = new LocalizedTextCollection();
    }
  }

  [DataMember(Name = "ProductUri", IsRequired = false, Order = 5)]
  public string ProductUri
  {
    get => this.m_productUri;
    set => this.m_productUri = value;
  }

  [DataMember(Name = "DiscoveryUrls", IsRequired = false, Order = 6)]
  public StringCollection DiscoveryUrls
  {
    get => this.m_discoveryUrls;
    set
    {
      this.m_discoveryUrls = value;
      if (value != null)
        return;
      this.m_discoveryUrls = new StringCollection();
    }
  }

  [DataMember(Name = "ServerCapabilities", IsRequired = false, Order = 7)]
  public StringCollection ServerCapabilities
  {
    get => this.m_serverCapabilities;
    set
    {
      this.m_serverCapabilities = value;
      if (value != null)
        return;
      this.m_serverCapabilities = new StringCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => DataTypeIds.ApplicationRecordDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => ObjectIds.ApplicationRecordDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => ObjectIds.ApplicationRecordDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => ObjectIds.ApplicationRecordDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/GDS/Types.xsd");
    encoder.WriteNodeId("ApplicationId", this.ApplicationId);
    encoder.WriteString("ApplicationUri", this.ApplicationUri);
    encoder.WriteEnumerated("ApplicationType", (Enum) this.ApplicationType);
    encoder.WriteLocalizedTextArray("ApplicationNames", (IList<LocalizedText>) this.ApplicationNames);
    encoder.WriteString("ProductUri", this.ProductUri);
    encoder.WriteStringArray("DiscoveryUrls", (IList<string>) this.DiscoveryUrls);
    encoder.WriteStringArray("ServerCapabilities", (IList<string>) this.ServerCapabilities);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/GDS/Types.xsd");
    this.ApplicationId = decoder.ReadNodeId("ApplicationId");
    this.ApplicationUri = decoder.ReadString("ApplicationUri");
    this.ApplicationType = (ApplicationType) decoder.ReadEnumerated("ApplicationType", typeof (ApplicationType));
    this.ApplicationNames = decoder.ReadLocalizedTextArray("ApplicationNames");
    this.ProductUri = decoder.ReadString("ProductUri");
    this.DiscoveryUrls = decoder.ReadStringArray("DiscoveryUrls");
    this.ServerCapabilities = decoder.ReadStringArray("ServerCapabilities");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ApplicationRecordDataType applicationRecordDataType && Utils.IsEqual((object) this.m_applicationId, (object) applicationRecordDataType.m_applicationId) && Utils.IsEqual((object) this.m_applicationUri, (object) applicationRecordDataType.m_applicationUri) && Utils.IsEqual((object) this.m_applicationType, (object) applicationRecordDataType.m_applicationType) && Utils.IsEqual((object) this.m_applicationNames, (object) applicationRecordDataType.m_applicationNames) && Utils.IsEqual((object) this.m_productUri, (object) applicationRecordDataType.m_productUri) && Utils.IsEqual((object) this.m_discoveryUrls, (object) applicationRecordDataType.m_discoveryUrls) && Utils.IsEqual((object) this.m_serverCapabilities, (object) applicationRecordDataType.m_serverCapabilities);
  }

  public virtual object Clone() => (object) (ApplicationRecordDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ApplicationRecordDataType applicationRecordDataType = (ApplicationRecordDataType) base.MemberwiseClone();
    applicationRecordDataType.m_applicationId = (NodeId) Utils.Clone((object) this.m_applicationId);
    applicationRecordDataType.m_applicationUri = (string) Utils.Clone((object) this.m_applicationUri);
    applicationRecordDataType.m_applicationType = (ApplicationType) Utils.Clone((object) this.m_applicationType);
    applicationRecordDataType.m_applicationNames = (LocalizedTextCollection) Utils.Clone((object) this.m_applicationNames);
    applicationRecordDataType.m_productUri = (string) Utils.Clone((object) this.m_productUri);
    applicationRecordDataType.m_discoveryUrls = (StringCollection) Utils.Clone((object) this.m_discoveryUrls);
    applicationRecordDataType.m_serverCapabilities = (StringCollection) Utils.Clone((object) this.m_serverCapabilities);
    return (object) applicationRecordDataType;
  }
}
