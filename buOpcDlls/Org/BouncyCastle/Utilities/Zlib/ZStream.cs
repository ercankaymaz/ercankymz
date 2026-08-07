// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Zlib.ZStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Utilities.Zlib;

public sealed class ZStream
{
  private const int MAX_WBITS = 15;
  private const int DEF_WBITS = 15;
  private const int Z_NO_FLUSH = 0;
  private const int Z_PARTIAL_FLUSH = 1;
  private const int Z_SYNC_FLUSH = 2;
  private const int Z_FULL_FLUSH = 3;
  private const int Z_FINISH = 4;
  private const int MAX_MEM_LEVEL = 9;
  private const int Z_OK = 0;
  private const int Z_STREAM_END = 1;
  private const int Z_NEED_DICT = 2;
  private const int Z_ERRNO = -1;
  private const int Z_STREAM_ERROR = -2;
  private const int Z_DATA_ERROR = -3;
  private const int Z_MEM_ERROR = -4;
  private const int Z_BUF_ERROR = -5;
  private const int Z_VERSION_ERROR = -6;
  public byte[] next_in;
  public int next_in_index;
  public int avail_in;
  public long total_in;
  public byte[] next_out;
  public int next_out_index;
  public int avail_out;
  public long total_out;
  public string msg;
  internal Deflate dstate;
  internal Inflate istate;
  internal int data_type;
  public long adler;
  internal Adler32 _adler = new Adler32();

  public int inflateInit() => this.inflateInit(15);

  public int inflateInit(bool nowrap) => this.inflateInit(15, nowrap);

  public int inflateInit(int w) => this.inflateInit(w, false);

  public int inflateInit(int w, bool nowrap)
  {
    this.istate = new Inflate();
    return this.istate.inflateInit(this, nowrap ? -w : w);
  }

  public int inflate(int f) => this.istate == null ? -2 : this.istate.inflate(this, f);

  public int inflateEnd()
  {
    if (this.istate == null)
      return -2;
    int num = this.istate.inflateEnd(this);
    this.istate = (Inflate) null;
    return num;
  }

  public int inflateSync() => this.istate == null ? -2 : this.istate.inflateSync(this);

  public int inflateSetDictionary(byte[] dictionary, int dictLength)
  {
    return this.istate == null ? -2 : this.istate.inflateSetDictionary(this, dictionary, dictLength);
  }

  public int deflateInit(int level) => this.deflateInit(level, 15);

  public int deflateInit(int level, bool nowrap) => this.deflateInit(level, 15, nowrap);

  public int deflateInit(int level, int bits) => this.deflateInit(level, bits, false);

  public int deflateInit(int level, int bits, bool nowrap)
  {
    this.dstate = new Deflate();
    return this.dstate.deflateInit(this, level, nowrap ? -bits : bits);
  }

  public int deflate(int flush) => this.dstate == null ? -2 : this.dstate.deflate(this, flush);

  public int deflateEnd()
  {
    if (this.dstate == null)
      return -2;
    int num = this.dstate.deflateEnd();
    this.dstate = (Deflate) null;
    return num;
  }

  public int deflateParams(int level, int strategy)
  {
    return this.dstate == null ? -2 : this.dstate.deflateParams(this, level, strategy);
  }

  public int deflateSetDictionary(byte[] dictionary, int dictLength)
  {
    return this.dstate == null ? -2 : this.dstate.deflateSetDictionary(this, dictionary, dictLength);
  }

  internal void flush_pending()
  {
    int length = this.dstate.pending;
    if (length > this.avail_out)
      length = this.avail_out;
    if (length == 0)
      return;
    if (this.dstate.pending_buf.Length <= this.dstate.pending_out || this.next_out.Length <= this.next_out_index || this.dstate.pending_buf.Length >= this.dstate.pending_out + length)
      ;
    Array.Copy((Array) this.dstate.pending_buf, this.dstate.pending_out, (Array) this.next_out, this.next_out_index, length);
    this.next_out_index += length;
    this.dstate.pending_out += length;
    this.total_out += (long) length;
    this.avail_out -= length;
    this.dstate.pending -= length;
    if (this.dstate.pending != 0)
      return;
    this.dstate.pending_out = 0;
  }

  internal int read_buf(byte[] buf, int start, int size)
  {
    int num = this.avail_in;
    if (num > size)
      num = size;
    if (num == 0)
      return 0;
    this.avail_in -= num;
    if (this.dstate.noheader == 0)
      this.adler = this._adler.adler32(this.adler, this.next_in, this.next_in_index, num);
    Array.Copy((Array) this.next_in, this.next_in_index, (Array) buf, start, num);
    this.next_in_index += num;
    this.total_in += (long) num;
    return num;
  }

  public void free()
  {
    this.next_in = (byte[]) null;
    this.next_out = (byte[]) null;
    this.msg = (string) null;
    this._adler = (Adler32) null;
  }
}
