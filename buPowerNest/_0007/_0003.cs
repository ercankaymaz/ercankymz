// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using System.IO;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0007;

internal static class \u0003
{
  internal sealed class \u0001
  {
    public const \u0008.\u0001 \u0004 = \u0008.\u0001.\u0002 | \u0008.\u0001.\u0003;
    internal static readonly int[] \u0001;
    internal static readonly int[] \u0002;
    internal static readonly int[] \u0003;
    internal static readonly int[] \u0004;
    internal int \u0001;
    internal int \u0002;
    internal int \u0003;
    internal int \u0004;
    internal int \u0005;
    internal bool \u0001;
    internal \u0007.\u0003.\u0002 \u0001;
    internal \u0007.\u0003.\u0003 \u0001;
    internal \u0007.\u0003.\u0005 \u0001;
    internal \u0007.\u0003.\u0004 \u0001;

    public \u0001()
      : this()
    {
    }

    public \u0001([In] byte[] obj0)
    {
      this.\u0001 = (\u0007.\u0003.\u0002) new \u0007.\u0003.\u0003();
      this.\u0001 = (\u0007.\u0003.\u0003) new \u0007.\u0003.\u0004();
      this.\u0001 = 2;
      \u0005.\u0003.\u0001(0, obj0, this.\u0001, obj0.Length);
    }
  }

  internal sealed class \u0002
  {
    internal \u0007.\u0003.\u0004 \u0002;
    internal byte[] \u0001;
    internal int \u0001;
    internal int \u0002;
    internal uint \u0001;

    static \u0002()
    {
      \u0007.\u0003.\u0001.\u0001 = new int[29]
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
      \u0007.\u0003.\u0001.\u0002 = new int[29]
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
      \u0007.\u0003.\u0001.\u0003 = new int[30]
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
      \u0007.\u0003.\u0001.\u0004 = new int[30]
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
    }
  }

  internal sealed class \u0003
  {
    internal int \u0003;
    internal byte[] \u0001;
    internal int \u0001;
  }

  internal sealed class \u0004
  {
    internal int \u0002;
    internal short[] \u0001;
    public static readonly \u0007.\u0003.\u0004 \u0001;

    public \u0004()
    {
      ((\u0007.\u0003.\u0003) this).\u0001 = new byte[32768 /*0x8000*/];
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    static \u0004()
    {
      byte[] numArray1 = new byte[288];
      int num1 = 0;
      while (num1 < 144 /*0x90*/)
        numArray1[num1++] = (byte) 8;
      while (num1 < 256 /*0x0100*/)
        numArray1[num1++] = (byte) 9;
      while (num1 < 280)
        numArray1[num1++] = (byte) 7;
      while (num1 < 288)
        numArray1[num1++] = (byte) 8;
      \u0007.\u0003.\u0004.\u0001 = (\u0007.\u0003.\u0004) new \u0007.\u0003.\u0005(numArray1);
      byte[] numArray2 = new byte[32 /*0x20*/];
      int num2 = 0;
      while (num2 < 32 /*0x20*/)
        numArray2[num2++] = (byte) 5;
      \u0007.\u0003.\u0005.\u0002 = (\u0007.\u0003.\u0004) new \u0007.\u0003.\u0005(numArray2);
    }
  }

  internal sealed class \u0005
  {
    public static readonly \u0007.\u0003.\u0004 \u0002;
    internal static readonly int[] \u0001;
    internal static readonly int[] \u0002;
    internal byte[] \u0001;
    internal byte[] \u0002;
    internal \u0007.\u0003.\u0004 \u0001;
    internal int \u0001;
    internal int \u0002;
    internal int \u0003;
    internal int \u0004;
    internal int \u0005;
    internal int \u0006;
    internal byte \u0001;
    internal int \u0007;

    public \u0005([In] byte[] obj0) => \u0005.\u0003.\u0001(obj0, (\u0007.\u0003.\u0004) this);

    public \u0005()
    {
    }
  }

  internal sealed class \u0006
  {
    internal static readonly int[] \u0003;
    private static readonly int[] \u0001;
    internal static readonly byte[] \u0001;
    private static readonly short[] \u0001;
    private static readonly byte[] \u0002;
    private static readonly short[] \u0002;

    static \u0006()
    {
      \u0007.\u0003.\u0005.\u0001 = new int[3]{ 3, 3, 11 };
      \u0007.\u0003.\u0005.\u0002 = new int[3]{ 2, 3, 7 };
      \u0007.\u0003.\u0006.\u0003 = new int[19]
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
  }

  internal sealed class \u0007 : MemoryStream
  {
    static \u0007()
    {
      \u0007.\u0003.\u0006.\u0001 = new int[19]
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
      \u0007.\u0003.\u0006.\u0001 = new byte[16 /*0x10*/]
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
      \u0007.\u0003.\u0006.\u0001 = new short[286];
      \u0007.\u0003.\u0006.\u0002 = new byte[286];
      int index1;
      for (index1 = 0; index1 < 144 /*0x90*/; \u0007.\u0003.\u0006.\u0002[index1++] = (byte) 8)
        \u0007.\u0003.\u0006.\u0001[index1] = \u0005.\u0003.\u0001(48 /*0x30*/ + index1 << 8);
      for (; index1 < 256 /*0x0100*/; \u0007.\u0003.\u0006.\u0002[index1++] = (byte) 9)
        \u0007.\u0003.\u0006.\u0001[index1] = \u0005.\u0003.\u0001(256 /*0x0100*/ + index1 << 7);
      for (; index1 < 280; \u0007.\u0003.\u0006.\u0002[index1++] = (byte) 7)
        \u0007.\u0003.\u0006.\u0001[index1] = \u0005.\u0003.\u0001(index1 - 256 /*0x0100*/ << 9);
      for (; index1 < 286; \u0007.\u0003.\u0006.\u0002[index1++] = (byte) 8)
        \u0007.\u0003.\u0006.\u0001[index1] = \u0005.\u0003.\u0001(index1 - 88 << 8);
      \u0007.\u0003.\u0006.\u0002 = new short[30];
      \u0007.\u0004.\u0003 = new byte[30];
      for (int index2 = 0; index2 < 30; ++index2)
      {
        \u0007.\u0003.\u0006.\u0002[index2] = \u0005.\u0003.\u0001(index2 << 11);
        \u0007.\u0004.\u0003[index2] = (byte) 5;
      }
    }
  }
}
