// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.Lock
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Threading;

#nullable disable
namespace PdfSharp.Internal;

internal static class Lock
{
  private static readonly object GdiPlus = new object();
  private static int _gdiPlusLockCount;
  private static readonly object FontFactory = new object();
  [ThreadStatic]
  private static int _fontFactoryLockCount;

  public static void EnterGdiPlus()
  {
    Monitor.Enter(Lock.GdiPlus);
    ++Lock._gdiPlusLockCount;
  }

  public static void ExitGdiPlus()
  {
    --Lock._gdiPlusLockCount;
    Monitor.Exit(Lock.GdiPlus);
  }

  public static void EnterFontFactory()
  {
    Monitor.Enter(Lock.FontFactory);
    ++Lock._fontFactoryLockCount;
  }

  public static void ExitFontFactory()
  {
    --Lock._fontFactoryLockCount;
    Monitor.Exit(Lock.FontFactory);
  }
}
