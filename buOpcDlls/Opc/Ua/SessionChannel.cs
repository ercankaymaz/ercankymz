// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionChannel : UaChannelBase<ISessionChannel>, ISessionChannel, IChannelBase
{
  public static ITransportChannel Create(
    ApplicationConfiguration configuration,
    EndpointDescription description,
    EndpointConfiguration endpointConfiguration,
    X509Certificate2 clientCertificate,
    IServiceMessageContext messageContext)
  {
    return SessionChannel.Create(configuration, description, endpointConfiguration, clientCertificate, (X509Certificate2Collection) null, messageContext);
  }

  public static ITransportChannel Create(
    ApplicationConfiguration configuration,
    EndpointDescription description,
    EndpointConfiguration endpointConfiguration,
    X509Certificate2 clientCertificate,
    X509Certificate2Collection clientCertificateChain,
    IServiceMessageContext messageContext)
  {
    return UaChannelBase.CreateUaBinaryChannel(configuration, description, endpointConfiguration, clientCertificate, clientCertificateChain, messageContext);
  }

  public static ITransportChannel Create(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    EndpointDescription description,
    EndpointConfiguration endpointConfiguration,
    X509Certificate2 clientCertificate,
    X509Certificate2Collection clientCertificateChain,
    IServiceMessageContext messageContext)
  {
    return UaChannelBase.CreateUaBinaryChannel(configuration, connection, description, endpointConfiguration, clientCertificate, clientCertificateChain, messageContext);
  }

  internal SessionChannel()
  {
  }

  public CreateSessionResponseMessage CreateSession(CreateSessionMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginCreateSession(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndCreateSession(result);
  }

  public IAsyncResult BeginCreateSession(
    CreateSessionMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult session = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (session.Lock)
      session.InnerResult = session.Channel.BeginCreateSession(request, new AsyncCallback(session.OnOperationCompleted), (object) null);
    return (IAsyncResult) session;
  }

  public CreateSessionResponseMessage EndCreateSession(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndCreateSession(channelAsyncResult.InnerResult);
  }

  public Task<CreateSessionResponseMessage> CreateSessionAsync(CreateSessionMessage request)
  {
    return this.Channel.CreateSessionAsync(request);
  }

  public ActivateSessionResponseMessage ActivateSession(ActivateSessionMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginActivateSession(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndActivateSession(result);
  }

  public IAsyncResult BeginActivateSession(
    ActivateSessionMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginActivateSession(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public ActivateSessionResponseMessage EndActivateSession(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndActivateSession(channelAsyncResult.InnerResult);
  }

  public Task<ActivateSessionResponseMessage> ActivateSessionAsync(ActivateSessionMessage request)
  {
    return this.Channel.ActivateSessionAsync(request);
  }

  public CloseSessionResponseMessage CloseSession(CloseSessionMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginCloseSession(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndCloseSession(result);
  }

  public IAsyncResult BeginCloseSession(
    CloseSessionMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginCloseSession(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public CloseSessionResponseMessage EndCloseSession(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndCloseSession(channelAsyncResult.InnerResult);
  }

  public Task<CloseSessionResponseMessage> CloseSessionAsync(CloseSessionMessage request)
  {
    return this.Channel.CloseSessionAsync(request);
  }

  public CancelResponseMessage Cancel(CancelMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginCancel(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndCancel(result);
  }

  public IAsyncResult BeginCancel(CancelMessage request, AsyncCallback callback, object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginCancel(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public CancelResponseMessage EndCancel(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndCancel(channelAsyncResult.InnerResult);
  }

  public Task<CancelResponseMessage> CancelAsync(CancelMessage request)
  {
    return this.Channel.CancelAsync(request);
  }

  public AddNodesResponseMessage AddNodes(AddNodesMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginAddNodes(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndAddNodes(result);
  }

  public IAsyncResult BeginAddNodes(
    AddNodesMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginAddNodes(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public AddNodesResponseMessage EndAddNodes(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndAddNodes(channelAsyncResult.InnerResult);
  }

  public Task<AddNodesResponseMessage> AddNodesAsync(AddNodesMessage request)
  {
    return this.Channel.AddNodesAsync(request);
  }

  public AddReferencesResponseMessage AddReferences(AddReferencesMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginAddReferences(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndAddReferences(result);
  }

  public IAsyncResult BeginAddReferences(
    AddReferencesMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginAddReferences(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public AddReferencesResponseMessage EndAddReferences(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndAddReferences(channelAsyncResult.InnerResult);
  }

  public Task<AddReferencesResponseMessage> AddReferencesAsync(AddReferencesMessage request)
  {
    return this.Channel.AddReferencesAsync(request);
  }

  public DeleteNodesResponseMessage DeleteNodes(DeleteNodesMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginDeleteNodes(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndDeleteNodes(result);
  }

  public IAsyncResult BeginDeleteNodes(
    DeleteNodesMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginDeleteNodes(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public DeleteNodesResponseMessage EndDeleteNodes(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndDeleteNodes(channelAsyncResult.InnerResult);
  }

  public Task<DeleteNodesResponseMessage> DeleteNodesAsync(DeleteNodesMessage request)
  {
    return this.Channel.DeleteNodesAsync(request);
  }

  public DeleteReferencesResponseMessage DeleteReferences(DeleteReferencesMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginDeleteReferences(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndDeleteReferences(result);
  }

  public IAsyncResult BeginDeleteReferences(
    DeleteReferencesMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginDeleteReferences(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public DeleteReferencesResponseMessage EndDeleteReferences(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndDeleteReferences(channelAsyncResult.InnerResult);
  }

  public Task<DeleteReferencesResponseMessage> DeleteReferencesAsync(DeleteReferencesMessage request)
  {
    return this.Channel.DeleteReferencesAsync(request);
  }

  public BrowseResponseMessage Browse(BrowseMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginBrowse(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndBrowse(result);
  }

  public IAsyncResult BeginBrowse(BrowseMessage request, AsyncCallback callback, object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginBrowse(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public BrowseResponseMessage EndBrowse(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndBrowse(channelAsyncResult.InnerResult);
  }

  public Task<BrowseResponseMessage> BrowseAsync(BrowseMessage request)
  {
    return this.Channel.BrowseAsync(request);
  }

  public BrowseNextResponseMessage BrowseNext(BrowseNextMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginBrowseNext(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndBrowseNext(result);
  }

  public IAsyncResult BeginBrowseNext(
    BrowseNextMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginBrowseNext(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public BrowseNextResponseMessage EndBrowseNext(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndBrowseNext(channelAsyncResult.InnerResult);
  }

  public Task<BrowseNextResponseMessage> BrowseNextAsync(BrowseNextMessage request)
  {
    return this.Channel.BrowseNextAsync(request);
  }

  public TranslateBrowsePathsToNodeIdsResponseMessage TranslateBrowsePathsToNodeIds(
    TranslateBrowsePathsToNodeIdsMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginTranslateBrowsePathsToNodeIds(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndTranslateBrowsePathsToNodeIds(result);
  }

  public IAsyncResult BeginTranslateBrowsePathsToNodeIds(
    TranslateBrowsePathsToNodeIdsMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult nodeIds = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (nodeIds.Lock)
      nodeIds.InnerResult = nodeIds.Channel.BeginTranslateBrowsePathsToNodeIds(request, new AsyncCallback(nodeIds.OnOperationCompleted), (object) null);
    return (IAsyncResult) nodeIds;
  }

  public TranslateBrowsePathsToNodeIdsResponseMessage EndTranslateBrowsePathsToNodeIds(
    IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndTranslateBrowsePathsToNodeIds(channelAsyncResult.InnerResult);
  }

  public Task<TranslateBrowsePathsToNodeIdsResponseMessage> TranslateBrowsePathsToNodeIdsAsync(
    TranslateBrowsePathsToNodeIdsMessage request)
  {
    return this.Channel.TranslateBrowsePathsToNodeIdsAsync(request);
  }

  public RegisterNodesResponseMessage RegisterNodes(RegisterNodesMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginRegisterNodes(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndRegisterNodes(result);
  }

  public IAsyncResult BeginRegisterNodes(
    RegisterNodesMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginRegisterNodes(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public RegisterNodesResponseMessage EndRegisterNodes(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndRegisterNodes(channelAsyncResult.InnerResult);
  }

  public Task<RegisterNodesResponseMessage> RegisterNodesAsync(RegisterNodesMessage request)
  {
    return this.Channel.RegisterNodesAsync(request);
  }

  public UnregisterNodesResponseMessage UnregisterNodes(UnregisterNodesMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginUnregisterNodes(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndUnregisterNodes(result);
  }

  public IAsyncResult BeginUnregisterNodes(
    UnregisterNodesMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginUnregisterNodes(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public UnregisterNodesResponseMessage EndUnregisterNodes(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndUnregisterNodes(channelAsyncResult.InnerResult);
  }

  public Task<UnregisterNodesResponseMessage> UnregisterNodesAsync(UnregisterNodesMessage request)
  {
    return this.Channel.UnregisterNodesAsync(request);
  }

  public QueryFirstResponseMessage QueryFirst(QueryFirstMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginQueryFirst(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndQueryFirst(result);
  }

  public IAsyncResult BeginQueryFirst(
    QueryFirstMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginQueryFirst(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public QueryFirstResponseMessage EndQueryFirst(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndQueryFirst(channelAsyncResult.InnerResult);
  }

  public Task<QueryFirstResponseMessage> QueryFirstAsync(QueryFirstMessage request)
  {
    return this.Channel.QueryFirstAsync(request);
  }

  public QueryNextResponseMessage QueryNext(QueryNextMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginQueryNext(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndQueryNext(result);
  }

  public IAsyncResult BeginQueryNext(
    QueryNextMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginQueryNext(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public QueryNextResponseMessage EndQueryNext(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndQueryNext(channelAsyncResult.InnerResult);
  }

  public Task<QueryNextResponseMessage> QueryNextAsync(QueryNextMessage request)
  {
    return this.Channel.QueryNextAsync(request);
  }

  public ReadResponseMessage Read(ReadMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginRead(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndRead(result);
  }

  public IAsyncResult BeginRead(ReadMessage request, AsyncCallback callback, object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginRead(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public ReadResponseMessage EndRead(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndRead(channelAsyncResult.InnerResult);
  }

  public Task<ReadResponseMessage> ReadAsync(ReadMessage request)
  {
    return this.Channel.ReadAsync(request);
  }

  public HistoryReadResponseMessage HistoryRead(HistoryReadMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginHistoryRead(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndHistoryRead(result);
  }

  public IAsyncResult BeginHistoryRead(
    HistoryReadMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginHistoryRead(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public HistoryReadResponseMessage EndHistoryRead(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndHistoryRead(channelAsyncResult.InnerResult);
  }

  public Task<HistoryReadResponseMessage> HistoryReadAsync(HistoryReadMessage request)
  {
    return this.Channel.HistoryReadAsync(request);
  }

  public WriteResponseMessage Write(WriteMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginWrite(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndWrite(result);
  }

  public IAsyncResult BeginWrite(WriteMessage request, AsyncCallback callback, object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginWrite(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public WriteResponseMessage EndWrite(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndWrite(channelAsyncResult.InnerResult);
  }

  public Task<WriteResponseMessage> WriteAsync(WriteMessage request)
  {
    return this.Channel.WriteAsync(request);
  }

  public HistoryUpdateResponseMessage HistoryUpdate(HistoryUpdateMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginHistoryUpdate(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndHistoryUpdate(result);
  }

  public IAsyncResult BeginHistoryUpdate(
    HistoryUpdateMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginHistoryUpdate(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public HistoryUpdateResponseMessage EndHistoryUpdate(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndHistoryUpdate(channelAsyncResult.InnerResult);
  }

  public Task<HistoryUpdateResponseMessage> HistoryUpdateAsync(HistoryUpdateMessage request)
  {
    return this.Channel.HistoryUpdateAsync(request);
  }

  public CallResponseMessage Call(CallMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginCall(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndCall(result);
  }

  public IAsyncResult BeginCall(CallMessage request, AsyncCallback callback, object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginCall(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public CallResponseMessage EndCall(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndCall(channelAsyncResult.InnerResult);
  }

  public Task<CallResponseMessage> CallAsync(CallMessage request)
  {
    return this.Channel.CallAsync(request);
  }

  public CreateMonitoredItemsResponseMessage CreateMonitoredItems(
    CreateMonitoredItemsMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginCreateMonitoredItems(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndCreateMonitoredItems(result);
  }

  public IAsyncResult BeginCreateMonitoredItems(
    CreateMonitoredItemsMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult monitoredItems = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (monitoredItems.Lock)
      monitoredItems.InnerResult = monitoredItems.Channel.BeginCreateMonitoredItems(request, new AsyncCallback(monitoredItems.OnOperationCompleted), (object) null);
    return (IAsyncResult) monitoredItems;
  }

  public CreateMonitoredItemsResponseMessage EndCreateMonitoredItems(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndCreateMonitoredItems(channelAsyncResult.InnerResult);
  }

  public Task<CreateMonitoredItemsResponseMessage> CreateMonitoredItemsAsync(
    CreateMonitoredItemsMessage request)
  {
    return this.Channel.CreateMonitoredItemsAsync(request);
  }

  public ModifyMonitoredItemsResponseMessage ModifyMonitoredItems(
    ModifyMonitoredItemsMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginModifyMonitoredItems(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndModifyMonitoredItems(result);
  }

  public IAsyncResult BeginModifyMonitoredItems(
    ModifyMonitoredItemsMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginModifyMonitoredItems(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public ModifyMonitoredItemsResponseMessage EndModifyMonitoredItems(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndModifyMonitoredItems(channelAsyncResult.InnerResult);
  }

  public Task<ModifyMonitoredItemsResponseMessage> ModifyMonitoredItemsAsync(
    ModifyMonitoredItemsMessage request)
  {
    return this.Channel.ModifyMonitoredItemsAsync(request);
  }

  public SetMonitoringModeResponseMessage SetMonitoringMode(SetMonitoringModeMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginSetMonitoringMode(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndSetMonitoringMode(result);
  }

  public IAsyncResult BeginSetMonitoringMode(
    SetMonitoringModeMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginSetMonitoringMode(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public SetMonitoringModeResponseMessage EndSetMonitoringMode(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndSetMonitoringMode(channelAsyncResult.InnerResult);
  }

  public Task<SetMonitoringModeResponseMessage> SetMonitoringModeAsync(
    SetMonitoringModeMessage request)
  {
    return this.Channel.SetMonitoringModeAsync(request);
  }

  public SetTriggeringResponseMessage SetTriggering(SetTriggeringMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginSetTriggering(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndSetTriggering(result);
  }

  public IAsyncResult BeginSetTriggering(
    SetTriggeringMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginSetTriggering(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public SetTriggeringResponseMessage EndSetTriggering(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndSetTriggering(channelAsyncResult.InnerResult);
  }

  public Task<SetTriggeringResponseMessage> SetTriggeringAsync(SetTriggeringMessage request)
  {
    return this.Channel.SetTriggeringAsync(request);
  }

  public DeleteMonitoredItemsResponseMessage DeleteMonitoredItems(
    DeleteMonitoredItemsMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginDeleteMonitoredItems(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndDeleteMonitoredItems(result);
  }

  public IAsyncResult BeginDeleteMonitoredItems(
    DeleteMonitoredItemsMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginDeleteMonitoredItems(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public DeleteMonitoredItemsResponseMessage EndDeleteMonitoredItems(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndDeleteMonitoredItems(channelAsyncResult.InnerResult);
  }

  public Task<DeleteMonitoredItemsResponseMessage> DeleteMonitoredItemsAsync(
    DeleteMonitoredItemsMessage request)
  {
    return this.Channel.DeleteMonitoredItemsAsync(request);
  }

  public CreateSubscriptionResponseMessage CreateSubscription(CreateSubscriptionMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginCreateSubscription(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndCreateSubscription(result);
  }

  public IAsyncResult BeginCreateSubscription(
    CreateSubscriptionMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult subscription = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (subscription.Lock)
      subscription.InnerResult = subscription.Channel.BeginCreateSubscription(request, new AsyncCallback(subscription.OnOperationCompleted), (object) null);
    return (IAsyncResult) subscription;
  }

  public CreateSubscriptionResponseMessage EndCreateSubscription(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndCreateSubscription(channelAsyncResult.InnerResult);
  }

  public Task<CreateSubscriptionResponseMessage> CreateSubscriptionAsync(
    CreateSubscriptionMessage request)
  {
    return this.Channel.CreateSubscriptionAsync(request);
  }

  public ModifySubscriptionResponseMessage ModifySubscription(ModifySubscriptionMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginModifySubscription(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndModifySubscription(result);
  }

  public IAsyncResult BeginModifySubscription(
    ModifySubscriptionMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginModifySubscription(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public ModifySubscriptionResponseMessage EndModifySubscription(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndModifySubscription(channelAsyncResult.InnerResult);
  }

  public Task<ModifySubscriptionResponseMessage> ModifySubscriptionAsync(
    ModifySubscriptionMessage request)
  {
    return this.Channel.ModifySubscriptionAsync(request);
  }

  public SetPublishingModeResponseMessage SetPublishingMode(SetPublishingModeMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginSetPublishingMode(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndSetPublishingMode(result);
  }

  public IAsyncResult BeginSetPublishingMode(
    SetPublishingModeMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginSetPublishingMode(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public SetPublishingModeResponseMessage EndSetPublishingMode(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndSetPublishingMode(channelAsyncResult.InnerResult);
  }

  public Task<SetPublishingModeResponseMessage> SetPublishingModeAsync(
    SetPublishingModeMessage request)
  {
    return this.Channel.SetPublishingModeAsync(request);
  }

  public PublishResponseMessage Publish(PublishMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginPublish(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndPublish(result);
  }

  public IAsyncResult BeginPublish(
    PublishMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginPublish(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public PublishResponseMessage EndPublish(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndPublish(channelAsyncResult.InnerResult);
  }

  public Task<PublishResponseMessage> PublishAsync(PublishMessage request)
  {
    return this.Channel.PublishAsync(request);
  }

  public RepublishResponseMessage Republish(RepublishMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginRepublish(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndRepublish(result);
  }

  public IAsyncResult BeginRepublish(
    RepublishMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginRepublish(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public RepublishResponseMessage EndRepublish(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndRepublish(channelAsyncResult.InnerResult);
  }

  public Task<RepublishResponseMessage> RepublishAsync(RepublishMessage request)
  {
    return this.Channel.RepublishAsync(request);
  }

  public TransferSubscriptionsResponseMessage TransferSubscriptions(
    TransferSubscriptionsMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginTransferSubscriptions(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndTransferSubscriptions(result);
  }

  public IAsyncResult BeginTransferSubscriptions(
    TransferSubscriptionsMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginTransferSubscriptions(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public TransferSubscriptionsResponseMessage EndTransferSubscriptions(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndTransferSubscriptions(channelAsyncResult.InnerResult);
  }

  public Task<TransferSubscriptionsResponseMessage> TransferSubscriptionsAsync(
    TransferSubscriptionsMessage request)
  {
    return this.Channel.TransferSubscriptionsAsync(request);
  }

  public DeleteSubscriptionsResponseMessage DeleteSubscriptions(DeleteSubscriptionsMessage request)
  {
    IAsyncResult result = (IAsyncResult) null;
    lock (this.Channel)
      result = this.Channel.BeginDeleteSubscriptions(request, (AsyncCallback) null, (object) null);
    return this.Channel.EndDeleteSubscriptions(result);
  }

  public IAsyncResult BeginDeleteSubscriptions(
    DeleteSubscriptionsMessage request,
    AsyncCallback callback,
    object asyncState)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = new UaChannelBase<ISessionChannel>.UaChannelAsyncResult(this.Channel, callback, asyncState);
    lock (channelAsyncResult.Lock)
      channelAsyncResult.InnerResult = channelAsyncResult.Channel.BeginDeleteSubscriptions(request, new AsyncCallback(channelAsyncResult.OnOperationCompleted), (object) null);
    return (IAsyncResult) channelAsyncResult;
  }

  public DeleteSubscriptionsResponseMessage EndDeleteSubscriptions(IAsyncResult result)
  {
    UaChannelBase<ISessionChannel>.UaChannelAsyncResult channelAsyncResult = UaChannelBase<ISessionChannel>.UaChannelAsyncResult.WaitForComplete(result);
    return channelAsyncResult.Channel.EndDeleteSubscriptions(channelAsyncResult.InnerResult);
  }

  public Task<DeleteSubscriptionsResponseMessage> DeleteSubscriptionsAsync(
    DeleteSubscriptionsMessage request)
  {
    return this.Channel.DeleteSubscriptionsAsync(request);
  }
}
