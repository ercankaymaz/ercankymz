// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionServerBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionServerBase : ServerBase, ISessionServer, IServerBase, IAuditEventCallback
{
  public virtual ResponseHeader FindServers(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection serverUris,
    out ApplicationDescriptionCollection servers)
  {
    servers = (ApplicationDescriptionCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader FindServersOnNetwork(
    RequestHeader requestHeader,
    uint startingRecordId,
    uint maxRecordsToReturn,
    StringCollection serverCapabilityFilter,
    out DateTime lastCounterResetTime,
    out ServerOnNetworkCollection servers)
  {
    lastCounterResetTime = DateTime.MinValue;
    servers = (ServerOnNetworkCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader GetEndpoints(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection profileUris,
    out EndpointDescriptionCollection endpoints)
  {
    endpoints = (EndpointDescriptionCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader CreateSession(
    RequestHeader requestHeader,
    ApplicationDescription clientDescription,
    string serverUri,
    string endpointUrl,
    string sessionName,
    byte[] clientNonce,
    byte[] clientCertificate,
    double requestedSessionTimeout,
    uint maxResponseMessageSize,
    out NodeId sessionId,
    out NodeId authenticationToken,
    out double revisedSessionTimeout,
    out byte[] serverNonce,
    out byte[] serverCertificate,
    out EndpointDescriptionCollection serverEndpoints,
    out SignedSoftwareCertificateCollection serverSoftwareCertificates,
    out SignatureData serverSignature,
    out uint maxRequestMessageSize)
  {
    sessionId = (NodeId) null;
    authenticationToken = (NodeId) null;
    revisedSessionTimeout = 0.0;
    serverNonce = (byte[]) null;
    serverCertificate = (byte[]) null;
    serverEndpoints = (EndpointDescriptionCollection) null;
    serverSoftwareCertificates = (SignedSoftwareCertificateCollection) null;
    serverSignature = (SignatureData) null;
    maxRequestMessageSize = 0U;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader ActivateSession(
    RequestHeader requestHeader,
    SignatureData clientSignature,
    SignedSoftwareCertificateCollection clientSoftwareCertificates,
    StringCollection localeIds,
    ExtensionObject userIdentityToken,
    SignatureData userTokenSignature,
    out byte[] serverNonce,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    serverNonce = (byte[]) null;
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions)
  {
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader Cancel(
    RequestHeader requestHeader,
    uint requestHandle,
    out uint cancelCount)
  {
    cancelCount = 0U;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader AddNodes(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    out AddNodesResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (AddNodesResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader AddReferences(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader DeleteNodes(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader DeleteReferences(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader Browse(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (BrowseResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader BrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoints,
    ByteStringCollection continuationPoints,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (BrowseResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader TranslateBrowsePathsToNodeIds(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    out BrowsePathResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (BrowsePathResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader RegisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    out NodeIdCollection registeredNodeIds)
  {
    registeredNodeIds = (NodeIdCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader UnregisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister)
  {
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader QueryFirst(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeTypeDescriptionCollection nodeTypes,
    ContentFilter filter,
    uint maxDataSetsToReturn,
    uint maxReferencesToReturn,
    out QueryDataSetCollection queryDataSets,
    out byte[] continuationPoint,
    out ParsingResultCollection parsingResults,
    out DiagnosticInfoCollection diagnosticInfos,
    out ContentFilterResult filterResult)
  {
    queryDataSets = (QueryDataSetCollection) null;
    continuationPoint = (byte[]) null;
    parsingResults = (ParsingResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    filterResult = (ContentFilterResult) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader QueryNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    out QueryDataSetCollection queryDataSets,
    out byte[] revisedContinuationPoint)
  {
    queryDataSets = (QueryDataSetCollection) null;
    revisedContinuationPoint = (byte[]) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader Read(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    out DataValueCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (DataValueCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader HistoryRead(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    out HistoryReadResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (HistoryReadResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader Write(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader HistoryUpdate(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    out HistoryUpdateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (HistoryUpdateResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader Call(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    out CallMethodResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (CallMethodResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader CreateMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    out MonitoredItemCreateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (MonitoredItemCreateResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader ModifyMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    out MonitoredItemModifyResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (MonitoredItemModifyResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader SetMonitoringMode(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader SetTriggering(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint triggeringItemId,
    UInt32Collection linksToAdd,
    UInt32Collection linksToRemove,
    out StatusCodeCollection addResults,
    out DiagnosticInfoCollection addDiagnosticInfos,
    out StatusCodeCollection removeResults,
    out DiagnosticInfoCollection removeDiagnosticInfos)
  {
    addResults = (StatusCodeCollection) null;
    addDiagnosticInfos = (DiagnosticInfoCollection) null;
    removeResults = (StatusCodeCollection) null;
    removeDiagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader DeleteMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader CreateSubscription(
    RequestHeader requestHeader,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    bool publishingEnabled,
    byte priority,
    out uint subscriptionId,
    out double revisedPublishingInterval,
    out uint revisedLifetimeCount,
    out uint revisedMaxKeepAliveCount)
  {
    subscriptionId = 0U;
    revisedPublishingInterval = 0.0;
    revisedLifetimeCount = 0U;
    revisedMaxKeepAliveCount = 0U;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader ModifySubscription(
    RequestHeader requestHeader,
    uint subscriptionId,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    byte priority,
    out double revisedPublishingInterval,
    out uint revisedLifetimeCount,
    out uint revisedMaxKeepAliveCount)
  {
    revisedPublishingInterval = 0.0;
    revisedLifetimeCount = 0U;
    revisedMaxKeepAliveCount = 0U;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader SetPublishingMode(
    RequestHeader requestHeader,
    bool publishingEnabled,
    UInt32Collection subscriptionIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader Publish(
    RequestHeader requestHeader,
    SubscriptionAcknowledgementCollection subscriptionAcknowledgements,
    out uint subscriptionId,
    out UInt32Collection availableSequenceNumbers,
    out bool moreNotifications,
    out NotificationMessage notificationMessage,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    subscriptionId = 0U;
    availableSequenceNumbers = (UInt32Collection) null;
    moreNotifications = false;
    notificationMessage = (NotificationMessage) null;
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader Republish(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint retransmitSequenceNumber,
    out NotificationMessage notificationMessage)
  {
    notificationMessage = (NotificationMessage) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader TransferSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    out TransferResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (TransferResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader DeleteSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }
}
