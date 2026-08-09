using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Client;

[ComVisible(true)]
public interface ISession : ISessionClient, ISessionClientMethods, IClientBase, IDisposable
{
	ISessionFactory SessionFactory { get; }

	ConfiguredEndpoint ConfiguredEndpoint { get; }

	string SessionName { get; }

	double SessionTimeout { get; }

	object Handle { get; }

	IUserIdentity Identity { get; }

	IEnumerable<IUserIdentity> IdentityHistory { get; }

	NamespaceTable NamespaceUris { get; }

	StringTable ServerUris { get; }

	ISystemContext SystemContext { get; }

	IEncodeableFactory Factory { get; }

	ITypeTable TypeTree { get; }

	INodeCache NodeCache { get; }

	FilterContext FilterContext { get; }

	StringCollection PreferredLocales { get; }

	IReadOnlyDictionary<NodeId, DataDictionary> DataTypeSystem { get; }

	IEnumerable<Subscription> Subscriptions { get; }

	int SubscriptionCount { get; }

	bool DeleteSubscriptionsOnClose { get; set; }

	Subscription DefaultSubscription { get; set; }

	int KeepAliveInterval { get; set; }

	bool KeepAliveStopped { get; }

	DateTime LastKeepAliveTime { get; }

	int OutstandingRequestCount { get; }

	int DefunctRequestCount { get; }

	int GoodPublishRequestCount { get; }

	int MinPublishRequestCount { get; set; }

	OperationLimits OperationLimits { get; }

	bool TransferSubscriptionsOnReconnect { get; set; }

	bool CheckDomain { get; }

	event KeepAliveEventHandler KeepAlive;

	event NotificationEventHandler Notification;

	event PublishErrorEventHandler PublishError;

	event PublishSequenceNumbersToAcknowledgeEventHandler PublishSequenceNumbersToAcknowledge;

	event EventHandler SubscriptionsChanged;

	event EventHandler SessionClosing;

	event EventHandler SessionConfigurationChanged;

	event RenewUserIdentityEventHandler RenewUserIdentity;

	void Reconnect();

	void Reconnect(ITransportWaitingConnection connection);

	void Reconnect(ITransportChannel channel);

	Task ReconnectAsync(CancellationToken ct = default(CancellationToken));

	Task ReconnectAsync(ITransportWaitingConnection connection, CancellationToken ct = default(CancellationToken));

	Task ReconnectAsync(ITransportChannel channel, CancellationToken ct = default(CancellationToken));

	void Save(string filePath, IEnumerable<Type> knownTypes = null);

	void Save(Stream stream, IEnumerable<Subscription> subscriptions, IEnumerable<Type> knownTypes = null);

	void Save(string filePath, IEnumerable<Subscription> subscriptions, IEnumerable<Type> knownTypes = null);

	IEnumerable<Subscription> Load(Stream stream, bool transferSubscriptions = false, IEnumerable<Type> knownTypes = null);

	IEnumerable<Subscription> Load(string filePath, bool transferSubscriptions = false, IEnumerable<Type> knownTypes = null);

	SessionConfiguration SaveSessionConfiguration(Stream stream = null);

	bool ApplySessionConfiguration(SessionConfiguration sessionConfiguration);

	void FetchNamespaceTables();

	void FetchTypeTree(ExpandedNodeId typeId);

	void FetchTypeTree(ExpandedNodeIdCollection typeIds);

	Task FetchNamespaceTablesAsync(CancellationToken ct = default(CancellationToken));

	Task FetchTypeTreeAsync(ExpandedNodeId typeId, CancellationToken ct = default(CancellationToken));

	Task FetchTypeTreeAsync(ExpandedNodeIdCollection typeIds, CancellationToken ct = default(CancellationToken));

	ReferenceDescriptionCollection ReadAvailableEncodings(NodeId variableId);

	ReferenceDescription FindDataDescription(NodeId encodingId);

	Task<DataDictionary> FindDataDictionary(NodeId descriptionId, CancellationToken ct = default(CancellationToken));

	DataDictionary LoadDataDictionary(ReferenceDescription dictionaryNode, bool forceReload = false);

	Task<Dictionary<NodeId, DataDictionary>> LoadDataTypeSystem(NodeId dataTypeSystem = null, CancellationToken ct = default(CancellationToken));

	Node ReadNode(NodeId nodeId);

	Node ReadNode(NodeId nodeId, NodeClass nodeClass, bool optionalAttributes = true);

	void ReadNodes(IList<NodeId> nodeIds, out IList<Node> nodeCollection, out IList<ServiceResult> errors, bool optionalAttributes = false);

	void ReadNodes(IList<NodeId> nodeIds, NodeClass nodeClass, out IList<Node> nodeCollection, out IList<ServiceResult> errors, bool optionalAttributes = false);

	DataValue ReadValue(NodeId nodeId);

	object ReadValue(NodeId nodeId, Type expectedType);

	void ReadValues(IList<NodeId> nodeIds, out DataValueCollection values, out IList<ServiceResult> errors);

	ReferenceDescriptionCollection FetchReferences(NodeId nodeId);

	void FetchReferences(IList<NodeId> nodeIds, out IList<ReferenceDescriptionCollection> referenceDescriptions, out IList<ServiceResult> errors);

	Task<ReferenceDescriptionCollection> FetchReferencesAsync(NodeId nodeId, CancellationToken ct);

