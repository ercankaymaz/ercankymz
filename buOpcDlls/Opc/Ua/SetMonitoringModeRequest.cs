// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SetMonitoringModeRequest
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
public class SetMonitoringModeRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_subscriptionId;
  private MonitoringMode m_monitoringMode;
  private UInt32Collection m_monitoredItemIds;

  public SetMonitoringModeRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_subscriptionId = 0U;
    this.m_monitoringMode = MonitoringMode.Disabled;
    this.m_monitoredItemIds = new UInt32Collection();
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

  [DataMember(Name = "MonitoringMode", IsRequired = false, Order = 3)]
  public MonitoringMode MonitoringMode
  {
    get => this.m_monitoringMode;
    set => this.m_monitoringMode = value;
  }

  [DataMember(Name = "MonitoredItemIds", IsRequired = false, Order = 4)]
  public UInt32Collection MonitoredItemIds
  {
    get => this.m_monitoredItemIds;
    set
    {
      this.m_monitoredItemIds = value;
      if (value != null)
        return;
      this.m_monitoredItemIds = new UInt32Collection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SetMonitoringModeRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetMonitoringModeRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetMonitoringModeRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SetMonitoringModeRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteEnumerated("MonitoringMode", (Enum) this.MonitoringMode);
    encoder.WriteUInt32Array("MonitoredItemIds", (IList<uint>) this.MonitoredItemIds);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.MonitoringMode = (MonitoringMode) decoder.ReadEnumerated("MonitoringMode", typeof (MonitoringMode));
    this.MonitoredItemIds = decoder.ReadUInt32Array("MonitoredItemIds");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SetMonitoringModeRequest monitoringModeRequest && Utils.IsEqual((object) this.m_requestHeader, (object) monitoringModeRequest.m_requestHeader) && Utils.IsEqual((object) this.m_subscriptionId, (object) monitoringModeRequest.m_subscriptionId) && Utils.IsEqual((object) this.m_monitoringMode, (object) monitoringModeRequest.m_monitoringMode) && Utils.IsEqual((object) this.m_monitoredItemIds, (object) monitoringModeRequest.m_monitoredItemIds);
  }

  public virtual object Clone() => (object) (SetMonitoringModeRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SetMonitoringModeRequest monitoringModeRequest = (SetMonitoringModeRequest) base.MemberwiseClone();
    monitoringModeRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    monitoringModeRequest.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    monitoringModeRequest.m_monitoringMode = (MonitoringMode) Utils.Clone((object) this.m_monitoringMode);
    monitoringModeRequest.m_monitoredItemIds = (UInt32Collection) Utils.Clone((object) this.m_monitoredItemIds);
    return (object) monitoringModeRequest;
  }
}
