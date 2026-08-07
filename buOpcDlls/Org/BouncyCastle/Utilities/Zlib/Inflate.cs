// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Zlib.Inflate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Utilities.Zlib;

internal sealed class Inflate
{
  private const int MAX_WBITS = 15;
  private const int PRESET_DICT = 32 /*0x20*/;
  internal const int Z_NO_FLUSH = 0;
  internal const int Z_PARTIAL_FLUSH = 1;
  internal const int Z_SYNC_FLUSH = 2;
  internal const int Z_FULL_FLUSH = 3;
  internal const int Z_FINISH = 4;
  private const int Z_DEFLATED = 8;
  private const int Z_OK = 0;
  private const int Z_STREAM_END = 1;
  private const int Z_NEED_DICT = 2;
  private const int Z_ERRNO = -1;
  private const int Z_STREAM_ERROR = -2;
  private const int Z_DATA_ERROR = -3;
  private const int Z_MEM_ERROR = -4;
  private const int Z_BUF_ERROR = -5;
  private const int Z_VERSION_ERROR = -6;
  private const int METHOD = 0;
  private const int FLAG = 1;
  private const int DICT4 = 2;
  private const int DICT3 = 3;
  private const int DICT2 = 4;
  private const int DICT1 = 5;
  private const int DICT0 = 6;
  private const int BLOCKS = 7;
  private const int CHECK4 = 8;
  private const int CHECK3 = 9;
  private const int CHECK2 = 10;
  private const int CHECK1 = 11;
  private const int DONE = 12;
  private const int BAD = 13;
  internal int mode;
  internal int method;
  internal long[] was = new long[1];
  internal long need;
  internal int marker;
  internal int nowrap;
  internal int wbits;
  internal InfBlocks blocks;
  private static readonly byte[] mark = new byte[4]
  {
    (byte) 0,
    (byte) 0,
    byte.MaxValue,
    byte.MaxValue
  };

  internal int inflateReset(ZStream z)
  {
    if (z == null || z.istate == null)
      return -2;
    ZStream zstream = z;
    z.total_out = 0L;
    zstream.total_in = 0L;
    z.msg = (string) null;
    z.istate.mode = z.istate.nowrap != 0 ? 7 : 0;
    z.istate.blocks.reset(z, (long[]) null);
    return 0;
  }

  internal int inflateEnd(ZStream z)
  {
    if (this.blocks != null)
      this.blocks.free(z);
    this.blocks = (InfBlocks) null;
    return 0;
  }

  internal int inflateInit(ZStream z, int w)
  {
    z.msg = (string) null;
    this.blocks = (InfBlocks) null;
    this.nowrap = 0;
    if (w < 0)
    {
      w = -w;
      this.nowrap = 1;
    }
    if (w >= 8 && w <= 15)
    {
      this.wbits = w;
      z.istate.blocks = new InfBlocks(z, z.istate.nowrap != 0 ? (object) (Inflate) null : (object) this, 1 << w);
      this.inflateReset(z);
      return 0;
    }
    this.inflateEnd(z);
    return -2;
  }

