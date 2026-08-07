// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.TwofishEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public sealed class TwofishEngine : IBlockCipher
{
  private static readonly byte[,] P = new byte[2, 256 /*0x0100*/]
  {
    {
      (byte) 169,
      (byte) 103,
      (byte) 179,
      (byte) 232,
      (byte) 4,
      (byte) 253,
      (byte) 163,
      (byte) 118,
      (byte) 154,
      (byte) 146,
      (byte) 128 /*0x80*/,
      (byte) 120,
      (byte) 228,
      (byte) 221,
      (byte) 209,
      (byte) 56,
      (byte) 13,
      (byte) 198,
      (byte) 53,
      (byte) 152,
      (byte) 24,
      (byte) 247,
      (byte) 236,
      (byte) 108,
      (byte) 67,
      (byte) 117,
      (byte) 55,
      (byte) 38,
      (byte) 250,
      (byte) 19,
      (byte) 148,
      (byte) 72,
      (byte) 242,
      (byte) 208 /*0xD0*/,
      (byte) 139,
      (byte) 48 /*0x30*/,
      (byte) 132,
      (byte) 84,
      (byte) 223,
      (byte) 35,
      (byte) 25,
      (byte) 91,
      (byte) 61,
      (byte) 89,
      (byte) 243,
      (byte) 174,
      (byte) 162,
      (byte) 130,
      (byte) 99,
      (byte) 1,
      (byte) 131,
      (byte) 46,
      (byte) 217,
      (byte) 81,
      (byte) 155,
      (byte) 124,
      (byte) 166,
      (byte) 235,
      (byte) 165,
      (byte) 190,
      (byte) 22,
      (byte) 12,
      (byte) 227,
      (byte) 97,
      (byte) 192 /*0xC0*/,
      (byte) 140,
      (byte) 58,
      (byte) 245,
      (byte) 115,
      (byte) 44,
      (byte) 37,
      (byte) 11,
      (byte) 187,
      (byte) 78,
      (byte) 137,
      (byte) 107,
      (byte) 83,
      (byte) 106,
      (byte) 180,
      (byte) 241,
      (byte) 225,
      (byte) 230,
      (byte) 189,
      (byte) 69,
      (byte) 226,
      (byte) 244,
      (byte) 182,
      (byte) 102,
      (byte) 204,
      (byte) 149,
      (byte) 3,
      (byte) 86,
      (byte) 212,
      (byte) 28,
      (byte) 30,
      (byte) 215,
      (byte) 251,
      (byte) 195,
      (byte) 142,
      (byte) 181,
      (byte) 233,
      (byte) 207,
      (byte) 191,
      (byte) 186,
      (byte) 234,
      (byte) 119,
      (byte) 57,
      (byte) 175,
      (byte) 51,
      (byte) 201,
      (byte) 98,
      (byte) 113,
      (byte) 129,
      (byte) 121,
      (byte) 9,
      (byte) 173,
      (byte) 36,
      (byte) 205,
      (byte) 249,
      (byte) 216,
      (byte) 229,
      (byte) 197,
      (byte) 185,
      (byte) 77,
      (byte) 68,
      (byte) 8,
      (byte) 134,
      (byte) 231,
      (byte) 161,
      (byte) 29,
      (byte) 170,
      (byte) 237,
      (byte) 6,
      (byte) 112 /*0x70*/,
      (byte) 178,
      (byte) 210,
      (byte) 65,
      (byte) 123,
      (byte) 160 /*0xA0*/,
      (byte) 17,
      (byte) 49,
      (byte) 194,
      (byte) 39,
      (byte) 144 /*0x90*/,
      (byte) 32 /*0x20*/,
      (byte) 246,
      (byte) 96 /*0x60*/,
      byte.MaxValue,
      (byte) 150,
      (byte) 92,
      (byte) 177,
      (byte) 171,
      (byte) 158,
      (byte) 156,
      (byte) 82,
      (byte) 27,
      (byte) 95,
      (byte) 147,
      (byte) 10,
      (byte) 239,
      (byte) 145,
      (byte) 133,
      (byte) 73,
      (byte) 238,
      (byte) 45,
      (byte) 79,
      (byte) 143,
      (byte) 59,
      (byte) 71,
      (byte) 135,
      (byte) 109,
      (byte) 70,
      (byte) 214,
      (byte) 62,
      (byte) 105,
      (byte) 100,
      (byte) 42,
      (byte) 206,
      (byte) 203,
      (byte) 47,
      (byte) 252,
      (byte) 151,
      (byte) 5,
      (byte) 122,
      (byte) 172,
      (byte) 127 /*0x7F*/,
      (byte) 213,
      (byte) 26,
      (byte) 75,
      (byte) 14,
      (byte) 167,
      (byte) 90,
      (byte) 40,
      (byte) 20,
      (byte) 63 /*0x3F*/,
      (byte) 41,
      (byte) 136,
      (byte) 60,
      (byte) 76,
      (byte) 2,
      (byte) 184,
      (byte) 218,
      (byte) 176 /*0xB0*/,
      (byte) 23,
      (byte) 85,
      (byte) 31 /*0x1F*/,
      (byte) 138,
      (byte) 125,
      (byte) 87,
      (byte) 199,
      (byte) 141,
      (byte) 116,
      (byte) 183,
      (byte) 196,
      (byte) 159,
      (byte) 114,
      (byte) 126,
      (byte) 21,
      (byte) 34,
      (byte) 18,
      (byte) 88,
      (byte) 7,
      (byte) 153,
      (byte) 52,
      (byte) 110,
      (byte) 80 /*0x50*/,
      (byte) 222,
      (byte) 104,
      (byte) 101,
      (byte) 188,
      (byte) 219,
      (byte) 248,
      (byte) 200,
      (byte) 168,
      (byte) 43,
      (byte) 64 /*0x40*/,
      (byte) 220,
      (byte) 254,
      (byte) 50,
      (byte) 164,
      (byte) 202,
      (byte) 16 /*0x10*/,
      (byte) 33,
      (byte) 240 /*0xF0*/,
      (byte) 211,
      (byte) 93,
      (byte) 15,
      (byte) 0,
      (byte) 111,
      (byte) 157,
      (byte) 54,
      (byte) 66,
      (byte) 74,
      (byte) 94,
      (byte) 193,
      (byte) 224 /*0xE0*/
    },
    {
      (byte) 117,
      (byte) 243,
      (byte) 198,
      (byte) 244,
      (byte) 219,
      (byte) 123,
      (byte) 251,
      (byte) 200,
      (byte) 74,
      (byte) 211,
      (byte) 230,
      (byte) 107,
      (byte) 69,
      (byte) 125,
      (byte) 232,
      (byte) 75,
      (byte) 214,
      (byte) 50,
      (byte) 216,
      (byte) 253,
      (byte) 55,
      (byte) 113,
      (byte) 241,
      (byte) 225,
      (byte) 48 /*0x30*/,
      (byte) 15,
      (byte) 248,
      (byte) 27,
      (byte) 135,
      (byte) 250,
      (byte) 6,
      (byte) 63 /*0x3F*/,
      (byte) 94,
      (byte) 186,
      (byte) 174,
      (byte) 91,
      (byte) 138,
      (byte) 0,
      (byte) 188,
      (byte) 157,
      (byte) 109,
      (byte) 193,
      (byte) 177,
      (byte) 14,
      (byte) 128 /*0x80*/,
      (byte) 93,
      (byte) 210,
      (byte) 213,
      (byte) 160 /*0xA0*/,
      (byte) 132,
      (byte) 7,
      (byte) 20,
      (byte) 181,
      (byte) 144 /*0x90*/,
      (byte) 44,
      (byte) 163,
      (byte) 178,
      (byte) 115,
      (byte) 76,
      (byte) 84,
      (byte) 146,
      (byte) 116,
      (byte) 54,
      (byte) 81,
      (byte) 56,
      (byte) 176 /*0xB0*/,
      (byte) 189,
      (byte) 90,
      (byte) 252,
      (byte) 96 /*0x60*/,
      (byte) 98,
      (byte) 150,
      (byte) 108,
      (byte) 66,
      (byte) 247,
      (byte) 16 /*0x10*/,
      (byte) 124,
      (byte) 40,
      (byte) 39,
      (byte) 140,
      (byte) 19,
      (byte) 149,
      (byte) 156,
      (byte) 199,
      (byte) 36,
      (byte) 70,
      (byte) 59,
      (byte) 112 /*0x70*/,
      (byte) 202,
      (byte) 227,
      (byte) 133,
      (byte) 203,
      (byte) 17,
      (byte) 208 /*0xD0*/,
      (byte) 147,
      (byte) 184,
      (byte) 166,
      (byte) 131,
      (byte) 32 /*0x20*/,
      byte.MaxValue,
      (byte) 159,
      (byte) 119,
      (byte) 195,
      (byte) 204,
      (byte) 3,
      (byte) 111,
      (byte) 8,
      (byte) 191,
      (byte) 64 /*0x40*/,
      (byte) 231,
      (byte) 43,
      (byte) 226,
      (byte) 121,
      (byte) 12,
      (byte) 170,
      (byte) 130,
      (byte) 65,
      (byte) 58,
      (byte) 234,
      (byte) 185,
      (byte) 228,
      (byte) 154,
      (byte) 164,
      (byte) 151,
      (byte) 126,
      (byte) 218,
      (byte) 122,
      (byte) 23,
      (byte) 102,
      (byte) 148,
      (byte) 161,
      (byte) 29,
      (byte) 61,
      (byte) 240 /*0xF0*/,
      (byte) 222,
      (byte) 179,
      (byte) 11,
      (byte) 114,
      (byte) 167,
      (byte) 28,
      (byte) 239,
      (byte) 209,
      (byte) 83,
      (byte) 62,
      (byte) 143,
      (byte) 51,
      (byte) 38,
      (byte) 95,
      (byte) 236,
      (byte) 118,
      (byte) 42,
      (byte) 73,
      (byte) 129,
      (byte) 136,
      (byte) 238,
      (byte) 33,
      (byte) 196,
      (byte) 26,
      (byte) 235,
      (byte) 217,
      (byte) 197,
      (byte) 57,
      (byte) 153,
      (byte) 205,
      (byte) 173,
      (byte) 49,
      (byte) 139,
      (byte) 1,
      (byte) 24,
      (byte) 35,
      (byte) 221,
      (byte) 31 /*0x1F*/,
      (byte) 78,
      (byte) 45,
      (byte) 249,
      (byte) 72,
      (byte) 79,
      (byte) 242,
      (byte) 101,
      (byte) 142,
      (byte) 120,
      (byte) 92,
      (byte) 88,
      (byte) 25,
      (byte) 141,
      (byte) 229,
      (byte) 152,
      (byte) 87,
      (byte) 103,
      (byte) 127 /*0x7F*/,
      (byte) 5,
      (byte) 100,
      (byte) 175,
      (byte) 99,
      (byte) 182,
      (byte) 254,
      (byte) 245,
      (byte) 183,
      (byte) 60,
      (byte) 165,
      (byte) 206,
      (byte) 233,
      (byte) 104,
      (byte) 68,
      (byte) 224 /*0xE0*/,
      (byte) 77,
      (byte) 67,
      (byte) 105,
      (byte) 41,
      (byte) 46,
      (byte) 172,
      (byte) 21,
      (byte) 89,
      (byte) 168,
      (byte) 10,
      (byte) 158,
      (byte) 110,
      (byte) 71,
      (byte) 223,
      (byte) 52,
      (byte) 53,
      (byte) 106,
      (byte) 207,
      (byte) 220,
      (byte) 34,
      (byte) 201,
      (byte) 192 /*0xC0*/,
      (byte) 155,
      (byte) 137,
      (byte) 212,
      (byte) 237,
      (byte) 171,
      (byte) 18,
      (byte) 162,
      (byte) 13,
      (byte) 82,
      (byte) 187,
      (byte) 2,
      (byte) 47,
      (byte) 169,
      (byte) 215,
      (byte) 97,
      (byte) 30,
      (byte) 180,
      (byte) 80 /*0x50*/,
      (byte) 4,
      (byte) 246,
      (byte) 194,
      (byte) 22,
      (byte) 37,
      (byte) 134,
      (byte) 86,
      (byte) 85,
      (byte) 9,
      (byte) 190,
      (byte) 145
    }
  };
  private const int P_00 = 1;
  private const int P_01 = 0;
  private const int P_02 = 0;
  private const int P_03 = 1;
  private const int P_04 = 1;
  private const int P_10 = 0;
  private const int P_11 = 0;
  private const int P_12 = 1;
  private const int P_13 = 1;
  private const int P_14 = 0;
  private const int P_20 = 1;
  private const int P_21 = 1;
  private const int P_22 = 0;
  private const int P_23 = 0;
  private const int P_24 = 0;
  private const int P_30 = 0;
  private const int P_31 = 1;
  private const int P_32 = 1;
  private const int P_33 = 0;
  private const int P_34 = 1;
  private const int GF256_FDBK = 361;
  private const int GF256_FDBK_2 = 180;
  private const int GF256_FDBK_4 = 90;
  private const int RS_GF_FDBK = 333;
  private const int ROUNDS = 16 /*0x10*/;
  private const int MAX_ROUNDS = 16 /*0x10*/;
  private const int BLOCK_SIZE = 16 /*0x10*/;
  private const int MAX_KEY_BITS = 256 /*0x0100*/;
  private const int INPUT_WHITEN = 0;
  private const int OUTPUT_WHITEN = 4;
  private const int ROUND_SUBKEYS = 8;
  private const int TOTAL_SUBKEYS = 40;
  private const int SK_STEP = 33686018;
  private const int SK_BUMP = 16843009;
  private const int SK_ROTL = 9;
  private bool encrypting;
  private int[] gMDS0 = new int[256 /*0x0100*/];
  private int[] gMDS1 = new int[256 /*0x0100*/];
  private int[] gMDS2 = new int[256 /*0x0100*/];
  private int[] gMDS3 = new int[256 /*0x0100*/];
  private int[] gSubKeys;
  private int[] gSBox;
  private int k64Cnt;
  private byte[] workingKey;

  public TwofishEngine()
  {
    int[] numArray1 = new int[2];
    int[] numArray2 = new int[2];
    int[] numArray3 = new int[2];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
    {
      int x1 = (int) TwofishEngine.P[0, index] & (int) byte.MaxValue;
      numArray1[0] = x1;
      numArray2[0] = this.Mx_X(x1) & (int) byte.MaxValue;
      numArray3[0] = this.Mx_Y(x1) & (int) byte.MaxValue;
      int x2 = (int) TwofishEngine.P[1, index] & (int) byte.MaxValue;
      numArray1[1] = x2;
      numArray2[1] = this.Mx_X(x2) & (int) byte.MaxValue;
      numArray3[1] = this.Mx_Y(x2) & (int) byte.MaxValue;
      this.gMDS0[index] = numArray1[1] | numArray2[1] << 8 | numArray3[1] << 16 /*0x10*/ | numArray3[1] << 24;
      this.gMDS1[index] = numArray3[0] | numArray3[0] << 8 | numArray2[0] << 16 /*0x10*/ | numArray1[0] << 24;
      this.gMDS2[index] = numArray2[1] | numArray3[1] << 8 | numArray1[1] << 16 /*0x10*/ | numArray3[1] << 24;
      this.gMDS3[index] = numArray2[0] | numArray1[0] << 8 | numArray3[0] << 16 /*0x10*/ | numArray2[0] << 24;
    }
  }

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter))
      throw new ArgumentException("invalid parameter passed to Twofish init - " + Platform.GetTypeName((object) parameters));
    this.encrypting = forEncryption;
    this.workingKey = ((KeyParameter) parameters).GetKey();
    switch (this.workingKey.Length * 8)
    {
      case 128 /*0x80*/:
      case 192 /*0xC0*/:
      case 256 /*0x0100*/:
        this.k64Cnt = this.workingKey.Length / 8;
        this.SetKey(this.workingKey);
        break;
      default:
        throw new ArgumentException("Key length not 128/192/256 bits.");
    }
  }

  public string AlgorithmName => "Twofish";

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.workingKey == null)
      throw new InvalidOperationException("Twofish not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 16 /*0x10*/, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer too short");
    if (this.encrypting)
      this.EncryptBlock(input, inOff, output, outOff);
    else
      this.DecryptBlock(input, inOff, output, outOff);
    return 16 /*0x10*/;
  }

  public int GetBlockSize() => 16 /*0x10*/;

  private void SetKey(byte[] key)
  {
    int[] k32_1 = new int[4];
    int[] k32_2 = new int[4];
    int[] numArray = new int[4];
    this.gSubKeys = new int[40];
    for (int index = 0; index < this.k64Cnt; ++index)
    {
      int off = index * 8;
      k32_1[index] = (int) Pack.LE_To_UInt32(key, off);
      k32_2[index] = (int) Pack.LE_To_UInt32(key, off + 4);
      numArray[this.k64Cnt - 1 - index] = this.RS_MDS_Encode(k32_1[index], k32_2[index]);
    }
    for (int index = 0; index < 20; ++index)
    {
      int x = index * 33686018;
      int num1 = this.F32(x, k32_1);
      int num2 = Integers.RotateLeft(this.F32(x + 16843009, k32_2), 8);
      int num3 = num1 + num2;
      this.gSubKeys[index * 2] = num3;
      int i = num3 + num2;
      this.gSubKeys[index * 2 + 1] = Integers.RotateLeft(i, 9);
    }
    int x1 = numArray[0];
    int x2 = numArray[1];
    int x3 = numArray[2];
    int x4 = numArray[3];
    this.gSBox = new int[1024 /*0x0400*/];
    for (int index1 = 0; index1 < 256 /*0x0100*/; ++index1)
    {
      int num;
      int index2 = num = index1;
      int index3 = num;
      int index4 = num;
      int index5 = num;
      switch (this.k64Cnt & 3)
      {
        case 0:
          index5 = (int) TwofishEngine.P[1, index5] & (int) byte.MaxValue ^ this.M_b0(x4);
          index4 = (int) TwofishEngine.P[0, index4] & (int) byte.MaxValue ^ this.M_b1(x4);
          index3 = (int) TwofishEngine.P[0, index3] & (int) byte.MaxValue ^ this.M_b2(x4);
          index2 = (int) TwofishEngine.P[1, index2] & (int) byte.MaxValue ^ this.M_b3(x4);
          goto case 3;
        case 1:
          this.gSBox[index1 * 2] = this.gMDS0[(int) TwofishEngine.P[0, index5] & (int) byte.MaxValue ^ this.M_b0(x1)];
          this.gSBox[index1 * 2 + 1] = this.gMDS1[(int) TwofishEngine.P[0, index4] & (int) byte.MaxValue ^ this.M_b1(x1)];
          this.gSBox[index1 * 2 + 512 /*0x0200*/] = this.gMDS2[(int) TwofishEngine.P[1, index3] & (int) byte.MaxValue ^ this.M_b2(x1)];
          this.gSBox[index1 * 2 + 513] = this.gMDS3[(int) TwofishEngine.P[1, index2] & (int) byte.MaxValue ^ this.M_b3(x1)];
          break;
        case 2:
          this.gSBox[index1 * 2] = this.gMDS0[(int) TwofishEngine.P[0, (int) TwofishEngine.P[0, index5] & (int) byte.MaxValue ^ this.M_b0(x2)] & (int) byte.MaxValue ^ this.M_b0(x1)];
          this.gSBox[index1 * 2 + 1] = this.gMDS1[(int) TwofishEngine.P[0, (int) TwofishEngine.P[1, index4] & (int) byte.MaxValue ^ this.M_b1(x2)] & (int) byte.MaxValue ^ this.M_b1(x1)];
          this.gSBox[index1 * 2 + 512 /*0x0200*/] = this.gMDS2[(int) TwofishEngine.P[1, (int) TwofishEngine.P[0, index3] & (int) byte.MaxValue ^ this.M_b2(x2)] & (int) byte.MaxValue ^ this.M_b2(x1)];
          this.gSBox[index1 * 2 + 513] = this.gMDS3[(int) TwofishEngine.P[1, (int) TwofishEngine.P[1, index2] & (int) byte.MaxValue ^ this.M_b3(x2)] & (int) byte.MaxValue ^ this.M_b3(x1)];
          break;
        case 3:
          index5 = (int) TwofishEngine.P[1, index5] & (int) byte.MaxValue ^ this.M_b0(x3);
          index4 = (int) TwofishEngine.P[1, index4] & (int) byte.MaxValue ^ this.M_b1(x3);
          index3 = (int) TwofishEngine.P[0, index3] & (int) byte.MaxValue ^ this.M_b2(x3);
          index2 = (int) TwofishEngine.P[0, index2] & (int) byte.MaxValue ^ this.M_b3(x3);
          goto case 2;
      }
    }
  }

  private void EncryptBlock(byte[] src, int srcIndex, byte[] dst, int dstIndex)
  {
    int x1 = (int) Pack.LE_To_UInt32(src, srcIndex) ^ this.gSubKeys[0];
    int num1 = (int) Pack.LE_To_UInt32(src, srcIndex + 4) ^ this.gSubKeys[1];
    int x2 = (int) Pack.LE_To_UInt32(src, srcIndex + 8) ^ this.gSubKeys[2];
    int num2 = (int) Pack.LE_To_UInt32(src, srcIndex + 12) ^ this.gSubKeys[3];
    int num3 = 8;
    for (int index1 = 0; index1 < 16 /*0x10*/; index1 += 2)
    {
      int num4 = this.Fe32_0(x1);
      int num5 = this.Fe32_3(num1);
      int num6 = x2;
      int num7 = num4 + num5;
      int[] gSubKeys1 = this.gSubKeys;
      int index2 = num3;
      int num8 = index2 + 1;
      int num9 = gSubKeys1[index2];
      int num10 = num7 + num9;
      x2 = Integers.RotateRight(num6 ^ num10, 1);
      int num11 = Integers.RotateLeft(num2, 1);
      int num12 = num4 + 2 * num5;
      int[] gSubKeys2 = this.gSubKeys;
      int index3 = num8;
      int num13 = index3 + 1;
      int num14 = gSubKeys2[index3];
      int num15 = num12 + num14;
      num2 = num11 ^ num15;
      int num16 = this.Fe32_0(x2);
      int num17 = this.Fe32_3(num2);
      int num18 = x1;
      int num19 = num16 + num17;
      int[] gSubKeys3 = this.gSubKeys;
      int index4 = num13;
      int num20 = index4 + 1;
      int num21 = gSubKeys3[index4];
      int num22 = num19 + num21;
      x1 = Integers.RotateRight(num18 ^ num22, 1);
      int num23 = Integers.RotateLeft(num1, 1);
      int num24 = num16 + 2 * num17;
      int[] gSubKeys4 = this.gSubKeys;
      int index5 = num20;
      num3 = index5 + 1;
      int num25 = gSubKeys4[index5];
      int num26 = num24 + num25;
      num1 = num23 ^ num26;
    }
    Pack.UInt32_To_LE((uint) (x2 ^ this.gSubKeys[4]), dst, dstIndex);
    Pack.UInt32_To_LE((uint) (num2 ^ this.gSubKeys[5]), dst, dstIndex + 4);
    Pack.UInt32_To_LE((uint) (x1 ^ this.gSubKeys[6]), dst, dstIndex + 8);
    Pack.UInt32_To_LE((uint) (num1 ^ this.gSubKeys[7]), dst, dstIndex + 12);
  }

  private void DecryptBlock(byte[] src, int srcIndex, byte[] dst, int dstIndex)
  {
    int num1 = (int) Pack.LE_To_UInt32(src, srcIndex) ^ this.gSubKeys[4];
    int x1 = (int) Pack.LE_To_UInt32(src, srcIndex + 4) ^ this.gSubKeys[5];
    int num2 = (int) Pack.LE_To_UInt32(src, srcIndex + 8) ^ this.gSubKeys[6];
    int x2 = (int) Pack.LE_To_UInt32(src, srcIndex + 12) ^ this.gSubKeys[7];
    int num3 = 39;
    for (int index1 = 0; index1 < 16 /*0x10*/; index1 += 2)
    {
      int num4 = this.Fe32_0(num1);
      int num5 = this.Fe32_3(x1);
      int num6 = x2;
      int num7 = num4 + 2 * num5;
      int[] gSubKeys1 = this.gSubKeys;
      int index2 = num3;
      int num8 = index2 - 1;
      int num9 = gSubKeys1[index2];
      int num10 = num7 + num9;
      int i1 = num6 ^ num10;
      int num11 = Integers.RotateLeft(num2, 1);
      int num12 = num4 + num5;
      int[] gSubKeys2 = this.gSubKeys;
      int index3 = num8;
      int num13 = index3 - 1;
      int num14 = gSubKeys2[index3];
      int num15 = num12 + num14;
      num2 = num11 ^ num15;
      x2 = Integers.RotateRight(i1, 1);
      int num16 = this.Fe32_0(num2);
      int num17 = this.Fe32_3(x2);
      int num18 = x1;
      int num19 = num16 + 2 * num17;
      int[] gSubKeys3 = this.gSubKeys;
      int index4 = num13;
      int num20 = index4 - 1;
      int num21 = gSubKeys3[index4];
      int num22 = num19 + num21;
      int i2 = num18 ^ num22;
      int num23 = Integers.RotateLeft(num1, 1);
      int num24 = num16 + num17;
      int[] gSubKeys4 = this.gSubKeys;
      int index5 = num20;
      num3 = index5 - 1;
      int num25 = gSubKeys4[index5];
      int num26 = num24 + num25;
      num1 = num23 ^ num26;
      x1 = Integers.RotateRight(i2, 1);
    }
    Pack.UInt32_To_LE((uint) (num2 ^ this.gSubKeys[0]), dst, dstIndex);
    Pack.UInt32_To_LE((uint) (x2 ^ this.gSubKeys[1]), dst, dstIndex + 4);
    Pack.UInt32_To_LE((uint) (num1 ^ this.gSubKeys[2]), dst, dstIndex + 8);
    Pack.UInt32_To_LE((uint) (x1 ^ this.gSubKeys[3]), dst, dstIndex + 12);
  }

  private int F32(int x, int[] k32)
  {
    int index1 = this.M_b0(x);
    int index2 = this.M_b1(x);
    int index3 = this.M_b2(x);
    int index4 = this.M_b3(x);
    int x1 = k32[0];
    int x2 = k32[1];
    int x3 = k32[2];
    int x4 = k32[3];
    int num = 0;
    switch (this.k64Cnt & 3)
    {
      case 0:
        index1 = (int) TwofishEngine.P[1, index1] & (int) byte.MaxValue ^ this.M_b0(x4);
        index2 = (int) TwofishEngine.P[0, index2] & (int) byte.MaxValue ^ this.M_b1(x4);
        index3 = (int) TwofishEngine.P[0, index3] & (int) byte.MaxValue ^ this.M_b2(x4);
        index4 = (int) TwofishEngine.P[1, index4] & (int) byte.MaxValue ^ this.M_b3(x4);
        goto case 3;
      case 1:
        num = this.gMDS0[(int) TwofishEngine.P[0, index1] & (int) byte.MaxValue ^ this.M_b0(x1)] ^ this.gMDS1[(int) TwofishEngine.P[0, index2] & (int) byte.MaxValue ^ this.M_b1(x1)] ^ this.gMDS2[(int) TwofishEngine.P[1, index3] & (int) byte.MaxValue ^ this.M_b2(x1)] ^ this.gMDS3[(int) TwofishEngine.P[1, index4] & (int) byte.MaxValue ^ this.M_b3(x1)];
        break;
      case 2:
        num = this.gMDS0[(int) TwofishEngine.P[0, (int) TwofishEngine.P[0, index1] & (int) byte.MaxValue ^ this.M_b0(x2)] & (int) byte.MaxValue ^ this.M_b0(x1)] ^ this.gMDS1[(int) TwofishEngine.P[0, (int) TwofishEngine.P[1, index2] & (int) byte.MaxValue ^ this.M_b1(x2)] & (int) byte.MaxValue ^ this.M_b1(x1)] ^ this.gMDS2[(int) TwofishEngine.P[1, (int) TwofishEngine.P[0, index3] & (int) byte.MaxValue ^ this.M_b2(x2)] & (int) byte.MaxValue ^ this.M_b2(x1)] ^ this.gMDS3[(int) TwofishEngine.P[1, (int) TwofishEngine.P[1, index4] & (int) byte.MaxValue ^ this.M_b3(x2)] & (int) byte.MaxValue ^ this.M_b3(x1)];
        break;
      case 3:
        index1 = (int) TwofishEngine.P[1, index1] & (int) byte.MaxValue ^ this.M_b0(x3);
        index2 = (int) TwofishEngine.P[1, index2] & (int) byte.MaxValue ^ this.M_b1(x3);
        index3 = (int) TwofishEngine.P[0, index3] & (int) byte.MaxValue ^ this.M_b2(x3);
        index4 = (int) TwofishEngine.P[0, index4] & (int) byte.MaxValue ^ this.M_b3(x3);
        goto case 2;
    }
    return num;
  }

  private int RS_MDS_Encode(int k0, int k1)
  {
    int x1 = k1;
    for (int index = 0; index < 4; ++index)
      x1 = this.RS_rem(x1);
    int x2 = x1 ^ k0;
    for (int index = 0; index < 4; ++index)
      x2 = this.RS_rem(x2);
    return x2;
  }

  private int RS_rem(int x)
  {
    int num1 = x >>> 24 & (int) byte.MaxValue;
    int num2 = (num1 << 1 ^ ((num1 & 128 /*0x80*/) != 0 ? 333 : 0)) & (int) byte.MaxValue;
    int num3 = num1 >>> 1 ^ ((num1 & 1) != 0 ? 166 : 0) ^ num2;
    return x << 8 ^ num3 << 24 ^ num2 << 16 /*0x10*/ ^ num3 << 8 ^ num1;
  }

  private int LFSR1(int x) => x >> 1 ^ ((x & 1) != 0 ? 180 : 0);

  private int LFSR2(int x) => x >> 2 ^ ((x & 2) != 0 ? 180 : 0) ^ ((x & 1) != 0 ? 90 : 0);

  private int Mx_X(int x) => x ^ this.LFSR2(x);

  private int Mx_Y(int x) => x ^ this.LFSR1(x) ^ this.LFSR2(x);

  private int M_b0(int x) => x & (int) byte.MaxValue;

  private int M_b1(int x) => x >>> 8 & (int) byte.MaxValue;

  private int M_b2(int x) => x >>> 16 /*0x10*/ & (int) byte.MaxValue;

  private int M_b3(int x) => x >>> 24 & (int) byte.MaxValue;

  private int Fe32_0(int x)
  {
    return this.gSBox[2 * (x & (int) byte.MaxValue)] ^ this.gSBox[1 + 2 * (x >>> 8 & (int) byte.MaxValue)] ^ this.gSBox[512 /*0x0200*/ + 2 * (x >>> 16 /*0x10*/ & (int) byte.MaxValue)] ^ this.gSBox[513 + 2 * (x >>> 24 & (int) byte.MaxValue)];
  }

  private int Fe32_3(int x)
  {
    return this.gSBox[2 * (x >>> 24 & (int) byte.MaxValue)] ^ this.gSBox[1 + 2 * (x & (int) byte.MaxValue)] ^ this.gSBox[512 /*0x0200*/ + 2 * (x >>> 8 & (int) byte.MaxValue)] ^ this.gSBox[513 + 2 * (x >>> 16 /*0x10*/ & (int) byte.MaxValue)];
  }
}
