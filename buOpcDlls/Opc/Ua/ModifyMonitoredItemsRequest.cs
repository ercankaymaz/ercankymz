// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ModifyMonitoredItemsRequest
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
public class ModifyMonitoredItemsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_subscriptionId;
  private TimestampsToReturn m_timestampsToReturn;
  private MonitoredItemModifyRequestCollection m_itemsToModify;

  public ModifyMonitoredItemsRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_subscriptionId = 0U;
    this.m_timestampsToReturn = TimestampsToReturn.Source;
    this.m_itemsToModify = new MonitoredItemModifyRequestCollection();
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

  [DataMember(Name = "ItemsToModify", IsRequired = false, Order = 4)]
  public MonitoredItemModifyRequestCollection ItemsToModify
  {
    get => this.m_itemsToModify;
    set
    {
      this.m_itemsToModify = value;
      if (value != null)
        return;
      this.m_itemsToModify = new MonitoredItemModifyRequestCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ModifyMonitoredItemsRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifyMonitoredItemsRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifyMonitoredItemsRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifyMonitoredItemsRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteEnumerated("TimestampsToReturn", (Enum) this.TimestampsToReturn);
    encoder.WriteEncodeableArray("ItemsToModify", (IList<IEncodeable>) this.ItemsToModify.ToArray(), typeof (MonitoredItemModifyRequest));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.TimestampsToReturn = (TimestampsToReturn) decoder.ReadEnumerated("TimestampsToReturn", typeof (TimestampsToReturn));
    this.ItemsToModify = (MonitoredItemModifyRequestCollection) (MonitoredItemModifyRequest[]) decoder.ReadEncodeableArray("ItemsToModify", typeof (MonitoredItemModifyRequest));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ModifyMonitoredItemsRequest monitoredItemsRequest && Utils.IsEqual((object) this.m_requestHeader, (object) monitoredItemsRequest.m_requestHeader) && Utils.IsEqual((object) this.m_subscriptionId, (object) monitoredItemsRequest.m_subscriptionId) && Utils.IsEqual((object) this.m_timestampsToReturn, (object) monitoredItemsRequest.m_timestampsToReturn) && Utils.IsEqual((object) this.m_itemsToModify, (object) monitoredItemsRequest.m_itemsToModify);
  }

  public virtual object Clone() => (object) (ModifyMonitoredItemsRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ModifyMonitoredItemsRequest monitoredItemsRequest = (ModifyMonitoredItemsRequest) base.MemberwiseClone();
    monitoredItemsRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    monitoredItemsRequest.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    monitoredItemsRequest.m_timestampsToReturn = (TimestampsToReturn) Utils.Clone((object) this.m_timestampsToReturn);
    monitoredItemsRequest.m_itemsToModify = (MonitoredItemModifyRequestCollection) Utils.Clone((object) this.m_itemsToModify);
    return (object) monitoredItemsRequest;
  }
}
