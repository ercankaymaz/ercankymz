using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Opc.Ua.Security;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class UaSCUaBinaryClientChannel : UaSCUaBinaryChannel
{
	private struct QueuedOperation(WriteOperation operation, int timeout, IServiceRequest request)
	{
		public WriteOperation Operation = operation;

		public int Timeout = timeout;

		public IServiceRequest Request = request;
	}

	private Uri m_url;

	private Uri m_via;

	private long m_lastRequestId;

	private Dictionary<uint, WriteOperation> m_requests;

	private WriteOperation m_handshakeOperation;

	private ChannelToken m_requestedToken;

	private Timer m_handshakeTimer;

	private bool m_reconnecting;

	private int m_waitBetweenReconnects;

	private EventHandler<IMessageSocketAsyncEventArgs> m_ConnectCallback;

	private IMessageSocketFactory m_socketFactory;

	private TimerCallback m_startHandshake;

	private AsyncCallback m_handshakeComplete;

	private List<QueuedOperation> m_queuedOperations;

	private readonly string g_ImplementationString = ".NET Standard ClientChannel {0} " + Utils.GetAssemblyBuildNumber();

	public UaSCUaBinaryClientChannel(string contextId, BufferManager bufferManager, IMessageSocketFactory socketFactory, ChannelQuotas quotas, X509Certificate2 clientCertificate, X509Certificate2 serverCertificate, EndpointDescription endpoint)
		: this(contextId, bufferManager, socketFactory, quotas, clientCertificate, null, serverCertificate, endpoint)
	{
	}

	public UaSCUaBinaryClientChannel(string contextId, BufferManager bufferManager, IMessageSocketFactory socketFactory, ChannelQuotas quotas, X509Certificate2 clientCertificate, X509Certificate2Collection clientCertificateChain, X509Certificate2 serverCertificate, EndpointDescription endpoint)
		: base(contextId, bufferManager, quotas, serverCertificate, (endpoint != null) ? new EndpointDescriptionCollection(new EndpointDescription[1] { endpoint }) : null, endpoint?.SecurityMode ?? MessageSecurityMode.None, (endpoint != null) ? endpoint.SecurityPolicyUri : "http://opcfoundation.org/UA/SecurityPolicy#None")
	{
		if (endpoint != null && endpoint.SecurityMode != MessageSecurityMode.None)
		{
			if (clientCertificate == null)
			{
				throw new ArgumentNullException("clientCertificate");
			}
			if (clientCertificate.RawData.Length > 7500)
			{
				throw new ArgumentException(Utils.Format("The DER encoded certificate may not be more than {0} bytes.", 7500), "clientCertificate");
			}
			base.ClientCertificate = clientCertificate;
			base.ClientCertificateChain = clientCertificateChain;
		}
		m_requests = new Dictionary<uint, WriteOperation>();
		m_lastRequestId = 0L;
		m_ConnectCallback = OnConnectComplete;
		m_startHandshake = OnScheduledHandshake;
		m_handshakeComplete = OnHandshakeComplete;
		m_socketFactory = socketFactory;
		base.EndpointDescription = endpoint;
		m_url = new Uri(endpoint.EndpointUrl);
	}

	protected override void Dispose(bool disposing)
	{
		m_waitBetweenReconnects = -1;
		if (disposing)
		{
			Utils.SilentDispose(m_handshakeTimer);
			m_handshakeTimer = null;
		}
		base.Dispose(disposing);
	}

	public IAsyncResult BeginConnect(Uri url, int timeout, AsyncCallback callback, object state)
	{
		if (url == null)
		{
			throw new ArgumentNullException("url");
		}
		if (timeout <= 0)
		{
			throw new ArgumentException("Timeout must be greater than zero.", "timeout");
		}
		lock (base.DataLock)
		{
			if (base.State != TcpChannelState.Closed)
			{
				throw new InvalidOperationException("Channel is already connected.");
			}
			m_url = url;
			m_via = url;
			if (base.EndpointDescription != null && base.EndpointDescription.ProxyUrl != null)
			{
				m_via = base.EndpointDescription.ProxyUrl;
			}
			m_waitBetweenReconnects = -1;
			WriteOperation operation = BeginOperation(timeout, callback, state);
			m_handshakeOperation = operation;
			base.State = TcpChannelState.Connecting;
			if (base.ReverseSocket)
			{
				if (base.Socket != null)
				{
					SendHelloMessage(operation);
				}
			}
			else
			{
				base.Socket = m_socketFactory.Create(this, base.BufferManager, base.Quotas.MaxBufferSize);
				Task.Run(async delegate
				{
					using CancellationTokenSource cts = new CancellationTokenSource(timeout);
					await (base.Socket?.BeginConnect(m_via, m_ConnectCallback, operation, cts.Token) ?? Task.FromResult(result: false)).ConfigureAwait(continueOnCapturedContext: false);
				});
			}
		}
		return m_handshakeOperation;
	}

	public void EndConnect(IAsyncResult result)
	{
		if (!(result is WriteOperation writeOperation))
		{
			throw new ArgumentNullException("result");
		}
		try
		{
			writeOperation.End(int.MaxValue);
			Utils.LogInfo("CLIENTCHANNEL SOCKET CONNECTED: {0:X8}, ChannelId={1}", base.Socket.Handle, base.ChannelId);
		}
		catch (Exception e)
		{
			Shutdown(ServiceResult.Create(e, 2156003328u, "Fatal error during connect."));
			throw;
		}
		finally
		{
			OperationCompleted(writeOperation);
		}
	}

	public async Task EndConnectAsync(IAsyncResult result, CancellationToken ct = default(CancellationToken))
	{
		if (!(result is WriteOperation operation))
		{
			throw new ArgumentNullException("result");
		}
		try
		{
			await operation.EndAsync(int.MaxValue, throwOnError: true, ct).ConfigureAwait(continueOnCapturedContext: false);
			Utils.LogInfo("CLIENTCHANNEL SOCKET CONNECTED: {0:X8}, ChannelId={1}", base.Socket.Handle, base.ChannelId);
		}
		catch (Exception e)
		{
			Shutdown(ServiceResult.Create(e, 2156003328u, "Fatal error during connect."));
			throw;
		}
		finally
		{
			OperationCompleted(operation);
		}
	}

	public async Task CloseAsync(int timeout, CancellationToken ct = default(CancellationToken))
	{
		WriteOperation writeOperation = InternalClose(timeout);
		if (writeOperation != null)
		{
			try
			{
				await writeOperation.EndAsync(timeout, throwOnError: true, ct).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (ServiceResultException ex)
			{
				uint statusCode = ex.StatusCode;
				if (statusCode != 2156134400u && statusCode != 2156265472u)
				{
					Utils.LogWarning(ex, "ChannelId {0}: Could not gracefully close the channel. Reason={1}", base.ChannelId, ex.Result.StatusCode);
				}
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "ChannelId {0}: Could not gracefully close the channel.", base.ChannelId);
			}
		}
		Shutdown(2158886912u);
	}

	public void Close(int timeout)
	{
		WriteOperation writeOperation = InternalClose(timeout);
		if (writeOperation != null)
		{
			try
			{
				writeOperation.End(timeout, throwOnError: false);
			}
			catch (ServiceResultException ex)
			{
				uint statusCode = ex.StatusCode;
				if (statusCode != 2156134400u && statusCode != 2156265472u)
				{
					Utils.LogWarning(ex, "ChannelId {0}: Could not gracefully close the channel. Reason={1}", base.ChannelId, ex.Result.StatusCode);
				}
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "ChannelId {0}: Could not gracefully close the channel.", base.ChannelId);
			}
		}
		Shutdown(2158886912u);
	}

	public IAsyncResult BeginSendRequest(IServiceRequest request, int timeout, AsyncCallback callback, object state)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (timeout <= 0)
		{
			throw new ArgumentException("Timeout must be greater than zero.", "timeout");
		}
		lock (base.DataLock)
		{
			bool flag = false;
			WriteOperation writeOperation = null;
			if (base.State == TcpChannelState.Closed && m_queuedOperations == null)
			{
				flag = true;
				m_queuedOperations = new List<QueuedOperation>();
			}
			if (m_queuedOperations != null)
			{
				writeOperation = BeginOperation(timeout, callback, state);
				m_queuedOperations.Add(new QueuedOperation(writeOperation, timeout, request));
				if (flag)
				{
					BeginConnect(m_url, timeout, OnConnectOnDemandComplete, null);
				}
				return writeOperation;
			}
			if (base.State != TcpChannelState.Open)
			{
				throw new ServiceResultException(2158886912u);
			}
			Utils.LogTrace("ChannelId {0}: BeginSendRequest()", base.ChannelId);
			if (m_reconnecting)
			{
				throw ServiceResultException.Create(2156134400u, "Attempting to reconnect to the server.");
			}
			writeOperation = BeginOperation(timeout, callback, state);
			SendRequest(writeOperation, timeout, request);
			return writeOperation;
		}
	}

	public IServiceResponse EndSendRequest(IAsyncResult result)
	{
		if (!(result is WriteOperation writeOperation))
		{
			throw new ArgumentNullException("result");
		}
		try
		{
			writeOperation.End(int.MaxValue);
		}
		finally
		{
			OperationCompleted(writeOperation);
		}
		return writeOperation.MessageBody as IServiceResponse;
	}

	public async Task<IServiceResponse> EndSendRequestAsync(IAsyncResult result, CancellationToken ct)
	{
		if (!(result is WriteOperation operation))
		{
			throw new ArgumentNullException("result");
		}
		try
		{
			await operation.EndAsync(int.MaxValue, throwOnError: true, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			OperationCompleted(operation);
		}
		return operation.MessageBody as IServiceResponse;
	}

	private void SendHelloMessage(WriteOperation operation)
	{
		Utils.LogTrace("ChannelId {0}: SendHelloMessage()", base.ChannelId);
		byte[] array = base.BufferManager.TakeBuffer(base.SendBufferSize, "SendHelloMessage");
		try
		{
			using BinaryEncoder binaryEncoder = new BinaryEncoder(new MemoryStream(array, 0, base.SendBufferSize), base.Quotas.MessageContext, leaveOpen: false);
			binaryEncoder.WriteUInt32(null, 1179403592u);
			binaryEncoder.WriteUInt32(null, 0u);
			binaryEncoder.WriteUInt32(null, 0u);
			binaryEncoder.WriteUInt32(null, (uint)base.ReceiveBufferSize);
			binaryEncoder.WriteUInt32(null, (uint)base.SendBufferSize);
			binaryEncoder.WriteUInt32(null, (uint)base.MaxResponseMessageSize);
			binaryEncoder.WriteUInt32(null, (uint)base.MaxResponseChunkCount);
			byte[] array2 = Encoding.UTF8.GetBytes(m_url.ToString());
			if (array2.Length > 4096)
			{
				byte[] array3 = new byte[4096];
				Array.Copy(array2, array3, 4096);
				array2 = array3;
			}
			binaryEncoder.WriteByteString(null, array2);
			int num = binaryEncoder.Close();
			UaSCUaBinaryChannel.UpdateMessageSize(array, 0, num);
			BeginWriteMessage(new ArraySegment<byte>(array, 0, num), operation);
			array = null;
		}
		finally
		{
			if (array != null)
			{
				base.BufferManager.ReturnBuffer(array, "SendHelloMessage");
			}
		}
	}

	private bool ProcessAcknowledgeMessage(ArraySegment<byte> messageChunk)
	{
		Utils.LogTrace("ChannelId {0}: ProcessAcknowledgeMessage()", base.ChannelId);
		if (base.State != TcpChannelState.Connecting)
		{
			ForceReconnect(ServiceResult.Create(2155741184u, "Server sent an unexpected acknowledge message."));
			return false;
		}
		if (m_handshakeOperation == null)
		{
			return false;
		}
		MemoryStream memoryStream = new MemoryStream(messageChunk.Array, messageChunk.Offset, messageChunk.Count);
		BinaryDecoder binaryDecoder = new BinaryDecoder(memoryStream, base.Quotas.MessageContext);
		memoryStream.Seek(8L, SeekOrigin.Current);
		try
		{
			binaryDecoder.ReadUInt32(null);
			base.SendBufferSize = (int)binaryDecoder.ReadUInt32(null);
			base.ReceiveBufferSize = (int)binaryDecoder.ReadUInt32(null);
			int num = (int)binaryDecoder.ReadUInt32(null);
			int num2 = (int)binaryDecoder.ReadUInt32(null);
			if (num > 0 && num < base.MaxRequestMessageSize)
			{
				base.MaxRequestMessageSize = num;
			}
			if (base.MaxRequestMessageSize < base.SendBufferSize)
			{
				base.MaxRequestMessageSize = base.SendBufferSize;
			}
			base.MaxRequestChunkCount = UaSCUaBinaryChannel.CalculateChunkCount(base.MaxRequestMessageSize, base.SendBufferSize);
			if (num2 > 0 && num2 < base.MaxRequestChunkCount)
			{
				base.MaxRequestChunkCount = num2;
			}
		}
		finally
		{
			binaryDecoder.Close();
		}
		if (base.ReceiveBufferSize < 8192)
		{
			m_handshakeOperation.Fault(2155937792u, "Server receive buffer size is too small ({0} bytes).", base.ReceiveBufferSize);
			return false;
		}
		if (base.SendBufferSize < 8192)
		{
			m_handshakeOperation.Fault(2155937792u, "Server send buffer size is too small ({0} bytes).", base.SendBufferSize);
			return false;
		}
		base.State = TcpChannelState.Opening;
		try
		{
			if (base.CurrentToken != null)
			{
				SendOpenSecureChannelRequest(renew: true);
				return false;
			}
			SendOpenSecureChannelRequest(renew: false);
		}
		catch (Exception e)
		{
			m_handshakeOperation.Fault(e, 2156003328u, "Could not send an Open Secure Channel request.");
		}
		return false;
	}

	private void SendOpenSecureChannelRequest(bool renew)
	{
		ChannelToken channelToken = CreateToken();
		channelToken.ClientNonce = CreateNonce();
		byte[] array = BinaryEncoder.EncodeMessage(new OpenSecureChannelRequest
		{
			RequestHeader = 
			{
				Timestamp = DateTime.UtcNow
			},
			RequestType = (renew ? SecurityTokenRequestType.Renew : SecurityTokenRequestType.Issue),
			SecurityMode = base.SecurityMode,
			ClientNonce = channelToken.ClientNonce,
			RequestedLifetime = (uint)base.Quotas.SecurityTokenLifetime
		}, base.Quotas.MessageContext);
		BufferCollection bufferCollection = WriteAsymmetricMessage(5132367u, m_handshakeOperation.RequestId, base.ClientCertificate, base.ClientCertificateChain, base.ServerCertificate, new ArraySegment<byte>(array, 0, array.Length));
		m_requestedToken = channelToken;
		try
		{
			BeginWriteMessage(bufferCollection, m_handshakeOperation);
			bufferCollection = null;
		}
		finally
		{
			bufferCollection?.Release(base.BufferManager, "SendOpenSecureChannelRequest");
		}
	}

	private bool ProcessOpenSecureChannelResponse(uint messageType, ArraySegment<byte> messageChunk)
	{
		Utils.LogTrace("ChannelId {0}: ProcessOpenSecureChannelResponse()", base.ChannelId);
		if (base.State != TcpChannelState.Opening && base.State != TcpChannelState.Open)
		{
			ForceReconnect(ServiceResult.Create(2155741184u, "Server sent an unexpected OpenSecureChannel response."));
			return false;
		}
		if (m_handshakeOperation == null)
		{
			return false;
		}
		uint channelId = 0u;
		X509Certificate2 senderCertificate = null;
		uint requestId = 0u;
		uint sequenceNumber = 0u;
		ArraySegment<byte> chunk;
		try
		{
			chunk = ReadAsymmetricMessage(messageChunk, base.ClientCertificate, out channelId, out senderCertificate, out requestId, out sequenceNumber);
		}
		catch (Exception e)
		{
			ForceReconnect(ServiceResult.Create(e, 2148728832u, "Could not verify security on OpenSecureChannel response."));
			return false;
		}
		BufferCollection bufferCollection = null;
		try
		{
			UaSCUaBinaryChannel.CompareCertificates(base.ServerCertificate, senderCertificate, allowNull: true);
			ResetSequenceNumber(sequenceNumber);
			if (!TcpMessageType.IsFinal(messageType))
			{
				SaveIntermediateChunk(requestId, chunk, isServerContext: false);
				return false;
			}
			bufferCollection = GetSavedChunks(requestId, chunk, isServerContext: false);
			if (!(ParseResponse(bufferCollection) is OpenSecureChannelResponse openSecureChannelResponse))
			{
				throw ServiceResultException.Create(2155085824u, "Server did not return a valid OpenSecureChannelResponse.");
			}
			m_requestedToken.TokenId = openSecureChannelResponse.SecurityToken.TokenId;
			m_requestedToken.Lifetime = (int)openSecureChannelResponse.SecurityToken.RevisedLifetime;
			m_requestedToken.ServerNonce = openSecureChannelResponse.ServerNonce;
			string implementationInfo = string.Format(g_ImplementationString, m_socketFactory.Implementation);
			if (base.State == TcpChannelState.Opening)
			{
				Audit.SecureChannelCreated(implementationInfo, m_url.ToString(), Utils.Format("{0}", channelId), base.EndpointDescription, base.ClientCertificate, senderCertificate, BinaryEncodingSupport.Required);
			}
			else
			{
				Audit.SecureChannelRenewed(implementationInfo, Utils.Format("{0}", channelId));
			}
			uint channelId2 = (m_requestedToken.ChannelId = channelId);
			base.ChannelId = channelId2;
			ActivateToken(m_requestedToken);
			m_requestedToken = null;
			base.State = TcpChannelState.Open;
			m_reconnecting = false;
			m_waitBetweenReconnects = -1;
			ScheduleTokenRenewal(base.CurrentToken);
			m_handshakeOperation.Complete(0);
		}
		catch (Exception e2)
		{
			m_handshakeOperation.Fault(e2, 2156003328u, "Could not process OpenSecureChannelResponse.");
		}
		finally
		{
			bufferCollection?.Release(base.BufferManager, "ProcessOpenSecureChannelResponse");
		}
		return false;
	}

	protected override void DoMessageLimitsExceeded()
	{
		base.DoMessageLimitsExceeded();
		Shutdown(new ServiceResult(2159607808u));
	}

	protected override void HandleSocketError(ServiceResult result)
	{
		ForceReconnect(result);
	}

	protected override void HandleWriteComplete(BufferCollection buffers, object state, int bytesWritten, ServiceResult result)
	{
		lock (base.DataLock)
		{
			if (state is WriteOperation writeOperation && ServiceResult.IsBad(result))
			{
				writeOperation.Fault(new ServiceResult(2148728832u, result));
			}
		}
		base.HandleWriteComplete(buffers, state, bytesWritten, result);
	}

	protected override bool HandleIncomingMessage(uint messageType, ArraySegment<byte> messageChunk)
	{
		lock (base.DataLock)
		{
			if (TcpMessageType.IsType(messageType, 4674381u))
			{
				return ProcessResponseMessage(messageType, messageChunk);
			}
			switch (messageType)
			{
			case 1179337537u:
				return ProcessAcknowledgeMessage(messageChunk);
			case 1179800133u:
				return ProcessErrorMessage(messageType, messageChunk);
			default:
				if (TcpMessageType.IsType(messageType, 5132367u))
				{
					return ProcessOpenSecureChannelResponse(messageType, messageChunk);
				}
				if (TcpMessageType.IsType(messageType, 5196867u))
				{
					return ProcessResponseMessage(messageType, messageChunk);
				}
				ForceReconnect(ServiceResult.Create(2155741184u, "The client does not recognize the message type: {0:X8}.", messageType));
				return false;
			}
		}
	}

	private void OnConnectComplete(object sender, IMessageSocketAsyncEventArgs e)
	{
		WriteOperation writeOperation = (WriteOperation)e.UserToken;
		if (writeOperation == null)
		{
			return;
		}
		if (e.IsSocketError)
		{
			writeOperation.Fault(2156527616u);
			return;
		}
		lock (base.DataLock)
		{
			try
			{
				if (base.Socket == null)
				{
					writeOperation.Fault(2156265472u);
					return;
				}
				base.Socket.ReadNextMessage();
				SendHelloMessage(writeOperation);
			}
			catch (Exception e2)
			{
				ServiceResult error = ServiceResult.Create(e2, 2156003328u, "An unexpected error occurred while connecting to the server.");
				writeOperation.Fault(error);
			}
		}
	}

	private void OnScheduledHandshake(object state)
	{
		try
		{
			Utils.LogInfo("ChannelId {0}: Scheduled Handshake Starting: TokenId={1}", base.ChannelId, base.CurrentToken?.TokenId);
			lock (base.DataLock)
			{
				ChannelToken channelToken = state as ChannelToken;
				if (channelToken == base.CurrentToken)
				{
					Utils.LogInfo("ChannelId {0}: Attempting Renew Token Now: TokenId={1}", base.ChannelId, channelToken?.TokenId);
					if (base.State == TcpChannelState.Open)
					{
						m_handshakeOperation = BeginOperation(int.MaxValue, m_handshakeComplete, channelToken);
						SendOpenSecureChannelRequest(renew: true);
					}
				}
				else
				{
					if (!m_reconnecting)
					{
						return;
					}
					Utils.LogInfo("ChannelId {0}: Attempting Reconnect Now.", base.ChannelId);
					if (m_handshakeOperation != null)
					{
						m_handshakeOperation.Fault(2148139008u);
						m_handshakeOperation = null;
					}
					base.State = TcpChannelState.Closed;
					if (base.Socket != null)
					{
						Utils.LogInfo("ChannelId {0}: CLIENTCHANNEL SOCKET CLOSED: {1:X8}", base.ChannelId, base.Socket.Handle);
						base.Socket.Close();
						base.Socket = null;
					}
					if (!base.ReverseSocket)
					{
						m_handshakeOperation = BeginOperation(int.MaxValue, m_handshakeComplete, null);
						base.State = TcpChannelState.Connecting;
						base.Socket = m_socketFactory.Create(this, base.BufferManager, base.Quotas.MaxBufferSize);
						Task.Run(async () => await (base.Socket?.BeginConnect(m_via, m_ConnectCallback, m_handshakeOperation, CancellationToken.None) ?? Task.FromResult(result: false)).ConfigureAwait(continueOnCapturedContext: false));
					}
				}
			}
		}
		catch (Exception ex)
		{
			Utils.LogError("ChannelId {0}: Reconnect Failed {1}.", base.ChannelId, ex.Message);
			ForceReconnect(ServiceResult.Create(ex, 2147549184u, "Unexpected error reconnecting or renewing a token."));
		}
	}

	private void OnHandshakeComplete(IAsyncResult result)
	{
		lock (base.DataLock)
		{
			try
			{
				if (m_handshakeOperation != null)
				{
					Utils.LogTrace("ChannelId {0}: OnHandshakeComplete", base.ChannelId);
					m_handshakeOperation.End(int.MaxValue);
					m_handshakeOperation = null;
					m_reconnecting = false;
				}
			}
			catch (Exception ex)
			{
				Utils.LogError(ex, "ChannelId {0}: Handshake Failed {1}", base.ChannelId, ex.Message);
				m_handshakeOperation = null;
				m_reconnecting = false;
				ServiceResult serviceResult = ServiceResult.Create(ex, 2147549184u, "Unexpected error reconnecting or renewing a token.");
				if (serviceResult.Code == 2155806720u || serviceResult.Code == 2148728832u)
				{
					Utils.LogError("ChannelId {0}: Cannot Recover Channel", base.ChannelId);
					Shutdown(serviceResult);
				}
				else
				{
					ForceReconnect(ServiceResult.Create(ex, 2147549184u, "Unexpected error reconnecting or renewing a token."));
				}
			}
		}
	}

	private void SendRequest(WriteOperation operation, int timeout, IServiceRequest request)
	{
		bool flag = false;
		BufferCollection bufferCollection = null;
		try
		{
			ChannelToken currentToken = base.CurrentToken;
			if (currentToken == null)
			{
				throw new ServiceResultException(2156265472u);
			}
			bool limitsExceeded = false;
			bufferCollection = WriteSymmetricMessage(4674381u, operation.RequestId, currentToken, request, isRequest: true, out limitsExceeded);
			BeginWriteMessage(bufferCollection, operation);
			bufferCollection = null;
			flag = true;
			if (limitsExceeded)
			{
				throw new ServiceResultException(2159542272u);
			}
		}
		catch (Exception e)
		{
			operation.Fault(e, 2156134400u, "Could not send request to server.");
		}
		finally
		{
			bufferCollection?.Release(base.BufferManager, "SendRequest");
			if (!flag)
			{
				OperationCompleted(operation);
			}
		}
	}

	private IServiceResponse ParseResponse(BufferCollection chunksToProcess)
	{
		return (BinaryDecoder.DecodeMessage(new ArraySegmentStream(chunksToProcess), null, base.Quotas.MessageContext) as IServiceResponse) ?? throw ServiceResultException.Create(2152071168u, "Could not parse response body.");
	}

	private void Shutdown(ServiceResult reason)
	{
		lock (base.DataLock)
		{
			if (base.State == TcpChannelState.Closed)
			{
				return;
			}
			SaveIntermediateChunk(0u, default(ArraySegment<byte>), isServerContext: false);
			if (m_handshakeTimer != null)
			{
				m_handshakeTimer.Dispose();
				m_handshakeTimer = null;
			}
			if (m_handshakeOperation != null && !m_handshakeOperation.IsCompleted)
			{
				m_handshakeOperation.Fault(reason);
			}
			foreach (WriteOperation item in new List<WriteOperation>(m_requests.Values))
			{
				item.Fault(new ServiceResult(2156265472u, reason));
			}
			m_requests.Clear();
			uint channelId = base.ChannelId;
			base.State = TcpChannelState.Closed;
			base.ChannelId = 0u;
			DiscardTokens();
			m_handshakeOperation = null;
			m_requestedToken = null;
			m_reconnecting = false;
			if (base.Socket != null)
			{
				Utils.LogInfo("ChannelId {0}: CLIENTCHANNEL SOCKET CLOSED: {1:X8}", channelId, base.Socket.Handle);
				base.Socket.Close();
				base.Socket = null;
			}
			ChannelStateChanged(TcpChannelState.Closed, reason);
		}
	}

	private void ForceReconnect(ServiceResult reason)
	{
		lock (base.DataLock)
		{
			if (m_reconnecting)
			{
				return;
			}
			if (base.State == TcpChannelState.Closing || m_waitBetweenReconnects == -1)
			{
				Shutdown(reason);
				return;
			}
			Utils.LogWarning("ChannelId {0}: Force reconnect reason={1}", base.Id, reason);
			foreach (WriteOperation item in new List<WriteOperation>(m_requests.Values))
			{
				item.Fault(new ServiceResult(2156265472u, reason));
			}
			m_requests.Clear();
			if (m_handshakeOperation != null && !m_handshakeOperation.IsCompleted)
			{
				m_handshakeOperation.Fault(reason);
				return;
			}
			SaveIntermediateChunk(0u, default(ArraySegment<byte>), isServerContext: false);
			if (m_handshakeTimer != null)
			{
				m_handshakeTimer.Dispose();
				m_handshakeTimer = null;
			}
			m_handshakeOperation = null;
			m_requestedToken = null;
			m_reconnecting = true;
			base.State = TcpChannelState.Faulted;
			Utils.LogInfo("ChannelId {0}: Attempting Reconnect in {1} ms. Reason: {2}", base.ChannelId, m_waitBetweenReconnects, reason.ToLongString());
			m_handshakeTimer = new Timer(m_startHandshake, null, m_waitBetweenReconnects, -1);
			m_waitBetweenReconnects *= 2;
			if (m_waitBetweenReconnects <= 0)
			{
				m_waitBetweenReconnects = 1000;
			}
			if (m_waitBetweenReconnects > 120000)
			{
				m_waitBetweenReconnects = 120000;
			}
			ChannelStateChanged(TcpChannelState.Faulted, reason);
		}
	}

	private void ScheduleTokenRenewal(ChannelToken token)
	{
		if (base.State == TcpChannelState.Open)
		{
			if (m_handshakeTimer != null)
			{
				m_handshakeTimer.Dispose();
				m_handshakeTimer = null;
			}
			DateTime dateTime = token.CreatedAt.AddMilliseconds(token.Lifetime);
			double num = (double)((dateTime.Ticks - DateTime.UtcNow.Ticks) / 10000) * 0.75;
			if (num < 0.0)
			{
				num = 0.0;
			}
			Utils.LogInfo("ChannelId {0}: Token Expiry {1}, renewal scheduled in {2} ms.", base.ChannelId, dateTime, (int)num);
			m_handshakeTimer = new Timer(m_startHandshake, token, (int)num, -1);
		}
	}

	private WriteOperation BeginOperation(int timeout, AsyncCallback callback, object state)
	{
		WriteOperation writeOperation = new WriteOperation(timeout, callback, state);
		writeOperation.RequestId = Utils.IncrementIdentifier(ref m_lastRequestId);
		m_requests.Add(writeOperation.RequestId, writeOperation);
		return writeOperation;
	}

	private void OperationCompleted(WriteOperation operation)
	{
		if (operation == null)
		{
			return;
		}
		lock (base.DataLock)
		{
			if (m_handshakeOperation == operation)
			{
				m_handshakeOperation = null;
			}
			m_requests.Remove(operation.RequestId);
		}
	}

	private void OnConnectOnDemandComplete(object state)
	{
		lock (base.DataLock)
		{
			WriteOperation writeOperation = (WriteOperation)state;
			for (int i = 0; i < m_queuedOperations.Count; i++)
			{
				QueuedOperation queuedOperation = m_queuedOperations[i];
				if (i == 0)
				{
					try
					{
						writeOperation.End(queuedOperation.Timeout);
					}
					catch (Exception ex)
					{
						queuedOperation.Operation.Fault(ex, 2150694912u, "Error establishing a connection: " + ex.Message);
						break;
					}
				}
				if (base.CurrentToken == null)
				{
					queuedOperation.Operation.Fault(2158886912u, "Could not send request because connection is closed.");
				}
				try
				{
					SendRequest(queuedOperation.Operation, queuedOperation.Timeout, queuedOperation.Request);
				}
				catch (Exception e)
				{
					queuedOperation.Operation.Fault(e, 2147811328u, "Could not send request.");
				}
			}
			m_queuedOperations = null;
		}
	}

	private WriteOperation InternalClose(int timeout)
	{
		WriteOperation writeOperation = null;
		lock (base.DataLock)
		{
			if (base.State == TcpChannelState.Closed)
			{
				return null;
			}
			if (m_handshakeOperation != null && !m_handshakeOperation.IsCompleted)
			{
				m_handshakeOperation.Fault(ServiceResult.Create(2158886912u, "Channel was closed by the user."));
			}
			Utils.LogTrace("ChannelId {0}: Close", base.ChannelId);
			if (base.State == TcpChannelState.Open)
			{
				base.State = TcpChannelState.Closing;
				writeOperation = BeginOperation(timeout, null, null);
				SendCloseSecureChannelRequest(writeOperation);
			}
		}
		return writeOperation;
	}

	protected bool ProcessErrorMessage(uint messageType, ArraySegment<byte> messageChunk)
	{
		MemoryStream memoryStream = new MemoryStream(messageChunk.Array, messageChunk.Offset, messageChunk.Count, writable: false);
		BinaryDecoder binaryDecoder = new BinaryDecoder(memoryStream, base.Quotas.MessageContext);
		memoryStream.Seek(8L, SeekOrigin.Current);
		try
		{
			ServiceResult serviceResult = UaSCUaBinaryChannel.ReadErrorMessageBody(binaryDecoder);
			Utils.LogTrace("ChannelId {0}: ProcessErrorMessage({1})", base.ChannelId, serviceResult);
			if (m_handshakeOperation != null)
			{
				m_handshakeOperation.Fault(serviceResult);
				return false;
			}
			ForceReconnect(serviceResult);
			return false;
		}
		finally
		{
			binaryDecoder.Close();
		}
	}

	private void SendCloseSecureChannelRequest(WriteOperation operation)
	{
		Utils.LogTrace("ChannelId {0}: SendCloseSecureChannelRequest()", base.ChannelId);
		m_waitBetweenReconnects = -1;
		ChannelToken currentToken = base.CurrentToken;
		if (currentToken == null)
		{
			throw new ServiceResultException(2156265472u);
		}
		CloseSecureChannelRequest closeSecureChannelRequest = new CloseSecureChannelRequest();
		closeSecureChannelRequest.RequestHeader.Timestamp = DateTime.UtcNow;
		bool limitsExceeded = false;
		BufferCollection bufferCollection = WriteSymmetricMessage(5196867u, operation.RequestId, currentToken, closeSecureChannelRequest, isRequest: true, out limitsExceeded);
		try
		{
			BeginWriteMessage(bufferCollection, operation);
			bufferCollection = null;
		}
		finally
		{
			bufferCollection?.Release(base.BufferManager, "SendCloseSecureChannelRequest");
		}
	}

	private bool ProcessResponseMessage(uint messageType, ArraySegment<byte> messageChunk)
	{
		Utils.LogTrace("ChannelId {0}: ProcessResponseMessage()", base.ChannelId);
		ChannelToken token = null;
		uint requestId = 0u;
		uint sequenceNumber = 0u;
		ArraySegment<byte> chunk;
		try
		{
			chunk = ReadSymmetricMessage(messageChunk, isRequest: false, out token, out requestId, out sequenceNumber);
		}
		catch (Exception e)
		{
			ForceReconnect(ServiceResult.Create(e, 2148728832u, "Could not verify security on response."));
			return false;
		}
		WriteOperation value = null;
		if (!m_requests.TryGetValue(requestId, out value))
		{
			return false;
		}
		BufferCollection bufferCollection = null;
		if (!VerifySequenceNumber(sequenceNumber, "ProcessResponseMessage"))
		{
			throw new ServiceResultException(2156396544u);
		}
		try
		{
			if (TcpMessageType.IsAbort(messageType))
			{
				bufferCollection = GetSavedChunks(requestId, chunk, isServerContext: false);
				BinaryDecoder binaryDecoder = new BinaryDecoder(new MemoryStream(chunk.Array, chunk.Offset, chunk.Count, writable: false), base.Quotas.MessageContext);
				ServiceResult error = UaSCUaBinaryChannel.ReadErrorMessageBody(binaryDecoder);
				binaryDecoder.Close();
				value.Fault(doNotBlock: true, error);
				return true;
			}
			if (!TcpMessageType.IsFinal(messageType))
			{
				SaveIntermediateChunk(requestId, chunk, isServerContext: false);
				return true;
			}
			bufferCollection = GetSavedChunks(requestId, chunk, isServerContext: false);
			value.MessageBody = ParseResponse(bufferCollection);
			if (value.MessageBody == null)
			{
				value.Fault(true, 2152071168u, "Could not parse response body.");
				return true;
			}
			value.Complete(doNotBlock: true, 0);
			return true;
		}
		catch (Exception ex)
		{
			Utils.LogError(ex, "Unexpected error processing response.");
			value.Fault(true, ex, 2148073472u, "Unexpected error processing response.");
			return true;
		}
		finally
		{
			bufferCollection?.Release(base.BufferManager, "ProcessResponseMessage");
		}
	}
}
