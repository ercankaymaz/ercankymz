// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.Compression.DeflaterConstants
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip.Compression;

internal class DeflaterConstants
{
  public const int STORED_BLOCK = 0;
  public const int STATIC_TREES = 1;
  public const int DYN_TREES = 2;
  public const int PRESET_DICT = 32 /*0x20*/;
  public const int DEFAULT_MEM_LEVEL = 8;
  public const int MAX_MATCH = 258;
  public const int MIN_MATCH = 3;
  public const int MAX_WBITS = 15;
  public const int WSIZE = 32768 /*0x8000*/;
  public const int WMASK = 32767 /*0x7FFF*/;
  public const int HASH_BITS = 15;
  public const int HASH_SIZE = 32768 /*0x8000*/;
  public const int HASH_MASK = 32767 /*0x7FFF*/;
  public const int HASH_SHIFT = 5;
  public const int MIN_LOOKAHEAD = 262;
  public const int MAX_DIST = 32506;
  public const int PENDING_BUF_SIZE = 65536 /*0x010000*/;
  public static int MAX_BLOCK_SIZE = Math.Min((int) ushort.MaxValue, 65531);
  public const int DEFLATE_STORED = 0;
  public const int DEFLATE_FAST = 1;
  public const int DEFLATE_SLOW = 2;
  public static int[] GOOD_LENGTH = new int[10]
  {
    0,
    4,
    4,
    4,
    4,
    8,
    8,
    8,
    32 /*0x20*/,
    32 /*0x20*/
  };
  public static int[] MAX_LAZY = new int[10]
  {
    0,
    4,
    5,
    6,
    4,
    16 /*0x10*/,
    16 /*0x10*/,
    32 /*0x20*/,
    128 /*0x80*/,
    258
  };
  public static int[] NICE_LENGTH = new int[10]
  {
    0,
    8,
    16 /*0x10*/,
    32 /*0x20*/,
    16 /*0x10*/,
    32 /*0x20*/,
    128 /*0x80*/,
    128 /*0x80*/,
    258,
    258
  };
  public static int[] MAX_CHAIN = new int[10]
  {
    0,
    4,
    8,
    32 /*0x20*/,
    16 /*0x10*/,
    32 /*0x20*/,
    128 /*0x80*/,
    256 /*0x0100*/,
    1024 /*0x0400*/,
    4096 /*0x1000*/
  };
  public static int[] COMPR_FUNC = new int[10]
  {
    0,
    1,
    1,
    1,
    1,
    2,
    2,
    2,
    2,
    2
  };

  public static bool DEBUGGING => false;
}
