using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class TraceableSession : ISession, ISessionClient, ISessionClientMethods, IClientBase, IDisposable
{
	public static readonly string ActivitySourceName = "Opc.Ua.Client-TraceableSession-ActivitySource";

	private static readonly Lazy<ActivitySource> s_activitySource = new Lazy<ActivitySource>(() => new ActivitySource(ActivitySourceName, "1.0.0"));

	private readonly ISession m_session;

	public static ActivitySource ActivitySource => s_activitySource.Value;

	public ISession Session => m_session;

	public ISessionFactory SessionFactory => TraceableSessionFactory.Instance;

	public ConfiguredEndpoint ConfiguredEndpoint => m_session.ConfiguredEndpoint;

	public string SessionName => m_session.SessionName;

	public double SessionTimeout => m_session.SessionTimeout;

	public object Handle => m_session.Handle;

	public IUserIdentity Identity => m_session.Identity;

	public IEnumerable<IUserIdentity> IdentityHistory => m_session.IdentityHistory;

	public NamespaceTable NamespaceUris => m_session.NamespaceUris;

	public StringTable ServerUris => m_session.ServerUris;

	public ISystemContext SystemContext => m_session.SystemContext;

	public IEncodeableFactory Factory => m_session.Factory;

	public ITypeTable TypeTree => m_session.TypeTree;

	public INodeCache NodeCache => m_session.NodeCache;

	public FilterContext FilterContext => m_session.FilterContext;

	public StringCollection PreferredLocales => m_session.PreferredLocales;

	public IReadOnlyDictionary<NodeId, DataDictionary> DataTypeSystem => m_session.DataTypeSystem;

	public IEnumerable<Subscription> Subscriptions => m_session.Subscriptions;

	public int SubscriptionCount => m_session.SubscriptionCount;

	public bool DeleteSubscriptionsOnClose
	{
		get
		{
			return m_session.DeleteSubscriptionsOnClose;
		}
		set
		{
			m_session.DeleteSubscriptionsOnClose = value;
		}
	}

	public Subscription DefaultSubscription
	{
		get
		{
			return m_session.DefaultSubscription;
		}
		set
		{
			m_session.DefaultSubscription = value;
		}
	}

	public int KeepAliveInterval
	{
		get
		{
			return m_session.KeepAliveInterval;
		}
		set
		{
			m_session.KeepAliveInterval = value;
		}
	}

	public bool KeepAliveStopped => m_session.KeepAliveStopped;

	public DateTime LastKeepAliveTime => m_session.LastKeepAliveTime;

	public int OutstandingRequestCount => m_session.OutstandingRequestCount;

	public int DefunctRequestCount => m_session.DefunctRequestCount;

	public int GoodPublishRequestCount => m_session.GoodPublishRequestCount;

	public int MinPublishRequestCount
	{
		get
		{
			return m_session.MinPublishRequestCount;
		}
		set
		{
			m_session.MinPublishRequestCount = value;
		}
	}

	public OperationLimits OperationLimits => m_session.OperationLimits;

	public bool TransferSubscriptionsOnReconnect
	{
		get
		{
			return m_session.TransferSubscriptionsOnReconnect;
		}
		set
		{
			m_session.TransferSubscriptionsOnReconnect = value;
		}
	}

	public NodeId SessionId => m_session.SessionId;

	public bool Connected => m_session.Connected;

	public EndpointDescription Endpoint => m_session.Endpoint;

	public EndpointConfiguration EndpointConfiguration => m_session.EndpointConfiguration;

	public IServiceMessageContext MessageContext => m_session.MessageContext;

	public ITransportChannel TransportChannel => m_session.TransportChannel;

	public DiagnosticsMasks ReturnDiagnostics
	{
		get
		{
			return m_session.ReturnDiagnostics;
		}
		set
		{
			m_session.ReturnDiagnostics = value;
		}
	}

	public int OperationTimeout
	{
		get
		{
			return m_session.OperationTimeout;
		}
		set
		{
			m_session.OperationTimeout = value;
		}
	}

	public bool Disposed => m_session.Disposed;

	public bool CheckDomain => m_session.CheckDomain;

	public event KeepAliveEventHandler KeepAlive
	{
		add
		{
			m_session.KeepAlive += value;
		}
		remove
		{
			m_session.KeepAlive -= value;
		}
	}

	public event NotificationEventHandler Notification
	{
		add
		{
			m_session.Notification += value;
		}
		remove
		{
			m_session.Notification -= value;
		}
	}

	public event PublishErrorEventHandler PublishError
	{
		add
		{
			m_session.PublishError += value;
		}
		remove
		{
			m_session.PublishError -= value;
		}
	}

	public event PublishSequenceNumbersToAcknowledgeEventHandler PublishSequenceNumbersToAcknowledge
	{
		add
		{
			m_session.PublishSequenceNumbersToAcknowledge += value;
		}
		remove
		{
			m_session.PublishSequenceNumbersToAcknowledge -= value;
		}
	}

	public event EventHandler SubscriptionsChanged
	{
		add
		{
			m_session.SubscriptionsChanged += value;
		}
		remove
		{
			m_session.SubscriptionsChanged -= value;
		}
	}

	public event EventHandler SessionClosing
	{
		add
		{
			m_session.SessionClosing += value;
		}
		remove
		{
			m_session.SessionClosing -= value;
		}
	}

	public event EventHandler SessionConfigurationChanged
	{
		add
		{
			m_session.SessionConfigurationChanged += value;
		}
		remove
		{
			m_session.SessionConfigurationChanged -= value;
		}
	}

	public event RenewUserIdentityEventHandler RenewUserIdentity
	{
		add
		{
			m_session.RenewUserIdentity += value;
		}
		remove
		{
			m_session.RenewUserIdentity -= value;
		}
	}

	public TraceableSession(ISession session)
	{
		m_session = session;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (m_session == obj)
		{
			return true;
		}
		return m_session?.Equals(obj) ?? false;
	}

	public override int GetHashCode()
	{
		return m_session?.GetHashCode() ?? base.GetHashCode();
	}

	public void Reconnect()
	{
		using (ActivitySource.StartActivity("Reconnect"))
		{
			m_session.Reconnect();
		}
	}

	public void Reconnect(ITransportWaitingConnection connection)
	{
		using (ActivitySource.StartActivity("Reconnect"))
		{
			m_session.Reconnect(connection);
		}
	}

	public void Reconnect(ITransportChannel channel)
	{
		using (ActivitySource.StartActivity("Reconnect"))
		{
			m_session.Reconnect(channel);
		}
	}

	public async Task ReconnectAsync(CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReconnectAsync"))
		{
			await m_session.ReconnectAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task ReconnectAsync(ITransportWaitingConnection connection, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReconnectAsync"))
		{
			await m_session.ReconnectAsync(connection, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task ReconnectAsync(ITransportChannel channel, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReconnectAsync"))
		{
			await m_session.ReconnectAsync(channel, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public void Save(string filePath, IEnumerable<Type> knownTypes = null)
	{
		using (ActivitySource.StartActivity("Save"))
		{
			m_session.Save(filePath, knownTypes);
		}
	}

	public void Save(Stream stream, IEnumerable<Subscription> subscriptions, IEnumerable<Type> knownTypes = null)
	{
		using (ActivitySource.StartActivity("Save"))
		{
			m_session.Save(stream, subscriptions, knownTypes);
		}
	}

	public void Save(string filePath, IEnumerable<Subscription> subscriptions, IEnumerable<Type> knownTypes = null)
	{
		using (ActivitySource.StartActivity("Save"))
		{
			m_session.Save(filePath, subscriptions, knownTypes);
		}
	}

	public IEnumerable<Subscription> Load(Stream stream, bool transferSubscriptions = false, IEnumerable<Type> knownTypes = null)
	{
		using (ActivitySource.StartActivity("Load"))
		{
			return m_session.Load(stream, transferSubscriptions, knownTypes);
		}
	}

	public IEnumerable<Subscription> Load(string filePath, bool transferSubscriptions = false, IEnumerable<Type> knownTypes = null)
	{
		using (ActivitySource.StartActivity("Load"))
		{
			return m_session.Load(filePath, transferSubscriptions, knownTypes);
		}
	}

	public void FetchNamespaceTables()
	{
		using (ActivitySource.StartActivity("FetchNamespaceTables"))
		{
			m_session.FetchNamespaceTables();
		}
	}

	public void FetchTypeTree(ExpandedNodeId typeId)
	{
		using (ActivitySource.StartActivity("FetchTypeTree"))
		{
			m_session.FetchTypeTree(typeId);
		}
	}

	public void FetchTypeTree(ExpandedNodeIdCollection typeIds)
	{
		using (ActivitySource.StartActivity("FetchTypeTree"))
		{
			m_session.FetchTypeTree(typeIds);
		}
	}

	public async Task FetchTypeTreeAsync(ExpandedNodeId typeId, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("FetchTypeTreeAsync"))
		{
			await m_session.FetchTypeTreeAsync(typeId, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task FetchTypeTreeAsync(ExpandedNodeIdCollection typeIds, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("FetchTypeTreeAsync"))
		{
			await m_session.FetchTypeTreeAsync(typeIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ReferenceDescriptionCollection ReadAvailableEncodings(NodeId variableId)
	{
		using (ActivitySource.StartActivity("ReadAvailableEncodings"))
		{
			return m_session.ReadAvailableEncodings(variableId);
		}
	}

	public ReferenceDescription FindDataDescription(NodeId encodingId)
	{
		using (ActivitySource.StartActivity("FindDataDescription"))
		{
			return m_session.FindDataDescription(encodingId);
		}
	}

	public async Task<DataDictionary> FindDataDictionary(NodeId descriptionId, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("FindDataDictionary"))
		{
			return await m_session.FindDataDictionary(descriptionId, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public DataDictionary LoadDataDictionary(ReferenceDescription dictionaryNode, bool forceReload = false)
	{
		using (ActivitySource.StartActivity("LoadDataDictionary"))
		{
			return m_session.LoadDataDictionary(dictionaryNode, forceReload);
		}
	}

	public async Task<Dictionary<NodeId, DataDictionary>> LoadDataTypeSystem(NodeId dataTypeSystem = null, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("LoadDataTypeSystem"))
		{
			return await m_session.LoadDataTypeSystem(dataTypeSystem, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public Node ReadNode(NodeId nodeId)
	{
		using (ActivitySource.StartActivity("ReadNode"))
		{
			return m_session.ReadNode(nodeId);
		}
	}

	public Node ReadNode(NodeId nodeId, NodeClass nodeClass, bool optionalAttributes = true)
	{
		using (ActivitySource.StartActivity("ReadNode"))
		{
			return m_session.ReadNode(nodeId, nodeClass, optionalAttributes);
		}
	}

	public void ReadNodes(IList<NodeId> nodeIds, out IList<Node> nodeCollection, out IList<ServiceResult> errors, bool optionalAttributes = false)
	{
		using (ActivitySource.StartActivity("ReadNodes"))
		{
			m_session.ReadNodes(nodeIds, out nodeCollection, out errors, optionalAttributes);
		}
	}

	public void ReadNodes(IList<NodeId> nodeIds, NodeClass nodeClass, out IList<Node> nodeCollection, out IList<ServiceResult> errors, bool optionalAttributes = false)
	{
		using (ActivitySource.StartActivity("ReadNodes"))
		{
			m_session.ReadNodes(nodeIds, nodeClass, out nodeCollection, out errors, optionalAttributes);
		}
	}

	public DataValue ReadValue(NodeId nodeId)
	{
		using (ActivitySource.StartActivity("ReadValue"))
		{
			return m_session.ReadValue(nodeId);
		}
	}

	public object ReadValue(NodeId nodeId, Type expectedType)
	{
		using (ActivitySource.StartActivity("ReadValue"))
		{
			return m_session.ReadValue(nodeId, expectedType);
		}
	}

	public void ReadValues(IList<NodeId> nodeIds, out DataValueCollection values, out IList<ServiceResult> errors)
	{
		using (ActivitySource.StartActivity("ReadValues"))
		{
			m_session.ReadValues(nodeIds, out values, out errors);
		}
	}

	public ReferenceDescriptionCollection FetchReferences(NodeId nodeId)
	{
		using (ActivitySource.StartActivity("FetchReferences"))
		{
			return m_session.FetchReferences(nodeId);
		}
	}

	public void FetchReferences(IList<NodeId> nodeIds, out IList<ReferenceDescriptionCollection> referenceDescriptions, out IList<ServiceResult> errors)
	{
		using (ActivitySource.StartActivity("FetchReferences"))
		{
			m_session.FetchReferences(nodeIds, out referenceDescriptions, out errors);
		}
	}

	public async Task<ReferenceDescriptionCollection> FetchReferencesAsync(NodeId nodeId, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("FetchReferencesAsync"))
		{
			return await m_session.FetchReferencesAsync(nodeId, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<(IList<ReferenceDescriptionCollection>, IList<ServiceResult>)> FetchReferencesAsync(IList<NodeId> nodeIds, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("FetchReferencesAsync"))
		{
			return await m_session.FetchReferencesAsync(nodeIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public void Open(string sessionName, IUserIdentity identity)
	{
		using (ActivitySource.StartActivity("Open"))
		{
			m_session.Open(sessionName, identity);
		}
	}

	public void Open(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales)
	{
		using (ActivitySource.StartActivity("Open"))
		{
			m_session.Open(sessionName, sessionTimeout, identity, preferredLocales);
		}
	}

	public void Open(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, bool checkDomain)
	{
		using (ActivitySource.StartActivity("Open"))
		{
			m_session.Open(sessionName, sessionTimeout, identity, preferredLocales, checkDomain);
		}
	}

	public void ChangePreferredLocales(StringCollection preferredLocales)
	{
		using (ActivitySource.StartActivity("ChangePreferredLocales"))
		{
			m_session.ChangePreferredLocales(preferredLocales);
		}
	}

	public void UpdateSession(IUserIdentity identity, StringCollection preferredLocales)
	{
		using (ActivitySource.StartActivity("UpdateSession"))
		{
			m_session.UpdateSession(identity, preferredLocales);
		}
	}

	public void FindComponentIds(NodeId instanceId, IList<string> componentPaths, out NodeIdCollection componentIds, out List<ServiceResult> errors)
	{
		using (ActivitySource.StartActivity("FindComponentIds"))
		{
			m_session.FindComponentIds(instanceId, componentPaths, out componentIds, out errors);
		}
	}

	public void ReadValues(IList<NodeId> variableIds, IList<Type> expectedTypes, out List<object> values, out List<ServiceResult> errors)
	{
		using (ActivitySource.StartActivity("ReadValues"))
		{
			m_session.ReadValues(variableIds, expectedTypes, out values, out errors);
		}
	}

	public void ReadDisplayName(IList<NodeId> nodeIds, out IList<string> displayNames, out IList<ServiceResult> errors)
	{
		using (ActivitySource.StartActivity("ReadDisplayName"))
		{
			m_session.ReadDisplayName(nodeIds, out displayNames, out errors);
		}
	}

	public async Task OpenAsync(string sessionName, IUserIdentity identity, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("OpenAsync"))
		{
			await m_session.OpenAsync(sessionName, identity, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task OpenAsync(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("OpenAsync"))
		{
			await m_session.OpenAsync(sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task OpenAsync(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, bool checkDomain, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("OpenAsync"))
		{
			await m_session.OpenAsync(sessionName, sessionTimeout, identity, preferredLocales, checkDomain, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task FetchNamespaceTablesAsync(CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("FetchNamespaceTablesAsync"))
		{
			await m_session.FetchNamespaceTablesAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<(IList<Node>, IList<ServiceResult>)> ReadNodesAsync(IList<NodeId> nodeIds, NodeClass nodeClass, bool optionalAttributes = false, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReadNodesAsync"))
		{
			return await m_session.ReadNodesAsync(nodeIds, nodeClass, optionalAttributes, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<DataValue> ReadValueAsync(NodeId nodeId, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReadValueAsync"))
		{
			return await m_session.ReadValueAsync(nodeId, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<Node> ReadNodeAsync(NodeId nodeId, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReadNodeAsync"))
		{
			return await m_session.ReadNodeAsync(nodeId, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<Node> ReadNodeAsync(NodeId nodeId, NodeClass nodeClass, bool optionalAttributes = true, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReadNodeAsync"))
		{
			return await m_session.ReadNodeAsync(nodeId, nodeClass, optionalAttributes, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<(IList<Node>, IList<ServiceResult>)> ReadNodesAsync(IList<NodeId> nodeIds, bool optionalAttributes = false, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReadNodesAsync"))
		{
			return await m_session.ReadNodesAsync(nodeIds, optionalAttributes, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<(DataValueCollection, IList<ServiceResult>)> ReadValuesAsync(IList<NodeId> nodeIds, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReadValuesAsync"))
		{
			return await m_session.ReadValuesAsync(nodeIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public StatusCode Close(int timeout)
	{
		using (ActivitySource.StartActivity("Close"))
		{
			return m_session.Close(timeout);
		}
	}

	public StatusCode Close(bool closeChannel)
	{
		using (ActivitySource.StartActivity("Close"))
		{
			return m_session.Close(closeChannel);
		}
	}

	public StatusCode Close(int timeout, bool closeChannel)
	{
		using (ActivitySource.StartActivity("Close"))
		{
			return m_session.Close(timeout, closeChannel);
		}
	}

	public async Task<StatusCode> CloseAsync(CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("CloseAsync"))
		{
			return await m_session.CloseAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<StatusCode> CloseAsync(bool closeChannel, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("CloseAsync"))
		{
			return await m_session.CloseAsync(closeChannel, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<StatusCode> CloseAsync(int timeout, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("CloseAsync"))
		{
			return await m_session.CloseAsync(timeout, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<StatusCode> CloseAsync(int timeout, bool closeChannel, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("CloseAsync"))
		{
			return await m_session.CloseAsync(timeout, closeChannel, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public bool AddSubscription(Subscription subscription)
	{
		using (ActivitySource.StartActivity("AddSubscription"))
		{
			return m_session.AddSubscription(subscription);
		}
	}

	public bool RemoveSubscription(Subscription subscription)
	{
		using (ActivitySource.StartActivity("RemoveSubscription"))
		{
			return m_session.RemoveSubscription(subscription);
		}
	}

	public bool RemoveSubscriptions(IEnumerable<Subscription> subscriptions)
	{
		using (ActivitySource.StartActivity("RemoveSubscriptions"))
		{
			return m_session.RemoveSubscriptions(subscriptions);
		}
	}

	public bool TransferSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues)
	{
		using (ActivitySource.StartActivity("TransferSubscriptions"))
		{
			return m_session.TransferSubscriptions(subscriptions, sendInitialValues);
		}
	}

	public bool RemoveTransferredSubscription(Subscription subscription)
	{
		using (ActivitySource.StartActivity("RemoveTransferredSubscription"))
		{
			return m_session.RemoveTransferredSubscription(subscription);
		}
	}

	public async Task<bool> RemoveSubscriptionAsync(Subscription subscription)
	{
		using (ActivitySource.StartActivity("RemoveSubscriptionAsync"))
		{
			return await m_session.RemoveSubscriptionAsync(subscription).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<bool> RemoveSubscriptionsAsync(IEnumerable<Subscription> subscriptions)
	{
		using (ActivitySource.StartActivity("RemoveSubscriptionsAsync"))
		{
			return await m_session.RemoveSubscriptionsAsync(subscriptions).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, NodeId nodeToBrowse, uint maxResultsToReturn, BrowseDirection browseDirection, NodeId referenceTypeId, bool includeSubtypes, uint nodeClassMask, out byte[] continuationPoint, out ReferenceDescriptionCollection references)
	{
		using (ActivitySource.StartActivity("Browse"))
		{
			return m_session.Browse(requestHeader, view, nodeToBrowse, maxResultsToReturn, browseDirection, referenceTypeId, includeSubtypes, nodeClassMask, out continuationPoint, out references);
		}
	}

	public IAsyncResult BeginBrowse(RequestHeader requestHeader, ViewDescription view, NodeId nodeToBrowse, uint maxResultsToReturn, BrowseDirection browseDirection, NodeId referenceTypeId, bool includeSubtypes, uint nodeClassMask, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginBrowse(requestHeader, view, nodeToBrowse, maxResultsToReturn, browseDirection, referenceTypeId, includeSubtypes, nodeClassMask, callback, asyncState);
	}

	public ResponseHeader EndBrowse(IAsyncResult result, out byte[] continuationPoint, out ReferenceDescriptionCollection references)
	{
		return m_session.EndBrowse(result, out continuationPoint, out references);
	}

	public ResponseHeader BrowseNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, out byte[] revisedContinuationPoint, out ReferenceDescriptionCollection references)
	{
		using (ActivitySource.StartActivity("BrowseNext"))
		{
			return m_session.BrowseNext(requestHeader, releaseContinuationPoint, continuationPoint, out revisedContinuationPoint, out references);
		}
	}

	public IAsyncResult BeginBrowseNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginBrowseNext(requestHeader, releaseContinuationPoint, continuationPoint, callback, asyncState);
	}

	public ResponseHeader EndBrowseNext(IAsyncResult result, out byte[] revisedContinuationPoint, out ReferenceDescriptionCollection references)
	{
		return m_session.EndBrowseNext(result, out revisedContinuationPoint, out references);
	}

	public IList<object> Call(NodeId objectId, NodeId methodId, params object[] args)
	{
		using (ActivitySource.StartActivity("Call"))
		{
			return m_session.Call(objectId, methodId, args);
		}
	}

	public IAsyncResult BeginPublish(int timeout)
	{
		return m_session.BeginPublish(timeout);
	}

	public bool Republish(uint subscriptionId, uint sequenceNumber)
	{
		using (ActivitySource.StartActivity("Republish"))
		{
			return m_session.Republish(subscriptionId, sequenceNumber);
		}
	}

	public async Task<bool> RepublishAsync(uint subscriptionId, uint sequenceNumber, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("RepublishAsync"))
		{
			return await m_session.RepublishAsync(subscriptionId, sequenceNumber, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader CreateSession(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, out NodeId sessionId, out NodeId authenticationToken, out double revisedSessionTimeout, out byte[] serverNonce, out byte[] serverCertificate, out EndpointDescriptionCollection serverEndpoints, out SignedSoftwareCertificateCollection serverSoftwareCertificates, out SignatureData serverSignature, out uint maxRequestMessageSize)
	{
		using (ActivitySource.StartActivity("CreateSession"))
		{
			return m_session.CreateSession(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, out sessionId, out authenticationToken, out revisedSessionTimeout, out serverNonce, out serverCertificate, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out maxRequestMessageSize);
		}
	}

	public IAsyncResult BeginCreateSession(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginCreateSession(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, callback, asyncState);
	}

	public ResponseHeader EndCreateSession(IAsyncResult result, out NodeId sessionId, out NodeId authenticationToken, out double revisedSessionTimeout, out byte[] serverNonce, out byte[] serverCertificate, out EndpointDescriptionCollection serverEndpoints, out SignedSoftwareCertificateCollection serverSoftwareCertificates, out SignatureData serverSignature, out uint maxRequestMessageSize)
	{
		return m_session.EndCreateSession(result, out sessionId, out authenticationToken, out revisedSessionTimeout, out serverNonce, out serverCertificate, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out maxRequestMessageSize);
	}

	public async Task<CreateSessionResponse> CreateSessionAsync(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("CreateSessionAsync"))
		{
			return await m_session.CreateSessionAsync(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader ActivateSession(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, out byte[] serverNonce, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("ActivateSession"))
		{
			return m_session.ActivateSession(requestHeader, clientSignature, clientSoftwareCertificates, localeIds, userIdentityToken, userTokenSignature, out serverNonce, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginActivateSession(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginActivateSession(requestHeader, clientSignature, clientSoftwareCertificates, localeIds, userIdentityToken, userTokenSignature, callback, asyncState);
	}

	public ResponseHeader EndActivateSession(IAsyncResult result, out byte[] serverNonce, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndActivateSession(result, out serverNonce, out results, out diagnosticInfos);
	}

	public async Task<ActivateSessionResponse> ActivateSessionAsync(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("ActivateSessionAsync"))
		{
			return await m_session.ActivateSessionAsync(requestHeader, clientSignature, clientSoftwareCertificates, localeIds, userIdentityToken, userTokenSignature, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions)
	{
		using (ActivitySource.StartActivity("CloseSession"))
		{
			return m_session.CloseSession(requestHeader, deleteSubscriptions);
		}
	}

	public IAsyncResult BeginCloseSession(RequestHeader requestHeader, bool deleteSubscriptions, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginCloseSession(requestHeader, deleteSubscriptions, callback, asyncState);
	}

	public ResponseHeader EndCloseSession(IAsyncResult result)
	{
		return m_session.EndCloseSession(result);
	}

	public async Task<CloseSessionResponse> CloseSessionAsync(RequestHeader requestHeader, bool deleteSubscriptions, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("CloseSessionAsync"))
		{
			return await m_session.CloseSessionAsync(requestHeader, deleteSubscriptions, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader Cancel(RequestHeader requestHeader, uint requestHandle, out uint cancelCount)
	{
		using (ActivitySource.StartActivity("Cancel"))
		{
			return m_session.Cancel(requestHeader, requestHandle, out cancelCount);
		}
	}

	public IAsyncResult BeginCancel(RequestHeader requestHeader, uint requestHandle, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginCancel(requestHeader, requestHandle, callback, asyncState);
	}

	public ResponseHeader EndCancel(IAsyncResult result, out uint cancelCount)
	{
		return m_session.EndCancel(result, out cancelCount);
	}

	public async Task<CancelResponse> CancelAsync(RequestHeader requestHeader, uint requestHandle, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("CancelAsync"))
		{
			return await m_session.CancelAsync(requestHeader, requestHandle, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader AddNodes(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, out AddNodesResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("AddNodes"))
		{
			return m_session.AddNodes(requestHeader, nodesToAdd, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginAddNodes(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginAddNodes(requestHeader, nodesToAdd, callback, asyncState);
	}

	public ResponseHeader EndAddNodes(IAsyncResult result, out AddNodesResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndAddNodes(result, out results, out diagnosticInfos);
	}

	public async Task<AddNodesResponse> AddNodesAsync(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("AddNodesAsync"))
		{
			return await m_session.AddNodesAsync(requestHeader, nodesToAdd, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader AddReferences(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("AddReferences"))
		{
			return m_session.AddReferences(requestHeader, referencesToAdd, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginAddReferences(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginAddReferences(requestHeader, referencesToAdd, callback, asyncState);
	}

	public ResponseHeader EndAddReferences(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndAddReferences(result, out results, out diagnosticInfos);
	}

	public async Task<AddReferencesResponse> AddReferencesAsync(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("AddReferencesAsync"))
		{
			return await m_session.AddReferencesAsync(requestHeader, referencesToAdd, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader DeleteNodes(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("DeleteNodes"))
		{
			return m_session.DeleteNodes(requestHeader, nodesToDelete, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginDeleteNodes(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginDeleteNodes(requestHeader, nodesToDelete, callback, asyncState);
	}

	public ResponseHeader EndDeleteNodes(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndDeleteNodes(result, out results, out diagnosticInfos);
	}

	public async Task<DeleteNodesResponse> DeleteNodesAsync(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("DeleteNodesAsync"))
		{
			return await m_session.DeleteNodesAsync(requestHeader, nodesToDelete, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader DeleteReferences(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("DeleteReferences"))
		{
			return m_session.DeleteReferences(requestHeader, referencesToDelete, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginDeleteReferences(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginDeleteReferences(requestHeader, referencesToDelete, callback, asyncState);
	}

	public ResponseHeader EndDeleteReferences(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndDeleteReferences(result, out results, out diagnosticInfos);
	}

	public async Task<DeleteReferencesResponse> DeleteReferencesAsync(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("DeleteReferencesAsync"))
		{
			return await m_session.DeleteReferencesAsync(requestHeader, referencesToDelete, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("Browse"))
		{
			return m_session.Browse(requestHeader, view, requestedMaxReferencesPerNode, nodesToBrowse, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginBrowse(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginBrowse(requestHeader, view, requestedMaxReferencesPerNode, nodesToBrowse, callback, asyncState);
	}

	public ResponseHeader EndBrowse(IAsyncResult result, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndBrowse(result, out results, out diagnosticInfos);
	}

	public async Task<BrowseResponse> BrowseAsync(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("BrowseAsync"))
		{
			return await m_session.BrowseAsync(requestHeader, view, requestedMaxReferencesPerNode, nodesToBrowse, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader BrowseNext(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("BrowseNext"))
		{
			return m_session.BrowseNext(requestHeader, releaseContinuationPoints, continuationPoints, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginBrowseNext(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginBrowseNext(requestHeader, releaseContinuationPoints, continuationPoints, callback, asyncState);
	}

	public ResponseHeader EndBrowseNext(IAsyncResult result, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndBrowseNext(result, out results, out diagnosticInfos);
	}

	public async Task<BrowseNextResponse> BrowseNextAsync(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("BrowseNextAsync"))
		{
			return await m_session.BrowseNextAsync(requestHeader, releaseContinuationPoints, continuationPoints, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader TranslateBrowsePathsToNodeIds(RequestHeader requestHeader, BrowsePathCollection browsePaths, out BrowsePathResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("TranslateBrowsePathsToNodeIds"))
		{
			return m_session.TranslateBrowsePathsToNodeIds(requestHeader, browsePaths, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginTranslateBrowsePathsToNodeIds(RequestHeader requestHeader, BrowsePathCollection browsePaths, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginTranslateBrowsePathsToNodeIds(requestHeader, browsePaths, callback, asyncState);
	}

	public ResponseHeader EndTranslateBrowsePathsToNodeIds(IAsyncResult result, out BrowsePathResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndTranslateBrowsePathsToNodeIds(result, out results, out diagnosticInfos);
	}

	public async Task<TranslateBrowsePathsToNodeIdsResponse> TranslateBrowsePathsToNodeIdsAsync(RequestHeader requestHeader, BrowsePathCollection browsePaths, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("TranslateBrowsePathsToNodeIdsAsync"))
		{
			return await m_session.TranslateBrowsePathsToNodeIdsAsync(requestHeader, browsePaths, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader RegisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToRegister, out NodeIdCollection registeredNodeIds)
	{
		using (ActivitySource.StartActivity("RegisterNodes"))
		{
			return m_session.RegisterNodes(requestHeader, nodesToRegister, out registeredNodeIds);
		}
	}

	public IAsyncResult BeginRegisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToRegister, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginRegisterNodes(requestHeader, nodesToRegister, callback, asyncState);
	}

	public ResponseHeader EndRegisterNodes(IAsyncResult result, out NodeIdCollection registeredNodeIds)
	{
		return m_session.EndRegisterNodes(result, out registeredNodeIds);
	}

	public async Task<RegisterNodesResponse> RegisterNodesAsync(RequestHeader requestHeader, NodeIdCollection nodesToRegister, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("RegisterNodesAsync"))
		{
			return await m_session.RegisterNodesAsync(requestHeader, nodesToRegister, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader UnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister)
	{
		using (ActivitySource.StartActivity("UnregisterNodes"))
		{
			return m_session.UnregisterNodes(requestHeader, nodesToUnregister);
		}
	}

	public IAsyncResult BeginUnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginUnregisterNodes(requestHeader, nodesToUnregister, callback, asyncState);
	}

	public ResponseHeader EndUnregisterNodes(IAsyncResult result)
	{
		return m_session.EndUnregisterNodes(result);
	}

	public async Task<UnregisterNodesResponse> UnregisterNodesAsync(RequestHeader requestHeader, NodeIdCollection nodesToUnregister, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("UnregisterNodesAsync"))
		{
			return await m_session.UnregisterNodesAsync(requestHeader, nodesToUnregister, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader QueryFirst(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, out QueryDataSetCollection queryDataSets, out byte[] continuationPoint, out ParsingResultCollection parsingResults, out DiagnosticInfoCollection diagnosticInfos, out ContentFilterResult filterResult)
	{
		using (ActivitySource.StartActivity("QueryFirst"))
		{
			return m_session.QueryFirst(requestHeader, view, nodeTypes, filter, maxDataSetsToReturn, maxReferencesToReturn, out queryDataSets, out continuationPoint, out parsingResults, out diagnosticInfos, out filterResult);
		}
	}

	public IAsyncResult BeginQueryFirst(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginQueryFirst(requestHeader, view, nodeTypes, filter, maxDataSetsToReturn, maxReferencesToReturn, callback, asyncState);
	}

	public ResponseHeader EndQueryFirst(IAsyncResult result, out QueryDataSetCollection queryDataSets, out byte[] continuationPoint, out ParsingResultCollection parsingResults, out DiagnosticInfoCollection diagnosticInfos, out ContentFilterResult filterResult)
	{
		return m_session.EndQueryFirst(result, out queryDataSets, out continuationPoint, out parsingResults, out diagnosticInfos, out filterResult);
	}

	public async Task<QueryFirstResponse> QueryFirstAsync(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("QueryFirstAsync"))
		{
			return await m_session.QueryFirstAsync(requestHeader, view, nodeTypes, filter, maxDataSetsToReturn, maxReferencesToReturn, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader QueryNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, out QueryDataSetCollection queryDataSets, out byte[] revisedContinuationPoint)
	{
		using (ActivitySource.StartActivity("QueryNext"))
		{
			return m_session.QueryNext(requestHeader, releaseContinuationPoint, continuationPoint, out queryDataSets, out revisedContinuationPoint);
		}
	}

	public IAsyncResult BeginQueryNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginQueryNext(requestHeader, releaseContinuationPoint, continuationPoint, callback, asyncState);
	}

	public ResponseHeader EndQueryNext(IAsyncResult result, out QueryDataSetCollection queryDataSets, out byte[] revisedContinuationPoint)
	{
		return m_session.EndQueryNext(result, out queryDataSets, out revisedContinuationPoint);
	}

	public async Task<QueryNextResponse> QueryNextAsync(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("QueryNextAsync"))
		{
			return await m_session.QueryNextAsync(requestHeader, releaseContinuationPoint, continuationPoint, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader Read(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, out DataValueCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("Read"))
		{
			return m_session.Read(requestHeader, maxAge, timestampsToReturn, nodesToRead, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginRead(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginRead(requestHeader, maxAge, timestampsToReturn, nodesToRead, callback, asyncState);
	}

	public ResponseHeader EndRead(IAsyncResult result, out DataValueCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndRead(result, out results, out diagnosticInfos);
	}

	public async Task<ReadResponse> ReadAsync(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("ReadAsync"))
		{
			return await m_session.ReadAsync(requestHeader, maxAge, timestampsToReturn, nodesToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader HistoryRead(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, out HistoryReadResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("HistoryRead"))
		{
			return m_session.HistoryRead(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, nodesToRead, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginHistoryRead(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginHistoryRead(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, nodesToRead, callback, asyncState);
	}

	public ResponseHeader EndHistoryRead(IAsyncResult result, out HistoryReadResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndHistoryRead(result, out results, out diagnosticInfos);
	}

	public async Task<HistoryReadResponse> HistoryReadAsync(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("HistoryReadAsync"))
		{
			return await m_session.HistoryReadAsync(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, nodesToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader Write(RequestHeader requestHeader, WriteValueCollection nodesToWrite, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("Write"))
		{
			return m_session.Write(requestHeader, nodesToWrite, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginWrite(RequestHeader requestHeader, WriteValueCollection nodesToWrite, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginWrite(requestHeader, nodesToWrite, callback, asyncState);
	}

	public ResponseHeader EndWrite(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndWrite(result, out results, out diagnosticInfos);
	}

	public async Task<WriteResponse> WriteAsync(RequestHeader requestHeader, WriteValueCollection nodesToWrite, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("WriteAsync"))
		{
			return await m_session.WriteAsync(requestHeader, nodesToWrite, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader HistoryUpdate(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, out HistoryUpdateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("HistoryUpdate"))
		{
			return m_session.HistoryUpdate(requestHeader, historyUpdateDetails, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginHistoryUpdate(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginHistoryUpdate(requestHeader, historyUpdateDetails, callback, asyncState);
	}

	public ResponseHeader EndHistoryUpdate(IAsyncResult result, out HistoryUpdateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndHistoryUpdate(result, out results, out diagnosticInfos);
	}

	public async Task<HistoryUpdateResponse> HistoryUpdateAsync(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("HistoryUpdateAsync"))
		{
			return await m_session.HistoryUpdateAsync(requestHeader, historyUpdateDetails, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader Call(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, out CallMethodResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("Call"))
		{
			return m_session.Call(requestHeader, methodsToCall, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginCall(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginCall(requestHeader, methodsToCall, callback, asyncState);
	}

	public ResponseHeader EndCall(IAsyncResult result, out CallMethodResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndCall(result, out results, out diagnosticInfos);
	}

	public async Task<CallResponse> CallAsync(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("CallAsync"))
		{
			return await m_session.CallAsync(requestHeader, methodsToCall, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader CreateMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, out MonitoredItemCreateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("CreateMonitoredItems"))
		{
			return m_session.CreateMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, itemsToCreate, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginCreateMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginCreateMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, itemsToCreate, callback, asyncState);
	}

	public ResponseHeader EndCreateMonitoredItems(IAsyncResult result, out MonitoredItemCreateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndCreateMonitoredItems(result, out results, out diagnosticInfos);
	}

	public async Task<CreateMonitoredItemsResponse> CreateMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("CreateMonitoredItemsAsync"))
		{
			return await m_session.CreateMonitoredItemsAsync(requestHeader, subscriptionId, timestampsToReturn, itemsToCreate, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader ModifyMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, out MonitoredItemModifyResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("ModifyMonitoredItems"))
		{
			return m_session.ModifyMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, itemsToModify, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginModifyMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginModifyMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, itemsToModify, callback, asyncState);
	}

	public ResponseHeader EndModifyMonitoredItems(IAsyncResult result, out MonitoredItemModifyResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndModifyMonitoredItems(result, out results, out diagnosticInfos);
	}

	public async Task<ModifyMonitoredItemsResponse> ModifyMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("ModifyMonitoredItemsAsync"))
		{
			return await m_session.ModifyMonitoredItemsAsync(requestHeader, subscriptionId, timestampsToReturn, itemsToModify, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader SetMonitoringMode(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("SetMonitoringMode"))
		{
			return m_session.SetMonitoringMode(requestHeader, subscriptionId, monitoringMode, monitoredItemIds, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginSetMonitoringMode(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginSetMonitoringMode(requestHeader, subscriptionId, monitoringMode, monitoredItemIds, callback, asyncState);
	}

	public ResponseHeader EndSetMonitoringMode(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndSetMonitoringMode(result, out results, out diagnosticInfos);
	}

	public async Task<SetMonitoringModeResponse> SetMonitoringModeAsync(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("SetMonitoringModeAsync"))
		{
			return await m_session.SetMonitoringModeAsync(requestHeader, subscriptionId, monitoringMode, monitoredItemIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader SetTriggering(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, out StatusCodeCollection addResults, out DiagnosticInfoCollection addDiagnosticInfos, out StatusCodeCollection removeResults, out DiagnosticInfoCollection removeDiagnosticInfos)
	{
		using (ActivitySource.StartActivity("SetTriggering"))
		{
			return m_session.SetTriggering(requestHeader, subscriptionId, triggeringItemId, linksToAdd, linksToRemove, out addResults, out addDiagnosticInfos, out removeResults, out removeDiagnosticInfos);
		}
	}

	public IAsyncResult BeginSetTriggering(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginSetTriggering(requestHeader, subscriptionId, triggeringItemId, linksToAdd, linksToRemove, callback, asyncState);
	}

	public ResponseHeader EndSetTriggering(IAsyncResult result, out StatusCodeCollection addResults, out DiagnosticInfoCollection addDiagnosticInfos, out StatusCodeCollection removeResults, out DiagnosticInfoCollection removeDiagnosticInfos)
	{
		return m_session.EndSetTriggering(result, out addResults, out addDiagnosticInfos, out removeResults, out removeDiagnosticInfos);
	}

	public async Task<SetTriggeringResponse> SetTriggeringAsync(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("SetTriggeringAsync"))
		{
			return await m_session.SetTriggeringAsync(requestHeader, subscriptionId, triggeringItemId, linksToAdd, linksToRemove, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader DeleteMonitoredItems(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("DeleteMonitoredItems"))
		{
			return m_session.DeleteMonitoredItems(requestHeader, subscriptionId, monitoredItemIds, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginDeleteMonitoredItems(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginDeleteMonitoredItems(requestHeader, subscriptionId, monitoredItemIds, callback, asyncState);
	}

	public ResponseHeader EndDeleteMonitoredItems(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndDeleteMonitoredItems(result, out results, out diagnosticInfos);
	}

	public async Task<DeleteMonitoredItemsResponse> DeleteMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("DeleteMonitoredItemsAsync"))
		{
			return await m_session.DeleteMonitoredItemsAsync(requestHeader, subscriptionId, monitoredItemIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader CreateSubscription(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, out uint subscriptionId, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount)
	{
		using (ActivitySource.StartActivity("CreateSubscription"))
		{
			return m_session.CreateSubscription(requestHeader, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, publishingEnabled, priority, out subscriptionId, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
		}
	}

	public IAsyncResult BeginCreateSubscription(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginCreateSubscription(requestHeader, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, publishingEnabled, priority, callback, asyncState);
	}

	public ResponseHeader EndCreateSubscription(IAsyncResult result, out uint subscriptionId, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount)
	{
		return m_session.EndCreateSubscription(result, out subscriptionId, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
	}

	public async Task<CreateSubscriptionResponse> CreateSubscriptionAsync(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("CreateSubscriptionAsync"))
		{
			return await m_session.CreateSubscriptionAsync(requestHeader, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, publishingEnabled, priority, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader ModifySubscription(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount)
	{
		using (ActivitySource.StartActivity("ModifySubscription"))
		{
			return m_session.ModifySubscription(requestHeader, subscriptionId, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, priority, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
		}
	}

	public IAsyncResult BeginModifySubscription(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginModifySubscription(requestHeader, subscriptionId, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, priority, callback, asyncState);
	}

	public ResponseHeader EndModifySubscription(IAsyncResult result, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount)
	{
		return m_session.EndModifySubscription(result, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
	}

	public async Task<ModifySubscriptionResponse> ModifySubscriptionAsync(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("ModifySubscriptionAsync"))
		{
			return await m_session.ModifySubscriptionAsync(requestHeader, subscriptionId, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, priority, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader SetPublishingMode(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("SetPublishingMode"))
		{
			return m_session.SetPublishingMode(requestHeader, publishingEnabled, subscriptionIds, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginSetPublishingMode(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginSetPublishingMode(requestHeader, publishingEnabled, subscriptionIds, callback, asyncState);
	}

	public ResponseHeader EndSetPublishingMode(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndSetPublishingMode(result, out results, out diagnosticInfos);
	}

	public async Task<SetPublishingModeResponse> SetPublishingModeAsync(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("SetPublishingModeAsync"))
		{
			return await m_session.SetPublishingModeAsync(requestHeader, publishingEnabled, subscriptionIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader Publish(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, out uint subscriptionId, out UInt32Collection availableSequenceNumbers, out bool moreNotifications, out NotificationMessage notificationMessage, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("Publish"))
		{
			return m_session.Publish(requestHeader, subscriptionAcknowledgements, out subscriptionId, out availableSequenceNumbers, out moreNotifications, out notificationMessage, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginPublish(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginPublish(requestHeader, subscriptionAcknowledgements, callback, asyncState);
	}

	public ResponseHeader EndPublish(IAsyncResult result, out uint subscriptionId, out UInt32Collection availableSequenceNumbers, out bool moreNotifications, out NotificationMessage notificationMessage, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndPublish(result, out subscriptionId, out availableSequenceNumbers, out moreNotifications, out notificationMessage, out results, out diagnosticInfos);
	}

	public async Task<PublishResponse> PublishAsync(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("PublishAsync"))
		{
			return await m_session.PublishAsync(requestHeader, subscriptionAcknowledgements, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader Republish(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, out NotificationMessage notificationMessage)
	{
		using (ActivitySource.StartActivity("Republish"))
		{
			return m_session.Republish(requestHeader, subscriptionId, retransmitSequenceNumber, out notificationMessage);
		}
	}

	public IAsyncResult BeginRepublish(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginRepublish(requestHeader, subscriptionId, retransmitSequenceNumber, callback, asyncState);
	}

	public ResponseHeader EndRepublish(IAsyncResult result, out NotificationMessage notificationMessage)
	{
		return m_session.EndRepublish(result, out notificationMessage);
	}

	public async Task<RepublishResponse> RepublishAsync(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("RepublishAsync"))
		{
			return await m_session.RepublishAsync(requestHeader, subscriptionId, retransmitSequenceNumber, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader TransferSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, out TransferResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("TransferSubscriptions"))
		{
			return m_session.TransferSubscriptions(requestHeader, subscriptionIds, sendInitialValues, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginTransferSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginTransferSubscriptions(requestHeader, subscriptionIds, sendInitialValues, callback, asyncState);
	}

	public ResponseHeader EndTransferSubscriptions(IAsyncResult result, out TransferResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndTransferSubscriptions(result, out results, out diagnosticInfos);
	}

	public async Task<TransferSubscriptionsResponse> TransferSubscriptionsAsync(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("TransferSubscriptionsAsync"))
		{
			return await m_session.TransferSubscriptionsAsync(requestHeader, subscriptionIds, sendInitialValues, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public ResponseHeader DeleteSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		using (ActivitySource.StartActivity("DeleteSubscriptions"))
		{
			return m_session.DeleteSubscriptions(requestHeader, subscriptionIds, out results, out diagnosticInfos);
		}
	}

	public IAsyncResult BeginDeleteSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, AsyncCallback callback, object asyncState)
	{
		return m_session.BeginDeleteSubscriptions(requestHeader, subscriptionIds, callback, asyncState);
	}

	public ResponseHeader EndDeleteSubscriptions(IAsyncResult result, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return m_session.EndDeleteSubscriptions(result, out results, out diagnosticInfos);
	}

	public async Task<DeleteSubscriptionsResponse> DeleteSubscriptionsAsync(RequestHeader requestHeader, UInt32Collection subscriptionIds, CancellationToken ct)
	{
		using (ActivitySource.StartActivity("DeleteSubscriptionsAsync"))
		{
			return await m_session.DeleteSubscriptionsAsync(requestHeader, subscriptionIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public void AttachChannel(ITransportChannel channel)
	{
		using (ActivitySource.StartActivity("AttachChannel"))
		{
			m_session.AttachChannel(channel);
		}
	}

	public void DetachChannel()
	{
		using (ActivitySource.StartActivity("DetachChannel"))
		{
			m_session.DetachChannel();
		}
	}

	public StatusCode Close()
	{
		using (ActivitySource.StartActivity("Close"))
		{
			return m_session.Close();
		}
	}

	public uint NewRequestHandle()
	{
		return m_session.NewRequestHandle();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Utils.SilentDispose(m_session);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public SessionConfiguration SaveSessionConfiguration(Stream stream = null)
	{
		using (ActivitySource.StartActivity("SaveSessionConfiguration"))
		{
			return m_session.SaveSessionConfiguration(stream);
		}
	}

	public bool ApplySessionConfiguration(SessionConfiguration sessionConfiguration)
	{
		using (ActivitySource.StartActivity("ApplySessionConfiguration"))
		{
			return m_session.ApplySessionConfiguration(sessionConfiguration);
		}
	}

	public bool ReactivateSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues)
	{
		using (ActivitySource.StartActivity("ReactivateSubscriptions"))
		{
			return m_session.ReactivateSubscriptions(subscriptions, sendInitialValues);
		}
	}

	public async Task<bool> RemoveSubscriptionAsync(Subscription subscription, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("RemoveSubscriptionAsync"))
		{
			return await m_session.RemoveSubscriptionAsync(subscription, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<bool> RemoveSubscriptionsAsync(IEnumerable<Subscription> subscriptions, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("RemoveSubscriptionsAsync"))
		{
			return await m_session.RemoveSubscriptionsAsync(subscriptions, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<bool> ReactivateSubscriptionsAsync(SubscriptionCollection subscriptions, bool sendInitialValues, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ReactivateSubscriptionsAsync"))
		{
			return await m_session.ReactivateSubscriptionsAsync(subscriptions, sendInitialValues, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<bool> TransferSubscriptionsAsync(SubscriptionCollection subscriptions, bool sendInitialValues, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("TransferSubscriptionsAsync"))
		{
			return await m_session.TransferSubscriptionsAsync(subscriptions, sendInitialValues, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task<IList<object>> CallAsync(NodeId objectId, NodeId methodId, CancellationToken ct = default(CancellationToken), params object[] args)
	{
		using (ActivitySource.StartActivity("CallAsync"))
		{
			return await m_session.CallAsync(objectId, methodId, ct, args).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public bool ResendData(IEnumerable<Subscription> subscriptions, out IList<ServiceResult> errors)
	{
		using (ActivitySource.StartActivity("ResendData"))
		{
			return m_session.ResendData(subscriptions, out errors);
		}
	}

	public async Task<(bool, IList<ServiceResult>)> ResendDataAsync(IEnumerable<Subscription> subscriptions, CancellationToken ct = default(CancellationToken))
	{
		using (ActivitySource.StartActivity("ResendDataAsync"))
		{
			return await m_session.ResendDataAsync(subscriptions, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
