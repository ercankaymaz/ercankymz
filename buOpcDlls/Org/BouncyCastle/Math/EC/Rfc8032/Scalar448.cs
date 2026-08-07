// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc8032.Scalar448
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc8032;

internal static class Scalar448
{
  internal const int Size = 14;
  private const int ScalarBytes = 57;
  private const ulong M26UL = 67108863 /*0x03FFFFFF*/;
  private const ulong M28UL = 268435455 /*0x0FFFFFFF*/;
  private const int TargetLength = 447;
  private static readonly uint[] L = new uint[14]
  {
    2874688755U,
    595116690U,
    2378534741U,
    560775794U,
    2933274256U,
    3293502281U,
    2093622249U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    1073741823U /*0x3FFFFFFF*/
  };
  private static readonly uint[] LSq = new uint[28]
  {
    463601321U,
    3249404856U,
    1239460018U,
    3105617207U,
    3882145813U,
    1160071467U,
    2729996653U,
    1256291574U,
    3124512708U,
    4054436884U,
    2118977290U,
    2449812427U,
    2676112242U,
    3275762323U,
    1437344377U,
    2445041993U,
    1189267370U,
    280387897U,
    3614120776U,
    3794234788U,
    3194294772U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    268435455U /*0x0FFFFFFF*/
  };
  private const int L_0 = 78101261;
  private const int L_1 = 141809365;
  private const int L_2 = 175155932;
  private const int L_3 = 64542499;
  private const int L_4 = 158326419;
  private const int L_5 = 191173276;
  private const int L_6 = 104575268;
  private const int L_7 = 137584065;
  private const int L4_0 = 43969588;
  private const int L4_1 = 30366549;
  private const int L4_2 = 163752818;
  private const int L4_3 = 258169998;
  private const int L4_4 = 96434764;
  private const int L4_5 = 227822194;
  private const int L4_6 = 149865618;
  private const int L4_7 = 550336261;

  internal static bool CheckVar(byte[] s, uint[] n)
  {
    if (s[56] != (byte) 0)
      return false;
    Scalar448.Decode(s, n);
    return !Nat.Gte(14, n, Scalar448.L);
  }

  internal static void Decode(byte[] k, uint[] n) => Codec.Decode32(k, 0, n, 0, 14);

  internal static void GetOrderWnafVar(int width, sbyte[] ws)
  {
    Wnaf.GetSignedVar(Scalar448.L, width, ws);
  }

  internal static void Multiply225Var(uint[] x, uint[] y225, uint[] z)
  {
    uint[] numArray1 = new uint[22];
    Nat.Mul(y225, 0, 8, x, 0, 14, numArray1, 0);
    if ((int) y225[7] < 0)
    {
      int num = (int) Nat.AddTo(14, Scalar448.L, 0, numArray1, 8);
      Nat.SubFrom(14, x, 0, numArray1, 8);
    }
    byte[] numArray2 = new byte[114];
    Codec.Encode32(numArray1, 0, 22, numArray2, 0);
    Scalar448.Decode(Scalar448.Reduce(numArray2), z);
  }