  internal int inflate(ZStream z, int f)
  {
    if (z == null || z.istate == null || z.next_in == null)
      return -2;
    f = f == 4 ? -5 : 0;
    int r = -5;
    while (true)
    {
      switch (z.istate.mode)
      {
        case 0:
          if (z.avail_in != 0)
          {
            r = f;
            --z.avail_in;
            ++z.total_in;
            Inflate istate = z.istate;
            byte[] nextIn = z.next_in;
            int index = z.next_in_index++;
            int num1;
            int num2 = num1 = (int) nextIn[index];
            istate.method = num1;
            if ((num2 & 15) != 8)
            {
              z.istate.mode = 13;
              z.msg = "unknown compression method";
              z.istate.marker = 5;
              continue;
            }
            if ((z.istate.method >> 4) + 8 > z.istate.wbits)
            {
              z.istate.mode = 13;
              z.msg = "invalid window size";
              z.istate.marker = 5;
              continue;
            }
            z.istate.mode = 1;
            goto case 1;
          }
          goto label_32;
        case 1:
          if (z.avail_in != 0)
          {
            r = f;
            --z.avail_in;
            ++z.total_in;
            int num = (int) z.next_in[z.next_in_index++] & (int) byte.MaxValue;
            if (((z.istate.method << 8) + num) % 31 /*0x1F*/ != 0)
            {
              z.istate.mode = 13;
              z.msg = "incorrect header check";
              z.istate.marker = 5;
              continue;
            }
            if ((num & 32 /*0x20*/) == 0)
            {
              z.istate.mode = 7;
              continue;
            }
            goto label_34;
          }
          goto label_33;
        case 2:
          goto label_35;
        case 3:
          goto label_38;
        case 4:
          goto label_41;
        case 5:
          goto label_44;
        case 6:
          goto label_47;
        case 7:
          r = z.istate.blocks.proc(z, r);
          if (r == -3)
          {
            z.istate.mode = 13;
            z.istate.marker = 0;
            continue;
          }
          if (r == 0)
            r = f;
          if (r == 1)
          {
            r = f;
            z.istate.blocks.reset(z, z.istate.was);
            if (z.istate.nowrap != 0)
            {
              z.istate.mode = 12;
              continue;
            }
            z.istate.mode = 8;
            goto case 8;
          }
          goto label_48;
        case 8:
          if (z.avail_in != 0)
          {
            r = f;
            --z.avail_in;
            ++z.total_in;
            z.istate.need = (long) (((int) z.next_in[z.next_in_index++] & (int) byte.MaxValue) << 24) & 4278190080L /*0xFF000000*/;
            z.istate.mode = 9;
            goto case 9;
          }
          goto label_49;
        case 9:
          if (z.avail_in != 0)
          {
            r = f;
            --z.avail_in;
            ++z.total_in;
            z.istate.need += (long) (((int) z.next_in[z.next_in_index++] & (int) byte.MaxValue) << 16 /*0x10*/) & 16711680L /*0xFF0000*/;
            z.istate.mode = 10;
            goto case 10;
          }
          goto label_50;
        case 10:
          if (z.avail_in != 0)
          {
            r = f;
            --z.avail_in;
            ++z.total_in;
            z.istate.need += (long) (((int) z.next_in[z.next_in_index++] & (int) byte.MaxValue) << 8) & 65280L;
            z.istate.mode = 11;
            goto case 11;
          }
          goto label_51;
        case 11:
          if (z.avail_in != 0)
          {
            r = f;
            --z.avail_in;
            ++z.total_in;
            z.istate.need += (long) z.next_in[z.next_in_index++] & (long) byte.MaxValue;
            if ((int) z.istate.was[0] != (int) z.istate.need)
            {
              z.istate.mode = 13;
              z.msg = "incorrect data check";
              z.istate.marker = 5;
              continue;
            }
            goto label_53;
          }
          goto label_52;
        case 12:
          goto label_54;
        case 13:
          goto label_55;
        default:
          goto label_31;
      }
    }
label_31:
    return -2;
label_32:
    return r;
label_33:
    return r;
label_34:
    z.istate.mode = 2;
label_35:
    if (z.avail_in == 0)
      return r;
    r = f;
    --z.avail_in;
    ++z.total_in;
    z.istate.need = (long) (((int) z.next_in[z.next_in_index++] & (int) byte.MaxValue) << 24) & 4278190080L /*0xFF000000*/;
    z.istate.mode = 3;
label_38:
    if (z.avail_in == 0)
      return r;
    r = f;
    --z.avail_in;
    ++z.total_in;
    z.istate.need += (long) (((int) z.next_in[z.next_in_index++] & (int) byte.MaxValue) << 16 /*0x10*/) & 16711680L /*0xFF0000*/;
    z.istate.mode = 4;
label_41:
    if (z.avail_in == 0)
      return r;
    r = f;
    --z.avail_in;
    ++z.total_in;
    z.istate.need += (long) (((int) z.next_in[z.next_in_index++] & (int) byte.MaxValue) << 8) & 65280L;
    z.istate.mode = 5;
label_44:
    if (z.avail_in == 0)
      return r;
    --z.avail_in;
    ++z.total_in;
    z.istate.need += (long) z.next_in[z.next_in_index++] & (long) byte.MaxValue;
    z.adler = z.istate.need;
    z.istate.mode = 6;
    return 2;
label_47:
    z.istate.mode = 13;
    z.msg = "need dictionary";
    z.istate.marker = 0;
    return -2;
label_48:
    return r;
label_49:
    return r;
label_50:
    return r;
label_51:
    return r;
label_52:
    return r;
label_53:
    z.istate.mode = 12;
label_54:
    return 1;
label_55:
    return -3;
  }

  internal int inflateSetDictionary(ZStream z, byte[] dictionary, int dictLength)
  {
    int start = 0;
    int n = dictLength;
    if (z == null || z.istate == null || z.istate.mode != 6)
      return -2;
    if (z._adler.adler32(1L, dictionary, 0, dictLength) != z.adler)
      return -3;
    z.adler = z._adler.adler32(0L, (byte[]) null, 0, 0);
    if (n >= 1 << z.istate.wbits)
    {
      n = (1 << z.istate.wbits) - 1;
      start = dictLength - n;
    }
    z.istate.blocks.set_dictionary(dictionary, start, n);
    z.istate.mode = 7;
    return 0;
  }

  internal int inflateSync(ZStream z)
  {
    if (z == null || z.istate == null)
      return -2;
    if (z.istate.mode != 13)
    {
      z.istate.mode = 13;
      z.istate.marker = 0;
    }
    int availIn;
    if ((availIn = z.avail_in) == 0)
      return -5;
    int nextInIndex = z.next_in_index;
    int index;
    for (index = z.istate.marker; availIn != 0 && index < 4; --availIn)
    {
      if ((int) z.next_in[nextInIndex] == (int) Inflate.mark[index])
        ++index;
      else
        index = z.next_in[nextInIndex] == (byte) 0 ? 4 - index : 0;
      ++nextInIndex;
    }
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    z.avail_in = availIn;
    z.istate.marker = index;
    if (index != 4)
      return -3;
    long totalIn = z.total_in;
    long totalOut = z.total_out;
    this.inflateReset(z);
    z.total_in = totalIn;
    z.total_out = totalOut;
    z.istate.mode = 7;
    return 0;
  }

  internal int inflateSyncPoint(ZStream z)
  {
    return z != null && z.istate != null && z.istate.blocks != null ? z.istate.blocks.sync_point() : -2;
  }
}
