// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.SkipjackEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public sealed class SkipjackEngine : IBlockCipher
{
  private const int BLOCK_SIZE = 8;
  private static readonly short[] ftable = new short[256 /*0x0100*/]
  {
    (short) 163,
    (short) 215,
    (short) 9,
    (short) 131,
    (short) 248,
    (short) 72,
    (short) 246,
    (short) 244,
    (short) 179,
    (short) 33,
    (short) 21,
    (short) 120,
    (short) 153,
    (short) 177,
    (short) 175,
    (short) 249,
    (short) 231,
    (short) 45,
    (short) 77,
    (short) 138,
    (short) 206,
    (short) 76,
    (short) 202,
    (short) 46,
    (short) 82,
    (short) 149,
    (short) 217,
    (short) 30,
    (short) 78,
    (short) 56,
    (short) 68,
    (short) 40,
    (short) 10,
    (short) 223,
    (short) 2,
    (short) 160 /*0xA0*/,
    (short) 23,
    (short) 241,
    (short) 96 /*0x60*/,
    (short) 104,
    (short) 18,
    (short) 183,
    (short) 122,
    (short) 195,
    (short) 233,
    (short) 250,
    (short) 61,
    (short) 83,
    (short) 150,
    (short) 132,
    (short) 107,
    (short) 186,
    (short) 242,
    (short) 99,
    (short) 154,
    (short) 25,
    (short) 124,
    (short) 174,
    (short) 229,
    (short) 245,
    (short) 247,
    (short) 22,
    (short) 106,
    (short) 162,
    (short) 57,
    (short) 182,
    (short) 123,
    (short) 15,
    (short) 193,
    (short) 147,
    (short) 129,
    (short) 27,
    (short) 238,
    (short) 180,
    (short) 26,
    (short) 234,
    (short) 208 /*0xD0*/,
    (short) 145,
    (short) 47,
    (short) 184,
    (short) 85,
    (short) 185,
    (short) 218,
    (short) 133,
    (short) 63 /*0x3F*/,
    (short) 65,
    (short) 191,
    (short) 224 /*0xE0*/,
    (short) 90,
    (short) 88,
    (short) 128 /*0x80*/,
    (short) 95,
    (short) 102,
    (short) 11,
    (short) 216,
    (short) 144 /*0x90*/,
    (short) 53,
    (short) 213,
    (short) 192 /*0xC0*/,
    (short) 167,
    (short) 51,
    (short) 6,
    (short) 101,
    (short) 105,
    (short) 69,
    (short) 0,
    (short) 148,
    (short) 86,
    (short) 109,
    (short) 152,
    (short) 155,
    (short) 118,
    (short) 151,
    (short) 252,
    (short) 178,
    (short) 194,
    (short) 176 /*0xB0*/,
    (short) 254,
    (short) 219,
    (short) 32 /*0x20*/,
    (short) 225,
    (short) 235,
    (short) 214,
    (short) 228,
    (short) 221,
    (short) 71,
    (short) 74,
    (short) 29,
    (short) 66,
    (short) 237,
    (short) 158,
    (short) 110,
    (short) 73,
    (short) 60,
    (short) 205,
    (short) 67,
    (short) 39,
    (short) 210,
    (short) 7,
    (short) 212,
    (short) 222,
    (short) 199,
    (short) 103,
    (short) 24,
    (short) 137,
    (short) 203,
    (short) 48 /*0x30*/,
    (short) 31 /*0x1F*/,
    (short) 141,
    (short) 198,
    (short) 143,
    (short) 170,
    (short) 200,
    (short) 116,
    (short) 220,
    (short) 201,
    (short) 93,
    (short) 92,
    (short) 49,
    (short) 164,
    (short) 112 /*0x70*/,
    (short) 136,
    (short) 97,
    (short) 44,
    (short) 159,
    (short) 13,
    (short) 43,
    (short) 135,
    (short) 80 /*0x50*/,
    (short) 130,
    (short) 84,
    (short) 100,
    (short) 38,
    (short) 125,
    (short) 3,
    (short) 64 /*0x40*/,
    (short) 52,
    (short) 75,
    (short) 28,
    (short) 115,
    (short) 209,
    (short) 196,
    (short) 253,
    (short) 59,
    (short) 204,
    (short) 251,
    (short) sbyte.MaxValue,
    (short) 171,
    (short) 230,
    (short) 62,
    (short) 91,
    (short) 165,
    (short) 173,
    (short) 4,
    (short) 35,
    (short) 156,
    (short) 20,
    (short) 81,
    (short) 34,
    (short) 240 /*0xF0*/,
    (short) 41,
    (short) 121,
    (short) 113,
    (short) 126,
    (short) byte.MaxValue,
    (short) 140,
    (short) 14,
    (short) 226,
    (short) 12,
    (short) 239,
    (short) 188,
    (short) 114,
    (short) 117,
    (short) 111,
    (short) 55,
    (short) 161,
    (short) 236,
    (short) 211,
    (short) 142,
    (short) 98,
    (short) 139,
    (short) 134,
    (short) 16 /*0x10*/,
    (short) 232,
    (short) 8,
    (short) 119,
    (short) 17,
    (short) 190,
    (short) 146,
    (short) 79,
    (short) 36,
    (short) 197,
    (short) 50,
    (short) 54,
    (short) 157,
    (short) 207,
    (short) 243,
    (short) 166,
    (short) 187,
    (short) 172,
    (short) 94,
    (short) 108,
    (short) 169,
    (short) 19,
    (short) 87,
    (short) 37,
    (short) 181,
    (short) 227,
    (short) 189,
    (short) 168,
    (short) 58,
    (short) 1,
    (short) 5,
    (short) 89,
    (short) 42,
    (short) 70
  };
  private int[] key0;
  private int[] key1;
  private int[] key2;
  private int[] key3;
  private bool encrypting;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    byte[] numArray = parameters is KeyParameter keyParameter ? keyParameter.GetKey() : throw new ArgumentException("invalid parameter passed to SKIPJACK init - " + Platform.GetTypeName((object) parameters));
    this.encrypting = forEncryption;
    this.key0 = new int[32 /*0x20*/];
    this.key1 = new int[32 /*0x20*/];
    this.key2 = new int[32 /*0x20*/];
    this.key3 = new int[32 /*0x20*/];
    for (int index = 0; index < 32 /*0x20*/; ++index)
    {
      this.key0[index] = (int) numArray[index * 4 % 10];
      this.key1[index] = (int) numArray[(index * 4 + 1) % 10];
      this.key2[index] = (int) numArray[(index * 4 + 2) % 10];
      this.key3[index] = (int) numArray[(index * 4 + 3) % 10];
    }
  }

  public string AlgorithmName => "SKIPJACK";

  public int GetBlockSize() => 8;

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.key1 == null)
      throw new InvalidOperationException("SKIPJACK engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 8, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 8, "output buffer too short");
    if (this.encrypting)
      this.EncryptBlock(input, inOff, output, outOff);
    else
      this.DecryptBlock(input, inOff, output, outOff);
    return 8;
  }

  private int G(int k, int w)
  {
    int num1 = w >> 8 & (int) byte.MaxValue;
    int num2 = w & (int) byte.MaxValue;
    int num3 = (int) SkipjackEngine.ftable[num2 ^ this.key0[k]] ^ num1;
    int num4 = (int) SkipjackEngine.ftable[num3 ^ this.key1[k]] ^ num2;
    int num5 = (int) SkipjackEngine.ftable[num4 ^ this.key2[k]] ^ num3;
    int num6 = (int) SkipjackEngine.ftable[num5 ^ this.key3[k]] ^ num4;
    return (num5 << 8) + num6;
  }

  private int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    int w = ((int) input[inOff] << 8) + ((int) input[inOff + 1] & (int) byte.MaxValue);
    int num1 = ((int) input[inOff + 2] << 8) + ((int) input[inOff + 3] & (int) byte.MaxValue);
    int num2 = ((int) input[inOff + 4] << 8) + ((int) input[inOff + 5] & (int) byte.MaxValue);
    int num3 = ((int) input[inOff + 6] << 8) + ((int) input[inOff + 7] & (int) byte.MaxValue);
    int k = 0;
    for (int index1 = 0; index1 < 2; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        int num4 = num3;
        num3 = num2;
        num2 = num1;
        num1 = this.G(k, w);
        w = num1 ^ num4 ^ k + 1;
        ++k;
      }
      for (int index3 = 0; index3 < 8; ++index3)
      {
        int num5 = num3;
        num3 = num2;
        num2 = w ^ num1 ^ k + 1;
        num1 = this.G(k, w);
        w = num5;
        ++k;
      }
    }
    outBytes[outOff] = (byte) (w >> 8);
    outBytes[outOff + 1] = (byte) w;
    outBytes[outOff + 2] = (byte) (num1 >> 8);
    outBytes[outOff + 3] = (byte) num1;
    outBytes[outOff + 4] = (byte) (num2 >> 8);
    outBytes[outOff + 5] = (byte) num2;
    outBytes[outOff + 6] = (byte) (num3 >> 8);
    outBytes[outOff + 7] = (byte) num3;
    return 8;
  }

  private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    int num1 = ((int) input[inOff] << 8) + ((int) input[inOff + 1] & (int) byte.MaxValue);
    int w = ((int) input[inOff + 2] << 8) + ((int) input[inOff + 3] & (int) byte.MaxValue);
    int num2 = ((int) input[inOff + 4] << 8) + ((int) input[inOff + 5] & (int) byte.MaxValue);
    int num3 = ((int) input[inOff + 6] << 8) + ((int) input[inOff + 7] & (int) byte.MaxValue);
    int k = 31 /*0x1F*/;
    for (int index1 = 0; index1 < 2; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        int num4 = num2;
        num2 = num3;
        num3 = num1;
        num1 = this.H(k, w);
        w = num1 ^ num4 ^ k + 1;
        --k;
      }
      for (int index3 = 0; index3 < 8; ++index3)
      {
        int num5 = num2;
        num2 = num3;
        num3 = w ^ num1 ^ k + 1;
        num1 = this.H(k, w);
        w = num5;
        --k;
      }
    }
    outBytes[outOff] = (byte) (num1 >> 8);
    outBytes[outOff + 1] = (byte) num1;
    outBytes[outOff + 2] = (byte) (w >> 8);
    outBytes[outOff + 3] = (byte) w;
    outBytes[outOff + 4] = (byte) (num2 >> 8);
    outBytes[outOff + 5] = (byte) num2;
    outBytes[outOff + 6] = (byte) (num3 >> 8);
    outBytes[outOff + 7] = (byte) num3;
    return 8;
  }

  private int H(int k, int w)
  {
    int num1 = w & (int) byte.MaxValue;
    int num2 = w >> 8 & (int) byte.MaxValue;
    int num3 = (int) SkipjackEngine.ftable[num2 ^ this.key3[k]] ^ num1;
    int num4 = (int) SkipjackEngine.ftable[num3 ^ this.key2[k]] ^ num2;
    int num5 = (int) SkipjackEngine.ftable[num4 ^ this.key1[k]] ^ num3;
    return (((int) SkipjackEngine.ftable[num5 ^ this.key0[k]] ^ num4) << 8) + num5;
  }
}