  internal static byte[] Reduce(byte[] n)
  {
    byte[] bs = new byte[57];
    ulong num1 = (ulong) Codec.Decode32(n, 0);
    ulong num2 = (ulong) (Codec.Decode24(n, 4) << 4);
    ulong num3 = (ulong) Codec.Decode32(n, 7);
    ulong num4 = (ulong) (Codec.Decode24(n, 11) << 4);
    ulong num5 = (ulong) Codec.Decode32(n, 14);
    ulong num6 = (ulong) (Codec.Decode24(n, 18) << 4);
    ulong num7 = (ulong) Codec.Decode32(n, 21);
    ulong num8 = (ulong) (Codec.Decode24(n, 25) << 4);
    ulong num9 = (ulong) Codec.Decode32(n, 28);
    ulong num10 = (ulong) (Codec.Decode24(n, 32 /*0x20*/) << 4);
    ulong num11 = (ulong) Codec.Decode32(n, 35);
    ulong num12 = (ulong) (Codec.Decode24(n, 39) << 4);
    ulong num13 = (ulong) Codec.Decode32(n, 42);
    ulong num14 = (ulong) (Codec.Decode24(n, 46) << 4);
    ulong num15 = (ulong) Codec.Decode32(n, 49);
    ulong num16 = (ulong) (Codec.Decode24(n, 53) << 4);
    ulong num17 = (ulong) Codec.Decode32(n, 56);
    ulong num18 = (ulong) (Codec.Decode24(n, 60) << 4);
    ulong num19 = (ulong) Codec.Decode32(n, 63 /*0x3F*/);
    ulong num20 = (ulong) (Codec.Decode24(n, 67) << 4);
    ulong num21 = (ulong) Codec.Decode32(n, 70);
    ulong num22 = (ulong) (Codec.Decode24(n, 74) << 4);
    ulong num23 = (ulong) Codec.Decode32(n, 77);
    ulong num24 = (ulong) (Codec.Decode24(n, 81) << 4);
    ulong num25 = (ulong) Codec.Decode32(n, 84);
    ulong num26 = (ulong) (Codec.Decode24(n, 88) << 4);
    ulong num27 = (ulong) Codec.Decode32(n, 91);
    ulong num28 = (ulong) (Codec.Decode24(n, 95) << 4);
    ulong num29 = (ulong) Codec.Decode32(n, 98);
    ulong num30 = (ulong) (Codec.Decode24(n, 102) << 4);
    ulong num31 = (ulong) Codec.Decode32(n, 105);
    ulong num32 = (ulong) (Codec.Decode24(n, 109) << 4);
    ulong num33 = (ulong) Codec.Decode16(n, 112 /*0x70*/);
    ulong num34 = num17 + num33 * 43969588UL;
    ulong num35 = num18 + num33 * 30366549UL;
    ulong num36 = num19 + num33 * 163752818UL;
    ulong num37 = num20 + num33 * 258169998UL;
    ulong num38 = num21 + num33 * 96434764UL;
    ulong num39 = num22 + num33 * 227822194UL;
    ulong num40 = num23 + num33 * 149865618UL;
    ulong num41 = num24 + num33 * 550336261UL;
    ulong num42 = num32 + (num31 >> 28);
    ulong num43 = num31 & 268435455UL /*0x0FFFFFFF*/;
    ulong num44 = num16 + num42 * 43969588UL;
    ulong num45 = num34 + num42 * 30366549UL;
    ulong num46 = num35 + num42 * 163752818UL;
    ulong num47 = num36 + num42 * 258169998UL;
    ulong num48 = num37 + num42 * 96434764UL;
    ulong num49 = num38 + num42 * 227822194UL;
    ulong num50 = num39 + num42 * 149865618UL;
    ulong num51 = num40 + num42 * 550336261UL;
    ulong num52 = num15 + num43 * 43969588UL;
    ulong num53 = num44 + num43 * 30366549UL;
    ulong num54 = num45 + num43 * 163752818UL;
    ulong num55 = num46 + num43 * 258169998UL;
    ulong num56 = num47 + num43 * 96434764UL;
    ulong num57 = num48 + num43 * 227822194UL;
    ulong num58 = num49 + num43 * 149865618UL;
    ulong num59 = num50 + num43 * 550336261UL;
    ulong num60 = num30 + (num29 >> 28);
    ulong num61 = num29 & 268435455UL /*0x0FFFFFFF*/;
    ulong num62 = num14 + num60 * 43969588UL;
    ulong num63 = num52 + num60 * 30366549UL;
    ulong num64 = num53 + num60 * 163752818UL;
    ulong num65 = num54 + num60 * 258169998UL;
    ulong num66 = num55 + num60 * 96434764UL;
    ulong num67 = num56 + num60 * 227822194UL;
    ulong num68 = num57 + num60 * 149865618UL;
    ulong num69 = num58 + num60 * 550336261UL;
    ulong num70 = num13 + num61 * 43969588UL;
    ulong num71 = num62 + num61 * 30366549UL;
    ulong num72 = num63 + num61 * 163752818UL;
    ulong num73 = num64 + num61 * 258169998UL;
    ulong num74 = num65 + num61 * 96434764UL;
    ulong num75 = num66 + num61 * 227822194UL;
    ulong num76 = num67 + num61 * 149865618UL;
    ulong num77 = num68 + num61 * 550336261UL;
    ulong num78 = num28 + (num27 >> 28);
    ulong num79 = num27 & 268435455UL /*0x0FFFFFFF*/;
    ulong num80 = num12 + num78 * 43969588UL;
    ulong num81 = num70 + num78 * 30366549UL;
    ulong num82 = num71 + num78 * 163752818UL;
    ulong num83 = num72 + num78 * 258169998UL;
    ulong num84 = num73 + num78 * 96434764UL;
    ulong num85 = num74 + num78 * 227822194UL;
    ulong num86 = num75 + num78 * 149865618UL;
    ulong num87 = num76 + num78 * 550336261UL;
    ulong num88 = num11 + num79 * 43969588UL;
    ulong num89 = num80 + num79 * 30366549UL;
    ulong num90 = num81 + num79 * 163752818UL;
    ulong num91 = num82 + num79 * 258169998UL;
    ulong num92 = num83 + num79 * 96434764UL;
    ulong num93 = num84 + num79 * 227822194UL;
    ulong num94 = num85 + num79 * 149865618UL;
    ulong num95 = num86 + num79 * 550336261UL;
    ulong num96 = num26 + (num25 >> 28);
    ulong num97 = num25 & 268435455UL /*0x0FFFFFFF*/;
    ulong num98 = num10 + num96 * 43969588UL;
    ulong num99 = num88 + num96 * 30366549UL;
    ulong num100 = num89 + num96 * 163752818UL;
    ulong num101 = num90 + num96 * 258169998UL;
    ulong num102 = num91 + num96 * 96434764UL;
    ulong num103 = num92 + num96 * 227822194UL;
    ulong num104 = num93 + num96 * 149865618UL;
    ulong num105 = num94 + num96 * 550336261UL;
    ulong num106 = num59 + (num69 >> 28);
    ulong num107 = num69 & 268435455UL /*0x0FFFFFFF*/;
    ulong num108 = num51 + (num106 >> 28);
    ulong num109 = num106 & 268435455UL /*0x0FFFFFFF*/;
    ulong num110 = num41 + (num108 >> 28);
    ulong num111 = num108 & 268435455UL /*0x0FFFFFFF*/;
    ulong num112 = num97 + (num110 >> 28);
    ulong num113 = num110 & 268435455UL /*0x0FFFFFFF*/;
    ulong num114 = num9 + num112 * 43969588UL;
    ulong num115 = num98 + num112 * 30366549UL;
    ulong num116 = num99 + num112 * 163752818UL;
    ulong num117 = num100 + num112 * 258169998UL;
    ulong num118 = num101 + num112 * 96434764UL;
    ulong num119 = num102 + num112 * 227822194UL;
    ulong num120 = num103 + num112 * 149865618UL;
    ulong num121 = num104 + num112 * 550336261UL;
    ulong num122 = num8 + num113 * 43969588UL;
    ulong num123 = num114 + num113 * 30366549UL;
    ulong num124 = num115 + num113 * 163752818UL;
    ulong num125 = num116 + num113 * 258169998UL;
    ulong num126 = num117 + num113 * 96434764UL;
    ulong num127 = num118 + num113 * 227822194UL;
    ulong num128 = num119 + num113 * 149865618UL;
    ulong num129 = num120 + num113 * 550336261UL;
    ulong num130 = num7 + num111 * 43969588UL;
    ulong num131 = num122 + num111 * 30366549UL;
    ulong num132 = num123 + num111 * 163752818UL;
    ulong num133 = num124 + num111 * 258169998UL;
    ulong num134 = num125 + num111 * 96434764UL;
    ulong num135 = num126 + num111 * 227822194UL;
    ulong num136 = num127 + num111 * 149865618UL;
    ulong num137 = num128 + num111 * 550336261UL;
    ulong num138 = num87 + (num95 >> 28);
    ulong num139 = num95 & 268435455UL /*0x0FFFFFFF*/;
    ulong num140 = num77 + (num138 >> 28);
    ulong num141 = num138 & 268435455UL /*0x0FFFFFFF*/;
    ulong num142 = num107 + (num140 >> 28);
    ulong num143 = num140 & 268435455UL /*0x0FFFFFFF*/;
    ulong num144 = num109 + (num142 >> 28);
    ulong num145 = num142 & 268435455UL /*0x0FFFFFFF*/;
    ulong num146 = num6 + num144 * 43969588UL;
    ulong num147 = num130 + num144 * 30366549UL;
    ulong num148 = num131 + num144 * 163752818UL;
    ulong num149 = num132 + num144 * 258169998UL;
    ulong num150 = num133 + num144 * 96434764UL;
    ulong num151 = num134 + num144 * 227822194UL;
    ulong num152 = num135 + num144 * 149865618UL;
    ulong num153 = num136 + num144 * 550336261UL;
    ulong num154 = num5 + num145 * 43969588UL;
    ulong num155 = num146 + num145 * 30366549UL;
    ulong num156 = num147 + num145 * 163752818UL;
    ulong num157 = num148 + num145 * 258169998UL;
    ulong num158 = num149 + num145 * 96434764UL;
    ulong num159 = num150 + num145 * 227822194UL;
    ulong num160 = num151 + num145 * 149865618UL;
    ulong num161 = num152 + num145 * 550336261UL;
    ulong num162 = num4 + num143 * 43969588UL;
    ulong num163 = num154 + num143 * 30366549UL;
    ulong num164 = num155 + num143 * 163752818UL;
    ulong num165 = num156 + num143 * 258169998UL;
    ulong num166 = num157 + num143 * 96434764UL;
    ulong num167 = num158 + num143 * 227822194UL;
    ulong num168 = num159 + num143 * 149865618UL;
    ulong num169 = num160 + num143 * 550336261UL;
    ulong num170 = num121 + (num129 >> 28);
    ulong num171 = num129 & 268435455UL /*0x0FFFFFFF*/;
    ulong num172 = num105 + (num170 >> 28);
    ulong num173 = num170 & 268435455UL /*0x0FFFFFFF*/;
    ulong num174 = num139 + (num172 >> 28);
    ulong num175 = num172 & 268435455UL /*0x0FFFFFFF*/;
    ulong num176 = num141 + (num174 >> 28);
    ulong num177 = num174 & 268435455UL /*0x0FFFFFFF*/;
    ulong num178 = num3 + num176 * 43969588UL;
    ulong num179 = num162 + num176 * 30366549UL;
    ulong num180 = num163 + num176 * 163752818UL;
    ulong num181 = num164 + num176 * 258169998UL;
    ulong num182 = num165 + num176 * 96434764UL;
    ulong num183 = num166 + num176 * 227822194UL;
    ulong num184 = num167 + num176 * 149865618UL;
    ulong num185 = num168 + num176 * 550336261UL;
    ulong num186 = num2 + num177 * 43969588UL;
    ulong num187 = num178 + num177 * 30366549UL;
    ulong num188 = num179 + num177 * 163752818UL;
    ulong num189 = num180 + num177 * 258169998UL;
    ulong num190 = num181 + num177 * 96434764UL;
    ulong num191 = num182 + num177 * 227822194UL;
    ulong num192 = num183 + num177 * 149865618UL;
    ulong num193 = num184 + num177 * 550336261UL;
    ulong num194 = num175 * 4UL + (num173 >> 26);
    ulong num195 = num173 & 67108863UL /*0x03FFFFFF*/;
    ulong num196 = num194 + 1UL;
    ulong num197 = num1 + num196 * 78101261UL;
    ulong num198 = num186 + num196 * 141809365UL;
    ulong num199 = num187 + num196 * 175155932UL;
    ulong num200 = num188 + num196 * 64542499UL;
    ulong num201 = num189 + num196 * 158326419UL;
    ulong num202 = num190 + num196 * 191173276UL;
    ulong num203 = num191 + num196 * 104575268UL;
    ulong num204 = num192 + num196 * 137584065UL;
    ulong num205 = num198 + (num197 >> 28);
    ulong num206 = num197 & 268435455UL /*0x0FFFFFFF*/;
    ulong num207 = num199 + (num205 >> 28);
    ulong num208 = num205 & 268435455UL /*0x0FFFFFFF*/;
    ulong num209 = num200 + (num207 >> 28);
    ulong num210 = num207 & 268435455UL /*0x0FFFFFFF*/;
    ulong num211 = num201 + (num209 >> 28);
    ulong num212 = num209 & 268435455UL /*0x0FFFFFFF*/;
    ulong num213 = num202 + (num211 >> 28);
    ulong num214 = num211 & 268435455UL /*0x0FFFFFFF*/;
    ulong num215 = num203 + (num213 >> 28);
    ulong num216 = num213 & 268435455UL /*0x0FFFFFFF*/;
    ulong num217 = num204 + (num215 >> 28);
    ulong num218 = num215 & 268435455UL /*0x0FFFFFFF*/;
    ulong num219 = num193 + (num217 >> 28);
    ulong num220 = num217 & 268435455UL /*0x0FFFFFFF*/;
    ulong num221 = num185 + (num219 >> 28);
    ulong num222 = num219 & 268435455UL /*0x0FFFFFFF*/;
    ulong num223 = num169 + (num221 >> 28);
    ulong num224 = num221 & 268435455UL /*0x0FFFFFFF*/;
    ulong num225 = num161 + (num223 >> 28);
    ulong num226 = num223 & 268435455UL /*0x0FFFFFFF*/;
    ulong num227 = num153 + (num225 >> 28);
    ulong num228 = num225 & 268435455UL /*0x0FFFFFFF*/;
    ulong num229 = num137 + (num227 >> 28);
    ulong num230 = num227 & 268435455UL /*0x0FFFFFFF*/;
    ulong num231 = num171 + (num229 >> 28);
    ulong num232 = num229 & 268435455UL /*0x0FFFFFFF*/;
    ulong num233 = num195 + (num231 >> 28);
    ulong num234 = num231 & 268435455UL /*0x0FFFFFFF*/;
    ulong num235 = num233 >> 26;
    ulong num236 = num233 & 67108863UL /*0x03FFFFFF*/;
    ulong num237 = num235 - 1UL;
    ulong num238 = num206 - (num237 & 78101261UL);
    ulong num239 = num208 - (num237 & 141809365UL);
    ulong num240 = num210 - (num237 & 175155932UL);
    ulong num241 = num212 - (num237 & 64542499UL);
    ulong num242 = num214 - (num237 & 158326419UL);
    ulong num243 = num216 - (num237 & 191173276UL);
    ulong num244 = num218 - (num237 & 104575268UL);
    ulong num245 = num220 - (num237 & 137584065UL);
    ulong num246 = num239 + (num238 >> 28);
    ulong num247 = num238 & 268435455UL /*0x0FFFFFFF*/;
    ulong num248 = num240 + (num246 >> 28);
    ulong num249 = num246 & 268435455UL /*0x0FFFFFFF*/;
    ulong num250 = num241 + (num248 >> 28);
    ulong num251 = num248 & 268435455UL /*0x0FFFFFFF*/;
    ulong num252 = num242 + (num250 >> 28);
    ulong num253 = num250 & 268435455UL /*0x0FFFFFFF*/;
    ulong num254 = num243 + (num252 >> 28);
    ulong num255 = num252 & 268435455UL /*0x0FFFFFFF*/;
    ulong num256 = num244 + (num254 >> 28);
    ulong num257 = num254 & 268435455UL /*0x0FFFFFFF*/;
    ulong num258 = num245 + (num256 >> 28);
    ulong num259 = num256 & 268435455UL /*0x0FFFFFFF*/;
    ulong num260 = num222 + (num258 >> 28);
    ulong num261 = num258 & 268435455UL /*0x0FFFFFFF*/;
    ulong num262 = num224 + (num260 >> 28);
    ulong num263 = num260 & 268435455UL /*0x0FFFFFFF*/;
    ulong num264 = num226 + (num262 >> 28);
    ulong num265 = num262 & 268435455UL /*0x0FFFFFFF*/;
    ulong num266 = num228 + (num264 >> 28);
    ulong num267 = num264 & 268435455UL /*0x0FFFFFFF*/;
    ulong num268 = num230 + (num266 >> 28);
    ulong num269 = num266 & 268435455UL /*0x0FFFFFFF*/;
    ulong num270 = num232 + (num268 >> 28);
    ulong num271 = num268 & 268435455UL /*0x0FFFFFFF*/;
    ulong num272 = num234 + (num270 >> 28);
    ulong num273 = num270 & 268435455UL /*0x0FFFFFFF*/;
    ulong num274 = num236 + (num272 >> 28);
    ulong num275 = num272 & 268435455UL /*0x0FFFFFFF*/;
    Codec.Encode56(num247 | num249 << 28, bs, 0);
    Codec.Encode56(num251 | num253 << 28, bs, 7);
    Codec.Encode56(num255 | num257 << 28, bs, 14);
    Codec.Encode56(num259 | num261 << 28, bs, 21);
    Codec.Encode56(num263 | num265 << 28, bs, 28);
    Codec.Encode56(num267 | num269 << 28, bs, 35);
    Codec.Encode56(num271 | num273 << 28, bs, 42);
    Codec.Encode56(num275 | num274 << 28, bs, 49);
    return bs;
  }

