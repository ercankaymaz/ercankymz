// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.WhirlpoolDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class WhirlpoolDigest : IDigest, IMemoable
{
  private const int BITCOUNT_ARRAY_SIZE = 32 /*0x20*/;
  private const int BYTE_LENGTH = 64 /*0x40*/;
  private const int DIGEST_LENGTH_BYTES = 64 /*0x40*/;
  private const int REDUCTION_POLYNOMIAL = 285;
  private const int ROUNDS = 10;
  private static readonly int[] SBOX = new int[256 /*0x0100*/]
  {
    24,
    35,
    198,
    232,
    135,
    184,
    1,
    79,
    54,
    166,
    210,
    245,
    121,
    111,
    145,
    82,
    96 /*0x60*/,
    188,
    155,
    142,
    163,
    12,
    123,
    53,
    29,
    224 /*0xE0*/,
    215,
    194,
    46,
    75,
    254,
    87,
    21,
    119,
    55,
    229,
    159,
    240 /*0xF0*/,
    74,
    218,
    88,
    201,
    41,
    10,
    177,
    160 /*0xA0*/,
    107,
    133,
    189,
    93,
    16 /*0x10*/,
    244,
    203,
    62,
    5,
    103,
    228,
    39,
    65,
    139,
    167,
    125,
    149,
    216,
    251,
    238,
    124,
    102,
    221,
    23,
    71,
    158,
    202,
    45,
    191,
    7,
    173,
    90,
    131,
    51,
    99,
    2,
    170,
    113,
    200,
    25,
    73,
    217,
    242,
    227,
    91,
    136,
    154,
    38,
    50,
    176 /*0xB0*/,
    233,
    15,
    213,
    128 /*0x80*/,
    190,
    205,
    52,
    72,
    (int) byte.MaxValue,
    122,
    144 /*0x90*/,
    95,
    32 /*0x20*/,
    104,
    26,
    174,
    180,
    84,
    147,
    34,
    100,
    241,
    115,
    18,
    64 /*0x40*/,
    8,
    195,
    236,
    219,
    161,
    141,
    61,
    151,
    0,
    207,
    43,
    118,
    130,
    214,
    27,
    181,
    175,
    106,
    80 /*0x50*/,
    69,
    243,
    48 /*0x30*/,
    239,
    63 /*0x3F*/,
    85,
    162,
    234,
    101,
    186,
    47,
    192 /*0xC0*/,
    222,
    28,
    253,
    77,
    146,
    117,
    6,
    138,
    178,
    230,
    14,
    31 /*0x1F*/,
    98,
    212,
    168,
    150,
    249,
    197,
    37,
    89,
    132,
    114,
    57,
    76,
    94,
    120,
    56,
    140,
    209,
    165,
    226,
    97,
    179,
    33,
    156,
    30,
    67,
    199,
    252,
    4,
    81,
    153,
    109,
    13,
    250,
    223,
    126,
    36,
    59,
    171,
    206,
    17,
    143,
    78,
    183,
    235,
    60,
    129,
    148,
    247,
    185,
    19,
    44,
    211,
    231,
    110,
    196,
    3,
    86,
    68,
    (int) sbyte.MaxValue,
    169,
    42,
    187,
    193,
    83,
    220,
    11,
    157,
    108,
    49,
    116,
    246,
    70,
    172,
    137,
    20,
    225,
    22,
    58,
    105,
    9,
    112 /*0x70*/,
    182,
    208 /*0xD0*/,
    237,
    204,
    66,
    152,
    164,
    40,
    92,
    248,
    134
  };
  private static readonly ulong[] C0 = new ulong[256 /*0x0100*/];
  private static readonly ulong[] C1 = new ulong[256 /*0x0100*/];
  private static readonly ulong[] C2 = new ulong[256 /*0x0100*/];
  private static readonly ulong[] C3 = new ulong[256 /*0x0100*/];
  private static readonly ulong[] C4 = new ulong[256 /*0x0100*/];
  private static readonly ulong[] C5 = new ulong[256 /*0x0100*/];
  private static readonly ulong[] C6 = new ulong[256 /*0x0100*/];
  private static readonly ulong[] C7 = new ulong[256 /*0x0100*/];
  private static readonly short[] EIGHT = new short[32 /*0x20*/];
  private readonly ulong[] _rc = new ulong[11];
  private byte[] _buffer = new byte[64 /*0x40*/];
  private int _bufferPos;
  private short[] _bitCount = new short[32 /*0x20*/];
  private ulong[] _hash = new ulong[8];
  private ulong[] _K = new ulong[8];
  private ulong[] _L = new ulong[8];
  private ulong[] _block = new ulong[8];
  private ulong[] _state = new ulong[8];

  static WhirlpoolDigest()
  {
    WhirlpoolDigest.EIGHT[31 /*0x1F*/] = (short) 8;
    for (int index = 0; index < 256 /*0x0100*/; ++index)
    {
      int num1 = WhirlpoolDigest.SBOX[index];
      int num2 = WhirlpoolDigest.MulX(num1);
      int num3 = WhirlpoolDigest.MulX(num2);
      int num4 = num3 ^ num1;
      int num5 = WhirlpoolDigest.MulX(num3);
      int num6 = num5 ^ num1;
      WhirlpoolDigest.C0[index] = WhirlpoolDigest.PackIntoUInt64(num1, num1, num3, num1, num5, num4, num2, num6);
      WhirlpoolDigest.C1[index] = WhirlpoolDigest.PackIntoUInt64(num6, num1, num1, num3, num1, num5, num4, num2);
      WhirlpoolDigest.C2[index] = WhirlpoolDigest.PackIntoUInt64(num2, num6, num1, num1, num3, num1, num5, num4);
      WhirlpoolDigest.C3[index] = WhirlpoolDigest.PackIntoUInt64(num4, num2, num6, num1, num1, num3, num1, num5);
      WhirlpoolDigest.C4[index] = WhirlpoolDigest.PackIntoUInt64(num5, num4, num2, num6, num1, num1, num3, num1);
      WhirlpoolDigest.C5[index] = WhirlpoolDigest.PackIntoUInt64(num1, num5, num4, num2, num6, num1, num1, num3);
      WhirlpoolDigest.C6[index] = WhirlpoolDigest.PackIntoUInt64(num3, num1, num5, num4, num2, num6, num1, num1);
      WhirlpoolDigest.C7[index] = WhirlpoolDigest.PackIntoUInt64(num1, num3, num1, num5, num4, num2, num6, num1);
    }
  }

  private static int MulX(int input) => input << 1 ^ -(input >> 7) & 285;

  private static ulong PackIntoUInt64(
    int b7,
    int b6,
    int b5,
    int b4,
    int b3,
    int b2,
    int b1,
    int b0)
  {
    return (ulong) ((long) b7 << 56 ^ (long) b6 << 48 /*0x30*/ ^ (long) b5 << 40 ^ (long) b4 << 32 /*0x20*/ ^ (long) b3 << 24 ^ (long) b2 << 16 /*0x10*/ ^ (long) b1 << 8) ^ (ulong) b0;
  }

  public WhirlpoolDigest()
  {
    this._rc[0] = 0UL;
    for (int index1 = 1; index1 <= 10; ++index1)
    {
      int index2 = 8 * (index1 - 1);
      this._rc[index1] = (ulong) ((long) WhirlpoolDigest.C0[index2] & -72057594037927936L /*0xFF00000000000000*/ ^ (long) WhirlpoolDigest.C1[index2 + 1] & 71776119061217280L /*0xFF000000000000*/ ^ (long) WhirlpoolDigest.C2[index2 + 2] & 280375465082880L /*0xFF0000000000*/ ^ (long) WhirlpoolDigest.C3[index2 + 3] & 1095216660480L /*0xFF00000000*/ ^ (long) WhirlpoolDigest.C4[index2 + 4] & 4278190080L /*0xFF000000*/ ^ (long) WhirlpoolDigest.C5[index2 + 5] & 16711680L /*0xFF0000*/ ^ (long) WhirlpoolDigest.C6[index2 + 6] & 65280L ^ (long) WhirlpoolDigest.C7[index2 + 7] & (long) byte.MaxValue);
    }
  }

  public WhirlpoolDigest(WhirlpoolDigest originalDigest) => this.Reset((IMemoable) originalDigest);

  public string AlgorithmName => "Whirlpool";

  public int GetDigestSize() => 64 /*0x40*/;

  public int DoFinal(byte[] output, int outOff)
  {
    this.Finish();
    Pack.UInt64_To_BE(this._hash, output, outOff);
    this.Reset();
    return this.GetDigestSize();
  }

  public void Reset()
  {
    this._bufferPos = 0;
    Array.Clear((Array) this._bitCount, 0, this._bitCount.Length);
    Array.Clear((Array) this._buffer, 0, this._buffer.Length);
    Array.Clear((Array) this._hash, 0, this._hash.Length);
    Array.Clear((Array) this._K, 0, this._K.Length);
    Array.Clear((Array) this._L, 0, this._L.Length);
    Array.Clear((Array) this._block, 0, this._block.Length);
    Array.Clear((Array) this._state, 0, this._state.Length);
  }

  private void ProcessFilledBuffer()
  {
    Pack.BE_To_UInt64(this._buffer, 0, this._block);
    this.ProcessBlock();
    this._bufferPos = 0;
    Array.Clear((Array) this._buffer, 0, this._buffer.Length);
  }

  private void ProcessBlock()
  {
    for (int index = 0; index < 8; ++index)
      this._state[index] = this._block[index] ^ (this._K[index] = this._hash[index]);
    for (int index1 = 1; index1 <= 10; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        this._L[index2] = WhirlpoolDigest.C0[(int) (this._K[index2 & 7] >> 56) & (int) byte.MaxValue];
        this._L[index2] ^= WhirlpoolDigest.C1[(int) (this._K[index2 - 1 & 7] >> 48 /*0x30*/) & (int) byte.MaxValue];
        this._L[index2] ^= WhirlpoolDigest.C2[(int) (this._K[index2 - 2 & 7] >> 40) & (int) byte.MaxValue];
        this._L[index2] ^= WhirlpoolDigest.C3[(int) (this._K[index2 - 3 & 7] >> 32 /*0x20*/) & (int) byte.MaxValue];
        this._L[index2] ^= WhirlpoolDigest.C4[(int) (this._K[index2 - 4 & 7] >> 24) & (int) byte.MaxValue];
        this._L[index2] ^= WhirlpoolDigest.C5[(int) (this._K[index2 - 5 & 7] >> 16 /*0x10*/) & (int) byte.MaxValue];
        this._L[index2] ^= WhirlpoolDigest.C6[(int) (this._K[index2 - 6 & 7] >> 8) & (int) byte.MaxValue];
        this._L[index2] ^= WhirlpoolDigest.C7[(int) this._K[index2 - 7 & 7] & (int) byte.MaxValue];
      }
      Array.Copy((Array) this._L, 0, (Array) this._K, 0, this._K.Length);
      this._K[0] ^= this._rc[index1];
      for (int index3 = 0; index3 < 8; ++index3)
      {
        this._L[index3] = this._K[index3];
        this._L[index3] ^= WhirlpoolDigest.C0[(int) (this._state[index3 & 7] >> 56) & (int) byte.MaxValue];
        this._L[index3] ^= WhirlpoolDigest.C1[(int) (this._state[index3 - 1 & 7] >> 48 /*0x30*/) & (int) byte.MaxValue];
        this._L[index3] ^= WhirlpoolDigest.C2[(int) (this._state[index3 - 2 & 7] >> 40) & (int) byte.MaxValue];
        this._L[index3] ^= WhirlpoolDigest.C3[(int) (this._state[index3 - 3 & 7] >> 32 /*0x20*/) & (int) byte.MaxValue];
        this._L[index3] ^= WhirlpoolDigest.C4[(int) (this._state[index3 - 4 & 7] >> 24) & (int) byte.MaxValue];
        this._L[index3] ^= WhirlpoolDigest.C5[(int) (this._state[index3 - 5 & 7] >> 16 /*0x10*/) & (int) byte.MaxValue];
        this._L[index3] ^= WhirlpoolDigest.C6[(int) (this._state[index3 - 6 & 7] >> 8) & (int) byte.MaxValue];
        this._L[index3] ^= WhirlpoolDigest.C7[(int) this._state[index3 - 7 & 7] & (int) byte.MaxValue];
      }
      Array.Copy((Array) this._L, 0, (Array) this._state, 0, this._state.Length);
    }
    for (int index = 0; index < 8; ++index)
      this._hash[index] ^= this._state[index] ^ this._block[index];
  }

  public void Update(byte input)
  {
    this._buffer[this._bufferPos] = input;
    if (++this._bufferPos == this._buffer.Length)
      this.ProcessFilledBuffer();
    this.Increment();
  }

  private void Increment()
  {
    int num1 = 0;
    for (int index = this._bitCount.Length - 1; index >= 0; --index)
    {
      int num2 = ((int) this._bitCount[index] & (int) byte.MaxValue) + (int) WhirlpoolDigest.EIGHT[index] + num1;
      num1 = num2 >> 8;
      this._bitCount[index] = (short) (num2 & (int) byte.MaxValue);
    }
  }

  public void BlockUpdate(byte[] input, int inOff, int length)
  {
    for (; length > 0; --length)
    {
      this.Update(input[inOff]);
      ++inOff;
    }
  }

  private void Finish()
  {
    byte[] sourceArray = this.CopyBitLength();
    this._buffer[this._bufferPos] |= (byte) 128 /*0x80*/;
    if (++this._bufferPos == this._buffer.Length)
      this.ProcessFilledBuffer();
    if (this._bufferPos > 32 /*0x20*/)
    {
      while (this._bufferPos != 0)
        this.Update((byte) 0);
    }
    while (this._bufferPos <= 32 /*0x20*/)
      this.Update((byte) 0);
    Array.Copy((Array) sourceArray, 0, (Array) this._buffer, 32 /*0x20*/, sourceArray.Length);
    this.ProcessFilledBuffer();
  }

  private byte[] CopyBitLength()
  {
    byte[] numArray = new byte[32 /*0x20*/];
    for (int index = 0; index < numArray.Length; ++index)
      numArray[index] = (byte) ((uint) this._bitCount[index] & (uint) byte.MaxValue);
    return numArray;
  }

  public int GetByteLength() => 64 /*0x40*/;

  public IMemoable Copy() => (IMemoable) new WhirlpoolDigest(this);

  public void Reset(IMemoable other)
  {
    WhirlpoolDigest whirlpoolDigest = (WhirlpoolDigest) other;
    Array.Copy((Array) whirlpoolDigest._rc, 0, (Array) this._rc, 0, this._rc.Length);
    Array.Copy((Array) whirlpoolDigest._buffer, 0, (Array) this._buffer, 0, this._buffer.Length);
    this._bufferPos = whirlpoolDigest._bufferPos;
    Array.Copy((Array) whirlpoolDigest._bitCount, 0, (Array) this._bitCount, 0, this._bitCount.Length);
    Array.Copy((Array) whirlpoolDigest._hash, 0, (Array) this._hash, 0, this._hash.Length);
    Array.Copy((Array) whirlpoolDigest._K, 0, (Array) this._K, 0, this._K.Length);
    Array.Copy((Array) whirlpoolDigest._L, 0, (Array) this._L, 0, this._L.Length);
    Array.Copy((Array) whirlpoolDigest._block, 0, (Array) this._block, 0, this._block.Length);
    Array.Copy((Array) whirlpoolDigest._state, 0, (Array) this._state, 0, this._state.Length);
  }
}
