// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Zlib.InfBlocks
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Utilities.Zlib;

internal sealed class InfBlocks
{
  private const int MANY = 1440;
  private static readonly int[] inflate_mask = new int[17]
  {
    0,
    1,
    3,
    7,
    15,
    31 /*0x1F*/,
    63 /*0x3F*/,
    (int) sbyte.MaxValue,
    (int) byte.MaxValue,
    511 /*0x01FF*/,
    1023 /*0x03FF*/,
    2047 /*0x07FF*/,
    4095 /*0x0FFF*/,
    8191 /*0x1FFF*/,
    16383 /*0x3FFF*/,
    (int) short.MaxValue,
    (int) ushort.MaxValue
  };
  private static readonly int[] border = new int[19]
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
  private const int Z_OK = 0;
  private const int Z_STREAM_END = 1;
  private const int Z_NEED_DICT = 2;
  private const int Z_ERRNO = -1;
  private const int Z_STREAM_ERROR = -2;
  private const int Z_DATA_ERROR = -3;
  private const int Z_MEM_ERROR = -4;
  private const int Z_BUF_ERROR = -5;
  private const int Z_VERSION_ERROR = -6;
  private const int TYPE = 0;
  private const int LENS = 1;
  private const int STORED = 2;
  private const int TABLE = 3;
  private const int BTREE = 4;
  private const int DTREE = 5;
  private const int CODES = 6;
  private const int DRY = 7;
  private const int DONE = 8;
  private const int BAD = 9;
  internal int mode;
  internal int left;
  internal int table;
  internal int index;
  internal int[] blens;
  internal int[] bb = new int[1];
  internal int[] tb = new int[1];
  internal InfCodes codes = new InfCodes();
  private int last;
  internal int bitk;
  internal int bitb;
  internal int[] hufts;
  internal byte[] window;
  internal int end;
  internal int read;
  internal int write;
  internal object checkfn;
  internal long check;
  internal InfTree inftree = new InfTree();

  internal InfBlocks(ZStream z, object checkfn, int w)
  {
    this.hufts = new int[4320];
    this.window = new byte[w];
    this.end = w;
    this.checkfn = checkfn;
    this.mode = 0;
    this.reset(z, (long[]) null);
  }

  internal void reset(ZStream z, long[] c)
  {
    if (c != null)
      c[0] = this.check;
    if (this.mode == 4)
      ;
    if (this.mode == 6)
      this.codes.free(z);
    this.mode = 0;
    this.bitk = 0;
    this.bitb = 0;
    this.write = 0;
    this.read = 0;
    if (this.checkfn == null)
      return;
    z.adler = this.check = z._adler.adler32(0L, (byte[]) null, 0, 0);
  }

