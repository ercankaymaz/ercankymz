using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface ISessionEndpoint : IEndpointBase
{
	IAsyncResult BeginCreateSession(CreateSessionMessage request, AsyncCallback callback, object asyncState);

	CreateSessionResponseMessage EndCreateSession(IAsyncResult result);

	IAsyncResult BeginActivateSession(ActivateSessionMessage request, AsyncCallback callback, object asyncState);

	ActivateSessionResponseMessage EndActivateSession(IAsyncResult result);

	IAsyncResult BeginCloseSession(CloseSessionMessage request, AsyncCallback callback, object asyncState);

	CloseSessionResponseMessage EndCloseSession(IAsyncResult result);

	IAsyncResult BeginCancel(CancelMessage request, AsyncCallback callback, object asyncState);

	CancelResponseMessage EndCancel(IAsyncResult result);

	IAsyncResult BeginAddNodes(AddNodesMessage request, AsyncCallback callback, object asyncState);

	AddNodesResponseMessage EndAddNodes(IAsyncResult result);

	IAsyncResult BeginAddReferences(AddReferencesMessage request, AsyncCallback callback, object asyncState);

	AddReferencesResponseMessage EndAddReferences(IAsyncResult result);

	IAsyncResult BeginDeleteNodes(DeleteNodesMessage request, AsyncCallback callback, object asyncState);

	DeleteNodesResponseMessage EndDeleteNodes(IAsyncResult result);

	IAsyncResult BeginDeleteReferences(DeleteReferencesMessage request, AsyncCallback callback, object asyncState);

	DeleteReferencesResponseMessage EndDeleteReferences(IAsyncResult result);

	IAsyncResult BeginBrowse(BrowseMessage request, AsyncCallback callback, object asyncState);

	BrowseResponseMessage EndBrowse(IAsyncResult result);

	IAsyncResult BeginBrowseNext(BrowseNextMessage request, AsyncCallback callback, object asyncState);

	BrowseNextResponseMessage EndBrowseNext(IAsyncResult result);

	IAsyncResult BeginTranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage request, AsyncCallback callback, object asyncState);

	TranslateBrowsePathsToNodeIdsResponseMessage EndTranslateBrowsePathsToNodeIds(IAsyncResult result);

	IAsyncResult BeginRegisterNodes(RegisterNodesMessage request, AsyncCallback callback, object asyncState);

	RegisterNodesResponseMessage EndRegisterNodes(IAsyncResult result);

	IAsyncResult BeginUnregisterNodes(UnregisterNodesMessage request, AsyncCallback callback, object asyncState);

	UnregisterNodesResponseMessage EndUnregisterNodes(IAsyncResult result);

	IAsyncResult BeginQueryFirst(QueryFirstMessage request, AsyncCallback callback, object asyncState);

	QueryFirstResponseMessage EndQueryFirst(IAsyncResult result);

	IAsyncResult BeginQueryNext(QueryNextMessage request, AsyncCallback callback, object asyncState);

	QueryNextResponseMessage EndQueryNext(IAsyncResult result);

	IAsyncResult BeginRead(ReadMessage request, AsyncCallback callback, object asyncState);

	ReadResponseMessage EndRead(IAsyncResult result);

	IAsyncResult BeginHistoryRead(HistoryReadMessage request, AsyncCallback callback, object asyncState);

	HistoryReadResponseMessage EndHistoryRead(IAsyncResult result);

	IAsyncResult BeginWrite(WriteMessage request, AsyncCallback callback, object asyncState);

	WriteResponseMessage EndWrite(IAsyncResult result);

	IAsyncResult BeginHistoryUpdate(HistoryUpdateMessage request, AsyncCallback callback, object asyncState);

	HistoryUpdateResponseMessage EndHistoryUpdate(IAsyncResult result);

	IAsyncResult BeginCall(CallMessage request, AsyncCallback callback, object asyncState);

	CallResponseMessage EndCall(IAsyncResult result);

	IAsyncResult BeginCreateMonitoredItems(CreateMonitoredItemsMessage request, AsyncCallback callback, object asyncState);

	CreateMonitoredItemsResponseMessage EndCreateMonitoredItems(IAsyncResult result);

	IAsyncResult BeginModifyMonitoredItems(ModifyMonitoredItemsMessage request, AsyncCallback callback, object asyncState);

	ModifyMonitoredItemsResponseMessage EndModifyMonitoredItems(IAsyncResult result);

	IAsyncResult BeginSetMonitoringMode(SetMonitoringModeMessage request, AsyncCallback callback, object asyncState);

	SetMonitoringModeResponseMessage EndSetMonitoringMode(IAsyncResult result);

	IAsyncResult BeginSetTriggering(SetTriggeringMessage request, AsyncCallback callback, object asyncState);

	SetTriggeringResponseMessage EndSetTriggering(IAsyncResult result);

	IAsyncResult BeginDeleteMonitoredItems(DeleteMonitoredItemsMessage request, AsyncCallback callback, object asyncState);

	DeleteMonitoredItemsResponseMessage EndDeleteMonitoredItems(IAsyncResult result);

	IAsyncResult BeginCreateSubscription(CreateSubscriptionMessage request, AsyncCallback callback, object asyncState);

	CreateSubscriptionResponseMessage EndCreateSubscription(IAsyncResult result);

	IAsyncResult BeginModifySubscription(ModifySubscriptionMessage request, AsyncCallback callback, object asyncState);

	ModifySubscriptionResponseMessage EndModifySubscription(IAsyncResult result);

	IAsyncResult BeginSetPublishingMode(SetPublishingModeMessage request, AsyncCallback callback, object asyncState);

	SetPublishingModeResponseMessage EndSetPublishingMode(IAsyncResult result);

	IAsyncResult BeginPublish(PublishMessage request, AsyncCallback callback, object asyncState);

	PublishResponseMessage EndPublish(IAsyncResult result);

	IAsyncResult BeginRepublish(RepublishMessage request, AsyncCallback callback, object asyncState);

	RepublishResponseMessage EndRepublish(IAsyncResult result);

	IAsyncResult BeginTransferSubscriptions(TransferSubscriptionsMessage request, AsyncCallback callback, object asyncState);

	TransferSubscriptionsResponseMessage EndTransferSubscriptions(IAsyncResult result);

	IAsyncResult BeginDeleteSubscriptions(DeleteSubscriptionsMessage request, AsyncCallback callback, object asyncState);

	DeleteSubscriptionsResponseMessage EndDeleteSubscriptions(IAsyncResult result);
}
