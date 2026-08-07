// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransferSubscriptionsRequest
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
public class TransferSubscriptionsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private UInt32Collection m_subscriptionIds;
  private bool m_sendInitialValues;

  public TransferSubscriptionsRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_subscriptionIds = new UInt32Collection();
    this.m_sendInitialValues = true;
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

  [DataMember(Name = "SubscriptionIds", IsRequired = false, Order = 2)]
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

  [DataMember(Name = "SendInitialValues", IsRequired = false, Order = 3)]
  public bool SendInitialValues
  {
    get => this.m_sendInitialValues;
    set => this.m_sendInitialValues = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.TransferSubscriptionsRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TransferSubscriptionsRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TransferSubscriptionsRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TransferSubscriptionsRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32Array("SubscriptionIds", (IList<uint>) this.SubscriptionIds);
    encoder.WriteBoolean("SendInitialValues", this.SendInitialValues);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.SubscriptionIds = decoder.ReadUInt32Array("SubscriptionIds");
    this.SendInitialValues = decoder.ReadBoolean("SendInitialValues");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is TransferSubscriptionsRequest subscriptionsRequest && Utils.IsEqual((object) this.m_requestHeader, (object) subscriptionsRequest.m_requestHeader) && Utils.IsEqual((object) this.m_subscriptionIds, (object) subscriptionsRequest.m_subscriptionIds) && Utils.IsEqual((object) this.m_sendInitialValues, (object) subscriptionsRequest.m_sendInitialValues);
  }

  public virtual object Clone() => (object) (TransferSubscriptionsRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TransferSubscriptionsRequest subscriptionsRequest = (TransferSubscriptionsRequest) base.MemberwiseClone();
    subscriptionsRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    subscriptionsRequest.m_subscriptionIds = (UInt32Collection) Utils.Clone((object) this.m_subscriptionIds);
    subscriptionsRequest.m_sendInitialValues = (bool) Utils.Clone((object) this.m_sendInitialValues);
    return (object) subscriptionsRequest;
  }
}
