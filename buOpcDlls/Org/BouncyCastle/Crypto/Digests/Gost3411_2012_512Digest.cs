// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Gost3411_2012_512Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class Gost3411_2012_512Digest : Gost3411_2012Digest
{
  private static readonly byte[] IV = new byte[64 /*0x40*/];

  public override string AlgorithmName => "GOST3411-2012-512";

  public Gost3411_2012_512Digest()
    : base(Gost3411_2012_512Digest.IV)
  {
  }

  public Gost3411_2012_512Digest(Gost3411_2012_512Digest other)
    : base(Gost3411_2012_512Digest.IV)
  {
    this.Reset((IMemoable) other);
  }

  public override int GetDigestSize() => 64 /*0x40*/;

  public override IMemoable Copy() => (IMemoable) new Gost3411_2012_512Digest(this);
}
