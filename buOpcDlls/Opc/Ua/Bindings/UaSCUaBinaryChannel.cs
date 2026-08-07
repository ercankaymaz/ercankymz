// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.UaSCUaBinaryChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class UaSCUaBinaryChannel : IMessageSink, IDisposable
{
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
      lock (this.DataLock)
        return this.m_selectedEndpoint;
    }
    protected set
    {
      lock (this.DataLock)
        this.m_selectedEndpoint = value;
    }
  }

  protected X509Certificate2 ServerCertificate => this.m_serverCertificate;

  protected X509Certificate2Collection ServerCertificateChain
  {
    get => this.m_serverCertificateChain;
    set => this.m_serverCertificateChain = value;
  }

  protected MessageSecurityMode SecurityMode => this.m_securityMode;

  protected string SecurityPolicyUri => this.m_securityPolicyUri;

  protected bool DiscoveryOnly => this.m_discoveryOnly;

  protected X509Certificate2 ClientCertificate
  {
    get => this.m_clientCertificate;
    set => this.m_clientCertificate = value;
  }

  internal X509Certificate2Collection ClientCertificateChain
  {
    get => this.m_clientCertificateChain;
    set => this.m_clientCertificateChain = value;
  }

  protected byte[] CreateNonce()
  {
    uint nonceLength = this.GetNonceLength();
    return nonceLength > 0U ? Opc.Ua.Utils.Nonce.CreateNonce(nonceLength) : (byte[]) null;
  }

  protected static string GetThumbprintString(byte[] thumbprint)
  {
    if (thumbprint == null)
      return (string) null;
    StringBuilder stringBuilder = new StringBuilder(thumbprint.Length * 2);
    for (int index = 0; index < thumbprint.Length; ++index)
      stringBuilder.AppendFormat("{0:X2}", (object) thumbprint[index]);
    return stringBuilder.ToString();
  }

  protected static byte[] GetThumbprintBytes(string thumbprint)
  {
    if (thumbprint == null)
      return (byte[]) null;
    byte[] thumbprintBytes = new byte[thumbprint.Length / 2];
    for (int startIndex = 0; startIndex < thumbprint.Length - 1; startIndex += 2)
      thumbprintBytes[startIndex / 2] = Convert.ToByte(thumbprint.Substring(startIndex, 2), 16 /*0x10*/);
    return thumbprintBytes;
  }

  protected static void CompareCertificates(
    X509Certificate2 expected,
    X509Certificate2 actual,
    bool allowNull)
  {
    bool flag = true;
    if (expected == null)
    {
      flag = actual == null;
      if (allowNull)
        flag = true;
    }
    else if (actual == null)
      flag = allowNull;
    else if (!Opc.Ua.Utils.IsEqual((object) expected.RawData, (object) actual.RawData))
      flag = false;
    if (!flag)
      throw ServiceResultException.Create(2148663296U /*0x80120000*/, "Certificate mismatch. Expecting '{0}'/{1},. Received '{2}'/{3}.", expected != null ? (object) expected.Subject : (object) "(null)", expected != null ? (object) expected.Thumbprint : (object) "(null)", actual != null ? (object) actual.Subject : (object) "(null)", actual != null ? (object) actual.Thumbprint : (object) "(null)");
  }

  protected uint GetNonceLength() => Opc.Ua.Utils.Nonce.GetNonceLength(this.SecurityPolicyUri);

  protected bool ValidateNonce(byte[] nonce)
  {
    return Opc.Ua.Utils.Nonce.ValidateNonce(nonce, this.SecurityMode, this.SecurityPolicyUri);
  }

  protected int GetPlainTextBlockSize(X509Certificate2 receiverCertificate)
  {
    switch (this.SecurityPolicyUri)
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
    switch (this.SecurityPolicyUri)
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

  protected int GetAsymmetricHeaderSize(
    string securityPolicyUri,
    X509Certificate2 senderCertificate)
  {
    int num1 = 0;
    num1 = 12;
    int num2 = 16 /*0x10*/;
    if (securityPolicyUri != null)
      num2 += Encoding.UTF8.GetByteCount(securityPolicyUri);
    int asymmetricHeaderSize = num2 + 4 + 4;
    if (this.SecurityMode != MessageSecurityMode.None)
      asymmetricHeaderSize = asymmetricHeaderSize + senderCertificate.RawData.Length + 20;
    if (asymmetricHeaderSize >= this.SendBufferSize - 8 - this.GetAsymmetricSignatureSize(senderCertificate) - 1)
      throw ServiceResultException.Create(2147614720U /*0x80020000*/, "AsymmetricSecurityHeader is {0} bytes which is too large for the send buffer size of {1} bytes.", (object) asymmetricHeaderSize, (object) this.SendBufferSize);
    return asymmetricHeaderSize;
  }

  protected int GetAsymmetricHeaderSize(
    string securityPolicyUri,
    X509Certificate2 senderCertificate,
    int senderCertificateSize)
  {
    int num1 = 0;
    num1 = 12;
    int num2 = 16 /*0x10*/;
    if (securityPolicyUri != null)
      num2 += Encoding.UTF8.GetByteCount(securityPolicyUri);
    int asymmetricHeaderSize = num2 + 4 + 4;
    if (this.SecurityMode != MessageSecurityMode.None)
      asymmetricHeaderSize = asymmetricHeaderSize + senderCertificateSize + 20;
    if (asymmetricHeaderSize >= this.SendBufferSize - 8 - this.GetAsymmetricSignatureSize(senderCertificate) - 1)
      throw ServiceResultException.Create(2147614720U /*0x80020000*/, "AsymmetricSecurityHeader is {0} bytes which is too large for the send buffer size of {1} bytes.", (object) asymmetricHeaderSize, (object) this.SendBufferSize);
    return asymmetricHeaderSize;
  }

  protected int GetAsymmetricSignatureSize(X509Certificate2 senderCertificate)
  {
    switch (this.SecurityPolicyUri)
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

  protected void WriteAsymmetricMessageHeader(
    BinaryEncoder encoder,
    uint messageType,
    uint secureChannelId,
    string securityPolicyUri,
    X509Certificate2 senderCertificate,
    X509Certificate2 receiverCertificate)
  {
    int senderCertificateSize = 0;
    this.WriteAsymmetricMessageHeader(encoder, messageType, secureChannelId, securityPolicyUri, senderCertificate, (X509Certificate2Collection) null, receiverCertificate, out senderCertificateSize);
  }

  protected void WriteAsymmetricMessageHeader(
    BinaryEncoder encoder,
    uint messageType,
    uint secureChannelId,
    string securityPolicyUri,
    X509Certificate2 senderCertificate,
    X509Certificate2Collection senderCertificateChain,
    X509Certificate2 receiverCertificate,
    out int senderCertificateSize)
  {
    int position = encoder.Position;
    senderCertificateSize = 0;
    encoder.WriteUInt32((string) null, messageType);
    encoder.WriteUInt32((string) null, 0U);
    encoder.WriteUInt32((string) null, secureChannelId);
    encoder.WriteString((string) null, securityPolicyUri);
    if (this.SecurityMode != MessageSecurityMode.None)
    {
      if (senderCertificateChain != null && senderCertificateChain.Count > 0)
      {
        X509Certificate2 senderCertificate1 = senderCertificateChain[0];
        int senderCertificateSize1 = this.GetMaxSenderCertificateSize(senderCertificate1, securityPolicyUri);
        List<byte> byteList = new List<byte>((IEnumerable<byte>) senderCertificate1.RawData);
        senderCertificateSize = senderCertificate1.RawData.Length;
        for (int index = 1; index < senderCertificateChain.Count; ++index)
        {
          X509Certificate2 x509Certificate2 = senderCertificateChain[index];
          senderCertificateSize += x509Certificate2.RawData.Length;
          if (senderCertificateSize < senderCertificateSize1)
          {
            byteList.AddRange((IEnumerable<byte>) x509Certificate2.RawData);
          }
          else
          {
            senderCertificateSize -= x509Certificate2.RawData.Length;
            break;
          }
        }
        encoder.WriteByteString((string) null, byteList.ToArray());
      }
      else
        encoder.WriteByteString((string) null, senderCertificate.RawData);
      encoder.WriteByteString((string) null, UaSCUaBinaryChannel.GetThumbprintBytes(receiverCertificate.Thumbprint));
    }
    else
    {
      encoder.WriteByteString((string) null, (byte[]) null);
      encoder.WriteByteString((string) null, (byte[]) null);
    }
    if (encoder.Position - position > this.SendBufferSize)
      throw ServiceResultException.Create(2147614720U /*0x80020000*/, "AsymmetricSecurityHeader is {0} bytes which is too large for the send buffer size of {1} bytes.", (object) (encoder.Position - position), (object) this.SendBufferSize);
  }

  private int GetMaxSenderCertificateSize(
    X509Certificate2 senderCertificate,
    string securityPolicyUri)
  {
    int num = 16 /*0x10*/;
    if (securityPolicyUri != null)
      num += Encoding.UTF8.GetByteCount(securityPolicyUri);
    return this.SendBufferSize - (num + 4 + 4 + 20 + 8 + 1 + this.GetAsymmetricSignatureSize(senderCertificate));
  }

  protected BufferCollection WriteAsymmetricMessage(
    uint messageType,
    uint requestId,
    X509Certificate2 senderCertificate,
    X509Certificate2 receiverCertificate,
    ArraySegment<byte> messageBody)
  {
    return this.WriteAsymmetricMessage(messageType, requestId, senderCertificate, (X509Certificate2Collection) null, receiverCertificate, messageBody);
  }

  protected BufferCollection WriteAsymmetricMessage(
    uint messageType,
    uint requestId,
    X509Certificate2 senderCertificate,
    X509Certificate2Collection senderCertificateChain,
    X509Certificate2 receiverCertificate,
    ArraySegment<byte> messageBody)
  {
    bool flag = false;
    BufferCollection bufferCollection = new BufferCollection();
    byte[] buffer1 = this.BufferManager.TakeBuffer(this.SendBufferSize, nameof (WriteAsymmetricMessage));
    BinaryEncoder encoder = (BinaryEncoder) null;
    try
    {
      encoder = new BinaryEncoder(buffer1, 0, this.SendBufferSize, this.Quotas.MessageContext);
      int asymmetricHeaderSize;
      if (senderCertificateChain != null && senderCertificateChain.Count > 0)
      {
        int senderCertificateSize = 0;
        this.WriteAsymmetricMessageHeader(encoder, messageType | 1124073472U /*0x43000000*/, this.ChannelId, this.SecurityPolicyUri, senderCertificate, senderCertificateChain, receiverCertificate, out senderCertificateSize);
        asymmetricHeaderSize = this.GetAsymmetricHeaderSize(this.SecurityPolicyUri, senderCertificate, senderCertificateSize);
      }
      else
      {
        this.WriteAsymmetricMessageHeader(encoder, messageType | 1124073472U /*0x43000000*/, this.ChannelId, this.SecurityPolicyUri, senderCertificate, receiverCertificate);
        asymmetricHeaderSize = this.GetAsymmetricHeaderSize(this.SecurityPolicyUri, senderCertificate);
      }
      int asymmetricSignatureSize = this.GetAsymmetricSignatureSize(senderCertificate);
      ArraySegment<byte> headerToCopy = new ArraySegment<byte>(buffer1, 0, asymmetricHeaderSize);
      int plainTextBlockSize = this.GetPlainTextBlockSize(receiverCertificate);
      int cipherTextBlockSize = this.GetCipherTextBlockSize(receiverCertificate);
      int num1 = (this.SendBufferSize - asymmetricHeaderSize) / cipherTextBlockSize * plainTextBlockSize - asymmetricSignatureSize - 1 - 8;
      int count1 = messageBody.Count;
      int offset = messageBody.Offset;
      while (count1 > 0)
      {
        encoder.WriteUInt32((string) null, this.GetNewSequenceNumber());
        encoder.WriteUInt32((string) null, requestId);
        int count2 = count1;
        if (count2 > num1)
          count2 = num1;
        else
          UaSCUaBinaryChannel.UpdateMessageType(buffer1, 0, messageType | 1174405120U /*0x46000000*/);
        encoder.WriteRawBytes(messageBody.Array, messageBody.Offset + offset, count2);
        int num2 = encoder.Position - asymmetricHeaderSize + asymmetricSignatureSize;
        int num3 = 0;
        if (this.SecurityMode != MessageSecurityMode.None)
        {
          int num4;
          if (Opc.Ua.X509Utils.GetRSAPublicKeySize(receiverCertificate) <= 2048 /*0x0800*/)
          {
            num4 = num2 + 1;
            if (num4 % plainTextBlockSize != 0)
              num3 = plainTextBlockSize - num4 % plainTextBlockSize;
            encoder.WriteByte((string) null, (byte) num3);
            for (int index = 0; index < num3; ++index)
              encoder.WriteByte((string) null, (byte) num3);
          }
          else
          {
            num4 = num2 + 1 + 1;
            if (num4 % plainTextBlockSize != 0)
              num3 = plainTextBlockSize - num4 % plainTextBlockSize;
            byte num5 = (byte) (num3 & (int) byte.MaxValue);
            byte num6 = (byte) (num3 >> 8 & (int) byte.MaxValue);
            encoder.WriteByte((string) null, num5);
            for (int index = 0; index < num3; ++index)
              encoder.WriteByte((string) null, num5);
            encoder.WriteByte((string) null, num6);
          }
          num2 = num4 + num3;
        }
        int num7 = num2 / plainTextBlockSize * cipherTextBlockSize;
        UaSCUaBinaryChannel.UpdateMessageSize(buffer1, 0, num7 + asymmetricHeaderSize);
        byte[] buffer2 = this.Sign(new ArraySegment<byte>(buffer1, 0, encoder.Position), senderCertificate);
        if (buffer2 != null)
          encoder.WriteRawBytes(buffer2, 0, buffer2.Length);
        int num8 = encoder.Close();
        ArraySegment<byte> arraySegment = this.Encrypt(new ArraySegment<byte>(buffer1, asymmetricHeaderSize, num8 - asymmetricHeaderSize), headerToCopy, receiverCertificate);
        if (arraySegment.Count != num7 + asymmetricHeaderSize)
          throw new InvalidDataException("Actual message size is not the same as the predicted message size.");
        bufferCollection.Add(arraySegment);
        count1 -= count2;
        offset += count2;
        if (count1 > 0)
        {
          Opc.Ua.Utils.SilentDispose((IDisposable) encoder);
          MemoryStream memoryStream = new MemoryStream(buffer1, 0, this.SendBufferSize);
          memoryStream.Seek((long) headerToCopy.Count, SeekOrigin.Current);
          encoder = new BinaryEncoder((Stream) memoryStream, this.Quotas.MessageContext, false);
        }
      }
      flag = true;
      return bufferCollection;
    }
    catch (Exception ex)
    {
      throw new ServiceResultException("Could not write async message", ex);
    }
    finally
    {
      Opc.Ua.Utils.SilentDispose((IDisposable) encoder);
      this.BufferManager.ReturnBuffer(buffer1, nameof (WriteAsymmetricMessage));
      if (!flag)
        bufferCollection.Release(this.BufferManager, nameof (WriteAsymmetricMessage));
    }
  }

  protected void ReadAsymmetricMessageHeader(
    BinaryDecoder decoder,
    X509Certificate2 receiverCertificate,
    out uint secureChannelId,
    out X509Certificate2Collection senderCertificateChain,
    out string securityPolicyUri)
  {
    senderCertificateChain = (X509Certificate2Collection) null;
    int num1 = (int) decoder.ReadUInt32((string) null);
    int num2 = (int) decoder.ReadUInt32((string) null);
    byte[] certificateData;
    byte[] thumbprint;
    try
    {
      secureChannelId = decoder.ReadUInt32((string) null);
      securityPolicyUri = decoder.ReadString((string) null, 256 /*0x0100*/);
      certificateData = decoder.ReadByteString((string) null, 7500);
      thumbprint = decoder.ReadByteString((string) null, 20);
    }
    catch (Exception ex)
    {
      throw ServiceResultException.Create(2148728832U /*0x80130000*/, ex, "The asymmetric security header could not be parsed.");
    }
    if (certificateData != null && certificateData.Length != 0)
    {
      senderCertificateChain = Opc.Ua.Utils.ParseCertificateChainBlob(certificateData);
      try
      {
        if (senderCertificateChain[0].Thumbprint == null)
          throw ServiceResultException.Create(2148663296U /*0x80120000*/, "Invalid certificate thumbprint.");
      }
      catch (Exception ex)
      {
        throw ServiceResultException.Create(2148663296U /*0x80120000*/, ex, "The sender's certificate could not be parsed.");
      }
    }
    else if (securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
      throw ServiceResultException.Create(2148663296U /*0x80120000*/, "The sender's certificate was not specified.");
    if (thumbprint != null && thumbprint.Length != 0)
    {
      if (receiverCertificate.Thumbprint.ToUpperInvariant() != UaSCUaBinaryChannel.GetThumbprintString(thumbprint))
        throw ServiceResultException.Create(2148663296U /*0x80120000*/, "The receiver's certificate thumbprint is not valid.");
    }
    else if (securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
      throw ServiceResultException.Create(2148663296U /*0x80120000*/, "The receiver's certificate thumbprint was not specified.");
  }

  protected void ReviseSecurityMode(bool firstCall, MessageSecurityMode requestedMode)
  {
    bool flag = false;
    if (firstCall && !this.m_discoveryOnly)
    {
      foreach (EndpointDescription endpoint in (List<EndpointDescription>) this.m_endpoints)
      {
        if (endpoint.SecurityMode == requestedMode && (requestedMode == MessageSecurityMode.None || endpoint.SecurityPolicyUri == this.m_securityPolicyUri))
        {
          this.m_securityMode = endpoint.SecurityMode;
          this.m_selectedEndpoint = endpoint;
          flag = true;
          break;
        }
      }
    }
    if (!flag)
      throw ServiceResultException.Create(2152988672U /*0x80540000*/, "Security mode is not acceptable to the server.");
  }

  protected virtual bool SetEndpointUrl(string endpointUrl)
  {
    Uri uri1 = Opc.Ua.Utils.ParseUri(endpointUrl);
    if (uri1 == (Uri) null)
      return false;
    foreach (EndpointDescription endpoint in (List<EndpointDescription>) this.m_endpoints)
    {
      Uri uri2 = Opc.Ua.Utils.ParseUri(endpoint.EndpointUrl);
      if (!(uri2 == (Uri) null) && !(uri2.Scheme != uri1.Scheme))
      {
        this.m_securityMode = endpoint.SecurityMode;
        this.m_securityPolicyUri = endpoint.SecurityPolicyUri;
        this.m_selectedEndpoint = endpoint;
        return true;
      }
    }
    return false;
  }

  protected ArraySegment<byte> ReadAsymmetricMessage(
    ArraySegment<byte> buffer,
    X509Certificate2 receiverCertificate,
    out uint channelId,
    out X509Certificate2 senderCertificate,
    out uint requestId,
    out uint sequenceNumber)
  {
    BinaryDecoder decoder = new BinaryDecoder(buffer.Array, buffer.Offset, buffer.Count, this.Quotas.MessageContext);
    string securityPolicyUri = (string) null;
    X509Certificate2Collection senderCertificateChain;
    this.ReadAsymmetricMessageHeader(decoder, receiverCertificate, out channelId, out senderCertificateChain, out securityPolicyUri);
    senderCertificate = senderCertificateChain == null || senderCertificateChain.Count <= 0 ? (X509Certificate2) null : senderCertificateChain[0];
    if (senderCertificate != null && this.Quotas.CertificateValidator != null && securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
    {
      if (this.Quotas.CertificateValidator is CertificateValidator certificateValidator)
        certificateValidator.Validate(senderCertificateChain);
      else
        this.Quotas.CertificateValidator.Validate(senderCertificate);
    }
    if (!this.m_uninitialized)
    {
      if (securityPolicyUri != this.m_securityPolicyUri)
        throw ServiceResultException.Create(2153054208U /*0x80550000*/, "Cannot change the security policy after creating the channnel.");
    }
    else
    {
      if (this.m_endpoints != null)
      {
        foreach (EndpointDescription endpoint in (List<EndpointDescription>) this.m_endpoints)
        {
          if (endpoint.SecurityPolicyUri == securityPolicyUri || securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None" && endpoint.SecurityMode == MessageSecurityMode.None)
          {
            this.m_securityMode = endpoint.SecurityMode;
            this.m_securityPolicyUri = securityPolicyUri;
            this.m_discoveryOnly = false;
            this.m_uninitialized = false;
            this.m_selectedEndpoint = endpoint;
            this.CalculateSymmetricKeySizes();
            break;
          }
        }
      }
      if (this.m_uninitialized)
      {
        if (securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
          throw ServiceResultException.Create(2153054208U /*0x80550000*/, "The security policy is not supported.");
        this.m_securityMode = MessageSecurityMode.None;
        this.m_securityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None";
        this.m_discoveryOnly = true;
        this.m_uninitialized = false;
        this.m_selectedEndpoint = (EndpointDescription) null;
      }
    }
    int position = decoder.Position;
    ArraySegment<byte> arraySegment = this.Decrypt(new ArraySegment<byte>(buffer.Array, buffer.Offset + position, buffer.Count - position), new ArraySegment<byte>(buffer.Array, buffer.Offset, position), receiverCertificate);
    int asymmetricSignatureSize = this.GetAsymmetricSignatureSize(senderCertificate);
    byte[] signature = new byte[asymmetricSignatureSize];
    for (int index = 0; index < asymmetricSignatureSize; ++index)
      signature[index] = arraySegment.Array[arraySegment.Offset + arraySegment.Count - asymmetricSignatureSize + index];
    if (!this.Verify(new ArraySegment<byte>(arraySegment.Array, arraySegment.Offset, arraySegment.Count - asymmetricSignatureSize), signature, senderCertificate))
    {
      Opc.Ua.Utils.LogWarning("Could not verify signature on message.");
      throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Could not verify the signature on the message.");
    }
    int num1 = 0;
    if (this.SecurityMode != MessageSecurityMode.None)
    {
      int num2;
      if (Opc.Ua.X509Utils.GetRSAPublicKeySize(receiverCertificate) > 2048 /*0x0800*/)
      {
        int index1 = arraySegment.Offset + arraySegment.Count - asymmetricSignatureSize - 1;
        num2 = (int) arraySegment.Array[index1 - 1] + (int) arraySegment.Array[index1] * 256 /*0x0100*/;
        for (int index2 = index1 - num2; index2 < index1; ++index2)
        {
          if ((int) arraySegment.Array[index2] != (int) arraySegment.Array[index1 - 1])
            throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Could not verify the padding in the message.");
        }
      }
      else
      {
        int index3 = arraySegment.Offset + arraySegment.Count - asymmetricSignatureSize - 1;
        num2 = (int) arraySegment.Array[index3];
        for (int index4 = index3 - num2; index4 < index3; ++index4)
        {
          if ((int) arraySegment.Array[index4] != (int) arraySegment.Array[index3])
            throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Could not verify the padding in the message.");
        }
      }
      num1 = num2 + 1;
    }
    BinaryDecoder binaryDecoder = new BinaryDecoder(arraySegment.Array, arraySegment.Offset + position, arraySegment.Count - position, this.Quotas.MessageContext);
    sequenceNumber = binaryDecoder.ReadUInt32((string) null);
    requestId = binaryDecoder.ReadUInt32((string) null);
    int num3 = position + binaryDecoder.Position;
    binaryDecoder.Close();
    Opc.Ua.Utils.LogInfo("Security Policy: {0}", (object) this.SecurityPolicyUri);
    Opc.Ua.Utils.LogCertificate("Sender Certificate:", senderCertificate);
    return new ArraySegment<byte>(arraySegment.Array, arraySegment.Offset + num3, arraySegment.Count - num3 - asymmetricSignatureSize - num1);
  }

  protected byte[] Sign(ArraySegment<byte> dataToSign, X509Certificate2 senderCertificate)
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        return UaSCUaBinaryChannel.Rsa_Sign(dataToSign, senderCertificate, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        return UaSCUaBinaryChannel.Rsa_Sign(dataToSign, senderCertificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        return UaSCUaBinaryChannel.Rsa_Sign(dataToSign, senderCertificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
      default:
        return (byte[]) null;
    }
  }

  protected bool Verify(
    ArraySegment<byte> dataToVerify,
    byte[] signature,
    X509Certificate2 senderCertificate)
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#None":
        return true;
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
        return UaSCUaBinaryChannel.Rsa_Verify(dataToVerify, signature, senderCertificate, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        return UaSCUaBinaryChannel.Rsa_Verify(dataToVerify, signature, senderCertificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        return UaSCUaBinaryChannel.Rsa_Verify(dataToVerify, signature, senderCertificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
      default:
        return false;
    }
  }

  protected ArraySegment<byte> Encrypt(
    ArraySegment<byte> dataToEncrypt,
    ArraySegment<byte> headerToCopy,
    X509Certificate2 receiverCertificate)
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        return this.Rsa_Encrypt(dataToEncrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.OaepSHA1);
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        return this.Rsa_Encrypt(dataToEncrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.OaepSHA256);
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        return this.Rsa_Encrypt(dataToEncrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.Pkcs1);
      default:
        byte[] buffer = this.BufferManager.TakeBuffer(this.SendBufferSize, nameof (Encrypt));
        Array.Copy((Array) headerToCopy.Array, headerToCopy.Offset, (Array) buffer, 0, headerToCopy.Count);
        Array.Copy((Array) dataToEncrypt.Array, dataToEncrypt.Offset, (Array) buffer, headerToCopy.Count, dataToEncrypt.Count);
        return new ArraySegment<byte>(buffer, 0, dataToEncrypt.Count + headerToCopy.Count);
    }
  }

  protected ArraySegment<byte> Decrypt(
    ArraySegment<byte> dataToDecrypt,
    ArraySegment<byte> headerToCopy,
    X509Certificate2 receiverCertificate)
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        return this.Rsa_Decrypt(dataToDecrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.OaepSHA1);
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        return this.Rsa_Decrypt(dataToDecrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.OaepSHA256);
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        return this.Rsa_Decrypt(dataToDecrypt, headerToCopy, receiverCertificate, RsaUtils.Padding.Pkcs1);
      default:
        byte[] buffer = this.BufferManager.TakeBuffer(this.SendBufferSize, nameof (Decrypt));
        Array.Copy((Array) headerToCopy.Array, headerToCopy.Offset, (Array) buffer, 0, headerToCopy.Count);
        Array.Copy((Array) dataToDecrypt.Array, dataToDecrypt.Offset, (Array) buffer, headerToCopy.Count, dataToDecrypt.Count);
        return new ArraySegment<byte>(buffer, 0, dataToDecrypt.Count + headerToCopy.Count);
    }
  }

  public UaSCUaBinaryChannel(
    string contextId,
    BufferManager bufferManager,
    ChannelQuotas quotas,
    X509Certificate2 serverCertificate,
    EndpointDescriptionCollection endpoints,
    MessageSecurityMode securityMode,
    string securityPolicyUri)
    : this(contextId, bufferManager, quotas, serverCertificate, (X509Certificate2Collection) null, endpoints, securityMode, securityPolicyUri)
  {
  }

  public UaSCUaBinaryChannel(
    string contextId,
    BufferManager bufferManager,
    ChannelQuotas quotas,
    X509Certificate2 serverCertificate,
    X509Certificate2Collection serverCertificateChain,
    EndpointDescriptionCollection endpoints,
    MessageSecurityMode securityMode,
    string securityPolicyUri)
  {
    if (bufferManager == null)
      throw new ArgumentNullException(nameof (bufferManager));
    if (quotas == null)
      throw new ArgumentNullException(nameof (quotas));
    this.m_contextId = contextId;
    if (string.IsNullOrEmpty(this.m_contextId))
      this.m_contextId = Guid.NewGuid().ToString();
    if (securityMode == MessageSecurityMode.None)
      securityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None";
    if (securityMode != MessageSecurityMode.None)
    {
      if (serverCertificate == null)
        throw new ArgumentNullException(nameof (serverCertificate));
      if (serverCertificate.RawData.Length > 7500)
        throw new ArgumentException(Opc.Ua.Utils.Format("The DER encoded certificate may not be more than {0} bytes.", (object) 7500), nameof (serverCertificate));
    }
    if (Encoding.UTF8.GetByteCount(securityPolicyUri) > 256 /*0x0100*/)
      throw new ArgumentException(Opc.Ua.Utils.Format("UTF-8 form of the security policy URI may not be more than {0} bytes.", (object) 256 /*0x0100*/), nameof (securityPolicyUri));
    this.m_bufferManager = bufferManager;
    this.m_quotas = quotas;
    this.m_serverCertificate = serverCertificate;
    this.m_serverCertificateChain = serverCertificateChain;
    this.m_endpoints = endpoints;
    this.m_securityMode = securityMode;
    this.m_securityPolicyUri = securityPolicyUri;
    this.m_discoveryOnly = false;
    this.m_uninitialized = true;
    this.m_state = TcpChannelState.Closed;
    this.m_receiveBufferSize = quotas.MaxBufferSize;
    this.m_sendBufferSize = quotas.MaxBufferSize;
    this.m_activeWriteRequests = 0;
    if (this.m_receiveBufferSize < 8192 /*0x2000*/)
      this.m_receiveBufferSize = 8192 /*0x2000*/;
    if (this.m_receiveBufferSize > 147456 /*0x024000*/)
      this.m_receiveBufferSize = 147456 /*0x024000*/;
    if (this.m_sendBufferSize < 8192 /*0x2000*/)
      this.m_sendBufferSize = 8192 /*0x2000*/;
    if (this.m_sendBufferSize > 147456 /*0x024000*/)
      this.m_sendBufferSize = 147456 /*0x024000*/;
    this.m_maxRequestMessageSize = quotas.MaxMessageSize;
    this.m_maxResponseMessageSize = quotas.MaxMessageSize;
    this.m_maxRequestChunkCount = UaSCUaBinaryChannel.CalculateChunkCount(this.m_maxRequestMessageSize, 8192 /*0x2000*/);
    this.m_maxResponseChunkCount = UaSCUaBinaryChannel.CalculateChunkCount(this.m_maxResponseMessageSize, 8192 /*0x2000*/);
    this.CalculateSymmetricKeySizes();
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
  }

  public uint Id
  {
    get
    {
      lock (this.m_lock)
        return this.m_channelId;
    }
  }

  public string GlobalChannelId
  {
    get
    {
      lock (this.m_lock)
        return this.m_globalChannelId;
    }
  }

  public void SetStateChangedCallback(TcpChannelStateEventHandler callback)
  {
    lock (this.m_lock)
      this.m_StateChanged = callback;
  }

  protected void ChannelStateChanged(TcpChannelState state, ServiceResult reason)
  {
    if (this.m_StateChanged == null)
      return;
    Task.Run((Action) (() =>
    {
      TcpChannelStateEventHandler stateChanged = this.m_StateChanged;
      if (stateChanged == null)
        return;
      stateChanged(this, state, reason);
    }));
  }

  protected uint GetNewSequenceNumber() => Opc.Ua.Utils.IncrementIdentifier(ref this.m_sequenceNumber);

  protected void ResetSequenceNumber(uint sequenceNumber)
  {
    this.m_remoteSequenceNumber = sequenceNumber;
  }

  protected bool VerifySequenceNumber(uint sequenceNumber, string context)
  {
    if (sequenceNumber > this.m_remoteSequenceNumber)
    {
      this.m_remoteSequenceNumber = sequenceNumber;
      return true;
    }
    if (this.m_remoteSequenceNumber > 4294966271U && sequenceNumber < 1024U /*0x0400*/ && !this.m_sequenceRollover)
    {
      this.m_sequenceRollover = true;
      this.m_remoteSequenceNumber = sequenceNumber;
      return true;
    }
    Opc.Ua.Utils.LogError("ChannelId {0}: {1} - Duplicate sequence number: {2} <= {3}", (object) this.ChannelId, (object) context, (object) sequenceNumber, (object) this.m_remoteSequenceNumber);
    return false;
  }

  protected bool SaveIntermediateChunk(
    uint requestId,
    ArraySegment<byte> chunk,
    bool isServerContext)
  {
    bool flag1 = false;
    if (this.m_partialMessageChunks == null)
    {
      flag1 = true;
      this.m_partialMessageChunks = new BufferCollection();
    }
    bool flag2 = this.MessageLimitsExceeded(isServerContext, this.m_partialMessageChunks.TotalSize, this.m_partialMessageChunks.Count);
    if ((int) this.m_partialRequestId != (int) requestId | flag2)
    {
      if (this.m_partialMessageChunks.Count > 0)
        Opc.Ua.Utils.LogWarning("WARNING - Discarding unprocessed message chunks for Request #{0}", (object) this.m_partialRequestId);
      this.m_partialMessageChunks.Release(this.BufferManager, nameof (SaveIntermediateChunk));
    }
    if (flag2)
    {
      this.DoMessageLimitsExceeded();
      return flag1;
    }
    if (requestId != 0U)
    {
      this.m_partialRequestId = requestId;
      this.m_partialMessageChunks.Add(chunk);
    }
    return flag1;
  }

  protected BufferCollection GetSavedChunks(
    uint requestId,
    ArraySegment<byte> chunk,
    bool isServerContext)
  {
    this.SaveIntermediateChunk(requestId, chunk, isServerContext);
    BufferCollection partialMessageChunks = this.m_partialMessageChunks;
    this.m_partialMessageChunks = (BufferCollection) null;
    return partialMessageChunks;
  }

  protected int GetSavedChunksTotalSize()
  {
    return this.m_partialMessageChunks != null ? this.m_partialMessageChunks.TotalSize : 0;
  }

  protected virtual void DoMessageLimitsExceeded()
  {
    Opc.Ua.Utils.LogError("ChannelId {0}: - Message limits exceeded while building up message. Channel will be closed.", (object) this.ChannelId);
  }

  public virtual bool ChannelFull => this.m_activeWriteRequests > 100;

  public virtual void OnMessageReceived(IMessageSocket source, ArraySegment<byte> message)
  {
    lock (this.DataLock)
    {
      try
      {
        if (this.HandleIncomingMessage(BitConverter.ToUInt32(message.Array, message.Offset), message))
          return;
        this.BufferManager.ReturnBuffer(message.Array, nameof (OnMessageReceived));
      }
      catch (Exception ex)
      {
        this.HandleMessageProcessingError(ex, 2156003328U /*0x80820000*/, "An error occurred receiving a message.");
        this.BufferManager.ReturnBuffer(message.Array, nameof (OnMessageReceived));
      }
    }
  }

  protected virtual bool HandleIncomingMessage(uint messageType, ArraySegment<byte> messageChunk)
  {
    return false;
  }

  protected void HandleMessageProcessingError(
    Exception e,
    uint defaultCode,
    string format,
    params object[] args)
  {
    this.HandleMessageProcessingError(ServiceResult.Create(e, defaultCode, format, args));
  }

  protected void HandleMessageProcessingError(uint statusCode, string format, params object[] args)
  {
    this.HandleMessageProcessingError(ServiceResult.Create(statusCode, format, args));
  }

  protected virtual void HandleMessageProcessingError(ServiceResult result)
  {
  }

  public virtual void OnReceiveError(IMessageSocket source, ServiceResult result)
  {
    lock (this.DataLock)
      this.HandleSocketError(result);
  }

  protected virtual void HandleSocketError(ServiceResult result)
  {
  }

  protected virtual void OnWriteComplete(object sender, IMessageSocketAsyncEventArgs e)
  {
    ServiceResult good = ServiceResult.Good;
    try
    {
      if (e.BytesTransferred == 0)
        good = ServiceResult.Create(2158886912U /*0x80AE0000*/, "The socket was closed by the remote application.");
      if (e.Buffer != null)
        this.BufferManager.ReturnBuffer(e.Buffer, nameof (OnWriteComplete));
      this.HandleWriteComplete(e.BufferList, e.UserToken, e.BytesTransferred, good);
    }
    catch (Exception ex)
    {
      if (ex is InvalidOperationException)
        e.BufferList = (BufferCollection) null;
      object[] objArray = Array.Empty<object>();
      ServiceResult result = ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Unexpected error during write operation.", objArray);
      this.HandleWriteComplete(e.BufferList, e.UserToken, e.BytesTransferred, result);
    }
    e.Dispose();
  }

  protected void BeginWriteMessage(ArraySegment<byte> buffer, object state)
  {
    ServiceResult good = ServiceResult.Good;
    IMessageSocketAsyncEventArgs socketAsyncEventArgs = this.m_socket.MessageSocketEventArgs();
    try
    {
      Interlocked.Increment(ref this.m_activeWriteRequests);
      socketAsyncEventArgs.SetBuffer(buffer.Array, buffer.Offset, buffer.Count);
      socketAsyncEventArgs.Completed += new EventHandler<IMessageSocketAsyncEventArgs>(this.OnWriteComplete);
      socketAsyncEventArgs.UserToken = state;
      if (this.m_socket.SendAsync(socketAsyncEventArgs))
        return;
      if (!socketAsyncEventArgs.IsSocketError && socketAsyncEventArgs.BytesTransferred >= buffer.Count)
      {
        this.OnWriteComplete((object) null, socketAsyncEventArgs);
      }
      else
      {
        ServiceResult result = ServiceResult.Create(2158886912U /*0x80AE0000*/, socketAsyncEventArgs.SocketErrorString);
        this.HandleWriteComplete((BufferCollection) null, state, socketAsyncEventArgs.BytesTransferred, result);
        socketAsyncEventArgs.Dispose();
      }
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      ServiceResult result = ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Unexpected error during write operation.", objArray);
      this.HandleWriteComplete((BufferCollection) null, state, socketAsyncEventArgs.BytesTransferred, result);
      socketAsyncEventArgs.Dispose();
    }
  }

  protected void BeginWriteMessage(BufferCollection buffers, object state)
  {
    ServiceResult good = ServiceResult.Good;
    IMessageSocketAsyncEventArgs socketAsyncEventArgs = this.m_socket.MessageSocketEventArgs();
    try
    {
      Interlocked.Increment(ref this.m_activeWriteRequests);
      socketAsyncEventArgs.BufferList = buffers;
      socketAsyncEventArgs.Completed += new EventHandler<IMessageSocketAsyncEventArgs>(this.OnWriteComplete);
      socketAsyncEventArgs.UserToken = state;
      if (this.m_socket != null && this.m_socket.SendAsync(socketAsyncEventArgs))
        return;
      if (!socketAsyncEventArgs.IsSocketError && socketAsyncEventArgs.BytesTransferred >= buffers.TotalSize)
      {
        this.OnWriteComplete((object) null, socketAsyncEventArgs);
      }
      else
      {
        ServiceResult result = ServiceResult.Create(2158886912U /*0x80AE0000*/, socketAsyncEventArgs.SocketErrorString);
        this.HandleWriteComplete(buffers, state, socketAsyncEventArgs.BytesTransferred, result);
        socketAsyncEventArgs.Dispose();
      }
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      ServiceResult result = ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Unexpected error during write operation.", objArray);
      this.HandleWriteComplete(buffers, state, socketAsyncEventArgs.BytesTransferred, result);
      socketAsyncEventArgs.Dispose();
    }
  }

  protected virtual void HandleWriteComplete(
    BufferCollection buffers,
    object state,
    int bytesWritten,
    ServiceResult result)
  {
    buffers?.Release(this.BufferManager, "WriteOperation");
    Interlocked.Decrement(ref this.m_activeWriteRequests);
  }

  protected static void WriteErrorMessageBody(BinaryEncoder encoder, ServiceResult error)
  {
    string s = error.LocalizedText != (LocalizedText) null ? error.LocalizedText.Text : (string) null;
    if (s != null && Encoding.UTF8.GetByteCount(s) > 4096 /*0x1000*/)
      s = s.Substring(0, 4096 /*0x1000*/ / Encoding.UTF8.GetMaxByteCount(1));
    encoder.WriteStatusCode((string) null, error.StatusCode);
    encoder.WriteString((string) null, s);
  }

  protected static ServiceResult ReadErrorMessageBody(BinaryDecoder decoder)
  {
    uint code = decoder.ReadUInt32((string) null);
    string str = (string) null;
    int count = decoder.ReadInt32((string) null);
    if (count > 0 && count < 4096 /*0x1000*/)
    {
      byte[] bytes = new byte[count];
      for (int index = 0; index < count; ++index)
        bytes[index] = decoder.ReadByte((string) null);
      str = Encoding.UTF8.GetString(bytes, 0, count);
    }
    if (str == null)
      str = new ServiceResult(code).ToString();
    return ServiceResult.Create(code, "Error received from remote host: {0}", (object) str);
  }

  protected bool MessageLimitsExceeded(bool isRequest, int messageSize, int chunkCount)
  {
    if (isRequest)
    {
      if (this.MaxRequestChunkCount > 0 && this.MaxRequestChunkCount < chunkCount || this.MaxRequestMessageSize > 0 && this.MaxRequestMessageSize < messageSize)
        return true;
    }
    else if (this.MaxResponseChunkCount > 0 && this.MaxResponseChunkCount < chunkCount || this.MaxResponseMessageSize > 0 && this.MaxResponseMessageSize < messageSize)
      return true;
    return false;
  }

  protected static void UpdateMessageType(byte[] buffer, int offset, uint messageType)
  {
    buffer[offset++] = (byte) (messageType & (uint) byte.MaxValue);
    buffer[offset++] = (byte) ((messageType & 65280U) >> 8);
    buffer[offset++] = (byte) ((messageType & 16711680U /*0xFF0000*/) >> 16 /*0x10*/);
    buffer[offset] = (byte) ((messageType & 4278190080U /*0xFF000000*/) >> 24);
  }

  protected static void UpdateMessageSize(byte[] buffer, int offset, int messageSize)
  {
    if (offset >= 2147483643)
      throw new ArgumentOutOfRangeException(nameof (offset));
    offset += 4;
    buffer[offset++] = (byte) (messageSize & (int) byte.MaxValue);
    buffer[offset++] = (byte) ((messageSize & 65280) >> 8);
    buffer[offset++] = (byte) ((messageSize & 16711680 /*0xFF0000*/) >> 16 /*0x10*/);
    buffer[offset] = (byte) (((long) messageSize & 4278190080L /*0xFF000000*/) >> 24);
  }

  protected object DataLock => this.m_lock;

  protected internal IMessageSocket Socket
  {
    get => this.m_socket;
    set => this.m_socket = value;
  }

  protected internal bool ReverseSocket { get; set; }

  protected BufferManager BufferManager => this.m_bufferManager;

  protected ChannelQuotas Quotas => this.m_quotas;

  protected int ReceiveBufferSize
  {
    get => this.m_receiveBufferSize;
    set => this.m_receiveBufferSize = value;
  }

  protected int SendBufferSize
  {
    get => this.m_sendBufferSize;
    set => this.m_sendBufferSize = value;
  }

  protected int MaxRequestMessageSize
  {
    get => this.m_maxRequestMessageSize;
    set => this.m_maxRequestMessageSize = value;
  }

  protected int MaxRequestChunkCount
  {
    get => this.m_maxRequestChunkCount;
    set => this.m_maxRequestChunkCount = value;
  }

  protected int MaxResponseMessageSize
  {
    get => this.m_maxResponseMessageSize;
    set => this.m_maxResponseMessageSize = value;
  }

  protected int MaxResponseChunkCount
  {
    get => this.m_maxResponseChunkCount;
    set => this.m_maxResponseChunkCount = value;
  }

  protected TcpChannelState State
  {
    get => this.m_state;
    set
    {
      if (this.m_state != value)
        Opc.Ua.Utils.LogInfo("ChannelId {0}: in {1} state.", (object) this.ChannelId, (object) value);
      this.m_state = value;
    }
  }

  protected uint ChannelId
  {
    get => this.m_channelId;
    set
    {
      this.m_channelId = value;
      this.m_globalChannelId = Opc.Ua.Utils.Format("{0}-{1}", (object) this.m_contextId, (object) this.m_channelId);
    }
  }

  protected static int CalculateChunkCount(int messageSize, int bufferSize)
  {
    if (bufferSize <= 0)
      return 1;
    int chunkCount = messageSize / bufferSize;
    if (chunkCount * bufferSize < messageSize)
      ++chunkCount;
    return chunkCount;
  }

  private static byte[] Rsa_Sign(
    ArraySegment<byte> dataToSign,
    X509Certificate2 signingCertificate,
    HashAlgorithmName algorithm,
    RSASignaturePadding padding)
  {
    using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(signingCertificate))
    {
      if (rsaPrivateKey == null)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No private key for certificate.");
      return rsaPrivateKey.SignData(dataToSign.Array, dataToSign.Offset, dataToSign.Count, algorithm, padding);
    }
  }

  private static bool Rsa_Verify(
    ArraySegment<byte> dataToVerify,
    byte[] signature,
    X509Certificate2 signingCertificate,
    HashAlgorithmName algorithm,
    RSASignaturePadding padding)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(signingCertificate))
    {
      if (rsaPublicKey == null)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No public key for certificate.");
      if (rsaPublicKey.VerifyData(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, signature, algorithm, padding))
        return true;
      string str = Encoding.UTF8.GetString(dataToVerify.Array, dataToVerify.Offset, 4);
      int int32 = BitConverter.ToInt32(dataToVerify.Array, dataToVerify.Offset + 4);
      string hexString = Opc.Ua.Utils.ToHexString(signature);
      Opc.Ua.Utils.LogError("Could not validate signature.");
      Opc.Ua.Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Error, "Certificate: ", signingCertificate);
      Opc.Ua.Utils.LogError("MessageType ={0}, Length ={1}, ActualSignature={2}", (object) str, (object) int32, (object) hexString);
      return false;
    }
  }

  private ArraySegment<byte> Rsa_Encrypt(
    ArraySegment<byte> dataToEncrypt,
    ArraySegment<byte> headerToCopy,
    X509Certificate2 encryptingCertificate,
    RsaUtils.Padding padding)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(encryptingCertificate))
    {
      int length = rsaPublicKey != null ? RsaUtils.GetPlainTextBlockSize(rsaPublicKey, padding) : throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No public key for certificate.");
      int cipherTextBlockSize = RsaUtils.GetCipherTextBlockSize(rsaPublicKey, padding);
      if (dataToEncrypt.Count % length != 0)
        Opc.Ua.Utils.LogWarning("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", (object) dataToEncrypt.Count, (object) length);
      byte[] buffer1 = this.BufferManager.TakeBuffer(this.SendBufferSize, nameof (Rsa_Encrypt));
      Array.Copy((Array) headerToCopy.Array, headerToCopy.Offset, (Array) buffer1, 0, headerToCopy.Count);
      RSAEncryptionPadding encryptionPadding = RsaUtils.GetRSAEncryptionPadding(padding);
      using (MemoryStream memoryStream = new MemoryStream(buffer1, headerToCopy.Count, buffer1.Length - headerToCopy.Count))
      {
        byte[] numArray = new byte[length];
        for (int offset = dataToEncrypt.Offset; offset < dataToEncrypt.Offset + dataToEncrypt.Count; offset += length)
        {
          Array.Copy((Array) dataToEncrypt.Array, offset, (Array) numArray, 0, numArray.Length);
          byte[] buffer2 = rsaPublicKey.Encrypt(numArray, encryptionPadding);
          memoryStream.Write(buffer2, 0, buffer2.Length);
        }
      }
      return new ArraySegment<byte>(buffer1, 0, dataToEncrypt.Count / length * cipherTextBlockSize + headerToCopy.Count);
    }
  }

  private ArraySegment<byte> Rsa_Decrypt(
    ArraySegment<byte> dataToDecrypt,
    ArraySegment<byte> headerToCopy,
    X509Certificate2 encryptingCertificate,
    RsaUtils.Padding padding)
  {
    using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(encryptingCertificate))
    {
      int length = rsaPrivateKey != null ? RsaUtils.GetCipherTextBlockSize(rsaPrivateKey, padding) : throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No private key for certificate.");
      int plainTextBlockSize = RsaUtils.GetPlainTextBlockSize(rsaPrivateKey, padding);
      if (dataToDecrypt.Count % length != 0)
        Opc.Ua.Utils.LogWarning("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", (object) dataToDecrypt.Count, (object) length);
      byte[] buffer1 = this.BufferManager.TakeBuffer(this.SendBufferSize, nameof (Rsa_Decrypt));
      Array.Copy((Array) headerToCopy.Array, headerToCopy.Offset, (Array) buffer1, 0, headerToCopy.Count);
      RSAEncryptionPadding encryptionPadding = RsaUtils.GetRSAEncryptionPadding(padding);
      using (MemoryStream memoryStream = new MemoryStream(buffer1, headerToCopy.Count, buffer1.Length - headerToCopy.Count))
      {
        byte[] numArray = new byte[length];
        for (int offset = dataToDecrypt.Offset; offset < dataToDecrypt.Offset + dataToDecrypt.Count; offset += length)
        {
          Array.Copy((Array) dataToDecrypt.Array, offset, (Array) numArray, 0, numArray.Length);
          byte[] buffer2 = rsaPrivateKey.Decrypt(numArray, encryptionPadding);
          memoryStream.Write(buffer2, 0, buffer2.Length);
        }
      }
      return new ArraySegment<byte>(buffer1, 0, dataToDecrypt.Count / length * plainTextBlockSize + headerToCopy.Count);
    }
  }

  protected internal ChannelToken CurrentToken => this.m_currentToken;

  protected ChannelToken PreviousToken => this.m_previousToken;

  protected ChannelToken RenewedToken => this.m_renewedToken;

  protected ChannelToken CreateToken()
  {
    ChannelToken token = new ChannelToken();
    token.ChannelId = this.m_channelId;
    token.TokenId = 0U;
    token.CreatedAt = DateTime.UtcNow;
    token.Lifetime = this.Quotas.SecurityTokenLifetime;
    Opc.Ua.Utils.LogInfo("ChannelId {0}: Token #{1} created. CreatedAt={2:HH:mm:ss.fff}. Lifetime={3}.", (object) this.Id, (object) token.TokenId, (object) token.CreatedAt, (object) token.Lifetime);
    return token;
  }

  protected void ActivateToken(ChannelToken token)
  {
    this.ComputeKeys(token);
    this.m_previousToken = this.m_currentToken;
    this.m_currentToken = token;
    this.m_renewedToken = (ChannelToken) null;
    Opc.Ua.Utils.LogInfo("ChannelId {0}: Token #{1} activated. CreatedAt={2:HH:mm:ss.fff}. Lifetime={3}.", (object) this.Id, (object) token.TokenId, (object) token.CreatedAt, (object) token.Lifetime);
  }

  protected void SetRenewedToken(ChannelToken token)
  {
    this.m_renewedToken = token;
    Opc.Ua.Utils.LogInfo("ChannelId {0}: Renewed Token #{1} set. CreatedAt={2:HH:mm:ss.fff}. Lifetime ={3}.", (object) this.Id, (object) token.TokenId, (object) token.CreatedAt, (object) token.Lifetime);
  }

  protected void DiscardTokens()
  {
    this.m_previousToken = (ChannelToken) null;
    this.m_currentToken = (ChannelToken) null;
  }

  private int SymmetricSignatureSize => this.m_hmacHashSize;

  private int EncryptionBlockSize => this.m_encryptionBlockSize;

  protected void CalculateSymmetricKeySizes()
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        this.m_hmacHashSize = 20;
        this.m_signatureKeySize = 16 /*0x10*/;
        this.m_encryptionKeySize = 16 /*0x10*/;
        this.m_encryptionBlockSize = 16 /*0x10*/;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
        this.m_hmacHashSize = 20;
        this.m_signatureKeySize = 24;
        this.m_encryptionKeySize = 32 /*0x20*/;
        this.m_encryptionBlockSize = 16 /*0x10*/;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        this.m_hmacHashSize = 32 /*0x20*/;
        this.m_signatureKeySize = 32 /*0x20*/;
        this.m_encryptionKeySize = 32 /*0x20*/;
        this.m_encryptionBlockSize = 16 /*0x10*/;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
        this.m_hmacHashSize = 32 /*0x20*/;
        this.m_signatureKeySize = 32 /*0x20*/;
        this.m_encryptionKeySize = 16 /*0x10*/;
        this.m_encryptionBlockSize = 16 /*0x10*/;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        this.m_hmacHashSize = 32 /*0x20*/;
        this.m_signatureKeySize = 32 /*0x20*/;
        this.m_encryptionKeySize = 32 /*0x20*/;
        this.m_encryptionBlockSize = 16 /*0x10*/;
        break;
      default:
        this.m_hmacHashSize = 0;
        this.m_signatureKeySize = 0;
        this.m_encryptionKeySize = 0;
        this.m_encryptionBlockSize = 1;
        break;
    }
  }

  protected void ComputeKeys(ChannelToken token)
  {
    if (this.SecurityMode == MessageSecurityMode.None)
      return;
    if (!(this.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256") && !(this.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep") && !(this.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss"))
    {
      token.ClientSigningKey = Opc.Ua.Utils.PSHA1(token.ServerNonce, (string) null, token.ClientNonce, 0, this.m_signatureKeySize);
      token.ClientEncryptingKey = Opc.Ua.Utils.PSHA1(token.ServerNonce, (string) null, token.ClientNonce, this.m_signatureKeySize, this.m_encryptionKeySize);
      token.ClientInitializationVector = Opc.Ua.Utils.PSHA1(token.ServerNonce, (string) null, token.ClientNonce, this.m_signatureKeySize + this.m_encryptionKeySize, this.m_encryptionBlockSize);
      token.ServerSigningKey = Opc.Ua.Utils.PSHA1(token.ClientNonce, (string) null, token.ServerNonce, 0, this.m_signatureKeySize);
      token.ServerEncryptingKey = Opc.Ua.Utils.PSHA1(token.ClientNonce, (string) null, token.ServerNonce, this.m_signatureKeySize, this.m_encryptionKeySize);
      token.ServerInitializationVector = Opc.Ua.Utils.PSHA1(token.ClientNonce, (string) null, token.ServerNonce, this.m_signatureKeySize + this.m_encryptionKeySize, this.m_encryptionBlockSize);
    }
    else
    {
      token.ClientSigningKey = Opc.Ua.Utils.PSHA256(token.ServerNonce, (string) null, token.ClientNonce, 0, this.m_signatureKeySize);
      token.ClientEncryptingKey = Opc.Ua.Utils.PSHA256(token.ServerNonce, (string) null, token.ClientNonce, this.m_signatureKeySize, this.m_encryptionKeySize);
      token.ClientInitializationVector = Opc.Ua.Utils.PSHA256(token.ServerNonce, (string) null, token.ClientNonce, this.m_signatureKeySize + this.m_encryptionKeySize, this.m_encryptionBlockSize);
      token.ServerSigningKey = Opc.Ua.Utils.PSHA256(token.ClientNonce, (string) null, token.ServerNonce, 0, this.m_signatureKeySize);
      token.ServerEncryptingKey = Opc.Ua.Utils.PSHA256(token.ClientNonce, (string) null, token.ServerNonce, this.m_signatureKeySize, this.m_encryptionKeySize);
      token.ServerInitializationVector = Opc.Ua.Utils.PSHA256(token.ClientNonce, (string) null, token.ServerNonce, this.m_signatureKeySize + this.m_encryptionKeySize, this.m_encryptionBlockSize);
    }
    string securityPolicyUri = this.SecurityPolicyUri;
    if (!(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15") && !(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Basic256") && !(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256") && !(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep") && !(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss"))
    {
      int num = securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None" ? 1 : 0;
    }
    else
    {
      SymmetricAlgorithm symmetricAlgorithm1 = (SymmetricAlgorithm) Aes.Create();
      symmetricAlgorithm1.Mode = CipherMode.CBC;
      symmetricAlgorithm1.Padding = PaddingMode.None;
      symmetricAlgorithm1.Key = token.ClientEncryptingKey;
      symmetricAlgorithm1.IV = token.ClientInitializationVector;
      token.ClientEncryptor = symmetricAlgorithm1;
      SymmetricAlgorithm symmetricAlgorithm2 = (SymmetricAlgorithm) Aes.Create();
      symmetricAlgorithm2.Mode = CipherMode.CBC;
      symmetricAlgorithm2.Padding = PaddingMode.None;
      symmetricAlgorithm2.Key = token.ServerEncryptingKey;
      symmetricAlgorithm2.IV = token.ServerInitializationVector;
      token.ServerEncryptor = symmetricAlgorithm2;
      if (!(this.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256") && !(this.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep") && !(this.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss"))
      {
        token.ServerHmac = (HMAC) new HMACSHA1(token.ServerSigningKey);
        token.ClientHmac = (HMAC) new HMACSHA1(token.ClientSigningKey);
      }
      else
      {
        token.ServerHmac = (HMAC) new HMACSHA256(token.ServerSigningKey);
        token.ClientHmac = (HMAC) new HMACSHA256(token.ClientSigningKey);
      }
    }
  }

  protected BufferCollection WriteSymmetricMessage(
    uint messageType,
    uint requestId,
    ChannelToken token,
    object messageBody,
    bool isRequest,
    out bool limitsExceeded)
  {
    limitsExceeded = false;
    bool flag = false;
    BufferCollection bufferCollection1 = (BufferCollection) null;
    try
    {
      int count1 = (this.SendBufferSize - 16 /*0x10*/) / this.EncryptionBlockSize * this.EncryptionBlockSize - this.SymmetricSignatureSize - 1 - 8;
      int num1 = 24;
      ArraySegmentStream arraySegmentStream = new ArraySegmentStream(this.BufferManager, this.SendBufferSize, 24, count1);
      if (messageBody is IEncodeable message)
        BinaryEncoder.EncodeMessage(message, (Stream) arraySegmentStream, this.Quotas.MessageContext, true);
      ArraySegment<byte>? nullable = messageBody as ArraySegment<byte>?;
      if (nullable.HasValue)
      {
        using (BinaryEncoder binaryEncoder1 = new BinaryEncoder((Stream) arraySegmentStream, this.Quotas.MessageContext, true))
        {
          BinaryEncoder binaryEncoder2 = binaryEncoder1;
          ArraySegment<byte> arraySegment = nullable.Value;
          byte[] array = arraySegment.Array;
          arraySegment = nullable.Value;
          int offset = arraySegment.Offset;
          arraySegment = nullable.Value;
          int count2 = arraySegment.Count;
          binaryEncoder2.WriteRawBytes(array, offset, count2);
        }
      }
      bufferCollection1 = arraySegmentStream.GetBuffers(nameof (WriteSymmetricMessage));
      if (bufferCollection1.Count == 0)
      {
        byte[] buffer = this.BufferManager.TakeBuffer(this.SendBufferSize, nameof (WriteSymmetricMessage));
        bufferCollection1.Add(new ArraySegment<byte>(buffer, 0, 0));
      }
      BufferCollection bufferCollection2 = new BufferCollection(bufferCollection1.Capacity);
      int num2 = 0;
      for (int index1 = 0; index1 < bufferCollection1.Count; ++index1)
      {
        ArraySegment<byte> arraySegment = bufferCollection1[index1];
        if (limitsExceeded)
        {
          this.BufferManager.ReturnBuffer(arraySegment.Array, nameof (WriteSymmetricMessage));
        }
        else
        {
          MemoryStream memoryStream = new MemoryStream(arraySegment.Array, 0, this.SendBufferSize);
          BinaryEncoder binaryEncoder = new BinaryEncoder((Stream) memoryStream, this.Quotas.MessageContext, false);
          try
          {
            if (this.MessageLimitsExceeded(isRequest, num2 + arraySegment.Count - num1, index1 + 1))
            {
              binaryEncoder.WriteUInt32((string) null, messageType | 1090519040U /*0x41000000*/);
              BinaryEncoder encoder = new BinaryEncoder(arraySegment.Array, arraySegment.Offset, arraySegment.Count, this.Quotas.MessageContext);
              UaSCUaBinaryChannel.WriteErrorMessageBody(encoder, (ServiceResult) (isRequest ? 2159542272U /*0x80B80000*/ : 2159607808U /*0x80B90000*/));
              int count3 = encoder.Close();
              encoder.Dispose();
              arraySegment = new ArraySegment<byte>(arraySegment.Array, arraySegment.Offset, count3);
              limitsExceeded = true;
            }
            else if (index1 == bufferCollection1.Count - 1)
              binaryEncoder.WriteUInt32((string) null, messageType | 1174405120U /*0x46000000*/);
            else
              binaryEncoder.WriteUInt32((string) null, messageType | 1124073472U /*0x43000000*/);
            int num3 = 0;
            num3 = 8;
            int num4 = 8 + arraySegment.Count + this.SymmetricSignatureSize;
            int num5 = 0;
            if (this.SecurityMode == MessageSecurityMode.SignAndEncrypt)
            {
              int num6 = num4 + 1;
              if (num6 % this.EncryptionBlockSize != 0)
                num5 = this.EncryptionBlockSize - num6 % this.EncryptionBlockSize;
              num4 = num6 + num5;
            }
            int num7 = num4 + 16 /*0x10*/;
            binaryEncoder.WriteUInt32((string) null, (uint) num7);
            binaryEncoder.WriteUInt32((string) null, this.ChannelId);
            binaryEncoder.WriteUInt32((string) null, token.TokenId);
            uint newSequenceNumber = this.GetNewSequenceNumber();
            binaryEncoder.WriteUInt32((string) null, newSequenceNumber);
            binaryEncoder.WriteUInt32((string) null, requestId);
            memoryStream.Seek((long) arraySegment.Count, SeekOrigin.Current);
            num2 += arraySegment.Count;
            if (this.SecurityMode == MessageSecurityMode.SignAndEncrypt)
            {
              for (int index2 = 0; index2 <= num5; ++index2)
                binaryEncoder.WriteByte((string) null, (byte) num5);
            }
            if (this.SecurityMode != MessageSecurityMode.None)
            {
              byte[] buffer = this.Sign(token, new ArraySegment<byte>(arraySegment.Array, 0, binaryEncoder.Position), isRequest);
              if (buffer != null)
                binaryEncoder.WriteRawBytes(buffer, 0, buffer.Length);
            }
            if (this.SecurityMode == MessageSecurityMode.SignAndEncrypt)
            {
              ArraySegment<byte> dataToEncrypt = new ArraySegment<byte>(arraySegment.Array, 16 /*0x10*/, binaryEncoder.Position - 16 /*0x10*/);
              this.Encrypt(token, dataToEncrypt, isRequest);
            }
            bufferCollection2.Add(new ArraySegment<byte>(arraySegment.Array, 0, binaryEncoder.Position));
          }
          finally
          {
            binaryEncoder.Dispose();
          }
        }
      }
      flag = true;
      return bufferCollection2;
    }
    finally
    {
      if (!flag && bufferCollection1 != null)
        bufferCollection1.Release(this.BufferManager, nameof (WriteSymmetricMessage));
    }
  }

  protected ArraySegment<byte> ReadSymmetricMessage(
    ArraySegment<byte> buffer,
    bool isRequest,
    out ChannelToken token,
    out uint requestId,
    out uint sequenceNumber)
  {
    BinaryDecoder binaryDecoder = new BinaryDecoder(buffer.Array, buffer.Offset, buffer.Count, this.Quotas.MessageContext);
    int num1 = (int) binaryDecoder.ReadUInt32((string) null);
    int num2 = (int) binaryDecoder.ReadUInt32((string) null);
    uint num3 = binaryDecoder.ReadUInt32((string) null);
    uint num4 = binaryDecoder.ReadUInt32((string) null);
    if ((int) num3 != (int) this.ChannelId)
      throw ServiceResultException.Create(2155806720U /*0x807F0000*/, "SecureChannelId is not known. ChanneId={0}, CurrentChannelId={1}", (object) num3, (object) this.ChannelId);
    if (this.RenewedToken != null && (int) this.RenewedToken.TokenId == (int) num4)
      this.ActivateToken(this.RenewedToken);
    if (this.RenewedToken != null && this.CurrentToken.ActivationRequired)
    {
      this.ActivateToken(this.RenewedToken);
      Opc.Ua.Utils.LogInfo("ChannelId {0}: Token #{1} activated forced.", (object) this.Id, (object) this.CurrentToken.TokenId);
    }
    ChannelToken currentToken = this.CurrentToken;
    if (currentToken == null)
      throw new ServiceResultException(2156265472U /*0x80860000*/);
    if ((int) currentToken.TokenId != (int) num4 && this.PreviousToken != null && (int) this.PreviousToken.TokenId != (int) num4)
      throw ServiceResultException.Create(2155806720U /*0x807F0000*/, "Channel{0}: TokenId is not known. ChanneId={1}, TokenId={2}, CurrentTokenId={3}, PreviousTokenId={4}", (object) this.Id, (object) num3, (object) num4, (object) currentToken.TokenId, (object) (this.PreviousToken != null ? (int) this.PreviousToken.TokenId : -1));
    token = currentToken;
    if (this.PreviousToken != null && (int) this.PreviousToken.TokenId == (int) num4)
      token = this.PreviousToken;
    if (token.Expired)
      throw ServiceResultException.Create(2155806720U /*0x807F0000*/, "Channel{0}: Token #{1} has expired. Lifetime={2:HH:mm:ss.fff}", (object) this.Id, (object) token.TokenId, (object) token.CreatedAt);
    int position = binaryDecoder.Position;
    if (this.SecurityMode == MessageSecurityMode.SignAndEncrypt)
      this.Decrypt(token, new ArraySegment<byte>(buffer.Array, buffer.Offset + position, buffer.Count - position), isRequest);
    if (this.SecurityMode != MessageSecurityMode.None)
    {
      byte[] signature = new byte[this.SymmetricSignatureSize];
      for (int index = 0; index < this.SymmetricSignatureSize; ++index)
        signature[index] = buffer.Array[buffer.Offset + buffer.Count - this.SymmetricSignatureSize + index];
      if (!this.Verify(token, signature, new ArraySegment<byte>(buffer.Array, buffer.Offset, buffer.Count - this.SymmetricSignatureSize), isRequest))
      {
        Opc.Ua.Utils.LogError("ChannelId {0}: Could not verify signature on message.", (object) this.Id);
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Could not verify the signature on the message.");
      }
    }
    int num5 = 0;
    if (this.SecurityMode == MessageSecurityMode.SignAndEncrypt)
    {
      int index1 = buffer.Offset + buffer.Count - this.SymmetricSignatureSize - 1;
      int num6 = (int) buffer.Array[index1];
      for (int index2 = index1 - num6; index2 < index1; ++index2)
      {
        if ((int) buffer.Array[index2] != num6)
          throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Could not verify the padding in the message.");
      }
      num5 = num6 + 1;
    }
    sequenceNumber = binaryDecoder.ReadUInt32((string) null);
    requestId = binaryDecoder.ReadUInt32((string) null);
    int offset = buffer.Offset + 16 /*0x10*/ + 8;
    int count = buffer.Count - 16 /*0x10*/ - 8 - num5 - this.SymmetricSignatureSize;
    return new ArraySegment<byte>(buffer.Array, offset, count);
  }

  protected byte[] Sign(ChannelToken token, ArraySegment<byte> dataToSign, bool useClientKeys)
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        return UaSCUaBinaryChannel.SymmetricSign(token, dataToSign, useClientKeys);
      default:
        return (byte[]) null;
    }
  }

  protected bool Verify(
    ChannelToken token,
    byte[] signature,
    ArraySegment<byte> dataToVerify,
    bool useClientKeys)
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#None":
        return true;
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        return this.SymmetricVerify(token, signature, dataToVerify, useClientKeys);
      default:
        return false;
    }
  }

  protected void Encrypt(ChannelToken token, ArraySegment<byte> dataToEncrypt, bool useClientKeys)
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        UaSCUaBinaryChannel.SymmetricEncrypt(token, dataToEncrypt, useClientKeys);
        break;
    }
  }

  protected void Decrypt(ChannelToken token, ArraySegment<byte> dataToDecrypt, bool useClientKeys)
  {
    switch (this.SecurityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        UaSCUaBinaryChannel.SymmetricDecrypt(token, dataToDecrypt, useClientKeys);
        break;
    }
  }

  private static byte[] SymmetricSign(
    ChannelToken token,
    ArraySegment<byte> dataToSign,
    bool useClientKeys)
  {
    HMAC hmac = useClientKeys ? token.ClientHmac : token.ServerHmac;
    MemoryStream memoryStream = new MemoryStream(dataToSign.Array, dataToSign.Offset, dataToSign.Count, false);
    MemoryStream inputStream = memoryStream;
    byte[] hash = hmac.ComputeHash((Stream) inputStream);
    memoryStream.Dispose();
    return hash;
  }

  private bool SymmetricVerify(
    ChannelToken token,
    byte[] signature,
    ArraySegment<byte> dataToVerify,
    bool useClientKeys)
  {
    HMAC hmac = useClientKeys ? token.ClientHmac : token.ServerHmac;
    MemoryStream memoryStream = new MemoryStream(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, false);
    MemoryStream inputStream = memoryStream;
    byte[] hash = hmac.ComputeHash((Stream) inputStream);
    memoryStream.Dispose();
    for (int index = 0; index < signature.Length; ++index)
    {
      if ((int) hash[index] != (int) signature[index])
      {
        string str = Encoding.UTF8.GetString(dataToVerify.Array, dataToVerify.Offset, 4);
        int int32 = BitConverter.ToInt32(dataToVerify.Array, dataToVerify.Offset + 4);
        string hexString1 = Opc.Ua.Utils.ToHexString(hash);
        string hexString2 = Opc.Ua.Utils.ToHexString(signature);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Channel{0}: Could not validate signature.");
        stringBuilder.AppendLine("ChannelId={1}, TokenId={2}, MessageType={3}, Length={4}");
        stringBuilder.AppendLine("ExpectedSignature={5}");
        stringBuilder.AppendLine("ActualSignature={6}");
        Opc.Ua.Utils.LogError(stringBuilder.ToString(), (object) this.Id, (object) token.ChannelId, (object) token.TokenId, (object) str, (object) int32, (object) hexString1, (object) hexString2);
        return false;
      }
    }
    return true;
  }

  private static void SymmetricEncrypt(
    ChannelToken token,
    ArraySegment<byte> dataToEncrypt,
    bool useClientKeys)
  {
    SymmetricAlgorithm symmetricAlgorithm;
    if (!useClientKeys)
    {
      SymmetricAlgorithm serverEncryptor = token.ServerEncryptor;
      if (serverEncryptor == null)
      {
        symmetricAlgorithm = serverEncryptor;
      }
      else
      {
        symmetricAlgorithm = serverEncryptor;
        goto label_4;
      }
    }
    else
    {
      symmetricAlgorithm = token.ClientEncryptor;
      if (symmetricAlgorithm != null)
        goto label_4;
    }
    throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Token missing symmetric key object.");
label_4:
    using (ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor())
    {
      byte[] array = dataToEncrypt.Array;
      int offset = dataToEncrypt.Offset;
      int count = dataToEncrypt.Count;
      if (count % encryptor.InputBlockSize != 0)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Input data is not an even number of encryption blocks.");
      encryptor.TransformBlock(array, offset, count, array, offset);
    }
  }

  private static void SymmetricDecrypt(
    ChannelToken token,
    ArraySegment<byte> dataToDecrypt,
    bool useClientKeys)
  {
    SymmetricAlgorithm symmetricAlgorithm;
    if (!useClientKeys)
    {
      SymmetricAlgorithm serverEncryptor = token.ServerEncryptor;
      if (serverEncryptor == null)
      {
        symmetricAlgorithm = serverEncryptor;
      }
      else
      {
        symmetricAlgorithm = serverEncryptor;
        goto label_4;
      }
    }
    else
    {
      symmetricAlgorithm = token.ClientEncryptor;
      if (symmetricAlgorithm != null)
        goto label_4;
    }
    throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Token missing symmetric key object.");
label_4:
    using (ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor())
    {
      byte[] array = dataToDecrypt.Array;
      int offset = dataToDecrypt.Offset;
      int count = dataToDecrypt.Count;
      if (count % decryptor.InputBlockSize != 0)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Input data is not an even number of encryption blocks.");
      decryptor.TransformBlock(array, offset, count, array, offset);
    }
  }

  protected class WriteOperation(int timeout, AsyncCallback callback, object asyncState) : 
    ChannelAsyncOperation<int>(timeout, callback, asyncState)
  {
    private uint m_requestId;
    private IEncodeable m_messageBody;

    public uint RequestId
    {
      get => this.m_requestId;
      set => this.m_requestId = value;
    }

    public IEncodeable MessageBody
    {
      get => this.m_messageBody;
      set => this.m_messageBody = value;
    }
  }
}
