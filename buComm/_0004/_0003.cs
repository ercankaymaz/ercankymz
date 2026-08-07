// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0004;

internal static class \u0003
{
  internal sealed class \u0001
  {
    internal static readonly Dictionary<int, string> \u0001;
    internal static readonly object \u0001;
    internal static readonly bool \u0001;
    private static readonly int \u0001;
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

    public static string \u0001([In] int obj0) => \u0004.\u0003.\u0002.\u0001(obj0);

    static \u0001()
    {
      \u0005.\u0003.\u0001 = "1";
      \u0005.\u0003.\u0002 = "120";
      \u0005.\u0003.\u0001 = (byte[]) null;
      \u0004.\u0003.\u0001.\u0001 = new object();
      \u0004.\u0003.\u0001.\u0001 = false;
      \u0004.\u0003.\u0001.\u0001 = 0;
      if (\u0005.\u0003.\u0001 == "1")
      {
        \u0004.\u0003.\u0001.\u0001 = true;
        \u0004.\u0003.\u0001.\u0001 = new Dictionary<int, string>();
      }
      \u0004.\u0003.\u0001.\u0001 = Convert.ToInt32(\u0005.\u0003.\u0002);
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{f8511b9e-22b8-40b1-adf3-f8736d139c4f}"))
      {
        int int32 = Convert.ToInt32(manifestResourceStream.Length);
        byte[] buffer = new byte[int32];
        manifestResourceStream.Read(buffer, 0, int32);
        \u0005.\u0003.\u0001 = \u0005.\u0004.\u0001(buffer);
      }
    }
  }

  internal sealed class \u0002
  {
    internal int \u0003;
    internal int \u0004;
    internal int \u0005;
    internal bool \u0001;
    internal \u0004.\u0003.\u0002 \u0001;

    public static string \u0001([In] int obj0)
    {
      obj0 ^= 107396847;
      obj0 -= \u0004.\u0003.\u0001.\u0001;
      return !\u0004.\u0003.\u0001.\u0001 ? \u0005.\u0004.\u0001(obj0) : \u0005.\u0004.\u0001(obj0);
    }
  }

  internal sealed class \u0003
  {
    internal \u0004.\u0003.\u0003 \u0001;
    internal \u0004.\u0003.\u0005 \u0001;
    internal \u0004.\u0003.\u0004 \u0001;

    public \u0003()
      : this()
    {
    }
  }

  internal sealed class \u0004
  {
    internal \u0004.\u0003.\u0004 \u0002;
    internal byte[] \u0001;
    internal int \u0001;

    public \u0004()
      : this()
    {
    }

    public \u0004([In] byte[] obj0)
    {
      ((\u0004.\u0003.\u0002) this).\u0001 = (\u0004.\u0003.\u0002) new \u0004.\u0003.\u0005();
      ((\u0004.\u0003.\u0003) this).\u0001 = (\u0004.\u0003.\u0003) new \u0004.\u0003.\u0006();
      ((\u0004.\u0003.\u0001) this).\u0001 = 2;
      \u0005.\u0004.\u0001(obj0.Length, 0, ((\u0004.\u0003.\u0002) this).\u0001, obj0);
    }
  }

  internal sealed class \u0005
  {
    internal int \u0002;
    internal uint \u0001;
    internal int \u0003;
    internal byte[] \u0001;
    internal int \u0001;
    internal int \u0002;
    internal short[] \u0001;
    public static readonly \u0004.\u0003.\u0004 \u0001;
    public static readonly \u0004.\u0003.\u0004 \u0002;
    internal static readonly int[] \u0001;
    internal static readonly int[] \u0002;
    internal byte[] \u0001;
    internal byte[] \u0002;
    internal \u0004.\u0003.\u0004 \u0001;

    static \u0005()
    {
      \u0004.\u0003.\u0001.\u0001 = new int[29]
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
      \u0004.\u0003.\u0001.\u0002 = new int[29]
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
      \u0004.\u0003.\u0001.\u0003 = new int[30]
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
      \u0004.\u0003.\u0001.\u0004 = new int[30]
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

  internal sealed class \u0006
  {
    internal int \u0001;
    internal int \u0002;
    internal int \u0003;
    internal int \u0004;
    internal int \u0005;
    internal int \u0006;

    public \u0006()
    {
      ((\u0004.\u0003.\u0005) this).\u0001 = new byte[32768 /*0x8000*/];
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }
  }

  internal sealed class \u0007 : MemoryStream
  {
    static \u0007()
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
      \u0004.\u0003.\u0005.\u0001 = (\u0004.\u0003.\u0004) new \u0005.\u0004(numArray1);
      byte[] numArray2 = new byte[32 /*0x20*/];
      int num2 = 0;
      while (num2 < 32 /*0x20*/)
        numArray2[num2++] = (byte) 5;
      \u0004.\u0003.\u0005.\u0002 = (\u0004.\u0003.\u0004) new \u0005.\u0004(numArray2);
    }
  }
}
