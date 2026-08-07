// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.CamelliaLightEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class CamelliaLightEngine : IBlockCipher
{
  private const int BLOCK_SIZE = 16 /*0x10*/;
  private bool initialised;
  private bool _keyis128;
  private uint[] subkey = new uint[96 /*0x60*/];
  private uint[] kw = new uint[8];
  private uint[] ke = new uint[12];
  private static readonly uint[] SIGMA = new uint[12]
  {
    2694735487U,
    1003262091U,
    3061508184U,
    1286239154U,
    3337565999U,
    3914302142U,
    1426019237U,
    4057165596U,
    283453434U,
    3731369245U,
    2958461122U,
    3018244605U
  };
  private static readonly byte[] SBOX1 = new byte[256 /*0x0100*/]
  {
    (byte) 112 /*0x70*/,
    (byte) 130,
    (byte) 44,
    (byte) 236,
    (byte) 179,
    (byte) 39,
    (byte) 192 /*0xC0*/,
    (byte) 229,
    (byte) 228,
    (byte) 133,
    (byte) 87,
    (byte) 53,
    (byte) 234,
    (byte) 12,
    (byte) 174,
    (byte) 65,
    (byte) 35,
    (byte) 239,
    (byte) 107,
    (byte) 147,
    (byte) 69,
    (byte) 25,
    (byte) 165,
    (byte) 33,
    (byte) 237,
    (byte) 14,
    (byte) 79,
    (byte) 78,
    (byte) 29,
    (byte) 101,
    (byte) 146,
    (byte) 189,
    (byte) 134,
    (byte) 184,
    (byte) 175,
    (byte) 143,
    (byte) 124,
    (byte) 235,
    (byte) 31 /*0x1F*/,
    (byte) 206,
    (byte) 62,
    (byte) 48 /*0x30*/,
    (byte) 220,
    (byte) 95,
    (byte) 94,
    (byte) 197,
    (byte) 11,
    (byte) 26,
    (byte) 166,
    (byte) 225,
    (byte) 57,
    (byte) 202,
    (byte) 213,
    (byte) 71,
    (byte) 93,
    (byte) 61,
    (byte) 217,
    (byte) 1,
    (byte) 90,
    (byte) 214,
    (byte) 81,
    (byte) 86,
    (byte) 108,
    (byte) 77,
    (byte) 139,
    (byte) 13,
    (byte) 154,
    (byte) 102,
    (byte) 251,
    (byte) 204,
    (byte) 176 /*0xB0*/,
    (byte) 45,
    (byte) 116,
    (byte) 18,
    (byte) 43,
    (byte) 32 /*0x20*/,
    (byte) 240 /*0xF0*/,
    (byte) 177,
    (byte) 132,
    (byte) 153,
    (byte) 223,
    (byte) 76,
    (byte) 203,
    (byte) 194,
    (byte) 52,
    (byte) 126,
    (byte) 118,
    (byte) 5,
    (byte) 109,
    (byte) 183,
    (byte) 169,
    (byte) 49,
    (byte) 209,
    (byte) 23,
    (byte) 4,
    (byte) 215,
    (byte) 20,
    (byte) 88,
    (byte) 58,
    (byte) 97,
    (byte) 222,
    (byte) 27,
    (byte) 17,
    (byte) 28,
    (byte) 50,
    (byte) 15,
    (byte) 156,
    (byte) 22,
    (byte) 83,
    (byte) 24,
    (byte) 242,
    (byte) 34,
    (byte) 254,
    (byte) 68,
    (byte) 207,
    (byte) 178,
    (byte) 195,
    (byte) 181,
    (byte) 122,
    (byte) 145,
    (byte) 36,
    (byte) 8,
    (byte) 232,
    (byte) 168,
    (byte) 96 /*0x60*/,
    (byte) 252,
    (byte) 105,
    (byte) 80 /*0x50*/,
    (byte) 170,
    (byte) 208 /*0xD0*/,
    (byte) 160 /*0xA0*/,
    (byte) 125,
    (byte) 161,
    (byte) 137,
    (byte) 98,
    (byte) 151,
    (byte) 84,
    (byte) 91,
    (byte) 30,
    (byte) 149,
    (byte) 224 /*0xE0*/,
    byte.MaxValue,
    (byte) 100,
    (byte) 210,
    (byte) 16 /*0x10*/,
    (byte) 196,
    (byte) 0,
    (byte) 72,
    (byte) 163,
    (byte) 247,
    (byte) 117,
    (byte) 219,
    (byte) 138,
    (byte) 3,
    (byte) 230,
    (byte) 218,
    (byte) 9,
    (byte) 63 /*0x3F*/,
    (byte) 221,
    (byte) 148,
    (byte) 135,
    (byte) 92,
    (byte) 131,
    (byte) 2,
    (byte) 205,
    (byte) 74,
    (byte) 144 /*0x90*/,
    (byte) 51,
    (byte) 115,
    (byte) 103,
    (byte) 246,
    (byte) 243,
    (byte) 157,
    (byte) 127 /*0x7F*/,
    (byte) 191,
    (byte) 226,
    (byte) 82,
    (byte) 155,
    (byte) 216,
    (byte) 38,
    (byte) 200,
    (byte) 55,
    (byte) 198,
    (byte) 59,
    (byte) 129,
    (byte) 150,
    (byte) 111,
    (byte) 75,
    (byte) 19,
    (byte) 190,
    (byte) 99,
    (byte) 46,
    (byte) 233,
    (byte) 121,
    (byte) 167,
    (byte) 140,
    (byte) 159,
    (byte) 110,
    (byte) 188,
    (byte) 142,
    (byte) 41,
    (byte) 245,
    (byte) 249,
    (byte) 182,
    (byte) 47,
    (byte) 253,
    (byte) 180,
    (byte) 89,
    (byte) 120,
    (byte) 152,
    (byte) 6,
    (byte) 106,
    (byte) 231,
    (byte) 70,
    (byte) 113,
    (byte) 186,
    (byte) 212,
    (byte) 37,
    (byte) 171,
    (byte) 66,
    (byte) 136,
    (byte) 162,
    (byte) 141,
    (byte) 250,
    (byte) 114,
    (byte) 7,
    (byte) 185,
    (byte) 85,
    (byte) 248,
    (byte) 238,
    (byte) 172,
    (byte) 10,
    (byte) 54,
    (byte) 73,
    (byte) 42,
    (byte) 104,
    (byte) 60,
    (byte) 56,
    (byte) 241,
    (byte) 164,
    (byte) 64 /*0x40*/,
    (byte) 40,
    (byte) 211,
    (byte) 123,
    (byte) 187,
    (byte) 201,
    (byte) 67,
    (byte) 193,
    (byte) 21,
    (byte) 227,
    (byte) 173,
    (byte) 244,
    (byte) 119,
    (byte) 199,
    (byte) 128 /*0x80*/,
    (byte) 158
  };

  private static uint rightRotate(uint x, int s) => (x >> s) + (x << 32 /*0x20*/ - s);

  private static uint leftRotate(uint x, int s) => (x << s) + (x >> 32 /*0x20*/ - s);

  private static void roldq(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
  {
    ko[ooff] = ki[ioff] << rot | ki[1 + ioff] >> 32 /*0x20*/ - rot;
    ko[1 + ooff] = ki[1 + ioff] << rot | ki[2 + ioff] >> 32 /*0x20*/ - rot;
    ko[2 + ooff] = ki[2 + ioff] << rot | ki[3 + ioff] >> 32 /*0x20*/ - rot;
    ko[3 + ooff] = ki[3 + ioff] << rot | ki[ioff] >> 32 /*0x20*/ - rot;
    ki[ioff] = ko[ooff];
    ki[1 + ioff] = ko[1 + ooff];
    ki[2 + ioff] = ko[2 + ooff];
    ki[3 + ioff] = ko[3 + ooff];
  }

  private static void decroldq(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
  {
    ko[2 + ooff] = ki[ioff] << rot | ki[1 + ioff] >> 32 /*0x20*/ - rot;
    ko[3 + ooff] = ki[1 + ioff] << rot | ki[2 + ioff] >> 32 /*0x20*/ - rot;
    ko[ooff] = ki[2 + ioff] << rot | ki[3 + ioff] >> 32 /*0x20*/ - rot;
    ko[1 + ooff] = ki[3 + ioff] << rot | ki[ioff] >> 32 /*0x20*/ - rot;
    ki[ioff] = ko[2 + ooff];
    ki[1 + ioff] = ko[3 + ooff];
    ki[2 + ioff] = ko[ooff];
    ki[3 + ioff] = ko[1 + ooff];
  }

  private static void roldqo32(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
  {
    ko[ooff] = ki[1 + ioff] << rot - 32 /*0x20*/ | ki[2 + ioff] >> 64 /*0x40*/ - rot;
    ko[1 + ooff] = ki[2 + ioff] << rot - 32 /*0x20*/ | ki[3 + ioff] >> 64 /*0x40*/ - rot;
    ko[2 + ooff] = ki[3 + ioff] << rot - 32 /*0x20*/ | ki[ioff] >> 64 /*0x40*/ - rot;
    ko[3 + ooff] = ki[ioff] << rot - 32 /*0x20*/ | ki[1 + ioff] >> 64 /*0x40*/ - rot;
    ki[ioff] = ko[ooff];
    ki[1 + ioff] = ko[1 + ooff];
    ki[2 + ioff] = ko[2 + ooff];
    ki[3 + ioff] = ko[3 + ooff];
  }

  private static void decroldqo32(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
  {
    ko[2 + ooff] = ki[1 + ioff] << rot - 32 /*0x20*/ | ki[2 + ioff] >> 64 /*0x40*/ - rot;
    ko[3 + ooff] = ki[2 + ioff] << rot - 32 /*0x20*/ | ki[3 + ioff] >> 64 /*0x40*/ - rot;
    ko[ooff] = ki[3 + ioff] << rot - 32 /*0x20*/ | ki[ioff] >> 64 /*0x40*/ - rot;
    ko[1 + ooff] = ki[ioff] << rot - 32 /*0x20*/ | ki[1 + ioff] >> 64 /*0x40*/ - rot;
    ki[ioff] = ko[2 + ooff];
    ki[1 + ioff] = ko[3 + ooff];
    ki[2 + ioff] = ko[ooff];
    ki[3 + ioff] = ko[1 + ooff];
  }

  private byte lRot8(byte v, int rot) => (byte) ((uint) v << rot | (uint) v >> 8 - rot);

  private uint sbox2(int x) => (uint) this.lRot8(CamelliaLightEngine.SBOX1[x], 1);

  private uint sbox3(int x) => (uint) this.lRot8(CamelliaLightEngine.SBOX1[x], 7);

  private uint sbox4(int x) => (uint) CamelliaLightEngine.SBOX1[(int) this.lRot8((byte) x, 1)];

  private void camelliaF2(uint[] s, uint[] skey, int keyoff)
  {
    uint x1 = s[0] ^ skey[keyoff];
    uint num1 = this.sbox4((int) (byte) x1) | this.sbox3((int) (byte) (x1 >> 8)) << 8 | this.sbox2((int) (byte) (x1 >> 16 /*0x10*/)) << 16 /*0x10*/ | (uint) CamelliaLightEngine.SBOX1[(int) (byte) (x1 >> 24)] << 24;
    uint index1 = s[1] ^ skey[1 + keyoff];
    uint x2 = CamelliaLightEngine.leftRotate((uint) CamelliaLightEngine.SBOX1[(int) (byte) index1] | this.sbox4((int) (byte) (index1 >> 8)) << 8 | this.sbox3((int) (byte) (index1 >> 16 /*0x10*/)) << 16 /*0x10*/ | this.sbox2((int) (byte) (index1 >> 24)) << 24, 8);
    uint x3 = num1 ^ x2;
    uint x4 = CamelliaLightEngine.leftRotate(x2, 8) ^ x3;
    uint x5 = CamelliaLightEngine.rightRotate(x3, 8) ^ x4;
    s[2] ^= CamelliaLightEngine.leftRotate(x4, 16 /*0x10*/) ^ x5;
    s[3] ^= CamelliaLightEngine.leftRotate(x5, 8);
    uint x6 = s[2] ^ skey[2 + keyoff];
    uint num2 = this.sbox4((int) (byte) x6) | this.sbox3((int) (byte) (x6 >> 8)) << 8 | this.sbox2((int) (byte) (x6 >> 16 /*0x10*/)) << 16 /*0x10*/ | (uint) CamelliaLightEngine.SBOX1[(int) (byte) (x6 >> 24)] << 24;
    uint index2 = s[3] ^ skey[3 + keyoff];
    uint x7 = CamelliaLightEngine.leftRotate((uint) CamelliaLightEngine.SBOX1[(int) (byte) index2] | this.sbox4((int) (byte) (index2 >> 8)) << 8 | this.sbox3((int) (byte) (index2 >> 16 /*0x10*/)) << 16 /*0x10*/ | this.sbox2((int) (byte) (index2 >> 24)) << 24, 8);
    uint x8 = num2 ^ x7;
    uint x9 = CamelliaLightEngine.leftRotate(x7, 8) ^ x8;
    uint x10 = CamelliaLightEngine.rightRotate(x8, 8) ^ x9;
    s[0] ^= CamelliaLightEngine.leftRotate(x9, 16 /*0x10*/) ^ x10;
    s[1] ^= CamelliaLightEngine.leftRotate(x10, 8);
  }

  private void camelliaFLs(uint[] s, uint[] fkey, int keyoff)
  {
    s[1] ^= CamelliaLightEngine.leftRotate(s[0] & fkey[keyoff], 1);
    s[0] ^= fkey[1 + keyoff] | s[1];
    s[2] ^= fkey[3 + keyoff] | s[3];
    s[3] ^= CamelliaLightEngine.leftRotate(fkey[2 + keyoff] & s[2], 1);
  }

  private void setKey(bool forEncryption, byte[] key)
  {
    uint[] numArray1 = new uint[8];
    uint[] numArray2 = new uint[4];
    uint[] numArray3 = new uint[4];
    uint[] ko = new uint[4];
    switch (key.Length)
    {
      case 16 /*0x10*/:
        this._keyis128 = true;
        Pack.BE_To_UInt32(key, 0, numArray1, 0, 4);
        uint[] numArray4 = numArray1;
        uint[] numArray5 = numArray1;
        uint[] numArray6 = numArray1;
        numArray1[7] = 0U;
        numArray6[6] = 0U;
        numArray5[5] = 0U;
        numArray4[4] = 0U;
        break;
      case 24:
        Pack.BE_To_UInt32(key, 0, numArray1, 0, 6);
        numArray1[6] = ~numArray1[4];
        numArray1[7] = ~numArray1[5];
        this._keyis128 = false;
        break;
      case 32 /*0x20*/:
        Pack.BE_To_UInt32(key, 0, numArray1, 0, 8);
        this._keyis128 = false;
        break;
      default:
        throw new ArgumentException("key sizes are only 16/24/32 bytes.");
    }
    for (int index = 0; index < 4; ++index)
      numArray2[index] = numArray1[index] ^ numArray1[index + 4];
    this.camelliaF2(numArray2, CamelliaLightEngine.SIGMA, 0);
    for (int index = 0; index < 4; ++index)
      numArray2[index] ^= numArray1[index];
    this.camelliaF2(numArray2, CamelliaLightEngine.SIGMA, 4);
    if (this._keyis128)
    {
      if (forEncryption)
      {
        this.kw[0] = numArray1[0];
        this.kw[1] = numArray1[1];
        this.kw[2] = numArray1[2];
        this.kw[3] = numArray1[3];
        CamelliaLightEngine.roldq(15, numArray1, 0, this.subkey, 4);
        CamelliaLightEngine.roldq(30, numArray1, 0, this.subkey, 12);
        CamelliaLightEngine.roldq(15, numArray1, 0, ko, 0);
        this.subkey[18] = ko[2];
        this.subkey[19] = ko[3];
        CamelliaLightEngine.roldq(17, numArray1, 0, this.ke, 4);
        CamelliaLightEngine.roldq(17, numArray1, 0, this.subkey, 24);
        CamelliaLightEngine.roldq(17, numArray1, 0, this.subkey, 32 /*0x20*/);
        this.subkey[0] = numArray2[0];
        this.subkey[1] = numArray2[1];
        this.subkey[2] = numArray2[2];
        this.subkey[3] = numArray2[3];
        CamelliaLightEngine.roldq(15, numArray2, 0, this.subkey, 8);
        CamelliaLightEngine.roldq(15, numArray2, 0, this.ke, 0);
        CamelliaLightEngine.roldq(15, numArray2, 0, ko, 0);
        this.subkey[16 /*0x10*/] = ko[0];
        this.subkey[17] = ko[1];
        CamelliaLightEngine.roldq(15, numArray2, 0, this.subkey, 20);
        CamelliaLightEngine.roldqo32(34, numArray2, 0, this.subkey, 28);
        CamelliaLightEngine.roldq(17, numArray2, 0, this.kw, 4);
      }
      else
      {
        this.kw[4] = numArray1[0];
        this.kw[5] = numArray1[1];
        this.kw[6] = numArray1[2];
        this.kw[7] = numArray1[3];
        CamelliaLightEngine.decroldq(15, numArray1, 0, this.subkey, 28);
        CamelliaLightEngine.decroldq(30, numArray1, 0, this.subkey, 20);
        CamelliaLightEngine.decroldq(15, numArray1, 0, ko, 0);
        this.subkey[16 /*0x10*/] = ko[0];
        this.subkey[17] = ko[1];
        CamelliaLightEngine.decroldq(17, numArray1, 0, this.ke, 0);
        CamelliaLightEngine.decroldq(17, numArray1, 0, this.subkey, 8);
        CamelliaLightEngine.decroldq(17, numArray1, 0, this.subkey, 0);
        this.subkey[34] = numArray2[0];
        this.subkey[35] = numArray2[1];
        this.subkey[32 /*0x20*/] = numArray2[2];
        this.subkey[33] = numArray2[3];
        CamelliaLightEngine.decroldq(15, numArray2, 0, this.subkey, 24);
        CamelliaLightEngine.decroldq(15, numArray2, 0, this.ke, 4);
        CamelliaLightEngine.decroldq(15, numArray2, 0, ko, 0);
        this.subkey[18] = ko[2];
        this.subkey[19] = ko[3];
        CamelliaLightEngine.decroldq(15, numArray2, 0, this.subkey, 12);
        CamelliaLightEngine.decroldqo32(34, numArray2, 0, this.subkey, 4);
        CamelliaLightEngine.roldq(17, numArray2, 0, this.kw, 0);
      }
    }
    else
    {
      for (int index = 0; index < 4; ++index)
        numArray3[index] = numArray2[index] ^ numArray1[index + 4];
      this.camelliaF2(numArray3, CamelliaLightEngine.SIGMA, 8);
      if (forEncryption)
      {
        this.kw[0] = numArray1[0];
        this.kw[1] = numArray1[1];
        this.kw[2] = numArray1[2];
        this.kw[3] = numArray1[3];
        CamelliaLightEngine.roldqo32(45, numArray1, 0, this.subkey, 16 /*0x10*/);
        CamelliaLightEngine.roldq(15, numArray1, 0, this.ke, 4);
        CamelliaLightEngine.roldq(17, numArray1, 0, this.subkey, 32 /*0x20*/);
        CamelliaLightEngine.roldqo32(34, numArray1, 0, this.subkey, 44);
        CamelliaLightEngine.roldq(15, numArray1, 4, this.subkey, 4);
        CamelliaLightEngine.roldq(15, numArray1, 4, this.ke, 0);
        CamelliaLightEngine.roldq(30, numArray1, 4, this.subkey, 24);
        CamelliaLightEngine.roldqo32(34, numArray1, 4, this.subkey, 36);
        CamelliaLightEngine.roldq(15, numArray2, 0, this.subkey, 8);
        CamelliaLightEngine.roldq(30, numArray2, 0, this.subkey, 20);
        this.ke[8] = numArray2[1];
        this.ke[9] = numArray2[2];
        this.ke[10] = numArray2[3];
        this.ke[11] = numArray2[0];
        CamelliaLightEngine.roldqo32(49, numArray2, 0, this.subkey, 40);
        this.subkey[0] = numArray3[0];
        this.subkey[1] = numArray3[1];
        this.subkey[2] = numArray3[2];
        this.subkey[3] = numArray3[3];
        CamelliaLightEngine.roldq(30, numArray3, 0, this.subkey, 12);
        CamelliaLightEngine.roldq(30, numArray3, 0, this.subkey, 28);
        CamelliaLightEngine.roldqo32(51, numArray3, 0, this.kw, 4);
      }
      else
      {
        this.kw[4] = numArray1[0];
        this.kw[5] = numArray1[1];
        this.kw[6] = numArray1[2];
        this.kw[7] = numArray1[3];
        CamelliaLightEngine.decroldqo32(45, numArray1, 0, this.subkey, 28);
        CamelliaLightEngine.decroldq(15, numArray1, 0, this.ke, 4);
        CamelliaLightEngine.decroldq(17, numArray1, 0, this.subkey, 12);
        CamelliaLightEngine.decroldqo32(34, numArray1, 0, this.subkey, 0);
        CamelliaLightEngine.decroldq(15, numArray1, 4, this.subkey, 40);
        CamelliaLightEngine.decroldq(15, numArray1, 4, this.ke, 8);
        CamelliaLightEngine.decroldq(30, numArray1, 4, this.subkey, 20);
        CamelliaLightEngine.decroldqo32(34, numArray1, 4, this.subkey, 8);
        CamelliaLightEngine.decroldq(15, numArray2, 0, this.subkey, 36);
        CamelliaLightEngine.decroldq(30, numArray2, 0, this.subkey, 24);
        this.ke[2] = numArray2[1];
        this.ke[3] = numArray2[2];
        this.ke[0] = numArray2[3];
        this.ke[1] = numArray2[0];
        CamelliaLightEngine.decroldqo32(49, numArray2, 0, this.subkey, 4);
        this.subkey[46] = numArray3[0];
        this.subkey[47] = numArray3[1];
        this.subkey[44] = numArray3[2];
        this.subkey[45] = numArray3[3];
        CamelliaLightEngine.decroldq(30, numArray3, 0, this.subkey, 32 /*0x20*/);
        CamelliaLightEngine.decroldq(30, numArray3, 0, this.subkey, 16 /*0x10*/);
        CamelliaLightEngine.roldqo32(51, numArray3, 0, this.kw, 0);
      }
    }
  }

  private int ProcessBlock128(byte[] input, int inOff, byte[] output, int outOff)
  {
    uint[] s = new uint[4];
    for (int index = 0; index < 4; ++index)
      s[index] = Pack.BE_To_UInt32(input, inOff + index * 4) ^ this.kw[index];
    this.camelliaF2(s, this.subkey, 0);
    this.camelliaF2(s, this.subkey, 4);
    this.camelliaF2(s, this.subkey, 8);
    this.camelliaFLs(s, this.ke, 0);
    this.camelliaF2(s, this.subkey, 12);
    this.camelliaF2(s, this.subkey, 16 /*0x10*/);
    this.camelliaF2(s, this.subkey, 20);
    this.camelliaFLs(s, this.ke, 4);
    this.camelliaF2(s, this.subkey, 24);
    this.camelliaF2(s, this.subkey, 28);
    this.camelliaF2(s, this.subkey, 32 /*0x20*/);
    Pack.UInt32_To_BE(s[2] ^ this.kw[4], output, outOff);
    Pack.UInt32_To_BE(s[3] ^ this.kw[5], output, outOff + 4);
    Pack.UInt32_To_BE(s[0] ^ this.kw[6], output, outOff + 8);
    Pack.UInt32_To_BE(s[1] ^ this.kw[7], output, outOff + 12);
    return 16 /*0x10*/;
  }

  private int ProcessBlock192or256(byte[] input, int inOff, byte[] output, int outOff)
  {
    uint[] s = new uint[4];
    for (int index = 0; index < 4; ++index)
      s[index] = Pack.BE_To_UInt32(input, inOff + index * 4) ^ this.kw[index];
    this.camelliaF2(s, this.subkey, 0);
    this.camelliaF2(s, this.subkey, 4);
    this.camelliaF2(s, this.subkey, 8);
    this.camelliaFLs(s, this.ke, 0);
    this.camelliaF2(s, this.subkey, 12);
    this.camelliaF2(s, this.subkey, 16 /*0x10*/);
    this.camelliaF2(s, this.subkey, 20);
    this.camelliaFLs(s, this.ke, 4);
    this.camelliaF2(s, this.subkey, 24);
    this.camelliaF2(s, this.subkey, 28);
    this.camelliaF2(s, this.subkey, 32 /*0x20*/);
    this.camelliaFLs(s, this.ke, 8);
    this.camelliaF2(s, this.subkey, 36);
    this.camelliaF2(s, this.subkey, 40);
    this.camelliaF2(s, this.subkey, 44);
    Pack.UInt32_To_BE(s[2] ^ this.kw[4], output, outOff);
    Pack.UInt32_To_BE(s[3] ^ this.kw[5], output, outOff + 4);
    Pack.UInt32_To_BE(s[0] ^ this.kw[6], output, outOff + 8);
    Pack.UInt32_To_BE(s[1] ^ this.kw[7], output, outOff + 12);
    return 16 /*0x10*/;
  }

  public CamelliaLightEngine() => this.initialised = false;

  public virtual string AlgorithmName => "Camellia";

  public virtual int GetBlockSize() => 16 /*0x10*/;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter))
      throw new ArgumentException("only simple KeyParameter expected.");
    this.setKey(forEncryption, ((KeyParameter) parameters).GetKey());
    this.initialised = true;
  }

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (!this.initialised)
      throw new InvalidOperationException("Camellia engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 16 /*0x10*/, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer too short");
    return this._keyis128 ? this.ProcessBlock128(input, inOff, output, outOff) : this.ProcessBlock192or256(input, inOff, output, outOff);
  }
}
