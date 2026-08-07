// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Zlib.ZOutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Zlib;

public class ZOutputStream : BaseOutputStream
{
  private const int BufferSize = 4096 /*0x1000*/;
  protected ZStream z;
  protected int flushLevel;
  protected byte[] buf = new byte[4096 /*0x1000*/];
  protected byte[] buf1 = new byte[1];
  protected bool compress;
  protected Stream output;
  protected bool closed;

  private static ZStream GetDefaultZStream(bool nowrap)
  {
    ZStream defaultZstream = new ZStream();
    defaultZstream.inflateInit(nowrap);
    return defaultZstream;
  }

  public ZOutputStream(Stream output)
    : this(output, false)
  {
  }

  public ZOutputStream(Stream output, bool nowrap)
    : this(output, ZOutputStream.GetDefaultZStream(nowrap))
  {
  }

  public ZOutputStream(Stream output, ZStream z)
  {
    if (z == null)
      z = new ZStream();
    if (z.istate == null && z.dstate == null)
      z.inflateInit();
    this.output = output;
    this.compress = z.istate == null;
    this.z = z;
  }

  public ZOutputStream(Stream output, int level)
    : this(output, level, false)
  {
  }

  public ZOutputStream(Stream output, int level, bool nowrap)
  {
    this.output = output;
    this.compress = true;
    this.z = new ZStream();
    this.z.deflateInit(level, nowrap);
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

  private void ImplDisposing(bool disposeOutput)
  {
    if (this.closed)
      return;
    try
    {
      this.Finish();
    }
    catch (IOException ex)
    {
    }
    finally
    {
      this.closed = true;
      this.End();
      if (disposeOutput)
        this.output.Dispose();
      this.output = (Stream) null;
    }
  }

  public virtual void End()
  {
    if (this.z == null)
      return;
    if (this.compress)
      this.z.deflateEnd();
    else
      this.z.inflateEnd();
    this.z.free();
    this.z = (ZStream) null;
  }

  public virtual void Finish()
  {
    do
    {
      this.z.next_out = this.buf;
      this.z.next_out_index = 0;
      this.z.avail_out = this.buf.Length;
      switch (!this.compress ? this.z.inflate(4) : this.z.deflate(4))
      {
        case 0:
        case 1:
          int count = this.buf.Length - this.z.avail_out;
          if (count > 0)
            this.output.Write(this.buf, 0, count);
          continue;
        default:
          goto label_4;
      }
    }
    while (this.z.avail_in > 0 || this.z.avail_out == 0);
    goto label_5;
label_4:
    throw new IOException($"{(this.compress ? "de" : "in")}flating: {this.z.msg}");
label_5:
    this.Flush();
  }

  public override void Flush() => this.output.Flush();

  public virtual int FlushMode
  {
    get => this.flushLevel;
    set => this.flushLevel = value;
  }

  public virtual long TotalIn => this.z.total_in;

  public virtual long TotalOut => this.z.total_out;

  public override void Write(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (count != 0)
    {
      this.z.next_in = buffer;
      this.z.next_in_index = offset;
      this.z.avail_in = count;
      do
      {
        this.z.next_out = this.buf;
        this.z.next_out_index = 0;
        this.z.avail_out = this.buf.Length;
        if ((this.compress ? this.z.deflate(this.flushLevel) : this.z.inflate(this.flushLevel)) == 0)
          this.output.Write(this.buf, 0, this.buf.Length - this.z.avail_out);
        else
          goto label_6;
      }
      while (this.z.avail_in > 0 || this.z.avail_out == 0);
      return;
label_6:
      throw new IOException($"{(this.compress ? "de" : "in")}flating: {this.z.msg}");
    }
  }

  public override void WriteByte(byte value)
  {
    this.buf1[0] = value;
    this.Write(this.buf1, 0, 1);
  }
}
