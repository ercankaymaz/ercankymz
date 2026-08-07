// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.AesLightEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public sealed class AesLightEngine : IBlockCipher
{
  private static readonly byte[] S = new byte[256 /*0x0100*/]
  {
    (byte) 99,
    (byte) 124,
    (byte) 119,
    (byte) 123,
    (byte) 242,
    (byte) 107,
    (byte) 111,
    (byte) 197,
    (byte) 48 /*0x30*/,
    (byte) 1,
    (byte) 103,
    (byte) 43,
    (byte) 254,
    (byte) 215,
    (byte) 171,
    (byte) 118,
    (byte) 202,
    (byte) 130,
    (byte) 201,
    (byte) 125,
    (byte) 250,
    (byte) 89,
    (byte) 71,
    (byte) 240 /*0xF0*/,
    (byte) 173,
    (byte) 212,
    (byte) 162,
    (byte) 175,
    (byte) 156,
    (byte) 164,
    (byte) 114,
    (byte) 192 /*0xC0*/,
    (byte) 183,
    (byte) 253,
    (byte) 147,
    (byte) 38,
    (byte) 54,
    (byte) 63 /*0x3F*/,
    (byte) 247,
    (byte) 204,
    (byte) 52,
    (byte) 165,
    (byte) 229,
    (byte) 241,
    (byte) 113,
    (byte) 216,
    (byte) 49,
    (byte) 21,
    (byte) 4,
    (byte) 199,
    (byte) 35,
    (byte) 195,
    (byte) 24,
    (byte) 150,
    (byte) 5,
    (byte) 154,
    (byte) 7,
    (byte) 18,
    (byte) 128 /*0x80*/,
    (byte) 226,
    (byte) 235,
    (byte) 39,
    (byte) 178,
    (byte) 117,
    (byte) 9,
    (byte) 131,
    (byte) 44,
    (byte) 26,
    (byte) 27,
    (byte) 110,
    (byte) 90,
    (byte) 160 /*0xA0*/,
    (byte) 82,
    (byte) 59,
    (byte) 214,
    (byte) 179,
    (byte) 41,
    (byte) 227,
    (byte) 47,
    (byte) 132,
    (byte) 83,
    (byte) 209,
    (byte) 0,
    (byte) 237,
    (byte) 32 /*0x20*/,
    (byte) 252,
    (byte) 177,
    (byte) 91,
    (byte) 106,
    (byte) 203,
    (byte) 190,
    (byte) 57,
    (byte) 74,
    (byte) 76,
    (byte) 88,
    (byte) 207,
    (byte) 208 /*0xD0*/,
    (byte) 239,
    (byte) 170,
    (byte) 251,
    (byte) 67,
    (byte) 77,
    (byte) 51,
    (byte) 133,
    (byte) 69,
    (byte) 249,
    (byte) 2,
    (byte) 127 /*0x7F*/,
    (byte) 80 /*0x50*/,
    (byte) 60,
    (byte) 159,
    (byte) 168,
    (byte) 81,
    (byte) 163,
    (byte) 64 /*0x40*/,
    (byte) 143,
    (byte) 146,
    (byte) 157,
    (byte) 56,
    (byte) 245,
    (byte) 188,
    (byte) 182,
    (byte) 218,
    (byte) 33,
    (byte) 16 /*0x10*/,
    byte.MaxValue,
    (byte) 243,
    (byte) 210,
    (byte) 205,
    (byte) 12,
    (byte) 19,
    (byte) 236,
    (byte) 95,
    (byte) 151,
    (byte) 68,
    (byte) 23,
    (byte) 196,
    (byte) 167,
    (byte) 126,
    (byte) 61,
    (byte) 100,
    (byte) 93,
    (byte) 25,
    (byte) 115,
    (byte) 96 /*0x60*/,
    (byte) 129,
    (byte) 79,
    (byte) 220,
    (byte) 34,
    (byte) 42,
    (byte) 144 /*0x90*/,
    (byte) 136,
    (byte) 70,
    (byte) 238,
    (byte) 184,
    (byte) 20,
    (byte) 222,
    (byte) 94,
    (byte) 11,
    (byte) 219,
    (byte) 224 /*0xE0*/,
    (byte) 50,
    (byte) 58,
    (byte) 10,
    (byte) 73,
    (byte) 6,
    (byte) 36,
    (byte) 92,
    (byte) 194,
    (byte) 211,
    (byte) 172,
    (byte) 98,
    (byte) 145,
    (byte) 149,
    (byte) 228,
    (byte) 121,
    (byte) 231,
    (byte) 200,
    (byte) 55,
    (byte) 109,
    (byte) 141,
    (byte) 213,
    (byte) 78,
    (byte) 169,
    (byte) 108,
    (byte) 86,
    (byte) 244,
    (byte) 234,
    (byte) 101,
    (byte) 122,
    (byte) 174,
    (byte) 8,
    (byte) 186,
    (byte) 120,
    (byte) 37,
    (byte) 46,
    (byte) 28,
    (byte) 166,
    (byte) 180,
    (byte) 198,
    (byte) 232,
    (byte) 221,
    (byte) 116,
    (byte) 31 /*0x1F*/,
    (byte) 75,
    (byte) 189,
    (byte) 139,
    (byte) 138,
    (byte) 112 /*0x70*/,
    (byte) 62,
    (byte) 181,
    (byte) 102,
    (byte) 72,
    (byte) 3,
    (byte) 246,
    (byte) 14,
    (byte) 97,
    (byte) 53,
    (byte) 87,
    (byte) 185,
    (byte) 134,
    (byte) 193,
    (byte) 29,
    (byte) 158,
    (byte) 225,
    (byte) 248,
    (byte) 152,
    (byte) 17,
    (byte) 105,
    (byte) 217,
    (byte) 142,
    (byte) 148,
    (byte) 155,
    (byte) 30,
    (byte) 135,
    (byte) 233,
    (byte) 206,
    (byte) 85,
    (byte) 40,
    (byte) 223,
    (byte) 140,
    (byte) 161,
    (byte) 137,
    (byte) 13,
    (byte) 191,
    (byte) 230,
    (byte) 66,
    (byte) 104,
    (byte) 65,
    (byte) 153,
    (byte) 45,
    (byte) 15,
    (byte) 176 /*0xB0*/,
    (byte) 84,
    (byte) 187,
    (byte) 22
  };
  private static readonly byte[] Si = new byte[256 /*0x0100*/]
  {
    (byte) 82,
    (byte) 9,
    (byte) 106,
    (byte) 213,
    (byte) 48 /*0x30*/,
    (byte) 54,
    (byte) 165,
    (byte) 56,
    (byte) 191,
    (byte) 64 /*0x40*/,
    (byte) 163,
    (byte) 158,
    (byte) 129,
    (byte) 243,
    (byte) 215,
    (byte) 251,
    (byte) 124,
    (byte) 227,
    (byte) 57,
    (byte) 130,
    (byte) 155,
    (byte) 47,
    byte.MaxValue,
    (byte) 135,
    (byte) 52,
    (byte) 142,
    (byte) 67,
    (byte) 68,
    (byte) 196,
    (byte) 222,
    (byte) 233,
    (byte) 203,
    (byte) 84,
    (byte) 123,
    (byte) 148,
    (byte) 50,
    (byte) 166,
    (byte) 194,
    (byte) 35,
    (byte) 61,
    (byte) 238,
    (byte) 76,
    (byte) 149,
    (byte) 11,
    (byte) 66,
    (byte) 250,
    (byte) 195,
    (byte) 78,
    (byte) 8,
    (byte) 46,
    (byte) 161,
    (byte) 102,
    (byte) 40,
    (byte) 217,
    (byte) 36,
    (byte) 178,
    (byte) 118,
    (byte) 91,
    (byte) 162,
    (byte) 73,
    (byte) 109,
    (byte) 139,
    (byte) 209,
    (byte) 37,
    (byte) 114,
    (byte) 248,
    (byte) 246,
    (byte) 100,
    (byte) 134,
    (byte) 104,
    (byte) 152,
    (byte) 22,
    (byte) 212,
    (byte) 164,
    (byte) 92,
    (byte) 204,
    (byte) 93,
    (byte) 101,
    (byte) 182,
    (byte) 146,
    (byte) 108,
    (byte) 112 /*0x70*/,
    (byte) 72,
    (byte) 80 /*0x50*/,
    (byte) 253,
    (byte) 237,
    (byte) 185,
    (byte) 218,
    (byte) 94,
    (byte) 21,
    (byte) 70,
    (byte) 87,
    (byte) 167,
    (byte) 141,
    (byte) 157,
    (byte) 132,
    (byte) 144 /*0x90*/,
    (byte) 216,
    (byte) 171,
    (byte) 0,
    (byte) 140,
    (byte) 188,
    (byte) 211,
    (byte) 10,
    (byte) 247,
    (byte) 228,
    (byte) 88,
    (byte) 5,
    (byte) 184,
    (byte) 179,
    (byte) 69,
    (byte) 6,
    (byte) 208 /*0xD0*/,
    (byte) 44,
    (byte) 30,
    (byte) 143,
    (byte) 202,
    (byte) 63 /*0x3F*/,
    (byte) 15,
    (byte) 2,
    (byte) 193,
    (byte) 175,
    (byte) 189,
    (byte) 3,
    (byte) 1,
    (byte) 19,
    (byte) 138,
    (byte) 107,
    (byte) 58,
    (byte) 145,
    (byte) 17,
    (byte) 65,
    (byte) 79,
    (byte) 103,
    (byte) 220,
    (byte) 234,
    (byte) 151,
    (byte) 242,
    (byte) 207,
    (byte) 206,
    (byte) 240 /*0xF0*/,
    (byte) 180,
    (byte) 230,
    (byte) 115,
    (byte) 150,
    (byte) 172,
    (byte) 116,
    (byte) 34,
    (byte) 231,
    (byte) 173,
    (byte) 53,
    (byte) 133,
    (byte) 226,
    (byte) 249,
    (byte) 55,
    (byte) 232,
    (byte) 28,
    (byte) 117,
    (byte) 223,
    (byte) 110,
    (byte) 71,
    (byte) 241,
    (byte) 26,
    (byte) 113,
    (byte) 29,
    (byte) 41,
    (byte) 197,
    (byte) 137,
    (byte) 111,
    (byte) 183,
    (byte) 98,
    (byte) 14,
    (byte) 170,
    (byte) 24,
    (byte) 190,
    (byte) 27,
    (byte) 252,
    (byte) 86,
    (byte) 62,
    (byte) 75,
    (byte) 198,
    (byte) 210,
    (byte) 121,
    (byte) 32 /*0x20*/,
    (byte) 154,
    (byte) 219,
    (byte) 192 /*0xC0*/,
    (byte) 254,
    (byte) 120,
    (byte) 205,
    (byte) 90,
    (byte) 244,
    (byte) 31 /*0x1F*/,
    (byte) 221,
    (byte) 168,
    (byte) 51,
    (byte) 136,
    (byte) 7,
    (byte) 199,
    (byte) 49,
    (byte) 177,
    (byte) 18,
    (byte) 16 /*0x10*/,
    (byte) 89,
    (byte) 39,
    (byte) 128 /*0x80*/,
    (byte) 236,
    (byte) 95,
    (byte) 96 /*0x60*/,
    (byte) 81,
    (byte) 127 /*0x7F*/,
    (byte) 169,
    (byte) 25,
    (byte) 181,
    (byte) 74,
    (byte) 13,
    (byte) 45,
    (byte) 229,
    (byte) 122,
    (byte) 159,
    (byte) 147,
    (byte) 201,
    (byte) 156,
    (byte) 239,
    (byte) 160 /*0xA0*/,
    (byte) 224 /*0xE0*/,
    (byte) 59,
    (byte) 77,
    (byte) 174,
    (byte) 42,
    (byte) 245,
    (byte) 176 /*0xB0*/,
    (byte) 200,
    (byte) 235,
    (byte) 187,
    (byte) 60,
    (byte) 131,
    (byte) 83,
    (byte) 153,
    (byte) 97,
    (byte) 23,
    (byte) 43,
    (byte) 4,
    (byte) 126,
    (byte) 186,
    (byte) 119,
    (byte) 214,
    (byte) 38,
    (byte) 225,
    (byte) 105,
    (byte) 20,
    (byte) 99,
    (byte) 85,
    (byte) 33,
    (byte) 12,
    (byte) 125
  };
  private static readonly byte[] rcon = new byte[30]
  {
    (byte) 1,
    (byte) 2,
    (byte) 4,
    (byte) 8,
    (byte) 16 /*0x10*/,
    (byte) 32 /*0x20*/,
    (byte) 64 /*0x40*/,
    (byte) 128 /*0x80*/,
    (byte) 27,
    (byte) 54,
    (byte) 108,
    (byte) 216,
    (byte) 171,
    (byte) 77,
    (byte) 154,
    (byte) 47,
    (byte) 94,
    (byte) 188,
    (byte) 99,
    (byte) 198,
    (byte) 151,
    (byte) 53,
    (byte) 106,
    (byte) 212,
    (byte) 179,
    (byte) 125,
    (byte) 250,
    (byte) 239,
    (byte) 197,
    (byte) 145
  };
  private const uint m1 = 2155905152 /*0x80808080*/;
  private const uint m2 = 2139062143 /*0x7F7F7F7F*/;
  private const uint m3 = 27;
  private const uint m4 = 3233857728 /*0xC0C0C0C0*/;
  private const uint m5 = 1061109567 /*0x3F3F3F3F*/;
  private int ROUNDS;
  private uint[][] WorkingKey;
  private bool forEncryption;
  private const int BLOCK_SIZE = 16 /*0x10*/;

  private static uint Shift(uint r, int shift) => r >> shift | r << 32 /*0x20*/ - shift;

  private static uint FFmulX(uint x)
  {
    return (uint) (((int) x & 2139062143 /*0x7F7F7F7F*/) << 1 ^ (int) ((x & 2155905152U /*0x80808080*/) >> 7) * 27);
  }

  private static uint FFmulX2(uint x)
  {
    int num1 = ((int) x & 1061109567 /*0x3F3F3F3F*/) << 2;
    uint num2 = x & 3233857728U /*0xC0C0C0C0*/;
    uint num3 = num2 ^ num2 >> 1;
    int num4 = (int) (num3 >> 2);
    return (uint) (num1 ^ num4) ^ num3 >> 5;
  }

  private static uint Mcol(uint x)
  {
    uint num1 = AesLightEngine.Shift(x, 8);
    uint num2 = x ^ num1;
    return AesLightEngine.Shift(num2, 16 /*0x10*/) ^ num1 ^ AesLightEngine.FFmulX(num2);
  }

  private static uint Inv_Mcol(uint x)
  {
    uint r1 = x;
    uint x1 = r1 ^ AesLightEngine.Shift(r1, 8);
    uint x2 = r1 ^ AesLightEngine.FFmulX(x1);
    uint r2 = x1 ^ AesLightEngine.FFmulX2(x2);
    return x2 ^ r2 ^ AesLightEngine.Shift(r2, 16 /*0x10*/);
  }

  private static uint SubWord(uint x)
  {
    return (uint) ((int) AesLightEngine.S[(int) x & (int) byte.MaxValue] | (int) AesLightEngine.S[(int) (x >> 8) & (int) byte.MaxValue] << 8 | (int) AesLightEngine.S[(int) (x >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ | (int) AesLightEngine.S[(int) (x >> 24) & (int) byte.MaxValue] << 24);
  }

  private uint[][] GenerateWorkingKey(KeyParameter keyParameter, bool forEncryption)
  {
    byte[] key = keyParameter.GetKey();
    int length = key.Length;
    if (length < 16 /*0x10*/ || length > 32 /*0x20*/ || (length & 7) != 0)
      throw new ArgumentException("Key length not 128/192/256 bits.");
    int num1 = length >> 2;
    this.ROUNDS = num1 + 6;
    uint[][] workingKey = new uint[this.ROUNDS + 1][];
    for (int index = 0; index <= this.ROUNDS; ++index)
      workingKey[index] = new uint[4];
    switch (num1)
    {
      case 4:
        uint uint32_1 = Pack.LE_To_UInt32(key, 0);
        workingKey[0][0] = uint32_1;
        uint uint32_2 = Pack.LE_To_UInt32(key, 4);
        workingKey[0][1] = uint32_2;
        uint uint32_3 = Pack.LE_To_UInt32(key, 8);
        workingKey[0][2] = uint32_3;
        uint uint32_4 = Pack.LE_To_UInt32(key, 12);
        workingKey[0][3] = uint32_4;
        for (int index = 1; index <= 10; ++index)
        {
          uint num2 = AesLightEngine.SubWord(AesLightEngine.Shift(uint32_4, 8)) ^ (uint) AesLightEngine.rcon[index - 1];
          uint32_1 ^= num2;
          workingKey[index][0] = uint32_1;
          uint32_2 ^= uint32_1;
          workingKey[index][1] = uint32_2;
          uint32_3 ^= uint32_2;
          workingKey[index][2] = uint32_3;
          uint32_4 ^= uint32_3;
          workingKey[index][3] = uint32_4;
        }
        break;
      case 6:
        uint uint32_5 = Pack.LE_To_UInt32(key, 0);
        workingKey[0][0] = uint32_5;
        uint uint32_6 = Pack.LE_To_UInt32(key, 4);
        workingKey[0][1] = uint32_6;
        uint uint32_7 = Pack.LE_To_UInt32(key, 8);
        workingKey[0][2] = uint32_7;
        uint uint32_8 = Pack.LE_To_UInt32(key, 12);
        workingKey[0][3] = uint32_8;
        uint uint32_9 = Pack.LE_To_UInt32(key, 16 /*0x10*/);
        workingKey[1][0] = uint32_9;
        uint uint32_10 = Pack.LE_To_UInt32(key, 20);
        workingKey[1][1] = uint32_10;
        uint num3 = AesLightEngine.SubWord(AesLightEngine.Shift(uint32_10, 8)) ^ 1U;
        uint num4 = 2;
        uint num5 = uint32_5 ^ num3;
        workingKey[1][2] = num5;
        uint num6 = uint32_6 ^ num5;
        workingKey[1][3] = num6;
        uint num7 = uint32_7 ^ num6;
        workingKey[2][0] = num7;
        uint num8 = uint32_8 ^ num7;
        workingKey[2][1] = num8;
        uint num9 = uint32_9 ^ num8;
        workingKey[2][2] = num9;
        uint r1 = uint32_10 ^ num9;
        workingKey[2][3] = r1;
        for (int index = 3; index < 12; index += 3)
        {
          uint num10 = AesLightEngine.SubWord(AesLightEngine.Shift(r1, 8)) ^ num4;
          uint num11 = num4 << 1;
          uint num12 = num5 ^ num10;
          workingKey[index][0] = num12;
          uint num13 = num6 ^ num12;
          workingKey[index][1] = num13;
          uint num14 = num7 ^ num13;
          workingKey[index][2] = num14;
          uint num15 = num8 ^ num14;
          workingKey[index][3] = num15;
          uint num16 = num9 ^ num15;
          workingKey[index + 1][0] = num16;
          uint r2 = r1 ^ num16;
          workingKey[index + 1][1] = r2;
          uint num17 = AesLightEngine.SubWord(AesLightEngine.Shift(r2, 8)) ^ num11;
          num4 = num11 << 1;
          num5 = num12 ^ num17;
          workingKey[index + 1][2] = num5;
          num6 = num13 ^ num5;
          workingKey[index + 1][3] = num6;
          num7 = num14 ^ num6;
          workingKey[index + 2][0] = num7;
          num8 = num15 ^ num7;
          workingKey[index + 2][1] = num8;
          num9 = num16 ^ num8;
          workingKey[index + 2][2] = num9;
          r1 = r2 ^ num9;
          workingKey[index + 2][3] = r1;
        }
        uint num18 = AesLightEngine.SubWord(AesLightEngine.Shift(r1, 8)) ^ num4;
        uint num19 = num5 ^ num18;
        workingKey[12][0] = num19;
        uint num20 = num6 ^ num19;
        workingKey[12][1] = num20;
        uint num21 = num7 ^ num20;
        workingKey[12][2] = num21;
        uint num22 = num8 ^ num21;
        workingKey[12][3] = num22;
        break;
      case 8:
        uint uint32_11 = Pack.LE_To_UInt32(key, 0);
        workingKey[0][0] = uint32_11;
        uint uint32_12 = Pack.LE_To_UInt32(key, 4);
        workingKey[0][1] = uint32_12;
        uint uint32_13 = Pack.LE_To_UInt32(key, 8);
        workingKey[0][2] = uint32_13;
        uint uint32_14 = Pack.LE_To_UInt32(key, 12);
        workingKey[0][3] = uint32_14;
        uint uint32_15 = Pack.LE_To_UInt32(key, 16 /*0x10*/);
        workingKey[1][0] = uint32_15;
        uint uint32_16 = Pack.LE_To_UInt32(key, 20);
        workingKey[1][1] = uint32_16;
        uint uint32_17 = Pack.LE_To_UInt32(key, 24);
        workingKey[1][2] = uint32_17;
        uint uint32_18 = Pack.LE_To_UInt32(key, 28);
        workingKey[1][3] = uint32_18;
        uint num23 = 1;
        for (int index = 2; index < 14; index += 2)
        {
          uint num24 = AesLightEngine.SubWord(AesLightEngine.Shift(uint32_18, 8)) ^ num23;
          num23 <<= 1;
          uint32_11 ^= num24;
          workingKey[index][0] = uint32_11;
          uint32_12 ^= uint32_11;
          workingKey[index][1] = uint32_12;
          uint32_13 ^= uint32_12;
          workingKey[index][2] = uint32_13;
          uint32_14 ^= uint32_13;
          workingKey[index][3] = uint32_14;
          uint num25 = AesLightEngine.SubWord(uint32_14);
          uint32_15 ^= num25;
          workingKey[index + 1][0] = uint32_15;
          uint32_16 ^= uint32_15;
          workingKey[index + 1][1] = uint32_16;
          uint32_17 ^= uint32_16;
          workingKey[index + 1][2] = uint32_17;
          uint32_18 ^= uint32_17;
          workingKey[index + 1][3] = uint32_18;
        }
        uint num26 = AesLightEngine.SubWord(AesLightEngine.Shift(uint32_18, 8)) ^ num23;
        uint num27 = uint32_11 ^ num26;
        workingKey[14][0] = num27;
        uint num28 = uint32_12 ^ num27;
        workingKey[14][1] = num28;
        uint num29 = uint32_13 ^ num28;
        workingKey[14][2] = num29;
        uint num30 = uint32_14 ^ num29;
        workingKey[14][3] = num30;
        break;
      default:
        throw new InvalidOperationException("Should never get here");
    }
    if (!forEncryption)
    {
      for (int index1 = 1; index1 < this.ROUNDS; ++index1)
      {
        uint[] numArray = workingKey[index1];
        for (int index2 = 0; index2 < 4; ++index2)
          numArray[index2] = AesLightEngine.Inv_Mcol(numArray[index2]);
      }
    }
    return workingKey;
  }

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.WorkingKey = parameters is KeyParameter keyParameter ? this.GenerateWorkingKey(keyParameter, forEncryption) : throw new ArgumentException("invalid parameter passed to AES init - " + Platform.GetTypeName((object) parameters));
    this.forEncryption = forEncryption;
  }

  public string AlgorithmName => "AES";

  public int GetBlockSize() => 16 /*0x10*/;

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.WorkingKey == null)
      throw new InvalidOperationException("AES engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 16 /*0x10*/, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer too short");
    if (this.forEncryption)
      this.EncryptBlock(input, inOff, output, outOff, this.WorkingKey);
    else
      this.DecryptBlock(input, inOff, output, outOff, this.WorkingKey);
    return 16 /*0x10*/;
  }

  private void EncryptBlock(byte[] input, int inOff, byte[] output, int outOff, uint[][] KW)
  {
    uint uint32_1 = Pack.LE_To_UInt32(input, inOff);
    uint uint32_2 = Pack.LE_To_UInt32(input, inOff + 4);
    uint uint32_3 = Pack.LE_To_UInt32(input, inOff + 8);
    int uint32_4 = (int) Pack.LE_To_UInt32(input, inOff + 12);
    uint[] numArray1 = KW[0];
    uint num1 = uint32_1 ^ numArray1[0];
    uint num2 = uint32_2 ^ numArray1[1];
    uint num3 = uint32_3 ^ numArray1[2];
    int num4 = (int) numArray1[3];
    uint num5 = (uint) (uint32_4 ^ num4);
    int num6 = 1;
    while (num6 < this.ROUNDS - 1)
    {
      uint[][] numArray2 = KW;
      int index1 = num6;
      int num7 = index1 + 1;
      uint[] numArray3 = numArray2[index1];
      uint num8 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num1 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num2 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num3 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num5 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray3[0];
      uint num9 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num2 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num3 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num5 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num1 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray3[1];
      uint num10 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num3 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num5 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num1 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num2 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray3[2];
      uint num11 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num5 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num1 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num2 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num3 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray3[3];
      uint[][] numArray4 = KW;
      int index2 = num7;
      num6 = index2 + 1;
      uint[] numArray5 = numArray4[index2];
      num1 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num8 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num9 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num10 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num11 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray5[0];
      num2 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num9 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num10 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num11 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num8 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray5[1];
      num3 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num10 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num11 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num8 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num9 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray5[2];
      num5 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num11 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num8 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num9 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num10 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray5[3];
    }
    uint[][] numArray6 = KW;
    int index3 = num6;
    int index4 = index3 + 1;
    uint[] numArray7 = numArray6[index3];
    uint num12 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num1 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num2 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num3 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num5 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray7[0];
    uint num13 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num2 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num3 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num5 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num1 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray7[1];
    uint num14 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num3 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num5 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num1 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num2 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray7[2];
    uint num15 = AesLightEngine.Mcol((uint) ((int) AesLightEngine.S[(int) num5 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num1 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num2 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num3 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray7[3];
    uint[] numArray8 = KW[index4];
    uint n1 = (uint) ((int) AesLightEngine.S[(int) num12 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num13 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num14 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num15 >> 24) & (int) byte.MaxValue] << 24) ^ numArray8[0];
    uint n2 = (uint) ((int) AesLightEngine.S[(int) num13 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num14 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num15 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num12 >> 24) & (int) byte.MaxValue] << 24) ^ numArray8[1];
    uint n3 = (uint) ((int) AesLightEngine.S[(int) num14 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num15 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num12 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num13 >> 24) & (int) byte.MaxValue] << 24) ^ numArray8[2];
    int n4 = (int) AesLightEngine.S[(int) num15 & (int) byte.MaxValue] ^ (int) AesLightEngine.S[(int) (num12 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.S[(int) (num13 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.S[(int) (num14 >> 24) & (int) byte.MaxValue] << 24 ^ (int) numArray8[3];
    Pack.UInt32_To_LE(n1, output, outOff);
    Pack.UInt32_To_LE(n2, output, outOff + 4);
    Pack.UInt32_To_LE(n3, output, outOff + 8);
    byte[] bs = output;
    int off = outOff + 12;
    Pack.UInt32_To_LE((uint) n4, bs, off);
  }

  private void DecryptBlock(byte[] input, int inOff, byte[] output, int outOff, uint[][] KW)
  {
    uint uint32_1 = Pack.LE_To_UInt32(input, inOff);
    uint uint32_2 = Pack.LE_To_UInt32(input, inOff + 4);
    uint uint32_3 = Pack.LE_To_UInt32(input, inOff + 8);
    int uint32_4 = (int) Pack.LE_To_UInt32(input, inOff + 12);
    uint[] numArray1 = KW[this.ROUNDS];
    uint num1 = uint32_1 ^ numArray1[0];
    uint num2 = uint32_2 ^ numArray1[1];
    uint num3 = uint32_3 ^ numArray1[2];
    int num4 = (int) numArray1[3];
    uint num5 = (uint) (uint32_4 ^ num4);
    int num6 = this.ROUNDS - 1;
    while (num6 > 1)
    {
      uint[][] numArray2 = KW;
      int index1 = num6;
      int num7 = index1 - 1;
      uint[] numArray3 = numArray2[index1];
      uint num8 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num1 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num5 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num3 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num2 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray3[0];
      uint num9 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num2 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num1 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num5 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num3 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray3[1];
      uint num10 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num3 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num2 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num1 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num5 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray3[2];
      uint num11 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num5 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num3 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num2 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num1 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray3[3];
      uint[][] numArray4 = KW;
      int index2 = num7;
      num6 = index2 - 1;
      uint[] numArray5 = numArray4[index2];
      num1 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num8 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num11 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num10 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num9 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray5[0];
      num2 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num9 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num8 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num11 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num10 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray5[1];
      num3 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num10 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num9 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num8 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num11 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray5[2];
      num5 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num11 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num10 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num9 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num8 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray5[3];
    }
    uint[] numArray6 = KW[1];
    uint num12 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num1 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num5 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num3 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num2 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray6[0];
    uint num13 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num2 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num1 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num5 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num3 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray6[1];
    uint num14 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num3 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num2 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num1 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num5 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray6[2];
    uint num15 = AesLightEngine.Inv_Mcol((uint) ((int) AesLightEngine.Si[(int) num5 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num3 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num2 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num1 >> 24) & (int) byte.MaxValue] << 24)) ^ numArray6[3];
    uint[] numArray7 = KW[0];
    uint n1 = (uint) ((int) AesLightEngine.Si[(int) num12 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num15 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num14 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num13 >> 24) & (int) byte.MaxValue] << 24) ^ numArray7[0];
    uint n2 = (uint) ((int) AesLightEngine.Si[(int) num13 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num12 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num15 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num14 >> 24) & (int) byte.MaxValue] << 24) ^ numArray7[1];
    uint n3 = (uint) ((int) AesLightEngine.Si[(int) num14 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num13 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num12 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num15 >> 24) & (int) byte.MaxValue] << 24) ^ numArray7[2];
    int n4 = (int) AesLightEngine.Si[(int) num15 & (int) byte.MaxValue] ^ (int) AesLightEngine.Si[(int) (num14 >> 8) & (int) byte.MaxValue] << 8 ^ (int) AesLightEngine.Si[(int) (num13 >> 16 /*0x10*/) & (int) byte.MaxValue] << 16 /*0x10*/ ^ (int) AesLightEngine.Si[(int) (num12 >> 24) & (int) byte.MaxValue] << 24 ^ (int) numArray7[3];
    Pack.UInt32_To_LE(n1, output, outOff);
    Pack.UInt32_To_LE(n2, output, outOff + 4);
    Pack.UInt32_To_LE(n3, output, outOff + 8);
    byte[] bs = output;
    int off = outOff + 12;
    Pack.UInt32_To_LE((uint) n4, bs, off);
  }
}
