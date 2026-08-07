// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.AriaEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class AriaEngine : IBlockCipher
{
  private static readonly byte[][] C = new byte[3][]
  {
    Hex.DecodeStrict("517cc1b727220a94fe13abe8fa9a6ee0"),
    Hex.DecodeStrict("6db14acc9e21c820ff28b1d5ef5de2b0"),
    Hex.DecodeStrict("db92371d2126e9700324977504e8c90e")
  };
  private static readonly byte[] SB1_sbox = new byte[256 /*0x0100*/]
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
  private static readonly byte[] SB2_sbox = new byte[256 /*0x0100*/]
  {
    (byte) 226,
    (byte) 78,
    (byte) 84,
    (byte) 252,
    (byte) 148,
    (byte) 194,
    (byte) 74,
    (byte) 204,
    (byte) 98,
    (byte) 13,
    (byte) 106,
    (byte) 70,
    (byte) 60,
    (byte) 77,
    (byte) 139,
    (byte) 209,
    (byte) 94,
    (byte) 250,
    (byte) 100,
    (byte) 203,
    (byte) 180,
    (byte) 151,
    (byte) 190,
    (byte) 43,
    (byte) 188,
    (byte) 119,
    (byte) 46,
    (byte) 3,
    (byte) 211,
    (byte) 25,
    (byte) 89,
    (byte) 193,
    (byte) 29,
    (byte) 6,
    (byte) 65,
    (byte) 107,
    (byte) 85,
    (byte) 240 /*0xF0*/,
    (byte) 153,
    (byte) 105,
    (byte) 234,
    (byte) 156,
    (byte) 24,
    (byte) 174,
    (byte) 99,
    (byte) 223,
    (byte) 231,
    (byte) 187,
    (byte) 0,
    (byte) 115,
    (byte) 102,
    (byte) 251,
    (byte) 150,
    (byte) 76,
    (byte) 133,
    (byte) 228,
    (byte) 58,
    (byte) 9,
    (byte) 69,
    (byte) 170,
    (byte) 15,
    (byte) 238,
    (byte) 16 /*0x10*/,
    (byte) 235,
    (byte) 45,
    (byte) 127 /*0x7F*/,
    (byte) 244,
    (byte) 41,
    (byte) 172,
    (byte) 207,
    (byte) 173,
    (byte) 145,
    (byte) 141,
    (byte) 120,
    (byte) 200,
    (byte) 149,
    (byte) 249,
    (byte) 47,
    (byte) 206,
    (byte) 205,
    (byte) 8,
    (byte) 122,
    (byte) 136,
    (byte) 56,
    (byte) 92,
    (byte) 131,
    (byte) 42,
    (byte) 40,
    (byte) 71,
    (byte) 219,
    (byte) 184,
    (byte) 199,
    (byte) 147,
    (byte) 164,
    (byte) 18,
    (byte) 83,
    byte.MaxValue,
    (byte) 135,
    (byte) 14,
    (byte) 49,
    (byte) 54,
    (byte) 33,
    (byte) 88,
    (byte) 72,
    (byte) 1,
    (byte) 142,
    (byte) 55,
    (byte) 116,
    (byte) 50,
    (byte) 202,
    (byte) 233,
    (byte) 177,
    (byte) 183,
    (byte) 171,
    (byte) 12,
    (byte) 215,
    (byte) 196,
    (byte) 86,
    (byte) 66,
    (byte) 38,
    (byte) 7,
    (byte) 152,
    (byte) 96 /*0x60*/,
    (byte) 217,
    (byte) 182,
    (byte) 185,
    (byte) 17,
    (byte) 64 /*0x40*/,
    (byte) 236,
    (byte) 32 /*0x20*/,
    (byte) 140,
    (byte) 189,
    (byte) 160 /*0xA0*/,
    (byte) 201,
    (byte) 132,
    (byte) 4,
    (byte) 73,
    (byte) 35,
    (byte) 241,
    (byte) 79,
    (byte) 80 /*0x50*/,
    (byte) 31 /*0x1F*/,
    (byte) 19,
    (byte) 220,
    (byte) 216,
    (byte) 192 /*0xC0*/,
    (byte) 158,
    (byte) 87,
    (byte) 227,
    (byte) 195,
    (byte) 123,
    (byte) 101,
    (byte) 59,
    (byte) 2,
    (byte) 143,
    (byte) 62,
    (byte) 232,
    (byte) 37,
    (byte) 146,
    (byte) 229,
    (byte) 21,
    (byte) 221,
    (byte) 253,
    (byte) 23,
    (byte) 169,
    (byte) 191,
    (byte) 212,
    (byte) 154,
    (byte) 126,
    (byte) 197,
    (byte) 57,
    (byte) 103,
    (byte) 254,
    (byte) 118,
    (byte) 157,
    (byte) 67,
    (byte) 167,
    (byte) 225,
    (byte) 208 /*0xD0*/,
    (byte) 245,
    (byte) 104,
    (byte) 242,
    (byte) 27,
    (byte) 52,
    (byte) 112 /*0x70*/,
    (byte) 5,
    (byte) 163,
    (byte) 138,
    (byte) 213,
    (byte) 121,
    (byte) 134,
    (byte) 168,
    (byte) 48 /*0x30*/,
    (byte) 198,
    (byte) 81,
    (byte) 75,
    (byte) 30,
    (byte) 166,
    (byte) 39,
    (byte) 246,
    (byte) 53,
    (byte) 210,
    (byte) 110,
    (byte) 36,
    (byte) 22,
    (byte) 130,
    (byte) 95,
    (byte) 218,
    (byte) 230,
    (byte) 117,
    (byte) 162,
    (byte) 239,
    (byte) 44,
    (byte) 178,
    (byte) 28,
    (byte) 159,
    (byte) 93,
    (byte) 111,
    (byte) 128 /*0x80*/,
    (byte) 10,
    (byte) 114,
    (byte) 68,
    (byte) 155,
    (byte) 108,
    (byte) 144 /*0x90*/,
    (byte) 11,
    (byte) 91,
    (byte) 51,
    (byte) 125,
    (byte) 90,
    (byte) 82,
    (byte) 243,
    (byte) 97,
    (byte) 161,
    (byte) 247,
    (byte) 176 /*0xB0*/,
    (byte) 214,
    (byte) 63 /*0x3F*/,
    (byte) 124,
    (byte) 109,
    (byte) 237,
    (byte) 20,
    (byte) 224 /*0xE0*/,
    (byte) 165,
    (byte) 61,
    (byte) 34,
    (byte) 179,
    (byte) 248,
    (byte) 137,
    (byte) 222,
    (byte) 113,
    (byte) 26,
    (byte) 175,
    (byte) 186,
    (byte) 181,
    (byte) 129
  };
  private static readonly byte[] SB3_sbox = new byte[256 /*0x0100*/]
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
  private static readonly byte[] SB4_sbox = new byte[256 /*0x0100*/]
  {
    (byte) 48 /*0x30*/,
    (byte) 104,
    (byte) 153,
    (byte) 27,
    (byte) 135,
    (byte) 185,
    (byte) 33,
    (byte) 120,
    (byte) 80 /*0x50*/,
    (byte) 57,
    (byte) 219,
    (byte) 225,
    (byte) 114,
    (byte) 9,
    (byte) 98,
    (byte) 60,
    (byte) 62,
    (byte) 126,
    (byte) 94,
    (byte) 142,
    (byte) 241,
    (byte) 160 /*0xA0*/,
    (byte) 204,
    (byte) 163,
    (byte) 42,
    (byte) 29,
    (byte) 251,
    (byte) 182,
    (byte) 214,
    (byte) 32 /*0x20*/,
    (byte) 196,
    (byte) 141,
    (byte) 129,
    (byte) 101,
    (byte) 245,
    (byte) 137,
    (byte) 203,
    (byte) 157,
    (byte) 119,
    (byte) 198,
    (byte) 87,
    (byte) 67,
    (byte) 86,
    (byte) 23,
    (byte) 212,
    (byte) 64 /*0x40*/,
    (byte) 26,
    (byte) 77,
    (byte) 192 /*0xC0*/,
    (byte) 99,
    (byte) 108,
    (byte) 227,
    (byte) 183,
    (byte) 200,
    (byte) 100,
    (byte) 106,
    (byte) 83,
    (byte) 170,
    (byte) 56,
    (byte) 152,
    (byte) 12,
    (byte) 244,
    (byte) 155,
    (byte) 237,
    (byte) 127 /*0x7F*/,
    (byte) 34,
    (byte) 118,
    (byte) 175,
    (byte) 221,
    (byte) 58,
    (byte) 11,
    (byte) 88,
    (byte) 103,
    (byte) 136,
    (byte) 6,
    (byte) 195,
    (byte) 53,
    (byte) 13,
    (byte) 1,
    (byte) 139,
    (byte) 140,
    (byte) 194,
    (byte) 230,
    (byte) 95,
    (byte) 2,
    (byte) 36,
    (byte) 117,
    (byte) 147,
    (byte) 102,
    (byte) 30,
    (byte) 229,
    (byte) 226,
    (byte) 84,
    (byte) 216,
    (byte) 16 /*0x10*/,
    (byte) 206,
    (byte) 122,
    (byte) 232,
    (byte) 8,
    (byte) 44,
    (byte) 18,
    (byte) 151,
    (byte) 50,
    (byte) 171,
    (byte) 180,
    (byte) 39,
    (byte) 10,
    (byte) 35,
    (byte) 223,
    (byte) 239,
    (byte) 202,
    (byte) 217,
    (byte) 184,
    (byte) 250,
    (byte) 220,
    (byte) 49,
    (byte) 107,
    (byte) 209,
    (byte) 173,
    (byte) 25,
    (byte) 73,
    (byte) 189,
    (byte) 81,
    (byte) 150,
    (byte) 238,
    (byte) 228,
    (byte) 168,
    (byte) 65,
    (byte) 218,
    byte.MaxValue,
    (byte) 205,
    (byte) 85,
    (byte) 134,
    (byte) 54,
    (byte) 190,
    (byte) 97,
    (byte) 82,
    (byte) 248,
    (byte) 187,
    (byte) 14,
    (byte) 130,
    (byte) 72,
    (byte) 105,
    (byte) 154,
    (byte) 224 /*0xE0*/,
    (byte) 71,
    (byte) 158,
    (byte) 92,
    (byte) 4,
    (byte) 75,
    (byte) 52,
    (byte) 21,
    (byte) 121,
    (byte) 38,
    (byte) 167,
    (byte) 222,
    (byte) 41,
    (byte) 174,
    (byte) 146,
    (byte) 215,
    (byte) 132,
    (byte) 233,
    (byte) 210,
    (byte) 186,
    (byte) 93,
    (byte) 243,
    (byte) 197,
    (byte) 176 /*0xB0*/,
    (byte) 191,
    (byte) 164,
    (byte) 59,
    (byte) 113,
    (byte) 68,
    (byte) 70,
    (byte) 43,
    (byte) 252,
    (byte) 235,
    (byte) 111,
    (byte) 213,
    (byte) 246,
    (byte) 20,
    (byte) 254,
    (byte) 124,
    (byte) 112 /*0x70*/,
    (byte) 90,
    (byte) 125,
    (byte) 253,
    (byte) 47,
    (byte) 24,
    (byte) 131,
    (byte) 22,
    (byte) 165,
    (byte) 145,
    (byte) 31 /*0x1F*/,
    (byte) 5,
    (byte) 149,
    (byte) 116,
    (byte) 169,
    (byte) 193,
    (byte) 91,
    (byte) 74,
    (byte) 133,
    (byte) 109,
    (byte) 19,
    (byte) 7,
    (byte) 79,
    (byte) 78,
    (byte) 69,
    (byte) 178,
    (byte) 15,
    (byte) 201,
    (byte) 28,
    (byte) 166,
    (byte) 188,
    (byte) 236,
    (byte) 115,
    (byte) 144 /*0x90*/,
    (byte) 123,
    (byte) 207,
    (byte) 89,
    (byte) 143,
    (byte) 161,
    (byte) 249,
    (byte) 45,
    (byte) 242,
    (byte) 177,
    (byte) 0,
    (byte) 148,
    (byte) 55,
    (byte) 159,
    (byte) 208 /*0xD0*/,
    (byte) 46,
    (byte) 156,
    (byte) 110,
    (byte) 40,
    (byte) 63 /*0x3F*/,
    (byte) 128 /*0x80*/,
    (byte) 240 /*0xF0*/,
    (byte) 61,
    (byte) 211,
    (byte) 37,
    (byte) 138,
    (byte) 181,
    (byte) 231,
    (byte) 66,
    (byte) 179,
    (byte) 199,
    (byte) 234,
    (byte) 247,
    (byte) 76,
    (byte) 17,
    (byte) 51,
    (byte) 3,
    (byte) 162,
    (byte) 172,
    (byte) 96 /*0x60*/
  };
  protected const int BlockSize = 16 /*0x10*/;
  private byte[][] m_roundKeys;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.m_roundKeys = parameters is KeyParameter keyParameter ? AriaEngine.KeySchedule(forEncryption, keyParameter.GetKey()) : throw new ArgumentException("invalid parameter passed to ARIA init - " + Platform.GetTypeName((object) parameters));
  }

  public virtual string AlgorithmName => "ARIA";

  public virtual int GetBlockSize() => 16 /*0x10*/;

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.m_roundKeys == null)
      throw new InvalidOperationException("ARIA engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 16 /*0x10*/, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer too short");
    byte[] numArray = new byte[16 /*0x10*/];
    Array.Copy((Array) input, inOff, (Array) numArray, 0, 16 /*0x10*/);
    int num1 = 0;
    int num2 = this.m_roundKeys.Length - 3;
    while (num1 < num2)
    {
      byte[] D1 = numArray;
      byte[][] roundKeys1 = this.m_roundKeys;
      int index1 = num1;
      int num3 = index1 + 1;
      byte[] RK1 = roundKeys1[index1];
      AriaEngine.FO(D1, RK1);
      byte[] D2 = numArray;
      byte[][] roundKeys2 = this.m_roundKeys;
      int index2 = num3;
      num1 = index2 + 1;
      byte[] RK2 = roundKeys2[index2];
      AriaEngine.FE(D2, RK2);
    }
    byte[] D = numArray;
    byte[][] roundKeys3 = this.m_roundKeys;
    int index3 = num1;
    int num4 = index3 + 1;
    byte[] RK = roundKeys3[index3];
    AriaEngine.FO(D, RK);
    byte[] z = numArray;
    byte[][] roundKeys4 = this.m_roundKeys;
    int index4 = num4;
    int index5 = index4 + 1;
    byte[] x = roundKeys4[index4];
    AriaEngine.Xor(z, x);
    AriaEngine.SL2(numArray);
    AriaEngine.Xor(numArray, this.m_roundKeys[index5]);
    Array.Copy((Array) numArray, 0, (Array) output, outOff, 16 /*0x10*/);
    return 16 /*0x10*/;
  }

  protected static void A(byte[] z)
  {
    byte num1 = z[0];
    byte num2 = z[1];
    byte num3 = z[2];
    byte num4 = z[3];
    byte num5 = z[4];
    byte num6 = z[5];
    byte num7 = z[6];
    byte num8 = z[7];
    byte num9 = z[8];
    byte num10 = z[9];
    byte num11 = z[10];
    byte num12 = z[11];
    byte num13 = z[12];
    byte num14 = z[13];
    byte num15 = z[14];
    byte num16 = z[15];
    z[0] = (byte) ((uint) num4 ^ (uint) num5 ^ (uint) num7 ^ (uint) num9 ^ (uint) num10 ^ (uint) num14 ^ (uint) num15);
    z[1] = (byte) ((uint) num3 ^ (uint) num6 ^ (uint) num8 ^ (uint) num9 ^ (uint) num10 ^ (uint) num13 ^ (uint) num16);
    z[2] = (byte) ((uint) num2 ^ (uint) num5 ^ (uint) num7 ^ (uint) num11 ^ (uint) num12 ^ (uint) num13 ^ (uint) num16);
    z[3] = (byte) ((uint) num1 ^ (uint) num6 ^ (uint) num8 ^ (uint) num11 ^ (uint) num12 ^ (uint) num14 ^ (uint) num15);
    z[4] = (byte) ((uint) num1 ^ (uint) num3 ^ (uint) num6 ^ (uint) num9 ^ (uint) num12 ^ (uint) num15 ^ (uint) num16);
    z[5] = (byte) ((uint) num2 ^ (uint) num4 ^ (uint) num5 ^ (uint) num10 ^ (uint) num11 ^ (uint) num15 ^ (uint) num16);
    z[6] = (byte) ((uint) num1 ^ (uint) num3 ^ (uint) num8 ^ (uint) num10 ^ (uint) num11 ^ (uint) num13 ^ (uint) num14);
    z[7] = (byte) ((uint) num2 ^ (uint) num4 ^ (uint) num7 ^ (uint) num9 ^ (uint) num12 ^ (uint) num13 ^ (uint) num14);
    z[8] = (byte) ((uint) num1 ^ (uint) num2 ^ (uint) num5 ^ (uint) num8 ^ (uint) num11 ^ (uint) num14 ^ (uint) num16);
    z[9] = (byte) ((uint) num1 ^ (uint) num2 ^ (uint) num6 ^ (uint) num7 ^ (uint) num12 ^ (uint) num13 ^ (uint) num15);
    z[10] = (byte) ((uint) num3 ^ (uint) num4 ^ (uint) num6 ^ (uint) num7 ^ (uint) num9 ^ (uint) num14 ^ (uint) num16);
    z[11] = (byte) ((uint) num3 ^ (uint) num4 ^ (uint) num5 ^ (uint) num8 ^ (uint) num10 ^ (uint) num13 ^ (uint) num15);
    z[12] = (byte) ((uint) num2 ^ (uint) num3 ^ (uint) num7 ^ (uint) num8 ^ (uint) num10 ^ (uint) num12 ^ (uint) num13);
    z[13] = (byte) ((uint) num1 ^ (uint) num4 ^ (uint) num7 ^ (uint) num8 ^ (uint) num9 ^ (uint) num11 ^ (uint) num14);
    z[14] = (byte) ((uint) num1 ^ (uint) num4 ^ (uint) num5 ^ (uint) num6 ^ (uint) num10 ^ (uint) num12 ^ (uint) num15);
    z[15] = (byte) ((uint) num2 ^ (uint) num3 ^ (uint) num5 ^ (uint) num6 ^ (uint) num9 ^ (uint) num11 ^ (uint) num16);
  }

  protected static void FE(byte[] D, byte[] RK)
  {
    AriaEngine.Xor(D, RK);
    AriaEngine.SL2(D);
    AriaEngine.A(D);
  }

  protected static void FO(byte[] D, byte[] RK)
  {
    AriaEngine.Xor(D, RK);
    AriaEngine.SL1(D);
    AriaEngine.A(D);
  }

  protected static byte[][] KeySchedule(bool forEncryption, byte[] K)
  {
    int length = K.Length;
    if (length < 16 /*0x10*/ || length > 32 /*0x20*/ || (length & 7) != 0)
      throw new ArgumentException("Key length not 128/192/256 bits.");
    int index1 = (length >> 3) - 2;
    byte[] RK1 = AriaEngine.C[index1];
    byte[] RK2 = AriaEngine.C[(index1 + 1) % 3];
    byte[] RK3 = AriaEngine.C[(index1 + 2) % 3];
    byte[] numArray1 = new byte[16 /*0x10*/];
    byte[] numArray2 = new byte[16 /*0x10*/];
    Array.Copy((Array) K, 0, (Array) numArray1, 0, 16 /*0x10*/);
    Array.Copy((Array) K, 16 /*0x10*/, (Array) numArray2, 0, length - 16 /*0x10*/);
    byte[] numArray3 = new byte[16 /*0x10*/];
    byte[] numArray4 = new byte[16 /*0x10*/];
    byte[] numArray5 = new byte[16 /*0x10*/];
    byte[] numArray6 = new byte[16 /*0x10*/];
    Array.Copy((Array) numArray1, 0, (Array) numArray3, 0, 16 /*0x10*/);
    Array.Copy((Array) numArray3, 0, (Array) numArray4, 0, 16 /*0x10*/);
    AriaEngine.FO(numArray4, RK1);
    AriaEngine.Xor(numArray4, numArray2);
    Array.Copy((Array) numArray4, 0, (Array) numArray5, 0, 16 /*0x10*/);
    AriaEngine.FE(numArray5, RK2);
    AriaEngine.Xor(numArray5, numArray3);
    Array.Copy((Array) numArray5, 0, (Array) numArray6, 0, 16 /*0x10*/);
    AriaEngine.FO(numArray6, RK3);
    AriaEngine.Xor(numArray6, numArray4);
    int num = 12 + index1 * 2;
    byte[][] keys = new byte[num + 1][];
    keys[0] = AriaEngine.KeyScheduleRound(numArray3, numArray4, 19);
    keys[1] = AriaEngine.KeyScheduleRound(numArray4, numArray5, 19);
    keys[2] = AriaEngine.KeyScheduleRound(numArray5, numArray6, 19);
    keys[3] = AriaEngine.KeyScheduleRound(numArray6, numArray3, 19);
    keys[4] = AriaEngine.KeyScheduleRound(numArray3, numArray4, 31 /*0x1F*/);
    keys[5] = AriaEngine.KeyScheduleRound(numArray4, numArray5, 31 /*0x1F*/);
    keys[6] = AriaEngine.KeyScheduleRound(numArray5, numArray6, 31 /*0x1F*/);
    keys[7] = AriaEngine.KeyScheduleRound(numArray6, numArray3, 31 /*0x1F*/);
    keys[8] = AriaEngine.KeyScheduleRound(numArray3, numArray4, 67);
    keys[9] = AriaEngine.KeyScheduleRound(numArray4, numArray5, 67);
    keys[10] = AriaEngine.KeyScheduleRound(numArray5, numArray6, 67);
    keys[11] = AriaEngine.KeyScheduleRound(numArray6, numArray3, 67);
    keys[12] = AriaEngine.KeyScheduleRound(numArray3, numArray4, 97);
    if (num > 12)
    {
      keys[13] = AriaEngine.KeyScheduleRound(numArray4, numArray5, 97);
      keys[14] = AriaEngine.KeyScheduleRound(numArray5, numArray6, 97);
      if (num > 14)
      {
        keys[15] = AriaEngine.KeyScheduleRound(numArray6, numArray3, 97);
        keys[16 /*0x10*/] = AriaEngine.KeyScheduleRound(numArray3, numArray4, 109);
      }
    }
    if (!forEncryption)
    {
      AriaEngine.ReverseKeys(keys);
      for (int index2 = 1; index2 < num; ++index2)
        AriaEngine.A(keys[index2]);
    }
    return keys;
  }

  protected static byte[] KeyScheduleRound(byte[] w, byte[] wr, int n)
  {
    byte[] numArray = new byte[16 /*0x10*/];
    int num1 = n >> 3;
    int num2 = n & 7;
    int num3 = 8 - num2;
    int num4 = (int) wr[15 - num1] & (int) byte.MaxValue;
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      int num5 = (int) wr[index - num1 & 15] & (int) byte.MaxValue;
      int num6 = (num4 << num3 | num5 >> num2) ^ (int) w[index] & (int) byte.MaxValue;
      numArray[index] = (byte) num6;
      num4 = num5;
    }
    return numArray;
  }

  protected static void ReverseKeys(byte[][] keys)
  {
    int length = keys.Length;
    int num1 = length / 2;
    int num2 = length - 1;
    for (int index = 0; index < num1; ++index)
    {
      byte[] key = keys[index];
      keys[index] = keys[num2 - index];
      keys[num2 - index] = key;
    }
  }

  protected static byte SB1(byte x) => AriaEngine.SB1_sbox[(int) x & (int) byte.MaxValue];

  protected static byte SB2(byte x) => AriaEngine.SB2_sbox[(int) x & (int) byte.MaxValue];

  protected static byte SB3(byte x) => AriaEngine.SB3_sbox[(int) x & (int) byte.MaxValue];

  protected static byte SB4(byte x) => AriaEngine.SB4_sbox[(int) x & (int) byte.MaxValue];

  protected static void SL1(byte[] z)
  {
    z[0] = AriaEngine.SB1(z[0]);
    z[1] = AriaEngine.SB2(z[1]);
    z[2] = AriaEngine.SB3(z[2]);
    z[3] = AriaEngine.SB4(z[3]);
    z[4] = AriaEngine.SB1(z[4]);
    z[5] = AriaEngine.SB2(z[5]);
    z[6] = AriaEngine.SB3(z[6]);
    z[7] = AriaEngine.SB4(z[7]);
    z[8] = AriaEngine.SB1(z[8]);
    z[9] = AriaEngine.SB2(z[9]);
    z[10] = AriaEngine.SB3(z[10]);
    z[11] = AriaEngine.SB4(z[11]);
    z[12] = AriaEngine.SB1(z[12]);
    z[13] = AriaEngine.SB2(z[13]);
    z[14] = AriaEngine.SB3(z[14]);
    z[15] = AriaEngine.SB4(z[15]);
  }

  protected static void SL2(byte[] z)
  {
    z[0] = AriaEngine.SB3(z[0]);
    z[1] = AriaEngine.SB4(z[1]);
    z[2] = AriaEngine.SB1(z[2]);
    z[3] = AriaEngine.SB2(z[3]);
    z[4] = AriaEngine.SB3(z[4]);
    z[5] = AriaEngine.SB4(z[5]);
    z[6] = AriaEngine.SB1(z[6]);
    z[7] = AriaEngine.SB2(z[7]);
    z[8] = AriaEngine.SB3(z[8]);
    z[9] = AriaEngine.SB4(z[9]);
    z[10] = AriaEngine.SB1(z[10]);
    z[11] = AriaEngine.SB2(z[11]);
    z[12] = AriaEngine.SB3(z[12]);
    z[13] = AriaEngine.SB4(z[13]);
    z[14] = AriaEngine.SB1(z[14]);
    z[15] = AriaEngine.SB2(z[15]);
  }

  protected static void Xor(byte[] z, byte[] x)
  {
    for (int index = 0; index < 16 /*0x10*/; ++index)
      z[index] ^= x[index];
  }
}
