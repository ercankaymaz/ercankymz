// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using dummy_ptr;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0006;

internal static class \u0001
{
  internal sealed class \u0001
  {
    [SpecialName]
    public int value__;
    public const \u0005.\u0003 \u0001 = ; // Unable to render the field
    public const \u0005.\u0003 \u0002 = ; // Unable to render the field
    public const \u0005.\u0003 \u0003 = ; // Unable to render the field
    public const \u0005.\u0003 \u0004 = ; // Unable to render the field
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

    public static string \u0001([In] int obj0)
    {
      obj0 ^= 107396847;
      obj0 -= \u0005.\u0003.\u0001;
      return !\u0005.\u0003.\u0001 ? \u007Bc4786be5\u002D4d12\u002D491c\u002D8bef\u002D494b08e93552\u007D.\u0001(obj0) : \u0002.\u0003.\u0001(obj0);
    }

    public \u0001()
      : this()
    {
    }
  }

  internal sealed class \u0002
  {
    internal \u0006.\u0001.\u0002 \u0001;
    internal \u0006.\u0001.\u0003 \u0001;
    internal \u0006.\u0001.\u0005 \u0001;
    internal \u0006.\u0001.\u0004 \u0001;
    internal \u0006.\u0001.\u0004 \u0002;

    public \u0002()
      : this()
    {
    }
  }

  internal sealed class \u0003
  {
    internal byte[] \u0001;
    internal int \u0001;
    internal int \u0002;

    public \u0003([In] byte[] obj0)
    {
      ((\u0006.\u0001.\u0002) this).\u0001 = (\u0006.\u0001.\u0002) new \u0006.\u0001.\u0004();
      ((\u0006.\u0001.\u0002) this).\u0001 = (\u0006.\u0001.\u0003) new \u0006.\u0001.\u0005();
      ((\u0006.\u0001.\u0001) this).\u0001 = 2;
      \u0002.\u0003.\u0001(obj0, ((\u0006.\u0001.\u0002) this).\u0001, 0, obj0.Length);
    }
  }

  internal sealed class \u0004
  {
    internal uint \u0001;
    internal int \u0003;
    internal byte[] \u0001;

    static \u0004()
    {
      \u0006.\u0001.\u0001.\u0001 = new int[29]
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
      \u0006.\u0001.\u0001.\u0002 = new int[29]
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
      \u0006.\u0001.\u0001.\u0003 = new int[30]
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
      \u0006.\u0001.\u0001.\u0004 = new int[30]
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

  internal sealed class \u0005
  {
    internal int \u0001;
    internal int \u0002;
    internal short[] \u0001;
    public static readonly \u0006.\u0001.\u0004 \u0001;
    public static readonly \u0006.\u0001.\u0004 \u0002;
    internal static readonly int[] \u0001;
    internal static readonly int[] \u0002;
    internal byte[] \u0001;
    internal byte[] \u0002;
    internal \u0006.\u0001.\u0004 \u0001;
    internal int \u0001;
    internal int \u0002;
    internal int \u0003;
    internal int \u0004;

    public \u0005()
    {
      ((\u0006.\u0001.\u0004) this).\u0001 = new byte[32768 /*0x8000*/];
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    static \u0005()
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
      \u0006.\u0001.\u0005.\u0001 = (\u0006.\u0001.\u0004) new \u0006.\u0001.\u0006(numArray1);
      byte[] numArray2 = new byte[32 /*0x20*/];
      int num2 = 0;
      while (num2 < 32 /*0x20*/)
        numArray2[num2++] = (byte) 5;
      \u0006.\u0001.\u0005.\u0002 = (\u0006.\u0001.\u0004) new \u0006.\u0001.\u0006(numArray2);
    }
  }

  internal sealed class \u0006
  {
    internal int \u0005;
    internal int \u0006;
    internal byte \u0001;
    internal int \u0007;
    internal static readonly int[] \u0003;
    private static readonly int[] \u0001;

    public \u0006([In] byte[] obj0) => \u0002.\u0003.\u0001((\u0006.\u0001.\u0004) this, obj0);
  }

  internal sealed class \u0007 : MemoryStream
  {
  }
}
