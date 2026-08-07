// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.SparkleDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class SparkleDigest : IDigest
{
  private static readonly uint[] RCON = new uint[8]
  {
    3084996962U,
    3211876480U,
    951376470U,
    844003128U,
    3138487787U,
    1333558103U,
    3485442504U,
    3266521405U
  };
  private string algorithmName;
  private readonly uint[] state;
  private readonly MemoryStream message = new MemoryStream();
  private readonly int DIGEST_BYTES;
  private readonly int SPARKLE_STEPS_SLIM;
  private readonly int SPARKLE_STEPS_BIG;
  private readonly int STATE_BRANS;
  private readonly int STATE_WORDS;
  private readonly int RATE_WORDS;
  private readonly int RATE_BYTES;

  public SparkleDigest(SparkleDigest.SparkleParameters sparkleParameters)
  {
    int num1 = 128 /*0x80*/;
    int num2;
    int num3;
    if (sparkleParameters != SparkleDigest.SparkleParameters.ESCH256)
    {
      if (sparkleParameters != SparkleDigest.SparkleParameters.ESCH384)
        throw new ArgumentException("Invalid definition of SCHWAEMM instance");
      num2 = 384;
      num3 = 512 /*0x0200*/;
      this.SPARKLE_STEPS_SLIM = 8;
      this.SPARKLE_STEPS_BIG = 12;
      this.algorithmName = "ESCH-384";
    }
    else
    {
      num2 = 256 /*0x0100*/;
      num3 = 384;
      this.SPARKLE_STEPS_SLIM = 7;
      this.SPARKLE_STEPS_BIG = 11;
      this.algorithmName = "ESCH-256";
    }
    this.STATE_BRANS = num3 >> 6;
    this.STATE_WORDS = num3 >> 5;
    this.RATE_WORDS = num1 >> 5;
    this.RATE_BYTES = num1 >> 3;
    this.DIGEST_BYTES = num2 >> 3;
    this.state = new uint[this.STATE_WORDS];
  }

  public string AlgorithmName => this.algorithmName;

  public int GetDigestSize() => this.DIGEST_BYTES;

  public int GetByteLength() => this.RATE_BYTES;

  public void Update(byte input) => this.message.WriteByte(input);

  public void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, inLen, "input buffer too short");
    this.message.Write(input, inOff, inLen);
  }

  public int DoFinal(byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.DIGEST_BYTES, "output buffer too short");
    byte[] buffer = this.message.GetBuffer();
    int length = (int) this.message.Length;
    int num1 = 0;
    uint[] uint32 = Pack.LE_To_UInt32(buffer, 0, length >> 2);
    while (length > this.RATE_BYTES)
    {
      uint x1 = 0;
      uint x2 = 0;
      for (int index = 0; index < this.RATE_WORDS; index += 2)
      {
        x1 ^= uint32[index + (num1 >> 2)];
        x2 ^= uint32[index + 1 + (num1 >> 2)];
      }
      uint num2 = SparkleDigest.ELL(x1);
      uint num3 = SparkleDigest.ELL(x2);
      for (int index = 0; index < this.RATE_WORDS; index += 2)
      {
        this.state[index] ^= uint32[index + (num1 >> 2)] ^ num3;
        this.state[index + 1] ^= uint32[index + 1 + (num1 >> 2)] ^ num2;
      }
      for (int rateWords = this.RATE_WORDS; rateWords < this.STATE_WORDS / 2; rateWords += 2)
      {
        this.state[rateWords] ^= num3;
        this.state[rateWords + 1] ^= num2;
      }
      this.sparkle_opt(this.state, this.STATE_BRANS, this.SPARKLE_STEPS_SLIM);
      length -= this.RATE_BYTES;
      num1 += this.RATE_BYTES;
    }
    this.state[this.STATE_BRANS - 1] ^= length < this.RATE_BYTES ? 16777216U /*0x01000000*/ : 33554432U /*0x02000000*/;
    uint[] numArray = new uint[this.RATE_WORDS];
    int num4;
    for (num4 = 0; num4 < length; ++num4)
      numArray[num4 >> 2] |= (uint) (((int) buffer[num1++] & (int) byte.MaxValue) << ((num4 & 3) << 3));
    if (length < this.RATE_BYTES)
      numArray[num4 >> 2] |= (uint) (128 /*0x80*/ << ((num4 & 3) << 3));
    uint x3 = 0;
    uint x4 = 0;
    for (int index = 0; index < this.RATE_WORDS; index += 2)
    {
      x3 ^= numArray[index];
      x4 ^= numArray[index + 1];
    }
    uint num5 = SparkleDigest.ELL(x3);
    uint num6 = SparkleDigest.ELL(x4);
    for (int index = 0; index < this.RATE_WORDS; index += 2)
    {
      this.state[index] ^= numArray[index] ^ num6;
      this.state[index + 1] ^= numArray[index + 1] ^ num5;
    }
    for (int rateWords = this.RATE_WORDS; rateWords < this.STATE_WORDS / 2; rateWords += 2)
    {
      this.state[rateWords] ^= num6;
      this.state[rateWords + 1] ^= num5;
    }
    this.sparkle_opt(this.state, this.STATE_BRANS, this.SPARKLE_STEPS_BIG);
    Pack.UInt32_To_LE(this.state, 0, this.RATE_WORDS, output, outOff);
    int rateBytes = this.RATE_BYTES;
    outOff += this.RATE_BYTES;
    while (rateBytes < this.DIGEST_BYTES)
    {
      this.sparkle_opt(this.state, this.STATE_BRANS, this.SPARKLE_STEPS_SLIM);
      Pack.UInt32_To_LE(this.state, 0, this.RATE_WORDS, output, outOff);
      rateBytes += this.RATE_BYTES;
      outOff += this.RATE_BYTES;
    }
    return this.DIGEST_BYTES;
  }

  public void Reset()
  {
    this.message.SetLength(0L);
    Arrays.Fill<uint>(this.state, 0U);
  }

  private void sparkle_opt(uint[] state, int brans, int steps)
  {
    for (uint index1 = 0; (long) index1 < (long) steps; ++index1)
    {
      state[1] ^= SparkleDigest.RCON[(int) index1 & 7];
      state[3] ^= index1;
      for (uint index2 = 0; (long) index2 < (long) (2 * brans); index2 += 2U)
      {
        uint num = SparkleDigest.RCON[(int) (index2 >> 1)];
        state[(int) index2] += Integers.RotateRight(state[(int) index2 + 1], 31 /*0x1F*/);
        state[(int) index2 + 1] ^= Integers.RotateRight(state[(int) index2], 24);
        state[(int) index2] ^= num;
        state[(int) index2] += Integers.RotateRight(state[(int) index2 + 1], 17);
        state[(int) index2 + 1] ^= Integers.RotateRight(state[(int) index2], 17);
        state[(int) index2] ^= num;
        state[(int) index2] += state[(int) index2 + 1];
        state[(int) index2 + 1] ^= Integers.RotateRight(state[(int) index2], 31 /*0x1F*/);
        state[(int) index2] ^= num;
        state[(int) index2] += Integers.RotateRight(state[(int) index2 + 1], 24);
        state[(int) index2 + 1] ^= Integers.RotateRight(state[(int) index2], 16 /*0x10*/);
        state[(int) index2] ^= num;
      }
      uint num1;
      uint x1 = num1 = state[0];
      uint num2;
      uint x2 = num2 = state[1];
      for (uint index3 = 2; (long) index3 < (long) brans; index3 += 2U)
      {
        x1 ^= state[(int) index3];
        x2 ^= state[(int) index3 + 1];
      }
      uint num3 = SparkleDigest.ELL(x1);
      uint num4 = SparkleDigest.ELL(x2);
      for (uint index4 = 2; (long) index4 < (long) brans; index4 += 2U)
      {
        state[(int) index4 - 2] = state[(long) index4 + (long) brans] ^ state[(int) index4] ^ num4;
        state[(long) index4 + (long) brans] = state[(int) index4];
        state[(int) index4 - 1] = state[(long) index4 + (long) brans + 1L] ^ state[(int) index4 + 1] ^ num3;
        state[(long) index4 + (long) brans + 1L] = state[(int) index4 + 1];
      }
      state[brans - 2] = state[brans] ^ num1 ^ num4;
      state[brans] = num1;
      state[brans - 1] = state[brans + 1] ^ num2 ^ num3;
      state[brans + 1] = num2;
    }
  }

  private static uint ELL(uint x) => Integers.RotateRight(x ^ x << 16 /*0x10*/, 16 /*0x10*/);

  public enum SparkleParameters
  {
    ESCH256,
    ESCH384,
  }
}
