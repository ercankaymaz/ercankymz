// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Date.DateTimeUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Utilities.Date;

public static class DateTimeUtilities
{
  public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  public static readonly long MaxUnixMs = (DateTime.MaxValue.Ticks - DateTimeUtilities.UnixEpoch.Ticks) / 10000L;
  public static readonly long MinUnixMs = 0;

  public static long DateTimeToUnixMs(DateTime dateTime)
  {
    DateTime universalTime = dateTime.ToUniversalTime();
    if (universalTime.CompareTo(DateTimeUtilities.UnixEpoch) < 0)
      throw new ArgumentOutOfRangeException(nameof (dateTime), "DateTime value may not be before the epoch");
    return (universalTime.Ticks - DateTimeUtilities.UnixEpoch.Ticks) / 10000L;
  }

  public static DateTime UnixMsToDateTime(long unixMs)
  {
    if (unixMs < DateTimeUtilities.MinUnixMs || unixMs > DateTimeUtilities.MaxUnixMs)
      throw new ArgumentOutOfRangeException(nameof (unixMs));
    return new DateTime(unixMs * 10000L + DateTimeUtilities.UnixEpoch.Ticks, DateTimeKind.Utc);
  }

  public static long CurrentUnixMs() => DateTimeUtilities.DateTimeToUnixMs(DateTime.UtcNow);

  public static DateTime WithPrecisionCentisecond(DateTime dateTime)
  {
    return new DateTime(dateTime.Ticks - dateTime.Ticks % 100000L, dateTime.Kind);
  }

  public static DateTime WithPrecisionDecisecond(DateTime dateTime)
  {
    return new DateTime(dateTime.Ticks - dateTime.Ticks % 1000000L, dateTime.Kind);
  }

  public static DateTime WithPrecisionMillisecond(DateTime dateTime)
  {
    return new DateTime(dateTime.Ticks - dateTime.Ticks % 10000L, dateTime.Kind);
  }

  public static DateTime WithPrecisionSecond(DateTime dateTime)
  {
    return new DateTime(dateTime.Ticks - dateTime.Ticks % 10000000L, dateTime.Kind);
  }
}
