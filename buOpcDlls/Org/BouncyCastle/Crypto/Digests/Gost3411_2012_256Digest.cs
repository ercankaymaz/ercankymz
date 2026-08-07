// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Gost3411_2012_256Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class Gost3411_2012_256Digest : Gost3411_2012Digest
{
  private static readonly byte[] IV = new byte[64 /*0x40*/]
  {
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1
  };

  public override string AlgorithmName => "GOST3411-2012-256";

  public Gost3411_2012_256Digest()
    : base(Gost3411_2012_256Digest.IV)
  {
  }

  public Gost3411_2012_256Digest(Gost3411_2012_256Digest other)
    : base(Gost3411_2012_256Digest.IV)
  {
    this.Reset((IMemoable) other);
  }

  public override int GetDigestSize() => 32 /*0x20*/;

  public override int DoFinal(byte[] output, int outOff)
  {
    byte[] numArray = new byte[64 /*0x40*/];
    base.DoFinal(numArray, 0);
    Array.Copy((Array) numArray, 32 /*0x20*/, (Array) output, outOff, 32 /*0x20*/);
    return 32 /*0x20*/;
  }

  public override IMemoable Copy() => (IMemoable) new Gost3411_2012_256Digest(this);
}
