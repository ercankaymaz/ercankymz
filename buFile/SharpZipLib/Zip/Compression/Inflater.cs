// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.Inflater
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.SharpZipLib.Checksums;
using PdfSharp.SharpZipLib.Zip.Compression.Streams;
using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression;

internal class Inflater
{
  private static readonly int[] CPLENS = new int[29]
  {
    3,
    4,
    5,
    6,
    7,
    8,
    9,
    10,
    11,
    13,
    15,
    17,
    19,
    23,
    27,
    31 /*0x1F*/,
    35,
    43,
    51,
    59,
    67,
    83,
    99,
    115,
    131,
    163,
    195,
    227,
    258
  };
  private static readonly int[] CPLEXT = new int[29]
  {
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    1,
    1,
    1,
    1,
    2,
    2,
    2,
    2,
    3,
    3,
    3,
    3,
    4,
    4,
    4,
    4,
    5,
    5,
    5,
    5,
    0
  };
  private static readonly int[] CPDIST = new int[30]
  {
    1,
    2,
    3,
    4,
    5,
    7,
    9,
    13,
    17,
    25,
    33,
    49,
    65,
    97,
    129,
    193,
    257,
    385,
    513,
    769,
    1025,
    1537,
    2049,
    3073,
    4097,
    6145,
    8193,
    12289,
    16385,
    24577
  };
  private static readonly int[] CPDEXT = new int[30]
  {
    0,
    0,
    0,
    0,
    1,
    1,
    2,
    2,
    3,
    3,
    4,
    4,
    5,
    5,
    6,
    6,
    7,
    7,
    8,
    8,
    9,
    9,
    10,
    10,
    11,
    11,
    12,
    12,
    13,
    13
  };
  private const int DECODE_HEADER = 0;
  private const int DECODE_DICT = 1;
  private const int DECODE_BLOCKS = 2;
  private const int DECODE_STORED_LEN1 = 3;
  private const int DECODE_STORED_LEN2 = 4;
  private const int DECODE_STORED = 5;
  private const int DECODE_DYN_HEADER = 6;
  private const int DECODE_HUFFMAN = 7;
  private const int DECODE_HUFFMAN_LENBITS = 8;
  private const int DECODE_HUFFMAN_DIST = 9;
  private const int DECODE_HUFFMAN_DISTBITS = 10;
  private const int DECODE_CHKSUM = 11;
  private const int FINISHED = 12;
  private int mode;
  private int readAdler;
  private int neededBits;
  private int repLength;
  private int repDist;
  private int uncomprLen;
  private bool isLastBlock;
  private long totalOut;
  private long totalIn;
  private bool noHeader;
  private StreamManipulator input;
  private OutputWindow outputWindow;
  private InflaterDynHeader dynHeader;
  private InflaterHuffmanTree litlenTree;
  private InflaterHuffmanTree distTree;
  private Adler32 adler;

  public Inflater()
    : this(false)
  {
  }

  public Inflater(bool noHeader)
  {
    this.noHeader = noHeader;
    this.adler = new Adler32();
    this.input = new StreamManipulator();
    this.outputWindow = new OutputWindow();
    this.mode = noHeader ? 2 : 0;
  }

  public void Reset()
  {
    this.mode = this.noHeader ? 2 : 0;
    this.totalIn = 0L;
    this.totalOut = 0L;
    this.input.Reset();
    this.outputWindow.Reset();
    this.dynHeader = (InflaterDynHeader) null;
    this.litlenTree = (InflaterHuffmanTree) null;
    this.distTree = (InflaterHuffmanTree) null;
    this.isLastBlock = false;
    this.adler.Reset();
  }

  private bool DecodeHeader()
  {
    int num1 = this.input.PeekBits(16 /*0x10*/);
    bool flag;
    if (num1 < 0)
    {
      flag = false;
    }
    else
    {
      this.input.DropBits(16 /*0x10*/);
      int num2 = (num1 << 8 | num1 >> 8) & (int) ushort.MaxValue;
      if (num2 % 31 /*0x1F*/ != 0)
        throw new SharpZipBaseException("Header checksum illegal");
      if ((num2 & 3840 /*0x0F00*/) != 2048 /*0x0800*/)
        throw new SharpZipBaseException("Compression Method unknown");
      if ((num2 & 32 /*0x20*/) == 0)
      {
        this.mode = 2;
      }
      else
      {
        this.mode = 1;
        this.neededBits = 32 /*0x20*/;
      }
      flag = true;
    }
    return flag;
  }

