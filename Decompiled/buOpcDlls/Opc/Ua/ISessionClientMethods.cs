using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface ISessionClientMethods
{
	ResponseHeader CreateSession(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, out NodeId sessionId, out NodeId authenticationToken, out double revisedSessionTimeout, out byte[] serverNonce, out byte[] serverCertificate, out EndpointDescriptionCollection serverEndpoints, out SignedSoftwareCertificateCollection serverSoftwareCertificates, out SignatureData serverSignature, out uint maxRequestMessageSize);

	IAsyncResult BeginCreateSession(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, AsyncCallback callback, object asyncState);

	ResponseHeader EndCreateSession(IAsyncResult result, out NodeId sessionId, out NodeId authenticationToken, out double revisedSessionTimeout, out byte[] serverNonce, out byte[] serverCertificate, out EndpointDescriptionCollection serverEndpoints, out SignedSoftwareCertificateCollection serverSoftwareCertificates, out SignatureData serverSignature, out uint maxRequestMessageSize);

	Task<CreateSessionResponse> CreateSessionAsync(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, CancellationToken ct);

	ResponseHeader ActivateSession(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, out byte[] serverNonce, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginActivateSession(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, AsyncCallback callback, object asyncState);

	ResponseHeader EndActivateSession(IAsyncResult result, out byte[] serverNonce, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<ActivateSessionResponse> ActivateSessionAsync(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, CancellationToken ct);

	ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions);

	IAsyncResult BeginCloseSession(RequestHeader requestHeader, bool deleteSubscriptions, AsyncCallback callback, object asyncState);

	ResponseHeader EndCloseSession(IAsyncResult result);

	Task<CloseSessionResponse> CloseSessionAsync(RequestHeader requestHeader, bool deleteSubscriptions, CancellationToken ct);

	ResponseHeader Cancel(RequestHeader requestHeader, uint requestHandle, out uint cancelCount);

	IAsyncResult BeginCancel(RequestHeader requestHeader, uint requestHandle, AsyncCallback callback, object asyncState);

	ResponseHeader EndCancel(IAsyncResult result, out uint cancelCount);

	Task<CancelResponse> CancelAsync(RequestHeader requestHeader, uint requestHandle, CancellationToken ct);

	ResponseHeader AddNodes(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, out AddNodesResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginAddNodes(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, AsyncCallback callback, object asyncState);

	ResponseHeader EndAddNodes(IAsyncResult result, out AddNodesResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<AddNodesResponse> AddNodesAsync(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, CancellationToken ct);

	ResponseHeader AddReferences(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginAddReferences(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, AsyncCallback callback, object asyncState);

	ResponseHeader EndAddReferences(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<AddReferencesResponse> AddReferencesAsync(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, CancellationToken ct);

	ResponseHeader DeleteNodes(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginDeleteNodes(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, AsyncCallback callback, object asyncState);

	ResponseHeader EndDeleteNodes(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<DeleteNodesResponse> DeleteNodesAsync(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, CancellationToken ct);

	ResponseHeader DeleteReferences(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginDeleteReferences(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, AsyncCallback callback, object asyncState);

	ResponseHeader EndDeleteReferences(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<DeleteReferencesResponse> DeleteReferencesAsync(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, CancellationToken ct);

	ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginBrowse(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, AsyncCallback callback, object asyncState);

	ResponseHeader EndBrowse(IAsyncResult result, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<BrowseResponse> BrowseAsync(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, CancellationToken ct);

	ResponseHeader BrowseNext(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginBrowseNext(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, AsyncCallback callback, object asyncState);

	ResponseHeader EndBrowseNext(IAsyncResult result, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<BrowseNextResponse> BrowseNextAsync(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, CancellationToken ct);

	ResponseHeader TranslateBrowsePathsToNodeIds(RequestHeader requestHeader, BrowsePathCollection browsePaths, out BrowsePathResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginTranslateBrowsePathsToNodeIds(RequestHeader requestHeader, BrowsePathCollection browsePaths, AsyncCallback callback, object asyncState);

	ResponseHeader EndTranslateBrowsePathsToNodeIds(IAsyncResult result, out BrowsePathResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<TranslateBrowsePathsToNodeIdsResponse> TranslateBrowsePathsToNodeIdsAsync(RequestHeader requestHeader, BrowsePathCollection browsePaths, CancellationToken ct);

	ResponseHeader RegisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToRegister, out NodeIdCollection registeredNodeIds);

	IAsyncResult BeginRegisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToRegister, AsyncCallback callback, object asyncState);

	ResponseHeader EndRegisterNodes(IAsyncResult result, out NodeIdCollection registeredNodeIds);

	Task<RegisterNodesResponse> RegisterNodesAsync(RequestHeader requestHeader, NodeIdCollection nodesToRegister, CancellationToken ct);

	ResponseHeader UnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister);

	IAsyncResult BeginUnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister, AsyncCallback callback, object asyncState);

	ResponseHeader EndUnregisterNodes(IAsyncResult result);

	Task<UnregisterNodesResponse> UnregisterNodesAsync(RequestHeader requestHeader, NodeIdCollection nodesToUnregister, CancellationToken ct);

	ResponseHeader QueryFirst(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, out QueryDataSetCollection queryDataSets, out byte[] continuationPoint, out ParsingResultCollection parsingResults, out DiagnosticInfoCollection diagnosticInfos, out ContentFilterResult filterResult);

	IAsyncResult BeginQueryFirst(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, AsyncCallback callback, object asyncState);

	ResponseHeader EndQueryFirst(IAsyncResult result, out QueryDataSetCollection queryDataSets, out byte[] continuationPoint, out ParsingResultCollection parsingResults, out DiagnosticInfoCollection diagnosticInfos, out ContentFilterResult filterResult);

	Task<QueryFirstResponse> QueryFirstAsync(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, CancellationToken ct);

	ResponseHeader QueryNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, out QueryDataSetCollection queryDataSets, out byte[] revisedContinuationPoint);

	IAsyncResult BeginQueryNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, AsyncCallback callback, object asyncState);

	ResponseHeader EndQueryNext(IAsyncResult result, out QueryDataSetCollection queryDataSets, out byte[] revisedContinuationPoint);

	Task<QueryNextResponse> QueryNextAsync(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, CancellationToken ct);

	ResponseHeader Read(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, out DataValueCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginRead(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, AsyncCallback callback, object asyncState);

	ResponseHeader EndRead(IAsyncResult result, out DataValueCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<ReadResponse> ReadAsync(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, CancellationToken ct);

	ResponseHeader HistoryRead(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, out HistoryReadResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginHistoryRead(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, AsyncCallback callback, object asyncState);

	ResponseHeader EndHistoryRead(IAsyncResult result, out HistoryReadResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<HistoryReadResponse> HistoryReadAsync(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, CancellationToken ct);

	ResponseHeader Write(RequestHeader requestHeader, WriteValueCollection nodesToWrite, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginWrite(RequestHeader requestHeader, WriteValueCollection nodesToWrite, AsyncCallback callback, object asyncState);

	ResponseHeader EndWrite(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<WriteResponse> WriteAsync(RequestHeader requestHeader, WriteValueCollection nodesToWrite, CancellationToken ct);

	ResponseHeader HistoryUpdate(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, out HistoryUpdateResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginHistoryUpdate(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, AsyncCallback callback, object asyncState);

	ResponseHeader EndHistoryUpdate(IAsyncResult result, out HistoryUpdateResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<HistoryUpdateResponse> HistoryUpdateAsync(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, CancellationToken ct);

	ResponseHeader Call(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, out CallMethodResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginCall(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, AsyncCallback callback, object asyncState);

	ResponseHeader EndCall(IAsyncResult result, out CallMethodResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<CallResponse> CallAsync(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, CancellationToken ct);

	ResponseHeader CreateMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, out MonitoredItemCreateResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginCreateMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, AsyncCallback callback, object asyncState);

	ResponseHeader EndCreateMonitoredItems(IAsyncResult result, out MonitoredItemCreateResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<CreateMonitoredItemsResponse> CreateMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, CancellationToken ct);

	ResponseHeader ModifyMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, out MonitoredItemModifyResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginModifyMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, AsyncCallback callback, object asyncState);

	ResponseHeader EndModifyMonitoredItems(IAsyncResult result, out MonitoredItemModifyResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<ModifyMonitoredItemsResponse> ModifyMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, CancellationToken ct);

	ResponseHeader SetMonitoringMode(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginSetMonitoringMode(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, AsyncCallback callback, object asyncState);

	ResponseHeader EndSetMonitoringMode(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<SetMonitoringModeResponse> SetMonitoringModeAsync(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, CancellationToken ct);

	ResponseHeader SetTriggering(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, out StatusCodeCollection addResults, out DiagnosticInfoCollection addDiagnosticInfos, out StatusCodeCollection removeResults, out DiagnosticInfoCollection removeDiagnosticInfos);

	IAsyncResult BeginSetTriggering(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, AsyncCallback callback, object asyncState);

	ResponseHeader EndSetTriggering(IAsyncResult result, out StatusCodeCollection addResults, out DiagnosticInfoCollection addDiagnosticInfos, out StatusCodeCollection removeResults, out DiagnosticInfoCollection removeDiagnosticInfos);

	Task<SetTriggeringResponse> SetTriggeringAsync(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, CancellationToken ct);

	ResponseHeader DeleteMonitoredItems(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginDeleteMonitoredItems(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, AsyncCallback callback, object asyncState);

	ResponseHeader EndDeleteMonitoredItems(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<DeleteMonitoredItemsResponse> DeleteMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, CancellationToken ct);

	ResponseHeader CreateSubscription(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, out uint subscriptionId, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount);

	IAsyncResult BeginCreateSubscription(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, AsyncCallback callback, object asyncState);

	ResponseHeader EndCreateSubscription(IAsyncResult result, out uint subscriptionId, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount);

	Task<CreateSubscriptionResponse> CreateSubscriptionAsync(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, CancellationToken ct);

	ResponseHeader ModifySubscription(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount);

	IAsyncResult BeginModifySubscription(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, AsyncCallback callback, object asyncState);

	ResponseHeader EndModifySubscription(IAsyncResult result, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount);

	Task<ModifySubscriptionResponse> ModifySubscriptionAsync(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, CancellationToken ct);

	ResponseHeader SetPublishingMode(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginSetPublishingMode(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, AsyncCallback callback, object asyncState);

	ResponseHeader EndSetPublishingMode(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<SetPublishingModeResponse> SetPublishingModeAsync(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, CancellationToken ct);

	ResponseHeader Publish(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, out uint subscriptionId, out UInt32Collection availableSequenceNumbers, out bool moreNotifications, out NotificationMessage notificationMessage, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginPublish(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, AsyncCallback callback, object asyncState);

	ResponseHeader EndPublish(IAsyncResult result, out uint subscriptionId, out UInt32Collection availableSequenceNumbers, out bool moreNotifications, out NotificationMessage notificationMessage, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<PublishResponse> PublishAsync(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, CancellationToken ct);

	ResponseHeader Republish(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, out NotificationMessage notificationMessage);

	IAsyncResult BeginRepublish(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, AsyncCallback callback, object asyncState);

	ResponseHeader EndRepublish(IAsyncResult result, out NotificationMessage notificationMessage);

	Task<RepublishResponse> RepublishAsync(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, CancellationToken ct);

	ResponseHeader TransferSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, out TransferResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginTransferSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, AsyncCallback callback, object asyncState);

	ResponseHeader EndTransferSubscriptions(IAsyncResult result, out TransferResultCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<TransferSubscriptionsResponse> TransferSubscriptionsAsync(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, CancellationToken ct);

	ResponseHeader DeleteSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	IAsyncResult BeginDeleteSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, AsyncCallback callback, object asyncState);

	ResponseHeader EndDeleteSubscriptions(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);

	Task<DeleteSubscriptionsResponse> DeleteSubscriptionsAsync(RequestHeader requestHeader, UInt32Collection subscriptionIds, CancellationToken ct);
}