  internal int proc(ZStream z, int r)
  {
    int nextInIndex = z.next_in_index;
    int availIn = z.avail_in;
    int num1 = this.bitb;
    int num2 = this.bitk;
    int destinationIndex = this.write;
    int num3 = destinationIndex < this.read ? this.read - destinationIndex - 1 : this.end - destinationIndex;
    int num4;
    int num5;
    while (true)
    {
      int length1;
      do
      {
        switch (this.mode)
        {
          case 0:
            goto label_61;
          case 1:
            goto label_56;
          case 2:
            if (availIn != 0)
            {
              if (num3 == 0)
              {
                if (destinationIndex == this.end && this.read != 0)
                {
                  destinationIndex = 0;
                  num3 = 0 < this.read ? this.read - destinationIndex - 1 : this.end - destinationIndex;
                }
                if (num3 == 0)
                {
                  this.write = destinationIndex;
                  r = this.inflate_flush(z, r);
                  destinationIndex = this.write;
                  num3 = destinationIndex < this.read ? this.read - destinationIndex - 1 : this.end - destinationIndex;
                  if (destinationIndex == this.end && this.read != 0)
                  {
                    destinationIndex = 0;
                    num3 = 0 < this.read ? this.read - destinationIndex - 1 : this.end - destinationIndex;
                  }
                  if (num3 == 0)
                    goto label_73;
                }
              }
              r = 0;
              length1 = this.left;
              if (length1 > availIn)
                length1 = availIn;
              if (length1 > num3)
                length1 = num3;
              Array.Copy((Array) z.next_in, nextInIndex, (Array) this.window, destinationIndex, length1);
              nextInIndex += length1;
              availIn -= length1;
              destinationIndex += length1;
              num3 -= length1;
              continue;
            }
            goto label_72;
          case 3:
            goto label_32;
          case 4:
            goto label_25;
          case 5:
            goto label_18;
          case 6:
            goto label_1;
          case 7:
            goto label_87;
          case 8:
            goto label_90;
          case 9:
            goto label_91;
          default:
            goto label_67;
        }
      }
      while ((this.left -= length1) != 0);
      goto label_53;
label_1:
      this.bitb = num1;
      this.bitk = num2;
      z.avail_in = availIn;
      z.total_in += (long) (nextInIndex - z.next_in_index);
      z.next_in_index = nextInIndex;
      this.write = destinationIndex;
      if ((r = this.codes.proc(this, z, r)) == 1)
      {
        r = 0;
        this.codes.free(z);
        nextInIndex = z.next_in_index;
        availIn = z.avail_in;
        num1 = this.bitb;
        num2 = this.bitk;
        destinationIndex = this.write;
        num3 = destinationIndex < this.read ? this.read - destinationIndex - 1 : this.end - destinationIndex;
        if (this.last == 0)
        {
          this.mode = 0;
          continue;
        }
        goto label_86;
      }
      goto label_85;
label_18:
      while (true)
      {
        int table1 = this.table;
        if (this.index < 258 + (table1 & 31 /*0x1F*/) + (table1 >> 5 & 31 /*0x1F*/))
        {
          int index1;
          for (index1 = this.bb[0]; num2 < index1; num2 += 8)
          {
            if (availIn != 0)
            {
              r = 0;
              --availIn;
              num1 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num2;
            }
            else
            {
              this.bitb = num1;
              this.bitk = num2;
              z.avail_in = availIn;
              z.total_in += (long) (nextInIndex - z.next_in_index);
              z.next_in_index = nextInIndex;
              this.write = destinationIndex;
              return this.inflate_flush(z, r);
            }
          }
          int huft1 = this.hufts[(this.tb[0] + (num1 & InfBlocks.inflate_mask[index1])) * 3 + 1];
          int huft2 = this.hufts[(this.tb[0] + (num1 & InfBlocks.inflate_mask[huft1])) * 3 + 2];
          if (huft2 < 16 /*0x10*/)
          {
            num1 >>= huft1;
            num2 -= huft1;
            this.blens[this.index++] = huft2;
          }
          else
          {
            int index2 = huft2 == 18 ? 7 : huft2 - 14;
            int num6 = huft2 == 18 ? 11 : 3;
            for (; num2 < huft1 + index2; num2 += 8)
            {
              if (availIn != 0)
              {
                r = 0;
                --availIn;
                num1 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num2;
              }
              else
              {
                this.bitb = num1;
                this.bitk = num2;
                z.avail_in = availIn;
                z.total_in += (long) (nextInIndex - z.next_in_index);
                z.next_in_index = nextInIndex;
                this.write = destinationIndex;
                return this.inflate_flush(z, r);
              }
            }
            int num7 = num1 >> huft1;
            int num8 = num2 - huft1;
            int num9 = num6 + (num7 & InfBlocks.inflate_mask[index2]);
            num1 = num7 >> index2;
            num2 = num8 - index2;
            int index3 = this.index;
            int table2 = this.table;
            if (index3 + num9 <= 258 + (table2 & 31 /*0x1F*/) + (table2 >> 5 & 31 /*0x1F*/) && (huft2 != 16 /*0x10*/ || index3 >= 1))
            {
              int blen = huft2 == 16 /*0x10*/ ? this.blens[index3 - 1] : 0;
              do
              {
                this.blens[index3++] = blen;
              }
              while (--num9 != 0);
              this.index = index3;
            }
            else
              goto label_80;
          }
        }
        else
          break;
      }
      this.tb[0] = -1;
      int[] bl1 = new int[1];
      int[] bd1 = new int[1];
      int[] tl1 = new int[1];
      int[] td1 = new int[1];
      bl1[0] = 9;
      bd1[0] = 6;
      int table = this.table;
      num4 = this.inftree.inflate_trees_dynamic(257 + (table & 31 /*0x1F*/), 1 + (table >> 5 & 31 /*0x1F*/), this.blens, bl1, bd1, tl1, td1, this.hufts, z);
      switch (num4)
      {
        case -3:
          goto label_83;
        case 0:
          this.codes.init(bl1[0], bd1[0], this.hufts, tl1[0], this.hufts, td1[0], z);
          this.mode = 6;
          goto label_1;
        default:
          goto label_84;
      }
label_25:
      while (this.index < 4 + (this.table >> 10))
      {
        for (; num2 < 3; num2 += 8)
        {
          if (availIn != 0)
          {
            r = 0;
            --availIn;
            num1 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num2;
          }
          else
          {
            this.bitb = num1;
            this.bitk = num2;
            z.avail_in = availIn;
            z.total_in += (long) (nextInIndex - z.next_in_index);
            z.next_in_index = nextInIndex;
            this.write = destinationIndex;
            return this.inflate_flush(z, r);
          }
        }
        this.blens[InfBlocks.border[this.index++]] = num1 & 7;
        num1 >>= 3;
        num2 -= 3;
      }
      while (this.index < 19)
        this.blens[InfBlocks.border[this.index++]] = 0;
      this.bb[0] = 7;
      num5 = this.inftree.inflate_trees_bits(this.blens, this.bb, this.tb, this.hufts, z);
      if (num5 == 0)
      {
        this.index = 0;
        this.mode = 5;
        goto label_18;
      }
      goto label_76;
label_32:
      for (; num2 < 14; num2 += 8)
      {
        if (availIn != 0)
        {
          r = 0;
          --availIn;
          num1 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num2;
        }
        else
        {
          this.bitb = num1;
          this.bitk = num2;
          z.avail_in = availIn;
          z.total_in += (long) (nextInIndex - z.next_in_index);
          z.next_in_index = nextInIndex;
          this.write = destinationIndex;
          return this.inflate_flush(z, r);
        }
      }
      int num10;
      this.table = num10 = num1 & 16383 /*0x3FFF*/;
      if ((num10 & 31 /*0x1F*/) <= 29 && (num10 >> 5 & 31 /*0x1F*/) <= 29)
      {
        int length2 = 258 + (num10 & 31 /*0x1F*/) + (num10 >> 5 & 31 /*0x1F*/);
        if (this.blens != null && this.blens.Length >= length2)
        {
          for (int index = 0; index < length2; ++index)
            this.blens[index] = 0;
        }
        else
          this.blens = new int[length2];
        num1 >>= 14;
        num2 -= 14;
        this.index = 0;
        this.mode = 4;
        goto label_25;
      }
      goto label_74;
label_53:
      this.mode = this.last != 0 ? 7 : 0;
      continue;
label_56:
      for (; num2 < 32 /*0x20*/; num2 += 8)
      {
        if (availIn != 0)
        {
          r = 0;
          --availIn;
          num1 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num2;
        }
        else
        {
          this.bitb = num1;
          this.bitk = num2;
          z.avail_in = availIn;
          z.total_in += (long) (nextInIndex - z.next_in_index);
          z.next_in_index = nextInIndex;
          this.write = destinationIndex;
          return this.inflate_flush(z, r);
        }
      }
      if ((~num1 >> 16 /*0x10*/ & (int) ushort.MaxValue) == (num1 & (int) ushort.MaxValue))
      {
        this.left = num1 & (int) ushort.MaxValue;
        num2 = 0;
        num1 = 0;
        this.mode = this.left != 0 ? 2 : (this.last != 0 ? 7 : 0);
        continue;
      }
      goto label_70;
label_61:
      for (; num2 < 3; num2 += 8)
      {
        if (availIn != 0)
        {
          r = 0;
          --availIn;
          num1 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num2;
        }
        else
        {
          this.bitb = num1;
          this.bitk = num2;
          z.avail_in = availIn;
          z.total_in += (long) (nextInIndex - z.next_in_index);
          z.next_in_index = nextInIndex;
          this.write = destinationIndex;
          return this.inflate_flush(z, r);
        }
      }
      int num11 = num1 & 7;
      this.last = num11 & 1;
      switch (num11 >> 1)
      {
        case 0:
          int num12 = num1 >> 3;
          int num13 = num2 - 3;
          int num14 = num13 & 7;
          num1 = num12 >> num14;
          num2 = num13 - num14;
          this.mode = 1;
          continue;
        case 1:
          int[] bl2 = new int[1];
          int[] bd2 = new int[1];
          int[][] tl2 = new int[1][];
          int[][] td2 = new int[1][];
          InfTree.inflate_trees_fixed(bl2, bd2, tl2, td2, z);
          this.codes.init(bl2[0], bd2[0], tl2[0], 0, td2[0], 0, z);
          num1 >>= 3;
          num2 -= 3;
          this.mode = 6;
          continue;
        case 2:
          num1 >>= 3;
          num2 -= 3;
          this.mode = 3;
          continue;
        case 3:
          goto label_68;
        default:
          continue;
      }
    }
label_67:
    r = -2;
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, -2);
label_68:
    int num15 = num1 >> 3;
    int num16 = num2 - 3;
    this.mode = 9;
    z.msg = "invalid block type";
    r = -3;
    this.bitb = num15;
    this.bitk = num16;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, -3);
