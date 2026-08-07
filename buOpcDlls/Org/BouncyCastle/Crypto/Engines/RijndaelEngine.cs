// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RijndaelEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RijndaelEngine : IBlockCipher
{
  private static readonly int MAXROUNDS = 14;
  private static readonly int MAXKC = 64 /*0x40*/;
  private static readonly byte[] Logtable = new byte[256 /*0x0100*/]
  {
    (byte) 0,
    (byte) 0,
    (byte) 25,
    (byte) 1,
    (byte) 50,
    (byte) 2,
    (byte) 26,
    (byte) 198,
    (byte) 75,
    (byte) 199,
    (byte) 27,
    (byte) 104,
    (byte) 51,
    (byte) 238,
    (byte) 223,
    (byte) 3,
    (byte) 100,
    (byte) 4,
    (byte) 224 /*0xE0*/,
    (byte) 14,
    (byte) 52,
    (byte) 141,
    (byte) 129,
    (byte) 239,
    (byte) 76,
    (byte) 113,
    (byte) 8,
    (byte) 200,
    (byte) 248,
    (byte) 105,
    (byte) 28,
    (byte) 193,
    (byte) 125,
    (byte) 194,
    (byte) 29,
    (byte) 181,
    (byte) 249,
    (byte) 185,
    (byte) 39,
    (byte) 106,
    (byte) 77,
    (byte) 228,
    (byte) 166,
    (byte) 114,
    (byte) 154,
    (byte) 201,
    (byte) 9,
    (byte) 120,
    (byte) 101,
    (byte) 47,
    (byte) 138,
    (byte) 5,
    (byte) 33,
    (byte) 15,
    (byte) 225,
    (byte) 36,
    (byte) 18,
    (byte) 240 /*0xF0*/,
    (byte) 130,
    (byte) 69,
    (byte) 53,
    (byte) 147,
    (byte) 218,
    (byte) 142,
    (byte) 150,
    (byte) 143,
    (byte) 219,
    (byte) 189,
    (byte) 54,
    (byte) 208 /*0xD0*/,
    (byte) 206,
    (byte) 148,
    (byte) 19,
    (byte) 92,
    (byte) 210,
    (byte) 241,
    (byte) 64 /*0x40*/,
    (byte) 70,
    (byte) 131,
    (byte) 56,
    (byte) 102,
    (byte) 221,
    (byte) 253,
    (byte) 48 /*0x30*/,
    (byte) 191,
    (byte) 6,
    (byte) 139,
    (byte) 98,
    (byte) 179,
    (byte) 37,
    (byte) 226,
    (byte) 152,
    (byte) 34,
    (byte) 136,
    (byte) 145,
    (byte) 16 /*0x10*/,
    (byte) 126,
    (byte) 110,
    (byte) 72,
    (byte) 195,
    (byte) 163,
    (byte) 182,
    (byte) 30,
    (byte) 66,
    (byte) 58,
    (byte) 107,
    (byte) 40,
    (byte) 84,
    (byte) 250,
    (byte) 133,
    (byte) 61,
    (byte) 186,
    (byte) 43,
    (byte) 121,
    (byte) 10,
    (byte) 21,
    (byte) 155,
    (byte) 159,
    (byte) 94,
    (byte) 202,
    (byte) 78,
    (byte) 212,
    (byte) 172,
    (byte) 229,
    (byte) 243,
    (byte) 115,
    (byte) 167,
    (byte) 87,
    (byte) 175,
    (byte) 88,
    (byte) 168,
    (byte) 80 /*0x50*/,
    (byte) 244,
    (byte) 234,
    (byte) 214,
    (byte) 116,
    (byte) 79,
    (byte) 174,
    (byte) 233,
    (byte) 213,
    (byte) 231,
    (byte) 230,
    (byte) 173,
    (byte) 232,
    (byte) 44,
    (byte) 215,
    (byte) 117,
    (byte) 122,
    (byte) 235,
    (byte) 22,
    (byte) 11,
    (byte) 245,
    (byte) 89,
    (byte) 203,
    (byte) 95,
    (byte) 176 /*0xB0*/,
    (byte) 156,
    (byte) 169,
    (byte) 81,
    (byte) 160 /*0xA0*/,
    (byte) 127 /*0x7F*/,
    (byte) 12,
    (byte) 246,
    (byte) 111,
    (byte) 23,
    (byte) 196,
    (byte) 73,
    (byte) 236,
    (byte) 216,
    (byte) 67,
    (byte) 31 /*0x1F*/,
    (byte) 45,
    (byte) 164,
    (byte) 118,
    (byte) 123,
    (byte) 183,
    (byte) 204,
    (byte) 187,
    (byte) 62,
    (byte) 90,
    (byte) 251,
    (byte) 96 /*0x60*/,
    (byte) 177,
    (byte) 134,
    (byte) 59,
    (byte) 82,
    (byte) 161,
    (byte) 108,
    (byte) 170,
    (byte) 85,
    (byte) 41,
    (byte) 157,
    (byte) 151,
    (byte) 178,
    (byte) 135,
    (byte) 144 /*0x90*/,
    (byte) 97,
    (byte) 190,
    (byte) 220,
    (byte) 252,
    (byte) 188,
    (byte) 149,
    (byte) 207,
    (byte) 205,
    (byte) 55,
    (byte) 63 /*0x3F*/,
    (byte) 91,
    (byte) 209,
    (byte) 83,
    (byte) 57,
    (byte) 132,
    (byte) 60,
    (byte) 65,
    (byte) 162,
    (byte) 109,
    (byte) 71,
    (byte) 20,
    (byte) 42,
    (byte) 158,
    (byte) 93,
    (byte) 86,
    (byte) 242,
    (byte) 211,
    (byte) 171,
    (byte) 68,
    (byte) 17,
    (byte) 146,
    (byte) 217,
    (byte) 35,
    (byte) 32 /*0x20*/,
    (byte) 46,
    (byte) 137,
    (byte) 180,
    (byte) 124,
    (byte) 184,
    (byte) 38,
    (byte) 119,
    (byte) 153,
    (byte) 227,
    (byte) 165,
    (byte) 103,
    (byte) 74,
    (byte) 237,
    (byte) 222,
    (byte) 197,
    (byte) 49,
    (byte) 254,
    (byte) 24,
    (byte) 13,
    (byte) 99,
    (byte) 140,
    (byte) 128 /*0x80*/,
    (byte) 192 /*0xC0*/,
    (byte) 247,
    (byte) 112 /*0x70*/,
    (byte) 7
  };
  private static readonly byte[] Alogtable = new byte[511 /*0x01FF*/]
  {
    (byte) 0,
    (byte) 3,
    (byte) 5,
    (byte) 15,
    (byte) 17,
    (byte) 51,
    (byte) 85,
    byte.MaxValue,
    (byte) 26,
    (byte) 46,
    (byte) 114,
    (byte) 150,
    (byte) 161,
    (byte) 248,
    (byte) 19,
    (byte) 53,
    (byte) 95,
    (byte) 225,
    (byte) 56,
    (byte) 72,
    (byte) 216,
    (byte) 115,
    (byte) 149,
    (byte) 164,
    (byte) 247,
    (byte) 2,
    (byte) 6,
    (byte) 10,
    (byte) 30,
    (byte) 34,
    (byte) 102,
    (byte) 170,
    (byte) 229,
    (byte) 52,
    (byte) 92,
    (byte) 228,
    (byte) 55,
    (byte) 89,
    (byte) 235,
    (byte) 38,
    (byte) 106,
    (byte) 190,
    (byte) 217,
    (byte) 112 /*0x70*/,
    (byte) 144 /*0x90*/,
    (byte) 171,
    (byte) 230,
    (byte) 49,
    (byte) 83,
    (byte) 245,
    (byte) 4,
    (byte) 12,
    (byte) 20,
    (byte) 60,
    (byte) 68,
    (byte) 204,
    (byte) 79,
    (byte) 209,
    (byte) 104,
    (byte) 184,
    (byte) 211,
    (byte) 110,
    (byte) 178,
    (byte) 205,
    (byte) 76,
    (byte) 212,
    (byte) 103,
    (byte) 169,
    (byte) 224 /*0xE0*/,
    (byte) 59,
    (byte) 77,
    (byte) 215,
    (byte) 98,
    (byte) 166,
    (byte) 241,
    (byte) 8,
    (byte) 24,
    (byte) 40,
    (byte) 120,
    (byte) 136,
    (byte) 131,
    (byte) 158,
    (byte) 185,
    (byte) 208 /*0xD0*/,
    (byte) 107,
    (byte) 189,
    (byte) 220,
    (byte) 127 /*0x7F*/,
    (byte) 129,
    (byte) 152,
    (byte) 179,
    (byte) 206,
    (byte) 73,
    (byte) 219,
    (byte) 118,
    (byte) 154,
    (byte) 181,
    (byte) 196,
    (byte) 87,
    (byte) 249,
    (byte) 16 /*0x10*/,
    (byte) 48 /*0x30*/,
    (byte) 80 /*0x50*/,
    (byte) 240 /*0xF0*/,
    (byte) 11,
    (byte) 29,
    (byte) 39,
    (byte) 105,
    (byte) 187,
    (byte) 214,
    (byte) 97,
    (byte) 163,
    (byte) 254,
    (byte) 25,
    (byte) 43,
    (byte) 125,
    (byte) 135,
    (byte) 146,
    (byte) 173,
    (byte) 236,
    (byte) 47,
    (byte) 113,
    (byte) 147,
    (byte) 174,
    (byte) 233,
    (byte) 32 /*0x20*/,
    (byte) 96 /*0x60*/,
    (byte) 160 /*0xA0*/,
    (byte) 251,
    (byte) 22,
    (byte) 58,
    (byte) 78,
    (byte) 210,
    (byte) 109,
    (byte) 183,
    (byte) 194,
    (byte) 93,
    (byte) 231,
    (byte) 50,
    (byte) 86,
    (byte) 250,
    (byte) 21,
    (byte) 63 /*0x3F*/,
    (byte) 65,
    (byte) 195,
    (byte) 94,
    (byte) 226,
    (byte) 61,
    (byte) 71,
    (byte) 201,
    (byte) 64 /*0x40*/,
    (byte) 192 /*0xC0*/,
    (byte) 91,
    (byte) 237,
    (byte) 44,
    (byte) 116,
    (byte) 156,
    (byte) 191,
    (byte) 218,
    (byte) 117,
    (byte) 159,
    (byte) 186,
    (byte) 213,
    (byte) 100,
    (byte) 172,
    (byte) 239,
    (byte) 42,
    (byte) 126,
    (byte) 130,
    (byte) 157,
    (byte) 188,
    (byte) 223,
    (byte) 122,
    (byte) 142,
    (byte) 137,
    (byte) 128 /*0x80*/,
    (byte) 155,
    (byte) 182,
    (byte) 193,
    (byte) 88,
    (byte) 232,
    (byte) 35,
    (byte) 101,
    (byte) 175,
    (byte) 234,
    (byte) 37,
    (byte) 111,
    (byte) 177,
    (byte) 200,
    (byte) 67,
    (byte) 197,
    (byte) 84,
    (byte) 252,
    (byte) 31 /*0x1F*/,
    (byte) 33,
    (byte) 99,
    (byte) 165,
    (byte) 244,
    (byte) 7,
    (byte) 9,
    (byte) 27,
    (byte) 45,
    (byte) 119,
    (byte) 153,
    (byte) 176 /*0xB0*/,
    (byte) 203,
    (byte) 70,
    (byte) 202,
    (byte) 69,
    (byte) 207,
    (byte) 74,
    (byte) 222,
    (byte) 121,
    (byte) 139,
    (byte) 134,
    (byte) 145,
    (byte) 168,
    (byte) 227,
    (byte) 62,
    (byte) 66,
    (byte) 198,
    (byte) 81,
    (byte) 243,
    (byte) 14,
    (byte) 18,
    (byte) 54,
    (byte) 90,
    (byte) 238,
    (byte) 41,
    (byte) 123,
    (byte) 141,
    (byte) 140,
    (byte) 143,
    (byte) 138,
    (byte) 133,
    (byte) 148,
    (byte) 167,
    (byte) 242,
    (byte) 13,
    (byte) 23,
    (byte) 57,
    (byte) 75,
    (byte) 221,
    (byte) 124,
    (byte) 132,
    (byte) 151,
    (byte) 162,
    (byte) 253,
    (byte) 28,
    (byte) 36,
    (byte) 108,
    (byte) 180,
    (byte) 199,
    (byte) 82,
    (byte) 246,
    (byte) 1,
    (byte) 3,
    (byte) 5,
    (byte) 15,
    (byte) 17,
    (byte) 51,
    (byte) 85,
    byte.MaxValue,
    (byte) 26,
    (byte) 46,
    (byte) 114,
    (byte) 150,
    (byte) 161,
    (byte) 248,
    (byte) 19,
    (byte) 53,
    (byte) 95,
    (byte) 225,
    (byte) 56,
    (byte) 72,
    (byte) 216,
    (byte) 115,
    (byte) 149,
    (byte) 164,
    (byte) 247,
    (byte) 2,
    (byte) 6,
    (byte) 10,
    (byte) 30,
    (byte) 34,
    (byte) 102,
    (byte) 170,
    (byte) 229,
    (byte) 52,
    (byte) 92,
    (byte) 228,
    (byte) 55,
    (byte) 89,
    (byte) 235,
    (byte) 38,
    (byte) 106,
    (byte) 190,
    (byte) 217,
    (byte) 112 /*0x70*/,
    (byte) 144 /*0x90*/,
    (byte) 171,
    (byte) 230,
    (byte) 49,
    (byte) 83,
    (byte) 245,
    (byte) 4,
    (byte) 12,
    (byte) 20,
    (byte) 60,
    (byte) 68,
    (byte) 204,
    (byte) 79,
    (byte) 209,
    (byte) 104,
    (byte) 184,
    (byte) 211,
    (byte) 110,
    (byte) 178,
    (byte) 205,
    (byte) 76,
    (byte) 212,
    (byte) 103,
    (byte) 169,
    (byte) 224 /*0xE0*/,
    (byte) 59,
    (byte) 77,
    (byte) 215,
    (byte) 98,
    (byte) 166,
    (byte) 241,
    (byte) 8,
    (byte) 24,
    (byte) 40,
    (byte) 120,
    (byte) 136,
    (byte) 131,
    (byte) 158,
    (byte) 185,
    (byte) 208 /*0xD0*/,
    (byte) 107,
    (byte) 189,
    (byte) 220,
    (byte) 127 /*0x7F*/,
    (byte) 129,
    (byte) 152,
    (byte) 179,
    (byte) 206,
    (byte) 73,
    (byte) 219,
    (byte) 118,
    (byte) 154,
    (byte) 181,
    (byte) 196,
    (byte) 87,
    (byte) 249,
    (byte) 16 /*0x10*/,
    (byte) 48 /*0x30*/,
    (byte) 80 /*0x50*/,
    (byte) 240 /*0xF0*/,
    (byte) 11,
    (byte) 29,
    (byte) 39,
    (byte) 105,
    (byte) 187,
    (byte) 214,
    (byte) 97,
    (byte) 163,
    (byte) 254,
    (byte) 25,
    (byte) 43,
    (byte) 125,
    (byte) 135,
    (byte) 146,
    (byte) 173,
    (byte) 236,
    (byte) 47,
    (byte) 113,
    (byte) 147,
    (byte) 174,
    (byte) 233,
    (byte) 32 /*0x20*/,
    (byte) 96 /*0x60*/,
    (byte) 160 /*0xA0*/,
    (byte) 251,
    (byte) 22,
    (byte) 58,
    (byte) 78,
    (byte) 210,
    (byte) 109,
    (byte) 183,
    (byte) 194,
    (byte) 93,
    (byte) 231,
    (byte) 50,
    (byte) 86,
    (byte) 250,
    (byte) 21,
    (byte) 63 /*0x3F*/,
    (byte) 65,
    (byte) 195,
    (byte) 94,
    (byte) 226,
    (byte) 61,
    (byte) 71,
    (byte) 201,
    (byte) 64 /*0x40*/,
    (byte) 192 /*0xC0*/,
    (byte) 91,
    (byte) 237,
    (byte) 44,
    (byte) 116,
    (byte) 156,
    (byte) 191,
    (byte) 218,
    (byte) 117,
    (byte) 159,
    (byte) 186,
    (byte) 213,
    (byte) 100,
    (byte) 172,
    (byte) 239,
    (byte) 42,
    (byte) 126,
    (byte) 130,
    (byte) 157,
    (byte) 188,
    (byte) 223,
    (byte) 122,
    (byte) 142,
    (byte) 137,
    (byte) 128 /*0x80*/,
    (byte) 155,
    (byte) 182,
    (byte) 193,
    (byte) 88,
    (byte) 232,
    (byte) 35,
    (byte) 101,
    (byte) 175,
    (byte) 234,
    (byte) 37,
    (byte) 111,
    (byte) 177,
    (byte) 200,
    (byte) 67,
    (byte) 197,
    (byte) 84,
    (byte) 252,
    (byte) 31 /*0x1F*/,
    (byte) 33,
    (byte) 99,
    (byte) 165,
    (byte) 244,
    (byte) 7,
    (byte) 9,
    (byte) 27,
    (byte) 45,
    (byte) 119,
    (byte) 153,
    (byte) 176 /*0xB0*/,
    (byte) 203,
    (byte) 70,
    (byte) 202,
    (byte) 69,
    (byte) 207,
    (byte) 74,
    (byte) 222,
    (byte) 121,
    (byte) 139,
    (byte) 134,
    (byte) 145,
    (byte) 168,
    (byte) 227,
    (byte) 62,
    (byte) 66,
    (byte) 198,
    (byte) 81,
    (byte) 243,
    (byte) 14,
    (byte) 18,
    (byte) 54,
    (byte) 90,
    (byte) 238,
    (byte) 41,
    (byte) 123,
    (byte) 141,
    (byte) 140,
    (byte) 143,
    (byte) 138,
    (byte) 133,
    (byte) 148,
    (byte) 167,
    (byte) 242,
    (byte) 13,
    (byte) 23,
    (byte) 57,
    (byte) 75,
    (byte) 221,
    (byte) 124,
    (byte) 132,
    (byte) 151,
    (byte) 162,
    (byte) 253,
    (byte) 28,
    (byte) 36,
    (byte) 108,
    (byte) 180,
    (byte) 199,
    (byte) 82,
    (byte) 246,
    (byte) 1
  };
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
  private static readonly byte[][] shifts0 = new byte[5][]
  {
    new byte[4]
    {
      (byte) 0,
      (byte) 8,
      (byte) 16 /*0x10*/,
      (byte) 24
    },
    new byte[4]
    {
      (byte) 0,
      (byte) 8,
      (byte) 16 /*0x10*/,
      (byte) 24
    },
    new byte[4]
    {
      (byte) 0,
      (byte) 8,
      (byte) 16 /*0x10*/,
      (byte) 24
    },
    new byte[4]
    {
      (byte) 0,
      (byte) 8,
      (byte) 16 /*0x10*/,
      (byte) 32 /*0x20*/
    },
    new byte[4]
    {
      (byte) 0,
      (byte) 8,
      (byte) 24,
      (byte) 32 /*0x20*/
    }
  };
  private static readonly byte[][] shifts1 = new byte[5][]
  {
    new byte[4]
    {
      (byte) 0,
      (byte) 24,
      (byte) 16 /*0x10*/,
      (byte) 8
    },
    new byte[4]
    {
      (byte) 0,
      (byte) 32 /*0x20*/,
      (byte) 24,
      (byte) 16 /*0x10*/
    },
    new byte[4]
    {
      (byte) 0,
      (byte) 40,
      (byte) 32 /*0x20*/,
      (byte) 24
    },
    new byte[4]
    {
      (byte) 0,
      (byte) 48 /*0x30*/,
      (byte) 40,
      (byte) 24
    },
    new byte[4]
    {
      (byte) 0,
      (byte) 56,
      (byte) 40,
      (byte) 32 /*0x20*/
    }
  };
  private int BC;
  private long BC_MASK;
  private int ROUNDS;
  private int blockBits;
  private long[][] workingKey;
  private long A0;
  private long A1;
  private long A2;
  private long A3;
  private bool forEncryption;
  private byte[] shifts0SC;
  private byte[] shifts1SC;

  private byte Mul0x2(int b)
  {
    return b != 0 ? RijndaelEngine.Alogtable[25 + ((int) RijndaelEngine.Logtable[b] & (int) byte.MaxValue)] : (byte) 0;
  }

  private byte Mul0x3(int b)
  {
    return b != 0 ? RijndaelEngine.Alogtable[1 + ((int) RijndaelEngine.Logtable[b] & (int) byte.MaxValue)] : (byte) 0;
  }

  private byte Mul0x9(int b) => b >= 0 ? RijndaelEngine.Alogtable[199 + b] : (byte) 0;

  private byte Mul0xb(int b) => b >= 0 ? RijndaelEngine.Alogtable[104 + b] : (byte) 0;

  private byte Mul0xd(int b) => b >= 0 ? RijndaelEngine.Alogtable[238 + b] : (byte) 0;

  private byte Mul0xe(int b) => b >= 0 ? RijndaelEngine.Alogtable[223 + b] : (byte) 0;

  private void KeyAddition(long[] rk)
  {
    this.A0 ^= rk[0];
    this.A1 ^= rk[1];
    this.A2 ^= rk[2];
    this.A3 ^= rk[3];
  }

  private long Shift(long r, int shift)
  {
    ulong num = (ulong) (r >>> shift);
    if (shift > 31 /*0x1F*/)
      num &= (ulong) uint.MaxValue;
    return ((long) num | r << this.BC - shift) & this.BC_MASK;
  }

  private void ShiftRow(byte[] shiftsSC)
  {
    this.A1 = this.Shift(this.A1, (int) shiftsSC[1]);
    this.A2 = this.Shift(this.A2, (int) shiftsSC[2]);
    this.A3 = this.Shift(this.A3, (int) shiftsSC[3]);
  }

  private long ApplyS(long r, byte[] box)
  {
    long num = 0;
    for (int index = 0; index < this.BC; index += 8)
      num |= (long) ((int) box[(int) (r >> index & (long) byte.MaxValue)] & (int) byte.MaxValue) << index;
    return num;
  }

  private void Substitution(byte[] box)
  {
    this.A0 = this.ApplyS(this.A0, box);
    this.A1 = this.ApplyS(this.A1, box);
    this.A2 = this.ApplyS(this.A2, box);
    this.A3 = this.ApplyS(this.A3, box);
  }

  private void MixColumn()
  {
    long num1 = 0;
    long num2 = 0;
    long num3 = 0;
    long num4 = 0;
    for (int index = 0; index < this.BC; index += 8)
    {
      int b1 = (int) (this.A0 >> index & (long) byte.MaxValue);
      int b2 = (int) (this.A1 >> index & (long) byte.MaxValue);
      int b3 = (int) (this.A2 >> index & (long) byte.MaxValue);
      int b4 = (int) (this.A3 >> index & (long) byte.MaxValue);
      num4 |= (long) (((int) this.Mul0x2(b1) ^ (int) this.Mul0x3(b2) ^ b3 ^ b4) & (int) byte.MaxValue) << index;
      num3 |= (long) (((int) this.Mul0x2(b2) ^ (int) this.Mul0x3(b3) ^ b4 ^ b1) & (int) byte.MaxValue) << index;
      num2 |= (long) (((int) this.Mul0x2(b3) ^ (int) this.Mul0x3(b4) ^ b1 ^ b2) & (int) byte.MaxValue) << index;
      num1 |= (long) (((int) this.Mul0x2(b4) ^ (int) this.Mul0x3(b1) ^ b2 ^ b3) & (int) byte.MaxValue) << index;
    }
    this.A0 = num4;
    this.A1 = num3;
    this.A2 = num2;
    this.A3 = num1;
  }

  private void InvMixColumn()
  {
    long num1 = 0;
    long num2 = 0;
    long num3 = 0;
    long num4 = 0;
    for (int index = 0; index < this.BC; index += 8)
    {
      int num5 = (int) (this.A0 >> index & (long) byte.MaxValue);
      int num6 = (int) (this.A1 >> index & (long) byte.MaxValue);
      int num7 = (int) (this.A2 >> index & (long) byte.MaxValue);
      int num8 = (int) (this.A3 >> index & (long) byte.MaxValue);
      int b1 = num5 != 0 ? (int) RijndaelEngine.Logtable[num5 & (int) byte.MaxValue] & (int) byte.MaxValue : -1;
      int b2 = num6 != 0 ? (int) RijndaelEngine.Logtable[num6 & (int) byte.MaxValue] & (int) byte.MaxValue : -1;
      int b3 = num7 != 0 ? (int) RijndaelEngine.Logtable[num7 & (int) byte.MaxValue] & (int) byte.MaxValue : -1;
      int b4 = num8 != 0 ? (int) RijndaelEngine.Logtable[num8 & (int) byte.MaxValue] & (int) byte.MaxValue : -1;
      num4 |= (long) (((int) this.Mul0xe(b1) ^ (int) this.Mul0xb(b2) ^ (int) this.Mul0xd(b3) ^ (int) this.Mul0x9(b4)) & (int) byte.MaxValue) << index;
      num3 |= (long) (((int) this.Mul0xe(b2) ^ (int) this.Mul0xb(b3) ^ (int) this.Mul0xd(b4) ^ (int) this.Mul0x9(b1)) & (int) byte.MaxValue) << index;
      num2 |= (long) (((int) this.Mul0xe(b3) ^ (int) this.Mul0xb(b4) ^ (int) this.Mul0xd(b1) ^ (int) this.Mul0x9(b2)) & (int) byte.MaxValue) << index;
      num1 |= (long) (((int) this.Mul0xe(b4) ^ (int) this.Mul0xb(b1) ^ (int) this.Mul0xd(b2) ^ (int) this.Mul0x9(b3)) & (int) byte.MaxValue) << index;
    }
    this.A0 = num4;
    this.A1 = num3;
    this.A2 = num2;
    this.A3 = num1;
  }

  private long[][] GenerateWorkingKey(KeyParameter keyParameter)
  {
    byte[] key = keyParameter.GetKey();
    int num1 = 0;
    int num2 = key.Length * 8;
    byte[,] numArray = new byte[4, RijndaelEngine.MAXKC];
    long[][] workingKey = new long[RijndaelEngine.MAXROUNDS + 1][];
    for (int index = 0; index < RijndaelEngine.MAXROUNDS + 1; ++index)
      workingKey[index] = new long[4];
    int num3;
    switch (num2)
    {
      case 128 /*0x80*/:
        num3 = 4;
        break;
      case 160 /*0xA0*/:
        num3 = 5;
        break;
      case 192 /*0xC0*/:
        num3 = 6;
        break;
      case 224 /*0xE0*/:
        num3 = 7;
        break;
      case 256 /*0x0100*/:
        num3 = 8;
        break;
      default:
        throw new ArgumentException("Key length not 128/160/192/224/256 bits.");
    }
    this.ROUNDS = num2 < this.blockBits ? this.BC / 8 + 6 : num3 + 6;
    int num4 = 0;
    for (int index = 0; index < key.Length; ++index)
      numArray[index % 4, index / 4] = key[num4++];
    int num5 = 0;
    for (int index1 = 0; index1 < num3 && num5 < (this.ROUNDS + 1) * (this.BC / 8); ++num5)
    {
      for (int index2 = 0; index2 < 4; ++index2)
        workingKey[num5 / (this.BC / 8)][index2] |= (long) ((int) numArray[index2, index1] & (int) byte.MaxValue) << num5 * 8 % this.BC;
      ++index1;
    }
label_50:
    while (num5 < (this.ROUNDS + 1) * (this.BC / 8))
    {
      for (int index = 0; index < 4; ++index)
        numArray[index, 0] ^= RijndaelEngine.S[(int) numArray[(index + 1) % 4, num3 - 1] & (int) byte.MaxValue];
      numArray[0, 0] ^= RijndaelEngine.rcon[num1++];
      if (num3 <= 6)
      {
        for (int index3 = 1; index3 < num3; ++index3)
        {
          for (int index4 = 0; index4 < 4; ++index4)
            numArray[index4, index3] ^= numArray[index4, index3 - 1];
        }
      }
      else
      {
        for (int index5 = 1; index5 < 4; ++index5)
        {
          for (int index6 = 0; index6 < 4; ++index6)
            numArray[index6, index5] ^= numArray[index6, index5 - 1];
        }
        for (int index = 0; index < 4; ++index)
          numArray[index, 4] ^= RijndaelEngine.S[(int) numArray[index, 3] & (int) byte.MaxValue];
        for (int index7 = 5; index7 < num3; ++index7)
        {
          for (int index8 = 0; index8 < 4; ++index8)
            numArray[index8, index7] ^= numArray[index8, index7 - 1];
        }
      }
      int index9 = 0;
      while (true)
      {
        if (index9 < num3 && num5 < (this.ROUNDS + 1) * (this.BC / 8))
        {
          for (int index10 = 0; index10 < 4; ++index10)
            workingKey[num5 / (this.BC / 8)][index10] |= (long) ((int) numArray[index10, index9] & (int) byte.MaxValue) << num5 * 8 % this.BC;
          ++index9;
          ++num5;
        }
        else
          goto label_50;
      }
    }
    return workingKey;
  }

  public RijndaelEngine()
    : this(128 /*0x80*/)
  {
  }

  public RijndaelEngine(int blockBits)
  {
    switch (blockBits)
    {
      case 128 /*0x80*/:
        this.BC = 32 /*0x20*/;
        this.BC_MASK = (long) uint.MaxValue;
        this.shifts0SC = RijndaelEngine.shifts0[0];
        this.shifts1SC = RijndaelEngine.shifts1[0];
        break;
      case 160 /*0xA0*/:
        this.BC = 40;
        this.BC_MASK = 1099511627775L /*0xFFFFFFFFFF*/;
        this.shifts0SC = RijndaelEngine.shifts0[1];
        this.shifts1SC = RijndaelEngine.shifts1[1];
        break;
      case 192 /*0xC0*/:
        this.BC = 48 /*0x30*/;
        this.BC_MASK = 281474976710655L /*0xFFFFFFFFFFFF*/;
        this.shifts0SC = RijndaelEngine.shifts0[2];
        this.shifts1SC = RijndaelEngine.shifts1[2];
        break;
      case 224 /*0xE0*/:
        this.BC = 56;
        this.BC_MASK = 72057594037927935L /*0xFFFFFFFFFFFFFF*/;
        this.shifts0SC = RijndaelEngine.shifts0[3];
        this.shifts1SC = RijndaelEngine.shifts1[3];
        break;
      case 256 /*0x0100*/:
        this.BC = 64 /*0x40*/;
        this.BC_MASK = -1L;
        this.shifts0SC = RijndaelEngine.shifts0[4];
        this.shifts1SC = RijndaelEngine.shifts1[4];
        break;
      default:
        throw new ArgumentException("unknown blocksize to Rijndael");
    }
    this.blockBits = blockBits;
  }

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.workingKey = parameters is KeyParameter keyParameter ? this.GenerateWorkingKey(keyParameter) : throw new ArgumentException("invalid parameter passed to Rijndael init - " + Platform.GetTypeName((object) parameters));
    this.forEncryption = forEncryption;
  }

  public virtual string AlgorithmName => "Rijndael";

  public virtual int GetBlockSize() => this.BC / 2;

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.workingKey == null)
      throw new InvalidOperationException("Rijndael engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.BC / 2, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.BC / 2, "output buffer too short");
    this.UnPackBlock(input, inOff);
    if (this.forEncryption)
      this.EncryptBlock(this.workingKey);
    else
      this.DecryptBlock(this.workingKey);
    this.PackBlock(output, outOff);
    return this.BC / 2;
  }

  private void UnPackBlock(byte[] bytes, int off)
  {
    int num1 = off;
    byte[] numArray1 = bytes;
    int index1 = num1;
    int num2 = index1 + 1;
    this.A0 = (long) ((int) numArray1[index1] & (int) byte.MaxValue);
    byte[] numArray2 = bytes;
    int index2 = num2;
    int num3 = index2 + 1;
    this.A1 = (long) ((int) numArray2[index2] & (int) byte.MaxValue);
    byte[] numArray3 = bytes;
    int index3 = num3;
    int num4 = index3 + 1;
    this.A2 = (long) ((int) numArray3[index3] & (int) byte.MaxValue);
    byte[] numArray4 = bytes;
    int index4 = num4;
    int num5 = index4 + 1;
    this.A3 = (long) ((int) numArray4[index4] & (int) byte.MaxValue);
    for (int index5 = 8; index5 != this.BC; index5 += 8)
    {
      long a0 = this.A0;
      byte[] numArray5 = bytes;
      int index6 = num5;
      int num6 = index6 + 1;
      long num7 = (long) ((int) numArray5[index6] & (int) byte.MaxValue) << index5;
      this.A0 = a0 | num7;
      long a1 = this.A1;
      byte[] numArray6 = bytes;
      int index7 = num6;
      int num8 = index7 + 1;
      long num9 = (long) ((int) numArray6[index7] & (int) byte.MaxValue) << index5;
      this.A1 = a1 | num9;
      long a2 = this.A2;
      byte[] numArray7 = bytes;
      int index8 = num8;
      int num10 = index8 + 1;
      long num11 = (long) ((int) numArray7[index8] & (int) byte.MaxValue) << index5;
      this.A2 = a2 | num11;
      long a3 = this.A3;
      byte[] numArray8 = bytes;
      int index9 = num10;
      num5 = index9 + 1;
      long num12 = (long) ((int) numArray8[index9] & (int) byte.MaxValue) << index5;
      this.A3 = a3 | num12;
    }
  }

  private void PackBlock(byte[] bytes, int off)
  {
    int num1 = off;
    for (int index1 = 0; index1 != this.BC; index1 += 8)
    {
      byte[] numArray1 = bytes;
      int index2 = num1;
      int num2 = index2 + 1;
      int num3 = (int) (byte) (this.A0 >> index1);
      numArray1[index2] = (byte) num3;
      byte[] numArray2 = bytes;
      int index3 = num2;
      int num4 = index3 + 1;
      int num5 = (int) (byte) (this.A1 >> index1);
      numArray2[index3] = (byte) num5;
      byte[] numArray3 = bytes;
      int index4 = num4;
      int num6 = index4 + 1;
      int num7 = (int) (byte) (this.A2 >> index1);
      numArray3[index4] = (byte) num7;
      byte[] numArray4 = bytes;
      int index5 = num6;
      num1 = index5 + 1;
      int num8 = (int) (byte) (this.A3 >> index1);
      numArray4[index5] = (byte) num8;
    }
  }

  private void EncryptBlock(long[][] rk)
  {
    this.KeyAddition(rk[0]);
    for (int index = 1; index < this.ROUNDS; ++index)
    {
      this.Substitution(RijndaelEngine.S);
      this.ShiftRow(this.shifts0SC);
      this.MixColumn();
      this.KeyAddition(rk[index]);
    }
    this.Substitution(RijndaelEngine.S);
    this.ShiftRow(this.shifts0SC);
    this.KeyAddition(rk[this.ROUNDS]);
  }

  private void DecryptBlock(long[][] rk)
  {
    this.KeyAddition(rk[this.ROUNDS]);
    this.Substitution(RijndaelEngine.Si);
    this.ShiftRow(this.shifts1SC);
    for (int index = this.ROUNDS - 1; index > 0; --index)
    {
      this.KeyAddition(rk[index]);
      this.InvMixColumn();
      this.Substitution(RijndaelEngine.Si);
      this.ShiftRow(this.shifts1SC);
    }
    this.KeyAddition(rk[0]);
  }
}
