// Decompiled with JetBrains decompiler
// Type: ns10.Class34
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System.IO;

#nullable disable
namespace ns10;

internal static class Class34
{
  internal sealed class Class35
  {
    internal static readonly int[] int_0 = new int[29]
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
    internal static readonly int[] int_1 = new int[29]
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
    internal static readonly int[] int_2 = new int[30]
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
    internal static readonly int[] int_3 = new int[30]
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
    internal int int_4;
    internal int int_5;
    internal int int_6;
    internal int int_7;
    internal int int_8;
    internal bool bool_0;
    internal Class34.Class36 class36_0;
    internal Class34.Class37 class37_0;
    internal Class34.Class39 class39_0;
    internal Class34.Class38 class38_0;
    internal Class34.Class38 class38_1;

    public Class35(byte[] byte_0)
    {
      this.class36_0 = new Class34.Class36();
      this.class37_0 = new Class34.Class37();
      this.int_4 = 2;
      Class30.smethod_171(0, this.class36_0, byte_0.Length, byte_0);
    }
  }

  internal sealed class Class36
  {
    internal byte[] byte_0;
    internal int int_0;
    internal int int_1;
    internal uint uint_0;
    internal int int_2;
  }

  internal sealed class Class37
  {
    internal byte[] byte_0 = new byte[32768 /*0x8000*/];
    internal int int_0;
    internal int int_1;
  }

  internal sealed class Class38
  {
    internal short[] short_0;
    public static readonly Class34.Class38 class38_0;
    public static readonly Class34.Class38 class38_1;

    static Class38()
    {
      byte[] byte_0_1 = new byte[288];
      int num1 = 0;
      while (num1 < 144 /*0x90*/)
        byte_0_1[num1++] = (byte) 8;
      while (num1 < 256 /*0x0100*/)
        byte_0_1[num1++] = (byte) 9;
      while (num1 < 280)
        byte_0_1[num1++] = (byte) 7;
      while (num1 < 288)
        byte_0_1[num1++] = (byte) 8;
      Class34.Class38.class38_0 = new Class34.Class38(byte_0_1);
      byte[] byte_0_2 = new byte[32 /*0x20*/];
      int num2 = 0;
      while (num2 < 32 /*0x20*/)
        byte_0_2[num2++] = (byte) 5;
      Class34.Class38.class38_1 = new Class34.Class38(byte_0_2);
    }

    public Class38(byte[] byte_0) => Class30.smethod_148(this, byte_0);
  }

  internal sealed class Class39
  {
    internal static readonly int[] int_0 = new int[3]
    {
      3,
      3,
      11
    };
    internal static readonly int[] int_1 = new int[3]
    {
      2,
      3,
      7
    };
    internal byte[] byte_0;
    internal byte[] byte_1;
    internal Class34.Class38 class38_0;
    internal int int_2;
    internal int int_3;
    internal int int_4;
    internal int int_5;
    internal int int_6;
    internal int int_7;
    internal byte byte_2;
    internal int int_8;
    internal static readonly int[] int_9 = new int[19]
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
  }

  internal sealed class Class40
  {
    private static readonly int[] int_0 = new int[19]
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
    internal static readonly byte[] byte_0 = new byte[16 /*0x10*/]
    {
      (byte) 0,
      (byte) 8,
      (byte) 4,
      (byte) 12,
      (byte) 2,
      (byte) 10,
      (byte) 6,
      (byte) 14,
      (byte) 1,
      (byte) 9,
      (byte) 5,
      (byte) 13,
      (byte) 3,
      (byte) 11,
      (byte) 7,
      (byte) 15
    };
    private static readonly short[] short_0 = new short[286];
    private static readonly byte[] byte_1 = new byte[286];
    private static readonly short[] short_1;
    private static readonly byte[] byte_2;

    static Class40()
    {
      int index1;
      for (index1 = 0; index1 < 144 /*0x90*/; Class34.Class40.byte_1[index1++] = (byte) 8)
        Class34.Class40.short_0[index1] = Class30.smethod_176(48 /*0x30*/ + index1 << 8);
      for (; index1 < 256 /*0x0100*/; Class34.Class40.byte_1[index1++] = (byte) 9)
        Class34.Class40.short_0[index1] = Class30.smethod_176(256 /*0x0100*/ + index1 << 7);
      for (; index1 < 280; Class34.Class40.byte_1[index1++] = (byte) 7)
        Class34.Class40.short_0[index1] = Class30.smethod_176(index1 - 256 /*0x0100*/ << 9);
      for (; index1 < 286; Class34.Class40.byte_1[index1++] = (byte) 8)
        Class34.Class40.short_0[index1] = Class30.smethod_176(index1 - 88 << 8);
      Class34.Class40.short_1 = new short[30];
      Class34.Class40.byte_2 = new byte[30];
      for (int index2 = 0; index2 < 30; ++index2)
      {
        Class34.Class40.short_1[index2] = Class30.smethod_176(index2 << 11);
        Class34.Class40.byte_2[index2] = (byte) 5;
      }
    }
  }

  internal sealed class Stream0(byte[] byte_0) : MemoryStream(byte_0, false)
  {
  }
}
