// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Filters.AsciiHexDecode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Filters;

public class AsciiHexDecode : Filter
{
  public override byte[] Encode(byte[] data)
  {
    int num1 = data != null ? data.Length : throw new ArgumentNullException(nameof (data));
    byte[] numArray1 = new byte[2 * num1];
    int index1 = 0;
    int num2 = 0;
    for (; index1 < num1; ++index1)
    {
      byte num3 = data[index1];
      byte[] numArray2 = numArray1;
      int index2 = num2;
      int num4 = index2 + 1;
      int num5 = (int) (byte) (((int) num3 >> 4) + ((int) num3 >> 4 < 10 ? 48 /*0x30*/ : 55));
      numArray2[index2] = (byte) num5;
      byte[] numArray3 = numArray1;
      int index3 = num4;
      num2 = index3 + 1;
      int num6 = (int) (byte) (((int) num3 & 15) + (((int) num3 & 15) < 10 ? 48 /*0x30*/ : 55));
      numArray3[index3] = (byte) num6;
    }
    return numArray1;
  }

  public override byte[] Decode(byte[] data, FilterParms parms)
  {
    data = data != null ? this.RemoveWhiteSpace(data) : throw new ArgumentNullException(nameof (data));
    int length1 = data.Length;
    if ((length1 <= 0 ? 0 : (data[length1 - 1] == (byte) 62 ? 1 : 0)) != 0)
      --length1;
    if (length1 % 2 == 1)
    {
      ++length1;
      byte[] numArray = data;
      data = new byte[length1];
      numArray.CopyTo((Array) data, 0);
    }
    int length2 = length1 >> 1;
    byte[] numArray1 = new byte[length2];
    int index1 = 0;
    int num1 = 0;
    for (; index1 < length2; ++index1)
    {
      byte[] numArray2 = data;
      int index2 = num1;
      int num2 = index2 + 1;
      byte num3 = numArray2[index2];
      byte[] numArray3 = data;
      int index3 = num2;
      num1 = index3 + 1;
      byte num4 = numArray3[index3];
      if ((num3 < (byte) 97 ? 0 : (num3 <= (byte) 102 ? 1 : 0)) != 0)
        num3 -= (byte) 32 /*0x20*/;
      if ((num4 < (byte) 97 ? 0 : (num4 <= (byte) 102 ? 1 : 0)) != 0)
        num4 -= (byte) 32 /*0x20*/;
      numArray1[index1] = (byte) ((num3 > (byte) 57 ? (int) num3 - 55 : (int) num3 - 48 /*0x30*/) * 16 /*0x10*/ + (num4 > (byte) 57 ? (int) num4 - 55 : (int) num4 - 48 /*0x30*/));
    }
    return numArray1;
  }
}
