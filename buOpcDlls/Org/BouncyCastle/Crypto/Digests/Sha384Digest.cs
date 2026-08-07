// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Sha384Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class Sha384Digest : LongDigest
{
  private const int DigestLength = 48 /*0x30*/;

  public Sha384Digest()
  {
  }

  public Sha384Digest(Sha384Digest t)
    : base((LongDigest) t)
  {
  }

  public override string AlgorithmName => "SHA-384";

  public override int GetDigestSize() => 48 /*0x30*/;

  public override int DoFinal(byte[] output, int outOff)
  {
    this.Finish();
    Pack.UInt64_To_BE(this.H1, output, outOff);
    Pack.UInt64_To_BE(this.H2, output, outOff + 8);
    Pack.UInt64_To_BE(this.H3, output, outOff + 16 /*0x10*/);
    Pack.UInt64_To_BE(this.H4, output, outOff + 24);
    Pack.UInt64_To_BE(this.H5, output, outOff + 32 /*0x20*/);
    Pack.UInt64_To_BE(this.H6, output, outOff + 40);
    this.Reset();
    return 48 /*0x30*/;
  }

  public override void Reset()
  {
    base.Reset();
    this.H1 = 14680500436340154072UL;
    this.H2 = 7105036623409894663UL;
    this.H3 = 10473403895298186519UL;
    this.H4 = 1526699215303891257UL;
    this.H5 = 7436329637833083697UL;
    this.H6 = 10282925794625328401UL;
    this.H7 = 15784041429090275239UL;
    this.H8 = 5167115440072839076UL;
  }

  public override IMemoable Copy() => (IMemoable) new Sha384Digest(this);

  public override void Reset(IMemoable other) => this.CopyIn((LongDigest) other);
}
