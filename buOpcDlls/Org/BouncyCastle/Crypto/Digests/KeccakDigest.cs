// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.KeccakDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class KeccakDigest : IDigest, IMemoable
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
  private readonly ulong[] state = new ulong[25];
  protected byte[] dataQueue = new byte[192 /*0xC0*/];
  protected int rate;
  protected int bitsInQueue;
  protected internal int fixedOutputLength;
  protected bool squeezing;

  public KeccakDigest()
    : this(288)
  {
  }

  public KeccakDigest(int bitLength) => this.Init(bitLength);

  public KeccakDigest(KeccakDigest source) => this.CopyIn(source);

  private void CopyIn(KeccakDigest source)
  {
    Array.Copy((Array) source.state, 0, (Array) this.state, 0, source.state.Length);
    Array.Copy((Array) source.dataQueue, 0, (Array) this.dataQueue, 0, source.dataQueue.Length);
    this.rate = source.rate;
    this.bitsInQueue = source.bitsInQueue;
    this.fixedOutputLength = source.fixedOutputLength;
    this.squeezing = source.squeezing;
  }

  public virtual string AlgorithmName => "Keccak-" + this.fixedOutputLength.ToString();

  public virtual int GetDigestSize() => this.fixedOutputLength >> 3;

  public virtual void Update(byte input) => this.Absorb(input);

  public virtual void BlockUpdate(byte[] input, int inOff, int len)
  {
    this.Absorb(input, inOff, len);
  }

  public virtual int DoFinal(byte[] output, int outOff)
  {
    this.Squeeze(output, outOff, (long) this.fixedOutputLength);
    this.Reset();
    return this.GetDigestSize();
  }

  protected virtual int DoFinal(byte[] output, int outOff, byte partialByte, int partialBits)
  {
    if (partialBits > 0)
      this.AbsorbBits((int) partialByte, partialBits);
    this.Squeeze(output, outOff, (long) this.fixedOutputLength);
    this.Reset();
    return this.GetDigestSize();
  }

  public virtual void Reset() => this.Init(this.fixedOutputLength);

  public virtual int GetByteLength() => this.rate >> 3;

  private void Init(int bitLength)
  {
    if (bitLength <= 256 /*0x0100*/)
    {
      if (bitLength == 128 /*0x80*/ || bitLength == 224 /*0xE0*/ || bitLength == 256 /*0x0100*/)
        goto label_4;
    }
    else if (bitLength == 288 || bitLength == 384 || bitLength == 512 /*0x0200*/)
      goto label_4;
    throw new ArgumentException("must be one of 128, 224, 256, 288, 384, or 512.", nameof (bitLength));
label_4:
    this.InitSponge(1600 - (bitLength << 1));
  }

  private void InitSponge(int rate)
  {
    this.rate = rate > 0 && rate < 1600 && (rate & 63 /*0x3F*/) == 0 ? rate : throw new InvalidOperationException("invalid rate value");
    Array.Clear((Array) this.state, 0, this.state.Length);
    Arrays.Fill(this.dataQueue, (byte) 0);
    this.bitsInQueue = 0;
    this.squeezing = false;
    this.fixedOutputLength = 1600 - rate >> 1;
  }

  protected void Absorb(byte data)
  {
    if ((this.bitsInQueue & 7) != 0)
      throw new InvalidOperationException("attempt to absorb with odd length queue");
    if (this.squeezing)
      throw new InvalidOperationException("attempt to absorb while squeezing");
    this.dataQueue[this.bitsInQueue >> 3] = data;
    if ((this.bitsInQueue += 8) != this.rate)
      return;
    this.KeccakAbsorb(this.dataQueue, 0);
    this.bitsInQueue = 0;
  }

  protected void Absorb(byte[] data, int off, int len)
  {
    if ((this.bitsInQueue & 7) != 0)
      throw new InvalidOperationException("attempt to absorb with odd length queue");
    if (this.squeezing)
      throw new InvalidOperationException("attempt to absorb while squeezing");
    int destinationIndex = this.bitsInQueue >> 3;
    int num1 = this.rate >> 3;
    int length1 = num1 - destinationIndex;
    if (len < length1)
    {
      Array.Copy((Array) data, off, (Array) this.dataQueue, destinationIndex, len);
      this.bitsInQueue += len << 3;
    }
    else
    {
      int num2 = 0;
      if (destinationIndex > 0)
      {
        Array.Copy((Array) data, off, (Array) this.dataQueue, destinationIndex, length1);
        num2 += length1;
        this.KeccakAbsorb(this.dataQueue, 0);
      }
      int length2;
      for (; (length2 = len - num2) >= num1; num2 += num1)
        this.KeccakAbsorb(data, off + num2);
      Array.Copy((Array) data, off + num2, (Array) this.dataQueue, 0, length2);
      this.bitsInQueue = length2 << 3;
    }
  }

  protected void AbsorbBits(int data, int bits)
  {
    if (bits < 1 || bits > 7)
      throw new ArgumentException("must be in the range 1 to 7", nameof (bits));
    if ((this.bitsInQueue & 7) != 0)
      throw new InvalidOperationException("attempt to absorb with odd length queue");
    if (this.squeezing)
      throw new InvalidOperationException("attempt to absorb while squeezing");
    int num = (1 << bits) - 1;
    this.dataQueue[this.bitsInQueue >> 3] = (byte) (data & num);
    this.bitsInQueue += bits;
  }

  private void PadAndSwitchToSqueezingPhase()
  {
    this.dataQueue[this.bitsInQueue >> 3] |= (byte) (1 << (this.bitsInQueue & 7));
    if (++this.bitsInQueue == this.rate)
    {
      this.KeccakAbsorb(this.dataQueue, 0);
    }
    else
    {
      int index1 = this.bitsInQueue >> 6;
      int num1 = this.bitsInQueue & 63 /*0x3F*/;
      int off = 0;
      for (int index2 = 0; index2 < index1; ++index2)
      {
        this.state[index2] ^= Pack.LE_To_UInt64(this.dataQueue, off);
        off += 8;
      }
      if (num1 > 0)
      {
        ulong num2 = (ulong) ((1L << num1) - 1L);
        this.state[index1] ^= Pack.LE_To_UInt64(this.dataQueue, off) & num2;
      }
    }
    this.state[this.rate - 1 >> 6] ^= 9223372036854775808UL /*0x8000000000000000*/;
    this.bitsInQueue = 0;
    this.squeezing = true;
  }

  protected void Squeeze(byte[] output, int offset, long outputLength)
  {
    if (!this.squeezing)
      this.PadAndSwitchToSqueezingPhase();
    if ((outputLength & 7L) != 0L)
      throw new InvalidOperationException("outputLength not a multiple of 8");
    int num;
    for (long index = 0; index < outputLength; index += (long) num)
    {
      if (this.bitsInQueue == 0)
        this.KeccakExtract();
      num = (int) Math.Min((long) this.bitsInQueue, outputLength - index);
      Array.Copy((Array) this.dataQueue, this.rate - this.bitsInQueue >> 3, (Array) output, offset + (int) (index >> 3), num >> 3);
      this.bitsInQueue -= num;
    }
  }

  private void KeccakAbsorb(byte[] data, int off)
  {
    int num = this.rate >> 6;
    for (int index = 0; index < num; ++index)
    {
      this.state[index] ^= Pack.LE_To_UInt64(data, off);
      off += 8;
    }
    KeccakDigest.KeccakPermutation(this.state);
  }

  private void KeccakExtract()
  {
    KeccakDigest.KeccakPermutation(this.state);
    Pack.UInt64_To_LE(this.state, 0, this.rate >> 6, this.dataQueue, 0);
    this.bitsInQueue = this.rate;
  }

  internal static void KeccakPermutation(ulong[] A)
  {
    ulong num1 = A[0];
    ulong num2 = A[1];
    ulong num3 = A[2];
    ulong num4 = A[3];
    ulong num5 = A[4];
    ulong num6 = A[5];
    ulong num7 = A[6];
    ulong num8 = A[7];
    ulong num9 = A[8];
    ulong num10 = A[9];
    ulong num11 = A[10];
    ulong num12 = A[11];
    ulong num13 = A[12];
    ulong num14 = A[13];
    ulong num15 = A[14];
    ulong num16 = A[15];
    ulong num17 = A[16 /*0x10*/];
    ulong num18 = A[17];
    ulong num19 = A[18];
    ulong num20 = A[19];
    ulong num21 = A[20];
    ulong num22 = A[21];
    ulong num23 = A[22];
    ulong num24 = A[23];
    ulong num25 = A[24];
    for (int index = 0; index < 24; ++index)
    {
      ulong i1 = num1 ^ num6 ^ num11 ^ num16 ^ num21;
      ulong i2 = num2 ^ num7 ^ num12 ^ num17 ^ num22;
      ulong i3 = num3 ^ num8 ^ num13 ^ num18 ^ num23;
      ulong i4 = num4 ^ num9 ^ num14 ^ num19 ^ num24;
      ulong i5 = num5 ^ num10 ^ num15 ^ num20 ^ num25;
      ulong num26 = Longs.RotateLeft(i2, 1) ^ i5;
      ulong num27 = Longs.RotateLeft(i3, 1) ^ i1;
      ulong num28 = Longs.RotateLeft(i4, 1) ^ i2;
      ulong num29 = Longs.RotateLeft(i5, 1) ^ i3;
      ulong num30 = Longs.RotateLeft(i1, 1) ^ i4;
      ulong num31 = num1 ^ num26;
      ulong i6 = num6 ^ num26;
      ulong i7 = num11 ^ num26;
      ulong i8 = num16 ^ num26;
      ulong i9 = num21 ^ num26;
      ulong i10 = num2 ^ num27;
      ulong i11 = num7 ^ num27;
      ulong i12 = num12 ^ num27;
      ulong i13 = num17 ^ num27;
      ulong i14 = num22 ^ num27;
      ulong i15 = num3 ^ num28;
      ulong i16 = num8 ^ num28;
      ulong i17 = num13 ^ num28;
      ulong i18 = num18 ^ num28;
      ulong i19 = num23 ^ num28;
      ulong i20 = num4 ^ num29;
      ulong i21 = num9 ^ num29;
      ulong i22 = num14 ^ num29;
      ulong i23 = num19 ^ num29;
      ulong i24 = num24 ^ num29;
      ulong i25 = num5 ^ num30;
      ulong i26 = num10 ^ num30;
      ulong i27 = num15 ^ num30;
      ulong i28 = num20 ^ num30;
      ulong i29 = num25 ^ num30;
      ulong num32 = Longs.RotateLeft(i10, 1);
      ulong num33 = Longs.RotateLeft(i11, 44);
      ulong num34 = Longs.RotateLeft(i26, 20);
      ulong num35 = Longs.RotateLeft(i19, 61);
      ulong num36 = Longs.RotateLeft(i27, 39);
      ulong num37 = Longs.RotateLeft(i9, 18);
      ulong num38 = Longs.RotateLeft(i15, 62);
      ulong num39 = Longs.RotateLeft(i17, 43);
      ulong num40 = Longs.RotateLeft(i22, 25);
      ulong num41 = Longs.RotateLeft(i28, 8);
      ulong num42 = Longs.RotateLeft(i24, 56);
      ulong num43 = Longs.RotateLeft(i8, 41);
      ulong num44 = Longs.RotateLeft(i25, 27);
      ulong num45 = Longs.RotateLeft(i29, 14);
      ulong num46 = Longs.RotateLeft(i14, 2);
      ulong num47 = Longs.RotateLeft(i21, 55);
      ulong num48 = Longs.RotateLeft(i13, 45);
      ulong num49 = Longs.RotateLeft(i6, 36);
      ulong num50 = Longs.RotateLeft(i20, 28);
      ulong num51 = Longs.RotateLeft(i23, 21);
      ulong num52 = Longs.RotateLeft(i18, 15);
      ulong num53 = Longs.RotateLeft(i12, 10);
      ulong num54 = Longs.RotateLeft(i16, 6);
      ulong num55 = Longs.RotateLeft(i7, 3);
      ulong num56 = num32;
      ulong num57 = num31 ^ ~num33 & num39;
      ulong num58 = num33 ^ ~num39 & num51;
      num3 = num39 ^ ~num51 & num45;
      num4 = num51 ^ ~num45 & num31;
      num5 = num45 ^ ~num31 & num33;
      ulong num59 = num57;
      num2 = num58;
      ulong num60 = num50 ^ ~num34 & num55;
      ulong num61 = num34 ^ ~num55 & num48;
      num8 = num55 ^ ~num48 & num35;
      num9 = num48 ^ ~num35 & num50;
      num10 = num35 ^ ~num50 & num34;
      num6 = num60;
      num7 = num61;
      ulong num62 = num56 ^ ~num54 & num40;
      ulong num63 = num54 ^ ~num40 & num41;
      num13 = num40 ^ ~num41 & num37;
      num14 = num41 ^ ~num37 & num56;
      num15 = num37 ^ ~num56 & num54;
      num11 = num62;
      num12 = num63;
      ulong num64 = num44 ^ ~num49 & num53;
      ulong num65 = num49 ^ ~num53 & num52;
      num18 = num53 ^ ~num52 & num42;
      num19 = num52 ^ ~num42 & num44;
      num20 = num42 ^ ~num44 & num49;
      num16 = num64;
      num17 = num65;
      ulong num66 = num38 ^ ~num47 & num36;
      ulong num67 = num47 ^ ~num36 & num43;
      num23 = num36 ^ ~num43 & num46;
      num24 = num43 ^ ~num46 & num38;
      num25 = num46 ^ ~num38 & num47;
      num21 = num66;
      num22 = num67;
      num1 = num59 ^ KeccakDigest.KeccakRoundConstants[index];
    }
    A[0] = num1;
    A[1] = num2;
    A[2] = num3;
    A[3] = num4;
    A[4] = num5;
    A[5] = num6;
    A[6] = num7;
    A[7] = num8;
    A[8] = num9;
    A[9] = num10;
    A[10] = num11;
    A[11] = num12;
    A[12] = num13;
    A[13] = num14;
    A[14] = num15;
    A[15] = num16;
    A[16 /*0x10*/] = num17;
    A[17] = num18;
    A[18] = num19;
    A[19] = num20;
    A[20] = num21;
    A[21] = num22;
    A[22] = num23;
    A[23] = num24;
    A[24] = num25;
  }

  public virtual IMemoable Copy() => (IMemoable) new KeccakDigest(this);

  public virtual void Reset(IMemoable other) => this.CopyIn((KeccakDigest) other);
}
