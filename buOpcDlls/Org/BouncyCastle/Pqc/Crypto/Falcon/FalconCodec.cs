// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconCodec
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class FalconCodec
{
  internal byte[] max_fg_bits = new byte[11]
  {
    (byte) 0,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 7,
    (byte) 7,
    (byte) 6,
    (byte) 6,
    (byte) 5
  };
  internal byte[] max_FG_bits = new byte[11]
  {
    (byte) 0,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8
  };
  internal byte[] max_sig_bits = new byte[11]
  {
    (byte) 0,
    (byte) 10,
    (byte) 11,
    (byte) 11,
    (byte) 12,
    (byte) 12,
    (byte) 12,
    (byte) 12,
    (byte) 12,
    (byte) 12,
    (byte) 12
  };

  internal FalconCodec()
  {
  }

  internal int modq_encode(
    byte[] outarrsrc,
    int outarr,
    int max_out_len,
    ushort[] xsrc,
    int x,
    uint logn)
  {
    int num1 = 1 << (int) logn;
    for (int index = 0; index < num1; ++index)
    {
      if (xsrc[x + index] >= (ushort) 12289)
        return 0;
    }
    int num2 = num1 * 14 + 7 >> 3;
    if (outarrsrc == null)
      return num2;
    if (num2 > max_out_len)
      return 0;
    int index1 = outarr;
    uint num3 = 0;
    int num4 = 0;
    for (int index2 = 0; index2 < num1; ++index2)
    {
      num3 = num3 << 14 | (uint) xsrc[x + index2];
      num4 += 14;
      while (num4 >= 8)
      {
        num4 -= 8;
        outarrsrc[index1++] = (byte) (num3 >> num4);
      }
    }
    if (num4 > 0)
      outarrsrc[index1] = (byte) (num3 << 8 - num4);
    return num2;
  }

  internal int modq_decode(
    ushort[] xsrc,
    int x,
    uint logn,
    byte[] inarrsrc,
    int inarr,
    int max_in_len)
  {
    int num1 = 1 << (int) logn;
    int num2 = num1 * 14 + 7 >> 3;
    if (num2 > max_in_len)
      return 0;
    int num3 = inarr;
    uint num4 = 0;
    int num5 = 0;
    int num6 = 0;
    while (num6 < num1)
    {
      num4 = num4 << 8 | (uint) inarrsrc[num3++];
      num5 += 8;
      if (num5 >= 14)
      {
        num5 -= 14;
        uint num7 = num4 >> num5 & 16383U /*0x3FFF*/;
        if (num7 >= 12289U)
          return 0;
        xsrc[x + num6] = (ushort) num7;
        ++num6;
      }
    }
    return ((int) num4 & (1 << num5) - 1) != 0 ? 0 : num2;
  }

  internal int trim_i16_encode(
    byte[] outarrsrc,
    int outarr,
    int max_out_len,
    short[] xsrc,
    int x,
    uint logn,
    uint bits)
  {
    int num1 = 1 << (int) logn;
    int num2 = (1 << (int) bits - 1) - 1;
    int num3 = -num2;
    for (int index = 0; index < num1; ++index)
    {
      if ((int) xsrc[x + index] < num3 || (int) xsrc[x + index] > num2)
        return 0;
    }
    int num4 = (int) ((long) num1 * (long) bits + 7L) >> 3;
    if (outarrsrc == null)
      return num4;
    if (num4 > max_out_len)
      return 0;
    int num5 = outarr;
    uint num6 = 0;
    uint num7 = 0;
    uint num8 = (uint) ((1 << (int) bits) - 1);
    for (int index = 0; index < num1; ++index)
    {
      num6 = (uint) ((int) num6 << (int) bits | (int) (ushort) xsrc[x + index] & (int) num8);
      num7 += bits;
      while (num7 >= 8U)
      {
        num7 -= 8U;
        outarrsrc[num5++] = (byte) (num6 >> (int) num7);
      }
    }
    if (num7 > 0U)
    {
      byte[] numArray = outarrsrc;
      int index = num5;
      int num9 = index + 1;
      int num10 = (int) (byte) (num6 << 8 - (int) num7);
      numArray[index] = (byte) num10;
    }
    return num4;
  }

  internal int trim_i16_decode(
    short[] xsrc,
    int x,
    uint logn,
    uint bits,
    byte[] inarrsrc,
    int inarr,
    int max_in_len)
  {
    int num1 = 1 << (int) logn;
    int num2 = (int) ((long) num1 * (long) bits + 7L) >> 3;
    if (num2 > max_in_len)
      return 0;
    int num3 = inarr;
    int num4 = 0;
    uint num5 = 0;
    uint num6 = 0;
    uint num7 = (uint) ((1 << (int) bits) - 1);
    uint num8 = (uint) (1 << (int) bits - 1);
label_7:
    while (num4 < num1)
    {
      num5 = num5 << 8 | (uint) inarrsrc[num3++];
      num6 += 8U;
      while (true)
      {
        if (num6 >= bits && num4 < num1)
        {
          num6 -= bits;
          uint num9 = num5 >> (int) num6 & num7;
          uint num10 = (uint) ((ulong) num9 | (ulong) -(num9 & num8));
          uint num11 = num10 | -(num10 & num8);
          if ((long) num11 != (long) -num8)
          {
            uint num12 = num11 | -(num11 & num8);
            xsrc[x + num4] = (short) num12;
            ++num4;
          }
          else
            break;
        }
        else
          goto label_7;
      }
      return 0;
    }
    return ((int) num5 & (1 << (int) num6) - 1) != 0 ? 0 : num2;
  }

  internal int trim_i8_encode(
    byte[] outarrsrc,
    int outarr,
    int max_out_len,
    sbyte[] xsrc,
    int x,
    uint logn,
    uint bits)
  {
    int num1 = 1 << (int) logn;
    int num2 = (1 << (int) bits - 1) - 1;
    int num3 = -num2;
    for (int index = 0; index < num1; ++index)
    {
      if ((int) xsrc[x + index] < num3 || (int) xsrc[x + index] > num2)
        return 0;
    }
    int num4 = (int) ((long) num1 * (long) bits + 7L) >> 3;
    if (outarrsrc == null)
      return num4;
    if (num4 > max_out_len)
      return 0;
    int num5 = outarr;
    uint num6 = 0;
    uint num7 = 0;
    uint num8 = (uint) ((1 << (int) bits) - 1);
    for (int index = 0; index < num1; ++index)
    {
      num6 = (uint) ((int) num6 << (int) bits | (int) (byte) xsrc[x + index] & (int) num8);
      num7 += bits;
      while (num7 >= 8U)
      {
        num7 -= 8U;
        outarrsrc[num5++] = (byte) (num6 >> (int) num7);
      }
    }
    if (num7 > 0U)
    {
      byte[] numArray = outarrsrc;
      int index = num5;
      int num9 = index + 1;
      int num10 = (int) (byte) (num6 << 8 - (int) num7);
      numArray[index] = (byte) num10;
    }
    return num4;
  }

  internal int trim_i8_decode(
    sbyte[] xsrc,
    int x,
    uint logn,
    uint bits,
    byte[] inarrsrc,
    int inarr,
    int max_in_len)
  {
    int num1 = 1 << (int) logn;
    int num2 = (int) ((long) num1 * (long) bits + 7L) >> 3;
    if (num2 > max_in_len)
      return 0;
    int num3 = inarr;
    int num4 = 0;
    uint num5 = 0;
    uint num6 = 0;
    uint num7 = (uint) ((1 << (int) bits) - 1);
    uint num8 = (uint) (1 << (int) bits - 1);
label_7:
    while (num4 < num1)
    {
      num5 = num5 << 8 | (uint) inarrsrc[num3++];
      num6 += 8U;
      while (true)
      {
        if (num6 >= bits && num4 < num1)
        {
          num6 -= bits;
          uint num9 = num5 >> (int) num6 & num7;
          uint num10 = num9 | -(num9 & num8);
          if ((long) num10 != (long) -num8)
          {
            xsrc[x + num4] = (sbyte) num10;
            ++num4;
          }
          else
            break;
        }
        else
          goto label_7;
      }
      return 0;
    }
    return ((int) num5 & (1 << (int) num6) - 1) != 0 ? 0 : num2;
  }

  internal int comp_encode(
    byte[] outarrsrc,
    int outarr,
    int max_out_len,
    short[] xsrc,
    int x,
    uint logn)
  {
    int num1 = 1 << (int) logn;
    int num2 = outarr;
    for (int index = 0; index < num1; ++index)
    {
      if (xsrc[x + index] < (short) -2047 || xsrc[x + index] > (short) 2047 /*0x07FF*/)
        return 0;
    }
    uint num3 = 0;
    uint num4 = 0;
    int num5 = 0;
    for (int index = 0; index < num1; ++index)
    {
      uint num6 = num3 << 1;
      int num7 = (int) xsrc[x + index];
      if (num7 < 0)
      {
        num7 = -num7;
        num6 |= 1U;
      }
      uint num8 = (uint) num7;
      uint num9 = num6 << 7 | num8 & (uint) sbyte.MaxValue;
      uint num10 = num8 >> 7;
      uint num11 = num4 + 8U;
      num3 = num9 << (int) num10 + 1 | 1U;
      num4 = num11 + (num10 + 1U);
      while (num4 >= 8U)
      {
        num4 -= 8U;
        if (outarrsrc != null)
        {
          if (num5 >= max_out_len)
            return 0;
          outarrsrc[num2 + num5] = (byte) (num3 >> (int) num4);
        }
        ++num5;
      }
    }
    if (num4 > 0U)
    {
      if (outarrsrc != null)
      {
        if (num5 >= max_out_len)
          return 0;
        outarrsrc[num2 + num5] = (byte) (num3 << 8 - (int) num4);
      }
      ++num5;
    }
    return num5;
  }

  internal int comp_decode(
    short[] xsrc,
    int x,
    uint logn,
    byte[] inarrsrc,
    int inarr,
    int max_in_len)
  {
    int num1 = 1 << (int) logn;
    int num2 = inarr;
    uint num3 = 0;
    uint num4 = 0;
    int num5 = 0;
    for (int index = 0; index < num1; ++index)
    {
      if (num5 >= max_in_len)
        return 0;
      num3 = num3 << 8 | (uint) inarrsrc[num2 + num5];
      ++num5;
      int num6 = (int) (num3 >> (int) num4);
      uint num7 = (uint) (num6 & 128 /*0x80*/);
      uint num8 = (uint) (num6 & (int) sbyte.MaxValue);
      do
      {
        if (num4 == 0U)
          goto label_5;
label_3:
        --num4;
        if (((int) (num3 >> (int) num4) & 1) == 0)
        {
          num8 += 128U /*0x80*/;
          continue;
        }
        goto label_8;
label_5:
        if (num5 < max_in_len)
        {
          num3 = num3 << 8 | (uint) inarrsrc[num2 + num5];
          ++num5;
          num4 = 8U;
          goto label_3;
        }
        goto label_15;
      }
      while (num8 <= 2047U /*0x07FF*/);
      goto label_16;
label_8:
      if (num7 != 0U && num8 == 0U)
        return 0;
      xsrc[x + index] = num7 != 0U ? (short) -(int) num8 : (short) num8;
      continue;
label_15:
      return 0;
label_16:
      return 0;
    }
    return ((int) num3 & (1 << (int) num4) - 1) != 0 ? 0 : num5;
  }
}
