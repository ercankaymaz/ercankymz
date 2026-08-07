// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DefaultTlsClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class DefaultTlsClient : AbstractTlsClient
{
  private static readonly int[] DefaultCipherSuites = new int[17]
  {
    4867,
    4865,
    52393,
    49195,
    49187,
    49161,
    52392,
    49199,
    49191,
    49171,
    52394,
    158,
    103,
    51,
    156,
    60,
    47
  };

  public DefaultTlsClient(TlsCrypto crypto)
    : base(crypto)
  {
  }

  protected override int[] GetSupportedCipherSuites()
  {
    return TlsUtilities.GetSupportedCipherSuites(this.Crypto, DefaultTlsClient.DefaultCipherSuites);
  }
}
