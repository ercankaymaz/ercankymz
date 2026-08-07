// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.Srp.Srp6VerifierGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.Srp;

public class Srp6VerifierGenerator
{
  protected BigInteger N;
  protected BigInteger g;
  protected IDigest digest;

  public virtual void Init(BigInteger N, BigInteger g, IDigest digest)
  {
    this.N = N;
    this.g = g;
    this.digest = digest;
  }

  public virtual void Init(Srp6GroupParameters group, IDigest digest)
  {
    this.Init(group.N, group.G, digest);
  }

  public virtual BigInteger GenerateVerifier(byte[] salt, byte[] identity, byte[] password)
  {
    return this.g.ModPow(Srp6Utilities.CalculateX(this.digest, this.N, salt, identity, password), this.N);
  }
}
