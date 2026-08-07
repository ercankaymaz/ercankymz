// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Timeout
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Date;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal class Timeout
{
  private long durationMillis;
  private long startMillis;

  internal Timeout(long durationMillis)
    : this(durationMillis, DateTimeUtilities.CurrentUnixMs())
  {
  }

  internal Timeout(long durationMillis, long currentTimeMillis)
  {
    this.durationMillis = Math.Max(0L, durationMillis);
    this.startMillis = Math.Max(0L, currentTimeMillis);
  }

  internal long RemainingMillis(long currentTimeMillis)
  {
    lock (this)
    {
      if (this.startMillis > currentTimeMillis)
      {
        this.startMillis = currentTimeMillis;
        return this.durationMillis;
      }
      long num = this.durationMillis - (currentTimeMillis - this.startMillis);
      if (num > 0L)
        return num;
      this.durationMillis = 0L;
      return 0;
    }
  }

  internal static int ConstrainWaitMillis(int waitMillis, Timeout timeout, long currentTimeMillis)
  {
    if (waitMillis < 0)
      return -1;
    int waitMillis1 = Timeout.GetWaitMillis(timeout, currentTimeMillis);
    if (waitMillis1 < 0)
      return -1;
    if (waitMillis == 0)
      return waitMillis1;
    return waitMillis1 == 0 ? waitMillis : Math.Min(waitMillis, waitMillis1);
  }

  internal static Timeout ForWaitMillis(int waitMillis)
  {
    return Timeout.ForWaitMillis(waitMillis, DateTimeUtilities.CurrentUnixMs());
  }

  internal static Timeout ForWaitMillis(int waitMillis, long currentTimeMillis)
  {
    if (waitMillis < 0)
      throw new ArgumentException("cannot be negative", nameof (waitMillis));
    return waitMillis > 0 ? new Timeout((long) waitMillis, currentTimeMillis) : (Timeout) null;
  }

  internal static int GetWaitMillis(Timeout timeout, long currentTimeMillis)
  {
    if (timeout == null)
      return 0;
    long num = timeout.RemainingMillis(currentTimeMillis);
    if (num < 1L)
      return -1;
    return num > (long) int.MaxValue ? int.MaxValue : (int) num;
  }

  internal static bool HasExpired(Timeout timeout)
  {
    return Timeout.HasExpired(timeout, DateTimeUtilities.CurrentUnixMs());
  }

  internal static bool HasExpired(Timeout timeout, long currentTimeMillis)
  {
    return timeout != null && timeout.RemainingMillis(currentTimeMillis) < 1L;
  }
}