  internal static void ReduceBasisVar(uint[] k, uint[] z0, uint[] z1)
  {
    uint[] x1 = new uint[28];
    Array.Copy((Array) Scalar448.LSq, (Array) x1, 28);
    uint[] y1 = new uint[28];
    Nat448.Square(k, y1);
    ++y1[0];
    uint[] numArray = new uint[28];
    Nat448.Mul(Scalar448.L, k, numArray);
    uint[] x2 = new uint[8];
    Array.Copy((Array) Scalar448.L, (Array) x2, 8);
    uint[] x3 = new uint[8];
    uint[] y2 = new uint[8];
    Array.Copy((Array) k, (Array) y2, 8);
    uint[] y3 = new uint[8];
    y3[0] = 1U;
    int last = 27;
    int bitLengthPositive = ScalarUtilities.GetBitLengthPositive(27, y1);
    while (bitLengthPositive > 447)
    {
      int num = ScalarUtilities.GetBitLength(last, numArray) - bitLengthPositive;
      int s = num & ~(num >> 31 /*0x1F*/);
      if ((int) numArray[last] < 0)
      {
        ScalarUtilities.AddShifted_NP(last, s, x1, y1, numArray);
        ScalarUtilities.AddShifted_UV(7, s, x2, x3, y2, y3);
      }
      else
      {
        ScalarUtilities.SubShifted_NP(last, s, x1, y1, numArray);
        ScalarUtilities.SubShifted_UV(7, s, x2, x3, y2, y3);
      }
      if (ScalarUtilities.LessThan(last, x1, y1))
      {
        ScalarUtilities.Swap(ref x2, ref y2);
        ScalarUtilities.Swap(ref x3, ref y3);
        ScalarUtilities.Swap(ref x1, ref y1);
        last = bitLengthPositive >> 5;
        bitLengthPositive = ScalarUtilities.GetBitLengthPositive(last, y1);
      }
    }
    Array.Copy((Array) y2, (Array) z0, 8);
    Array.Copy((Array) y3, (Array) z1, 8);
  }

  internal static void ToSignedDigits(int bits, uint[] x, uint[] z)
  {
    z[14] = (uint) (1 << bits - 448) + Nat.CAdd(14, ~(int) x[0] & 1, x, Scalar448.L, z);
    int num = (int) Nat.ShiftDownBit(15, z, 0U);
  }
}
