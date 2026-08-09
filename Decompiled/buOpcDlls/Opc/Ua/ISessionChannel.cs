using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface ISessionChannel : IChannelBase
{
	CreateSessionResponseMessage CreateSession(CreateSessionMessage request);

	IAsyncResult BeginCreateSession(CreateSessionMessage request, AsyncCallback callback, object asyncState);

	CreateSessionResponseMessage EndCreateSession(IAsyncResult result);

	Task<CreateSessionResponseMessage> CreateSessionAsync(CreateSessionMessage request);

	ActivateSessionResponseMessage ActivateSession(ActivateSessionMessage request);

	IAsyncResult BeginActivateSession(ActivateSessionMessage request, AsyncCallback callback, object asyncState);

	ActivateSessionResponseMessage EndActivateSession(IAsyncResult result);

	Task<ActivateSessionResponseMessage> ActivateSessionAsync(ActivateSessionMessage request);

	CloseSessionResponseMessage CloseSession(CloseSessionMessage request);

	IAsyncResult BeginCloseSession(CloseSessionMessage request, AsyncCallback callback, object asyncState);

	CloseSessionResponseMessage EndCloseSession(IAsyncResult result);

	Task<CloseSessionResponseMessage> CloseSessionAsync(CloseSessionMessage request);

	CancelResponseMessage Cancel(CancelMessage request);

	IAsyncResult BeginCancel(CancelMessage request, AsyncCallback callback, object asyncState);

	CancelResponseMessage EndCancel(IAsyncResult result);

	Task<CancelResponseMessage> CancelAsync(CancelMessage request);

	AddNodesResponseMessage AddNodes(AddNodesMessage request);

	IAsyncResult BeginAddNodes(AddNodesMessage request, AsyncCallback callback, object asyncState);

	AddNodesResponseMessage EndAddNodes(IAsyncResult result);

	Task<AddNodesResponseMessage> AddNodesAsync(AddNodesMessage request);

	AddReferencesResponseMessage AddReferences(AddReferencesMessage request);

	IAsyncResult BeginAddReferences(AddReferencesMessage request, AsyncCallback callback, object asyncState);

	AddReferencesResponseMessage EndAddReferences(IAsyncResult result);

	Task<AddReferencesResponseMessage> AddReferencesAsync(AddReferencesMessage request);

	DeleteNodesResponseMessage DeleteNodes(DeleteNodesMessage request);

	IAsyncResult BeginDeleteNodes(DeleteNodesMessage request, AsyncCallback callback, object asyncState);

	DeleteNodesResponseMessage EndDeleteNodes(IAsyncResult result);

	Task<DeleteNodesResponseMessage> DeleteNodesAsync(DeleteNodesMessage request);

	DeleteReferencesResponseMessage DeleteReferences(DeleteReferencesMessage request);

	IAsyncResult BeginDeleteReferences(DeleteReferencesMessage request, AsyncCallback callback, object asyncState);

	DeleteReferencesResponseMessage EndDeleteReferences(IAsyncResult result);

	Task<DeleteReferencesResponseMessage> DeleteReferencesAsync(DeleteReferencesMessage request);

	BrowseResponseMessage Browse(BrowseMessage request);

	IAsyncResult BeginBrowse(BrowseMessage request, AsyncCallback callback, object asyncState);

	BrowseResponseMessage EndBrowse(IAsyncResult result);

	Task<BrowseResponseMessage> BrowseAsync(BrowseMessage request);

	BrowseNextResponseMessage BrowseNext(BrowseNextMessage request);

	IAsyncResult BeginBrowseNext(BrowseNextMessage request, AsyncCallback callback, object asyncState);

	BrowseNextResponseMessage EndBrowseNext(IAsyncResult result);

	Task<BrowseNextResponseMessage> BrowseNextAsync(BrowseNextMessage request);

	TranslateBrowsePathsToNodeIdsResponseMessage TranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage request);

	IAsyncResult BeginTranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage request, AsyncCallback callback, object asyncState);

	TranslateBrowsePathsToNodeIdsResponseMessage EndTranslateBrowsePathsToNodeIds(IAsyncResult result);

	Task<TranslateBrowsePathsToNodeIdsResponseMessage> TranslateBrowsePathsToNodeIdsAsync(TranslateBrowsePathsToNodeIdsMessage request);

	RegisterNodesResponseMessage RegisterNodes(RegisterNodesMessage request);

	IAsyncResult BeginRegisterNodes(RegisterNodesMessage request, AsyncCallback callback, object asyncState);

	RegisterNodesResponseMessage EndRegisterNodes(IAsyncResult result);

	Task<RegisterNodesResponseMessage> RegisterNodesAsync(RegisterNodesMessage request);

	UnregisterNodesResponseMessage UnregisterNodes(UnregisterNodesMessage request);

	IAsyncResult BeginUnregisterNodes(UnregisterNodesMessage request, AsyncCallback callback, object asyncState);

	UnregisterNodesResponseMessage EndUnregisterNodes(IAsyncResult result);

	Task<UnregisterNodesResponseMessage> UnregisterNodesAsync(UnregisterNodesMessage request);

	QueryFirstResponseMessage QueryFirst(QueryFirstMessage request);

	IAsyncResult BeginQueryFirst(QueryFirstMessage request, AsyncCallback callback, object asyncState);

	QueryFirstResponseMessage EndQueryFirst(IAsyncResult result);

	Task<QueryFirstResponseMessage> QueryFirstAsync(QueryFirstMessage request);

	QueryNextResponseMessage QueryNext(QueryNextMessage request);

	IAsyncResult BeginQueryNext(QueryNextMessage request, AsyncCallback callback, object asyncState);

	QueryNextResponseMessage EndQueryNext(IAsyncResult result);

	Task<QueryNextResponseMessage> QueryNextAsync(QueryNextMessage request);

	ReadResponseMessage Read(ReadMessage request);

	IAsyncResult BeginRead(ReadMessage request, AsyncCallback callback, object asyncState);

	ReadResponseMessage EndRead(IAsyncResult result);

	Task<ReadResponseMessage> ReadAsync(ReadMessage request);

	HistoryReadResponseMessage HistoryRead(HistoryReadMessage request);

	IAsyncResult BeginHistoryRead(HistoryReadMessage request, AsyncCallback callback, object asyncState);

	HistoryReadResponseMessage EndHistoryRead(IAsyncResult result);

	Task<HistoryReadResponseMessage> HistoryReadAsync(HistoryReadMessage request);

	WriteResponseMessage Write(WriteMessage request);

	IAsyncResult BeginWrite(WriteMessage request, AsyncCallback callback, object asyncState);

	WriteResponseMessage EndWrite(IAsyncResult result);

	Task<WriteResponseMessage> WriteAsync(WriteMessage request);

	HistoryUpdateResponseMessage HistoryUpdate(HistoryUpdateMessage request);

	IAsyncResult BeginHistoryUpdate(HistoryUpdateMessage request, AsyncCallback callback, object asyncState);

	HistoryUpdateResponseMessage EndHistoryUpdate(IAsyncResult result);

	Task<HistoryUpdateResponseMessage> HistoryUpdateAsync(HistoryUpdateMessage request);

	CallResponseMessage Call(CallMessage request);

	IAsyncResult BeginCall(CallMessage request, AsyncCallback callback, object asyncState);

	CallResponseMessage EndCall(IAsyncResult result);

	Task<CallResponseMessage> CallAsync(CallMessage request);

	CreateMonitoredItemsResponseMessage CreateMonitoredItems(CreateMonitoredItemsMessage request);

	IAsyncResult BeginCreateMonitoredItems(CreateMonitoredItemsMessage request, AsyncCallback callback, object asyncState);

	CreateMonitoredItemsResponseMessage EndCreateMonitoredItems(IAsyncResult result);

	Task<CreateMonitoredItemsResponseMessage> CreateMonitoredItemsAsync(CreateMonitoredItemsMessage request);

	ModifyMonitoredItemsResponseMessage ModifyMonitoredItems(ModifyMonitoredItemsMessage request);

	IAsyncResult BeginModifyMonitoredItems(ModifyMonitoredItemsMessage request, AsyncCallback callback, object asyncState);

	ModifyMonitoredItemsResponseMessage EndModifyMonitoredItems(IAsyncResult result);

	Task<ModifyMonitoredItemsResponseMessage> ModifyMonitoredItemsAsync(ModifyMonitoredItemsMessage request);

	SetMonitoringModeResponseMessage SetMonitoringMode(SetMonitoringModeMessage request);

	IAsyncResult BeginSetMonitoringMode(SetMonitoringModeMessage request, AsyncCallback callback, object asyncState);

	SetMonitoringModeResponseMessage EndSetMonitoringMode(IAsyncResult result);

	Task<SetMonitoringModeResponseMessage> SetMonitoringModeAsync(SetMonitoringModeMessage request);

	SetTriggeringResponseMessage SetTriggering(SetTriggeringMessage request);

	IAsyncResult BeginSetTriggering(SetTriggeringMessage request, AsyncCallback callback, object asyncState);

	SetTriggeringResponseMessage EndSetTriggering(IAsyncResult result);

	Task<SetTriggeringResponseMessage> SetTriggeringAsync(SetTriggeringMessage request);

	DeleteMonitoredItemsResponseMessage DeleteMonitoredItems(DeleteMonitoredItemsMessage request);

	IAsyncResult BeginDeleteMonitoredItems(DeleteMonitoredItemsMessage request, AsyncCallback callback, object asyncState);

	DeleteMonitoredItemsResponseMessage EndDeleteMonitoredItems(IAsyncResult result);

	Task<DeleteMonitoredItemsResponseMessage> DeleteMonitoredItemsAsync(DeleteMonitoredItemsMessage request);

	CreateSubscriptionResponseMessage CreateSubscription(CreateSubscriptionMessage request);

	IAsyncResult BeginCreateSubscription(CreateSubscriptionMessage request, AsyncCallback callback, object asyncState);

	CreateSubscriptionResponseMessage EndCreateSubscription(IAsyncResult result);

	Task<CreateSubscriptionResponseMessage> CreateSubscriptionAsync(CreateSubscriptionMessage request);

	ModifySubscriptionResponseMessage ModifySubscription(ModifySubscriptionMessage request);

	IAsyncResult BeginModifySubscription(ModifySubscriptionMessage request, AsyncCallback callback, object asyncState);

	ModifySubscriptionResponseMessage EndModifySubscription(IAsyncResult result);

	Task<ModifySubscriptionResponseMessage> ModifySubscriptionAsync(ModifySubscriptionMessage request);

	SetPublishingModeResponseMessage SetPublishingMode(SetPublishingModeMessage request);

	IAsyncResult BeginSetPublishingMode(SetPublishingModeMessage request, AsyncCallback callback, object asyncState);

	SetPublishingModeResponseMessage EndSetPublishingMode(IAsyncResult result);

	Task<SetPublishingModeResponseMessage> SetPublishingModeAsync(SetPublishingModeMessage request);

	PublishResponseMessage Publish(PublishMessage request);

	IAsyncResult BeginPublish(PublishMessage request, AsyncCallback callback, object asyncState);

	PublishResponseMessage EndPublish(IAsyncResult result);

	Task<PublishResponseMessage> PublishAsync(PublishMessage request);

	RepublishResponseMessage Republish(RepublishMessage request);

	IAsyncResult BeginRepublish(RepublishMessage request, AsyncCallback callback, object asyncState);

	RepublishResponseMessage EndRepublish(IAsyncResult result);

	Task<RepublishResponseMessage> RepublishAsync(RepublishMessage request);

	TransferSubscriptionsResponseMessage TransferSubscriptions(TransferSubscriptionsMessage request);

	IAsyncResult BeginTransferSubscriptions(TransferSubscriptionsMessage request, AsyncCallback callback, object asyncState);

	TransferSubscriptionsResponseMessage EndTransferSubscriptions(IAsyncResult result);

	Task<TransferSubscriptionsResponseMessage> TransferSubscriptionsAsync(TransferSubscriptionsMessage request);

	DeleteSubscriptionsResponseMessage DeleteSubscriptions(DeleteSubscriptionsMessage request);

	IAsyncResult BeginDeleteSubscriptions(DeleteSubscriptionsMessage request, AsyncCallback callback, object asyncState);

	DeleteSubscriptionsResponseMessage EndDeleteSubscriptions(IAsyncResult result);

	Task<DeleteSubscriptionsResponseMessage> DeleteSubscriptionsAsync(DeleteSubscriptionsMessage request);
}
