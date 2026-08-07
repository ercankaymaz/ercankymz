// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionDiagnosticsDataType
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
public class SessionDiagnosticsDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_sessionId;
  private string m_sessionName;
  private ApplicationDescription m_clientDescription;
  private string m_serverUri;
  private string m_endpointUrl;
  private StringCollection m_localeIds;
  private double m_actualSessionTimeout;
  private uint m_maxResponseMessageSize;
  private DateTime m_clientConnectionTime;
  private DateTime m_clientLastContactTime;
  private uint m_currentSubscriptionsCount;
  private uint m_currentMonitoredItemsCount;
  private uint m_currentPublishRequestsInQueue;
  private ServiceCounterDataType m_totalRequestCount;
  private uint m_unauthorizedRequestCount;
  private ServiceCounterDataType m_readCount;
  private ServiceCounterDataType m_historyReadCount;
  private ServiceCounterDataType m_writeCount;
  private ServiceCounterDataType m_historyUpdateCount;
  private ServiceCounterDataType m_callCount;
  private ServiceCounterDataType m_createMonitoredItemsCount;
  private ServiceCounterDataType m_modifyMonitoredItemsCount;
  private ServiceCounterDataType m_setMonitoringModeCount;
  private ServiceCounterDataType m_setTriggeringCount;
  private ServiceCounterDataType m_deleteMonitoredItemsCount;
  private ServiceCounterDataType m_createSubscriptionCount;
  private ServiceCounterDataType m_modifySubscriptionCount;
  private ServiceCounterDataType m_setPublishingModeCount;
  private ServiceCounterDataType m_publishCount;
  private ServiceCounterDataType m_republishCount;
  private ServiceCounterDataType m_transferSubscriptionsCount;
  private ServiceCounterDataType m_deleteSubscriptionsCount;
  private ServiceCounterDataType m_addNodesCount;
  private ServiceCounterDataType m_addReferencesCount;
  private ServiceCounterDataType m_deleteNodesCount;
  private ServiceCounterDataType m_deleteReferencesCount;
  private ServiceCounterDataType m_browseCount;
  private ServiceCounterDataType m_browseNextCount;
  private ServiceCounterDataType m_translateBrowsePathsToNodeIdsCount;
  private ServiceCounterDataType m_queryFirstCount;
  private ServiceCounterDataType m_queryNextCount;
  private ServiceCounterDataType m_registerNodesCount;
  private ServiceCounterDataType m_unregisterNodesCount;

  public SessionDiagnosticsDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_sessionId = (NodeId) null;
    this.m_sessionName = (string) null;
    this.m_clientDescription = new ApplicationDescription();
    this.m_serverUri = (string) null;
    this.m_endpointUrl = (string) null;
    this.m_localeIds = new StringCollection();
    this.m_actualSessionTimeout = 0.0;
    this.m_maxResponseMessageSize = 0U;
    this.m_clientConnectionTime = DateTime.MinValue;
    this.m_clientLastContactTime = DateTime.MinValue;
    this.m_currentSubscriptionsCount = 0U;
    this.m_currentMonitoredItemsCount = 0U;
    this.m_currentPublishRequestsInQueue = 0U;
    this.m_totalRequestCount = new ServiceCounterDataType();
    this.m_unauthorizedRequestCount = 0U;
    this.m_readCount = new ServiceCounterDataType();
    this.m_historyReadCount = new ServiceCounterDataType();
    this.m_writeCount = new ServiceCounterDataType();
    this.m_historyUpdateCount = new ServiceCounterDataType();
    this.m_callCount = new ServiceCounterDataType();
    this.m_createMonitoredItemsCount = new ServiceCounterDataType();
    this.m_modifyMonitoredItemsCount = new ServiceCounterDataType();
    this.m_setMonitoringModeCount = new ServiceCounterDataType();
    this.m_setTriggeringCount = new ServiceCounterDataType();
    this.m_deleteMonitoredItemsCount = new ServiceCounterDataType();
    this.m_createSubscriptionCount = new ServiceCounterDataType();
    this.m_modifySubscriptionCount = new ServiceCounterDataType();
    this.m_setPublishingModeCount = new ServiceCounterDataType();
    this.m_publishCount = new ServiceCounterDataType();
    this.m_republishCount = new ServiceCounterDataType();
    this.m_transferSubscriptionsCount = new ServiceCounterDataType();
    this.m_deleteSubscriptionsCount = new ServiceCounterDataType();
    this.m_addNodesCount = new ServiceCounterDataType();
    this.m_addReferencesCount = new ServiceCounterDataType();
    this.m_deleteNodesCount = new ServiceCounterDataType();
    this.m_deleteReferencesCount = new ServiceCounterDataType();
    this.m_browseCount = new ServiceCounterDataType();
    this.m_browseNextCount = new ServiceCounterDataType();
    this.m_translateBrowsePathsToNodeIdsCount = new ServiceCounterDataType();
    this.m_queryFirstCount = new ServiceCounterDataType();
    this.m_queryNextCount = new ServiceCounterDataType();
    this.m_registerNodesCount = new ServiceCounterDataType();
    this.m_unregisterNodesCount = new ServiceCounterDataType();
  }

  [DataMember(Name = "SessionId", IsRequired = false, Order = 1)]
  public NodeId SessionId
  {
    get => this.m_sessionId;
    set => this.m_sessionId = value;
  }

  [DataMember(Name = "SessionName", IsRequired = false, Order = 2)]
  public string SessionName
  {
    get => this.m_sessionName;
    set => this.m_sessionName = value;
  }

  [DataMember(Name = "ClientDescription", IsRequired = false, Order = 3)]
  public ApplicationDescription ClientDescription
  {
    get => this.m_clientDescription;
    set
    {
      this.m_clientDescription = value;
      if (value != null)
        return;
      this.m_clientDescription = new ApplicationDescription();
    }
  }

  [DataMember(Name = "ServerUri", IsRequired = false, Order = 4)]
  public string ServerUri
  {
    get => this.m_serverUri;
    set => this.m_serverUri = value;
  }

  [DataMember(Name = "EndpointUrl", IsRequired = false, Order = 5)]
  public string EndpointUrl
  {
    get => this.m_endpointUrl;
    set => this.m_endpointUrl = value;
  }

  [DataMember(Name = "LocaleIds", IsRequired = false, Order = 6)]
  public StringCollection LocaleIds
  {
    get => this.m_localeIds;
    set
    {
      this.m_localeIds = value;
      if (value != null)
        return;
      this.m_localeIds = new StringCollection();
    }
  }

  [DataMember(Name = "ActualSessionTimeout", IsRequired = false, Order = 7)]
  public double ActualSessionTimeout
  {
    get => this.m_actualSessionTimeout;
    set => this.m_actualSessionTimeout = value;
  }

  [DataMember(Name = "MaxResponseMessageSize", IsRequired = false, Order = 8)]
  public uint MaxResponseMessageSize
  {
    get => this.m_maxResponseMessageSize;
    set => this.m_maxResponseMessageSize = value;
  }

  [DataMember(Name = "ClientConnectionTime", IsRequired = false, Order = 9)]
  public DateTime ClientConnectionTime
  {
    get => this.m_clientConnectionTime;
    set => this.m_clientConnectionTime = value;
  }

  [DataMember(Name = "ClientLastContactTime", IsRequired = false, Order = 10)]
  public DateTime ClientLastContactTime
  {
    get => this.m_clientLastContactTime;
    set => this.m_clientLastContactTime = value;
  }

  [DataMember(Name = "CurrentSubscriptionsCount", IsRequired = false, Order = 11)]
  public uint CurrentSubscriptionsCount
  {
    get => this.m_currentSubscriptionsCount;
    set => this.m_currentSubscriptionsCount = value;
  }

  [DataMember(Name = "CurrentMonitoredItemsCount", IsRequired = false, Order = 12)]
  public uint CurrentMonitoredItemsCount
  {
    get => this.m_currentMonitoredItemsCount;
    set => this.m_currentMonitoredItemsCount = value;
  }

  [DataMember(Name = "CurrentPublishRequestsInQueue", IsRequired = false, Order = 13)]
  public uint CurrentPublishRequestsInQueue
  {
    get => this.m_currentPublishRequestsInQueue;
    set => this.m_currentPublishRequestsInQueue = value;
  }

  [DataMember(Name = "TotalRequestCount", IsRequired = false, Order = 14)]
  public ServiceCounterDataType TotalRequestCount
  {
    get => this.m_totalRequestCount;
    set
    {
      this.m_totalRequestCount = value;
      if (value != null)
        return;
      this.m_totalRequestCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "UnauthorizedRequestCount", IsRequired = false, Order = 15)]
  public uint UnauthorizedRequestCount
  {
    get => this.m_unauthorizedRequestCount;
    set => this.m_unauthorizedRequestCount = value;
  }

  [DataMember(Name = "ReadCount", IsRequired = false, Order = 16 /*0x10*/)]
  public ServiceCounterDataType ReadCount
  {
    get => this.m_readCount;
    set
    {
      this.m_readCount = value;
      if (value != null)
        return;
      this.m_readCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "HistoryReadCount", IsRequired = false, Order = 17)]
  public ServiceCounterDataType HistoryReadCount
  {
    get => this.m_historyReadCount;
    set
    {
      this.m_historyReadCount = value;
      if (value != null)
        return;
      this.m_historyReadCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "WriteCount", IsRequired = false, Order = 18)]
  public ServiceCounterDataType WriteCount
  {
    get => this.m_writeCount;
    set
    {
      this.m_writeCount = value;
      if (value != null)
        return;
      this.m_writeCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "HistoryUpdateCount", IsRequired = false, Order = 19)]
  public ServiceCounterDataType HistoryUpdateCount
  {
    get => this.m_historyUpdateCount;
    set
    {
      this.m_historyUpdateCount = value;
      if (value != null)
        return;
      this.m_historyUpdateCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "CallCount", IsRequired = false, Order = 20)]
  public ServiceCounterDataType CallCount
  {
    get => this.m_callCount;
    set
    {
      this.m_callCount = value;
      if (value != null)
        return;
      this.m_callCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "CreateMonitoredItemsCount", IsRequired = false, Order = 21)]
  public ServiceCounterDataType CreateMonitoredItemsCount
  {
    get => this.m_createMonitoredItemsCount;
    set
    {
      this.m_createMonitoredItemsCount = value;
      if (value != null)
        return;
      this.m_createMonitoredItemsCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "ModifyMonitoredItemsCount", IsRequired = false, Order = 22)]
  public ServiceCounterDataType ModifyMonitoredItemsCount
  {
    get => this.m_modifyMonitoredItemsCount;
    set
    {
      this.m_modifyMonitoredItemsCount = value;
      if (value != null)
        return;
      this.m_modifyMonitoredItemsCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "SetMonitoringModeCount", IsRequired = false, Order = 23)]
  public ServiceCounterDataType SetMonitoringModeCount
  {
    get => this.m_setMonitoringModeCount;
    set
    {
      this.m_setMonitoringModeCount = value;
      if (value != null)
        return;
      this.m_setMonitoringModeCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "SetTriggeringCount", IsRequired = false, Order = 24)]
  public ServiceCounterDataType SetTriggeringCount
  {
    get => this.m_setTriggeringCount;
    set
    {
      this.m_setTriggeringCount = value;
      if (value != null)
        return;
      this.m_setTriggeringCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "DeleteMonitoredItemsCount", IsRequired = false, Order = 25)]
  public ServiceCounterDataType DeleteMonitoredItemsCount
  {
    get => this.m_deleteMonitoredItemsCount;
    set
    {
      this.m_deleteMonitoredItemsCount = value;
      if (value != null)
        return;
      this.m_deleteMonitoredItemsCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "CreateSubscriptionCount", IsRequired = false, Order = 26)]
  public ServiceCounterDataType CreateSubscriptionCount
  {
    get => this.m_createSubscriptionCount;
    set
    {
      this.m_createSubscriptionCount = value;
      if (value != null)
        return;
      this.m_createSubscriptionCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "ModifySubscriptionCount", IsRequired = false, Order = 27)]
  public ServiceCounterDataType ModifySubscriptionCount
  {
    get => this.m_modifySubscriptionCount;
    set
    {
      this.m_modifySubscriptionCount = value;
      if (value != null)
        return;
      this.m_modifySubscriptionCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "SetPublishingModeCount", IsRequired = false, Order = 28)]
  public ServiceCounterDataType SetPublishingModeCount
  {
    get => this.m_setPublishingModeCount;
    set
    {
      this.m_setPublishingModeCount = value;
      if (value != null)
        return;
      this.m_setPublishingModeCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "PublishCount", IsRequired = false, Order = 29)]
  public ServiceCounterDataType PublishCount
  {
    get => this.m_publishCount;
    set
    {
      this.m_publishCount = value;
      if (value != null)
        return;
      this.m_publishCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "RepublishCount", IsRequired = false, Order = 30)]
  public ServiceCounterDataType RepublishCount
  {
    get => this.m_republishCount;
    set
    {
      this.m_republishCount = value;
      if (value != null)
        return;
      this.m_republishCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "TransferSubscriptionsCount", IsRequired = false, Order = 31 /*0x1F*/)]
  public ServiceCounterDataType TransferSubscriptionsCount
  {
    get => this.m_transferSubscriptionsCount;
    set
    {
      this.m_transferSubscriptionsCount = value;
      if (value != null)
        return;
      this.m_transferSubscriptionsCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "DeleteSubscriptionsCount", IsRequired = false, Order = 32 /*0x20*/)]
  public ServiceCounterDataType DeleteSubscriptionsCount
  {
    get => this.m_deleteSubscriptionsCount;
    set
    {
      this.m_deleteSubscriptionsCount = value;
      if (value != null)
        return;
      this.m_deleteSubscriptionsCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "AddNodesCount", IsRequired = false, Order = 33)]
  public ServiceCounterDataType AddNodesCount
  {
    get => this.m_addNodesCount;
    set
    {
      this.m_addNodesCount = value;
      if (value != null)
        return;
      this.m_addNodesCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "AddReferencesCount", IsRequired = false, Order = 34)]
  public ServiceCounterDataType AddReferencesCount
  {
    get => this.m_addReferencesCount;
    set
    {
      this.m_addReferencesCount = value;
      if (value != null)
        return;
      this.m_addReferencesCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "DeleteNodesCount", IsRequired = false, Order = 35)]
  public ServiceCounterDataType DeleteNodesCount
  {
    get => this.m_deleteNodesCount;
    set
    {
      this.m_deleteNodesCount = value;
      if (value != null)
        return;
      this.m_deleteNodesCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "DeleteReferencesCount", IsRequired = false, Order = 36)]
  public ServiceCounterDataType DeleteReferencesCount
  {
    get => this.m_deleteReferencesCount;
    set
    {
      this.m_deleteReferencesCount = value;
      if (value != null)
        return;
      this.m_deleteReferencesCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "BrowseCount", IsRequired = false, Order = 37)]
  public ServiceCounterDataType BrowseCount
  {
    get => this.m_browseCount;
    set
    {
      this.m_browseCount = value;
      if (value != null)
        return;
      this.m_browseCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "BrowseNextCount", IsRequired = false, Order = 38)]
  public ServiceCounterDataType BrowseNextCount
  {
    get => this.m_browseNextCount;
    set
    {
      this.m_browseNextCount = value;
      if (value != null)
        return;
      this.m_browseNextCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "TranslateBrowsePathsToNodeIdsCount", IsRequired = false, Order = 39)]
  public ServiceCounterDataType TranslateBrowsePathsToNodeIdsCount
  {
    get => this.m_translateBrowsePathsToNodeIdsCount;
    set
    {
      this.m_translateBrowsePathsToNodeIdsCount = value;
      if (value != null)
        return;
      this.m_translateBrowsePathsToNodeIdsCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "QueryFirstCount", IsRequired = false, Order = 40)]
  public ServiceCounterDataType QueryFirstCount
  {
    get => this.m_queryFirstCount;
    set
    {
      this.m_queryFirstCount = value;
      if (value != null)
        return;
      this.m_queryFirstCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "QueryNextCount", IsRequired = false, Order = 41)]
  public ServiceCounterDataType QueryNextCount
  {
    get => this.m_queryNextCount;
    set
    {
      this.m_queryNextCount = value;
      if (value != null)
        return;
      this.m_queryNextCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "RegisterNodesCount", IsRequired = false, Order = 42)]
  public ServiceCounterDataType RegisterNodesCount
  {
    get => this.m_registerNodesCount;
    set
    {
      this.m_registerNodesCount = value;
      if (value != null)
        return;
      this.m_registerNodesCount = new ServiceCounterDataType();
    }
  }

  [DataMember(Name = "UnregisterNodesCount", IsRequired = false, Order = 43)]
  public ServiceCounterDataType UnregisterNodesCount
  {
    get => this.m_unregisterNodesCount;
    set
    {
      this.m_unregisterNodesCount = value;
      if (value != null)
        return;
      this.m_unregisterNodesCount = new ServiceCounterDataType();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SessionDiagnosticsDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionDiagnosticsDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionDiagnosticsDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionDiagnosticsDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("SessionId", this.SessionId);
    encoder.WriteString("SessionName", this.SessionName);
    encoder.WriteEncodeable("ClientDescription", (IEncodeable) this.ClientDescription, typeof (ApplicationDescription));
    encoder.WriteString("ServerUri", this.ServerUri);
    encoder.WriteString("EndpointUrl", this.EndpointUrl);
    encoder.WriteStringArray("LocaleIds", (IList<string>) this.LocaleIds);
    encoder.WriteDouble("ActualSessionTimeout", this.ActualSessionTimeout);
    encoder.WriteUInt32("MaxResponseMessageSize", this.MaxResponseMessageSize);
    encoder.WriteDateTime("ClientConnectionTime", this.ClientConnectionTime);
    encoder.WriteDateTime("ClientLastContactTime", this.ClientLastContactTime);
    encoder.WriteUInt32("CurrentSubscriptionsCount", this.CurrentSubscriptionsCount);
    encoder.WriteUInt32("CurrentMonitoredItemsCount", this.CurrentMonitoredItemsCount);
    encoder.WriteUInt32("CurrentPublishRequestsInQueue", this.CurrentPublishRequestsInQueue);
    encoder.WriteEncodeable("TotalRequestCount", (IEncodeable) this.TotalRequestCount, typeof (ServiceCounterDataType));
    encoder.WriteUInt32("UnauthorizedRequestCount", this.UnauthorizedRequestCount);
    encoder.WriteEncodeable("ReadCount", (IEncodeable) this.ReadCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("HistoryReadCount", (IEncodeable) this.HistoryReadCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("WriteCount", (IEncodeable) this.WriteCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("HistoryUpdateCount", (IEncodeable) this.HistoryUpdateCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("CallCount", (IEncodeable) this.CallCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("CreateMonitoredItemsCount", (IEncodeable) this.CreateMonitoredItemsCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("ModifyMonitoredItemsCount", (IEncodeable) this.ModifyMonitoredItemsCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("SetMonitoringModeCount", (IEncodeable) this.SetMonitoringModeCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("SetTriggeringCount", (IEncodeable) this.SetTriggeringCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("DeleteMonitoredItemsCount", (IEncodeable) this.DeleteMonitoredItemsCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("CreateSubscriptionCount", (IEncodeable) this.CreateSubscriptionCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("ModifySubscriptionCount", (IEncodeable) this.ModifySubscriptionCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("SetPublishingModeCount", (IEncodeable) this.SetPublishingModeCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("PublishCount", (IEncodeable) this.PublishCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("RepublishCount", (IEncodeable) this.RepublishCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("TransferSubscriptionsCount", (IEncodeable) this.TransferSubscriptionsCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("DeleteSubscriptionsCount", (IEncodeable) this.DeleteSubscriptionsCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("AddNodesCount", (IEncodeable) this.AddNodesCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("AddReferencesCount", (IEncodeable) this.AddReferencesCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("DeleteNodesCount", (IEncodeable) this.DeleteNodesCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("DeleteReferencesCount", (IEncodeable) this.DeleteReferencesCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("BrowseCount", (IEncodeable) this.BrowseCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("BrowseNextCount", (IEncodeable) this.BrowseNextCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("TranslateBrowsePathsToNodeIdsCount", (IEncodeable) this.TranslateBrowsePathsToNodeIdsCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("QueryFirstCount", (IEncodeable) this.QueryFirstCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("QueryNextCount", (IEncodeable) this.QueryNextCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("RegisterNodesCount", (IEncodeable) this.RegisterNodesCount, typeof (ServiceCounterDataType));
    encoder.WriteEncodeable("UnregisterNodesCount", (IEncodeable) this.UnregisterNodesCount, typeof (ServiceCounterDataType));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SessionId = decoder.ReadNodeId("SessionId");
    this.SessionName = decoder.ReadString("SessionName");
    this.ClientDescription = (ApplicationDescription) decoder.ReadEncodeable("ClientDescription", typeof (ApplicationDescription));
    this.ServerUri = decoder.ReadString("ServerUri");
    this.EndpointUrl = decoder.ReadString("EndpointUrl");
    this.LocaleIds = decoder.ReadStringArray("LocaleIds");
    this.ActualSessionTimeout = decoder.ReadDouble("ActualSessionTimeout");
    this.MaxResponseMessageSize = decoder.ReadUInt32("MaxResponseMessageSize");
    this.ClientConnectionTime = decoder.ReadDateTime("ClientConnectionTime");
    this.ClientLastContactTime = decoder.ReadDateTime("ClientLastContactTime");
    this.CurrentSubscriptionsCount = decoder.ReadUInt32("CurrentSubscriptionsCount");
    this.CurrentMonitoredItemsCount = decoder.ReadUInt32("CurrentMonitoredItemsCount");
    this.CurrentPublishRequestsInQueue = decoder.ReadUInt32("CurrentPublishRequestsInQueue");
    this.TotalRequestCount = (ServiceCounterDataType) decoder.ReadEncodeable("TotalRequestCount", typeof (ServiceCounterDataType));
    this.UnauthorizedRequestCount = decoder.ReadUInt32("UnauthorizedRequestCount");
    this.ReadCount = (ServiceCounterDataType) decoder.ReadEncodeable("ReadCount", typeof (ServiceCounterDataType));
    this.HistoryReadCount = (ServiceCounterDataType) decoder.ReadEncodeable("HistoryReadCount", typeof (ServiceCounterDataType));
    this.WriteCount = (ServiceCounterDataType) decoder.ReadEncodeable("WriteCount", typeof (ServiceCounterDataType));
    this.HistoryUpdateCount = (ServiceCounterDataType) decoder.ReadEncodeable("HistoryUpdateCount", typeof (ServiceCounterDataType));
    this.CallCount = (ServiceCounterDataType) decoder.ReadEncodeable("CallCount", typeof (ServiceCounterDataType));
    this.CreateMonitoredItemsCount = (ServiceCounterDataType) decoder.ReadEncodeable("CreateMonitoredItemsCount", typeof (ServiceCounterDataType));
    this.ModifyMonitoredItemsCount = (ServiceCounterDataType) decoder.ReadEncodeable("ModifyMonitoredItemsCount", typeof (ServiceCounterDataType));
    this.SetMonitoringModeCount = (ServiceCounterDataType) decoder.ReadEncodeable("SetMonitoringModeCount", typeof (ServiceCounterDataType));
    this.SetTriggeringCount = (ServiceCounterDataType) decoder.ReadEncodeable("SetTriggeringCount", typeof (ServiceCounterDataType));
    this.DeleteMonitoredItemsCount = (ServiceCounterDataType) decoder.ReadEncodeable("DeleteMonitoredItemsCount", typeof (ServiceCounterDataType));
    this.CreateSubscriptionCount = (ServiceCounterDataType) decoder.ReadEncodeable("CreateSubscriptionCount", typeof (ServiceCounterDataType));
    this.ModifySubscriptionCount = (ServiceCounterDataType) decoder.ReadEncodeable("ModifySubscriptionCount", typeof (ServiceCounterDataType));
    this.SetPublishingModeCount = (ServiceCounterDataType) decoder.ReadEncodeable("SetPublishingModeCount", typeof (ServiceCounterDataType));
    this.PublishCount = (ServiceCounterDataType) decoder.ReadEncodeable("PublishCount", typeof (ServiceCounterDataType));
    this.RepublishCount = (ServiceCounterDataType) decoder.ReadEncodeable("RepublishCount", typeof (ServiceCounterDataType));
    this.TransferSubscriptionsCount = (ServiceCounterDataType) decoder.ReadEncodeable("TransferSubscriptionsCount", typeof (ServiceCounterDataType));
    this.DeleteSubscriptionsCount = (ServiceCounterDataType) decoder.ReadEncodeable("DeleteSubscriptionsCount", typeof (ServiceCounterDataType));
    this.AddNodesCount = (ServiceCounterDataType) decoder.ReadEncodeable("AddNodesCount", typeof (ServiceCounterDataType));
    this.AddReferencesCount = (ServiceCounterDataType) decoder.ReadEncodeable("AddReferencesCount", typeof (ServiceCounterDataType));
    this.DeleteNodesCount = (ServiceCounterDataType) decoder.ReadEncodeable("DeleteNodesCount", typeof (ServiceCounterDataType));
    this.DeleteReferencesCount = (ServiceCounterDataType) decoder.ReadEncodeable("DeleteReferencesCount", typeof (ServiceCounterDataType));
    this.BrowseCount = (ServiceCounterDataType) decoder.ReadEncodeable("BrowseCount", typeof (ServiceCounterDataType));
    this.BrowseNextCount = (ServiceCounterDataType) decoder.ReadEncodeable("BrowseNextCount", typeof (ServiceCounterDataType));
    this.TranslateBrowsePathsToNodeIdsCount = (ServiceCounterDataType) decoder.ReadEncodeable("TranslateBrowsePathsToNodeIdsCount", typeof (ServiceCounterDataType));
    this.QueryFirstCount = (ServiceCounterDataType) decoder.ReadEncodeable("QueryFirstCount", typeof (ServiceCounterDataType));
    this.QueryNextCount = (ServiceCounterDataType) decoder.ReadEncodeable("QueryNextCount", typeof (ServiceCounterDataType));
    this.RegisterNodesCount = (ServiceCounterDataType) decoder.ReadEncodeable("RegisterNodesCount", typeof (ServiceCounterDataType));
    this.UnregisterNodesCount = (ServiceCounterDataType) decoder.ReadEncodeable("UnregisterNodesCount", typeof (ServiceCounterDataType));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SessionDiagnosticsDataType diagnosticsDataType && Utils.IsEqual((object) this.m_sessionId, (object) diagnosticsDataType.m_sessionId) && Utils.IsEqual((object) this.m_sessionName, (object) diagnosticsDataType.m_sessionName) && Utils.IsEqual((object) this.m_clientDescription, (object) diagnosticsDataType.m_clientDescription) && Utils.IsEqual((object) this.m_serverUri, (object) diagnosticsDataType.m_serverUri) && Utils.IsEqual((object) this.m_endpointUrl, (object) diagnosticsDataType.m_endpointUrl) && Utils.IsEqual((object) this.m_localeIds, (object) diagnosticsDataType.m_localeIds) && Utils.IsEqual((object) this.m_actualSessionTimeout, (object) diagnosticsDataType.m_actualSessionTimeout) && Utils.IsEqual((object) this.m_maxResponseMessageSize, (object) diagnosticsDataType.m_maxResponseMessageSize) && Utils.IsEqual(this.m_clientConnectionTime, diagnosticsDataType.m_clientConnectionTime) && Utils.IsEqual(this.m_clientLastContactTime, diagnosticsDataType.m_clientLastContactTime) && Utils.IsEqual((object) this.m_currentSubscriptionsCount, (object) diagnosticsDataType.m_currentSubscriptionsCount) && Utils.IsEqual((object) this.m_currentMonitoredItemsCount, (object) diagnosticsDataType.m_currentMonitoredItemsCount) && Utils.IsEqual((object) this.m_currentPublishRequestsInQueue, (object) diagnosticsDataType.m_currentPublishRequestsInQueue) && Utils.IsEqual((object) this.m_totalRequestCount, (object) diagnosticsDataType.m_totalRequestCount) && Utils.IsEqual((object) this.m_unauthorizedRequestCount, (object) diagnosticsDataType.m_unauthorizedRequestCount) && Utils.IsEqual((object) this.m_readCount, (object) diagnosticsDataType.m_readCount) && Utils.IsEqual((object) this.m_historyReadCount, (object) diagnosticsDataType.m_historyReadCount) && Utils.IsEqual((object) this.m_writeCount, (object) diagnosticsDataType.m_writeCount) && Utils.IsEqual((object) this.m_historyUpdateCount, (object) diagnosticsDataType.m_historyUpdateCount) && Utils.IsEqual((object) this.m_callCount, (object) diagnosticsDataType.m_callCount) && Utils.IsEqual((object) this.m_createMonitoredItemsCount, (object) diagnosticsDataType.m_createMonitoredItemsCount) && Utils.IsEqual((object) this.m_modifyMonitoredItemsCount, (object) diagnosticsDataType.m_modifyMonitoredItemsCount) && Utils.IsEqual((object) this.m_setMonitoringModeCount, (object) diagnosticsDataType.m_setMonitoringModeCount) && Utils.IsEqual((object) this.m_setTriggeringCount, (object) diagnosticsDataType.m_setTriggeringCount) && Utils.IsEqual((object) this.m_deleteMonitoredItemsCount, (object) diagnosticsDataType.m_deleteMonitoredItemsCount) && Utils.IsEqual((object) this.m_createSubscriptionCount, (object) diagnosticsDataType.m_createSubscriptionCount) && Utils.IsEqual((object) this.m_modifySubscriptionCount, (object) diagnosticsDataType.m_modifySubscriptionCount) && Utils.IsEqual((object) this.m_setPublishingModeCount, (object) diagnosticsDataType.m_setPublishingModeCount) && Utils.IsEqual((object) this.m_publishCount, (object) diagnosticsDataType.m_publishCount) && Utils.IsEqual((object) this.m_republishCount, (object) diagnosticsDataType.m_republishCount) && Utils.IsEqual((object) this.m_transferSubscriptionsCount, (object) diagnosticsDataType.m_transferSubscriptionsCount) && Utils.IsEqual((object) this.m_deleteSubscriptionsCount, (object) diagnosticsDataType.m_deleteSubscriptionsCount) && Utils.IsEqual((object) this.m_addNodesCount, (object) diagnosticsDataType.m_addNodesCount) && Utils.IsEqual((object) this.m_addReferencesCount, (object) diagnosticsDataType.m_addReferencesCount) && Utils.IsEqual((object) this.m_deleteNodesCount, (object) diagnosticsDataType.m_deleteNodesCount) && Utils.IsEqual((object) this.m_deleteReferencesCount, (object) diagnosticsDataType.m_deleteReferencesCount) && Utils.IsEqual((object) this.m_browseCount, (object) diagnosticsDataType.m_browseCount) && Utils.IsEqual((object) this.m_browseNextCount, (object) diagnosticsDataType.m_browseNextCount) && Utils.IsEqual((object) this.m_translateBrowsePathsToNodeIdsCount, (object) diagnosticsDataType.m_translateBrowsePathsToNodeIdsCount) && Utils.IsEqual((object) this.m_queryFirstCount, (object) diagnosticsDataType.m_queryFirstCount) && Utils.IsEqual((object) this.m_queryNextCount, (object) diagnosticsDataType.m_queryNextCount) && Utils.IsEqual((object) this.m_registerNodesCount, (object) diagnosticsDataType.m_registerNodesCount) && Utils.IsEqual((object) this.m_unregisterNodesCount, (object) diagnosticsDataType.m_unregisterNodesCount);
  }

  public virtual object Clone() => (object) (SessionDiagnosticsDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SessionDiagnosticsDataType diagnosticsDataType = (SessionDiagnosticsDataType) base.MemberwiseClone();
    diagnosticsDataType.m_sessionId = (NodeId) Utils.Clone((object) this.m_sessionId);
    diagnosticsDataType.m_sessionName = (string) Utils.Clone((object) this.m_sessionName);
    diagnosticsDataType.m_clientDescription = (ApplicationDescription) Utils.Clone((object) this.m_clientDescription);
    diagnosticsDataType.m_serverUri = (string) Utils.Clone((object) this.m_serverUri);
    diagnosticsDataType.m_endpointUrl = (string) Utils.Clone((object) this.m_endpointUrl);
    diagnosticsDataType.m_localeIds = (StringCollection) Utils.Clone((object) this.m_localeIds);
    diagnosticsDataType.m_actualSessionTimeout = (double) Utils.Clone((object) this.m_actualSessionTimeout);
    diagnosticsDataType.m_maxResponseMessageSize = (uint) Utils.Clone((object) this.m_maxResponseMessageSize);
    diagnosticsDataType.m_clientConnectionTime = (DateTime) Utils.Clone((object) this.m_clientConnectionTime);
    diagnosticsDataType.m_clientLastContactTime = (DateTime) Utils.Clone((object) this.m_clientLastContactTime);
    diagnosticsDataType.m_currentSubscriptionsCount = (uint) Utils.Clone((object) this.m_currentSubscriptionsCount);
    diagnosticsDataType.m_currentMonitoredItemsCount = (uint) Utils.Clone((object) this.m_currentMonitoredItemsCount);
    diagnosticsDataType.m_currentPublishRequestsInQueue = (uint) Utils.Clone((object) this.m_currentPublishRequestsInQueue);
    diagnosticsDataType.m_totalRequestCount = (ServiceCounterDataType) Utils.Clone((object) this.m_totalRequestCount);
    diagnosticsDataType.m_unauthorizedRequestCount = (uint) Utils.Clone((object) this.m_unauthorizedRequestCount);
    diagnosticsDataType.m_readCount = (ServiceCounterDataType) Utils.Clone((object) this.m_readCount);
    diagnosticsDataType.m_historyReadCount = (ServiceCounterDataType) Utils.Clone((object) this.m_historyReadCount);
    diagnosticsDataType.m_writeCount = (ServiceCounterDataType) Utils.Clone((object) this.m_writeCount);
    diagnosticsDataType.m_historyUpdateCount = (ServiceCounterDataType) Utils.Clone((object) this.m_historyUpdateCount);
    diagnosticsDataType.m_callCount = (ServiceCounterDataType) Utils.Clone((object) this.m_callCount);
    diagnosticsDataType.m_createMonitoredItemsCount = (ServiceCounterDataType) Utils.Clone((object) this.m_createMonitoredItemsCount);
    diagnosticsDataType.m_modifyMonitoredItemsCount = (ServiceCounterDataType) Utils.Clone((object) this.m_modifyMonitoredItemsCount);
    diagnosticsDataType.m_setMonitoringModeCount = (ServiceCounterDataType) Utils.Clone((object) this.m_setMonitoringModeCount);
    diagnosticsDataType.m_setTriggeringCount = (ServiceCounterDataType) Utils.Clone((object) this.m_setTriggeringCount);
    diagnosticsDataType.m_deleteMonitoredItemsCount = (ServiceCounterDataType) Utils.Clone((object) this.m_deleteMonitoredItemsCount);
    diagnosticsDataType.m_createSubscriptionCount = (ServiceCounterDataType) Utils.Clone((object) this.m_createSubscriptionCount);
    diagnosticsDataType.m_modifySubscriptionCount = (ServiceCounterDataType) Utils.Clone((object) this.m_modifySubscriptionCount);
    diagnosticsDataType.m_setPublishingModeCount = (ServiceCounterDataType) Utils.Clone((object) this.m_setPublishingModeCount);
    diagnosticsDataType.m_publishCount = (ServiceCounterDataType) Utils.Clone((object) this.m_publishCount);
    diagnosticsDataType.m_republishCount = (ServiceCounterDataType) Utils.Clone((object) this.m_republishCount);
    diagnosticsDataType.m_transferSubscriptionsCount = (ServiceCounterDataType) Utils.Clone((object) this.m_transferSubscriptionsCount);
    diagnosticsDataType.m_deleteSubscriptionsCount = (ServiceCounterDataType) Utils.Clone((object) this.m_deleteSubscriptionsCount);
    diagnosticsDataType.m_addNodesCount = (ServiceCounterDataType) Utils.Clone((object) this.m_addNodesCount);
    diagnosticsDataType.m_addReferencesCount = (ServiceCounterDataType) Utils.Clone((object) this.m_addReferencesCount);
    diagnosticsDataType.m_deleteNodesCount = (ServiceCounterDataType) Utils.Clone((object) this.m_deleteNodesCount);
    diagnosticsDataType.m_deleteReferencesCount = (ServiceCounterDataType) Utils.Clone((object) this.m_deleteReferencesCount);
    diagnosticsDataType.m_browseCount = (ServiceCounterDataType) Utils.Clone((object) this.m_browseCount);
    diagnosticsDataType.m_browseNextCount = (ServiceCounterDataType) Utils.Clone((object) this.m_browseNextCount);
    diagnosticsDataType.m_translateBrowsePathsToNodeIdsCount = (ServiceCounterDataType) Utils.Clone((object) this.m_translateBrowsePathsToNodeIdsCount);
    diagnosticsDataType.m_queryFirstCount = (ServiceCounterDataType) Utils.Clone((object) this.m_queryFirstCount);
    diagnosticsDataType.m_queryNextCount = (ServiceCounterDataType) Utils.Clone((object) this.m_queryNextCount);
    diagnosticsDataType.m_registerNodesCount = (ServiceCounterDataType) Utils.Clone((object) this.m_registerNodesCount);
    diagnosticsDataType.m_unregisterNodesCount = (ServiceCounterDataType) Utils.Clone((object) this.m_unregisterNodesCount);
    return (object) diagnosticsDataType;
  }
}