  private bool DecodeDict()
  {
    bool flag;
    for (; this.neededBits > 0; this.neededBits -= 8)
    {
      int num = this.input.PeekBits(8);
      if (num >= 0)
      {
        this.input.DropBits(8);
        this.readAdler = this.readAdler << 8 | num;
      }
      else
      {
        flag = false;
        goto label_6;
      }
    }
    flag = false;
label_6:
    return flag;
  }

  private bool DecodeHuffman()
  {
    int freeSpace = this.outputWindow.GetFreeSpace();
    bool flag;
    while (freeSpace >= 258)
    {
      switch (this.mode)
      {
        case 7:
          int symbol1;
          while (((symbol1 = this.litlenTree.GetSymbol(this.input)) & -256) == 0)
          {
            this.outputWindow.Write(symbol1);
            if (--freeSpace < 258)
            {
              flag = true;
              goto label_28;
            }
          }
          if (symbol1 >= 257)
          {
            try
            {
              this.repLength = Inflater.CPLENS[symbol1 - 257];
              this.neededBits = Inflater.CPLEXT[symbol1 - 257];
              goto case 8;
            }
            catch (Exception ex)
            {
              throw new SharpZipBaseException("Illegal rep length code");
            }
          }
          else
          {
            if (symbol1 < 0)
            {
              flag = false;
              goto label_28;
            }
            this.distTree = (InflaterHuffmanTree) null;
            this.litlenTree = (InflaterHuffmanTree) null;
            this.mode = 2;
            flag = true;
            goto label_28;
          }
        case 8:
          if (this.neededBits > 0)
          {
            this.mode = 8;
            int num = this.input.PeekBits(this.neededBits);
            if (num >= 0)
            {
              this.input.DropBits(this.neededBits);
              this.repLength += num;
            }
            else
            {
              flag = false;
              goto label_28;
            }
          }
          this.mode = 9;
          goto case 9;
        case 9:
          int symbol2 = this.distTree.GetSymbol(this.input);
          if (symbol2 >= 0)
          {
            try
            {
              this.repDist = Inflater.CPDIST[symbol2];
              this.neededBits = Inflater.CPDEXT[symbol2];
              goto case 10;
            }
            catch (Exception ex)
            {
              throw new SharpZipBaseException("Illegal rep dist code");
            }
          }
          else
          {
            flag = false;
            goto label_28;
          }
        case 10:
          if (this.neededBits > 0)
          {
            this.mode = 10;
            int num = this.input.PeekBits(this.neededBits);
            if (num >= 0)
            {
              this.input.DropBits(this.neededBits);
              this.repDist += num;
            }
            else
            {
              flag = false;
              goto label_28;
            }
          }
          this.outputWindow.Repeat(this.repLength, this.repDist);
          freeSpace -= this.repLength;
          this.mode = 7;
          continue;
        default:
          throw new SharpZipBaseException("Inflater unknown mode");
      }
    }
    flag = true;
label_28:
    return flag;
  }

  private bool DecodeChksum()
  {
    bool flag;
    for (; this.neededBits > 0; this.neededBits -= 8)
    {
      int num = this.input.PeekBits(8);
      if (num >= 0)
      {
        this.input.DropBits(8);
        this.readAdler = this.readAdler << 8 | num;
      }
      else
      {
        flag = false;
        goto label_8;
      }
    }
    if ((int) this.adler.Value != this.readAdler)
      throw new SharpZipBaseException($"Adler chksum doesn't match: {((int) this.adler.Value).ToString()} vs. {this.readAdler.ToString()}");
    this.mode = 12;
    flag = false;
label_8:
    return flag;
  }

