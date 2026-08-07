// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RepublishRequest
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
public class RepublishRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_subscriptionId;
  private uint m_retransmitSequenceNumber;

  public RepublishRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_subscriptionId = 0U;
    this.m_retransmitSequenceNumber = 0U;
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

  [DataMember(Name = "SubscriptionId", IsRequired = false, Order = 2)]
  public uint SubscriptionId
  {
    get => this.m_subscriptionId;
    set => this.m_subscriptionId = value;
  }

  [DataMember(Name = "RetransmitSequenceNumber", IsRequired = false, Order = 3)]
  public uint RetransmitSequenceNumber
  {
    get => this.m_retransmitSequenceNumber;
    set => this.m_retransmitSequenceNumber = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RepublishRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RepublishRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RepublishRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RepublishRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteUInt32("RetransmitSequenceNumber", this.RetransmitSequenceNumber);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.RetransmitSequenceNumber = decoder.ReadUInt32("RetransmitSequenceNumber");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RepublishRequest republishRequest && Utils.IsEqual((object) this.m_requestHeader, (object) republishRequest.m_requestHeader) && Utils.IsEqual((object) this.m_subscriptionId, (object) republishRequest.m_subscriptionId) && Utils.IsEqual((object) this.m_retransmitSequenceNumber, (object) republishRequest.m_retransmitSequenceNumber);
  }

  public virtual object Clone() => (object) (RepublishRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RepublishRequest republishRequest = (RepublishRequest) base.MemberwiseClone();
    republishRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    republishRequest.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    republishRequest.m_retransmitSequenceNumber = (uint) Utils.Clone((object) this.m_retransmitSequenceNumber);
    return (object) republishRequest;
  }
}
