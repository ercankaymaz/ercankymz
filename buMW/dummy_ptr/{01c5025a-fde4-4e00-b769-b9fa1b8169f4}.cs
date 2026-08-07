// Decompiled with JetBrains decompiler
// Type: dummy_ptr.{01c5025a-fde4-4e00-b769-b9fa1b8169f4}
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using System.Runtime.InteropServices;

#nullable disable
namespace dummy_ptr;

internal abstract class \u007B01c5025a\u002Dfde4\u002D4e00\u002Db769\u002Db9fa1b8169f4\u007D
{
  internal static readonly \u0002.\u0003.\u0002 \u0001;
  internal static readonly \u0002.\u0003.\u0004 \u0001;
  internal static readonly \u0002.\u0003.\u0001 \u0001;
  internal static readonly \u0002.\u0003.\u0002 \u0002;
  internal static readonly \u0002.\u0003.\u0005 \u0001;
  internal static readonly \u0002.\u0003.\u0003 \u0001;
  internal static readonly \u0002.\u0003.\u0002 \u0003;
  internal static readonly \u0002.\u0003.\u0001 \u0002;
  internal static readonly \u0002.\u0003.\u0004 \u0002;
  internal static readonly \u0002.\u0003.\u0005 \u0002;

  public \u007B01c5025a\u002Dfde4\u002D4e00\u002Db769\u002Db9fa1b8169f4\u007D()
  {
  }

  static \u007B01c5025a\u002Dfde4\u002D4e00\u002Db769\u002Db9fa1b8169f4\u007D()
  {
    \u0011.\u0001.\u0005.\u0001 = new int[3]{ 3, 3, 11 };
    \u0011.\u0001.\u0005.\u0002 = new int[3]{ 2, 3, 7 };
    // ISSUE: reference to a compiler-generated field
    \u0002.\u0003.\u0003 = new int[19]
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

  static \u007B01c5025a\u002Dfde4\u002D4e00\u002Db769\u002Db9fa1b8169f4\u007D()
  {
    // ISSUE: reference to a compiler-generated field
    \u0002.\u0003.\u0001 = new int[19]
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
    // ISSUE: reference to a compiler-generated field
    \u0002.\u0003.\u0001 = new byte[16 /*0x10*/]
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
    // ISSUE: reference to a compiler-generated field
    \u0002.\u0003.\u0001 = new short[286];
    // ISSUE: reference to a compiler-generated field
    \u0002.\u0003.\u0002 = new byte[286];
    int index1;
    // ISSUE: reference to a compiler-generated field
    for (index1 = 0; index1 < 144 /*0x90*/; \u0002.\u0003.\u0002[index1++] = (byte) 8)
    {
      // ISSUE: reference to a compiler-generated field
      \u0002.\u0003.\u0001[index1] = \u0005.\u0002.\u0001(48 /*0x30*/ + index1 << 8);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 256 /*0x0100*/; \u0002.\u0003.\u0002[index1++] = (byte) 9)
    {
      // ISSUE: reference to a compiler-generated field
      \u0002.\u0003.\u0001[index1] = \u0005.\u0002.\u0001(256 /*0x0100*/ + index1 << 7);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 280; \u0002.\u0003.\u0002[index1++] = (byte) 7)
    {
      // ISSUE: reference to a compiler-generated field
      \u0002.\u0003.\u0001[index1] = \u0005.\u0002.\u0001(index1 - 256 /*0x0100*/ << 9);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 286; \u0002.\u0003.\u0002[index1++] = (byte) 8)
    {
      // ISSUE: reference to a compiler-generated field
      \u0002.\u0003.\u0001[index1] = \u0005.\u0002.\u0001(index1 - 88 << 8);
    }
    // ISSUE: reference to a compiler-generated field
    \u0002.\u0003.\u0002 = new short[30];
    // ISSUE: reference to a compiler-generated field
    \u0002.\u0003.\u0003 = new byte[30];
    for (int index2 = 0; index2 < 30; ++index2)
    {
      // ISSUE: reference to a compiler-generated field
      \u0002.\u0003.\u0002[index2] = \u0005.\u0002.\u0001(index2 << 11);
      // ISSUE: reference to a compiler-generated field
      \u0002.\u0003.\u0003[index2] = (byte) 5;
    }
  }

  public \u007B01c5025a\u002Dfde4\u002D4e00\u002Db769\u002Db9fa1b8169f4\u007D([In] byte[] obj0)
    : this(obj0, false)
  {
  }
}
