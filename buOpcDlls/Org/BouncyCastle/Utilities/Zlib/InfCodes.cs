// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Zlib.InfCodes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Utilities.Zlib;

internal sealed class InfCodes
{
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
  private const int Z_OK = 0;
  private const int Z_STREAM_END = 1;
  private const int Z_NEED_DICT = 2;
  private const int Z_ERRNO = -1;
  private const int Z_STREAM_ERROR = -2;
  private const int Z_DATA_ERROR = -3;
  private const int Z_MEM_ERROR = -4;
  private const int Z_BUF_ERROR = -5;
  private const int Z_VERSION_ERROR = -6;
  private const int START = 0;
  private const int LEN = 1;
  private const int LENEXT = 2;
  private const int DIST = 3;
  private const int DISTEXT = 4;
  private const int COPY = 5;
  private const int LIT = 6;
  private const int WASH = 7;
  private const int END = 8;
  private const int BADCODE = 9;
  private int mode;
  private int len;
  private int[] tree;
  private int tree_index;
  private int need;
  private int lit;
  private int get;
  private int dist;
  private byte lbits;
  private byte dbits;
  private int[] ltree;
  private int ltree_index;
  private int[] dtree;
  private int dtree_index;

  internal InfCodes()
  {
  }

  internal void init(int bl, int bd, int[] tl, int tl_index, int[] td, int td_index, ZStream z)
  {
    this.mode = 0;
    this.lbits = (byte) bl;
    this.dbits = (byte) bd;
    this.ltree = tl;
    this.ltree_index = tl_index;
    this.dtree = td;
    this.dtree_index = td_index;
    this.tree = (int[]) null;
  }

