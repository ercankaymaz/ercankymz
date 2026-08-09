using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class UaSCUaBinaryChannel : IMessageSink, IDisposable
{
	protected class WriteOperation : ChannelAsyncOperation<int>
	{
		private uint m_requestId;

		private IEncodeable m_messageBody;

		public uint RequestId
		{
			get
			{
				return m_requestId;
			}
			set
			{
				m_requestId = value;
			}
		}

		public IEncodeable MessageBody
		{
			get
			{
				return m_messageBody;
			}
			set
			{
				m_messageBody = value;
			}
		}

		public WriteOperation(int timeout, AsyncCallback callback, object asyncState)
			: base(timeout, callback, asyncState)
		{
		}
	}

	private EndpointDescriptionCollection m_endpoints;

	private MessageSecurityMode m_securityMode;

	private string m_securityPolicyUri;

	private bool m_discoveryOnly;

	private EndpointDescription m_selectedEndpoint;

	private X509Certificate2 m_serverCertificate;

	private X509Certificate2Collection m_serverCertificateChain;

	private X509Certificate2 m_clientCertificate;

	private X509Certificate2Collection m_clientCertificateChain;

	private bool m_uninitialized;

	private readonly object m_lock = new object();

	private IMessageSocket m_socket;

	private BufferManager m_bufferManager;

	private ChannelQuotas m_quotas;

	private int m_receiveBufferSize;

	private int m_sendBufferSize;

	private int m_activeWriteRequests;

	private int m_maxRequestMessageSize;

	private int m_maxResponseMessageSize;

	private int m_maxRequestChunkCount;

	private int m_maxResponseChunkCount;

	private string m_contextId;

	private TcpChannelState m_state;

	private uint m_channelId;

	private string m_globalChannelId;

	private long m_sequenceNumber;

	private uint m_remoteSequenceNumber;

	private bool m_sequenceRollover;

	private uint m_partialRequestId;

	private BufferCollection m_partialMessageChunks;

	private TcpChannelStateEventHandler m_StateChanged;

	private ChannelToken m_currentToken;

	private ChannelToken m_previousToken;

	private ChannelToken m_renewedToken;

	private int m_hmacHashSize;

	private int m_signatureKeySize;

	private int m_encryptionKeySize;

	private int m_encryptionBlockSize;

	public EndpointDescription EndpointDescription
	{
		get
		{
			lock (DataLock)
			{
				return m_selectedEndpoint;
			}
		}
		protected set
		{
			lock (DataLock)
			{
				m_selectedEndpoint = value;
			}
		}
	}

	protected X509Certificate2 ServerCertificate => m_serverCertificate;

	protected X509Certificate2Collection ServerCertificateChain
	{
		get
		{
			return m_serverCertificateChain;
		}
		set
		{
			m_serverCertificateChain = value;
		}
	}

	protected MessageSecurityMode SecurityMode => m_securityMode;

	protected string SecurityPolicyUri => m_securityPolicyUri;

	protected bool DiscoveryOnly => m_discoveryOnly;

	protected X509Certificate2 ClientCertificate
	{
		get
		{
			return m_clientCertificate;
		}
		set
		{
			m_clientCertificate = value;
		}
	}

	internal X509Certificate2Collection ClientCertificateChain
	{
		get
		{
			return m_clientCertificateChain;
		}
		set
		{
			m_clientCertificateChain = value;
		}
	}

	public uint Id
	{
		get
		{
			lock (m_lock)
			{
				return m_channelId;
			}
		}
	}

	public string GlobalChannelId
	{
		get
		{
			lock (m_lock)
			{
				return m_globalChannelId;
			}
		}
	}

	public virtual bool ChannelFull => m_activeWriteRequests > 100;

	protected object DataLock => m_lock;

	protected internal IMessageSocket Socket
	{
		get
		{
			return m_socket;
		}
		set
		{
			m_socket = value;
		}
	}

	protected internal bool ReverseSocket { get; set; }

	protected BufferManager BufferManager => m_bufferManager;

	protected ChannelQuotas Quotas => m_quotas;

	protected int ReceiveBufferSize
	{
		get
		{
			return m_receiveBufferSize;
		}
		set
		{
			m_receiveBufferSize = value;
		}
	}

	protected int SendBufferSize
	{
		get
		{
			return m_sendBufferSize;
		}
		set
		{
			m_sendBufferSize = value;
		}
	}

	protected int MaxRequestMessageSize
	{
		get
		{
			return m_maxRequestMessageSize;
		}
		set
		{
			m_maxRequestMessageSize = value;
		}
	}

	protected int MaxRequestChunkCount
	{
		get
		{
			return m_maxRequestChunkCount;
		}
		set
		{
			m_maxRequestChunkCount = value;
		}
	}

	protected int MaxResponseMessageSize
	{
		get
		{
			return m_maxResponseMessageSize;
		}
		set
		{
			m_maxResponseMessageSize = value;
		}
	}

	protected int MaxResponseChunkCount
	{
		get
		{
			return m_maxResponseChunkCount;
		}
		set
		{
			m_maxResponseChunkCount = value;
		}
	}

	protected TcpChannelState State
	{
		get
		{
			return m_state;
		}
		set
		{
			if (m_state != value)
			{
				Utils.LogInfo("ChannelId {0}: in {1} state.", ChannelId, value);
			}
			m_state = value;
		}
	}

	protected uint ChannelId
	{
		get
		{
			return m_channelId;
		}
		set
		{
			m_channelId = value;
			m_globalChannelId = Utils.Format("{0}-{1}", m_contextId, m_channelId);
		}
	}

	protected internal ChannelToken CurrentToken => m_currentToken;

	protected ChannelToken PreviousToken => m_previousToken;

	protected ChannelToken RenewedToken => m_renewedToken;

	private int SymmetricSignatureSize => m_hmacHashSize;

	private int EncryptionBlockSize => m_encryptionBlockSize;

	protected byte[] CreateNonce()
	{
		uint nonceLength = GetNonceLength();
		if (nonceLength != 0)
		{
			return Utils.Nonce.CreateNonce(nonceLength);
		}
		return null;
	}

	protected static string GetThumbprintString(byte[] thumbprint)
	{
		if (thumbprint == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder(thumbprint.Length * 2);
		for (int i = 0; i < thumbprint.Length; i++)
		{
			stringBuilder.AppendFormat("{0:X2}", thumbprint[i]);
		}
		return stringBuilder.ToString();
	}

	protected static byte[] GetThumbprintBytes(string thumbprint)
	{
		if (thumbprint == null)
		{
			return null;
		}
		byte[] array = new byte[thumbprint.Length / 2];
		for (int i = 0; i < thumbprint.Length - 1; i += 2)
		{
			array[i / 2] = Convert.ToByte(thumbprint.Substring(i, 2), 16);
		}
		return array;
	}

	protected static void CompareCertificates(X509Certificate2 expected, X509Certificate2 actual, bool allowNull)
	{
		bool flag = true;
		if (expected == null)
		{
			flag = actual == null;
			if (allowNull)
			{
				flag = true;
			}
		}
		else if (actual == null)
		{
			flag = allowNull;
		}
		else if (!Utils.IsEqual(expected.RawData, actual.RawData))
		{
			flag = false;
		}
		if (!flag)
		{
			throw ServiceResultException.Create(2148663296u, "Certificate mismatch. Expecting '{0}'/{1},. Received '{2}'/{3}.", (expected != null) ? expected.Subject : "(null)", (expected != null) ? expected.Thumbprint : "(null)", (actual != null) ? actual.Subject : "(null)", (actual != null) ? actual.Thumbprint : "(null)");
		}
	}

	protected uint GetNonceLength()
	{
		return Utils.Nonce.GetNonceLength(SecurityPolicyUri);
	}

	protected bool ValidateNonce(byte[] nonce)
	{
		return Utils.Nonce.ValidateNonce(nonce, SecurityMode, SecurityPolicyUri);
	}

	protected int GetPlainTextBlockSize(X509Certificate2 receiverCertificate)
	{
		switch (SecurityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
			return RsaUtils.GetPlainTextBlockSize(receiverCertificate, RsaUtils.Padding.OaepSHA1);
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return RsaUtils.GetPlainTextBlockSize(receiverCertificate, RsaUtils.Padding.OaepSHA256);
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			return RsaUtils.GetPlainTextBlockSize(receiverCertificate, RsaUtils.Padding.Pkcs1);
		default:
			return 1;
		}
	}

	protected int GetCipherTextBlockSize(X509Certificate2 receiverCertificate)
	{
		switch (SecurityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
			return RsaUtils.GetCipherTextBlockSize(receiverCertificate, RsaUtils.Padding.OaepSHA1);
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return RsaUtils.GetCipherTextBlockSize(receiverCertificate, RsaUtils.Padding.OaepSHA256);
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			return RsaUtils.GetCipherTextBlockSize(receiverCertificate, RsaUtils.Padding.Pkcs1);
		default:
			return 1;
		}
	}

	protected int GetAsymmetricHeaderSize(string securityPolicyUri, X509Certificate2 senderCertificate)
	{
		int num = 0;
		num += 12;
		num += 4;
		if (securityPolicyUri != null)
		{
			num += Encoding.UTF8.GetByteCount(securityPolicyUri);
		}
		num += 4;
		num += 4;
		if (SecurityMode != MessageSecurityMode.None)
		{
			num += senderCertificate.RawData.Length;
			num += 20;
		}
		if (num >= SendBufferSize - 8 - GetAsymmetricSignatureSize(senderCertificate) - 1)
		{
			throw ServiceResultException.Create(2147614720u, "AsymmetricSecurityHeader is {0} bytes which is too large for the send buffer size of {1} bytes.", num, SendBufferSize);
		}
		return num;
	}

	protected int GetAsymmetricHeaderSize(string securityPolicyUri, X509Certificate2 senderCertificate, int senderCertificateSize)
	{
		int num = 0;
		num += 12;
		num += 4;
		if (securityPolicyUri != null)
		{
			num += Encoding.UTF8.GetByteCount(securityPolicyUri);
		}
		num += 4;
		num += 4;
		if (SecurityMode != MessageSecurityMode.None)
		{
			num += senderCertificateSize;
			num += 20;
		}
		if (num >= SendBufferSize - 8 - GetAsymmetricSignatureSize(senderCertificate) - 1)
		{
			throw ServiceResultException.Create(2147614720u, "AsymmetricSecurityHeader is {0} bytes which is too large for the send buffer size of {1} bytes.", num, SendBufferSize);
		}
		return num;
	}

	protected int GetAsymmetricSignatureSize(X509Certificate2 senderCertificate)
	{
		switch (SecurityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return RsaUtils.GetSignatureLength(senderCertificate);
		default:
			return 0;
		}
	}

	protected void WriteAsymmetricMessageHeader(BinaryEncoder encoder, uint messageType, uint secureChannelId, string securityPolicyUri, X509Certificate2 senderCertificate, X509Certificate2 receiverCertificate)
	{
		int senderCertificateSize = 0;
		WriteAsymmetricMessageHeader(encoder, messageType, secureChannelId, securityPolicyUri, senderCertificate, null, receiverCertificate, out senderCertificateSize);
	}

	protected void WriteAsymmetricMessageHeader(BinaryEncoder encoder, uint messageType, uint secureChannelId, string securityPolicyUri, X509Certificate2 senderCertificate, X509Certificate2Collection senderCertificateChain, X509Certificate2 receiverCertificate, out int senderCertificateSize)
	{
		int position = encoder.Position;
		senderCertificateSize = 0;
		encoder.WriteUInt32(null, messageType);
		encoder.WriteUInt32(null, 0u);
		encoder.WriteUInt32(null, secureChannelId);
		encoder.WriteString(null, securityPolicyUri);
		if (SecurityMode != MessageSecurityMode.None)
		{
			if (senderCertificateChain != null && senderCertificateChain.Count > 0)
			{
				X509Certificate2 x509Certificate = senderCertificateChain[0];
				int maxSenderCertificateSize = GetMaxSenderCertificateSize(x509Certificate, securityPolicyUri);
				List<byte> list = new List<byte>(x509Certificate.RawData);
				senderCertificateSize = x509Certificate.RawData.Length;
				for (int i = 1; i < senderCertificateChain.Count; i++)
				{
					x509Certificate = senderCertificateChain[i];
					senderCertificateSize += x509Certificate.RawData.Length;
					if (senderCertificateSize < maxSenderCertificateSize)
					{
						list.AddRange(x509Certificate.RawData);
						continue;
					}
					senderCertificateSize -= x509Certificate.RawData.Length;
					break;
				}
				encoder.WriteByteString(null, list.ToArray());
			}
			else
			{
				encoder.WriteByteString(null, senderCertificate.RawData);
			}
			encoder.WriteByteString(null, GetThumbprintBytes(receiverCertificate.Thumbprint));
		}
		else
		{
			encoder.WriteByteString(null, null);
			encoder.WriteByteString(null, null);
		}
		if (encoder.Position - position > SendBufferSize)
		{
			throw ServiceResultException.Create(2147614720u, "AsymmetricSecurityHeader is {0} bytes which is too large for the send buffer size of {1} bytes.", encoder.Position - position, SendBufferSize);
		}
	}

	private int GetMaxSenderCertificateSize(X509Certificate2 senderCertificate, string securityPolicyUri)
	{
		int num = 16;
		if (securityPolicyUri != null)
		{
			num += Encoding.UTF8.GetByteCount(securityPolicyUri);
		}
		num += 4;
		num += 4;
		num += 20;
		num += 8;
		num++;
		num += GetAsymmetricSignatureSize(senderCertificate);
		return SendBufferSize - num;
	}

	protected BufferCollection WriteAsymmetricMessage(uint messageType, uint requestId, X509Certificate2 senderCertificate, X509Certificate2 receiverCertificate, ArraySegment<byte> messageBody)
	{
		return WriteAsymmetricMessage(messageType, requestId, senderCertificate, null, receiverCertificate, messageBody);
	}

	protected BufferCollection WriteAsymmetricMessage(uint messageType, uint requestId, X509Certificate2 senderCertificate, X509Certificate2Collection senderCertificateChain, X509Certificate2 receiverCertificate, ArraySegment<byte> messageBody)
	{
		bool flag = false;
		BufferCollection bufferCollection = new BufferCollection();
		byte[] array = BufferManager.TakeBuffer(SendBufferSize, "WriteAsymmetricMessage");
		BinaryEncoder binaryEncoder = null;
		try
		{
			binaryEncoder = new BinaryEncoder(array, 0, SendBufferSize, Quotas.MessageContext);
			int num = 0;
			if (senderCertificateChain != null && senderCertificateChain.Count > 0)
			{
				int senderCertificateSize = 0;
				WriteAsymmetricMessageHeader(binaryEncoder, messageType | 0x43000000, ChannelId, SecurityPolicyUri, senderCertificate, senderCertificateChain, receiverCertificate, out senderCertificateSize);
				num = GetAsymmetricHeaderSize(SecurityPolicyUri, senderCertificate, senderCertificateSize);
			}
			else
			{
				WriteAsymmetricMessageHeader(binaryEncoder, messageType | 0x43000000, ChannelId, SecurityPolicyUri, senderCertificate, receiverCertificate);
				num = GetAsymmetricHeaderSize(SecurityPolicyUri, senderCertificate);
			}
			int asymmetricSignatureSize = GetAsymmetricSignatureSize(senderCertificate);
			ArraySegment<byte> headerToCopy = new ArraySegment<byte>(array, 0, num);
			int plainTextBlockSize = GetPlainTextBlockSize(receiverCertificate);
			int cipherTextBlockSize = GetCipherTextBlockSize(receiverCertificate);
			int num2 = (SendBufferSize - num) / cipherTextBlockSize * plainTextBlockSize - asymmetricSignatureSize - 1 - 8;
			int num3 = messageBody.Count;
			int num4 = messageBody.Offset;
			while (num3 > 0)
			{
				binaryEncoder.WriteUInt32(null, GetNewSequenceNumber());
				binaryEncoder.WriteUInt32(null, requestId);
				int num5 = num3;
				if (num5 > num2)
				{
					num5 = num2;
				}
				else
				{
					UpdateMessageType(array, 0, messageType | 0x46000000);
				}
				binaryEncoder.WriteRawBytes(messageBody.Array, messageBody.Offset + num4, num5);
				int num6 = binaryEncoder.Position - num + asymmetricSignatureSize;
				int num7 = 0;
				if (SecurityMode != MessageSecurityMode.None)
				{
					if (X509Utils.GetRSAPublicKeySize(receiverCertificate) <= 2048)
					{
						num6++;
						if (num6 % plainTextBlockSize != 0)
						{
							num7 = plainTextBlockSize - num6 % plainTextBlockSize;
						}
						binaryEncoder.WriteByte(null, (byte)num7);
						for (int i = 0; i < num7; i++)
						{
							binaryEncoder.WriteByte(null, (byte)num7);
						}
					}
					else
					{
						num6++;
						num6++;
						if (num6 % plainTextBlockSize != 0)
						{
							num7 = plainTextBlockSize - num6 % plainTextBlockSize;
						}
						byte value = (byte)(num7 & 0xFF);
						byte value2 = (byte)((num7 >> 8) & 0xFF);
						binaryEncoder.WriteByte(null, value);
						for (int j = 0; j < num7; j++)
						{
							binaryEncoder.WriteByte(null, value);
						}
						binaryEncoder.WriteByte(null, value2);
					}
					num6 += num7;
				}
				int num8 = num6 / plainTextBlockSize * cipherTextBlockSize;
				UpdateMessageSize(array, 0, num8 + num);
				byte[] array2 = Sign(new ArraySegment<byte>(array, 0, binaryEncoder.Position), senderCertificate);
				if (array2 != null)
				{
					binaryEncoder.WriteRawBytes(array2, 0, array2.Length);
				}
				int num9 = binaryEncoder.Close();
				ArraySegment<byte> item = Encrypt(new ArraySegment<byte>(array, num, num9 - num), headerToCopy, receiverCertificate);
				if (item.Count != num8 + num)
				{
					throw new InvalidDataException("Actual message size is not the same as the predicted message size.");
				}
				bufferCollection.Add(item);
				num3 -= num5;
				num4 += num5;
				if (num3 > 0)
				{
					Utils.SilentDispose(binaryEncoder);
					MemoryStream memoryStream = new MemoryStream(array, 0, SendBufferSize);
					memoryStream.Seek(headerToCopy.Count, SeekOrigin.Current);
					binaryEncoder = new BinaryEncoder(memoryStream, Quotas.MessageContext, leaveOpen: false);
				}
			}
			flag = true;
			return bufferCollection;
		}
		catch (Exception e)
		{
			throw new ServiceResultException("Could not write async message", e);
		}
		finally
		{
			Utils.SilentDispose(binaryEncoder);
			BufferManager.ReturnBuffer(array, "WriteAsymmetricMessage");
			if (!flag)
			{
				bufferCollection.Release(BufferManager, "WriteAsymmetricMessage");
			}
		}
	}

	protected void ReadAsymmetricMessageHeader(BinaryDecoder decoder, X509Certificate2 receiverCertificate, out uint secureChannelId, out X509Certificate2Collection senderCertificateChain, out string securityPolicyUri)
	{
		senderCertificateChain = null;
		decoder.ReadUInt32(null);
		decoder.ReadUInt32(null);
		byte[] array = null;
		byte[] array2 = null;
		try
		{
			secureChannelId = decoder.ReadUInt32(null);
			securityPolicyUri = decoder.ReadString(null, 256);
			array = decoder.ReadByteString(null, 7500);
			array2 = decoder.ReadByteString(null, 20);
		}
		catch (Exception e)
		{
			throw ServiceResultException.Create(2148728832u, e, "The asymmetric security header could not be parsed.");
		}
		if (array != null && array.Length != 0)
		{
			senderCertificateChain = Utils.ParseCertificateChainBlob(array);
			try
			{
				if (senderCertificateChain[0].Thumbprint == null)
				{
					throw ServiceResultException.Create(2148663296u, "Invalid certificate thumbprint.");
				}
			}
			catch (Exception e2)
			{
				throw ServiceResultException.Create(2148663296u, e2, "The sender's certificate could not be parsed.");
			}
		}
		else if (securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			throw ServiceResultException.Create(2148663296u, "The sender's certificate was not specified.");
		}
		if (array2 != null && array2.Length != 0)
		{
			if (receiverCertificate.Thumbprint.ToUpperInvariant() != GetThumbprintString(array2))
			{
				throw ServiceResultException.Create(2148663296u, "The receiver's certificate thumbprint is not valid.");
			}
		}
		else if (securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			throw ServiceResultException.Create(2148663296u, "The receiver's certificate thumbprint was not specified.");
		}
	}

	protected void ReviseSecurityMode(bool firstCall, MessageSecurityMode requestedMode)
	{
		bool flag = false;
		if (firstCall && !m_discoveryOnly)
		{
			foreach (EndpointDescription endpoint in m_endpoints)
			{
				if (endpoint.SecurityMode == requestedMode && (requestedMode == MessageSecurityMode.None || endpoint.SecurityPolicyUri == m_securityPolicyUri))
				{
					m_securityMode = endpoint.SecurityMode;
					m_selectedEndpoint = endpoint;
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			throw ServiceResultException.Create(2152988672u, "Security mode is not acceptable to the server.");
		}
	}

	protected virtual bool SetEndpointUrl(string endpointUrl)
	{
		Uri uri = Utils.ParseUri(endpointUrl);
		if (uri == null)
		{
			return false;
		}
		foreach (EndpointDescription endpoint in m_endpoints)
		{
			Uri uri2 = Utils.ParseUri(endpoint.EndpointUrl);
			if (!(uri2 == null) && !(uri2.Scheme != uri.Scheme))
			{
				m_securityMode = endpoint.SecurityMode;
				m_securityPolicyUri = endpoint.SecurityPolicyUri;
				m_selectedEndpoint = endpoint;
				return true;
			}
		}
		return false;
	}

	protected ArraySegment<byte> ReadAsymmetricMessage(ArraySegment<byte> buffer, X509Certificate2 receiverCertificate, out uint channelId, out X509Certificate2 senderCertificate, out uint requestId, out uint sequenceNumber)
	{
		BinaryDecoder binaryDecoder = new BinaryDecoder(buffer.Array, buffer.Offset, buffer.Count, Quotas.MessageContext);
		string securityPolicyUri = null;
		ReadAsymmetricMessageHeader(binaryDecoder, receiverCertificate, out channelId, out var senderCertificateChain, out securityPolicyUri);
		if (senderCertificateChain != null && senderCertificateChain.Count > 0)
		{
			senderCertificate = senderCertificateChain[0];
		}
		else
		{
			senderCertificate = null;
		}
		if (senderCertificate != null && Quotas.CertificateValidator != null && securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			if (Quotas.CertificateValidator is CertificateValidator certificateValidator)
			{
				certificateValidator.Validate(senderCertificateChain);
			}
			else
			{
				Quotas.CertificateValidator.Validate(senderCertificate);
			}
		}
		if (!m_uninitialized)
		{
			if (securityPolicyUri != m_securityPolicyUri)
			{
				throw ServiceResultException.Create(2153054208u, "Cannot change the security policy after creating the channnel.");
			}
		}
		else
		{
			if (m_endpoints != null)
			{
				foreach (EndpointDescription endpoint in m_endpoints)
				{
					if (endpoint.SecurityPolicyUri == securityPolicyUri || (securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None" && endpoint.SecurityMode == MessageSecurityMode.None))
					{
						m_securityMode = endpoint.SecurityMode;
						m_securityPolicyUri = securityPolicyUri;
						m_discoveryOnly = false;
						m_uninitialized = false;
						m_selectedEndpoint = endpoint;
						CalculateSymmetricKeySizes();
						break;
					}
				}
			}
			if (m_uninitialized)
			{
				if (securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
				{
					throw ServiceResultException.Create(2153054208u, "The security policy is not supported.");
				}
				m_securityMode = MessageSecurityMode.None;
				m_securityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None";
				m_discoveryOnly = true;
				m_uninitialized = false;
				m_selectedEndpoint = null;
			}
		}
		int position = binaryDecoder.Position;
		ArraySegment<byte> arraySegment = Decrypt(new ArraySegment<byte>(buffer.Array, buffer.Offset + position, buffer.Count - position), new ArraySegment<byte>(buffer.Array, buffer.Offset, position), receiverCertificate);
		int asymmetricSignatureSize = GetAsymmetricSignatureSize(senderCertificate);
		byte[] array = new byte[asymmetricSignatureSize];
		for (int i = 0; i < asymmetricSignatureSize; i++)
		{
			array[i] = arraySegment.Array[arraySegment.Offset + arraySegment.Count - asymmetricSignatureSize + i];
		}
		ArraySegment<byte> dataToVerify = new ArraySegment<byte>(arraySegment.Array, arraySegment.Offset, arraySegment.Count - asymmetricSignatureSize);
		if (!Verify(dataToVerify, array, senderCertificate))
		{
			Utils.LogWarning("Could not verify signature on message.");
			throw ServiceResultException.Create(2148728832u, "Could not verify the signature on the message.");
		}
		int num = 0;
		if (SecurityMode != MessageSecurityMode.None)
		{
			int num2 = -1;
			if (X509Utils.GetRSAPublicKeySize(receiverCertificate) > 2048)
			{
				num2 = arraySegment.Offset + arraySegment.Count - asymmetricSignatureSize - 1;
				num = arraySegment.Array[num2 - 1] + arraySegment.Array[num2] * 256;
				for (int j = num2 - num; j < num2; j++)
				{
					if (arraySegment.Array[j] != arraySegment.Array[num2 - 1])
					{
						throw ServiceResultException.Create(2148728832u, "Could not verify the padding in the message.");
					}
				}
			}
			else
			{
				num2 = arraySegment.Offset + arraySegment.Count - asymmetricSignatureSize - 1;
				num = arraySegment.Array[num2];
				for (int k = num2 - num; k < num2; k++)
				{
					if (arraySegment.Array[k] != arraySegment.Array[num2])
					{
						throw ServiceResultException.Create(2148728832u, "Could not verify the padding in the message.");
					}
				}
			}
			num++;
		}
		binaryDecoder = new BinaryDecoder(arraySegment.Array, arraySegment.Offset + position, arraySegment.Count - position, Quotas.MessageContext);
		sequenceNumber = binaryDecoder.ReadUInt32(null);
		requestId = binaryDecoder.ReadUInt32(null);
		position += binaryDecoder.Position;
		binaryDecoder.Close();
		Utils.LogInfo("Security Policy: {0}", SecurityPolicyUri);
		Utils.LogCertificate("Sender Certificate:", senderCertificate);
		return new ArraySegment<byte>(arraySegment.Array, arraySegment.Offset + position, arraySegment.Count - position - asymmetricSignatureSize - num);
	}

	protected byte[] Sign(ArraySegment<byte> dataToSign, X509Certificate2 senderCertificate)
	{
		switch (SecurityPolicyUri)
		{
		default:
			return null;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			return Rsa_Sign(dataToSign, senderCertificate, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
			return Rsa_Sign(dataToSign, senderCertificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return Rsa_Sign(dataToSign, senderCertificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
		}
	}

	protected bool Verify(ArraySegment<byte> dataToVerify, byte[] signature, X509Certificate2 senderCertificate)
	{
		switch (SecurityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#None":
			return true;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
			return Rsa_Verify(dataToVerify, signature, senderCertificate, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
			return Rsa_Verify(dataToVerify, signature, senderCertificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return Rsa_Verify(dataToVerify, signature, senderCertificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
		default:
			return false;
		}
	}

	protected ArraySegment<byte> Encrypt(ArraySegment<byte> dataToEncrypt, ArraySegment<byte> headerToCopy, X509Certificate2 receiverCertificate)
	{
		switch (SecurityPolicyUri)
		{
		default:
		{
			byte[] array = BufferManager.TakeBuffer(SendBufferSize, "Encrypt");
			Array.Copy(headerToCopy.Array, headerToCopy.Offset, array, 0, headerToCopy.Count);
			Array.Copy(dataToEncrypt.Array, dataToEncrypt.Offset, array, headerToCopy.Count, dataToEncrypt.Count);
			return new ArraySegment<byte>(array, 0, dataToEncrypt.Count + headerToCopy.Count);
		}
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
			return Rsa_Encrypt(dataToEncrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.OaepSHA1);
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return Rsa_Encrypt(dataToEncrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.OaepSHA256);
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			return Rsa_Encrypt(dataToEncrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.Pkcs1);
		}
	}

	protected ArraySegment<byte> Decrypt(ArraySegment<byte> dataToDecrypt, ArraySegment<byte> headerToCopy, X509Certificate2 receiverCertificate)
	{
		switch (SecurityPolicyUri)
		{
		default:
		{
			byte[] array = BufferManager.TakeBuffer(SendBufferSize, "Decrypt");
			Array.Copy(headerToCopy.Array, headerToCopy.Offset, array, 0, headerToCopy.Count);
			Array.Copy(dataToDecrypt.Array, dataToDecrypt.Offset, array, headerToCopy.Count, dataToDecrypt.Count);
			return new ArraySegment<byte>(array, 0, dataToDecrypt.Count + headerToCopy.Count);
		}
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
			return Rsa_Decrypt(dataToDecrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.OaepSHA1);
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return Rsa_Decrypt(dataToDecrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.OaepSHA256);
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			return Rsa_Decrypt(dataToDecrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.Pkcs1);
		}
	}

	public UaSCUaBinaryChannel(string contextId, BufferManager bufferManager, ChannelQuotas quotas, X509Certificate2 serverCertificate, EndpointDescriptionCollection endpoints, MessageSecurityMode securityMode, string securityPolicyUri)
		: this(contextId, bufferManager, quotas, serverCertificate, null, endpoints, securityMode, securityPolicyUri)
	{
	}

	public UaSCUaBinaryChannel(string contextId, BufferManager bufferManager, ChannelQuotas quotas, X509Certificate2 serverCertificate, X509Certificate2Collection serverCertificateChain, EndpointDescriptionCollection endpoints, MessageSecurityMode securityMode, string securityPolicyUri)
	{
		if (bufferManager == null)
		{
			throw new ArgumentNullException("bufferManager");
		}
		if (quotas == null)
		{
			throw new ArgumentNullException("quotas");
		}
		m_contextId = contextId;
		if (string.IsNullOrEmpty(m_contextId))
		{
			m_contextId = Guid.NewGuid().ToString();
		}
		if (securityMode == MessageSecurityMode.None)
		{
			securityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None";
		}
		if (securityMode != MessageSecurityMode.None)
		{
			if (serverCertificate == null)
			{
				throw new ArgumentNullException("serverCertificate");
			}
			if (serverCertificate.RawData.Length > 7500)
			{
				throw new ArgumentException(Utils.Format("The DER encoded certificate may not be more than {0} bytes.", 7500), "serverCertificate");
			}
		}
		if (Encoding.UTF8.GetByteCount(securityPolicyUri) > 256)
		{
			throw new ArgumentException(Utils.Format("UTF-8 form of the security policy URI may not be more than {0} bytes.", 256), "securityPolicyUri");
		}
		m_bufferManager = bufferManager;
		m_quotas = quotas;
		m_serverCertificate = serverCertificate;
		m_serverCertificateChain = serverCertificateChain;
		m_endpoints = endpoints;
		m_securityMode = securityMode;
		m_securityPolicyUri = securityPolicyUri;
		m_discoveryOnly = false;
		m_uninitialized = true;
		m_state = TcpChannelState.Closed;
		m_receiveBufferSize = quotas.MaxBufferSize;
		m_sendBufferSize = quotas.MaxBufferSize;
		m_activeWriteRequests = 0;
		if (m_receiveBufferSize < 8192)
		{
			m_receiveBufferSize = 8192;
		}
		if (m_receiveBufferSize > 147456)
		{
			m_receiveBufferSize = 147456;
		}
		if (m_sendBufferSize < 8192)
		{
			m_sendBufferSize = 8192;
		}
		if (m_sendBufferSize > 147456)
		{
			m_sendBufferSize = 147456;
		}
		m_maxRequestMessageSize = quotas.MaxMessageSize;
		m_maxResponseMessageSize = quotas.MaxMessageSize;
		m_maxRequestChunkCount = CalculateChunkCount(m_maxRequestMessageSize, 8192);
		m_maxResponseChunkCount = CalculateChunkCount(m_maxResponseMessageSize, 8192);
		CalculateSymmetricKeySizes();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public void SetStateChangedCallback(TcpChannelStateEventHandler callback)
	{
		lock (m_lock)
		{
			m_StateChanged = callback;
		}
	}

	protected void ChannelStateChanged(TcpChannelState state, ServiceResult reason)
	{
		if (m_StateChanged != null)
		{
			Task.Run(delegate
			{
				m_StateChanged?.Invoke(this, state, reason);
			});
		}
	}

	protected uint GetNewSequenceNumber()
	{
		return Utils.IncrementIdentifier(ref m_sequenceNumber);
	}

	protected void ResetSequenceNumber(uint sequenceNumber)
	{
		m_remoteSequenceNumber = sequenceNumber;
	}

	protected bool VerifySequenceNumber(uint sequenceNumber, string context)
	{
		if (sequenceNumber > m_remoteSequenceNumber)
		{
			m_remoteSequenceNumber = sequenceNumber;
			return true;
		}
		if (m_remoteSequenceNumber > 4294966271u && sequenceNumber < 1024 && !m_sequenceRollover)
		{
			m_sequenceRollover = true;
			m_remoteSequenceNumber = sequenceNumber;
			return true;
		}
		Utils.LogError("ChannelId {0}: {1} - Duplicate sequence number: {2} <= {3}", ChannelId, context, sequenceNumber, m_remoteSequenceNumber);
		return false;
	}

	protected bool SaveIntermediateChunk(uint requestId, ArraySegment<byte> chunk, bool isServerContext)
	{
		bool result = false;
		if (m_partialMessageChunks == null)
		{
			result = true;
			m_partialMessageChunks = new BufferCollection();
		}
		bool flag = MessageLimitsExceeded(isServerContext, m_partialMessageChunks.TotalSize, m_partialMessageChunks.Count);
		if (m_partialRequestId != requestId || flag)
		{
			if (m_partialMessageChunks.Count > 0)
			{
				Utils.LogWarning("WARNING - Discarding unprocessed message chunks for Request #{0}", m_partialRequestId);
			}
			m_partialMessageChunks.Release(BufferManager, "SaveIntermediateChunk");
		}
		if (flag)
		{
			DoMessageLimitsExceeded();
			return result;
		}
		if (requestId != 0)
		{
			m_partialRequestId = requestId;
			m_partialMessageChunks.Add(chunk);
		}
		return result;
	}

	protected BufferCollection GetSavedChunks(uint requestId, ArraySegment<byte> chunk, bool isServerContext)
	{
		SaveIntermediateChunk(requestId, chunk, isServerContext);
		BufferCollection partialMessageChunks = m_partialMessageChunks;
		m_partialMessageChunks = null;
		return partialMessageChunks;
	}

	protected int GetSavedChunksTotalSize()
	{
		if (m_partialMessageChunks != null)
		{
			return m_partialMessageChunks.TotalSize;
		}
		return 0;
	}

	protected virtual void DoMessageLimitsExceeded()
	{
		Utils.LogError("ChannelId {0}: - Message limits exceeded while building up message. Channel will be closed.", ChannelId);
	}

	public virtual void OnMessageReceived(IMessageSocket source, ArraySegment<byte> message)
	{
		lock (DataLock)
		{
			try
			{
				uint messageType = BitConverter.ToUInt32(message.Array, message.Offset);
				if (!HandleIncomingMessage(messageType, message))
				{
					BufferManager.ReturnBuffer(message.Array, "OnMessageReceived");
				}
			}
			catch (Exception e)
			{
				HandleMessageProcessingError(e, 2156003328u, "An error occurred receiving a message.");
				BufferManager.ReturnBuffer(message.Array, "OnMessageReceived");
			}
		}
	}

	protected virtual bool HandleIncomingMessage(uint messageType, ArraySegment<byte> messageChunk)
	{
		return false;
	}

	protected void HandleMessageProcessingError(Exception e, uint defaultCode, string format, params object[] args)
	{
		HandleMessageProcessingError(ServiceResult.Create(e, defaultCode, format, args));
	}

	protected void HandleMessageProcessingError(uint statusCode, string format, params object[] args)
	{
		HandleMessageProcessingError(ServiceResult.Create(statusCode, format, args));
	}

	protected virtual void HandleMessageProcessingError(ServiceResult result)
	{
	}

	public virtual void OnReceiveError(IMessageSocket source, ServiceResult result)
	{
		lock (DataLock)
		{
			HandleSocketError(result);
		}
	}

	protected virtual void HandleSocketError(ServiceResult result)
	{
	}

	protected virtual void OnWriteComplete(object sender, IMessageSocketAsyncEventArgs e)
	{
		ServiceResult result = ServiceResult.Good;
		try
		{
			if (e.BytesTransferred == 0)
			{
				result = ServiceResult.Create(2158886912u, "The socket was closed by the remote application.");
			}
			if (e.Buffer != null)
			{
				BufferManager.ReturnBuffer(e.Buffer, "OnWriteComplete");
			}
			HandleWriteComplete(e.BufferList, e.UserToken, e.BytesTransferred, result);
		}
		catch (Exception ex)
		{
			if (ex is InvalidOperationException)
			{
				e.BufferList = null;
			}
			result = ServiceResult.Create(ex, 2156003328u, "Unexpected error during write operation.");
			HandleWriteComplete(e.BufferList, e.UserToken, e.BytesTransferred, result);
		}
		e.Dispose();
	}

	protected void BeginWriteMessage(ArraySegment<byte> buffer, object state)
	{
		ServiceResult good = ServiceResult.Good;
		IMessageSocketAsyncEventArgs e = m_socket.MessageSocketEventArgs();
		try
		{
			Interlocked.Increment(ref m_activeWriteRequests);
			e.SetBuffer(buffer.Array, buffer.Offset, buffer.Count);
			e.Completed += OnWriteComplete;
			e.UserToken = state;
			if (!m_socket.SendAsync(e))
			{
				if (e.IsSocketError || e.BytesTransferred < buffer.Count)
				{
					good = ServiceResult.Create(2158886912u, e.SocketErrorString);
					HandleWriteComplete(null, state, e.BytesTransferred, good);
					e.Dispose();
				}
				else
				{
					OnWriteComplete(null, e);
				}
			}
		}
		catch (Exception e2)
		{
			good = ServiceResult.Create(e2, 2156003328u, "Unexpected error during write operation.");
			HandleWriteComplete(null, state, e.BytesTransferred, good);
			e.Dispose();
		}
	}

	protected void BeginWriteMessage(BufferCollection buffers, object state)
	{
		ServiceResult good = ServiceResult.Good;
		IMessageSocketAsyncEventArgs e = m_socket.MessageSocketEventArgs();
		try
		{
			Interlocked.Increment(ref m_activeWriteRequests);
			e.BufferList = buffers;
			e.Completed += OnWriteComplete;
			e.UserToken = state;
			if (m_socket == null || !m_socket.SendAsync(e))
			{
				if (e.IsSocketError || e.BytesTransferred < buffers.TotalSize)
				{
					good = ServiceResult.Create(2158886912u, e.SocketErrorString);
					HandleWriteComplete(buffers, state, e.BytesTransferred, good);
					e.Dispose();
				}
				else
				{
					OnWriteComplete(null, e);
				}
			}
		}
		catch (Exception e2)
		{
			good = ServiceResult.Create(e2, 2156003328u, "Unexpected error during write operation.");
			HandleWriteComplete(buffers, state, e.BytesTransferred, good);
			e.Dispose();
		}
	}

	protected virtual void HandleWriteComplete(BufferCollection buffers, object state, int bytesWritten, ServiceResult result)
	{
		buffers?.Release(BufferManager, "WriteOperation");
		Interlocked.Decrement(ref m_activeWriteRequests);
	}

	protected static void WriteErrorMessageBody(BinaryEncoder encoder, ServiceResult error)
	{
		string text = ((error.LocalizedText != null) ? error.LocalizedText.Text : null);
		if (text != null && Encoding.UTF8.GetByteCount(text) > 4096)
		{
			text = text.Substring(0, 4096 / Encoding.UTF8.GetMaxByteCount(1));
		}
		encoder.WriteStatusCode(null, error.StatusCode);
		encoder.WriteString(null, text);
	}

	protected static ServiceResult ReadErrorMessageBody(BinaryDecoder decoder)
	{
		uint code = decoder.ReadUInt32(null);
		string text = null;
		int num = decoder.ReadInt32(null);
		if (num > 0 && num < 4096)
		{
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = decoder.ReadByte(null);
			}
			text = Encoding.UTF8.GetString(array, 0, num);
		}
		if (text == null)
		{
			text = new ServiceResult(code).ToString();
		}
		return ServiceResult.Create(code, "Error received from remote host: {0}", text);
	}

	protected bool MessageLimitsExceeded(bool isRequest, int messageSize, int chunkCount)
	{
		if (isRequest)
		{
			if (MaxRequestChunkCount > 0 && MaxRequestChunkCount < chunkCount)
			{
				return true;
			}
			if (MaxRequestMessageSize > 0 && MaxRequestMessageSize < messageSize)
			{
				return true;
			}
		}
		else
		{
			if (MaxResponseChunkCount > 0 && MaxResponseChunkCount < chunkCount)
			{
				return true;
			}
			if (MaxResponseMessageSize > 0 && MaxResponseMessageSize < messageSize)
			{
				return true;
			}
		}
		return false;
	}

	protected static void UpdateMessageType(byte[] buffer, int offset, uint messageType)
	{
		buffer[offset++] = (byte)(messageType & 0xFF);
		buffer[offset++] = (byte)((messageType & 0xFF00) >> 8);
		buffer[offset++] = (byte)((messageType & 0xFF0000) >> 16);
		buffer[offset] = (byte)((messageType & 0xFF000000u) >> 24);
	}

	protected static void UpdateMessageSize(byte[] buffer, int offset, int messageSize)
	{
		if (offset >= 2147483643)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		offset += 4;
		buffer[offset++] = (byte)(messageSize & 0xFF);
		buffer[offset++] = (byte)((messageSize & 0xFF00) >> 8);
		buffer[offset++] = (byte)((messageSize & 0xFF0000) >> 16);
		buffer[offset] = (byte)((messageSize & 0xFF000000u) >> 24);
	}

	protected static int CalculateChunkCount(int messageSize, int bufferSize)
	{
		if (bufferSize > 0)
		{
			int num = messageSize / bufferSize;
			if (num * bufferSize < messageSize)
			{
				num++;
			}
			return num;
		}
		return 1;
	}

	private static byte[] Rsa_Sign(ArraySegment<byte> dataToSign, X509Certificate2 signingCertificate, HashAlgorithmName algorithm, RSASignaturePadding padding)
	{
		using RSA rSA = signingCertificate.GetRSAPrivateKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No private key for certificate.");
		}
		return rSA.SignData(dataToSign.Array, dataToSign.Offset, dataToSign.Count, algorithm, padding);
	}

	private static bool Rsa_Verify(ArraySegment<byte> dataToVerify, byte[] signature, X509Certificate2 signingCertificate, HashAlgorithmName algorithm, RSASignaturePadding padding)
	{
		using RSA rSA = signingCertificate.GetRSAPublicKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No public key for certificate.");
		}
		if (!rSA.VerifyData(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, signature, algorithm, padding))
		{
			string text = Encoding.UTF8.GetString(dataToVerify.Array, dataToVerify.Offset, 4);
			int num = BitConverter.ToInt32(dataToVerify.Array, dataToVerify.Offset + 4);
			string text2 = Utils.ToHexString(signature);
			Utils.LogError("Could not validate signature.");
			Utils.LogCertificate(LogLevel.Error, "Certificate: ", signingCertificate);
			Utils.LogError("MessageType ={0}, Length ={1}, ActualSignature={2}", text, num, text2);
			return false;
		}
		return true;
	}

	private ArraySegment<byte> Rsa_Encrypt(ArraySegment<byte> dataToEncrypt, ArraySegment<byte> headerToCopy, X509Certificate2 encryptingCertificate, RsaUtils.Padding padding)
	{
		using RSA rSA = encryptingCertificate.GetRSAPublicKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No public key for certificate.");
		}
		int plainTextBlockSize = RsaUtils.GetPlainTextBlockSize(rSA, padding);
		int cipherTextBlockSize = RsaUtils.GetCipherTextBlockSize(rSA, padding);
		if (dataToEncrypt.Count % plainTextBlockSize != 0)
		{
			Utils.LogWarning("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", dataToEncrypt.Count, plainTextBlockSize);
		}
		byte[] array = BufferManager.TakeBuffer(SendBufferSize, "Rsa_Encrypt");
		Array.Copy(headerToCopy.Array, headerToCopy.Offset, array, 0, headerToCopy.Count);
		RSAEncryptionPadding rSAEncryptionPadding = RsaUtils.GetRSAEncryptionPadding(padding);
		using (MemoryStream memoryStream = new MemoryStream(array, headerToCopy.Count, array.Length - headerToCopy.Count))
		{
			byte[] array2 = new byte[plainTextBlockSize];
			for (int i = dataToEncrypt.Offset; i < dataToEncrypt.Offset + dataToEncrypt.Count; i += plainTextBlockSize)
			{
				Array.Copy(dataToEncrypt.Array, i, array2, 0, array2.Length);
				byte[] array3 = rSA.Encrypt(array2, rSAEncryptionPadding);
				memoryStream.Write(array3, 0, array3.Length);
			}
		}
		return new ArraySegment<byte>(array, 0, dataToEncrypt.Count / plainTextBlockSize * cipherTextBlockSize + headerToCopy.Count);
	}

	private ArraySegment<byte> Rsa_Decrypt(ArraySegment<byte> dataToDecrypt, ArraySegment<byte> headerToCopy, X509Certificate2 encryptingCertificate, RsaUtils.Padding padding)
	{
		using RSA rSA = encryptingCertificate.GetRSAPrivateKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No private key for certificate.");
		}
		int cipherTextBlockSize = RsaUtils.GetCipherTextBlockSize(rSA, padding);
		int plainTextBlockSize = RsaUtils.GetPlainTextBlockSize(rSA, padding);
		if (dataToDecrypt.Count % cipherTextBlockSize != 0)
		{
			Utils.LogWarning("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", dataToDecrypt.Count, cipherTextBlockSize);
		}
		byte[] array = BufferManager.TakeBuffer(SendBufferSize, "Rsa_Decrypt");
		Array.Copy(headerToCopy.Array, headerToCopy.Offset, array, 0, headerToCopy.Count);
		RSAEncryptionPadding rSAEncryptionPadding = RsaUtils.GetRSAEncryptionPadding(padding);
		using (MemoryStream memoryStream = new MemoryStream(array, headerToCopy.Count, array.Length - headerToCopy.Count))
		{
			byte[] array2 = new byte[cipherTextBlockSize];
			for (int i = dataToDecrypt.Offset; i < dataToDecrypt.Offset + dataToDecrypt.Count; i += cipherTextBlockSize)
			{
				Array.Copy(dataToDecrypt.Array, i, array2, 0, array2.Length);
				byte[] array3 = rSA.Decrypt(array2, rSAEncryptionPadding);
				memoryStream.Write(array3, 0, array3.Length);
			}
		}
		return new ArraySegment<byte>(array, 0, dataToDecrypt.Count / cipherTextBlockSize * plainTextBlockSize + headerToCopy.Count);
	}

	protected ChannelToken CreateToken()
	{
		ChannelToken channelToken = new ChannelToken();
		channelToken.ChannelId = m_channelId;
		channelToken.TokenId = 0u;
		channelToken.CreatedAt = DateTime.UtcNow;
		channelToken.Lifetime = Quotas.SecurityTokenLifetime;
		Utils.LogInfo("ChannelId {0}: Token #{1} created. CreatedAt={2:HH:mm:ss.fff}. Lifetime={3}.", Id, channelToken.TokenId, channelToken.CreatedAt, channelToken.Lifetime);
		return channelToken;
	}

	protected void ActivateToken(ChannelToken token)
	{
		ComputeKeys(token);
		m_previousToken = m_currentToken;
		m_currentToken = token;
		m_renewedToken = null;
		Utils.LogInfo("ChannelId {0}: Token #{1} activated. CreatedAt={2:HH:mm:ss.fff}. Lifetime={3}.", Id, token.TokenId, token.CreatedAt, token.Lifetime);
	}

	protected void SetRenewedToken(ChannelToken token)
	{
		m_renewedToken = token;
		Utils.LogInfo("ChannelId {0}: Renewed Token #{1} set. CreatedAt={2:HH:mm:ss.fff}. Lifetime ={3}.", Id, token.TokenId, token.CreatedAt, token.Lifetime);
	}

	protected void DiscardTokens()
	{
		m_previousToken = null;
		m_currentToken = null;
	}

	protected void CalculateSymmetricKeySizes()
	{
		switch (SecurityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			m_hmacHashSize = 20;
			m_signatureKeySize = 16;
			m_encryptionKeySize = 16;
			m_encryptionBlockSize = 16;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
			m_hmacHashSize = 20;
			m_signatureKeySize = 24;
			m_encryptionKeySize = 32;
			m_encryptionBlockSize = 16;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
			m_hmacHashSize = 32;
			m_signatureKeySize = 32;
			m_encryptionKeySize = 32;
			m_encryptionBlockSize = 16;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
			m_hmacHashSize = 32;
			m_signatureKeySize = 32;
			m_encryptionKeySize = 16;
			m_encryptionBlockSize = 16;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			m_hmacHashSize = 32;
			m_signatureKeySize = 32;
			m_encryptionKeySize = 32;
			m_encryptionBlockSize = 16;
			break;
		default:
			m_hmacHashSize = 0;
			m_signatureKeySize = 0;
			m_encryptionKeySize = 0;
			m_encryptionBlockSize = 1;
			break;
		}
	}

	protected void ComputeKeys(ChannelToken token)
	{
		if (SecurityMode == MessageSecurityMode.None)
		{
			return;
		}
		if (SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256" || SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep" || SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss")
		{
			token.ClientSigningKey = Utils.PSHA256(token.ServerNonce, null, token.ClientNonce, 0, m_signatureKeySize);
			token.ClientEncryptingKey = Utils.PSHA256(token.ServerNonce, null, token.ClientNonce, m_signatureKeySize, m_encryptionKeySize);
			token.ClientInitializationVector = Utils.PSHA256(token.ServerNonce, null, token.ClientNonce, m_signatureKeySize + m_encryptionKeySize, m_encryptionBlockSize);
			token.ServerSigningKey = Utils.PSHA256(token.ClientNonce, null, token.ServerNonce, 0, m_signatureKeySize);
			token.ServerEncryptingKey = Utils.PSHA256(token.ClientNonce, null, token.ServerNonce, m_signatureKeySize, m_encryptionKeySize);
			token.ServerInitializationVector = Utils.PSHA256(token.ClientNonce, null, token.ServerNonce, m_signatureKeySize + m_encryptionKeySize, m_encryptionBlockSize);
		}
		else
		{
			token.ClientSigningKey = Utils.PSHA1(token.ServerNonce, null, token.ClientNonce, 0, m_signatureKeySize);
			token.ClientEncryptingKey = Utils.PSHA1(token.ServerNonce, null, token.ClientNonce, m_signatureKeySize, m_encryptionKeySize);
			token.ClientInitializationVector = Utils.PSHA1(token.ServerNonce, null, token.ClientNonce, m_signatureKeySize + m_encryptionKeySize, m_encryptionBlockSize);
			token.ServerSigningKey = Utils.PSHA1(token.ClientNonce, null, token.ServerNonce, 0, m_signatureKeySize);
			token.ServerEncryptingKey = Utils.PSHA1(token.ClientNonce, null, token.ServerNonce, m_signatureKeySize, m_encryptionKeySize);
			token.ServerInitializationVector = Utils.PSHA1(token.ClientNonce, null, token.ServerNonce, m_signatureKeySize + m_encryptionKeySize, m_encryptionBlockSize);
		}
		string securityPolicyUri = SecurityPolicyUri;
		switch (securityPolicyUri)
		{
		default:
			_ = securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None";
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
		{
			SymmetricAlgorithm symmetricAlgorithm = Aes.Create();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			symmetricAlgorithm.Padding = PaddingMode.None;
			symmetricAlgorithm.Key = token.ClientEncryptingKey;
			symmetricAlgorithm.IV = token.ClientInitializationVector;
			token.ClientEncryptor = symmetricAlgorithm;
			SymmetricAlgorithm symmetricAlgorithm2 = Aes.Create();
			symmetricAlgorithm2.Mode = CipherMode.CBC;
			symmetricAlgorithm2.Padding = PaddingMode.None;
			symmetricAlgorithm2.Key = token.ServerEncryptingKey;
			symmetricAlgorithm2.IV = token.ServerInitializationVector;
			token.ServerEncryptor = symmetricAlgorithm2;
			if (SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256" || SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep" || SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss")
			{
				token.ServerHmac = new HMACSHA256(token.ServerSigningKey);
				token.ClientHmac = new HMACSHA256(token.ClientSigningKey);
			}
			else
			{
				token.ServerHmac = new HMACSHA1(token.ServerSigningKey);
				token.ClientHmac = new HMACSHA1(token.ClientSigningKey);
			}
			break;
		}
		}
	}

	protected BufferCollection WriteSymmetricMessage(uint messageType, uint requestId, ChannelToken token, object messageBody, bool isRequest, out bool limitsExceeded)
	{
		limitsExceeded = false;
		bool flag = false;
		BufferCollection bufferCollection = null;
		try
		{
			int count = (SendBufferSize - 16) / EncryptionBlockSize * EncryptionBlockSize - SymmetricSignatureSize - 1 - 8;
			int num = 24;
			ArraySegmentStream arraySegmentStream = new ArraySegmentStream(BufferManager, SendBufferSize, num, count);
			if (messageBody is IEncodeable message)
			{
				BinaryEncoder.EncodeMessage(message, arraySegmentStream, Quotas.MessageContext, leaveOpen: true);
			}
			ArraySegment<byte>? arraySegment = messageBody as ArraySegment<byte>?;
			if (arraySegment.HasValue)
			{
				using BinaryEncoder binaryEncoder = new BinaryEncoder(arraySegmentStream, Quotas.MessageContext, leaveOpen: true);
				binaryEncoder.WriteRawBytes(arraySegment.Value.Array, arraySegment.Value.Offset, arraySegment.Value.Count);
			}
			bufferCollection = arraySegmentStream.GetBuffers("WriteSymmetricMessage");
			if (bufferCollection.Count == 0)
			{
				byte[] array = BufferManager.TakeBuffer(SendBufferSize, "WriteSymmetricMessage");
				bufferCollection.Add(new ArraySegment<byte>(array, 0, 0));
			}
			BufferCollection bufferCollection2 = new BufferCollection(bufferCollection.Capacity);
			int num2 = 0;
			for (int i = 0; i < bufferCollection.Count; i++)
			{
				ArraySegment<byte> arraySegment2 = bufferCollection[i];
				if (limitsExceeded)
				{
					BufferManager.ReturnBuffer(arraySegment2.Array, "WriteSymmetricMessage");
					continue;
				}
				MemoryStream memoryStream = new MemoryStream(arraySegment2.Array, 0, SendBufferSize);
				BinaryEncoder binaryEncoder2 = new BinaryEncoder(memoryStream, Quotas.MessageContext, leaveOpen: false);
				try
				{
					if (MessageLimitsExceeded(isRequest, num2 + arraySegment2.Count - num, i + 1))
					{
						binaryEncoder2.WriteUInt32(null, messageType | 0x41000000);
						BinaryEncoder binaryEncoder3 = new BinaryEncoder(arraySegment2.Array, arraySegment2.Offset, arraySegment2.Count, Quotas.MessageContext);
						WriteErrorMessageBody(binaryEncoder3, isRequest ? 2159542272u : 2159607808u);
						int count2 = binaryEncoder3.Close();
						binaryEncoder3.Dispose();
						arraySegment2 = new ArraySegment<byte>(arraySegment2.Array, arraySegment2.Offset, count2);
						limitsExceeded = true;
					}
					else if (i == bufferCollection.Count - 1)
					{
						binaryEncoder2.WriteUInt32(null, messageType | 0x46000000);
					}
					else
					{
						binaryEncoder2.WriteUInt32(null, messageType | 0x43000000);
					}
					int num3 = 0;
					num3 += 8;
					num3 += arraySegment2.Count;
					num3 += SymmetricSignatureSize;
					int num4 = 0;
					if (SecurityMode == MessageSecurityMode.SignAndEncrypt)
					{
						num3++;
						if (num3 % EncryptionBlockSize != 0)
						{
							num4 = EncryptionBlockSize - num3 % EncryptionBlockSize;
						}
						num3 += num4;
					}
					num3 += 16;
					binaryEncoder2.WriteUInt32(null, (uint)num3);
					binaryEncoder2.WriteUInt32(null, ChannelId);
					binaryEncoder2.WriteUInt32(null, token.TokenId);
					uint newSequenceNumber = GetNewSequenceNumber();
					binaryEncoder2.WriteUInt32(null, newSequenceNumber);
					binaryEncoder2.WriteUInt32(null, requestId);
					memoryStream.Seek(arraySegment2.Count, SeekOrigin.Current);
					num2 += arraySegment2.Count;
					if (SecurityMode == MessageSecurityMode.SignAndEncrypt)
					{
						for (int j = 0; j <= num4; j++)
						{
							binaryEncoder2.WriteByte(null, (byte)num4);
						}
					}
					if (SecurityMode != MessageSecurityMode.None)
					{
						byte[] array2 = Sign(token, new ArraySegment<byte>(arraySegment2.Array, 0, binaryEncoder2.Position), isRequest);
						if (array2 != null)
						{
							binaryEncoder2.WriteRawBytes(array2, 0, array2.Length);
						}
					}
					if (SecurityMode == MessageSecurityMode.SignAndEncrypt)
					{
						ArraySegment<byte> dataToEncrypt = new ArraySegment<byte>(arraySegment2.Array, 16, binaryEncoder2.Position - 16);
						Encrypt(token, dataToEncrypt, isRequest);
					}
					bufferCollection2.Add(new ArraySegment<byte>(arraySegment2.Array, 0, binaryEncoder2.Position));
				}
				finally
				{
					binaryEncoder2.Dispose();
				}
			}
			flag = true;
			return bufferCollection2;
		}
		finally
		{
			if (!flag)
			{
				bufferCollection?.Release(BufferManager, "WriteSymmetricMessage");
			}
		}
	}

	protected ArraySegment<byte> ReadSymmetricMessage(ArraySegment<byte> buffer, bool isRequest, out ChannelToken token, out uint requestId, out uint sequenceNumber)
	{
		BinaryDecoder binaryDecoder = new BinaryDecoder(buffer.Array, buffer.Offset, buffer.Count, Quotas.MessageContext);
		binaryDecoder.ReadUInt32(null);
		binaryDecoder.ReadUInt32(null);
		uint num = binaryDecoder.ReadUInt32(null);
		uint num2 = binaryDecoder.ReadUInt32(null);
		if (num != ChannelId)
		{
			throw ServiceResultException.Create(2155806720u, "SecureChannelId is not known. ChanneId={0}, CurrentChannelId={1}", num, ChannelId);
		}
		if (RenewedToken != null && RenewedToken.TokenId == num2)
		{
			ActivateToken(RenewedToken);
		}
		if (RenewedToken != null && CurrentToken.ActivationRequired)
		{
			ActivateToken(RenewedToken);
			Utils.LogInfo("ChannelId {0}: Token #{1} activated forced.", Id, CurrentToken.TokenId);
		}
		ChannelToken currentToken = CurrentToken;
		if (currentToken == null)
		{
			throw new ServiceResultException(2156265472u);
		}
		if (currentToken.TokenId != num2 && PreviousToken != null && PreviousToken.TokenId != num2)
		{
			throw ServiceResultException.Create(2155806720u, "Channel{0}: TokenId is not known. ChanneId={1}, TokenId={2}, CurrentTokenId={3}, PreviousTokenId={4}", Id, num, num2, currentToken.TokenId, (PreviousToken != null) ? ((int)PreviousToken.TokenId) : (-1));
		}
		token = currentToken;
		if (PreviousToken != null && PreviousToken.TokenId == num2)
		{
			token = PreviousToken;
		}
		if (token.Expired)
		{
			throw ServiceResultException.Create(2155806720u, "Channel{0}: Token #{1} has expired. Lifetime={2:HH:mm:ss.fff}", Id, token.TokenId, token.CreatedAt);
		}
		int position = binaryDecoder.Position;
		if (SecurityMode == MessageSecurityMode.SignAndEncrypt)
		{
			Decrypt(token, new ArraySegment<byte>(buffer.Array, buffer.Offset + position, buffer.Count - position), isRequest);
		}
		if (SecurityMode != MessageSecurityMode.None)
		{
			byte[] array = new byte[SymmetricSignatureSize];
			for (int i = 0; i < SymmetricSignatureSize; i++)
			{
				array[i] = buffer.Array[buffer.Offset + buffer.Count - SymmetricSignatureSize + i];
			}
			if (!Verify(token, array, new ArraySegment<byte>(buffer.Array, buffer.Offset, buffer.Count - SymmetricSignatureSize), isRequest))
			{
				Utils.LogError("ChannelId {0}: Could not verify signature on message.", Id);
				throw ServiceResultException.Create(2148728832u, "Could not verify the signature on the message.");
			}
		}
		int num3 = 0;
		if (SecurityMode == MessageSecurityMode.SignAndEncrypt)
		{
			int num4 = buffer.Offset + buffer.Count - SymmetricSignatureSize - 1;
			num3 = buffer.Array[num4];
			for (int j = num4 - num3; j < num4; j++)
			{
				if (buffer.Array[j] != num3)
				{
					throw ServiceResultException.Create(2148728832u, "Could not verify the padding in the message.");
				}
			}
			num3++;
		}
		sequenceNumber = binaryDecoder.ReadUInt32(null);
		requestId = binaryDecoder.ReadUInt32(null);
		int offset = buffer.Offset + 16 + 8;
		int count = buffer.Count - 16 - 8 - num3 - SymmetricSignatureSize;
		return new ArraySegment<byte>(buffer.Array, offset, count);
	}

	protected byte[] Sign(ChannelToken token, ArraySegment<byte> dataToSign, bool useClientKeys)
	{
		switch (SecurityPolicyUri)
		{
		default:
			return null;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return SymmetricSign(token, dataToSign, useClientKeys);
		}
	}

	protected bool Verify(ChannelToken token, byte[] signature, ArraySegment<byte> dataToVerify, bool useClientKeys)
	{
		switch (SecurityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#None":
			return true;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			return SymmetricVerify(token, signature, dataToVerify, useClientKeys);
		default:
			return false;
		}
	}

	protected void Encrypt(ChannelToken token, ArraySegment<byte> dataToEncrypt, bool useClientKeys)
	{
		switch (SecurityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			SymmetricEncrypt(token, dataToEncrypt, useClientKeys);
			break;
		}
	}

	protected void Decrypt(ChannelToken token, ArraySegment<byte> dataToDecrypt, bool useClientKeys)
	{
		switch (SecurityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			SymmetricDecrypt(token, dataToDecrypt, useClientKeys);
			break;
		}
	}

	private static byte[] SymmetricSign(ChannelToken token, ArraySegment<byte> dataToSign, bool useClientKeys)
	{
		HMAC obj = (useClientKeys ? token.ClientHmac : token.ServerHmac);
		MemoryStream memoryStream = new MemoryStream(dataToSign.Array, dataToSign.Offset, dataToSign.Count, writable: false);
		byte[] result = obj.ComputeHash(memoryStream);
		memoryStream.Dispose();
		return result;
	}

	private bool SymmetricVerify(ChannelToken token, byte[] signature, ArraySegment<byte> dataToVerify, bool useClientKeys)
	{
		HMAC obj = (useClientKeys ? token.ClientHmac : token.ServerHmac);
		MemoryStream memoryStream = new MemoryStream(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, writable: false);
		byte[] array = obj.ComputeHash(memoryStream);
		memoryStream.Dispose();
		for (int i = 0; i < signature.Length; i++)
		{
			if (array[i] != signature[i])
			{
				string text = Encoding.UTF8.GetString(dataToVerify.Array, dataToVerify.Offset, 4);
				int num = BitConverter.ToInt32(dataToVerify.Array, dataToVerify.Offset + 4);
				string text2 = Utils.ToHexString(array);
				string text3 = Utils.ToHexString(signature);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("Channel{0}: Could not validate signature.");
				stringBuilder.AppendLine("ChannelId={1}, TokenId={2}, MessageType={3}, Length={4}");
				stringBuilder.AppendLine("ExpectedSignature={5}");
				stringBuilder.AppendLine("ActualSignature={6}");
				Utils.LogError(stringBuilder.ToString(), Id, token.ChannelId, token.TokenId, text, num, text2, text3);
				return false;
			}
		}
		return true;
	}

	private static void SymmetricEncrypt(ChannelToken token, ArraySegment<byte> dataToEncrypt, bool useClientKeys)
	{
		using ICryptoTransform cryptoTransform = ((useClientKeys ? token.ClientEncryptor : token.ServerEncryptor) ?? throw ServiceResultException.Create(2148728832u, "Token missing symmetric key object.")).CreateEncryptor();
		byte[] array = dataToEncrypt.Array;
		int offset = dataToEncrypt.Offset;
		int count = dataToEncrypt.Count;
		if (count % cryptoTransform.InputBlockSize != 0)
		{
			throw ServiceResultException.Create(2148728832u, "Input data is not an even number of encryption blocks.");
		}
		cryptoTransform.TransformBlock(array, offset, count, array, offset);
	}

	private static void SymmetricDecrypt(ChannelToken token, ArraySegment<byte> dataToDecrypt, bool useClientKeys)
	{
		using ICryptoTransform cryptoTransform = ((useClientKeys ? token.ClientEncryptor : token.ServerEncryptor) ?? throw ServiceResultException.Create(2148728832u, "Token missing symmetric key object.")).CreateDecryptor();
		byte[] array = dataToDecrypt.Array;
		int offset = dataToDecrypt.Offset;
		int count = dataToDecrypt.Count;
		if (count % cryptoTransform.InputBlockSize != 0)
		{
			throw ServiceResultException.Create(2148728832u, "Input data is not an even number of encryption blocks.");
		}
		cryptoTransform.TransformBlock(array, offset, count, array, offset);
	}
}
