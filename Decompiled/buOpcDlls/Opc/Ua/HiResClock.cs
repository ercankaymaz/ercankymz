using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class HiResClock
{
	private static HiResClock s_Default = new HiResClock();

	private long m_frequency;

	private long m_baseline;

	private long m_offset;

	private double m_ticksPerMillisecond;

	private decimal m_ratio;

	private bool m_disabled;

	private bool m_initialized;

	public static DateTime UtcNow
	{
		get
		{
			if (s_Default.m_disabled)
			{
				return DateTime.UtcNow;
			}
			return new DateTime((long)((decimal)(Stopwatch.GetTimestamp() - s_Default.m_baseline) * s_Default.m_ratio) + s_Default.m_offset);
		}
	}

	public static long TickCount64
	{
		get
		{
			if (s_Default.m_disabled)
			{
				return DateTime.UtcNow.Ticks / 10000;
			}
			return (long)((double)Stopwatch.GetTimestamp() / s_Default.m_ticksPerMillisecond);
		}
	}

	public static long Frequency
	{
		get
		{
			if (!s_Default.m_disabled)
			{
				return s_Default.m_frequency;
			}
			return 10000000L;
		}
	}

	public static double TicksPerMillisecond
	{
		get
		{
			if (!s_Default.m_disabled)
			{
				return s_Default.m_ticksPerMillisecond;
			}
			return 10000.0;
		}
	}

	public static bool Disabled
	{
		get
		{
			return s_Default.m_disabled;
		}
		set
		{
			if (Stopwatch.IsHighResolution && !s_Default.m_initialized)
			{
				if (s_Default.m_disabled && !value)
				{
					s_Default = new HiResClock();
				}
				else
				{
					s_Default.m_disabled = value;
				}
				s_Default.m_initialized = true;
			}
		}
	}

	public static void Reset()
	{
		s_Default = new HiResClock();
	}

	private HiResClock()
	{
		m_initialized = false;
		m_offset = DateTime.UtcNow.Ticks;
		if (!Stopwatch.IsHighResolution)
		{
			m_frequency = 10000000L;
			m_ticksPerMillisecond = 10000.0;
			m_baseline = m_offset;
			m_disabled = true;
		}
		else
		{
			m_baseline = Stopwatch.GetTimestamp();
			m_frequency = Stopwatch.Frequency;
			m_ticksPerMillisecond = (double)m_frequency / 1000.0;
		}
		m_ratio = 10000000m / (decimal)m_frequency;
	}
}
