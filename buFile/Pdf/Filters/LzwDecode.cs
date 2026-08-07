// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Filters.LzwDecode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.Filters;

public class LzwDecode : Filter
{
  private readonly int[] _andTable = new int[4]
  {
    511 /*0x01FF*/,
    1023 /*0x03FF*/,
    2047 /*0x07FF*/,
    4095 /*0x0FFF*/
  };
  private byte[][] _stringTable;
  private byte[] _data;
  private int _tableIndex;
  private int _bitsToGet = 9;
  private int _bytePointer;
  private int _nextData = 0;
  private int _nextBits = 0;

  public override byte[] Encode(byte[] data)
  {
    throw new NotImplementedException("PDFsharp does not support LZW encoding.");
  }

  public override byte[] Decode(byte[] data, FilterParms parms)
  {
    if ((data[0] != (byte) 0 ? 0 : (data[1] == (byte) 1 ? 1 : 0)) != 0)
      throw new Exception("LZW flavour not supported.");
    MemoryStream memoryStream = new MemoryStream();
    this.InitializeDictionary();
    this._data = data;
    this._bytePointer = 0;
    this._nextData = 0;
    this._nextBits = 0;
    int index = 0;
    int nextCode1;
    while ((nextCode1 = this.NextCode) != 257)
    {
      if (nextCode1 == 256 /*0x0100*/)
      {
        this.InitializeDictionary();
        int nextCode2 = this.NextCode;
        if (nextCode2 != 257)
        {
          memoryStream.Write(this._stringTable[nextCode2], 0, this._stringTable[nextCode2].Length);
          index = nextCode2;
        }
        else
          break;
      }
      else if (nextCode1 < this._tableIndex)
      {
        byte[] buffer = this._stringTable[nextCode1];
        memoryStream.Write(buffer, 0, buffer.Length);
        this.AddEntry(this._stringTable[index], buffer[0]);
        index = nextCode1;
      }
      else
      {
        byte[] numArray = this._stringTable[index];
        memoryStream.Write(numArray, 0, numArray.Length);
        this.AddEntry(numArray, numArray[0]);
        index = nextCode1;
      }
    }
    byte[] numArray1;
    if (memoryStream.Length >= 0L)
    {
      memoryStream.Capacity = (int) memoryStream.Length;
      numArray1 = memoryStream.GetBuffer();
    }
    else
      numArray1 = (byte[]) null;
    return numArray1;
  }

  private void InitializeDictionary()
  {
    this._stringTable = new byte[8192 /*0x2000*/][];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
    {
      this._stringTable[index] = new byte[1];
      this._stringTable[index][0] = (byte) index;
    }
    this._tableIndex = 258;
    this._bitsToGet = 9;
  }

  private void AddEntry(byte[] oldstring, byte newstring)
  {
    int length = oldstring.Length;
    byte[] destinationArray = new byte[length + 1];
    Array.Copy((Array) oldstring, 0, (Array) destinationArray, 0, length);
    destinationArray[length] = newstring;
    this._stringTable[this._tableIndex++] = destinationArray;
    if (this._tableIndex == 511 /*0x01FF*/)
      this._bitsToGet = 10;
    else if (this._tableIndex == 1023 /*0x03FF*/)
    {
      this._bitsToGet = 11;
    }
    else
    {
      if (this._tableIndex != 2047 /*0x07FF*/)
        return;
      this._bitsToGet = 12;
    }
  }

  private int NextCode
  {
    get
    {
      try
      {
        this._nextData = this._nextData << 8 | (int) this._data[this._bytePointer++] & (int) byte.MaxValue;
        this._nextBits += 8;
        if (this._nextBits < this._bitsToGet)
        {
          this._nextData = this._nextData << 8 | (int) this._data[this._bytePointer++] & (int) byte.MaxValue;
          this._nextBits += 8;
        }
        int nextCode = this._nextData >> this._nextBits - this._bitsToGet & this._andTable[this._bitsToGet - 9];
        this._nextBits -= this._bitsToGet;
        return nextCode;
      }
      catch
      {
        return 257;
      }
    }
  }
}
