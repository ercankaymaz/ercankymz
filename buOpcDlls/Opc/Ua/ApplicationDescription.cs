// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ApplicationDescription
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ApplicationDescription : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_applicationUri;
  private string m_productUri;
  private LocalizedText m_applicationName;
  private ApplicationType m_applicationType;
  private string m_gatewayServerUri;
  private string m_discoveryProfileUri;
  private StringCollection m_discoveryUrls;

  public ApplicationDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_applicationUri = (string) null;
    this.m_productUri = (string) null;
    this.m_applicationName = (LocalizedText) null;
    this.m_applicationType = ApplicationType.Server;
    this.m_gatewayServerUri = (string) null;
    this.m_discoveryProfileUri = (string) null;
    this.m_discoveryUrls = new StringCollection();
  }

  [DataMember(Name = "ApplicationUri", IsRequired = false, Order = 1)]
  public string ApplicationUri
  {
    get => this.m_applicationUri;
    set => this.m_applicationUri = value;
  }

  [DataMember(Name = "ProductUri", IsRequired = false, Order = 2)]
  public string ProductUri
  {
    get => this.m_productUri;
    set => this.m_productUri = value;
  }

  [DataMember(Name = "ApplicationName", IsRequired = false, Order = 3)]
  public LocalizedText ApplicationName
  {
    get => this.m_applicationName;
    set => this.m_applicationName = value;
  }

  [DataMember(Name = "ApplicationType", IsRequired = false, Order = 4)]
  public ApplicationType ApplicationType
  {
    get => this.m_applicationType;
    set => this.m_applicationType = value;
  }

  [DataMember(Name = "GatewayServerUri", IsRequired = false, Order = 5)]
  public string GatewayServerUri
  {
    get => this.m_gatewayServerUri;
    set => this.m_gatewayServerUri = value;
  }

  [DataMember(Name = "DiscoveryProfileUri", IsRequired = false, Order = 6)]
  public string DiscoveryProfileUri
  {
    get => this.m_discoveryProfileUri;
    set => this.m_discoveryProfileUri = value;
  }

  [DataMember(Name = "DiscoveryUrls", IsRequired = false, Order = 7)]
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

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ApplicationDescription;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ApplicationDescription_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ApplicationDescription_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ApplicationDescription_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("ApplicationUri", this.ApplicationUri);
    encoder.WriteString("ProductUri", this.ProductUri);
    encoder.WriteLocalizedText("ApplicationName", this.ApplicationName);
    encoder.WriteEnumerated("ApplicationType", (Enum) this.ApplicationType);
    encoder.WriteString("GatewayServerUri", this.GatewayServerUri);
    encoder.WriteString("DiscoveryProfileUri", this.DiscoveryProfileUri);
    encoder.WriteStringArray("DiscoveryUrls", (IList<string>) this.DiscoveryUrls);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ApplicationUri = decoder.ReadString("ApplicationUri");
    this.ProductUri = decoder.ReadString("ProductUri");
    this.ApplicationName = decoder.ReadLocalizedText("ApplicationName");
    this.ApplicationType = (ApplicationType) decoder.ReadEnumerated("ApplicationType", typeof (ApplicationType));
    this.GatewayServerUri = decoder.ReadString("GatewayServerUri");
    this.DiscoveryProfileUri = decoder.ReadString("DiscoveryProfileUri");
    this.DiscoveryUrls = decoder.ReadStringArray("DiscoveryUrls");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ApplicationDescription applicationDescription && Utils.IsEqual((object) this.m_applicationUri, (object) applicationDescription.m_applicationUri) && Utils.IsEqual((object) this.m_productUri, (object) applicationDescription.m_productUri) && Utils.IsEqual((object) this.m_applicationName, (object) applicationDescription.m_applicationName) && Utils.IsEqual((object) this.m_applicationType, (object) applicationDescription.m_applicationType) && Utils.IsEqual((object) this.m_gatewayServerUri, (object) applicationDescription.m_gatewayServerUri) && Utils.IsEqual((object) this.m_discoveryProfileUri, (object) applicationDescription.m_discoveryProfileUri) && Utils.IsEqual((object) this.m_discoveryUrls, (object) applicationDescription.m_discoveryUrls);
  }

  public virtual object Clone() => (object) (ApplicationDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ApplicationDescription applicationDescription = (ApplicationDescription) base.MemberwiseClone();
    applicationDescription.m_applicationUri = (string) Utils.Clone((object) this.m_applicationUri);
    applicationDescription.m_productUri = (string) Utils.Clone((object) this.m_productUri);
    applicationDescription.m_applicationName = (LocalizedText) Utils.Clone((object) this.m_applicationName);
    applicationDescription.m_applicationType = (ApplicationType) Utils.Clone((object) this.m_applicationType);
    applicationDescription.m_gatewayServerUri = (string) Utils.Clone((object) this.m_gatewayServerUri);
    applicationDescription.m_discoveryProfileUri = (string) Utils.Clone((object) this.m_discoveryProfileUri);
    applicationDescription.m_discoveryUrls = (StringCollection) Utils.Clone((object) this.m_discoveryUrls);
    return (object) applicationDescription;
  }
}
