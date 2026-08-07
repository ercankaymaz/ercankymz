// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.DeflaterEngine
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.SharpZipLib.Checksums;
using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression;

internal class DeflaterEngine : DeflaterConstants
{
  private const int TooFar = 4096 /*0x1000*/;
  private int ins_h;
  private short[] head;
  private short[] prev;
  private int matchStart;
  private int matchLen;
  private bool prevAvailable;
  private int blockStart;
  private int strstart;
  private int lookahead;
  private byte[] window;
  private DeflateStrategy strategy;
  private int max_chain;
  private int max_lazy;
  private int niceLength;
  private int goodLength;
  private int compressionFunction;
  private byte[] inputBuf;
  private long totalIn;
  private int inputOff;
  private int inputEnd;
  private DeflaterPending pending;
  private DeflaterHuffman huffman;
  private Adler32 adler;

  public DeflaterEngine(DeflaterPending pending)
  {
    this.pending = pending;
    this.huffman = new DeflaterHuffman(pending);
    this.adler = new Adler32();
    this.window = new byte[65536 /*0x010000*/];
    this.head = new short[32768 /*0x8000*/];
    this.prev = new short[32768 /*0x8000*/];
    this.strstart = 1;
    this.blockStart = 1;
  }

  public bool Deflate(bool flush, bool finish)
  {
    bool flag;
    do
    {
      this.FillWindow();
      bool flush1 = flush && this.inputOff == this.inputEnd;
      switch (this.compressionFunction)
      {
        case 0:
          flag = this.DeflateStored(flush1, finish);
          break;
        case 1:
          flag = this.DeflateFast(flush1, finish);
          break;
        case 2:
          flag = this.DeflateSlow(flush1, finish);
          break;
        default:
          goto label_6;
      }
    }
    while (this.pending.IsFlushed & flag);
    goto label_7;
label_6:
    throw new InvalidOperationException("unknown compressionFunction");
label_7:
    return flag;
  }

