// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Filters.Ascii85Decode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Filters;

public class Ascii85Decode : Filter
{
  public override byte[] Encode(byte[] data)
  {
    int num1 = data != null ? data.Length : throw new ArgumentNullException(nameof (data));
    int num2 = num1 / 4;
    int num3 = num1 - num2 * 4;
    byte[] array = new byte[num2 * 5 + (num3 == 0 ? 0 : num3 + 1) + 2];
    int index1 = 0;
    int num4 = 0;
    for (int index2 = 0; index2 < num2; ++index2)
    {
      byte[] numArray1 = data;
      int index3 = index1;
      int num5 = index3 + 1;
      int num6 = (int) numArray1[index3] << 24;
      byte[] numArray2 = data;
      int index4 = num5;
      int num7 = index4 + 1;
      int num8 = (int) numArray2[index4] << 16 /*0x10*/;
      int num9 = num6 + num8;
      byte[] numArray3 = data;
      int index5 = num7;
      int num10 = index5 + 1;
      int num11 = (int) numArray3[index5] << 8;
      int num12 = num9 + num11;
      byte[] numArray4 = data;
      int index6 = num10;
      index1 = index6 + 1;
      int num13 = (int) numArray4[index6];
      uint num14 = (uint) (num12 + num13);
      if (num14 == 0U)
      {
        array[num4++] = (byte) 122;
      }
      else
      {
        byte num15 = (byte) (num14 % 85U + 33U);
        uint num16 = num14 / 85U;
        byte num17 = (byte) (num16 % 85U + 33U);
        uint num18 = num16 / 85U;
        byte num19 = (byte) (num18 % 85U + 33U);
        uint num20 = num18 / 85U;
        byte num21 = (byte) (num20 % 85U + 33U);
        byte num22 = (byte) (num20 / 85U + 33U);
        byte[] numArray5 = array;
        int index7 = num4;
        int num23 = index7 + 1;
        int num24 = (int) num22;
        numArray5[index7] = (byte) num24;
        byte[] numArray6 = array;
        int index8 = num23;
        int num25 = index8 + 1;
        int num26 = (int) num21;
        numArray6[index8] = (byte) num26;
        byte[] numArray7 = array;
        int index9 = num25;
        int num27 = index9 + 1;
        int num28 = (int) num19;
        numArray7[index9] = (byte) num28;
        byte[] numArray8 = array;
        int index10 = num27;
        int num29 = index10 + 1;
        int num30 = (int) num17;
        numArray8[index10] = (byte) num30;
        byte[] numArray9 = array;
        int index11 = num29;
        num4 = index11 + 1;
        int num31 = (int) num15;
        numArray9[index11] = (byte) num31;
      }
    }
    switch (num3)
    {
      case 1:
        uint num32 = ((uint) data[index1] << 24) / 614125U;
        byte num33 = (byte) (num32 % 85U + 33U);
        byte num34 = (byte) (num32 / 85U + 33U);
        byte[] numArray10 = array;
        int index12 = num4;
        int num35 = index12 + 1;
        int num36 = (int) num34;
        numArray10[index12] = (byte) num36;
        byte[] numArray11 = array;
        int index13 = num35;
        num4 = index13 + 1;
        int num37 = (int) num33;
        numArray11[index13] = (byte) num37;
        break;
      case 2:
        byte[] numArray12 = data;
        int index14 = index1;
        int index15 = index14 + 1;
        uint num38 = (uint) (((int) numArray12[index14] << 24) + ((int) data[index15] << 16 /*0x10*/)) / 7225U;
        byte num39 = (byte) (num38 % 85U + 33U);
        uint num40 = num38 / 85U;
        byte num41 = (byte) (num40 % 85U + 33U);
        byte num42 = (byte) (num40 / 85U + 33U);
        byte[] numArray13 = array;
        int index16 = num4;
        int num43 = index16 + 1;
        int num44 = (int) num42;
        numArray13[index16] = (byte) num44;
        byte[] numArray14 = array;
        int index17 = num43;
        int num45 = index17 + 1;
        int num46 = (int) num41;
        numArray14[index17] = (byte) num46;
        byte[] numArray15 = array;
        int index18 = num45;
        num4 = index18 + 1;
        int num47 = (int) num39;
        numArray15[index18] = (byte) num47;
        break;
      case 3:
        byte[] numArray16 = data;
        int index19 = index1;
        int num48 = index19 + 1;
        int num49 = (int) numArray16[index19] << 24;
        byte[] numArray17 = data;
        int index20 = num48;
        int index21 = index20 + 1;
        int num50 = (int) numArray17[index20] << 16 /*0x10*/;
        uint num51 = (uint) (num49 + num50 + ((int) data[index21] << 8)) / 85U;
        byte num52 = (byte) (num51 % 85U + 33U);
        uint num53 = num51 / 85U;
        byte num54 = (byte) (num53 % 85U + 33U);
        uint num55 = num53 / 85U;
        byte num56 = (byte) (num55 % 85U + 33U);
        byte num57 = (byte) (num55 / 85U + 33U);
        byte[] numArray18 = array;
        int index22 = num4;
        int num58 = index22 + 1;
        int num59 = (int) num57;
        numArray18[index22] = (byte) num59;
        byte[] numArray19 = array;
        int index23 = num58;
        int num60 = index23 + 1;
        int num61 = (int) num56;
        numArray19[index23] = (byte) num61;
        byte[] numArray20 = array;
        int index24 = num60;
        int num62 = index24 + 1;
        int num63 = (int) num54;
        numArray20[index24] = (byte) num63;
        byte[] numArray21 = array;
        int index25 = num62;
        num4 = index25 + 1;
        int num64 = (int) num52;
        numArray21[index25] = (byte) num64;
        break;
    }
    byte[] numArray22 = array;
    int index26 = num4;
    int num65 = index26 + 1;
    numArray22[index26] = (byte) 126;
    byte[] numArray23 = array;
    int index27 = num65;
    int newSize = index27 + 1;
    numArray23[index27] = (byte) 62;
    if (newSize < array.Length)
      Array.Resize<byte>(ref array, newSize);
    return array;
  }

