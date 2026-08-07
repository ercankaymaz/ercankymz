// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HiResClock
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class HiResClock
{
  private static HiResClock s_Default = new HiResClock();
  private long m_frequency;
  private long m_baseline;
  private long m_offset;
  private double m_ticksPerMillisecond;
  private Decimal m_ratio;
  private bool m_disabled;
  private bool m_initialized;

  public static DateTime UtcNow
  {
    get
    {
      return HiResClock.s_Default.m_disabled ? DateTime.UtcNow : new DateTime((long) ((Decimal) (Stopwatch.GetTimestamp() - HiResClock.s_Default.m_baseline) * HiResClock.s_Default.m_ratio) + HiResClock.s_Default.m_offset);
    }
  }

  public static long TickCount64
  {
    get
    {
      return HiResClock.s_Default.m_disabled ? DateTime.UtcNow.Ticks / 10000L : (long) ((double) Stopwatch.GetTimestamp() / HiResClock.s_Default.m_ticksPerMillisecond);
    }
  }

  public static long Frequency
  {
    get => !HiResClock.s_Default.m_disabled ? HiResClock.s_Default.m_frequency : 10000000L;
  }

  public static double TicksPerMillisecond
  {
    get => !HiResClock.s_Default.m_disabled ? HiResClock.s_Default.m_ticksPerMillisecond : 10000.0;
  }

  public static bool Disabled
  {
    get => HiResClock.s_Default.m_disabled;
    set
    {
      if (!Stopwatch.IsHighResolution || HiResClock.s_Default.m_initialized)
        return;
      if (HiResClock.s_Default.m_disabled && !value)
        HiResClock.s_Default = new HiResClock();
      else
        HiResClock.s_Default.m_disabled = value;
      HiResClock.s_Default.m_initialized = true;
    }
  }

  public static void Reset() => HiResClock.s_Default = new HiResClock();

  private HiResClock()
  {
    this.m_initialized = false;
    this.m_offset = DateTime.UtcNow.Ticks;
    if (!Stopwatch.IsHighResolution)
    {
      this.m_frequency = 10000000L;
      this.m_ticksPerMillisecond = 10000.0;
      this.m_baseline = this.m_offset;
      this.m_disabled = true;
    }
    else
    {
      this.m_baseline = Stopwatch.GetTimestamp();
      this.m_frequency = Stopwatch.Frequency;
      this.m_ticksPerMillisecond = (double) this.m_frequency / 1000.0;
    }
    this.m_ratio = 10000000M / (Decimal) this.m_frequency;
  }
}
