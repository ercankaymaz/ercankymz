// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SetTriggeringRequest
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
public class SetTriggeringRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_subscriptionId;
  private uint m_triggeringItemId;
  private UInt32Collection m_linksToAdd;
  private UInt32Collection m_linksToRemove;

  public SetTriggeringRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_subscriptionId = 0U;
    this.m_triggeringItemId = 0U;
    this.m_linksToAdd = new UInt32Collection();
    this.m_linksToRemove = new UInt32Collection();
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

  [DataMember(Name = "TriggeringItemId", IsRequired = false, Order = 3)]
  public uint TriggeringItemId
  {
    get => this.m_triggeringItemId;
    set => this.m_triggeringItemId = value;
  }

  [DataMember(Name = "LinksToAdd", IsRequired = false, Order = 4)]
  public UInt32Collection LinksToAdd
  {
    get => this.m_linksToAdd;
    set
    {
      this.m_linksToAdd = value;
      if (value != null)
        return;
      this.m_linksToAdd = new UInt32Collection();
    }
  }

  [DataMember(Name = "LinksToRemove", IsRequired = false, Order = 5)]
  public UInt32Collection LinksToRemove
  {
    get => this.m_linksToRemove;
    set
    {
      this.m_linksToRemove = value;
      if (value != null)
        return;
      this.m_linksToRemove = new UInt32Collection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SetTriggeringRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetTriggeringRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetTriggeringRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetTriggeringRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteUInt32("TriggeringItemId", this.TriggeringItemId);
    encoder.WriteUInt32Array("LinksToAdd", (IList<uint>) this.LinksToAdd);
    encoder.WriteUInt32Array("LinksToRemove", (IList<uint>) this.LinksToRemove);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.TriggeringItemId = decoder.ReadUInt32("TriggeringItemId");
    this.LinksToAdd = decoder.ReadUInt32Array("LinksToAdd");
    this.LinksToRemove = decoder.ReadUInt32Array("LinksToRemove");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SetTriggeringRequest triggeringRequest && Utils.IsEqual((object) this.m_requestHeader, (object) triggeringRequest.m_requestHeader) && Utils.IsEqual((object) this.m_subscriptionId, (object) triggeringRequest.m_subscriptionId) && Utils.IsEqual((object) this.m_triggeringItemId, (object) triggeringRequest.m_triggeringItemId) && Utils.IsEqual((object) this.m_linksToAdd, (object) triggeringRequest.m_linksToAdd) && Utils.IsEqual((object) this.m_linksToRemove, (object) triggeringRequest.m_linksToRemove);
  }

  public virtual object Clone() => (object) (SetTriggeringRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SetTriggeringRequest triggeringRequest = (SetTriggeringRequest) base.MemberwiseClone();
    triggeringRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    triggeringRequest.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    triggeringRequest.m_triggeringItemId = (uint) Utils.Clone((object) this.m_triggeringItemId);
    triggeringRequest.m_linksToAdd = (UInt32Collection) Utils.Clone((object) this.m_linksToAdd);
    triggeringRequest.m_linksToRemove = (UInt32Collection) Utils.Clone((object) this.m_linksToRemove);
    return (object) triggeringRequest;
  }
}
