// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.HqcKeccakRandomGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

internal sealed class HqcKeccakRandomGenerator
{
  private static readonly ulong[] KeccakRoundConstants = new ulong[24]
  {
    1UL,
    32898UL,
    9223372036854808714UL /*0x800000000000808A*/,
    9223372039002292224UL /*0x8000000080008000*/,
    32907UL,
    2147483649UL /*0x80000001*/,
    9223372039002292353UL /*0x8000000080008081*/,
    9223372036854808585UL /*0x8000000000008009*/,
    138UL,
    136UL,
    2147516425UL /*0x80008009*/,
    2147483658UL /*0x8000000A*/,
    2147516555UL,
    9223372036854775947UL /*0x800000000000008B*/,
    9223372036854808713UL /*0x8000000000008089*/,
    9223372036854808579UL /*0x8000000000008003*/,
    9223372036854808578UL /*0x8000000000008002*/,
    9223372036854775936UL /*0x8000000000000080*/,
    32778UL,
    9223372039002259466UL /*0x800000008000000A*/,
    9223372039002292353UL /*0x8000000080008081*/,
    9223372036854808704UL /*0x8000000000008080*/,
    2147483649UL /*0x80000001*/,
    9223372039002292232UL /*0x8000000080008008*/
  };
  private readonly ulong[] state = new ulong[26];
  private readonly byte[] dataQueue = new byte[192 /*0xC0*/];
  private int rate;
  private int fixedOutputLength;

  public HqcKeccakRandomGenerator() => this.Init(288);

  public HqcKeccakRandomGenerator(int bitLength) => this.Init(bitLength);

  private void Init(int bitLength)
  {
    if (bitLength <= 256 /*0x0100*/)
    {
      if (bitLength == 128 /*0x80*/ || bitLength == 224 /*0xE0*/ || bitLength == 256 /*0x0100*/)
        goto label_4;
    }
    else if (bitLength == 288 || bitLength == 384 || bitLength == 512 /*0x0200*/)
      goto label_4;
    throw new ArgumentException("bitLength must be one of 128, 224, 256, 288, 384, or 512.");
label_4:
    this.InitSponge(1600 - (bitLength << 1));
  }

  private void InitSponge(int rate)
  {
    this.rate = rate > 0 && rate < 1600 && rate % 64 /*0x40*/ == 0 ? rate : throw new InvalidOperationException("invalid rate value");
    Arrays.Fill(this.state, 0UL);
    Arrays.Fill(this.dataQueue, (byte) 0);
    this.fixedOutputLength = (1600 - rate) / 2;
  }

  private void KeccakIncAbsorb(byte[] input, int inputLen)
  {
    int num1 = 0;
    int num2 = this.rate >> 3;
    while ((long) inputLen + (long) this.state[25] >= (long) num2)
    {
      for (int index = 0; (long) index < (long) num2 - (long) this.state[25]; ++index)
        this.state[(int) ((long) this.state[25] + (long) index) >> 3] ^= (ulong) input[index + num1] << 8 * ((int) this.state[25] + index & 7);
      inputLen -= (int) ((long) num2 - (long) this.state[25]);
      num1 += (int) ((long) num2 - (long) this.state[25]);
      this.state[25] = 0UL;
      KeccakDigest.KeccakPermutation(this.state);
    }
    for (int index = 0; index < inputLen; ++index)
      this.state[(int) ((long) this.state[25] + (long) index) >> 3] ^= (ulong) input[index + num1] << 8 * ((int) this.state[25] + index & 7);
    this.state[25] = this.state[25] + (ulong) inputLen;
  }

  private void KeccakIncFinalize(int p)
  {
    int num = this.rate >> 3;
    this.state[(int) this.state[25] >> 3] ^= (ulong) p << (int) (8L * ((long) this.state[25] & 7L));
    this.state[num - 1 >> 3] ^= (ulong) (128L /*0x80*/ << 8 * (num - 1 & 7));
    this.state[25] = 0UL;
  }

  private void KeccakIncSqueeze(byte[] output, int outLen)
  {
    int num1 = this.rate >> 3;
    int index;
    for (index = 0; index < outLen && (long) index < (long) this.state[25]; ++index)
      output[index] = (byte) (this.state[(int) ((long) num1 - (long) this.state[25] + (long) index >> 3)] >> (int) (8L * ((long) num1 - (long) this.state[25] + (long) index & 7L)));
    int num2 = index;
    outLen -= index;
    this.state[25] = this.state[25] - (ulong) index;
    while (outLen > 0)
    {
      KeccakDigest.KeccakPermutation(this.state);
      int num3;
      for (num3 = 0; num3 < outLen && num3 < num1; ++num3)
        output[num2 + num3] = (byte) (this.state[num3 >> 3] >> 8 * (num3 & 7));
      num2 += num3;
      outLen -= num3;
      this.state[25] = (ulong) (num1 - num3);
    }
  }

  public void Squeeze(byte[] output, int outLen) => this.KeccakIncSqueeze(output, outLen);

  public void RandomGeneratorInit(
    byte[] entropyInput,
    byte[] personalizationString,
    int entropyLen,
    int perLen)
  {
    byte[] input = new byte[1]{ (byte) 1 };
    this.KeccakIncAbsorb(entropyInput, entropyLen);
    this.KeccakIncAbsorb(personalizationString, perLen);
    this.KeccakIncAbsorb(input, input.Length);
    this.KeccakIncFinalize(31 /*0x1F*/);
  }

  public void SeedExpanderInit(byte[] seed, int seedLen)
  {
    byte[] input = new byte[1]{ (byte) 2 };
    this.KeccakIncAbsorb(seed, seedLen);
    this.KeccakIncAbsorb(input, 1);
    this.KeccakIncFinalize(31 /*0x1F*/);
  }

  public void ExpandSeed(byte[] output, int outLen)
  {
    int length = outLen & 7;
    this.KeccakIncSqueeze(output, outLen - length);
    if (length == 0)
      return;
    byte[] numArray = new byte[8];
    this.KeccakIncSqueeze(numArray, 8);
    Array.Copy((Array) numArray, 0, (Array) output, outLen - length, length);
  }

  public void SHAKE256_512_ds(byte[] output, byte[] input, int inLen, byte[] domain)
  {
    Arrays.Fill(this.state, 0UL);
    this.KeccakIncAbsorb(input, inLen);
    this.KeccakIncAbsorb(domain, domain.Length);
    this.KeccakIncFinalize(31 /*0x1F*/);
    this.KeccakIncSqueeze(output, 64 /*0x40*/);
  }
}