  private bool Decode()
  {
    bool flag;
    switch (this.mode)
    {
      case 0:
        flag = this.DecodeHeader();
        break;
      case 1:
        flag = this.DecodeDict();
        break;
      case 2:
        if (this.isLastBlock)
        {
          if (this.noHeader)
          {
            this.mode = 12;
            flag = false;
            break;
          }
          this.input.SkipToByteBoundary();
          this.neededBits = 32 /*0x20*/;
          this.mode = 11;
          flag = true;
          break;
        }
        int num1 = this.input.PeekBits(3);
        if (num1 < 0)
        {
          flag = false;
          break;
        }
        this.input.DropBits(3);
        if ((num1 & 1) != 0)
          this.isLastBlock = true;
        switch (num1 >> 1)
        {
          case 0:
            this.input.SkipToByteBoundary();
            this.mode = 3;
            break;
          case 1:
            this.litlenTree = InflaterHuffmanTree.defLitLenTree;
            this.distTree = InflaterHuffmanTree.defDistTree;
            this.mode = 7;
            break;
          case 2:
            this.dynHeader = new InflaterDynHeader();
            this.mode = 6;
            break;
          default:
            throw new SharpZipBaseException("Unknown block type " + num1.ToString());
        }
        flag = true;
        break;
      case 3:
        if ((this.uncomprLen = this.input.PeekBits(16 /*0x10*/)) < 0)
        {
          flag = false;
          break;
        }
        this.input.DropBits(16 /*0x10*/);
        this.mode = 4;
        goto case 4;
      case 4:
        int num2 = this.input.PeekBits(16 /*0x10*/);
        if (num2 < 0)
        {
          flag = false;
          break;
        }
        this.input.DropBits(16 /*0x10*/);
        if (num2 != (this.uncomprLen ^ (int) ushort.MaxValue))
          throw new SharpZipBaseException("broken uncompressed block");
        this.mode = 5;
        goto case 5;
      case 5:
        this.uncomprLen -= this.outputWindow.CopyStored(this.input, this.uncomprLen);
        if (this.uncomprLen == 0)
        {
          this.mode = 2;
          flag = true;
          break;
        }
        flag = !this.input.IsNeedingInput;
        break;
      case 6:
        if (!this.dynHeader.Decode(this.input))
        {
          flag = false;
          break;
        }
        this.litlenTree = this.dynHeader.BuildLitLenTree();
        this.distTree = this.dynHeader.BuildDistTree();
        this.mode = 7;
        goto case 7;
      case 7:
      case 8:
      case 9:
      case 10:
        flag = this.DecodeHuffman();
        break;
      case 11:
        flag = this.DecodeChksum();
        break;
      case 12:
        flag = false;
        break;
      default:
        throw new SharpZipBaseException("Inflater.Decode unknown mode");
    }
    return flag;
  }

  public void SetDictionary(byte[] buffer) => this.SetDictionary(buffer, 0, buffer.Length);

  public void SetDictionary(byte[] buffer, int index, int count)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    if (index < 0)
      throw new ArgumentOutOfRangeException(nameof (index));
    if (count < 0)
      throw new ArgumentOutOfRangeException(nameof (count));
    if (!this.IsNeedingDictionary)
      throw new InvalidOperationException("Dictionary is not needed");
    this.adler.Update(buffer, index, count);
    if ((int) this.adler.Value != this.readAdler)
      throw new SharpZipBaseException("Wrong adler checksum");
    this.adler.Reset();
    this.outputWindow.CopyDict(buffer, index, count);
    this.mode = 2;
  }

  public void SetInput(byte[] buffer) => this.SetInput(buffer, 0, buffer.Length);

  public void SetInput(byte[] buffer, int index, int count)
  {
    this.input.SetInput(buffer, index, count);
    this.totalIn += (long) count;
  }

  public int Inflate(byte[] buffer)
  {
    return buffer != null ? this.Inflate(buffer, 0, buffer.Length) : throw new ArgumentNullException(nameof (buffer));
  }

  public int Inflate(byte[] buffer, int offset, int count)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    if (count < 0)
      throw new ArgumentOutOfRangeException(nameof (count), "count cannot be negative");
    if (offset < 0)
      throw new ArgumentOutOfRangeException(nameof (offset), "offset cannot be negative");
    if (offset + count > buffer.Length)
      throw new ArgumentException("count exceeds buffer bounds");
    int num1;
    if (count == 0)
    {
      if (!this.IsFinished)
        this.Decode();
      num1 = 0;
    }
    else
    {
      int num2 = 0;
      do
      {
        if (this.mode != 11)
          goto label_14;
label_13:
        continue;
label_14:
        int count1 = this.outputWindow.CopyOutput(buffer, offset, count);
        if (count1 > 0)
        {
          this.adler.Update(buffer, offset, count1);
          offset += count1;
          num2 += count1;
          this.totalOut += (long) count1;
          count -= count1;
          if (count != 0)
            goto label_13;
          goto label_17;
        }
        goto label_13;
      }
      while ((this.Decode() ? 1 : (this.outputWindow.GetAvailable() <= 0 ? 0 : (this.mode != 11 ? 1 : 0))) != 0);
      goto label_18;
label_17:
      num1 = num2;
      goto label_19;
label_18:
      num1 = num2;
    }
label_19:
    return num1;
  }

  public bool IsNeedingInput => this.input.IsNeedingInput;

  public bool IsNeedingDictionary => this.mode == 1 && this.neededBits == 0;

  public bool IsFinished => this.mode == 12 && this.outputWindow.GetAvailable() == 0;

  public int Adler => this.IsNeedingDictionary ? this.readAdler : (int) this.adler.Value;

  public long TotalOut => this.totalOut;

  public long TotalIn => this.totalIn - (long) this.RemainingInput;

  public int RemainingInput => this.input.AvailableBytes;
}
