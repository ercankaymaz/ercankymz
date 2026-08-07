// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.Base64Encoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public class Base64Encoder : IEncoder
{
  protected readonly byte[] encodingTable = new byte[64 /*0x40*/]
  {
    (byte) 65,
    (byte) 66,
    (byte) 67,
    (byte) 68,
    (byte) 69,
    (byte) 70,
    (byte) 71,
    (byte) 72,
    (byte) 73,
    (byte) 74,
    (byte) 75,
    (byte) 76,
    (byte) 77,
    (byte) 78,
    (byte) 79,
    (byte) 80 /*0x50*/,
    (byte) 81,
    (byte) 82,
    (byte) 83,
    (byte) 84,
    (byte) 85,
    (byte) 86,
    (byte) 87,
    (byte) 88,
    (byte) 89,
    (byte) 90,
    (byte) 97,
    (byte) 98,
    (byte) 99,
    (byte) 100,
    (byte) 101,
    (byte) 102,
    (byte) 103,
    (byte) 104,
    (byte) 105,
    (byte) 106,
    (byte) 107,
    (byte) 108,
    (byte) 109,
    (byte) 110,
    (byte) 111,
    (byte) 112 /*0x70*/,
    (byte) 113,
    (byte) 114,
    (byte) 115,
    (byte) 116,
    (byte) 117,
    (byte) 118,
    (byte) 119,
    (byte) 120,
    (byte) 121,
    (byte) 122,
    (byte) 48 /*0x30*/,
    (byte) 49,
    (byte) 50,
    (byte) 51,
    (byte) 52,
    (byte) 53,
    (byte) 54,
    (byte) 55,
    (byte) 56,
    (byte) 57,
    (byte) 43,
    (byte) 47
  };
  protected byte padding = 61;
  protected readonly byte[] decodingTable = new byte[128 /*0x80*/];

  protected void InitialiseDecodingTable()
  {
    Arrays.Fill(this.decodingTable, byte.MaxValue);
    for (int index = 0; index < this.encodingTable.Length; ++index)
      this.decodingTable[(int) this.encodingTable[index]] = (byte) index;
  }

  public Base64Encoder() => this.InitialiseDecodingTable();

  public int Encode(byte[] inBuf, int inOff, int inLen, byte[] outBuf, int outOff)
  {
    int num1 = inOff;
    int num2 = inOff + inLen - 2;
    int num3 = outOff;
    while (num1 < num2)
    {
      byte[] numArray1 = inBuf;
      int index1 = num1;
      int num4 = index1 + 1;
      uint num5 = (uint) numArray1[index1];
      byte[] numArray2 = inBuf;
      int index2 = num4;
      int num6 = index2 + 1;
      uint num7 = (uint) numArray2[index2];
      byte[] numArray3 = inBuf;
      int index3 = num6;
      num1 = index3 + 1;
      uint num8 = (uint) numArray3[index3];
      byte[] numArray4 = outBuf;
      int index4 = num3;
      int num9 = index4 + 1;
      int num10 = (int) this.encodingTable[(int) (num5 >> 2) & 63 /*0x3F*/];
      numArray4[index4] = (byte) num10;
      byte[] numArray5 = outBuf;
      int index5 = num9;
      int num11 = index5 + 1;
      int num12 = (int) this.encodingTable[((int) num5 << 4 | (int) (num7 >> 4)) & 63 /*0x3F*/];
      numArray5[index5] = (byte) num12;
      byte[] numArray6 = outBuf;
      int index6 = num11;
      int num13 = index6 + 1;
      int num14 = (int) this.encodingTable[((int) num7 << 2 | (int) (num8 >> 6)) & 63 /*0x3F*/];
      numArray6[index6] = (byte) num14;
      byte[] numArray7 = outBuf;
      int index7 = num13;
      num3 = index7 + 1;
      int num15 = (int) this.encodingTable[(int) num8 & 63 /*0x3F*/];
      numArray7[index7] = (byte) num15;
    }
    int num16;
    switch (inLen - (num1 - inOff))
    {
      case 1:
        byte[] numArray8 = inBuf;
        int index8 = num1;
        num16 = index8 + 1;
        uint num17 = (uint) numArray8[index8];
        byte[] numArray9 = outBuf;
        int index9 = num3;
        int num18 = index9 + 1;
        int num19 = (int) this.encodingTable[(int) (num17 >> 2) & 63 /*0x3F*/];
        numArray9[index9] = (byte) num19;
        byte[] numArray10 = outBuf;
        int index10 = num18;
        int num20 = index10 + 1;
        int num21 = (int) this.encodingTable[(int) num17 << 4 & 63 /*0x3F*/];
        numArray10[index10] = (byte) num21;
        byte[] numArray11 = outBuf;
        int index11 = num20;
        int num22 = index11 + 1;
        int padding1 = (int) this.padding;
        numArray11[index11] = (byte) padding1;
        byte[] numArray12 = outBuf;
        int index12 = num22;
        num3 = index12 + 1;
        int padding2 = (int) this.padding;
        numArray12[index12] = (byte) padding2;
        break;
      case 2:
        byte[] numArray13 = inBuf;
        int index13 = num1;
        int num23 = index13 + 1;
        uint num24 = (uint) numArray13[index13];
        byte[] numArray14 = inBuf;
        int index14 = num23;
        num16 = index14 + 1;
        uint num25 = (uint) numArray14[index14];
        byte[] numArray15 = outBuf;
        int index15 = num3;
        int num26 = index15 + 1;
        int num27 = (int) this.encodingTable[(int) (num24 >> 2) & 63 /*0x3F*/];
        numArray15[index15] = (byte) num27;
        byte[] numArray16 = outBuf;
        int index16 = num26;
        int num28 = index16 + 1;
        int num29 = (int) this.encodingTable[((int) num24 << 4 | (int) (num25 >> 4)) & 63 /*0x3F*/];
        numArray16[index16] = (byte) num29;
        byte[] numArray17 = outBuf;
        int index17 = num28;
        int num30 = index17 + 1;
        int num31 = (int) this.encodingTable[(int) num25 << 2 & 63 /*0x3F*/];
        numArray17[index17] = (byte) num31;
        byte[] numArray18 = outBuf;
        int index18 = num30;
        num3 = index18 + 1;
        int padding3 = (int) this.padding;
        numArray18[index18] = (byte) padding3;
        break;
    }
    return num3 - outOff;
  }

  public int Encode(byte[] buf, int off, int len, Stream outStream)
  {
    if (len < 0)
      return 0;
    byte[] numArray = new byte[72];
    int inLen;
    for (int val2 = len; val2 > 0; val2 -= inLen)
    {
      inLen = Math.Min(54, val2);
      int count = this.Encode(buf, off, inLen, numArray, 0);
      outStream.Write(numArray, 0, count);
      off += inLen;
    }
    return (len + 2) / 3 * 4;
  }

  private bool Ignore(char c) => c == '\n' || c == '\r' || c == '\t' || c == ' ';

  public int Decode(byte[] data, int off, int length, Stream outStream)
  {
    byte[] buffer = new byte[54];
    int count = 0;
    int num1 = 0;
    int finish1 = off + length;
    while (finish1 > off && this.Ignore((char) data[finish1 - 1]))
      --finish1;
    int finish2 = finish1 - 4;
    int i1;
    int i2;
    for (i1 = this.NextI(data, off, finish2); i1 < finish2; i1 = this.NextI(data, i2, finish2))
    {
      byte[] decodingTable1 = this.decodingTable;
      byte[] numArray1 = data;
      int index1 = i1;
      int i3 = index1 + 1;
      int index2 = (int) numArray1[index1];
      byte num2 = decodingTable1[index2];
      int num3 = this.NextI(data, i3, finish2);
      byte[] decodingTable2 = this.decodingTable;
      byte[] numArray2 = data;
      int index3 = num3;
      int i4 = index3 + 1;
      int index4 = (int) numArray2[index3];
      byte num4 = decodingTable2[index4];
      int num5 = this.NextI(data, i4, finish2);
      byte[] decodingTable3 = this.decodingTable;
      byte[] numArray3 = data;
      int index5 = num5;
      int i5 = index5 + 1;
      int index6 = (int) numArray3[index5];
      byte num6 = decodingTable3[index6];
      int num7 = this.NextI(data, i5, finish2);
      byte[] decodingTable4 = this.decodingTable;
      byte[] numArray4 = data;
      int index7 = num7;
      i2 = index7 + 1;
      int index8 = (int) numArray4[index7];
      byte num8 = decodingTable4[index8];
      if (((int) num2 | (int) num4 | (int) num6 | (int) num8) >= 128 /*0x80*/)
        throw new IOException("invalid characters encountered in base64 data");
      byte[] numArray5 = buffer;
      int index9 = count;
      int num9 = index9 + 1;
      int num10 = (int) (byte) ((int) num2 << 2 | (int) num4 >> 4);
      numArray5[index9] = (byte) num10;
      byte[] numArray6 = buffer;
      int index10 = num9;
      int num11 = index10 + 1;
      int num12 = (int) (byte) ((int) num4 << 4 | (int) num6 >> 2);
      numArray6[index10] = (byte) num12;
      byte[] numArray7 = buffer;
      int index11 = num11;
      count = index11 + 1;
      int num13 = (int) (byte) ((uint) num6 << 6 | (uint) num8);
      numArray7[index11] = (byte) num13;
      if (count == buffer.Length)
      {
        outStream.Write(buffer, 0, count);
        count = 0;
      }
      num1 += 3;
    }
    if (count > 0)
      outStream.Write(buffer, 0, count);
    int index12 = this.NextI(data, i1, finish1);
    int index13 = this.NextI(data, index12 + 1, finish1);
    int index14 = this.NextI(data, index13 + 1, finish1);
    int index15 = this.NextI(data, index14 + 1, finish1);
    return num1 + this.DecodeLastBlock(outStream, (char) data[index12], (char) data[index13], (char) data[index14], (char) data[index15]);
  }

  private int NextI(byte[] data, int i, int finish)
  {
    while (i < finish && this.Ignore((char) data[i]))
      ++i;
    return i;
  }

  public int DecodeString(string data, Stream outStream)
  {
    int num1 = 0;
    int length = data.Length;
    while (length > 0 && this.Ignore(data[length - 1]))
      --length;
    int finish = length - 4;
    int i1;
    for (int index1 = this.NextI(data, 0, finish); index1 < finish; index1 = this.NextI(data, i1, finish))
    {
      byte[] decodingTable1 = this.decodingTable;
      string str1 = data;
      int index2 = index1;
      int i2 = index2 + 1;
      int index3 = (int) str1[index2];
      byte num2 = decodingTable1[index3];
      int num3 = this.NextI(data, i2, finish);
      byte[] decodingTable2 = this.decodingTable;
      string str2 = data;
      int index4 = num3;
      int i3 = index4 + 1;
      int index5 = (int) str2[index4];
      byte num4 = decodingTable2[index5];
      int num5 = this.NextI(data, i3, finish);
      byte[] decodingTable3 = this.decodingTable;
      string str3 = data;
      int index6 = num5;
      int i4 = index6 + 1;
      int index7 = (int) str3[index6];
      byte num6 = decodingTable3[index7];
      int num7 = this.NextI(data, i4, finish);
      byte[] decodingTable4 = this.decodingTable;
      string str4 = data;
      int index8 = num7;
      i1 = index8 + 1;
      int index9 = (int) str4[index8];
      byte num8 = decodingTable4[index9];
      if (((int) num2 | (int) num4 | (int) num6 | (int) num8) >= 128 /*0x80*/)
        throw new IOException("invalid characters encountered in base64 data");
      outStream.WriteByte((byte) ((int) num2 << 2 | (int) num4 >> 4));
      outStream.WriteByte((byte) ((int) num4 << 4 | (int) num6 >> 2));
      outStream.WriteByte((byte) ((uint) num6 << 6 | (uint) num8));
      num1 += 3;
    }
    return num1 + this.DecodeLastBlock(outStream, data[length - 4], data[length - 3], data[length - 2], data[length - 1]);
  }

  private int DecodeLastBlock(Stream outStream, char c1, char c2, char c3, char c4)
  {
    if ((int) c3 == (int) this.padding)
    {
      if ((int) c4 != (int) this.padding)
        throw new IOException("invalid characters encountered at end of base64 data");
      byte num1 = this.decodingTable[(int) c1];
      byte num2 = this.decodingTable[(int) c2];
      if (((int) num1 | (int) num2) >= 128 /*0x80*/)
        throw new IOException("invalid characters encountered at end of base64 data");
      outStream.WriteByte((byte) ((int) num1 << 2 | (int) num2 >> 4));
      return 1;
    }
    if ((int) c4 == (int) this.padding)
    {
      byte num3 = this.decodingTable[(int) c1];
      byte num4 = this.decodingTable[(int) c2];
      byte num5 = this.decodingTable[(int) c3];
      if (((int) num3 | (int) num4 | (int) num5) >= 128 /*0x80*/)
        throw new IOException("invalid characters encountered at end of base64 data");
      outStream.WriteByte((byte) ((int) num3 << 2 | (int) num4 >> 4));
      outStream.WriteByte((byte) ((int) num4 << 4 | (int) num5 >> 2));
      return 2;
    }
    byte num6 = this.decodingTable[(int) c1];
    byte num7 = this.decodingTable[(int) c2];
    byte num8 = this.decodingTable[(int) c3];
    byte num9 = this.decodingTable[(int) c4];
    if (((int) num6 | (int) num7 | (int) num8 | (int) num9) >= 128 /*0x80*/)
      throw new IOException("invalid characters encountered at end of base64 data");
    outStream.WriteByte((byte) ((int) num6 << 2 | (int) num7 >> 4));
    outStream.WriteByte((byte) ((int) num7 << 4 | (int) num8 >> 2));
    outStream.WriteByte((byte) ((uint) num8 << 6 | (uint) num9));
    return 3;
  }

  private int NextI(string data, int i, int finish)
  {
    while (i < finish && this.Ignore(data[i]))
      ++i;
    return i;
  }
}
