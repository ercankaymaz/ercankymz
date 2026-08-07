// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.TraceableSession
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class TraceableSession : 
  ISession,
  ISessionClient,
  ISessionClientMethods,
  IClientBase,
  IDisposable
{
  public static readonly string ActivitySourceName = "Opc.Ua.Client-TraceableSession-ActivitySource";
  private static readonly Lazy<ActivitySource> s_activitySource = new Lazy<ActivitySource>((Func<ActivitySource>) (() => new ActivitySource(TraceableSession.ActivitySourceName, "1.0.0")));
  private readonly ISession m_session;

  public TraceableSession(ISession session) => this.m_session = session;

  public static ActivitySource ActivitySource => TraceableSession.s_activitySource.Value;

  public ISession Session => this.m_session;

  public event KeepAliveEventHandler KeepAlive
  {
    add => this.m_session.KeepAlive += value;
    remove => this.m_session.KeepAlive -= value;
  }

  public event NotificationEventHandler Notification
  {
    add => this.m_session.Notification += value;
    remove => this.m_session.Notification -= value;
  }

  public event PublishErrorEventHandler PublishError
  {
    add => this.m_session.PublishError += value;
    remove => this.m_session.PublishError -= value;
  }

  public event PublishSequenceNumbersToAcknowledgeEventHandler PublishSequenceNumbersToAcknowledge
  {
    add => this.m_session.PublishSequenceNumbersToAcknowledge += value;
    remove => this.m_session.PublishSequenceNumbersToAcknowledge -= value;
  }

  public event EventHandler SubscriptionsChanged
  {
    add => this.m_session.SubscriptionsChanged += value;
    remove => this.m_session.SubscriptionsChanged -= value;
  }

  public event EventHandler SessionClosing
  {
    add => this.m_session.SessionClosing += value;
    remove => this.m_session.SessionClosing -= value;
  }

  public event EventHandler SessionConfigurationChanged
  {
    add => this.m_session.SessionConfigurationChanged += value;
    remove => this.m_session.SessionConfigurationChanged -= value;
  }

  public event RenewUserIdentityEventHandler RenewUserIdentity
  {
    add => this.m_session.RenewUserIdentity += value;
    remove => this.m_session.RenewUserIdentity -= value;
  }

  public ISessionFactory SessionFactory => (ISessionFactory) TraceableSessionFactory.Instance;

  public ConfiguredEndpoint ConfiguredEndpoint => this.m_session.ConfiguredEndpoint;

  public string SessionName => this.m_session.SessionName;

  public double SessionTimeout => this.m_session.SessionTimeout;

  public object Handle => this.m_session.Handle;

  public IUserIdentity Identity => this.m_session.Identity;

  public IEnumerable<IUserIdentity> IdentityHistory => this.m_session.IdentityHistory;

  public NamespaceTable NamespaceUris => this.m_session.NamespaceUris;

  public StringTable ServerUris => this.m_session.ServerUris;

  public ISystemContext SystemContext => this.m_session.SystemContext;

  public IEncodeableFactory Factory => this.m_session.Factory;

  public ITypeTable TypeTree => this.m_session.TypeTree;

  public INodeCache NodeCache => this.m_session.NodeCache;

  public FilterContext FilterContext => this.m_session.FilterContext;

  public StringCollection PreferredLocales => this.m_session.PreferredLocales;

  public IReadOnlyDictionary<NodeId, DataDictionary> DataTypeSystem
  {
    get => this.m_session.DataTypeSystem;
  }

  public IEnumerable<Subscription> Subscriptions => this.m_session.Subscriptions;

  public int SubscriptionCount => this.m_session.SubscriptionCount;

  public bool DeleteSubscriptionsOnClose
  {
    get => this.m_session.DeleteSubscriptionsOnClose;
    set => this.m_session.DeleteSubscriptionsOnClose = value;
  }

  public Subscription DefaultSubscription
  {
    get => this.m_session.DefaultSubscription;
    set => this.m_session.DefaultSubscription = value;
  }

  public int KeepAliveInterval
  {
    get => this.m_session.KeepAliveInterval;
    set => this.m_session.KeepAliveInterval = value;
  }

  public bool KeepAliveStopped => this.m_session.KeepAliveStopped;

  public DateTime LastKeepAliveTime => this.m_session.LastKeepAliveTime;

  public int OutstandingRequestCount => this.m_session.OutstandingRequestCount;

  public int DefunctRequestCount => this.m_session.DefunctRequestCount;

  public int GoodPublishRequestCount => this.m_session.GoodPublishRequestCount;

  public int MinPublishRequestCount
  {
    get => this.m_session.MinPublishRequestCount;
    set => this.m_session.MinPublishRequestCount = value;
  }

  public OperationLimits OperationLimits => this.m_session.OperationLimits;

  public bool TransferSubscriptionsOnReconnect
  {
    get => this.m_session.TransferSubscriptionsOnReconnect;
    set => this.m_session.TransferSubscriptionsOnReconnect = value;
  }

  public NodeId SessionId => this.m_session.SessionId;

  public bool Connected => this.m_session.Connected;

  public EndpointDescription Endpoint => this.m_session.Endpoint;

  public EndpointConfiguration EndpointConfiguration => this.m_session.EndpointConfiguration;

  public IServiceMessageContext MessageContext => this.m_session.MessageContext;

  public ITransportChannel TransportChannel => this.m_session.TransportChannel;

  public DiagnosticsMasks ReturnDiagnostics
  {
    get => this.m_session.ReturnDiagnostics;
    set => this.m_session.ReturnDiagnostics = value;
  }

  public int OperationTimeout
  {
    get => this.m_session.OperationTimeout;
    set => this.m_session.OperationTimeout = value;
  }

  public bool Disposed => this.m_session.Disposed;

  public bool CheckDomain => this.m_session.CheckDomain;

  public override bool Equals(object obj)
  {
    if (this == obj || this.m_session == obj)
      return true;
    ISession session = this.m_session;
    return session != null && session.Equals(obj);
  }

  public override int GetHashCode()
  {
    ISession session = this.m_session;
    return session == null ? base.GetHashCode() : session.GetHashCode();
  }

  public void Reconnect()
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Reconnect)))
      this.m_session.Reconnect();
  }

  public void Reconnect(ITransportWaitingConnection connection)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Reconnect)))
      this.m_session.Reconnect(connection);
  }

  public void Reconnect(ITransportChannel channel)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Reconnect)))
      this.m_session.Reconnect(channel);
  }

  public async Task ReconnectAsync(CancellationToken ct = default (CancellationToken))
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReconnectAsync)))
      await this.m_session.ReconnectAsync(ct).ConfigureAwait(false);
  }

  public async Task ReconnectAsync(ITransportWaitingConnection connection, CancellationToken ct = default (CancellationToken))
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReconnectAsync)))
      await this.m_session.ReconnectAsync(connection, ct).ConfigureAwait(false);
  }

  public async Task ReconnectAsync(ITransportChannel channel, CancellationToken ct = default (CancellationToken))
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReconnectAsync)))
      await this.m_session.ReconnectAsync(channel, ct).ConfigureAwait(false);
  }

  public void Save(string filePath, IEnumerable<Type> knownTypes = null)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Save)))
      this.m_session.Save(filePath, knownTypes);
  }

  public void Save(
    Stream stream,
    IEnumerable<Subscription> subscriptions,
    IEnumerable<Type> knownTypes = null)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Save)))
      this.m_session.Save(stream, subscriptions, knownTypes);
  }

  public void Save(
    string filePath,
    IEnumerable<Subscription> subscriptions,
    IEnumerable<Type> knownTypes = null)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Save)))
      this.m_session.Save(filePath, subscriptions, knownTypes);
  }

  public IEnumerable<Subscription> Load(
    Stream stream,
    bool transferSubscriptions = false,
    IEnumerable<Type> knownTypes = null)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Load)))
      return this.m_session.Load(stream, transferSubscriptions, knownTypes);
  }

  public IEnumerable<Subscription> Load(
    string filePath,
    bool transferSubscriptions = false,
    IEnumerable<Type> knownTypes = null)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Load)))
      return this.m_session.Load(filePath, transferSubscriptions, knownTypes);
  }

  public void FetchNamespaceTables()
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchNamespaceTables)))
      this.m_session.FetchNamespaceTables();
  }

  public void FetchTypeTree(ExpandedNodeId typeId)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchTypeTree)))
      this.m_session.FetchTypeTree(typeId);
  }

  public void FetchTypeTree(ExpandedNodeIdCollection typeIds)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchTypeTree)))
      this.m_session.FetchTypeTree(typeIds);
  }

  public async Task FetchTypeTreeAsync(ExpandedNodeId typeId, CancellationToken ct = default (CancellationToken))
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchTypeTreeAsync)))
      await this.m_session.FetchTypeTreeAsync(typeId, ct).ConfigureAwait(false);
  }

  public async Task FetchTypeTreeAsync(ExpandedNodeIdCollection typeIds, CancellationToken ct = default (CancellationToken))
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchTypeTreeAsync)))
      await this.m_session.FetchTypeTreeAsync(typeIds, ct).ConfigureAwait(false);
  }

  public ReferenceDescriptionCollection ReadAvailableEncodings(NodeId variableId)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadAvailableEncodings)))
      return this.m_session.ReadAvailableEncodings(variableId);
  }

  public ReferenceDescription FindDataDescription(NodeId encodingId)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FindDataDescription)))
      return this.m_session.FindDataDescription(encodingId);
  }

  public async Task<DataDictionary> FindDataDictionary(NodeId descriptionId, CancellationToken ct = default (CancellationToken))
  {
    DataDictionary dataDictionary;
    using (TraceableSession.ActivitySource.StartActivity(nameof (FindDataDictionary)))
      dataDictionary = await this.m_session.FindDataDictionary(descriptionId, ct).ConfigureAwait(false);
    return dataDictionary;
  }

  public DataDictionary LoadDataDictionary(ReferenceDescription dictionaryNode, bool forceReload = false)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (LoadDataDictionary)))
      return this.m_session.LoadDataDictionary(dictionaryNode, forceReload);
  }

  public async Task<Dictionary<NodeId, DataDictionary>> LoadDataTypeSystem(
    NodeId dataTypeSystem = null,
    CancellationToken ct = default (CancellationToken))
  {
    Dictionary<NodeId, DataDictionary> dictionary;
    using (TraceableSession.ActivitySource.StartActivity(nameof (LoadDataTypeSystem)))
      dictionary = await this.m_session.LoadDataTypeSystem(dataTypeSystem, ct).ConfigureAwait(false);
    return dictionary;
  }

  public Opc.Ua.Node ReadNode(NodeId nodeId)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadNode)))
      return this.m_session.ReadNode(nodeId);
  }

  public Opc.Ua.Node ReadNode(NodeId nodeId, NodeClass nodeClass, bool optionalAttributes = true)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadNode)))
      return this.m_session.ReadNode(nodeId, nodeClass, optionalAttributes);
  }

  public void ReadNodes(
    IList<NodeId> nodeIds,
    out IList<Opc.Ua.Node> nodeCollection,
    out IList<ServiceResult> errors,
    bool optionalAttributes = false)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadNodes)))
      this.m_session.ReadNodes(nodeIds, out nodeCollection, out errors, optionalAttributes);
  }

  public void ReadNodes(
    IList<NodeId> nodeIds,
    NodeClass nodeClass,
    out IList<Opc.Ua.Node> nodeCollection,
    out IList<ServiceResult> errors,
    bool optionalAttributes = false)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadNodes)))
      this.m_session.ReadNodes(nodeIds, nodeClass, out nodeCollection, out errors, optionalAttributes);
  }

  public DataValue ReadValue(NodeId nodeId)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadValue)))
      return this.m_session.ReadValue(nodeId);
  }

  public object ReadValue(NodeId nodeId, Type expectedType)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadValue)))
      return this.m_session.ReadValue(nodeId, expectedType);
  }

  public void ReadValues(
    IList<NodeId> nodeIds,
    out DataValueCollection values,
    out IList<ServiceResult> errors)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadValues)))
      this.m_session.ReadValues(nodeIds, out values, out errors);
  }

  public ReferenceDescriptionCollection FetchReferences(NodeId nodeId)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchReferences)))
      return this.m_session.FetchReferences(nodeId);
  }

  public void FetchReferences(
    IList<NodeId> nodeIds,
    out IList<ReferenceDescriptionCollection> referenceDescriptions,
    out IList<ServiceResult> errors)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchReferences)))
      this.m_session.FetchReferences(nodeIds, out referenceDescriptions, out errors);
  }

  public async Task<ReferenceDescriptionCollection> FetchReferencesAsync(
    NodeId nodeId,
    CancellationToken ct)
  {
    ReferenceDescriptionCollection descriptionCollection;
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchReferencesAsync)))
      descriptionCollection = await this.m_session.FetchReferencesAsync(nodeId, ct).ConfigureAwait(false);
    return descriptionCollection;
  }

  public async Task<(IList<ReferenceDescriptionCollection>, IList<ServiceResult>)> FetchReferencesAsync(
    IList<NodeId> nodeIds,
    CancellationToken ct)
  {
    (IList<ReferenceDescriptionCollection>, IList<ServiceResult>) valueTuple;
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchReferencesAsync)))
      valueTuple = await this.m_session.FetchReferencesAsync(nodeIds, ct).ConfigureAwait(false);
    return valueTuple;
  }

  public void Open(string sessionName, IUserIdentity identity)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Open)))
      this.m_session.Open(sessionName, identity);
  }

  public void Open(
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Open)))
      this.m_session.Open(sessionName, sessionTimeout, identity, preferredLocales);
  }

  public void Open(
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    bool checkDomain)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Open)))
      this.m_session.Open(sessionName, sessionTimeout, identity, preferredLocales, checkDomain);
  }

  public void ChangePreferredLocales(StringCollection preferredLocales)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ChangePreferredLocales)))
      this.m_session.ChangePreferredLocales(preferredLocales);
  }

  public void UpdateSession(IUserIdentity identity, StringCollection preferredLocales)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (UpdateSession)))
      this.m_session.UpdateSession(identity, preferredLocales);
  }

  public void FindComponentIds(
    NodeId instanceId,
    IList<string> componentPaths,
    out NodeIdCollection componentIds,
    out List<ServiceResult> errors)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FindComponentIds)))
      this.m_session.FindComponentIds(instanceId, componentPaths, out componentIds, out errors);
  }

  public void ReadValues(
    IList<NodeId> variableIds,
    IList<Type> expectedTypes,
    out List<object> values,
    out List<ServiceResult> errors)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadValues)))
      this.m_session.ReadValues(variableIds, expectedTypes, out values, out errors);
  }

  public void ReadDisplayName(
    IList<NodeId> nodeIds,
    out IList<string> displayNames,
    out IList<ServiceResult> errors)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadDisplayName)))
      this.m_session.ReadDisplayName(nodeIds, out displayNames, out errors);
  }

  public async Task OpenAsync(string sessionName, IUserIdentity identity, CancellationToken ct)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (OpenAsync)))
      await this.m_session.OpenAsync(sessionName, identity, ct).ConfigureAwait(false);
  }

  public async Task OpenAsync(
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (OpenAsync)))
      await this.m_session.OpenAsync(sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(false);
  }

  public async Task OpenAsync(
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    bool checkDomain,
    CancellationToken ct)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (OpenAsync)))
      await this.m_session.OpenAsync(sessionName, sessionTimeout, identity, preferredLocales, checkDomain, ct).ConfigureAwait(false);
  }

  public async Task FetchNamespaceTablesAsync(CancellationToken ct = default (CancellationToken))
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (FetchNamespaceTablesAsync)))
      await this.m_session.FetchNamespaceTablesAsync(ct).ConfigureAwait(false);
  }

  public async Task<(IList<Opc.Ua.Node>, IList<ServiceResult>)> ReadNodesAsync(
    IList<NodeId> nodeIds,
    NodeClass nodeClass,
    bool optionalAttributes = false,
    CancellationToken ct = default (CancellationToken))
  {
    (IList<Opc.Ua.Node>, IList<ServiceResult>) valueTuple;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadNodesAsync)))
      valueTuple = await this.m_session.ReadNodesAsync(nodeIds, nodeClass, optionalAttributes, ct).ConfigureAwait(false);
    return valueTuple;
  }

  public async Task<DataValue> ReadValueAsync(NodeId nodeId, CancellationToken ct = default (CancellationToken))
  {
    DataValue dataValue;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadValueAsync)))
      dataValue = await this.m_session.ReadValueAsync(nodeId, ct).ConfigureAwait(false);
    return dataValue;
  }

  public async Task<Opc.Ua.Node> ReadNodeAsync(NodeId nodeId, CancellationToken ct = default (CancellationToken))
  {
    Opc.Ua.Node node;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadNodeAsync)))
      node = await this.m_session.ReadNodeAsync(nodeId, ct).ConfigureAwait(false);
    return node;
  }

  public async Task<Opc.Ua.Node> ReadNodeAsync(
    NodeId nodeId,
    NodeClass nodeClass,
    bool optionalAttributes = true,
    CancellationToken ct = default (CancellationToken))
  {
    Opc.Ua.Node node;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadNodeAsync)))
      node = await this.m_session.ReadNodeAsync(nodeId, nodeClass, optionalAttributes, ct).ConfigureAwait(false);
    return node;
  }

  public async Task<(IList<Opc.Ua.Node>, IList<ServiceResult>)> ReadNodesAsync(
    IList<NodeId> nodeIds,
    bool optionalAttributes = false,
    CancellationToken ct = default (CancellationToken))
  {
    (IList<Opc.Ua.Node>, IList<ServiceResult>) valueTuple;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadNodesAsync)))
      valueTuple = await this.m_session.ReadNodesAsync(nodeIds, optionalAttributes, ct).ConfigureAwait(false);
    return valueTuple;
  }

  public async Task<(DataValueCollection, IList<ServiceResult>)> ReadValuesAsync(
    IList<NodeId> nodeIds,
    CancellationToken ct = default (CancellationToken))
  {
    (DataValueCollection, IList<ServiceResult>) valueTuple;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadValuesAsync)))
      valueTuple = await this.m_session.ReadValuesAsync(nodeIds, ct).ConfigureAwait(false);
    return valueTuple;
  }

  public StatusCode Close(int timeout)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Close)))
      return this.m_session.Close(timeout);
  }

  public StatusCode Close(bool closeChannel)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Close)))
      return this.m_session.Close(closeChannel);
  }

  public StatusCode Close(int timeout, bool closeChannel)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Close)))
      return this.m_session.Close(timeout, closeChannel);
  }

  public async Task<StatusCode> CloseAsync(CancellationToken ct = default (CancellationToken))
  {
    StatusCode statusCode;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CloseAsync)))
      statusCode = await this.m_session.CloseAsync(ct).ConfigureAwait(false);
    return statusCode;
  }

  public async Task<StatusCode> CloseAsync(bool closeChannel, CancellationToken ct = default (CancellationToken))
  {
    StatusCode statusCode;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CloseAsync)))
      statusCode = await this.m_session.CloseAsync(closeChannel, ct).ConfigureAwait(false);
    return statusCode;
  }

  public async Task<StatusCode> CloseAsync(int timeout, CancellationToken ct = default (CancellationToken))
  {
    StatusCode statusCode;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CloseAsync)))
      statusCode = await this.m_session.CloseAsync(timeout, ct).ConfigureAwait(false);
    return statusCode;
  }

  public async Task<StatusCode> CloseAsync(int timeout, bool closeChannel, CancellationToken ct = default (CancellationToken))
  {
    StatusCode statusCode;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CloseAsync)))
      statusCode = await this.m_session.CloseAsync(timeout, closeChannel, ct).ConfigureAwait(false);
    return statusCode;
  }

  public bool AddSubscription(Subscription subscription)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (AddSubscription)))
      return this.m_session.AddSubscription(subscription);
  }

  public bool RemoveSubscription(Subscription subscription)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (RemoveSubscription)))
      return this.m_session.RemoveSubscription(subscription);
  }

  public bool RemoveSubscriptions(IEnumerable<Subscription> subscriptions)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (RemoveSubscriptions)))
      return this.m_session.RemoveSubscriptions(subscriptions);
  }

  public bool TransferSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (TransferSubscriptions)))
      return this.m_session.TransferSubscriptions(subscriptions, sendInitialValues);
  }

  public bool RemoveTransferredSubscription(Subscription subscription)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (RemoveTransferredSubscription)))
      return this.m_session.RemoveTransferredSubscription(subscription);
  }

  public async Task<bool> RemoveSubscriptionAsync(Subscription subscription)
  {
    bool flag;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RemoveSubscriptionAsync)))
      flag = await this.m_session.RemoveSubscriptionAsync(subscription).ConfigureAwait(false);
    return flag;
  }

  public async Task<bool> RemoveSubscriptionsAsync(IEnumerable<Subscription> subscriptions)
  {
    bool flag;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RemoveSubscriptionsAsync)))
      flag = await this.m_session.RemoveSubscriptionsAsync(subscriptions).ConfigureAwait(false);
    return flag;
  }

  public ResponseHeader Browse(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeId nodeToBrowse,
    uint maxResultsToReturn,
    BrowseDirection browseDirection,
    NodeId referenceTypeId,
    bool includeSubtypes,
    uint nodeClassMask,
    out byte[] continuationPoint,
    out ReferenceDescriptionCollection references)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Browse)))
      return this.m_session.Browse(requestHeader, view, nodeToBrowse, maxResultsToReturn, browseDirection, referenceTypeId, includeSubtypes, nodeClassMask, out continuationPoint, out references);
  }

  public IAsyncResult BeginBrowse(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeId nodeToBrowse,
    uint maxResultsToReturn,
    BrowseDirection browseDirection,
    NodeId referenceTypeId,
    bool includeSubtypes,
    uint nodeClassMask,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginBrowse(requestHeader, view, nodeToBrowse, maxResultsToReturn, browseDirection, referenceTypeId, includeSubtypes, nodeClassMask, callback, asyncState);
  }

  public ResponseHeader EndBrowse(
    IAsyncResult result,
    out byte[] continuationPoint,
    out ReferenceDescriptionCollection references)
  {
    return this.m_session.EndBrowse(result, out continuationPoint, out references);
  }

  public ResponseHeader BrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    out byte[] revisedContinuationPoint,
    out ReferenceDescriptionCollection references)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (BrowseNext)))
      return this.m_session.BrowseNext(requestHeader, releaseContinuationPoint, continuationPoint, out revisedContinuationPoint, out references);
  }

  public IAsyncResult BeginBrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginBrowseNext(requestHeader, releaseContinuationPoint, continuationPoint, callback, asyncState);
  }

  public ResponseHeader EndBrowseNext(
    IAsyncResult result,
    out byte[] revisedContinuationPoint,
    out ReferenceDescriptionCollection references)
  {
    return this.m_session.EndBrowseNext(result, out revisedContinuationPoint, out references);
  }

  public IList<object> Call(NodeId objectId, NodeId methodId, params object[] args)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Call)))
      return this.m_session.Call(objectId, methodId, args);
  }

  public IAsyncResult BeginPublish(int timeout) => this.m_session.BeginPublish(timeout);

  public bool Republish(uint subscriptionId, uint sequenceNumber)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Republish)))
      return this.m_session.Republish(subscriptionId, sequenceNumber);
  }

  public async Task<bool> RepublishAsync(
    uint subscriptionId,
    uint sequenceNumber,
    CancellationToken ct = default (CancellationToken))
  {
    bool flag;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RepublishAsync)))
      flag = await this.m_session.RepublishAsync(subscriptionId, sequenceNumber, ct).ConfigureAwait(false);
    return flag;
  }

  public ResponseHeader CreateSession(
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
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateSession)))
      return this.m_session.CreateSession(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, out sessionId, out authenticationToken, out revisedSessionTimeout, out serverNonce, out serverCertificate, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out maxRequestMessageSize);
  }

  public IAsyncResult BeginCreateSession(
    RequestHeader requestHeader,
    ApplicationDescription clientDescription,
    string serverUri,
    string endpointUrl,
    string sessionName,
    byte[] clientNonce,
    byte[] clientCertificate,
    double requestedSessionTimeout,
    uint maxResponseMessageSize,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginCreateSession(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, callback, asyncState);
  }

  public ResponseHeader EndCreateSession(
    IAsyncResult result,
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
    return this.m_session.EndCreateSession(result, out sessionId, out authenticationToken, out revisedSessionTimeout, out serverNonce, out serverCertificate, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out maxRequestMessageSize);
  }

  public async Task<CreateSessionResponse> CreateSessionAsync(
    RequestHeader requestHeader,
    ApplicationDescription clientDescription,
    string serverUri,
    string endpointUrl,
    string sessionName,
    byte[] clientNonce,
    byte[] clientCertificate,
    double requestedSessionTimeout,
    uint maxResponseMessageSize,
    CancellationToken ct)
  {
    CreateSessionResponse sessionAsync;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateSessionAsync)))
      sessionAsync = await this.m_session.CreateSessionAsync(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, ct).ConfigureAwait(false);
    return sessionAsync;
  }

  public ResponseHeader ActivateSession(
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
    using (TraceableSession.ActivitySource.StartActivity(nameof (ActivateSession)))
      return this.m_session.ActivateSession(requestHeader, clientSignature, clientSoftwareCertificates, localeIds, userIdentityToken, userTokenSignature, out serverNonce, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginActivateSession(
    RequestHeader requestHeader,
    SignatureData clientSignature,
    SignedSoftwareCertificateCollection clientSoftwareCertificates,
    StringCollection localeIds,
    ExtensionObject userIdentityToken,
    SignatureData userTokenSignature,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginActivateSession(requestHeader, clientSignature, clientSoftwareCertificates, localeIds, userIdentityToken, userTokenSignature, callback, asyncState);
  }

  public ResponseHeader EndActivateSession(
    IAsyncResult result,
    out byte[] serverNonce,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndActivateSession(result, out serverNonce, out results, out diagnosticInfos);
  }

  public async Task<ActivateSessionResponse> ActivateSessionAsync(
    RequestHeader requestHeader,
    SignatureData clientSignature,
    SignedSoftwareCertificateCollection clientSoftwareCertificates,
    StringCollection localeIds,
    ExtensionObject userIdentityToken,
    SignatureData userTokenSignature,
    CancellationToken ct)
  {
    ActivateSessionResponse activateSessionResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ActivateSessionAsync)))
      activateSessionResponse = await this.m_session.ActivateSessionAsync(requestHeader, clientSignature, clientSoftwareCertificates, localeIds, userIdentityToken, userTokenSignature, ct).ConfigureAwait(false);
    return activateSessionResponse;
  }

  public ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (CloseSession)))
      return this.m_session.CloseSession(requestHeader, deleteSubscriptions);
  }

  public IAsyncResult BeginCloseSession(
    RequestHeader requestHeader,
    bool deleteSubscriptions,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginCloseSession(requestHeader, deleteSubscriptions, callback, asyncState);
  }

  public ResponseHeader EndCloseSession(IAsyncResult result)
  {
    return this.m_session.EndCloseSession(result);
  }

  public async Task<CloseSessionResponse> CloseSessionAsync(
    RequestHeader requestHeader,
    bool deleteSubscriptions,
    CancellationToken ct)
  {
    CloseSessionResponse closeSessionResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CloseSessionAsync)))
      closeSessionResponse = await this.m_session.CloseSessionAsync(requestHeader, deleteSubscriptions, ct).ConfigureAwait(false);
    return closeSessionResponse;
  }

  public ResponseHeader Cancel(
    RequestHeader requestHeader,
    uint requestHandle,
    out uint cancelCount)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Cancel)))
      return this.m_session.Cancel(requestHeader, requestHandle, out cancelCount);
  }

  public IAsyncResult BeginCancel(
    RequestHeader requestHeader,
    uint requestHandle,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginCancel(requestHeader, requestHandle, callback, asyncState);
  }

  public ResponseHeader EndCancel(IAsyncResult result, out uint cancelCount)
  {
    return this.m_session.EndCancel(result, out cancelCount);
  }

  public async Task<CancelResponse> CancelAsync(
    RequestHeader requestHeader,
    uint requestHandle,
    CancellationToken ct)
  {
    CancelResponse cancelResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CancelAsync)))
      cancelResponse = await this.m_session.CancelAsync(requestHeader, requestHandle, ct).ConfigureAwait(false);
    return cancelResponse;
  }

  public ResponseHeader AddNodes(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    out AddNodesResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (AddNodes)))
      return this.m_session.AddNodes(requestHeader, nodesToAdd, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginAddNodes(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginAddNodes(requestHeader, nodesToAdd, callback, asyncState);
  }

  public ResponseHeader EndAddNodes(
    IAsyncResult result,
    out AddNodesResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndAddNodes(result, out results, out diagnosticInfos);
  }

  public async Task<AddNodesResponse> AddNodesAsync(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    CancellationToken ct)
  {
    AddNodesResponse addNodesResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (AddNodesAsync)))
      addNodesResponse = await this.m_session.AddNodesAsync(requestHeader, nodesToAdd, ct).ConfigureAwait(false);
    return addNodesResponse;
  }

  public ResponseHeader AddReferences(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (AddReferences)))
      return this.m_session.AddReferences(requestHeader, referencesToAdd, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginAddReferences(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginAddReferences(requestHeader, referencesToAdd, callback, asyncState);
  }

  public ResponseHeader EndAddReferences(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndAddReferences(result, out results, out diagnosticInfos);
  }

  public async Task<AddReferencesResponse> AddReferencesAsync(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    CancellationToken ct)
  {
    AddReferencesResponse referencesResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (AddReferencesAsync)))
      referencesResponse = await this.m_session.AddReferencesAsync(requestHeader, referencesToAdd, ct).ConfigureAwait(false);
    return referencesResponse;
  }

  public ResponseHeader DeleteNodes(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (DeleteNodes)))
      return this.m_session.DeleteNodes(requestHeader, nodesToDelete, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginDeleteNodes(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginDeleteNodes(requestHeader, nodesToDelete, callback, asyncState);
  }

  public ResponseHeader EndDeleteNodes(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndDeleteNodes(result, out results, out diagnosticInfos);
  }

  public async Task<DeleteNodesResponse> DeleteNodesAsync(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    CancellationToken ct)
  {
    DeleteNodesResponse deleteNodesResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (DeleteNodesAsync)))
      deleteNodesResponse = await this.m_session.DeleteNodesAsync(requestHeader, nodesToDelete, ct).ConfigureAwait(false);
    return deleteNodesResponse;
  }

  public ResponseHeader DeleteReferences(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (DeleteReferences)))
      return this.m_session.DeleteReferences(requestHeader, referencesToDelete, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginDeleteReferences(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginDeleteReferences(requestHeader, referencesToDelete, callback, asyncState);
  }

  public ResponseHeader EndDeleteReferences(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndDeleteReferences(result, out results, out diagnosticInfos);
  }

  public async Task<DeleteReferencesResponse> DeleteReferencesAsync(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    CancellationToken ct)
  {
    DeleteReferencesResponse referencesResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (DeleteReferencesAsync)))
      referencesResponse = await this.m_session.DeleteReferencesAsync(requestHeader, referencesToDelete, ct).ConfigureAwait(false);
    return referencesResponse;
  }

  public ResponseHeader Browse(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Browse)))
      return this.m_session.Browse(requestHeader, view, requestedMaxReferencesPerNode, nodesToBrowse, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginBrowse(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginBrowse(requestHeader, view, requestedMaxReferencesPerNode, nodesToBrowse, callback, asyncState);
  }

  public ResponseHeader EndBrowse(
    IAsyncResult result,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndBrowse(result, out results, out diagnosticInfos);
  }

  public async Task<BrowseResponse> BrowseAsync(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    CancellationToken ct)
  {
    BrowseResponse browseResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (BrowseAsync)))
      browseResponse = await this.m_session.BrowseAsync(requestHeader, view, requestedMaxReferencesPerNode, nodesToBrowse, ct).ConfigureAwait(false);
    return browseResponse;
  }

  public ResponseHeader BrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoints,
    ByteStringCollection continuationPoints,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (BrowseNext)))
      return this.m_session.BrowseNext(requestHeader, releaseContinuationPoints, continuationPoints, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginBrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoints,
    ByteStringCollection continuationPoints,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginBrowseNext(requestHeader, releaseContinuationPoints, continuationPoints, callback, asyncState);
  }

  public ResponseHeader EndBrowseNext(
    IAsyncResult result,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndBrowseNext(result, out results, out diagnosticInfos);
  }

  public async Task<BrowseNextResponse> BrowseNextAsync(
    RequestHeader requestHeader,
    bool releaseContinuationPoints,
    ByteStringCollection continuationPoints,
    CancellationToken ct)
  {
    BrowseNextResponse browseNextResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (BrowseNextAsync)))
      browseNextResponse = await this.m_session.BrowseNextAsync(requestHeader, releaseContinuationPoints, continuationPoints, ct).ConfigureAwait(false);
    return browseNextResponse;
  }

  public ResponseHeader TranslateBrowsePathsToNodeIds(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    out BrowsePathResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (TranslateBrowsePathsToNodeIds)))
      return this.m_session.TranslateBrowsePathsToNodeIds(requestHeader, browsePaths, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginTranslateBrowsePathsToNodeIds(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginTranslateBrowsePathsToNodeIds(requestHeader, browsePaths, callback, asyncState);
  }

  public ResponseHeader EndTranslateBrowsePathsToNodeIds(
    IAsyncResult result,
    out BrowsePathResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndTranslateBrowsePathsToNodeIds(result, out results, out diagnosticInfos);
  }

  public async Task<TranslateBrowsePathsToNodeIdsResponse> TranslateBrowsePathsToNodeIdsAsync(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    CancellationToken ct)
  {
    TranslateBrowsePathsToNodeIdsResponse nodeIdsAsync;
    using (TraceableSession.ActivitySource.StartActivity(nameof (TranslateBrowsePathsToNodeIdsAsync)))
      nodeIdsAsync = await this.m_session.TranslateBrowsePathsToNodeIdsAsync(requestHeader, browsePaths, ct).ConfigureAwait(false);
    return nodeIdsAsync;
  }

  public ResponseHeader RegisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    out NodeIdCollection registeredNodeIds)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (RegisterNodes)))
      return this.m_session.RegisterNodes(requestHeader, nodesToRegister, out registeredNodeIds);
  }

  public IAsyncResult BeginRegisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginRegisterNodes(requestHeader, nodesToRegister, callback, asyncState);
  }

  public ResponseHeader EndRegisterNodes(
    IAsyncResult result,
    out NodeIdCollection registeredNodeIds)
  {
    return this.m_session.EndRegisterNodes(result, out registeredNodeIds);
  }

  public async Task<RegisterNodesResponse> RegisterNodesAsync(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    CancellationToken ct)
  {
    RegisterNodesResponse registerNodesResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RegisterNodesAsync)))
      registerNodesResponse = await this.m_session.RegisterNodesAsync(requestHeader, nodesToRegister, ct).ConfigureAwait(false);
    return registerNodesResponse;
  }

  public ResponseHeader UnregisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (UnregisterNodes)))
      return this.m_session.UnregisterNodes(requestHeader, nodesToUnregister);
  }

  public IAsyncResult BeginUnregisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginUnregisterNodes(requestHeader, nodesToUnregister, callback, asyncState);
  }

  public ResponseHeader EndUnregisterNodes(IAsyncResult result)
  {
    return this.m_session.EndUnregisterNodes(result);
  }

  public async Task<UnregisterNodesResponse> UnregisterNodesAsync(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister,
    CancellationToken ct)
  {
    UnregisterNodesResponse unregisterNodesResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (UnregisterNodesAsync)))
      unregisterNodesResponse = await this.m_session.UnregisterNodesAsync(requestHeader, nodesToUnregister, ct).ConfigureAwait(false);
    return unregisterNodesResponse;
  }

  public ResponseHeader QueryFirst(
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
    using (TraceableSession.ActivitySource.StartActivity(nameof (QueryFirst)))
      return this.m_session.QueryFirst(requestHeader, view, nodeTypes, filter, maxDataSetsToReturn, maxReferencesToReturn, out queryDataSets, out continuationPoint, out parsingResults, out diagnosticInfos, out filterResult);
  }

  public IAsyncResult BeginQueryFirst(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeTypeDescriptionCollection nodeTypes,
    ContentFilter filter,
    uint maxDataSetsToReturn,
    uint maxReferencesToReturn,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginQueryFirst(requestHeader, view, nodeTypes, filter, maxDataSetsToReturn, maxReferencesToReturn, callback, asyncState);
  }

  public ResponseHeader EndQueryFirst(
    IAsyncResult result,
    out QueryDataSetCollection queryDataSets,
    out byte[] continuationPoint,
    out ParsingResultCollection parsingResults,
    out DiagnosticInfoCollection diagnosticInfos,
    out ContentFilterResult filterResult)
  {
    return this.m_session.EndQueryFirst(result, out queryDataSets, out continuationPoint, out parsingResults, out diagnosticInfos, out filterResult);
  }

  public async Task<QueryFirstResponse> QueryFirstAsync(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeTypeDescriptionCollection nodeTypes,
    ContentFilter filter,
    uint maxDataSetsToReturn,
    uint maxReferencesToReturn,
    CancellationToken ct)
  {
    QueryFirstResponse queryFirstResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (QueryFirstAsync)))
      queryFirstResponse = await this.m_session.QueryFirstAsync(requestHeader, view, nodeTypes, filter, maxDataSetsToReturn, maxReferencesToReturn, ct).ConfigureAwait(false);
    return queryFirstResponse;
  }

  public ResponseHeader QueryNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    out QueryDataSetCollection queryDataSets,
    out byte[] revisedContinuationPoint)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (QueryNext)))
      return this.m_session.QueryNext(requestHeader, releaseContinuationPoint, continuationPoint, out queryDataSets, out revisedContinuationPoint);
  }

  public IAsyncResult BeginQueryNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginQueryNext(requestHeader, releaseContinuationPoint, continuationPoint, callback, asyncState);
  }

  public ResponseHeader EndQueryNext(
    IAsyncResult result,
    out QueryDataSetCollection queryDataSets,
    out byte[] revisedContinuationPoint)
  {
    return this.m_session.EndQueryNext(result, out queryDataSets, out revisedContinuationPoint);
  }

  public async Task<QueryNextResponse> QueryNextAsync(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    CancellationToken ct)
  {
    QueryNextResponse queryNextResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (QueryNextAsync)))
      queryNextResponse = await this.m_session.QueryNextAsync(requestHeader, releaseContinuationPoint, continuationPoint, ct).ConfigureAwait(false);
    return queryNextResponse;
  }

  public ResponseHeader Read(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    out DataValueCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Read)))
      return this.m_session.Read(requestHeader, maxAge, timestampsToReturn, nodesToRead, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginRead(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginRead(requestHeader, maxAge, timestampsToReturn, nodesToRead, callback, asyncState);
  }

  public ResponseHeader EndRead(
    IAsyncResult result,
    out DataValueCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndRead(result, out results, out diagnosticInfos);
  }

  public async Task<ReadResponse> ReadAsync(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    CancellationToken ct)
  {
    ReadResponse readResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReadAsync)))
      readResponse = await this.m_session.ReadAsync(requestHeader, maxAge, timestampsToReturn, nodesToRead, ct).ConfigureAwait(false);
    return readResponse;
  }

  public ResponseHeader HistoryRead(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    out HistoryReadResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (HistoryRead)))
      return this.m_session.HistoryRead(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, nodesToRead, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginHistoryRead(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginHistoryRead(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, nodesToRead, callback, asyncState);
  }

  public ResponseHeader EndHistoryRead(
    IAsyncResult result,
    out HistoryReadResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndHistoryRead(result, out results, out diagnosticInfos);
  }

  public async Task<HistoryReadResponse> HistoryReadAsync(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    CancellationToken ct)
  {
    HistoryReadResponse historyReadResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (HistoryReadAsync)))
      historyReadResponse = await this.m_session.HistoryReadAsync(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, nodesToRead, ct).ConfigureAwait(false);
    return historyReadResponse;
  }

  public ResponseHeader Write(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Write)))
      return this.m_session.Write(requestHeader, nodesToWrite, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginWrite(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginWrite(requestHeader, nodesToWrite, callback, asyncState);
  }

  public ResponseHeader EndWrite(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndWrite(result, out results, out diagnosticInfos);
  }

  public async Task<WriteResponse> WriteAsync(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    CancellationToken ct)
  {
    WriteResponse writeResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (WriteAsync)))
      writeResponse = await this.m_session.WriteAsync(requestHeader, nodesToWrite, ct).ConfigureAwait(false);
    return writeResponse;
  }

  public ResponseHeader HistoryUpdate(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    out HistoryUpdateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (HistoryUpdate)))
      return this.m_session.HistoryUpdate(requestHeader, historyUpdateDetails, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginHistoryUpdate(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginHistoryUpdate(requestHeader, historyUpdateDetails, callback, asyncState);
  }

  public ResponseHeader EndHistoryUpdate(
    IAsyncResult result,
    out HistoryUpdateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndHistoryUpdate(result, out results, out diagnosticInfos);
  }

  public async Task<HistoryUpdateResponse> HistoryUpdateAsync(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    CancellationToken ct)
  {
    HistoryUpdateResponse historyUpdateResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (HistoryUpdateAsync)))
      historyUpdateResponse = await this.m_session.HistoryUpdateAsync(requestHeader, historyUpdateDetails, ct).ConfigureAwait(false);
    return historyUpdateResponse;
  }

  public ResponseHeader Call(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    out CallMethodResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Call)))
      return this.m_session.Call(requestHeader, methodsToCall, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginCall(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginCall(requestHeader, methodsToCall, callback, asyncState);
  }

  public ResponseHeader EndCall(
    IAsyncResult result,
    out CallMethodResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndCall(result, out results, out diagnosticInfos);
  }

  public async Task<CallResponse> CallAsync(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    CancellationToken ct)
  {
    CallResponse callResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CallAsync)))
      callResponse = await this.m_session.CallAsync(requestHeader, methodsToCall, ct).ConfigureAwait(false);
    return callResponse;
  }

  public ResponseHeader CreateMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    out MonitoredItemCreateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateMonitoredItems)))
      return this.m_session.CreateMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, itemsToCreate, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginCreateMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginCreateMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, itemsToCreate, callback, asyncState);
  }

  public ResponseHeader EndCreateMonitoredItems(
    IAsyncResult result,
    out MonitoredItemCreateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndCreateMonitoredItems(result, out results, out diagnosticInfos);
  }

  public async Task<CreateMonitoredItemsResponse> CreateMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    CancellationToken ct)
  {
    CreateMonitoredItemsResponse monitoredItemsAsync;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateMonitoredItemsAsync)))
      monitoredItemsAsync = await this.m_session.CreateMonitoredItemsAsync(requestHeader, subscriptionId, timestampsToReturn, itemsToCreate, ct).ConfigureAwait(false);
    return monitoredItemsAsync;
  }

  public ResponseHeader ModifyMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    out MonitoredItemModifyResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ModifyMonitoredItems)))
      return this.m_session.ModifyMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, itemsToModify, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginModifyMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginModifyMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, itemsToModify, callback, asyncState);
  }

  public ResponseHeader EndModifyMonitoredItems(
    IAsyncResult result,
    out MonitoredItemModifyResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndModifyMonitoredItems(result, out results, out diagnosticInfos);
  }

  public async Task<ModifyMonitoredItemsResponse> ModifyMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    CancellationToken ct)
  {
    ModifyMonitoredItemsResponse monitoredItemsResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ModifyMonitoredItemsAsync)))
      monitoredItemsResponse = await this.m_session.ModifyMonitoredItemsAsync(requestHeader, subscriptionId, timestampsToReturn, itemsToModify, ct).ConfigureAwait(false);
    return monitoredItemsResponse;
  }

  public ResponseHeader SetMonitoringMode(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (SetMonitoringMode)))
      return this.m_session.SetMonitoringMode(requestHeader, subscriptionId, monitoringMode, monitoredItemIds, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginSetMonitoringMode(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginSetMonitoringMode(requestHeader, subscriptionId, monitoringMode, monitoredItemIds, callback, asyncState);
  }

  public ResponseHeader EndSetMonitoringMode(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndSetMonitoringMode(result, out results, out diagnosticInfos);
  }

  public async Task<SetMonitoringModeResponse> SetMonitoringModeAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    CancellationToken ct)
  {
    SetMonitoringModeResponse monitoringModeResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (SetMonitoringModeAsync)))
      monitoringModeResponse = await this.m_session.SetMonitoringModeAsync(requestHeader, subscriptionId, monitoringMode, monitoredItemIds, ct).ConfigureAwait(false);
    return monitoringModeResponse;
  }

  public ResponseHeader SetTriggering(
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
    using (TraceableSession.ActivitySource.StartActivity(nameof (SetTriggering)))
      return this.m_session.SetTriggering(requestHeader, subscriptionId, triggeringItemId, linksToAdd, linksToRemove, out addResults, out addDiagnosticInfos, out removeResults, out removeDiagnosticInfos);
  }

  public IAsyncResult BeginSetTriggering(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint triggeringItemId,
    UInt32Collection linksToAdd,
    UInt32Collection linksToRemove,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginSetTriggering(requestHeader, subscriptionId, triggeringItemId, linksToAdd, linksToRemove, callback, asyncState);
  }

  public ResponseHeader EndSetTriggering(
    IAsyncResult result,
    out StatusCodeCollection addResults,
    out DiagnosticInfoCollection addDiagnosticInfos,
    out StatusCodeCollection removeResults,
    out DiagnosticInfoCollection removeDiagnosticInfos)
  {
    return this.m_session.EndSetTriggering(result, out addResults, out addDiagnosticInfos, out removeResults, out removeDiagnosticInfos);
  }

  public async Task<SetTriggeringResponse> SetTriggeringAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint triggeringItemId,
    UInt32Collection linksToAdd,
    UInt32Collection linksToRemove,
    CancellationToken ct)
  {
    SetTriggeringResponse triggeringResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (SetTriggeringAsync)))
      triggeringResponse = await this.m_session.SetTriggeringAsync(requestHeader, subscriptionId, triggeringItemId, linksToAdd, linksToRemove, ct).ConfigureAwait(false);
    return triggeringResponse;
  }

  public ResponseHeader DeleteMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (DeleteMonitoredItems)))
      return this.m_session.DeleteMonitoredItems(requestHeader, subscriptionId, monitoredItemIds, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginDeleteMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginDeleteMonitoredItems(requestHeader, subscriptionId, monitoredItemIds, callback, asyncState);
  }

  public ResponseHeader EndDeleteMonitoredItems(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndDeleteMonitoredItems(result, out results, out diagnosticInfos);
  }

  public async Task<DeleteMonitoredItemsResponse> DeleteMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    CancellationToken ct)
  {
    DeleteMonitoredItemsResponse monitoredItemsResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (DeleteMonitoredItemsAsync)))
      monitoredItemsResponse = await this.m_session.DeleteMonitoredItemsAsync(requestHeader, subscriptionId, monitoredItemIds, ct).ConfigureAwait(false);
    return monitoredItemsResponse;
  }

  public ResponseHeader CreateSubscription(
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
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateSubscription)))
      return this.m_session.CreateSubscription(requestHeader, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, publishingEnabled, priority, out subscriptionId, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
  }

  public IAsyncResult BeginCreateSubscription(
    RequestHeader requestHeader,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    bool publishingEnabled,
    byte priority,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginCreateSubscription(requestHeader, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, publishingEnabled, priority, callback, asyncState);
  }

  public ResponseHeader EndCreateSubscription(
    IAsyncResult result,
    out uint subscriptionId,
    out double revisedPublishingInterval,
    out uint revisedLifetimeCount,
    out uint revisedMaxKeepAliveCount)
  {
    return this.m_session.EndCreateSubscription(result, out subscriptionId, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
  }

  public async Task<CreateSubscriptionResponse> CreateSubscriptionAsync(
    RequestHeader requestHeader,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    bool publishingEnabled,
    byte priority,
    CancellationToken ct)
  {
    CreateSubscriptionResponse subscriptionAsync;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateSubscriptionAsync)))
      subscriptionAsync = await this.m_session.CreateSubscriptionAsync(requestHeader, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, publishingEnabled, priority, ct).ConfigureAwait(false);
    return subscriptionAsync;
  }

  public ResponseHeader ModifySubscription(
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
    using (TraceableSession.ActivitySource.StartActivity(nameof (ModifySubscription)))
      return this.m_session.ModifySubscription(requestHeader, subscriptionId, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, priority, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
  }

  public IAsyncResult BeginModifySubscription(
    RequestHeader requestHeader,
    uint subscriptionId,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    byte priority,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginModifySubscription(requestHeader, subscriptionId, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, priority, callback, asyncState);
  }

  public ResponseHeader EndModifySubscription(
    IAsyncResult result,
    out double revisedPublishingInterval,
    out uint revisedLifetimeCount,
    out uint revisedMaxKeepAliveCount)
  {
    return this.m_session.EndModifySubscription(result, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
  }

  public async Task<ModifySubscriptionResponse> ModifySubscriptionAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    double requestedPublishingInterval,
    uint requestedLifetimeCount,
    uint requestedMaxKeepAliveCount,
    uint maxNotificationsPerPublish,
    byte priority,
    CancellationToken ct)
  {
    ModifySubscriptionResponse subscriptionResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ModifySubscriptionAsync)))
      subscriptionResponse = await this.m_session.ModifySubscriptionAsync(requestHeader, subscriptionId, requestedPublishingInterval, requestedLifetimeCount, requestedMaxKeepAliveCount, maxNotificationsPerPublish, priority, ct).ConfigureAwait(false);
    return subscriptionResponse;
  }

  public ResponseHeader SetPublishingMode(
    RequestHeader requestHeader,
    bool publishingEnabled,
    UInt32Collection subscriptionIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (SetPublishingMode)))
      return this.m_session.SetPublishingMode(requestHeader, publishingEnabled, subscriptionIds, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginSetPublishingMode(
    RequestHeader requestHeader,
    bool publishingEnabled,
    UInt32Collection subscriptionIds,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginSetPublishingMode(requestHeader, publishingEnabled, subscriptionIds, callback, asyncState);
  }

  public ResponseHeader EndSetPublishingMode(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndSetPublishingMode(result, out results, out diagnosticInfos);
  }

  public async Task<SetPublishingModeResponse> SetPublishingModeAsync(
    RequestHeader requestHeader,
    bool publishingEnabled,
    UInt32Collection subscriptionIds,
    CancellationToken ct)
  {
    SetPublishingModeResponse publishingModeResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (SetPublishingModeAsync)))
      publishingModeResponse = await this.m_session.SetPublishingModeAsync(requestHeader, publishingEnabled, subscriptionIds, ct).ConfigureAwait(false);
    return publishingModeResponse;
  }

  public ResponseHeader Publish(
    RequestHeader requestHeader,
    SubscriptionAcknowledgementCollection subscriptionAcknowledgements,
    out uint subscriptionId,
    out UInt32Collection availableSequenceNumbers,
    out bool moreNotifications,
    out NotificationMessage notificationMessage,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Publish)))
      return this.m_session.Publish(requestHeader, subscriptionAcknowledgements, out subscriptionId, out availableSequenceNumbers, out moreNotifications, out notificationMessage, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginPublish(
    RequestHeader requestHeader,
    SubscriptionAcknowledgementCollection subscriptionAcknowledgements,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginPublish(requestHeader, subscriptionAcknowledgements, callback, asyncState);
  }

  public ResponseHeader EndPublish(
    IAsyncResult result,
    out uint subscriptionId,
    out UInt32Collection availableSequenceNumbers,
    out bool moreNotifications,
    out NotificationMessage notificationMessage,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndPublish(result, out subscriptionId, out availableSequenceNumbers, out moreNotifications, out notificationMessage, out results, out diagnosticInfos);
  }

  public async Task<PublishResponse> PublishAsync(
    RequestHeader requestHeader,
    SubscriptionAcknowledgementCollection subscriptionAcknowledgements,
    CancellationToken ct)
  {
    PublishResponse publishResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (PublishAsync)))
      publishResponse = await this.m_session.PublishAsync(requestHeader, subscriptionAcknowledgements, ct).ConfigureAwait(false);
    return publishResponse;
  }

  public ResponseHeader Republish(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint retransmitSequenceNumber,
    out NotificationMessage notificationMessage)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Republish)))
      return this.m_session.Republish(requestHeader, subscriptionId, retransmitSequenceNumber, out notificationMessage);
  }

  public IAsyncResult BeginRepublish(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint retransmitSequenceNumber,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginRepublish(requestHeader, subscriptionId, retransmitSequenceNumber, callback, asyncState);
  }

  public ResponseHeader EndRepublish(
    IAsyncResult result,
    out NotificationMessage notificationMessage)
  {
    return this.m_session.EndRepublish(result, out notificationMessage);
  }

  public async Task<RepublishResponse> RepublishAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint retransmitSequenceNumber,
    CancellationToken ct)
  {
    RepublishResponse republishResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RepublishAsync)))
      republishResponse = await this.m_session.RepublishAsync(requestHeader, subscriptionId, retransmitSequenceNumber, ct).ConfigureAwait(false);
    return republishResponse;
  }

  public ResponseHeader TransferSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    out TransferResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (TransferSubscriptions)))
      return this.m_session.TransferSubscriptions(requestHeader, subscriptionIds, sendInitialValues, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginTransferSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginTransferSubscriptions(requestHeader, subscriptionIds, sendInitialValues, callback, asyncState);
  }

  public ResponseHeader EndTransferSubscriptions(
    IAsyncResult result,
    out TransferResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndTransferSubscriptions(result, out results, out diagnosticInfos);
  }

  public async Task<TransferSubscriptionsResponse> TransferSubscriptionsAsync(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    CancellationToken ct)
  {
    TransferSubscriptionsResponse subscriptionsResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (TransferSubscriptionsAsync)))
      subscriptionsResponse = await this.m_session.TransferSubscriptionsAsync(requestHeader, subscriptionIds, sendInitialValues, ct).ConfigureAwait(false);
    return subscriptionsResponse;
  }

  public ResponseHeader DeleteSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (DeleteSubscriptions)))
      return this.m_session.DeleteSubscriptions(requestHeader, subscriptionIds, out results, out diagnosticInfos);
  }

  public IAsyncResult BeginDeleteSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    AsyncCallback callback,
    object asyncState)
  {
    return this.m_session.BeginDeleteSubscriptions(requestHeader, subscriptionIds, callback, asyncState);
  }

  public ResponseHeader EndDeleteSubscriptions(
    IAsyncResult result,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return this.m_session.EndDeleteSubscriptions(result, out results, out diagnosticInfos);
  }

  public async Task<DeleteSubscriptionsResponse> DeleteSubscriptionsAsync(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    CancellationToken ct)
  {
    DeleteSubscriptionsResponse subscriptionsResponse;
    using (TraceableSession.ActivitySource.StartActivity(nameof (DeleteSubscriptionsAsync)))
      subscriptionsResponse = await this.m_session.DeleteSubscriptionsAsync(requestHeader, subscriptionIds, ct).ConfigureAwait(false);
    return subscriptionsResponse;
  }

  public void AttachChannel(ITransportChannel channel)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (AttachChannel)))
      this.m_session.AttachChannel(channel);
  }

  public void DetachChannel()
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (DetachChannel)))
      this.m_session.DetachChannel();
  }

  public StatusCode Close()
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Close)))
      return this.m_session.Close();
  }

  public uint NewRequestHandle() => this.m_session.NewRequestHandle();

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    Utils.SilentDispose((IDisposable) this.m_session);
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  public SessionConfiguration SaveSessionConfiguration(Stream stream = null)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (SaveSessionConfiguration)))
      return this.m_session.SaveSessionConfiguration(stream);
  }

  public bool ApplySessionConfiguration(SessionConfiguration sessionConfiguration)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ApplySessionConfiguration)))
      return this.m_session.ApplySessionConfiguration(sessionConfiguration);
  }

  public bool ReactivateSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReactivateSubscriptions)))
      return this.m_session.ReactivateSubscriptions(subscriptions, sendInitialValues);
  }

  public async Task<bool> RemoveSubscriptionAsync(Subscription subscription, CancellationToken ct = default (CancellationToken))
  {
    bool flag;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RemoveSubscriptionAsync)))
      flag = await this.m_session.RemoveSubscriptionAsync(subscription, ct).ConfigureAwait(false);
    return flag;
  }

  public async Task<bool> RemoveSubscriptionsAsync(
    IEnumerable<Subscription> subscriptions,
    CancellationToken ct = default (CancellationToken))
  {
    bool flag;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RemoveSubscriptionsAsync)))
      flag = await this.m_session.RemoveSubscriptionsAsync(subscriptions, ct).ConfigureAwait(false);
    return flag;
  }

  public async Task<bool> ReactivateSubscriptionsAsync(
    SubscriptionCollection subscriptions,
    bool sendInitialValues,
    CancellationToken ct = default (CancellationToken))
  {
    bool flag;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ReactivateSubscriptionsAsync)))
      flag = await this.m_session.ReactivateSubscriptionsAsync(subscriptions, sendInitialValues, ct).ConfigureAwait(false);
    return flag;
  }

  public async Task<bool> TransferSubscriptionsAsync(
    SubscriptionCollection subscriptions,
    bool sendInitialValues,
    CancellationToken ct = default (CancellationToken))
  {
    bool flag;
    using (TraceableSession.ActivitySource.StartActivity(nameof (TransferSubscriptionsAsync)))
      flag = await this.m_session.TransferSubscriptionsAsync(subscriptions, sendInitialValues, ct).ConfigureAwait(false);
    return flag;
  }

  public async Task<IList<object>> CallAsync(
    NodeId objectId,
    NodeId methodId,
    CancellationToken ct = default (CancellationToken),
    params object[] args)
  {
    IList<object> objectList;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CallAsync)))
      objectList = await this.m_session.CallAsync(objectId, methodId, ct, args).ConfigureAwait(false);
    return objectList;
  }

  public bool ResendData(IEnumerable<Subscription> subscriptions, out IList<ServiceResult> errors)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (ResendData)))
      return this.m_session.ResendData(subscriptions, out errors);
  }

  public async Task<(bool, IList<ServiceResult>)> ResendDataAsync(
    IEnumerable<Subscription> subscriptions,
    CancellationToken ct = default (CancellationToken))
  {
    (bool, IList<ServiceResult>) valueTuple;
    using (TraceableSession.ActivitySource.StartActivity(nameof (ResendDataAsync)))
      valueTuple = await this.m_session.ResendDataAsync(subscriptions, ct).ConfigureAwait(false);
    return valueTuple;
  }
}
