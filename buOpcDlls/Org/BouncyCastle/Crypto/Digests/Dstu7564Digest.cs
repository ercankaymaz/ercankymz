// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Dstu7564Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class Dstu7564Digest : IDigest, IMemoable
{
  private const int NB_512 = 8;
  private const int NB_1024 = 16 /*0x10*/;
  private const int NR_512 = 10;
  private const int NR_1024 = 14;
  private int hashSize;
  private int blockSize;
  private int columns;
  private int rounds;
  private ulong[] state;
  private ulong[] tempState1;
  private ulong[] tempState2;
  private ulong inputBlocks;
  private int bufOff;
  private byte[] buf;
  private static readonly byte[] S0 = new byte[256 /*0x0100*/]
  {
    (byte) 168,
    (byte) 67,
    (byte) 95,
    (byte) 6,
    (byte) 107,
    (byte) 117,
    (byte) 108,
    (byte) 89,
    (byte) 113,
    (byte) 223,
    (byte) 135,
    (byte) 149,
    (byte) 23,
    (byte) 240 /*0xF0*/,
    (byte) 216,
    (byte) 9,
    (byte) 109,
    (byte) 243,
    (byte) 29,
    (byte) 203,
    (byte) 201,
    (byte) 77,
    (byte) 44,
    (byte) 175,
    (byte) 121,
    (byte) 224 /*0xE0*/,
    (byte) 151,
    (byte) 253,
    (byte) 111,
    (byte) 75,
    (byte) 69,
    (byte) 57,
    (byte) 62,
    (byte) 221,
    (byte) 163,
    (byte) 79,
    (byte) 180,
    (byte) 182,
    (byte) 154,
    (byte) 14,
    (byte) 31 /*0x1F*/,
    (byte) 191,
    (byte) 21,
    (byte) 225,
    (byte) 73,
    (byte) 210,
    (byte) 147,
    (byte) 198,
    (byte) 146,
    (byte) 114,
    (byte) 158,
    (byte) 97,
    (byte) 209,
    (byte) 99,
    (byte) 250,
    (byte) 238,
    (byte) 244,
    (byte) 25,
    (byte) 213,
    (byte) 173,
    (byte) 88,
    (byte) 164,
    (byte) 187,
    (byte) 161,
    (byte) 220,
    (byte) 242,
    (byte) 131,
    (byte) 55,
    (byte) 66,
    (byte) 228,
    (byte) 122,
    (byte) 50,
    (byte) 156,
    (byte) 204,
    (byte) 171,
    (byte) 74,
    (byte) 143,
    (byte) 110,
    (byte) 4,
    (byte) 39,
    (byte) 46,
    (byte) 231,
    (byte) 226,
    (byte) 90,
    (byte) 150,
    (byte) 22,
    (byte) 35,
    (byte) 43,
    (byte) 194,
    (byte) 101,
    (byte) 102,
    (byte) 15,
    (byte) 188,
    (byte) 169,
    (byte) 71,
    (byte) 65,
    (byte) 52,
    (byte) 72,
    (byte) 252,
    (byte) 183,
    (byte) 106,
    (byte) 136,
    (byte) 165,
    (byte) 83,
    (byte) 134,
    (byte) 249,
    (byte) 91,
    (byte) 219,
    (byte) 56,
    (byte) 123,
    (byte) 195,
    (byte) 30,
    (byte) 34,
    (byte) 51,
    (byte) 36,
    (byte) 40,
    (byte) 54,
    (byte) 199,
    (byte) 178,
    (byte) 59,
    (byte) 142,
    (byte) 119,
    (byte) 186,
    (byte) 245,
    (byte) 20,
    (byte) 159,
    (byte) 8,
    (byte) 85,
    (byte) 155,
    (byte) 76,
    (byte) 254,
    (byte) 96 /*0x60*/,
    (byte) 92,
    (byte) 218,
    (byte) 24,
    (byte) 70,
    (byte) 205,
    (byte) 125,
    (byte) 33,
    (byte) 176 /*0xB0*/,
    (byte) 63 /*0x3F*/,
    (byte) 27,
    (byte) 137,
    byte.MaxValue,
    (byte) 235,
    (byte) 132,
    (byte) 105,
    (byte) 58,
    (byte) 157,
    (byte) 215,
    (byte) 211,
    (byte) 112 /*0x70*/,
    (byte) 103,
    (byte) 64 /*0x40*/,
    (byte) 181,
    (byte) 222,
    (byte) 93,
    (byte) 48 /*0x30*/,
    (byte) 145,
    (byte) 177,
    (byte) 120,
    (byte) 17,
    (byte) 1,
    (byte) 229,
    (byte) 0,
    (byte) 104,
    (byte) 152,
    (byte) 160 /*0xA0*/,
    (byte) 197,
    (byte) 2,
    (byte) 166,
    (byte) 116,
    (byte) 45,
    (byte) 11,
    (byte) 162,
    (byte) 118,
    (byte) 179,
    (byte) 190,
    (byte) 206,
    (byte) 189,
    (byte) 174,
    (byte) 233,
    (byte) 138,
    (byte) 49,
    (byte) 28,
    (byte) 236,
    (byte) 241,
    (byte) 153,
    (byte) 148,
    (byte) 170,
    (byte) 246,
    (byte) 38,
    (byte) 47,
    (byte) 239,
    (byte) 232,
    (byte) 140,
    (byte) 53,
    (byte) 3,
    (byte) 212,
    (byte) 127 /*0x7F*/,
    (byte) 251,
    (byte) 5,
    (byte) 193,
    (byte) 94,
    (byte) 144 /*0x90*/,
    (byte) 32 /*0x20*/,
    (byte) 61,
    (byte) 130,
    (byte) 247,
    (byte) 234,
    (byte) 10,
    (byte) 13,
    (byte) 126,
    (byte) 248,
    (byte) 80 /*0x50*/,
    (byte) 26,
    (byte) 196,
    (byte) 7,
    (byte) 87,
    (byte) 184,
    (byte) 60,
    (byte) 98,
    (byte) 227,
    (byte) 200,
    (byte) 172,
    (byte) 82,
    (byte) 100,
    (byte) 16 /*0x10*/,
    (byte) 208 /*0xD0*/,
    (byte) 217,
    (byte) 19,
    (byte) 12,
    (byte) 18,
    (byte) 41,
    (byte) 81,
    (byte) 185,
    (byte) 207,
    (byte) 214,
    (byte) 115,
    (byte) 141,
    (byte) 129,
    (byte) 84,
    (byte) 192 /*0xC0*/,
    (byte) 237,
    (byte) 78,
    (byte) 68,
    (byte) 167,
    (byte) 42,
    (byte) 133,
    (byte) 37,
    (byte) 230,
    (byte) 202,
    (byte) 124,
    (byte) 139,
    (byte) 86,
    (byte) 128 /*0x80*/
  };
  private static readonly byte[] S1 = new byte[256 /*0x0100*/]
  {
    (byte) 206,
    (byte) 187,
    (byte) 235,
    (byte) 146,
    (byte) 234,
    (byte) 203,
    (byte) 19,
    (byte) 193,
    (byte) 233,
    (byte) 58,
    (byte) 214,
    (byte) 178,
    (byte) 210,
    (byte) 144 /*0x90*/,
    (byte) 23,
    (byte) 248,
    (byte) 66,
    (byte) 21,
    (byte) 86,
    (byte) 180,
    (byte) 101,
    (byte) 28,
    (byte) 136,
    (byte) 67,
    (byte) 197,
    (byte) 92,
    (byte) 54,
    (byte) 186,
    (byte) 245,
    (byte) 87,
    (byte) 103,
    (byte) 141,
    (byte) 49,
    (byte) 246,
    (byte) 100,
    (byte) 88,
    (byte) 158,
    (byte) 244,
    (byte) 34,
    (byte) 170,
    (byte) 117,
    (byte) 15,
    (byte) 2,
    (byte) 177,
    (byte) 223,
    (byte) 109,
    (byte) 115,
    (byte) 77,
    (byte) 124,
    (byte) 38,
    (byte) 46,
    (byte) 247,
    (byte) 8,
    (byte) 93,
    (byte) 68,
    (byte) 62,
    (byte) 159,
    (byte) 20,
    (byte) 200,
    (byte) 174,
    (byte) 84,
    (byte) 16 /*0x10*/,
    (byte) 216,
    (byte) 188,
    (byte) 26,
    (byte) 107,
    (byte) 105,
    (byte) 243,
    (byte) 189,
    (byte) 51,
    (byte) 171,
    (byte) 250,
    (byte) 209,
    (byte) 155,
    (byte) 104,
    (byte) 78,
    (byte) 22,
    (byte) 149,
    (byte) 145,
    (byte) 238,
    (byte) 76,
    (byte) 99,
    (byte) 142,
    (byte) 91,
    (byte) 204,
    (byte) 60,
    (byte) 25,
    (byte) 161,
    (byte) 129,
    (byte) 73,
    (byte) 123,
    (byte) 217,
    (byte) 111,
    (byte) 55,
    (byte) 96 /*0x60*/,
    (byte) 202,
    (byte) 231,
    (byte) 43,
    (byte) 72,
    (byte) 253,
    (byte) 150,
    (byte) 69,
    (byte) 252,
    (byte) 65,
    (byte) 18,
    (byte) 13,
    (byte) 121,
    (byte) 229,
    (byte) 137,
    (byte) 140,
    (byte) 227,
    (byte) 32 /*0x20*/,
    (byte) 48 /*0x30*/,
    (byte) 220,
    (byte) 183,
    (byte) 108,
    (byte) 74,
    (byte) 181,
    (byte) 63 /*0x3F*/,
    (byte) 151,
    (byte) 212,
    (byte) 98,
    (byte) 45,
    (byte) 6,
    (byte) 164,
    (byte) 165,
    (byte) 131,
    (byte) 95,
    (byte) 42,
    (byte) 218,
    (byte) 201,
    (byte) 0,
    (byte) 126,
    (byte) 162,
    (byte) 85,
    (byte) 191,
    (byte) 17,
    (byte) 213,
    (byte) 156,
    (byte) 207,
    (byte) 14,
    (byte) 10,
    (byte) 61,
    (byte) 81,
    (byte) 125,
    (byte) 147,
    (byte) 27,
    (byte) 254,
    (byte) 196,
    (byte) 71,
    (byte) 9,
    (byte) 134,
    (byte) 11,
    (byte) 143,
    (byte) 157,
    (byte) 106,
    (byte) 7,
    (byte) 185,
    (byte) 176 /*0xB0*/,
    (byte) 152,
    (byte) 24,
    (byte) 50,
    (byte) 113,
    (byte) 75,
    (byte) 239,
    (byte) 59,
    (byte) 112 /*0x70*/,
    (byte) 160 /*0xA0*/,
    (byte) 228,
    (byte) 64 /*0x40*/,
    byte.MaxValue,
    (byte) 195,
    (byte) 169,
    (byte) 230,
    (byte) 120,
    (byte) 249,
    (byte) 139,
    (byte) 70,
    (byte) 128 /*0x80*/,
    (byte) 30,
    (byte) 56,
    (byte) 225,
    (byte) 184,
    (byte) 168,
    (byte) 224 /*0xE0*/,
    (byte) 12,
    (byte) 35,
    (byte) 118,
    (byte) 29,
    (byte) 37,
    (byte) 36,
    (byte) 5,
    (byte) 241,
    (byte) 110,
    (byte) 148,
    (byte) 40,
    (byte) 154,
    (byte) 132,
    (byte) 232,
    (byte) 163,
    (byte) 79,
    (byte) 119,
    (byte) 211,
    (byte) 133,
    (byte) 226,
    (byte) 82,
    (byte) 242,
    (byte) 130,
    (byte) 80 /*0x50*/,
    (byte) 122,
    (byte) 47,
    (byte) 116,
    (byte) 83,
    (byte) 179,
    (byte) 97,
    (byte) 175,
    (byte) 57,
    (byte) 53,
    (byte) 222,
    (byte) 205,
    (byte) 31 /*0x1F*/,
    (byte) 153,
    (byte) 172,
    (byte) 173,
    (byte) 114,
    (byte) 44,
    (byte) 221,
    (byte) 208 /*0xD0*/,
    (byte) 135,
    (byte) 190,
    (byte) 94,
    (byte) 166,
    (byte) 236,
    (byte) 4,
    (byte) 198,
    (byte) 3,
    (byte) 52,
    (byte) 251,
    (byte) 219,
    (byte) 89,
    (byte) 182,
    (byte) 194,
    (byte) 1,
    (byte) 240 /*0xF0*/,
    (byte) 90,
    (byte) 237,
    (byte) 167,
    (byte) 102,
    (byte) 33,
    (byte) 127 /*0x7F*/,
    (byte) 138,
    (byte) 39,
    (byte) 199,
    (byte) 192 /*0xC0*/,
    (byte) 41,
    (byte) 215
  };
  private static readonly byte[] S2 = new byte[256 /*0x0100*/]
  {
    (byte) 147,
    (byte) 217,
    (byte) 154,
    (byte) 181,
    (byte) 152,
    (byte) 34,
    (byte) 69,
    (byte) 252,
    (byte) 186,
    (byte) 106,
    (byte) 223,
    (byte) 2,
    (byte) 159,
    (byte) 220,
    (byte) 81,
    (byte) 89,
    (byte) 74,
    (byte) 23,
    (byte) 43,
    (byte) 194,
    (byte) 148,
    (byte) 244,
    (byte) 187,
    (byte) 163,
    (byte) 98,
    (byte) 228,
    (byte) 113,
    (byte) 212,
    (byte) 205,
    (byte) 112 /*0x70*/,
    (byte) 22,
    (byte) 225,
    (byte) 73,
    (byte) 60,
    (byte) 192 /*0xC0*/,
    (byte) 216,
    (byte) 92,
    (byte) 155,
    (byte) 173,
    (byte) 133,
    (byte) 83,
    (byte) 161,
    (byte) 122,
    (byte) 200,
    (byte) 45,
    (byte) 224 /*0xE0*/,
    (byte) 209,
    (byte) 114,
    (byte) 166,
    (byte) 44,
    (byte) 196,
    (byte) 227,
    (byte) 118,
    (byte) 120,
    (byte) 183,
    (byte) 180,
    (byte) 9,
    (byte) 59,
    (byte) 14,
    (byte) 65,
    (byte) 76,
    (byte) 222,
    (byte) 178,
    (byte) 144 /*0x90*/,
    (byte) 37,
    (byte) 165,
    (byte) 215,
    (byte) 3,
    (byte) 17,
    (byte) 0,
    (byte) 195,
    (byte) 46,
    (byte) 146,
    (byte) 239,
    (byte) 78,
    (byte) 18,
    (byte) 157,
    (byte) 125,
    (byte) 203,
    (byte) 53,
    (byte) 16 /*0x10*/,
    (byte) 213,
    (byte) 79,
    (byte) 158,
    (byte) 77,
    (byte) 169,
    (byte) 85,
    (byte) 198,
    (byte) 208 /*0xD0*/,
    (byte) 123,
    (byte) 24,
    (byte) 151,
    (byte) 211,
    (byte) 54,
    (byte) 230,
    (byte) 72,
    (byte) 86,
    (byte) 129,
    (byte) 143,
    (byte) 119,
    (byte) 204,
    (byte) 156,
    (byte) 185,
    (byte) 226,
    (byte) 172,
    (byte) 184,
    (byte) 47,
    (byte) 21,
    (byte) 164,
    (byte) 124,
    (byte) 218,
    (byte) 56,
    (byte) 30,
    (byte) 11,
    (byte) 5,
    (byte) 214,
    (byte) 20,
    (byte) 110,
    (byte) 108,
    (byte) 126,
    (byte) 102,
    (byte) 253,
    (byte) 177,
    (byte) 229,
    (byte) 96 /*0x60*/,
    (byte) 175,
    (byte) 94,
    (byte) 51,
    (byte) 135,
    (byte) 201,
    (byte) 240 /*0xF0*/,
    (byte) 93,
    (byte) 109,
    (byte) 63 /*0x3F*/,
    (byte) 136,
    (byte) 141,
    (byte) 199,
    (byte) 247,
    (byte) 29,
    (byte) 233,
    (byte) 236,
    (byte) 237,
    (byte) 128 /*0x80*/,
    (byte) 41,
    (byte) 39,
    (byte) 207,
    (byte) 153,
    (byte) 168,
    (byte) 80 /*0x50*/,
    (byte) 15,
    (byte) 55,
    (byte) 36,
    (byte) 40,
    (byte) 48 /*0x30*/,
    (byte) 149,
    (byte) 210,
    (byte) 62,
    (byte) 91,
    (byte) 64 /*0x40*/,
    (byte) 131,
    (byte) 179,
    (byte) 105,
    (byte) 87,
    (byte) 31 /*0x1F*/,
    (byte) 7,
    (byte) 28,
    (byte) 138,
    (byte) 188,
    (byte) 32 /*0x20*/,
    (byte) 235,
    (byte) 206,
    (byte) 142,
    (byte) 171,
    (byte) 238,
    (byte) 49,
    (byte) 162,
    (byte) 115,
    (byte) 249,
    (byte) 202,
    (byte) 58,
    (byte) 26,
    (byte) 251,
    (byte) 13,
    (byte) 193,
    (byte) 254,
    (byte) 250,
    (byte) 242,
    (byte) 111,
    (byte) 189,
    (byte) 150,
    (byte) 221,
    (byte) 67,
    (byte) 82,
    (byte) 182,
    (byte) 8,
    (byte) 243,
    (byte) 174,
    (byte) 190,
    (byte) 25,
    (byte) 137,
    (byte) 50,
    (byte) 38,
    (byte) 176 /*0xB0*/,
    (byte) 234,
    (byte) 75,
    (byte) 100,
    (byte) 132,
    (byte) 130,
    (byte) 107,
    (byte) 245,
    (byte) 121,
    (byte) 191,
    (byte) 1,
    (byte) 95,
    (byte) 117,
    (byte) 99,
    (byte) 27,
    (byte) 35,
    (byte) 61,
    (byte) 104,
    (byte) 42,
    (byte) 101,
    (byte) 232,
    (byte) 145,
    (byte) 246,
    byte.MaxValue,
    (byte) 19,
    (byte) 88,
    (byte) 241,
    (byte) 71,
    (byte) 10,
    (byte) 127 /*0x7F*/,
    (byte) 197,
    (byte) 167,
    (byte) 231,
    (byte) 97,
    (byte) 90,
    (byte) 6,
    (byte) 70,
    (byte) 68,
    (byte) 66,
    (byte) 4,
    (byte) 160 /*0xA0*/,
    (byte) 219,
    (byte) 57,
    (byte) 134,
    (byte) 84,
    (byte) 170,
    (byte) 140,
    (byte) 52,
    (byte) 33,
    (byte) 139,
    (byte) 248,
    (byte) 12,
    (byte) 116,
    (byte) 103
  };
  private static readonly byte[] S3 = new byte[256 /*0x0100*/]
  {
    (byte) 104,
    (byte) 141,
    (byte) 202,
    (byte) 77,
    (byte) 115,
    (byte) 75,
    (byte) 78,
    (byte) 42,
    (byte) 212,
    (byte) 82,
    (byte) 38,
    (byte) 179,
    (byte) 84,
    (byte) 30,
    (byte) 25,
    (byte) 31 /*0x1F*/,
    (byte) 34,
    (byte) 3,
    (byte) 70,
    (byte) 61,
    (byte) 45,
    (byte) 74,
    (byte) 83,
    (byte) 131,
    (byte) 19,
    (byte) 138,
    (byte) 183,
    (byte) 213,
    (byte) 37,
    (byte) 121,
    (byte) 245,
    (byte) 189,
    (byte) 88,
    (byte) 47,
    (byte) 13,
    (byte) 2,
    (byte) 237,
    (byte) 81,
    (byte) 158,
    (byte) 17,
    (byte) 242,
    (byte) 62,
    (byte) 85,
    (byte) 94,
    (byte) 209,
    (byte) 22,
    (byte) 60,
    (byte) 102,
    (byte) 112 /*0x70*/,
    (byte) 93,
    (byte) 243,
    (byte) 69,
    (byte) 64 /*0x40*/,
    (byte) 204,
    (byte) 232,
    (byte) 148,
    (byte) 86,
    (byte) 8,
    (byte) 206,
    (byte) 26,
    (byte) 58,
    (byte) 210,
    (byte) 225,
    (byte) 223,
    (byte) 181,
    (byte) 56,
    (byte) 110,
    (byte) 14,
    (byte) 229,
    (byte) 244,
    (byte) 249,
    (byte) 134,
    (byte) 233,
    (byte) 79,
    (byte) 214,
    (byte) 133,
    (byte) 35,
    (byte) 207,
    (byte) 50,
    (byte) 153,
    (byte) 49,
    (byte) 20,
    (byte) 174,
    (byte) 238,
    (byte) 200,
    (byte) 72,
    (byte) 211,
    (byte) 48 /*0x30*/,
    (byte) 161,
    (byte) 146,
    (byte) 65,
    (byte) 177,
    (byte) 24,
    (byte) 196,
    (byte) 44,
    (byte) 113,
    (byte) 114,
    (byte) 68,
    (byte) 21,
    (byte) 253,
    (byte) 55,
    (byte) 190,
    (byte) 95,
    (byte) 170,
    (byte) 155,
    (byte) 136,
    (byte) 216,
    (byte) 171,
    (byte) 137,
    (byte) 156,
    (byte) 250,
    (byte) 96 /*0x60*/,
    (byte) 234,
    (byte) 188,
    (byte) 98,
    (byte) 12,
    (byte) 36,
    (byte) 166,
    (byte) 168,
    (byte) 236,
    (byte) 103,
    (byte) 32 /*0x20*/,
    (byte) 219,
    (byte) 124,
    (byte) 40,
    (byte) 221,
    (byte) 172,
    (byte) 91,
    (byte) 52,
    (byte) 126,
    (byte) 16 /*0x10*/,
    (byte) 241,
    (byte) 123,
    (byte) 143,
    (byte) 99,
    (byte) 160 /*0xA0*/,
    (byte) 5,
    (byte) 154,
    (byte) 67,
    (byte) 119,
    (byte) 33,
    (byte) 191,
    (byte) 39,
    (byte) 9,
    (byte) 195,
    (byte) 159,
    (byte) 182,
    (byte) 215,
    (byte) 41,
    (byte) 194,
    (byte) 235,
    (byte) 192 /*0xC0*/,
    (byte) 164,
    (byte) 139,
    (byte) 140,
    (byte) 29,
    (byte) 251,
    byte.MaxValue,
    (byte) 193,
    (byte) 178,
    (byte) 151,
    (byte) 46,
    (byte) 248,
    (byte) 101,
    (byte) 246,
    (byte) 117,
    (byte) 7,
    (byte) 4,
    (byte) 73,
    (byte) 51,
    (byte) 228,
    (byte) 217,
    (byte) 185,
    (byte) 208 /*0xD0*/,
    (byte) 66,
    (byte) 199,
    (byte) 108,
    (byte) 144 /*0x90*/,
    (byte) 0,
    (byte) 142,
    (byte) 111,
    (byte) 80 /*0x50*/,
    (byte) 1,
    (byte) 197,
    (byte) 218,
    (byte) 71,
    (byte) 63 /*0x3F*/,
    (byte) 205,
    (byte) 105,
    (byte) 162,
    (byte) 226,
    (byte) 122,
    (byte) 167,
    (byte) 198,
    (byte) 147,
    (byte) 15,
    (byte) 10,
    (byte) 6,
    (byte) 230,
    (byte) 43,
    (byte) 150,
    (byte) 163,
    (byte) 28,
    (byte) 175,
    (byte) 106,
    (byte) 18,
    (byte) 132,
    (byte) 57,
    (byte) 231,
    (byte) 176 /*0xB0*/,
    (byte) 130,
    (byte) 247,
    (byte) 254,
    (byte) 157,
    (byte) 135,
    (byte) 92,
    (byte) 129,
    (byte) 53,
    (byte) 222,
    (byte) 180,
    (byte) 165,
    (byte) 252,
    (byte) 128 /*0x80*/,
    (byte) 239,
    (byte) 203,
    (byte) 187,
    (byte) 107,
    (byte) 118,
    (byte) 186,
    (byte) 90,
    (byte) 125,
    (byte) 120,
    (byte) 11,
    (byte) 149,
    (byte) 227,
    (byte) 173,
    (byte) 116,
    (byte) 152,
    (byte) 59,
    (byte) 54,
    (byte) 100,
    (byte) 109,
    (byte) 220,
    (byte) 240 /*0xF0*/,
    (byte) 89,
    (byte) 169,
    (byte) 76,
    (byte) 23,
    (byte) 127 /*0x7F*/,
    (byte) 145,
    (byte) 184,
    (byte) 201,
    (byte) 87,
    (byte) 27,
    (byte) 224 /*0xE0*/,
    (byte) 97
  };

  public Dstu7564Digest(Dstu7564Digest digest) => this.CopyIn(digest);

  private void CopyIn(Dstu7564Digest digest)
  {
    this.hashSize = digest.hashSize;
    this.blockSize = digest.blockSize;
    this.rounds = digest.rounds;
    if (this.columns > 0 && this.columns == digest.columns)
    {
      Array.Copy((Array) digest.state, 0, (Array) this.state, 0, this.columns);
      Array.Copy((Array) digest.buf, 0, (Array) this.buf, 0, this.blockSize);
    }
    else
    {
      this.columns = digest.columns;
      this.state = Arrays.Clone(digest.state);
      this.tempState1 = new ulong[this.columns];
      this.tempState2 = new ulong[this.columns];
      this.buf = Arrays.Clone(digest.buf);
    }
    this.inputBlocks = digest.inputBlocks;
    this.bufOff = digest.bufOff;
  }

  public Dstu7564Digest(int hashSizeBits)
  {
    if (hashSizeBits != 256 /*0x0100*/ && hashSizeBits != 384 && hashSizeBits != 512 /*0x0200*/)
      throw new ArgumentException("Hash size is not recommended. Use 256/384/512 instead");
    this.hashSize = hashSizeBits / 8;
    if (hashSizeBits > 256 /*0x0100*/)
    {
      this.columns = 16 /*0x10*/;
      this.rounds = 14;
    }
    else
    {
      this.columns = 8;
      this.rounds = 10;
    }
    this.blockSize = this.columns << 3;
    this.state = new ulong[this.columns];
    this.state[0] = (ulong) this.blockSize;
    this.tempState1 = new ulong[this.columns];
    this.tempState2 = new ulong[this.columns];
    this.buf = new byte[this.blockSize];
  }

  public virtual string AlgorithmName => "DSTU7564";

  public virtual int GetDigestSize() => this.hashSize;

  public virtual int GetByteLength() => this.blockSize;

  public virtual void Update(byte input)
  {
    this.buf[this.bufOff++] = input;
    if (this.bufOff != this.blockSize)
      return;
    this.ProcessBlock(this.buf, 0);
    this.bufOff = 0;
    ++this.inputBlocks;
  }

  public virtual void BlockUpdate(byte[] input, int inOff, int length)
  {
    for (; this.bufOff != 0 && length > 0; --length)
      this.Update(input[inOff++]);
    while (length >= this.blockSize)
    {
      this.ProcessBlock(input, inOff);
      inOff += this.blockSize;
      length -= this.blockSize;
      ++this.inputBlocks;
    }
    for (; length > 0; --length)
      this.Update(input[inOff++]);
  }

  public virtual int DoFinal(byte[] output, int outOff)
  {
    int bufOff = this.bufOff;
    this.buf[this.bufOff++] = (byte) 128 /*0x80*/;
    int num1 = this.blockSize - 12;
    if (this.bufOff > num1)
    {
      while (this.bufOff < this.blockSize)
        this.buf[this.bufOff++] = (byte) 0;
      this.bufOff = 0;
      this.ProcessBlock(this.buf, 0);
    }
    while (this.bufOff < num1)
      this.buf[this.bufOff++] = (byte) 0;
    long num2;
    Pack.UInt32_To_LE((uint) (int) (num2 = ((long) this.inputBlocks & (long) uint.MaxValue) * (long) this.blockSize + (long) (uint) bufOff << 3), this.buf, this.bufOff);
    this.bufOff += 4;
    Pack.UInt64_To_LE((ulong) ((num2 >>> 32 /*0x20*/) + ((long) (this.inputBlocks >> 32 /*0x20*/) * (long) this.blockSize << 3)), this.buf, this.bufOff);
    this.ProcessBlock(this.buf, 0);
    Array.Copy((Array) this.state, 0, (Array) this.tempState1, 0, this.columns);
    this.P(this.tempState1);
    for (int index = 0; index < this.columns; ++index)
      this.state[index] ^= this.tempState1[index];
    for (int index = this.columns - this.hashSize / 8; index < this.columns; ++index)
    {
      Pack.UInt64_To_LE(this.state[index], output, outOff);
      outOff += 8;
    }
    this.Reset();
    return this.hashSize;
  }

  public virtual void Reset()
  {
    Array.Clear((Array) this.state, 0, this.state.Length);
    this.state[0] = (ulong) this.blockSize;
    this.inputBlocks = 0UL;
    this.bufOff = 0;
  }

  protected virtual void ProcessBlock(byte[] input, int inOff)
  {
    int off = inOff;
    for (int index = 0; index < this.columns; ++index)
    {
      ulong uint64 = Pack.LE_To_UInt64(input, off);
      off += 8;
      this.tempState1[index] = this.state[index] ^ uint64;
      this.tempState2[index] = uint64;
    }
    this.P(this.tempState1);
    this.Q(this.tempState2);
    for (int index = 0; index < this.columns; ++index)
      this.state[index] ^= this.tempState1[index] ^ this.tempState2[index];
  }

  private void P(ulong[] s)
  {
    for (int index1 = 0; index1 < this.rounds; ++index1)
    {
      ulong num = (ulong) index1;
      for (int index2 = 0; index2 < this.columns; ++index2)
      {
        s[index2] ^= num;
        num += 16UL /*0x10*/;
      }
      this.ShiftRows(s);
      this.SubBytes(s);
      this.MixColumns(s);
    }
  }

  private void Q(ulong[] s)
  {
    for (int index1 = 0; index1 < this.rounds; ++index1)
    {
      ulong num = (ulong) ((long) (this.columns - 1 << 4 ^ index1) << 56 | 67818912035696883L);
      for (int index2 = 0; index2 < this.columns; ++index2)
      {
        s[index2] += num;
        num -= 1152921504606846976UL /*0x1000000000000000*/;
      }
      this.ShiftRows(s);
      this.SubBytes(s);
      this.MixColumns(s);
    }
  }

  private static ulong MixColumn(ulong c)
  {
    ulong x1 = (ulong) (((long) c & 9187201950435737471L /*0x7F7F7F7F7F7F7F7F*/) << 1 ^ (long) ((c & 9259542123273814144UL /*0x8080808080808080*/) >> 7) * 29L);
    ulong x2 = Dstu7564Digest.Rotate(8, c) ^ c;
    ulong num1 = x2 ^ Dstu7564Digest.Rotate(16 /*0x10*/, x2) ^ Dstu7564Digest.Rotate(48 /*0x30*/, c);
    ulong num2 = num1 ^ c ^ x1;
    ulong x3 = (ulong) (((long) num2 & 4557430888798830399L /*0x3F3F3F3F3F3F3F3F*/) << 2 ^ (long) ((num2 & 9259542123273814144UL /*0x8080808080808080*/) >> 6) * 29L ^ (long) ((num2 & 4629771061636907072UL /*0x4040404040404040*/) >> 6) * 29L);
    return num1 ^ Dstu7564Digest.Rotate(32 /*0x20*/, x3) ^ Dstu7564Digest.Rotate(40, x1) ^ Dstu7564Digest.Rotate(48 /*0x30*/, x1);
  }

  private void MixColumns(ulong[] s)
  {
    for (int index = 0; index < this.columns; ++index)
      s[index] = Dstu7564Digest.MixColumn(s[index]);
  }

  private static ulong Rotate(int n, ulong x) => x >> n | x << -n;

  private void ShiftRows(ulong[] s)
  {
    switch (this.columns)
    {
      case 8:
        ulong num1 = s[0];
        ulong num2 = s[1];
        ulong num3 = s[2];
        ulong num4 = s[3];
        ulong num5 = s[4];
        ulong num6 = s[5];
        ulong num7 = s[6];
        ulong num8 = s[7];
        ulong num9 = (ulong) (((long) num1 ^ (long) num5) & -4294967296L);
        ulong num10 = num1 ^ num9;
        ulong num11 = num5 ^ num9;
        ulong num12 = (ulong) (((long) num2 ^ (long) num6) & 72057594021150720L);
        ulong num13 = num2 ^ num12;
        ulong num14 = num6 ^ num12;
        ulong num15 = (ulong) (((long) num3 ^ (long) num7) & 281474976645120L);
        ulong num16 = num3 ^ num15;
        ulong num17 = num7 ^ num15;
        ulong num18 = (ulong) (((long) num4 ^ (long) num8) & 1099511627520L);
        ulong num19 = num4 ^ num18;
        ulong num20 = num8 ^ num18;
        ulong num21 = (ulong) (((long) num10 ^ (long) num16) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num22 = num10 ^ num21;
        ulong num23 = num16 ^ num21;
        ulong num24 = (ulong) (((long) num13 ^ (long) num19) & 72056494543077120L);
        ulong num25 = num13 ^ num24;
        ulong num26 = num19 ^ num24;
        ulong num27 = (ulong) (((long) num11 ^ (long) num17) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num28 = num11 ^ num27;
        ulong num29 = num17 ^ num27;
        ulong num30 = (ulong) (((long) num14 ^ (long) num20) & 72056494543077120L);
        ulong num31 = num14 ^ num30;
        ulong num32 = num20 ^ num30;
        ulong num33 = (ulong) (((long) num22 ^ (long) num25) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num34 = num22 ^ num33;
        ulong num35 = num25 ^ num33;
        ulong num36 = (ulong) (((long) num23 ^ (long) num26) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num37 = num23 ^ num36;
        ulong num38 = num26 ^ num36;
        ulong num39 = (ulong) (((long) num28 ^ (long) num31) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num40 = num28 ^ num39;
        ulong num41 = num31 ^ num39;
        ulong num42 = (ulong) (((long) num29 ^ (long) num32) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num43 = num29 ^ num42;
        ulong num44 = num32 ^ num42;
        s[0] = num34;
        s[1] = num35;
        s[2] = num37;
        s[3] = num38;
        s[4] = num40;
        s[5] = num41;
        s[6] = num43;
        s[7] = num44;
        break;
      case 16 /*0x10*/:
        ulong num45 = s[0];
        ulong num46 = s[1];
        ulong num47 = s[2];
        ulong num48 = s[3];
        ulong num49 = s[4];
        ulong num50 = s[5];
        ulong num51 = s[6];
        ulong num52 = s[7];
        ulong num53 = s[8];
        ulong num54 = s[9];
        ulong num55 = s[10];
        ulong num56 = s[11];
        ulong num57 = s[12];
        ulong num58 = s[13];
        ulong num59 = s[14];
        ulong num60 = s[15];
        ulong num61 = (ulong) (((long) num45 ^ (long) num53) & -72057594037927936L /*0xFF00000000000000*/);
        ulong num62 = num45 ^ num61;
        ulong num63 = num53 ^ num61;
        ulong num64 = (ulong) (((long) num46 ^ (long) num54) & -72057594037927936L /*0xFF00000000000000*/);
        ulong num65 = num46 ^ num64;
        ulong num66 = num54 ^ num64;
        ulong num67 = (ulong) (((long) num47 ^ (long) num55) & -281474976710656L /*0xFFFF000000000000*/);
        ulong num68 = num47 ^ num67;
        ulong num69 = num55 ^ num67;
        ulong num70 = (ulong) (((long) num48 ^ (long) num56) & -1099511627776L /*0xFFFFFF0000000000*/);
        ulong num71 = num48 ^ num70;
        ulong num72 = num56 ^ num70;
        ulong num73 = (ulong) (((long) num49 ^ (long) num57) & -4294967296L);
        ulong num74 = num49 ^ num73;
        ulong num75 = num57 ^ num73;
        ulong num76 = (ulong) (((long) num50 ^ (long) num58) & 72057594021150720L);
        ulong num77 = num50 ^ num76;
        ulong num78 = num58 ^ num76;
        ulong num79 = (ulong) (((long) num51 ^ (long) num59) & 72057594037862400L);
        ulong num80 = num51 ^ num79;
        ulong num81 = num59 ^ num79;
        ulong num82 = (ulong) (((long) num52 ^ (long) num60) & 72057594037927680L);
        ulong num83 = num52 ^ num82;
        ulong num84 = num60 ^ num82;
        ulong num85 = (ulong) (((long) num62 ^ (long) num74) & 72057589742960640L /*0xFFFFFF00000000*/);
        ulong num86 = num62 ^ num85;
        ulong num87 = num74 ^ num85;
        ulong num88 = (ulong) (((long) num65 ^ (long) num77) & -16777216L);
        ulong num89 = num65 ^ num88;
        ulong num90 = num77 ^ num88;
        ulong num91 = (ulong) (((long) num68 ^ (long) num80) & -71776119061282816L);
        ulong num92 = num68 ^ num91;
        ulong num93 = num80 ^ num91;
        ulong num94 = (ulong) (((long) num71 ^ (long) num83) & -72056494526300416L);
        ulong num95 = num71 ^ num94;
        ulong num96 = num83 ^ num94;
        ulong num97 = (ulong) (((long) num63 ^ (long) num75) & 72057589742960640L /*0xFFFFFF00000000*/);
        ulong num98 = num63 ^ num97;
        ulong num99 = num75 ^ num97;
        ulong num100 = (ulong) (((long) num66 ^ (long) num78) & -16777216L);
        ulong num101 = num66 ^ num100;
        ulong num102 = num78 ^ num100;
        ulong num103 = (ulong) (((long) num69 ^ (long) num81) & -71776119061282816L);
        ulong num104 = num69 ^ num103;
        ulong num105 = num81 ^ num103;
        ulong num106 = (ulong) (((long) num72 ^ (long) num84) & -72056494526300416L);
        ulong num107 = num72 ^ num106;
        ulong num108 = num84 ^ num106;
        ulong num109 = (ulong) (((long) num86 ^ (long) num92) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num110 = num86 ^ num109;
        ulong num111 = num92 ^ num109;
        ulong num112 = (ulong) (((long) num89 ^ (long) num95) & 72056494543077120L);
        ulong num113 = num89 ^ num112;
        ulong num114 = num95 ^ num112;
        ulong num115 = (ulong) (((long) num87 ^ (long) num93) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num116 = num87 ^ num115;
        ulong num117 = num93 ^ num115;
        ulong num118 = (ulong) (((long) num90 ^ (long) num96) & 72056494543077120L);
        ulong num119 = num90 ^ num118;
        ulong num120 = num96 ^ num118;
        ulong num121 = (ulong) (((long) num98 ^ (long) num104) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num122 = num98 ^ num121;
        ulong num123 = num104 ^ num121;
        ulong num124 = (ulong) (((long) num101 ^ (long) num107) & 72056494543077120L);
        ulong num125 = num101 ^ num124;
        ulong num126 = num107 ^ num124;
        ulong num127 = (ulong) (((long) num99 ^ (long) num105) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num128 = num99 ^ num127;
        ulong num129 = num105 ^ num127;
        ulong num130 = (ulong) (((long) num102 ^ (long) num108) & 72056494543077120L);
        ulong num131 = num102 ^ num130;
        ulong num132 = num108 ^ num130;
        ulong num133 = (ulong) (((long) num110 ^ (long) num113) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num134 = num110 ^ num133;
        ulong num135 = num113 ^ num133;
        ulong num136 = (ulong) (((long) num111 ^ (long) num114) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num137 = num111 ^ num136;
        ulong num138 = num114 ^ num136;
        ulong num139 = (ulong) (((long) num116 ^ (long) num119) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num140 = num116 ^ num139;
        ulong num141 = num119 ^ num139;
        ulong num142 = (ulong) (((long) num117 ^ (long) num120) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num143 = num117 ^ num142;
        ulong num144 = num120 ^ num142;
        ulong num145 = (ulong) (((long) num122 ^ (long) num125) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num146 = num122 ^ num145;
        ulong num147 = num125 ^ num145;
        ulong num148 = (ulong) (((long) num123 ^ (long) num126) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num149 = num123 ^ num148;
        ulong num150 = num126 ^ num148;
        ulong num151 = (ulong) (((long) num128 ^ (long) num131) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num152 = num128 ^ num151;
        ulong num153 = num131 ^ num151;
        ulong num154 = (ulong) (((long) num129 ^ (long) num132) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num155 = num129 ^ num154;
        ulong num156 = num132 ^ num154;
        s[0] = num134;
        s[1] = num135;
        s[2] = num137;
        s[3] = num138;
        s[4] = num140;
        s[5] = num141;
        s[6] = num143;
        s[7] = num144;
        s[8] = num146;
        s[9] = num147;
        s[10] = num149;
        s[11] = num150;
        s[12] = num152;
        s[13] = num153;
        s[14] = num155;
        s[15] = num156;
        break;
      default:
        throw new InvalidOperationException("unsupported state size: only 512/1024 are allowed");
    }
  }

  private void SubBytes(ulong[] s)
  {
    for (int index = 0; index < this.columns; ++index)
    {
      uint num1;
      uint num2 = (uint) ((ulong) (num1 = (uint) s[index]) >> 32 /*0x20*/);
      int num3 = (int) Dstu7564Digest.S0[(int) num1 & (int) byte.MaxValue];
      byte num4 = Dstu7564Digest.S1[(int) (num1 >> 8) & (int) byte.MaxValue];
      byte num5 = Dstu7564Digest.S2[(int) (num1 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num6 = Dstu7564Digest.S3[(int) (num1 >> 24)];
      int num7 = (int) num4 << 8;
      uint num8 = (uint) (num3 | num7 | (int) num5 << 16 /*0x10*/ | (int) num6 << 24);
      int num9 = (int) Dstu7564Digest.S0[(int) num2 & (int) byte.MaxValue];
      byte num10 = Dstu7564Digest.S1[(int) (num2 >> 8) & (int) byte.MaxValue];
      byte num11 = Dstu7564Digest.S2[(int) (num2 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num12 = Dstu7564Digest.S3[(int) (num2 >> 24)];
      int num13 = (int) num10 << 8;
      uint num14 = (uint) (num9 | num13 | (int) num11 << 16 /*0x10*/ | (int) num12 << 24);
      s[index] = (ulong) num8 | (ulong) num14 << 32 /*0x20*/;
    }
  }

  public virtual IMemoable Copy() => (IMemoable) new Dstu7564Digest(this);

  public virtual void Reset(IMemoable other) => this.CopyIn((Dstu7564Digest) other);
}
