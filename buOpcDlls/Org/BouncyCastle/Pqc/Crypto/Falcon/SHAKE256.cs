// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.SHAKE256
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class SHAKE256
{
  private ulong[] A;
  private byte[] dubf;
  private ulong dptr;
  private ulong[] RC = new ulong[24]
  {
    1UL,
    32898UL,
    9223372036854808714UL /*0x800000000000808A*/,
    9223372039002292224UL /*0x8000000080008000*/,
    32907UL,
    2147483649UL /*0x80000001*/,
    9223372039002292353UL /*0x8000000080008081*/,
    9223372036854808585UL /*0x8000000000008009*/,
    138UL,
    136UL,
    2147516425UL /*0x80008009*/,
    2147483658UL /*0x8000000A*/,
    2147516555UL,
    9223372036854775947UL /*0x800000000000008B*/,
    9223372036854808713UL /*0x8000000000008089*/,
    9223372036854808579UL /*0x8000000000008003*/,
    9223372036854808578UL /*0x8000000000008002*/,
    9223372036854775936UL /*0x8000000000000080*/,
    32778UL,
    9223372039002259466UL /*0x800000008000000A*/,
    9223372039002292353UL /*0x8000000080008081*/,
    9223372036854808704UL /*0x8000000000008080*/,
    2147483649UL /*0x80000001*/,
    9223372039002292232UL /*0x8000000080008008*/
  };

  private void process_block(ulong[] A)
  {
    A[1] = ~A[1];
    A[2] = ~A[2];
    A[8] = ~A[8];
    A[12] = ~A[12];
    A[17] = ~A[17];
    A[20] = ~A[20];
    for (int index = 0; index < 24; index += 2)
    {
      ulong num1 = A[1] ^ A[6];
      ulong num2 = A[11] ^ A[16 /*0x10*/];
      ulong num3 = num1 ^ A[21] ^ num2;
      ulong num4 = num3 << 1 | num3 >> 63 /*0x3F*/;
      ulong num5 = A[4] ^ A[9];
      ulong num6 = A[14] ^ A[19];
      ulong num7 = num4 ^ A[24] ^ num5 ^ num6;
      ulong num8 = A[2] ^ A[7];
      ulong num9 = A[12] ^ A[17];
      ulong num10 = num8 ^ A[22] ^ num9;
      ulong num11 = num10 << 1 | num10 >> 63 /*0x3F*/;
      ulong num12 = A[0] ^ A[5];
      ulong num13 = A[10] ^ A[15];
      ulong num14 = num11 ^ A[20] ^ num12 ^ num13;
      ulong num15 = A[3] ^ A[8];
      ulong num16 = A[13] ^ A[18];
      ulong num17 = num15 ^ A[23] ^ num16;
      ulong num18 = num17 << 1 | num17 >> 63 /*0x3F*/;
      ulong num19 = A[1] ^ A[6];
      ulong num20 = A[11] ^ A[16 /*0x10*/];
      ulong num21 = num18 ^ A[21] ^ num19 ^ num20;
      ulong num22 = A[4] ^ A[9];
      ulong num23 = A[14] ^ A[19];
      ulong num24 = num22 ^ A[24] ^ num23;
      ulong num25 = num24 << 1 | num24 >> 63 /*0x3F*/;
      ulong num26 = A[2] ^ A[7];
      ulong num27 = A[12] ^ A[17];
      ulong num28 = num25 ^ A[22] ^ num26 ^ num27;
      ulong num29 = A[0] ^ A[5];
      ulong num30 = A[10] ^ A[15];
      ulong num31 = num29 ^ A[20] ^ num30;
      ulong num32 = num31 << 1 | num31 >> 63 /*0x3F*/;
      ulong num33 = A[3] ^ A[8];
      ulong num34 = A[13] ^ A[18];
      ulong num35 = num32 ^ A[23] ^ num33 ^ num34;
      A[0] = A[0] ^ num7;
      A[5] = A[5] ^ num7;
      A[10] = A[10] ^ num7;
      A[15] = A[15] ^ num7;
      A[20] = A[20] ^ num7;
      A[1] = A[1] ^ num14;
      A[6] = A[6] ^ num14;
      A[11] = A[11] ^ num14;
      A[16 /*0x10*/] = A[16 /*0x10*/] ^ num14;
      A[21] = A[21] ^ num14;
      A[2] = A[2] ^ num21;
      A[7] = A[7] ^ num21;
      A[12] = A[12] ^ num21;
      A[17] = A[17] ^ num21;
      A[22] = A[22] ^ num21;
      A[3] = A[3] ^ num28;
      A[8] = A[8] ^ num28;
      A[13] = A[13] ^ num28;
      A[18] = A[18] ^ num28;
      A[23] = A[23] ^ num28;
      A[4] = A[4] ^ num35;
      A[9] = A[9] ^ num35;
      A[14] = A[14] ^ num35;
      A[19] = A[19] ^ num35;
      A[24] = A[24] ^ num35;
      A[5] = A[5] << 36 | A[5] >> 28;
      A[10] = A[10] << 3 | A[10] >> 61;
      A[15] = A[15] << 41 | A[15] >> 23;
      A[20] = A[20] << 18 | A[20] >> 46;
      A[1] = A[1] << 1 | A[1] >> 63 /*0x3F*/;
      A[6] = A[6] << 44 | A[6] >> 20;
      A[11] = A[11] << 10 | A[11] >> 54;
      A[16 /*0x10*/] = A[16 /*0x10*/] << 45 | A[16 /*0x10*/] >> 19;
      A[21] = A[21] << 2 | A[21] >> 62;
      A[2] = A[2] << 62 | A[2] >> 2;
      A[7] = A[7] << 6 | A[7] >> 58;
      A[12] = A[12] << 43 | A[12] >> 21;
      A[17] = A[17] << 15 | A[17] >> 49;
      A[22] = A[22] << 61 | A[22] >> 3;
      A[3] = A[3] << 28 | A[3] >> 36;
      A[8] = A[8] << 55 | A[8] >> 9;
      A[13] = A[13] << 25 | A[13] >> 39;
      A[18] = A[18] << 21 | A[18] >> 43;
      A[23] = A[23] << 56 | A[23] >> 8;
      A[4] = A[4] << 27 | A[4] >> 37;
      A[9] = A[9] << 20 | A[9] >> 44;
      A[14] = A[14] << 39 | A[14] >> 25;
      A[19] = A[19] << 8 | A[19] >> 56;
      A[24] = A[24] << 14 | A[24] >> 50;
      ulong num36 = ~A[12];
      ulong num37 = A[6] | A[12];
      ulong num38 = A[0] ^ num37;
      ulong num39 = num36 | A[18];
      ulong num40 = A[6] ^ num39;
      ulong num41 = A[18] & A[24];
      ulong num42 = A[12] ^ num41;
      ulong num43 = A[24] | A[0];
      ulong num44 = A[18] ^ num43;
      ulong num45 = A[0] & A[6];
      ulong num46 = A[24] ^ num45;
      A[0] = num38;
      A[6] = num40;
      A[12] = num42;
      A[18] = num44;
      A[24] = num46;
      ulong num47 = ~A[22];
      ulong num48 = A[9] | A[10];
      ulong num49 = A[3] ^ num48;
      ulong num50 = A[10] & A[16 /*0x10*/];
      ulong num51 = A[9] ^ num50;
      ulong num52 = A[16 /*0x10*/] | num47;
      ulong num53 = A[10] ^ num52;
      ulong num54 = A[22] | A[3];
      ulong num55 = A[16 /*0x10*/] ^ num54;
      ulong num56 = A[3] & A[9];
      ulong num57 = A[22] ^ num56;
      A[3] = num49;
      A[9] = num51;
      A[10] = num53;
      A[16 /*0x10*/] = num55;
      A[22] = num57;
      ulong num58 = ~A[19];
      ulong num59 = A[7] | A[13];
      ulong num60 = A[1] ^ num59;
      ulong num61 = A[13] & A[19];
      ulong num62 = A[7] ^ num61;
      ulong num63 = num58 & A[20];
      ulong num64 = A[13] ^ num63;
      ulong num65 = A[20] | A[1];
      ulong num66 = num58 ^ num65;
      ulong num67 = A[1] & A[7];
      ulong num68 = A[20] ^ num67;
      A[1] = num60;
      A[7] = num62;
      A[13] = num64;
      A[19] = num66;
      A[20] = num68;
      ulong num69 = ~A[17];
      ulong num70 = A[5] & A[11];
      ulong num71 = A[4] ^ num70;
      ulong num72 = A[11] | A[17];
      ulong num73 = A[5] ^ num72;
      ulong num74 = num69 | A[23];
      ulong num75 = A[11] ^ num74;
      ulong num76 = A[23] & A[4];
      ulong num77 = num69 ^ num76;
      ulong num78 = A[4] | A[5];
      ulong num79 = A[23] ^ num78;
      A[4] = num71;
      A[5] = num73;
      A[11] = num75;
      A[17] = num77;
      A[23] = num79;
      ulong num80 = ~A[8];
      ulong num81 = num80 & A[14];
      ulong num82 = A[2] ^ num81;
      ulong num83 = A[14] | A[15];
      ulong num84 = num80 ^ num83;
      ulong num85 = A[15] & A[21];
      ulong num86 = A[14] ^ num85;
      ulong num87 = A[21] | A[2];
      ulong num88 = A[15] ^ num87;
      ulong num89 = A[2] & A[8];
      ulong num90 = A[21] ^ num89;
      A[2] = num82;
      A[8] = num84;
      A[14] = num86;
      A[15] = num88;
      A[21] = num90;
      A[0] = A[0] ^ this.RC[index];
      ulong num91 = A[6] ^ A[9];
      ulong num92 = A[7] ^ A[5];
      ulong num93 = num91 ^ A[8] ^ num92;
      ulong num94 = num93 << 1 | num93 >> 63 /*0x3F*/;
      ulong num95 = A[24] ^ A[22];
      ulong num96 = A[20] ^ A[23];
      ulong num97 = num94 ^ A[21] ^ num95 ^ num96;
      ulong num98 = A[12] ^ A[10];
      ulong num99 = A[13] ^ A[11];
      ulong num100 = num98 ^ A[14] ^ num99;
      ulong num101 = num100 << 1 | num100 >> 63 /*0x3F*/;
      ulong num102 = A[0] ^ A[3];
      ulong num103 = A[1] ^ A[4];
      ulong num104 = num101 ^ A[2] ^ num102 ^ num103;
      ulong num105 = A[18] ^ A[16 /*0x10*/];
      ulong num106 = A[19] ^ A[17];
      ulong num107 = num105 ^ A[15] ^ num106;
      ulong num108 = num107 << 1 | num107 >> 63 /*0x3F*/;
      ulong num109 = A[6] ^ A[9];
      ulong num110 = A[7] ^ A[5];
      ulong num111 = num108 ^ A[8] ^ num109 ^ num110;
      ulong num112 = A[24] ^ A[22];
      ulong num113 = A[20] ^ A[23];
      ulong num114 = num112 ^ A[21] ^ num113;
      ulong num115 = num114 << 1 | num114 >> 63 /*0x3F*/;
      ulong num116 = A[12] ^ A[10];
      ulong num117 = A[13] ^ A[11];
      ulong num118 = num115 ^ A[14] ^ num116 ^ num117;
      ulong num119 = A[0] ^ A[3];
      ulong num120 = A[1] ^ A[4];
      ulong num121 = num119 ^ A[2] ^ num120;
      ulong num122 = num121 << 1 | num121 >> 63 /*0x3F*/;
      ulong num123 = A[18] ^ A[16 /*0x10*/];
      ulong num124 = A[19] ^ A[17];
      ulong num125 = num122 ^ A[15] ^ num123 ^ num124;
      A[0] = A[0] ^ num97;
      A[3] = A[3] ^ num97;
      A[1] = A[1] ^ num97;
      A[4] = A[4] ^ num97;
      A[2] = A[2] ^ num97;
      A[6] = A[6] ^ num104;
      A[9] = A[9] ^ num104;
      A[7] = A[7] ^ num104;
      A[5] = A[5] ^ num104;
      A[8] = A[8] ^ num104;
      A[12] = A[12] ^ num111;
      A[10] = A[10] ^ num111;
      A[13] = A[13] ^ num111;
      A[11] = A[11] ^ num111;
      A[14] = A[14] ^ num111;
      A[18] = A[18] ^ num118;
      A[16 /*0x10*/] = A[16 /*0x10*/] ^ num118;
      A[19] = A[19] ^ num118;
      A[17] = A[17] ^ num118;
      A[15] = A[15] ^ num118;
      A[24] = A[24] ^ num125;
      A[22] = A[22] ^ num125;
      A[20] = A[20] ^ num125;
      A[23] = A[23] ^ num125;
      A[21] = A[21] ^ num125;
      A[3] = A[3] << 36 | A[3] >> 28;
      A[1] = A[1] << 3 | A[1] >> 61;
      A[4] = A[4] << 41 | A[4] >> 23;
      A[2] = A[2] << 18 | A[2] >> 46;
      A[6] = A[6] << 1 | A[6] >> 63 /*0x3F*/;
      A[9] = A[9] << 44 | A[9] >> 20;
      A[7] = A[7] << 10 | A[7] >> 54;
      A[5] = A[5] << 45 | A[5] >> 19;
      A[8] = A[8] << 2 | A[8] >> 62;
      A[12] = A[12] << 62 | A[12] >> 2;
      A[10] = A[10] << 6 | A[10] >> 58;
      A[13] = A[13] << 43 | A[13] >> 21;
      A[11] = A[11] << 15 | A[11] >> 49;
      A[14] = A[14] << 61 | A[14] >> 3;
      A[18] = A[18] << 28 | A[18] >> 36;
      A[16 /*0x10*/] = A[16 /*0x10*/] << 55 | A[16 /*0x10*/] >> 9;
      A[19] = A[19] << 25 | A[19] >> 39;
      A[17] = A[17] << 21 | A[17] >> 43;
      A[15] = A[15] << 56 | A[15] >> 8;
      A[24] = A[24] << 27 | A[24] >> 37;
      A[22] = A[22] << 20 | A[22] >> 44;
      A[20] = A[20] << 39 | A[20] >> 25;
      A[23] = A[23] << 8 | A[23] >> 56;
      A[21] = A[21] << 14 | A[21] >> 50;
      ulong num126 = ~A[13];
      ulong num127 = A[9] | A[13];
      ulong num128 = A[0] ^ num127;
      ulong num129 = num126 | A[17];
      ulong num130 = A[9] ^ num129;
      ulong num131 = A[17] & A[21];
      ulong num132 = A[13] ^ num131;
      ulong num133 = A[21] | A[0];
      ulong num134 = A[17] ^ num133;
      ulong num135 = A[0] & A[9];
      ulong num136 = A[21] ^ num135;
      A[0] = num128;
      A[9] = num130;
      A[13] = num132;
      A[17] = num134;
      A[21] = num136;
      ulong num137 = ~A[14];
      ulong num138 = A[22] | A[1];
      ulong num139 = A[18] ^ num138;
      ulong num140 = A[1] & A[5];
      ulong num141 = A[22] ^ num140;
      ulong num142 = A[5] | num137;
      ulong num143 = A[1] ^ num142;
      ulong num144 = A[14] | A[18];
      ulong num145 = A[5] ^ num144;
      ulong num146 = A[18] & A[22];
      ulong num147 = A[14] ^ num146;
      A[18] = num139;
      A[22] = num141;
      A[1] = num143;
      A[5] = num145;
      A[14] = num147;
      ulong num148 = ~A[23];
      ulong num149 = A[10] | A[19];
      ulong num150 = A[6] ^ num149;
      ulong num151 = A[19] & A[23];
      ulong num152 = A[10] ^ num151;
      ulong num153 = num148 & A[2];
      ulong num154 = A[19] ^ num153;
      ulong num155 = A[2] | A[6];
      ulong num156 = num148 ^ num155;
      ulong num157 = A[6] & A[10];
      ulong num158 = A[2] ^ num157;
      A[6] = num150;
      A[10] = num152;
      A[19] = num154;
      A[23] = num156;
      A[2] = num158;
      ulong num159 = ~A[11];
      ulong num160 = A[3] & A[7];
      ulong num161 = A[24] ^ num160;
      ulong num162 = A[7] | A[11];
      ulong num163 = A[3] ^ num162;
      ulong num164 = num159 | A[15];
      ulong num165 = A[7] ^ num164;
      ulong num166 = A[15] & A[24];
      ulong num167 = num159 ^ num166;
      ulong num168 = A[24] | A[3];
      ulong num169 = A[15] ^ num168;
      A[24] = num161;
      A[3] = num163;
      A[7] = num165;
      A[11] = num167;
      A[15] = num169;
      ulong num170 = ~A[16 /*0x10*/];
      ulong num171 = num170 & A[20];
      ulong num172 = A[12] ^ num171;
      ulong num173 = A[20] | A[4];
      ulong num174 = num170 ^ num173;
      ulong num175 = A[4] & A[8];
      ulong num176 = A[20] ^ num175;
      ulong num177 = A[8] | A[12];
      ulong num178 = A[4] ^ num177;
      ulong num179 = A[12] & A[16 /*0x10*/];
      ulong num180 = A[8] ^ num179;
      A[12] = num172;
      A[16 /*0x10*/] = num174;
      A[20] = num176;
      A[4] = num178;
      A[8] = num180;
      A[0] = A[0] ^ this.RC[index + 1];
      ulong num181 = A[5];
      A[5] = A[18];
      A[18] = A[11];
      A[11] = A[10];
      A[10] = A[6];
      A[6] = A[22];
      A[22] = A[20];
      A[20] = A[12];
      A[12] = A[19];
      A[19] = A[15];
      A[15] = A[24];
      A[24] = A[8];
      A[8] = num181;
      ulong num182 = A[1];
      A[1] = A[9];
      A[9] = A[14];
      A[14] = A[2];
      A[2] = A[13];
      A[13] = A[23];
      A[23] = A[4];
      A[4] = A[21];
      A[21] = A[16 /*0x10*/];
      A[16 /*0x10*/] = A[3];
      A[3] = A[17];
      A[17] = A[7];
      A[7] = num182;
    }
    A[1] = ~A[1];
    A[2] = ~A[2];
    A[8] = ~A[8];
    A[12] = ~A[12];
    A[17] = ~A[17];
    A[20] = ~A[20];
  }

  internal void i_shake256_init()
  {
    this.dptr = 0UL;
    this.A = new ulong[25];
    this.dubf = new byte[200];
    for (int index = 0; index < this.A.Length; ++index)
      this.A[index] = 0UL;
  }

  internal void i_shake256_inject(byte[] insrc, int inarray, int len)
  {
    ulong num1 = this.dptr;
    while (len > 0)
    {
      int num2 = 136 - (int) num1;
      if (num2 > len)
        num2 = len;
      for (int index = 0; index < num2; ++index)
      {
        int num3 = index + (int) num1;
        this.A[num3 >> 3] ^= (ulong) insrc[inarray + index] << ((num3 & 7) << 3);
      }
      num1 += (ulong) num2;
      inarray += num2;
      len -= num2;
      if (num1 == 136UL)
      {
        this.process_block(this.A);
        num1 = 0UL;
      }
    }
    this.dptr = num1;
  }

  internal void i_shake256_flip()
  {
    uint dptr = (uint) this.dptr;
    this.A[(int) (dptr >> 3)] ^= (ulong) (31L /*0x1F*/ << (((int) dptr & 7) << 3));
    this.A[16 /*0x10*/] ^= 9223372036854775808UL /*0x8000000000000000*/;
    this.dptr = 136UL;
  }

  internal void i_shake256_extract(byte[] outsrc, int outarray, int len)
  {
    ulong num1 = this.dptr;
    while (len > 0)
    {
      if (num1 == 136UL)
      {
        this.process_block(this.A);
        num1 = 0UL;
      }
      int num2 = 136 - (int) num1;
      if (num2 > len)
        num2 = len;
      len -= num2;
      while (num2-- > 0)
      {
        outsrc[outarray++] = (byte) (this.A[num1 >> 3] >> (int) (((long) num1 & 7L) << 3));
        ++num1;
      }
    }
    this.dptr = num1;
  }
}
