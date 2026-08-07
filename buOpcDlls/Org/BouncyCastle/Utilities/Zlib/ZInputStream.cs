// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Zlib.ZInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Zlib;

public class ZInputStream : BaseInputStream
{
  private const int BufferSize = 4096 /*0x1000*/;
  protected ZStream z;
  protected int flushLevel;
  protected byte[] buf = new byte[4096 /*0x1000*/];
  protected byte[] buf1 = new byte[1];
  protected bool compress;
  protected Stream input;
  protected bool closed;
  private bool nomoreinput;

  private static ZStream GetDefaultZStream(bool nowrap)
  {
    ZStream defaultZstream = new ZStream();
    defaultZstream.inflateInit(nowrap);
    return defaultZstream;
  }

  public ZInputStream(Stream input)
    : this(input, false)
  {
  }

  public ZInputStream(Stream input, bool nowrap)
    : this(input, ZInputStream.GetDefaultZStream(nowrap))
  {
  }

  public ZInputStream(Stream input, ZStream z)
  {
    if (z == null)
      z = new ZStream();
    if (z.istate == null && z.dstate == null)
      z.inflateInit();
    this.input = input;
    this.compress = z.istate == null;
    this.z = z;
    this.z.next_in = this.buf;
    this.z.next_in_index = 0;
    this.z.avail_in = 0;
  }

  public ZInputStream(Stream input, int level)
    : this(input, level, false)
  {
  }

  public ZInputStream(Stream input, int level, bool nowrap)
  {
    this.input = input;
    this.compress = true;
    this.z = new ZStream();
    this.z.deflateInit(level, nowrap);
    this.z.next_in = this.buf;
    this.z.next_in_index = 0;
    this.z.avail_in = 0;
  }

  protected void Detach(bool disposing)
  {
    if (disposing)
      this.ImplDisposing(false);
    base.Dispose(disposing);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.ImplDisposing(true);
    base.Dispose(disposing);
  }

  private void ImplDisposing(bool disposeInput)
  {
    if (this.closed)
      return;
    this.closed = true;
    if (!disposeInput)
      return;
    this.input.Dispose();
  }

  public virtual int FlushMode
  {
    get => this.flushLevel;
    set => this.flushLevel = value;
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (count == 0)
      return 0;
    this.z.next_out = buffer;
    this.z.next_out_index = offset;
    this.z.avail_out = count;
    int num;
    do
    {
      if (this.z.avail_in == 0 && !this.nomoreinput)
        goto label_7;
label_3:
      num = this.compress ? this.z.deflate(this.flushLevel) : this.z.inflate(this.flushLevel);
      if (!this.nomoreinput || num != -5)
      {
        if (num == 0 || num == 1)
        {
          if (!this.nomoreinput && num != 1 || this.z.avail_out != count)
            continue;
          goto label_12;
        }
        goto label_11;
      }
      goto label_10;
label_7:
      this.z.next_in_index = 0;
      this.z.avail_in = this.input.Read(this.buf, 0, this.buf.Length);
      if (this.z.avail_in <= 0)
      {
        this.z.avail_in = 0;
        this.nomoreinput = true;
        goto label_3;
      }
      goto label_3;
    }
    while (this.z.avail_out == count && num == 0);
    goto label_13;
label_10:
    return 0;
label_11:
    throw new IOException($"{(this.compress ? "de" : "in")}flating: {this.z.msg}");
label_12:
    return 0;
label_13:
    return count - this.z.avail_out;
  }

  public override int ReadByte() => this.Read(this.buf1, 0, 1) <= 0 ? -1 : (int) this.buf1[0];

  public virtual long TotalIn => this.z.total_in;

  public virtual long TotalOut => this.z.total_out;
}
