// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.Dstu7624Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class Dstu7624Engine : IBlockCipher
{
  private ulong[] internalState;
  private ulong[] workingKey;
  private ulong[][] roundKeys;
  private int wordsInBlock;
  private int wordsInKey;
  private const int ROUNDS_128 = 10;
  private const int ROUNDS_256 = 14;
  private const int ROUNDS_512 = 18;
  private int roundsAmount;
  private bool forEncryption;
  private const ulong mdsMatrix = 290207332435296513;
  private const ulong mdsInvMatrix = 14616231584692868525;
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
  private static readonly byte[] T0 = new byte[256 /*0x0100*/]
  {
    (byte) 164,
    (byte) 162,
    (byte) 169,
    (byte) 197,
    (byte) 78,
    (byte) 201,
    (byte) 3,
    (byte) 217,
    (byte) 126,
    (byte) 15,
    (byte) 210,
    (byte) 173,
    (byte) 231,
    (byte) 211,
    (byte) 39,
    (byte) 91,
    (byte) 227,
    (byte) 161,
    (byte) 232,
    (byte) 230,
    (byte) 124,
    (byte) 42,
    (byte) 85,
    (byte) 12,
    (byte) 134,
    (byte) 57,
    (byte) 215,
    (byte) 141,
    (byte) 184,
    (byte) 18,
    (byte) 111,
    (byte) 40,
    (byte) 205,
    (byte) 138,
    (byte) 112 /*0x70*/,
    (byte) 86,
    (byte) 114,
    (byte) 249,
    (byte) 191,
    (byte) 79,
    (byte) 115,
    (byte) 233,
    (byte) 247,
    (byte) 87,
    (byte) 22,
    (byte) 172,
    (byte) 80 /*0x50*/,
    (byte) 192 /*0xC0*/,
    (byte) 157,
    (byte) 183,
    (byte) 71,
    (byte) 113,
    (byte) 96 /*0x60*/,
    (byte) 196,
    (byte) 116,
    (byte) 67,
    (byte) 108,
    (byte) 31 /*0x1F*/,
    (byte) 147,
    (byte) 119,
    (byte) 220,
    (byte) 206,
    (byte) 32 /*0x20*/,
    (byte) 140,
    (byte) 153,
    (byte) 95,
    (byte) 68,
    (byte) 1,
    (byte) 245,
    (byte) 30,
    (byte) 135,
    (byte) 94,
    (byte) 97,
    (byte) 44,
    (byte) 75,
    (byte) 29,
    (byte) 129,
    (byte) 21,
    (byte) 244,
    (byte) 35,
    (byte) 214,
    (byte) 234,
    (byte) 225,
    (byte) 103,
    (byte) 241,
    (byte) 127 /*0x7F*/,
    (byte) 254,
    (byte) 218,
    (byte) 60,
    (byte) 7,
    (byte) 83,
    (byte) 106,
    (byte) 132,
    (byte) 156,
    (byte) 203,
    (byte) 2,
    (byte) 131,
    (byte) 51,
    (byte) 221,
    (byte) 53,
    (byte) 226,
    (byte) 89,
    (byte) 90,
    (byte) 152,
    (byte) 165,
    (byte) 146,
    (byte) 100,
    (byte) 4,
    (byte) 6,
    (byte) 16 /*0x10*/,
    (byte) 77,
    (byte) 28,
    (byte) 151,
    (byte) 8,
    (byte) 49,
    (byte) 238,
    (byte) 171,
    (byte) 5,
    (byte) 175,
    (byte) 121,
    (byte) 160 /*0xA0*/,
    (byte) 24,
    (byte) 70,
    (byte) 109,
    (byte) 252,
    (byte) 137,
    (byte) 212,
    (byte) 199,
    byte.MaxValue,
    (byte) 240 /*0xF0*/,
    (byte) 207,
    (byte) 66,
    (byte) 145,
    (byte) 248,
    (byte) 104,
    (byte) 10,
    (byte) 101,
    (byte) 142,
    (byte) 182,
    (byte) 253,
    (byte) 195,
    (byte) 239,
    (byte) 120,
    (byte) 76,
    (byte) 204,
    (byte) 158,
    (byte) 48 /*0x30*/,
    (byte) 46,
    (byte) 188,
    (byte) 11,
    (byte) 84,
    (byte) 26,
    (byte) 166,
    (byte) 187,
    (byte) 38,
    (byte) 128 /*0x80*/,
    (byte) 72,
    (byte) 148,
    (byte) 50,
    (byte) 125,
    (byte) 167,
    (byte) 63 /*0x3F*/,
    (byte) 174,
    (byte) 34,
    (byte) 61,
    (byte) 102,
    (byte) 170,
    (byte) 246,
    (byte) 0,
    (byte) 93,
    (byte) 189,
    (byte) 74,
    (byte) 224 /*0xE0*/,
    (byte) 59,
    (byte) 180,
    (byte) 23,
    (byte) 139,
    (byte) 159,
    (byte) 118,
    (byte) 176 /*0xB0*/,
    (byte) 36,
    (byte) 154,
    (byte) 37,
    (byte) 99,
    (byte) 219,
    (byte) 235,
    (byte) 122,
    (byte) 62,
    (byte) 92,
    (byte) 179,
    (byte) 177,
    (byte) 41,
    (byte) 242,
    (byte) 202,
    (byte) 88,
    (byte) 110,
    (byte) 216,
    (byte) 168,
    (byte) 47,
    (byte) 117,
    (byte) 223,
    (byte) 20,
    (byte) 251,
    (byte) 19,
    (byte) 73,
    (byte) 136,
    (byte) 178,
    (byte) 236,
    (byte) 228,
    (byte) 52,
    (byte) 45,
    (byte) 150,
    (byte) 198,
    (byte) 58,
    (byte) 237,
    (byte) 149,
    (byte) 14,
    (byte) 229,
    (byte) 133,
    (byte) 107,
    (byte) 64 /*0x40*/,
    (byte) 33,
    (byte) 155,
    (byte) 9,
    (byte) 25,
    (byte) 43,
    (byte) 82,
    (byte) 222,
    (byte) 69,
    (byte) 163,
    (byte) 250,
    (byte) 81,
    (byte) 194,
    (byte) 181,
    (byte) 209,
    (byte) 144 /*0x90*/,
    (byte) 185,
    (byte) 243,
    (byte) 55,
    (byte) 193,
    (byte) 13,
    (byte) 186,
    (byte) 65,
    (byte) 17,
    (byte) 56,
    (byte) 123,
    (byte) 190,
    (byte) 208 /*0xD0*/,
    (byte) 213,
    (byte) 105,
    (byte) 54,
    (byte) 200,
    (byte) 98,
    (byte) 27,
    (byte) 130,
    (byte) 143
  };
  private static readonly byte[] T1 = new byte[256 /*0x0100*/]
  {
    (byte) 131,
    (byte) 242,
    (byte) 42,
    (byte) 235,
    (byte) 233,
    (byte) 191,
    (byte) 123,
    (byte) 156,
    (byte) 52,
    (byte) 150,
    (byte) 141,
    (byte) 152,
    (byte) 185,
    (byte) 105,
    (byte) 140,
    (byte) 41,
    (byte) 61,
    (byte) 136,
    (byte) 104,
    (byte) 6,
    (byte) 57,
    (byte) 17,
    (byte) 76,
    (byte) 14,
    (byte) 160 /*0xA0*/,
    (byte) 86,
    (byte) 64 /*0x40*/,
    (byte) 146,
    (byte) 21,
    (byte) 188,
    (byte) 179,
    (byte) 220,
    (byte) 111,
    (byte) 248,
    (byte) 38,
    (byte) 186,
    (byte) 190,
    (byte) 189,
    (byte) 49,
    (byte) 251,
    (byte) 195,
    (byte) 254,
    (byte) 128 /*0x80*/,
    (byte) 97,
    (byte) 225,
    (byte) 122,
    (byte) 50,
    (byte) 210,
    (byte) 112 /*0x70*/,
    (byte) 32 /*0x20*/,
    (byte) 161,
    (byte) 69,
    (byte) 236,
    (byte) 217,
    (byte) 26,
    (byte) 93,
    (byte) 180,
    (byte) 216,
    (byte) 9,
    (byte) 165,
    (byte) 85,
    (byte) 142,
    (byte) 55,
    (byte) 118,
    (byte) 169,
    (byte) 103,
    (byte) 16 /*0x10*/,
    (byte) 23,
    (byte) 54,
    (byte) 101,
    (byte) 177,
    (byte) 149,
    (byte) 98,
    (byte) 89,
    (byte) 116,
    (byte) 163,
    (byte) 80 /*0x50*/,
    (byte) 47,
    (byte) 75,
    (byte) 200,
    (byte) 208 /*0xD0*/,
    (byte) 143,
    (byte) 205,
    (byte) 212,
    (byte) 60,
    (byte) 134,
    (byte) 18,
    (byte) 29,
    (byte) 35,
    (byte) 239,
    (byte) 244,
    (byte) 83,
    (byte) 25,
    (byte) 53,
    (byte) 230,
    (byte) 127 /*0x7F*/,
    (byte) 94,
    (byte) 214,
    (byte) 121,
    (byte) 81,
    (byte) 34,
    (byte) 20,
    (byte) 247,
    (byte) 30,
    (byte) 74,
    (byte) 66,
    (byte) 155,
    (byte) 65,
    (byte) 115,
    (byte) 45,
    (byte) 193,
    (byte) 92,
    (byte) 166,
    (byte) 162,
    (byte) 224 /*0xE0*/,
    (byte) 46,
    (byte) 211,
    (byte) 40,
    (byte) 187,
    (byte) 201,
    (byte) 174,
    (byte) 106,
    (byte) 209,
    (byte) 90,
    (byte) 48 /*0x30*/,
    (byte) 144 /*0x90*/,
    (byte) 132,
    (byte) 249,
    (byte) 178,
    (byte) 88,
    (byte) 207,
    (byte) 126,
    (byte) 197,
    (byte) 203,
    (byte) 151,
    (byte) 228,
    (byte) 22,
    (byte) 108,
    (byte) 250,
    (byte) 176 /*0xB0*/,
    (byte) 109,
    (byte) 31 /*0x1F*/,
    (byte) 82,
    (byte) 153,
    (byte) 13,
    (byte) 78,
    (byte) 3,
    (byte) 145,
    (byte) 194,
    (byte) 77,
    (byte) 100,
    (byte) 119,
    (byte) 159,
    (byte) 221,
    (byte) 196,
    (byte) 73,
    (byte) 138,
    (byte) 154,
    (byte) 36,
    (byte) 56,
    (byte) 167,
    (byte) 87,
    (byte) 133,
    (byte) 199,
    (byte) 124,
    (byte) 125,
    (byte) 231,
    (byte) 246,
    (byte) 183,
    (byte) 172,
    (byte) 39,
    (byte) 70,
    (byte) 222,
    (byte) 223,
    (byte) 59,
    (byte) 215,
    (byte) 158,
    (byte) 43,
    (byte) 11,
    (byte) 213,
    (byte) 19,
    (byte) 117,
    (byte) 240 /*0xF0*/,
    (byte) 114,
    (byte) 182,
    (byte) 157,
    (byte) 27,
    (byte) 1,
    (byte) 63 /*0x3F*/,
    (byte) 68,
    (byte) 229,
    (byte) 135,
    (byte) 253,
    (byte) 7,
    (byte) 241,
    (byte) 171,
    (byte) 148,
    (byte) 24,
    (byte) 234,
    (byte) 252,
    (byte) 58,
    (byte) 130,
    (byte) 95,
    (byte) 5,
    (byte) 84,
    (byte) 219,
    (byte) 0,
    (byte) 139,
    (byte) 227,
    (byte) 72,
    (byte) 12,
    (byte) 202,
    (byte) 120,
    (byte) 137,
    (byte) 10,
    byte.MaxValue,
    (byte) 62,
    (byte) 91,
    (byte) 129,
    (byte) 238,
    (byte) 113,
    (byte) 226,
    (byte) 218,
    (byte) 44,
    (byte) 184,
    (byte) 181,
    (byte) 204,
    (byte) 110,
    (byte) 168,
    (byte) 107,
    (byte) 173,
    (byte) 96 /*0x60*/,
    (byte) 198,
    (byte) 8,
    (byte) 4,
    (byte) 2,
    (byte) 232,
    (byte) 245,
    (byte) 79,
    (byte) 164,
    (byte) 243,
    (byte) 192 /*0xC0*/,
    (byte) 206,
    (byte) 67,
    (byte) 37,
    (byte) 28,
    (byte) 33,
    (byte) 51,
    (byte) 15,
    (byte) 175,
    (byte) 71,
    (byte) 237,
    (byte) 102,
    (byte) 99,
    (byte) 147,
    (byte) 170
  };
  private static readonly byte[] T2 = new byte[256 /*0x0100*/]
  {
    (byte) 69,
    (byte) 212,
    (byte) 11,
    (byte) 67,
    (byte) 241,
    (byte) 114,
    (byte) 237,
    (byte) 164,
    (byte) 194,
    (byte) 56,
    (byte) 230,
    (byte) 113,
    (byte) 253,
    (byte) 182,
    (byte) 58,
    (byte) 149,
    (byte) 80 /*0x50*/,
    (byte) 68,
    (byte) 75,
    (byte) 226,
    (byte) 116,
    (byte) 107,
    (byte) 30,
    (byte) 17,
    (byte) 90,
    (byte) 198,
    (byte) 180,
    (byte) 216,
    (byte) 165,
    (byte) 138,
    (byte) 112 /*0x70*/,
    (byte) 163,
    (byte) 168,
    (byte) 250,
    (byte) 5,
    (byte) 217,
    (byte) 151,
    (byte) 64 /*0x40*/,
    (byte) 201,
    (byte) 144 /*0x90*/,
    (byte) 152,
    (byte) 143,
    (byte) 220,
    (byte) 18,
    (byte) 49,
    (byte) 44,
    (byte) 71,
    (byte) 106,
    (byte) 153,
    (byte) 174,
    (byte) 200,
    (byte) 127 /*0x7F*/,
    (byte) 249,
    (byte) 79,
    (byte) 93,
    (byte) 150,
    (byte) 111,
    (byte) 244,
    (byte) 179,
    (byte) 57,
    (byte) 33,
    (byte) 218,
    (byte) 156,
    (byte) 133,
    (byte) 158,
    (byte) 59,
    (byte) 240 /*0xF0*/,
    (byte) 191,
    (byte) 239,
    (byte) 6,
    (byte) 238,
    (byte) 229,
    (byte) 95,
    (byte) 32 /*0x20*/,
    (byte) 16 /*0x10*/,
    (byte) 204,
    (byte) 60,
    (byte) 84,
    (byte) 74,
    (byte) 82,
    (byte) 148,
    (byte) 14,
    (byte) 192 /*0xC0*/,
    (byte) 40,
    (byte) 246,
    (byte) 86,
    (byte) 96 /*0x60*/,
    (byte) 162,
    (byte) 227,
    (byte) 15,
    (byte) 236,
    (byte) 157,
    (byte) 36,
    (byte) 131,
    (byte) 126,
    (byte) 213,
    (byte) 124,
    (byte) 235,
    (byte) 24,
    (byte) 215,
    (byte) 205,
    (byte) 221,
    (byte) 120,
    byte.MaxValue,
    (byte) 219,
    (byte) 161,
    (byte) 9,
    (byte) 208 /*0xD0*/,
    (byte) 118,
    (byte) 132,
    (byte) 117,
    (byte) 187,
    (byte) 29,
    (byte) 26,
    (byte) 47,
    (byte) 176 /*0xB0*/,
    (byte) 254,
    (byte) 214,
    (byte) 52,
    (byte) 99,
    (byte) 53,
    (byte) 210,
    (byte) 42,
    (byte) 89,
    (byte) 109,
    (byte) 77,
    (byte) 119,
    (byte) 231,
    (byte) 142,
    (byte) 97,
    (byte) 207,
    (byte) 159,
    (byte) 206,
    (byte) 39,
    (byte) 245,
    (byte) 128 /*0x80*/,
    (byte) 134,
    (byte) 199,
    (byte) 166,
    (byte) 251,
    (byte) 248,
    (byte) 135,
    (byte) 171,
    (byte) 98,
    (byte) 63 /*0x3F*/,
    (byte) 223,
    (byte) 72,
    (byte) 0,
    (byte) 20,
    (byte) 154,
    (byte) 189,
    (byte) 91,
    (byte) 4,
    (byte) 146,
    (byte) 2,
    (byte) 37,
    (byte) 101,
    (byte) 76,
    (byte) 83,
    (byte) 12,
    (byte) 242,
    (byte) 41,
    (byte) 175,
    (byte) 23,
    (byte) 108,
    (byte) 65,
    (byte) 48 /*0x30*/,
    (byte) 233,
    (byte) 147,
    (byte) 85,
    (byte) 247,
    (byte) 172,
    (byte) 104,
    (byte) 38,
    (byte) 196,
    (byte) 125,
    (byte) 202,
    (byte) 122,
    (byte) 62,
    (byte) 160 /*0xA0*/,
    (byte) 55,
    (byte) 3,
    (byte) 193,
    (byte) 54,
    (byte) 105,
    (byte) 102,
    (byte) 8,
    (byte) 22,
    (byte) 167,
    (byte) 188,
    (byte) 197,
    (byte) 211,
    (byte) 34,
    (byte) 183,
    (byte) 19,
    (byte) 70,
    (byte) 50,
    (byte) 232,
    (byte) 87,
    (byte) 136,
    (byte) 43,
    (byte) 129,
    (byte) 178,
    (byte) 78,
    (byte) 100,
    (byte) 28,
    (byte) 170,
    (byte) 145,
    (byte) 88,
    (byte) 46,
    (byte) 155,
    (byte) 92,
    (byte) 27,
    (byte) 81,
    (byte) 115,
    (byte) 66,
    (byte) 35,
    (byte) 1,
    (byte) 110,
    (byte) 243,
    (byte) 13,
    (byte) 190,
    (byte) 61,
    (byte) 10,
    (byte) 45,
    (byte) 31 /*0x1F*/,
    (byte) 103,
    (byte) 51,
    (byte) 25,
    (byte) 123,
    (byte) 94,
    (byte) 234,
    (byte) 222,
    (byte) 139,
    (byte) 203,
    (byte) 169,
    (byte) 140,
    (byte) 141,
    (byte) 173,
    (byte) 73,
    (byte) 130,
    (byte) 228,
    (byte) 186,
    (byte) 195,
    (byte) 21,
    (byte) 209,
    (byte) 224 /*0xE0*/,
    (byte) 137,
    (byte) 252,
    (byte) 177,
    (byte) 185,
    (byte) 181,
    (byte) 7,
    (byte) 121,
    (byte) 184,
    (byte) 225
  };
  private static readonly byte[] T3 = new byte[256 /*0x0100*/]
  {
    (byte) 178,
    (byte) 182,
    (byte) 35,
    (byte) 17,
    (byte) 167,
    (byte) 136,
    (byte) 197,
    (byte) 166,
    (byte) 57,
    (byte) 143,
    (byte) 196,
    (byte) 232,
    (byte) 115,
    (byte) 34,
    (byte) 67,
    (byte) 195,
    (byte) 130,
    (byte) 39,
    (byte) 205,
    (byte) 24,
    (byte) 81,
    (byte) 98,
    (byte) 45,
    (byte) 247,
    (byte) 92,
    (byte) 14,
    (byte) 59,
    (byte) 253,
    (byte) 202,
    (byte) 155,
    (byte) 13,
    (byte) 15,
    (byte) 121,
    (byte) 140,
    (byte) 16 /*0x10*/,
    (byte) 76,
    (byte) 116,
    (byte) 28,
    (byte) 10,
    (byte) 142,
    (byte) 124,
    (byte) 148,
    (byte) 7,
    (byte) 199,
    (byte) 94,
    (byte) 20,
    (byte) 161,
    (byte) 33,
    (byte) 87,
    (byte) 80 /*0x50*/,
    (byte) 78,
    (byte) 169,
    (byte) 128 /*0x80*/,
    (byte) 217,
    (byte) 239,
    (byte) 100,
    (byte) 65,
    (byte) 207,
    (byte) 60,
    (byte) 238,
    (byte) 46,
    (byte) 19,
    (byte) 41,
    (byte) 186,
    (byte) 52,
    (byte) 90,
    (byte) 174,
    (byte) 138,
    (byte) 97,
    (byte) 51,
    (byte) 18,
    (byte) 185,
    (byte) 85,
    (byte) 168,
    (byte) 21,
    (byte) 5,
    (byte) 246,
    (byte) 3,
    (byte) 6,
    (byte) 73,
    (byte) 181,
    (byte) 37,
    (byte) 9,
    (byte) 22,
    (byte) 12,
    (byte) 42,
    (byte) 56,
    (byte) 252,
    (byte) 32 /*0x20*/,
    (byte) 244,
    (byte) 229,
    (byte) 127 /*0x7F*/,
    (byte) 215,
    (byte) 49,
    (byte) 43,
    (byte) 102,
    (byte) 111,
    byte.MaxValue,
    (byte) 114,
    (byte) 134,
    (byte) 240 /*0xF0*/,
    (byte) 163,
    (byte) 47,
    (byte) 120,
    (byte) 0,
    (byte) 188,
    (byte) 204,
    (byte) 226,
    (byte) 176 /*0xB0*/,
    (byte) 241,
    (byte) 66,
    (byte) 180,
    (byte) 48 /*0x30*/,
    (byte) 95,
    (byte) 96 /*0x60*/,
    (byte) 4,
    (byte) 236,
    (byte) 165,
    (byte) 227,
    (byte) 139,
    (byte) 231,
    (byte) 29,
    (byte) 191,
    (byte) 132,
    (byte) 123,
    (byte) 230,
    (byte) 129,
    (byte) 248,
    (byte) 222,
    (byte) 216,
    (byte) 210,
    (byte) 23,
    (byte) 206,
    (byte) 75,
    (byte) 71,
    (byte) 214,
    (byte) 105,
    (byte) 108,
    (byte) 25,
    (byte) 153,
    (byte) 154,
    (byte) 1,
    (byte) 179,
    (byte) 133,
    (byte) 177,
    (byte) 249,
    (byte) 89,
    (byte) 194,
    (byte) 55,
    (byte) 233,
    (byte) 200,
    (byte) 160 /*0xA0*/,
    (byte) 237,
    (byte) 79,
    (byte) 137,
    (byte) 104,
    (byte) 109,
    (byte) 213,
    (byte) 38,
    (byte) 145,
    (byte) 135,
    (byte) 88,
    (byte) 189,
    (byte) 201,
    (byte) 152,
    (byte) 220,
    (byte) 117,
    (byte) 192 /*0xC0*/,
    (byte) 118,
    (byte) 245,
    (byte) 103,
    (byte) 107,
    (byte) 126,
    (byte) 235,
    (byte) 82,
    (byte) 203,
    (byte) 209,
    (byte) 91,
    (byte) 159,
    (byte) 11,
    (byte) 219,
    (byte) 64 /*0x40*/,
    (byte) 146,
    (byte) 26,
    (byte) 250,
    (byte) 172,
    (byte) 228,
    (byte) 225,
    (byte) 113,
    (byte) 31 /*0x1F*/,
    (byte) 101,
    (byte) 141,
    (byte) 151,
    (byte) 158,
    (byte) 149,
    (byte) 144 /*0x90*/,
    (byte) 93,
    (byte) 183,
    (byte) 193,
    (byte) 175,
    (byte) 84,
    (byte) 251,
    (byte) 2,
    (byte) 224 /*0xE0*/,
    (byte) 53,
    (byte) 187,
    (byte) 58,
    (byte) 77,
    (byte) 173,
    (byte) 44,
    (byte) 61,
    (byte) 86,
    (byte) 8,
    (byte) 27,
    (byte) 74,
    (byte) 147,
    (byte) 106,
    (byte) 171,
    (byte) 184,
    (byte) 122,
    (byte) 242,
    (byte) 125,
    (byte) 218,
    (byte) 63 /*0x3F*/,
    (byte) 254,
    (byte) 62,
    (byte) 190,
    (byte) 234,
    (byte) 170,
    (byte) 68,
    (byte) 198,
    (byte) 208 /*0xD0*/,
    (byte) 54,
    (byte) 72,
    (byte) 112 /*0x70*/,
    (byte) 150,
    (byte) 119,
    (byte) 36,
    (byte) 83,
    (byte) 223,
    (byte) 243,
    (byte) 131,
    (byte) 40,
    (byte) 50,
    (byte) 69,
    (byte) 30,
    (byte) 164,
    (byte) 211,
    (byte) 162,
    (byte) 70,
    (byte) 110,
    (byte) 156,
    (byte) 221,
    (byte) 99,
    (byte) 212,
    (byte) 157
  };

  public Dstu7624Engine(int blockSizeBits)
  {
    if (blockSizeBits != 128 /*0x80*/ && blockSizeBits != 256 /*0x0100*/ && blockSizeBits != 512 /*0x0200*/)
      throw new ArgumentException("unsupported block length: only 128/256/512 are allowed");
    this.wordsInBlock = blockSizeBits / 64 /*0x40*/;
    this.internalState = new ulong[this.wordsInBlock];
  }

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter))
      throw new ArgumentException("Invalid parameter passed to Dstu7624Engine Init");
    this.forEncryption = forEncryption;
    byte[] key = ((KeyParameter) parameters).GetKey();
    int num1 = key.Length << 3;
    int num2 = this.wordsInBlock << 6;
    if (num1 != 128 /*0x80*/ && num1 != 256 /*0x0100*/ && num1 != 512 /*0x0200*/)
      throw new ArgumentException("unsupported key length: only 128/256/512 are allowed");
    if (num1 != num2 && num1 != 2 * num2)
      throw new ArgumentException("Unsupported key length");
    switch (num1)
    {
      case 128 /*0x80*/:
        this.roundsAmount = 10;
        break;
      case 256 /*0x0100*/:
        this.roundsAmount = 14;
        break;
      case 512 /*0x0200*/:
        this.roundsAmount = 18;
        break;
    }
    this.wordsInKey = num1 / 64 /*0x40*/;
    this.roundKeys = new ulong[this.roundsAmount + 1][];
    for (int index = 0; index < this.roundKeys.Length; ++index)
      this.roundKeys[index] = new ulong[this.wordsInBlock];
    this.workingKey = new ulong[this.wordsInKey];
    if (key.Length != this.wordsInKey * 8)
      throw new ArgumentException("Invalid key parameter passed to Dstu7624Engine Init");
    Pack.LE_To_UInt64(key, 0, this.workingKey);
    ulong[] numArray = new ulong[this.wordsInBlock];
    this.WorkingKeyExpandKT(this.workingKey, numArray);
    this.WorkingKeyExpandEven(this.workingKey, numArray);
    this.WorkingKeyExpandOdd();
  }

  private void WorkingKeyExpandKT(ulong[] workingKey, ulong[] tempKeys)
  {
    ulong[] destinationArray1 = new ulong[this.wordsInBlock];
    ulong[] destinationArray2 = new ulong[this.wordsInBlock];
    this.internalState = new ulong[this.wordsInBlock];
    this.internalState[0] += (ulong) (this.wordsInBlock + this.wordsInKey + 1);
    if (this.wordsInBlock == this.wordsInKey)
    {
      Array.Copy((Array) workingKey, 0, (Array) destinationArray1, 0, destinationArray1.Length);
      Array.Copy((Array) workingKey, 0, (Array) destinationArray2, 0, destinationArray2.Length);
    }
    else
    {
      Array.Copy((Array) workingKey, 0, (Array) destinationArray1, 0, this.wordsInBlock);
      Array.Copy((Array) workingKey, this.wordsInBlock, (Array) destinationArray2, 0, this.wordsInBlock);
    }
    for (int index = 0; index < this.internalState.Length; ++index)
      this.internalState[index] += destinationArray1[index];
    this.EncryptionRound();
    for (int index = 0; index < this.internalState.Length; ++index)
      this.internalState[index] ^= destinationArray2[index];
    this.EncryptionRound();
    for (int index = 0; index < this.internalState.Length; ++index)
      this.internalState[index] += destinationArray1[index];
    this.EncryptionRound();
    Array.Copy((Array) this.internalState, 0, (Array) tempKeys, 0, this.wordsInBlock);
  }

  private void WorkingKeyExpandEven(ulong[] workingKey, ulong[] tempKey)
  {
    ulong[] destinationArray = new ulong[this.wordsInKey];
    ulong[] numArray = new ulong[this.wordsInBlock];
    int index1 = 0;
    Array.Copy((Array) workingKey, 0, (Array) destinationArray, 0, this.wordsInKey);
    ulong num1 = 281479271743489 /*0x01000100010001*/;
    while (true)
    {
      for (int index2 = 0; index2 < this.wordsInBlock; ++index2)
        numArray[index2] = tempKey[index2] + num1;
      for (int index3 = 0; index3 < this.wordsInBlock; ++index3)
        this.internalState[index3] = destinationArray[index3] + numArray[index3];
      this.EncryptionRound();
      for (int index4 = 0; index4 < this.wordsInBlock; ++index4)
        this.internalState[index4] ^= numArray[index4];
      this.EncryptionRound();
      for (int index5 = 0; index5 < this.wordsInBlock; ++index5)
        this.internalState[index5] += numArray[index5];
      Array.Copy((Array) this.internalState, 0, (Array) this.roundKeys[index1], 0, this.wordsInBlock);
      if (this.roundsAmount != index1)
      {
        if (this.wordsInKey != this.wordsInBlock)
        {
          index1 += 2;
          num1 <<= 1;
          for (int index6 = 0; index6 < this.wordsInBlock; ++index6)
            numArray[index6] = tempKey[index6] + num1;
          for (int index7 = 0; index7 < this.wordsInBlock; ++index7)
            this.internalState[index7] = destinationArray[this.wordsInBlock + index7] + numArray[index7];
          this.EncryptionRound();
          for (int index8 = 0; index8 < this.wordsInBlock; ++index8)
            this.internalState[index8] ^= numArray[index8];
          this.EncryptionRound();
          for (int index9 = 0; index9 < this.wordsInBlock; ++index9)
            this.internalState[index9] += numArray[index9];
          Array.Copy((Array) this.internalState, 0, (Array) this.roundKeys[index1], 0, this.wordsInBlock);
          if (this.roundsAmount == index1)
            goto label_33;
        }
        index1 += 2;
        num1 <<= 1;
        ulong num2 = destinationArray[0];
        for (int index10 = 1; index10 < destinationArray.Length; ++index10)
          destinationArray[index10 - 1] = destinationArray[index10];
        destinationArray[destinationArray.Length - 1] = num2;
      }
      else
        break;
    }
    return;
label_33:;
  }

  private void WorkingKeyExpandOdd()
  {
    for (int index = 1; index < this.roundsAmount; index += 2)
      this.RotateLeft(this.roundKeys[index - 1], this.roundKeys[index]);
  }

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.workingKey == null)
      throw new InvalidOperationException("Dstu7624Engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.GetBlockSize(), "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.GetBlockSize(), "output buffer too short");
    if (this.forEncryption)
    {
      if (this.wordsInBlock == 2)
      {
        this.EncryptBlock_128(input, inOff, output, outOff);
      }
      else
      {
        Pack.LE_To_UInt64(input, inOff, this.internalState);
        this.AddRoundKey(0);
        int round = 0;
        while (true)
        {
          this.EncryptionRound();
          if (++round != this.roundsAmount)
            this.XorRoundKey(round);
          else
            break;
        }
        this.AddRoundKey(this.roundsAmount);
        Pack.UInt64_To_LE(this.internalState, output, outOff);
        Array.Clear((Array) this.internalState, 0, this.internalState.Length);
      }
    }
    else if (this.wordsInBlock == 2)
    {
      this.DecryptBlock_128(input, inOff, output, outOff);
    }
    else
    {
      Pack.LE_To_UInt64(input, inOff, this.internalState);
      this.SubRoundKey(this.roundsAmount);
      int roundsAmount = this.roundsAmount;
      while (true)
      {
        this.DecryptionRound();
        if (--roundsAmount != 0)
          this.XorRoundKey(roundsAmount);
        else
          break;
      }
      this.SubRoundKey(0);
      Pack.UInt64_To_LE(this.internalState, output, outOff);
      Array.Clear((Array) this.internalState, 0, this.internalState.Length);
    }
    return this.GetBlockSize();
  }

  private void EncryptionRound()
  {
    this.SubBytes();
    this.ShiftRows();
    this.MixColumns();
  }

  private void DecryptionRound()
  {
    this.MixColumnsInv();
    this.InvShiftRows();
    this.InvSubBytes();
  }

  private void DecryptBlock_128(byte[] input, int inOff, byte[] output, int outOff)
  {
    ulong uint64_1 = Pack.LE_To_UInt64(input, inOff);
    ulong uint64_2 = Pack.LE_To_UInt64(input, inOff + 8);
    ulong[] roundKey1 = this.roundKeys[this.roundsAmount];
    ulong c1 = uint64_1 - roundKey1[0];
    ulong c2 = uint64_2 - roundKey1[1];
    int roundsAmount = this.roundsAmount;
    ulong num1;
    ulong num2;
    while (true)
    {
      ulong num3 = Dstu7624Engine.MixColumnInv(c1);
      ulong num4 = Dstu7624Engine.MixColumnInv(c2);
      uint num5 = (uint) num3;
      uint num6 = (uint) (num3 >> 32 /*0x20*/);
      uint num7 = (uint) num4;
      uint num8 = (uint) (num4 >> 32 /*0x20*/);
      int num9 = (int) Dstu7624Engine.T0[(int) num5 & (int) byte.MaxValue];
      byte num10 = Dstu7624Engine.T1[(int) (num5 >> 8) & (int) byte.MaxValue];
      byte num11 = Dstu7624Engine.T2[(int) (num5 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num12 = Dstu7624Engine.T3[(int) (num5 >> 24)];
      int num13 = (int) num10 << 8;
      uint num14 = (uint) (num9 | num13 | (int) num11 << 16 /*0x10*/ | (int) num12 << 24);
      int num15 = (int) Dstu7624Engine.T0[(int) num8 & (int) byte.MaxValue];
      byte num16 = Dstu7624Engine.T1[(int) (num8 >> 8) & (int) byte.MaxValue];
      byte num17 = Dstu7624Engine.T2[(int) (num8 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num18 = Dstu7624Engine.T3[(int) (num8 >> 24)];
      int num19 = (int) num16 << 8;
      uint num20 = (uint) (num15 | num19 | (int) num17 << 16 /*0x10*/ | (int) num18 << 24);
      num1 = (ulong) num14 | (ulong) num20 << 32 /*0x20*/;
      int num21 = (int) Dstu7624Engine.T0[(int) num7 & (int) byte.MaxValue];
      byte num22 = Dstu7624Engine.T1[(int) (num7 >> 8) & (int) byte.MaxValue];
      byte num23 = Dstu7624Engine.T2[(int) (num7 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num24 = Dstu7624Engine.T3[(int) (num7 >> 24)];
      int num25 = (int) num22 << 8;
      uint num26 = (uint) (num21 | num25 | (int) num23 << 16 /*0x10*/ | (int) num24 << 24);
      int num27 = (int) Dstu7624Engine.T0[(int) num6 & (int) byte.MaxValue];
      byte num28 = Dstu7624Engine.T1[(int) (num6 >> 8) & (int) byte.MaxValue];
      byte num29 = Dstu7624Engine.T2[(int) (num6 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num30 = Dstu7624Engine.T3[(int) (num6 >> 24)];
      int num31 = (int) num28 << 8;
      uint num32 = (uint) (num27 | num31 | (int) num29 << 16 /*0x10*/ | (int) num30 << 24);
      num2 = (ulong) num26 | (ulong) num32 << 32 /*0x20*/;
      if (--roundsAmount != 0)
      {
        ulong[] roundKey2 = this.roundKeys[roundsAmount];
        c1 = num1 ^ roundKey2[0];
        c2 = num2 ^ roundKey2[1];
      }
      else
        break;
    }
    ulong[] roundKey3 = this.roundKeys[0];
    ulong n1 = num1 - roundKey3[0];
    ulong n2 = num2 - roundKey3[1];
    Pack.UInt64_To_LE(n1, output, outOff);
    Pack.UInt64_To_LE(n2, output, outOff + 8);
  }

  private void EncryptBlock_128(byte[] input, int inOff, byte[] output, int outOff)
  {
    ulong uint64_1 = Pack.LE_To_UInt64(input, inOff);
    ulong uint64_2 = Pack.LE_To_UInt64(input, inOff + 8);
    ulong[] roundKey1 = this.roundKeys[0];
    ulong num1 = uint64_1 + roundKey1[0];
    ulong num2 = uint64_2 + roundKey1[1];
    int index = 0;
    ulong num3;
    ulong num4;
    while (true)
    {
      uint num5 = (uint) num1;
      uint num6 = (uint) (num1 >> 32 /*0x20*/);
      uint num7 = (uint) num2;
      uint num8 = (uint) (num2 >> 32 /*0x20*/);
      int num9 = (int) Dstu7624Engine.S0[(int) num5 & (int) byte.MaxValue];
      byte num10 = Dstu7624Engine.S1[(int) (num5 >> 8) & (int) byte.MaxValue];
      byte num11 = Dstu7624Engine.S2[(int) (num5 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num12 = Dstu7624Engine.S3[(int) (num5 >> 24)];
      int num13 = (int) num10 << 8;
      uint num14 = (uint) (num9 | num13 | (int) num11 << 16 /*0x10*/ | (int) num12 << 24);
      int num15 = (int) Dstu7624Engine.S0[(int) num8 & (int) byte.MaxValue];
      byte num16 = Dstu7624Engine.S1[(int) (num8 >> 8) & (int) byte.MaxValue];
      byte num17 = Dstu7624Engine.S2[(int) (num8 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num18 = Dstu7624Engine.S3[(int) (num8 >> 24)];
      int num19 = (int) num16 << 8;
      uint num20 = (uint) (num15 | num19 | (int) num17 << 16 /*0x10*/ | (int) num18 << 24);
      ulong c1 = (ulong) num14 | (ulong) num20 << 32 /*0x20*/;
      int num21 = (int) Dstu7624Engine.S0[(int) num7 & (int) byte.MaxValue];
      byte num22 = Dstu7624Engine.S1[(int) (num7 >> 8) & (int) byte.MaxValue];
      byte num23 = Dstu7624Engine.S2[(int) (num7 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num24 = Dstu7624Engine.S3[(int) (num7 >> 24)];
      int num25 = (int) num22 << 8;
      uint num26 = (uint) (num21 | num25 | (int) num23 << 16 /*0x10*/ | (int) num24 << 24);
      int num27 = (int) Dstu7624Engine.S0[(int) num6 & (int) byte.MaxValue];
      byte num28 = Dstu7624Engine.S1[(int) (num6 >> 8) & (int) byte.MaxValue];
      byte num29 = Dstu7624Engine.S2[(int) (num6 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num30 = Dstu7624Engine.S3[(int) (num6 >> 24)];
      int num31 = (int) num28 << 8;
      uint num32 = (uint) (num27 | num31 | (int) num29 << 16 /*0x10*/ | (int) num30 << 24);
      ulong c2 = (ulong) num26 | (ulong) num32 << 32 /*0x20*/;
      num3 = Dstu7624Engine.MixColumn(c1);
      num4 = Dstu7624Engine.MixColumn(c2);
      if (++index != this.roundsAmount)
      {
        ulong[] roundKey2 = this.roundKeys[index];
        num1 = num3 ^ roundKey2[0];
        num2 = num4 ^ roundKey2[1];
      }
      else
        break;
    }
    ulong[] roundKey3 = this.roundKeys[this.roundsAmount];
    ulong n1 = num3 + roundKey3[0];
    ulong n2 = num4 + roundKey3[1];
    Pack.UInt64_To_LE(n1, output, outOff);
    Pack.UInt64_To_LE(n2, output, outOff + 8);
  }

  private void SubBytes()
  {
    for (int index = 0; index < this.wordsInBlock; ++index)
    {
      uint num1;
      uint num2 = (uint) ((ulong) (num1 = (uint) this.internalState[index]) >> 32 /*0x20*/);
      int num3 = (int) Dstu7624Engine.S0[(int) num1 & (int) byte.MaxValue];
      byte num4 = Dstu7624Engine.S1[(int) (num1 >> 8) & (int) byte.MaxValue];
      byte num5 = Dstu7624Engine.S2[(int) (num1 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num6 = Dstu7624Engine.S3[(int) (num1 >> 24)];
      int num7 = (int) num4 << 8;
      uint num8 = (uint) (num3 | num7 | (int) num5 << 16 /*0x10*/ | (int) num6 << 24);
      int num9 = (int) Dstu7624Engine.S0[(int) num2 & (int) byte.MaxValue];
      byte num10 = Dstu7624Engine.S1[(int) (num2 >> 8) & (int) byte.MaxValue];
      byte num11 = Dstu7624Engine.S2[(int) (num2 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num12 = Dstu7624Engine.S3[(int) (num2 >> 24)];
      int num13 = (int) num10 << 8;
      uint num14 = (uint) (num9 | num13 | (int) num11 << 16 /*0x10*/ | (int) num12 << 24);
      this.internalState[index] = (ulong) num8 | (ulong) num14 << 32 /*0x20*/;
    }
  }

  private void InvSubBytes()
  {
    for (int index = 0; index < this.wordsInBlock; ++index)
    {
      uint num1;
      uint num2 = (uint) ((ulong) (num1 = (uint) this.internalState[index]) >> 32 /*0x20*/);
      int num3 = (int) Dstu7624Engine.T0[(int) num1 & (int) byte.MaxValue];
      byte num4 = Dstu7624Engine.T1[(int) (num1 >> 8) & (int) byte.MaxValue];
      byte num5 = Dstu7624Engine.T2[(int) (num1 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num6 = Dstu7624Engine.T3[(int) (num1 >> 24)];
      int num7 = (int) num4 << 8;
      uint num8 = (uint) (num3 | num7 | (int) num5 << 16 /*0x10*/ | (int) num6 << 24);
      int num9 = (int) Dstu7624Engine.T0[(int) num2 & (int) byte.MaxValue];
      byte num10 = Dstu7624Engine.T1[(int) (num2 >> 8) & (int) byte.MaxValue];
      byte num11 = Dstu7624Engine.T2[(int) (num2 >> 16 /*0x10*/) & (int) byte.MaxValue];
      byte num12 = Dstu7624Engine.T3[(int) (num2 >> 24)];
      int num13 = (int) num10 << 8;
      uint num14 = (uint) (num9 | num13 | (int) num11 << 16 /*0x10*/ | (int) num12 << 24);
      this.internalState[index] = (ulong) num8 | (ulong) num14 << 32 /*0x20*/;
    }
  }

  private void ShiftRows()
  {
    switch (this.wordsInBlock)
    {
      case 2:
        ulong num1 = this.internalState[0];
        ulong num2 = this.internalState[1];
        ulong num3 = (ulong) (((long) num1 ^ (long) num2) & -4294967296L);
        ulong num4 = num1 ^ num3;
        ulong num5 = num2 ^ num3;
        this.internalState[0] = num4;
        this.internalState[1] = num5;
        break;
      case 4:
        ulong num6 = this.internalState[0];
        ulong num7 = this.internalState[1];
        ulong num8 = this.internalState[2];
        ulong num9 = this.internalState[3];
        ulong num10 = (ulong) (((long) num6 ^ (long) num8) & -4294967296L);
        ulong num11 = num6 ^ num10;
        ulong num12 = num8 ^ num10;
        ulong num13 = (ulong) (((long) num7 ^ (long) num9) & 281474976645120L);
        ulong num14 = num7 ^ num13;
        ulong num15 = num9 ^ num13;
        ulong num16 = (ulong) (((long) num11 ^ (long) num14) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num17 = num11 ^ num16;
        ulong num18 = num14 ^ num16;
        ulong num19 = (ulong) (((long) num12 ^ (long) num15) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num20 = num12 ^ num19;
        ulong num21 = num15 ^ num19;
        this.internalState[0] = num17;
        this.internalState[1] = num18;
        this.internalState[2] = num20;
        this.internalState[3] = num21;
        break;
      case 8:
        ulong num22 = this.internalState[0];
        ulong num23 = this.internalState[1];
        ulong num24 = this.internalState[2];
        ulong num25 = this.internalState[3];
        ulong num26 = this.internalState[4];
        ulong num27 = this.internalState[5];
        ulong num28 = this.internalState[6];
        ulong num29 = this.internalState[7];
        ulong num30 = (ulong) (((long) num22 ^ (long) num26) & -4294967296L);
        ulong num31 = num22 ^ num30;
        ulong num32 = num26 ^ num30;
        ulong num33 = (ulong) (((long) num23 ^ (long) num27) & 72057594021150720L);
        ulong num34 = num23 ^ num33;
        ulong num35 = num27 ^ num33;
        ulong num36 = (ulong) (((long) num24 ^ (long) num28) & 281474976645120L);
        ulong num37 = num24 ^ num36;
        ulong num38 = num28 ^ num36;
        ulong num39 = (ulong) (((long) num25 ^ (long) num29) & 1099511627520L);
        ulong num40 = num25 ^ num39;
        ulong num41 = num29 ^ num39;
        ulong num42 = (ulong) (((long) num31 ^ (long) num37) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num43 = num31 ^ num42;
        ulong num44 = num37 ^ num42;
        ulong num45 = (ulong) (((long) num34 ^ (long) num40) & 72056494543077120L);
        ulong num46 = num34 ^ num45;
        ulong num47 = num40 ^ num45;
        ulong num48 = (ulong) (((long) num32 ^ (long) num38) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num49 = num32 ^ num48;
        ulong num50 = num38 ^ num48;
        ulong num51 = (ulong) (((long) num35 ^ (long) num41) & 72056494543077120L);
        ulong num52 = num35 ^ num51;
        ulong num53 = num41 ^ num51;
        ulong num54 = (ulong) (((long) num43 ^ (long) num46) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num55 = num43 ^ num54;
        ulong num56 = num46 ^ num54;
        ulong num57 = (ulong) (((long) num44 ^ (long) num47) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num58 = num44 ^ num57;
        ulong num59 = num47 ^ num57;
        ulong num60 = (ulong) (((long) num49 ^ (long) num52) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num61 = num49 ^ num60;
        ulong num62 = num52 ^ num60;
        ulong num63 = (ulong) (((long) num50 ^ (long) num53) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num64 = num50 ^ num63;
        ulong num65 = num53 ^ num63;
        this.internalState[0] = num55;
        this.internalState[1] = num56;
        this.internalState[2] = num58;
        this.internalState[3] = num59;
        this.internalState[4] = num61;
        this.internalState[5] = num62;
        this.internalState[6] = num64;
        this.internalState[7] = num65;
        break;
      default:
        throw new InvalidOperationException("unsupported block length: only 128/256/512 are allowed");
    }
  }

  private void InvShiftRows()
  {
    switch (this.wordsInBlock)
    {
      case 2:
        ulong num1 = this.internalState[0];
        ulong num2 = this.internalState[1];
        ulong num3 = (ulong) (((long) num1 ^ (long) num2) & -4294967296L);
        ulong num4 = num1 ^ num3;
        ulong num5 = num2 ^ num3;
        this.internalState[0] = num4;
        this.internalState[1] = num5;
        break;
      case 4:
        ulong num6 = this.internalState[0];
        ulong num7 = this.internalState[1];
        ulong num8 = this.internalState[2];
        ulong num9 = this.internalState[3];
        ulong num10 = (ulong) (((long) num6 ^ (long) num7) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num11 = num6 ^ num10;
        ulong num12 = num7 ^ num10;
        ulong num13 = (ulong) (((long) num8 ^ (long) num9) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num14 = num8 ^ num13;
        ulong num15 = num9 ^ num13;
        ulong num16 = (ulong) (((long) num11 ^ (long) num14) & -4294967296L);
        ulong num17 = num11 ^ num16;
        ulong num18 = num14 ^ num16;
        ulong num19 = (ulong) (((long) num12 ^ (long) num15) & 281474976645120L);
        ulong num20 = num12 ^ num19;
        ulong num21 = num15 ^ num19;
        this.internalState[0] = num17;
        this.internalState[1] = num20;
        this.internalState[2] = num18;
        this.internalState[3] = num21;
        break;
      case 8:
        ulong num22 = this.internalState[0];
        ulong num23 = this.internalState[1];
        ulong num24 = this.internalState[2];
        ulong num25 = this.internalState[3];
        ulong num26 = this.internalState[4];
        ulong num27 = this.internalState[5];
        ulong num28 = this.internalState[6];
        ulong num29 = this.internalState[7];
        ulong num30 = (ulong) (((long) num22 ^ (long) num23) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num31 = num22 ^ num30;
        ulong num32 = num23 ^ num30;
        ulong num33 = (ulong) (((long) num24 ^ (long) num25) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num34 = num24 ^ num33;
        ulong num35 = num25 ^ num33;
        ulong num36 = (ulong) (((long) num26 ^ (long) num27) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num37 = num26 ^ num36;
        ulong num38 = num27 ^ num36;
        ulong num39 = (ulong) (((long) num28 ^ (long) num29) & -71777214294589696L /*0xFF00FF00FF00FF00*/);
        ulong num40 = num28 ^ num39;
        ulong num41 = num29 ^ num39;
        ulong num42 = (ulong) (((long) num31 ^ (long) num34) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num43 = num31 ^ num42;
        ulong num44 = num34 ^ num42;
        ulong num45 = (ulong) (((long) num32 ^ (long) num35) & 72056494543077120L);
        ulong num46 = num32 ^ num45;
        ulong num47 = num35 ^ num45;
        ulong num48 = (ulong) (((long) num37 ^ (long) num40) & -281470681808896L /*0xFFFF0000FFFF0000*/);
        ulong num49 = num37 ^ num48;
        ulong num50 = num40 ^ num48;
        ulong num51 = (ulong) (((long) num38 ^ (long) num41) & 72056494543077120L);
        ulong num52 = num38 ^ num51;
        ulong num53 = num41 ^ num51;
        ulong num54 = (ulong) (((long) num43 ^ (long) num49) & -4294967296L);
        ulong num55 = num43 ^ num54;
        ulong num56 = num49 ^ num54;
        ulong num57 = (ulong) (((long) num46 ^ (long) num52) & 72057594021150720L);
        ulong num58 = num46 ^ num57;
        ulong num59 = num52 ^ num57;
        ulong num60 = (ulong) (((long) num44 ^ (long) num50) & 281474976645120L);
        ulong num61 = num44 ^ num60;
        ulong num62 = num50 ^ num60;
        ulong num63 = (ulong) (((long) num47 ^ (long) num53) & 1099511627520L);
        ulong num64 = num47 ^ num63;
        ulong num65 = num53 ^ num63;
        this.internalState[0] = num55;
        this.internalState[1] = num58;
        this.internalState[2] = num61;
        this.internalState[3] = num64;
        this.internalState[4] = num56;
        this.internalState[5] = num59;
        this.internalState[6] = num62;
        this.internalState[7] = num65;
        break;
      default:
        throw new InvalidOperationException("unsupported block length: only 128/256/512 are allowed");
    }
  }

  private void AddRoundKey(int round)
  {
    ulong[] roundKey = this.roundKeys[round];
    for (int index = 0; index < this.wordsInBlock; ++index)
      this.internalState[index] += roundKey[index];
  }

  private void SubRoundKey(int round)
  {
    ulong[] roundKey = this.roundKeys[round];
    for (int index = 0; index < this.wordsInBlock; ++index)
      this.internalState[index] -= roundKey[index];
  }

  private void XorRoundKey(int round)
  {
    ulong[] roundKey = this.roundKeys[round];
    for (int index = 0; index < this.wordsInBlock; ++index)
      this.internalState[index] ^= roundKey[index];
  }

  private static ulong MixColumn(ulong c)
  {
    ulong x1 = Dstu7624Engine.MulX(c);
    ulong x2 = Dstu7624Engine.Rotate(8, c) ^ c;
    ulong num = x2 ^ Dstu7624Engine.Rotate(16 /*0x10*/, x2) ^ Dstu7624Engine.Rotate(48 /*0x30*/, c);
    ulong x3 = Dstu7624Engine.MulX2(num ^ c ^ x1);
    return num ^ Dstu7624Engine.Rotate(32 /*0x20*/, x3) ^ Dstu7624Engine.Rotate(40, x1) ^ Dstu7624Engine.Rotate(48 /*0x30*/, x1);
  }

  private void MixColumns()
  {
    for (int index = 0; index < this.wordsInBlock; ++index)
      this.internalState[index] = Dstu7624Engine.MixColumn(this.internalState[index]);
  }

  private static ulong MixColumnInv(ulong c)
  {
    ulong x1 = c;
    ulong x2 = x1 ^ Dstu7624Engine.Rotate(8, x1);
    ulong x3 = x2 ^ Dstu7624Engine.Rotate(32 /*0x20*/, x2) ^ Dstu7624Engine.Rotate(48 /*0x30*/, c);
    ulong x4 = x3 ^ c;
    ulong num1 = Dstu7624Engine.Rotate(48 /*0x30*/, c);
    ulong num2 = Dstu7624Engine.Rotate(56, c);
    ulong n1 = x4 ^ num2;
    ulong n2 = Dstu7624Engine.Rotate(56, x4) ^ Dstu7624Engine.MulX(n1);
    ulong n3 = Dstu7624Engine.Rotate(16 /*0x10*/, x4) ^ c ^ Dstu7624Engine.Rotate(40, Dstu7624Engine.MulX(n2) ^ c);
    ulong n4 = x4 ^ num1 ^ Dstu7624Engine.MulX(n3);
    ulong n5 = Dstu7624Engine.Rotate(16 /*0x10*/, x3) ^ Dstu7624Engine.MulX(n4);
    ulong n6 = x4 ^ Dstu7624Engine.Rotate(24, c) ^ num1 ^ num2 ^ Dstu7624Engine.MulX(n5);
    ulong x5 = Dstu7624Engine.Rotate(32 /*0x20*/, x4) ^ c ^ num2 ^ Dstu7624Engine.MulX(n6);
    return x3 ^ Dstu7624Engine.MulX(Dstu7624Engine.Rotate(40, x5));
  }

  private void MixColumnsInv()
  {
    for (int index = 0; index < this.wordsInBlock; ++index)
      this.internalState[index] = Dstu7624Engine.MixColumnInv(this.internalState[index]);
  }

  private static ulong MulX(ulong n)
  {
    return (ulong) (((long) n & 9187201950435737471L /*0x7F7F7F7F7F7F7F7F*/) << 1 ^ (long) ((n & 9259542123273814144UL /*0x8080808080808080*/) >> 7) * 29L);
  }

  private static ulong MulX2(ulong n)
  {
    return (ulong) (((long) n & 4557430888798830399L /*0x3F3F3F3F3F3F3F3F*/) << 2 ^ (long) ((n & 9259542123273814144UL /*0x8080808080808080*/) >> 6) * 29L ^ (long) ((n & 4629771061636907072UL /*0x4040404040404040*/) >> 6) * 29L);
  }

  private static ulong Rotate(int n, ulong x) => x >> n | x << -n;

  private void RotateLeft(ulong[] x, ulong[] z)
  {
    switch (this.wordsInBlock)
    {
      case 2:
        ulong num1 = x[0];
        ulong num2 = x[1];
        z[0] = num1 >> 56 | num2 << 8;
        z[1] = num2 >> 56 | num1 << 8;
        break;
      case 4:
        ulong num3 = x[0];
        ulong num4 = x[1];
        ulong num5 = x[2];
        ulong num6 = x[3];
        z[0] = num4 >> 24 | num5 << 40;
        z[1] = num5 >> 24 | num6 << 40;
        z[2] = num6 >> 24 | num3 << 40;
        z[3] = num3 >> 24 | num4 << 40;
        break;
      case 8:
        ulong num7 = x[0];
        ulong num8 = x[1];
        ulong num9 = x[2];
        ulong num10 = x[3];
        ulong num11 = x[4];
        ulong num12 = x[5];
        ulong num13 = x[6];
        ulong num14 = x[7];
        z[0] = num9 >> 24 | num10 << 40;
        z[1] = num10 >> 24 | num11 << 40;
        z[2] = num11 >> 24 | num12 << 40;
        z[3] = num12 >> 24 | num13 << 40;
        z[4] = num13 >> 24 | num14 << 40;
        z[5] = num14 >> 24 | num7 << 40;
        z[6] = num7 >> 24 | num8 << 40;
        z[7] = num8 >> 24 | num9 << 40;
        break;
      default:
        throw new InvalidOperationException("unsupported block length: only 128/256/512 are allowed");
    }
  }

  public virtual string AlgorithmName => "DSTU7624";

  public virtual int GetBlockSize() => this.wordsInBlock << 3;
}
