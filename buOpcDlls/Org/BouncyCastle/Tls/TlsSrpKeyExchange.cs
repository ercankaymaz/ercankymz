// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsSrpKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsSrpKeyExchange : AbstractTlsKeyExchange
{
  protected TlsSrpIdentity m_srpIdentity;
  protected TlsSrpConfigVerifier m_srpConfigVerifier;
  protected TlsCertificate m_serverCertificate;
  protected byte[] m_srpSalt;
  protected TlsSrp6Client m_srpClient;
  protected TlsSrpLoginParameters m_srpLoginParameters;
  protected TlsCredentialedSigner m_serverCredentials;
  protected TlsSrp6Server m_srpServer;
  protected BigInteger m_srpPeerCredentials;

  private static int CheckKeyExchange(int keyExchange)
  {
    switch (keyExchange)
    {
      case 21:
      case 22:
      case 23:
        return keyExchange;
      default:
        throw new ArgumentException("unsupported key exchange algorithm", nameof (keyExchange));
    }
  }

  public TlsSrpKeyExchange(
    int keyExchange,
    TlsSrpIdentity srpIdentity,
    TlsSrpConfigVerifier srpConfigVerifier)
    : base(TlsSrpKeyExchange.CheckKeyExchange(keyExchange))
  {
    this.m_srpIdentity = srpIdentity;
    this.m_srpConfigVerifier = srpConfigVerifier;
  }

  public TlsSrpKeyExchange(int keyExchange, TlsSrpLoginParameters srpLoginParameters)
    : base(TlsSrpKeyExchange.CheckKeyExchange(keyExchange))
  {
    this.m_srpLoginParameters = srpLoginParameters;
  }

  public override void SkipServerCredentials()
  {
    if (this.m_keyExchange != 21)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public override void ProcessServerCredentials(TlsCredentials serverCredentials)
  {
    if (this.m_keyExchange == 21)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_serverCredentials = TlsUtilities.RequireSignerCredentials(serverCredentials);
  }

  public override void ProcessServerCertificate(Certificate serverCertificate)
  {
    if (this.m_keyExchange == 21)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_serverCertificate = serverCertificate.GetCertificateAt(0);
  }

  public override bool RequiresServerKeyExchange => true;

  public override byte[] GenerateServerKeyExchange()
  {
    TlsSrpConfig config = this.m_srpLoginParameters.Config;
    this.m_srpServer = this.m_context.Crypto.CreateSrp6Server(config, this.m_srpLoginParameters.Verifier);
    BigInteger serverCredentials = this.m_srpServer.GenerateServerCredentials();
    BigInteger[] explicitNg = config.GetExplicitNG();
    ServerSrpParams serverSrpParams = new ServerSrpParams(explicitNg[0], explicitNg[1], this.m_srpLoginParameters.Salt, serverCredentials);
    DigestInputBuffer digestBuffer = new DigestInputBuffer();
    DigestInputBuffer output = digestBuffer;
    serverSrpParams.Encode((Stream) output);
    if (this.m_serverCredentials != null)
      TlsUtilities.GenerateServerKeyExchangeSignature(this.m_context, this.m_serverCredentials, (byte[]) null, digestBuffer);
    return digestBuffer.ToArray();
  }

  public override void ProcessServerKeyExchange(Stream input)
  {
    DigestInputBuffer digestInputBuffer = (DigestInputBuffer) null;
    Stream input1 = input;
    if (this.m_keyExchange != 21)
    {
      digestInputBuffer = new DigestInputBuffer();
      input1 = (Stream) new TeeInputStream(input, (Stream) digestInputBuffer);
    }
    ServerSrpParams serverSrpParams = ServerSrpParams.Parse(input1);
    if (digestInputBuffer != null)
      TlsUtilities.VerifyServerKeyExchangeSignature(this.m_context, input, this.m_serverCertificate, (byte[]) null, digestInputBuffer);
    TlsSrpConfig srpConfig = new TlsSrpConfig();
    srpConfig.SetExplicitNG(new BigInteger[2]
    {
      serverSrpParams.N,
      serverSrpParams.G
    });
    if (!this.m_srpConfigVerifier.Accept(srpConfig))
      throw new TlsFatalAlert((short) 71);
    this.m_srpSalt = serverSrpParams.S;
    this.m_srpPeerCredentials = TlsSrpKeyExchange.ValidatePublicValue(serverSrpParams.N, serverSrpParams.B);
    this.m_srpClient = this.m_context.Crypto.CreateSrp6Client(srpConfig);
  }

  public override void ProcessClientCredentials(TlsCredentials clientCredentials)
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public override void GenerateClientKeyExchange(Stream output)
  {
    byte[] srpIdentity = this.m_srpIdentity.GetSrpIdentity();
    byte[] srpPassword = this.m_srpIdentity.GetSrpPassword();
    TlsSrpUtilities.WriteSrpParameter(this.m_srpClient.GenerateClientCredentials(this.m_srpSalt, srpIdentity, srpPassword), output);
    this.m_context.SecurityParameters.m_srpIdentity = Arrays.Clone(srpIdentity);
  }

  public override void ProcessClientKeyExchange(Stream input)
  {
    this.m_srpPeerCredentials = TlsSrpKeyExchange.ValidatePublicValue(this.m_srpLoginParameters.Config.GetExplicitNG()[0], TlsSrpUtilities.ReadSrpParameter(input));
    this.m_context.SecurityParameters.m_srpIdentity = Arrays.Clone(this.m_srpLoginParameters.Identity);
  }

  public override TlsSecret GeneratePreMasterSecret()
  {
    return this.m_context.Crypto.CreateSecret(BigIntegers.AsUnsignedByteArray(this.m_srpServer != null ? this.m_srpServer.CalculateSecret(this.m_srpPeerCredentials) : this.m_srpClient.CalculateSecret(this.m_srpPeerCredentials)));
  }

  protected static BigInteger ValidatePublicValue(BigInteger N, BigInteger val)
  {
    val = val.Mod(N);
    return !val.Equals(BigInteger.Zero) ? val : throw new TlsFatalAlert((short) 47);
  }
}