label_70:
    this.mode = 9;
    z.msg = "invalid stored block lengths";
    r = -3;
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, -3);
label_72:
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, r);
label_73:
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, r);
label_74:
    this.mode = 9;
    z.msg = "too many length or distance symbols";
    r = -3;
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, -3);
label_76:
    r = num5;
    if (r == -3)
    {
      this.blens = (int[]) null;
      this.mode = 9;
    }
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, r);
label_80:
    this.blens = (int[]) null;
    this.mode = 9;
    z.msg = "invalid bit length repeat";
    r = -3;
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, -3);
label_83:
    this.blens = (int[]) null;
    this.mode = 9;
label_84:
    r = num4;
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, r);
label_85:
    return this.inflate_flush(z, r);
label_86:
    this.mode = 7;
label_87:
    this.write = destinationIndex;
    r = this.inflate_flush(z, r);
    destinationIndex = this.write;
    int num17 = destinationIndex < this.read ? this.read - destinationIndex - 1 : this.end - destinationIndex;
    if (this.read != this.write)
    {
      this.bitb = num1;
      this.bitk = num2;
      z.avail_in = availIn;
      z.total_in += (long) (nextInIndex - z.next_in_index);
      z.next_in_index = nextInIndex;
      this.write = destinationIndex;
      return this.inflate_flush(z, r);
    }
    this.mode = 8;
