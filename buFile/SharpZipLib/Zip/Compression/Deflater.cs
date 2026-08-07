// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.Deflater
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression;

internal class Deflater
{
  public const int BEST_COMPRESSION = 9;
  public const int BEST_SPEED = 1;
  public const int DEFAULT_COMPRESSION = -1;
  public const int NO_COMPRESSION = 0;
  public const int DEFLATED = 8;
  private const int IS_SETDICT = 1;
  private const int IS_FLUSHING = 4;
  private const int IS_FINISHING = 8;
  private const int INIT_STATE = 0;
  private const int SETDICT_STATE = 1;
  private const int BUSY_STATE = 16 /*0x10*/;
  private const int FLUSHING_STATE = 20;
  private const int FINISHING_STATE = 28;
  private const int FINISHED_STATE = 30;
  private const int CLOSED_STATE = 127 /*0x7F*/;
  private int level;
  private bool noZlibHeaderOrFooter;
  private int state;
  private long totalOut;
  private DeflaterPending pending;
  private DeflaterEngine engine;

  public Deflater()
    : this(-1, false)
  {
  }

  public Deflater(int level)
    : this(level, false)
  {
  }

  public Deflater(int level, bool noZlibHeaderOrFooter)
  {
    if (level == -1)
      level = 6;
    else if ((level < 0 ? 1 : (level > 9 ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (level));
    this.pending = new DeflaterPending();
    this.engine = new DeflaterEngine(this.pending);
    this.noZlibHeaderOrFooter = noZlibHeaderOrFooter;
    this.SetStrategy(DeflateStrategy.Default);
    this.SetLevel(level);
    this.Reset();
  }

  public void Reset()
  {
    this.state = this.noZlibHeaderOrFooter ? 16 /*0x10*/ : 0;
    this.totalOut = 0L;
    this.pending.Reset();
    this.engine.Reset();
  }

  public int Adler => this.engine.Adler;

  public long TotalIn => this.engine.TotalIn;

  public long TotalOut => this.totalOut;

  public void Flush() => this.state |= 4;

  public void Finish() => this.state |= 12;

  public bool IsFinished => this.state == 30 && this.pending.IsFlushed;

  public bool IsNeedingInput => this.engine.NeedsInput();

  public void SetInput(byte[] input) => this.SetInput(input, 0, input.Length);

  public void SetInput(byte[] input, int offset, int count)
  {
    if ((this.state & 8) != 0)
      throw new InvalidOperationException("Finish() already called");
    this.engine.SetInput(input, offset, count);
  }

  public void SetLevel(int level)
  {
    if (level == -1)
      level = 6;
    else if ((level < 0 ? 1 : (level > 9 ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (level));
    if (this.level == level)
      return;
    this.level = level;
    this.engine.SetLevel(level);
  }

  public int GetLevel() => this.level;

  public void SetStrategy(DeflateStrategy strategy) => this.engine.Strategy = strategy;

  public int Deflate(byte[] output) => this.Deflate(output, 0, output.Length);

  public int Deflate(byte[] output, int offset, int length)
  {
    int num1 = length;
    if (this.state == (int) sbyte.MaxValue)
      throw new InvalidOperationException("Deflater closed");
    if (this.state < 16 /*0x10*/)
    {
      int num2 = 30720;
      int num3 = this.level - 1 >> 1;
      if ((num3 < 0 ? 1 : (num3 > 3 ? 1 : 0)) != 0)
        num3 = 3;
      int num4 = num2 | num3 << 6;
      if ((this.state & 1) != 0)
        num4 |= 32 /*0x20*/;
      this.pending.WriteShortMSB(num4 + (31 /*0x1F*/ - num4 % 31 /*0x1F*/));
      if ((this.state & 1) != 0)
      {
        int adler = this.engine.Adler;
        this.engine.ResetAdler();
        this.pending.WriteShortMSB(adler >> 16 /*0x10*/);
        this.pending.WriteShortMSB(adler & (int) ushort.MaxValue);
      }
      this.state = 16 /*0x10*/ | this.state & 12;
    }
    while (true)
    {
      do
      {
        do
        {
          int num5 = this.pending.Flush(output, offset, length);
          offset += num5;
          this.totalOut += (long) num5;
          length -= num5;
          if ((length == 0 ? 1 : (this.state == 30 ? 1 : 0)) != 0)
            goto label_23;
        }
        while (this.engine.Deflate((this.state & 4) != 0, (this.state & 8) != 0));
        if (this.state != 16 /*0x10*/)
        {
          if (this.state == 20)
            goto label_13;
        }
        else
          goto label_24;
      }
      while (this.state != 28);
      goto label_19;
label_13:
      if (this.level != 0)
      {
        for (int index = 8 + (-this.pending.BitCount & 7); index > 0; index -= 10)
          this.pending.WriteBits(2, 10);
      }
      this.state = 16 /*0x10*/;
      continue;
label_19:
      this.pending.AlignToByte();
      if (!this.noZlibHeaderOrFooter)
      {
        int adler = this.engine.Adler;
        this.pending.WriteShortMSB(adler >> 16 /*0x10*/);
        this.pending.WriteShortMSB(adler & (int) ushort.MaxValue);
      }
      this.state = 30;
    }
label_23:
    int num6 = num1 - length;
    goto label_25;
label_24:
    num6 = num1 - length;
label_25:
    return num6;
  }

  public void SetDictionary(byte[] dictionary)
  {
    this.SetDictionary(dictionary, 0, dictionary.Length);
  }

  public void SetDictionary(byte[] dictionary, int index, int count)
  {
    this.state = this.state == 0 ? 1 : throw new InvalidOperationException();
    this.engine.SetDictionary(dictionary, index, count);
  }
}
