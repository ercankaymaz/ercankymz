using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionChannel : UaChannelBase<ISessionChannel>, ISessionChannel, IChannelBase
{
	public static ITransportChannel Create(ApplicationConfiguration configuration, EndpointDescription description, EndpointConfiguration endpointConfiguration, X509Certificate2 clientCertificate, IServiceMessageContext messageContext)
	{
		return Create(configuration, description, endpointConfiguration, clientCertificate, null, messageContext);
	}

	public static ITransportChannel Create(ApplicationConfiguration configuration, EndpointDescription description, EndpointConfiguration endpointConfiguration, X509Certificate2 clientCertificate, X509Certificate2Collection clientCertificateChain, IServiceMessageContext messageContext)
	{
		return UaChannelBase.CreateUaBinaryChannel(configuration, description, endpointConfiguration, clientCertificate, clientCertificateChain, messageContext);
	}

	public static ITransportChannel Create(ApplicationConfiguration configuration, ITransportWaitingConnection connection, EndpointDescription description, EndpointConfiguration endpointConfiguration, X509Certificate2 clientCertificate, X509Certificate2Collection clientCertificateChain, IServiceMessageContext messageContext)
	{
		return UaChannelBase.CreateUaBinaryChannel(configuration, connection, description, endpointConfiguration, clientCertificate, clientCertificateChain, messageContext);
	}

	internal SessionChannel()
	{
	}

	public CreateSessionResponseMessage CreateSession(CreateSessionMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginCreateSession(request, null, null);
		}
		return base.Channel.EndCreateSession(result);
	}

	public IAsyncResult BeginCreateSession(CreateSessionMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginCreateSession(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public CreateSessionResponseMessage EndCreateSession(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndCreateSession(uaChannelAsyncResult.InnerResult);
	}

	public Task<CreateSessionResponseMessage> CreateSessionAsync(CreateSessionMessage request)
	{
		return base.Channel.CreateSessionAsync(request);
	}

	public ActivateSessionResponseMessage ActivateSession(ActivateSessionMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginActivateSession(request, null, null);
		}
		return base.Channel.EndActivateSession(result);
	}

	public IAsyncResult BeginActivateSession(ActivateSessionMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginActivateSession(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public ActivateSessionResponseMessage EndActivateSession(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndActivateSession(uaChannelAsyncResult.InnerResult);
	}

	public Task<ActivateSessionResponseMessage> ActivateSessionAsync(ActivateSessionMessage request)
	{
		return base.Channel.ActivateSessionAsync(request);
	}

	public CloseSessionResponseMessage CloseSession(CloseSessionMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginCloseSession(request, null, null);
		}
		return base.Channel.EndCloseSession(result);
	}

	public IAsyncResult BeginCloseSession(CloseSessionMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginCloseSession(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public CloseSessionResponseMessage EndCloseSession(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndCloseSession(uaChannelAsyncResult.InnerResult);
	}

	public Task<CloseSessionResponseMessage> CloseSessionAsync(CloseSessionMessage request)
	{
		return base.Channel.CloseSessionAsync(request);
	}

	public CancelResponseMessage Cancel(CancelMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginCancel(request, null, null);
		}
		return base.Channel.EndCancel(result);
	}

	public IAsyncResult BeginCancel(CancelMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginCancel(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public CancelResponseMessage EndCancel(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndCancel(uaChannelAsyncResult.InnerResult);
	}

	public Task<CancelResponseMessage> CancelAsync(CancelMessage request)
	{
		return base.Channel.CancelAsync(request);
	}

	public AddNodesResponseMessage AddNodes(AddNodesMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginAddNodes(request, null, null);
		}
		return base.Channel.EndAddNodes(result);
	}

	public IAsyncResult BeginAddNodes(AddNodesMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginAddNodes(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public AddNodesResponseMessage EndAddNodes(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndAddNodes(uaChannelAsyncResult.InnerResult);
	}

	public Task<AddNodesResponseMessage> AddNodesAsync(AddNodesMessage request)
	{
		return base.Channel.AddNodesAsync(request);
	}

	public AddReferencesResponseMessage AddReferences(AddReferencesMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginAddReferences(request, null, null);
		}
		return base.Channel.EndAddReferences(result);
	}

	public IAsyncResult BeginAddReferences(AddReferencesMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginAddReferences(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public AddReferencesResponseMessage EndAddReferences(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndAddReferences(uaChannelAsyncResult.InnerResult);
	}

	public Task<AddReferencesResponseMessage> AddReferencesAsync(AddReferencesMessage request)
	{
		return base.Channel.AddReferencesAsync(request);
	}

	public DeleteNodesResponseMessage DeleteNodes(DeleteNodesMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginDeleteNodes(request, null, null);
		}
		return base.Channel.EndDeleteNodes(result);
	}

	public IAsyncResult BeginDeleteNodes(DeleteNodesMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginDeleteNodes(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public DeleteNodesResponseMessage EndDeleteNodes(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndDeleteNodes(uaChannelAsyncResult.InnerResult);
	}

	public Task<DeleteNodesResponseMessage> DeleteNodesAsync(DeleteNodesMessage request)
	{
		return base.Channel.DeleteNodesAsync(request);
	}

	public DeleteReferencesResponseMessage DeleteReferences(DeleteReferencesMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginDeleteReferences(request, null, null);
		}
		return base.Channel.EndDeleteReferences(result);
	}

	public IAsyncResult BeginDeleteReferences(DeleteReferencesMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginDeleteReferences(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public DeleteReferencesResponseMessage EndDeleteReferences(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndDeleteReferences(uaChannelAsyncResult.InnerResult);
	}

	public Task<DeleteReferencesResponseMessage> DeleteReferencesAsync(DeleteReferencesMessage request)
	{
		return base.Channel.DeleteReferencesAsync(request);
	}

	public BrowseResponseMessage Browse(BrowseMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginBrowse(request, null, null);
		}
		return base.Channel.EndBrowse(result);
	}

	public IAsyncResult BeginBrowse(BrowseMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginBrowse(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public BrowseResponseMessage EndBrowse(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndBrowse(uaChannelAsyncResult.InnerResult);
	}

	public Task<BrowseResponseMessage> BrowseAsync(BrowseMessage request)
	{
		return base.Channel.BrowseAsync(request);
	}

	public BrowseNextResponseMessage BrowseNext(BrowseNextMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginBrowseNext(request, null, null);
		}
		return base.Channel.EndBrowseNext(result);
	}

	public IAsyncResult BeginBrowseNext(BrowseNextMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginBrowseNext(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public BrowseNextResponseMessage EndBrowseNext(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndBrowseNext(uaChannelAsyncResult.InnerResult);
	}

	public Task<BrowseNextResponseMessage> BrowseNextAsync(BrowseNextMessage request)
	{
		return base.Channel.BrowseNextAsync(request);
	}

	public TranslateBrowsePathsToNodeIdsResponseMessage TranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginTranslateBrowsePathsToNodeIds(request, null, null);
		}
		return base.Channel.EndTranslateBrowsePathsToNodeIds(result);
	}

	public IAsyncResult BeginTranslateBrowsePathsToNodeIds(TranslateBrowsePathsToNodeIdsMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginTranslateBrowsePathsToNodeIds(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public TranslateBrowsePathsToNodeIdsResponseMessage EndTranslateBrowsePathsToNodeIds(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndTranslateBrowsePathsToNodeIds(uaChannelAsyncResult.InnerResult);
	}

	public Task<TranslateBrowsePathsToNodeIdsResponseMessage> TranslateBrowsePathsToNodeIdsAsync(TranslateBrowsePathsToNodeIdsMessage request)
	{
		return base.Channel.TranslateBrowsePathsToNodeIdsAsync(request);
	}

	public RegisterNodesResponseMessage RegisterNodes(RegisterNodesMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginRegisterNodes(request, null, null);
		}
		return base.Channel.EndRegisterNodes(result);
	}

	public IAsyncResult BeginRegisterNodes(RegisterNodesMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginRegisterNodes(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public RegisterNodesResponseMessage EndRegisterNodes(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndRegisterNodes(uaChannelAsyncResult.InnerResult);
	}

	public Task<RegisterNodesResponseMessage> RegisterNodesAsync(RegisterNodesMessage request)
	{
		return base.Channel.RegisterNodesAsync(request);
	}

	public UnregisterNodesResponseMessage UnregisterNodes(UnregisterNodesMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginUnregisterNodes(request, null, null);
		}
		return base.Channel.EndUnregisterNodes(result);
	}

	public IAsyncResult BeginUnregisterNodes(UnregisterNodesMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginUnregisterNodes(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public UnregisterNodesResponseMessage EndUnregisterNodes(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndUnregisterNodes(uaChannelAsyncResult.InnerResult);
	}

	public Task<UnregisterNodesResponseMessage> UnregisterNodesAsync(UnregisterNodesMessage request)
	{
		return base.Channel.UnregisterNodesAsync(request);
	}

	public QueryFirstResponseMessage QueryFirst(QueryFirstMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginQueryFirst(request, null, null);
		}
		return base.Channel.EndQueryFirst(result);
	}

	public IAsyncResult BeginQueryFirst(QueryFirstMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginQueryFirst(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public QueryFirstResponseMessage EndQueryFirst(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndQueryFirst(uaChannelAsyncResult.InnerResult);
	}

	public Task<QueryFirstResponseMessage> QueryFirstAsync(QueryFirstMessage request)
	{
		return base.Channel.QueryFirstAsync(request);
	}

	public QueryNextResponseMessage QueryNext(QueryNextMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginQueryNext(request, null, null);
		}
		return base.Channel.EndQueryNext(result);
	}

	public IAsyncResult BeginQueryNext(QueryNextMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginQueryNext(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public QueryNextResponseMessage EndQueryNext(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndQueryNext(uaChannelAsyncResult.InnerResult);
	}

	public Task<QueryNextResponseMessage> QueryNextAsync(QueryNextMessage request)
	{
		return base.Channel.QueryNextAsync(request);
	}

	public ReadResponseMessage Read(ReadMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginRead(request, null, null);
		}
		return base.Channel.EndRead(result);
	}

	public IAsyncResult BeginRead(ReadMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginRead(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public ReadResponseMessage EndRead(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndRead(uaChannelAsyncResult.InnerResult);
	}

	public Task<ReadResponseMessage> ReadAsync(ReadMessage request)
	{
		return base.Channel.ReadAsync(request);
	}

	public HistoryReadResponseMessage HistoryRead(HistoryReadMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginHistoryRead(request, null, null);
		}
		return base.Channel.EndHistoryRead(result);
	}

	public IAsyncResult BeginHistoryRead(HistoryReadMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginHistoryRead(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public HistoryReadResponseMessage EndHistoryRead(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndHistoryRead(uaChannelAsyncResult.InnerResult);
	}

	public Task<HistoryReadResponseMessage> HistoryReadAsync(HistoryReadMessage request)
	{
		return base.Channel.HistoryReadAsync(request);
	}

	public WriteResponseMessage Write(WriteMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginWrite(request, null, null);
		}
		return base.Channel.EndWrite(result);
	}

	public IAsyncResult BeginWrite(WriteMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginWrite(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public WriteResponseMessage EndWrite(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndWrite(uaChannelAsyncResult.InnerResult);
	}

	public Task<WriteResponseMessage> WriteAsync(WriteMessage request)
	{
		return base.Channel.WriteAsync(request);
	}

	public HistoryUpdateResponseMessage HistoryUpdate(HistoryUpdateMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginHistoryUpdate(request, null, null);
		}
		return base.Channel.EndHistoryUpdate(result);
	}

	public IAsyncResult BeginHistoryUpdate(HistoryUpdateMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginHistoryUpdate(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public HistoryUpdateResponseMessage EndHistoryUpdate(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndHistoryUpdate(uaChannelAsyncResult.InnerResult);
	}

	public Task<HistoryUpdateResponseMessage> HistoryUpdateAsync(HistoryUpdateMessage request)
	{
		return base.Channel.HistoryUpdateAsync(request);
	}

	public CallResponseMessage Call(CallMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginCall(request, null, null);
		}
		return base.Channel.EndCall(result);
	}

	public IAsyncResult BeginCall(CallMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginCall(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public CallResponseMessage EndCall(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndCall(uaChannelAsyncResult.InnerResult);
	}

	public Task<CallResponseMessage> CallAsync(CallMessage request)
	{
		return base.Channel.CallAsync(request);
	}

	public CreateMonitoredItemsResponseMessage CreateMonitoredItems(CreateMonitoredItemsMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginCreateMonitoredItems(request, null, null);
		}
		return base.Channel.EndCreateMonitoredItems(result);
	}

	public IAsyncResult BeginCreateMonitoredItems(CreateMonitoredItemsMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginCreateMonitoredItems(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public CreateMonitoredItemsResponseMessage EndCreateMonitoredItems(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndCreateMonitoredItems(uaChannelAsyncResult.InnerResult);
	}

	public Task<CreateMonitoredItemsResponseMessage> CreateMonitoredItemsAsync(CreateMonitoredItemsMessage request)
	{
		return base.Channel.CreateMonitoredItemsAsync(request);
	}

	public ModifyMonitoredItemsResponseMessage ModifyMonitoredItems(ModifyMonitoredItemsMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginModifyMonitoredItems(request, null, null);
		}
		return base.Channel.EndModifyMonitoredItems(result);
	}

	public IAsyncResult BeginModifyMonitoredItems(ModifyMonitoredItemsMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginModifyMonitoredItems(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public ModifyMonitoredItemsResponseMessage EndModifyMonitoredItems(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndModifyMonitoredItems(uaChannelAsyncResult.InnerResult);
	}

	public Task<ModifyMonitoredItemsResponseMessage> ModifyMonitoredItemsAsync(ModifyMonitoredItemsMessage request)
	{
		return base.Channel.ModifyMonitoredItemsAsync(request);
	}

	public SetMonitoringModeResponseMessage SetMonitoringMode(SetMonitoringModeMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginSetMonitoringMode(request, null, null);
		}
		return base.Channel.EndSetMonitoringMode(result);
	}

	public IAsyncResult BeginSetMonitoringMode(SetMonitoringModeMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginSetMonitoringMode(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public SetMonitoringModeResponseMessage EndSetMonitoringMode(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndSetMonitoringMode(uaChannelAsyncResult.InnerResult);
	}

	public Task<SetMonitoringModeResponseMessage> SetMonitoringModeAsync(SetMonitoringModeMessage request)
	{
		return base.Channel.SetMonitoringModeAsync(request);
	}

	public SetTriggeringResponseMessage SetTriggering(SetTriggeringMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginSetTriggering(request, null, null);
		}
		return base.Channel.EndSetTriggering(result);
	}

	public IAsyncResult BeginSetTriggering(SetTriggeringMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginSetTriggering(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public SetTriggeringResponseMessage EndSetTriggering(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndSetTriggering(uaChannelAsyncResult.InnerResult);
	}

	public Task<SetTriggeringResponseMessage> SetTriggeringAsync(SetTriggeringMessage request)
	{
		return base.Channel.SetTriggeringAsync(request);
	}

	public DeleteMonitoredItemsResponseMessage DeleteMonitoredItems(DeleteMonitoredItemsMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginDeleteMonitoredItems(request, null, null);
		}
		return base.Channel.EndDeleteMonitoredItems(result);
	}

	public IAsyncResult BeginDeleteMonitoredItems(DeleteMonitoredItemsMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginDeleteMonitoredItems(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public DeleteMonitoredItemsResponseMessage EndDeleteMonitoredItems(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndDeleteMonitoredItems(uaChannelAsyncResult.InnerResult);
	}

	public Task<DeleteMonitoredItemsResponseMessage> DeleteMonitoredItemsAsync(DeleteMonitoredItemsMessage request)
	{
		return base.Channel.DeleteMonitoredItemsAsync(request);
	}

	public CreateSubscriptionResponseMessage CreateSubscription(CreateSubscriptionMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginCreateSubscription(request, null, null);
		}
		return base.Channel.EndCreateSubscription(result);
	}

	public IAsyncResult BeginCreateSubscription(CreateSubscriptionMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginCreateSubscription(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public CreateSubscriptionResponseMessage EndCreateSubscription(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndCreateSubscription(uaChannelAsyncResult.InnerResult);
	}

	public Task<CreateSubscriptionResponseMessage> CreateSubscriptionAsync(CreateSubscriptionMessage request)
	{
		return base.Channel.CreateSubscriptionAsync(request);
	}

	public ModifySubscriptionResponseMessage ModifySubscription(ModifySubscriptionMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginModifySubscription(request, null, null);
		}
		return base.Channel.EndModifySubscription(result);
	}

	public IAsyncResult BeginModifySubscription(ModifySubscriptionMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginModifySubscription(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public ModifySubscriptionResponseMessage EndModifySubscription(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndModifySubscription(uaChannelAsyncResult.InnerResult);
	}

	public Task<ModifySubscriptionResponseMessage> ModifySubscriptionAsync(ModifySubscriptionMessage request)
	{
		return base.Channel.ModifySubscriptionAsync(request);
	}

	public SetPublishingModeResponseMessage SetPublishingMode(SetPublishingModeMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginSetPublishingMode(request, null, null);
		}
		return base.Channel.EndSetPublishingMode(result);
	}

	public IAsyncResult BeginSetPublishingMode(SetPublishingModeMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginSetPublishingMode(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public SetPublishingModeResponseMessage EndSetPublishingMode(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndSetPublishingMode(uaChannelAsyncResult.InnerResult);
	}

	public Task<SetPublishingModeResponseMessage> SetPublishingModeAsync(SetPublishingModeMessage request)
	{
		return base.Channel.SetPublishingModeAsync(request);
	}

	public PublishResponseMessage Publish(PublishMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginPublish(request, null, null);
		}
		return base.Channel.EndPublish(result);
	}

	public IAsyncResult BeginPublish(PublishMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginPublish(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public PublishResponseMessage EndPublish(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndPublish(uaChannelAsyncResult.InnerResult);
	}

	public Task<PublishResponseMessage> PublishAsync(PublishMessage request)
	{
		return base.Channel.PublishAsync(request);
	}

	public RepublishResponseMessage Republish(RepublishMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginRepublish(request, null, null);
		}
		return base.Channel.EndRepublish(result);
	}

	public IAsyncResult BeginRepublish(RepublishMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginRepublish(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public RepublishResponseMessage EndRepublish(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndRepublish(uaChannelAsyncResult.InnerResult);
	}

	public Task<RepublishResponseMessage> RepublishAsync(RepublishMessage request)
	{
		return base.Channel.RepublishAsync(request);
	}

	public TransferSubscriptionsResponseMessage TransferSubscriptions(TransferSubscriptionsMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginTransferSubscriptions(request, null, null);
		}
		return base.Channel.EndTransferSubscriptions(result);
	}

	public IAsyncResult BeginTransferSubscriptions(TransferSubscriptionsMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginTransferSubscriptions(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public TransferSubscriptionsResponseMessage EndTransferSubscriptions(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndTransferSubscriptions(uaChannelAsyncResult.InnerResult);
	}

	public Task<TransferSubscriptionsResponseMessage> TransferSubscriptionsAsync(TransferSubscriptionsMessage request)
	{
		return base.Channel.TransferSubscriptionsAsync(request);
	}

	public DeleteSubscriptionsResponseMessage DeleteSubscriptions(DeleteSubscriptionsMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginDeleteSubscriptions(request, null, null);
		}
		return base.Channel.EndDeleteSubscriptions(result);
	}

	public IAsyncResult BeginDeleteSubscriptions(DeleteSubscriptionsMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginDeleteSubscriptions(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public DeleteSubscriptionsResponseMessage EndDeleteSubscriptions(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndDeleteSubscriptions(uaChannelAsyncResult.InnerResult);
	}

	public Task<DeleteSubscriptionsResponseMessage> DeleteSubscriptionsAsync(DeleteSubscriptionsMessage request)
	{
		return base.Channel.DeleteSubscriptionsAsync(request);
	}
}
