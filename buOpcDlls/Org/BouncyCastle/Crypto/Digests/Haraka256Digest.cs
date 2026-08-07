// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Haraka256Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class Haraka256Digest : HarakaBase
{
  private readonly byte[] m_buf;
  private int m_bufPos;

  public Haraka256Digest()
  {
    this.m_buf = new byte[32 /*0x20*/];
    this.m_bufPos = 0;
  }

  public override string AlgorithmName => "Haraka-256";

  public override int GetByteLength() => 32 /*0x20*/;

  public override void Update(byte input)
  {
    this.m_buf[this.m_bufPos++] = this.m_bufPos <= 31 /*0x1F*/ ? input : throw new ArgumentException("total input cannot be more than 32 bytes");
  }

  public override void BlockUpdate(byte[] input, int inOff, int len)
  {
    if (this.m_bufPos > 32 /*0x20*/ - len)
      throw new ArgumentException("total input cannot be more than 32 bytes");
    Array.Copy((Array) input, inOff, (Array) this.m_buf, this.m_bufPos, len);
    this.m_bufPos += len;
  }

  public override int DoFinal(byte[] output, int outOff)
  {
    if (this.m_bufPos != 32 /*0x20*/)
      throw new ArgumentException("input must be exactly 32 bytes");
    if (output.Length - outOff < 32 /*0x20*/)
      throw new ArgumentException("output too short to receive digest");
    int num = Haraka256Digest.Haraka256256(this.m_buf, output, outOff);
    this.Reset();
    return num;
  }

  public override void Reset()
  {
    this.m_bufPos = 0;
    Array.Clear((Array) this.m_buf, 0, 32 /*0x20*/);
  }

  private static int Haraka256256(byte[] msg, byte[] output, int outOff)
  {
    byte[][] s1 = new byte[2][]
    {
      new byte[16 /*0x10*/],
      new byte[16 /*0x10*/]
    };
    byte[][] s2 = new byte[2][]
    {
      new byte[16 /*0x10*/],
      new byte[16 /*0x10*/]
    };
    Array.Copy((Array) msg, 0, (Array) s1[0], 0, 16 /*0x10*/);
    Array.Copy((Array) msg, 16 /*0x10*/, (Array) s1[1], 0, 16 /*0x10*/);
    s1[0] = HarakaBase.AesEnc(s1[0], HarakaBase.RC[0]);
    s1[1] = HarakaBase.AesEnc(s1[1], HarakaBase.RC[1]);
    s1[0] = HarakaBase.AesEnc(s1[0], HarakaBase.RC[2]);
    s1[1] = HarakaBase.AesEnc(s1[1], HarakaBase.RC[3]);
    Haraka256Digest.Mix256(s1, s2);
    s1[0] = HarakaBase.AesEnc(s2[0], HarakaBase.RC[4]);
    s1[1] = HarakaBase.AesEnc(s2[1], HarakaBase.RC[5]);
    s1[0] = HarakaBase.AesEnc(s1[0], HarakaBase.RC[6]);
    s1[1] = HarakaBase.AesEnc(s1[1], HarakaBase.RC[7]);
    Haraka256Digest.Mix256(s1, s2);
    s1[0] = HarakaBase.AesEnc(s2[0], HarakaBase.RC[8]);
    s1[1] = HarakaBase.AesEnc(s2[1], HarakaBase.RC[9]);
    s1[0] = HarakaBase.AesEnc(s1[0], HarakaBase.RC[10]);
    s1[1] = HarakaBase.AesEnc(s1[1], HarakaBase.RC[11]);
    Haraka256Digest.Mix256(s1, s2);
    s1[0] = HarakaBase.AesEnc(s2[0], HarakaBase.RC[12]);
    s1[1] = HarakaBase.AesEnc(s2[1], HarakaBase.RC[13]);
    s1[0] = HarakaBase.AesEnc(s1[0], HarakaBase.RC[14]);
    s1[1] = HarakaBase.AesEnc(s1[1], HarakaBase.RC[15]);
    Haraka256Digest.Mix256(s1, s2);
    s1[0] = HarakaBase.AesEnc(s2[0], HarakaBase.RC[16 /*0x10*/]);
    s1[1] = HarakaBase.AesEnc(s2[1], HarakaBase.RC[17]);
    s1[0] = HarakaBase.AesEnc(s1[0], HarakaBase.RC[18]);
    s1[1] = HarakaBase.AesEnc(s1[1], HarakaBase.RC[19]);
    Haraka256Digest.Mix256(s1, s2);
    s1[0] = HarakaBase.Xor(s2[0], msg, 0);
    s1[1] = HarakaBase.Xor(s2[1], msg, 16 /*0x10*/);
    Array.Copy((Array) s1[0], 0, (Array) output, outOff, 16 /*0x10*/);
    Array.Copy((Array) s1[1], 0, (Array) output, outOff + 16 /*0x10*/, 16 /*0x10*/);
    return HarakaBase.DIGEST_SIZE;
  }

  private static void Mix256(byte[][] s1, byte[][] s2)
  {
    Array.Copy((Array) s1[0], 0, (Array) s2[0], 0, 4);
    Array.Copy((Array) s1[1], 0, (Array) s2[0], 4, 4);
    Array.Copy((Array) s1[0], 4, (Array) s2[0], 8, 4);
    Array.Copy((Array) s1[1], 4, (Array) s2[0], 12, 4);
    Array.Copy((Array) s1[0], 8, (Array) s2[1], 0, 4);
    Array.Copy((Array) s1[1], 8, (Array) s2[1], 4, 4);
    Array.Copy((Array) s1[0], 12, (Array) s2[1], 8, 4);
    Array.Copy((Array) s1[1], 12, (Array) s2[1], 12, 4);
  }
}
