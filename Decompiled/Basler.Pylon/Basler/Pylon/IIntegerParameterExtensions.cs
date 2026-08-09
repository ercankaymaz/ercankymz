using System;
using System.Runtime.InteropServices;
using gtl;

namespace Basler.Pylon;

public static class IIntegerParameterExtensions
{
	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValue(this IIntegerParameter parameter, long value, IntegerValueCorrection correction)
	{
		ScopedLock scopedLock = null;
		if (correction == IntegerValueCorrection.None)
		{
			return parameter.TrySetValue(value);
		}
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable && parameter.IsReadable)
			{
				long minimum = parameter.GetMinimum();
				long maximum = parameter.GetMaximum();
				long increment = parameter.GetIncrement();
				long value2 = global::_003CModule_003E.gtl_002ECorrectIntValue(minimum, maximum, increment, value, (EValueCorrection)correction);
				parameter.SetValue(value2);
				goto IL_006f;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return false;
		IL_006f:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValue(this IIntegerParameter parameter, long value)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable)
			{
				parameter.SetValue(value);
				goto IL_003a;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return false;
		IL_003a:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	public static long GetValueOrDefault(this IIntegerParameter parameter, long defaultValue)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		long value;
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsReadable)
			{
				value = parameter.GetValue();
				goto IL_003a;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return defaultValue;
		IL_003a:
		((IDisposable)scopedLock).Dispose();
		return value;
	}

	public static void SetValue(this IIntegerParameter parameter, long value, IntegerValueCorrection correction)
	{
		ScopedLock scopedLock = null;
		if (correction == IntegerValueCorrection.None)
		{
			parameter.SetValue(value);
			return;
		}
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			long minimum = parameter.GetMinimum();
			long maximum = parameter.GetMaximum();
			long increment = parameter.GetIncrement();
			long value2 = global::_003CModule_003E.gtl_002ECorrectIntValue(minimum, maximum, increment, value, (EValueCorrection)correction);
			parameter.SetValue(value2);
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
	}

	public static double GetValuePercentOfRange(this IIntegerParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		long minimum;
		long maximum;
		long value;
		try
		{
			scopedLock = scopedLock2;
			minimum = parameter.GetMinimum();
			maximum = parameter.GetMaximum();
			value = parameter.GetValue();
			if (minimum != maximum && value != maximum)
			{
				if (value != minimum)
				{
					goto IL_0066;
				}
				goto IL_0055;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return 100.0;
		IL_0066:
		double num2;
		try
		{
			double num = minimum;
			num2 = ((double)value - num) / ((double)maximum - num) * 100.0;
			if (!(num2 <= 100.0))
			{
				num2 = 100.0;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return num2;
		IL_0055:
		((IDisposable)scopedLock).Dispose();
		return 0.0;
	}

	public static void SetValuePercentOfRange(this IIntegerParameter parameter, double percentOfRange)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			global::_003CModule_003E.Basler_002EPylon_002ESetValuePercentOfRangeImpl(parameter, percentOfRange);
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValuePercentOfRange(this IIntegerParameter parameter, double percentOfRange)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable && parameter.IsReadable)
			{
				global::_003CModule_003E.Basler_002EPylon_002ESetValuePercentOfRangeImpl(parameter, percentOfRange);
				goto IL_0044;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return false;
		IL_0044:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	public static void SetToMaximum(this IIntegerParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			long maximum = parameter.GetMaximum();
			parameter.SetValue(maximum);
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
	}

	public static void SetToMinimum(this IIntegerParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			long minimum = parameter.GetMinimum();
			parameter.SetValue(minimum);
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetToMaximum(this IIntegerParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable && parameter.IsReadable)
			{
				long maximum = parameter.GetMaximum();
				parameter.SetValue(maximum);
				goto IL_004b;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return false;
		IL_004b:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetToMinimum(this IIntegerParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable && parameter.IsReadable)
			{
				long minimum = parameter.GetMinimum();
				parameter.SetValue(minimum);
				goto IL_004b;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return false;
		IL_004b:
		((IDisposable)scopedLock).Dispose();
		return true;
	}
}
