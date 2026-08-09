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
public class TcpServerChannel : TcpListenerChannel
{
	private class ReverseConnectAsyncResult : AsyncResultBase
	{
		public IMessageSocket Socket;

		public ReverseConnectAsyncResult(AsyncCallback callback, object callbackData, int timeout)
			: base(callback, callbackData, timeout)
		{
		}
	}

	private SortedDictionary<uint, IServiceResponse> m_queuedResponses;

	private readonly string m_ImplementationString = ".NET Standard ServerChannel UA-TCP " + Utils.GetAssemblyBuildNumber();

	private ReverseConnectAsyncResult m_pendingReverseHello;

	public override string ChannelName => "TCPSERVERCHANNEL";

	public Uri ReverseConnectionUrl { get; internal set; }

	public event TcpChannelStatusEventHandler StatusChanged;

	public TcpServerChannel(string contextId, ITcpChannelListener listener, BufferManager bufferManager, ChannelQuotas quotas, X509Certificate2 serverCertificate, EndpointDescriptionCollection endpoints)
		: this(contextId, listener, bufferManager, quotas, serverCertificate, null, endpoints)
	{
		m_queuedResponses = new SortedDictionary<uint, IServiceResponse>();
	}

	public TcpServerChannel(string contextId, ITcpChannelListener listener, BufferManager bufferManager, ChannelQuotas quotas, X509Certificate2 serverCertificate, X509Certificate2Collection serverCertificateChain, EndpointDescriptionCollection endpoints)
		: base(contextId, listener, bufferManager, quotas, serverCertificate, serverCertificateChain, endpoints)
	{
		m_queuedResponses = new SortedDictionary<uint, IServiceResponse>();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	public IAsyncResult BeginReverseConnect(uint channelId, Uri endpointUrl, AsyncCallback callback, object callbackData, int timeout)
	{
		base.ChannelId = channelId;
		ReverseConnectionUrl = endpointUrl;
		SetEndpointUrl(base.Listener.EndpointUrl.ToString());
		ReverseConnectAsyncResult ar = new ReverseConnectAsyncResult(callback, callbackData, timeout);
		TcpMessageSocketFactory tcpMessageSocketFactory = new TcpMessageSocketFactory();
		ReverseConnectAsyncResult reverseConnectAsyncResult = ar;
		IMessageSocket socket = (base.Socket = tcpMessageSocketFactory.Create(this, base.BufferManager, base.ReceiveBufferSize));
		reverseConnectAsyncResult.Socket = socket;
		EventHandler<IMessageSocketAsyncEventArgs> connectComplete = OnReverseConnectComplete;
		Task.Run(async () => await base.Socket.BeginConnect(endpointUrl, connectComplete, ar, ar.CancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		return ar;
	}

	public void EndReverseConnect(IAsyncResult result)
	{
		if (!((result as ReverseConnectAsyncResult) ?? throw new ArgumentException("EndReverseConnect is called with invalid IAsyncResult.", "result")).WaitForComplete())
		{
			throw new TimeoutException();
		}
	}

	private void OnReverseConnectComplete(object sender, IMessageSocketAsyncEventArgs result)
	{
		ReverseConnectAsyncResult reverseConnectAsyncResult = (ReverseConnectAsyncResult)result.UserToken;
		if (reverseConnectAsyncResult == null || m_pendingReverseHello != null)
		{
			return;
		}
		if (result.IsSocketError)
		{
			reverseConnectAsyncResult.Exception = new ServiceResultException(2156527616u, result.SocketErrorString);
			reverseConnectAsyncResult.OperationCompleted();
			return;
		}
		byte[] array = base.BufferManager.TakeBuffer(base.SendBufferSize, "OnReverseConnectConnectComplete");
		try
		{
			reverseConnectAsyncResult.Socket.ReadNextMessage();
			using BinaryEncoder binaryEncoder = new BinaryEncoder(array, 0, base.SendBufferSize, base.Quotas.MessageContext);
			binaryEncoder.WriteUInt32(null, 1178945618u);
			binaryEncoder.WriteUInt32(null, 0u);
			binaryEncoder.WriteString(null, base.EndpointDescription.Server.ApplicationUri);
			binaryEncoder.WriteString(null, base.EndpointDescription.EndpointUrl);
			int num = binaryEncoder.Close();
			UaSCUaBinaryChannel.UpdateMessageSize(array, 0, num);
			base.State = TcpChannelState.Connecting;
			m_pendingReverseHello = reverseConnectAsyncResult;
			BeginWriteMessage(new ArraySegment<byte>(array, 0, num), null);
			array = null;
		}
		catch (Exception exception)
		{
			reverseConnectAsyncResult.Exception = exception;
			reverseConnectAsyncResult.OperationCompleted();
		}
		finally
		{
			if (array != null)
			{
				base.BufferManager.ReturnBuffer(array, "OnReverseConnectComplete");
			}
		}
	}

	public override void Reconnect(IMessageSocket socket, uint requestId, uint sequenceNumber, X509Certificate2 clientCertificate, ChannelToken token, OpenSecureChannelRequest request)
	{
		if (socket == null)
		{
			throw new ArgumentNullException("socket");
		}
		lock (base.DataLock)
		{
			UaSCUaBinaryChannel.CompareCertificates(base.ClientCertificate, clientCertificate, allowNull: false);
			if (!VerifySequenceNumber(sequenceNumber, "Reconnect"))
			{
				throw new ServiceResultException(2156396544u);
			}
			try
			{
				Utils.LogInfo("{0} SOCKET RECONNECTED: {1:X8}, ChannelId={2}", ChannelName, socket.Handle, base.ChannelId);
				base.Socket = socket;
				base.Socket.ChangeSink(this);
				token.TokenId = GetNewTokenId();
				ActivateToken(token);
				base.State = TcpChannelState.Open;
				CleanupTimer();
				SendOpenSecureChannelResponse(requestId, token, request);
				ResetQueuedResponses(OnChannelReconnected);
			}
			catch (Exception e)
			{
				SendServiceFault(token, requestId, ServiceResult.Create(e, 2156003328u, "Unexpected error processing request."));
			}
		}
	}

	protected override bool HandleIncomingMessage(uint messageType, ArraySegment<byte> messageChunk)
	{
		lock (base.DataLock)
		{
			SetResponseRequired(responseRequired: true);
			try
			{
				if (TcpMessageType.IsType(messageType, 4674381u))
				{
					Utils.LogTrace(16, "ChannelId {0}: ProcessRequestMessage", base.ChannelId);
					return ProcessRequestMessage(messageType, messageChunk);
				}
				if (messageType == 1179403592)
				{
					Utils.LogTrace(16, "ChannelId {0}: ProcessHelloMessage", base.ChannelId);
					return ProcessHelloMessage(messageChunk);
				}
				if (TcpMessageType.IsType(messageType, 5132367u))
				{
					Utils.LogTrace(16, "ChannelId {0}: ProcessOpenSecureChannelRequest", base.ChannelId);
					return ProcessOpenSecureChannelRequest(messageType, messageChunk);
				}
				if (TcpMessageType.IsType(messageType, 5196867u))
				{
					Utils.LogTrace(16, "ChannelId {0}: ProcessCloseSecureChannelRequest", base.ChannelId);
					return ProcessCloseSecureChannelRequest(messageType, messageChunk);
				}
				ForceChannelFault(2155741184u, "The server does not recognize the message type: {0:X8}.", messageType);
				return false;
			}
			finally
			{
				SetResponseRequired(responseRequired: false);
			}
		}
	}

	private void OnChannelReconnected(object state)
	{
		if (!(state is SortedDictionary<uint, IServiceResponse> sortedDictionary))
		{
			return;
		}
		foreach (KeyValuePair<uint, IServiceResponse> item in sortedDictionary)
		{
			try
			{
				SendResponse(item.Key, item.Value);
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Unexpected error re-sending request (ID={0}).", item.Key);
			}
		}
	}

	private bool ProcessHelloMessage(ArraySegment<byte> messageChunk)
	{
		if (base.State != TcpChannelState.Connecting)
		{
			ForceChannelFault(2155741184u, "Client sent an unexpected Hello message.");
			return false;
		}
		try
		{
			using (MemoryStream memoryStream = new MemoryStream(messageChunk.Array, messageChunk.Offset, messageChunk.Count, writable: false))
			{
				BinaryDecoder binaryDecoder = new BinaryDecoder(memoryStream, base.Quotas.MessageContext);
				memoryStream.Seek(8L, SeekOrigin.Current);
				binaryDecoder.ReadUInt32(null);
				uint num = binaryDecoder.ReadUInt32(null);
				uint num2 = binaryDecoder.ReadUInt32(null);
				uint num3 = binaryDecoder.ReadUInt32(null);
				uint num4 = binaryDecoder.ReadUInt32(null);
				int num5 = binaryDecoder.ReadInt32(null);
				if (num5 > 0)
				{
					if (num5 > 4096)
					{
						ForceChannelFault(2156068864u);
						return false;
					}
					byte[] array = new byte[num5];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = binaryDecoder.ReadByte(null);
					}
					if (!SetEndpointUrl(new UTF8Encoding().GetString(array, 0, array.Length)))
					{
						ForceChannelFault(2156068864u);
						return false;
					}
				}
				binaryDecoder.Close();
				if (num < base.ReceiveBufferSize)
				{
					base.ReceiveBufferSize = (int)num;
				}
				if (base.ReceiveBufferSize < 8192)
				{
					base.ReceiveBufferSize = 8192;
				}
				if (num2 < base.SendBufferSize)
				{
					base.SendBufferSize = (int)num2;
				}
				if (base.SendBufferSize < 8192)
				{
					base.SendBufferSize = 8192;
				}
				if (num3 != 0 && num3 < base.MaxResponseMessageSize)
				{
					base.MaxResponseMessageSize = (int)num3;
				}
				if (base.MaxResponseMessageSize < base.SendBufferSize)
				{
					base.MaxResponseMessageSize = base.SendBufferSize;
				}
				base.MaxResponseChunkCount = UaSCUaBinaryChannel.CalculateChunkCount(base.MaxResponseMessageSize, base.SendBufferSize);
				if (num4 != 0 && num4 < base.MaxResponseChunkCount)
				{
					base.MaxResponseChunkCount = (int)num4;
				}
				base.MaxRequestChunkCount = UaSCUaBinaryChannel.CalculateChunkCount(base.MaxRequestMessageSize, base.ReceiveBufferSize);
			}
			byte[] array2 = base.BufferManager.TakeBuffer(127, "ProcessHelloMessage");
			try
			{
				using (MemoryStream stream = new MemoryStream(array2, 0, 127))
				{
					using BinaryEncoder binaryEncoder = new BinaryEncoder(stream, base.Quotas.MessageContext, leaveOpen: false);
					binaryEncoder.WriteUInt32(null, 1179337537u);
					binaryEncoder.WriteUInt32(null, 0u);
					binaryEncoder.WriteUInt32(null, 0u);
					binaryEncoder.WriteUInt32(null, (uint)base.ReceiveBufferSize);
					binaryEncoder.WriteUInt32(null, (uint)base.SendBufferSize);
					binaryEncoder.WriteUInt32(null, (uint)base.MaxRequestMessageSize);
					binaryEncoder.WriteUInt32(null, (uint)base.MaxRequestChunkCount);
					int num6 = binaryEncoder.Close();
					UaSCUaBinaryChannel.UpdateMessageSize(array2, 0, num6);
					base.State = TcpChannelState.Opening;
					BeginWriteMessage(new ArraySegment<byte>(array2, 0, num6), null);
				}
				array2 = null;
			}
			finally
			{
				if (array2 != null)
				{
					base.BufferManager.ReturnBuffer(array2, "ProcessHelloMessage");
				}
			}
		}
		catch (Exception exception)
		{
			ForceChannelFault(exception, 2156003328u, "Unexpected error while processing a Hello message.");
		}
		return false;
	}

	private bool ProcessOpenSecureChannelRequest(uint messageType, ArraySegment<byte> messageChunk)
	{
		if (base.State != TcpChannelState.Opening && base.State != TcpChannelState.Open)
		{
			ForceChannelFault(2155741184u, "Client sent an unexpected OpenSecureChannel message.");
			return false;
		}
		uint channelId = 0u;
		X509Certificate2 senderCertificate = null;
		uint requestId = 0u;
		uint sequenceNumber = 0u;
		ArraySegment<byte> chunk;
		try
		{
			chunk = ReadAsymmetricMessage(messageChunk, base.ServerCertificate, out channelId, out senderCertificate, out requestId, out sequenceNumber);
			if (!VerifySequenceNumber(sequenceNumber, "ProcessOpenSecureChannelRequest"))
			{
				throw new ServiceResultException(2156396544u);
			}
		}
		catch (Exception ex)
		{
			base.ReportAuditOpenSecureChannelEvent?.Invoke(this, null, senderCertificate, ex);
			base.ReportAuditCertificateEvent?.Invoke(senderCertificate, ex);
			if (ex.InnerException is ServiceResultException ex2)
			{
				if (ex2.StatusCode == 2149187584u || ex2.StatusCode == 2165112832u || ex2.StatusCode == 2149384192u || ex2.StatusCode == 2148663296u || ex2.StatusCode == 2165571584u || (ex2.InnerResult != null && ex2.InnerResult.StatusCode == 2149187584u))
				{
					ForceChannelFault(2148728832u, "Could not verify security on OpenSecureChannel request.");
					return false;
				}
				if (ex2.StatusCode == 2148794368u || ex2.StatusCode == 2148859904u || ex2.StatusCode == 2148925440u || ex2.StatusCode == 2148990976u || ex2.StatusCode == 2149056512u || ex2.StatusCode == 2149122048u || ex2.StatusCode == 2149253120u || ex2.StatusCode == 2149318656u || ex2.StatusCode == 2149449728u)
				{
					ForceChannelFault(ex2, ex2.StatusCode, ex.Message);
					return false;
				}
			}
			ForceChannelFault(2148728832u, "Could not verify security on OpenSecureChannel request.");
			return false;
		}
		BufferCollection bufferCollection = null;
		OpenSecureChannelRequest openSecureChannelRequest = null;
		try
		{
			bool firstCall = base.ClientCertificate == null;
			if (base.ClientCertificate != null)
			{
				UaSCUaBinaryChannel.CompareCertificates(base.ClientCertificate, senderCertificate, allowNull: false);
			}
			else
			{
				base.ClientCertificate = senderCertificate;
			}
			if (!TcpMessageType.IsFinal(messageType))
			{
				SaveIntermediateChunk(requestId, chunk, isServerContext: true);
				return false;
			}
			bufferCollection = GetSavedChunks(requestId, chunk, isServerContext: true);
			openSecureChannelRequest = (OpenSecureChannelRequest)BinaryDecoder.DecodeMessage(new ArraySegmentStream(bufferCollection), typeof(OpenSecureChannelRequest), base.Quotas.MessageContext);
			if (openSecureChannelRequest == null)
			{
				throw ServiceResultException.Create(2152071168u, "Could not parse OpenSecureChannel request body.");
			}
			if (openSecureChannelRequest.SecurityMode != base.SecurityMode)
			{
				ReviseSecurityMode(firstCall, openSecureChannelRequest.SecurityMode);
			}
			ChannelToken channelToken = CreateToken();
			channelToken.TokenId = GetNewTokenId();
			channelToken.ServerNonce = CreateNonce();
			channelToken.ClientNonce = openSecureChannelRequest.ClientNonce;
			if (!ValidateNonce(channelToken.ClientNonce))
			{
				throw ServiceResultException.Create(2149842944u, "Client nonce is not the correct length or not random enough.");
			}
			int num = (int)openSecureChannelRequest.RequestedLifetime;
			if (num < 60000)
			{
				num = 60000;
			}
			if (num > 0 && num < channelToken.Lifetime)
			{
				channelToken.Lifetime = num;
			}
			SecurityTokenRequestType requestType = openSecureChannelRequest.RequestType;
			if (requestType == SecurityTokenRequestType.Issue && base.State != TcpChannelState.Opening)
			{
				throw ServiceResultException.Create(2152923136u, "Cannot request a new token for an open channel.");
			}
			if (requestType == SecurityTokenRequestType.Renew && base.State != TcpChannelState.Open)
			{
				if (base.State == TcpChannelState.Opening)
				{
					base.Listener.ReconnectToExistingChannel(base.Socket, requestId, sequenceNumber, channelId, base.ClientCertificate, channelToken, openSecureChannelRequest);
					Utils.LogInfo("{0} ReconnectToExistingChannel Socket={1:X8}, ChannelId={2}, TokenId={3}", ChannelName, (base.Socket != null) ? base.Socket.Handle : 0, (base.CurrentToken != null) ? base.CurrentToken.ChannelId : 0u, (base.CurrentToken != null) ? base.CurrentToken.TokenId : 0u);
					ChannelClosed();
					return false;
				}
				throw ServiceResultException.Create(2152923136u, "Cannot request to renew a token for a channel that has not been opened.");
			}
			if (requestType == SecurityTokenRequestType.Renew && channelId != base.ChannelId)
			{
				throw ServiceResultException.Create(2155806720u, "Do not recognize the secure channel id provided.");
			}
			if (requestType == SecurityTokenRequestType.Issue)
			{
				Audit.SecureChannelCreated(m_ImplementationString, base.Listener.EndpointUrl.ToString(), Utils.Format("{0}", base.ChannelId), base.EndpointDescription, base.ClientCertificate, base.ServerCertificate, BinaryEncodingSupport.Required);
			}
			else
			{
				Audit.SecureChannelRenewed(m_ImplementationString, Utils.Format("{0}", base.ChannelId));
			}
			if (requestType == SecurityTokenRequestType.Renew)
			{
				SetRenewedToken(channelToken);
			}
			else
			{
				ActivateToken(channelToken);
			}
			base.State = TcpChannelState.Open;
			SendOpenSecureChannelResponse(requestId, channelToken, openSecureChannelRequest);
			CompleteReverseHello(null);
			NotifyMonitors(ServiceResult.Good, closed: false);
			if (requestType == SecurityTokenRequestType.Issue)
			{
				base.ReportAuditOpenSecureChannelEvent?.Invoke(this, openSecureChannelRequest, base.ClientCertificate, null);
			}
			return false;
		}
		catch (Exception ex3)
		{
			base.ReportAuditOpenSecureChannelEvent?.Invoke(this, openSecureChannelRequest, base.ClientCertificate, ex3);
			SendServiceFault(requestId, ServiceResult.Create(ex3, 2156003328u, "Unexpected error processing OpenSecureChannel request."));
			CompleteReverseHello(ex3);
			return false;
		}
		finally
		{
			bufferCollection?.Release(base.BufferManager, "ProcessOpenSecureChannelRequest");
		}
	}

	protected override void NotifyMonitors(ServiceResult status, bool closed)
	{
		try
		{
			this.StatusChanged?.Invoke(this, status, closed);
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Error raising StatusChanged event.");
		}
	}

	protected override void CompleteReverseHello(Exception e)
	{
		ReverseConnectAsyncResult pendingReverseHello = m_pendingReverseHello;
		if (pendingReverseHello != null && pendingReverseHello == Interlocked.CompareExchange(ref m_pendingReverseHello, null, pendingReverseHello))
		{
			pendingReverseHello.Exception = e;
			pendingReverseHello.OperationCompleted();
		}
	}

	private void SendOpenSecureChannelResponse(uint requestId, ChannelToken token, OpenSecureChannelRequest request)
	{
		Utils.LogTrace("ChannelId {0}: SendOpenSecureChannelResponse()", base.ChannelId);
		byte[] array = BinaryEncoder.EncodeMessage(new OpenSecureChannelResponse
		{
			ResponseHeader = 
			{
				RequestHandle = request.RequestHeader.RequestHandle,
				Timestamp = DateTime.UtcNow
			},
			SecurityToken = 
			{
				ChannelId = token.ChannelId,
				TokenId = token.TokenId,
				CreatedAt = token.CreatedAt,
				RevisedLifetime = (uint)token.Lifetime
			},
			ServerNonce = token.ServerNonce
		}, base.Quotas.MessageContext);
		BufferCollection bufferCollection = WriteAsymmetricMessage(5132367u, requestId, base.ServerCertificate, base.ServerCertificateChain, base.ClientCertificate, new ArraySegment<byte>(array, 0, array.Length));
		try
		{
			BeginWriteMessage(bufferCollection, null);
			bufferCollection = null;
		}
		finally
		{
			bufferCollection?.Release(base.BufferManager, "SendOpenSecureChannelResponse");
		}
	}

	private bool ProcessCloseSecureChannelRequest(uint messageType, ArraySegment<byte> messageChunk)
	{
		ChannelToken token = null;
		uint requestId = 0u;
		uint sequenceNumber = 0u;
		ArraySegment<byte> chunk;
		try
		{
			chunk = ReadSymmetricMessage(messageChunk, isRequest: true, out token, out requestId, out sequenceNumber);
			if (!VerifySequenceNumber(sequenceNumber, "ProcessCloseSecureChannelRequest"))
			{
				throw new ServiceResultException(2156396544u, "Could not verify security on CloseSecureChannel request.");
			}
		}
		catch (Exception ex)
		{
			base.ReportAuditCloseSecureChannelEvent?.Invoke(this, ex);
			throw ServiceResultException.Create(2148728832u, ex, "Could not verify security on CloseSecureChannel request.");
		}
		BufferCollection bufferCollection = null;
		try
		{
			if (!TcpMessageType.IsFinal(messageType))
			{
				SaveIntermediateChunk(requestId, chunk, isServerContext: true);
				return false;
			}
			bufferCollection = GetSavedChunks(requestId, chunk, isServerContext: true);
			if (!(BinaryDecoder.DecodeMessage(new ArraySegmentStream(bufferCollection), typeof(CloseSecureChannelRequest), base.Quotas.MessageContext) is CloseSecureChannelRequest))
			{
				throw ServiceResultException.Create(2152071168u, "Could not parse CloseSecureChannel request body.");
			}
			base.ReportAuditCloseSecureChannelEvent?.Invoke(this, null);
		}
		catch (Exception exception)
		{
			base.ReportAuditCloseSecureChannelEvent?.Invoke(this, exception);
			Utils.LogError(exception, "Unexpected error processing CloseSecureChannel request.");
		}
		finally
		{
			bufferCollection?.Release(base.BufferManager, "ProcessCloseSecureChannelRequest");
			Utils.LogInfo("{0} ProcessCloseSecureChannelRequest success, ChannelId={1}, TokenId={2}, Socket={3:X8}", ChannelName, base.CurrentToken?.ChannelId, base.CurrentToken?.TokenId, base.Socket?.Handle);
			ChannelClosed();
		}
		return true;
	}

	private bool ProcessRequestMessage(uint messageType, ArraySegment<byte> messageChunk)
	{
		if (base.State != TcpChannelState.Open)
		{
			ForceChannelFault(2155741184u, "Client sent an unexpected request message.");
			return false;
		}
		ChannelToken token = null;
		uint requestId = 0u;
		uint sequenceNumber = 0u;
		ArraySegment<byte> arraySegment;
		try
		{
			arraySegment = ReadSymmetricMessage(messageChunk, isRequest: true, out token, out requestId, out sequenceNumber);
			if (!VerifySequenceNumber(sequenceNumber, "ProcessRequestMessage"))
			{
				throw new ServiceResultException(2156396544u);
			}
			if (token == base.CurrentToken && base.PreviousToken != null && !base.PreviousToken.Expired)
			{
				Utils.LogInfo("ChannelId {0}: Server Current Token #{1}, Revoked Token #{2}.", base.PreviousToken.ChannelId, base.CurrentToken.TokenId, base.PreviousToken.TokenId);
				base.PreviousToken.Lifetime = 0;
			}
		}
		catch (Exception exception)
		{
			ForceChannelFault(exception, 2148728832u, "Could not verify security on incoming request.");
			return false;
		}
		int num = 5;
		while (ChannelFull && num > 0)
		{
			Utils.LogInfo("Channel {0}: full -- delay processing.", base.Id);
			Thread.Sleep(1000);
			if (--num == 0 && ChannelFull)
			{
				Utils.LogWarning("Channel {0}: break socket connection.", base.Id);
				ChannelClosed();
				return false;
			}
		}
		BufferCollection chunksToProcess = null;
		try
		{
			if (TcpMessageType.IsAbort(messageType))
			{
				Utils.LogWarning(16, "ChannelId {0}: ProcessRequestMessage RequestId {1} was aborted.", base.ChannelId, requestId);
				chunksToProcess = GetSavedChunks(requestId, arraySegment, isServerContext: true);
				return true;
			}
			if (!TcpMessageType.IsFinal(messageType))
			{
				bool flag = SaveIntermediateChunk(requestId, arraySegment, isServerContext: true);
				if (base.DiscoveryOnly)
				{
					if (flag)
					{
						if (!ValidateDiscoveryServiceCall(token, requestId, arraySegment, out chunksToProcess))
						{
							ChannelClosed();
						}
					}
					else if (GetSavedChunksTotalSize() > 65535)
					{
						chunksToProcess = GetSavedChunks(0u, arraySegment, isServerContext: true);
						SendServiceFault(token, requestId, ServiceResult.Create(2153054208u, "Discovery Channel message size exceeded."));
						ChannelClosed();
					}
				}
				return true;
			}
			if (base.DiscoveryOnly && GetSavedChunksTotalSize() == 0 && !ValidateDiscoveryServiceCall(token, requestId, arraySegment, out chunksToProcess))
			{
				return true;
			}
			chunksToProcess = GetSavedChunks(requestId, arraySegment, isServerContext: true);
			if (!(BinaryDecoder.DecodeMessage(new ArraySegmentStream(chunksToProcess), null, base.Quotas.MessageContext) is IServiceRequest serviceRequest))
			{
				SendServiceFault(token, requestId, ServiceResult.Create(2152071168u, "Could not parse request body."));
				return true;
			}
			if (base.DiscoveryOnly && !(serviceRequest is GetEndpointsRequest) && !(serviceRequest is FindServersRequest) && !(serviceRequest is FindServersOnNetworkRequest))
			{
				SendServiceFault(token, requestId, ServiceResult.Create(2153054208u, "Channel can only be used for discovery."));
				return true;
			}
			base.RequestReceived?.Invoke(this, requestId, serviceRequest);
			return true;
		}
		catch (Exception ex)
		{
			Utils.LogError(ex, "Unexpected error processing request.");
			SendServiceFault(token, requestId, ServiceResult.Create(ex, 2156003328u, "Unexpected error processing request."));
			return true;
		}
		finally
		{
			chunksToProcess?.Release(base.BufferManager, "ProcessRequestMessage");
		}
	}

	public void SendResponse(uint requestId, IServiceResponse response)
	{
		if (response == null)
		{
			throw new ArgumentNullException("response");
		}
		lock (base.DataLock)
		{
			if (base.State == TcpChannelState.Faulted)
			{
				m_queuedResponses[requestId] = response;
				return;
			}
			Utils.EventLog.SendResponse((int)base.ChannelId, (int)requestId);
			BufferCollection bufferCollection = null;
			try
			{
				bool limitsExceeded = false;
				bufferCollection = WriteSymmetricMessage(4674381u, requestId, base.CurrentToken, response, isRequest: false, out limitsExceeded);
			}
			catch (Exception e)
			{
				SendServiceFault(base.CurrentToken, requestId, ServiceResult.Create(e, 2147876864u, "Could not encode outgoing message."));
				return;
			}
			try
			{
				BeginWriteMessage(bufferCollection, null);
				bufferCollection = null;
			}
			catch (Exception)
			{
				bufferCollection?.Release(base.BufferManager, "SendResponse");
				m_queuedResponses[requestId] = response;
			}
		}
	}

	private void ResetQueuedResponses(Action<object> action)
	{
		Task.Factory.StartNew(action, m_queuedResponses);
		m_queuedResponses = new SortedDictionary<uint, IServiceResponse>();
	}

	protected override void DoMessageLimitsExceeded()
	{
		base.DoMessageLimitsExceeded();
		ChannelClosed();
	}

	private bool ValidateDiscoveryServiceCall(ChannelToken token, uint requestId, ArraySegment<byte> messageBody, out BufferCollection chunksToProcess)
	{
		chunksToProcess = null;
		using BinaryDecoder binaryDecoder = new BinaryDecoder(messageBody.AsMemory().ToArray(), base.Quotas.MessageContext);
		NodeId nodeId = binaryDecoder.ReadNodeId(null);
		if (nodeId != ObjectIds.GetEndpointsRequest_Encoding_DefaultBinary && nodeId != ObjectIds.FindServersRequest_Encoding_DefaultBinary && nodeId != ObjectIds.FindServersOnNetworkRequest_Encoding_DefaultBinary)
		{
			chunksToProcess = GetSavedChunks(0u, messageBody, isServerContext: true);
			SendServiceFault(token, requestId, ServiceResult.Create(2153054208u, "Channel can only be used for discovery."));
			return false;
		}
		return true;
	}
}
