// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.AbstractTlsContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using System;
using System.Threading;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal abstract class AbstractTlsContext : TlsContext
{
  private static long counter = DateTime.UtcNow.Ticks;
  private readonly TlsCrypto m_crypto;
  private readonly int m_connectionEnd;
  private readonly TlsNonceGenerator m_nonceGenerator;
  private SecurityParameters m_securityParameters;
  private ProtocolVersion[] m_clientSupportedVersions;
  private ProtocolVersion m_clientVersion;
  private ProtocolVersion m_rsaPreMasterSecretVersion;
  private TlsSession m_session;
  private object m_userObject;
  private bool m_connected;

  private static long NextCounterValue() => Interlocked.Increment(ref AbstractTlsContext.counter);

  private static TlsNonceGenerator CreateNonceGenerator(TlsCrypto crypto, int connectionEnd)
  {
    byte[] numArray = new byte[16 /*0x10*/];
    Pack.UInt64_To_BE((ulong) AbstractTlsContext.NextCounterValue(), numArray, 0);
    Pack.UInt64_To_BE((ulong) DateTime.UtcNow.Ticks, numArray, 8);
    numArray[0] &= (byte) 127 /*0x7F*/;
    numArray[0] |= (byte) (connectionEnd << 7);
    return crypto.CreateNonceGenerator(numArray);
  }

  internal AbstractTlsContext(TlsCrypto crypto, int connectionEnd)
  {
    this.m_crypto = crypto;
    this.m_connectionEnd = connectionEnd;
    this.m_nonceGenerator = AbstractTlsContext.CreateNonceGenerator(crypto, connectionEnd);
  }

  internal void HandshakeBeginning(TlsPeer peer)
  {
    lock (this)
    {
      this.m_securityParameters = this.m_securityParameters == null ? new SecurityParameters() : throw new TlsFatalAlert((short) 80 /*0x50*/, "Handshake already started");
      this.m_securityParameters.m_entity = this.m_connectionEnd;
    }
    peer.NotifyHandshakeBeginning();
  }

  internal void HandshakeComplete(TlsPeer peer, TlsSession session)
  {
    lock (this)
    {
      if (this.m_securityParameters == null)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      this.m_session = session;
      this.m_connected = true;
    }
    peer.NotifyHandshakeComplete();
  }

  internal bool IsConnected
  {
    get
    {
      lock (this)
        return this.m_connected;
    }
  }

  internal bool IsHandshaking
  {
    get
    {
      lock (this)
        return !this.m_connected && this.m_securityParameters != null;
    }
  }

  public TlsCrypto Crypto => this.m_crypto;

  public virtual TlsNonceGenerator NonceGenerator => this.m_nonceGenerator;

  public SecurityParameters SecurityParameters
  {
    get
    {
      lock (this)
        return this.m_securityParameters;
    }
  }

  public abstract bool IsServer { get; }

  public virtual ProtocolVersion[] ClientSupportedVersions => this.m_clientSupportedVersions;

  internal void SetClientSupportedVersions(ProtocolVersion[] clientSupportedVersions)
  {
    this.m_clientSupportedVersions = clientSupportedVersions;
  }

  public virtual ProtocolVersion ClientVersion => this.m_clientVersion;

  internal void SetClientVersion(ProtocolVersion clientVersion)
  {
    this.m_clientVersion = clientVersion;
  }

  public virtual ProtocolVersion RsaPreMasterSecretVersion => this.m_rsaPreMasterSecretVersion;

  internal void SetRsaPreMasterSecretVersion(ProtocolVersion rsaPreMasterSecretVersion)
  {
    this.m_rsaPreMasterSecretVersion = rsaPreMasterSecretVersion;
  }

  public virtual ProtocolVersion ServerVersion => this.SecurityParameters.NegotiatedVersion;

  public virtual TlsSession ResumableSession
  {
    get
    {
      TlsSession session = this.Session;
      return session != null && session.IsResumable ? session : (TlsSession) null;
    }
  }

  public virtual TlsSession Session => this.m_session;

  public virtual object UserObject
  {
    get => this.m_userObject;
    set => this.m_userObject = value;
  }

  public virtual byte[] ExportChannelBinding(int channelBinding)
  {
    if (!this.IsConnected)
      throw new InvalidOperationException("Export of channel bindings unavailable before handshake completion");
    SecurityParameters securityParameters = this.SecurityParameters;
    if (3 == channelBinding)
      return this.ExportKeyingMaterial("EXPORTER-Channel-Binding", TlsUtilities.EmptyBytes, 32 /*0x20*/);
    if (TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
      return (byte[]) null;
    switch (channelBinding)
    {
      case 0:
        byte[] tlsServerEndPoint = securityParameters.TlsServerEndPoint;
        return !TlsUtilities.IsNullOrEmpty<byte>(tlsServerEndPoint) ? Arrays.Clone(tlsServerEndPoint) : (byte[]) null;
      case 1:
        return Arrays.Clone(securityParameters.TlsUnique);
      default:
        throw new NotSupportedException();
    }
  }

  public virtual byte[] ExportEarlyKeyingMaterial(string asciiLabel, byte[] context, int length)
  {
    if (!this.IsConnected)
      throw new InvalidOperationException("Export of early key material only available during handshake");
    SecurityParameters securityParameters = this.SecurityParameters;
    return this.ExportKeyingMaterial13(this.CheckEarlyExportSecret(securityParameters.EarlyExporterMasterSecret), securityParameters.PrfCryptoHashAlgorithm, asciiLabel, context, length);
  }

  public virtual byte[] ExportKeyingMaterial(string asciiLabel, byte[] context, int length)
  {
    if (!this.IsConnected)
      throw new InvalidOperationException("Export of key material unavailable before handshake completion");
    SecurityParameters securityParameters = this.SecurityParameters;
    if (!securityParameters.IsExtendedMasterSecret)
      throw new InvalidOperationException("Export of key material requires extended_master_secret");
    if (TlsUtilities.IsTlsV13(securityParameters.NegotiatedVersion))
      return this.ExportKeyingMaterial13(this.CheckExportSecret(securityParameters.ExporterMasterSecret), securityParameters.PrfCryptoHashAlgorithm, asciiLabel, context, length);
    byte[] exporterSeed = TlsUtilities.CalculateExporterSeed(securityParameters, context);
    return TlsUtilities.Prf(securityParameters, this.CheckExportSecret(securityParameters.MasterSecret), asciiLabel, exporterSeed, length).Extract();
  }

  protected virtual byte[] ExportKeyingMaterial13(
    TlsSecret secret,
    int cryptoHashAlgorithm,
    string asciiLabel,
    byte[] context,
    int length)
  {
    if (context == null)
      context = TlsUtilities.EmptyBytes;
    else if (!TlsUtilities.IsValidUint16(context.Length))
      throw new ArgumentException("must have length less than 2^16 (or be null)", nameof (context));
    TlsHash hash1 = this.Crypto.CreateHash(cryptoHashAlgorithm);
    byte[] hash2 = hash1.CalculateHash();
    TlsSecret secret1 = TlsUtilities.DeriveSecret(this.SecurityParameters, secret, asciiLabel, hash2);
    byte[] numArray = hash2;
    if (context.Length != 0)
    {
      hash1.Update(context, 0, context.Length);
      numArray = hash1.CalculateHash();
    }
    int cryptoHashAlgorithm1 = cryptoHashAlgorithm;
    byte[] context1 = numArray;
    int length1 = length;
    return TlsCryptoUtilities.HkdfExpandLabel(secret1, cryptoHashAlgorithm1, "exporter", context1, length1).Extract();
  }

  protected virtual TlsSecret CheckEarlyExportSecret(TlsSecret secret)
  {
    return secret != null ? secret : throw new InvalidOperationException("Export of early key material not available for this handshake");
  }

  protected virtual TlsSecret CheckExportSecret(TlsSecret secret)
  {
    return secret != null ? secret : throw new InvalidOperationException("Export of key material only available from NotifyHandshakeComplete()");
  }
}
