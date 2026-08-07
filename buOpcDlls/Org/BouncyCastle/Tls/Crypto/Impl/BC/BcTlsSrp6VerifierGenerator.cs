// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsSrp6VerifierGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Agreement.Srp;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsSrp6VerifierGenerator : TlsSrp6VerifierGenerator
{
  private readonly Srp6VerifierGenerator m_srp6VerifierGenerator;

  internal BcTlsSrp6VerifierGenerator(Srp6VerifierGenerator srp6VerifierGenerator)
  {
    this.m_srp6VerifierGenerator = srp6VerifierGenerator;
  }

  public BigInteger GenerateVerifier(byte[] salt, byte[] identity, byte[] password)
  {
    return this.m_srp6VerifierGenerator.GenerateVerifier(salt, identity, password);
  }
}
