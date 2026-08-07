// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CreateMonitoredItemsRequest
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
public class CreateMonitoredItemsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_subscriptionId;
  private TimestampsToReturn m_timestampsToReturn;
  private MonitoredItemCreateRequestCollection m_itemsToCreate;

  public CreateMonitoredItemsRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_subscriptionId = 0U;
    this.m_timestampsToReturn = TimestampsToReturn.Source;
    this.m_itemsToCreate = new MonitoredItemCreateRequestCollection();
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

  [DataMember(Name = "TimestampsToReturn", IsRequired = false, Order = 3)]
  public TimestampsToReturn TimestampsToReturn
  {
    get => this.m_timestampsToReturn;
    set => this.m_timestampsToReturn = value;
  }

  [DataMember(Name = "ItemsToCreate", IsRequired = false, Order = 4)]
  public MonitoredItemCreateRequestCollection ItemsToCreate
  {
    get => this.m_itemsToCreate;
    set
    {
      this.m_itemsToCreate = value;
      if (value != null)
        return;
      this.m_itemsToCreate = new MonitoredItemCreateRequestCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CreateMonitoredItemsRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateMonitoredItemsRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateMonitoredItemsRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateMonitoredItemsRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteEnumerated("TimestampsToReturn", (Enum) this.TimestampsToReturn);
    encoder.WriteEncodeableArray("ItemsToCreate", (IList<IEncodeable>) this.ItemsToCreate.ToArray(), typeof (MonitoredItemCreateRequest));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.TimestampsToReturn = (TimestampsToReturn) decoder.ReadEnumerated("TimestampsToReturn", typeof (TimestampsToReturn));
    this.ItemsToCreate = (MonitoredItemCreateRequestCollection) (MonitoredItemCreateRequest[]) decoder.ReadEncodeableArray("ItemsToCreate", typeof (MonitoredItemCreateRequest));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CreateMonitoredItemsRequest monitoredItemsRequest && Utils.IsEqual((object) this.m_requestHeader, (object) monitoredItemsRequest.m_requestHeader) && Utils.IsEqual((object) this.m_subscriptionId, (object) monitoredItemsRequest.m_subscriptionId) && Utils.IsEqual((object) this.m_timestampsToReturn, (object) monitoredItemsRequest.m_timestampsToReturn) && Utils.IsEqual((object) this.m_itemsToCreate, (object) monitoredItemsRequest.m_itemsToCreate);
  }

  public virtual object Clone() => (object) (CreateMonitoredItemsRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CreateMonitoredItemsRequest monitoredItemsRequest = (CreateMonitoredItemsRequest) base.MemberwiseClone();
    monitoredItemsRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    monitoredItemsRequest.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    monitoredItemsRequest.m_timestampsToReturn = (TimestampsToReturn) Utils.Clone((object) this.m_timestampsToReturn);
    monitoredItemsRequest.m_itemsToCreate = (MonitoredItemCreateRequestCollection) Utils.Clone((object) this.m_itemsToCreate);
    return (object) monitoredItemsRequest;
  }
}
