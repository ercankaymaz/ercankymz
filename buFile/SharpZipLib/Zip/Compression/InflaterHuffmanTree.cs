// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.InflaterHuffmanTree
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.SharpZipLib.Zip.Compression.Streams;
using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression;

internal class InflaterHuffmanTree
{
  private static int MAX_BITLEN = 15;
  private short[] tree;
  public static InflaterHuffmanTree defLitLenTree;
  public static InflaterHuffmanTree defDistTree;

  static InflaterHuffmanTree()
  {
    try
    {
      byte[] codeLengths1 = new byte[288];
      int num1 = 0;
      while (num1 < 144 /*0x90*/)
        codeLengths1[num1++] = (byte) 8;
      while (num1 < 256 /*0x0100*/)
        codeLengths1[num1++] = (byte) 9;
      while (num1 < 280)
        codeLengths1[num1++] = (byte) 7;
      while (num1 < 288)
        codeLengths1[num1++] = (byte) 8;
      InflaterHuffmanTree.defLitLenTree = new InflaterHuffmanTree(codeLengths1);
      byte[] codeLengths2 = new byte[32 /*0x20*/];
      int num2 = 0;
      while (num2 < 32 /*0x20*/)
        codeLengths2[num2++] = (byte) 5;
      InflaterHuffmanTree.defDistTree = new InflaterHuffmanTree(codeLengths2);
    }
    catch (Exception ex)
    {
      throw new SharpZipBaseException("InflaterHuffmanTree: static tree length illegal");
    }
  }

  public InflaterHuffmanTree(byte[] codeLengths) => this.BuildTree(codeLengths);

  private void BuildTree(byte[] codeLengths)
  {
    int[] numArray1 = new int[InflaterHuffmanTree.MAX_BITLEN + 1];
    int[] numArray2 = new int[InflaterHuffmanTree.MAX_BITLEN + 1];
    for (int index = 0; index < codeLengths.Length; ++index)
    {
      int codeLength = (int) codeLengths[index];
      if (codeLength > 0)
        ++numArray1[codeLength];
    }
    int num1 = 0;
    int length = 512 /*0x0200*/;
    for (int index = 1; index <= InflaterHuffmanTree.MAX_BITLEN; ++index)
    {
      numArray2[index] = num1;
      num1 += numArray1[index] << 16 /*0x10*/ - index;
      if (index >= 10)
      {
        int num2 = numArray2[index] & 130944;
        int num3 = num1 & 130944;
        length += num3 - num2 >> 16 /*0x10*/ - index;
      }
    }
    this.tree = new short[length];
    int num4 = 512 /*0x0200*/;
    for (int maxBitlen = InflaterHuffmanTree.MAX_BITLEN; maxBitlen >= 10; --maxBitlen)
    {
      int num5 = num1 & 130944;
      num1 -= numArray1[maxBitlen] << 16 /*0x10*/ - maxBitlen;
      for (int toReverse = num1 & 130944; toReverse < num5; toReverse += 128 /*0x80*/)
      {
        this.tree[(int) DeflaterHuffman.BitReverse(toReverse)] = (short) (-num4 << 4 | maxBitlen);
        num4 += 1 << maxBitlen - 9;
      }
    }
    for (int index1 = 0; index1 < codeLengths.Length; ++index1)
    {
      int codeLength = (int) codeLengths[index1];
      if (codeLength != 0)
      {
        int toReverse = numArray2[codeLength];
        int index2 = (int) DeflaterHuffman.BitReverse(toReverse);
        if (codeLength <= 9)
        {
          do
          {
            this.tree[index2] = (short) (index1 << 4 | codeLength);
            index2 += 1 << codeLength;
          }
          while (index2 < 512 /*0x0200*/);
        }
        else
        {
          int num6 = (int) this.tree[index2 & 511 /*0x01FF*/];
          int num7 = 1 << (num6 & 15);
          int num8 = -(num6 >> 4);
          do
          {
            this.tree[num8 | index2 >> 9] = (short) (index1 << 4 | codeLength);
            index2 += 1 << codeLength;
          }
          while (index2 < num7);
        }
        numArray2[codeLength] = toReverse + (1 << 16 /*0x10*/ - codeLength);
      }
    }
  }

  public int GetSymbol(StreamManipulator input)
  {
    int index;
    int symbol;
    if ((index = input.PeekBits(9)) >= 0)
    {
      int num1;
      if ((num1 = (int) this.tree[index]) >= 0)
      {
        input.DropBits(num1 & 15);
        symbol = num1 >> 4;
      }
      else
      {
        int num2 = -(num1 >> 4);
        int bitCount = num1 & 15;
        int num3;
        if ((num3 = input.PeekBits(bitCount)) >= 0)
        {
          int num4 = (int) this.tree[num2 | num3 >> 9];
          input.DropBits(num4 & 15);
          symbol = num4 >> 4;
        }
        else
        {
          int availableBits = input.AvailableBits;
          int num5 = input.PeekBits(availableBits);
          int num6 = (int) this.tree[num2 | num5 >> 9];
          if ((num6 & 15) <= availableBits)
          {
            input.DropBits(num6 & 15);
            symbol = num6 >> 4;
          }
          else
            symbol = -1;
        }
      }
    }
    else
    {
      int availableBits = input.AvailableBits;
      int num = (int) this.tree[input.PeekBits(availableBits)];
      if ((num < 0 ? 0 : ((num & 15) <= availableBits ? 1 : 0)) != 0)
      {
        input.DropBits(num & 15);
        symbol = num >> 4;
      }
      else
        symbol = -1;
    }
    return symbol;
  }
}
