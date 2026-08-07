// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.SkeinDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class SkeinDigest : IDigest, IMemoable
{
  public const int SKEIN_256 = 256 /*0x0100*/;
  public const int SKEIN_512 = 512 /*0x0200*/;
  public const int SKEIN_1024 = 1024 /*0x0400*/;
  private readonly SkeinEngine engine;

  public SkeinDigest(int stateSizeBits, int digestSizeBits)
  {
    this.engine = new SkeinEngine(stateSizeBits, digestSizeBits);
    this.Init((SkeinParameters) null);
  }

  public SkeinDigest(SkeinDigest digest) => this.engine = new SkeinEngine(digest.engine);

  public void Reset(IMemoable other) => this.engine.Reset((IMemoable) ((SkeinDigest) other).engine);

  public IMemoable Copy() => (IMemoable) new SkeinDigest(this);

  public string AlgorithmName
  {
    get
    {
      int num = this.engine.BlockSize * 8;
      string str1 = num.ToString();
      num = this.engine.OutputSize * 8;
      string str2 = num.ToString();
      return $"Skein-{str1}-{str2}";
    }
  }

  public int GetDigestSize() => this.engine.OutputSize;

  public int GetByteLength() => this.engine.BlockSize;

  public void Init(SkeinParameters parameters) => this.engine.Init(parameters);

  public void Reset() => this.engine.Reset();

  public void Update(byte inByte) => this.engine.Update(inByte);

  public void BlockUpdate(byte[] inBytes, int inOff, int len)
  {
    this.engine.BlockUpdate(inBytes, inOff, len);
  }

  public int DoFinal(byte[] outBytes, int outOff) => this.engine.DoFinal(outBytes, outOff);
}