  internal int proc(InfBlocks s, ZStream z, int r)
  {
    int nextInIndex = z.next_in_index;
    int availIn = z.avail_in;
    int bitb = s.bitb;
    int bitk = s.bitk;
    int num1 = s.write;
    int num2 = num1 < s.read ? s.read - num1 - 1 : s.end - num1;
    while (true)
    {
      switch (this.mode)
      {
        case 0:
          if (num2 >= 258 && availIn >= 10)
          {
            s.bitb = bitb;
            s.bitk = bitk;
            z.avail_in = availIn;
            z.total_in += (long) (nextInIndex - z.next_in_index);
            z.next_in_index = nextInIndex;
            s.write = num1;
            r = this.inflate_fast((int) this.lbits, (int) this.dbits, this.ltree, this.ltree_index, this.dtree, this.dtree_index, s, z);
            nextInIndex = z.next_in_index;
            availIn = z.avail_in;
            bitb = s.bitb;
            bitk = s.bitk;
            num1 = s.write;
            num2 = num1 < s.read ? s.read - num1 - 1 : s.end - num1;
            int num3;
            switch (r)
            {
              case 0:
                goto label_59;
              case 1:
                num3 = 7;
                break;
              default:
                num3 = 9;
                break;
            }
            this.mode = num3;
            continue;
          }
label_59:
          this.need = (int) this.lbits;
          this.tree = this.ltree;
          this.tree_index = this.ltree_index;
          this.mode = 1;
          goto case 1;
        case 1:
          int need1;
          for (need1 = this.need; bitk < need1; bitk += 8)
          {
            if (availIn != 0)
            {
              r = 0;
              --availIn;
              bitb |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << bitk;
            }
            else
            {
              s.bitb = bitb;
              s.bitk = bitk;
              z.avail_in = availIn;
              z.total_in += (long) (nextInIndex - z.next_in_index);
              z.next_in_index = nextInIndex;
              s.write = num1;
              return s.inflate_flush(z, r);
            }
          }
          int index1 = (this.tree_index + (bitb & InfCodes.inflate_mask[need1])) * 3;
          bitb >>= this.tree[index1 + 1];
          bitk -= this.tree[index1 + 1];
          int num4 = this.tree[index1];
          if (num4 == 0)
          {
            this.lit = this.tree[index1 + 2];
            this.mode = 6;
            continue;
          }
          if ((num4 & 16 /*0x10*/) != 0)
          {
            this.get = num4 & 15;
            this.len = this.tree[index1 + 2];
            this.mode = 2;
            continue;
          }
          if ((num4 & 64 /*0x40*/) == 0)
          {
            this.need = num4;
            this.tree_index = index1 / 3 + this.tree[index1 + 2];
            continue;
          }
          if ((num4 & 32 /*0x20*/) != 0)
          {
            this.mode = 7;
            continue;
          }
          goto label_62;
        case 2:
          int get1;
          for (get1 = this.get; bitk < get1; bitk += 8)
          {
            if (availIn != 0)
            {
              r = 0;
              --availIn;
              bitb |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << bitk;
            }
            else
            {
              s.bitb = bitb;
              s.bitk = bitk;
              z.avail_in = availIn;
              z.total_in += (long) (nextInIndex - z.next_in_index);
              z.next_in_index = nextInIndex;
              s.write = num1;
              return s.inflate_flush(z, r);
            }
          }
          this.len += bitb & InfCodes.inflate_mask[get1];
          bitb >>= get1;
          bitk -= get1;
          this.need = (int) this.dbits;
          this.tree = this.dtree;
          this.tree_index = this.dtree_index;
          this.mode = 3;
          goto case 3;
        case 3:
          int need2;
          for (need2 = this.need; bitk < need2; bitk += 8)
          {
            if (availIn != 0)
            {
              r = 0;
              --availIn;
              bitb |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << bitk;
            }
            else
            {
              s.bitb = bitb;
              s.bitk = bitk;
              z.avail_in = availIn;
              z.total_in += (long) (nextInIndex - z.next_in_index);
              z.next_in_index = nextInIndex;
              s.write = num1;
              return s.inflate_flush(z, r);
            }
          }
          int index2 = (this.tree_index + (bitb & InfCodes.inflate_mask[need2])) * 3;
          bitb >>= this.tree[index2 + 1];
          bitk -= this.tree[index2 + 1];
          int num5 = this.tree[index2];
          if ((num5 & 16 /*0x10*/) != 0)
          {
            this.get = num5 & 15;
            this.dist = this.tree[index2 + 2];
            this.mode = 4;
            continue;
          }
          if ((num5 & 64 /*0x40*/) == 0)
          {
            this.need = num5;
            this.tree_index = index2 / 3 + this.tree[index2 + 2];
            continue;
          }
          goto label_65;
        case 4:
          int get2;
          for (get2 = this.get; bitk < get2; bitk += 8)
          {
            if (availIn != 0)
            {
              r = 0;
              --availIn;
              bitb |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << bitk;
            }
            else
            {
              s.bitb = bitb;
              s.bitk = bitk;
              z.avail_in = availIn;
              z.total_in += (long) (nextInIndex - z.next_in_index);
              z.next_in_index = nextInIndex;
              s.write = num1;
              return s.inflate_flush(z, r);
            }
          }
          this.dist += bitb & InfCodes.inflate_mask[get2];
          bitb >>= get2;
          bitk -= get2;
          this.mode = 5;
          goto case 5;
        case 5:
          int num6 = num1 - this.dist;
          while (num6 < 0)
            num6 += s.end;
          for (; this.len != 0; --this.len)
          {
            if (num2 == 0)
            {
              if (num1 == s.end && s.read != 0)
              {
                num1 = 0;
                num2 = 0 < s.read ? s.read - num1 - 1 : s.end - num1;
              }
              if (num2 == 0)
              {
                s.write = num1;
                r = s.inflate_flush(z, r);
                num1 = s.write;
                num2 = num1 < s.read ? s.read - num1 - 1 : s.end - num1;
                if (num1 == s.end && s.read != 0)
                {
                  num1 = 0;
                  num2 = 0 < s.read ? s.read - num1 - 1 : s.end - num1;
                }
                if (num2 == 0)
                {
                  s.bitb = bitb;
                  s.bitk = bitk;
                  z.avail_in = availIn;
                  z.total_in += (long) (nextInIndex - z.next_in_index);
                  z.next_in_index = nextInIndex;
                  s.write = num1;
                  return s.inflate_flush(z, r);
                }
              }
            }
            s.window[num1++] = s.window[num6++];
            --num2;
            if (num6 == s.end)
              num6 = 0;
          }
          this.mode = 0;
          continue;
        case 6:
          if (num2 == 0)
          {
            if (num1 == s.end && s.read != 0)
            {
              num1 = 0;
              num2 = 0 < s.read ? s.read - num1 - 1 : s.end - num1;
            }
            if (num2 == 0)
            {
              s.write = num1;
              r = s.inflate_flush(z, r);
              num1 = s.write;
              num2 = num1 < s.read ? s.read - num1 - 1 : s.end - num1;
              if (num1 == s.end && s.read != 0)
              {
                num1 = 0;
                num2 = 0 < s.read ? s.read - num1 - 1 : s.end - num1;
              }
              if (num2 == 0)
                goto label_69;
            }
          }
          r = 0;
          s.window[num1++] = (byte) this.lit;
          --num2;
          this.mode = 0;
          continue;
        case 7:
          goto label_70;
        case 8:
          goto label_75;
        case 9:
          goto label_76;
        default:
          goto label_61;
      }
    }
label_61:
    r = -2;
    s.bitb = bitb;
    s.bitk = bitk;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    s.write = num1;
    return s.inflate_flush(z, -2);
label_62:
    this.mode = 9;
    z.msg = "invalid literal/length code";
    r = -3;
    s.bitb = bitb;
    s.bitk = bitk;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    s.write = num1;
    return s.inflate_flush(z, -3);
label_65:
    this.mode = 9;
    z.msg = "invalid distance code";
    r = -3;
    s.bitb = bitb;
    s.bitk = bitk;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    s.write = num1;
    return s.inflate_flush(z, -3);
label_69:
    s.bitb = bitb;
    s.bitk = bitk;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    s.write = num1;
    return s.inflate_flush(z, r);
label_70:
    if (bitk > 7)
    {
      bitk -= 8;
      ++availIn;
      --nextInIndex;
    }
    s.write = num1;
    r = s.inflate_flush(z, r);
    num1 = s.write;
    int num7 = num1 < s.read ? s.read - num1 - 1 : s.end - num1;
    if (s.read != s.write)
    {
      s.bitb = bitb;
      s.bitk = bitk;
      z.avail_in = availIn;
      z.total_in += (long) (nextInIndex - z.next_in_index);
      z.next_in_index = nextInIndex;
      s.write = num1;
      return s.inflate_flush(z, r);
    }
    this.mode = 8;
label_75:
    r = 1;
    s.bitb = bitb;
    s.bitk = bitk;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    s.write = num1;
    return s.inflate_flush(z, 1);
label_76:
    r = -3;
    s.bitb = bitb;
    s.bitk = bitk;
    z.avail_in = availIn;
    z.total_in += (long) (nextInIndex - z.next_in_index);
    z.next_in_index = nextInIndex;
    s.write = num1;
    return s.inflate_flush(z, -3);
  }

