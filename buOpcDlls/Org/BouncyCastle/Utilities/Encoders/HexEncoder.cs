// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.HexEncoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public class HexEncoder : IEncoder
{
  private static readonly char[] CharsLower = new char[16 /*0x10*/]
  {
    '0',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    'a',
    'b',
    'c',
    'd',
    'e',
    'f'
  };
  private static readonly char[] CharsUpper = new char[16 /*0x10*/]
  {
    '0',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    'A',
    'B',
    'C',
    'D',
    'E',
    'F'
  };
  protected readonly byte[] encodingTable = new byte[16 /*0x10*/]
  {
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
    (byte) 97,
    (byte) 98,
    (byte) 99,
    (byte) 100,
    (byte) 101,
    (byte) 102
  };
  protected readonly byte[] decodingTable = new byte[128 /*0x80*/];

  protected void InitialiseDecodingTable()
  {
    Arrays.Fill(this.decodingTable, byte.MaxValue);
    for (int index = 0; index < this.encodingTable.Length; ++index)
      this.decodingTable[(int) this.encodingTable[index]] = (byte) index;
    this.decodingTable[65] = this.decodingTable[97];
    this.decodingTable[66] = this.decodingTable[98];
    this.decodingTable[67] = this.decodingTable[99];
    this.decodingTable[68] = this.decodingTable[100];
    this.decodingTable[69] = this.decodingTable[101];
    this.decodingTable[70] = this.decodingTable[102];
  }

  public HexEncoder() => this.InitialiseDecodingTable();

  public int Encode(byte[] inBuf, int inOff, int inLen, byte[] outBuf, int outOff)
  {
    int num1 = inOff;
    int num2 = inOff + inLen;
    int num3 = outOff;
    while (num1 < num2)
    {
      uint num4 = (uint) inBuf[num1++];
      byte[] numArray1 = outBuf;
      int index1 = num3;
      int num5 = index1 + 1;
      int num6 = (int) this.encodingTable[(int) (num4 >> 4)];
      numArray1[index1] = (byte) num6;
      byte[] numArray2 = outBuf;
      int index2 = num5;
      num3 = index2 + 1;
      int num7 = (int) this.encodingTable[(int) num4 & 15];
      numArray2[index2] = (byte) num7;
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
      inLen = Math.Min(36, val2);
      int count = this.Encode(buf, off, inLen, numArray, 0);
      outStream.Write(numArray, 0, count);
      off += inLen;
    }
    return len * 2;
  }

  private static bool Ignore(char c) => c == '\n' || c == '\r' || c == '\t' || c == ' ';

  public int Decode(byte[] data, int off, int length, Stream outStream)
  {
    int num1 = 0;
    byte[] buffer = new byte[36];
    int count = 0;
    int num2 = off + length;
    while (num2 > off && HexEncoder.Ignore((char) data[num2 - 1]))
      --num2;
    int index1 = off;
    while (index1 < num2)
    {
      while (index1 < num2 && HexEncoder.Ignore((char) data[index1]))
        ++index1;
      byte[] decodingTable1 = this.decodingTable;
      byte[] numArray1 = data;
      int index2 = index1;
      int index3 = index2 + 1;
      int index4 = (int) numArray1[index2];
      byte num3 = decodingTable1[index4];
      while (index3 < num2 && HexEncoder.Ignore((char) data[index3]))
        ++index3;
      byte[] decodingTable2 = this.decodingTable;
      byte[] numArray2 = data;
      int index5 = index3;
      index1 = index5 + 1;
      int index6 = (int) numArray2[index5];
      byte num4 = decodingTable2[index6];
      if (((int) num3 | (int) num4) >= 128 /*0x80*/)
        throw new IOException("invalid characters encountered in Hex data");
      buffer[count++] = (byte) ((uint) num3 << 4 | (uint) num4);
      if (count == buffer.Length)
      {
        outStream.Write(buffer, 0, count);
        count = 0;
      }
      ++num1;
    }
    if (count > 0)
      outStream.Write(buffer, 0, count);
    return num1;
  }

  public int DecodeString(string data, Stream outStream)
  {
    int num1 = 0;
    byte[] buffer = new byte[36];
    int count = 0;
    int length = data.Length;
    while (length > 0 && HexEncoder.Ignore(data[length - 1]))
      --length;
    int index1 = 0;
    while (index1 < length)
    {
      while (index1 < length && HexEncoder.Ignore(data[index1]))
        ++index1;
      byte[] decodingTable1 = this.decodingTable;
      string str1 = data;
      int index2 = index1;
      int index3 = index2 + 1;
      int index4 = (int) str1[index2];
      byte num2 = decodingTable1[index4];
      while (index3 < length && HexEncoder.Ignore(data[index3]))
        ++index3;
      byte[] decodingTable2 = this.decodingTable;
      string str2 = data;
      int index5 = index3;
      index1 = index5 + 1;
      int index6 = (int) str2[index5];
      byte num3 = decodingTable2[index6];
      if (((int) num2 | (int) num3) >= 128 /*0x80*/)
        throw new IOException("invalid characters encountered in Hex data");
      buffer[count++] = (byte) ((uint) num2 << 4 | (uint) num3);
      if (count == buffer.Length)
      {
        outStream.Write(buffer, 0, count);
        count = 0;
      }
      ++num1;
    }
    if (count > 0)
      outStream.Write(buffer, 0, count);
    return num1;
  }

  internal byte[] DecodeStrict(string str, int off, int len)
  {
    if (str == null)
      throw new ArgumentNullException(nameof (str));
    if (off < 0 || len < 0 || off > str.Length - len)
      throw new IndexOutOfRangeException("invalid offset and/or length specified");
    if ((len & 1) != 0)
      throw new ArgumentException("a hexadecimal encoding must have an even number of characters", nameof (len));
    int length = len >> 1;
    byte[] numArray = new byte[length];
    int num1 = off;
    for (int index1 = 0; index1 < length; ++index1)
    {
      byte[] decodingTable1 = this.decodingTable;
      string str1 = str;
      int index2 = num1;
      int num2 = index2 + 1;
      int index3 = (int) str1[index2];
      byte num3 = decodingTable1[index3];
      byte[] decodingTable2 = this.decodingTable;
      string str2 = str;
      int index4 = num2;
      num1 = index4 + 1;
      int index5 = (int) str2[index4];
      byte num4 = decodingTable2[index5];
      if (((int) num3 | (int) num4) >= 128 /*0x80*/)
        throw new IOException("invalid characters encountered in Hex data");
      numArray[index1] = (byte) ((uint) num3 << 4 | (uint) num4);
    }
    return numArray;
  }
}