label_90:
    r = 1;
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, 1);
label_91:
    r = -3;
    this.bitb = num1;
    this.bitk = num2;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    this.write = destinationIndex;
    return this.inflate_flush(z, -3);
  }

  internal void free(ZStream z)
  {
    this.reset(z, (long[]) null);
    this.window = (byte[]) null;
    this.hufts = (int[]) null;
  }

  internal void set_dictionary(byte[] d, int start, int n)
  {
    Array.Copy((Array) d, start, (Array) this.window, 0, n);
    this.read = this.write = n;
  }

  internal int sync_point() => this.mode != 1 ? 0 : 1;

  internal int inflate_flush(ZStream z, int r)
  {
    int nextOutIndex = z.next_out_index;
    int read = this.read;
    int num1 = (read <= this.write ? this.write : this.end) - read;
    if (num1 > z.avail_out)
      num1 = z.avail_out;
    if (num1 != 0 && r == -5)
      r = 0;
    z.avail_out -= num1;
    z.total_out += (long) num1;
    if (this.checkfn != null)
      z.adler = this.check = z._adler.adler32(this.check, this.window, read, num1);
    Array.Copy((Array) this.window, read, (Array) z.next_out, nextOutIndex, num1);
    int destinationIndex = nextOutIndex + num1;
    int num2 = read + num1;
    if (num2 == this.end)
    {
      int num3 = 0;
      if (this.write == this.end)
        this.write = 0;
      int num4 = this.write - num3;
      if (num4 > z.avail_out)
        num4 = z.avail_out;
      if (num4 != 0 && r == -5)
        r = 0;
      z.avail_out -= num4;
      z.total_out += (long) num4;
      if (this.checkfn != null)
        z.adler = this.check = z._adler.adler32(this.check, this.window, num3, num4);
      Array.Copy((Array) this.window, num3, (Array) z.next_out, destinationIndex, num4);
      destinationIndex += num4;
      num2 = num3 + num4;
    }
    z.next_out_index = destinationIndex;
    this.read = num2;
    return r;
  }
}
