// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ModifySubscriptionRequest
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
public class ModifySubscriptionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_subscriptionId;
  private double m_requestedPublishingInterval;
  private uint m_requestedLifetimeCount;
  private uint m_requestedMaxKeepAliveCount;
  private uint m_maxNotificationsPerPublish;
  private byte m_priority;

  public ModifySubscriptionRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_subscriptionId = 0U;
    this.m_requestedPublishingInterval = 0.0;
    this.m_requestedLifetimeCount = 0U;
    this.m_requestedMaxKeepAliveCount = 0U;
    this.m_maxNotificationsPerPublish = 0U;
    this.m_priority = (byte) 0;
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

  [DataMember(Name = "RequestedPublishingInterval", IsRequired = false, Order = 3)]
  public double RequestedPublishingInterval
  {
    get => this.m_requestedPublishingInterval;
    set => this.m_requestedPublishingInterval = value;
  }

  [DataMember(Name = "RequestedLifetimeCount", IsRequired = false, Order = 4)]
  public uint RequestedLifetimeCount
  {
    get => this.m_requestedLifetimeCount;
    set => this.m_requestedLifetimeCount = value;
  }

  [DataMember(Name = "RequestedMaxKeepAliveCount", IsRequired = false, Order = 5)]
  public uint RequestedMaxKeepAliveCount
  {
    get => this.m_requestedMaxKeepAliveCount;
    set => this.m_requestedMaxKeepAliveCount = value;
  }

  [DataMember(Name = "MaxNotificationsPerPublish", IsRequired = false, Order = 6)]
  public uint MaxNotificationsPerPublish
  {
    get => this.m_maxNotificationsPerPublish;
    set => this.m_maxNotificationsPerPublish = value;
  }

  [DataMember(Name = "Priority", IsRequired = false, Order = 7)]
  public byte Priority
  {
    get => this.m_priority;
    set => this.m_priority = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ModifySubscriptionRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifySubscriptionRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifySubscriptionRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifySubscriptionRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteDouble("RequestedPublishingInterval", this.RequestedPublishingInterval);
    encoder.WriteUInt32("RequestedLifetimeCount", this.RequestedLifetimeCount);
    encoder.WriteUInt32("RequestedMaxKeepAliveCount", this.RequestedMaxKeepAliveCount);
    encoder.WriteUInt32("MaxNotificationsPerPublish", this.MaxNotificationsPerPublish);
    encoder.WriteByte("Priority", this.Priority);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.RequestedPublishingInterval = decoder.ReadDouble("RequestedPublishingInterval");
    this.RequestedLifetimeCount = decoder.ReadUInt32("RequestedLifetimeCount");
    this.RequestedMaxKeepAliveCount = decoder.ReadUInt32("RequestedMaxKeepAliveCount");
    this.MaxNotificationsPerPublish = decoder.ReadUInt32("MaxNotificationsPerPublish");
    this.Priority = decoder.ReadByte("Priority");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ModifySubscriptionRequest subscriptionRequest && Utils.IsEqual((object) this.m_requestHeader, (object) subscriptionRequest.m_requestHeader) && Utils.IsEqual((object) this.m_subscriptionId, (object) subscriptionRequest.m_subscriptionId) && Utils.IsEqual((object) this.m_requestedPublishingInterval, (object) subscriptionRequest.m_requestedPublishingInterval) && Utils.IsEqual((object) this.m_requestedLifetimeCount, (object) subscriptionRequest.m_requestedLifetimeCount) && Utils.IsEqual((object) this.m_requestedMaxKeepAliveCount, (object) subscriptionRequest.m_requestedMaxKeepAliveCount) && Utils.IsEqual((object) this.m_maxNotificationsPerPublish, (object) subscriptionRequest.m_maxNotificationsPerPublish) && Utils.IsEqual((object) this.m_priority, (object) subscriptionRequest.m_priority);
  }

  public virtual object Clone() => (object) (ModifySubscriptionRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ModifySubscriptionRequest subscriptionRequest = (ModifySubscriptionRequest) base.MemberwiseClone();
    subscriptionRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    subscriptionRequest.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    subscriptionRequest.m_requestedPublishingInterval = (double) Utils.Clone((object) this.m_requestedPublishingInterval);
    subscriptionRequest.m_requestedLifetimeCount = (uint) Utils.Clone((object) this.m_requestedLifetimeCount);
    subscriptionRequest.m_requestedMaxKeepAliveCount = (uint) Utils.Clone((object) this.m_requestedMaxKeepAliveCount);
    subscriptionRequest.m_maxNotificationsPerPublish = (uint) Utils.Clone((object) this.m_maxNotificationsPerPublish);
    subscriptionRequest.m_priority = (byte) Utils.Clone((object) this.m_priority);
    return (object) subscriptionRequest;
  }
}