	Task<(IList<ReferenceDescriptionCollection>, IList<ServiceResult>)> FetchReferencesAsync(IList<NodeId> nodeIds, CancellationToken ct);

	void Open(string sessionName, IUserIdentity identity);

	void Open(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales);

	void Open(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, bool checkDomain);

	void ChangePreferredLocales(StringCollection preferredLocales);

	void UpdateSession(IUserIdentity identity, StringCollection preferredLocales);

	void FindComponentIds(NodeId instanceId, IList<string> componentPaths, out NodeIdCollection componentIds, out List<ServiceResult> errors);

	void ReadValues(IList<NodeId> variableIds, IList<Type> expectedTypes, out List<object> values, out List<ServiceResult> errors);

	void ReadDisplayName(IList<NodeId> nodeIds, out IList<string> displayNames, out IList<ServiceResult> errors);

	Task OpenAsync(string sessionName, IUserIdentity identity, CancellationToken ct);

	Task OpenAsync(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct);

	Task OpenAsync(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, bool checkDomain, CancellationToken ct);

	Task<(IList<Node>, IList<ServiceResult>)> ReadNodesAsync(IList<NodeId> nodeIds, NodeClass nodeClass, bool optionalAttributes = false, CancellationToken ct = default(CancellationToken));

	Task<DataValue> ReadValueAsync(NodeId nodeId, CancellationToken ct = default(CancellationToken));

	Task<Node> ReadNodeAsync(NodeId nodeId, CancellationToken ct = default(CancellationToken));

	Task<Node> ReadNodeAsync(NodeId nodeId, NodeClass nodeClass, bool optionalAttributes = true, CancellationToken ct = default(CancellationToken));

	Task<(IList<Node>, IList<ServiceResult>)> ReadNodesAsync(IList<NodeId> nodeIds, bool optionalAttributes = false, CancellationToken ct = default(CancellationToken));

	Task<(DataValueCollection, IList<ServiceResult>)> ReadValuesAsync(IList<NodeId> nodeIds, CancellationToken ct = default(CancellationToken));

	StatusCode Close(int timeout);

	StatusCode Close(bool closeChannel);

	StatusCode Close(int timeout, bool closeChannel);

	Task<StatusCode> CloseAsync(CancellationToken ct = default(CancellationToken));

	Task<StatusCode> CloseAsync(bool closeChannel, CancellationToken ct = default(CancellationToken));

	Task<StatusCode> CloseAsync(int timeout, CancellationToken ct = default(CancellationToken));

	Task<StatusCode> CloseAsync(int timeout, bool closeChannel, CancellationToken ct = default(CancellationToken));

	bool AddSubscription(Subscription subscription);

	bool RemoveSubscription(Subscription subscription);

	bool RemoveSubscriptions(IEnumerable<Subscription> subscriptions);

	bool ReactivateSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues);

	bool TransferSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues);

	bool RemoveTransferredSubscription(Subscription subscription);

	Task<bool> RemoveSubscriptionAsync(Subscription subscription, CancellationToken ct = default(CancellationToken));

	Task<bool> RemoveSubscriptionsAsync(IEnumerable<Subscription> subscriptions, CancellationToken ct = default(CancellationToken));

	Task<bool> ReactivateSubscriptionsAsync(SubscriptionCollection subscriptions, bool sendInitialValues, CancellationToken ct = default(CancellationToken));

	Task<bool> TransferSubscriptionsAsync(SubscriptionCollection subscriptions, bool sendInitialValues, CancellationToken ct = default(CancellationToken));

	ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, NodeId nodeToBrowse, uint maxResultsToReturn, BrowseDirection browseDirection, NodeId referenceTypeId, bool includeSubtypes, uint nodeClassMask, out byte[] continuationPoint, out ReferenceDescriptionCollection references);

	IAsyncResult BeginBrowse(RequestHeader requestHeader, ViewDescription view, NodeId nodeToBrowse, uint maxResultsToReturn, BrowseDirection browseDirection, NodeId referenceTypeId, bool includeSubtypes, uint nodeClassMask, AsyncCallback callback, object asyncState);

	ResponseHeader EndBrowse(IAsyncResult result, out byte[] continuationPoint, out ReferenceDescriptionCollection references);

	ResponseHeader BrowseNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, out byte[] revisedContinuationPoint, out ReferenceDescriptionCollection references);

	IAsyncResult BeginBrowseNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, AsyncCallback callback, object asyncState);

	ResponseHeader EndBrowseNext(IAsyncResult result, out byte[] revisedContinuationPoint, out ReferenceDescriptionCollection references);

	IList<object> Call(NodeId objectId, NodeId methodId, params object[] args);

	Task<IList<object>> CallAsync(NodeId objectId, NodeId methodId, CancellationToken ct = default(CancellationToken), params object[] args);

	IAsyncResult BeginPublish(int timeout);

	bool Republish(uint subscriptionId, uint sequenceNumber);

	bool ResendData(IEnumerable<Subscription> subscriptions, out IList<ServiceResult> errors);

	Task<bool> RepublishAsync(uint subscriptionId, uint sequenceNumber, CancellationToken ct = default(CancellationToken));

	Task<(bool, IList<ServiceResult>)> ResendDataAsync(IEnumerable<Subscription> subscriptions, CancellationToken ct = default(CancellationToken));
}
