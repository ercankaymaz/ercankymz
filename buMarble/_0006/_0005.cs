// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buControls.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0006;

internal static class \u0005
{
  internal sealed class \u0001
  {
    public buSpin spn_WagonUpPositionX;
    public buSpin spn_WagonUpPositionZ;
    public buSpin spn_WagonUpPositionY;
    public buButton btn_wagonparkgetpos;
    internal const string \u0001 = "{71461f04-2faa-4bb9-a0dd-28a79101b599}";
    private const int \u0001 = 4;
    internal static Dictionary<string, Assembly> \u0001;
    public string \u0001;
    public Version \u0001;
    public string \u0002;
    public string \u0003;
    private static ModuleHandle \u0001;
    private static char[] \u0001;
    internal static readonly \u0003.\u0001.\u0001 \u0001;
    private static Assembly \u0001;

    static \u0001() => \u0006.\u0005.\u0002.\u0001 = new string[0];

    public static string \u0001([In] int obj0) => \u0006.\u0005.\u0003.\u0001(obj0);
  }

  internal sealed class \u0002
  {
    private static string[] \u0001;
    private static readonly string \u0001 = "1";
    private static readonly string \u0002 = "24";
    internal static readonly byte[] \u0001 = (byte[]) null;
    internal static readonly Dictionary<int, string> \u0001;

    static \u0002()
    {
      \u0006.\u0005.\u0003.\u0001 = new object();
      \u0006.\u0005.\u0003.\u0001 = false;
      \u0006.\u0005.\u0003.\u0001 = 0;
      if (\u0006.\u0005.\u0002.\u0001 == "1")
      {
        \u0006.\u0005.\u0003.\u0001 = true;
        \u0006.\u0005.\u0002.\u0001 = new Dictionary<int, string>();
      }
      \u0006.\u0005.\u0003.\u0001 = Convert.ToInt32(\u0006.\u0005.\u0002.\u0002);
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{73cfefc9-f5c0-4c53-95a2-e57484d2faf2}"))
      {
        int int32 = Convert.ToInt32(manifestResourceStream.Length);
        byte[] buffer = new byte[int32];
        manifestResourceStream.Read(buffer, 0, int32);
        \u0006.\u0005.\u0002.\u0001 = \u0005.\u0003.\u0001(buffer);
      }
    }
  }

  internal sealed class \u0003
  {
    internal static readonly object \u0001;
    internal static readonly bool \u0001;
    private static readonly int \u0001;

    public static string \u0001([In] int obj0)
    {
      obj0 ^= 107396847;
      obj0 -= \u0006.\u0005.\u0003.\u0001;
      return !\u0006.\u0005.\u0003.\u0001 ? \u0005.\u0003.\u0001(obj0) : \u0005.\u0003.\u0001(obj0);
    }
  }

  internal sealed class \u0004
  {
    [SpecialName]
    public int value__;
    public const \u0006.\u0004 \u0001 = ; // Unable to render the field
    public const \u0006.\u0004 \u0002 = ; // Unable to render the field

    public \u0004()
      : this()
    {
    }

    public \u0004()
      : this()
    {
    }
  }

  internal sealed class \u0005
  {
    public const \u0006.\u0004 \u0003 = ; // Unable to render the field
    public const \u0006.\u0004 \u0004 = ; // Unable to render the field
    internal static readonly int[] \u0001 = new int[29]
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
    internal static readonly int[] \u0002 = new int[29]
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
    internal static readonly int[] \u0003 = new int[30]
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
    internal static readonly int[] \u0004 = new int[30]
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
    internal int \u0001;
    internal int \u0002;
    internal int \u0003;
    internal int \u0004;
    internal int \u0005;
    internal bool \u0001;
    internal \u0006.\u0005.\u0002 \u0001;
    internal \u0006.\u0005.\u0003 \u0001;

    public \u0005([In] byte[] obj0)
    {
      this.\u0001 = (\u0006.\u0005.\u0002) new \u0006.\u0005.\u0006();
      this.\u0001 = (\u0006.\u0005.\u0003) new \u0006.\u0005.\u0007();
      this.\u0001 = 2;
      \u0005.\u0003.\u0001(0, this.\u0001, obj0, obj0.Length);
    }
  }

  internal sealed class \u0006
  {
    internal \u0006.\u0005.\u0005 \u0001;
    internal \u0006.\u0005.\u0004 \u0001;
    internal \u0006.\u0005.\u0004 \u0002;
    internal byte[] \u0001;
    internal int \u0001;
    internal int \u0002;
  }

  internal sealed class \u0007 : MemoryStream
  {
    public \u0007()
    {
      // ISSUE: reference to a compiler-generated field
      ((\u0002.\u0002) this).\u0001 = new byte[32768 /*0x8000*/];
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }
  }
}
