// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SetPublishingModeRequest
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
public class SetPublishingModeRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private bool m_publishingEnabled;
  private UInt32Collection m_subscriptionIds;

  public SetPublishingModeRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_publishingEnabled = true;
    this.m_subscriptionIds = new UInt32Collection();
  }

  [DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
  public RequestHeader RequestHeader
  {
    get => this.m_requestHeader;
    set
    {
      this.m_requestHeader = value;
      if (value != null)
        return;
      this.m_requestHeader = new RequestHeader();
    }
  }

  [DataMember(Name = "PublishingEnabled", IsRequired = false, Order = 2)]
  public bool PublishingEnabled
  {
    get => this.m_publishingEnabled;
    set => this.m_publishingEnabled = value;
  }

  [DataMember(Name = "SubscriptionIds", IsRequired = false, Order = 3)]
  public UInt32Collection SubscriptionIds
  {
    get => this.m_subscriptionIds;
    set
    {
      this.m_subscriptionIds = value;
      if (value != null)
        return;
      this.m_subscriptionIds = new UInt32Collection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SetPublishingModeRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetPublishingModeRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetPublishingModeRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetPublishingModeRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteBoolean("PublishingEnabled", this.PublishingEnabled);
    encoder.WriteUInt32Array("SubscriptionIds", (IList<uint>) this.SubscriptionIds);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.PublishingEnabled = decoder.ReadBoolean("PublishingEnabled");
    this.SubscriptionIds = decoder.ReadUInt32Array("SubscriptionIds");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SetPublishingModeRequest publishingModeRequest && Utils.IsEqual((object) this.m_requestHeader, (object) publishingModeRequest.m_requestHeader) && Utils.IsEqual((object) this.m_publishingEnabled, (object) publishingModeRequest.m_publishingEnabled) && Utils.IsEqual((object) this.m_subscriptionIds, (object) publishingModeRequest.m_subscriptionIds);
  }

  public virtual object Clone() => (object) (SetPublishingModeRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SetPublishingModeRequest publishingModeRequest = (SetPublishingModeRequest) base.MemberwiseClone();
    publishingModeRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    publishingModeRequest.m_publishingEnabled = (bool) Utils.Clone((object) this.m_publishingEnabled);
    publishingModeRequest.m_subscriptionIds = (UInt32Collection) Utils.Clone((object) this.m_subscriptionIds);
    return (object) publishingModeRequest;
  }
}
