// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.PskTlsClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class PskTlsClient : AbstractTlsClient
{
  private static readonly int[] DefaultCipherSuites = new int[7]
  {
    52396,
    49207,
    49205,
    52397,
    170,
    178,
    144 /*0x90*/
  };
  protected readonly TlsPskIdentity m_pskIdentity;

  public PskTlsClient(TlsCrypto crypto, byte[] identity, byte[] psk)
    : this(crypto, (TlsPskIdentity) new BasicTlsPskIdentity(identity, psk))
  {
  }

  public PskTlsClient(TlsCrypto crypto, TlsPskIdentity pskIdentity)
    : base(crypto)
  {
    this.m_pskIdentity = pskIdentity;
  }

  protected override ProtocolVersion[] GetSupportedVersions() => ProtocolVersion.TLSv12.Only();

  protected override int[] GetSupportedCipherSuites()
  {
    return TlsUtilities.GetSupportedCipherSuites(this.Crypto, PskTlsClient.DefaultCipherSuites);
  }

  public override TlsPskIdentity GetPskIdentity() => this.m_pskIdentity;

  public override TlsAuthentication GetAuthentication()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }
}
