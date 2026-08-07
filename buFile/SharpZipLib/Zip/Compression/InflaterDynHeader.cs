// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.InflaterDynHeader
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.SharpZipLib.Zip.Compression.Streams;
using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression;

internal class InflaterDynHeader
{
  private const int LNUM = 0;
  private const int DNUM = 1;
  private const int BLNUM = 2;
  private const int BLLENS = 3;
  private const int LENS = 4;
  private const int REPS = 5;
  private static readonly int[] repMin = new int[3]
  {
    3,
    3,
    11
  };
  private static readonly int[] repBits = new int[3]
  {
    2,
    3,
    7
  };
  private byte[] blLens;
  private byte[] litdistLens;
  private InflaterHuffmanTree blTree;
  private int mode;
  private int lnum;
  private int dnum;
  private int blnum;
  private int num;
  private int repSymbol;
  private byte lastLen;
  private int ptr;
  private static readonly int[] BL_ORDER = new int[19]
  {
    16 /*0x10*/,
    17,
    18,
    0,
    8,
    7,
    9,
    6,
    10,
    5,
    11,
    4,
    12,
    3,
    13,
    2,
    14,
    1,
    15
  };

  public bool Decode(StreamManipulator input)
  {
    bool flag;
    while (true)
    {
      switch (this.mode)
      {
        case 0:
          this.lnum = input.PeekBits(5);
          if (this.lnum >= 0)
          {
            this.lnum += 257;
            input.DropBits(5);
            this.mode = 1;
            goto case 1;
          }
          goto label_25;
        case 1:
          this.dnum = input.PeekBits(5);
          if (this.dnum >= 0)
          {
            ++this.dnum;
            input.DropBits(5);
            this.num = this.lnum + this.dnum;
            this.litdistLens = new byte[this.num];
            this.mode = 2;
            goto case 2;
          }
          goto label_26;
        case 2:
          this.blnum = input.PeekBits(4);
          if (this.blnum >= 0)
          {
            this.blnum += 4;
            input.DropBits(4);
            this.blLens = new byte[19];
            this.ptr = 0;
            this.mode = 3;
            goto case 3;
          }
          goto label_27;
        case 3:
          for (; this.ptr < this.blnum; ++this.ptr)
          {
            int num = input.PeekBits(3);
            if (num >= 0)
            {
              input.DropBits(3);
              this.blLens[InflaterDynHeader.BL_ORDER[this.ptr]] = (byte) num;
            }
            else
            {
              flag = false;
              goto label_35;
            }
          }
          this.blTree = new InflaterHuffmanTree(this.blLens);
          this.blLens = (byte[]) null;
          this.ptr = 0;
          this.mode = 4;
          goto case 4;
        case 4:
          int symbol;
          while (((symbol = this.blTree.GetSymbol(input)) & -16) == 0)
          {
            this.litdistLens[this.ptr++] = this.lastLen = (byte) symbol;
            if (this.ptr == this.num)
            {
              flag = true;
              goto label_35;
            }
          }
          if (symbol >= 0)
          {
            if (symbol >= 17)
              this.lastLen = (byte) 0;
            else if (this.ptr == 0)
              goto label_30;
            this.repSymbol = symbol - 16 /*0x10*/;
            this.mode = 5;
            goto case 5;
          }
          goto label_29;
        case 5:
          int repBit = InflaterDynHeader.repBits[this.repSymbol];
          int num1 = input.PeekBits(repBit);
          if (num1 >= 0)
          {
            input.DropBits(repBit);
            int num2 = num1 + InflaterDynHeader.repMin[this.repSymbol];
            if (this.ptr + num2 <= this.num)
            {
              while (num2-- > 0)
                this.litdistLens[this.ptr++] = this.lastLen;
              if (this.ptr != this.num)
              {
                this.mode = 4;
                continue;
              }
              goto label_34;
            }
            goto label_33;
          }
          goto label_32;
        default:
          continue;
      }
    }
label_25:
    flag = false;
    goto label_35;
label_26:
    flag = false;
    goto label_35;
label_27:
    flag = false;
    goto label_35;
label_29:
    flag = false;
    goto label_35;
label_30:
    throw new SharpZipBaseException();
label_32:
    flag = false;
    goto label_35;
label_33:
    throw new SharpZipBaseException();
label_34:
    flag = true;
label_35:
    return flag;
  }

  public InflaterHuffmanTree BuildLitLenTree()
  {
    byte[] numArray = new byte[this.lnum];
    Array.Copy((Array) this.litdistLens, 0, (Array) numArray, 0, this.lnum);
    return new InflaterHuffmanTree(numArray);
  }

  public InflaterHuffmanTree BuildDistTree()
  {
    byte[] numArray = new byte[this.dnum];
    Array.Copy((Array) this.litdistLens, this.lnum, (Array) numArray, 0, this.dnum);
    return new InflaterHuffmanTree(numArray);
  }
}
