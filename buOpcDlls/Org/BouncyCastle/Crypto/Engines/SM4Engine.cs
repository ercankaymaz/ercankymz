// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.SM4Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class SM4Engine : IBlockCipher
{
  private const int BlockSize = 16 /*0x10*/;
  private static readonly byte[] Sbox = new byte[256 /*0x0100*/]
  {
    (byte) 214,
    (byte) 144 /*0x90*/,
    (byte) 233,
    (byte) 254,
    (byte) 204,
    (byte) 225,
    (byte) 61,
    (byte) 183,
    (byte) 22,
    (byte) 182,
    (byte) 20,
    (byte) 194,
    (byte) 40,
    (byte) 251,
    (byte) 44,
    (byte) 5,
    (byte) 43,
    (byte) 103,
    (byte) 154,
    (byte) 118,
    (byte) 42,
    (byte) 190,
    (byte) 4,
    (byte) 195,
    (byte) 170,
    (byte) 68,
    (byte) 19,
    (byte) 38,
    (byte) 73,
    (byte) 134,
    (byte) 6,
    (byte) 153,
    (byte) 156,
    (byte) 66,
    (byte) 80 /*0x50*/,
    (byte) 244,
    (byte) 145,
    (byte) 239,
    (byte) 152,
    (byte) 122,
    (byte) 51,
    (byte) 84,
    (byte) 11,
    (byte) 67,
    (byte) 237,
    (byte) 207,
    (byte) 172,
    (byte) 98,
    (byte) 228,
    (byte) 179,
    (byte) 28,
    (byte) 169,
    (byte) 201,
    (byte) 8,
    (byte) 232,
    (byte) 149,
    (byte) 128 /*0x80*/,
    (byte) 223,
    (byte) 148,
    (byte) 250,
    (byte) 117,
    (byte) 143,
    (byte) 63 /*0x3F*/,
    (byte) 166,
    (byte) 71,
    (byte) 7,
    (byte) 167,
    (byte) 252,
    (byte) 243,
    (byte) 115,
    (byte) 23,
    (byte) 186,
    (byte) 131,
    (byte) 89,
    (byte) 60,
    (byte) 25,
    (byte) 230,
    (byte) 133,
    (byte) 79,
    (byte) 168,
    (byte) 104,
    (byte) 107,
    (byte) 129,
    (byte) 178,
    (byte) 113,
    (byte) 100,
    (byte) 218,
    (byte) 139,
    (byte) 248,
    (byte) 235,
    (byte) 15,
    (byte) 75,
    (byte) 112 /*0x70*/,
    (byte) 86,
    (byte) 157,
    (byte) 53,
    (byte) 30,
    (byte) 36,
    (byte) 14,
    (byte) 94,
    (byte) 99,
    (byte) 88,
    (byte) 209,
    (byte) 162,
    (byte) 37,
    (byte) 34,
    (byte) 124,
    (byte) 59,
    (byte) 1,
    (byte) 33,
    (byte) 120,
    (byte) 135,
    (byte) 212,
    (byte) 0,
    (byte) 70,
    (byte) 87,
    (byte) 159,
    (byte) 211,
    (byte) 39,
    (byte) 82,
    (byte) 76,
    (byte) 54,
    (byte) 2,
    (byte) 231,
    (byte) 160 /*0xA0*/,
    (byte) 196,
    (byte) 200,
    (byte) 158,
    (byte) 234,
    (byte) 191,
    (byte) 138,
    (byte) 210,
    (byte) 64 /*0x40*/,
    (byte) 199,
    (byte) 56,
    (byte) 181,
    (byte) 163,
    (byte) 247,
    (byte) 242,
    (byte) 206,
    (byte) 249,
    (byte) 97,
    (byte) 21,
    (byte) 161,
    (byte) 224 /*0xE0*/,
    (byte) 174,
    (byte) 93,
    (byte) 164,
    (byte) 155,
    (byte) 52,
    (byte) 26,
    (byte) 85,
    (byte) 173,
    (byte) 147,
    (byte) 50,
    (byte) 48 /*0x30*/,
    (byte) 245,
    (byte) 140,
    (byte) 177,
    (byte) 227,
    (byte) 29,
    (byte) 246,
    (byte) 226,
    (byte) 46,
    (byte) 130,
    (byte) 102,
    (byte) 202,
    (byte) 96 /*0x60*/,
    (byte) 192 /*0xC0*/,
    (byte) 41,
    (byte) 35,
    (byte) 171,
    (byte) 13,
    (byte) 83,
    (byte) 78,
    (byte) 111,
    (byte) 213,
    (byte) 219,
    (byte) 55,
    (byte) 69,
    (byte) 222,
    (byte) 253,
    (byte) 142,
    (byte) 47,
    (byte) 3,
    byte.MaxValue,
    (byte) 106,
    (byte) 114,
    (byte) 109,
    (byte) 108,
    (byte) 91,
    (byte) 81,
    (byte) 141,
    (byte) 27,
    (byte) 175,
    (byte) 146,
    (byte) 187,
    (byte) 221,
    (byte) 188,
    (byte) 127 /*0x7F*/,
    (byte) 17,
    (byte) 217,
    (byte) 92,
    (byte) 65,
    (byte) 31 /*0x1F*/,
    (byte) 16 /*0x10*/,
    (byte) 90,
    (byte) 216,
    (byte) 10,
    (byte) 193,
    (byte) 49,
    (byte) 136,
    (byte) 165,
    (byte) 205,
    (byte) 123,
    (byte) 189,
    (byte) 45,
    (byte) 116,
    (byte) 208 /*0xD0*/,
    (byte) 18,
    (byte) 184,
    (byte) 229,
    (byte) 180,
    (byte) 176 /*0xB0*/,
    (byte) 137,
    (byte) 105,
    (byte) 151,
    (byte) 74,
    (byte) 12,
    (byte) 150,
    (byte) 119,
    (byte) 126,
    (byte) 101,
    (byte) 185,
    (byte) 241,
    (byte) 9,
    (byte) 197,
    (byte) 110,
    (byte) 198,
    (byte) 132,
    (byte) 24,
    (byte) 240 /*0xF0*/,
    (byte) 125,
    (byte) 236,
    (byte) 58,
    (byte) 220,
    (byte) 77,
    (byte) 32 /*0x20*/,
    (byte) 121,
    (byte) 238,
    (byte) 95,
    (byte) 62,
    (byte) 215,
    (byte) 203,
    (byte) 57,
    (byte) 72
  };
  private static readonly uint[] CK = new uint[32 /*0x20*/]
  {
    462357U,
    472066609U,
    943670861U,
    1415275113U,
    1886879365U,
    2358483617U,
    2830087869U,
    3301692121U,
    3773296373U,
    4228057617U,
    404694573U,
    876298825U,
    1347903077U,
    1819507329U,
    2291111581U,
    2762715833U,
    3234320085U,
    3705924337U,
    4177462797U,
    337322537U,
    808926789U,
    1280531041U,
    1752135293U,
    2223739545U,
    2695343797U,
    3166948049U,
    3638552301U,
    4110090761U,
    269950501U,
    741554753U,
    1213159005U,
    1684763257U
  };
  private static readonly uint[] FK = new uint[4]
  {
    2746333894U,
    1453994832U,
    1736282519U,
    2993693404U
  };
  private uint[] rk;

  private static uint tau(uint A)
  {
    return (uint) ((int) SM4Engine.Sbox[(int) (A >> 24)] << 24 | (int) SM4Engine.Sbox[(int) (A >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ | (int) SM4Engine.Sbox[(int) (A >> 8) & (int) byte.MaxValue] << 8) | (uint) SM4Engine.Sbox[(int) A & (int) byte.MaxValue];
  }

  private static uint L_ap(uint B) => B ^ Integers.RotateLeft(B, 13) ^ Integers.RotateLeft(B, 23);

  private uint T_ap(uint Z) => SM4Engine.L_ap(SM4Engine.tau(Z));

  private void ExpandKey(bool forEncryption, byte[] key)
  {
    uint num1 = Pack.BE_To_UInt32(key, 0) ^ SM4Engine.FK[0];
    uint num2 = Pack.BE_To_UInt32(key, 4) ^ SM4Engine.FK[1];
    uint num3 = Pack.BE_To_UInt32(key, 8) ^ SM4Engine.FK[2];
    uint num4 = Pack.BE_To_UInt32(key, 12) ^ SM4Engine.FK[3];
    if (forEncryption)
    {
      this.rk[0] = num1 ^ this.T_ap(num2 ^ num3 ^ num4 ^ SM4Engine.CK[0]);
      this.rk[1] = num2 ^ this.T_ap(num3 ^ num4 ^ this.rk[0] ^ SM4Engine.CK[1]);
      this.rk[2] = num3 ^ this.T_ap(num4 ^ this.rk[0] ^ this.rk[1] ^ SM4Engine.CK[2]);
      this.rk[3] = num4 ^ this.T_ap(this.rk[0] ^ this.rk[1] ^ this.rk[2] ^ SM4Engine.CK[3]);
      for (int index = 4; index < 32 /*0x20*/; ++index)
        this.rk[index] = this.rk[index - 4] ^ this.T_ap(this.rk[index - 3] ^ this.rk[index - 2] ^ this.rk[index - 1] ^ SM4Engine.CK[index]);
    }
    else
    {
      this.rk[31 /*0x1F*/] = num1 ^ this.T_ap(num2 ^ num3 ^ num4 ^ SM4Engine.CK[0]);
      this.rk[30] = num2 ^ this.T_ap(num3 ^ num4 ^ this.rk[31 /*0x1F*/] ^ SM4Engine.CK[1]);
      this.rk[29] = num3 ^ this.T_ap(num4 ^ this.rk[31 /*0x1F*/] ^ this.rk[30] ^ SM4Engine.CK[2]);
      this.rk[28] = num4 ^ this.T_ap(this.rk[31 /*0x1F*/] ^ this.rk[30] ^ this.rk[29] ^ SM4Engine.CK[3]);
      for (int index = 27; index >= 0; --index)
        this.rk[index] = this.rk[index + 4] ^ this.T_ap(this.rk[index + 3] ^ this.rk[index + 2] ^ this.rk[index + 1] ^ SM4Engine.CK[31 /*0x1F*/ - index]);
    }
  }

  private static uint L(uint B)
  {
    return B ^ Integers.RotateLeft(B, 2) ^ Integers.RotateLeft(B, 10) ^ Integers.RotateLeft(B, 18) ^ Integers.RotateLeft(B, 24);
  }

  private static uint T(uint Z) => SM4Engine.L(SM4Engine.tau(Z));

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    byte[] key = parameters is KeyParameter keyParameter ? keyParameter.GetKey() : throw new ArgumentException("invalid parameter passed to SM4 init - " + Platform.GetTypeName((object) parameters), nameof (parameters));
    if (key.Length != 16 /*0x10*/)
      throw new ArgumentException("SM4 requires a 128 bit key", nameof (parameters));
    if (this.rk == null)
      this.rk = new uint[32 /*0x20*/];
    this.ExpandKey(forEncryption, key);
  }

  public virtual string AlgorithmName => "SM4";

  public virtual int GetBlockSize() => 16 /*0x10*/;

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.rk == null)
      throw new InvalidOperationException("SM4 not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 16 /*0x10*/, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer too short");
    uint uint32_1 = Pack.BE_To_UInt32(input, inOff);
    uint uint32_2 = Pack.BE_To_UInt32(input, inOff + 4);
    uint uint32_3 = Pack.BE_To_UInt32(input, inOff + 8);
    uint uint32_4 = Pack.BE_To_UInt32(input, inOff + 12);
    for (int index = 0; index < 32 /*0x20*/; index += 4)
    {
      uint32_1 ^= SM4Engine.T(uint32_2 ^ uint32_3 ^ uint32_4 ^ this.rk[index]);
      uint32_2 ^= SM4Engine.T(uint32_3 ^ uint32_4 ^ uint32_1 ^ this.rk[index + 1]);
      uint32_3 ^= SM4Engine.T(uint32_4 ^ uint32_1 ^ uint32_2 ^ this.rk[index + 2]);
      uint32_4 ^= SM4Engine.T(uint32_1 ^ uint32_2 ^ uint32_3 ^ this.rk[index + 3]);
    }
    Pack.UInt32_To_BE(uint32_4, output, outOff);
    Pack.UInt32_To_BE(uint32_3, output, outOff + 4);
    Pack.UInt32_To_BE(uint32_2, output, outOff + 8);
    Pack.UInt32_To_BE(uint32_1, output, outOff + 12);
    return 16 /*0x10*/;
  }
}
