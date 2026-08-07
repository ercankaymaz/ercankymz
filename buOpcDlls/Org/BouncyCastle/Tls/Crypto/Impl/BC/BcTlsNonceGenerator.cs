// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsNonceGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Prng;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsNonceGenerator : TlsNonceGenerator
{
  private readonly IRandomGenerator m_randomGenerator;

  internal BcTlsNonceGenerator(IRandomGenerator randomGenerator)
  {
    this.m_randomGenerator = randomGenerator;
  }

  public byte[] GenerateNonce(int size)
  {
    byte[] bytes = new byte[size];
    this.m_randomGenerator.NextBytes(bytes);
    return bytes;
  }
}