  public void SetInput(byte[] buffer, int offset, int count)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    if (offset < 0)
      throw new ArgumentOutOfRangeException(nameof (offset));
    if (count < 0)
      throw new ArgumentOutOfRangeException(nameof (count));
    if (this.inputOff < this.inputEnd)
      throw new InvalidOperationException("Old input was not completely processed");
    int num = offset + count;
    if ((offset > num ? 1 : (num > buffer.Length ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (count));
    this.inputBuf = buffer;
    this.inputOff = offset;
    this.inputEnd = num;
  }

  public bool NeedsInput() => this.inputEnd == this.inputOff;

  public void SetDictionary(byte[] buffer, int offset, int length)
  {
    this.adler.Update(buffer, offset, length);
    if (length < 3)
      return;
    if (length > 32506)
    {
      offset += length - 32506;
      length = 32506;
    }
    Array.Copy((Array) buffer, offset, (Array) this.window, this.strstart, length);
    this.UpdateHash();
    --length;
    while (--length > 0)
    {
      this.InsertString();
      ++this.strstart;
    }
    this.strstart += 2;
    this.blockStart = this.strstart;
  }

  public void Reset()
  {
    this.huffman.Reset();
    this.adler.Reset();
    this.strstart = 1;
    this.blockStart = 1;
    this.lookahead = 0;
    this.totalIn = 0L;
    this.prevAvailable = false;
    this.matchLen = 2;
    for (int index = 0; index < 32768 /*0x8000*/; ++index)
      this.head[index] = (short) 0;
    for (int index = 0; index < 32768 /*0x8000*/; ++index)
      this.prev[index] = (short) 0;
  }

  public void ResetAdler() => this.adler.Reset();

  public int Adler => (int) this.adler.Value;

  public long TotalIn => this.totalIn;

  public DeflateStrategy Strategy
  {
    get => this.strategy;
    set => this.strategy = value;
  }

  public void SetLevel(int level)
  {
    this.goodLength = (level < 0 ? 1 : (level > 9 ? 1 : 0)) == 0 ? DeflaterConstants.GOOD_LENGTH[level] : throw new ArgumentOutOfRangeException(nameof (level));
    this.max_lazy = DeflaterConstants.MAX_LAZY[level];
    this.niceLength = DeflaterConstants.NICE_LENGTH[level];
    this.max_chain = DeflaterConstants.MAX_CHAIN[level];
    if (DeflaterConstants.COMPR_FUNC[level] == this.compressionFunction)
      return;
    switch (this.compressionFunction)
    {
      case 0:
        if (this.strstart > this.blockStart)
        {
          this.huffman.FlushStoredBlock(this.window, this.blockStart, this.strstart - this.blockStart, false);
          this.blockStart = this.strstart;
        }
        this.UpdateHash();
        break;
      case 1:
        if (this.strstart > this.blockStart)
        {
          this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, false);
          this.blockStart = this.strstart;
          break;
        }
        break;
      case 2:
        if (this.prevAvailable)
          this.huffman.TallyLit((int) this.window[this.strstart - 1] & (int) byte.MaxValue);
        if (this.strstart > this.blockStart)
        {
          this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, false);
          this.blockStart = this.strstart;
        }
        this.prevAvailable = false;
        this.matchLen = 2;
        break;
    }
    this.compressionFunction = DeflaterConstants.COMPR_FUNC[level];
  }

  public void FillWindow()
  {
    if (this.strstart >= 65274)
      this.SlideWindow();
    int num;
    for (; (this.lookahead >= 262 ? 0 : (this.inputOff < this.inputEnd ? 1 : 0)) != 0; this.lookahead += num)
    {
      num = 65536 /*0x010000*/ - this.lookahead - this.strstart;
      if (num > this.inputEnd - this.inputOff)
        num = this.inputEnd - this.inputOff;
      Array.Copy((Array) this.inputBuf, this.inputOff, (Array) this.window, this.strstart + this.lookahead, num);
      this.adler.Update(this.inputBuf, this.inputOff, num);
      this.inputOff += num;
      this.totalIn += (long) num;
    }
    if (this.lookahead < 3)
      return;
    this.UpdateHash();
  }

  private void UpdateHash()
  {
    this.ins_h = (int) this.window[this.strstart] << 5 ^ (int) this.window[this.strstart + 1];
  }

  private int InsertString()
  {
    int index = (this.ins_h << 5 ^ (int) this.window[this.strstart + 2]) & (int) short.MaxValue;
    short num;
    this.prev[this.strstart & (int) short.MaxValue] = num = this.head[index];
    this.head[index] = (short) this.strstart;
    this.ins_h = index;
    return (int) num & (int) ushort.MaxValue;
  }

  private void SlideWindow()
  {
    Array.Copy((Array) this.window, 32768 /*0x8000*/, (Array) this.window, 0, 32768 /*0x8000*/);
    this.matchStart -= 32768 /*0x8000*/;
    this.strstart -= 32768 /*0x8000*/;
    this.blockStart -= 32768 /*0x8000*/;
    for (int index = 0; index < 32768 /*0x8000*/; ++index)
    {
      int num = (int) this.head[index] & (int) ushort.MaxValue;
      this.head[index] = num >= 32768 /*0x8000*/ ? (short) (num - 32768 /*0x8000*/) : (short) 0;
    }
    for (int index = 0; index < 32768 /*0x8000*/; ++index)
    {
      int num = (int) this.prev[index] & (int) ushort.MaxValue;
      this.prev[index] = num >= 32768 /*0x8000*/ ? (short) (num - 32768 /*0x8000*/) : (short) 0;
    }
  }

  private bool FindLongestMatch(int curMatch)
  {
    int maxChain = this.max_chain;
    int num1 = this.niceLength;
    short[] prev = this.prev;
    int strstart = this.strstart;
    int index = this.strstart + this.matchLen;
    int val1 = Math.Max(this.matchLen, 2);
    int num2 = Math.Max(this.strstart - 32506, 0);
    int num3 = this.strstart + 258 - 1;
    byte num4 = this.window[index - 1];
    byte num5 = this.window[index];
    if (val1 >= this.goodLength)
      maxChain >>= 2;
    if (num1 > this.lookahead)
      num1 = this.lookahead;
    do
    {
      if (((int) this.window[curMatch + val1] != (int) num5 || (int) this.window[curMatch + val1 - 1] != (int) num4 || (int) this.window[curMatch] != (int) this.window[strstart] ? 1 : ((int) this.window[curMatch + 1] != (int) this.window[strstart + 1] ? 1 : 0)) == 0)
      {
        int num6 = curMatch + 2;
        int num7 = strstart + 2;
        do
          ;
        while (((int) this.window[++num7] != (int) this.window[++num6] || (int) this.window[++num7] != (int) this.window[++num6] || (int) this.window[++num7] != (int) this.window[++num6] || (int) this.window[++num7] != (int) this.window[++num6] || (int) this.window[++num7] != (int) this.window[++num6] || (int) this.window[++num7] != (int) this.window[++num6] || (int) this.window[++num7] != (int) this.window[++num6] || (int) this.window[++num7] != (int) this.window[++num6] ? 0 : (num7 < num3 ? 1 : 0)) != 0);
        if (num7 > index)
        {
          this.matchStart = curMatch;
          index = num7;
          val1 = num7 - this.strstart;
          if (val1 < num1)
          {
            num4 = this.window[index - 1];
            num5 = this.window[index];
          }
          else
            break;
        }
        strstart = this.strstart;
      }
    }
    while (((curMatch = (int) prev[curMatch & (int) short.MaxValue] & (int) ushort.MaxValue) <= num2 ? 0 : (--maxChain != 0 ? 1 : 0)) != 0);
    this.matchLen = Math.Min(val1, this.lookahead);
    return this.matchLen >= 3;
  }

  private bool DeflateStored(bool flush, bool finish)
  {
    bool flag;
    if ((flush ? 0 : (this.lookahead == 0 ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      this.strstart += this.lookahead;
      this.lookahead = 0;
      int storedLength = this.strstart - this.blockStart;
      if (((storedLength >= DeflaterConstants.MAX_BLOCK_SIZE ? 1 : (this.blockStart >= 32768 /*0x8000*/ ? 0 : (storedLength >= 32506 ? 1 : 0))) | (flush ? 1 : 0)) != 0)
      {
        bool lastBlock = finish;
        if (storedLength > DeflaterConstants.MAX_BLOCK_SIZE)
        {
          storedLength = DeflaterConstants.MAX_BLOCK_SIZE;
          lastBlock = false;
        }
        this.huffman.FlushStoredBlock(this.window, this.blockStart, storedLength, lastBlock);
        this.blockStart += storedLength;
        flag = !lastBlock;
      }
      else
        flag = true;
    }
    return flag;
  }

  private bool DeflateFast(bool flush, bool finish)
  {
    bool flag1;
    if ((this.lookahead >= 262 ? 0 : (!flush ? 1 : 0)) != 0)
    {
      flag1 = false;
    }
    else
    {
      while (this.lookahead >= 262 | flush)
      {
        if (this.lookahead != 0)
        {
          if (this.strstart > 65274)
            this.SlideWindow();
          int curMatch;
          if ((this.lookahead < 3 || (curMatch = this.InsertString()) == 0 || this.strategy == DeflateStrategy.HuffmanOnly || this.strstart - curMatch > 32506 ? 0 : (this.FindLongestMatch(curMatch) ? 1 : 0)) != 0)
          {
            bool flag2 = this.huffman.TallyDist(this.strstart - this.matchStart, this.matchLen);
            this.lookahead -= this.matchLen;
            if ((this.matchLen > this.max_lazy ? 0 : (this.lookahead >= 3 ? 1 : 0)) != 0)
            {
              while (--this.matchLen > 0)
              {
                ++this.strstart;
                this.InsertString();
              }
              ++this.strstart;
            }
            else
            {
              this.strstart += this.matchLen;
              if (this.lookahead >= 2)
                this.UpdateHash();
            }
            this.matchLen = 2;
            if (!flag2)
              continue;
          }
          else
          {
            this.huffman.TallyLit((int) this.window[this.strstart] & (int) byte.MaxValue);
            ++this.strstart;
            --this.lookahead;
          }
          if (this.huffman.IsFull())
          {
            bool lastBlock = finish && this.lookahead == 0;
            this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, lastBlock);
            this.blockStart = this.strstart;
            flag1 = !lastBlock;
            goto label_19;
          }
        }
        else
        {
          this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, finish);
          this.blockStart = this.strstart;
          flag1 = false;
          goto label_19;
        }
      }
      flag1 = true;
    }
label_19:
    return flag1;
  }

  private bool DeflateSlow(bool flush, bool finish)
  {
    bool flag;
    if ((this.lookahead >= 262 ? 0 : (!flush ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      while (this.lookahead >= 262 | flush)
      {
        if (this.lookahead != 0)
        {
          if (this.strstart >= 65274)
            this.SlideWindow();
          int matchStart = this.matchStart;
          int matchLen = this.matchLen;
          if (this.lookahead >= 3)
          {
            int curMatch = this.InsertString();
            if ((this.strategy == DeflateStrategy.HuffmanOnly || curMatch == 0 || this.strstart - curMatch > 32506 ? 0 : (this.FindLongestMatch(curMatch) ? 1 : 0)) != 0 && (this.matchLen > 5 ? 0 : (this.strategy == DeflateStrategy.Filtered ? 1 : (this.matchLen != 3 ? 0 : (this.strstart - this.matchStart > 4096 /*0x1000*/ ? 1 : 0)))) != 0)
              this.matchLen = 2;
          }
          if ((matchLen < 3 ? 0 : (this.matchLen <= matchLen ? 1 : 0)) != 0)
          {
            this.huffman.TallyDist(this.strstart - 1 - matchStart, matchLen);
            int num = matchLen - 2;
            do
            {
              ++this.strstart;
              --this.lookahead;
              if (this.lookahead >= 3)
                goto label_11;
label_10:
              continue;
label_11:
              this.InsertString();
              goto label_10;
            }
            while (--num > 0);
            ++this.strstart;
            --this.lookahead;
            this.prevAvailable = false;
            this.matchLen = 2;
          }
          else
          {
            if (this.prevAvailable)
              this.huffman.TallyLit((int) this.window[this.strstart - 1] & (int) byte.MaxValue);
            this.prevAvailable = true;
            ++this.strstart;
            --this.lookahead;
          }
          if (this.huffman.IsFull())
          {
            int storedLength = this.strstart - this.blockStart;
            if (this.prevAvailable)
              --storedLength;
            bool lastBlock = finish && this.lookahead == 0 && !this.prevAvailable;
            this.huffman.FlushBlock(this.window, this.blockStart, storedLength, lastBlock);
            this.blockStart += storedLength;
            flag = !lastBlock;
            goto label_26;
          }
        }
        else
        {
          if (this.prevAvailable)
            this.huffman.TallyLit((int) this.window[this.strstart - 1] & (int) byte.MaxValue);
          this.prevAvailable = false;
          this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, finish);
          this.blockStart = this.strstart;
          flag = false;
          goto label_26;
        }
      }
      flag = true;
    }
label_26:
    return flag;
  }
}