  public override byte[] Decode(byte[] data, FilterParms parms)
  {
    int num1 = data != null ? data.Length : throw new ArgumentNullException(nameof (data));
    int num2 = 0;
    int num3 = 0;
    int index1;
    for (index1 = 0; index1 < num1; ++index1)
    {
      char ch = (char) data[index1];
      if ((ch < '!' ? 0 : (ch <= 'u' ? 1 : 0)) != 0)
      {
        data[num3++] = (byte) ch;
      }
      else
      {
        switch (ch)
        {
          case 'z':
            data[num3++] = (byte) ch;
            ++num2;
            continue;
          case '~':
            if (data[index1 + 1] != (byte) 62)
              throw new ArgumentException("Illegal character.", nameof (data));
            goto label_11;
          default:
            continue;
        }
      }
    }
label_11:
    if (index1 == num1)
      throw new ArgumentException("Illegal character.", nameof (data));
    int num4 = num3;
    int num5 = num4 - num2;
    int length = 4 * (num2 + num5 / 5);
    int num6 = num5 % 5;
    if (num6 == 1)
      throw new InvalidOperationException("Illegal character.");
    if (num6 != 0)
      length += num6 - 1;
    byte[] numArray1 = new byte[length];
    int index2 = 0;
    int index3 = 0;
    while (index3 + 4 < num4)
    {
      if ((char) data[index3] == 'z')
      {
        ++index3;
        index2 += 4;
      }
      else
      {
        byte[] numArray2 = data;
        int index4 = index3;
        int num7 = index4 + 1;
        long num8 = (long) ((int) numArray2[index4] - 33) * 52200625L;
        byte[] numArray3 = data;
        int index5 = num7;
        int num9 = index5 + 1;
        long num10 = (long) (uint) (((int) numArray3[index5] - 33) * 614125);
        long num11 = num8 + num10;
        byte[] numArray4 = data;
        int index6 = num9;
        int num12 = index6 + 1;
        long num13 = (long) (uint) (((int) numArray4[index6] - 33) * 7225);
        long num14 = num11 + num13;
        byte[] numArray5 = data;
        int index7 = num12;
        int num15 = index7 + 1;
        long num16 = (long) (uint) (((int) numArray5[index7] - 33) * 85);
        long num17 = num14 + num16;
        byte[] numArray6 = data;
        int index8 = num15;
        index3 = index8 + 1;
        long num18 = (long) ((uint) numArray6[index8] - 33U);
        long num19 = num17 + num18;
        if (num19 > (long) uint.MaxValue)
          throw new InvalidOperationException("Value of group greater than 2 power 32 - 1.");
        byte[] numArray7 = numArray1;
        int index9 = index2;
        int num20 = index9 + 1;
        int num21 = (int) (byte) (num19 >> 24);
        numArray7[index9] = (byte) num21;
        byte[] numArray8 = numArray1;
        int index10 = num20;
        int num22 = index10 + 1;
        int num23 = (int) (byte) (num19 >> 16 /*0x10*/);
        numArray8[index10] = (byte) num23;
        byte[] numArray9 = numArray1;
        int index11 = num22;
        int num24 = index11 + 1;
        int num25 = (int) (byte) (num19 >> 8);
        numArray9[index11] = (byte) num25;
        byte[] numArray10 = numArray1;
        int index12 = num24;
        index2 = index12 + 1;
        int num26 = (int) (byte) num19;
        numArray10[index12] = (byte) num26;
      }
    }
    switch (num6)
    {
      case 2:
        byte[] numArray11 = data;
        int index13 = index3;
        int index14 = index13 + 1;
        uint num27 = (uint) (((int) numArray11[index13] - 33) * 52200625 + ((int) data[index14] - 33) * 614125);
        if (num27 > 0U)
          num27 += 16777216U /*0x01000000*/;
        numArray1[index2] = (byte) (num27 >> 24);
        break;
      case 3:
        int index15 = index3;
        byte[] numArray12 = data;
        int index16 = index3;
        int num28 = index16 + 1;
        int num29 = ((int) numArray12[index16] - 33) * 52200625;
        byte[] numArray13 = data;
        int index17 = num28;
        int index18 = index17 + 1;
        int num30 = ((int) numArray13[index17] - 33) * 614125;
        uint num31 = (uint) (num29 + num30 + ((int) data[index18] - 33) * 7225);
        if (num31 > 0U)
        {
          num31 &= 4294901760U;
          uint num32 = num31 / 7225U;
          byte num33 = (byte) (num32 % 85U + 33U);
          uint num34 = num32 / 85U;
          byte num35 = (byte) (num34 % 85U + 33U);
          if (((int) (byte) (num34 / 85U + 33U) != (int) data[index15] || (int) num35 != (int) data[index15 + 1] ? 1 : ((int) num33 != (int) data[index15 + 2] ? 1 : 0)) != 0)
            num31 += 65536U /*0x010000*/;
        }
        byte[] numArray14 = numArray1;
        int index19 = index2;
        int index20 = index19 + 1;
        int num36 = (int) (byte) (num31 >> 24);
        numArray14[index19] = (byte) num36;
        numArray1[index20] = (byte) (num31 >> 16 /*0x10*/);
        break;
      case 4:
        int index21 = index3;
        byte[] numArray15 = data;
        int index22 = index3;
        int num37 = index22 + 1;
        int num38 = ((int) numArray15[index22] - 33) * 52200625;
        byte[] numArray16 = data;
        int index23 = num37;
        int num39 = index23 + 1;
        int num40 = ((int) numArray16[index23] - 33) * 614125;
        int num41 = num38 + num40;
        byte[] numArray17 = data;
        int index24 = num39;
        int index25 = index24 + 1;
        int num42 = ((int) numArray17[index24] - 33) * 7225;
        uint num43 = (uint) (num41 + num42 + ((int) data[index25] - 33) * 85);
        if (num43 > 0U)
        {
          num43 &= 4294967040U;
          uint num44 = num43 / 85U;
          byte num45 = (byte) (num44 % 85U + 33U);
          uint num46 = num44 / 85U;
          byte num47 = (byte) (num46 % 85U + 33U);
          uint num48 = num46 / 85U;
          byte num49 = (byte) (num48 % 85U + 33U);
          if (((int) (byte) (num48 / 85U + 33U) != (int) data[index21] || (int) num49 != (int) data[index21 + 1] || (int) num47 != (int) data[index21 + 2] ? 1 : ((int) num45 != (int) data[index21 + 3] ? 1 : 0)) != 0)
            num43 += 256U /*0x0100*/;
        }
        byte[] numArray18 = numArray1;
        int index26 = index2;
        int num50 = index26 + 1;
        int num51 = (int) (byte) (num43 >> 24);
        numArray18[index26] = (byte) num51;
        byte[] numArray19 = numArray1;
        int index27 = num50;
        int index28 = index27 + 1;
        int num52 = (int) (byte) (num43 >> 16 /*0x10*/);
        numArray19[index27] = (byte) num52;
        numArray1[index28] = (byte) (num43 >> 8);
        break;
    }
    return numArray1;
  }
}
