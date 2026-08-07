// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.HarakaBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public abstract class HarakaBase : IDigest
{
  internal static readonly int DIGEST_SIZE = 32 /*0x20*/;
  internal static readonly byte[][] RC = new byte[40][]
  {
    new byte[16 /*0x10*/]
    {
      (byte) 157,
      (byte) 123,
      (byte) 129,
      (byte) 117,
      (byte) 240 /*0xF0*/,
      (byte) 254,
      (byte) 197,
      (byte) 178,
      (byte) 10,
      (byte) 192 /*0xC0*/,
      (byte) 32 /*0x20*/,
      (byte) 230,
      (byte) 76,
      (byte) 112 /*0x70*/,
      (byte) 132,
      (byte) 6
    },
    new byte[16 /*0x10*/]
    {
      (byte) 23,
      (byte) 247,
      (byte) 8,
      (byte) 47,
      (byte) 164,
      (byte) 107,
      (byte) 15,
      (byte) 100,
      (byte) 107,
      (byte) 160 /*0xA0*/,
      (byte) 243,
      (byte) 136,
      (byte) 225,
      (byte) 180,
      (byte) 102,
      (byte) 139
    },
    new byte[16 /*0x10*/]
    {
      (byte) 20,
      (byte) 145,
      (byte) 2,
      (byte) 159,
      (byte) 96 /*0x60*/,
      (byte) 157,
      (byte) 2,
      (byte) 207,
      (byte) 152,
      (byte) 132,
      (byte) 242,
      (byte) 83,
      (byte) 45,
      (byte) 222,
      (byte) 2,
      (byte) 52
    },
    new byte[16 /*0x10*/]
    {
      (byte) 121,
      (byte) 79,
      (byte) 91,
      (byte) 253,
      (byte) 175,
      (byte) 188,
      (byte) 243,
      (byte) 187,
      (byte) 8,
      (byte) 79,
      (byte) 123,
      (byte) 46,
      (byte) 230,
      (byte) 234,
      (byte) 214,
      (byte) 14
    },
    new byte[16 /*0x10*/]
    {
      (byte) 68,
      (byte) 112 /*0x70*/,
      (byte) 57,
      (byte) 190,
      (byte) 28,
      (byte) 205,
      (byte) 238,
      (byte) 121,
      (byte) 139,
      (byte) 68,
      (byte) 114,
      (byte) 72,
      (byte) 203,
      (byte) 176 /*0xB0*/,
      (byte) 207,
      (byte) 203
    },
    new byte[16 /*0x10*/]
    {
      (byte) 123,
      (byte) 5,
      (byte) 138,
      (byte) 43,
      (byte) 237,
      (byte) 53,
      (byte) 83,
      (byte) 141,
      (byte) 183,
      (byte) 50,
      (byte) 144 /*0x90*/,
      (byte) 110,
      (byte) 238,
      (byte) 205,
      (byte) 234,
      (byte) 126
    },
    new byte[16 /*0x10*/]
    {
      (byte) 27,
      (byte) 239,
      (byte) 79,
      (byte) 218,
      (byte) 97,
      (byte) 39,
      (byte) 65,
      (byte) 226,
      (byte) 208 /*0xD0*/,
      (byte) 124,
      (byte) 46,
      (byte) 94,
      (byte) 67,
      (byte) 143,
      (byte) 194,
      (byte) 103
    },
    new byte[16 /*0x10*/]
    {
      (byte) 59,
      (byte) 11,
      (byte) 199,
      (byte) 31 /*0x1F*/,
      (byte) 226,
      (byte) 253,
      (byte) 95,
      (byte) 103,
      (byte) 7,
      (byte) 204,
      (byte) 202,
      (byte) 175,
      (byte) 176 /*0xB0*/,
      (byte) 217,
      (byte) 36,
      (byte) 41
    },
    new byte[16 /*0x10*/]
    {
      (byte) 238,
      (byte) 101,
      (byte) 212,
      (byte) 185,
      (byte) 202,
      (byte) 143,
      (byte) 219,
      (byte) 236,
      (byte) 233,
      (byte) 127 /*0x7F*/,
      (byte) 134,
      (byte) 230,
      (byte) 241,
      (byte) 99,
      (byte) 77,
      (byte) 171
    },
    new byte[16 /*0x10*/]
    {
      (byte) 51,
      (byte) 126,
      (byte) 3,
      (byte) 173,
      (byte) 79,
      (byte) 64 /*0x40*/,
      (byte) 42,
      (byte) 91,
      (byte) 100,
      (byte) 205,
      (byte) 183,
      (byte) 212,
      (byte) 132,
      (byte) 191,
      (byte) 48 /*0x30*/,
      (byte) 28
    },
    new byte[16 /*0x10*/]
    {
      (byte) 0,
      (byte) 152,
      (byte) 246,
      (byte) 141,
      (byte) 46,
      (byte) 139,
      (byte) 2,
      (byte) 105,
      (byte) 191,
      (byte) 35,
      (byte) 23,
      (byte) 148,
      (byte) 185,
      (byte) 11,
      (byte) 204,
      (byte) 178
    },
    new byte[16 /*0x10*/]
    {
      (byte) 138,
      (byte) 45,
      (byte) 157,
      (byte) 92,
      (byte) 200,
      (byte) 158,
      (byte) 170,
      (byte) 74,
      (byte) 114,
      (byte) 85,
      (byte) 111,
      (byte) 222,
      (byte) 166,
      (byte) 120,
      (byte) 4,
      (byte) 250
    },
    new byte[16 /*0x10*/]
    {
      (byte) 212,
      (byte) 159,
      (byte) 18,
      (byte) 41,
      (byte) 46,
      (byte) 79,
      (byte) 250,
      (byte) 14,
      (byte) 18,
      (byte) 42,
      (byte) 119,
      (byte) 107,
      (byte) 43,
      (byte) 159,
      (byte) 180,
      (byte) 223
    },
    new byte[16 /*0x10*/]
    {
      (byte) 238,
      (byte) 18,
      (byte) 106,
      (byte) 187,
      (byte) 174,
      (byte) 17,
      (byte) 214,
      (byte) 50,
      (byte) 54,
      (byte) 162,
      (byte) 73,
      (byte) 244,
      (byte) 68,
      (byte) 3,
      (byte) 161,
      (byte) 30
    },
    new byte[16 /*0x10*/]
    {
      (byte) 166,
      (byte) 236,
      (byte) 168,
      (byte) 156,
      (byte) 201,
      (byte) 0,
      (byte) 150,
      (byte) 95,
      (byte) 132,
      (byte) 0,
      (byte) 5,
      (byte) 75,
      (byte) 136,
      (byte) 73,
      (byte) 4,
      (byte) 175
    },
    new byte[16 /*0x10*/]
    {
      (byte) 236,
      (byte) 147,
      (byte) 229,
      (byte) 39,
      (byte) 227,
      (byte) 199,
      (byte) 162,
      (byte) 120,
      (byte) 79,
      (byte) 156,
      (byte) 25,
      (byte) 157,
      (byte) 216,
      (byte) 94,
      (byte) 2,
      (byte) 33
    },
    new byte[16 /*0x10*/]
    {
      (byte) 115,
      (byte) 1,
      (byte) 212,
      (byte) 130,
      (byte) 205,
      (byte) 46,
      (byte) 40,
      (byte) 185,
      (byte) 183,
      (byte) 201,
      (byte) 89,
      (byte) 167,
      (byte) 248,
      (byte) 170,
      (byte) 58,
      (byte) 191
    },
    new byte[16 /*0x10*/]
    {
      (byte) 107,
      (byte) 125,
      (byte) 48 /*0x30*/,
      (byte) 16 /*0x10*/,
      (byte) 217,
      (byte) 239,
      (byte) 242,
      (byte) 55,
      (byte) 23,
      (byte) 176 /*0xB0*/,
      (byte) 134,
      (byte) 97,
      (byte) 13,
      (byte) 112 /*0x70*/,
      (byte) 96 /*0x60*/,
      (byte) 98
    },
    new byte[16 /*0x10*/]
    {
      (byte) 198,
      (byte) 154,
      (byte) 252,
      (byte) 246,
      (byte) 83,
      (byte) 145,
      (byte) 194,
      (byte) 129,
      (byte) 67,
      (byte) 4,
      (byte) 48 /*0x30*/,
      (byte) 33,
      (byte) 194,
      (byte) 69,
      (byte) 202,
      (byte) 90
    },
    new byte[16 /*0x10*/]
    {
      (byte) 58,
      (byte) 148,
      (byte) 209,
      (byte) 54,
      (byte) 232,
      (byte) 146,
      (byte) 175,
      (byte) 44,
      (byte) 187,
      (byte) 104,
      (byte) 107,
      (byte) 34,
      (byte) 60,
      (byte) 151,
      (byte) 35,
      (byte) 146
    },
    new byte[16 /*0x10*/]
    {
      (byte) 180,
      (byte) 113,
      (byte) 16 /*0x10*/,
      (byte) 229,
      (byte) 88,
      (byte) 185,
      (byte) 186,
      (byte) 108,
      (byte) 235,
      (byte) 134,
      (byte) 88,
      (byte) 34,
      (byte) 56,
      (byte) 146,
      (byte) 191,
      (byte) 211
    },
    new byte[16 /*0x10*/]
    {
      (byte) 141,
      (byte) 18,
      (byte) 225,
      (byte) 36,
      (byte) 221,
      (byte) 253,
      (byte) 61,
      (byte) 147,
      (byte) 119,
      (byte) 198,
      (byte) 240 /*0xF0*/,
      (byte) 174,
      (byte) 229,
      (byte) 60,
      (byte) 134,
      (byte) 219
    },
    new byte[16 /*0x10*/]
    {
      (byte) 177,
      (byte) 18,
      (byte) 34,
      (byte) 203,
      (byte) 227,
      (byte) 141,
      (byte) 228,
      (byte) 131,
      (byte) 156,
      (byte) 160 /*0xA0*/,
      (byte) 235,
      byte.MaxValue,
      (byte) 104,
      (byte) 98,
      (byte) 96 /*0x60*/,
      (byte) 187
    },
    new byte[16 /*0x10*/]
    {
      (byte) 125,
      (byte) 247,
      (byte) 43,
      (byte) 199,
      (byte) 78,
      (byte) 26,
      (byte) 185,
      (byte) 45,
      (byte) 156,
      (byte) 209,
      (byte) 228,
      (byte) 226,
      (byte) 220,
      (byte) 211,
      (byte) 75,
      (byte) 115
    },
    new byte[16 /*0x10*/]
    {
      (byte) 78,
      (byte) 146,
      (byte) 179,
      (byte) 44,
      (byte) 196,
      (byte) 21,
      (byte) 20,
      (byte) 75,
      (byte) 67,
      (byte) 27,
      (byte) 48 /*0x30*/,
      (byte) 97,
      (byte) 195,
      (byte) 71,
      (byte) 187,
      (byte) 67
    },
    new byte[16 /*0x10*/]
    {
      (byte) 153,
      (byte) 104,
      (byte) 235,
      (byte) 22,
      (byte) 221,
      (byte) 49,
      (byte) 178,
      (byte) 3,
      (byte) 246,
      (byte) 239,
      (byte) 7,
      (byte) 231,
      (byte) 168,
      (byte) 117,
      (byte) 167,
      (byte) 219
    },
    new byte[16 /*0x10*/]
    {
      (byte) 44,
      (byte) 71,
      (byte) 202,
      (byte) 126,
      (byte) 2,
      (byte) 35,
      (byte) 94,
      (byte) 142,
      (byte) 119,
      (byte) 89,
      (byte) 117,
      (byte) 60,
      (byte) 75,
      (byte) 97,
      (byte) 243,
      (byte) 109
    },
    new byte[16 /*0x10*/]
    {
      (byte) 249,
      (byte) 23,
      (byte) 134,
      (byte) 184,
      (byte) 185,
      (byte) 229,
      (byte) 27,
      (byte) 109,
      (byte) 119,
      (byte) 125,
      (byte) 222,
      (byte) 214,
      (byte) 23,
      (byte) 90,
      (byte) 167,
      (byte) 205
    },
    new byte[16 /*0x10*/]
    {
      (byte) 93,
      (byte) 238,
      (byte) 70,
      (byte) 169,
      (byte) 157,
      (byte) 6,
      (byte) 108,
      (byte) 157,
      (byte) 170,
      (byte) 233,
      (byte) 168,
      (byte) 107,
      (byte) 240 /*0xF0*/,
      (byte) 67,
      (byte) 107,
      (byte) 236
    },
    new byte[16 /*0x10*/]
    {
      (byte) 193,
      (byte) 39,
      (byte) 243,
      (byte) 59,
      (byte) 89,
      (byte) 17,
      (byte) 83,
      (byte) 162,
      (byte) 43,
      (byte) 51,
      (byte) 87,
      (byte) 249,
      (byte) 80 /*0x50*/,
      (byte) 105,
      (byte) 30,
      (byte) 203
    },
    new byte[16 /*0x10*/]
    {
      (byte) 217,
      (byte) 208 /*0xD0*/,
      (byte) 14,
      (byte) 96 /*0x60*/,
      (byte) 83,
      (byte) 3,
      (byte) 237,
      (byte) 228,
      (byte) 156,
      (byte) 97,
      (byte) 218,
      (byte) 0,
      (byte) 117,
      (byte) 12,
      (byte) 238,
      (byte) 44
    },
    new byte[16 /*0x10*/]
    {
      (byte) 80 /*0x50*/,
      (byte) 163,
      (byte) 164,
      (byte) 99,
      (byte) 188,
      (byte) 186,
      (byte) 187,
      (byte) 128 /*0x80*/,
      (byte) 171,
      (byte) 12,
      (byte) 233,
      (byte) 150,
      (byte) 161,
      (byte) 165,
      (byte) 177,
      (byte) 240 /*0xF0*/
    },
    new byte[16 /*0x10*/]
    {
      (byte) 57,
      (byte) 202,
      (byte) 141,
      (byte) 147,
      (byte) 48 /*0x30*/,
      (byte) 222,
      (byte) 13,
      (byte) 171,
      (byte) 136,
      (byte) 41,
      (byte) 150,
      (byte) 94,
      (byte) 2,
      (byte) 177,
      (byte) 61,
      (byte) 174
    },
    new byte[16 /*0x10*/]
    {
      (byte) 66,
      (byte) 180,
      (byte) 117,
      (byte) 46,
      (byte) 168,
      (byte) 243,
      (byte) 20,
      (byte) 136,
      (byte) 11,
      (byte) 164,
      (byte) 84,
      (byte) 213,
      (byte) 56,
      (byte) 143,
      (byte) 187,
      (byte) 23
    },
    new byte[16 /*0x10*/]
    {
      (byte) 246,
      (byte) 22,
      (byte) 10,
      (byte) 54,
      (byte) 121,
      (byte) 183,
      (byte) 182,
      (byte) 174,
      (byte) 215,
      (byte) 127 /*0x7F*/,
      (byte) 66,
      (byte) 95,
      (byte) 91,
      (byte) 138,
      (byte) 187,
      (byte) 52
    },
    new byte[16 /*0x10*/]
    {
      (byte) 222,
      (byte) 175,
      (byte) 186,
      byte.MaxValue,
      (byte) 24,
      (byte) 89,
      (byte) 206,
      (byte) 67,
      (byte) 56,
      (byte) 84,
      (byte) 229,
      (byte) 203,
      (byte) 65,
      (byte) 82,
      (byte) 246,
      (byte) 38
    },
    new byte[16 /*0x10*/]
    {
      (byte) 120,
      (byte) 201,
      (byte) 158,
      (byte) 131,
      (byte) 247,
      (byte) 156,
      (byte) 202,
      (byte) 162,
      (byte) 106,
      (byte) 2,
      (byte) 243,
      (byte) 185,
      (byte) 84,
      (byte) 154,
      (byte) 233,
      (byte) 76
    },
    new byte[16 /*0x10*/]
    {
      (byte) 53,
      (byte) 18,
      (byte) 144 /*0x90*/,
      (byte) 34,
      (byte) 40,
      (byte) 110,
      (byte) 192 /*0xC0*/,
      (byte) 64 /*0x40*/,
      (byte) 190,
      (byte) 247,
      (byte) 223,
      (byte) 27,
      (byte) 26,
      (byte) 165,
      (byte) 81,
      (byte) 174
    },
    new byte[16 /*0x10*/]
    {
      (byte) 207,
      (byte) 89,
      (byte) 166,
      (byte) 72,
      (byte) 15,
      (byte) 188,
      (byte) 115,
      (byte) 193,
      (byte) 43,
      (byte) 210,
      (byte) 126,
      (byte) 186,
      (byte) 60,
      (byte) 97,
      (byte) 193,
      (byte) 160 /*0xA0*/
    },
    new byte[16 /*0x10*/]
    {
      (byte) 161,
      (byte) 157,
      (byte) 197,
      (byte) 233,
      (byte) 253,
      (byte) 189,
      (byte) 214,
      (byte) 74,
      (byte) 136,
      (byte) 130,
      (byte) 40,
      (byte) 2,
      (byte) 3,
      (byte) 204,
      (byte) 106,
      (byte) 117
    }
  };
  private static readonly byte[,] S = new byte[16 /*0x10*/, 16 /*0x10*/]
  {
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
      (byte) 118
    },
    {
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
      (byte) 192 /*0xC0*/
    },
    {
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
      (byte) 21
    },
    {
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
      (byte) 117
    },
    {
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
      (byte) 132
    },
    {
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
      (byte) 207
    },
    {
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
      (byte) 168
    },
    {
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
      (byte) 210
    },
    {
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
      (byte) 115
    },
    {
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
      (byte) 219
    },
    {
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
      (byte) 121
    },
    {
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
      (byte) 8
    },
    {
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
      (byte) 138
    },
    {
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
      (byte) 158
    },
    {
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
      (byte) 223
    },
    {
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
    }
  };

  private static byte SBox(byte x) => HarakaBase.S[(int) ((uint) x >> 4), (int) x & 15];

  private static byte[] SubBytes(byte[] s)
  {
    byte[] numArray = new byte[s.Length];
    for (int index = 0; index < 16 /*0x10*/; ++index)
      numArray[index] = HarakaBase.SBox(s[index]);
    return numArray;
  }

  private static byte[] ShiftRows(byte[] s)
  {
    return new byte[16 /*0x10*/]
    {
      s[0],
      s[5],
      s[10],
      s[15],
      s[4],
      s[9],
      s[14],
      s[3],
      s[8],
      s[13],
      s[2],
      s[7],
      s[12],
      s[1],
      s[6],
      s[11]
    };
  }

  internal static byte[] AesEnc(byte[] s, byte[] rk)
  {
    s = HarakaBase.SubBytes(s);
    s = HarakaBase.ShiftRows(s);
    s = HarakaBase.MixColumns(s);
    HarakaBase.XorTo(rk, s);
    return s;
  }

  private static byte MulX(byte p)
  {
    return (byte) ((ulong) (((int) p & (int) sbyte.MaxValue) << 1) ^ (ulong) (((uint) p >> 7) * 27U));
  }

  internal static byte[] Xor(byte[] x, byte[] y, int yStart)
  {
    byte[] numArray = new byte[16 /*0x10*/];
    for (int index = 0; index < numArray.Length; ++index)
      numArray[index] = (byte) ((int) x[index] ^ (int) y[yStart++]);
    return numArray;
  }

  private static void XorTo(byte[] x, byte[] z)
  {
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      z[index] ^= x[index];
      z[index + 1] ^= x[index + 1];
      z[index + 2] ^= x[index + 2];
      z[index + 3] ^= x[index + 3];
    }
  }

  private static byte[] MixColumns(byte[] s)
  {
    byte[] numArray1 = new byte[s.Length];
    int num1 = 0;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      int index2 = index1 << 2;
      byte[] numArray2 = numArray1;
      int index3 = num1;
      int num2 = index3 + 1;
      int num3 = (int) (byte) ((uint) HarakaBase.MulX(s[index2]) ^ (uint) HarakaBase.MulX(s[index2 + 1]) ^ (uint) s[index2 + 1] ^ (uint) s[index2 + 2] ^ (uint) s[index2 + 3]);
      numArray2[index3] = (byte) num3;
      byte[] numArray3 = numArray1;
      int index4 = num2;
      int num4 = index4 + 1;
      int num5 = (int) (byte) ((uint) s[index2] ^ (uint) HarakaBase.MulX(s[index2 + 1]) ^ (uint) HarakaBase.MulX(s[index2 + 2]) ^ (uint) s[index2 + 2] ^ (uint) s[index2 + 3]);
      numArray3[index4] = (byte) num5;
      byte[] numArray4 = numArray1;
      int index5 = num4;
      int num6 = index5 + 1;
      int num7 = (int) (byte) ((uint) s[index2] ^ (uint) s[index2 + 1] ^ (uint) HarakaBase.MulX(s[index2 + 2]) ^ (uint) HarakaBase.MulX(s[index2 + 3]) ^ (uint) s[index2 + 3]);
      numArray4[index5] = (byte) num7;
      byte[] numArray5 = numArray1;
      int index6 = num6;
      num1 = index6 + 1;
      int num8 = (int) (byte) ((uint) HarakaBase.MulX(s[index2]) ^ (uint) s[index2] ^ (uint) s[index2 + 1] ^ (uint) s[index2 + 2] ^ (uint) HarakaBase.MulX(s[index2 + 3]));
      numArray5[index6] = (byte) num8;
    }
    return numArray1;
  }

  public abstract string AlgorithmName { get; }

  public int GetDigestSize() => HarakaBase.DIGEST_SIZE;

  public abstract int GetByteLength();

  public abstract void Update(byte input);

  public abstract void BlockUpdate(byte[] input, int inOff, int length);

  public abstract int DoFinal(byte[] output, int outOff);

  public abstract void Reset();
}