  internal void free(ZStream z)
  {
  }

  internal int inflate_fast(
    int bl,
    int bd,
    int[] tl,
    int tl_index,
    int[] td,
    int td_index,
    InfBlocks s,
    ZStream z)
  {
    int nextInIndex = z.next_in_index;
    int availIn = z.avail_in;
    int num1 = s.bitb;
    int num2 = s.bitk;
    int destinationIndex = s.write;
    int num3 = destinationIndex < s.read ? s.read - destinationIndex - 1 : s.end - destinationIndex;
    int num4 = InfCodes.inflate_mask[bl];
    int num5 = InfCodes.inflate_mask[bd];
    int index1;
    int num6;
    int num7;
    do
    {
      for (; num2 < 20; num2 += 8)
      {
        --availIn;
        num1 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num2;
      }
      int num8 = num1 & num4;
      int[] numArray1 = tl;
      int num9 = tl_index;
      int index2 = (num9 + num8) * 3;
      if ((index1 = numArray1[index2]) == 0)
      {
        num1 >>= numArray1[index2 + 1];
        num2 -= numArray1[index2 + 1];
        s.window[destinationIndex++] = (byte) numArray1[index2 + 2];
        --num3;
      }
      else
      {
        do
        {
          num1 >>= numArray1[index2 + 1];
          num2 -= numArray1[index2 + 1];
          if ((index1 & 16 /*0x10*/) == 0)
          {
            if ((index1 & 64 /*0x40*/) == 0)
            {
              num8 = num8 + numArray1[index2 + 2] + (num1 & InfCodes.inflate_mask[index1]);
              index2 = (num9 + num8) * 3;
            }
            else
              goto label_36;
          }
          else
            goto label_7;
        }
        while ((index1 = numArray1[index2]) != 0);
        goto label_31;
label_7:
        int index3 = index1 & 15;
        int length1 = numArray1[index2 + 2] + (num1 & InfCodes.inflate_mask[index3]);
        num6 = num1 >> index3;
        for (num7 = num2 - index3; num7 < 15; num7 += 8)
        {
          --availIn;
          num6 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num7;
        }
        int num10 = num6 & num5;
        int[] numArray2 = td;
        int num11 = td_index;
        int index4 = (num11 + num10) * 3;
        int index5 = numArray2[index4];
        while (true)
        {
          num6 >>= numArray2[index4 + 1];
          num7 -= numArray2[index4 + 1];
          if ((index5 & 16 /*0x10*/) == 0)
          {
            if ((index5 & 64 /*0x40*/) == 0)
            {
              num10 = num10 + numArray2[index4 + 2] + (num6 & InfCodes.inflate_mask[index5]);
              index4 = (num11 + num10) * 3;
              index5 = numArray2[index4];
            }
            else
              goto label_34;
          }
          else
            break;
        }
        int index6;
        for (index6 = index5 & 15; num7 < index6; num7 += 8)
        {
          --availIn;
          num6 |= ((int) z.next_in[nextInIndex++] & (int) byte.MaxValue) << num7;
        }
        int num12 = numArray2[index4 + 2] + (num6 & InfCodes.inflate_mask[index6]);
        num1 = num6 >> index6;
        num2 = num7 - index6;
        num3 -= length1;
        int sourceIndex1;
        int num13;
        if (destinationIndex >= num12)
        {
          int sourceIndex2 = destinationIndex - num12;
          if (destinationIndex - sourceIndex2 > 0 && 2 > destinationIndex - sourceIndex2)
          {
            byte[] window1 = s.window;
            int index7 = destinationIndex;
            int num14 = index7 + 1;
            byte[] window2 = s.window;
            int index8 = sourceIndex2;
            int num15 = index8 + 1;
            int num16 = (int) window2[index8];
            window1[index7] = (byte) num16;
            byte[] window3 = s.window;
            int index9 = num14;
            destinationIndex = index9 + 1;
            byte[] window4 = s.window;
            int index10 = num15;
            sourceIndex1 = index10 + 1;
            int num17 = (int) window4[index10];
            window3[index9] = (byte) num17;
            length1 -= 2;
          }
          else
          {
            Array.Copy((Array) s.window, sourceIndex2, (Array) s.window, destinationIndex, 2);
            destinationIndex += 2;
            sourceIndex1 = sourceIndex2 + 2;
            length1 -= 2;
          }
        }
        else
        {
          sourceIndex1 = destinationIndex - num12;
          do
          {
            sourceIndex1 += s.end;
          }
          while (sourceIndex1 < 0);
          int length2 = s.end - sourceIndex1;
          if (length1 > length2)
          {
            length1 -= length2;
            if (destinationIndex - sourceIndex1 > 0 && length2 > destinationIndex - sourceIndex1)
            {
              do
              {
                s.window[destinationIndex++] = s.window[sourceIndex1++];
              }
              while (--length2 != 0);
            }
            else
            {
              Array.Copy((Array) s.window, sourceIndex1, (Array) s.window, destinationIndex, length2);
              destinationIndex += length2;
              num13 = sourceIndex1 + length2;
            }
            sourceIndex1 = 0;
          }
        }
        if (destinationIndex - sourceIndex1 > 0 && length1 > destinationIndex - sourceIndex1)
        {
          do
          {
            s.window[destinationIndex++] = s.window[sourceIndex1++];
          }
          while (--length1 != 0);
          goto label_32;
        }
        Array.Copy((Array) s.window, sourceIndex1, (Array) s.window, destinationIndex, length1);
        destinationIndex += length1;
        num13 = sourceIndex1 + length1;
        goto label_32;
label_31:
        num1 >>= numArray1[index2 + 1];
        num2 -= numArray1[index2 + 1];
        s.window[destinationIndex++] = (byte) numArray1[index2 + 2];
        --num3;
      }
label_32:;
    }
    while (num3 >= 258 && availIn >= 10);
    goto label_35;
label_34:
    z.msg = "invalid distance code";
    int num18 = z.avail_in - availIn;
    int num19 = num7 >> 3 < num18 ? num7 >> 3 : num18;
    int num20 = availIn + num19;
    int num21 = nextInIndex - num19;
    int num22 = num7 - (num19 << 3);
    s.bitb = num6;
    s.bitk = num22;
    z.avail_in = num20;
    z.total_in += (long) (num21 - z.next_in_index);
    z.next_in_index = num21;
    s.write = destinationIndex;
    return -3;
label_35:
    int num23 = z.avail_in - availIn;
    int num24 = num2 >> 3 < num23 ? num2 >> 3 : num23;
    int num25 = availIn + num24;
    int num26 = nextInIndex - num24;
    int num27 = num2 - (num24 << 3);
    s.bitb = num1;
    s.bitk = num27;
    z.avail_in = num25;
    z.total_in += (long) (num26 - z.next_in_index);
    z.next_in_index = num26;
    s.write = destinationIndex;
    return 0;
label_36:
    if ((index1 & 32 /*0x20*/) != 0)
    {
      int num28 = z.avail_in - availIn;
      int num29 = num2 >> 3 < num28 ? num2 >> 3 : num28;
      int num30 = availIn + num29;
      int num31 = nextInIndex - num29;
      int num32 = num2 - (num29 << 3);
      s.bitb = num1;
      s.bitk = num32;
      z.avail_in = num30;
      z.total_in += (long) (num31 - z.next_in_index);
      z.next_in_index = num31;
      s.write = destinationIndex;
      return 1;
    }
    z.msg = "invalid literal/length code";
    int num33 = z.avail_in - availIn;
    int num34 = num2 >> 3 < num33 ? num2 >> 3 : num33;
    int num35 = availIn + num34;
    int num36 = nextInIndex - num34;
    int num37 = num2 - (num34 << 3);
    s.bitb = num1;
    s.bitk = num37;
    z.avail_in = num35;
    z.total_in += (long) (num36 - z.next_in_index);
    z.next_in_index = num36;
    s.write = destinationIndex;
    return -3;
  }
}
