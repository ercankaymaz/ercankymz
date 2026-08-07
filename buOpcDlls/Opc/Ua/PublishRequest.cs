// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishRequest
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
public class PublishRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private SubscriptionAcknowledgementCollection m_subscriptionAcknowledgements;

  public PublishRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_subscriptionAcknowledgements = new SubscriptionAcknowledgementCollection();
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

  [DataMember(Name = "SubscriptionAcknowledgements", IsRequired = false, Order = 2)]
  public SubscriptionAcknowledgementCollection SubscriptionAcknowledgements
  {
    get => this.m_subscriptionAcknowledgements;
    set
    {
      this.m_subscriptionAcknowledgements = value;
      if (value != null)
        return;
      this.m_subscriptionAcknowledgements = new SubscriptionAcknowledgementCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PublishRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeableArray("SubscriptionAcknowledgements", (IList<IEncodeable>) this.SubscriptionAcknowledgements.ToArray(), typeof (SubscriptionAcknowledgement));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.SubscriptionAcknowledgements = (SubscriptionAcknowledgementCollection) (SubscriptionAcknowledgement[]) decoder.ReadEncodeableArray("SubscriptionAcknowledgements", typeof (SubscriptionAcknowledgement));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is PublishRequest publishRequest && Utils.IsEqual((object) this.m_requestHeader, (object) publishRequest.m_requestHeader) && Utils.IsEqual((object) this.m_subscriptionAcknowledgements, (object) publishRequest.m_subscriptionAcknowledgements);
  }

  public virtual object Clone() => (object) (PublishRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishRequest publishRequest = (PublishRequest) base.MemberwiseClone();
    publishRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    publishRequest.m_subscriptionAcknowledgements = (SubscriptionAcknowledgementCollection) Utils.Clone((object) this.m_subscriptionAcknowledgements);
    return (object) publishRequest;
  }
}
